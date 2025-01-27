using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AudientAzure.DataModels;
using Microsoft.Extensions.ML;
using Microsoft.ML;
using System.Reflection;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Collections.Generic;

namespace AudientAzure
{
    public class Function1
    {
        private readonly PredictionEnginePool<ModelInput, ModelOutput> _predictionEnginePool;

        public Function1(PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //Parse HTTP Request Body
            var gg = req.GetQueryParameterDictionary();
            log.LogInformation($"YOLO {gg.Keys.Contains("features")}");
            var feature_list = gg["features"].Split(",");
            ModelInput data = new ModelInput();

            FieldInfo[] fi = typeof(ModelInput).GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            int ind = 0;
            foreach (FieldInfo info in fi)
            {
                log.LogInformation(info.Name);
                if (ind == 0)
                {
                    info.SetValue(data, "blues");
                }
                else
                {
                    info.SetValue(data, float.Parse(feature_list[ind]));
                }
                ind += 1;
            }

            //Make Prediction
            ModelOutput prediction = _predictionEnginePool.Predict(modelName: "GenrePredictionModel", data);
            //ModelOutput prediction = ConsumeModel.Predict(data);
            //Convert prediction to string
            string scores = String.Empty;
            //Hacky way of assigning labels, fix this in the next build.
            var genreList = new List<string> {"Blues","Classical","Country","Disco","HipHop","Jazz","Metal","Pop","Reggae","Rock"};
            var tempList = new List<Genre>();
            ind = 0;
            foreach(float acc in prediction.Score)
            {
                var tempGenre = new Genre();
                tempGenre.Label = genreList[ind];
                tempGenre.Score = acc;
                tempList.Add(tempGenre);
                ind += 1;
            }
            //var tempGenre2 = new Genre();
            //tempGenre2.Label = $"Prediction: {prediction.Prediction}";
            //tempGenre2.Score = 100;
            tempList.Add(tempGenre2);
            string response = JsonConvert.SerializeObject(tempList);
            //string response = "HELLO WORLD";
            //Return Prediction

            return (ActionResult)new OkObjectResult(response);
        }
    }
}

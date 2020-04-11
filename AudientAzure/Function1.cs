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
            foreach(float acc in prediction.Score)
            {
                scores = $"{scores},{acc}";
            }
            string response = $"{prediction.Prediction}{scores}";
            //string response = "HELLO WORLD";
            //Return Prediction

            return (ActionResult)new OkObjectResult(response);
        }
    }
}

using System;
using System.IO;
using Microsoft.Extensions.ML;
using Microsoft.Azure;
using AudientAzure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using AudientAzure.DataModels;

[assembly: FunctionsStartup(typeof(Startup))]
namespace AudientAzure
{
    public class Startup : FunctionsStartup
    {
        private readonly string _environment;
        private readonly string _modelPath;

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddPredictionEnginePool<ModelInput, ModelOutput>()
        .FromFile(modelName: "GenrePredictionModel", filePath: _modelPath, watchForChanges: true);
        }

        public Startup()
        {
            _environment = Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT");

            if (_environment == "Development")
            {
                _modelPath = Path.Combine("MLModels", "MLModel.zip");
            }
            else
            {
                string deploymentPath = @"D:\home\site\wwwroot\";
                _modelPath = Path.Combine(deploymentPath, "MLModels", "MLModel.zip");
            }
        }
    }
}

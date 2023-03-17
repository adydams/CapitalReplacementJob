using CapitalReplacementJob;
using CapitalReplacementJob.Repository;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(StartUp))]

namespace CapitalReplacementJob
{
    public class StartUp: FunctionsStartup
    {
        private static readonly IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Environment.CurrentDirectory)
          .AddJsonFile("appsettings.json", true)
          .AddEnvironmentVariables()
          .Build();

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IImageVideo, ImageVideoRepo>();
            builder.Services.AddScoped<IApplication, ApplicationRepo>();

            builder.Services.AddSingleton(s =>
            {
                var connectionString = configuration["CosmosDBConnection"];
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException(
                        "Please specify a valid CosmosDBConnection in the appSettings.json file or your Azure Functions Settings.");
                }
                return new CosmosClientBuilder(connectionString)
                    .Build();
            });
           

        }
    }
}

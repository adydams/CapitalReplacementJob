using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Cosmos;
using CapitalReplacementJob.Model;
using System.Linq;
using static CapitalReplacementJob.Model.WorkFlowModel;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using Microsoft.Extensions.Options;
using CapitalReplacementJob.Helper;
using CapitalReplacementJob.Repository;
using System.Web.Http;

namespace CapitalReplacementJob
{
    
    public class CapitalReplacementApi
    {
          
        private readonly IApplication _application;
        //dependency injection
        public CapitalReplacementApi(CosmosClient cosmosClient, IHostingEnvironment env, IApplication application)
        {
           _application = application;
        }

        [FunctionName("GetApplications")]
        public async Task<IActionResult> GetApplications(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetApplications")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# Getting all applications.");

            return await _application.GetApplications();
          
        }

       
        [FunctionName("GetApplicationById")]
        public async Task<IActionResult> GetApplicationById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetApplicationbyId/{id}/{category}")] HttpRequest req,
            ILogger log, string id, string category)
        {
            log.LogInformation($"C# Getting applications by Id:{id}.");

            return await _application.GetApplicationbyId(id, category);
        }


        [FunctionName("CreateApplication")]
        public async Task<IActionResult> CreateApplication(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "CreateApplication")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"C# Creating application.");
          
            string requestdata =  await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<ApplicationModel>(requestdata);
            return await _application.CreateApplication(data);                       
        }

        [FunctionName("UpdateApplication")]
        public async Task<IActionResult> UpdateApplication(
          [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "UpdateApplication/{id}/{category}")] HttpRequest req,
          ILogger log, string id, string category)
        {
            log.LogInformation($"C# Updating application.");


            string requestdata = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<ApplicationModel>(requestdata);
            return await _application.UpdateApplication(data, id, category);          

        }


        [FunctionName("DeleteApplication")]
        public async Task<IActionResult> DeleteApplication(
         [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "DeleteApplication/{id}/{category}")] HttpRequest req,
         ILogger log, string id, string category)
        {
        
            log.LogInformation($"Delete application with ID: {id}");
            return await _application.DeleteApplication(id, category);
           
        }

    }
}

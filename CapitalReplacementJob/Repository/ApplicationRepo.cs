using Azure;
using CapitalReplacementJob.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using static System.Net.Mime.MediaTypeNames;

namespace CapitalReplacementJob.Repository
{
    public class ApplicationRepo : IApplication
    {
        private readonly CosmosClient _cosmosClient;
        private Container documentContainer;
        private readonly IHostingEnvironment _env;
        private readonly FileStream fileStream;
        private readonly string DefaultRoot, DefaultRootAbsolute;
        private readonly IImageVideo _imageVideo;
        public ApplicationRepo(CosmosClient cosmosClient, IHostingEnvironment env, IImageVideo imageVideo)
        {
            _cosmosClient = cosmosClient;
            documentContainer = _cosmosClient.GetContainer("CapitalReplacement", "Applications");
            _env = env;
            if (string.IsNullOrWhiteSpace(_env.WebRootPath))
            {
                env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }
            DefaultRoot = _env.WebRootPath;
            DefaultRootAbsolute = new Uri(DefaultRoot).AbsoluteUri;
            _imageVideo = imageVideo;
        }
        public async Task<IActionResult> CreateApplication(ApplicationModel data)
        {

            if (data.VideoInterview.Count > 3)
            {
                return new BadRequestErrorMessageResult("Video interview questions cannot be more than 3");
            }


            var application = new ApplicationModel()
            {
                Category = data.Category,
                Title = data.Title,
                Summary = data.Summary,
                Description = data.Description,
                Benefits = data.Benefits,
                Criteria = data.Criteria,
                Skils = data.Skils,
                Type = data.Type,
                Open = data.Open,
                Close = data.Close,
                Start = data.Start,
                Location = data.Location,
                DurationInMonths = data.DurationInMonths,
                MinimumQualification = data.MinimumQualification,
                MaxNumOfApplication = data.MaxNumOfApplication,
                Image = _imageVideo.ImageAndVideoToUrlService(data.Image, data.Title, data.Id),
                Firstname = data.Firstname,
                LastName = data.LastName,
                Email = data.Email,
                Phone = data.Phone,
                Nationality = data.Nationality,
                CurrentResidence = data.CurrentResidence,
                IDNumber = data.IDNumber,
                DateOfBirth = data.DateOfBirth,
                Gender = data.Gender,
                PersonalInformationQuestions = data.PersonalInformationQuestions,
                Education = data.Education,
                Experience = data.Experience,
                Resume = data.Resume,
                ProfileQuestions = data.ProfileQuestions,
                Name = data.Name,
                VideoType = data.VideoType,
                DisplayStageToCandidate = data.DisplayStageToCandidate,
                VideoInterview = data.VideoInterview

            };
            try
            {
                await documentContainer.CreateItemAsync(application, new Microsoft.Azure.Cosmos.PartitionKey(data.Category));
                return new OkObjectResult(application);

            }
            catch (Exception e)
            {

                throw e;
            }


        }

        public async Task<IActionResult> GetApplications()
        {

            try
            {
                var response = documentContainer.GetItemQueryIterator<ApplicationModel>();
                return new OkObjectResult((await response.ReadNextAsync()).ToList());
            }
            catch (CosmosException e) when (e.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw e;
            }
        }

        public async Task<IActionResult> GetApplicationbyId(string id, string category)

        {
            try
            {
                var response = await documentContainer.ReadItemAsync<ApplicationModel>(id, new Microsoft.Azure.Cosmos.PartitionKey(category));
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new NotFoundResult();
                }
                return new OkObjectResult(response.Resource);
            }
            catch (CosmosException e)
            {

                throw e;
            }
        }
        public async Task<IActionResult> UpdateApplication(ApplicationModel data, string id, string category)

        {
            var application = await documentContainer.ReadItemAsync<ApplicationModel>(id, new Microsoft.Azure.Cosmos.PartitionKey(category));

            if (application.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new NotFoundResult();
            }

            application.Resource.Id = id;
            application.Resource.Category = data.Category;
            application.Resource.Title = data.Title;
            application.Resource.Summary = data.Summary;
            application.Resource.Description = data.Description;
            application.Resource.Benefits = data.Benefits;
            application.Resource.Criteria = data.Criteria;
            application.Resource.Skils = data.Skils;
            application.Resource.Type = data.Type;
            application.Resource.Open = data.Open;
            application.Resource.Close = data.Close;
            application.Resource.Start = data.Start;
            application.Resource.Location = data.Location;
            application.Resource.DurationInMonths = data.DurationInMonths;
            application.Resource.MinimumQualification = data.MinimumQualification;
            application.Resource.MaxNumOfApplication = data.MaxNumOfApplication;
            application.Resource.Image = data.Image;
            application.Resource.Firstname = data.Firstname;
            application.Resource.LastName = data.LastName;
            application.Resource.Email = data.Email;
            application.Resource.Phone = data.Phone;
            application.Resource.Nationality = data.Nationality;
            application.Resource.CurrentResidence = data.CurrentResidence;
            application.Resource.IDNumber = data.IDNumber;
            application.Resource.DateOfBirth = data.DateOfBirth;
            application.Resource.Gender = data.Gender;
            application.Resource.PersonalInformationQuestions = data.PersonalInformationQuestions;
            application.Resource.Education = data.Education;
            application.Resource.Experience = data.Experience;
            application.Resource.Resume = data.Resume;
            application.Resource.ProfileQuestions = data.ProfileQuestions;
            application.Resource.Name = data.Name;
            application.Resource.VideoType = data.VideoType;
            application.Resource.DisplayStageToCandidate = data.DisplayStageToCandidate;
            application.Resource.VideoInterview = data.VideoInterview;


            try
            {
                await documentContainer.UpsertItemAsync(application.Resource);
                return new OkObjectResult(application.Resource);

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<IActionResult> DeleteApplication(string id, string category)
        {
            var item = await documentContainer.ReadItemAsync<ApplicationModel>(id, new Microsoft.Azure.Cosmos.PartitionKey(category));

            if (item.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new NotFoundResult();
            }
            await documentContainer.DeleteItemAsync<ApplicationModel>(id, new Microsoft.Azure.Cosmos.PartitionKey(category));
            return new OkResult();
        }
       

    }
}

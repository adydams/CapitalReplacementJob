using CapitalReplacementJob;
using CapitalReplacementJob.Model;
using CapitalReplacementJob.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Spatial;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System.Reflection;
using Xunit.Sdk;
using static CapitalPlacementApiTest.UnitTest1;
using static System.Net.Mime.MediaTypeNames;

namespace CapitalPlacementApiTest
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    var result = CapitalReplacementJob.Function1.Run(UnitTestFactory.GetHttpRequest(), null);
        //    Assert.IsNotNull(result);
        //    //var result = await CapitalReplacementApi.GetApplications(UnitTestFactory.GetHttpRequest());
        //    var expectedValue = "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.";
        //    var actualValue = ((OkObjectResult)result.Result).Value.ToString();
        //    Assert.IsNotNull(actualValue);
        //    Assert.AreEqual(expectedValue, actualValue);
        //}


        [TestMethod]
        public void TestCreateApplication()
        {
            //mock implementation of service using Moq with expected behavior
            var serviceMock = Mock.Of<IApplication>();
            //the system under test
            var sut = new CapitalReplacementApi(serviceMock);
            //Act
            var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
            Task<IActionResult> result = sut.CreateApplication(UnitTestFactory.HttpRequest(), logger);//exercise method under test

            //Assert
            Assert.IsNotNull(result);//verify that expectations have been met

            // Assert
            //Assert.IsNotNull(result.Result);
            //var presentations = result.Result as ApplicationModel;
            //Assert.IsNotNull(presentations);
        }

        [TestMethod]
        public void TestGetApplication()
        {            
            //mock implementation of service using Moq with expected behavior
            var serviceMock = Mock.Of<IApplication>();
            //the system under test
            var sut = new CapitalReplacementApi(serviceMock);
            //Act
            var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
            Task<IActionResult> result =  sut.GetApplications(UnitTestFactory.GetHttpRequest(), logger);//exercise method under test

            //Assert
            Assert.IsNotNull(result);//verify that expectations have been met
                                   
            //var presentations = result.Result as List<ApplicationModel>;
            //Assert.IsNotNull(presentations);
        }

        [TestMethod]
        public void TestGetApplicationById()
        {
            //mock implementation of service using Moq with expected behavior
            var serviceMock = Mock.Of<IApplication>();
            //the system under test
            var sut = new CapitalReplacementApi(serviceMock);
            //Act
            var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
            string id = "952fb805-7f33-4b4f-8dba-0ad9f7f854c0";
            string category = "Job test";
            var result = sut.GetApplicationById(UnitTestFactory.GetHttpRequest(), logger, id, category);//exercise method under test

            //Assert
            Assert.IsNotNull(result);//verify that expectations have been met
        }


    }

}
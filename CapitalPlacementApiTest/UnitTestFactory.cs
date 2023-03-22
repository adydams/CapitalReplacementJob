using CapitalReplacementJob.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementApiTest
{
    public class UnitTestFactory
    {
        public static HttpRequest GetHttpRequest()
        {
            var context = new DefaultHttpContext();
            return context.Request;
        }

        public static HttpRequest HttpRequest()
        {
            var httpContext = new DefaultHttpContext();

            var json = JsonConvert.DeserializeObject("{ 'Category': 'Remote Job',  'Title ': 'Test title 2 ', 'Summary ': 'Test Summary ',  'Description ': 'Test description ', 'Skils ': 3, 'Benefits ': 'Test benefits ', 'Criteria ': 'Test criteria ', 'Type ': 1, 'Start ': '2023-03-16 ',        'Open ': '2023-03-16 ',        'Close ': '2023-04-16 ',        'DurationInMonths ':6,        'Location ':2, 'MinimumQualification ':3, 'MaxNumOfApplication ':1, 'Image ': '' , 'Firstname ': 'Test firstname ', 'LastName ':  'Test last name ', 'Email ': 'Test@email.com ', 'Phone ': '12345678 ', 'Nationality ':  'Nigeria ', 'CurrentResidence ': 'Lagos ', 'IDNumber ': '887766578 ', 'DateOfBirth ': '2000-05-16 ', 'Gender ':2,          'PersonalInformationQuestions ':[             {              'QuestionType ': 1,              'Question ':  'test question here ',              'MaxChoiceAllowed ': 2             },               {              'QuestionType ': 2,              'Question ':  'test question2  here ',               'MaxChoiceAllowed ': 1             }   ],          'Education ': 'Computer science ',        'Experience ':  '2 ',        'Resume ':  'test question2  here ',          'ProfileQuestions ':[          {            'QuestionType ': 1,            'Question ':  'test question here ',            'MaxChoiceAllowed ': 2           },            {            'QuestionType ': 2,            'Question ':  'test question2  here ',            'MaxChoiceAllowed ': 1           } ],          'Name ':  'Test name ',         'VideoType ':  'Test name ',         'Placement ':  'Test name ',         'DisplayStageToCandidate ': true,         'VideoInterview ': [            { 'InterviewQuestion ':  'test intervies question ', 'DurationInSec ': 45, 'DeadlineInDays ': 5   }, {  'InterviewQuestion ':  'test intervies question ',    'DurationInSec ': 45,  'DeadlineInDays ': 5         } ]   }");
           
        
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( json )));
            httpContext.Request.Body = stream;
            httpContext.Request.ContentLength = stream.Length;
            httpContext.Request.ContentType = "application/json";

            return httpContext.Request;

        }


    }
}

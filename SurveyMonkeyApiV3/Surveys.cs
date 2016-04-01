using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyMonkeyApiV3.Models;
using SurveyMonkeyApiV3.Models.Responses;
using SurveyMonkeyApiV3.Modules.Networking;

namespace SurveyMonkeyApiV3
{
    public class Surveys
    {
        public static async Task<List<Survey>> GetSurveys()
        {
            SurveyResponse response = await SurveyMonkeyRequest.GetRequest<SurveyResponse>("/surveys");
            return response.data;
        }

        public static async Task<SurveyDetails> GetSurveyDetails(long surveyId)
        { 
            SurveyDetails response = await SurveyMonkeyRequest.GetRequest<SurveyDetails>(string.Format("/surveys/{0}", surveyId));
            return response;
        }

        public static async Task<SurveyDetails> GetSurveyDetailsExpanded(long surveyId)
        {
            SurveyDetails response = await SurveyMonkeyRequest.GetRequest<SurveyDetails>(string.Format("/surveys/{0}/details", surveyId));
            return response;
        }
         
        public static async Task<List<Page>> GetSurveyPages(long surveyId)
        {
            PageResponse response = await SurveyMonkeyRequest.GetRequest<PageResponse>(string.Format("/surveys/{0}/pages", surveyId));
            return response.data;
        }

        public static async Task<Page> GetSurveyPageDetails(long surveyId, long pageId)
        {
            Page response = await SurveyMonkeyRequest.GetRequest<Page>(string.Format("/surveys/{0}/pages/{1}", surveyId, pageId));
            return response;
        }
    }
}

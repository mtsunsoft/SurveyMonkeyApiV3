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

        public static async Task<List<Question>> GetSurveyPageQuestions(long surveyId, long pageId)
        {
            QuestionsResponse response = await SurveyMonkeyRequest.GetRequest<QuestionsResponse>(string.Format("/surveys/{0}/pages/{1}/questions", surveyId, pageId));
            return response.data;
        } 

        public static async Task<Question> GetSurveyPageQuestionDetails(long surveyId, long pageId, long questionId)
        {
            Question response = await SurveyMonkeyRequest.GetRequest<Question>(string.Format("/surveys/{0}/pages/{1}/questions/{2}", surveyId, pageId, questionId));
            return response;
        }

        public static async Task<List<Collector>> GetSurveyCollectors(long surveyId)
        {
            BaseResponse<Collector> response = await SurveyMonkeyRequest.GetRequest<BaseResponse<Collector>>(string.Format("/surveys/{0}/collectors", surveyId));
            return response.data;
        } 
    }
}

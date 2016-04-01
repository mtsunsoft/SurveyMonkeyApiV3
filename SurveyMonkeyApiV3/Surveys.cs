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
    }
}

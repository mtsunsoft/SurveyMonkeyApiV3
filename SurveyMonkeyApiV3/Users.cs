using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyMonkeyApiV3.Models;
using SurveyMonkeyApiV3.Networking;

namespace SurveyMonkeyApiV3
{
    public class Users
    {
        public static async Task<Me> GetSurveys()
        {
            Me response = await SurveyMonkeyRequest.GetRequest<Me>("/users/me");
            return response;
        }
    }
}

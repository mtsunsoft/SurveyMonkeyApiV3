using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SurveyMonkeyApiV3.Services;

namespace SurveyMonkeyApiV3
{
    public class SurveyMonkey
    {
        public static string ApiKey { get; set; }
        public static string AuthToken { get; set; }
        public static SurveyService Survey { get; set; }
    }
}

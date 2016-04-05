using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace SurveyMonkeyApiV3
{
    public class SurveyMonkey
    {
        public static string ApiKey { get; set; }
        public static string AuthToken { get; set; }
        public static int Throttle = 1000;
    }
}

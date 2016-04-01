using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyMonkeyApiV3.Models
{
    public class Me
    {
        public long id { get; set; }
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string language { get; set; }
        public string email { get; set; }
        public string account_type { get; set; }
        public string date_created { get; set; }
        public string date_last_login { get; set; }
    }
}

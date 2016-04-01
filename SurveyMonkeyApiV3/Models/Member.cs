using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyMonkeyApiV3.Models
{
    public class Member
    {
        public string id { get; set; }
        public string username { get; set; }
        public string href { get; set; }
    }

    public class MemberDetail
    { 
        public string id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string user_id { get; set; }
        public string date_created { get; set; }
    }
}

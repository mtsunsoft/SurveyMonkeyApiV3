using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyMonkeyApiV3.Models
{
    public class Group
    {
        public string id { get; set; }
        public string name { get; set; }
        public string href { get; set; }
    }

    public class GroupDetail 
    {
        public string id { get; set; }
        public string name { get; set; }
        public int member_count { get; set; }
        public int max_invites { get; set; }
        public string date_created { get; set; }
        public string owner_email { get; set; }
    }
}

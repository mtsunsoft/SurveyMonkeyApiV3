using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyMonkeyApiV3.Models
{
    public class ContactList
    {
        public string href { get; set; }
        public long id { get; set; }
        public string name { get; set; }
    }

    public class Contact
    {
        public string href { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public long id { get; set; }
        public string email { get; set; }
        public Dictionary<string, string> custom_fields { get; set; } 
    }

    public class ContactField
    { 
        public string href { get; set; }
        public long id { get; set; }
        public string label { get; set; }
    }
}

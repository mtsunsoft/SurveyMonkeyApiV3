using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyMonkeyApiV3.Models
{
    public class MessageResponse
    {
        public int total_time { get; set; }
        public string collection_mode { get; set; }
        public string href { get; set; }
        public Dictionary<string, string> custom_variables { get; set; }
        public string ip_address { get; set; }
        public List<Page> pages { get; set; }
        public string date_modified { get; set; }
        public string response_status { get; set; }
        public string custom_value { get; set; }
        public long id { get; set; }
        public string collector_id { get; set; }
        public string recipient_id { get; set; }
        public string date_created { get; set; }
        public long survey_id { get; set; } 
        public bool survey_completed { get; set; }
        public string email_address { get; set; }
        public object logic_path { get; set; }
        public object metadata { get; set; }
        public string current_page_id { get; set; }
        public List<object> page_path { get; set; }
        public int survey_version { get; set; }
    }


}

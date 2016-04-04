using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyMonkeyApiV3.Models
{
    public class Collector
    {
        public string status { get; set; }
        public long id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string thank_you_message { get; set; }
        public string disqualification_message { get; set; }
        public string close_date { get; set; }
        public string closed_page_message { get; set; }
        public string redirect_url { get; set; }
        public bool display_survey_results { get; set; }
        public string edit_response_type { get; set; }
        public string anonymous_type { get; set; }
        public bool allow_multiple_responses { get; set; }
        public string date_modified { get; set; }
        public string url { get; set; }
        public bool open { get; set; }
        public string date_created { get; set; }
        public bool password_enabled { get; set; }
        public string href { get; set; } 
    }

    public class Message
    {
        public string status { get; set; }
        public bool is_scheduled { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public bool is_branding_enabled { get; set; }
        public string date_created { get; set; }
        public string type { get; set; }
        public long id { get; set; }
        public string href { get; set; }
    }

    public class CreateMessage
    {
        public string type { get; set; } 
        public string subject { get; set; }
        public string body_text { get; set; }
        public string body_html { get; set; }
        public bool is_branding_enabled { get; set; }
    }


    public class Recipient
    {
        public string survey_response_status { get; set; }
        public string mail_status { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Dictionary<string, string> custom_fields { get; set; }
        public long id { get; set; }
        public string remove_link { get; set; }
        public Dictionary<string, string> extra_fields { get; set; } 
        public string survey_link { get; set; }
        public string href { get; set; }
    }

    public class CreateRecipient
    {
        public string contact_id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Dictionary<string, string> custom_fields { get; set; }
        public Dictionary<string, string> extra_fields { get; set; } 
    }
}

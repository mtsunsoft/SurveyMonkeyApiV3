using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyMonkeyApiV3.Models
{
    public class Survey
    {
        public string href { get; set; }
        public long id { get; set; }
        public string title { get; set; }
    }

    public class ButtonsText
    {
        public string done_button { get; set; }
        public string prev_button { get; set; }
        public string exit_button { get; set; }
        public string next_button { get; set; }
    }

    public class SurveyDetails
    {
        public string title { get; set; }
        //public List<string> custom_variables { get; set; }
        public string language { get; set; }
        public int question_count { get; set; }
        public int page_count { get; set; }
        public string date_created { get; set; }
        public string date_modified { get; set; }
        public long id { get; set; }
        public string href { get; set; }
        public ButtonsText buttons_text { get; set; }
        public List<Page> pages { get; set; }
    }

    public class Page
    {
        public string title { get; set; }
        public string description { get; set; }
        public int position { get; set; }
        public int question_count { get; set; }
        public long id { get; set; }
        public string href { get; set; }
        public List<Question> questions { get; set; } 
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyMonkeyApiV3.Models
{
    public class Question
    {
        public int position { get; set; }
        public string href { get; set; }
        public string heading { get; set; }
        public string id { get; set; }
    }

    public class Heading
    {
        public string heading { get; set; }
    }

    public class Choice
    {
        public bool visible { get; set; }
        public bool required { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public int position { get; set; }
    }

    public class Col
    {
        public List<Choice> choices { get; set; }
        public string text { get; set; }
    }

    public class Validation
    {
        public string text { get; set; }
        public string type { get; set; }
        public int sum { get; set; }
        public string sum_text { get; set; }
        public object min { get; set; }
        public object max { get; set; }
    }

    public class Answers
    {
        public List<Choice> choices { get; set; }
        public List<Choice> rows { get; set; }
        public List<Col> cols { get; set; }
    }

    public class QuestionDetails
    {
        public List<Heading> headings { get; set; }
        public int position { get; set; }
        public string family { get; set; }
        public string subtype { get; set; }
        public Answers answers { get; set; }
        public bool forced_ranking { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyMonkeyApiV3.Models
{
    public class SurveyTemplate
    {
        public string category { get; set; }
        public string name { get; set; }
        public bool available { get; set; }
        public long id { get; set; }
    }
}

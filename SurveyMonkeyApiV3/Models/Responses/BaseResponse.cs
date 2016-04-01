using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyMonkeyApiV3.Models.Responses
{
    public class BaseResponse<T>
    {
        public List<T> data { get; set; }
        public int per_page { get; set; }
        public int page { get; set; }
    }
}

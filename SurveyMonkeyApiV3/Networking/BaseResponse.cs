using System.Collections.Generic;

namespace SurveyMonkeyApiV3.Networking
{
    public class BaseResponse<T>
    {
        public List<T> data { get; set; }
        public int per_page { get; set; }
        public int page { get; set; }
    }
}

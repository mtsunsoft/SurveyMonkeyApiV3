using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
using Newtonsoft.Json;
using SurveyMonkeyApiV3.Helpers;

namespace SurveyMonkeyApiV3.Networking
{
    public class SurveyMonkeyRequest
    {
        private static string BaseUrl = "https://api.surveymonkey.net/v3";

        private static string RequestContentTypeValue = "application/json";

        private static void Throttle()
        {
            using (EventWaitHandle tmpEvent = new ManualResetEvent(false))
            {
                tmpEvent.WaitOne(TimeSpan.FromMilliseconds(SurveyMonkey.Throttle));
            } 
        }

        private static async Task<T> DeserializeServerResponse<T>(HttpResponseMessage response)
        {
            string responseStr = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseStr);
        }

        public static HttpContent GetHttpContent(object parameters)
        {
            HttpContent content = null;
            if (parameters != null)
            {
                string paramStr;
                if (parameters is Dictionary<object, object>)
                {
                    Dictionary<object, object> parameterDict = parameters as Dictionary<object, object>;
                    paramStr = JsonConvert.SerializeObject(parameterDict,
                            Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
                }
                else if (parameters is string)
                {
                    paramStr = parameters.ToString();
                }
                else
                {
                    paramStr = JsonConvert.SerializeObject(parameters, 
                            Formatting.None, 
                            new JsonSerializerSettings { 
                                NullValueHandling = NullValueHandling.Ignore
                            });
                }
                content = new StringContent(paramStr, Encoding.UTF8, RequestContentTypeValue);
            }

            return content;
        }

        public static void AddDefaultHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SurveyMonkey.AuthToken );
        }

        public static string GetParamsFromDict(Dictionary<object, object> urlParams)
        {
            return string.Format("{0}", string.Join("&", urlParams.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value))));
        }

        public static async Task<T> DeleteRequest<T>(string url, Dictionary<object, object> urlParams = null)
        {
            Throttle();
            using (HttpClient client = new HttpClient())
            {
                AddDefaultHeaders(client);
                if(urlParams == null) urlParams = new Dictionary<object, object>();
                urlParams.Add("api_key", SurveyMonkey.ApiKey);
                HttpResponseMessage response = await client.DeleteAsync(BaseUrl + url + "?" + GetParamsFromDict(urlParams));

                return await DeserializeServerResponse<T>(response);
            }
        }


        public static async Task<T> GetRequest<T>(string url, Dictionary<object, object> urlParams = null )
        {
            Throttle();
            using (HttpClient client = new HttpClient())
            {
                AddDefaultHeaders(client);
                if (urlParams == null) urlParams = new Dictionary<object, object>();
                urlParams.Add("api_key", SurveyMonkey.ApiKey);
                HttpResponseMessage response = await client.GetAsync(BaseUrl + url + "?" + GetParamsFromDict(urlParams));
                return await DeserializeServerResponse<T>(response);
            }
        }

        public static async Task<T> PostRequest<T>(string url, object bodyParams, Dictionary<object, object> urlParams = null )
        {
            Throttle();
            using (HttpClient client = new HttpClient())
            {
                AddDefaultHeaders(client);
                if (urlParams == null) urlParams = new Dictionary<object, object>();
                urlParams.Add("api_key", SurveyMonkey.ApiKey);
                HttpContent content = GetHttpContent(bodyParams);
                HttpResponseMessage response = await client.PostAsync(BaseUrl + url + "?" + GetParamsFromDict(urlParams), content);
                return await DeserializeServerResponse<T>(response);
            }
        }

        public static async Task<T> PutRequest<T>(string url, Dictionary<object, object> bodyParams, Dictionary<object,object> urlParams = null )
        {
            Throttle();
            using (HttpClient client = new HttpClient())
            {
                AddDefaultHeaders(client);
                if (urlParams == null) urlParams = new Dictionary<object, object>();
                urlParams.Add("api_key", SurveyMonkey.ApiKey);
                HttpContent content = GetHttpContent(bodyParams);
                HttpResponseMessage response = await client.PutAsync(BaseUrl + url + "?" + GetParamsFromDict(urlParams), content);
                return await DeserializeServerResponse<T>(response);
            }
        }

        public static async Task<T> PatchRequest<T>(string url, object bodyParams, Dictionary<object, object> urlParams = null)
        {
            Throttle();
            using (HttpClient client = new HttpClient())
            {
                AddDefaultHeaders(client);
                if (urlParams == null) urlParams = new Dictionary<object, object>();
                urlParams.Add("api_key", SurveyMonkey.ApiKey);
                HttpContent content = GetHttpContent(bodyParams);
                HttpResponseMessage response = await client.PatchAsync(BaseUrl + url + "?" + GetParamsFromDict(urlParams), content);
                return await DeserializeServerResponse<T>(response);
            }
        }
    }
}

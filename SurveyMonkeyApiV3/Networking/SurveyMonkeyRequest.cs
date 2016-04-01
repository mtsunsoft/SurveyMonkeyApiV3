﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SurveyMonkeyApiV3.Models.Responses;
using Newtonsoft.Json;

namespace SurveyMonkeyApiV3.Modules.Networking
{
    public class SurveyMonkeyRequest
    {
        private static string BaseUrl = "https://api.surveymonkey.net/v3";

        private static string RequestContentTypeValue = "application/json";

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
                    paramStr = JsonConvert.SerializeObject(parameterDict);
                }
                else
                {
                    paramStr = parameters as string;
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
            using (HttpClient client = new HttpClient())
            {
                AddDefaultHeaders(client);
                if (urlParams == null) urlParams = new Dictionary<object, object>();
                urlParams.Add("api_key", SurveyMonkey.ApiKey);
                HttpResponseMessage response = await client.GetAsync(BaseUrl + url + "?" + GetParamsFromDict(urlParams));
                return await DeserializeServerResponse<T>(response);
            }
        }

        public static async Task<T> PostRequest<T>(string url, Dictionary<object, object> bodyParams, Dictionary<object, object> urlParams = null )
        {
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
    }
}
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GameOnServices.ProxyServices
{
    public class ApiHelper : IApiHelper
    {
        private string _baseUrl;
        private string _apiKey;

        public ApiHelper()
        {
            _baseUrl = ConfigurationManager.AppSettings["GaintBombUrl"];
            _apiKey = string.Format("?api_key={0}", ConfigurationManager.AppSettings["ApiKey"]);
        }
        public dynamic GetData(Type responseType, string apiPath, string queryParams)
        {            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();              

                string completeDomainUrl = string.Format("{0}{1}{2}{3}",
                    _baseUrl, apiPath , _apiKey, queryParams??string.Empty);

                HttpResponseMessage jsonResponseMessage = client.GetAsync(completeDomainUrl).Result;

                if (jsonResponseMessage.IsSuccessStatusCode)
                {
                    var responseJson = jsonResponseMessage.Content.ReadAsStringAsync().Result;
                    string jObjAsString = JObject.Parse(responseJson).ToString();
                    
                    return JsonConvert.DeserializeObject(jObjAsString, responseType);
                }
                else
                {
                    throw new ApplicationException("API reponse returned failure status code.");
                }
            }
        }
    }
}
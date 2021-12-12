using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using iParaClientService.Domain;
using Newtonsoft.Json;

namespace iParaClientService.Utils
{
    public class RestHttpCallerHelpers : IDisposable
    {
        

        public T GetJson<T>(String url)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(url).Result;

            return JsonConvert.DeserializeObject<T>(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }


        /// <summary>
        /// Alanların Json olarak post edilmesine olanak sağlar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public T PostJson<T>(String url, WebHeaderCollection headers, AbstractiParaRequestBase request)
        {
            HttpClient httpClient = new HttpClient();
            foreach (String key in headers.Keys)
            {
                httpClient.DefaultRequestHeaders.Add(key, headers.Get(key));
            }
            HttpResponseMessage httpResponseMessage = httpClient.PostAsync(url, JsonBuilderHelpers.ToJsonString(request)).Result;
            var a = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(a);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

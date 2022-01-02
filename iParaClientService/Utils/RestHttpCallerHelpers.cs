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
            HttpResponseMessage httpResponseMessage = httpClient.PostAsync(url, JsonBuilderHelpers.ToJsonStringContent(request)).Result;
            var a = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(a);
        }

        /// <summary>
        /// Xml olarak post edilmesi istenen istek sınıflarında gönderilen değerlerin xml olarak post edilmesine
        /// imkan sağlayan metodu temsil eder.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public T PostXML<T>(String url, WebHeaderCollection headers, AbstractiParaRequestBase request)
        {
            HttpClient httpClient = new HttpClient();
            foreach (String key in headers.Keys)
            {
                httpClient.DefaultRequestHeaders.Add(key, headers.Get(key));
            }
            var xml = XmlBuilderHelpers.SerializeToXMLString(request);
            HttpResponseMessage httpResponseMessage = httpClient.PostAsync(url, xml).Result;
            var a = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return XmlBuilderHelpers.DeserializeObject<T>(a);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

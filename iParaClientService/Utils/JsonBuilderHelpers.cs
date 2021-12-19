using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using iParaClientService.Constant;
using iParaClientService.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace iParaClientService.Utils
{
    public class JsonBuilderHelpers
    {
        public static string SerializeToJsonString(AbstractiParaRequestBase request)
        {
            return JsonConvert.SerializeObject(request, new JsonSerializerSettings()
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        public static StringContent ToJsonStringContent(AbstractiParaRequestBase request)
        {
            return new StringContent(SerializeToJsonString(request), Encoding.Unicode, HeaderConstant.ApplicationJson);
        }
    }
}

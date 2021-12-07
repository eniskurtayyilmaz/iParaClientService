using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParaClientService.Constant
{
    public static class ExceptionMessagesConstant
    {
        public static class iParaConnectionSettingsExceptionMessages
        {

            public const string BaseUrlNotBeNullOrEmpty = "BaseUrl bilgisi null veya empty olamaz";
            public const string PublicKeyNotBeNullOrEmpty = "PublicKey bilgisi null veya empty olamaz";
            public const string PrivateKeyNotBeNullOrEmpty = "PrivateKey bilgisi null veya empty olamaz";
            public const string VersionNotBeNullOrEmpty = "Versiyon bilgisi null veya empty olamaz";

        }

        public static class iParaClientServiceConnectionExceptionMessages
        {

            public const string ParaConnectionSettings = "ParaConnectionSettings bilgisi null veya empty olamaz";

        }


    }
}

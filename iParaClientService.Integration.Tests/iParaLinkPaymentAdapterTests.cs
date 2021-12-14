using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using iParaClientService.Adapter;
using iParaClientService.Model;
using iParaClientService.Model.Request;
using iParaClientService.Service;

namespace iParaClientService.Integration.Tests
{
    [TestClass]
    public class iParaLinkPaymentAdapterTests
    {
        private string publicKey;
        private string privateKey;

        [TestInitialize]
        public void Setup()
        {
            this.publicKey = Environment.GetEnvironmentVariable("IPARA_PUBLICKEY");
            this.privateKey = Environment.GetEnvironmentVariable("IPARA_PRIVATEKEY");
        }

        [TestMethod]

        public void Can_Create_Link_Payment()
        {
            string baseUrl = "https://api.ipara.com/";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "1.0";

            using (var connection = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version))
            {
                var model = new iParaLinkPaymentCreateRequest
                {
                    Amount = 10,
                    ThreeD = true,
                    ClientIp = "127.0.0.1",
                    CommissionType = CommissionType.Dealer,
                    Email = "kurtayyilmaz@gmail.com",
                    SendEmail = true,
                    Name = "Kurtay",
                    Surname = "Yılmaz",
                    TcCertificate = "18946604794",
                    TaxNumber = "",
                    Echo = "",
                    Mode = "T",
                    ExpireDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd hh:mm:ss"),
                    Gsm = "5397143516",
                };
                var adapter = new iParaLinkPaymentAdapter(connection);
                var result = adapter.Execute(model);

                Assert.IsNull(result.ErrorCode);
                Assert.IsNull(result.ErrorMessage);

            }
        }

        [TestMethod]
        public void Can_Get_Test_Environment_From_GithubAction()
        {

            Assert.IsTrue(!string.IsNullOrEmpty(publicKey));
            Assert.IsTrue(!string.IsNullOrEmpty(privateKey));

        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using iParaClientService.Adapter;
using iParaClientService.Model;
using iParaClientService.Model.Request;
using iParaClientService.Service;

namespace iParaClientService.Integration.Tests
{
    [TestClass]
    public class iParaLinkPaymentCreateAdapterTests
    {
        private string publicKey;
        private string privateKey;

        [TestInitialize]
        public void Setup()
        {
            this.publicKey = Environment.GetEnvironmentVariable("IPARA_PUBLICKEY");
            this.privateKey = Environment.GetEnvironmentVariable("IPARA_PRIVATEKEY");

#if DEBUG
            this.publicKey = Environment.GetEnvironmentVariable("IPARA_PUBLICKEY", EnvironmentVariableTarget.User);

            this.privateKey = Environment.GetEnvironmentVariable("IPARA_PRIVATEKEY", EnvironmentVariableTarget.User);
#endif
        }

        [TestMethod]

        public void Can_Create_Link_Payment_Valid()
        {
            string baseUrl = "https://api.ipara.com/";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "1.0";

            using (var connection = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version))
            {
                var model = new iParaLinkPaymentCreateRequest
                {
                    ThreeD = false,
                    ClientIp = "127.0.0.1",
                    CommissionType = CommissionType.Dealer,
                    Email = "kurtayyilmaz@gmail.com",
                    SendEmail = true,
                    Name = "Kurtay",
                    Surname = "Yılmaz",
                    TcCertificate = "18946604794",
                    TaxNumber = "",
                    Echo = "",
                    //Mode = "T",
                    ExpireDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd hh:mm:ss"),
                    Gsm = "5397143516",
                };
                model.SetAmount(1);

                var adapter = new iParaLinkPaymentCreateAdapter(connection);
                var result = adapter.Execute(model);

                Trace.WriteLine(result.ErrorMessage);

                Assert.IsTrue(result.IsValid);
                Assert.IsNull(result.ErrorCode);
                Assert.IsNull(result.ErrorMessage);

                Assert.AreEqual(model.Amount, result.Amount.Value);
                Assert.IsNotNull(result.Link);
                Assert.IsNotNull(result.LinkPaymentId);
                Assert.IsNotNull(result.Result);
                Assert.IsNotNull(result.ResponseMessage);
            }
        }

        [TestMethod]

        public void Can_Create_Link_Payment_Invalid()
        {
            string baseUrl = "https://api.ipara.com/";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "1.0";

            using (var connection = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version))
            {
                var model = new iParaLinkPaymentCreateRequest
                {
                    ThreeD = true,
                    ClientIp = "127.0.0.1",
                    CommissionType = CommissionType.Dealer,
                    Email = "kurtayyilmaz@gmail.com",
                    SendEmail = true,
                    Name = "Kurtay",
                    Surname = "Yılmaz",
                    TcCertificate = "",
                    TaxNumber = "",
                    Echo = "",
                    //Mode = "T",
                    ExpireDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd hh:mm:ss"),
                    Gsm = "53143516",
                };
                model.SetAmount(0.10);
                var adapter = new iParaLinkPaymentCreateAdapter(connection);
                var result = adapter.Execute(model);

                Trace.WriteLine(result.ErrorMessage);

                Assert.IsFalse(result.IsValid);
                Assert.IsNotNull(result.ErrorCode);
                Assert.IsNotNull(result.ErrorMessage);
                Assert.IsNull(result.Link);
                Assert.IsNull(result.LinkPaymentId);
                Assert.IsNotNull(result.Result);
                
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

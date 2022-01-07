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
    public class iParaPaymentInquiryAdapterTests
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
        //[Ignore("Veri bütünlüğü eksik")]

        public void Can_Create_Link_Payment_Valid()
        {
            string baseUrl = "https://api.ipara.com/";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "1.0";

            using (var connection = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version))
            {
                var model = new iParaPaymentInquiryRequest
                {

                    Echo = "",
                    Mode = "T",
                    OrderId = "1b89aca4-5173-47f3-a760-a3c2db6b3f90"
                };

                var adapter = new iParaPaymentInquiryAdapter(connection);
                var result = adapter.Execute(model);

                Trace.WriteLine(result.ErrorMessage);

                Assert.IsTrue(result.IsValid);
                Assert.IsNull(result.ErrorCode);
                Assert.IsNull(result.ErrorMessage);

                Assert.IsNotNull(result.Result);
                Assert.IsNotNull(result.ResponseMessage);
                Assert.AreEqual(1, result.GetAmount());
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
                var model = new iParaPaymentInquiryRequest
                {
                    Echo = "",
                    //Mode = "T",
                    OrderId = ""
                };
                var adapter = new iParaPaymentInquiryAdapter(connection);
                var result = adapter.Execute(model);

                Trace.WriteLine(result.ErrorMessage);

                Assert.IsFalse(result.IsValid);
                Assert.IsNotNull(result.ErrorCode);
                Assert.IsNotNull(result.ErrorMessage);
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using iParaClientService.Adapter;
using iParaClientService.Model;
using iParaClientService.Model.Request;
using iParaClientService.Service;
using iParaClientService.Utils;

namespace iParaClientService.Integration.Tests
{
    [TestClass]
    public class iParaLinkPaymentListAdapterTests
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

        public void Can_List_Link_Payment_Valid()
        {
            string baseUrl = "https://api.ipara.com/";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "1.0";

            using (var connection = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version))
            {
                var model = new iParaLinkPaymentListRequest
                {
                    Echo = "",
                    Mode = "T",
                    PageSize = 15,
                    PageIndex = 1,
                    Email = "kurtayyilmaz@gmail.com"
                };

                var adapter = new iParaLinkPaymentListAdapter(connection);
                var result = adapter.Execute(model);

                Trace.WriteLine(result.ErrorMessage);
                Trace.WriteLine(result.ErrorCode);

                if (!result.IsValid)
                {
                    Trace.WriteLine(JsonBuilderHelpers.SerializeToJsonString(model));
                }
                Assert.IsTrue(result.IsValid);
                Assert.IsNull(result.ErrorCode);
                Assert.IsNull(result.ErrorMessage);

                Assert.IsNotNull(result.LinkPaymentRecordList);
                Assert.IsTrue(result.LinkPaymentRecordList.Count > 0);
                Assert.IsNotNull(result.Result);
                Assert.IsNotNull(result.ResponseMessage);
            }
        }

        [TestMethod]

        public void Can_List_Link_Payment_Valid_ByState()
        {
            string baseUrl = "https://api.ipara.com/";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "1.0";

            using (var connection = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version))
            {
                var model = new iParaLinkPaymentListRequest
                {
                    Echo = "",
                    Mode = "T",
                    PageSize = 15,
                    PageIndex = 1,
                    Email = "kurtayyilmaz@gmail.com",
                    LinkState = LinkState.LinkPaymentDone
                };

                var adapter = new iParaLinkPaymentListAdapter(connection);
                var result = adapter.Execute(model);

                Trace.WriteLine(result.ErrorMessage);
                Trace.WriteLine(result.ErrorCode);

                if (!result.IsValid)
                {
                    Trace.WriteLine(JsonBuilderHelpers.SerializeToJsonString(model));
                }
                Assert.IsTrue(result.IsValid);
                Assert.IsNull(result.ErrorCode);
                Assert.IsNull(result.ErrorMessage);

                Assert.IsNotNull(result.LinkPaymentRecordList);
                Assert.IsTrue(result.LinkPaymentRecordList.Count > 0);
                Assert.IsNotNull(result.Result);
                Assert.IsNotNull(result.ResponseMessage);
            }
        }
        [TestMethod]
        [DataRow("002R/OgkSDc2BpGXb4cr79R5Q==", "100")]
        public void Can_List_Link_Payment_Valid_ByLinkId(string linkId, string amount)
        {
            string baseUrl = "https://api.ipara.com/";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "1.0";

            using (var connection = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version))
            {
                var model = new iParaLinkPaymentListRequest
                {
                    Echo = "",
                    Mode = "T",
                    PageSize = 15,
                    PageIndex = 1,
                    Email = "kurtayyilmaz@gmail.com",
                    LinkState = LinkState.LinkPaymentDone
                };

                var adapter = new iParaLinkPaymentListAdapter(connection);
                var result = adapter.Execute(model);

                Trace.WriteLine(result.ErrorMessage);
                Trace.WriteLine(result.ErrorCode);

                if (!result.IsValid)
                {
                    Trace.WriteLine(JsonBuilderHelpers.SerializeToJsonString(model));
                }
                Assert.IsTrue(result.IsValid);
                Assert.IsNull(result.ErrorCode);
                Assert.IsNull(result.ErrorMessage);

                Assert.IsNotNull(result.LinkPaymentRecordList);
                Assert.IsTrue(result.LinkPaymentRecordList.Count == 1);

                var payment = result.LinkPaymentRecordList.Single();
                payment.Amount.Should().Be(Convert.ToInt16(amount));
                payment.LinkId.Should().Be(linkId);
                payment.LinkState.Should().Be(LinkState.LinkPaymentDone);

                Assert.IsNotNull(result.Result);
                Assert.IsNotNull(result.ResponseMessage);
            }
        }

        [TestMethod]

        public void Can_List_Link_Payment_Invalid()
        {
            string baseUrl = "https://api.ipara.com/";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "1.0";

            using (var connection = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version))
            {
                var model = new iParaLinkPaymentListRequest
                {
                    ClientIp = "127.0.0.1",
                    Echo = "",
                    Mode = "T",
                    Gsm = "53143516",
                };
                var adapter = new iParaLinkPaymentListAdapter(connection);
                var result = adapter.Execute(model);

                Trace.WriteLine(result.ErrorMessage);
                Trace.WriteLine(result.ErrorCode);

                if (!result.IsValid)
                {
                    Trace.WriteLine(JsonBuilderHelpers.SerializeToJsonString(model));
                }
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

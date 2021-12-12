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
        [TestMethod]
        
        public void Can_Create_Link_Payment()
        {
            string baseUrl = "https://api.ipara.com/";
            string publicKey = "XF0GK4W5WA0VN37";
            string privateKey = "XF0GK4W5WA0VN375PVB0XKHG0";
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
                    TcCertificate = "18946660001",
                    TaxNumber = "",
                    Echo = "",
                    Mode = "T",
                    ExpireDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                    Gsm = "5397143516",

                };
                var adapter = new iParaLinkPaymentAdapter(connection);
                var result = adapter.Execute(model);
              
            }
        }
    }
}

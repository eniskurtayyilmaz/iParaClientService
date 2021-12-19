using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iParaClientService.Model.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iParaClientService.Tests.Model
{
    [TestClass]
    public class iParaLinkPaymentCreateRequestModelTests
    {
        [TestMethod]
        [DataRow(10.0, 1000)]
        [DataRow(10.1, 1010)]
        [DataRow(10.20, 1020)]
        [DataRow(10.20, 1020)]
        [DataRow(10.21, 1021)]
        [DataRow(10.22, 1022)]
        [DataRow(10.23, 1023)]
        [DataRow(10.24, 1024)]
        [DataRow(10.25, 1025)]
        [DataRow(10.26, 1026)]
        [DataRow(10.27, 1027)]
        [DataRow(10.28, 1028)]
        [DataRow(10.29, 1029)]
        [DataRow(10.30, 1030)]
        [DataRow(10, 1000)]
        public void Can_Set_Amount(double amount, int expected)
        {
            iParaLinkPaymentCreateRequest model = new iParaLinkPaymentCreateRequest();
            model.SetAmount(amount);

            var result = model.Amount;

            Assert.AreEqual(expected, result);
        }
    }
}

using FluentAssertions;
using iParaClientService.Constant;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iParaClientService.Tests.Header
{
    [TestClass]
    public class RequestUrlConstantTests
    {
        [TestMethod]
        public void RequestUrlConstant_LinkPaymentCreate()
        {
            var result = RequestUrlConstant.LinkPaymentCreate;

            result.Should().Be("corporate/merchant/linkpayment/create");
        }  
        
        [TestMethod]
        public void RequestUrlConstant_LinkPaymentList()
        {
            var result = RequestUrlConstant.LinkPaymentList;

            result.Should().Be("corporate/merchant/linkpayment/list");
        }
    }
}
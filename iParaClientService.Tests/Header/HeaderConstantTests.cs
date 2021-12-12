using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using iParaClientService.Constant;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iParaClientService.Tests.Header
{
    [TestClass]
    public class HeaderConstantTests
    {
        [TestMethod]
        public void HeaderConstant_ApplicationJson()
        {
            var result = HeaderConstant.ApplicationJson;

            result.Should().Be("application/json");
        }

        [TestMethod]
        public void HeaderConstant_ApplicationXml()
        {
            var result = HeaderConstant.ApplicationXml;

            result.Should().Be("application/xml");
        }
    }
}

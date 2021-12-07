using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using iParaClientService.Constant;
using iParaClientService.Exception;
using iParaClientService.Model;
using iParaClientService.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iParaClientService.Tests.Service
{
    [TestClass]
    public class iParaClientConnectionTests
    {
        [TestMethod]
        public void Connection_Ctor_Must_Throw_Exception()
        {
            //Arrange
            iParaConnectionSettings iParaConnectionSettings = null;

            //Action
            var result = Assert.ThrowsException<iParaClientConnectionException>(() => new iParaClientConnection(iParaConnectionSettings));

            //Assert
            result.Message.Should()
                .Be(ExceptionMessagesConstant.iParaClientConnectionExceptionMessages.ParaConnectionSettings);
        }
    }
}

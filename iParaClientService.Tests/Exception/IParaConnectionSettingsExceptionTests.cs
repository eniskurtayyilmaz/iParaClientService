using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using iParaClientService.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iParaClientService.Tests.Exception
{
    [TestClass]
    public class IParaConnectionSettingsExceptionTests
    {
        [TestMethod]
        [DataRow("Test hata")]
        [DataRow("Hata mesajı")]
        public void Exception_Messages_Should_Be_Excepted_Same(string message)
        {
            //Arrange

            //Act
            var exceptionMessage = new IParaConnectionSettingsException(message);

            //Assert
            exceptionMessage.Message.Should().Be(message);
        }
    }
}

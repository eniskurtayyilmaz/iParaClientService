using FluentAssertions;
using iParaClientService.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iParaClientService.Tests.Exception
{
    [TestClass]
    public class iParaClientConnectionExceptionTests
    {
        [TestMethod]
        [DataRow("Test hata")]
        [DataRow("Hata mesajı")]
        public void Exception_Messages_Should_Be_Excepted_Same(string message)
        {
            //Arrange

            //Act
            var exceptionMessage = new iParaClientConnectionException(message);

            //Assert
            exceptionMessage.Message.Should().Be(message);
        }
    }
}
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
        #region BaseUrl
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void When_BaseUrl_Is_Invalid_Should_Be_Exception(string parameter)
        {
            //Arrange
            string baseUrl = parameter;
            string publicKey = "publicKey";
            string privateKey = "privateKey";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "version";

            //Action
            var result = Assert.ThrowsException<iParaClientConnectionException>(() => new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version));

            //Assert
            result.Message.Should().Be(ExceptionMessagesConstant.iParaClientConnectionExceptionMessages.BaseUrlNotBeNullOrEmpty);
        }

        [TestMethod]
        [DataRow("http://")]
        [DataRow("abc")]
        public void When_BaseUrl_Is_Valid_Should_Not_Have_Exception(string parameter)
        {
            //Arrange
            string baseUrl = parameter;
            string publicKey = "publicKey";
            string privateKey = "privateKey";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "version";

            //Action
            var result = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version);

            //Assert
            result.BaseUrl.Should().Be(baseUrl);
        }
        #endregion

        #region PublicKey
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void When_PublicKey_Is_Invalid_Should_Be_Exception(string parameter)
        {
            //Arrange
            string baseUrl = "baseUrl";
            string publicKey = parameter;
            string privateKey = "privateKey";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "version";

            //Action
            var result = Assert.ThrowsException<iParaClientConnectionException>(() => new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version));

            //Assert
            result.Message.Should().Be(ExceptionMessagesConstant.iParaClientConnectionExceptionMessages.PublicKeyNotBeNullOrEmpty);
        }

        [TestMethod]
        [DataRow("http://")]
        [DataRow("abc")]
        public void When_PublicKey_Is_Valid_Should_Not_Have_Exception(string parameter)
        {
            //Arrange
            string baseUrl = "baseUrl";
            string publicKey = "publicKey";
            string privateKey = "privateKey";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "version";

            //Action
            var result = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version);

            //Assert
            result.PublicKey.Should().Be(publicKey);
        }
        #endregion

        #region PrivateKey
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void When_PrivateKey_Is_Invalid_Should_Be_Exception(string parameter)
        {
            //Arrange
            string baseUrl = "baseUrl";
            string publicKey = "publicKey";
            string privateKey = parameter;
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "version";

            //Action
            var result = Assert.ThrowsException<iParaClientConnectionException>(() => new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version));

            //Assert
            result.Message.Should().Be(ExceptionMessagesConstant.iParaClientConnectionExceptionMessages.PrivateKeyNotBeNullOrEmpty);
        }

        [TestMethod]
        [DataRow("http://")]
        [DataRow("abc")]
        public void When_PrivateKey_Is_Valid_Should_Not_Have_Exception(string parameter)
        {
            //Arrange
            string baseUrl = "baseUrl";
            string publicKey = "publicKey";
            string privateKey = parameter;
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "version";

            //Action
            var result = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version);

            //Assert
            result.PrivateKey.Should().Be(privateKey);
        }
        #endregion
        
        #region Mode
        [TestMethod]
        public void When_Mode_Is_Valid_Should_Not_Have_Exception()
        {
            //Arrange
            string baseUrl = "baseUrl";
            string publicKey = "publicKey";
            string privateKey = "privateKey";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "version";

            //Action
            var result = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version);

            //Assert
            result.Mode.Should().Be(mode);
        }
        #endregion

        #region Version
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void When_Version_Is_Invalid_Should_Be_Exception(string parameter)
        {
            //Arrange
            string baseUrl = "baseUrl";
            string publicKey = "publicKey";
            string privateKey = "privateKey";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = parameter;

            //Action
            var result = Assert.ThrowsException<iParaClientConnectionException>(() => new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version));

            //Assert
            result.Message.Should().Be(ExceptionMessagesConstant.iParaClientConnectionExceptionMessages.VersionNotBeNullOrEmpty);
        }

        [TestMethod]
        [DataRow("http://")]
        [DataRow("abc")]
        public void When_Version_Is_Valid_Should_Not_Have_Exception(string parameter)
        {
            //Arrange
            string baseUrl = "baseUrl";
            string publicKey = "publicKey";
            string privateKey = "privateKey";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = parameter;

            //Action
            var result = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version);

            //Assert
            result.Version.Should().Be(version);
        }
        #endregion

        [TestMethod]
        public void Can_Dispose()
        {
            //Arrange
            string baseUrl = "baseUrl";
            string publicKey = "publicKey";
            string privateKey = "privateKey";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "version";
            using (var result = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version))
            {
                
            }
        }
    }
}

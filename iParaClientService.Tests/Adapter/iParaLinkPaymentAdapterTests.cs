using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using iParaClientService.Adapter;
using iParaClientService.Constant;
using iParaClientService.Exception;
using iParaClientService.Model;
using iParaClientService.Model.Request;
using iParaClientService.Model.Response;
using iParaClientService.Service;
using iParaClientService.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace iParaClientService.Tests.Adapter
{
    [TestClass]
    public class iParaLinkPaymentAdapterTests
    {
        private Mock<iParaClientConnection> _mockIParaClientConnection;
        private iParaConnectionSettings _iParaConnectionSettings;

        [TestInitialize]
        public void Setup()
        {
            string baseUrl = "baseUrl";
            string publicKey = "publicKey";
            string privateKey = "privateKey";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "version";

            //Action
            this._iParaConnectionSettings = new iParaConnectionSettings(baseUrl, publicKey, privateKey, mode, version);

            this._mockIParaClientConnection = new Mock<iParaClientConnection>(_iParaConnectionSettings);
        }

        [TestMethod]
        public void Request_Url_Must_Valid_And_Equal()
        {
            var linkPaymentAdapter = new iParaLinkPaymentAdapter(_mockIParaClientConnection.Object);

            var result = linkPaymentAdapter.GetRequestUrl;

            result.Should().Be(RequestUrlConstant.LinkPaymentCreate);
        }

        [TestMethod]
        public void Constructor_Exception_Handling()
        {
            //Arrange


            //Act
            var result = Assert.ThrowsException<iParaClientConnectionException>(() => new iParaLinkPaymentAdapter(null));


            //Assert    
            result.Message.Should()
                .Be(ExceptionMessagesConstant.iParaClientConnectionExceptionMessages.ParaClientConnection);
        }

        [TestMethod]
        public void GetHashString_Must_Valid_And_Equal()
        {
            //Arrange
            var model = new Fixture().Create<iParaLinkPaymentCreateRequest>();
            var linkPaymentAdapter = new iParaLinkPaymentAdapter(_mockIParaClientConnection.Object);
            var hashString = HashStringBuilderHelpers.GetHashString(_iParaConnectionSettings.PrivateKey, model.Name,
                model.Surname, model.Email, model.Amount.ToString(),
                model.ClientIp, HeaderHelpers.GetTransactionDateString());

            //Act
            var result = linkPaymentAdapter.GetHashString(model);

            //Assert
            result.Should().Be(hashString);
        }

        [TestMethod]
        public void Can_Call_Execute_As_LinkPayment()
        {
            //Arrange
            var model = new Fixture().Create<iParaLinkPaymentCreateRequest>();
            var linkPaymentAdapter = new iParaLinkPaymentAdapter(_mockIParaClientConnection.Object);

            //Act
            var result = linkPaymentAdapter.Execute(model);

            //Assert
            result.Should().BeOfType<iParaLinkPaymentCreateResponse>();
            result.ErrorCode.Should().Be("errorCode");
        }
    }
}

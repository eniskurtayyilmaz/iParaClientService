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
    public class iParaLinkPaymentListAdapterTests
    {
        private Mock<iParaClientConnection> _mockIParaClientConnection;

        [TestInitialize]
        public void Setup()
        {
            string baseUrl = "baseUrl";
            string publicKey = "publicKey";
            string privateKey = "privateKey";
            iParaConnectionMode mode = iParaConnectionMode.Test;
            string version = "version";

            //Action

            this._mockIParaClientConnection = new Mock<iParaClientConnection>(new object[]
            {
                baseUrl, publicKey, privateKey, mode, version
            });
        }



        [TestMethod]
        public void AcceptType_Must_Valid_And_Equal()
        {
            var linkPaymentAdapter = new iParaLinkPaymentListAdapter(_mockIParaClientConnection.Object);

            var result = linkPaymentAdapter.AcceptType;

            result.Should().Be(HeaderConstant.ApplicationJson);
        }


        [TestMethod]
        public void Request_Url_Must_Valid_And_Equal()
        {
            var linkPaymentAdapter = new iParaLinkPaymentListAdapter(_mockIParaClientConnection.Object);

            var result = linkPaymentAdapter.GetRequestUrl;

            result.Should().Be(_mockIParaClientConnection.Object.BaseUrl + RequestUrlConstant.LinkPaymentList);
        }

        [TestMethod]
        public void Constructor_Exception_Handling()
        {
            //Arrange


            //Act
            var result = Assert.ThrowsException<iParaClientConnectionException>(() => new iParaLinkPaymentListAdapter(null));


            //Assert    
            result.Message.Should()
                .Be(ExceptionMessagesConstant.iParaClientConnectionExceptionMessages.ParaClientConnectionNullOrEmpty);
        }

        [TestMethod]
        public void GetHashString_Must_Valid_And_Equal()
        {
            //Arrange
            var model = new Fixture().Create<iParaLinkPaymentListRequest>();
            var linkPaymentAdapter = new iParaLinkPaymentListAdapter(_mockIParaClientConnection.Object);
            var hashString = HashStringBuilderHelpers.GetHashString(_mockIParaClientConnection.Object.PrivateKey,
                model.ClientIp, HeaderHelpers.GetTransactionDateString());

            //Act
            var result = linkPaymentAdapter.GetHashString(model);

            //Assert
            result.Should().Be(hashString);
        }
    }
}

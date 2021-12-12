using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iParaClientService.Constant;
using iParaClientService.Domain;
using iParaClientService.Exception;
using iParaClientService.Model;
using iParaClientService.Model.Request;
using iParaClientService.Model.Response;

namespace iParaClientService.Service
{
    public class iParaClientConnection : IDisposable
    {
        public string BaseUrl { get; internal set; }
        public string PublicKey { get; internal set; }
        public string PrivateKey { get; internal set; }
        public iParaConnectionMode Mode { get; internal set; }
        public string Version { get; internal set; }

        public iParaClientConnection(string baseUrl, string publicKey, string privateKey, iParaConnectionMode mode, string version)
        {
            this.SetBaseUrl(baseUrl);
            this.SetPublicKey(publicKey);
            this.SetPrivateKey(privateKey);
            this.SetMode(mode);
            this.SetVersion(version);
        }

        public void SetBaseUrl(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl) || string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new iParaClientConnectionException(ExceptionMessagesConstant.iParaClientConnectionExceptionMessages.BaseUrlNotBeNullOrEmpty);
            }

            this.BaseUrl = baseUrl;
        }

        private void SetPublicKey(string publicKey)
        {
            if (string.IsNullOrEmpty(publicKey) || string.IsNullOrWhiteSpace(publicKey))
            {
                throw new iParaClientConnectionException(ExceptionMessagesConstant.iParaClientConnectionExceptionMessages.PublicKeyNotBeNullOrEmpty);
            }

            this.PublicKey = publicKey;
        }

        private void SetPrivateKey(string privateKey)
        {
            if (string.IsNullOrEmpty(privateKey) || string.IsNullOrWhiteSpace(privateKey))
            {
                throw new iParaClientConnectionException(ExceptionMessagesConstant.iParaClientConnectionExceptionMessages.PrivateKeyNotBeNullOrEmpty);
            }

            this.PrivateKey = privateKey;
        }

        public void SetMode(iParaConnectionMode mode)
        {
            this.Mode = mode;
        }

        public string GetMode()
        {
            return Mode == iParaConnectionMode.Production ? "P" : "T";
        }

        public void SetVersion(string version)
        {
            if (string.IsNullOrEmpty(version) || string.IsNullOrWhiteSpace(version))
            {
                throw new iParaClientConnectionException(ExceptionMessagesConstant.iParaClientConnectionExceptionMessages.VersionNotBeNullOrEmpty);
            }

            this.Version = version;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

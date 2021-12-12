using System.Net;
using iParaClientService.Constant;
using iParaClientService.Domain;
using iParaClientService.Exception;
using iParaClientService.Service;
using iParaClientService.Utils;

namespace iParaClientService.Adapter
{
    public abstract class AbstractIParaExecuter<TRequest, TResponse>
    where TRequest : AbstractiParaRequestBase
    where TResponse : AbstractiParaResponseBase
    {
        private readonly iParaClientConnection _iParaClientConnection;
        protected AbstractIParaExecuter(iParaClientConnection iParaClientConnection)
        {
            _iParaClientConnection = iParaClientConnection ?? throw new iParaClientConnectionException(ExceptionMessagesConstant
                .iParaClientConnectionExceptionMessages.ParaClientConnectionNullOrEmpty);
        }
        public abstract TResponse Execute(TRequest model);
        public abstract string GetRequestUrl { get; }  
        public abstract string GetHashString(TRequest model);
        public abstract string AcceptType { get; }
        
        private const string TransactionDate = "transactionDate";
        private const string version = "version";
        private const string token = "token";
        private const string Accept = "Accept";
        protected WebHeaderCollection WebHeaderCollection(string hashString)
        {
            WebHeaderCollection headers = new WebHeaderCollection();
            headers.Add(Accept, AcceptType);
            headers.Add(version, _iParaClientConnection.Version);
            headers.Add(token, HeaderHelpers.CreateToken(_iParaClientConnection.PublicKey, hashString));
            headers.Add(TransactionDate, HeaderHelpers.GetTransactionDateString());

            return headers;
        }
    }
}
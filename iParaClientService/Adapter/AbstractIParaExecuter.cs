using iParaClientService.Constant;
using iParaClientService.Domain;
using iParaClientService.Exception;
using iParaClientService.Service;

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
                .iParaClientConnectionExceptionMessages.ParaClientConnection);
        }
        public abstract TResponse Execute(TRequest model);
        public abstract string GetRequestUrl { get; }  
        public abstract string GetHashString(TRequest model);
    }
}
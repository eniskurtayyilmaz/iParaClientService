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
    public interface IExecuter<TRequest, TResponse> 
        where TRequest : AbstractiParaRequestBase
        where TResponse : AbstractiParaResponseBase
    {
        TResponse Execute(TRequest request);
    }

    public class iParaClientConnection : IDisposable, 
        IExecuter<iParaLinkPaymentCreateRequest, iParaLinkPaymentCreateResponse>
    {
        private readonly iParaConnectionSettings _paraConnectionSettings;

        public iParaClientConnection(iParaConnectionSettings paraConnectionSettings)
        {
            _paraConnectionSettings = paraConnectionSettings ?? throw new iParaClientConnectionException(ExceptionMessagesConstant
                .iParaClientConnectionExceptionMessages.ParaConnectionSettings);
        }
        

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public iParaLinkPaymentCreateResponse Execute(iParaLinkPaymentCreateRequest request)
        {   
            throw new NotImplementedException();
        }
    }
}

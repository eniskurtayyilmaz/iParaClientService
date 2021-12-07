using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iParaClientService.Constant;
using iParaClientService.Exception;
using iParaClientService.Model;

namespace iParaClientService.Service
{
    public class iParaClientConnection
    {
        private readonly iParaConnectionSettings _paraConnectionSettings;

        public iParaClientConnection(iParaConnectionSettings paraConnectionSettings)
        {
            _paraConnectionSettings = paraConnectionSettings ?? throw new iParaClientConnectionException(ExceptionMessagesConstant
                .iParaClientConnectionExceptionMessages.ParaConnectionSettings);
        }
    }
}

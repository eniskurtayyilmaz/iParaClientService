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
    public class iParaClientServiceConnection
    {
        private readonly iParaConnectionSettings _paraConnectionSettings;

        public iParaClientServiceConnection(iParaConnectionSettings paraConnectionSettings)
        {
            _paraConnectionSettings = paraConnectionSettings ?? throw new iParaClientServiceConnectionException(ExceptionMessagesConstant
                .iParaClientServiceConnectionExceptionMessages.ParaConnectionSettings);
        }
    }
}

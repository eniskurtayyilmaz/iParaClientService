using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParaClientService.Exception
{
    public class iParaConnectionSettingsException : System.Exception
    {
        public iParaConnectionSettingsException(string exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}

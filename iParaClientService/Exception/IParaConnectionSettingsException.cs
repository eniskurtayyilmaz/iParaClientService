using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParaClientService.Exception
{
    public class IParaConnectionSettingsException : System.Exception
    {
        public IParaConnectionSettingsException(string exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}

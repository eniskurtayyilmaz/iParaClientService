using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iParaClientService.Domain;

namespace iParaClientService.Model.Request
{
    public class iParaLinkPaymentCreateRequest : AbstractiParaRequestBase
    {
        public override string RequestEndpoint { get; }
        public override string RequestAcceptType { get; }
    }
}

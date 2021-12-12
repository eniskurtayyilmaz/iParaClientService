using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iParaClientService.Domain;

namespace iParaClientService.Model.Response
{
    public class iParaLinkPaymentCreateResponse : AbstractiParaResponseBase
    {
        public string Link { get; set; }

        public string LinkPaymentId { get; set; }

        public string Amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iParaClientService.Constant;
using iParaClientService.Domain;
using iParaClientService.Model.Response;
using iParaClientService.Service;

namespace iParaClientService.Model.Request
{
  
    public class iParaLinkPaymentCreateRequest : AbstractiParaRequestBase
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string TcCertificate { get; set; }

        public string TaxNumber { get; set; }

        public string Email { get; set; }

        public string Gsm { get; set; }

        public int Amount { get; set; }

        public bool ThreeD { get; set; }

        public string ExpireDate { get; set; }

        public bool SendEmail { get; set; }

        public string CommissionType { get; set; }

        public string ClientIp { get; set; }
    }
}

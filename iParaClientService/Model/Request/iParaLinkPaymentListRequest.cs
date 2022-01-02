using System;
using iParaClientService.Domain;

namespace iParaClientService.Model.Request
{
    public class iParaLinkPaymentListRequest : AbstractiParaRequestBase
    {
        public string Email { get; set; }

        public string Gsm { get; set; }

        public LinkState? LinkState { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public string ClientIp { get; set; }
    }
}

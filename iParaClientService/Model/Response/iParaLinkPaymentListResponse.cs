using System.Collections.Generic;
using iParaClientService.Domain;

namespace iParaClientService.Model.Response
{
    public class iParaLinkPaymentListResponse : AbstractiParaResponseBase
    {
        public List<PaymentLink> LinkPaymentRecordList { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }
    }
}

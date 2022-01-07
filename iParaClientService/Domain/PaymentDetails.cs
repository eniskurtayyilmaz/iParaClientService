using System;

namespace iParaClientService.Domain
{
    public class PaymentDetails
    {
        public DateTime? PaymentDate { set; get; }
        public string OrderId { set; get; }
    }
}

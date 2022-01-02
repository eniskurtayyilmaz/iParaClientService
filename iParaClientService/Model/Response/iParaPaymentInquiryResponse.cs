using System.Xml.Serialization;
using iParaClientService.Domain;
using iParaClientService.Model.Request;
using iParaClientService.Utils;

namespace iParaClientService.Model.Response
{
    [XmlRoot("inquiryResponse")]
    public class iParaPaymentInquiryResponse : AbstractiParaResponseBase, IAmount
    {
        [XmlElement("amount")]
        public int? Amount { get; set; }

        [XmlElement("orderId")]
        public string OrderId { get; set; }

        public void SetAmount(double money)
        {
            this.Amount = money.SetAmount();
        }

        public double GetAmount()
        {
            return this.Amount.GetAmount();
        }
    }
}

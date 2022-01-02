using System.Xml.Serialization;
using iParaClientService.Domain;

namespace iParaClientService.Model.Request
{
    [XmlRoot("inquiry")]
    public class iParaPaymentInquiryRequest : AbstractiParaRequestBase
    {
        [XmlElement("orderId")]
        public string OrderId { get; set; }
    }
}

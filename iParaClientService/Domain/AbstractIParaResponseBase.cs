using System.Xml.Serialization;

namespace iParaClientService.Domain
{
    public abstract class AbstractiParaResponseBase
    {
        [XmlElement("result")] public string Result { get; set; }

        [XmlElement("errorCode")] public string ErrorCode { get; set; }

        [XmlElement("errorMessage")] public string ErrorMessage { get; set; }

        [XmlElement("responseMessage")] public string ResponseMessage { get; set; }

        //XML Servisler için Gerekli
        [XmlElement("mode")] public string Mode { get; set; }

        [XmlElement("echo")] public string Echo { get; set; }

        [XmlElement("hash")] public string Hash { get; set; }

        [XmlElement("transactionDate")] public string TransactionDate { get; set; }

        //TODO: JsonIgnore
        //TODO: XmlElement Ignore
        public bool IsValid => string.IsNullOrEmpty(this.ErrorCode) && string.IsNullOrEmpty(this.ErrorMessage);
    }
}
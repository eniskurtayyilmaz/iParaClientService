using System.Xml.Serialization;

namespace iParaClientService.Domain
{
    public abstract class AbstractiParaResponseBase
    {
        [XmlElement("result")] public string Result { get; set; }

        [XmlElement("errorCode")] public string ErrorCode { get; set; }

        [XmlElement("errorMessage")] public string ErrorMessage { get; set; }

        [XmlElement("responseMessage")] public string ResponseMessage { get; set; }

        //TODO: JsonIgnore
        //TODO: XmlElement Ignore
        public bool IsValid => string.IsNullOrEmpty(this.ErrorCode) && string.IsNullOrEmpty(this.ErrorMessage);
    }
}
using System.Xml.Serialization;

namespace iParaClientService.Domain
{
    public abstract class AbstractIParaRequestBase
    {
        [XmlElement("echo")]
        public string Echo { get; set; }

        [XmlElement("mode")]
        public string Mode { get; set; }
    }
}

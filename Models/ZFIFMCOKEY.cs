using System.Xml.Serialization;

namespace BusinessWarehouseApp.Models
{
    [XmlRoot(ElementName = "ZFIFMCOKEY")]
    public class ZFIFMCOKEY
    {
        [XmlElement(ElementName = "KEY")]
        public string KEY { get; set; }
        [XmlElement(ElementName = "ZFIHEAD")]
        public ZFIHEAD ZFIHEAD { get; set; }
    }
}
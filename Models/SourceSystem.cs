using System.Xml.Serialization;

namespace BusinessWarehouseApp.Models
{
    [XmlRoot(ElementName = "SourceSystem")]
    public class SourceSystem
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "DocumentID")]
        public string DocumentID { get; set; }
        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "Time")]
        public string Time { get; set; }
    }
}
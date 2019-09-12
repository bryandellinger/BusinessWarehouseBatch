using System.Xml.Serialization;

namespace BusinessWarehouseApp.Models
{
    [XmlRoot(ElementName = "TargetSystem")]
    public class TargetSystem
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
    }
}
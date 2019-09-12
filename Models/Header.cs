using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessWarehouseApp.Models
{
    [XmlRoot(ElementName = "Header")]
    public class Header
    {
        [XmlElement(ElementName = "InterfaceID")]
        public string InterfaceID { get; set; }
        [XmlElement(ElementName = "InterfaceType")]
        public string InterfaceType { get; set; }
        [XmlElement(ElementName = "SourceSystem")]
        public SourceSystem SourceSystem { get; set; }
        [XmlElement(ElementName = "TargetSystem")]
        public TargetSystem TargetSystem { get; set; }
    }
}

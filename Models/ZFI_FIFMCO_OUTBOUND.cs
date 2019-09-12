using System.Collections.Generic;
using System.Xml.Serialization;

namespace BusinessWarehouseApp.Models
{
    [XmlRoot(ElementName = "ZFI_FIFMCO_OUTBOUND")]
    public  class ZFI_FIFMCO_OUTBOUND
    {
        [XmlElement(ElementName = "Header")]
        public Header Header { get; set; }
        [XmlElement(ElementName = "ZFIFMCOKEY")]
        public List<ZFIFMCOKEY> ZFIFMCOKEY { get; set; }
    }
}
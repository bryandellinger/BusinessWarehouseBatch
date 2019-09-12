using System.Collections.Generic;
using System.Xml.Serialization;

namespace BusinessWarehouseApp.Models
{
    [XmlRoot(ElementName = "ZFIHEAD")]
    public class ZFIHEAD
    {
        [XmlElement(ElementName = "BELNR")]
        public string BELNR { get; set; }
        [XmlElement(ElementName = "GJAHR")]
        public string GJAHR { get; set; }
        [XmlElement(ElementName = "BLART")]
        public string BLART { get; set; }
        [XmlElement(ElementName = "BLDAT")]
        public string BLDAT { get; set; }
        [XmlElement(ElementName = "BUDAT")]
        public string BUDAT { get; set; }
        [XmlElement(ElementName = "MONAT")]
        public string MONAT { get; set; }
        [XmlElement(ElementName = "CPUDT")]
        public string CPUDT { get; set; }
        [XmlElement(ElementName = "CPUTM")]
        public string CPUTM { get; set; }
        [XmlElement(ElementName = "AEDAT")]
        public string AEDAT { get; set; }
        [XmlElement(ElementName = "USNAM")]
        public string USNAM { get; set; }
        [XmlElement(ElementName = "TCODE")]
        public string TCODE { get; set; }
        [XmlElement(ElementName = "STBLG")]
        public string STBLG { get; set; }
        [XmlElement(ElementName = "BKTXT")]
        public string BKTXT { get; set; }
        [XmlElement(ElementName = "AWTYP")]
        public string AWTYP { get; set; }
        [XmlElement(ElementName = "AWKEY")]
        public string AWKEY { get; set; }
        [XmlElement(ElementName = "ZFIITEM")]
        public List<ZFIITEM> ZFIITEM { get; set; }
        [XmlElement(ElementName = "XBLNR")]
        public string XBLNR { get; set; }
    }
}
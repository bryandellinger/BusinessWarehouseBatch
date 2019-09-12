using System.Xml.Serialization;

namespace BusinessWarehouseApp.Models
{
    [XmlRoot(ElementName = "ZFIITEM")]
    public class ZFIITEM
    {
        [XmlElement(ElementName = "BELNR")]
        public string BELNR { get; set; }
        [XmlElement(ElementName = "GJAHR")]
        public string GJAHR { get; set; }
        [XmlElement(ElementName = "BUZEI")]
        public string BUZEI { get; set; }
        [XmlElement(ElementName = "AUGDT")]
        public string AUGDT { get; set; }
        [XmlElement(ElementName = "AUGCP")]
        public string AUGCP { get; set; }
        [XmlElement(ElementName = "BSCHL")]
        public string BSCHL { get; set; }
        [XmlElement(ElementName = "SHKZG")]
        public string SHKZG { get; set; }
        [XmlElement(ElementName = "GSBER")]
        public string GSBER { get; set; }
        [XmlElement(ElementName = "DMBTR")]
        public string DMBTR { get; set; }
        [XmlElement(ElementName = "VALUT")]
        public string VALUT { get; set; }
        [XmlElement(ElementName = "ZUONR")]
        public string ZUONR { get; set; }
        [XmlElement(ElementName = "SGTXT")]
        public string SGTXT { get; set; }
        [XmlElement(ElementName = "HKONT")]
        public string HKONT { get; set; }
        [XmlElement(ElementName = "EBELP")]
        public string EBELP { get; set; }
        [XmlElement(ElementName = "GEBER")]
        public string GEBER { get; set; }
        [XmlElement(ElementName = "BUDGET_PD")]
        public string BUDGET_PD { get; set; }
        [XmlElement(ElementName = "KBLPOS")]
        public string KBLPOS { get; set; }
        [XmlElement(ElementName = "FIPOS")]
        public string FIPOS { get; set; }
        [XmlElement(ElementName = "FISTL")]
        public string FISTL { get; set; }
        [XmlElement(ElementName = "AUGBL")]
        public string AUGBL { get; set; }
        [XmlElement(ElementName = "KOSTL")]
        public string KOSTL { get; set; }
        [XmlElement(ElementName = "LIFNR")]
        public string LIFNR { get; set; }
    }
}
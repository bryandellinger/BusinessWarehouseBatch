using System.Collections.Generic;
using System.Xml.Serialization;

namespace BusinessWarehouseApp.Models
{
    [XmlRoot(ElementName = "ZFIHEAD")]
    public class ZFIHEAD
    {
         [XmlElement(ElementName = "BELNR")] //accounting document number
        public string BELNR { get; set; } 

        [XmlElement(ElementName = "GJAHR")] //fiscal year
        public string GJAHR { get; set; }

        [XmlElement(ElementName = "BLART")] //Document type
        public string BLART { get; set; }

        [XmlElement(ElementName = "BLDAT")] //Document Date in Document
        public string BLDAT { get; set; }

        [XmlElement(ElementName = "BUDAT")] //Posting Date in the Document
        public string BUDAT { get; set; }

        [XmlElement(ElementName = "MONAT")] //Fiscal Period
        public string MONAT { get; set; }

        [XmlElement(ElementName = "CPUDT")] //Day on which Acct Doc entered
        public string CPUDT { get; set; }

        [XmlElement(ElementName = "CPUTM")] //Time of Entry
        public string CPUTM { get; set; }

        [XmlElement(ElementName = "AEDAT")] //Date of last doc changed
        public string AEDAT { get; set; }

        [XmlElement(ElementName = "USNAM")] //User name
        public string USNAM { get; set; }

        [XmlElement(ElementName = "TCODE")] //Transaction code
        public string TCODE { get; set; }

        [XmlElement(ElementName = "STBLG")] //Reverse Document Number
        public string STBLG { get; set; }

        [XmlElement(ElementName = "BKTXT")] //Document Header Text
        public string BKTXT { get; set; }

        [XmlElement(ElementName = "AWTYP")] //Reference Transaction
        public string AWTYP { get; set; }

        [XmlElement(ElementName = "AWKEY")] //Reference Key
        public string AWKEY { get; set; }

        [XmlElement(ElementName = "XBLNR")] //Reference Document Number
        public string XBLNR { get; set; }

        [XmlElement(ElementName = "DBBLG")] //Recurring Entry Doc Number
        public string DBBLG { get; set; }

        [XmlElement(ElementName = "ZFIITEM")]
        public List<ZFIITEM> ZFIITEM { get; set; }
    }
}
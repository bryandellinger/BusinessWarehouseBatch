using System.Xml.Serialization;

namespace BusinessWarehouseApp.Models
{
    [XmlRoot(ElementName = "ZFIITEM")]
    public class ZFIITEM
    {
        [XmlElement(ElementName = "BELNR")] //Accounting Document Number
        public string BELNR { get; set; }
        [XmlElement(ElementName = "GJAHR")] //Fiscal Year
        public string GJAHR { get; set; }
        [XmlElement(ElementName = "BUZEI")] //Number of Line item in Acct Doc
        public string BUZEI { get; set; }
        [XmlElement(ElementName = "AUGDT")] //Clearing Date
        public string AUGDT { get; set; }
        [XmlElement(ElementName = "AUGCP")] //Clearing Entry Date
        public string AUGCP { get; set; }
        [XmlElement(ElementName = "BSCHL")] //Posting Key
        public string BSCHL { get; set; }
        [XmlElement(ElementName = "SHKZG")] //Debit/Credit Indicator
        public string SHKZG { get; set; }
        [XmlElement(ElementName = "GSBER")] //Business Area
        public string GSBER { get; set; }
        [XmlElement(ElementName = "DMBTR")] //Amount in Local Currency
        public string DMBTR { get; set; }
        [XmlElement(ElementName = "VALUT")] //Value Date
        public string VALUT { get; set; }
        [XmlElement(ElementName = "ZUONR")] //Assignment Number
        public string ZUONR { get; set; }
        [XmlElement(ElementName = "SGTXT")] //Item Text
        public string SGTXT { get; set; }
        [XmlElement(ElementName = "HKONT")] //G/L Account Number
        public string HKONT { get; set; }
        [XmlElement(ElementName = "EBELP")] //Item Number of Purchasing Document
        public string EBELP { get; set; }
        [XmlElement(ElementName = "GEBER")] //Fund
        public string GEBER { get; set; }
        [XmlElement(ElementName = "BUDGET_PD")] //Budget Period
        public string BUDGET_PD { get; set; }
        [XmlElement(ElementName = "KBLPOS")] //Earmarked Funds: Document Item
        public string KBLPOS { get; set; }
        [XmlElement(ElementName = "FIPOS")] //Commitment Item
        public string FIPOS { get; set; }
        [XmlElement(ElementName = "FISTL")] //Funds Center
        public string FISTL { get; set; }
        [XmlElement(ElementName = "AUGBL")] //Document Number of the Clearing Document
        public string AUGBL { get; set; }
        [XmlElement(ElementName = "KOSTL")] //Cost Center
        public string KOSTL { get; set; }
        [XmlElement(ElementName = "LIFNR")] //Account Number of Vendor or Creditor
        public string LIFNR { get; set; }
        [XmlElement(ElementName = "BTART")] //Amount type
        public string BTART { get; set; }
        [XmlElement(ElementName = "BL_DOC_TYPE")] //Document Type
        public string BL_DOC_TYPE { get; set; }
        [XmlElement(ElementName = "REFBN")] //Document Number
        public string REFBN{ get; set; }
        [XmlElement(ElementName = "AUFNR")] //Order Number
        public string AUFNR { get; set; }
        [XmlElement(ElementName = "XBLNR")] //Reference Document Number
        public string XBLNR { get; set; }
        [XmlElement(ElementName = "PROJK")] //Work Breakdown Structure Element (WBS Element)
        public string PROJK { get; set; }
        [XmlElement(ElementName = "ZLSPR")] //Payment Block Key
        public string ZLSPR { get; set; }
        [XmlElement(ElementName = "EBELN")] //Purchasing Document Number
        public string EBELN { get; set; }
        [XmlElement(ElementName = "VERTT")] //Contract Type
        public string VERTT { get; set; }
        [XmlElement(ElementName = "KBLNR")] //Document Number of Earmarked Funds
        public string KBLNR { get; set; }
        [XmlElement(ElementName = "RFPOS")] //Line Item
        public string RFPOS { get; set; }
        [XmlElement(ElementName = "FKBTR")] //Line Item
        public string FKBTR { get; set; }
        [XmlElement(ElementName = "OBJNRZ")] //Object Number
        public string OBJNRZ { get; set; }
        [XmlElement(ElementName = "WRTTP")] //Value Type
        public string WRTTP { get; set; }

    }
}
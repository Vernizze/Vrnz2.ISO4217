using System.Xml.Serialization;

namespace Vrnz2.ISO4217.Shared.Models.Xml
{
    [XmlRoot(ElementName = "CcyNtry")]
    public class CcyNtry
    {

        [XmlElement(ElementName = "CcyNm")]
        public CcyNm CcyNm { get; set; }

        [XmlElement(ElementName = "Ccy")]
        public string Ccy { get; set; }

        [XmlElement(ElementName = "CcyNbr")]
        public string CcyNbr { get; set; }

        [XmlElement(ElementName = "CcyMnrUnts")]
        public string CcyMnrUnts { get; set; }

        [XmlElement(ElementName = "CtryNm")]
        public string CtryNm { get; set; }
    }
}

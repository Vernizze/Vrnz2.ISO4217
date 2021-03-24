using System.Xml.Serialization;

namespace Vrnz2.ISO4217.Shared.Models.Xml
{
    [XmlRoot(ElementName = "CcyNm")]
    public class CcyNm
    {

        [XmlAttribute(AttributeName = "IsFund")]
        public bool IsFund { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}

using System;
using System.Xml.Serialization;

namespace Vrnz2.ISO4217.Shared.Models.Xml
{
    [XmlRoot(ElementName = "ISO_4217")]
    public class ISO4217
    {

        [XmlElement(ElementName = "CcyTbl")]
        public CcyTbl CcyTbl { get; set; }

        [XmlAttribute(AttributeName = "Pblshd")]
        public DateTime Pblshd { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}

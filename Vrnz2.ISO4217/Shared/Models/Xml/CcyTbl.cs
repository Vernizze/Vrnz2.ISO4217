using System.Collections.Generic;
using System.Xml.Serialization;

namespace Vrnz2.ISO4217.Shared.Models.Xml
{
    [XmlRoot(ElementName = "CcyTbl")]
    public class CcyTbl
    {

        [XmlElement(ElementName = "CcyNtry")]
        public List<CcyNtry> CcyNtry { get; set; }
    }
}

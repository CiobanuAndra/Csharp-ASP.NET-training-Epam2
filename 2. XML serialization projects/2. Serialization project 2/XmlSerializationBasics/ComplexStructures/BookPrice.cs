using System.Xml.Serialization;

namespace XmlSerializationBasics.ComplexStructures
{
    public class BookPrice
    {
        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlAttribute("currency")]
        public string? Currency { get; set; }
    }
}

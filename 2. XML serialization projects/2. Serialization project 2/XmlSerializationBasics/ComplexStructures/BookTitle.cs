using System.Xml.Serialization;

namespace XmlSerializationBasics.ComplexStructures
{
    public class BookTitle
    {
        [XmlAttribute("language")]
        public string? Language { get; set; }

        [XmlElement("text")]
        public string? Title { get; set; }
    }
}

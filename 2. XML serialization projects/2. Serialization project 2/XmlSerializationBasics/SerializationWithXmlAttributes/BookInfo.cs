using System.Xml.Serialization;

namespace XmlSerializationBasics.SerializationWithXmlAttributes
{
    [XmlRoot("book", Namespace = "http://contoso.com/book")]
    public class BookInfo
    {
        [XmlAttribute("title")]
        public string? Title { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("genre")]
        public string? Genre { get; set; }

        [XmlAttribute("isbn")]
        public string? Isbn { get; set; }

        [XmlAttribute("publication-date")]
        public string? PublicationDate { get; set; }
    }
}

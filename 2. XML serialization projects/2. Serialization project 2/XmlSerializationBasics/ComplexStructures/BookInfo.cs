using System.Xml.Serialization;

namespace XmlSerializationBasics.ComplexStructures
{
    [XmlRoot("book-description", Namespace = "http://contoso.com/book-description")]
    public class BookInfo
    {
        [XmlElement("book-title")]
        public BookTitle? Title { get; set; }

        [XmlElement("book-price")]
        public BookPrice? Price { get; set; }

        [XmlElement("book-genre")]
        public string? Genre { get; set; }

        [XmlElement("book-isbn")]
        public string? Isbn { get; set; }

        [XmlElement("book-publication-date")]
        public BookPublicationDate? PublicationDate { get; set; }
    }
}

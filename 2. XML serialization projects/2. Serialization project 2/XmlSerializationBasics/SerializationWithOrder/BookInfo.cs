using System.Xml.Serialization;

namespace XmlSerializationBasics.SerializationWithOrder;

[XmlRoot("book", Namespace = "http://contoso.com/book")]
public class BookInfo
{
    [XmlElement("book-title", Order = 1)]
    public string? Title { get; set; }

    [XmlElement("book-price", Order = 5)]
    public decimal Price { get; set; }

    [XmlElement("book-genre", Order = 4)]
    public string? Genre { get; set; }

    [XmlElement("book-isbn", Order = 3)]
    public string? Isbn { get; set; }

    [XmlElement("book-publication-date", Order = 2)]
    public string? PublicationDate { get; set; }
}

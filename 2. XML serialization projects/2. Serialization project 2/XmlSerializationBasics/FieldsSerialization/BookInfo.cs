using System.Xml.Serialization;

namespace XmlSerializationBasics.FieldsSerialization
{
    [XmlRoot("book.info", Namespace = "http://contoso.com/book-info")]
    public class BookInfo
    {
        [XmlElement("sell.price", Order = 4)]
        public decimal Price;

        [XmlElement("category", Order = 1)]
        public string? Genre;

        [XmlIgnore]
        private string? isbn;

        [XmlIgnore]
        private string? publicationDate;

        [XmlElement("book.title", Order = 2)]
        public string? Title { get; set; }

        [XmlElement("book.number", Order = 5)]
        public string? Isbn
        {
            get { return this.isbn; }
            set { this.isbn = value; }
        }

        [XmlElement("pub.date", Order = 3)]
        public string? PublicationDate
        {
            get { return this.publicationDate; }
            set { this.publicationDate = value; }
        }
    }
}

using System.Xml.Serialization;
using NUnit.Framework;

namespace Xml.Tests.BookElements;

[TestFixture]
public class BookElementsTests : XmlTestFixtureBase
{
    private const string SourceFileName = "book-elements.xml";
    private const string SchemaFileName = "BookElements.book-elements.xsd";

    private string content = null!;
    private string schema = null!;

    [SetUp]
    public void SetUp()
    {
        this.content = ReadContent(SourceFileName);
        this.schema = ReadSchema(SchemaFileName);
    }

    [Test]
    public void DeserializeAndTestContent()
    {
        Book book = Deserialize<Book>(this.content);

        Assert.That(book,Is.Not.Null);
        Assert.That("Pride And Prejudice", Is.EqualTo(book.Title));
        Assert.That(24.95, Is.EqualTo(book.Price));
        Assert.That("novel", Is.EqualTo(book.Genre));
        Assert.That("1-861001-57-8", Is.EqualTo(book.Isbn));
        Assert.That("1823-01-28", Is.EqualTo(book.PublicationDate));
    }

    [Test]
    public void ValidateSchema()
    {
        ValidateSchema(this.content, this.schema, TargetNamespaces.BookNamespace);
    }

    [XmlRoot("book", Namespace = TargetNamespaces.BookNamespace)]
    public class Book
    {
        [XmlElement("title")]
        public string Title { get; set; } = null!;

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("genre")]
        public string Genre { get; set; } = null!;

        [XmlElement("isbn")]
        public string Isbn { get; set; } = null!;

        [XmlElement("publicationDate")]
        public string PublicationDate { get; set; } = null!;
    }
}

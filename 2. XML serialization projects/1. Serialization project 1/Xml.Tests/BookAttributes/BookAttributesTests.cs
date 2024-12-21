using System.Xml.Serialization;
using NUnit.Framework;

namespace Xml.Tests.BookAttributes;

[TestFixture]
public class BookAttributesTests : XmlTestFixtureBase
{
    private const string SourceFileName = "book-attributes.xml";
    private const string SchemaFileName = "BookAttributes.book-attributes.xsd";

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

        Assert.That(book, Is.Not.Null);
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
        [XmlAttribute("title")]
        public string Title { get; set; } = null!;

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("genre")]
        public string Genre { get; set; } = null!;

        [XmlAttribute("isbn")]
        public string Isbn { get; set; } = null!;

        [XmlAttribute("publicationDate")]
        public string PublicationDate { get; set; } = null!;
    }
}

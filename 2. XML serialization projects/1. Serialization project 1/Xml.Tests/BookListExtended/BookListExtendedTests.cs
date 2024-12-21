using System.Xml.Serialization;
using NUnit.Framework;

namespace Xml.Tests.BookListExtended;

[TestFixture]
public class BookListExtendedTests : XmlTestFixtureBase
{
    private const string SourceFileName = "book-list-extended.xml";
    private const string SchemaFileName = "BookListExtended.book-list-extended.xsd";
    private const string NamespacePrefix = "co";

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
            BookList bookList = Deserialize<BookList>(this.content);

            Assert.That(bookList,Is.Not.Null);
            Assert.That(bookList.Books, Is.Not.Null);
            Assert.That(bookList.Books.Count, Is.EqualTo(3));

            var book = bookList.Books[0];
            Assert.That(book.Id, Is.EqualTo(1));
            Assert.That(book.Author, Is.EqualTo("Jane Austen"));
            Assert.That(book.Country, Is.EqualTo("United Kingdom"));
            Assert.That(book.Title, Is.EqualTo("Pride And Prejudice"));
            Assert.That(book.Language, Is.EqualTo("English"));
            Assert.That(book.Price, Is.EqualTo(24.95));
            Assert.That(book.Genre, Is.EqualTo("novel"));
            Assert.That(book.Isbn, Is.EqualTo("1-861001-57-8"));
            Assert.That(book.PublicationDate, Is.EqualTo("1823-01-28"));

            book = bookList.Books[1];
            Assert.That(book.Id, Is.EqualTo(2));
            Assert.That(book.Author, Is.EqualTo("Margaret Atwood"));
            Assert.That(book.Country, Is.EqualTo("Canada"));
            Assert.That(book.Title, Is.EqualTo("The Handmaid's Tale"));
            Assert.That(book.Language, Is.EqualTo("English"));
            Assert.That(book.Price, Is.EqualTo(29.95));
            Assert.That(book.Genre, Is.EqualTo("novel"));
            Assert.That(book.Isbn, Is.EqualTo("1-861002-30-1"));
            Assert.That(book.PublicationDate, Is.EqualTo("1985-01-01"));

            book = bookList.Books[2];
            Assert.That(book.Id, Is.EqualTo(3));
            Assert.That(book.Author, Is.EqualTo("Jane Austen"));
            Assert.That(book.Country, Is.EqualTo("United Kingdom"));
            Assert.That(book.Title, Is.EqualTo("Sense and Sensibility"));
            Assert.That(book.Language, Is.EqualTo("English"));
            Assert.That(book.Price, Is.EqualTo(19.95));
            Assert.That(book.Genre, Is.EqualTo("novel"));
            Assert.That(book.Isbn, Is.EqualTo("1-861001-45-3"));
            Assert.That(book.PublicationDate, Is.EqualTo("1811-01-01"));
        }

    [Test]
    public void ValidateSchema()
    {
            ValidateSchema(this.content, this.schema, TargetNamespaces.BooksNamespace);
        }

    [Test]
    public void LoadXmlAndTestElementPrefixes()
    {
        LoadXmlAndTestElementPrefixes(this.content, NamespacePrefix);
        }

    [XmlRoot("books", Namespace = TargetNamespaces.BooksNamespace)]
    public class BookList
    {
        [XmlElement("book")]
        public List<Book> Books { get; } = new();
    }

    public class Book
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("author")]
        public string Author { get; set; } = null!;

        [XmlElement("country")]
        public string Country { get; set; } = null!;

        [XmlElement("title")]
        public string Title { get; set; } = null!;

        [XmlElement("language")]
        public string Language { get; set; } = null!;

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

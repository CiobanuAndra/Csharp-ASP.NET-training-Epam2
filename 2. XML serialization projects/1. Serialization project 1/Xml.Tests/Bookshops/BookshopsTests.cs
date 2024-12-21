using System.Xml.Serialization;
using Microsoft.Win32.SafeHandles;
using NUnit.Framework;

namespace Xml.Tests.Bookshops;

[TestFixture]
public class BookshopsTests : XmlTestFixtureBase
{
    private const string SourceFileName = "bookshops.xml";
    private const string SchemaFileName = "Bookshops.bookshops.xsd";
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
            BookshopList bookshopList = Deserialize<BookshopList>(this.content);

            Assert.That(bookshopList, Is.Not.Null);
            Assert.That(bookshopList.Bookshops, Is.Not.Null);
            Assert.That(bookshopList.Bookshops.Count, Is.EqualTo(3));

            var bookshop = bookshopList.Bookshops[0];
            Assert.That(bookshop.Id, Is.EqualTo(1));
            Assert.That(bookshop.Name, Is.EqualTo("Amazon"));
            Assert.That(bookshop.Website, Is.EqualTo("https://amazon.com"));
            Assert.That(bookshop.Books, Is.Not.Null);
            Assert.That(bookshop.Books.Count, Is.EqualTo(2));

            var book = bookshop.Books[0];
            Assert.That(book.Id, Is.EqualTo(1));
            Assert.That(book.Authors, Is.Not.Null);
            Assert.That(book.Authors.Count, Is.EqualTo(1));
            Assert.That(book.Authors[0], Is.EqualTo("Alexandre Dumas"));
            Assert.That(book.Title, Is.EqualTo("The Three Musketeers"));
            Assert.That(book.Genres, Is.Not.Null);
            Assert.That(book.Genres.Count, Is.EqualTo(3));
            Assert.That(book.Genres[0], Is.EqualTo("Historical novel"));
            Assert.That(book.Genres[1], Is.EqualTo("Adventure novel"));
            Assert.That(book.Genres[2], Is.EqualTo("Swashbuckler"));
            Assert.That(book.Categories, Is.Not.Null);
            Assert.That(book.Categories.Count, Is.EqualTo(2));
            Assert.That(book.Categories[0], Is.EqualTo("Action"));
            Assert.That(book.Categories[1], Is.EqualTo("Adventure"));
            Assert.That(book.Price, Is.Not.Null);
            Assert.That(book.Price.Value, Is.EqualTo(11.13M));
            Assert.That(book.Price.Currency, Is.EqualTo("USD"));
            Assert.That(book.Language, Is.EqualTo("English"));

            book = bookshop.Books[1];
            Assert.That(book.Id, Is.EqualTo(2));
            Assert.That(book.Authors, Is.Not.Null);
            Assert.That(book.Authors.Count, Is.EqualTo(2));
            Assert.That(book.Authors[0], Is.EqualTo("Terry Pratchett"));
            Assert.That(book.Authors[1], Is.EqualTo("Neil Gaiman"));
            Assert.That(book.Title, Is.EqualTo("The Illustrated Good Omens"));
            Assert.That(book.Genres, Is.Not.Null);
            Assert.That(book.Genres.Count, Is.EqualTo(2));
            Assert.That(book.Genres[0], Is.EqualTo("Fantasy novel"));
            Assert.That(book.Genres[1], Is.EqualTo("Comedy novel"));
            Assert.That(book.Categories, Is.Not.Null);
            Assert.That(book.Categories.Count, Is.EqualTo(2));
            Assert.That(book.Categories[0], Is.EqualTo("Fantasy"));
            Assert.That(book.Categories[1], Is.EqualTo("Science and Religion"));
            Assert.That(book.Price, Is.Not.Null);
            Assert.That(book.Price.Value, Is.EqualTo(39.39M));
            Assert.That(book.Price.Currency, Is.EqualTo("USD"));
            Assert.That(book.Language, Is.EqualTo("English"));

            bookshop = bookshopList.Bookshops[1];
            Assert.That(bookshop.Id, Is.EqualTo(2));
            Assert.That(bookshop.Name, Is.EqualTo("1000 livres et vous"));
            Assert.That(bookshop.Website, Is.EqualTo("https://1000livresetvous.com/"));
            Assert.That(bookshop.Books, Is.Not.Null);
            Assert.That(bookshop.Books.Count, Is.EqualTo(2));

            book = bookshop.Books[0];
            Assert.That(book.Id, Is.EqualTo(1));
            Assert.That(book.Authors, Is.Not.Null);
            Assert.That(book.Authors.Count, Is.EqualTo(1));
            Assert.That(book.Authors[0], Is.EqualTo("Alexandre Dumas"));
            Assert.That(book.Title, Is.EqualTo("Les Trois Mousquetaires"));
            Assert.That(book.Genres, Is.Not.Null);
            Assert.That(book.Genres.Count, Is.EqualTo(3));
            Assert.That(book.Genres[0], Is.EqualTo("Historical novel"));
            Assert.That( book.Genres[1], Is.EqualTo("Adventure novel"));
            Assert.That(book.Genres[2], Is.EqualTo("Swashbuckler"));
            Assert.That(book.Categories, Is.Not.Null);
            Assert.That(book.Categories.Count, Is.EqualTo(2));
            Assert.That(book.Categories[0], Is.EqualTo("Fiction"));
            Assert.That(book.Categories[1], Is.EqualTo("Littérature d'aventure"));
            Assert.That(book.Price, Is.Not.Null);
            Assert.That(book.Price.Value, Is.EqualTo(16M));
            Assert.That(book.Price.Currency, Is.EqualTo("EUR"));
            Assert.That(book.Language, Is.EqualTo("French"));

            book = bookshop.Books[1];
            Assert.That(book.Id, Is.EqualTo(2));
            Assert.That(book.Authors, Is.Not.Null);
            Assert.That(book.Authors.Count, Is.EqualTo(1));
            Assert.That(book.Authors[0], Is.EqualTo("Arthur Conan Doyle"));
            Assert.That(book.Title, Is.EqualTo("Une étude en rouge"));
            Assert.That(book.Genres, Is.Not.Null);
            Assert.That(book.Genres.Count, Is.EqualTo(2));
            Assert.That(book.Genres[0], Is.EqualTo("Detective fiction"));
            Assert.That(book.Genres[1], Is.EqualTo("Short stories"));
            Assert.That(book.Categories, Is.Not.Null);
            Assert.That(book.Categories.Count, Is.EqualTo(3));
            Assert.That(book.Categories[0], Is.EqualTo("Fiction"));
            Assert.That(book.Categories[1], Is.EqualTo("Littérature d'aventure"));
            Assert.That(book.Categories[2], Is.EqualTo("Détective"));
            Assert.That(book.Price, Is.Not.Null);
            Assert.That(book.Price.Value, Is.EqualTo(36M));
            Assert.That(book.Price.Currency, Is.EqualTo("EUR"));
            Assert.That(book.Language, Is.EqualTo("French"));

            bookshop = bookshopList.Bookshops[2];
            Assert.That(bookshop.Id, Is.EqualTo(3));
            Assert.That(bookshop.Name, Is.EqualTo("Oz"));
            Assert.That(bookshop.Website, Is.EqualTo("https://oz.by"));
            Assert.That(bookshop.Books, Is.Not.Null);
            Assert.That(bookshop.Books.Count, Is.EqualTo(2));

            book = bookshop.Books[0];
            Assert.That(book.Id, Is.EqualTo(2));
            Assert.That(book.Authors, Is.Not.Null);
            Assert.That(book.Authors.Count, Is.EqualTo(1));
            Assert.That(book.Authors[0], Is.EqualTo("Александр Дюма"));
            Assert.That(book.Title, Is.EqualTo("Три мушкетера"));
            Assert.That(book.Genres, Is.Not.Null);
            Assert.That(book.Genres.Count, Is.EqualTo(3));
            Assert.That(book.Genres[0], Is.EqualTo("Historical novel"));
            Assert.That(book.Genres[1], Is.EqualTo("Adventure novel"));
            Assert.That(book.Genres[2], Is.EqualTo("Swashbuckler"));
            Assert.That(book.Categories, Is.Not.Null);
            Assert.That(book.Categories.Count, Is.EqualTo(3));
            Assert.That(book.Categories[0], Is.EqualTo("Художественная литература"));
            Assert.That(book.Categories[1], Is.EqualTo("Классическая литература"));
            Assert.That(book.Categories[2], Is.EqualTo("Зарубежная литература"));
            Assert.That(book.Price, Is.Not.Null);
            Assert.That(book.Price.Value, Is.EqualTo(34.68M));
            Assert.That(book.Price.Currency, Is.EqualTo("BYN"));
            Assert.That(book.Language, Is.EqualTo("Русский"));

            book = bookshop.Books[1];
            Assert.That(book.Id, Is.EqualTo(1));
            Assert.That(book.Authors, Is.Not.Null);
            Assert.That(book.Authors.Count, Is.EqualTo(1));
            Assert.That(book.Authors[0], Is.EqualTo("Arthur Conan Doyle"));
            Assert.That(book.Title, Is.EqualTo("The Adventures of Sherlock Holmes"));
            Assert.That(book.Genres, Is.Not.Null);
            Assert.That(book.Genres.Count, Is.EqualTo(2));
            Assert.That(book.Genres[0], Is.EqualTo("Detective fiction"));
            Assert.That( book.Genres[1], Is.EqualTo("Short stories"));
            Assert.That(book.Categories, Is.Not.Null);
            Assert.That(book.Categories.Count, Is.EqualTo(3));
            Assert.That(book.Categories[0], Is.EqualTo("Нехудожественная литература"));
            Assert.That( book.Categories[1], Is.EqualTo("Изучение иностранных языков"));
            Assert.That(book.Categories[2], Is.EqualTo("Адаптированные книги"));
            Assert.That(book.Price, Is.Not.Null);
            Assert.That(book.Price.Value, Is.EqualTo(11.22M));
            Assert.That(book.Price.Currency, Is.EqualTo("BYN"));
            Assert.That(book.Language, Is.EqualTo("English"));
        }

    [Test]
    public void ValidateSchema()
    {
            ValidateSchema(this.content, this.schema, TargetNamespaces.BookshopsNamespace);
        }

    [Test]
    public void LoadXmlAndTestElementPrefixes()
    {
        LoadXmlAndTestElementPrefixes(this.content, NamespacePrefix);
        }

    [XmlRoot("bookshops", Namespace = TargetNamespaces.BookshopsNamespace)]
    public class BookshopList
    {
        [XmlElement("bookshop")]
        public List<Bookshop> Bookshops { get; } = new();
    }

    public class Bookshop
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("website")]
        public string Website { get; set; } = null!;

        [XmlArray("books")]
        [XmlArrayItem("book")]
        public List<Book> Books { get; } = new();
    }

    public class Book
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlArray("authors")]
        [XmlArrayItem("author")]
        public List<string> Authors { get; } = new();

        [XmlElement("title")]
        public string Title { get; set; } = null!;

        [XmlArray("genres")]
        [XmlArrayItem("genre")]
        public List<string> Genres { get; } = new();

        [XmlArray("categories")]
        [XmlArrayItem("category")]
        public List<string> Categories { get; } = new();

        [XmlElement("price")]
        public BookPrice Price { get; set; } = null!;

        [XmlElement("language")]
        public string Language { get; set; } = null!;
    }

    public class BookPrice
    {
        [XmlAttribute("currency")]
        public string Currency { get; set; } = null!;

        [XmlText]
        public decimal Value { get; set; }
    }
}

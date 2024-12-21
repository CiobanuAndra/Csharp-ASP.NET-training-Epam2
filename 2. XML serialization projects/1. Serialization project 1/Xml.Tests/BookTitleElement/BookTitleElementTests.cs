using System.Xml.Serialization;
using NUnit.Framework;

namespace Xml.Tests.BookTitleElement;

[TestFixture]
public class BookTitleElementTests : XmlTestFixtureBase
{
    private const string SourceFileName = "book-title-element.xml";

    private string content = null!;

    [SetUp]
    public void SetUp()
    {
            this.content = ReadContent(SourceFileName);
        }

    [Test]
    public void DeserializeAndTestContent()
    {
            Book book = Deserialize<Book>(this.content);

            Assert.That(book, Is.Not.Null);
            Assert.That(book.Title, Is.EqualTo("Pride And Prejudice"));
        }

    [XmlRoot("book", Namespace = "")]
    public class Book
    {
        [XmlElement("title")]
        public string Title { get; set; } = null!;
    }
}

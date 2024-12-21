using System.Xml.Serialization;
using NUnit.Framework;

namespace Xml.Tests.BookNamespacePrefix;

[TestFixture]
public class BookNamespacePrefixTests : XmlTestFixtureBase
{
    private const string SourceFileName = "book-namespace-prefix.xml";
    private const string SchemaFileName = "BookNamespacePrefix.book-namespace-prefix.xsd";
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
            Book book = Deserialize<Book>(this.content);

            Assert.That(book, Is.Not.Null);
            Assert.That(book.Title, Is.EqualTo("Pride And Prejudice"));
            Assert.That(book.Id, Is.EqualTo(1));
        }

    [Test]
    public void ValidateSchema()
    {
            ValidateSchema(this.content, this.schema, TargetNamespaces.BookNamespace);
        }

    [Test]
    public void LoadXmlAndTestElementPrefixes()
    {
        LoadXmlAndTestElementPrefixes(this.content, NamespacePrefix);
        }

    [XmlRoot("book", Namespace = TargetNamespaces.BookNamespace)]
    public class Book
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("title")]
        public string Title { get; set; } = null!;
    }
}

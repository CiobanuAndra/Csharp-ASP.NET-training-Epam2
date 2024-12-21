using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using NUnit.Framework;

[assembly: CLSCompliant(true)]

namespace Xml.Tests;

public abstract class XmlTestFixtureBase
{
    protected static string ReadContent(string xmlFileName)
    {
        var assembly = typeof(Stub).Assembly;
        return ReadManifestResource(assembly, xmlFileName);
    }

    protected static string ReadSchema(string schemaFileName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        return ReadManifestResource(assembly, schemaFileName);
    }

    protected static T Deserialize<T>(string content)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using var stringReader = new StringReader(content);
        using XmlReader xmlReader = XmlReader.Create(stringReader);
        return (T)xmlSerializer.Deserialize(xmlReader)!;
    }

    protected static void ValidateSchema(string content, string schema, string targetNamespace)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(content);

        using var stringReader = new StringReader(schema);
        using XmlReader reader = XmlReader.Create(stringReader);
        var xmlSchemaSet = new XmlSchemaSet();
        XmlSchema xmlSchema = xmlSchemaSet.Add(targetNamespace, reader)!;
        _ = xmlDocument.Schemas.Add(xmlSchema);

        xmlDocument.Validate((_, e) => { Assert.That(false, e.Message); });
    }

    protected static void LoadXmlAndTestElementPrefixes(string content, string namespacePrefix)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(content);

        Assert.That(xmlDocument.DocumentElement, Is.Not.Null);
        Assert.That(namespacePrefix, Is.EqualTo(xmlDocument.DocumentElement!.Prefix));

        TestPrefixes(xmlDocument.DocumentElement.ChildNodes, namespacePrefix);
    }

    private static string ReadManifestResource(Assembly assembly, string fileName)
    {
        string manifestResourceName = assembly.GetName().Name + "." + fileName;
        using Stream stream = assembly.GetManifestResourceStream(manifestResourceName)!;
        using StreamReader streamReader = new StreamReader(stream);
        return streamReader.ReadToEnd();
    }

    private static void TestPrefixes(XmlNodeList xmlNodeList, string namespacePrefix)
    {
        foreach (XmlNode element in xmlNodeList)
        {
            if (element is not XmlElement)
            {
                continue;
            }

            Assert.That(namespacePrefix, Is.EqualTo(element.Prefix));

            TestPrefixes(element.ChildNodes, namespacePrefix);
        }
    }
}

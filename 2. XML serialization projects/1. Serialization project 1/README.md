# XML
 
Intermediate level task for practicing using XML language.

In this task, you will describe data structures using XML language. You will work with the `Books` data model and the book information taken from the [XmlDocument class documentation page](https://learn.microsoft.com/en-us/dotnet/api/system.xml.xmldocument).

Estimated time to complete the task - 2h.

The task requires .NET 8 SDK installed.    
       
         
## Task Description

**To complete the task, you need to take 12 steps**. Be aware that the order of XML elements is important for a successful unit test run. 


### 1. Add a Book Title with the "title" Element

Add a new `title` element to `book` element with a book title "Pride And Prejudice" in the [book-title-element.xml](Xml/book-title-element.xml) file.

| Node Name | Node Type | Value               | Description   |
|-----------|-----------|---------------------|---------------|
| title     | element   | Pride And Prejudice | A book title. |

Code sample:

```xml
<book>
  <title>Pride And Prejudice</title>
</book>
```


### 2. Add the Book Title with the "title" Attribute

Now, add a new `title` attribute to the `book` element with the book title "Pride And Prejudice" in the [book-title-attribute.xml](Xml/book-title-attribute.xml) file.

| Node Name | Node Type | Value               | Description   |
|-----------|-----------|---------------------|---------------|
| title     | attribute | Pride And Prejudice | A book title. |

Code sample:

```xml
<book title="Pride And Prejudice" />
```


### 3. Add a Namespace

Add a new namespace with "http://www.contoso.com/book" URI to the `book` element in the [book-namespace.xml](Xml/book-namespace.xml) file.

| Node Name | Node Type | Value                       | Description               |
|-----------|-----------|-----------------------------|---------------------------|
| book      | namespace | http://www.contoso.com/book | A root element namespace. |

Code sample:

```xml
<book xmlns="http://www.contoso.com/book">
  <title>Pride And Prejudice</title>
</book>
```


### 4. Describe the Book with Elements

Add the namespace and the elements from the table below to the `book` element in the [book-elements.xml](Xml/book-elements.xml) file.

| Node Name       | Node Type | Value                       | Description               |
|-----------------|-----------|-----------------------------|---------------------------|
| book            | namespace | http://www.contoso.com/book | A root element namespace. |
| title           | element   | Pride And Prejudice         | A book title.             |
| price           | element   | 24.95                       | A book price in USD.      |
| genre           | element   | novel                       | A book genre.             |
| isbn            | element   | 1-861001-57-8               | An ISBN number.           |
| publicationDate | element   | 1823-01-28                  | A publication date.       |


### 5. Describe the Book with Attributes

Add the namespace and the attributes from the table below to the `book` element in the [book-attributes.xml](Xml/book-attributes.xml) file.

| Node Name       | Node Type | Value                       | Description               |
|-----------------|-----------|-----------------------------|---------------------------|
| book            | namespace | http://www.contoso.com/book | A root element namespace. |
| title           | attribute | Pride And Prejudice         | A book title.             |
| price           | attribute | 24.95                       | A book price in USD.      |
| genre           | attribute | novel                       | A book genre.             |
| isbn            | attribute | 1-861001-57-8               | An ISBN number.           |
| publicationDate | attribute | 1823-01-28                  | A publication date.       |


### 6. Add a Namespace with a Prefix

First, add the namespace with "http://www.contoso.com/book" URI and the prefix `co` to the `book` element in the [book-namespace-prefix.xml](Xml/book-namespace-prefix.xml) file. Then, add the prefix to the elements `book` and `title`.

| Node Name      | Node Type  | Value                       | Description               |
|----------------|------------|-----------------------------|---------------------------|
| book           | prefix     | co                          | A namespace prefix.       |
| book           | namespace  | http://www.contoso.com/book | A root element namespace. |

Code sample:

```xml
<co:book xmlns:co="http://www.contoso.com/book" id="1">
  <co:title>Pride And Prejudice</co:title>
</co:book>
```


### 7. Describe the List of Books with Elements

Add a list of books to the `books` root element in the [book-list-elements.xml](Xml/book-list-elements.xml) file. Each book is an XML structure with the `book` parent element that has a list of child elements like in step 4.

| Title                 | Price | Genre | ISBN          | Publication Date |
|-----------------------|-------|-------|---------------|------------------|
| Pride And Prejudice   | 24.95 | novel | 1-861001-57-8 | 1823-01-28       |
| The Handmaid's Tale   | 29.95 | novel | 1-861002-30-1 | 1985-01-01       |
| Sense and Sensibility | 19.95 | novel | 1-861001-45-3 | 1811-01-01       |

All XML elements should be prefixed with the `co` namespace. Only the root XML element `books` should have a namespace. 


### 8. Describe the List of Books with Attributes

Add the list of books to the `books` root element in the [book-list-attributes.xml](Xml/book-list-attributes.xml) file. Each book is an XML structure with the `book` element that has a list of attributes like in step 5. You will find all the necessary information in the list provided in step 7.  

All XML elements should be prefixed with the `co` namespace. Only the root XML element `books` should have a namespace. 


### 9.Add More Information

First, copy the XML code from the [book-list-elements.xml](Xml/book-list-elements.xml) file to the [book-list-extended.xml](Xml/book-list-extended.xml) file. Then, add the following elements and attributes for all the books in the list.

List of elements:

| Node Name        | Node Type | Description                                     |
|------------------|-----------|-------------------------------------------------|
| id               | attribute | A book identifier.                              |
| author           | element   | A book author.                                  |
| country          | element   | A country where a book was initially published. |
| title            | element   | A book title.                                   |
| language         | element   | A book language.                                |
| price            | element   | A book price in USD.                            |
| genre            | element   | A book genre.                                   |
| isbn             | element   | An ISBN number.                                 |
| publicationDate  | element   | A publication date.                             |

Book information:

| Book ID | Author          | Country        | Title                 | Language | Price | Genre | ISBN          | Publication Date |
|---------|-----------------|----------------|-----------------------|----------|-------|-------|---------------|------------------|
| 1       | Jane Austen     | United Kingdom | Pride And Prejudice   | English  | 24.95 | novel | 1-861001-57-8 | 1823-01-28       |
| 2       | Margaret Atwood | Canada         | The Handmaid's Tale   | English  | 29.95 | novel | 1-861002-30-1 | 1985-01-01       |
| 3       | Jane Austen     | United Kingdom | Sense and Sensibility | English  | 19.95 | novel | 1-861001-45-3 | 1811-01-01       |

All elements should have `co` namespace prefix. The only `books` root element should have a namespace.


### 10. Decompose the Publication Date

Copy the XML code from the [book-list-elements.xml](Xml/book-list-elements.xml) file to the [book-list-publication-date.xml](Xml/book-list-publication-date.xml) file and decompose the `publicationDate` element into three sub-elements (`publicationYear`, `publicationMonth` and `publicationDay`) for all books in the list. 

New element structure:

| Node Name                        | Node Type | Description                                     |
|----------------------------------|-----------|-------------------------------------------------|
| publicationDate                  | element   | A root node for publication date information.   |
| publicationDate\publicationYear  | element   | A year of publication date.                     |
| publicationDate\publicationMonth | element   | A month of publication date.                    |
| publicationDate\publicationDay   | element   | A day of publication date.                      |

Code sample:

```xml
<co:publicationDate>
  <co:publicationYear>1823</co:publicationYear>
  <co:publicationMonth>01</co:publicationMonth>
  <co:publicationDay>28</co:publicationDay>
</co:publicationDate>
```

All XML elements should be prefixed with the `co` namespace. Only the root XML element `books` should have a namespace. 


### 11. Add a Genre List

Copy the XML code the [book-list-elements.xml](Xml/book-list-elements.xml) file to the [book-list-genres.xml](Xml/book-list-genres.xml) file and transform the `genre` element into the genre list for all books in the list.

New element structure:

| Node Name    | Node Type | Description                      |
|--------------|-----------|----------------------------------|
| genres       | element   | A root node for list of genres.  |
| genres\genre | element   | A book genre.                    |

Code sample:

```xml
<co:genres>
  <co:genre>novel</co:genre>
</co:genres>
```

While `genres` element defines the genre list, each `genre` element defines a specific genre.

Replace the `novel` genre for all books with the genre list from the table below:

| Title                 | Genres                                                |
|-----------------------|-------------------------------------------------------|
| Pride And Prejudice   | Classic Regency novel<br />Romance novel              |
| The Handmaid's Tale   | Dystopian novel<br />Speculative fiction<br />Tragedy |
| Sense and Sensibility | Romance novel                                         |


All XML elements should be prefixed with the `co` namespace. Only the root XML element `books` should have a namespace. 


### 12. Complete the Bookshop List

First, review the XML Schema and XML Schema Definition (XSD) tutorials. Then, read and analyze XML schemas for the XML files you created in the previous steps:

| Step | XML File                                                                          | XML Schema                                                                                                    |
|------|-----------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|
| 3    | [book-namespace.xml](Xml/book-namespace.xml)                           | [book-namespace.xsd](Xml.Tests/BookNamespace/book-namespace.xsd)                                   |
| 4    | [book-elements.xml](Xml/book-elements.xml)                             | [book-elements.xsd](Xml.Tests/BookElements/book-elements.xsd)                                      |
| 5    | [book-attributes.xml](Xml/book-attributes.xml)                         | [book-attributes.xsd](Xml.Tests/BookAttributes/book-attributes.xsd)                                |
| 6    | [book-namespace-prefix.xml](Xml/book-namespace-prefix.xml)             | [book-namespace-prefix.xsd](Xml.Tests/BookNamespacePrefix/book-namespace-prefix.xsd)               |
| 7    | [book-list-elements.xml](Xml/book-list-elements.xml)                   | [book-list-elements.xsd](Xml.Tests/BookListElements/book-list-elements.xsd)                        |
| 8    | [book-list-attributes.xml](Xml/book-list-attributes.xml)               | [book-list-attributes.xsd](Xml.Tests/BookListAttributes/book-list-attributes.xsd)                  |
| 9    | [book-list-extended.xml](Xml/book-list-extended.xml)                   | [book-list-extended.xsd](Xml.Tests/BookListExtended/book-list-extended.xsd)                        |
| 10   | [book-list-publication-date.xml](Xml/book-list-publication-date.xml)   | [book-list-publication-date.xsd](Xml.Tests/BookListPublicationDate/book-list-publication-date.xsd) |
| 11   | [book-list-genres.xml](Xml/book-list-genres.xml)                       | [book-list-genres.xsd](Xml.Tests/BookListGenres/book-list-genres.xsd)                              |

After that, study the XML schema in the [bookshops.xsd](Xml.Tests/Bookshops/bookshops.xsd) file.

Now, complete the [bookshops.xml](Xml/bookshops.xml) with the bookshop data according to the XML schema. You can find the bookshop data in the [BookshopsTests.cs](Xml.Tests/Bookshops/BookshopsTests.cs) file.


## Fix Compiler Issues

Only XML files should be affected by your changes. Neither errors nor warning messages are expected during the compilation process.


## Task Checklist

1. Rebuild the solution.
1. Run all unit tests with Visual Studio and make sure there are no failed unit tests. Fix your code to make all tests GREEN. 
1. Review all changes, make sure only XML files (.xml) in the [Xml](Xml\) project have been changed. Make sure there are no changes in C# (.cs) and project files (.csproj) or in the [Xml.Tests](Xml.Tests\) project.
1. Stage your changes and create a commit.
1. Commit and push your code to the remote task repository.


## See also

* Tutorials
  * [XML Tutorial on w3schools.com](https://www.w3schools.com/xml)
  * [XML Tutorial on tutorialspoint.com](https://www.tutorialspoint.com/xml)
  * [XML Schema (XSD Schema) Tutorial](https://www.w3schools.com/xml/schema_intro.asp)
  * [XSD Tutorial](https://www.tutorialspoint.com/xsd/)
* [XmlDocument Class](https://learn.microsoft.com/en-us/dotnet/api/system.xml.xmldocument)
* [XML](https://en.wikipedia.org/wiki/XML)
* [Extensible Markup Language (XML)](https://www.w3.org/XML/)

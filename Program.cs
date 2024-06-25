using System.Xml.Linq;

namespace LINQToXMLDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            string xmlString = @"
                                <Books>
                                  <Book>
                                    <Title>LINQ in Action</Title>
                                    <Author>Fabrice Marguerie</Author>
                                  </Book>
                                  <Book>
                                    <Title>Pro LINQ</Title>
                                    <Author>Joseph C. Rattz</Author>
                                  </Book>
                                </Books>";

            XDocument xmlDoc = XDocument.Parse(xmlString);

            var books = from book in xmlDoc.Descendants("Book")
                        select new
                        {
                            Title = book.Element("Title")?.Value,
                            Author = book.Element("Author")?.Value
                        };

            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
            }
        }
    }
}

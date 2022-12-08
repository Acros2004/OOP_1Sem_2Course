using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;

namespace DeSerialisation
{
    class Program
    {
        static void Main(string[] args)
        {
            Kvitant kvi1 = new Kvitant(1234, 313131, 11);
            Kvitant kvi2 = new Kvitant(1111, 111111, 12);
            Kvitant kvi3 = new Kvitant(2222, 1222333, 24);

            Kvitant[] kviGroup = { kvi1, kvi2, kvi3 };
            Kvitant[] kviGroupTemp = null;

            CustomSerializer.Serialize<Kvitant[]>(kviGroup, "xml", "C:\\Users\\noname\\Desktop\\123\\OOP\\lab13\\DeSerialisation\\CustomSerialize.xml");
            CustomSerializer.Deserialize<Kvitant[]>(ref kviGroupTemp, "xml", "C:\\Users\\noname\\Desktop\\123\\OOP\\lab13\\DeSerialisation\\CustomSerialize.xml");

            foreach (var doc in kviGroupTemp)
            {
                Console.WriteLine(doc);
            }
            Kvitant[] kviGroupTemp2 = null;
            CustomSerializer.Serialize<Kvitant[]>(kviGroup, "json", "C:\\Users\\noname\\Desktop\\123\\OOP\\lab13\\DeSerialisation\\CustomSerialize.json");
            CustomSerializer.Deserialize<Kvitant[]>(ref kviGroupTemp2, "json", "C:\\Users\\noname\\Desktop\\123\\OOP\\lab13\\DeSerialisation\\CustomSerialize.json");
            foreach (var doc in kviGroupTemp2)
            {
                Console.WriteLine(doc);
            }
            Kvitant[] kviGroupTemp3 = null;
            CustomSerializer.Serialize<Kvitant[]>(kviGroup, "soap", "C:\\Users\\noname\\Desktop\\123\\OOP\\lab13\\DeSerialisation\\CustomSerialize.soap");
            CustomSerializer.Deserialize<Kvitant[]>(ref kviGroupTemp3, "soap", "C:\\Users\\noname\\Desktop\\123\\OOP\\lab13\\DeSerialisation\\CustomSerialize.soap");
            foreach (var doc in kviGroupTemp3)
            {
                Console.WriteLine(doc);
            }
            Kvitant[] kviGroupTemp4 = null;
            CustomSerializer.Serialize<Kvitant[]>(kviGroup, "bin", "C:\\Users\\noname\\Desktop\\123\\OOP\\lab13\\DeSerialisation\\CustomSerialize.txt");
            CustomSerializer.Deserialize<Kvitant[]>(ref kviGroupTemp4, "bin", "C:\\Users\\noname\\Desktop\\123\\OOP\\lab13\\DeSerialisation\\CustomSerialize.txt");
            foreach (var doc in kviGroupTemp4)
            {
                Console.WriteLine(doc);
            }


            findXMLTegs(@"C:\Users\noname\Desktop\123\OOP\lab13\DeSerialisation\XML.xml");
            Console.WriteLine("========================================");
            LinqToXML(@"C:\Users\noname\Desktop\Lab_13\Lab_13\Lab_13\newXML.xml");




        }

        public static void LinqToXML(string path)
        {
            XDocument documents = new XDocument(new XElement("Documents",
                       new XElement("document",
                           new XAttribute("name", "Kvitancia"),
                           new XElement("amount", "80"),
                           new XElement("signa", "false")),
                       new XElement("document",
                           new XAttribute("name", "Check"),
                           new XElement("amount", "10"),
                           new XElement("signa", "true"))));
            documents.Save(Path.GetFullPath(path));

            var items1 = from man in documents.Element("Documents").Elements("document")
                         where man.Element("signa").Value == "true"
                         select new DocumentName
                         {
                             Name = man.Attribute("name").Value
                         };

            foreach (var item in items1)
                Console.WriteLine($"{item.Name}");
        }
        public static void findXMLTegs(string path)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            var xRoot = xmlDocument.DocumentElement;

            var xmlNodes = xRoot.SelectNodes("*");

            foreach (XmlNode node in xmlNodes)
                Console.WriteLine(node.Name);

            Console.WriteLine("Содержимое Type:");
            var xmlNameNodes = xRoot.SelectNodes("Type");

            foreach (XmlNode nameNode in xmlNameNodes)
                Console.WriteLine(nameNode.InnerText);
        }
        class DocumentName
        {
            public string Name { get; set; }
        }

       
    }
}
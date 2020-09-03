using System;
using System.Xml;

namespace parseXml
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("http://www.cbr.ru/scripts/XML_daily.asp");
            string nominal = "";
            string name = "";
            string value = "";

            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("ID");
                    if (attr.Value == "R01200")
                    {
                        Console.WriteLine(attr.Value);
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            if (childnode.Name == "Name")
                            {
                                name = childnode.InnerText;
                                //Console.WriteLine($"Валюта: {childnode.InnerText}");
                            }

                            if (childnode.Name == "Nominal")
                            {
                                nominal = childnode.InnerText;
                                //Console.WriteLine($"Курс: {childnode.InnerText}");
                            }

                            if (childnode.Name == "Value")
                            {
                                value = childnode.InnerText;
                                //Console.WriteLine($"Курс: {childnode.InnerText}");
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"Курс {nominal} {name} равен {value} рублям");
            Console.Read();
        }
    }
}

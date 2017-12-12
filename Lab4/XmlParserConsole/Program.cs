using System;
using System.IO;
using System.Linq;
using System.Xml;
using XmlParserLib;

namespace XmlParserConsole
{
    class Program
    {
        private static string _path = @"D:/NET/_.NET/Lab4/XmlParserConsole/xml";
        static void Main(string[] args)
        {
            var xmlParser = new XmlParser();
            var xmlList = GetNodeLists(_path);

            var a = xmlParser.GetDifferentNode(xmlList, "sort/@s_c");

        }

        public static XmlDocument[] GetNodeLists(string path)
        {
            var files = Directory.GetFiles(path);
            return files.Select(p =>
                {
                    var xDoc = new XmlDocument();
                    try
                    {
                        xDoc.Load(p);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    return xDoc;
                })
                .ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using NLog;
using XmlParserLib;

namespace XmlParserConsole
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            var section = (CustomSection) ConfigurationManager.GetSection("customConfig");
            var path = section.Path;
            var xpath = section.XPath;
            var countThread = section.ThreadCount;
            var xmlParser = new XmlParser();
            var xmlList = GetXmlDocuments(path);
            var results = xmlParser.GetDifferentNode(xmlList, xpath, countThread);
            foreach (var res in results)
            {
                Console.WriteLine($"{res.Key}, {res.Value}");
            }
            Console.ReadKey();

        }

        public static IEnumerable<XmlDocument> GetXmlDocuments(string path, int countThread= 10)
        {
            var files = Directory.GetFiles(path);
            var xmls = new List<XmlDocument>();

            Parallel.ForEach(files, new ParallelOptions {MaxDegreeOfParallelism = countThread},
                file =>
                {
                    var xDoc = new XmlDocument();
                    try
                    {
                        xDoc.Load(file);
                    }
                    catch (Exception e)
                    {
                        logger.Error(e, e.Message);
                    }
                    if (xDoc.DocumentElement!=null)
                    {
                        lock (xmls)
                        {
                            xmls.Add(xDoc);
                        }
                    } 
                });
            return xmls;
        }
    }
}

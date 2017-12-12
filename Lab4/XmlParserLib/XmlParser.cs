using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace XmlParserLib
{
    public class XmlParser
    {
        private readonly Dictionary<string, int> _nodes = new Dictionary<string, int>();

        public Dictionary<string, int> GetDifferentNode(IEnumerable<XmlDocument> xmlDocuments, string xpath, int maxThread = 10)
        {
            var na = "N/A";
            Parallel.ForEach(xmlDocuments,
                new ParallelOptions { MaxDegreeOfParallelism = maxThread },
                (xml) =>
            {
                var nodes = GetNode(xml, xpath);
                if (nodes == null || !nodes.Any())
                {
                    lock (_nodes)
                    {
                        if (_nodes.ContainsKey(na))
                        {
                            _nodes[na]++;
                        }
                        else
                        {
                            _nodes.Add(na, 1);
                        }
                    }
                }
                else
                {
                    Parallel.ForEach(nodes, node =>
                    {
                        lock (_nodes)
                        {
                            if (!_nodes.ContainsKey(node.InnerXml))
                            {
                                _nodes.Add(node.InnerXml, 1);
                            }
                            else
                            {
                                _nodes[node.InnerXml]++;
                            }
                        }
                    });
                }
            });
            return _nodes;
        }

        private IEnumerable<XmlNode> GetNode(XmlDocument xml, string xpath)
        {
            if (xml == null)
            {
                throw new ArgumentNullException(nameof(xml));
            }
            var xmlDoc = xml.DocumentElement;
            if (xmlDoc == null)
            {
                throw new ArgumentNullException(nameof(xmlDoc));
            }
            var namesp = xmlDoc.NamespaceURI;
            XmlNodeList list;
            if (!string.IsNullOrEmpty(namesp))
            {
                var pref = "a";
                var nsmgr = new XmlNamespaceManager(xml.NameTable);
                nsmgr.AddNamespace("a", namesp);
                xpath = pref + ":" + xpath;
                list = xmlDoc.SelectNodes(xpath, nsmgr);
            }
            else
            {
                list = xmlDoc.SelectNodes(xpath);
            }
            return list?.Cast<XmlNode>();
        }
    }
}

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

        public Dictionary<string, int> GetDifferentNode(XmlDocument[] xmlNodes, string xpath)
        {
            Parallel.ForEach(xmlNodes, (xml) =>
            {
                var nodes = GetNode(xml);
                var d = nodes.ToArray()[1].SelectSingleNode(xpath);
                var n = nodes.Where(p=>p.Name == xpath);
                Parallel.ForEach(n, node =>
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

            });
            return _nodes;
        }

        private IEnumerable<XmlNode> GetNode(XmlDocument xml)
        {
            if (xml==null)
            {
                throw new ArgumentNullException(nameof(xml));
            }
            var xmlDoc = xml.DocumentElement;
            if (xmlDoc == null)
            {
                throw new ArgumentNullException(nameof(xmlDoc));
            }
            var d = xmlDoc.SelectNodes("*");
            foreach (XmlNode a in d)
            {
                var c = a.InnerXml;
            }
            return xmlDoc.SelectSingleNode("sort/@s_c")?.Cast<XmlNode>();
        }
    }
}

using System.Configuration;

namespace XmlParserConsole
{
    public class CustomSection : ConfigurationSection
    {
        [ConfigurationProperty("path")]
        public string Path
        {
            get
            {
                return (string)this["path"];
            }
            set
            {
                this["path"] = value;
            }
        }
        [ConfigurationProperty("xpath")]
        public string XPath
        {
            get
            {
                return (string)this["xpath"];
            }
            set
            {
                this["xpath"] = value;
            }
        }
        [ConfigurationProperty("threadCount")]
        public int ThreadCount
        {
            get
            {
                return (int)this["threadCount"];
            }
            set
            {
                this["threadCount"] = value;
            }
        }
    }
}

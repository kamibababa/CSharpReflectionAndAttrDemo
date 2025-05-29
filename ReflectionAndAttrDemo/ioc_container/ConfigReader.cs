using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttrDemo.ioc_container
{
    using System.Xml.Linq;

    public static class ConfigReader
    {
        public static string GetLoggerType(string configFilePath)
        {
            var doc = XDocument.Load(configFilePath);
            var loggerElement = doc.Root.Element("logger");
            if (loggerElement == null)
                throw new Exception("Missing <logger> element in config");

            var typeAttr = loggerElement.Attribute("type");
            if (typeAttr == null)
                throw new Exception("Missing 'type' attribute in <logger>");

            return typeAttr.Value;
        }
    }

}

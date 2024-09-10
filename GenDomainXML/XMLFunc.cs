using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GenDomainXML
{
    internal class XMLFunc
    {
        public static void genLocalNetXML(string _localName)
        {
            var model = new localNet
            {
                name = _localName, 
                NetEnterPort = "1010",
                ParentAgentPort = "1020",
                LoggerLevel = new Options { LoggerLevel = "2"}
            };

            FileInfo File = new FileInfo("net.xml"); 
            File.Delete(); // удаляем предыдущий файл 
            var serializer = new XmlSerializer(model.GetType()); // сериализуем 
            FileStream fs = new FileStream("net.xml", FileMode.OpenOrCreate); //определяем файл 
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty); // убираем первую строку с описанием
            serializer.Serialize(fs, model, ns);
        }
    }
}

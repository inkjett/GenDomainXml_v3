using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GenDomainXML
{
    internal class XMLFunc
    {
        public static void genLocalNetXML() //XmlNode _dataIn
        { 
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement root = xmlDoc.CreateElement("Alpha.Net.Agent");
            xmlDoc.AppendChild(root);
           
            XmlElement _name = xmlDoc.CreateElement("Name");
            _name.InnerText = "local";
            root.AppendChild(_name);

            xmlDoc.Save("net.xml");
        
        }
    }
}

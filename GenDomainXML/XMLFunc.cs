using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GenDomainXML
{
    internal class XMLFunc
    {
        public static void genLocalNetXML() //XmlNode _dataIn
        {
            // https://metanit.com/sharp/tutorial/16.3.php

            XmlDocument xmlDoc = new XmlDocument();
            //XDocument comments = new XDocument();

            

            XmlElement root = xmlDoc.CreateElement("Alpha.Net.Agent"); // создаем элемент Alpha.Net.Agent
            XmlElement Options = xmlDoc.CreateElement("Options");

            XmlAttribute _name = xmlDoc.CreateAttribute("name"); // создаем атрибут name
            XmlAttribute _NetEnterPort = xmlDoc.CreateAttribute("NetEnterPort");
            XmlAttribute _ParentAgentPort = xmlDoc.CreateAttribute("ParentAgentPort");
            XmlAttribute _Options = xmlDoc.CreateAttribute("LoggerLevel");
                        
            XmlText _nameText = xmlDoc.CreateTextNode("local"); // просто создаем значение local
            XmlText _NetEnterPortText = xmlDoc.CreateTextNode("1010");
            XmlText _ParentAgentPortText= xmlDoc.CreateTextNode("1012");
            XmlText _OptionsText = xmlDoc.CreateTextNode("2");

            _name.AppendChild(_nameText); // применяем значение local к атрибуту name
            _NetEnterPort.AppendChild(_NetEnterPortText);
            _ParentAgentPort.AppendChild(_ParentAgentPortText);
            _Options.AppendChild(_OptionsText);


            root.Attributes.Append(_name); // добавляем созданный атрибут в рутовый элемент 
            root.Attributes.Append(_NetEnterPort);
            root.Attributes.Append(_ParentAgentPort);
            Options.Attributes.Append(_Options);

            XmlComment _comment = xmlDoc.CreateComment("123");
            
            root.AppendChild(_comment); // добавленеие комментария
            root.AppendChild(Options); // добавление Option
            xmlDoc.AppendChild(root); // добавляем в основной xml
            
            xmlDoc.Save("net.xml");


        }
    }
}

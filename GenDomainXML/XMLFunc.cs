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
            // https://metanit.com/sharp/tutorial/16.3.php

            XmlDocument xmlDoc = new XmlDocument();

            XmlElement root = xmlDoc.CreateElement("Alpha.Net.Agent"); // создаем элемент Alpha.Net.Agent
            XmlAttribute _name = xmlDoc.CreateAttribute("name"); // создаем атрибут namr
            XmlText _nameText = xmlDoc.CreateTextNode("local"); // просто создаем значение local
            _name.AppendChild(_nameText); // применяем значение local к атрибуту name
            root.Attributes.Append(_name); // добавляем созданный атрибут в рутовый элемент 
            xmlDoc.AppendChild(root); // добавляем в основной xml
            xmlDoc.Save("net.xml");


        }
    }
}

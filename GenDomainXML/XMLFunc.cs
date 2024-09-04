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

            XmlComment _comment1 = xmlDoc.CreateComment("\t<ChildAgents> - дочерние узлы Net-агента.\r\n\t\tМожет содержать произвольное количество дочерних элементов <ChildAgent>.");
            XmlComment _cooment2 = xmlDoc.CreateComment("\t\t<ChildAgent> - один дочерний узел.\r\n\t\t\tОбязательный атрибут:\r\n\t\t\t\tName - имя дочернего агента (уникальное среди всех ChildAgent'ов; не должно содержать символы: '.' и '\\').\r\n\t\t\tОпциональный атрибут:\r\n\t\t\t\tPort - номер порта дочернего агента.\r\n\t\t\t\tЗначение по умолчанию - \"1010\".\r\n\t\t\tОпциональный атрибут:\r\n\t\t\t\tAddress - IP-адрес дочернего узла. Здесь допустимо задать единственный адрес, без учета резервных каналов связи.\r\n\t\t\t\tНет значения по умолчанию.\r\n\t\t\t\tЕсли не задан атрибут Address, далее должен содержаться один или более дочерних элементов <Address>.\r\n\t\t\t\tЕсли атрибут Address задан, то дочерние элементы <Address> игнорируются.");
            XmlComment _cooment3 = xmlDoc.CreateComment("\t\t\t<Address> - IP-адрес подключения дочернего агента по основному и резервным каналам связи.\r\n\t\t\t\tОбязательный атрибут:\r\n\t\t\t\t\tvalue - значение адреса для подключения.");
            XmlComment _cooment4 = xmlDoc.CreateComment("\tПример элемента <ChildAgents>.");
            XmlComment _cooment5 = xmlDoc.CreateComment("\t<ChildAgents>\r\n\t\t<ChildAgent Name=\"ChildA_1\" Port=\"1020\">\r\n\t\t\t<Address value=\"172.16.13.118\"/>\r\n\t\t\t<Address value=\"172.16.13.75\"/>\t\t\r\n\t\t</ChildAgent>\r\n\t\t<ChildAgent Name=\"ChildA_2\" Port=\"1022\" Address=\"192.22.22.222\"/>\r\n\t</ChildAgents>");
            XmlComment _cooment6 = xmlDoc.CreateComment("\t<Options> - дополнительные настройки Net-агента.\r\n\t\tОпциональный атрибут:\r\n\t\t\tLoggerLevel\t- изменяет количество информации, выводимой в журнал. Допустимые значения: \"0\", \"2\", \"5\".\r\n\t\t\t\t\"0\" - в журнал выводится минимальная информация.\r\n\t\t\t\t\"2\" - выводится информация, оптимально соответствующая регулярной работе агента.\r\n\t\t\t\t\"5\" - журнал выводится максимальная информация по работе агента.\r\n\t\t\t\t\tВнимание! Значение LoggerLevel=\"5\" устанавливать только при поиске/анализе ошибок, отладке и т.д.\r\n\t\t\t\tЗначение по умолчанию - \"2\".");
            XmlComment _comment7 = xmlDoc.CreateComment("<Alpha.Net.Agent> - настройки Net-агента.\r\n\tОбязательный атрибут:\r\n\t\tName - имя агента в сети (не должно содержать символы: '.' и '\\')\r\n\tОпциональный атрибут:\r\n\t\tNetEnterPort - номер порта для предоставления точки доступа в сеть.\r\n\t\tЗначение по умолчанию - \"1010\".\r\n\tОпциональный атрибут:\r\n\t\tParentAgentPort - номер порта для соединения с родительским агентом.\r\n\t\tНет значения по умолчанию.\r\n\tМожет содержать один дочерний элемент <ChildAgents>\r\n\tМожет содержать один дочерний элемент <Options>.");

            root.AppendChild(_comment1); // добавленеие комментария
            root.AppendChild(_cooment2);
            root.AppendChild(_cooment3);
            root.AppendChild(_cooment4);
            root.AppendChild(_cooment5);
            root.AppendChild(_cooment6);

            root.AppendChild(Options); // добавление Option
            xmlDoc.AppendChild(root); // добавляем в основной xml


            xmlDoc.InsertBefore(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null), root);
            xmlDoc.InsertBefore(_comment7, root);


            xmlDoc.Save("net.xml");


        }
    }
}

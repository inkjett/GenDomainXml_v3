using System;
using System.Collections.Generic;
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
    public class NetEnterPortElement
    {
        [XmlAnyAttribute]
        public string Value { get; set; }
    }

    public class SomeModel
    {
        [XmlElement("NetEnterPort")]
        public NetEnterPortElement parametrString { get; set; }    
    }




    internal class XMLFunc
    {
        public static void genLocalNetXML(string _localName) //XmlNode _dataIn
        {
            // https://metanit.com/sharp/tutorial/16.3.php

            XmlDocument xmlDoc = new XmlDocument();

            XmlElement root = xmlDoc.CreateElement("Alpha.Net.Agent"); // создаем элемент Alpha.Net.Agent
            XmlElement Options = xmlDoc.CreateElement("Options");

            XmlAttribute _name = xmlDoc.CreateAttribute("name"); // создаем атрибут name
            XmlAttribute _NetEnterPort = xmlDoc.CreateAttribute("NetEnterPort");
            XmlAttribute _ParentAgentPort = xmlDoc.CreateAttribute("ParentAgentPort");
            XmlAttribute _Options = xmlDoc.CreateAttribute("LoggerLevel");
                        
            XmlText _nameText = xmlDoc.CreateTextNode(_localName); // просто создаем значение local
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

            XmlComment _comment7 = xmlDoc.CreateComment("\n<Alpha.Net.Agent> - настройки Net-агента.\r\n\tОбязательный атрибут:\r\n\t\tName - имя агента в сети (не должно содержать символы: '.' и '\\')\r\n\tОпциональный атрибут:\r\n\t\tNetEnterPort - номер порта для предоставления точки доступа в сеть.\r\n\t\tЗначение по умолчанию - \"1010\".\r\n\tОпциональный атрибут:\r\n\t\tParentAgentPort - номер порта для соединения с родительским агентом.\r\n\t\tНет значения по умолчанию.\r\n\tМожет содержать один дочерний элемент <ChildAgents>\r\n\tМожет содержать один дочерний элемент <Options>.\n");
            XmlComment _comment1 = xmlDoc.CreateComment("\n\t<ChildAgents> - дочерние узлы Net-агента.\r\n\t\tМожет содержать произвольное количество дочерних элементов <ChildAgent>.\n\n");
            XmlComment _cooment2 = xmlDoc.CreateComment("\n\t\t<ChildAgent> - один дочерний узел.\r\n\t\t\tОбязательный атрибут:\r\n\t\t\t\tName - имя дочернего агента (уникальное среди всех ChildAgent'ов; не должно содержать символы: '.' и '\\').\r\n\t\t\tОпциональный атрибут:\r\n\t\t\t\tPort - номер порта дочернего агента.\r\n\t\t\t\tЗначение по умолчанию - \"1010\".\r\n\t\t\tОпциональный атрибут:\r\n\t\t\t\tAddress - IP-адрес дочернего узла. Здесь допустимо задать единственный адрес, без учета резервных каналов связи.\r\n\t\t\t\tНет значения по умолчанию.\r\n\t\t\t\tЕсли не задан атрибут Address, далее должен содержаться один или более дочерних элементов <Address>.\r\n\t\t\t\tЕсли атрибут Address задан, то дочерние элементы <Address> игнорируются.\n");
            XmlComment _cooment3 = xmlDoc.CreateComment("\n\t\t\t<Address> - IP-адрес подключения дочернего агента по основному и резервным каналам связи.\r\n\t\t\t\tОбязательный атрибут:\r\n\t\t\t\t\tvalue - значение адреса для подключения.\n");
            XmlComment _cooment4 = xmlDoc.CreateComment("\n\tПример элемента <ChildAgents>.\n");
            XmlComment _cooment5 = xmlDoc.CreateComment("\n\t<ChildAgents>\r\n\t\t<ChildAgent Name=\"ChildA_1\" Port=\"1020\">\r\n\t\t\t<Address value=\"172.16.13.118\"/>\r\n\t\t\t<Address value=\"172.16.13.75\"/>\t\t\r\n\t\t</ChildAgent>\r\n\t\t<ChildAgent Name=\"ChildA_2\" Port=\"1022\" Address=\"192.22.22.222\"/>\r\n\t</ChildAgents>\n");
            XmlComment _cooment6 = xmlDoc.CreateComment("\n\t<Options> - дополнительные настройки Net-агента.\r\n\t\tОпциональный атрибут:\r\n\t\t\tLoggerLevel\t- изменяет количество информации, выводимой в журнал. Допустимые значения: \"0\", \"2\", \"5\".\r\n\t\t\t\t\"0\" - в журнал выводится минимальная информация.\r\n\t\t\t\t\"2\" - выводится информация, оптимально соответствующая регулярной работе агента.\r\n\t\t\t\t\"5\" - журнал выводится максимальная информация по работе агента.\r\n\t\t\t\t\tВнимание! Значение LoggerLevel=\"5\" устанавливать только при поиске/анализе ошибок, отладке и т.д.\r\n\t\t\t\tЗначение по умолчанию - \"2\".\n");

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

        public static void genDomainXMl()
        {
            XmlDocument xmlDoc = new XmlDocument();
            
            XmlElement root = xmlDoc.CreateElement("Alpha.Domain.Agent"); // создаем элемент Alpha.Domain.Agent
            XmlElement EntryPointNetAgent = xmlDoc.CreateElement("EntryPointNetAgent"); // EntryPointNetAgent

            XmlAttribute _Name_EntryPointNetAgent = xmlDoc.CreateAttribute("Name");
            XmlAttribute _Address_EntryPointNetAgent = xmlDoc.CreateAttribute("Address");
            XmlAttribute _Port_EntryPointNetAgent = xmlDoc.CreateAttribute("Port");

            XmlText _Text_Name_EntryPointNetAgent = xmlDoc.CreateTextNode("local");
            XmlText _Text_Address_EntryPointNetAgent = xmlDoc.CreateTextNode("127.0.0.1");
            XmlText _Text_EntryPointNetAgent = xmlDoc.CreateTextNode("10110");

            _Name_EntryPointNetAgent.AppendChild(_Text_EntryPointNetAgent);
            _Address_EntryPointNetAgent.AppendChild(_Text_Address_EntryPointNetAgent);
            _Port_EntryPointNetAgent.AppendChild(_Text_EntryPointNetAgent);

            EntryPointNetAgent.Attributes.Append(_Name_EntryPointNetAgent);
            EntryPointNetAgent.Attributes.Append(_Address_EntryPointNetAgent);
            EntryPointNetAgent.Attributes.Append(_Port_EntryPointNetAgent);

            root.AppendChild(EntryPointNetAgent);
            xmlDoc.AppendChild(root);

            xmlDoc.Save("domain.xml");
        }

        public static void genLocalNetXML2()
        {
            var model = new SomeModel
            {
                parametrString = new NetEnterPortElement { Value = "local" }
            };
            var serializer = new XmlSerializer(model.GetType());
            serializer.Serialize(Console.Out, model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;


namespace GenDomainXML
{
    public class Options
    {
        [XmlAttribute]
        public string LoggerLevel { get; set; }
    }

    [XmlRoot("Alpha.Net.Agent")]
    public class localNet
    {        
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string NetEnterPort { get; set; }
        [XmlAttribute]
        public string ParentAgentPort {get; set;}

        [XmlAnyElement("Comment1")]
        public XmlComment Comment1 { get { return new XmlDocument().CreateComment("\n<Alpha.Net.Agent> - настройки Net-агента.\r\n\tОбязательный атрибут:\r\n\t\tName - имя агента в сети (не должно содержать символы: '.' и '\\')\r\n\tОпциональный атрибут:\r\n\t\tNetEnterPort - номер порта для предоставления точки доступа в сеть.\r\n\t\tЗначение по умолчанию - \"1010\".\r\n\tОпциональный атрибут:\r\n\t\tParentAgentPort - номер порта для соединения с родительским агентом.\r\n\t\tНет значения по умолчанию.\r\n\tМожет содержать один дочерний элемент <ChildAgents>\r\n\tМожет содержать один дочерний элемент <Options>.\n"); } set { } }

        [XmlAnyElement("Comment2")]
        public XmlComment Comment2 { get { return new XmlDocument().CreateComment("\n\t<ChildAgents> - дочерние узлы Net-агента.\r\n\t\tМожет содержать произвольное количество дочерних элементов <ChildAgent>.\n\n"); } set { } }

        [XmlAnyElement("Comment3")]
        public XmlComment Comment3 { get { return new XmlDocument().CreateComment("\n\t\t<ChildAgent> - один дочерний узел.\r\n\t\t\tОбязательный атрибут:\r\n\t\t\t\tName - имя дочернего агента (уникальное среди всех ChildAgent'ов; не должно содержать символы: '.' и '\\').\r\n\t\t\tОпциональный атрибут:\r\n\t\t\t\tPort - номер порта дочернего агента.\r\n\t\t\t\tЗначение по умолчанию - \"1010\".\r\n\t\t\tОпциональный атрибут:\r\n\t\t\t\tAddress - IP-адрес дочернего узла. Здесь допустимо задать единственный адрес, без учета резервных каналов связи.\r\n\t\t\t\tНет значения по умолчанию.\r\n\t\t\t\tЕсли не задан атрибут Address, далее должен содержаться один или более дочерних элементов <Address>.\r\n\t\t\t\tЕсли атрибут Address задан, то дочерние элементы <Address> игнорируются.\n"); } set { } }

        [XmlAnyElement("Comment4")]
        public XmlComment Comment4 { get { return new XmlDocument().CreateComment("\n\t\t\t<Address> - IP-адрес подключения дочернего агента по основному и резервным каналам связи.\r\n\t\t\t\tОбязательный атрибут:\r\n\t\t\t\t\tvalue - значение адреса для подключения.\n"); } set { } }

        [XmlAnyElement("Comment5")]
        public XmlComment Comment5 { get { return new XmlDocument().CreateComment("\n\tПример элемента <ChildAgents>.\n"); } set { } }

        [XmlAnyElement("Comment6")]
        public XmlComment Comment6 { get { return new XmlDocument().CreateComment("\n\t<ChildAgents>\r\n\t\t<ChildAgent Name=\"ChildA_1\" Port=\"1020\">\r\n\t\t\t<Address value=\"172.16.13.118\"/>\r\n\t\t\t<Address value=\"172.16.13.75\"/>\t\t\r\n\t\t</ChildAgent>\r\n\t\t<ChildAgent Name=\"ChildA_2\" Port=\"1022\" Address=\"192.22.22.222\"/>\r\n\t</ChildAgents>\n"); } set { } }

        [XmlAnyElement("Comment7")]
        public XmlComment Comment7 { get { return new XmlDocument().CreateComment("\n\t<Options> - дополнительные настройки Net-агента.\r\n\t\tОпциональный атрибут:\r\n\t\t\tLoggerLevel\t- изменяет количество информации, выводимой в журнал. Допустимые значения: \"0\", \"2\", \"5\".\r\n\t\t\t\t\"0\" - в журнал выводится минимальная информация.\r\n\t\t\t\t\"2\" - выводится информация, оптимально соответствующая регулярной работе агента.\r\n\t\t\t\t\"5\" - журнал выводится максимальная информация по работе агента.\r\n\t\t\t\t\tВнимание! Значение LoggerLevel=\"5\" устанавливать только при поиске/анализе ошибок, отладке и т.д.\r\n\t\t\t\tЗначение по умолчанию - \"2\".\n"); } set { } }

        [XmlElement("Options")]
        public Options LoggerLevel { get; set; }               
    }

    //domain
    public class EntryPointNetAgent
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Address { get; set; }
        [XmlAttribute]
        public string Port { get; set; }
    }

    public class AlphaServer
    {
        [XmlAnyAttribute]
        public string Name { get; set; }
        [XmlAnyAttribute]
        public string ServiceName { get; set; }
    }

    public class InstalledComponents
    {
        //[XmlElement("Alpha.Server")]
        [XmlAnyAttribute]
        public AlphaServer AlphaServer { get; set; }

    }





    [XmlRoot("Alpha.Domain.Agent")]
    public class localDomain
    {
        [XmlElement("EntryPointNetAgent")]
        public EntryPointNetAgent EntryPointNetAgent { get; set; }
        [XmlElement("InstalledComponents")]
        public InstalledComponents InstalledComponents { get; set; }

    }


}

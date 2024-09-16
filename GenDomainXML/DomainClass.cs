using NetXMLTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DomainXMLTypes
{
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
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string ServiceName { get; set; }
    }

    public class InstalledComponents
    {
        [XmlAnyElement("Comment4")]
        public XmlComment Comment4 { get { return new XmlDocument().CreateComment("<Alpha.Server> - один установленный экземпляр Alpha.Server или Alpha.AccessPoint.\r\n\t\t\tОбязательный атрибут:\r\n\t\t\t\tName - имя экземпляра в рамках данного файла конфигурации.\r\n\t\t\tОбязательный атрибут:\r\n\t\t\t\tServiceName - имя службы экземпляра.\r\n\t\t\tОпциональный атрибут:\r\n\t\t\t\tDefaultActivation - флаг перезапуска экземпляра после развёртывания:\r\n\t\t\t\t\t\"1\" - экземпляр будет запущен независимо от того, был ли он запущен до развёртывания;\r\n\t\t\t\t\t\"0\" - экземпляр будет запущен, только если он был запущен до развёртывания.\r\n\t\t\t\tЗначение по умолчанию - \"1\"."); } set { } }
        [XmlElement("Alpha.Server")]
        public AlphaServer AlphaServer { get; set; }

    }
    public class Component
    {
        [XmlAnyElement("Comment7")]
        public XmlComment Comment7 { get { return new XmlDocument().CreateComment("<Component> - один экземпляр Alpha.Server.\r\n\t\t\t\tОбязательный атрибут:\r\n\t\t\t\t\tInstalledName - имя экземпляра из перечня <InstalledComponents>.\r\n\t\t\t\tОбязательный атрибут:\r\n\t\t\t\t\tName - имя экземпляра в проекте автоматизации.\r\n\t\t\t\tОпциональный атрибут:\r\n\t\t\t\t\tStorageLimitSize - лимит в байтах на общий размер конфигураций. При превышении лимита самые старые конфигурации будут удалены.\r\n\t\t\t\t\tЗначение по умолчанию - \"0\": нет лимита по размеру конфигураций.\r\n\t\t\t\tОпциональный атрибут:\r\n\t\t\t\t\tStorageLimitNum - лимит на количество конфигураций. При превышении лимита самые старые конфигурации будут удалены.\r\n\t\t\t\t\tЗначение по умолчанию - \"0\": нет лимита по количеству конфигураций."); } set { } }
        [XmlAttribute]
        public string InstalledName { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
    }
    public class Components
    {
        [XmlElement("Component")]
        public Component Component { get; set; }
    }
    public class Server
    {
        [XmlAnyElement("Comment6")]
        public XmlComment Comment6 { get { return new XmlDocument().CreateComment("<Components> - экземпляры Alpha.Server, включаемые в роль сервера.\r\n\t\t\tОпциональный атрибут:\r\n\t\t\t\tStoragePath - путь к папке для хранения конфигураций, построенных для локальных экземпляров Alpha.Server.\r\n\t\t\t\tЗначение по умолчанию - \"c:/Domain/Storage/cache/server\".\r\n\t\t\tМожет содержать произвольное количество дочерних элементов <Component>."); } set { } }
        [XmlElement("Components")]
        public Components Components { get; set; }
    }

    [XmlRoot("Alpha.Domain.Agent")]
    public class localDomain
    {

        [XmlAnyElement("Comment1")]
        public XmlComment Comment1{get { return new XmlDocument().CreateComment("<Alpha.Domain.Agent> - настройки Домен-агента.\r\n\tДолжен содержать один дочерний элемент <EntryPointNetAgent>.\r\n\tДолжен содержать один дочерний элемент <InstalledComponents>.\r\n\tДолжен содержать хотя бы один дочерний элемент из <Server>, <Workstation> или <Domain>.\r\n\tМожет содержать один дочерний элемент <Options>."); } set { } }
        [XmlAnyElement("Comment2")]
        public XmlComment Comment2 { get { return new XmlDocument().CreateComment("<EntryPointNetAgent> - атрибуты Net-Агента.\r\n\t\tОбязательный атрибут:\r\n\t\t\tName - имя узла в сети Alpha.Net, указанное в конфигурации Net-агента.\r\n\t\tОпциональный атрибут:\r\n\t\t\tAddress - IP-адрес или имя хоста Net-агента.\r\n\t\t\tЗначение по умолчанию - IP-адрес локального компьютера.\r\n\t\tОпциональный атрибут:\r\n\t\t\tPort - номер порта для доступа в сеть. Должен совпадать со значением атрибута NetEnterPort, указанным в конфигурации Net-агента.\r\n\t\t\tЗначение по умолчанию - \"1010\"."); } set { } }

        [XmlElement("EntryPointNetAgent")]
        public EntryPointNetAgent EntryPointNetAgent { get; set; }
        [XmlAnyElement("Comment3")]
        public XmlComment Comment3 { get { return new XmlDocument().CreateComment("<InstalledComponents> - экземпляры Alpha.Server и Alpha.AccessPoint, установленные на данном компьютере.\r\n\t\tМожет содержать произвольное количество дочерних элементов <Alpha.Server>."); } set { } }
        [XmlElement("InstalledComponents")]
        public InstalledComponents InstalledComponents { get; set; }
        
        [XmlAnyElement("Comment5")]
        public XmlComment Comment5 { get { return new XmlDocument().CreateComment("<Server> - настройки Домен-агента, выполняющего роль сервера.\r\n\t\tДолжен содержать один дочерний элемент <Components>."); } set { } }

        [XmlElement("Server")]
        public Server Server { get; set; }
        [XmlElement("Options")]
        public Options LoggerLevel { get; set; }
    }
}








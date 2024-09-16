using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            [XmlElement("Alpha.Server")]
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








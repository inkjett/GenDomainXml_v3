using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GenDomainXML
{
    public class NetClass
    {
        public class _Name
        {
            [XmlAttribute]
            public string name { get; set; }
            //public string NetEnterPort { get; set; }
            //public string ParentAgentPort { get; set; }
        }

       public class _NetEnterPort
        {
            [XmlAttribute]
            public string NetEnterPort { get; set; }
        }

        public class _ParentAgentPort
        {
            [XmlAttribute]
            public string ParentAgentPort { get; set; }
        }

        public class localNet
        {
            [XmlElement("Alpha.Net.Agent")]
            public _Name name { get; set; }
            //public _Name NetEnterPort { get; set; }
            //public _Name ParentAgentPort { get; set; }
            public _NetEnterPort NetEnterPort { get; set; }
            //public _ParentAgentPort ParentAgentPort { get; set; }
        }


    }
}

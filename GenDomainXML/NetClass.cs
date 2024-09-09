using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GenDomainXML
{
    [XmlRoot("Alpha.Net.Agent")]
    public class localNet
    {
        [XmlAttribute]
        public string name { get; set; }
        public string NetEnterPort { get; set; }
        public string ParentAgentPort {get; set;} 
    }
}

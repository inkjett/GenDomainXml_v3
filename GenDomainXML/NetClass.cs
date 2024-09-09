using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        [XmlElement("Options")]
        public Options LoggerLevel { get; set; }
    }
}

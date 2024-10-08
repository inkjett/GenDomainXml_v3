﻿using DomainXMLTypes;
using NetXMLTypes;
using System;
using System.Collections.Generic;
using System.IO;
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
    internal class XMLFunc
    {
        public static void genLocalDomainXml(string _localName) // генерация Локальной XML для Domain
        {

            var Domain = new localDomain {
                EntryPointNetAgent = new EntryPointNetAgent { 
                    Name = _localName,
                    Address = "127.0.0.1",
                    Port = "1010"
                },
                InstalledComponents = new InstalledComponents {
                   AlphaServer = new AlphaServer {
                        Name = "MainServer",
                        ServiceName = "Alpha.Server"
                   }                
                },
                Server = new Server {
                    Components = new Components {
                        Component = new Component {
                            InstalledName = "MainServer",
                            Name = "Server"
                        }
                    }
                },
                LoggerLevel = new Options { LoggerLevel = "2" }
            };
            
            FileInfo FileDomain = new FileInfo("domain.xml");
            if (FileDomain.Exists)
            {
                FileDomain.Delete(); // удаляем предыдущий файл 
            }
            var serializerDomain = new XmlSerializer(Domain.GetType()); // сериализуем 
            FileStream fsDomain = new FileStream("alpha.domain.agent.xml", FileMode.OpenOrCreate); //определяем файл 
            var nsDomain = new XmlSerializerNamespaces();
            nsDomain.Add(string.Empty, string.Empty); // убираем первую строку с описанием
            serializerDomain.Serialize(fsDomain, Domain, nsDomain);
        }

        public static void genLocalNetXML(string _localName) // генерация Локальной xml для Net
        {
            var Net = new localNet
            {
                name = _localName, 
                NetEnterPort = "1010",
                ParentAgentPort = "1020",
                LoggerLevel = new Options { LoggerLevel = "2"}
            };

            FileInfo FileNet = new FileInfo("alpha.net.agent.xml");
            if (FileNet.Exists)
            {
                FileNet.Delete(); // удаляем предыдущий файл 
            }
            var serializerNet = new XmlSerializer(Net.GetType()); // сериализуем 
            FileStream fsNet = new FileStream("net.xml", FileMode.OpenOrCreate); //определяем файл 
            var nsNet = new XmlSerializerNamespaces();
            nsNet.Add(string.Empty, string.Empty); // убираем первую строку с описанием
            serializerNet.Serialize(fsNet, Net, nsNet);
        }
    }
}

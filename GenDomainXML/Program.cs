using GenDomainXML;
using System.ComponentModel.DataAnnotations;
using System.Xml;

//string _path = "C:\\Users\\admin\\Documents\\GenDomainXml_v3\\ADS";
string _path = "C:\\Users\\AutomiqUsr\\Documents\\GenDomainXml_v3\\ADS";
string _filename = "test.omx";
bool local = true;
int AlphaDomain = 0;

XmlDocument xmlDoc = new XmlDocument();
string tmp = "";
tmp = Path.Combine(_path, _filename);
FileInfo fileInfo = new FileInfo(tmp);
if (!fileInfo.Exists)
{
    return;
}

xmlDoc.Load(tmp);
XmlElement xROOT = xmlDoc.DocumentElement;

Console.WriteLine("1. Для локального применения конфигурации");
Console.WriteLine("2. Для удаленного применения конфигурации");
switch (DataFunc.select_value(2, 2))
{
    case 2:
        local = false;
        break;
    case -1:
        return;
}


if (local)
{
    int firstlevel= DataFunc.SelectElement("Выберите домен Alpha.Domain:", xROOT, "dp:domain");
    int secondlevel = DataFunc.SelectElement("Выберите домен Alpha.Domain.node:", xROOT.ChildNodes[firstlevel], "dp:domain-node");
    //Console.WriteLine(xROOT.ChildNodes[firstlevel].ChildNodes[secondlevel].ChildNodes[1].Attributes.GetNamedItem("name").Value);
    //XMLFunc.genLocalNetXML(xROOT.ChildNodes[firstlevel].ChildNodes[secondlevel].Attributes.GetNamedItem("name").Value); // генерация 
    //XMLFunc.genLocalDomainXml(xROOT.ChildNodes[firstlevel].ChildNodes[secondlevel].Attributes.GetNamedItem("name").Value);
    
    //проба вывести значение черз одну строку
    //Console.WriteLine(xROOT.ChildNodes[firstlevel].ChildNodes[secondlevel].SelectSingleNode("srv:io-server").Attributes.GetNamedItem("name").Value);
        //.Attributes["srv:io-server"].Value );
}
else
{
    Console.WriteLine("Пока тут ничего нет, но надеюсь скоро будет");
}


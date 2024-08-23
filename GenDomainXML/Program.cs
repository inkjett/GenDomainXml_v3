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
    //Console.WriteLine(xROOT.ChildNodes.Count); // получить количество элементов
    //Console.WriteLine(xROOT.GetElementsByTagName("dp:domain").Count); //количество по названию чаелда

    //DataFunc.dataToScrean("Выберите домен Alpha.Domain:", xROOT[DataFunc.dataToScrean("Выберите домен Alpha.Domain:", xROOT, "dp:domain")],""]);
    int firstlevel = DataFunc.SelectElement("Выберите домен Alpha.Domain:", xROOT, "dp:domain");
    int secondlevel = DataFunc.SelectElement("Выберите домен Alpha.Domain.node:", xROOT.ChildNodes[firstlevel], "dp:domain-node");
    //Console.WriteLine("firstlevel="+ firstlevel);



    //foreach (XmlElement xnode in xROOT.ChildNodes[3])
    /*foreach (XmlElement xnode in xROOT.ChildNodes[firstlevel])
    {
        Console.WriteLine(xnode.GetAttribute("name"));
    }*/

} 


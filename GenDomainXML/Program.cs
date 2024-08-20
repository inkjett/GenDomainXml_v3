using System.ComponentModel.DataAnnotations;
using System.Xml;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string _path = "C:\\Users\\AutomiqUsr\\Documents\\GenDomainXml_v3\\ADS";
string _filename = "test.omx";
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
foreach (XmlElement xnode in xROOT)
{ 
    //Console.WriteLine(xnode.Name);
    if (xnode.Name == "dp:domain")
    {
        Console.WriteLine(xnode.GetAttribute("name"));
    }
}
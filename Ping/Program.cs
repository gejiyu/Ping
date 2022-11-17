using System.Xml;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

XmlDocument xml = new XmlDocument();
XmlDeclaration dec = xml.CreateXmlDeclaration("1.0", "UTF-8", "");
xml.AppendChild(dec);

XmlElement yjwow = xml.CreateElement("yjwow");
yjwow.SetAttribute("version", "2.0");
xml.AppendChild(yjwow);

XmlElement channel = xml.CreateElement("channel");

XmlElement data = xml.CreateElement("data"); 
data.InnerText = "2022/11/11 "+ DateTime.Now.ToLongTimeString();
channel.AppendChild(data);

XmlElement type = xml.CreateElement("type");
type.InnerText = "ping";
channel.AppendChild(type);

XmlElement inf = xml.CreateElement("inf");
inf.InnerText = "yes";
channel.AppendChild(inf);

XmlElement errid = xml.CreateElement("errid");
errid.InnerText = "1";
channel.AppendChild(errid);

XmlElement datamd5 = xml.CreateElement("datamd5");
channel.AppendChild(datamd5);

yjwow.AppendChild(channel);

app.MapGet("/ping.aspx", () => xml.InnerXml);

app.Run();


using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Imposto.Core
{
    public static class Utils
    {
        public static string ObjectToXML<T>(T obj)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (StringWriter sw = new StringWriter())
                {
                    serializer.Serialize(sw, obj);
                    return sw.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static bool XmlDownload(string xml, string path, string fileName)
        {
            try
            {
                fileName = fileName + new Random().Next().ToString() + ".xml";

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                XmlWriter writer = XmlWriter.Create(path + @"\" + fileName, settings);

                doc.Save(writer);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
    }
}

using System.Collections.Generic;
using System.IO;
using System.Xml;


namespace XmlReaderFramework
{
    public static class XmlDocumentTest
    {
        public static void Read()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("D:/tmp/bbc_text/bbc-text.xml");

            List<BbcNewsItem> newsItems = new List<BbcNewsItem>();

            using (StreamWriter streamWriter = new StreamWriter("D:/tmp/bbc_text/bbc_text_cshape.csv"))
            {
                streamWriter.Write("category,text\n");
                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    XmlElement e = (XmlElement)node;
                    BbcNewsItem newsItem = new BbcNewsItem();
                    streamWriter.Write(e.GetAttribute("category"));
                    streamWriter.Write(",\"");
                    streamWriter.Write(e.InnerText.Replace("\"", "\"\""));
                    streamWriter.Write("\"\n");
                }
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}

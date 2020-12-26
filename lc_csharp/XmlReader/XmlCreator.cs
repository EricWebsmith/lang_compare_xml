using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace XmlTimer
{
    public class XmlCreator
    {


        public static void Create()
        {
            List<BbcNewsItem> newsItems = new List<BbcNewsItem>();

            using (StreamReader streamReader = new StreamReader("D:/tmp/bbc_text/bbc-text.csv"))
            {
                string line = streamReader.ReadLine();
                line = streamReader.ReadLine();
                while (line != null)
                {

                    int commaAt = line.IndexOf(",");
                    string category = line.Substring(0, commaAt);
                    string text = line.Substring(commaAt + 1);
                    BbcNewsItem item = new BbcNewsItem() { Category = category, Text = text };
                    newsItems.Add(item);
                    line = streamReader.ReadLine();
                }

                streamReader.Close();

            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<bbc></bbc>");

            foreach (BbcNewsItem item in newsItems)
            {
                XmlElement newsElement = xmlDoc.CreateElement("news");
                newsElement.SetAttribute("category", item.Category);
                newsElement.InnerText = item.Text;
                xmlDoc.DocumentElement.AppendChild(newsElement);
            }
            xmlDoc.Save("D:/tmp/bbc_text/bbc-text.xml");

        }

    }
}

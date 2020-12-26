using System.IO;
using System.Xml;


namespace XmlReaderFramework
{
    public static class XmlReaderTest
    {
        public static void Read()
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            XmlReader reader = XmlReader.Create("D:/tmp/bbc_text/bbc-text.xml");
            reader.Read();

            using (StreamWriter streamWriter = new StreamWriter("D:/tmp/bbc_text/bbc_text_cshape.csv"))
            {
                streamWriter.Write("category,text\n");
                while (reader.Read())
                {
                    reader.Read();//read open element
                    if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        break;
                    }
                    streamWriter.Write(reader.GetAttribute("category"));
                    streamWriter.Write(",");
                    reader.Read();                    string content = reader.ReadContentAsString();
                    streamWriter.Write(content.Replace("\"", "\"\""));
                    streamWriter.Write("\n");
                }
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}

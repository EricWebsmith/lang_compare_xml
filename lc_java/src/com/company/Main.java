package com.company;

import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.DocumentBuilder;
import org.w3c.dom.Document;
import org.w3c.dom.NodeList;
import org.w3c.dom.Node;
import org.w3c.dom.Element;
import java.io.File;
import java.io.FileWriter;

public class Main {

    public static void main(String[] args) {
	// write your code here
        System.out.println("Hello World");
        long startTime = System.currentTimeMillis();
        try{
            File fXmlFile = new File("D:\\tmp\\bbc_text\\bbc-text.xml");
            DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(fXmlFile);
            doc.getDocumentElement().normalize();

            Element root = doc.getDocumentElement();

            System.out.println("Root element :" + root.getNodeName());
            NodeList newsItems = doc.getElementsByTagName("news");

            //write to csv
            FileWriter csvWriter = new FileWriter("D:\\tmp\\bbc_text\\bbc_text_java.csv");
            csvWriter.write("category,text\n");

            for(int i=0;i<newsItems.getLength();i++){
                Node newsNode = newsItems.item(i);
                Element newsEletement = (Element) newsNode;
                //System.out.println(newsEletement.getAttribute("category"));
                csvWriter.write(newsEletement.getAttribute("category"));
                csvWriter.write(",\"");
                csvWriter.write(newsEletement.getTextContent().replaceAll("\"","\"\""));
                csvWriter.write("\"\n");
            }
            csvWriter.flush();
            csvWriter.close();
            System.out.println("----------------------------");



        }catch (Exception e) {
            e.printStackTrace();
        }
        long endTime   = System.currentTimeMillis();
        long totalTime = endTime - startTime;
        System.out.println(totalTime);
        System.out.println("Done!");
    }
}

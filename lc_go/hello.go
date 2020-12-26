package main

import (
	"encoding/xml"
	"fmt"
	"io/ioutil"
	"os"
	"strings"
	"time"
)

 	

func check(e error) {
    if e != nil {
        panic(e)
    }
}


type NewsItem struct{
	XMLName xml.Name `xml:"news"`
	Category string `xml:"category,attr"`
	Text string `xml:",innerxml"`
}

type XmlRoot struct{
	XMLName	xml.Name `xml:"bbc"`
	NewsItems	[]NewsItem	`xml:"news"`
}



func main(){


	fmt.Println("Hello World!")

	var startTime = time.Now()

	xmlFile, err := os.Open("D:\\tmp\\bbc_text\\bbc-text.xml")

    if err != nil {
        fmt.Println(err)
	}
	
	fmt.Println("Successfully Opened bbc.xml")

	defer xmlFile.Close()

	byteValue, _ := ioutil.ReadAll(xmlFile)

	var root XmlRoot

	xml.Unmarshal(byteValue, &root)

	f, err := os.Create("/tmp/bbc_text/bbc_text_go.csv")
	check(err)
	defer f.Close()

	f.WriteString("category,text\n")
	for i := 0; i < len(root.NewsItems); i++{
		//fmt.Println("Category: " + root.NewsItems[i].Category)
		f.WriteString(root.NewsItems[i].Category)
		f.WriteString(",")
		f.WriteString(strings.Replace(root.NewsItems[i].Text, "\"", "\"\"", -1))
		f.WriteString("\n")
	}

	//var endTime = time.Now()

	var duration = time.Since(startTime)

	fmt.Println(duration)

	fmt.Println("Done!!!")
}
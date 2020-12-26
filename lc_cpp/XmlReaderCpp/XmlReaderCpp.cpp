// XmlReaderCpp.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <fstream>
#include <chrono>
#include "pugixml.hpp"
#include "BbcNewsItem.h"

using namespace std;

void findAndReplaceAll(std::string& data, std::string toSearch, std::string replaceStr)
{
    // Get the first occurrence
    size_t pos = data.find(toSearch);
    // Repeat till end is reached
    while (pos != std::string::npos)
    {
        // Replace this occurrence of Sub String
        data.replace(pos, toSearch.size(), replaceStr);
        // Get the next occurrence from the current position
        pos = data.find(toSearch, pos + replaceStr.size());
    }
}

int main()
{
    auto start = chrono::system_clock::now();
    std::cout << "Hello World!\n";

    pugi::xml_document doc;
    pugi::xml_parse_result result = doc.load_file("D:/tmp/bbc_text/bbc-text.xml");
    if (!result)
        return -1;

    ofstream csv_file;
    csv_file.open("D:/tmp/bbc_text/bbc_text_cpp.csv");
    csv_file << "category,text" << endl;
    auto children = doc.child("bbc").children();
    for (auto child : children) {
        string category = child.attribute("category").value();
        string text = child.text().as_string();
        findAndReplaceAll(text, "\"", "\"\"");
        text = "\"" + text + "\"";
        csv_file << category << "," << text << endl;
    }

    csv_file.flush();
    csv_file.close();

    auto end = chrono::system_clock::now();
    std::chrono::duration<double> elapsed_seconds = end - start;
    auto millis = std::chrono::duration_cast<std::chrono::milliseconds>(elapsed_seconds).count();
    std::cout << millis << "\n";
    string c;
    std::cin >>c;
}

#pragma once
#include <string>

using namespace std;

class BbcNewsItem
{
private:
	string category;
	string text;
public:
	string getCategory() { return category; }
	void setCategory(string value) { category = value; }

	string getText() { return text; }
	void setText(string value) { text = value; }
};


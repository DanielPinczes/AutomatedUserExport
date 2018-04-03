using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace AutomatedUserExport.PageContents.UsersPage_Operations
{
	class UserChooser
	{
		IWebDriver webDriver;

        public UserChooser(IWebDriver driver) => this.webDriver = driver;

        string GetUserLinkXPath(int rowNum, int colNum)
		{
			string tab1Row = "//html//form[@name='adminForm']/table[1]/tbody[1]/tr";
			string rowNumber = "[" + rowNum.ToString() + "]";
			string tab1Dat = "/td";
			string colNumber = "[" + colNum.ToString() + "]";
			string elemLink = "/a[@href]";

			return tab1Row + rowNumber + tab1Dat + colNumber + elemLink;
		}

		By UserFromTable(int rowNum, int colNum) => By.XPath(GetUserLinkXPath(rowNum, colNum));

		public IWebElement GetChosenUser(int rowNum, int colNum) => webDriver.FindElement(UserFromTable(rowNum, colNum));

	}
}

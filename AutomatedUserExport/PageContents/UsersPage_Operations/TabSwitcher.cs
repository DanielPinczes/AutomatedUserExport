using System.Collections.Generic;
using OpenQA.Selenium;


namespace AutomatedUserExport.PageContents.UsersPage_Operations
{
    class TabSwitcher
    {
        IWebDriver webDriver;

        public TabSwitcher(IWebDriver driver) => this.webDriver = driver;

        public void SwitchTab(int tabNumber)
        {
            IReadOnlyList<string> tabs = new List<string>(webDriver.WindowHandles);
            webDriver.SwitchTo().Window(tabs[tabNumber]);
        }
    }
}

using System.Collections.Generic;
using OpenQA.Selenium;


namespace AutomatedUserExport.PageContents.UserList
{
    class TabSwitcher
    {
        IWebDriver driver;

        public TabSwitcher(IWebDriver driver) => this.driver = driver;

        void SwitchTab(int tabNumber)
        {
            IReadOnlyList<string> tabs = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[tabNumber]);
        }
    }
}

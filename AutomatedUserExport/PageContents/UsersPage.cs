using OpenQA.Selenium;
using System.Collections.Generic;
using AutomatedUserExport.PageContents.UsersPage_Operations;
using AutomatedUserExport.HelperClasses;
using AutomatedUserExport.PageContents.UsersPage_Operations;

namespace AutomatedUserExport.PageContents
{
    class UsersPage
    {
        IWebDriver webDriver;
        SecretDetailsReader secretDetailsOfPage;
    
        By evenUser = By.CssSelector("tr[class = row0]");
        By oddUser = By.CssSelector("tr[class = row1]");

        public UsersPage(IWebDriver driver, SecretDetailsReader secretDetailsOfPage)
        {
            this.webDriver = driver;
            this.secretDetailsOfPage = secretDetailsOfPage;
        }

        IReadOnlyCollection<IWebElement> EvenUsers => webDriver.FindElements(evenUser);

        IReadOnlyCollection<IWebElement> OddUsers => webDriver.FindElements(oddUser);

        public int UserCounter => OddUsers.Count + EvenUsers.Count;
        
        public void GoToURL() => webDriver.Navigate().GoToUrl(secretDetailsOfPage.GetSecretValue("userListURL"));

  
    }
}

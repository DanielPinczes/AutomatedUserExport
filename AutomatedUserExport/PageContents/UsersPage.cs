using OpenQA.Selenium;
using System.Collections.Generic;
using AutomatedUserExport.PageContents.UsersPage_Operations;
using AutomatedUserExport.HelperClasses;
using AutomatedUserExport.PageContents.UserInformation;

namespace AutomatedUserExport.PageContents
{
    class UsersPage
    {
        IWebDriver driver;
        SecretDetailsReader sdr;
    
        By evenUser = By.CssSelector("tr[class = row0]");
        By oddUser = By.CssSelector("tr[class = row1]");

        public UsersPage(IWebDriver driver, SecretDetailsReader sdr)
        {
            this.driver = driver;
            this.sdr = sdr;
        }

        IReadOnlyCollection<IWebElement> EvenUsers => driver.FindElements(evenUser);

        IReadOnlyCollection<IWebElement> OddUsers => driver.FindElements(oddUser);

        public int UserCounter => OddUsers.Count + EvenUsers.Count;
        
        public void GoToURL() => driver.Navigate().GoToUrl(sdr.GetSecretValue("userListURL"));

  
    }
}

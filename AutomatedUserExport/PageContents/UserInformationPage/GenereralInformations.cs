using OpenQA.Selenium;

namespace AutomatedUserExport.PageContents.UserInformationPage
{
    partial class UserInformationPage
    {
        IWebElement element;
        IWebDriver driver;
        public IWebElement Element { set => element = value; }
        public IWebDriver Driver { set => driver = value; }

        By usernameTxbx = By.XPath("//input[@class='inputbox'][@name='username']");
        By emailTxbx = By.XPath("//input[@class='inputbox'][@name='email']");
        By nextPageBtn = By.XPath("//a[text()='Számlázási cím']");

        IWebElement UsernameInput => driver.FindElement(usernameTxbx);
        IWebElement EmailInput => driver.FindElement(emailTxbx);
        IWebElement NextPageButton => driver.FindElement(nextPageBtn);


        public string GetUserName() => UsernameInput.GetAttribute("value");

        public string GetEmailTxbx() => EmailInput.GetAttribute("value");

        public void ScrollPage() => NextPageButton.Click();
    }

}

using OpenQA.Selenium;

namespace AutomatedUserExport.PageContents.UsersPage_Operations
{
    partial class UserInformationPage
    {
        IWebDriver webDriver;

        By usernameTxbx = By.XPath("//input[@class='inputbox'][@name='username']");
        By emailTxbx = By.XPath("//input[@class='inputbox'][@name='email']");
        By nextPageBtn = By.XPath("//a[text()='Számlázási cím']");

        public UserInformationPage(IWebDriver driver) => this.webDriver = driver;


        IWebElement UsernameInput => webDriver.FindElement(usernameTxbx);
        IWebElement EmailInput => webDriver.FindElement(emailTxbx);
        IWebElement NextPageButton => webDriver.FindElement(nextPageBtn);


        public string GetUserName() => UsernameInput.GetAttribute("value");

        public string GetEmailTxbx() => EmailInput.GetAttribute("value");

        public void ScrollPage() => NextPageButton.Click();
    }

}

using OpenQA.Selenium;

namespace AutomatedUserExport.PageContents.UsersPage_Operations
{
    partial class UserInformationPage
    {
        By lastnameTxbx = By.XPath("//input[@name='first_name']");
        By firstnameTxbx = By.XPath("//input[@name = 'last_name']");
        By shopnameTxbx = By.XPath("//input[@name = 'boltneve']");
        By companyTxbx = By.XPath("//input[@name = 'company']");
        By cityTxbx = By.XPath("//input[@name = 'city']");

        IWebElement LastnameInput => webDriver.FindElement(lastnameTxbx);
        IWebElement FirstnameInput => webDriver.FindElement(firstnameTxbx);
        IWebElement ShopnameInput => webDriver.FindElement(shopnameTxbx);
        IWebElement CompanyInput => webDriver.FindElement(companyTxbx);
        IWebElement CityInput => webDriver.FindElement(cityTxbx);


        public string GetLastName() => LastnameInput.GetAttribute("value");

        public string GetFirstName() => FirstnameInput.GetAttribute("value");

        public string GetShopName() => ShopnameInput.GetAttribute("value");

        public string GetCompanyName() => CompanyInput.GetAttribute("value");

        public string GetCity() => CityInput.GetAttribute("value");

    }
}
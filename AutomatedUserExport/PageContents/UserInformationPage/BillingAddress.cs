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

        IWebElement LastnameInput => driver.FindElement(lastnameTxbx);
        IWebElement FirstnameInput => driver.FindElement(firstnameTxbx);
        IWebElement ShopnameInput => driver.FindElement(shopnameTxbx);
        IWebElement CompanyInput => driver.FindElement(companyTxbx);
        IWebElement CityInput => driver.FindElement(cityTxbx);


        public string GetLastName() => LastnameInput.GetAttribute("value");

        public string GetFirstName() => FirstnameInput.GetAttribute("value");

        public string GetShopName() => ShopnameInput.GetAttribute("value");

        public string GetCompanyName() => CompanyInput.GetAttribute("value");

        public string GetCity() => CityInput.GetAttribute("value");

    }
}
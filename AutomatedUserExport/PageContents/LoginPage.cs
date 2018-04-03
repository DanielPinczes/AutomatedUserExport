using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using AutomatedUserExport;
using AutomatedUserExport.HelperClasses;

namespace AutomatedUserExport.PageContents
{
	class LoginPage
	{
		IWebDriver webDriver;
		SecretDetailsReader secretDetailsOfPage;

		By userNameTxbx = By.CssSelector("input[name = usrname]");
		By passwordTxbx = By.CssSelector("input[name = pass]");
		By submitBtn = By.CssSelector("input[name = submit]");

        public LoginPage(IWebDriver driver, SecretDetailsReader sdr)
        {
            this.webDriver = driver;
            this.secretDetailsOfPage = sdr;
        }

        IWebElement UserNameTxbx => webDriver.FindElement(userNameTxbx);

		IWebElement PasswordTxbx => webDriver.FindElement(passwordTxbx);

		IWebElement SubmitBtn => webDriver.FindElement(submitBtn);

		void SetUserName() => UserNameTxbx.SendKeys(secretDetailsOfPage.GetSecretValue("username"));

		void SetPassword() => PasswordTxbx.SendKeys(secretDetailsOfPage.GetSecretValue("password"));

		void ClickSubmit() => SubmitBtn.Click();

		public void Login()
		{
			webDriver.Navigate().GoToUrl(secretDetailsOfPage.GetSecretValue("loginURL"));
			SetUserName();
			SetPassword();
			ClickSubmit();
		}
		
	}
}

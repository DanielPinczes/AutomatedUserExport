using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using AutomatedUserExport;
using AutomatedUserExport.HelperClasses;

namespace AutomatedUserExport.PageContents
{
	class LoginPage
	{
		IWebDriver driver;
		SecretDetailsReader sdr;

		By userNameTxbx = By.CssSelector("input[name = usrname]");
		By passwordTxbx = By.CssSelector("input[name = pass]");
		By submitBtn = By.CssSelector("input[name = submit]");

        public LoginPage(IWebDriver driver, SecretDetailsReader sdr)
        {
            this.driver = driver;
            this.sdr = sdr;
        }

        IWebElement UserNameTxbx => driver.FindElement(userNameTxbx);

		IWebElement PasswordTxbx => driver.FindElement(passwordTxbx);

		IWebElement SubmitBtn => driver.FindElement(submitBtn);

		void SetUserName() => UserNameTxbx.SendKeys(sdr.GetSecretValue("username"));

		void SetPassword() => PasswordTxbx.SendKeys(sdr.GetSecretValue("password"));

		void ClickSubmit() => SubmitBtn.Click();

		public void Login()
		{
			driver.Navigate().GoToUrl(sdr.GetSecretValue("loginURL"));
			SetUserName();
			SetPassword();
			ClickSubmit();
		}
		
	}
}

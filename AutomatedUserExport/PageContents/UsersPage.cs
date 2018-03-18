using OpenQA.Selenium;
using System.Collections.Generic;
using AutomatedUserExport.PageContents.UserList;
using AutomatedUserExport.HelperClasses;

namespace AutomatedUserExport.PageContents
{
	class UsersPage
	{
		IWebDriver driver;
		SecretDetailsReader sdr;
		int counter;

		public IWebDriver Driver { set => driver = value; }
		public SecretDetailsReader Sdr { set => sdr = value; }

		By evenUser = By.CssSelector("tr[class = row0]");
		By oddUser = By.CssSelector("tr[class = row1]");

		IReadOnlyCollection<IWebElement> EvenUsers => driver.FindElements(evenUser);

		IReadOnlyCollection<IWebElement> OddUsers => driver.FindElements(oddUser);

		int UserCounter => OddUsers.Count + EvenUsers.Count;

		

		

		public void SetUsersLimit(int ddlElemNum, int newLimVal)
		{
			UserLimitSetter limSetter = new UserLimitSetter { Driver = driver };
			limSetter.SetNewLimit(ddlElemNum, newLimVal);
		}

		void GoToURL() => driver.Navigate().GoToUrl(sdr.GetSecretValue("userListURL"));
		
		public void IterateUsers()
		{
			UserChooser uc = new UserChooser { Driver = driver };
			for (int i =2; i<UserCounter+2; ++i)
			{
				OpenUserInNewTab(uc, i, 3);
			}
		}
		void OpenUserInNewTab(UserChooser uc, int rowNum, int colNum)
			=> uc.GetChosenUser(rowNum, colNum).SendKeys(Keys.Control + Keys.Return);
		
	}
}

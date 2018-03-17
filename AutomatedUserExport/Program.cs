using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomatedUserExport.HelperClasses;
using AutomatedUserExport.PageContents;

namespace AutomatedUserExport
{
	class Program
	{
		 
		static void Main(string[] args)
		{
			IWebDriver driver = new ChromeDriver();
			SecretDetailsReader sdr = new SecretDetailsReader("PageDetails.csv");

			LoginPage lp = new LoginPage { Driver = driver, Sdr = sdr };
			lp.Login();
			
			driver.Quit();
		}
	}
}

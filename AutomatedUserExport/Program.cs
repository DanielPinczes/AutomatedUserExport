using System;
using System.Collections.Generic;
using System.Linq;
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
            IWebDriver webDriver = new ChromeDriver();
            SecretDetailsReader secretDetailsOfPage = new SecretDetailsReader("PageDetails.csv");

            LoginPage lp = new LoginPage(webDriver, secretDetailsOfPage);
            lp.Login();

            DataExporter exporter = new DataExporter(webDriver, secretDetailsOfPage);
            exporter.StartExport();

            webDriver.Quit();
        }
    }
}

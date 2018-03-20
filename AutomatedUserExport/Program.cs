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
            IWebDriver driver = new ChromeDriver();
            SecretDetailsReader sdr = new SecretDetailsReader("PageDetails.csv");

            LoginPage lp = new LoginPage(driver, sdr);
            lp.Login();

            DataExporter exporter = new DataExporter(driver, sdr);
            exporter.StartExport();

            driver.Quit();
        }
    }
}

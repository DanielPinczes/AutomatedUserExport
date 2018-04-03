using System.Collections.Generic;
using OpenQA.Selenium;
using AutomatedUserExport.HelperClasses;
using AutomatedUserExport.PageContents;
using AutomatedUserExport.PageContents.UsersPage_Operations;

namespace AutomatedUserExport
{
    class DataExporter
    {
        IWebDriver webDriver;
        SecretDetailsReader secretDetailsOfPage;

        public DataExporter(IWebDriver driver, SecretDetailsReader secretDetailsOfPage)
        {
            this.webDriver = driver;
            this.secretDetailsOfPage = secretDetailsOfPage;
        }

        public void StartExport()
        {
            UsersPage up = new UsersPage(webDriver, secretDetailsOfPage);
            up.GoToURL();
            SetUsersLimit(2, 5);
            ExportAllUser(up);
        }
        void ExportAllUser(UsersPage up)
        {
            UserChooser userChooser = new UserChooser(webDriver);
            TabSwitcher tabControl = new TabSwitcher(webDriver);
            ExportFileWriter export = new ExportFileWriter("Export.csv", secretDetailsOfPage);
            UserInformationPage uip = new UserInformationPage(webDriver);

            for (int i = 2; i < up.UserCounter + 2; ++i)
            {
                OpenUserInNewTab(userChooser, i, 3);
                tabControl.SwitchTab(1);
                export.AddNewRecord(GetRecord(uip));
                webDriver.Close();
                tabControl.SwitchTab(0);
            }
        }
        string GetRecord(UserInformationPage uip)
        {
             string sep = ",", emptyValue = "";

            string recordPage1 = uip.GetEmailTxbx() + sep +
                                 uip.GetUserName() + sep;

            uip.ScrollPage();

            string recordPage2 = uip.GetLastName() + sep +
                                 uip.GetFirstName() + sep +
                                 uip.GetShopName() + sep +
                                 uip.GetCompanyName() + sep +
                                 uip.GetCity() + sep +
                                 "regisztraltak";

            return recordPage1 + recordPage2;
        }

        void OpenUserInNewTab(UserChooser uc, int rowNum, int colNum)
            => uc.GetChosenUser(rowNum, colNum).SendKeys(Keys.Control + Keys.Return);

        void SetUsersLimit(int ddlElemNum, int newLimVal)
        {
            UserLimitSetter limSetter = new UserLimitSetter(webDriver);
            limSetter.SetNewLimit(ddlElemNum, newLimVal);
        }

    }
}

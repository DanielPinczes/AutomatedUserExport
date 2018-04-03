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
            ExportFileWriter export = new ExportFileWriter("Export.csv");
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

            string[] field = new string[9];

            field[0] = uip.GetEmailTxbx();
            field[3] = uip.GetUserName();

            uip.ScrollPage();

            field[1] = uip.GetLastName();
            field[2] = uip.GetFirstName();
            field[5] = uip.GetShopName();
            field[4] = uip.GetCompanyName();
            field[6] = uip.GetCity();
            field[7] = emptyValue;
            field[8] = "regisztraltak";

            return string.Join(sep, field);
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

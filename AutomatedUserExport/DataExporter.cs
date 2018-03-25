using OpenQA.Selenium;
using AutomatedUserExport.HelperClasses;
using AutomatedUserExport.PageContents;
using AutomatedUserExport.PageContents.UsersPage_Operations;

namespace AutomatedUserExport
{
    class DataExporter
    {
        IWebDriver driver;
        SecretDetailsReader sdr;

        public DataExporter(IWebDriver driver, SecretDetailsReader sdr)
        {
            this.driver = driver;
            this.sdr = sdr;
        }

        public void StartExport()
        {
            UsersPage up = new UsersPage(driver, sdr);
            up.GoToURL();
            SetUsersLimit(2, 5);
            ExportAllUser(up);
        }
        void ExportAllUser(UsersPage up)
        {
            UserChooser uc = new UserChooser(driver);
            TabSwitcher tabControl = new TabSwitcher(driver);
            ExportFileWriter export = new ExportFileWriter("Export.csv", sdr);
            UserInformationPage uip = new UserInformationPage(driver);

            for (int i = 2; i < up.UserCounter + 2; ++i)
            {
                OpenUserInNewTab(uc, i, 3);
                tabControl.SwitchTab(1);
                export.AddNewRecord(GetRecord(uip));
                driver.Close();
                tabControl.SwitchTab(0);
            }
        }
        string GetRecord(UserInformationPage uip)
        {

            string sep = ",";

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
            UserLimitSetter limSetter = new UserLimitSetter(driver);
            limSetter.SetNewLimit(ddlElemNum, newLimVal);
        }

    }
}

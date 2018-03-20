using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomatedUserExport.PageContents.HelpersOfUsersPage
{
    class UserLimitSetter
    {

        IWebDriver driver;

        public UserLimitSetter(IWebDriver driver) => this.driver = driver;

        string GetXPathDdlElem(int elemIndex)
        {
            string xPathName = ".//*[@name='limit']";
            string xPathDdlElem = "/option[" + elemIndex.ToString() + "]";

            return xPathName + xPathDdlElem;
        }

        By GetLimElemByXpath(int elemIndex) => By.XPath(GetXPathDdlElem(elemIndex));

        IWebElement GetLimElem(int elemIndex) => driver.FindElement(GetLimElemByXpath(elemIndex));

        string GenNewLimJS(int newLimit)
        {
            string arguments = "arguments[0].";
            string value = "value='" + newLimit.ToString() + "';";

            return arguments + value;
        }

        void ModLimElem(int DdlElemNum, int newLimVal)
        {
            IJavaScriptExecutor jsExecutor = driver as IJavaScriptExecutor;

            jsExecutor.ExecuteScript(GenNewLimJS(newLimVal), GetLimElem(DdlElemNum));
        }

        public void SetNewLimit(int DdlElemNum, int newLimVal)
        {
            ModLimElem(DdlElemNum, newLimVal);

            GetLimElem(DdlElemNum).Click();
        }
    }
}

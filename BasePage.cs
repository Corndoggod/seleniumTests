using System;
using OpenQA.Selenium;

namespace UnitTestProject1
{
    class BasePage
    {
        private IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetTitle()
        {
            return driver.Title;
        }
        public Boolean IsElemExist(By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException) { return false; }
        }

        public void FillField(By locator, String value, Boolean sendByFill)
        {
            IWebElement elem = driver.FindElement(locator);
            elem.Clear();
            if (sendByFill)
                elem.SendKeys(value + Keys.Enter);
            else
                elem.SendKeys(value);
        }
    }
}

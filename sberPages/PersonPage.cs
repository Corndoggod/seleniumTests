using System;
using OpenQA.Selenium;
using NLog;

namespace UnitTestProject1.sberPages
{
    class PersonPage : BasePage
    {
        private IWebDriver driver;
        private Logger logger = LogManager.GetCurrentClassLogger();
        By menuLocator = By.XPath(".//div[contains(@class,'lg-menu')]");

        public PersonPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            logger.Info(" ");
            logger.Info("Открытие стартовой страницы");
        }

        public void SelectMenuItem(String item)
        {
            logger.Info("Выбор пункта меню: " + item);
            try
            {
                driver.FindElement(menuLocator);
                driver.FindElement(By.XPath("//li//span[contains(text(),'" + item + "')]/../..")).Click();
            }
            catch (Exception e)
            {
                logger.Info("Ошибка: " + e);
            }
        }

        public void SelectSubMenuItem(String subitem)
        {
            logger.Info("Выбор подпункта меню: " + subitem);
            try
            {
                driver.FindElement(By.XPath("//a[contains(text(),'" + subitem + "')]")).Click();
            }
            catch (Exception e)
            {
                logger.Info("Ошибка: " + e);
            }
        }
    }
}

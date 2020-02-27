using System;
using OpenQA.Selenium;
using NLog;

namespace UnitTestProject1.yaPages
{
    class MarketPage : BasePage
    {
        private IWebDriver driver;
        private By menuLocator = By.XPath("//div[@role='tablist']");
        private Logger logger = LogManager.GetCurrentClassLogger();

        public MarketPage(IWebDriver driver) : base(driver)
        {
            logger.Info("Открытие страницы маркета");
            try
            {
                this.driver = driver;
            }
            catch (Exception e)
            {
                logger.Error("Ошибка: " + e);
            }
        }

        public void SelectMenuItem(String item)
        {
            logger.Info("Выбор раздела: " + item);
            try
            {
                driver.FindElement(menuLocator);
                driver.FindElement(By.XPath("//span[contains(text(),'" + item + "')]")).Click();
            }
            catch (Exception e)
            {
                logger.Error("Ошибка: " + e);
            }
        }
    }
}

using System;
using OpenQA.Selenium;
using NLog;

namespace UnitTestProject1.yaPages
{
    class MainPage : BasePage
    {
        private IWebDriver driver;
        private By menuLocator = By.XPath("//div[@class='home-arrow__tabs ']");
        private Logger logger = LogManager.GetCurrentClassLogger();

        public MainPage(IWebDriver driver) : base(driver)
        {
            logger.Info(" ");
            logger.Info("Открытие главной страницы");
            try
            {
                this.driver = driver;
            }
            catch(Exception e)
            {
                logger.Error("Ошибка: " + e);
            }
            
        }

        public void SelectMenuItem(String item)
        {
            logger.Info("Выбор пункта меню: " + item);
            try
            {
                driver.FindElement(menuLocator);
                driver.FindElement(By.XPath("//a[contains(text(),'" + item + "')]")).Click();
            }
            catch(Exception e)
            {
                logger.Error("Ошибка: " + e);
            }
        }
    }
}

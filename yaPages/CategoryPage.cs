using System;
using OpenQA.Selenium;
using NLog;

namespace UnitTestProject1.yaPages
{
    class CategoryPage : BasePage
    {
        private IWebDriver driver;
        private By menuLocator = By.XPath("//div[@class='section N9o4gAuSnb QGJ9xgri-V qUW8qep9Rv _2n8U4OismH']");
        private Logger logger = LogManager.GetCurrentClassLogger();

        public CategoryPage(IWebDriver driver) : base(driver)
        {
            logger.Info("Открытие раздела");
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
            logger.Info("Выбор подраздела " + item);
            try
            {
                driver.FindElement(menuLocator);
                driver.FindElement(By.XPath("//a[contains(text(),'" + item + "')]")).Click();
            }
            catch (Exception e)
            {
                logger.Error("Ошибка: " + e);
            }
        }
    }
}

using System;
using OpenQA.Selenium;
using NLog;

namespace UnitTestProject1.yaPages
{
    class FilterPage : BasePage
    {
        public enum Sides { LEFT, RIGHT };
        private IWebDriver driver;
        private Logger logger = LogManager.GetCurrentClassLogger();

        private By leftPriceBound = By.XPath("//span[contains(@class,'input_price_from')]//input");
        private By rightPriceBound = By.XPath("//span[contains(@class,'input_price_to')]//input");
        private By optionsLocator = By.XPath("//div[contains(@class,'n-filter-panel-extend i-bem')]");

        public FilterPage(IWebDriver driver) : base(driver)
        {
            logger.Info("Открытие расширенного фильтра");
            try
            {
                this.driver = driver;
            }
            catch (Exception e)
            {
                logger.Error("Ошибка: " + e);
            }
        }

        public void FilterByProducer(String producer)
        {
            logger.Info("Выбор производителя: " + producer);
            try
            {
                driver.FindElement(optionsLocator);
                driver.FindElement(By.XPath("//span[contains(text(),'Производитель')]/../../..//label[@class='checkbox__label'][contains(text(),'" + producer + "')]")).Click();
            }
            catch (Exception e)
            {
                logger.Error("Ошибка: " + e);
            }
        }

        public void FillPriceBound(Sides side, string value)
        {
            try
            {
                switch (side)
                {
                    case Sides.LEFT:
                        {
                            logger.Info("Оганичение цены от " + value);
                            FillField(leftPriceBound, value, false);
                            break;
                        }
                    case Sides.RIGHT:
                        {
                            logger.Info("Оганичение цены до " + value);
                            FillField(rightPriceBound, value, false);
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                logger.Error("Ошибка: " + e);
            }
        }

        public void Apply()
        {
            logger.Info("Применение фильтра");
            try
            {
                driver.FindElement(optionsLocator);
                driver.FindElement(By.XPath("//a[contains(@role,'button')]//span[contains(text(),'Показать подходящие')]/..")).Click();
            }
            catch (Exception e)
            {
                logger.Error("Ошибка: " + e);
            }
        }
    }
}

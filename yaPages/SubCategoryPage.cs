using System;
using OpenQA.Selenium;
using NLog;
using System.Linq;

namespace UnitTestProject1.yaPages
{
    class SubCategoryPage : BasePage
    {
        private IWebDriver driver;
        private Logger logger = LogManager.GetCurrentClassLogger();
        private By searchLocator = By.XPath("//input[@id='header-search']");
        private By advancedFilterLocator = By.XPath("//div[@class='search-layout']//span[contains(text(),'Все фильтры')]");
        private By visibleAmountLocator = By.XPath(".//span[contains(text(),'Показывать по')]/..");
        private By snippetCardLocator = By.XPath("//div[contains(@class,'n-snippet-card2 i-bem')]//h3/a");

        public SubCategoryPage(IWebDriver driver) : base(driver)
        {
            logger.Info("Открытие подраздела");
            try
            {
                this.driver = driver;
            }
            catch (Exception e)
            {
                logger.Error("Ошибка: " + e);
            }
        }

        public void ToAdvancedFilter()
        {
            logger.Info("Переход к расширенному фильтру");
            try
            {
                driver.FindElement(advancedFilterLocator).Click();
            }
            catch (Exception e)
            {
                logger.Error("Ошибка: " + e);
            }
        }

        public int CountItems()
        {
            logger.Info("Подсчёт элементов на странице");
            try
            {
                return driver.FindElements(snippetCardLocator).Count;
            }
            catch (Exception e)
            {
                logger.Error("Ошибка: " + e);
                return 0;
            }
        }

        public IWebElement GetFirstElement()
        {
            logger.Info("Запись первого элемента");
            try
            {
                return driver.FindElements(snippetCardLocator).First();
            }
            catch (Exception e)
            {
                logger.Error("Ошибка: " + e);
                return null;
            }
        }

        public void SearchProduct(String product)
        {
            logger.Info("Поиск записанного значения: " + product);
            try
            {
                FillField(searchLocator, product, true);
            }
            catch (Exception e)
            {
                logger.Error("Ошибка: " + e);
            }
        }

        public void ChangeVisibleAmount()
        {
            if (IsElemExist(By.XPath(".//button//span[contains(text(),'Показывать по')]/../..")))
            {
                logger.Info("Смена количества показываемых элементов");
                driver.FindElement(visibleAmountLocator).Click();
                driver.FindElement(By.XPath(".//div[contains(@class,'select__item')]//span[contains(text(),'12')]")).Click();
            }
            else
                Console.WriteLine("Переключение невозможно");
        }
    }
}

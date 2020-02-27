using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NLog;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1.sberPages
{
    class DrawUpPage : BasePage
    {
        private IWebDriver driver;
        private IWait<IWebDriver> wait;
        private Logger logger = LogManager.GetCurrentClassLogger();

        private By insuranceLvlLocator = By.XPath(".//legend[contains(text(),'Выберите сумму страховой')]/..");
        private By drawUpButtonLocator = By.XPath(".//button[contains(text(),'Оформить')]/..");

        private By insuredLocator = By.XPath(".//div//fieldset//legend[contains(text(),'Застрахованные')]/..//input");
        private By insuredSurname = By.XPath(".//input[contains(@id,'surname')]");
        private By insuredName = By.XPath(".//input[starts-with(@id,'name')]");
        private By insuredBirth = By.XPath(".//input[starts-with(@id,'birthDate')]");

        private By insurantLocator = By.XPath(".//div//fieldset//legend[contains(text(),'Страхователь')]/..//input[not(contains(@name,'Empty'))]");
        private By insurantSurname = By.XPath(".//input[starts-with(@id,'person_lastName')]");
        private By insurantName = By.XPath(".//input[starts-with(@id,'person_firstName')]");
        private By insurantMiddleName = By.XPath(".//input[starts-with(@id,'person_middleName')]");
        private By insurantBirth = By.XPath(".//input[starts-with(@id,'person_birthDate')]");

        private By passLocator = By.XPath(".//div//fieldset//legend[contains(text(),'Паспортные')]/..//input");
        private By passSeries = By.XPath(".//input[contains(@id,'passportSeries')]");
        private By passNum = By.XPath(".//input[contains(@id,'passportNumber')]");
        private By passIssueDate = By.XPath(".//input[contains(@id,'documentDate')]");
        private By passIssuer = By.XPath(".//input[contains(@id,'documentIssue')]");

        private By submitButton = By.XPath(".//button[contains(text(),'Продолжить')]");

        public DrawUpPage(IWebDriver driver) : base(driver)
        {
            logger.Info("Открытие страницы оформления страховки");
            try
            {
                this.driver = driver;
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            }
            catch (Exception e)
            {
                logger.Info("Ошибка: " + e);
            }
        }

        public void SelectLvl(String lvl)
        {
            logger.Info("Выбран вид страховки: " + lvl);
            try
            {
                driver.FindElement(insuranceLvlLocator);
                driver.FindElement(By.XPath("//h3[contains(text(),'" + lvl + "')]")).Click();
            }
            catch (Exception e)
            {
                logger.Info("Ошибка: " + e);
            }
        }

        public void DrawUp()
        {
            logger.Info("Нажата кнопка \"Оформить\"");
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(drawUpButtonLocator));
                driver.FindElement(drawUpButtonLocator).Click();
            }
            catch (Exception e)
            {
                logger.Info("Ошибка: " + e);
            }
        }

        public void FillInsuredData(String surname, String name, String birthday)
        {
            logger.Info("Заполнение данных застрахованных");
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(insuredLocator));
                driver.FindElement(insuredSurname).SendKeys(surname);
                driver.FindElement(insuredName).SendKeys(name);
                driver.FindElement(insuredBirth).SendKeys(birthday);
                driver.FindElement(insuredLocator).Click();
            }
            catch(Exception e)
            {
                logger.Info("Ошибка: " + e);
            }
        }

        public void FillInsurantData(String surname, String name, String middlename, String birthday, String gender)
        {
            logger.Info("Заполнение данных страхователя");
            try
            {
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(insurantLocator));
                driver.FindElement(insurantSurname).SendKeys(surname);
                driver.FindElement(insurantName).SendKeys(name);
                driver.FindElement(insurantMiddleName).SendKeys(middlename);
                driver.FindElement(insurantBirth).SendKeys(birthday);
                driver.FindElement(insurantLocator).Click();
                driver.FindElement(By.XPath(".//span[contains(text(),' Пол')]/..//label[contains(text(),'" + gender + "')]")).Click();
            }
            catch (Exception e)
            {
                logger.Error("Ошибка: " + e);
            }
        }

        public void FillPassData(String series, String number, String date, String issuer)
        {
            logger.Info("Заполнение паспортных данных");
            try
            {
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(passLocator));
                FillField(passSeries, series, false);
                FillField(passNum, number, false);
                FillField(passIssueDate, date, false);
                driver.FindElement(passLocator).Click();
                FillField(passIssuer, issuer, false);
            }
            catch(Exception e)
            {
                logger.Error("Ошибка: " + e);
            }
        }

        public void Submit()
        {
            logger.Info("Нажата кнопка \"Продолжить\"");
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(submitButton));
                driver.FindElement(submitButton).Click();
            }
            catch (Exception e)
            {
                logger.Error("Ошибка: " + e);
            }
            Assert.IsTrue(this.IsElemExist(By.XPath(".//span[contains(@class,'invalid-validate')]")));
        }
    }
}

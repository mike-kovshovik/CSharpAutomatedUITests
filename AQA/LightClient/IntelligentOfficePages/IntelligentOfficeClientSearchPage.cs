using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AQA.LightClient.IntelligentOfficePages
{
    internal class IntelligentOfficeClientSearchPage
    {

        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private readonly By emailAddressInput = By.XPath("//input[@id='id_email']");
        private readonly By searchButton = By.XPath("//a[starts-with(text(), 'Search')]");
        private readonly By searchResultsGridPrototype = By.XPath("//a[@class='sortAvailable sort' and contains(text(), 'Email')]");
        private readonly By emailAddressSearchResultPrototype = By.XPath("//tr[starts-with(@id, 'ClientSearchNameGrid')]/td[11]/span");


        public IntelligentOfficeClientSearchPage(IWebDriver driver, WebDriverWait wait)
        {
            this._driver = driver;
            this._wait = wait;
        }


        public IntelligentOfficeClientSearchPage isLightClientRegisteredIniO(string email)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(emailAddressInput)).SendKeys(email);
            _driver.FindElement(searchButton).Click();
            _wait.Until(ExpectedConditions.ElementIsVisible(searchResultsGridPrototype));
            Assert.IsTrue(_driver.FindElement(emailAddressSearchResultPrototype).Text.Length > 0);
            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages
{
    class IntelligentOfficeLogInPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public IntelligentOfficeLogInPage(IWebDriver driver, WebDriverWait wait)
        {
            this._driver = driver;
            this._wait = wait;
        }


        private readonly By loginButtonOnLandingPage = By.XPath("//span[contains(text(), 'Login')]");
        private readonly By loginButtonOnIdentityPage = By.XPath("//button[contains(text(), 'Login')]");
        private readonly By usernameInput = By.XPath("//input[@id='username']");
        private readonly By passwordInput = By.XPath("//input[@id='password']");


        public IntelligentOfficeLogInPage LogInToIntelligentOffice(string url, string login, string password)
        {
            _driver.Navigate().GoToUrl(url);
            _wait.Until(ExpectedConditions.ElementToBeClickable(loginButtonOnLandingPage)).Click();
            _wait.Until(ExpectedConditions.ElementIsVisible(usernameInput)).SendKeys(login);
            _driver.FindElement(passwordInput).SendKeys(password);
            _driver.FindElement(loginButtonOnIdentityPage).Submit();
            return this;
        }

    }
}

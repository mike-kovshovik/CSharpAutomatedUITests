using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages
{
    class YourInvestmentChoicesPage
    {
        IWebDriver _driver;
        WebDriverWait _wait;

        private By yourInvestmentChoicesHeaderPrototype = By.XPath("//b[contains(text(), 'Your investment Choices')]");
        private By nextButton = By.XPath("//a[@title='Next']");


        public YourInvestmentChoicesPage(IWebDriver driver, WebDriverWait wait)
        {
            this._driver = driver;
            this._wait = wait;
        }

        public void PressNextButton()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(yourInvestmentChoicesHeaderPrototype));
            _driver.FindElement(nextButton).Submit();
        }


    }
}

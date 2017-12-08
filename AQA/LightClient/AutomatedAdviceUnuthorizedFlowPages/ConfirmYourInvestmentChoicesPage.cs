using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages
{
    class ConfirmYourInvestmentChoicesPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private By confirmYourInvestmentChoicesHeaderPrototype = By.XPath("//b[contains(text(), 'Please confirm your investment choices')]");
        private By nextButton = By.XPath("//a[@title='Next']");


        public ConfirmYourInvestmentChoicesPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void PressNextButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(confirmYourInvestmentChoicesHeaderPrototype));
            driver.FindElement(nextButton).Submit();
        }
    }
}

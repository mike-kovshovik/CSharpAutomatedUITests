using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages
{
    class AboutYourRiskCapacityPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private By yourInvestmentProjectionHeaderPrototype = By.XPath("//b[contains(text(), 'About your risk capacity')]");
        private By nextButton = By.XPath("//a[@title='Next']");


        public AboutYourRiskCapacityPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void PressNextButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(yourInvestmentProjectionHeaderPrototype));
            driver.FindElement(nextButton).Submit();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages
{
    class AttitudeToRiskPage
    {
        IWebDriver driver;
        WebDriverWait wait;

        private By AttitudeToInvestmentRiskHeaderPrototype = By.XPath("//b[contains(text(), 'About your attitude to investment risk')]");
        private By nextButton = By.XPath("//a[@title='Next']");


        public AttitudeToRiskPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void PressNextButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(AttitudeToInvestmentRiskHeaderPrototype));
            driver.FindElement(nextButton).Submit();
        }

    }
}

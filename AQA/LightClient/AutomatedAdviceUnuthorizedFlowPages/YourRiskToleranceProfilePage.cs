using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages
{
    class YourRiskToleranceProfilePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private By riskToleranceProfileHeaderPrototype = By.XPath("//b[contains(text(), 'Your risk tolerance profile')]");
        private By nextButton = By.XPath("//a[@title='Next']");


        public YourRiskToleranceProfilePage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void PressNextButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(riskToleranceProfileHeaderPrototype));
            driver.FindElement(nextButton).Submit();
        }
    }
}

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
        IWebDriver driver;
        WebDriverWait wait;

        private By yourInvestmentChoicesHeaderPrototype = By.XPath("//b[contains(text(), 'Your investment Choices')]");
        private By nextButton = By.XPath("//a[@title='Next']");


        public YourInvestmentChoicesPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void PressNextButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(yourInvestmentChoicesHeaderPrototype));
            driver.FindElement(nextButton).Submit();
        }


    }
}

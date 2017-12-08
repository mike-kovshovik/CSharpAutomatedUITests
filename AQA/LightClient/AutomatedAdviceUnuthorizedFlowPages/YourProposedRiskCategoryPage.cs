using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages
{
    class YourProposedRiskCategoryPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private By yourProposedRiskCategoryHeaderPrototype = By.XPath("//b[contains(text(), 'Your proposed risk category')]");
        private By nextButton = By.XPath("//a[@title='Next']");


        public YourProposedRiskCategoryPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void PressNextButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(yourProposedRiskCategoryHeaderPrototype));
            driver.FindElement(nextButton).Submit();
        }
    }
}

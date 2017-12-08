using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AQA.LightClient.Helpers;

namespace AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages
{
    class HowServiceWorksPage
    {
        IWebDriver driver;
        WebDriverWait wait;

        private By howServiceWorksHeaderPrototype = By.XPath("//b[contains(text(), 'How the service works')]");
        private By nextButton = By.XPath("//a[@title='Next']");


        public HowServiceWorksPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void PressNextButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(howServiceWorksHeaderPrototype));
            driver.FindElement(nextButton).Submit();
        }
        
    }
}

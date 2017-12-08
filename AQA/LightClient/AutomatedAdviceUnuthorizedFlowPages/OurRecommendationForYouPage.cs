using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages
{
    class OurRecommendationForYouPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private By ourRecommendationForYouHeaderPrototype = By.XPath("//b[contains(text(), 'Our recommendation for you')]");
        private By continueNowButton = By.XPath("//a[@title='Continue now']");


        public OurRecommendationForYouPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }


        public void PressContinueNowButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(ourRecommendationForYouHeaderPrototype));
            driver.FindElement(continueNowButton).Submit();
        }
    }
}

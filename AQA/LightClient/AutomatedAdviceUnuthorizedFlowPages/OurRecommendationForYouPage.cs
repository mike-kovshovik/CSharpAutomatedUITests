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
        private IWebDriver _driver;
        private WebDriverWait _wait;

        private By ourRecommendationForYouHeaderPrototype = By.XPath("//b[contains(text(), 'Our recommendation for you')]");
        private By continueNowButton = By.XPath("//a[@title='Continue now']");


        public OurRecommendationForYouPage(IWebDriver driver, WebDriverWait wait)
        {
            this._driver = driver;
            this._wait = wait;
        }


        public void PressContinueNowButton()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(ourRecommendationForYouHeaderPrototype));
            _driver.FindElement(continueNowButton).Submit();
        }
    }
}

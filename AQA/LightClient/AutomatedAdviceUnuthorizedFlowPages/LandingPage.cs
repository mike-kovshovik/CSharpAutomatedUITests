using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages
{
    class LandingPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        private readonly By updateProfileButton = By.XPath("//a[@title='Update Profile']");

        public LandingPage(IWebDriver driver, WebDriverWait wait)
        {
            this._driver = driver;
            this._wait = wait;
        }

        public void GoToProfile()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(updateProfileButton)).Click();
        }

    }
}

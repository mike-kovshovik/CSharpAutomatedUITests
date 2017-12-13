using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages
{
    class DeclarationPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        private By pfpLogoPrototype = By.XPath("//img[@alt='Personal Finance Portal']");
        private By PageHeaderPrototype = By.XPath("//h3[@class='p-y-15']");

        public DeclarationPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }


        public void VerifyPageHeaderIsDeclaration(string pageHeader)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(pfpLogoPrototype));
            Assert.AreEqual(driver.FindElement(PageHeaderPrototype).Text, pageHeader);
        }


        public void GoToPfpHomePage()
        {
            driver.FindElement(pfpLogoPrototype).Click();
        }

    }
}

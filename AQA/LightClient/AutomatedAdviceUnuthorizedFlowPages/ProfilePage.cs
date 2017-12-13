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
    class ProfilePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        private By emailPrototype = By.XPath("//*[@id='personal-details']/div[2]/div/section[1]/div/div[2]/div[2]/div");
        private By contactDetailsSection = By.XPath("//div[@id='personal-details']/div[2]/div/section[1]/div");
        private By logoutButton = By.XPath("//div[@class='d-flex']/a[@title='Logout']");


        public ProfilePage(IWebDriver driver, WebDriverWait wait)
        {
            this._driver = driver;
            this._wait = wait;
        }

        public ProfilePage IsClientEmailIsPresentInContactDetails(string emailAddress)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(contactDetailsSection));
            Assert.AreEqual(_driver.FindElement(emailPrototype).Text, emailAddress);
            return this;
        }

        public void LogoutFromPfp()
        {
            _driver.FindElement(logoutButton).Click();
        }


    }
}

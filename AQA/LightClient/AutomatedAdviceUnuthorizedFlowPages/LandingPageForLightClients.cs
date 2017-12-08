using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages
{
    class LandingPageForLightClients
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        private By pageHeaderPrototype = By.XPath("//b[contains(text(), 'Looking for a quick, simple investment? Start here')]");
        private By startPlanningButton = By.XPath("//button[@id='btnStartPlanning']");
        public By heavingReadTermsConditionsCheckbox = By.XPath("//span[contains(text(), 'Having read')]");
        public By noDebtsCheckbox = By.XPath("//span[contains(text(), 'I confirm I do not')]");
        private By signUpWithFacebookButton = By.XPath("//a[@title='Sign up with Facebook']");
        private By faceBookLoginPagePrototype = By.XPath("//div[@id='header_block']");
        private By emailInput = By.XPath("//input[@id='email']");
        private By passwordInput = By.XPath("//input[@id='pass']");
        private By loginButton = By.XPath("//button[@id='loginbutton']");


        // created constructor passing driver and wait in parameters
        public LandingPageForLightClients(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public LandingPageForLightClients tickCheckbox(By checkboxLocator)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(pageHeaderPrototype));
            Actions clicker = new Actions(driver);
            clicker.MoveToElement(driver.FindElement(checkboxLocator), 0, 0).Click().Perform();
            return this;
        }


        public void pressStartPlanning()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(startPlanningButton))).Click();
        }

        public void signUpWithFacebook(String login, String password)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(signUpWithFacebookButton)).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(faceBookLoginPagePrototype)); // wait for the login page to load
            driver.FindElement(emailInput).SendKeys(login);
            driver.FindElement(passwordInput).SendKeys(password);
            driver.FindElement(loginButton).Click();
        }

        


    }
}

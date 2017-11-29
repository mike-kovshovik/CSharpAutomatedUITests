using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AQA.LightClient.Helpers
{
    public class LoginHelper
    {
        public void LinkedInLogin(IWebDriver driver, WebDriverWait wait, string login, string password) // signing up with LinkedIn account
        {
            IWebElement signUpWithLinkedIn = driver.FindElement(By.XPath("//a[@title='Sign up with LinkedIn']"));
            signUpWithLinkedIn.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(), 'LinkedIn ') and @class='logo']")));
            IWebElement emailInputField = driver.FindElement(By.XPath("//input[@placeholder='Email']"));
            IWebElement passwordInputField = driver.FindElement(By.XPath("//input[@placeholder='Password']"));
            IWebElement allowAccessButton = driver.FindElement(By.XPath("//input[@value='Allow access']"));

            emailInputField.SendKeys(login);
            passwordInputField.SendKeys(password);
            allowAccessButton.Submit();
        }

        public void FacebookLogin(IWebDriver driver, WebDriverWait wait, string login, string password) // signing up with Facebook account
        {
            IWebElement signUpWithFacebook = driver.FindElement(By.XPath("//a[@title='Sign up with Facebook']"));
            signUpWithFacebook.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='header_block']")));
            IWebElement emailInputField = driver.FindElement(By.XPath("//input[@id='email']"));
            IWebElement passwordInputField = driver.FindElement(By.XPath("//input[@id='pass']"));
            IWebElement loginButton = driver.FindElement(By.XPath("//button[@id='loginbutton']"));


            emailInputField.SendKeys(login);
            passwordInputField.SendKeys(password);
            loginButton.Submit();
        }
    }
}

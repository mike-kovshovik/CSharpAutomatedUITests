using AQA.LightClient.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace AQA
{
    public class Program
    {
      
        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver();
            var testDataVariables = new TestData();
            var helper = new LoginHelper();
            String nextButtonXpath = "//a[@title='Next']";

            
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(testDataVariables.baseUrlLightClientsProd99);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'Looking for a quick, simple investment? Start here')]")));

            IWebElement start_planning_button = driver.FindElement(By.XPath("//button[@id='btnStartPlanning']"));
            Assert.IsFalse(start_planning_button.Enabled);


            // Scrolling down the page so that the 2 checkboxes are visible and can be clicked
            var pageFooter = driver.FindElement(By.XPath("//footer"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(pageFooter);
            actions.Perform();

            


            // locating terms of service checkbox
            IWebElement terms_of_service_checkbox = driver.FindElement(By.XPath("//span[contains(text(), 'Having read')]"));
            

            Actions clicker = new Actions(driver);
            clicker.MoveToElement(terms_of_service_checkbox, 0, 0).Click().Perform();
            

            // locating "no liabilities or debts" checkbox
            IWebElement has_no_debts_checkbox = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), 'I confirm I do not')]")));
            has_no_debts_checkbox.Click();

            start_planning_button.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'New Client?')]"))); // Waiting till the popup loads


            //helper.LinkedInLogin(driver, wait, "darryl.snyder@bk.ru", "P@ssw0rd12"); // Signing up with linkedin
            //helper.FacebookLogin(driver, wait, "gregg.walton@mail.ru", "qWaszx12"); // Signing up with linkedin


            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'How the service works')]")));
            IWebElement nextButton = driver.FindElement(By.XPath(nextButtonXpath));
            nextButton.Submit();


            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'Your investment Choices')]")));
            IWebElement goalTravel = driver.FindElement(By.XPath("//i[@class='icon-list-category-holiday']"));
            goalTravel.Click();
            nextButton = driver.FindElement(By.XPath(nextButtonXpath));
            nextButton.Submit();


            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'About your attitude to investment risk')]")));
            nextButton = driver.FindElement(By.XPath(nextButtonXpath));
            nextButton.Submit();


            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'Risk tolerance questions')]")));
            var atrAnswersXpath = "//button[@id='question_{0}_answer_5']";


            for (int i = 0; i <= 9; i++)
            {
                string str = string.Format(atrAnswersXpath, i);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(str)));
                driver.FindElement(By.XPath(str)).Click();                
            }


            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'Your risk tolerance profile')]")));
            nextButton = driver.FindElement(By.XPath(nextButtonXpath));
            nextButton.Submit();


            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'Your investment projection')]")));
            nextButton = driver.FindElement(By.XPath(nextButtonXpath));
            nextButton.Submit();


            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'About your risk capacity')]")));
            nextButton = driver.FindElement(By.XPath(nextButtonXpath));
            nextButton.Submit();


            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'Risk capacity questions')]")));
        


            var cflAnswersXpath = "//button[@type='button' and @id='question_{0}_answer_2']";


            for (int i = 0; i <= 2; i++)
            {
                string str = string.Format(cflAnswersXpath, i);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(str)));
                driver.FindElement(By.XPath(str)).Click();
            }


            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'Your proposed risk category')]")));
            String recommendedRiskCategory = "We recommend risk category 3";
            Assert.AreEqual(driver.FindElement(By.XPath("//table[@class='comparison table']//th[3]")).Text, recommendedRiskCategory);


            nextButton = driver.FindElement(By.XPath(nextButtonXpath));
            nextButton.Submit();


            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'Please confirm your investment choices')]")));
            nextButton = driver.FindElement(By.XPath(nextButtonXpath));
            nextButton.Submit();


            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'Our recommendation for you')]")));
            IWebElement continueNowButton = driver.FindElement(By.XPath("//a[@title='Continue now']"));
            continueNowButton.Submit();


            IWebElement emailAddress = wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//input[@id='pers-det-email']"))));

            // new object of Select class created in order to do manipulations with drop-down lists
            //Confirm your details page

            SelectElement title = new SelectElement(driver.FindElement(By.XPath("//select[@id='pers-det-title']")));
            title.SelectByValue("Mr");

            SelectElement dayOfBirth = new SelectElement(driver.FindElement(By.XPath("//select[@id='pers-det-dob-day']")));
            dayOfBirth.SelectByValue("14");
            
            SelectElement monthOfBirth = new SelectElement(driver.FindElement(By.XPath("//select[@id='pers-det-dob-month']")));
            monthOfBirth.SelectByValue("9");

            SelectElement yearOfBirth = new SelectElement(driver.FindElement(By.XPath("//select[@id='pers-det-dob-year']")));
            yearOfBirth.SelectByValue("1984");


            IWebElement contactNumberInput = driver.FindElement(By.XPath("//input[@id='pers-det-contact']"));
            contactNumberInput.SendKeys("+44 207 111 7755");


            IWebElement residencyCheckbox = driver.FindElement(By.XPath("//label[@for='pers-isUKResident']/span"));
            residencyCheckbox.Click();

   
            IWebElement citizenshipCheckbox = driver.FindElement(By.XPath("//label[@for='pers-isNotUSCitizen']/span"));
            citizenshipCheckbox.Click();

            IWebElement addressLineOneInput = driver.FindElement(By.XPath("//input[@id='pers-addr-line1']"));
            addressLineOneInput.SendKeys("Address Line 1");

            IWebElement townInput = driver.FindElement(By.XPath("//input[@id='pers-addr-locality']"));
            townInput.SendKeys("Kingston");

            IWebElement postalCodeInput = driver.FindElement(By.XPath("//input[@id='pers-addr-postalcode']"));
            postalCodeInput.SendKeys("KT1 2PD");

            IWebElement nationalInsuranceNumberInput = driver.FindElement(By.XPath("//input[@id='pers-NINumber']"));
            nationalInsuranceNumberInput.SendKeys("AA018998B");

            nextButton = driver.FindElement(By.XPath(nextButtonXpath));
            nextButton.Submit();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'Declaration')]")));
            
            // Go to PFP Profile
            driver.Navigate().GoToUrl("https://tst-04-pfp.test.intelliflo.com/profile");  //moved to a separate file;

            // Verify the client was converted and his email address can be found in his PFP Profile
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='personal-details']/div[2]/div/section[1]/div/div[2]/div[2]/div")));
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='personal-details']/div[2]/div/section[1]/div/div[2]/div[2]/div")).Text, "gregg.walton@mail.ru");


            // Logout from PFP
            driver.FindElement(By.XPath("//a[@title='Logout']")).Click();


            driver.Navigate().GoToUrl("https://tst-04.test.intelliflo.com/nio/dashboard/userdashboard");  //moved to a separate file;
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), 'Login')]"))).Click();

            // Log into iO
            IWebElement usernameInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='username']")));
            usernameInput.SendKeys("MK04");

            IWebElement passwordInput = driver.FindElement(By.XPath("//input[@id='password']"));
            passwordInput.SendKeys("qWaszx12");

            IWebElement loginButton = driver.FindElement(By.XPath("//button[contains(text(), 'Login')]"));
            loginButton.Click();


            // Verification whether the client was registered to iO

            IWebElement myRecentClientsLInk = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(), 'My Recent Clients')]")));
            myRecentClientsLInk.Click();

            IWebElement emailAddressInput = driver.FindElement(By.XPath("//input[@id='id_Plan_EmailAddress']"));
            emailAddressInput.SendKeys("gregg.walton@mail.ru");

            IWebElement searchButton = driver.FindElement(By.XPath("//a[starts-with(text(), 'Search')]"));
            searchButton.Click();

            IWebElement searchResultsLabel = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(), 'Search Results')]")));

            Assert.IsTrue(driver.FindElement(By.XPath("//tr[starts-with(@id, 'ClientSearchNameGrid')]/td[11]/span")).Text.Length > 0);

           
            driver.Quit();
            



        }


    }





}

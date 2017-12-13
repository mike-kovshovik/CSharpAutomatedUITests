using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages
{
    class ConfirmYourDetailsPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private By confirmYourDetailsHeaderPrototype = By.XPath("//b[contains(text(), 'Confirm your details')]");
        private By nextButton = By.XPath("//a[@title='Next']");
        private By emailAddressInput = By.XPath("//input[@id='pers-det-email']");
        private By titleSelect = By.XPath("//select[@id='pers-det-title']");
        private By dateOfBirthSelect = By.XPath("//select[@id='pers-det-dob-day']");
        private By monthOfBirthSelect = By.XPath("//select[@id='pers-det-dob-month']");
        private By yearOfBirthSelect = By.XPath("//select[@id='pers-det-dob-year']");
        private By genderSelect = By.XPath("//select[@id='pers-det-gender']");
        private By contactNumberInput = By.XPath("//input[@id='pers-det-contact']");
        public static readonly By residencyCheckbox = By.XPath("//label[@for='pers-isUKResident']/span");
        public static readonly By citizenshipCheckbox = By.XPath("//label[@for='pers-isNotUSCitizen']/span");
        private By addressLineOneInput = By.XPath("//input[@id='pers-addr-line1']");
        private By townInput = By.XPath("//input[@id='pers-addr-locality']");
        private By postalCodeInput = By.XPath("//input[@id='pers-addr-postalcode']");
        private By nationalInsuranceNumberInput = By.XPath("//input[@id='pers-NINumber']");
        

        public ConfirmYourDetailsPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

       public ConfirmYourDetailsPage SelectTitle(string title)
        {
            SelectElement titleDropDown = new SelectElement(driver.FindElement(titleSelect));
            titleDropDown.SelectByText(title);
            return this;
        }


        public ConfirmYourDetailsPage SelectDoB(string day, string month, string year)
        {
            var dayDropDown = new SelectElement(driver.FindElement(dateOfBirthSelect));
            dayDropDown.SelectByText(day);

            SelectElement monthDropDown = new SelectElement(driver.FindElement(monthOfBirthSelect));
            monthDropDown.SelectByText(month);

            SelectElement yearDropDown = new SelectElement(driver.FindElement(yearOfBirthSelect));
            yearDropDown.SelectByText(year);

            return this;
        }


        public ConfirmYourDetailsPage SelectGender(string gender)
        {
            SelectElement genderDropDown = new SelectElement(driver.FindElement(genderSelect));
            genderDropDown.SelectByText(gender);
            return this;
        }

        public ConfirmYourDetailsPage EnterContactNumber(string phoneNumber)
        {
            driver.FindElement(contactNumberInput).SendKeys(phoneNumber);
            return this;
        }


        public ConfirmYourDetailsPage TickCheckBox(By checkbox)
        {
            driver.FindElement(checkbox).Click();
            return this;
        }


        public ConfirmYourDetailsPage FillInAddressLineOne(string addressLineOne)
        {
            driver.FindElement(addressLineOneInput).SendKeys(addressLineOne);
            return this;
        }

        public ConfirmYourDetailsPage FillInTown(string town)
        {
            driver.FindElement(townInput).SendKeys(town);
            return this;
        }

        public ConfirmYourDetailsPage FillInPostCode(string postcode)
        {
            driver.FindElement(postalCodeInput).SendKeys(postcode);
            return this;
        }

        public ConfirmYourDetailsPage FillInNINumber(string niNumber)
        {
            driver.FindElement(nationalInsuranceNumberInput).SendKeys(niNumber);
            return this;
        }

        public void PressNextButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(confirmYourDetailsHeaderPrototype));
            driver.FindElement(nextButton).Submit();
        }




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AQA.LightClient.IntelligentOfficePages
{
    class IntelligentOfficeDashboardPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private readonly By myRecentClientsLInk = By.XPath("//a[contains(text(), 'My Recent Clients')]");

    
        public IntelligentOfficeDashboardPage(IWebDriver driver, WebDriverWait wait)
        {
            this._driver = driver;
            this._wait = wait;
        }


        public IntelligentOfficeDashboardPage SelectMyRecentClients()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(myRecentClientsLInk)).Click();
            return this;
        }

    }
}

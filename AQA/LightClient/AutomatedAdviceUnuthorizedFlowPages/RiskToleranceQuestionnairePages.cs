using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages
{
    class RiskToleranceQuestionnairePages
    {
        IWebDriver driver;
        WebDriverWait wait;

        private By riskToleranceHeaderPrototype = By.XPath("//b[contains(text(), 'Risk tolerance questions')]");
        private string atrAnswersXpath = "//button[@id='question_{0}_answer_5']";
                
        public RiskToleranceQuestionnairePages(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void answerRiskToleranceQuestions()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(riskToleranceHeaderPrototype));
            for (int i = 0; i <= 9; i++)
            {
                string str = string.Format(atrAnswersXpath, i);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(str)));
                driver.FindElement(By.XPath(str)).Click();
            }
        }

    }
}

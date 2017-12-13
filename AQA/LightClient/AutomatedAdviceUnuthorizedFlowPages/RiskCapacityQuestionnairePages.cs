using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages
{
    class RiskCapacityQuestionnairePages
    {
        IWebDriver driver;
        WebDriverWait wait;

        private By riskCapacityQuestionsHeaderPrototype = By.XPath("//b[contains(text(), 'Risk capacity questions')]");
        private string cflAnswersXpath = "//button[@type='button' and @id='question_{0}_answer_2']";
        
        public RiskCapacityQuestionnairePages(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void AnswerRiskToleranceQuestions()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(riskCapacityQuestionsHeaderPrototype));
            for (int i = 0; i <= 2; i++)
            {
                string str = string.Format(cflAnswersXpath, i);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(str)));
                driver.FindElement(By.XPath(str)).Click();
            }
        }


    }
}

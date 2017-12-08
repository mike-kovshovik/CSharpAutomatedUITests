using System;
using AQA.LightClient.Helpers;
using AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;



namespace AQA
{
    class LightClientsFlowTests
    {
        IWebDriver driver;
        WebDriverWait wait;
        TestData testDataVariables;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            testDataVariables = new TestData();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(testDataVariables.baseUrlLightClientsTST04);  
        }


        [Test]
        public void ExecuteTest()
        {
            // create an object of LightClientsLandingPage
            LandingPageForLightClients landingPage = new LandingPageForLightClients(driver, wait);

            // tick two checkboxes at the bottom of the page
            landingPage
                .tickCheckbox(landingPage.heavingReadTermsConditionsCheckbox)
                .tickCheckbox(landingPage.noDebtsCheckbox);

            // press Start Planning button
            landingPage.pressStartPlanning();

            // sign up to Automated Advice with Facebook account
            landingPage.signUpWithFacebook(testDataVariables.facebookLoginEmail, testDataVariables.facebookPassword);

            // submit Next button on How Service Works page
            HowServiceWorksPage howServiceWorks = new HowServiceWorksPage(driver, wait);
            howServiceWorks.PressNextButton();

            // submit Next button on Your investment Choices page
            YourInvestmentChoicesPage investmentChoicesPage = new YourInvestmentChoicesPage(driver, wait);
            investmentChoicesPage.PressNextButton();

            // submit Next button on About your attitude to investment risk page
            AttitudeToRiskPage attitudeToRiskPage = new AttitudeToRiskPage(driver, wait);
            attitudeToRiskPage.PressNextButton();

            // answer Risk Tolerance Questions
            RiskToleranceQuestionnairePages riskToleranceQuestionnaire = new RiskToleranceQuestionnairePages(driver, wait);
            riskToleranceQuestionnaire.answerRiskToleranceQuestions();



        }

        [TearDown]
        public void CleanUp()
        {
            //driver.Close();
        }



    }
}

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


            // press Next on Your risk tolerance profile page
            YourRiskToleranceProfilePage riskToleranceProfilePage = new YourRiskToleranceProfilePage(driver, wait);
            riskToleranceProfilePage.PressNextButton();


            // press Next on Your investment projection
            YourInvestmentProjectionPage yourInvestmentProjection = new YourInvestmentProjectionPage(driver, wait);
            yourInvestmentProjection.PressNextButton();


            // press Next on Your risk capacity page
            AboutYourRiskCapacityPage aboutYourRiskCapacity = new AboutYourRiskCapacityPage(driver, wait);
            aboutYourRiskCapacity.PressNextButton();


            // answer Risk Capacity Questions
            RiskCapacityQuestionnairePages riskCapacityQuestionnaire = new RiskCapacityQuestionnairePages(driver, wait);
            riskCapacityQuestionnaire.answerRiskToleranceQuestions();


            // press Next on Your proposed risk category page
            YourProposedRiskCategoryPage yourProposedRiskCategory = new YourProposedRiskCategoryPage(driver, wait);
            yourProposedRiskCategory.PressNextButton();


            // press Next on Please confirm your investment choices page
            ConfirmYourInvestmentChoicesPage confirmYourInvestmentChoices = new ConfirmYourInvestmentChoicesPage(driver, wait);
            confirmYourInvestmentChoices.PressNextButton();


            // press ContinueNow on Our recommendation for you page
            OurRecommendationForYouPage ourRecommendationForYou = new OurRecommendationForYouPage(driver, wait);
            ourRecommendationForYou.PressContinueNowButton();


            // fill out the fields on Confirm your details page
            ConfirmYourDetailsPage confirmYourDetails = new ConfirmYourDetailsPage(driver, wait);
            confirmYourDetails
                .selectTitle("Mr")
                .selectDoB("14", "Sep", "1984")
                .selectGender("Male")
                .enterContactNumber("+44 207 111 7755")
                .tickCheckBox(ConfirmYourDetailsPage.residencyCheckbox)
                .tickCheckBox(ConfirmYourDetailsPage.citizenshipCheckbox);




        }

        [TearDown]
        public void CleanUp()
        {
            //driver.Close();
        }



    }
}

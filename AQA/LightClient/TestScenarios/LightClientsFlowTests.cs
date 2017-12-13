using System;
using AQA.LightClient.Helpers;
using AQA.LightClient.AutomatedAdviceUnuthorizedFlowPages;
using AQA.LightClient.IntelligentOfficePages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace AQA
{
    class LightClientsFlowTests
    {
        IWebDriver _driver;
        WebDriverWait _wait;
        TestData testDataVariables;

        [SetUp]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            testDataVariables = new TestData();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(TestData.baseUrlLightClientsTST04);  
        }


        [Test]
        public void ExecuteTest()
        {
            // create an object of LightClientsLandingPage
            LandingPageForLightClients landingPage = new LandingPageForLightClients(_driver, _wait);
                
            // tick two checkboxes at the bottom of the page
            landingPage
                .TickCheckbox(landingPage.heavingReadTermsConditionsCheckbox)
                .TickCheckbox(landingPage.noDebtsCheckbox);


            // press Start Planning button
            landingPage.PressStartPlanning();


            // sign up to Automated Advice with Facebook account
            landingPage.SignUpWithFacebook(TestData.facebookLoginEmail, TestData.facebookPassword);


            // submit Next button on How Service Works page
            var howServiceWorks = new HowServiceWorksPage(_driver, _wait);
            howServiceWorks.PressNextButton();


            // submit Next button on Your investment Choices page
            var investmentChoicesPage = new YourInvestmentChoicesPage(_driver, _wait);
            investmentChoicesPage.PressNextButton();


            // submit Next button on About your attitude to investment risk page
            var attitudeToRiskPage = new AttitudeToRiskPage(_driver, _wait);
            attitudeToRiskPage.PressNextButton();


            // answer Risk Tolerance Questions
            var riskToleranceQuestionnaire = new RiskToleranceQuestionnairePages(_driver, _wait);
            riskToleranceQuestionnaire.AnswerRiskToleranceQuestions();


            // press Next on Your risk tolerance profile page
            var riskToleranceProfilePage = new YourRiskToleranceProfilePage(_driver, _wait);
            riskToleranceProfilePage.PressNextButton();


            // press Next on Your investment projection
            var yourInvestmentProjection = new YourInvestmentProjectionPage(_driver, _wait);
            yourInvestmentProjection.PressNextButton();


            // press Next on Your risk capacity page
            var aboutYourRiskCapacity = new AboutYourRiskCapacityPage(_driver, _wait);
            aboutYourRiskCapacity.PressNextButton();


            // answer Risk Capacity Questions
            var riskCapacityQuestionnaire = new RiskCapacityQuestionnairePages(_driver, _wait);
            riskCapacityQuestionnaire.AnswerRiskToleranceQuestions();


            // press Next on Your proposed risk category page
            var yourProposedRiskCategory = new YourProposedRiskCategoryPage(_driver, _wait);
            yourProposedRiskCategory.PressNextButton();


            // press Next on Please confirm your investment choices page
            var confirmYourInvestmentChoices = new ConfirmYourInvestmentChoicesPage(_driver, _wait);
            confirmYourInvestmentChoices.PressNextButton();


            // press ContinueNow on Our recommendation for you page
            var ourRecommendationForYou = new OurRecommendationForYouPage(_driver, _wait);
            ourRecommendationForYou.PressContinueNowButton();


            // fill out the fields on Confirm your details page
            var confirmYourDetails = new ConfirmYourDetailsPage(_driver, _wait);
            confirmYourDetails
                .SelectTitle("Mr")
                .SelectDoB("14", "Sep", "1984")
                .SelectGender("Male")
                .EnterContactNumber("+44 207 111 7755")
                .TickCheckBox(ConfirmYourDetailsPage.residencyCheckbox)
                .TickCheckBox(ConfirmYourDetailsPage.citizenshipCheckbox)
                .FillInAddressLineOne("Address Line 1")
                .FillInTown("London")
                .FillInPostCode("KT1 2PD")
                .FillInNINumber("AA018998B")
                .PressNextButton();

            // verify page header is Declaration and go to PFP LandingPage
            var declaration = new DeclarationPage(_driver, _wait);
            declaration.VerifyPageHeaderIsDeclaration("Declaration");
            declaration.GoToPfpHomePage();

            // Click Update Profile from the Landing Page
            var landing = new LandingPage(_driver, _wait);
            landing.GoToProfile();

            // Verify client's email address is present is Contact Details
            var profile = new ProfilePage(_driver, _wait);
            profile
                .IsClientEmailIsPresentInContactDetails(TestData.facebookLoginEmail)
                .LogoutFromPfp();


            // Log into Intelligent Office
            var intellignentOffice = new IntelligentOfficeLogInPage(_driver, _wait);
            intellignentOffice.LogInToIntelligentOffice(TestData.intelligentOfficeLoginPageTST04, TestData.intelligendOfficeTST04Login, TestData.intelligendOfficeTST04Password);

            // Select My Recent Items
            var dashboard = new IntelligentOfficeDashboardPage(_driver, _wait);
            dashboard.SelectMyRecentClients();

            // verify whether the Light Client has been converted and can be found in Intelligent Office

            var clientSeachPage = new IntelligentOfficeClientSearchPage(_driver, _wait);
            clientSeachPage.isLightClientRegisteredIniO(TestData.facebookLoginEmail);

        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Close();
        }

    }
}

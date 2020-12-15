using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace GuidantSurveyProject.Welcome_Page
{
    [TestClass]
    public class WelcomePageTests
    {
        

        //[TestInitialize]
        //public void SetupBeforeBeforeEveryMethod()
        //{
        //    //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    //driver = new ChromeDriver(path);
        //    //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //}

        //[TestCleanup]
        //public void CleanUpEveryAfterTestMethod()
        //{
        //    //driver.Close();
        //    //driver.Quit();
        //}


        [TestMethod]
        public void AccessOnboardingApp()
        {

            var welcomePage = new WelcomePage();
            welcomePage.Open();
            Assert.AreEqual("Welcome - Guidant Business Financial Survey", welcomePage._driver.Title);

        }

        [TestMethod]
        public void AccessOnboardingAppWelcome_CheckBallTracker_BallTrackerGreen()
        {
            var welcomePage = new WelcomePage();
            welcomePage.Open();

            var welcomeBallTrackerColor = welcomePage._wait.Until(ExpectedConditions.ElementExists(
                By.XPath("//div[@class='col-lg-4 mt-lg-4 mb-lg-2 text-center d-none d-lg-block']/div[1]"))).GetAttribute("class");
            Assert.AreEqual("tracker tracker-lg tracker-lg-green rounded-circle", welcomeBallTrackerColor);
            welcomePage.Dispose();
        }

        [TestMethod]
        public void AccessOnboardingAppWelcome_ClickContinue_GetFirstNameValidation()
        {

            var welcomePage = new WelcomePage();
            welcomePage.Open();         
            welcomePage.ClickContinue();
            var firstNameError = welcomePage._wait.Until(ExpectedConditions.ElementIsVisible(By.Id("FirstName-error"))).Text;           
            
            Assert.IsTrue(firstNameError.Contains("Required"));
            welcomePage.Dispose();
        }

        [TestMethod]
        public void EnterAllValidInfo_ClickContinue_AccessSpousePage()
        {
            
            var welcomePage = new WelcomePage();
            welcomePage.Open();
            welcomePage.EnterCompleteInfo("Illidan", "Stormrage", "a@a.com", "9199199191", "For the Horde, Inc");
            welcomePage.ClickContinue();
            
            var spousePage =
                welcomePage._wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='card-title text-lg-center']")));
            Assert.AreEqual("Spouse - Guidant Business Financial Survey", welcomePage._driver.Title);
            welcomePage.Dispose();
        }
    }
}   

using System;
using System.IO;
using System.Reflection;
using GuidantSurveyProject.Welcome_Page;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace GuidantSurveyProject.Spouse_Page
{
    [TestClass]
    public class SpousePageTest
    {
        

        [TestMethod]
        public void CompleteWelcomePage_ClickContinue_AccessSpousePage()
        {

            var spousePage = new SpousePage();
            spousePage.OpenSpousePage("Illidan", "Stormrage", "a@a.com", "9199199191", "For the Horde, Inc");
            var spouseTitle =
                spousePage._wait.Until(
                    ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='card-title text-lg-center']")));

            Assert.AreEqual("Spouse - Guidant Business Financial Survey", spouseTitle);
            spousePage.Dispose();

        }

        [TestMethod]
        public void AccessSpousePage_CheckPreviousBallTracker_BallTrackerGreenWithCheck()
        {
            var spousePage = new SpousePage();
            spousePage.OpenSpousePage("Illidan", "Stormrage", "a@a.com", "9199199191", "For the Horde, Inc");

            

            var welcomeBallTrackerColor = spousePage._wait.Until(ExpectedConditions.ElementExists(
                By.XPath("//div[@class='col-lg-4 mt-lg-4 mb-lg-2 text-center d-none d-lg-block']/div[1]"))).GetAttribute("class");
            var welcomeBallTrackerIcon = spousePage._wait.Until(ExpectedConditions.ElementExists(
                By.XPath("//div[@class='col-lg-4 mt-lg-4 mb-lg-2 text-center d-none d-lg-block']/div[1]//*[@data-icon='check']"))).GetAttribute("data-icon");


            Assert.AreEqual("tracker tracker-lg tracker-lg-green rounded-circle", welcomeBallTrackerColor);
            Assert.AreEqual("check", welcomeBallTrackerIcon);
            spousePage.Dispose();
        }


        [TestMethod]
        public void AccessSpousePage_CheckSpouseBallTracker_BallTrackerGreen()
        {
            var spousePage = new SpousePage();
            spousePage.OpenSpousePage("Illidan", "Stormrage", "a@a.com", "9199199191", "For the Horde, Inc");
            var spouseBallTrackerColor = spousePage._wait.Until(ExpectedConditions.ElementExists(
                By.XPath("//div[@class='col-lg-4 mt-lg-4 mb-lg-2 text-center d-none d-lg-block']/div[2]"))).GetAttribute("class");
            

            Assert.AreEqual("tracker tracker-lg tracker-lg-green rounded-circle", spouseBallTrackerColor);
        
            spousePage.Dispose();
        }


        [TestMethod]
        public void AccessSpousePage_NoInfoClickContinue_ValidateAllFields()
        {
            var spousePage = new SpousePage();
            spousePage.OpenSpousePage("Mirana", "Moon", "a@a.com", "9198958597", "Night Elf Wathchers");
            spousePage.ContinueButton.Click();
            Assert.AreEqual("Required", spousePage.firstNameError.Text);
            Assert.AreEqual("Required", spousePage.lastNameError.Text);
            Assert.AreEqual("Required", spousePage.emailError.Text);
            Assert.AreEqual("Required", spousePage.phoneError.Text);
            spousePage.Dispose();







        }

    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace GuidantSurveyProject.Review_Page
{
    [TestClass]
    public class ReviewPageTests
    {
        

        [TestMethod]
        public void AccessReviewPage_ClickEditContactInformation_WelcomePageOpens()
        {
            var reviewPage = new ReviewPage();
            reviewPage.OpenSpousePage("Illidan", "Stormrage", "a@a.com", "9199199191", "For the Horde, Inc");
            reviewPage.OpenBusinessInfoPage("Mirana", "Moon", "a@a.com", "9198958597");
            reviewPage.OpenReviewPage("Independent", "100000", "Less than 2 months");
            reviewPage.EditContactInfoLink.Click();

            Assert.AreEqual("Welcome - Guidant Business Financial Survey", reviewPage._driver.Title);
            reviewPage.Dispose();
        }


        [TestMethod]
        public void EditBusinessInfo_ChangeCost_ReviewPageUpdatedwithNewCost()
        {
            var reviewPage = new ReviewPage();
            reviewPage.OpenSpousePage("Illidan", "Stormrage", "a@a.com", "9199199191", "For the Horde, Inc");
            reviewPage.OpenBusinessInfoPage("Mirana", "Moon", "a@a.com", "9198958597");
            reviewPage.OpenReviewPage("Independent", "100000", "Less than 2 months");
            reviewPage.EditBusinessInfoLink.Click();
            reviewPage.EnterNewProjCost("9999");
            reviewPage.ContinueButton.Click();
            reviewPage._wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='text-muted']")));
            var newProjCost = reviewPage.reviewProjCostText;
            Assert.AreEqual("$9999", newProjCost.Text);
            reviewPage.Dispose();

        }


        [TestMethod]
        public void EnteredAllInfo_ClickConfirm_ThankYouPage()
        {
            var reviewPage = new ReviewPage();
            reviewPage.OpenSpousePage("Illidan", "Stormrage", "a@a.com", "9199199191", "For the Horde, Inc");
            reviewPage.OpenBusinessInfoPage("Mirana", "Moon", "a@a.com", "9198958597");
            reviewPage.OpenReviewPage("Independent", "100000", "Less than 2 months");
            reviewPage.ConfirmButton.Click();
            var thankYouMessage = reviewPage._wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));
                      
            Assert.IsTrue(thankYouMessage.Displayed);
            reviewPage.Dispose();
        }
    }
}

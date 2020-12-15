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
        public void EnteredAllInfo_ClickConfirm_ThankYouPage()
        {
            var reviewPage = new ReviewPage();
            reviewPage.OpenSpousePage("Illidan", "Stormrage", "a@a.com", "9199199191", "For the Horde, Inc");
            reviewPage.OpenBusinessInfoPage("Mirana", "Moon", "a@a.com", "9198958597");
            reviewPage.OpenReviewPage("100000");
            var thankYouMessage = reviewPage._wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));
            Assert.IsTrue(thankYouMessage.Displayed);
            reviewPage.Dispose();
        }
    }
}

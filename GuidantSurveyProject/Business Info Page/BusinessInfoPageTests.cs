using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace GuidantSurveyProject.Business_Info_Page
{
    [TestClass]
    public class BusinessInfoPageTests
    {

        [TestMethod]
        public void CompletedSpousePage_ClickContinue_AccessBusinessInfoPage()
        {
            var businessInfoPage = new BusinessInfoPage();
            businessInfoPage.OpenSpousePage("Illidan", "Stormrage", "a@a.com", "9199199191", "For the Horde, Inc");
            businessInfoPage.OpenBusinessInfoPage("Mirana", "Moon", "a@a.com", "9198958597");
            var businessInfoTitle =
                businessInfoPage._wait.Until(
                    ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='card-title text-lg-center']")));

            Assert.AreEqual("Business - Guidant Business Financial Survey", businessInfoTitle);
            businessInfoPage.Dispose();
        }



        [TestMethod]
        public void AccessBusinessInfoPage_SelectFranchise_FranschiseNameQuestionAppears()
        {
            var businessInfoPage = new BusinessInfoPage();
            businessInfoPage.OpenSpousePage("Illidan", "Stormrage", "a@a.com", "9199199191", "For the Horde, Inc");
            businessInfoPage.OpenBusinessInfoPage("Mirana", "Moon", "a@a.com", "9198958597");
            businessInfoPage.BusinessTypeDropDown.Click();
            var selectFranchise = new SelectElement(businessInfoPage.BusinessTypeDropDown);
            selectFranchise.SelectByText("Franchise");

            var franchiseNameTexBox =
                businessInfoPage._wait.Until(ExpectedConditions.ElementIsVisible(By.Id("FranchiseName")));

            Assert.IsTrue(franchiseNameTexBox.Displayed);

            businessInfoPage.Dispose();

        }

        [TestMethod]
        public void AccessBusinessInfoPage_ClickBusinessType_ShowsExpectedTypes()
        {
            var businessInfoPage = new BusinessInfoPage();
            businessInfoPage.OpenSpousePage("Illidan", "Stormrage", "a@a.com", "9199199191", "For the Horde, Inc");
            businessInfoPage.OpenBusinessInfoPage("Mirana", "Moon", "a@a.com", "9198958597");

            List<string> businessType = new List<string>() { "---", "Franchise", "Independent", "Licensee", "I don't know yet"};
            IList<IWebElement> dropdownList = businessInfoPage._driver.FindElements(By.Id("BusinessType"));
            foreach (IWebElement i in dropdownList)
            {
                Assert.AreEqual(i.Text, businessType);
            }
            businessInfoPage.Dispose();
        }


        [TestMethod]
        public void AccessBusinessInfoPage_ClickIDontKnowCheckbox_DisableFranchiseTextbox()
        {
            var businessInfoPage = new BusinessInfoPage();
            businessInfoPage.OpenSpousePage("Illidan", "Stormrage", "a@a.com", "9199199191", "For the Horde, Inc");
            businessInfoPage.OpenBusinessInfoPage("Mirana", "Moon", "a@a.com", "9198958597");
            var selectFranchise = new SelectElement(businessInfoPage.BusinessTypeDropDown);
            selectFranchise.SelectByText("Franchise");
            businessInfoPage.IDontKnowFranshiseCheckBox.Click();

            Assert.IsFalse(businessInfoPage.FranchiseNameTextBox.Enabled);
            businessInfoPage.Dispose();
        }

    }
}

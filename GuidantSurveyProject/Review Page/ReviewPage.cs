using GuidantSurveyProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace GuidantSurveyProject.Review_Page
{
    public class ReviewPage : Page
    {
        public IWebElement BusinessTypeDropDown => _driver.FindElement(By.Id("BusinessType"));
        public IWebElement FranchiseNameTextBox => _driver.FindElement(By.Id("FranchiseName"));
        public IWebElement FundOptionRadioStart => _driver.FindElement(By.XPath("//*[@class='form-check'][1]/input"));
        public IWebElement FundingTimeLineDropDown => _driver.FindElement(By.Id("FundingTimeline"));
        public IWebElement ProjectCostTextBox => _driver.FindElement(By.Id("ProjectCost"));
        public IWebElement ProjectCostTextBox9999 => _driver.FindElement(By.Id("ProjectCost"));
        public IWebElement ThankYouMsg => _driver.FindElement(By.XPath("h1"));

        public IWebElement FirstNameTextbox => _driver.FindElement(By.Id("FirstName"));
        public IWebElement LastNameTextbox => _driver.FindElement(By.Id("LastName"));
        public IWebElement EmailTextbox => _driver.FindElement(By.Id("Email"));
        public IWebElement PrimaryPhoneTextbox => _driver.FindElement(By.Id("PrimaryPhone"));
        public IWebElement BusinessNameTextbox => _driver.FindElement(By.Id("BusinessName"));
        public IWebElement ContinueButton => _driver.FindElement(By.XPath("//*[@class='btn btn-success w-50']"));
        public IWebElement ConfirmButton => _driver.FindElement(By.XPath("//*[@class='btn btn-success w-50']"));

        public IWebElement EditContactInfoLink => _driver.FindElements(By.XPath("//strong"))[0];
        public IWebElement EditSpouseInfoLink => _driver.FindElements(By.XPath("//strong"))[1];
        public IWebElement EditBusinessInfoLink => _driver.FindElements(By.XPath("//strong"))[2];

        public IWebElement reviewProjCostText => _driver.FindElements(By.XPath("//*[@class='text-muted']"))[2];


        public IWebElement RightArrowKey =>
            _driver.FindElement(By.XPath("//*[@class='col-lg-2 text-lg-left mt-lg-6 d-none d-lg-block']/a"));



        internal void EnterNewProjCost(string newProjCost)
        {
            ProjectCostTextBox.Clear();
            ProjectCostTextBox.SendKeys(newProjCost);
        }

        public void Open()
        {
            _driver.Navigate().GoToUrl("https://gf-onboarding-test.azurewebsites.net/");
        }



        public void OpenSpousePage(string fName, string lName, string email, string phone, string bName)
        {

            Open();
            FirstNameTextbox.SendKeys(fName);
            LastNameTextbox.SendKeys(lName);
            EmailTextbox.SendKeys(email);
            PrimaryPhoneTextbox.SendKeys(phone);
            BusinessNameTextbox.SendKeys(bName);
            ContinueButton.Click();
            
        }

        public void OpenBusinessInfoPage(string fName, string lName, string email, string phone)
        {
            FirstNameTextbox.SendKeys(fName);
            LastNameTextbox.SendKeys(lName);
            EmailTextbox.SendKeys(email);
            PrimaryPhoneTextbox.SendKeys(phone);
            ContinueButton.Click();
        }


        public void OpenReviewPage(string franchise, string pCost, string fundTime)
        {
            var selectFranchise = new SelectElement(BusinessTypeDropDown);
            selectFranchise.SelectByText(franchise);
            FundOptionRadioStart.Click();
            ProjectCostTextBox.SendKeys(pCost);
            var selectFunding = new SelectElement(FundingTimeLineDropDown);
            selectFunding.SelectByText(fundTime);
            ConfirmButton.Click();
        }

        public void FillOutEverything() 
        {
            FirstNameTextbox.SendKeys("Illidan");
            LastNameTextbox.SendKeys("Stormrage");
            EmailTextbox.SendKeys("a@a.com");
            PrimaryPhoneTextbox.SendKeys("9199199191");
            BusinessNameTextbox.SendKeys("For the Horde, Inc");
            ContinueButton.Click();

            
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='card-title text-lg-center']")));

            FirstNameTextbox.SendKeys("Mirana");
            LastNameTextbox.SendKeys("Moon");
            EmailTextbox.SendKeys("a@b.com");
            PrimaryPhoneTextbox.SendKeys("9198958597");
            ContinueButton.Click();

            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'Business Information')]")));

            var selectFranchise = new SelectElement(BusinessTypeDropDown);
            selectFranchise.SelectByText("Independent");
            FundOptionRadioStart.Click();
            ProjectCostTextBox.SendKeys("1000000");
            var selectFunding = new SelectElement(FundingTimeLineDropDown);
            selectFunding.SelectByText("Less than 2 months");
            ConfirmButton.Click();
        }


    }

    
}

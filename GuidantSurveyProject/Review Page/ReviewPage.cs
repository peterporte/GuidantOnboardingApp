using GuidantSurveyProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidantSurveyProject.Review_Page
{ 
    public class ReviewPage : Page
    
    {
        public IWebElement BusinessTypeDropDown => _driver.FindElement(By.Id("BusinessType"));
        public IWebElement FranchiseNameTextBox => _driver.FindElement(By.Id("FranchiseName"));
        public IWebElement FundOptionRadioStart => _driver.FindElement(By.XPath("//*[@class='form-check'][1]/input"));
        public IWebElement FundingTimeLineDropDown => _driver.FindElement(By.Id("FundingTimeline"));
        public IWebElement ProjectCostTextBox => _driver.FindElement(By.Id("ProjectCost"));
        public IWebElement ThankYouMsg => _driver.FindElement(By.XPath("h1"));


        public IWebElement FirstNameTextbox => _driver.FindElement(By.Id("FirstName"));
        public IWebElement LastNameTextbox => _driver.FindElement(By.Id("LastName"));
        public IWebElement EmailTextbox => _driver.FindElement(By.Id("Email"));
        public IWebElement PrimaryPhoneTextbox => _driver.FindElement(By.Id("PrimaryPhone"));
        public IWebElement BusinessNameTextbox => _driver.FindElement(By.Id("BusinessName"));
        public IWebElement ContinueButton => _driver.FindElement(By.XPath("//*[@class='btn btn-success w-50']"));
        public IWebElement ConfirmButton => _driver.FindElement(By.XPath("//*[@class='btn btn-success w-50']"));


        public void OpenSpousePage(string fName, string lName, string email, string phone, string bName)
        {

            _driver.Navigate().GoToUrl("https://gf-onboarding-test.azurewebsites.net/");
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


        public void OpenReviewPage(string pCost)
        {
            var selectFranchise = new SelectElement(BusinessTypeDropDown);
            selectFranchise.SelectByText("Independent");
            FundOptionRadioStart.Click();
            ProjectCostTextBox.SendKeys(pCost);
            var selectFunding = new SelectElement(FundingTimeLineDropDown);
            selectFunding.SelectByText("Less than 2 months");
            ConfirmButton.Click();



        }

    }
}

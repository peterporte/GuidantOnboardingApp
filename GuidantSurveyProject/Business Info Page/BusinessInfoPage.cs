using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuidantSurveyProject.Pages;
using OpenQA.Selenium;

namespace GuidantSurveyProject.Business_Info_Page
{
    public class BusinessInfoPage : Page
    {

        public IWebElement BusinessTypeDropDown => _driver.FindElement(By.Id("BusinessType"));
        public IWebElement FranchiseNameTextBox => _driver.FindElement(By.Id("FranchiseName"));
        public IWebElement IDontKnowFranshiseCheckBox => _driver.FindElement(By.Id("UnknowFranchiseName"));


        public IWebElement FirstNameTextbox => _driver.FindElement(By.Id("FirstName"));
        public IWebElement LastNameTextbox => _driver.FindElement(By.Id("LastName"));
        public IWebElement EmailTextbox => _driver.FindElement(By.Id("Email"));
        public IWebElement PrimaryPhoneTextbox => _driver.FindElement(By.Id("PrimaryPhone"));
        public IWebElement BusinessNameTextbox => _driver.FindElement(By.Id("BusinessName"));
        public IWebElement ContinueButton => _driver.FindElement(By.XPath("//*[@class='btn btn-success w-50']"));


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

     
    }
}

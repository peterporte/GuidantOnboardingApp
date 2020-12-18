using System;
using GuidantSurveyProject.Pages;
using OpenQA.Selenium;

namespace GuidantSurveyProject.Spouse_Page
{
    public class SpousePage : Page
    {
        
        public IWebElement FirstNameTextbox => _driver.FindElement(By.Id("FirstName"));
        public IWebElement LastNameTextbox => _driver.FindElement(By.Id("LastName"));
        public IWebElement EmailTextbox => _driver.FindElement(By.Id("Email"));
        public IWebElement PrimaryPhoneTextbox => _driver.FindElement(By.Id("PrimaryPhone"));
        public IWebElement BusinessNameTextbox => _driver.FindElement(By.Id("BusinessName"));
        public IWebElement ContinueButton => _driver.FindElement(By.XPath("//*[@class='btn btn-success w-50']"));

        public IWebElement firstNameError => _driver.FindElement(By.Id("FirstName-error"));
        public IWebElement lastNameError => _driver.FindElement(By.Id("LastName-error"));
        public IWebElement emailError => _driver.FindElement(By.Id("Email-error"));
        public IWebElement phoneError => _driver.FindElement(By.Id("PrimaryPhone-error"));


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


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuidantSurveyProject.Pages;
using OpenQA.Selenium;

namespace GuidantSurveyProject.Welcome_Page
{
    public class WelcomePage : Page
    {
        

     

        public WelcomePage()
            
        {
            
        }

      
        public IWebElement FirstNameTextbox => _driver.FindElement(By.Id("FirstName"));
        public IWebElement LastNameTextbox => _driver.FindElement(By.Id("LastName"));
        public IWebElement EmailTextbox => _driver.FindElement(By.Id("Email"));
        public IWebElement PrimaryPhoneTextbox => _driver.FindElement(By.Id("PrimaryPhone"));
        public IWebElement BusinessNameTextbox => _driver.FindElement(By.Id("BusinessName"));

        public IWebElement GetFirstNameValidation => _driver.FindElement(By.Id("FirstName-error"));
     

        public void Open()
        {
            _driver.Navigate().GoToUrl("https://gf-onboarding-test.azurewebsites.net/");

        }

        public void ClickContinue()
        {
            _driver.FindElement(By.XPath("//*[@class='btn btn-success w-50']")).Click();
        }

        public void EnterCompleteInfo(string fName, string lName, string email, string phone, string bName)
        {
            FirstNameTextbox.SendKeys(fName);
            LastNameTextbox.SendKeys(lName);
            EmailTextbox.SendKeys(email);
            PrimaryPhoneTextbox.SendKeys(phone);
            BusinessNameTextbox.SendKeys(bName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace GuidantSurveyProject.Pages
{
    public class Page : IDisposable
    {
        public IWebDriver _driver;
        public WebDriverWait _wait;
        public Actions _action;


        public Page()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(path);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _action = new Actions(_driver);
            _driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.Utilities
{
    public class Base
    {
       public IWebDriver driver; // Global variable`

        [SetUp]
        public void InvokeBrowser()
        {
            string browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName); // You can change "chrome" to "firefox" or "edge" as needed
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            // Set timeouts and maximize window
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }
        public void InitBrowser(String browsername)
        {
            switch(browsername)
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--incognito");
                    driver = new ChromeDriver(options);
                    break;
                // Add cases for other browsers if needed
                case "firefox":
                    // Initialize FirefoxDriver here
                    FirefoxOptions options1 = new FirefoxOptions();
                    options1.AddArgument("--incognito");
                    driver = new FirefoxDriver(options1);
                    break;
                 case "edge":
                    EdgeOptions options2 = new EdgeOptions();
                    options2.AddArgument("--incognito");
                    driver = new EdgeDriver(options2);
                    break;
            }

        }
        [TearDown]
        public void AfterTest()
        {
            // Close the browser after the test
            driver.Quit();
        }
    }
}

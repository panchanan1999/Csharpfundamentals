using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumAutomation
{
    internal class FunctionalTest
    {
        IWebDriver driver;//making it global variable so that everymethod can access it

        [SetUp]
        public void InvokeBrowser()
        {
            //SetUp --geturl,click--
            //edge browser
            //firefoxbrowser
            //chromedriver.exe on chrome browser
            //version specifiic
            //Webdriver manager --Automatically update the browser and installed it and invoke it(Webdriver manager package)
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            // new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            // driver = new EdgeDriver();
            //driver = new FirefoxDriver();
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            //Implicit wait globally creation

            //Explicit wait initialization
            //Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            //driver.Manage().Window.FullScreen();

        }
        [Test]
        public void dropdown()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            IWebElement Username = driver.FindElement(By.Id("username"));
            IWebElement Password = driver.FindElement(By.Name("password"));
            IWebElement LoginButton = driver.FindElement(By.CssSelector("input[type='submit']"));
            Username.SendKeys("rahulshettyacademy");
            Password.SendKeys("learning");
            IList<IWebElement> radiobttns = driver.FindElements(By.CssSelector("input[type='radio']"));
            //checking if the radiobutton select the user then only click on it
            foreach (IWebElement radiobtn in radiobttns)
            {
                if (radiobtn.GetAttribute("value") == "user")
                {
                    radiobtn.Click();
                    break;
                }
            }
            //giving some explicit wait for clicking the okay button
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn"))); 
            driver.FindElement(By.Id("okayBtn")).Click();
            IWebElement rdrop=driver.FindElement(By.XPath("//select[@class='form-control']"));
            SelectElement s = new SelectElement(rdrop);
            s.SelectByValue("consult");
            //s.SelectByIndex(1);
            IWebElement termsbox = driver.FindElement(By.Id("terms"));
            termsbox.Click();
            IWebElement signbttn = driver.FindElement(By.Id("signInBtn"));
            signbttn.Click();

        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
namespace SeleniumAutomation
{
    public class Locators
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
        public void LocatorsIdentification()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            IWebElement Username = driver.FindElement(By.Id("username"));
            IWebElement Password = driver.FindElement(By.Name("password"));
            IWebElement LoginButton = driver.FindElement(By.CssSelector("input[type='submit']"));
            Username.SendKeys("rahulshettyacademy");
            //Thread.Sleep(10000);
            Password.SendKeys("learning");
            IWebElement termsbox = driver.FindElement(By.Id("terms"));
            IWebElement signInButton = driver.FindElement(By.Id("signInBtn"));
            termsbox.Click();
            signInButton.Click();
            string errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);
            //Thread.Sleep(10000);
            //---***This code checks if the url blinking is correct or not
            IWebElement link = driver.FindElement(By.ClassName("blinkingText"));
            string hrefValue = link.GetAttribute("href");
            string expectedHref = "https://rahulshettyacademy.com/documents-request";
            Assert.AreEqual(expectedHref, hrefValue, "The href value does not match the expected value.");
            //---this is the end of the test---//
        }
        //[TearDown]
        //public void Closingbrower()
        //{
        //    driver.Close();//closing the browser
        //}
    }
}

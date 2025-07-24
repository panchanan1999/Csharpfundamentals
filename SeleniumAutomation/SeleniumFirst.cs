using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumAutomation
{
    //[TestFixture]
    public class SeleniumFirst
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
            driver.Manage().Window.Maximize();

            //driver.Manage().Window.FullScreen();

        }
        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/";
            //Thread.Sleep(1000000000);
        }
        [TearDown]
        public void Closingbrower()
        {
            driver.Close();//closing the browser
        }
    }
}

using NUnit.Framework.Legacy;
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
    internal class AlertsActionsAutoSuggestive
    {
        IWebDriver driver;//making it global variable so that everymethod can access it

        [SetUp]
        public void InvokeBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/";
            IWebElement practice = driver.FindElement(By.CssSelector("a[href*=\"practice-project\"]"));
            practice.Click();
            IWebElement name = driver.FindElement(By.CssSelector("input[id*=\"name\"]"));
            IWebElement email = driver.FindElement(By.XPath("//input[contains(@name,'email')]"));
            name.SendKeys("Test User");
            email.SendKeys("ronimandal848@gmail.com");
            IWebElement checkbox = driver.FindElement(By.XPath("//input[contains(@type,'checkbox')]"));
            checkbox.Click();
            IWebElement submit = driver.FindElement(By.CssSelector("button[type='submit']"));
            submit.Click();
        }
        [Test]
        public void testAlert()
        {
            String MyName = "Panchanan";
            IWebElement practice2= driver.FindElement(By.CssSelector("a[href='https://rahulshettyacademy.com/AutomationPractice/']"));
            practice2.Click();
            driver.FindElement(By.Id("name")).SendKeys(MyName);
            driver.FindElement(By.Id("confirmbtn")).Click();
            String AlertText=driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept(); // Accept the alert
            StringAssert.Contains(MyName, AlertText, "Alert text does not contain the expected name.");

        }
        [Test]
        public void testAlertAutoSuggestiveDropdowns()
        {

        }
    }
}

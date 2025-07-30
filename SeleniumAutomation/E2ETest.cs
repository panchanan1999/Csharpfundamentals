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
    internal class E2ETest
    {
        IWebDriver driver;//making it global variable so that everymethod can access it

        [SetUp]
        public void InvokeBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();           
        }
        [Test]
        public void E2EWorkflow()
        {
            string[]ExpectedProducts = { "Blackberry", "Nokia Edge" };
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            IWebElement Username = driver.FindElement(By.Id("username"));
            IWebElement Password = driver.FindElement(By.Name("password"));
            Username.SendKeys("rahulshettyacademy");
            Password.SendKeys("learning");
            IWebElement termsbox = driver.FindElement(By.Id("terms"));
            termsbox.Click();
            IWebElement signbttn = driver.FindElement(By.Id("signInBtn"));
            signbttn.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));  
            IList<IWebElement> products = driver.FindElements(By.CssSelector("app-card"));
            foreach(IWebElement product in products)
            {
                
                if (ExpectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text) || ExpectedProducts.Contains(product.FindElement(By.CssSelector("h4.card-title")).Text))
                {
                    //This will click on the add to cart button of the product
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                  
                }
            }
            //Click on the checkout button
            driver.FindElement(By.PartialLinkText("Checkout")).Click();


        }
    }
}

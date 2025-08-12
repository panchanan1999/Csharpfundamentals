using CSharpSelFramework.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CSharpSelFramework.Tests
{
    public class Tests
    {

        internal class E2ETest:Base
        {
            [Test]
            public void E2EWorkflow()
            {
                string[] ExpectedProducts = { "Blackberry", "Nokia Edge" };
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
                foreach (IWebElement product in products)
                {

                    if (ExpectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                    {
                        //This will click on the add to cart button of the product
                        product.FindElement(By.CssSelector(".card-footer button")).Click();
                    }
                    TestContext.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
                }
                //Assert.AreEqual(ExpectedProducts, products);
                //Click on the checkout button
                driver.FindElement(By.CssSelector("a.nav-link.btn.btn-primary")).Click();
                driver.FindElement(By.CssSelector("button.btn.btn-success")).Click();


            }
        }
    }
}
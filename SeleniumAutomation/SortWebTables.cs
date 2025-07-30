using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumAutomation
{
    internal class SortWebTables
    {
        IWebDriver driver;//making it global variable so that everymethod can access it

        [SetUp]
        public void InvokeBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }
        [Test]
        public void sort_table()
        {
            ArrayList a=new ArrayList();//creating an array to store the names of the vegies
            //at first i will increse the page size to 20 to see all the products
            IWebElement pagesize=driver.FindElement(By.Id("page-menu"));
            SelectElement selectElement = new SelectElement(pagesize);
            selectElement.SelectByValue("20");//selecting the page size to 20
            //step-1 get all vagie names into arraylist
            IList<IWebElement> vegies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement vegie in vegies)
            {
                Console.WriteLine(vegie.Text);
                a.Add(vegie.Text);//adding the vegie names to the arraylist
            }
            //step-2 sort the arraylist
            a.Sort();
            TestContext.WriteLine("Sorted ArrayList: ");

            foreach (var item in a)
            {
                TestContext.WriteLine(item);//printing the sorted arraylist
            }
            //step-3 click on the header to sort the table
            IWebElement e = driver.FindElement(By.CssSelector("th[aria-label*=\"Veg/fruit name\"]"));
            e.Click();//clicking on the header to sort the table
            //step-4 get all the vegie names after sorting
            ArrayList a1 = new ArrayList();//creating an array to store the names of the vegies after sorting
            IList<IWebElement> sveggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement vegie in sveggies)
            {
                a1.Add(vegie.Text);//adding the vegie names to the arraylist
            }
            Assert.AreEqual(a,a1);//comparing the sorted arraylist with the table values



        }
    }
}

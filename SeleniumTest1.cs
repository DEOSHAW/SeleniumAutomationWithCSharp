using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationWithCSharp
{
    public class SeleniumTest1
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.FullScreen();

        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            

            TestContext.Progress.WriteLine("Page title is: "+driver.Title);

            TestContext.Progress.WriteLine("Page title is: " + driver.Url);

            driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("Deo");
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("Deo");
            driver.FindElement(By.Id("terms")).Click();
            driver.FindElement(By.Id("signInBtn")).Click();
            WebDriverWait wait=new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            Thread.Sleep(2000);

           IWebElement errorElement= driver.FindElement(By.CssSelector(".alert.alert-danger.col-md-12"));
            String errorMsg = errorElement.Text;
            TestContext.Progress.Write("Error message is: "+errorMsg);

             Assert.AreEqual("Incorrect username/password.",errorMsg);

           






        }
        [TearDown]
        public void closeBrowser()
        {

            driver.Quit();

        }
    }
}

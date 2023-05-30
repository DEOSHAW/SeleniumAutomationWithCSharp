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

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
           

            TestContext.Progress.WriteLine("Page title is: "+driver.Title);

            TestContext.Progress.WriteLine("Page title is: " + driver.Url);

            driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("Deo");
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("Deo");
            driver.FindElement(By.CssSelector(".text-info span:nth-child(1) input")).Click(); 
            IWebElement SignIn=driver.FindElement(By.Id("signInBtn"));
            SignIn.Click();
            WebDriverWait wait=new WebDriverWait(driver,TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(SignIn, "Sign In"));

           IWebElement errorElement= driver.FindElement(By.CssSelector(".alert.alert-danger.col-md-12"));
            String errorMsg = errorElement.Text;
            IWebElement blinkingElement= driver.FindElement(By.CssSelector(".blinkingText:nth-child(1)"));
            String hrefUrl=blinkingElement.GetAttribute("href");
            Thread.Sleep(2000);
            


            TestContext.Progress.Write("Error message is: "+errorMsg);

             Assert.AreEqual("Incorrect username/password.",errorMsg);
             Assert.AreEqual("https://rahulshettyacademy.com/documents-request", hrefUrl);
             Thread.Sleep(2000);

          








        }
        [TearDown]
        public void closeBrowser()
        {

            driver.Quit();

        }
    }
}

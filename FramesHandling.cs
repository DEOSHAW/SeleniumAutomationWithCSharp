using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationWithCSharp
{
    internal class FramesHandling
    {

        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            //driver.Manage().Window.FullScreen();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        [Test]
        public void testFrame()
        {
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Id("courses-iframe")));
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.XPath("(//a[contains(text(),'All Access plan')])[1]")).Click();
            Thread.Sleep(2000);
            String FrameText= driver.FindElement(By.CssSelector("h1")).Text;
            TestContext.Progress.WriteLine(FrameText);
            Assert.AreEqual("ALL ACCESS SUBSCRIPTION", FrameText);
            driver.SwitchTo().DefaultContent();
            String MainPageText = driver.FindElement(By.CssSelector("h1")).Text;
            TestContext.Progress.WriteLine(MainPageText);
            Assert.AreEqual("Practice Page", MainPageText);



        }

        [TearDown]
        public void closeBrowser()
        {

            driver.Quit();

        }
    }
}

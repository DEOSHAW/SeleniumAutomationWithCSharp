using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SeleniumAutomationWithCSharp
{
    internal class WindowHandling
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
        public void testWindowHandling()
        {

            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            driver.FindElement(By.CssSelector(".blinkingText:nth-child(1)")).Click();
           String parentWindow= driver.CurrentWindowHandle;
           ReadOnlyCollection<String> allWindows= driver.WindowHandles;
            Assert.AreEqual(2,allWindows.Count);
            TestContext.Progress.WriteLine(driver.Title);

            foreach (String wd in allWindows)
            {
                if(!parentWindow.Equals(wd))
                {
                    driver.SwitchTo().Window(wd);
                    break;
                }
            }
         

           TestContext.Progress.WriteLine(driver.Title);
            IWebElement EmailElement = driver.FindElement(By.XPath("//a[contains(@href,'mailto')]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].style.border='3px solid green'", EmailElement);
            Thread.Sleep(2000);
            String Email= EmailElement.Text;
            driver.SwitchTo().Window(parentWindow);
            driver.FindElement(By.Id("username")).SendKeys(Email);
            Thread.Sleep(3000);


        }


        [TearDown]
        public void closeBrowser()
        {

            driver.Quit();

        }
    }
}

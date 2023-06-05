using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SeleniumAutomationWithCSharp.Base;

namespace SeleniumAutomationWithCSharp.Tests
{
    internal class WindowHandling:BaseClass
    {


        [Test]
        public void testWindowHandling()
        {

            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            driver.FindElement(By.CssSelector(".blinkingText:nth-child(1)")).Click();
            string parentWindow = driver.CurrentWindowHandle;
            ReadOnlyCollection<string> allWindows = driver.WindowHandles;
            Assert.AreEqual(2, allWindows.Count);
            TestContext.Progress.WriteLine(driver.Title);

            foreach (string wd in allWindows)
            {
                if (!parentWindow.Equals(wd))
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
            string Email = EmailElement.Text;
            driver.SwitchTo().Window(parentWindow);
            driver.FindElement(By.Id("username")).SendKeys(Email);
            Thread.Sleep(3000);


        }


       
    }
}

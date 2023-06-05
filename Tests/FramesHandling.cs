using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAutomationWithCSharp.Base;

namespace SeleniumAutomationWithCSharp.Tests
{
    internal class FramesHandling:BaseClass
    {


        [Test]
        public void testFrame()
        {
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Id("courses-iframe")));
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.XPath("(//a[contains(text(),'All Access plan')])[1]")).Click();
            Thread.Sleep(2000);
            string FrameText = driver.FindElement(By.CssSelector("h1")).Text;
            TestContext.Progress.WriteLine(FrameText);
            Assert.AreEqual("ALL ACCESS SUBSCRIPTION", FrameText);
            driver.SwitchTo().DefaultContent();
            string MainPageText = driver.FindElement(By.CssSelector("h1")).Text;
            TestContext.Progress.WriteLine(MainPageText);
            Assert.AreEqual("Practice Page", MainPageText);



        }

        
    }
}

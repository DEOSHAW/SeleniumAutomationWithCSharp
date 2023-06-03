﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationWithCSharp
{
     internal class AlertActionsAutoSuggestive
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.FullScreen();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        [Test]
        [Ignore("Ignore a test")]
        public void testAlert()
        {
            String name = "Deo Prasad Shaw";
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            driver.FindElement(By.XPath("//*[@name='enter-name']")).SendKeys(name);
            driver.FindElement(By.CssSelector("#confirmbtn")).Click();
            IAlert alert = driver.SwitchTo().Alert();
            Thread.Sleep(2000);
            String alertText= alert.Text;
            TestContext.Progress.WriteLine(alertText);
            alert.Accept();
            Thread.Sleep(2000);
            StringAssert.Contains(name, alertText);

            

        }

        [Test]
        [Ignore("Ignore a test")]
        public void testAutoSuggestiveDropdowns()
        {
            String name = "Deo Prasad Shaw";
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            driver.FindElement(By.XPath("//input[@placeholder='Type to Select Countries']")).SendKeys("Ind");
            Thread.Sleep(2000);
            IList<IWebElement> Options = driver.FindElements(By.CssSelector(".ui-menu-item div"));
            foreach (IWebElement element in Options)
            {
                String optionText=element.Text;
                if(optionText.Equals("India"))
                {
                    element.Click();
                    break;
                }

            }

           String Value= driver.FindElement(By.XPath("//input[@placeholder='Type to Select Countries']")).GetAttribute("value");
            Assert.AreEqual("India", Value);


        }

        [Test]
        [Ignore("Ignore a test")]
        public void testActions()
        {
            driver.Url = "https://rahulshettyacademy.com/";
            Actions actions = new Actions(driver);
            IWebElement moreMenu=driver.FindElement(By.XPath("(//a[contains(text(),'More ') and @class='dropdown-toggle'])[1]"));
            actions.MoveToElement(moreMenu).Perform();
            Thread.Sleep(2000);
            IWebElement AboutUs=driver.FindElement(By.XPath("(//ul[@class='dropdown-menu'])[1]/li/a"));
            actions.MoveToElement(AboutUs).Click().Perform();
            Thread.Sleep(4000);
        }

        [Test]
        public void testDragAndDrop()
        {
            driver.Url = "https://demoqa.com/droppable";
            Actions actions = new Actions(driver);
            actions.DragAndDrop(driver.FindElement(By.CssSelector("#draggable")), driver.FindElement(By.CssSelector("#droppable"))).Perform();
            Thread.Sleep(4000);
        }

        [TearDown]
        public void closeBrowser()
        {

            driver.Quit();

        }


    }
}

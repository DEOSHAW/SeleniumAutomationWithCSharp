using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomationWithCSharp.Base;

namespace SeleniumAutomationWithCSharp.Tests
{
    internal class FunctionalTest:BaseClass
    {


      

        [Test,Category("Regression")]
        public void handleDropDown()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

            //IWebElement professionDropdown= driver.FindElement(By.CssSelector("select.form-control"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement professionDropdown = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("select.form-control")));

            SelectElement profDropDown = new SelectElement(professionDropdown);


            profDropDown.SelectByValue("consult");

            IList<IWebElement> radioList = driver.FindElements(By.XPath("//input[@type='radio']"));
            //System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> radioList = driver.FindElements(By.XPath("//input[@type='radio']"));

            for (int i = 0; i < radioList.Count; i++)
            {
                IWebElement radio = radioList[i];
                if (radio.GetAttribute("value").Equals("user"))
                {
                    radio.Click();
                    break;
                }
            }

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#okayBtn")));

            driver.FindElement(By.CssSelector("#okayBtn")).Click();
            bool result = driver.FindElement(By.Id("usertype")).Selected;
            TestContext.Progress.WriteLine(result);
            //Assert.That(result, Is.True);


            Thread.Sleep(2000);



        }


       


    }
}

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationWithCSharp
{
    internal class E2ETest
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
        public void handleDropDown()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            String[] Products = { "iphone X", "Blackberry" };

            driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("learning");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement professionDropdown = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("select.form-control")));
            SelectElement profDropDown = new SelectElement(professionDropdown);
             profDropDown.SelectByValue("consult");

            driver.FindElement(By.CssSelector(".text-info span:nth-child(1) input")).Click();
            IWebElement SignIn = driver.FindElement(By.Id("signInBtn"));
            SignIn.Click();
            Thread.Sleep(3000);
            TestContext.Progress.WriteLine("Login Successful");

           IWebElement checkoutElement= wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText
               ("Checkout")));

            IList<IWebElement> allProducts=driver.FindElements(By.XPath("//app-card"));

            foreach(IWebElement ele in allProducts)
            {

                String productText=ele.FindElement(By.CssSelector(".card-title")).Text;

                TestContext.Progress.WriteLine(productText);

                if(Products.Contains(productText))
                {
                    ele.FindElement(By.TagName("button")).Click();

                }
                /* for(int i=0;i< Products.Length;i++)
                {
                    if (productText.Equals(Products[i]))
                    {
                        ele.FindElement(By.TagName("button")).Click();

                    }
                }*/
            }

            checkoutElement.Click();

            Thread.Sleep(4000);
            
            

          


          

           

            


            Thread.Sleep(2000);



        }


        [TearDown]
        public void closeBrowser()
        {

            driver.Quit();

        }
    }
}

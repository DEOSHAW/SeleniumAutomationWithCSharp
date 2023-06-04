using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace SeleniumAutomationWithCSharp
{
    internal class E2ETest
    {

        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {

            ChromeOptions options=new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            //driver.Manage().Window.FullScreen();
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

           IList<IWebElement> productsInCart= driver.FindElements(By.CssSelector("h4.media-heading a"));
            foreach(IWebElement ele in productsInCart)
            {
                Products.Contains(ele.Text);
            }

            driver.FindElement(By.CssSelector(".btn.btn-success")).Click();
            driver.FindElement(By.CssSelector("#country")).SendKeys("India");
           IWebElement Country= wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='India']")));
            Country.Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", driver.FindElement(By.CssSelector("#checkbox2")));
            driver.FindElement(By.XPath("//input[@value='Purchase']")).Click();
            Thread.Sleep(2000);
            String successMessage=driver.FindElement(By.CssSelector(".alert.alert-success")).Text;
            Thread.Sleep(2000);
            Assert.AreEqual("Thank you! Your order will be delivered in next few weeks :-)", successMessage);
            
            

          


          

           

            


            Thread.Sleep(2000);



        }


        [TearDown]
        public void closeBrowser()
        {

            driver.Quit();

        }
    }
}

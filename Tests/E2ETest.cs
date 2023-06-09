﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using SeleniumAutomationWithCSharp.Base;
using SeleniumAutomationWithCSharp.PageObjects;
using SeleniumAutomationWithCSharp.Utilities;

namespace SeleniumAutomationWithCSharp.Tests
{
   // [Parallelizable(ParallelScope.Self)]  (To run test multiple files in parallel, mention the same command in all the files)
    //[Parallelizable(ParallelScope.Children)]  (To run all tests in a class in parallel)
    internal class E2ETest : BaseClass
    {


        //[Test, TestCaseSource("AddTestDataConfig")]
        //[Parallelizable(ParallelScope.All)] (This will work only for parameterized test method, so above statement is compulsory)
        //[TestCaseSource("AddTestDataConfig")]
        //[TestCase("rahulshettyacademy", "learning")]
        //[TestCase("rahulshettyacademy", "learning1")]
        // public void endToEndTestForProductPurchase(String userName,String password)
        [Test,Category("Smoke")]
        public void endToEndTestForProductPurchase()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            //string[] Products = { "iphone X", "Blackberry" };
            string[] Products= getDataParser().ExtractDataArray("products");

            LoginPage loginPage = new LoginPage(getDriver());
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            /*loginPage.getUserName().SendKeys("rahulshettyacademy");
            loginPage.getPassword().SendKeys("learning");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement professionDropdown = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("select.form-control")));
            SelectElement profDropDown = new SelectElement(professionDropdown);
            profDropDown.SelectByValue("consult");

            loginPage.getCheckBox().Click();
            IWebElement SignIn = loginPage.getSignInButton();
            SignIn.Click();
            Thread.Sleep(3000);*/

            String userName=getDataParser().ExtractData("username");
            String password = getDataParser().ExtractData("password");
            ProductsPage products=loginPage.login(userName, password);
            TestContext.Progress.WriteLine("Login Successful");

            /*IWebElement checkoutElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText
                ("Checkout")));

            IList<IWebElement> allProducts = driver.FindElements(By.XPath("//app-card"));*/
            products.waitForProductsPage();
            IList<IWebElement> allProducts=products.getCards();

            foreach (IWebElement ele in allProducts)
            {

                string productText = ele.FindElement(products.getCardTitle()).Text;

                TestContext.Progress.WriteLine(productText);

                if (Products.Contains(productText))
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

            products.getCheckoutButton().Click();

            IList<IWebElement> productsInCart = products.getCartProducts();
            foreach (IWebElement ele in productsInCart)
            {
                Products.Contains(ele.Text);
            }

            products.getSuccessButton().Click();
            products.getCountryTextBox().SendKeys("India");
            IWebElement Country = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(products.getCountryLink()));
            Country.Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", products.getCheckBox2Button());
            products.getPurchaseButton().Click();
            Thread.Sleep(2000);
            IWebElement successMessageElement=wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(products.getsuccessMessageElement()));
            string successMessage = successMessageElement.Text;
            Thread.Sleep(4000);

            StringAssert.Contains("Thank you! Your order will be delivered", successMessage);
            //Assert.AreEqual("Thank you! Your order will be delivered in next few weeks :-)", successMessage);
            Thread.Sleep(2000);
            



        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {

            yield return new TestCaseData("rahulshettyacademy", "learning");
            yield return new TestCaseData("rahulshettyacademy", "learning");
            yield return new TestCaseData("rahulshettyacademy", "learning");

        }



    }
}

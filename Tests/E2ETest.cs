using OpenQA.Selenium.Chrome;
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

namespace SeleniumAutomationWithCSharp.Tests
{
    internal class E2ETest : BaseClass
    {


        [Test]
        public void endToEndTestForProductPurchase()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            string[] Products = { "iphone X", "Blackberry" };

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
            ProductsPage products=loginPage.login("rahulshettyacademy", "learning");
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



    }
}

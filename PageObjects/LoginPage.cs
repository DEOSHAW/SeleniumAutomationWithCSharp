using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationWithCSharp.PageObjects
{
    public class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }



        [FindsBy(How = How.XPath, Using = "//input[@name='username']")]
        private IWebElement userName;
        [FindsBy(How=How.XPath,Using = "//input[@name='password']")]
        private IWebElement password;
        [FindsBy(How = How.CssSelector, Using = ".text-info span:nth-child(1) input")]
        private IWebElement checkBox;
        [FindsBy(How = How.Id, Using = "signInBtn")]
        private IWebElement signInButton;



        public IWebElement getUserName()
        {
            return userName;
            

        }

        public IWebElement getPassword()
        {
            return password;


        }

        public IWebElement getSignInButton()
        {
            return signInButton;


        }

        public IWebElement getCheckBox()
        {
            return checkBox;


        }

        public ProductsPage login(String user,String pwd)
        {
            userName.SendKeys(user);
            password.SendKeys(pwd);
            checkBox.Click();
            signInButton.Click();
            return new ProductsPage(driver);
        }

    }
}

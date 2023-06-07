using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace SeleniumAutomationWithCSharp.PageObjects
{
    public class ProductsPage
    {
        IWebDriver driver;

        //IWebElement checkoutElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText
               // ("Checkout")));

        //IList<IWebElement> allProducts = driver.FindElements(By.XPath("//app-card"));

       public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//app-card")]
        IList<IWebElement> allProducts;

        [FindsBy(How = How.CssSelector, Using = "h4.media-heading a")]
        IList<IWebElement> productsInCart;
        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        IWebElement checkoutButton;

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-success")]
        IWebElement successButton;

        [FindsBy(How = How.CssSelector, Using = "#country")]
        IWebElement countryTextBox;

        [FindsBy(How = How.CssSelector, Using = "#checkbox2")]
        IWebElement checkBox2Button;
        [FindsBy(How = How.XPath, Using = "//input[@value='Purchase']")]
        IWebElement purchaseButton;

        By cardTitle=By.CssSelector(".card-title");

        By countryLink = By.XPath("//a[text()='India']");

        By successMessageElement = By.CssSelector(".alert.alert-success");

        public void waitForProductsPage()
        {
            WebDriverWait wait=new WebDriverWait(driver,TimeSpan.FromSeconds(5));

            IWebElement checkoutElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText
                ("Checkout")));

        }

        public IList<IWebElement> getCards()
        {
            return allProducts;
        }

        public IList<IWebElement> getCartProducts()
        {
            return productsInCart;
        }

        public IWebElement getCheckoutButton()
        {
            return checkoutButton;
        }

        public IWebElement getCountryTextBox()
        {
            return countryTextBox;
        }

        public IWebElement getSuccessButton()
        {
            return successButton;
        }

        public IWebElement getCheckBox2Button()
        {
            return checkBox2Button;
        }

        public By getsuccessMessageElement()
        {
            return successMessageElement;
        }

        public By getCardTitle()
        {

            return cardTitle;

        }

        public By getCountryLink()
        {

            return countryLink;

        }

        public IWebElement getPurchaseButton()
        {

            return purchaseButton;

        }



    }
}

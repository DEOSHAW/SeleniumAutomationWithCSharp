using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationWithCSharp.PageObjects
{
    internal class RSPractice2
    {
        IWebDriver driver;


        public RSPractice2(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        
        }
        [FindsBy(How = How.XPath, Using = "//input[@id='name']")]
        IWebElement nameTextBox;

        [FindsBy(How = How.XPath, Using = "//input[@id='displayed-text']")]
        IWebElement displayedTextBox;

        internal void copyPasteText()
        {

            nameTextBox.SendKeys("Deo Shaw");
            Actions actions = new Actions(driver);
            actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            actions.KeyDown(Keys.Control).SendKeys("c").KeyUp(Keys.Control).Perform();
            displayedTextBox.Click();
            actions.KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control).Perform();

            Thread.Sleep(1000);


        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationWithCSharp.PageObjects
{
    internal class NextGen
    {
        IWebDriver driver;

        internal NextGen(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        
        
        }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'New Browser Tab')]")]
        IWebElement newBrowserTab;

        [FindsBy(How = How.XPath, Using = "(//a[contains(text(),'Course Offered')])[2]/parent::li/ul/li/a")]
        IList<IWebElement> allCourses;


        internal void clickOnNewBrowserTab()
        {
            newBrowserTab.Click();
        }


        internal void getListOfCourses()
        {
            WebDriverWait wait=new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            IWebElement coursesMenu=wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//a[contains(text(),'Course Offered')])[2]")));
            Actions actions=new Actions(driver);
            actions.MoveToElement(coursesMenu).Perform();
            StringBuilder sb=new StringBuilder();
            foreach(IWebElement element in allCourses)
            {
                sb.Append(element.Text);
                sb.Append("\n");
            }
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("alert(arguments[0])",sb.ToString());
            Thread.Sleep(3000);
            IAlert alert=driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(1000);


           


        }
    }
}

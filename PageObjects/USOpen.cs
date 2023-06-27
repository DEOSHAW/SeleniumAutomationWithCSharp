using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace SeleniumAutomationWithCSharp.PageObjects
{
    internal class USOpen
    {
        IWebDriver driver;


        public USOpen(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);


        }

        By championImage = By.XPath("//img[contains(@alt,'LA Confidential')]");


        internal void takeChampionImage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement championPic=wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(championImage));
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot ss= ts.GetScreenshot();
            //TestContext.Progress.WriteLine(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar);
            ss.SaveAsFile("C:\\Selenium Projects\\SeleniumAutomationWithCSharp" + Path.DirectorySeparatorChar + "Champion.png");

        }
    }
}

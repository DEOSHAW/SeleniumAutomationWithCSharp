using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using SeleniumAutomationWithCSharp.Utilities;

namespace SeleniumAutomationWithCSharp.Base
{
    public class BaseClass
    {

        public IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {;
            String BrowserName=ConfigurationManager.AppSettings["browser"];
            TestContext.Progress.WriteLine("Browser Name is: "+BrowserName);

            /* ChromeOptions options = new ChromeOptions();
             options.AddArgument("--start-maximized");
             driver = new ChromeDriver(options);
             //driver.Manage().Window.FullScreen();*/
            InitBrowser(BrowserName);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public JsonReader getDataParser()
        {
            return new JsonReader();
        }

        public void InitBrowser(String BrowserName)
        {
            switch (BrowserName)
            {
                case "Firefox": driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    driver = new ChromeDriver(options);
                    break;

                case "Edge": driver = new EdgeDriver();
                    break;
            }
        }

        [TearDown]
        public void closeBrowser()
        {

            driver.Quit();

        }


    }
}

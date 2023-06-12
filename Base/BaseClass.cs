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
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.DevTools.V111.Page;

namespace SeleniumAutomationWithCSharp.Base
{
    public class BaseClass
    {

        public IWebDriver driver;
        ExtentReports extent;
        ExtentTest test;
         String BrowserName;

        //Report file
        [OneTimeSetUp] 
        public void Setup()
        {

            String WorkingDirectory = Environment.CurrentDirectory;
            String parentDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String reportPath = parentDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host","Local Host");
        
        }
        //ThreadLocal<IWebDriver> driver=new ThreadLocal<IWebDriver>();

        [SetUp]
        public void startBrowser()
        {

           test= extent.CreateTest(TestContext.CurrentContext.Test.Name);
            BrowserName = ConfigurationManager.AppSettings["browser"];

            
           
            TestContext.Progress.WriteLine("Browser Name is: "+BrowserName);

            /* ChromeOptions options = new ChromeOptions();
             options.AddArgument("--start-maximized");
             driver = new ChromeDriver(options);
             //driver.Manage().Window.FullScreen();*/
            InitBrowser(BrowserName);
           // driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
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
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime time=DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            if(status==TestStatus.Failed)
            {
                test.Fail("Test Failed",CaptureScreenshot(driver,fileName));
                test.Log(Status.Fail, stackTrace);

            }
            else if(status == TestStatus.Passed)
            {
                test.Pass("Test Passed");

            }
            extent.Flush();

            driver.Quit();

        }

        public MediaEntityModelProvider CaptureScreenshot(IWebDriver driver,String screenshotName)
        {

            ITakesScreenshot ts = (ITakesScreenshot)driver;
           String screenshot= ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();
            //return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();



        }

      


    }
}

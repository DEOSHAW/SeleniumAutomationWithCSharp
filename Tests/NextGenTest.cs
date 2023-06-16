using SeleniumAutomationWithCSharp.Base;
using SeleniumAutomationWithCSharp.PageObjects;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationWithCSharp.Tests
{
    internal class NextGenTest:BaseClass
    {

        [Test]
        public void windowSwitching()
        {

            driver.Url = "https://nxtgenaiacademy.com/multiplewindows/";
            String parentWindow = driver.CurrentWindowHandle;
            TestContext.Progress.WriteLine("Page title is: " + driver.Title);
            NextGen ng=new NextGen(driver);
            ng.clickOnNewBrowserTab();
            //List<String> allWindows= driver.WindowHandles.ToList();
            IList<String> allWindows= driver.WindowHandles;
            int count = 0;
            foreach (String window in allWindows)
            { 
                count++;
                if(!window.Equals(parentWindow))
                {
                    TestContext.Progress.WriteLine("*****"+count+"*****");
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
            TestContext.Progress.WriteLine("Page title is: " + driver.Title);
            ng.getListOfCourses();




        }
    }
}

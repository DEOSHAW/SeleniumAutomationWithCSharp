using SeleniumAutomationWithCSharp.Base;
using SeleniumAutomationWithCSharp.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationWithCSharp.Tests
{
    internal class RSPractice2Test:BaseClass
    {

        [Test]
        public void testKeyboardActions()
        {

            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            RSPractice2 ob = new RSPractice2(driver);
            ob.copyPasteText();


        }
    }
}

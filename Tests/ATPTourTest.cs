using System;
using SeleniumAutomationWithCSharp.Base;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAutomationWithCSharp.PageObjects;

namespace SeleniumAutomationWithCSharp.Tests
{
    internal class ATPTourTest: BaseClass
    {

        [Test]
        public void getATPTop10InRankings()
        {
            driver.Url = "https://www.atptour.com/en/rankings/singles";
            ATPTour ob=new ATPTour(driver);
            ob.displayTop10InATPRankings();

        }
    }
}

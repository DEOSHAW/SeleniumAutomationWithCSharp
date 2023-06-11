using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SeleniumAutomationWithCSharp.Base;

namespace SeleniumAutomationWithCSharp.Tests
{
    internal class SortWebTable:BaseClass
    {

      

        [Test,Category("Regression")]
        public void sortWebTable()
        {
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            IWebElement pageElement = driver.FindElement(By.XPath("//select[@id='page-menu']"));
            SelectElement pageDropDown = new SelectElement(pageElement);
            pageDropDown.SelectByText("20");

            IList<IWebElement> vegList = driver.FindElements(By.XPath("//table//tbody//tr//td[1]"));
            ArrayList vegetableList = new ArrayList();
            foreach (IWebElement veg in vegList)
            {
                vegetableList.Add(veg.Text);

            }
            vegetableList.Sort();

            TestContext.Progress.WriteLine("Before Sorting");

            foreach (string veg in vegetableList)
            {
                TestContext.Progress.WriteLine(veg);
            }

            driver.FindElement(By.CssSelector("span.sort-icon.sort-descending")).Click();

            IList<IWebElement> sortedVegList = driver.FindElements(By.XPath("//table//tbody//tr//td[1]"));
            ArrayList sortedVegetableList = new ArrayList();

            foreach (IWebElement veg in sortedVegList)
            {
                sortedVegetableList.Add(veg.Text);
            }

            TestContext.Progress.WriteLine("After Sorting");

            foreach (string veg in sortedVegetableList)
            {
                TestContext.Progress.WriteLine(veg);
            }


            Assert.AreEqual(sortedVegetableList, vegetableList);
            bool Sorted = true;

            for (int i = 0; i < vegetableList.Count; i++)
            {
                string Veg1 = (string)vegetableList[i];
                string Veg2 = (string)vegetableList[i];
                if (!Veg1.Equals(Veg2))
                {
                    Sorted = false;
                }
            }
            if (Sorted)
            {
                TestContext.Progress.WriteLine("Sorted");
            }
            else
            {
                TestContext.Progress.WriteLine("Not Sorted");

            }










        }


        

    }
}

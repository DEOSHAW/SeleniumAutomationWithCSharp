using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationWithCSharp.PageObjects
{
    internal class ATPTour
    {
        IWebDriver driver;


        internal protected ATPTour(IWebDriver driver) 
        { 
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        /*[FindsBy(How = How.XPath, Using = "//table[@id='player-rank-detail-ajax']//tr")]
        IList<IWebElement> totalPlayers;*/

        By rankingsPageElement = By.XPath("//*[contains(text(),'ATP Rankings, the')]");

        internal void displayTop10InATPRankings()
        {

            WebDriverWait wait=new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(rankingsPageElement));
            ReadOnlyCollection<IWebElement> allPlayers= driver.FindElements(By.XPath("//table[@id='player-rank-detail-ajax']//tr"));
            TestContext.Progress.WriteLine("Total players: "+ allPlayers.Count());
            
            StringBuilder top10Players=new StringBuilder();
            for(int i = 1; i <=10; i++)
            {
                String playerName=driver.FindElement(By.XPath("//table[@id='player-rank-detail-ajax']//tr[" + i + "]//td[4]//a")).Text;
                top10Players.Append(playerName);
                top10Players.Append("\n");

            }
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("alert(arguments[0])",top10Players.ToString());
            Thread.Sleep(3000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);
           
           

        }
    }
}

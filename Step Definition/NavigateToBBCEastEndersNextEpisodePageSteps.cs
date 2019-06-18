using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace ZoneInterviewTask_PeterOlofinmoyin.Step_Definition
{
    [Binding]
    public class NavigateToBBCEastEndersNextEpisodePageSteps
    {
        IWebDriver driver;
        private readonly BrowserContext _browserContext;

        public NavigateToBBCEastEndersNextEpisodePageSteps(BrowserContext browserContext)
        {
            _browserContext = browserContext;
        }//end constructor


        [Given(@"I'm on the ""(.*)"" homepage")]
        public void GivenIMOnTheHomepage(string homepageUrl)
        {
            _browserContext.WebDriver.Navigate().GoToUrl(homepageUrl);
        }
        
        [When(@"I search for EastEnders Episode Next on schedule:")]
        public void WhenISearchForEastEndersEpisodeNextOnSchedule(Table table)
        {
            var Criteria = table.Rows[0][0];
            _browserContext.WebDriver.FindElement(By.XPath("//*[@id='orb-search-q']")).SendKeys(Criteria);
            Thread.Sleep(3000);
            _browserContext.WebDriver.FindElement(By.XPath("//*[@id='suggestion-0']/em")).Click();
            _browserContext.WebDriver.FindElement(By.XPath("//*[@id='search-content']/ol/li[1]/article/a[2]")).Click();
            Thread.Sleep(3000);
            _browserContext.WebDriver.FindElement(By.XPath("//*[@id='br-nav-programme']/ul[1]/li[2]/a")).Click();
            Thread.Sleep(3000);
            _browserContext.WebDriver.FindElement(By.XPath("//*[@id='orb-modules']/div/div/div[2]/div[3]/ul/li[4]/a/span[1]")).Click();

        }

        [When(@"I request to navigate to ""(.*)""")]
        public void WhenIRequestToNavigateTo(string EpisodesPage)
        {
            _browserContext.WebDriver.Navigate().GoToUrl(EpisodesPage);
        }
        
        [Then(@"I am redirected to the Next Episodes screen")]
        public void ThenIAmRedirectedToTheNextEpisodesScreen()
        {
            _browserContext.WebDriver.FindElement(By.XPath("//*[@id='orb-modules']/div/div/div[2]/div[2]/h1")).Equals("Episodes");
        }
    }
}

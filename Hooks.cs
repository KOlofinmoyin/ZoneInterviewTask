using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ZoneInterviewTask_PeterOlofinmoyin
{
    
    [Binding]
    public sealed class Hooks
    {
        private readonly BrowserContext _browserContext;
        private IWebDriver _driver;

        public Hooks(BrowserContext browserContext)
        {
            _browserContext = browserContext;
        }

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            _browserContext.WebDriver.Quit();
        }
    }
}


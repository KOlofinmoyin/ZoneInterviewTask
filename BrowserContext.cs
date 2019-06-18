using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace ZoneInterviewTask_PeterOlofinmoyin
{
    public class BrowserContext
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _webDriver;
        private static IConfiguration _config => Configuration.GetConfigurationRoot();
        private readonly string _fileSuffix = $"_{DateTime.UtcNow.Year}{DateTime.UtcNow.Month}{DateTime.UtcNow.Day}_{DateTime.UtcNow.Hour}{DateTime.UtcNow.Minute}{DateTime.UtcNow.Second}";
        public BrowserContext(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        public IWebDriver WebDriver
        {
            get
            {
                if (_webDriver == null)
                {
                    _webDriver = CreateWebDriver();
                }
                return _webDriver;
            }
            private set { _webDriver = value; }
        }


        internal IWebDriver CreateWebDriver()
        {
            var browser = _config["Browser"] ?? "chrome";
            IWebDriver driver;

            switch (browser.ToLowerInvariant())
            {
                case "chrome":
                    var options = new ChromeOptions();
                    options.AddArgument("disable-save-password-bubble");
                    options.AddUserProfilePreference("credentials-enable-service", false);
                    options.AddArgument("start-maximised");
                    options.AddArgument("lang-en-GB");
                    //driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    driver = new ChromeDriver(Directory.GetCurrentDirectory(), options);
                    break;
                case "firefox":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;

                case "remote":
                    var Options = new ChromeOptions();
                    Options.PlatformName = "windows";
                    Options.AddAdditionalCapability("platform", "WIN10", true); // Supported values: "VISTA" (Windows 7), "WIN8" (Windows 8), "WIN8_1" (windows 8.1), "WIN10" (Windows 10), "LINUX" 
                                                                                /* Options.AddAdditionalCapability("version", "latest", true); // for Chrome only version=latest can be used*/
                    driver = new RemoteWebDriver(
                      new Uri("http://172.20.10.3:4444/wd/hub"), Options.ToCapabilities(), TimeSpan.FromSeconds(600));
                    return driver;

                default:
                    throw new ConfigurationErrorsException($"Unsupported {browser}");
            }
            return driver;
        }



        public static void KillDriverProcesses()
        {
            foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                process.Kill();
            }
            foreach (var process in Process.GetProcessesByName("gekodriver"))
            {
                process.Kill();
            }
        }
    }
}

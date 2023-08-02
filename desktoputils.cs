// Represents a collection of desktop utilities and my driver setup.

using QuasarAutomation.DesktopConfig;
using NUnit.Framework;
using NLog;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QuasarAutomation.DesktopUtils
{
    
    public static class MyDesktopUtils
    {
        public static readonly ILogger logger;
        private static IWebDriver driver;

        static MyDesktopUtils()
        {
            
            LogManager.Setup().LoadConfigurationFromFile("C:\\Coding\\Automation Learning\\QuasarAutomation\\nlog.config");

            
            logger = LogManager.GetCurrentClassLogger();
        }

        
        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    throw new Exception("WebDriver has not been set up.");
                }
                return driver;
            }
        }

        public static void NavigateToURL(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        // Sets up the WebDriver instance based on the test configuration.
        public static IWebDriver SetupDriver(TestContext testContext)
        {
            
            TestContext = testContext;

           
            var configPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "testconfig.json");
            var json = File.ReadAllText(configPath);
            var config = JsonConvert.DeserializeObject<Dictionary<string, MyTestConfig>>(json);
            var testConfig = config["Desktop"];

            var options = new ChromeOptions();
            options.AddArgument("--incognito");
            options.AddArgument("--start-maximized");

            
            driver = new ChromeDriver(testConfig.DriverPath, options);

           
            NavigateToURL(testConfig.Url);

            return driver;
        }


        
        public static TestContext TestContext { get; set; }

        
        public static void LogError(Exception ex, string message)
        {
            logger.Error(ex, message);
        }

       
        public static void QuitDriver()
        {
            driver?.Quit();
        }
    }
}

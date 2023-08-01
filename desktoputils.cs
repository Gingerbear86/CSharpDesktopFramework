// Represents a collection of desktop utilities and my driver setup.

using QuasarAutomation.DesktopConfig;
using NUnit.Framework;
using NLog;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QuasarAutomation.DesktopUtils
{
    // Provides utility methods for desktop automation.
    public static class MyDesktopUtils
    {
        public static readonly ILogger logger;
        private static IWebDriver driver;

        static MyDesktopUtils()
        {
            // Initialize NLog configuration
            LogManager.Setup().LoadConfigurationFromFile("C:\\Coding\\Automation Learning\\QuasarAutomation\\nlog.config");

            // Get the logger instance
            logger = LogManager.GetCurrentClassLogger();
        }

        // Gets the WebDriver instance.
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
            // Assign the test context to a static field for later use
            TestContext = testContext;

            // Read the test configuration from the JSON file.
            var configPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "testconfig.json");
            var json = File.ReadAllText(configPath);
            var config = JsonConvert.DeserializeObject<Dictionary<string, MyTestConfig>>(json);
            var testConfig = config["Desktop"];

            var options = new ChromeOptions();
            options.AddArgument("--incognito");
            options.AddArgument("--start-maximized");

            // Create the WebDriver instance.
            driver = new ChromeDriver(testConfig.DriverPath, options);

            // Navigate to Q.dev
            NavigateToURL(testConfig.Url);

            return driver;
        }


        // Public property to provide context
        public static TestContext TestContext { get; set; }

        // Public method to log errors
        public static void LogError(Exception ex, string message)
        {
            logger.Error(ex, message);
        }

        // Quits the WebDriver and performs the necessary cleanup.
        public static void QuitDriver()
        {
            driver?.Quit();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QuasarAutomation.Pages
{
    public class HomePage
    {
        private IWebDriver Driver { get; }
        private WebDriverWait Wait { get; }

       
        private By AcceptButton => By.XPath("//span[@class='block' and text()='Accept']");
        private By DocsLink => By.XPath("//span[@class='block' and text()='Docs']");

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

       
        public void ClickAcceptButtonWithJS()
        {
            var acceptButton = Wait.Until(driver =>
            {
                var element = driver.FindElement(AcceptButton);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", acceptButton);
        }

        public DocsPage NavigateToDocsPage()
        {
            var docsLink = Wait.Until(driver =>
            {
                var element = driver.FindElement(DocsLink);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
            docsLink.Click();
            return new DocsPage(Driver);
        }
    }
}

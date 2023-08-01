using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QuasarAutomation.Pages
{
    public class DocsPage
    {
        private IWebDriver Driver { get; }
        private WebDriverWait Wait { get; }

        // Selectors
        private By VueComponents => By.XPath("//div[@class='q-item__label' and text()='Vue Components']");
        private By Table => By.XPath("//div[@class='q-item__section column q-item__section--main justify-center' and text()='Table']");

        public DocsPage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        // Methods
        public void ClickVueComponents()
        {
            var vueComponents = Wait.Until(driver =>
            {
                var element = driver.FindElement(VueComponents);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
            vueComponents.Click();
        }

        public TablePage NavigateToTablePage()
        {
            var tableLink = Wait.Until(driver =>
            {
                var element = driver.FindElement(Table);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
            tableLink.Click();
            return new TablePage(Driver);
        }
    }
}
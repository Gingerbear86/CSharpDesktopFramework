// Represents a collection of desktop resources such as URLs and selectors.

namespace QuasarAutomation.DesktopResources
{
    public static class MyDesktopResources
    {
        // URL of the website to automate.
        public static readonly string WebsiteUrl = "https://quasar.dev/";

        // Selector for the accept button.
        public static readonly string AcceptButton = "//span[@class='block' and text()='Accept']";

        // Selector for the documentation link.
        public static readonly string DocsLink = "//span[@class='block' and text()='Docs']";

        // Selector for the Vue components.
        public static readonly string VueComponents = "/html/body/div[1]/div/div[1]/main/div[1]/div[1]/div/div[1]/div/div/div[5]/div/div[1]/div[3]/div";

        // Selector for the table.
        public static readonly string Table = "//div[@class='q-item__section column q-item__section--main justify-center' and text()='Table']";

        // Selector for the basic usage.
        public static readonly string BasicUsage = "//div[@class='q-item__section column q-item__section--main justify-center' and text()='7. Basic usage']";

        // Selector for the records dropdown.
        public static readonly string RecordsDropdown = "//div[@class='q-field__native row items-center' and span[text()='5']]";

        // Selector for the dropdown option 10.
        public static readonly string DropdownOption10 = "//div[@class='q-item__label' and span[text()='10']]";

        // Selector for the table element.
        public static readonly string TableSelector = ".q-table";
    }
}


// Represents a collection of desktop resources such as URLs and selectors.

namespace QuasarAutomation.DesktopResources
{
    public static class MyDesktopResources
    {
       
        public static readonly string WebsiteUrl = "https://quasar.dev/";

       
        public static readonly string AcceptButton = "//span[@class='block' and text()='Accept']";

        
        public static readonly string DocsLink = "//span[@class='block' and text()='Docs']";

        
        public static readonly string VueComponents = "/html/body/div[1]/div/div[1]/main/div[1]/div[1]/div/div[1]/div/div/div[5]/div/div[1]/div[3]/div";

        
        public static readonly string Table = "//div[@class='q-item__section column q-item__section--main justify-center' and text()='Table']";

        
        public static readonly string BasicUsage = "//div[@class='q-item__section column q-item__section--main justify-center' and text()='7. Basic usage']";

        
        public static readonly string RecordsDropdown = "//div[@class='q-field__native row items-center' and span[text()='5']]";

        
        public static readonly string DropdownOption10 = "//div[@class='q-item__label' and span[text()='10']]";

        
        public static readonly string TableSelector = ".q-table";
    }
}


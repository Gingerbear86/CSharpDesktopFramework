using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Data;
using OfficeOpenXml;

namespace QuasarAutomation.Pages
{
    public class TablePage
    {
        private IWebDriver Driver { get; }
        private WebDriverWait Wait { get; }

        
        private By BasicUsage => By.XPath("//div[@class='q-item__section column q-item__section--main justify-center' and text()='7. Basic usage']");
        private By RecordsDropdown => By.XPath("//label[contains(@class,'q-table__select')]//span[text()='5']");
        private By DropdownOption10 => By.XPath("//div[@class='q-item__label' and span[text()='10']]");
        private By TableSelector => By.CssSelector(".q-table");

        public TablePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        public void ClickBasicUsage()
        {
            var basicUsage = Wait.Until(driver =>
            {
                var element = driver.FindElement(BasicUsage);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
            basicUsage.Click();
        }

        public void ClickRecordsDropdown()
        {
            var recordsDropdown = Wait.Until(driver =>
                {
                    var element = driver.FindElement(RecordsDropdown);
                    return (element != null && element.Displayed && element.Enabled) ? element : null;
                });
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", recordsDropdown);
        }

        public void ClickDropdownOption10()
        {
            var dropdownOption10 = Wait.Until(driver =>
            {
                var element = driver.FindElement(DropdownOption10);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
            dropdownOption10.Click();
        }

        public void ClickTableSelector()
        {
            var tableSelector = Wait.Until(driver =>
            {
                var element = driver.FindElement(TableSelector);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
            tableSelector.Click();
        }

        public DataTable ScrapeTable()
        {
            var dataTable = new DataTable();
            var table = Driver.FindElement(TableSelector);
            var rows = table.FindElements(By.TagName("tr"));

            if (rows.Count() > 0)
            {
                // Adding column headers
                var headers = rows[0].FindElements(By.TagName("th"));
                foreach (var header in headers)
                {
                    dataTable.Columns.Add(header.Text);
                }

                // Adding row data
                for (int i = 1; i < rows.Count(); i++)
                {
                    var cells = rows[i].FindElements(By.TagName("td"));
                    dataTable.Rows.Add(cells.Select(c => c.Text).ToArray());
                }
            }

            return dataTable;
        }

        public void WriteTableToExcel(DataTable table, string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells["A1"].LoadFromDataTable(table, true);
                package.SaveAs(new FileInfo(filePath));
            }
        }
    }
}

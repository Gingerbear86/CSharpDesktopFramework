// Represents a collection of test cases for testing Quasar.

using QuasarAutomation.DesktopUtils;
using QuasarAutomation.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

[TestFixture]
public class Tests
{
    private TestContext testContext;

    [SetUp]
    public void Setup()
    {
        testContext = TestContext.CurrentContext;
        MyDesktopUtils.SetupDriver(testContext);
    }

    [TearDown]
    public void TearDown()
    {
        var testName = testContext?.Test.FullName;
        var testOutcome = testContext?.Result.Outcome.Status;

        MyDesktopUtils.logger.Info($"Test {testName} - Outcome: {testOutcome}");

        MyDesktopUtils.QuitDriver();
    }

    [Test, Order(1)]
    public void TestHomePage()
    {
        try
        {
            // Navigate to Quasar Homepage
            var homePage = new HomePage(MyDesktopUtils.Driver);
            homePage.ClickAcceptButtonWithJS();

            // Navigate to Docs Page
            var docsPage = homePage.NavigateToDocsPage();
        }
        catch (Exception ex)
        {
            // Log the error before failing the test
            MyDesktopUtils.LogError(ex, "Error occurred while running the test");
            throw;
        }
    }

    [Test, Order(2)]
    public void TestDocsPage()
    {
        try
        {
            // Navigate to Quasar Homepage
            var homePage = new HomePage(MyDesktopUtils.Driver);
            homePage.ClickAcceptButtonWithJS();

            // Navigate to Docs Page
            var docsPage = homePage.NavigateToDocsPage();

            // Click on the VueComponents button on the Docs page
            docsPage.ClickVueComponents();
        }
        catch (Exception ex)
        {
            // Log the error before failing the test
            MyDesktopUtils.LogError(ex, "Error occurred while running the test");
            throw;
        }
    }

    [Test, Order(3)]
    public void TestTableScraping()
    {
        try
        {
            // Navigate to Quasar Homepage
            var homePage = new HomePage(MyDesktopUtils.Driver);
            homePage.ClickAcceptButtonWithJS();

            // Navigate to Docs Page
            var docsPage = homePage.NavigateToDocsPage();

            // Click on the VueComponents button on the Docs page
            docsPage.ClickVueComponents();

            // Navigate to Table Page from the Docs page
            var tablePage = docsPage.NavigateToTablePage();

            // Interact with elements on the Table Page here
            tablePage.ClickBasicUsage();

            // 
            tablePage.ClickRecordsDropdown();

            //
            tablePage.ClickDropdownOption10();

            //
            tablePage.ClickTableSelector();

            // Scraping data from the web table
            var tableData = tablePage.ScrapeTable();

            // Writing data to an Excel file
            var excelFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "data.xlsx");
            tablePage.WriteTableToExcel(tableData, excelFilePath);
        }
        catch (Exception ex)
        {
            // Log the error before failing the test
            MyDesktopUtils.LogError(ex, "Error occurred while running the test");
            throw;
        }
    }
}

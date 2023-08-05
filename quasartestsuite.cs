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
           
            var homePage = new HomePage(MyDesktopUtils.Driver);
            homePage.ClickAcceptButtonWithJS();

            
            var docsPage = homePage.NavigateToDocsPage();
        }
        catch (Exception ex)
        {
           
            MyDesktopUtils.LogError(ex, "Error occurred while running the test");
            throw;
        }
    }

    [Test, Order(2)]
    public void TestDocsPage()
    {
        try
        {
            
            var homePage = new HomePage(MyDesktopUtils.Driver);
            homePage.ClickAcceptButtonWithJS();

            
            var docsPage = homePage.NavigateToDocsPage();

            
            docsPage.ClickVueComponents();
        }
        catch (Exception ex)
        {
            
            MyDesktopUtils.LogError(ex, "Error occurred while running the test");
            throw;
        }
    }

    [Test, Order(3)]
    public void TestTableScraping()
    {
        try
        {
            
            var homePage = new HomePage(MyDesktopUtils.Driver);
            homePage.ClickAcceptButtonWithJS();

            
            var docsPage = homePage.NavigateToDocsPage();

           
            docsPage.ClickVueComponents();

           
            var tablePage = docsPage.NavigateToTablePage();

            tablePage.ClickBasicUsage();

          
            tablePage.ClickRecordsDropdown();

           
            tablePage.ClickDropdownOption10();

           
            tablePage.ClickTableSelector();

           
            var tableData = tablePage.ScrapeTable();

            
            var excelFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "data.xlsx");
            tablePage.WriteTableToExcel(tableData, excelFilePath);
        }
        catch (Exception ex)
        {
            
            MyDesktopUtils.LogError(ex, "Error occurred while running the test");
            throw;
        }
    }
}

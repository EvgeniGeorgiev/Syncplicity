using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using static ConfigurationSettings;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;


    private static IWebDriver driver;
    private static ExtentReports extent;
    private static ExtentTest test;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        extent = ExtentManager.GetExtent();
        test = extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
    }

    [BeforeScenario]
    public static void BeforeScenario()
    {
        Config config = ConfigurationSettings.GetConfig();
        
        if (config.Browser.ToLower() == "chrome")
        {
            driver = new ChromeDriver();
        }
        else if (config.Browser.ToLower() == "firefox")
        {
            driver = new FirefoxDriver();
        }
        else
        {
            throw new Exception("Unsupported browser: " + config.Browser);
        }
    }

    [AfterScenario]
    public void AfterScenario()
    {
        driver.Quit();

        if (_scenarioContext.TestError != null)
        {
            var error = _scenarioContext.TestError;
            Console.WriteLine("An error occurred: " + error.Message);
            Console.WriteLine("It was of type: " + error.GetType().Name);
            test.Fail("Test failed: " + error.Message);
        }
        else
        {
            test.Pass("Test passed.");
        }

        extent.Flush();
    }

    public static IWebDriver GetWebDriver()
    {
        return driver;
    }
}
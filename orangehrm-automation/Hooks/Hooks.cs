using OpenQA.Selenium;
using Orangehrm_Automation.Drivers;
using Orangehrm_Automation.Support;
using Serilog;
using AventStack.ExtentReports;


namespace Orangehrm_Automation.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private static ExtentReports _extent;
        private static ExtentTest _feature;
        private ExtentTest _scenario;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            Logger.Init();

            if (_extent == null)
                _extent = ExtentManager.GetInstance();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extent.CreateTest(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Log.Information("Starting scenario: " + _scenarioContext.ScenarioInfo.Title);

            _scenario = _feature.CreateNode(_scenarioContext.ScenarioInfo.Title);

            var driver = DriverFactory.CreateDriver();
            _scenarioContext["WebDriver"] = driver;
        }

        [AfterStep]
        public void AfterStep()
        {
            if (_scenarioContext.TestError == null)
            {
                _scenario.Pass($"Step passed: {_scenarioContext.StepContext.StepInfo.Text}");
            }
            else
            {
                _scenario.Fail(_scenarioContext.TestError.Message);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var scenarioTitle = _scenarioContext.ScenarioInfo.Title;
            var driver = _scenarioContext["WebDriver"] as IWebDriver;

            if (_scenarioContext.TestError != null)
            {
                Log.Error("Scenario failed: " + scenarioTitle);

                string screenshotPath = ScreenshotHelper.TakeScreenshot(driver, scenarioTitle);

                if (screenshotPath != null)
                {
                    _scenario.AddScreenCaptureFromPath(screenshotPath);
                    Log.Information($"Screenshot saved: {screenshotPath}");
                }
            }

            Log.Information("Ending scenario: " + scenarioTitle);

            DriverFactory.QuitDriver();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extent.Flush();
        }
    }
}

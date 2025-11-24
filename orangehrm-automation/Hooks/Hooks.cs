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
            // ✔ Necesario porque BeforeFeature corre ANTES del constructor
            if (_extent == null)
                _extent = ExtentManager.GetInstance();

            _feature = _extent.CreateTest(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var scenarioName = _scenarioContext.ScenarioInfo.Title;
            Log.Information("Starting scenario: " + scenarioName);

            _scenario = _feature.CreateNode(scenarioName);

            var driver = DriverFactory.CreateDriver();
            _scenarioContext["WebDriver"] = driver;
        }

        [AfterStep]
        public void AfterStep()
        {
            string stepText = _scenarioContext.StepContext.StepInfo.Text;

            if (_scenarioContext.TestError == null)
            {
                _scenario.Pass("Step passed: " + stepText);
            }
            else
            {
                _scenario.Fail("Step failed: " + stepText);
                _scenario.Fail(_scenarioContext.TestError.Message);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var title = _scenarioContext.ScenarioInfo.Title;

            if (_scenarioContext.ContainsKey("WebDriver"))
            {
                var driver = _scenarioContext["WebDriver"] as IWebDriver;

                if (_scenarioContext.TestError != null)
                {
                    string screenshot = ScreenshotHelper.TakeScreenshot(driver, title);

                    // ✔ aseguramos que el archivo existe antes de añadirlo
                    if (File.Exists(screenshot))
                        _scenario.AddScreenCaptureFromPath(screenshot);
                }

                DriverFactory.QuitDriver();
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extent.Flush();
        }
    }
}

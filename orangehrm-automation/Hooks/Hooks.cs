using OpenQA.Selenium;
using Orangehrm_Automation.Drivers;
using Orangehrm_Automation.Support;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangehrm_Automation.Hooks
{
    [Binding]
    public class Hooks
    {
        //ScenarioContext instead of static variables
        ///Fully parallel-friendly
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            // Initialize Logger once (Serilog)
            Logger.Init(); 
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Log.Information("Starting scenario: " + _scenarioContext.ScenarioInfo.Title);
            
            var driver = DriverFactory.CreateDriver();
            _scenarioContext["WebDriver"] = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Log.Information("Ending scenario: " + _scenarioContext.ScenarioInfo.Title);

            DriverFactory.QuitDriver();
        }

    }
}

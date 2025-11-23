using OpenQA.Selenium;
using Orangehrm_Automation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangehrm_Automation.StepDefinitions
{
    [Binding]
    public class LeaveSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly LeavePage _leavePage;


        public LeaveSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            var driver = _scenarioContext["WebDriver"] as IWebDriver;

            _leavePage = new LeavePage(driver);
        }

        // Background steps
        [Given(@"I am on the Leave page")]
        public void GivenImOnTheLeavePage()
        {
            _leavePage.ClickLeaveLink();
            if (!_leavePage.IsPageLoaded())
            {
                throw new Exception("Leave page did not load correctly.");
            }
        }

        // Scenario: Assign Leave without filling mandatory fields
        [Given(@"I am on assign leave page")]
        public void GivenIAmOnAssignLeavePage()
        {
            _leavePage.ClickAssignLeaveLink();
            if (!_leavePage.IsAssignLeavePageLoaded())
            {
                throw new Exception("Assign Leave page did not load correctly.");
            }
        }

        [When(@"I attempt to assign leave without filling mandatory fields")]
        public void WhenIAttemptToAssignLeaveWithoutFillingMandatoryFields()
        {
            _leavePage.ClickAssignButton();
        }
    }
}

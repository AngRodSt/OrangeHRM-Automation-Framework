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
    internal class MyInfoSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly MyInfoPage _myInfoPage;
       
        public MyInfoSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            var driver = scenarioContext["WebDriver"] as IWebDriver;
            _myInfoPage = new MyInfoPage(driver);
           
        }

        // Background Step
        [Given(@"I am on the My Info page")]
        public void GivenIAmOnTheMyInfoPage()
        {  
            _myInfoPage.ClickMyInfoLink();
            if (!_myInfoPage.IsPageLoaded())
            {
                throw new Exception("My Info page did not load correctly.");
            }
        }

        // Scenario Step
        [When(@"I update my personal details with First Name ""(.*)"", Middle Name ""(.*)"", and Last Name ""(.*)""")]

        public void WhenIUpdateMyPersonalDetailsWithFirstNameMiddleNameAndLastName(string firstName, string middleName, string lastName)
        {
            _myInfoPage.UpdateName(firstName, middleName, lastName);
            _myInfoPage.ClickSaveButton();
        }

        [Then(@"I should see a success message ""(.*)""")]
        public void ThenIShouldSeeASuccessMessage(string expectedMessage)
        {
            string actualMessage = _myInfoPage.GetToastMessage();
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), "Success message did not match.");
        }
    }
}

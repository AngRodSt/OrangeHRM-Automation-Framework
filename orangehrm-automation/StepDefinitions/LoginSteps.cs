
using NUnit.Framework;
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
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioCotext;
        private readonly LoginPage _loginPage;
        private readonly DashboardPage _dashboardPage;

        public LoginSteps(ScenarioContext scenarioCotext)
        {
            _scenarioCotext = scenarioCotext;

            var driver = _scenarioCotext["WebDriver"] as IWebDriver;
            _loginPage = new LoginPage(driver);
            _dashboardPage = new DashboardPage(driver, false);
        }

        // Background step
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _loginPage.NavigateToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
          
        }

        // Scenario Outline: Successful Login
        [When(@"I log in with username ""(.*)"" and password ""(.*)""")]
        public void WhenILogInWithUsernameAndPassword(string username, string password)
        {
            _scenarioCotext["username"] = username;
            _scenarioCotext["password"] = password;

            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
            _loginPage.ClickLoginButton();
        }

        [Then(@"I should be redirected to the dashboard page")]
        public void ThenIShouldBeRedirectedToTheDashboardPage()
        {
            Assert.That(_dashboardPage.IsPageLoaded(), Is.True, "Dashboard is not displayed.");
        }

        // Scenario Outline: Unsuccessful Login
        [Then(@"I should see an error message ""(.*)""")]
        public void ThenIShouldSeeAnErrorMessage(string expectedError)
        {
            string  actualMessage = _loginPage.GetErrorMessage();

            Assert.That(actualMessage, Is.EqualTo(expectedError), "Error message does not match.");
        }

        // Scenario: Login with empty credentials

        [When(@"I attempt to log in without entering credentials")]
        public void WhenIAttemptToLogInWithoutEnteringCredentials()
        {
            _loginPage.ClickLoginButton();
        }
       

    }
}

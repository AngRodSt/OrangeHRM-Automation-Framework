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
    public class AdminSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly AdminPage _adminPage;
        private readonly LoginPage _loginPage;
       
        public AdminSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            var driver = _scenarioContext["WebDriver"] as IWebDriver;
            _adminPage = new AdminPage(driver);
            _loginPage = new LoginPage(driver);
        }

        // Background steps
        [Given(@"I am on the Admin page")]
        public void GivenImOnTheAdminPage()
        {
            _adminPage.ClickAdminLink();
           
            if (!_adminPage.IsPageLoaded())
            {
                throw new Exception("Login failed.");
            }
        }

        // Verify that the system only shows records related to the search criteria
        [When(@"I search for a specific ""(.*)""")]
        public void WhenISearchForASpecific(string username)
        {
            _adminPage.EnterUsername(username);
            _adminPage.ClickSearchButton();
        }

        [Then(@"the results should only show users related to that ""(.*)""")]
        public void ThenTheResultsShouldOnlyShowUsersRelatedToThat(string username)
        {
            var employeeNames = _adminPage.GetAllEmployeeNames();
            foreach (var name in employeeNames)
            {
                Assert.That(name, Does.Contain(username), $"The employee name {name} does not contain the username {username}");
            }
        }

        // Verify that I can select all listed users at once
        [When(@"I choose the option to select all users in the list")]
        public void WhenIChooseTheOptionToSelectAllUsersInTheList()
        {
            _adminPage.SelectAllUsers();
        }

        [Then(@"all users displayed on the page should be marked as selected")]
        public void ThenAllUsersDisplayedOnThePageShouldBeMarkedAsSelected()
        {
            var allSelected = _adminPage.AreAllUsersSelected();
            Assert.That(allSelected, Is.True, "Not all users are selected.");
        }
    }
}

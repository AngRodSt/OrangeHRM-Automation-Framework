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
    public class PIMSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly PIMPage _pIMPage;

        public PIMSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            var driver = _scenarioContext["WebDriver"] as IWebDriver;
            _pIMPage = new PIMPage(driver);
        }
    

        // Background steps
        [Given(@"I am on the PIM page")]
        public void GivenImOnThePIMPage()
        {
            _pIMPage.ClickPIMLink();
            if (!_pIMPage.IsPageLoaded())
            {
                throw new Exception("PIM page did not load correctly.");
            }
        }

        // Scenario: Sort Employees by First Name
        [When(@"I sort employees by first name in ascending order")]
        public void WhenISortEmployeesByFirstNameInAscendingOrder()
        {
            _pIMPage.SortByFirstNameAscending();
        }

        [Then(@"the employees should be sorted by first name in ascending order")]
        public void ThenTheEmployeesShouldBeSortedByFirstNameInAscendingOrder()
        {
            bool isSorted = _pIMPage.AreNamesSortedAsc();
            Assert.That(isSorted, Is.True, "Employees are not sorted by first name in ascending order.");
        }

        // Scenario: Navigate to Next Page of Employees
        [When(@"I navigate to the next page of employees")]
        public void WhenINavigateToTheNextPageOfEmployees()
        {
            var before = _pIMPage.GetFirstNames();

            _scenarioContext["EmployeeListBefore"] = before;

            _pIMPage.NavigateToNextPage();

            _pIMPage.WaitForNextPageToLoad(before.First());
        }

        [Then(@"the next page of employees should be displayed")]
        public void ThenTheNextPageOfEmployeesShouldBeDisplayed()
        {
            var before = _scenarioContext["EmployeeListBefore"] as List<string>;
            var after = _pIMPage.GetFirstNames();

            Assert.That(after, Is.Not.EqualTo(before), "The next page of employees was not displayed.");
        }

        // Scenario: Select an Employees
        [When(@"I select an employee from the list")]
        public void WhenISelectAnEmployeeFromTheList()
        {
            _pIMPage.SelectFirstEmployee();
        }

        [Then(@"the system should consider that employee as selected")]
        public void ThenTheSystemShouldConsiderThatEmployeeAsSelected()
        {
            bool isSelected = _pIMPage.IsFirstEmployeeSelected();
            Assert.That(isSelected, Is.True, "The employee was not selected.");
        }

        // Scenario: Confirm Action Dialog on Delete
        [When(@"I attempt to delete the selected employee")]
        public void WhenIAttemptToDeleteTheSelectedEmployee()
        {
            _pIMPage.ClickTrashButton();
        }

        [Then(@"a confirmation dialog should appear")]
        public void ThenAConfirmationDialogShouldAppear()
        {
            bool isDialogVisible = _pIMPage.IsConfirmDialogVisible();
            Assert.That(isDialogVisible, Is.True, "The confirmation dialog did not appear.");
        }
    }
}

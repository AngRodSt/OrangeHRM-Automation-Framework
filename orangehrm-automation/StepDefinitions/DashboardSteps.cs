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
    public class DashboardSteps
    {
        private readonly ScenarioContext _scenarioCotext;
        private readonly DashboardPage _dashboardPage;
        private readonly LoginPage _loginPage;

        public DashboardSteps(ScenarioContext scenarioContext)
        {
            _scenarioCotext = scenarioContext;

            var driver = _scenarioCotext["WebDriver"] as IWebDriver;
            _dashboardPage = new DashboardPage(driver);
            _loginPage = new LoginPage(driver);

        }

        //Background steps
        [Given(@"I am logged in as a valid user")]
        public void GivenIAmLoggedInAsAValidUser()
        {
            _loginPage.NavigateToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            _loginPage.EnterUsername("Admin");
            _loginPage.EnterPassword("admin123");
            _loginPage.ClickLoginButton();
            
        }

        [Given(@"I am on the dashboard page")]
        public void GivenIAmOnTheDashboardPage()
        {
            // Verify login
            if (!_loginPage.IsDashboardDisplayed())
            {
                throw new Exception("Login failed.");
            }
        }

        [Then(@"the dashboard should display the ""(.*)""")]
        public void ThenTheDashboardShouldDisplay(string elementName)
        {
            bool result = _dashboardPage.isDashboardElementVisible(elementName);
            Assert.That(result, Is.True, $"The dashboard element {elementName} was not displayed");
        }

        [Then(@"the dashboard chart ""(.*)"" should be visible")]
        public void ThenTheDashboardChartShouldBeVisible(string chartName)
        {
            bool result = _dashboardPage.isDashboardChartVisible(chartName);
            Assert.That(result, Is.True, $"The dashboard chart {chartName} was not visible");
        }

    }
}

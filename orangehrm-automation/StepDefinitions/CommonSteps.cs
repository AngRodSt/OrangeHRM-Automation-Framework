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
    public class CommonSteps
    {
        private readonly CommonPage _commonPage;
        private readonly LoginPage _loginPage;
        private readonly DashboardPage _dashboardPage;

        public CommonSteps(ScenarioContext scenarioContext)
        {
            var driver = scenarioContext["WebDriver"] as IWebDriver;
            _commonPage = new CommonPage(driver);
            _loginPage = new LoginPage(driver);
            _dashboardPage = new DashboardPage(driver);
        }

        [Given(@"I am logged in as a valid user")]
        public void GivenIAmLoggedInAsAValidUser()
        {
            _loginPage.NavigateToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login" +
                "");

            _loginPage.EnterUsername("Admin");
            _loginPage.EnterPassword("admin123");
            _loginPage.ClickLoginButton();

            if (!_dashboardPage.IsPageLoaded())
            {
                throw new Exception("Login failed.");
            }
        }

        [Then(@"I should see a required field error")]
        public void ThenIShouldSeeARequiredFieldError()
        {
            string actual = _commonPage.GetRequiredMessage();
            Assert.That(actual, Is.EqualTo("Required"), "Required message was not displayed.");
        }
    }
}

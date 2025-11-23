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
    public class UserMenuSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly UserMenuPage _userMenuPage;
        private readonly LoginPage _loginPage;


        public UserMenuSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            var driver = _scenarioContext["WebDriver"] as IWebDriver;

            _userMenuPage = new UserMenuPage(driver);
            _loginPage = new LoginPage(driver);
        }

        [When(@"I choose to end my session")]
        public void WhenIChooseToEndMySession()
        {
            _userMenuPage.OpenUserMenu();
            _userMenuPage.ClickLogout();
        }

        [Then(@"I should be logged out and redirected to the login page")]
        public void ThenIShouldBeLoggedOutAndRedirectedToTheLoginPage()
        {
            if (!_loginPage.IsPageLoaded())
            {
                throw new Exception("Logout failed, not redirected to login page.");
            }
        }
    }
}

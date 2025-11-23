using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangehrm_Automation.Pages
{
    public class LoginPage: Base.BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        //Locators
        private readonly By usernameInput = By.Name("username");
        private readonly By passwordInput = By.Name("password");
        private readonly By loginButton = By.CssSelector("button[type='submit']");
        private readonly By errorMessage = By.CssSelector(".oxd-alert-content-text");
        public readonly By loginText = By.XPath("//h5[text()='Login']");

        //Actions
        public override bool IsPageLoaded()
        {
            return isVisible(loginText);
        }
        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void EnterUsername(string username)
        {
            Type(usernameInput, username);
        }

        public void EnterPassword(string password)
        {
            Type(passwordInput, password);
        }

        public void ClickLoginButton()
        {
            ClickElement(loginButton);

        }

        public string GetErrorMessage()
        {
            return GetText(errorMessage);
        }

 

       
    }
}

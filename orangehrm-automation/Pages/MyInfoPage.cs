using OpenQA.Selenium;
using Orangehrm_Automation.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangehrm_Automation.Pages
{
    public class MyInfoPage: BasePage
    {
        public MyInfoPage(IWebDriver driver): base(driver) { }

        //Locators
        private readonly By MyInfoLink = By.XPath("//a[@href='/web/index.php/pim/viewMyDetails']");
        private readonly By PersonalDetailsHeader = By.XPath("//h6[text()='Personal Details']");
        private readonly By FirstNameInput = By.Name("firstName");
        private readonly By MiddleNameInput = By.Name("middleName");
        private readonly By LastNameInput = By.Name("lastName");
        private readonly By SaveButton = By.XPath("//button[@type='submit']");
        private readonly By ToastMessage = By.CssSelector(".oxd-toast-content--success .oxd-text--toast-message");

        //Methods

        public override bool IsPageLoaded()
        {
            return isVisible(PersonalDetailsHeader);
        }

        public void ClickMyInfoLink()
        {
            ClickElement(MyInfoLink);
        }

        public void UpdateName(string firstName, string middleName, string lastName)
        {
            Type(FirstNameInput, firstName);
            Type(MiddleNameInput, middleName);
            Type(LastNameInput, lastName);
        }

        public void ClickSaveButton()
        {
            ClickElement(SaveButton);
        }

        public string GetToastMessage()
        {
            return GetText(ToastMessage);
        }
    }
}

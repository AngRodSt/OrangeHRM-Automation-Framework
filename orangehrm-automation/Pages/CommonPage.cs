using OpenQA.Selenium;
using Orangehrm_Automation.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangehrm_Automation.Pages
{
    public class CommonPage: BasePage
    {
        public CommonPage(IWebDriver driver): base(driver) { }

        //Locators
        private readonly By RequiredMessage = By.CssSelector(".oxd-input-field-error-message");

        //Methods
        public string GetRequiredMessage()
        {
            return GetText(RequiredMessage);
        }

        public override bool IsPageLoaded()
        {
            throw new NotImplementedException();
        }

    }
}

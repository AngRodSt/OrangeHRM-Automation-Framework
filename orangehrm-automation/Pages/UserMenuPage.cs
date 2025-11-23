using OpenQA.Selenium;
using Orangehrm_Automation.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangehrm_Automation.Pages
{
    public class UserMenuPage : BasePage
    {
        public UserMenuPage(IWebDriver driver) : base(driver) { }

        // Locators
        private readonly By UserMenuButton = By.XPath("//span[contains(@class,'oxd-userdropdown-tab')]");
        private readonly By LogoutButton = By.XPath("//a[contains(@class,'oxd-userdropdown-link') and text()='Logout']");

        // Methods
        public override bool IsPageLoaded()
        {
            throw new NotImplementedException();
        }

        public void OpenUserMenu()
        {
            ClickElement(UserMenuButton);

        }

        public void ClickLogout()
        {
            ClickElement(LogoutButton);
        }
    }
}

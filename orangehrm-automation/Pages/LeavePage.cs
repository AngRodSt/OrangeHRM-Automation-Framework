using OpenQA.Selenium;
using Orangehrm_Automation.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangehrm_Automation.Pages
{
    public class LeavePage : BasePage
    {
        public LeavePage(IWebDriver driver) : base(driver) { }

        //Locators
        private readonly By LeaveHeader = By.XPath("//h6[text()='Leave']");
        private readonly By LeaveLink = By.XPath("//a[@href='/web/index.php/leave/viewLeaveModule']");
        private readonly By AssignLeaveLi = By.XPath("//li[contains(@class, 'oxd-topbar-body-nav-tab')]//a[text()='Assign Leave']");
        private readonly By AssignLeaveHeader = By.XPath("//h6[text()='Assign Leave']");
        private readonly By AssingBtn = By.CssSelector("button[type='submit']");

        //Methods
        public override bool IsPageLoaded()
        {
            return isVisible(LeaveHeader);
        }

        public void ClickLeaveLink()
        {
            ClickElement(LeaveLink);
        }

       public void ClickAssignLeaveLink()
        {
            ClickElement(AssignLeaveLi);
        }
        public bool IsAssignLeavePageLoaded()
        {
            return isVisible(AssignLeaveHeader);
        }

        public void ClickAssignButton()
        {
            ClickElement(AssingBtn);
        }

    
    }
}

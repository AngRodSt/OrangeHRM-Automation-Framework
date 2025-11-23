using OpenQA.Selenium;
using Orangehrm_Automation.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangehrm_Automation.Pages
{
    public class AdminPage: BasePage
    {
        public AdminPage(IWebDriver driver): base(driver) { }

        //Locators
        private readonly By AdminLink = By.XPath("//a[@href='/web/index.php/admin/viewAdminModule']");
        private readonly By UsernameInput = By.XPath("//label[text()='Username']/ancestor::div[contains(@class,'oxd-input-group')]//input");
        private readonly By SearchBtn = By.CssSelector("button[type='submit']");
        private readonly By TableRows = By.XPath("//div[@class='oxd-table-body']//div[@role='row']");
        private readonly By SelectAllCheckbox = By.XPath("//div[contains(@class,'oxd-table-header-cell')]//span[contains(@class,'oxd-checkbox-input')]");
        private readonly By AdminText = By.XPath("//h6[text()='Admin']");

        //Methods employing search functionality
        public override bool IsPageLoaded()
        {
            return isVisible(AdminText);
        }

        public void ClickAdminLink()
        {
            ClickElement(AdminLink);
        }

        public void EnterUsername(string username)
        {
            Type(UsernameInput, username);
        }

        public void ClickSearchButton()
        {
            ClickElement(SearchBtn);
        }

        private string GetEmployeeName(IWebElement row)
        {
            var nameCell = row.FindElement(By.XPath("//div[@role='cell'][2]//div"));
            return nameCell.Text.Trim();
        }


        public List<string> GetAllEmployeeNames()
        {
            var rows = Driver.FindElements(TableRows);
            var names = new List<string>();

            foreach (var row in rows)
            {
                names.Add(GetEmployeeName(row));
            }

            return names;
        }

        //Method to select all checkboxes in the table

        public void SelectAllUsers()
        {
            ClickElement(SelectAllCheckbox);
        }
        private bool isCheckboxActive(IWebElement checkboxSpan)
        {
            return checkboxSpan.GetAttribute("class").Contains("oxd-checkbox-input--active");
        }

        public bool AreAllUsersSelected()
        {
            var rows = Driver.FindElements(TableRows); 
            foreach (var row in rows)
            {
                var checkboxSpan = row.FindElement(By.XPath("//div[@role='cell'][1]//span"));
                if (!isCheckboxActive(checkboxSpan))
                {
                    return false;
                }
               
            }
            return true;
        }

    }

}

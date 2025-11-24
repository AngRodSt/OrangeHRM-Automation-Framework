using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Orangehrm_Automation.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangehrm_Automation.Pages
{
    public class PIMPage : BasePage
    {
        public PIMPage(IWebDriver driver) : base(driver) { }

        // Locators
        private readonly By PIMLink = By.XPath("//a[@href='/web/index.php/pim/viewPimModule']");
        private readonly By PIMText = By.XPath("//h6[text()='PIM']");

        private readonly By FirstNameSortIcon = By.XPath("//div[@role='columnheader'][contains(., 'First')]//i[contains(@class,'oxd-table-header-sort-icon')]");
        private readonly By SortDropdown = By.XPath("//div[@role='columnheader'][contains(., 'First')]//div[contains(@class, 'oxd-table-header-sort-dropdown')]");
        private readonly By SortAscending = By.XPath("//div[@role='columnheader'][contains(., 'First')]//span[text()='Ascending']");
        private readonly By FirstNameCells = By.XPath("//div[contains(@class, 'oxd-table-body')]//div[@role='row']//div[3]");

        private readonly By NavigationBtn = By.CssSelector(".oxd-pagination-page-item--previous-next");

        private readonly By TableCheckbox = By.XPath("//div[@class='oxd-table-body']//div[@class='oxd-checkbox-wrapper']//span[contains(@class,'oxd-checkbox-input')]");
        private readonly By TrashButton = By.XPath("(//i[contains(@class,'bi-trash')]/parent::button)[1]");
        private readonly By ConfirmDeleteButton = By.XPath("//button[@type='button'][contains(.,' Yes, Delete ')]");
        private readonly By ConfirmDialog = By.XPath("//div[contains(@class,'orangehrm-dialog-popup')]");

        //Methods
        public override bool IsPageLoaded()
        {
            return isVisible(PIMText);
        }

        public void ClickPIMLink()
        {
            ClickElement(PIMLink);
        }

        public void SortByFirstNameAscending()
        {
            ClickElement(FirstNameSortIcon);
            isVisible(SortDropdown);
            ClickElement(SortAscending);
        }

        public List<string> GetFirstNames()
        {

            var elements = Driver.FindElements(FirstNameCells);
            return elements.Select(e => e.Text.Trim()).ToList();
        }

        public void WaitForNextPageToLoad(string previousFirstName)
        {
            WaitForElementTextToChange(FirstNameCells, previousFirstName);
        }


        public bool AreNamesSortedAsc()
        {
            var names = GetFirstNames();
            var sortedNames = names.OrderBy(n => n).ToList();

            return names.SequenceEqual(sortedNames);
        }

        public void NavigateToNextPage()
        {
            ClickElement(NavigationBtn);
        }

        public void SelectFirstEmployee()
        {
            var allCheckboxes = Driver.FindElements(TableCheckbox);
            allCheckboxes[1].Click();
        }

        public bool IsFirstEmployeeSelected()
        {
            var allCheckboxes = Driver.FindElements(TableCheckbox);
            var first = allCheckboxes[1];

            string classes = first.GetAttribute("class");
            return classes.Contains("oxd-checkbox-input--focus");
        }

        public void ClickTrashButton()
        {
            ClickElement(TrashButton);

        }

        public bool IsConfirmDialogVisible()
        {
            return isVisible(ConfirmDialog) && isVisible(ConfirmDeleteButton);
        }
    }


}

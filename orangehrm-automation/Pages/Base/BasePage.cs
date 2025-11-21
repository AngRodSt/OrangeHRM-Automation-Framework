using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangehrm_Automation.Pages.Base
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        private WebDriverWait _wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        // Wait for element
        protected IWebElement WaitForElementVisible(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));

        }

        protected IWebElement WaitForElementClickable(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        // Common actions
        protected void ClickElement(By locator)
        {
            WaitForElementClickable(locator).Click();
        }

        protected void Type(By locator, string value)
        {
            var element = WaitForElementVisible(locator);
            element.Clear();
            element.SendKeys(value);
        }

        protected string GetText(By locator)
        {
            return WaitForElementVisible(locator).Text;
        }

        protected bool isVisible(By locator)
        {
            try
            {
                return WaitForElementVisible(locator).Displayed;
            }
            catch
            {
                return false;
            }
        }

        protected IWebElement Find(By locator)
        {
            return WaitForElementVisible(locator);
        }

    }
}

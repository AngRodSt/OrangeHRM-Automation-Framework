using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Serilog;
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
            try
            {
                
                return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Element not visible: {locator}");
                throw;
            }

        }

        protected IWebElement WaitForElementClickable(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        // Common actions

        public abstract bool IsPageLoaded();
        protected void ClickElement(By locator)
        {
            try
            {
                WaitForElementClickable(locator).Click();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Failed to click element: {locator}");
                throw;
            }
        }

        protected void Type(By locator, string value)
        {
            try
            { 
                var element = WaitForElementVisible(locator);
                element.Clear();
                element.SendKeys(value);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Failed to type in: {locator}");
                throw;
            }
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

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Orangehrm_Automation.Drivers
{
    public static class DriverFactory
    {
        //enabling safe parallel test execution.
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        public static IWebDriver CreateDriver()
        {
            if (driver.Value == null)
            {
                //Automatically downloads the correct driver version
                new DriverManager().SetUpDriver(new ChromeConfig());

                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                options.AddArgument("--disable-notifications");
                options.AddArgument("--disable-infobars");
                //options.AddArgument("--headless");
                driver.Value = new ChromeDriver(options);

                
            }
            return driver.Value;
        }

        public static void QuitDriver()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose();
                driver.Value = null;
            }
        }
    }
}

using OpenQA.Selenium;
using Orangehrm_Automation.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangehrm_Automation.Pages
{
    public class DashboardPage : BasePage
    {
        //Dictionary to hold dashboard elements and their locators
        private readonly Dictionary<string, By> DashboardElements;
        private readonly Dictionary<string, By> DashboardCharts;
      
        public DashboardPage(IWebDriver driver, bool initialize= true) : base(driver)
        {
            // Initialize dictionaries for dashboard elements and charts
            DashboardElements = new Dictionary<string, By>(StringComparer.OrdinalIgnoreCase)
            {
                { "Time at Work", TimeAtWorkText },
                { "My Actions", MyActionsText },
                { "Quick Launch", QuickLaunchText },
                { "Employee Distribution by Sub Unit", EmDistributionUnitText },
                { "Employee Distribution by Location", EmDistributionLocationText } 
            };

            DashboardCharts = new Dictionary<string, By>(StringComparer.OrdinalIgnoreCase)
            {
                { "Employee Distribution by Sub Unit", SubUnitChart },
                { "Employee Distribution by Location", LocationChart }
            };
        }

        //Locators
        private readonly By TimeAtWorkText = By.XPath("//p[text()='Time at Work']");
        private readonly By MyActionsText = By.XPath("//p[text()='My Actions']");
        private readonly By QuickLaunchText = By.XPath("//p[text()='Quick Launch']");
        private readonly By EmDistributionUnitText = By.XPath("//p[text()='Employee Distribution by Sub Unit']");
        private readonly By EmDistributionLocationText = By.XPath("//p[text()='Employee Distribution by Location']");

        private readonly By SubUnitChart = By.XPath("//p[text()='Employee Distribution by Sub Unit']/ancestor::div[contains(@class,'orangehrm-dashboard-widget')]//canvas");
        private readonly By LocationChart = By.XPath("//p[text()='Employee Distribution by Location']/ancestor::div[contains(@class,'orangehrm-dashboard-widget')]//canvas");
        public readonly By dashboardText = By.XPath("//h6[text()='Dashboard']");

        public override bool IsPageLoaded()
        {
           return isVisible(dashboardText);
        }


        //Methods to verify elements on Dashboard Page
        public bool isDashboardElementVisible(string elementName)
        {
            if (!DashboardElements.ContainsKey(elementName))
            {
                throw new ArgumentException($"Dashboard element not found: {elementName}");
            }
            return isVisible(DashboardElements[elementName]);
        }

        public bool isDashboardChartVisible(string chartName)
        {
            if (!DashboardCharts.ContainsKey(chartName))
            {
                throw new ArgumentException($"Dashboard chart not found: {chartName}");
            }
            return isVisible(DashboardCharts[chartName]);
        }

    }
}
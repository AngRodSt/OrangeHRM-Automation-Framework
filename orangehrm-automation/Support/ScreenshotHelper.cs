using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangehrm_Automation.Support
{
    public static class ScreenshotHelper
    {
        public static string TakeScreenshot(IWebDriver driver, string scenarioName)
        {
            try
            {
                var projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
                var screenshotsDir = Path.Combine(projectRoot, "Screenshots");

                if (!Directory.Exists(screenshotsDir))
                    Directory.CreateDirectory(screenshotsDir);

                string fileName = $"{scenarioName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                string filePath = Path.Combine(screenshotsDir, fileName);

                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filePath);

                return filePath;
            }
            catch (Exception ex)
            {
                return $"Failed to capture screenshot: {ex.Message}";
            }
        }
    }
}

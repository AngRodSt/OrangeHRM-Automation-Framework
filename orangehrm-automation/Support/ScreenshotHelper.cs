using OpenQA.Selenium;

public static class ScreenshotHelper
{
    public static string TakeScreenshot(IWebDriver driver, string scenarioName)
    {
        try
        {
            var screenshotsDir = PathHelper.ScreenshotsDir;

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

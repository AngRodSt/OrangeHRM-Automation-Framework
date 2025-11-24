using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

public static class ExtentManager
{
    private static ExtentReports _extent;

    public static ExtentReports GetInstance()
    {
        if (_extent == null)
        {
            var projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
            var reportPath = Path.Combine(projectRoot, "Reports", "TestReport.html");

            var spark = new ExtentSparkReporter(reportPath);
            spark.Config.DocumentTitle = "Automation Test Report";
            spark.Config.ReportName = "UI Test Execution";

            _extent = new ExtentReports();
            _extent.AttachReporter(spark);
        }

        return _extent;
    }
}

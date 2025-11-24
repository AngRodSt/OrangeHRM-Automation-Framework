using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

public static class ExtentManager
{
    private static ExtentReports _extent;

    public static ExtentReports GetInstance()
    {
        if (_extent == null)
        {
            // ✔ Usamos tu PathHelper
            var reportsDir = PathHelper.ReportsDir;

            Directory.CreateDirectory(reportsDir);

            var reportPath = Path.Combine(reportsDir, "TestReport.html");

            var spark = new ExtentSparkReporter(reportPath);
            spark.Config.DocumentTitle = "Automation Test Report";
            spark.Config.ReportName = "UI Test Execution";

            _extent = new ExtentReports();
            _extent.AttachReporter(spark);
        }

        return _extent;
    }
}

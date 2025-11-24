public static class PathHelper
{
    public static string ProjectRoot
    {
        get
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;

            // Sube desde /bin/Debug/net8.0 hasta llegar al root del proyecto
            return Directory.GetParent(dir)!.Parent!.Parent!.Parent!.FullName;
        }
    }

    public static string ScreenshotsDir => Path.Combine(ProjectRoot, "Screenshots");
    public static string ReportsDir => Path.Combine(ProjectRoot, "Reports");
}

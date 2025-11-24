using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangehrm_Automation.Support
{
    public static class Logger
    {
        private static bool _isInitialized = false;
        public static void Init()
        {
            if (_isInitialized) return;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("Logs/execution.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            _isInitialized = true;
        }
    }
}

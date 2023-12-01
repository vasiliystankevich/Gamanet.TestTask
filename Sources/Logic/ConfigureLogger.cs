using Gamanet.TestTask.Wpf.Interfaces;
using Serilog;

namespace Gamanet.TestTask.Wpf.Logic
{
    public class ConfigureLogger : IConfigureLogger
    {
        public ConfigureLogger()
        {
        }

        public ILogger GetLogger(string logFilePath)
        {
            var template = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Indent:l}{Message}{NewLine}{Exception}";
            return new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(logFilePath, outputTemplate: template, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
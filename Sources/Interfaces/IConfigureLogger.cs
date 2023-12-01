using Serilog;

namespace Gamanet.TestTask.Wpf.Interfaces;

public interface IConfigureLogger
{
    public ILogger GetLogger(string logFilePath);
}
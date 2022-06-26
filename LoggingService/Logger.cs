using NLog;
using ILogger = Contracts.ILogger;

namespace LoggingService;

public class Logger: ILogger
{
    private static readonly NLog.ILogger _logService = NLog.LogManager.GetCurrentClassLogger();
    
    public void LogError(string message)
    {
       _logService.Error(message);
    }

    public void LogDebug(string message)
    {
        _logService.Debug(message);
    }

    public void LogWarning(string message)
    {
        _logService.Warn(message);
    }

    public void LogInformation(string message)
    {
        _logService.Info(message);
    }
}
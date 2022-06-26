namespace Contracts;

public interface ILogger
{
    void LogError(string message);
    void LogDebug(string message);
    void LogWarning(string message);
    void LogInformation(string message);
}
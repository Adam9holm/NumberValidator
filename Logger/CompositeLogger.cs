public class CompositeLogger : ILogger
{
    private readonly ILogger[] _loggers;

    public CompositeLogger(params ILogger[] loggers)
    {
        _loggers = loggers;
    }

    public void Log(string message, LogLevel level = LogLevel.Info)
    {
        foreach (var logger in _loggers)
        {
            logger.Log(message, level);
        }
    }
}
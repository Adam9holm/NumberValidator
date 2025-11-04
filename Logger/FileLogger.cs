public class FileLogger : ILogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Log(string message, LogLevel level = LogLevel.Info)
    {
        string log = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}][{level}] {message}";
        File.AppendAllText(_filePath, log + Environment.NewLine);
    }
}
public class ConsoleLogger : ILogger
{
        public void Log(string message, LogLevel level = LogLevel.Info)
    {
        ConsoleColor originalColor = Console.ForegroundColor;

        switch (level)
        {
            case LogLevel.Info:
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case LogLevel.Success:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case LogLevel.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case LogLevel.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
        }

        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}][{level}] {message}");
        Console.ForegroundColor = originalColor;
    }

}
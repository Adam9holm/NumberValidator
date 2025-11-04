public class RunValidator
{
    private readonly ILogger _logger;
    private readonly DateValidator _dateValidator;
    private readonly IdentifierValidatorManager _manager;

    public RunValidator()
    {
        Menu menu = new Menu();
    
        string logDir = "Logger";
        if (!Directory.Exists(logDir))
        Directory.CreateDirectory(logDir);

        string logPath = Path.Combine(logDir, "log.txt");
            List<string> loggerOptions = new List<string> { "Console", "File", "Both" };
            int selectedLoggerIndex = menu.ShowMenuOptions(loggerOptions, "Choose logtype:");

            switch (selectedLoggerIndex)
            {
                case 0:
                    _logger = new ConsoleLogger();
                    break;
                case 1:
                    _logger = new FileLogger("Logger/log.txt");
                    break;
                case 2:
                    _logger = new CompositeLogger(new ConsoleLogger(), new FileLogger(logPath));
                    break;
                default:
                    _logger = new ConsoleLogger();
                    break;
            }
        

        _logger.Log("[RunValidator] Logger initialized.", LogLevel.Info);

        _dateValidator = new DateValidator(_logger);
        _manager = new IdentifierValidatorManager(_logger);
    }

public void Run()
{
    Console.Write("Enter Swedish ID number: ");
    string input = Console.ReadLine() ?? "";

    IIdentifierNumber idNumber = new IdentifierNumber(input, _logger);

    if (!idNumber.IsValid)
    {
        _logger.Log("[RunValidator] Input failed sanitization. Stopping validation.", LogLevel.Error);
        Console.WriteLine("Input is NOT a valid Swedish identifier.");
        return;
    }

    if (!_dateValidator.Validate(idNumber))
    {
        _logger.Log("[RunValidator] Input failed date validation. Stopping validation.", LogLevel.Error);
        Console.WriteLine("Input is NOT a valid Swedish identifier.");
        return;
    }

    if (!_manager.Validate(idNumber))
    {
        _logger.Log("[RunValidator] Input failed number validation. Stopping validation.", LogLevel.Error);
        Console.WriteLine("Input is NOT a valid Swedish identifier.");
        return;
    }

    _logger.Log("[RunValidator] Input passed all validations.", LogLevel.Success);
    Console.WriteLine("Input is a valid Swedish identifier.");
}
}

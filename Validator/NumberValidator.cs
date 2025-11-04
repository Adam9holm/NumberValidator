
public abstract class NumberValidator : IValidator
{
    protected readonly IAlgorithm _algorithm = null!;
    protected readonly ILogger _logger;

    protected NumberValidator(ILogger logger)
    {
        _logger = logger;
        _algorithm = new LuhnAlgorithm(_logger); 
    }

    public abstract bool Validate(IIdentifierNumber idNumber);

    protected bool RunAlgorithm(IIdentifierNumber idNumber)
    {
        if (_algorithm.RunAlgorithm(idNumber))
        {
            _logger.Log($"[NumberValidator] {idNumber.Value} Passed algorithm check", LogLevel.Success);
            return true;
        }
        else{
            _logger.Log($"[NumberValidator] {idNumber.Value} Failed algorithm check", LogLevel.Error);
            return false;
        }
    }
}


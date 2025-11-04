public class CoordinationNumberValidator : NumberValidator
{
    public CoordinationNumberValidator(ILogger logger) 
        : base(logger) { }

    public override bool Validate(IIdentifierNumber idNumber)
    {

        if (!RunAlgorithm(idNumber))
            return false;

        _logger.Log($"[CoordinationNumberValidator] Valid coordination number: {idNumber.Value}", LogLevel.Success);
        return true;
    }

}



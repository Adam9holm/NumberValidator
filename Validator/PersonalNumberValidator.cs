public class PersonalNumberValidator : NumberValidator
{
    public PersonalNumberValidator(ILogger logger) 
        : base(logger) { }

    public override bool Validate(IIdentifierNumber idNumber)
    {
        if (!RunAlgorithm(idNumber))
            return false;

        _logger.Log($"[PersonalNumberValidator] Valid personal number: {idNumber.Value}", LogLevel.Success);
        return true;
    
    }
}

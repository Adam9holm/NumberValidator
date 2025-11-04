public class OrganizationNumberValidator : NumberValidator
{
    public OrganizationNumberValidator(ILogger logger) 
        : base(logger) { }

    public override bool Validate(IIdentifierNumber idNumber)
    {

        if (!RunAlgorithm(idNumber))
            return false;

        _logger.Log($"[OrganizationNumberValidator] Valid organization number: {idNumber.Value}", LogLevel.Success);
        return true;
    
    }


}

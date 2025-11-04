public class IdentifierValidatorManager
{
    private readonly ILogger _logger;
    private readonly IdentifyNumberType _typeHelper;
    public IdentifierValidatorManager(ILogger logger)
    {
        _logger = logger;
        _typeHelper = new IdentifyNumberType(_logger); 
    }
    public bool Validate(IIdentifierNumber idNumber)
    {
        IValidator validator;

        if (_typeHelper.IsOrganizationNumber(idNumber))
        {
            validator = new OrganizationNumberValidator(_logger);
            _logger.Log("[IdentifierValidatorManager] Using OrganizationNumberValidator.", LogLevel.Info);
        }
        else if (_typeHelper.IsCoordinationNumber(idNumber))
        {
            validator = new CoordinationNumberValidator(_logger);
            _logger.Log("[IdentifierValidatorManager] Using CoordinationNumberValidator.", LogLevel.Info);
        }
        else
        {
            validator = new PersonalNumberValidator(_logger);
            _logger.Log("[IdentifierValidatorManager] Using PersonalNumberValidator.", LogLevel.Info);
        }

        return validator.Validate(idNumber); 
    }
    }



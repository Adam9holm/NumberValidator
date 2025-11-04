    public class IdentifyNumberType
    {

    protected readonly ILogger _logger;

    public IdentifyNumberType(ILogger logger)
    {
        _logger = logger;
    }

        public bool IsOrganizationNumber(IIdentifierNumber idNumber)
        {
            int.TryParse(idNumber.CleanedValue.Substring(2, 2), out int month);

            if(month >= 20){
                _logger.Log("[IdentifyNumberType] Number identified as organization number",LogLevel.Info);
                return true;
            }
            else return false;
        }

        public bool IsCoordinationNumber(IIdentifierNumber idNumber)
        {
            int day = int.Parse(idNumber.CleanedValue.Substring(4, 2));
            if(day >= 61 && day <= 91){
                _logger.Log("[IdentifyNumberType] Number identified as Coordination number",LogLevel.Info);

                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool IsPersonalNumber(IIdentifierNumber idNumber){
            if(!IsCoordinationNumber(idNumber) && !IsOrganizationNumber(idNumber))
            {
                _logger.Log("[IdentifyNumberType] Number identified as personal number",LogLevel.Info);
                return true;
                }
            else{
            return false;
            }
            
        }
    }    

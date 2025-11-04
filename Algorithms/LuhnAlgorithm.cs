using System;
    public class LuhnAlgorithm : IAlgorithm
    {      
    protected readonly ILogger _logger;

    public LuhnAlgorithm(ILogger logger)
    {
        _logger = logger;
    }
        public bool RunAlgorithm(IIdentifierNumber idNumber)
        {

            if (string.IsNullOrWhiteSpace(idNumber.CleanedValue))
            {
                _logger.Log("[LuhnAlgorithm] Input cannot be null or empty.",LogLevel.Error);
                return false;
            }

            if (idNumber.CleanedValue.Length != 10)
            {
                _logger.Log("[LuhnAlgorithm] Input must be exactly 10 digits.",LogLevel.Error);
                return false;
            }

            if (!long.TryParse(idNumber.CleanedValue, out _))
            {
                _logger.Log("[LuhnAlgorithm] Input must contain only numeric characters.",LogLevel.Error);
                return false;
            }

            int sum = 0;

            for (int i = 0; i < idNumber.CleanedValue.Length; i++)
            {
                int digit = idNumber.CleanedValue[idNumber.CleanedValue.Length - 1 - i] - '0';

                if (i % 2 == 1)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit = digit / 10 + digit % 10; 
                }
                sum += digit;
            }

            if (sum % 10 != 0)
            {
                _logger.Log("[LuhnAlgorithm] Luhn check failed: control digit mismatch.",LogLevel.Error);
                return false;
            }
            return true;
        }
    }


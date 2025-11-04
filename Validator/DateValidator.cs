using System;

public class DateValidator : IValidator
{
    private readonly ILogger _logger;
    private readonly IdentifyNumberType _typeHelper;
    public DateValidator(ILogger logger)
    {
        _logger = logger;
        _typeHelper = new IdentifyNumberType(_logger);

    }

    public bool Validate(IIdentifierNumber idNumber)
    {
        bool hasPlus = idNumber.Value.Contains("+");
        string withoutSign = idNumber.Value.Replace("-", "").Replace("+", "");

        bool isOrg = _typeHelper.IsOrganizationNumber(idNumber);
        bool isCoord = _typeHelper.IsCoordinationNumber(idNumber);

        if (isOrg)
        {
            _logger.Log("[DateValidator] Input identified as organization, skipping date validation.", LogLevel.Info);
            return true;
        }

        int year, month, day;
        if (withoutSign.Length == 12)
        {
            year = int.Parse(withoutSign.Substring(0, 4));
            month = int.Parse(withoutSign.Substring(4, 2));
            day = int.Parse(withoutSign.Substring(6, 2));
        }
        else if (withoutSign.Length == 10)
        {
            int yy   = int.Parse(withoutSign.Substring(0, 2));
            int mm   = int.Parse(withoutSign.Substring(2, 2));
            int dd   = int.Parse(withoutSign.Substring(4, 2));

            DateTime today = DateTime.Today;
            DateTime candidate;
            try
            {
                candidate = new DateTime(2000 + yy, mm, dd);
            }
            catch
            {
                _logger.Log($"[DateValidator] Invalid date candidate: 20{yy:D2}-{mm:D2}-{dd:D2}", LogLevel.Warning);
                return false;
            }

            if (hasPlus)
            {
                candidate = candidate.AddYears(-100);

                if (candidate > today.AddYears(-100))
                {
                    candidate = candidate.AddYears(-100);
                }
            }
            else
            {
                if (candidate > today)
                {
                    candidate = candidate.AddYears(-100);
                }
            }

            year  = candidate.Year;
            month = candidate.Month;
            day   = candidate.Day;

            _logger.Log($"[DateValidator] Interpreted 10-digit input as {year:D4}-{month:D2}-{day:D2}", LogLevel.Info);
        }

        else
        {
            _logger.Log("[DateValidator] Input is not 10 or 12 digits long.", LogLevel.Error);
            return false;
        }

        if (isCoord)
        {
            day -= 60;
        }

        try
        {
            DateTime birthDate = new DateTime(year, month, day);
            DateTime todayDate = DateTime.Today;
            DateTime earliestValid = todayDate.AddYears(-200); 

            if (birthDate > todayDate || birthDate < earliestValid)
            {
                _logger.Log($"[DateValidator] Birthdate {birthDate:yyyy-MM-dd} is out of valid range.", LogLevel.Error);
                return false;
            }

            _logger.Log($"[DateValidator] Valid birthdate: {birthDate:yyyy-MM-dd}", LogLevel.Success);
            return true;
        }
        catch
        {
            _logger.Log($"[DateValidator] Invalid date components: {year}-{month}-{day}", LogLevel.Error);
            return false;
        }
    }
}

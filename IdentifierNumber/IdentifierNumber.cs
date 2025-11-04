public  class IdentifierNumber : IIdentifierNumber
{
   protected readonly ILogger _logger;
    protected readonly InputSanitizer _sanitizer;
    public string Value { get; private set; }
    public string CleanedValue { get; private set; }
    public bool IsValid { get; private set; }

   public IdentifierNumber(string input, ILogger logger)
    {
        _logger = logger;
        _sanitizer = new InputSanitizer(_logger); 

        if (!_sanitizer.Sanitize(input))
        {
            _logger.Log($"[IdentifierNumber] Invalid identifier number: {input}", LogLevel.Error);
            IsValid = false;
            Value = string.Empty;
            CleanedValue = string.Empty;
            return;
        }

        Value = input;
        CleanedValue = CleanInputTenDigits(input); 
        IsValid = true;

        _logger.Log($"[IdentifierNumber] Created identifier number: {input} (cleaned: {CleanedValue})", LogLevel.Info);
    }

    private string CleanInputTenDigits(string input)
    {
        string cleaned = input.Replace("-", "").Replace("+", "");
        if (cleaned.Length == 12){
            return cleaned = cleaned.Substring(2);
        }
        else{
        return cleaned;}
    }

    public override string ToString() => IsValid ? Value : "[Invalid IdentifierNumber]";
}
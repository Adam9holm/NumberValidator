using System.Text.RegularExpressions;

public class InputSanitizer
    {
        private readonly ILogger _logger;

        public InputSanitizer(ILogger logger)
        {
            _logger = logger;
        }

        public bool Sanitize(string input)
        {

            _logger.Log($"[InputSanitizer] Sanitizing input: {input}", LogLevel.Info);

            if (string.IsNullOrWhiteSpace(input))
            {
                _logger.Log($"[InputSanitizer] Input cannot be empty.", LogLevel.Error);
                return false;
            }

            if (input.Length > 13)
            {
                _logger.Log($"[InputSanitizer] Input cannot be longer than 12 digits (+ optional separator)", LogLevel.Error);
                return false;
            }

            var pattern = @"^\d{6,8}[-+]?\d{4}$";
            if (!Regex.IsMatch(input, pattern))
            {
                _logger.Log($"[InputSanitizer] Input contains invalid characters", LogLevel.Error);
                return false;
            }
            _logger.Log($"[InputSanitizer] Input passed sanitization.", LogLevel.Success);
            return true;
        }
    }


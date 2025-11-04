# Solution Documentation

## Assumptions

1. **Input Format**  
   - Swedish personal numbers, coordination numbers, and organization numbers can be entered in the formats `YYMMDD-NNNN` or `YYYYMMDDNNNN`.  
   - Optional separators are `-` or `+`.  
   - Input length should not exceed 13 characters (including separator).

2. **Validation Rules**  
   - **Personal number:** 10 digits after cleaning, valid date, and passes Luhn check.  
   - **Coordination number:** Similar to personal number, but day is offset by +60.  
   - **Organization number:** Month ≥ 20 or starts with `16` for 12-digit numbers. No date validation is required.  
   - **Date validation:** Only uses standard .NET libraries (`System.DateTime`).  
   - **Luhn Algorithm:** Validates the last digit as a control number.  

3. **Logging**  
   - Logging can be directed to Console, File, or Both.
   - Console logs are color-coded based on log level: `Info` (white), `Warning` (yellow), `Error` (red).  
   - File logs include timestamps and log levels.  
   - CompositeLogger allows multiple loggers simultaneously.  

4. **Other assumptions**  
   - Program should handle leap years correctly.  
   - Inputs outside the valid range (birthdates < 200 years ago or > today) are rejected.  
   - No external packages or libraries are used. Only standard .NET libraries are permitted.  

## Installation and Compilation
    - Ensure **.NET SDK** is installed.  
    - Clone the repository
    - Navigate to project file
Run commands:
    - dotnet build
    - dotnet run

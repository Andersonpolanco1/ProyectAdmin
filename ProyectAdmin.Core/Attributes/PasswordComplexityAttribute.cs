using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class PasswordComplexityAttribute : ValidationAttribute
{
    public int MinimumLength { get; set; } = 8; 
    public new string ErrorMessage { get; set; } = "La contraseña debe tener al menos {0} caracteres, incluir al menos una letra mayúscula, un número y un carácter especial.";

    private Regex GetPasswordRegex()
    {
        var pattern = $@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{{{MinimumLength},}}$";
        return new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var password = value as string;


        if (string.IsNullOrEmpty(password) || !GetPasswordRegex().IsMatch(password))
        {
            var formattedMessage = string.Format(ErrorMessage, MinimumLength);
            return new ValidationResult(formattedMessage);
        }

        return ValidationResult.Success!;
    }
}

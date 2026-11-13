using System;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace pract8_trpo.Data.Validators
{
    class PhoneValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value?.ToString() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult(false, "Значение не может быть пустым");
            }

            if (input.Length != 11)
            {
                return new ValidationResult(false, "Номер телефона состоит из 11 цифр");
            }

            if (input.Any(character => !char.IsAsciiDigit(character)))
            {
                return new ValidationResult(false, "Номер телефона состоит только из цифр");
            }
            if (input[0] != '8')
            {
                return new ValidationResult(false, "Номер телефона должен начинаться на 8");
            }

            return ValidationResult.ValidResult;
        }
    }
}

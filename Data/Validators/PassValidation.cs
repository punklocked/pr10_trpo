using System;
using System.Globalization;
using System.Windows.Controls;

namespace pract8_trpo.Data.Validators
{
    class PassValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(false, "Значение не может быть пустым");
            }

            string inputString = value.ToString();
            if (inputString.Length < 8)
            {
                return new ValidationResult(false, "Пароль должен содержать минимум 8 символов");
            }
            if (inputString.Length > 50)
            {
                return new ValidationResult(false, "Пароль не должен содержать больше чем 50 символов");
            }

            return ValidationResult.ValidResult;
        }
    }
}

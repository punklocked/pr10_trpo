using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pract8_trpo.Data.Validators
{
    class IDDvalidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string inputString = value?.ToString() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(inputString))
            {
                return new ValidationResult(false, "Значение не может быть пустым");
            }

            if (inputString.Length != 5)
            {
                return new ValidationResult(false, "ID состоит из 5 цифр");
            }

            if (inputString.Any(character => !char.IsAsciiDigit(character)))
            {
                return new ValidationResult(false, "ID состоит только из цифр");
            }

            return ValidationResult.ValidResult;
        }
    }
}

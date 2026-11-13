using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pract8_trpo.Data.Validators
{
    class IDPvalidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string inputString = value?.ToString() ?? string.Empty;
            if (inputString.Length == 0)
            {
                return ValidationResult.ValidResult;
            }

            if (inputString.Length > 7)
            {
                return new ValidationResult(false, "ID пациента не может быть больше 7 цифр");
            }

            if (inputString.Any(character => !char.IsAsciiDigit(character)))
            {
                return new ValidationResult(false, "ID состоит только из цифр");
            }

            return ValidationResult.ValidResult;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pract8_trpo.Data.Validators
{
    class StringValidation : ValidationRule
    {
        public int MinimumLength { get; set; } = 2;
        public int MaximumLength { get; set; } = 50;
        public bool AllowDigits { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string inputString = value?.ToString() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(inputString))
            {
                return new ValidationResult(false, "Значение не может быть пустым");
            }

            if (inputString.Trim().Length < MinimumLength)
            {
                return new ValidationResult(false, $"Строка должна содержать минимум {MinimumLength} символа");
            }
            if (inputString.Length > MaximumLength)
            {
                return new ValidationResult(false, $"Строка должна содержать не более {MaximumLength} символов");
            }

            if (!AllowDigits && ContainsDigits(inputString))
            {
                return new ValidationResult(false, "Строка не должна содержать цифры");
            }

            return ValidationResult.ValidResult;
        }

        private bool ContainsDigits(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

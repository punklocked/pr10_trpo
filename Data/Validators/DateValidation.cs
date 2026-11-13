using System;
using System.Globalization;
using System.Windows.Controls;

namespace pract8_trpo.Data.Validators
{
    class DateValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Значение не может быть пустым");
            }

            if (value is not DateTime input &&
                !DateTime.TryParse(value.ToString(), cultureInfo, DateTimeStyles.None, out input))
            {
                return new ValidationResult(false, "Введите корректную дату");
            }

            if (input.Date > DateTime.Today)
            {
                return new ValidationResult(false, "День рождения не может быть больше сегодняшнего");
            }
            if (input.Date < DateTime.Today.AddYears(-125))
            {
                return new ValidationResult(false, "Неверный день рождения");
            }

            return ValidationResult.ValidResult;
        }
    }
}

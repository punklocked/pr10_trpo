using System;
using System.Globalization;
using System.Windows.Data;

namespace pract8_trpo.Data.Converters
{
    class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            if (value is not DateTime birthday &&
                (value == null || !DateTime.TryParse(value.ToString(), cultureInfo, DateTimeStyles.None, out birthday)))
            {
                return string.Empty;
            }

            if (birthday.Date > DateTime.Today)
            {
                return string.Empty;
            }

            int age = GetAge(birthday);
            return age < 18
                ? $"{age} Несовершеннолетний"
                : $"{age} Совершеннолетний";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            return Binding.DoNothing;
        }

        public int GetAge(DateTime birthday)
        {
            int age = DateTime.Today.Year - birthday.Year;
            if (birthday.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}

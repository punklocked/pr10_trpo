using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace pract8_trpo.Data.Converters
{
    class AppointmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            if (value is not IEnumerable<Appointment> appointments)
            {
                return string.Empty;
            }

            DateTime[] appointmentDates = appointments
                .Where(appointment => appointment != null)
                .Select(appointment => appointment.Date.Date)
                .ToArray();
            if (appointmentDates.Length == 0)
            {
                return "Первый приём в клинике";
            }

            DateTime lastAppointment = appointmentDates.Max();
            if (lastAppointment > DateTime.Today)
            {
                return $"Следующий приём: {lastAppointment.ToString("dd.MM.yyyy", cultureInfo)}";
            }

            int daysSinceLastAppointment = (DateTime.Today - lastAppointment).Days;
            return daysSinceLastAppointment == 0
                ? "Последний приём был сегодня"
                : $"Дней с последнего приёма: {daysSinceLastAppointment}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            return Binding.DoNothing;
        }
    }
}

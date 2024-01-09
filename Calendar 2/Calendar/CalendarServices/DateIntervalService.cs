using Helpers;

namespace CalendarServices
{
    public class DateIntervalService
    {
        public void CalculateDateInterval()
        {
            DateTime startDate = DateTimeExtensions.ReadDateFromConsole(Literals.start_date);
            if (startDate == DateTime.MinValue) return;

            DateTime endDate = DateTimeExtensions.ReadDateFromConsole(Literals.end_date);
            if (endDate == DateTime.MinValue) return;

            TimeSpan interval = endDate - startDate;
            ConsoleWrapper.WriteLine(String.Format(Literals.interval_length, interval.Days));
        }
    }
}

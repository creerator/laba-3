using System;
using System.Collections.Generic;

namespace Helpers
{
    public static class DateTimeExtensions
    {
        public static DateTime ReadDateFromConsole(string datePrompt)
        {
            if (datePrompt != String.Empty) ConsoleWrapper.WriteLine(datePrompt);

            int year, month, day;

            ConsoleWrapper.Write(Literals.year_input);
            if (!int.TryParse(ConsoleWrapper.ReadLine(), out year))
            {
                ConsoleWrapper.WriteLine(Literals.year_input_wrong);
                return DateTime.MinValue;
            }

            ConsoleWrapper.Write(Literals.month_input);
            if (!int.TryParse(ConsoleWrapper.ReadLine(), out month) || month < 1 || month > 12)
            {
                ConsoleWrapper.WriteLine(Literals.month_input_wrong);
                return DateTime.MinValue;
            }

            ConsoleWrapper.Write(Literals.day_input);
            if (!int.TryParse(ConsoleWrapper.ReadLine(), out day) || day < 1 || day > DateTime.DaysInMonth(year, month))
            {
                ConsoleWrapper.WriteLine(Literals.day_input_wrong);
                return DateTime.MinValue;
            }

            try
            {
                var date = new DateTime(year, month, day);
                return date;
            }
            catch (ArgumentOutOfRangeException)
            {
                ConsoleWrapper.WriteLine(Literals.date_input_wrong);
                return DateTime.MinValue;
            }
        }
    }
}

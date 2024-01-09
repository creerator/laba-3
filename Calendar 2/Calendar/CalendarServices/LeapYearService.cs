using System;
using Helpers;

namespace CalendarServices
{
    public class LeapYearService
    {
        public void CheckLeapYear()
        {
            ConsoleWrapper.WriteLine(Literals.year_input);
            if (int.TryParse(ConsoleWrapper.ReadLine(), out int year))
            {
                try
                {
                    bool isLeapYear = DateTime.IsLeapYear(year);
                    ConsoleWrapper.WriteLine(String.Format(Literals.is_year_leap, year, isLeapYear));
                }
                catch {
                    ConsoleWrapper.WriteLine(Literals.year_input_wrong);
                }
            }
            else
            {
                ConsoleWrapper.WriteLine(Literals.year_input_wrong);
            }
        }
    }
}

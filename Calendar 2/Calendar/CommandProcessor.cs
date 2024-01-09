using Helpers;
using CalendarServices;

namespace ProgramUtilities
{
    public class CommandProcessor
    {
        private readonly LeapYearService _leapYearService;
        private readonly DateIntervalService _dateIntervalService;
        private readonly DayOfWeekService _dayOfWeekService;
        private readonly SaveService _saveService;
        private readonly LoadService _loadService;

        public CommandProcessor()
        {
            _leapYearService = new LeapYearService();
            _dateIntervalService = new DateIntervalService();
            _dayOfWeekService = new DayOfWeekService();
            _saveService = new SaveService();
            _loadService = new LoadService();
        }

        public bool ProcessCommand()
        {
            string command = ConsoleWrapper.ReadLine().Trim().ToLower();

            switch (command)
            {
                case "check":
                    _leapYearService.CheckLeapYear();
                    break;
                case "calc":
                    _dateIntervalService.CalculateDateInterval();
                    break;
                case "day":
                    _dayOfWeekService.DisplayDayOfWeek();
                    break;
                case "save":
                    _saveService.Save();
                    break;
                case "load":
                    _loadService.Load();
                    break;
                case "quit":
                    return false;
                default:
                    ConsoleWrapper.WriteLine(Literals.unknow_command);
                    break;
            }

            return true;
        }
    }
}
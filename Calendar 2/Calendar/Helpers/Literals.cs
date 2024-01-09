namespace Helpers
{
    public static class Literals
    {
        public static string welcome_message = "Usage:\nUse one of commands:\n\"check\" to check is year leap\n\"calc\" to calc interval length\n\"day\" to get the name of day of week\n\"quit\" to exit.\n\"save\" save data\n\"load\" load data";
        public static string separator = "----";
        public static string input_command = "Input the command: ";
        public static string unknow_command = "Command is unknown.";
        public static string year_input = "Input the year: ";
        public static string year_input_wrong = "Wrong year input.";
        public static string month_input = "Input the month: ";
        public static string month_input_wrong = "Wrong month input.";
        public static string day_input = "Input the day: ";
        public static string day_input_wrong = "Wrong day input.";
        public static string date_input_wrong = "Wrong date input.";
        public static string start_date = "Start date: ";
        public static string end_date = "End date: ";
        public static string interval_length = "Interval length: {0} days.";
        public static string is_year_leap = "Is year {0} leap? {1}";

        public static string save_dialog = "choose format: json, xml, sql";
        public static string load_dialog = "choose format: json, xml, sql";

        public static string data_path = ".";

        public static string file_not_found = "File not found";
        public static string empty_dir = "directory is empty";
        public static string saved_msg = "saved succsessfully";

        public static string GetCurrentDate() => DateTime.UtcNow.ToString().Replace(" ", "").Replace(":", "").Replace(".", "");
    }
}
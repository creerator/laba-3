using Helpers;
using System;

namespace CalendarServices
{
    public class SaveService
    {
        public void Save()
        {
            ConsoleWrapper.WriteLine(Literals.save_dialog);

            string command = ConsoleWrapper.ReadLine().Trim().ToLower();

            switch (command)
            {
                case "json":
                    SaveDataToJson();
                    break;
                case "xml":
                    SaveDataToXml();
                    break;
                case "sql":
                    SaveDataToSql();
                    break;
                default:
                    ConsoleWrapper.WriteLine(Literals.unknow_command);
                    break;
            }
        }
        private void SaveDataToJson()
        {
            DataManager.JsonDataManager.Save($"{Literals.data_path}\\json_data\\{Literals.GetCurrentDate()}.json", ConsoleWrapper.History);
            ConsoleWrapper.WriteLine(Literals.saved_msg);
        }

        private void SaveDataToXml()
        {
            DataManager.XmlDataManager.Save($"{Literals.data_path}\\xml_data\\{Literals.GetCurrentDate()}.xml", ConsoleWrapper.History);
            ConsoleWrapper.WriteLine(Literals.saved_msg);
        }

        private void SaveDataToSql()
        {
            DataManager.SqlDataManager.Save(Literals.GetCurrentDate(), ConsoleWrapper.History);
            ConsoleWrapper.WriteLine(Literals.saved_msg);
        }
    }
}

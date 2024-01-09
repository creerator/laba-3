using Helpers;
using System;
using System.Collections.Generic;
using DataManager;

namespace CalendarServices
{
    public class LoadService
    {
        public void Load()
        {
            ConsoleWrapper.WriteLine(Literals.load_dialog);

            string command = ConsoleWrapper.ReadLine().Trim().ToLower();

            switch (command)
            {
                case "json":
                    LoadDataFromJson();
                    break;
                case "xml":
                    LoadDataFromXml();
                    break;
                case "sql":
                    LoadDataFromSql();
                    break;
                default:
                    ConsoleWrapper.WriteLine(Literals.unknow_command);
                    break;
            }
        }
        private void LoadDataFromJson()
        {
            string file = GetFile("json_data");

            if (String.IsNullOrEmpty(file)) return;

            List<string> l = JsonDataManager.Load<List<string>>(file);

            foreach (string s in l) ConsoleWrapper.Write(s);
            ConsoleWrapper.WriteLine("");
        }
        
        private void LoadDataFromXml()
        {
            string file = GetFile("xml_data");

            if (String.IsNullOrEmpty(file)) return;

            List<string> l = XmlDataManager.Load<List<string>>(file);

            foreach (string s in l) ConsoleWrapper.Write(s);
            ConsoleWrapper.WriteLine("");
        }

        private void LoadDataFromSql()
        {
            ConsoleWrapper.WriteLine("");

            List<string> files = SqlDataManager.GetFiles();

            for (int i = 0; i < files.Count; i++)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(files[i]);
                ConsoleWrapper.WriteLine((i + 1).ToString() + ") " + fileNameWithoutExtension);
            }

            if (files == null)
            {
                ConsoleWrapper.WriteLine(Literals.empty_dir);
                return;
            }

            int n;

            try
            {
                n = int.Parse(ConsoleWrapper.ReadLine()) - 1;
            }
            catch
            {
                ConsoleWrapper.WriteLine(Literals.file_not_found);
                return;
            }

            if (n > files.Count - 1)
            {
                ConsoleWrapper.WriteLine(Literals.file_not_found);
                return;
            }

            List<string> l = SqlDataManager.Load(files[n]);

            foreach (string s in l) ConsoleWrapper.Write(s);
            ConsoleWrapper.WriteLine("");
        }

        private string GetFile(string subfolder)
        {
            ConsoleWrapper.WriteLine("");

            string[] files = GetFilesFromCatalog($"{Literals.data_path}\\{subfolder}");

            if (files == null)
            {
                ConsoleWrapper.WriteLine(Literals.empty_dir);
                return "";
            }

            int n;

            try
            {
                n = int.Parse(ConsoleWrapper.ReadLine()) - 1;
            }
            catch
            {
                ConsoleWrapper.WriteLine(Literals.file_not_found);
                return "";
            }

            if (n > files.Length - 1)
            {
                ConsoleWrapper.WriteLine(Literals.file_not_found);
                return "";
            }

            return files[n];
        }

        private string[] GetFilesFromCatalog(string path)
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
            
                for(int i=0; i< files.Length; i++)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(files[i]);
                    ConsoleWrapper.WriteLine((i+1).ToString() + ") " + fileNameWithoutExtension);
                }
                return files;
            }
            else
            {
                return null;
            }

        }
    }
}

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataManager
{
    public static class JsonDataManager
    {
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public static void Save<T>(string filePath, T data)
        {
            try
            {
                CreateDirectoryIfNeeded(filePath);

                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    JsonSerializer.Serialize(fileStream, data, Options);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error saving data synchronously.", ex);
            }
        }

        public static T Load<T>(string filePath)
        {
            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return JsonSerializer.Deserialize<T>(fileStream);
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new InvalidOperationException("Error loading data synchronously.", ex);
            }
        }

        private static void CreateDirectoryIfNeeded(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);

            if (directory == null)
                throw new ArgumentException("The directory path could not be determined from the file path.", nameof(filePath));

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
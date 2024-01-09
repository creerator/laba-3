using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DataManager
{
    public static class XmlDataManager
    {
        public static void Save<T>(string filePath, T data)
        {
            try
            {
                CreateDirectoryIfNeeded(filePath);

                var serializer = new XmlSerializer(typeof(T));

                using (var writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, data);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error saving data synchronously.", ex);
            }
        }

        public static T Load<T>(string filePath) where T : new()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                using (var reader = new StreamReader(filePath))
                {
                    return (T)serializer.Deserialize(reader);
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
            {
                throw new ArgumentException("The directory path could not be determined from the file path.", nameof(filePath));
            }

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.IO;

namespace AddSharedParametersToFamilies
{
    public static class Json
    {
        public static string applicationPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string jsonFolderPath = $"{applicationPath}\\Nika_RD_Data\\Nika_RD_Json\\AddSharedParametersToFamilies";

        static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            CheckAdditionalContent = true,
            Formatting = Formatting.Indented
        };

        public static void CheckOrCreateDirectory(string folderName)
        {
            if (!Directory.Exists($"{jsonFolderPath}\\{folderName}"))
            {
                Directory.CreateDirectory($"{jsonFolderPath}\\{folderName}");
            }
        }

        public static void WriteJson(object objectToSerialize, string settedName, string folderName)
        {
            string jsonFilePath = $"{jsonFolderPath}\\{folderName}\\{settedName}.json";

            using (StreamWriter writer = File.CreateText(jsonFilePath))
            {
                string output = JsonConvert.SerializeObject(objectToSerialize);
                writer.Write(output);
            }
        }

        public static T Deserialize<T>(string json) where T : new()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json, settings);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: Failed to deserialize json string into a valid object___{ex.Message}");
            }
        }

        public static T ReadJson<T>(string settedName, string folderName) where T : new()
        {
            string jsonFilePath = $"{jsonFolderPath}\\{folderName}\\{settedName}.json";

            T result = default(T);
            try
            {
                if (File.Exists(jsonFilePath))
                {
                    using (var reader = File.OpenText(jsonFilePath))
                    {
                        string fileText = reader.ReadToEnd();
                        var deserializedObject = Deserialize<T>(fileText);
                        if (deserializedObject != null)
                        {
                            result = deserializedObject;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return result;
        }
    }
}

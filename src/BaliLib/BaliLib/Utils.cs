using BaleLib.Resolver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BaleLib
{
    public static class Utils
    {
        public static string ReadValue(string key, string configurationsFilePath = null)
        {
            string path = configurationsFilePath ?? "./Configurations.json";
            if (File.Exists(path))
            {
                string jsonContent = File.ReadAllText(path);
                JObject jo = JObject.Parse(jsonContent);
                return jo[key].ToString();
            }

            return null;
        }

        public static string ReadFile(string filePath)
        {
            if (File.Exists(filePath))
                return File.ReadAllText(filePath);

            return null;
        }

        public static T Deserialize<T>(string json)
        {
            try
            {
                JsonSerializerSettings setting = new JsonSerializerSettings()
                {
                    ContractResolver = new BaleContractResolver()
                };

                return JsonConvert.DeserializeObject<T>(json, setting);
            }

            catch (Exception exp)
            {
                return default(T);
            }
        }

        public static string Serialize(object obj)
        {
            JsonSerializerSettings setting = new JsonSerializerSettings()
            {
                ContractResolver = new BaleContractResolver()
            };

            return JsonConvert.SerializeObject(obj, setting);
        }

        public static string Serialize(object obj, IEnumerable<KeyValuePair<string, string>> appedValues)
        {
            JsonSerializerSettings setting = new JsonSerializerSettings()
            {
                ContractResolver = new BaleContractResolver()
            };

            JObject jObjects = JObject.FromObject(obj);
            foreach(KeyValuePair<string, string> item in appedValues)
            {
                jObjects.Add(item.Key, item.Value);
            }

            return JsonConvert.SerializeObject(jObjects, setting);
        }
    }

}

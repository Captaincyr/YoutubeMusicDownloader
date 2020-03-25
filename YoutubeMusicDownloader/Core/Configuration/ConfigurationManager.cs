using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configuration
{
    public class ConfigurationManager
    {
        private const string FILENAME_CONFIG = @"\Configuration.json";

        public static AppConfig Config;

        static ConfigurationManager()
        {
            try
            {
                Config = JsonConvert.DeserializeObject<AppConfig>(File.ReadAllText(Directory.GetCurrentDirectory() + FILENAME_CONFIG));
            }
            catch
            {
                Config = new AppConfig();
            }
        }

        public static async Task Save()
        {
            await File.WriteAllTextAsync(Directory.GetCurrentDirectory() + FILENAME_CONFIG, JsonConvert.SerializeObject(Config));
        }
    }
}

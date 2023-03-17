using System.Text.Json;

namespace VSCodeLauncher.Lib.Config {
    public static class ConfigFile {

        public static ConfigBase LoadConfig(string configPath) {
            var configFullPath = Path.Combine(Directory.GetCurrentDirectory(), configPath);

            if (File.Exists(configFullPath)) {
                var jsonString = File.ReadAllText(configFullPath);
                if (jsonString == null) {
                    throw new Exception("Config file is empty");
                }

                return JsonSerializer.Deserialize<ConfigBase>(jsonString)
                        ?? throw new Exception("Invalid format config file");
            } else {
                throw new Exception("Config file is not found");
            }
        }

    }
}
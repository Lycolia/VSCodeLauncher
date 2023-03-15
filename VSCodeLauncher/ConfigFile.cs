using System.Text.Json;

namespace VSCodeLauncher {
    public class ConfigFile {

        private string ConfigFullPath { get; }

        public ConfigFile(string configPath) {
            this.ConfigFullPath = Path.Combine(Directory.GetCurrentDirectory(), configPath);
        }

        public void ExistsConfigFile() {
            if (File.Exists(this.ConfigFullPath)) {
                return;
            } else {
                throw new Exception("Config file is not found");
            }
        }

        public ConfigBase LoadConfig(Func<string, string?> FileReadAllHandler) {
            var jsonString = FileReadAllHandler(this.ConfigFullPath);
            if (jsonString == null) {
                throw new Exception("Config file is empty");
            }

            return JsonSerializer.Deserialize<ConfigBase>(jsonString)
                    ?? throw new Exception("Invalid format config file");
        }

    }
}

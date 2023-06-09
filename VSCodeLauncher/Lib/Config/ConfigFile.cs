﻿using System.Reflection;
using System.Text.Json;

namespace VSCodeLauncher.Lib.Config {
    public class ConfigFile {
        public static ConfigBase LoadConfig(string configPath) {
            var assembly = Assembly.GetEntryAssembly();
            if (assembly == null) {
                throw new Exception("An unexpected exception has occurred");
            }
            var executePath = Path.GetDirectoryName(assembly.Location);
            if (executePath == null) {
                throw new Exception("An unexpected exception has occurred");
            }

            var configFullPath = Path.Combine(executePath, configPath);

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
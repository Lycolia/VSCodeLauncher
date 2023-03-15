namespace VSCodeLauncher {
    public class ConfigBase {
        public string? CodePath { get; set; }
        public Dictionary<string, ConfigHost>? Host { get; set; }
    }
}

namespace VSCodeLauncher.Lib.Config {
    public class ConfigBase {
        private string? _CodePath;
        private Dictionary<string, ConfigRemote>? _Remote;

        public string CodePath {
            get {
                if (this._CodePath == null) {
                    throw new Exception("Config Error: Missing CodePath.");
                } else if (this._CodePath == null) {
                    throw new Exception("Config Error: CodePath is empty. Set the code.exe path in this field.");
                } else if (!File.Exists(this._CodePath)) {
                    throw new Exception("Config Error: CodePath is Not exists.");
                } else {
                    return this._CodePath;
                }
            }
            set { this._CodePath = value; }
        }

        public Dictionary<string, ConfigRemote> Remote {
            get {
                if (this._Remote == null) {
                    throw new Exception("Config Error: Missing Remote.");
                } else if (this._Remote.Count == 0) {
                    throw new Exception("Config Error: Remote is empty. Set the remote infomation in this field.");
                } else {
                    return this._Remote;
                }
            }
            set { this._Remote = value; }
        }
    }
}

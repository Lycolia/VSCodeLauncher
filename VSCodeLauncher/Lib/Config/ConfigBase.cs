﻿using VSCodeLauncher.Interface;

namespace VSCodeLauncher.Lib.Config {
    public class ConfigBase : IConfigBase {
        private IFileInfo? _CodePath;
        private Dictionary<string, IConfigRemote>? _Remote;

        public ConfigBase(IFileInfo? codePath, Dictionary<string, IConfigRemote>? remote) {
            this._CodePath = codePath;
            this._Remote = remote;
        }

        public string CodePath {
            get {
                if (this._CodePath == null) {
                    throw new Exception("Config Error: Missing CodePath.");
                } else if (this._CodePath == null) {
                    throw new Exception("Config Error: CodePath is empty. Set the code.exe path in this field.");
                } else if (!this._CodePath.Exists) {
                    throw new Exception("Config Error: CodePath is Not exists.");
                } else {
                    return this._CodePath.FullName;
                }
            }
        }

        public IDictionary<string, IConfigRemote> Remote {
            get {
                if (this._Remote == null) {
                    throw new Exception("Config Error: Missing Remote.");
                } else if (this._Remote.Count == 0) {
                    throw new Exception("Config Error: Remote is empty. Set the remote infomation in this field.");
                } else {
                    return this._Remote;
                }
            }
        }
    }
}

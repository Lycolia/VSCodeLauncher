namespace VSCodeLauncher.Lib.Config {
    public class ConfigRemote {
        /// <summary>
        /// Destination type
        /// SSH or WSL
        /// </summary>
        /// <example>
        /// SSH
        /// </example>
        private string? _RemoteType;
        /// <summary>
        /// Destination hostname
        /// example.com | WSL host name
        /// </summary>
        /// <example>
        /// Ubuntu-20.04
        /// </example>
        private string? _RemoteHostName;
        /// <summary>
        /// Destination UNC path prefix
        /// Paths in Explorer but unnecessary for VSCode
        /// </summary>
        /// <example>
        /// \\wsl.localhost\Ubuntu-20.04
        /// </example>
        private string? _ExplorerPrefix;
        /// <summary>
        /// The path is not in explorer but is required for VSCode
        /// </summary>
        /// <example>
        /// /home/
        /// </example>
        private string? _AppendPrefix;

        public ConfigRemote(string? remoteType, string? remoteHostName, string? explorerPrefix, string? appendPrefix) {
            this._RemoteType = remoteType;
            this._RemoteHostName = remoteHostName;
            this._ExplorerPrefix = explorerPrefix;
            this._AppendPrefix = appendPrefix;
        }

        public string RemoteType {
            get {
                if (this._RemoteType == null) {
                    throw new Exception("Config Error: Required Host.{HostName}.RemoteType.");
                } else if (this._RemoteType != "SSH" && this._RemoteType != "WSL") {
                    throw new Exception("Config Error: Host.{HostName}.RemoteType must be SSH or WSL.");
                } else {
                    return this._RemoteType;
                }
            }
        }

        public string RemoteHostName {
            get {
                if (this._RemoteHostName == null) {
                    throw new Exception("Config Error: Required Host.{RemoteHostName}.RemoteHostName.");
                } else if (this._RemoteHostName == "") {
                    throw new Exception("Config Error: Host.{RemoteHostName}.RemoteHostName is empty.");
                } else {
                    return this._RemoteHostName;
                }
            }
        }

        public string ExplorerPrefix {
            get {
                if (this._ExplorerPrefix == null) {
                    throw new Exception("Config Error: Required Host.{RemoteHostName}.ExplorerPrefix.");
                } else {
                    return this._ExplorerPrefix;
                }
            }
        }

        public string AppendPrefix {
            get {
                if (this._AppendPrefix == null) {
                    throw new Exception("Config Error: Required Host.{RemoteHostName}.AppendPrefix.");
                } else {
                    return this._AppendPrefix;
                }
            }
        }

    }
}

namespace VSCodeLauncher.Lib.Config {
    public class ConfigRemote {
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


        public string ExplorerPrefix {
            get {
                if (this._ExplorerPrefix == null) {
                    throw new Exception("Config Error: Required Host.{RemoteHostName}.ExplorerPrefix.");
                } else {
                    return this._ExplorerPrefix;
                }
            }
            set { this._ExplorerPrefix = value; }
        }

        public string AppendPrefix {
            get {
                if (this._AppendPrefix == null) {
                    throw new Exception("Config Error: Required Host.{RemoteHostName}.AppendPrefix.");
                } else {
                    return this._AppendPrefix;
                }
            }
            set {
                this._AppendPrefix = value;
            }
        }

    }
}

using VSCodeLauncher.Lib.Config;

namespace VSCodeLauncher.Lib.CommandGenerator {
    public class CommandGenerator {

        readonly string _HostName = "";
        readonly ConfigBase? _Config = null;

        public CommandGenerator(string hostName, ConfigBase config) {
            this._HostName = hostName;
            this._Config = config;
        }

        private ConfigRemote GetConfigHost() {
            if (this._Config == null) {
                throw new Exception("Config Error: no config");
            }

            return this._Config.Remote[this._HostName];
        }

        private string GetRemoteType() {
            var type = this.GetConfigHost().RemoteType;

            if (type == "SSH") {
                return "ssh-remote";
            } else if (type == "WSL") {
                return "wsl";
            } else {
                throw new Exception("Config Error: Host.{HostName}.Type must be SSH or WSL.");
            }
        }
        private string GetRemoteHostName() {
            return this.GetConfigHost().RemoteHostName;
        }
        private string GetExplorerPrefix() {
            return this.GetConfigHost().ExplorerPrefix;
        }
        private string GetAppendPrefix() {
            return this.GetConfigHost().AppendPrefix;
        }



        // 起動コマンド生成

        public CommandContext GenerateCommand() {
            if (this._Config == null) {
                throw new Exception("Config Error: no config");
            }

            try {
                var type = this.GetRemoteType();
                var hostname = this.GetRemoteHostName();
                var explorerPrefix = this.GetExplorerPrefix();
                var appendPrefix = this.GetAppendPrefix();

                return $"{type}+{hostname} {explorerPrefix} {appendPrefix}";

            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        public string GetRemoteType(string type) {
            if (type == "SSH") {
                return "ssh-remote+";
            } else if (type == "WSL") {
                return "wsl+";
            } else {
                throw new Exception($"Host.{this._HostName}.Type must be SSH or WSL");
            }
        }
        // 起動
    }
}

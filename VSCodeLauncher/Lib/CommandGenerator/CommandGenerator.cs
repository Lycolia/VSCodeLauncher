using System.Text.RegularExpressions;
using VSCodeLauncher.Lib.CommandLineParser;
using VSCodeLauncher.Lib.Config;

namespace VSCodeLauncher.Lib.CommandGenerator {
    public class CommandGenerator {

        public OpenPath OpenPath { get; }
        public ConfigBase Config { get; }

        public CommandGenerator(OpenPath openPath, ConfigBase config) {
            this.OpenPath = openPath;
            this.Config = config;
        }

        public static string GetHostNameByUncPath(string path) {
            var regex = new Regex(@"\\\\([^\\]+?)\\");
            var mat = regex.Match(path);
            if (mat.Success && mat.Captures.Count > 0) {
                return mat.Captures[1].Value;
            } else {
                throw new Exception("Failure path resolving");
            }
        }

        private ConfigRemote GetConfigHost() {
            if (!this.Config.Remote.ContainsKey(this.OpenPath.HostName)) {
                throw new Exception($"Host ${this.OpenPath.HostName} not exists in config file.");
            }

            return this.Config.Remote[this.OpenPath.HostName];
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

        public string[] GenerateCommand() {
            if (!this.OpenPath.IsRemote) {
                return new string[] { this.OpenPath.Path };
            }

            var explorerPrefix = this.GetExplorerPrefix();
            var appendPrefix = this.GetAppendPrefix();

            var openPath = $"{appendPrefix}{this.OpenPath.Path.Replace(explorerPrefix, "").Replace(@"\", "/")}";
            var type = this.GetRemoteType();
            var hostname = this.GetRemoteHostName();

            return new string[] { "--remote", $"{type}+{hostname}", openPath };
        }
    }
}

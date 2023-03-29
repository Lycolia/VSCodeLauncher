using System.Text.RegularExpressions;
using VSCodeLauncher.Lib.CommandLineParser;
using VSCodeLauncher.Lib.Config;

namespace VSCodeLauncher.Lib.Util {
    public class CommandGenerator {

        public OpenPath OpenPath { get; }
        public ConfigBase Config { get; }

        public CommandGenerator(OpenPath openPath, ConfigBase config) {
            OpenPath = openPath;
            Config = config;
        }

        private ConfigRemote GetConfigHost() {
            if (!Config.Remote.ContainsKey(OpenPath.HostName)) {
                throw new Exception($"Host ${OpenPath.HostName} not exists in config file.");
            }

            return Config.Remote[OpenPath.HostName];
        }

        private string GetExplorerPrefix() {
            return GetConfigHost().ExplorerPrefix;
        }

        private string GetAppendPrefix() {
            return GetConfigHost().AppendPrefix;
        }

        private string GetPosixOpenPath() {
            var explorerPrefix = GetExplorerPrefix();
            var appendPrefix = GetAppendPrefix();

            var explorerPrefixBuff = explorerPrefix.Replace(@"\", @"\\");
            var regexSafeExplorerPrefix = explorerPrefixBuff.Replace("$", @"\$");

            var unPrefixFullPath = Regex.Replace(OpenPath.FullPath, $"^{regexSafeExplorerPrefix}", "");
            var preOpenPath = PathUtil.Join('/', appendPrefix, unPrefixFullPath.Replace(@"\", "/"));
            return Regex.IsMatch(preOpenPath, "^/") ? preOpenPath : $"/{preOpenPath}";
        }

        public string[] GenerateCommand() {
            if (!OpenPath.IsRemote) {
                return new string[] { OpenPath.FullPath };
            }

            var openPath = GetPosixOpenPath();
            var type = OpenPath.RemoteType;
            var hostname = OpenPath.HostName;

            return new string[] { "--remote", $"{type}+{hostname}", openPath };
        }
    }
}
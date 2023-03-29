using VSCodeLauncher.Lib.Config;

namespace VSCodeLauncher.Test.Config {
    public class ConfigRemoteMock : IConfigRemote {
        public string ExplorerPrefix { get; }
        public string AppendPrefix { get; }

        public ConfigRemoteMock(string explorerPrefix, string appendPrefix) {
            this.ExplorerPrefix = explorerPrefix;
            this.AppendPrefix = appendPrefix;
        }
    }
}

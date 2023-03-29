using VSCodeLauncher.Lib.Config;

namespace VSCodeLauncher.Test.Config {
    public class ConfigBaseMock : IConfigBase {
        public string CodePath { get; }

        public IDictionary<string, IConfigRemote> Remote { get; }

        public ConfigBaseMock(string codePath, IDictionary<string, IConfigRemote> remote) {
            this.CodePath = codePath;
            this.Remote = remote;
        }
    }
}

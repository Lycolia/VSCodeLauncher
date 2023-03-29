using VSCodeLauncher.Interface;
using VSCodeLauncher.Lib.Config;

namespace VSCodeLauncher.Test.Config {
    public class DummyFile : IFileInfo {
        public string FullName { get; }
        public bool Exists { get; }

        public DummyFile(string fullName, bool exists) {
            this.FullName = fullName;
            this.Exists = exists;
        }
    }

    public class ConfigBaseTest {


        [Fact]
        public void CodePathTest() {
            var cf = new ConfigRemote("", "");
            var remote = new Dictionary<string, ConfigRemote>{
                { "example.com", cf }
            };
            var dummyFile = new DummyFile(@"C:users\foo\code", true);
            var actual = new ConfigBase(dummyFile, remote);

            Assert.Equal(@"C:users\foo\code", actual.CodePath);
            Assert.True(remote.Equals(actual.Remote));
        }
    }
}

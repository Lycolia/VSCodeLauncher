using VSCodeLauncher.Lib.Config;

namespace VSCodeLauncher.Test.Config {

    public class ConfigBaseTest {


        [Fact]
        public void CodePathTest() {
            var cf = new ConfigRemoteMock("", "");
            var remote = new Dictionary<string, IConfigRemote>{
                { "example.com", cf }
            };
            var dummyFile = new FileInfoMock(@"C:users\foo\code", true);
            var actual = new ConfigBase(dummyFile, remote);

            Assert.Equal(@"C:users\foo\code", actual.CodePath);
            Assert.True(remote.Equals(actual.Remote));
        }
    }
}

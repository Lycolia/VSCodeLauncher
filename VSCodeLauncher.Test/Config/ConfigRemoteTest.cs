using VSCodeLauncher.Lib.Config;

namespace VSCodeLauncher.Test.Config {
    public class ConfigRemoteTest {

        [Fact]
        public void NonNullTest() {
            var actual = new ConfigRemote { ExplorerPrefix = "foo", AppendPrefix = "bar" };

            Assert.Equal("foo", actual.ExplorerPrefix);
            Assert.Equal("bar", actual.AppendPrefix);
        }

        [Fact]
        public void ExplorerPrefixNullTest() {
            var actual = new ConfigRemote { ExplorerPrefix = null, AppendPrefix = "bar" };
            var ex = Assert.Throws<Exception>(() => actual.ExplorerPrefix);

            Assert.Equal("Config Error: Required Host.{RemoteHostName}.ExplorerPrefix.", ex.Message);
        }

        [Fact]
        public void AppendPrefixNullTest() {
            var actual = new ConfigRemote { ExplorerPrefix = "foo", AppendPrefix = null };
            var ex = Assert.Throws<Exception>(() => actual.AppendPrefix);

            Assert.Equal("Config Error: Required Host.{RemoteHostName}.AppendPrefix.", ex.Message);
        }
    }
}

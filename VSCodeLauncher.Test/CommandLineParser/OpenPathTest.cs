using VSCodeLauncher.Lib.CommandLineParser;

namespace VSCodeLauncher.Test.CommandLineParser {
    public class OpenPathTest {
        [Fact]
        public void IsRemote_False_All_Empty() {
            var actual = new OpenPath("", "", "");

            Assert.False(actual.IsRemote);
            Assert.Equal("", actual.RemoteType);
            Assert.Equal("", actual.HostName);
            Assert.Equal("", actual.FullPath);
        }

        [Fact]
        public void IsRemote_True_WSL_Type() {
            var actual = new OpenPath("wsl", "", "");

            Assert.True(actual.IsRemote);
            Assert.Equal("wsl", actual.RemoteType);
            Assert.Equal("", actual.HostName);
            Assert.Equal("", actual.FullPath);
        }

        [Fact]
        public void IsRemote_True_SSH_Type() {
            var actual = new OpenPath("ssh", "", "");

            Assert.True(actual.IsRemote);
            Assert.Equal("ssh", actual.RemoteType);
            Assert.Equal("", actual.HostName);
            Assert.Equal("", actual.FullPath);
        }

    }
}

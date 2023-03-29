using VSCodeLauncher.Lib;
using VSCodeLauncher.Lib.Config;
using VSCodeLauncher.Test.Config;

namespace VSCodeLauncher.Test {

    public class CommandGeneratorTest {

        [Fact]
        public void TestCommandGenerator() {
            var configRemote = new ConfigRemoteMock("", "");
            var remoteDict = new Dictionary<string, IConfigRemote> {
                { "test", configRemote }
            };

            var configBase = new ConfigBaseMock(@"C:\user\foo\code", remoteDict);
            var openPath = new OpenPathMock("", "", @"C:\user\foo\desktop\example", false);
            var actual = new CommandGenerator(openPath, configBase);

            Assert.True(actual.OpenPath.Equals(openPath));
            Assert.True(actual.Config.Equals(configBase));
        }

        [Fact]
        public void Return_LocalCommand() {
            var configRemote = new ConfigRemoteMock("", "");
            var remoteDict = new Dictionary<string, IConfigRemote> {
                { "test", configRemote }
            };

            var configBase = new ConfigBaseMock(@"C:\user\foo\code", remoteDict);
            var openPath = new OpenPathMock("", "", @"C:\user\foo\desktop\example", false);
            var cg = new CommandGenerator(openPath, configBase);

            var actual = cg.GenerateCommand();
            Assert.Single(actual);
            Assert.Equal(@"C:\user\foo\desktop\example", actual[0]);
        }

        [Theory]
        [InlineData(@"\\example.com", "/home/")]
        [InlineData(@"\\example.com\", "/home/")]
        [InlineData(@"\\example.com\", "/home")]
        [InlineData(@"\\example.com", "/home")]
        public void Return_RemoteSshCommand(string explorePrefix, string appendPrefix) {
            var configRemote = new ConfigRemoteMock(explorePrefix, appendPrefix);
            var remoteDict = new Dictionary<string, IConfigRemote> {
                { "example.com", configRemote }
            };

            var configBase = new ConfigBaseMock(@"C:\user\foo\code", remoteDict);
            var openPath = new OpenPathMock("ssh", "example.com", @"\\example.com\develop", true);
            var cg = new CommandGenerator(openPath, configBase);

            var actual = cg.GenerateCommand();
            Assert.Equal(3, actual.Count());
            Assert.Equal("--remote", actual[0]);
            Assert.Equal(@"ssh+example.com", actual[1]);
            Assert.Equal(@"/home/develop", actual[2]);
        }

        [Theory]
        [InlineData(@"\\wsl.localhost\Ubuntu-20.04")]
        [InlineData(@"\\wsl.localhost\Ubuntu-20.04\")]
        public void Return_RemoteWslCommand(string explorePrefix) {
            var configRemote = new ConfigRemoteMock(explorePrefix, "");
            var remoteDict = new Dictionary<string, IConfigRemote> {
                { "Ubuntu-20.04", configRemote }
            };

            var configBase = new ConfigBaseMock(@"C:\user\foo\code", remoteDict);
            var openPath = new OpenPathMock("wsl", "Ubuntu-20.04", @"\\wsl.localhost\Ubuntu-20.04\home\foo\develop", true);
            var cg = new CommandGenerator(openPath, configBase);

            var actual = cg.GenerateCommand();
            Assert.Equal(3, actual.Count());
            Assert.Equal("--remote", actual[0]);
            Assert.Equal(@"wsl+Ubuntu-20.04", actual[1]);
            Assert.Equal(@"/home/foo/develop", actual[2]);
        }

        [Theory]
        [InlineData(@"\\wsl$\Ubuntu-20.04")]
        [InlineData(@"\\wsl$\Ubuntu-20.04\")]
        public void Return_RemoteLegacyWslCommand(string explorePrefix) {
            var configRemote = new ConfigRemoteMock(explorePrefix, "");
            var remoteDict = new Dictionary<string, IConfigRemote> {
                { "Ubuntu-20.04", configRemote }
            };

            var configBase = new ConfigBaseMock(@"C:\user\foo\code", remoteDict);
            var openPath = new OpenPathMock("wsl", "Ubuntu-20.04", @"\\wsl$\Ubuntu-20.04\home\foo\develop", true);
            var cg = new CommandGenerator(openPath, configBase);

            var actual = cg.GenerateCommand();
            Assert.Equal(3, actual.Count());
            Assert.Equal("--remote", actual[0]);
            Assert.Equal(@"wsl+Ubuntu-20.04", actual[1]);
            Assert.Equal(@"/home/foo/develop", actual[2]);
        }
    }
}
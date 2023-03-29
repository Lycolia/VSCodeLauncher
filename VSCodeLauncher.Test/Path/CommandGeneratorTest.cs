using VSCodeLauncher.Lib.CommandLineParser;
using VSCodeLauncher.Lib.Config;
using VSCodeLauncher.Lib.Util;

namespace VSCodeLauncher.Test.Path {
    public class CommandGeneratorTest {

        [Fact]
        public void TestCommandGenerator() {
            var configRemote = new ConfigRemote("", "");
            var remoteDict = new Dictionary<string, ConfigRemote>();
            remoteDict.Add("test", configRemote);

            var configBase = new ConfigBase(@"C:\user\foo\code", remoteDict);
            var openPath = new OpenPath("", "", @"C:\user\foo\desktop\example");
            var actual = new CommandGenerator(openPath, configBase);

            Assert.True(actual.OpenPath.Equals(openPath));
            Assert.True(actual.Config.Equals(configBase));
        }

        [Fact]
        public void Return_LocalCommand() {
            var configRemote = new ConfigRemote("", "");
            var remoteDict = new Dictionary<string, ConfigRemote> {
                { "test", configRemote }
            };

            var configBase = new ConfigBase(@"C:\user\foo\code", remoteDict);
            var openPath = new OpenPath("", "", @"C:\user\foo\desktop\example");
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
            var configRemote = new ConfigRemote(explorePrefix, appendPrefix);
            var remoteDict = new Dictionary<string, ConfigRemote> {
                { "example.com", configRemote }
            };

            var configBase = new ConfigBase(@"C:\user\foo\code", remoteDict);
            var openPath = new OpenPath("ssh", "example.com", @"\\example.com\develop");
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
            var configRemote = new ConfigRemote(explorePrefix, "");
            var remoteDict = new Dictionary<string, ConfigRemote> {
                { "Ubuntu-20.04", configRemote }
            };

            var configBase = new ConfigBase(@"C:\user\foo\code", remoteDict);
            var openPath = new OpenPath("wsl", "Ubuntu-20.04", @"\\wsl.localhost\Ubuntu-20.04\home\foo\develop");
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
            var configRemote = new ConfigRemote(explorePrefix, "");
            var remoteDict = new Dictionary<string, ConfigRemote> {
                { "Ubuntu-20.04", configRemote }
            };

            var configBase = new ConfigBase(@"C:\user\foo\code", remoteDict);
            var openPath = new OpenPath("wsl", "Ubuntu-20.04", @"\\wsl$\Ubuntu-20.04\home\foo\develop");
            var cg = new CommandGenerator(openPath, configBase);

            var actual = cg.GenerateCommand();
            Assert.Equal(3, actual.Count());
            Assert.Equal("--remote", actual[0]);
            Assert.Equal(@"wsl+Ubuntu-20.04", actual[1]);
            Assert.Equal(@"/home/foo/develop", actual[2]);
        }
    }
}
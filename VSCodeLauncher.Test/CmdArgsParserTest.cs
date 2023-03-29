using VSCodeLauncher.Lib;

namespace VSCodeLauncher.Test {
    public class CmdArgsParserTest {
        [Fact]
        public void ReturnFirstArgs_GetFullPath() {
            var param = new string[] { @"C:\windows", @"C:\user" };
            var actual = CmdArgsParser.GetFullPath(param);

            Assert.Equal(@"C:\user", actual);
        }

        [Fact]
        public void ThrowsException_GetFullPath() {
            var param = new string[] { @"C:\windows" };
            var ex = Assert.Throws<ArgumentException>(() => CmdArgsParser.GetFullPath(param));
            Assert.Equal("Empty command-line arguments. Required specify the path to open in VSCode in the command line argument.", ex.Message);
        }

        [Fact]
        public void ResolveWindowsPath_ResolveOpenPath() {
            var actual = CmdArgsParser.ResolveOpenPath(@"C:\user");

            Assert.Equal("", actual.RemoteType);
            Assert.Equal("", actual.HostName);
            Assert.Equal(@"C:\user", actual.FullPath);
        }

        [Fact]
        public void ResolveWslPath_ResolveOpenPath() {
            var actual = CmdArgsParser.ResolveOpenPath(@"\\wsl.localhost\Ubuntu-20.04\home");

            Assert.Equal("WSL", actual.RemoteType);
            Assert.Equal("Ubuntu-20.04", actual.HostName);
            Assert.Equal(@"\\wsl.localhost\Ubuntu-20.04\home", actual.FullPath);
        }

        [Fact]
        public void ResolveLegacyWslPath_ResolveOpenPath() {
            var actual = CmdArgsParser.ResolveOpenPath(@"\\wsl$\Ubuntu-20.04\home");

            Assert.Equal("WSL", actual.RemoteType);
            Assert.Equal("Ubuntu-20.04", actual.HostName);
            Assert.Equal(@"\\wsl$\Ubuntu-20.04\home", actual.FullPath);
        }

        [Fact]
        public void ResolveSshPath_ResolveOpenPath() {
            var actual = CmdArgsParser.ResolveOpenPath(@"\\example.com\foo");

            Assert.Equal("SSH", actual.RemoteType);
            Assert.Equal("example.com", actual.HostName);
            Assert.Equal(@"\\example.com\foo", actual.FullPath);
        }

        [Fact]
        public void ThrowsException_ResolveOpenPath() {
            var ex = Assert.Throws<ArgumentException>(() => CmdArgsParser.ResolveOpenPath("foo"));
            Assert.Equal("Invalid path format. Required specify UNC path or Windows path as absolute path in command-line arguments.", ex.Message);
        }
    }
}

using VSCodeLauncher.Lib.CommandLineParser;

namespace VSCodeLauncher.Test.CommandLineParser {
    public class CmdArgsResolverTest {
        [Fact]
        public void ReturnFirstArgs_GetOpenPath() {
            var param = new string[] { @"C:\windows", @"C:\user" };
            var actual = CmdArgsParser.GetOpenPath(param);

            Assert.Equal(@"C:\user", actual);
        }

        [Fact]
        public void ThrowsException_GetOpenPath() {
            var param = new string[] { @"C:\windows" };
            var ex = Assert.Throws<ArgumentException>(() => CmdArgsParser.GetOpenPath(param));
            Assert.Equal("Empty command-line arguments. Required specify the path to open in VSCode in the command line argument.", ex.Message);
        }

        [Fact]
        public void ResolveWindowsPath_ResolvePath() {
            var actual = CmdArgsParser.ResolvePath(@"C:\user");
            var expected = new OpenPath(false, @"C:\user");

            Assert.Equal(expected.Type, actual.Type);
            Assert.Equal(expected.Path, actual.Path);
            Assert.Equal(expected.IsRemote, actual.IsRemote);
        }

        [Fact]
        public void ResolveNewWslPath_ResolvePath() {
            var actual = CmdArgsParser.ResolvePath(@"\\example.com\foo");
            var expected = new OpenPath(true, @"\\example.com\foo");

            Assert.Equal(expected.Type, actual.Type);
            Assert.Equal(expected.Path, actual.Path);
            Assert.Equal(expected.IsRemote, actual.IsRemote);
        }

        [Fact]
        public void ResolveSshPath_ResolvePath() {
            var actual = CmdArgsParser.ResolvePath(@"\\example.com\foo");
            var expected = new OpenPath(true, @"\\example.com\foo");

            Assert.Equal(expected.Type, actual.Type);
            Assert.Equal(expected.Path, actual.Path);
            Assert.Equal(expected.IsRemote, actual.IsRemote);
        }

        [Fact]
        public void ThrowsException_ResolvePath() {
            var param = new string[] { @"C:\windows" };
            var ex = Assert.Throws<ArgumentException>(() => CmdArgsParser.GetOpenPath(param));
            Assert.Equal("Empty command-line arguments. Required specify the path to open in VSCode in the command line argument.", ex.Message);
        }
    }
}

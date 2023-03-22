using VSCodeLauncher.Lib.CommandLineParser;

namespace VSCodeLauncher.Test.CommandLineParser {
    public class OpenPathTest {
        [Fact]
        public void IsRemote_False() {
            var path = new OpenPath(false, @"\\example.com\foo");

            Assert.False(path.IsRemote);
        }

        [Fact]
        public void IsRemote_True() {
            var path = new OpenPath(true, @"C:\windows");

            Assert.True(path.IsRemote);
        }

        [Fact]
        public void GetPath() {
            var path = new OpenPath(false, @"C:\windows");

            Assert.Equal(@"C:\windows", path.Path);
        }


        [Fact]
        public void WSL_Type_new() {
            var path = new OpenPath(false, @"\\wsl.localhost\Ubuntu-20.04\home\foo");

            Assert.Equal("WSL", path.Type);
        }

        [Fact]
        public void WSL_Type_legacy() {
            var path = new OpenPath(false, @"\\wsl$\Ubuntu-20.04\home\foo");

            Assert.Equal("WSL", path.Type);
        }

        [Fact]
        public void SSH_Type_With_Domain() {
            var path = new OpenPath(false, @"\\example.com\foo");

            Assert.Equal("SSH", path.Type);
        }

        [Fact]
        public void SSH_Type_With_Ip() {
            var path = new OpenPath(false, @"\\127.0.0.1\foo");

            Assert.Equal("SSH", path.Type);
        }
    }
}

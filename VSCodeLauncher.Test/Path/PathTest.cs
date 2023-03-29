using VSCodeLauncher.Lib.Util;

namespace VSCodeLauncher.Test.Util {
    public class PathUtilTest {

        [Theory]
        [InlineData('\\', @"C:\users\foo", @"desktop\bar", @"C:\users\foo\desktop\bar")]
        [InlineData('\\', @"C:\users\foo\", @"desktop\bar", @"C:\users\foo\desktop\bar")]
        [InlineData('\\', @"C:\users\foo", @"\desktop\bar", @"C:\users\foo\desktop\bar")]
        [InlineData('\\', @"C:\users\foo\", @"\desktop\bar", @"C:\users\foo\desktop\bar")]
        [InlineData('/', @"/home/foo", @"desktop/bar", @"/home/foo/desktop/bar")]
        [InlineData('/', @"/home/foo/", @"desktop/bar", @"/home/foo/desktop/bar")]
        [InlineData('/', @"/home/foo", @"/desktop/bar", @"/home/foo/desktop/bar")]
        [InlineData('/', @"/home/foo/", @"/desktop/bar", @"/home/foo/desktop/bar")]
        public void JoinTest(char separator, string path1, string path2, string expected) {
            var actual = PathUtil.Join(separator, path1, path2);

            Assert.Equal(expected, actual);
        }
    }
}

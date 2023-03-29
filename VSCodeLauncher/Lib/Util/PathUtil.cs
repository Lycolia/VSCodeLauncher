using System.Text.RegularExpressions;

namespace VSCodeLauncher.Lib.Util {
    public class PathUtil {
        public static string Join(char separator, string path1, string path2) {
            var regexSafeSeparator = separator == '\\' ? @"\\" : "/";
            var pathFirst = Regex.Replace(path1, $"{regexSafeSeparator}$", "");
            var pathSecond = Regex.Replace(path2, $"^{regexSafeSeparator}", "");
            return $"{pathFirst}{separator}{pathSecond}";
        }
    }
}

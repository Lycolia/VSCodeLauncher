using System.Text.RegularExpressions;

namespace VSCodeLauncher.Lib.CommandLineParser {
    public static class CmdArgsParser {
        public static string GetFullPath(string[] cmdArgs) {
            if (cmdArgs.Length < 2) {
                throw new ArgumentException("Empty command-line arguments. Required specify the path to open in VSCode in the command line argument.");
            }

            return cmdArgs[1];
        }

        public static OpenPath ResolveOpenPath(string fullPath) {
            var uncPathPattern = new Regex(@"^\\\\([^\\]+?)\\");
            var uncMatch = uncPathPattern.Match(fullPath);

            var windowsPathPattern = new Regex(@"^[A-Z]:\\");

            if (windowsPathPattern.IsMatch(fullPath)) {
                return new OpenPath(false, fullPath, "");
            } else if (uncMatch.Success && uncMatch.Groups.Count == 2) {
                return new OpenPath(true, fullPath, uncMatch.Groups[1].Value);
            } else {
                throw new ArgumentException("Invalid path format. Required specify UNC path or Windows path as absolute path in command-line arguments.");
            }
        }
    }
}

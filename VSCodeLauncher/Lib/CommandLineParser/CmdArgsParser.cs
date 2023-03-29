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
            if (Regex.IsMatch(fullPath, @"^[A-Z]:\\")) {
                // Windows
                return new OpenPath("", "", fullPath);
            }

            var wslPathMat = Regex.Match(fullPath, @"^\\\\wsl\.[^\\]+\\([^\\]+)");
            if (wslPathMat.Success && wslPathMat.Groups.Count == 2) {
                // \\wsl.localhost\<Distro-name>
                return new OpenPath("WSL", wslPathMat.Groups[1].Value, fullPath);
            }

            var wslLegacyPathMat = Regex.Match(fullPath, @"^\\\\wsl\$\\([^\\]+)");
            if (wslLegacyPathMat.Success && wslLegacyPathMat.Groups.Count == 2) {
                // \\wsl$\<Distro-name>
                return new OpenPath("WSL", wslLegacyPathMat.Groups[1].Value, fullPath);
            }

            var sshPathMat = Regex.Match(fullPath, @"^\\\\([^\\]+?)\\");
            if (sshPathMat.Success && sshPathMat.Groups.Count == 2) {
                // other
                return new OpenPath("SSH", sshPathMat.Groups[1].Value, fullPath);
            }

            // invalid path
            throw new ArgumentException("Invalid path format. Required specify UNC path or Windows path as absolute path in command-line arguments.");
        }
    }
}

namespace VSCodeLauncher.Lib.CommandLineParser {
    public class OpenPath {
        public bool IsRemote { get; }

        public string Path { get; }

        public string HostName { get; }

        public OpenPath(bool isRemote, string path, string hostName) {
            this.IsRemote = isRemote;
            this.Path = path;
            this.HostName = hostName;
        }
    }
}

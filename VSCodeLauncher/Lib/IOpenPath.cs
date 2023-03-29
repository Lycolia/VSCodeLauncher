namespace VSCodeLauncher.Lib {
    public interface IOpenPath {
        public string RemoteType { get; }

        public string HostName { get; }

        public string FullPath { get; }

        public bool IsRemote { get; }
    }
}

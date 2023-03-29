using VSCodeLauncher.Lib;

namespace VSCodeLauncher.Test {
    public class OpenPathMock : IOpenPath {
        public string RemoteType { get; }

        public string HostName { get; }

        public string FullPath { get; }

        public bool IsRemote { get; }

        public OpenPathMock(string remoteType, string hostName, string fullPath, bool isRemote) {
            this.RemoteType = remoteType;
            this.HostName = hostName;
            this.FullPath = fullPath;
            this.IsRemote = isRemote;
        }
    }
}

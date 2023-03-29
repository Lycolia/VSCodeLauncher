﻿namespace VSCodeLauncher.Lib.CommandLineParser {
    public class OpenPath {
        /// <summary>
        /// "" | "ssh" | "wsl"
        /// </summary>
        public string RemoteType { get; }

        public string HostName { get; }

        public string FullPath { get; }

        public OpenPath(string remoteType, string hostName, string fullPath) {
            this.RemoteType = remoteType;
            this.HostName = hostName;
            this.FullPath = fullPath;
        }

        public bool IsRemote {
            get {
                return this.RemoteType == "ssh" || this.RemoteType == "wsl";
            }
        }
    }
}

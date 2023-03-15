namespace VSCodeLauncher {
    public class ConfigHost {
        /// <summary>
        /// SSH | WSL
        /// </summary>
        public string? Type { get; set; }
        /// <summary>
        /// example.com | WSL host name
        /// </summary>
        public string? HostName { get; set; }
        /// <summary>
        /// UNC path prefix
        /// </summary>
        public string? ExplorerPrefix { get; set; }
        /// <summary>
        /// /home/
        /// </summary>
        public string? AppendPrefix { get; set; }
    }
}

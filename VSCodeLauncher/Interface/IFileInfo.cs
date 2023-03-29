namespace VSCodeLauncher.Interface {
    public interface IFileInfo {
        string FullName { get; }
        bool Exists { get; }
    }
}

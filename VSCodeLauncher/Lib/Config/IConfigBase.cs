namespace VSCodeLauncher.Lib.Config {
    public interface IConfigBase {
        string CodePath { get; }
        IDictionary<string, IConfigRemote> Remote { get; }
    }
}

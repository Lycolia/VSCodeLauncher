namespace VSCodeLauncher.Lib.CommandGenerator {
    public class CommandContext {
        public string CodePath { get; }
        public string RemoteType { get; }
        public string RemoteHost { get; }
        public string CodePath { get; }
        public string CodePath { get; }

        public CommandContext(string codePath, List<string> ArgumentsList) {
            this.CodePath = codePath;
            this.ArgumentsList = ArgumentsList;
        }
    }
}

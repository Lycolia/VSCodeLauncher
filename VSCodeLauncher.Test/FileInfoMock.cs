using VSCodeLauncher.Interface;

namespace VSCodeLauncher.Test {
    public class FileInfoMock : IFileInfo {
        public string FullName { get; }
        public bool Exists { get; }

        public FileInfoMock(string fullName, bool exists) {
            this.FullName = fullName;
            this.Exists = exists;
        }
    }
}

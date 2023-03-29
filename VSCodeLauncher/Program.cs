using System.Diagnostics;
using VSCodeLauncher.Lib;
using VSCodeLauncher.Lib.Config;
/**
* usage
*   VSCodeLauncher.exe path\to\config.json <FULL_PATH>
*  
* TODO
*   configのパス指定
*   自動テスト
*   Windows, WSL, SSHの動作確認
* 
*/

var cmdArgs = Environment.GetCommandLineArgs();
var fullPath = CmdArgsParser.GetFullPath(cmdArgs);
var op = CmdArgsParser.ResolveOpenPath(fullPath);
if (op == null) {
    throw new Exception("");
}

var config = ConfigFile.LoadConfig("config.json");
if (config == null) {
    throw new Exception("");
}

var cg = new CommandGenerator(op, config);
if (cg == null) {
    throw new Exception("");
}

var psi = new ProcessStartInfo();
psi.FileName = config.CodePath;
psi.WindowStyle = ProcessWindowStyle.Hidden;

foreach (var argv in cg.GenerateCommand()) {
    psi.ArgumentList.Add(argv);
}

Process.Start(psi);


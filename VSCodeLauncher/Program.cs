using System.Diagnostics;
using VSCodeLauncher.Lib;
using VSCodeLauncher.Lib.Config;
/**
* usage
*   VSCodeLauncher.exe <FULL_PATH>
*/

var cmdArgs = Environment.GetCommandLineArgs();
var fullPath = CmdArgsParser.GetFullPath(cmdArgs);
var op = CmdArgsParser.ResolveOpenPath(fullPath);
if (op == null) {
    // ここに来ることはない
    // 例外が投げられてルートでキャッチされて勝手に死ぬ想定
    return;
}

var config = ConfigFile.LoadConfig("config.json");
if (config == null) {
    // ここに来ることはない
    // 例外が投げられてルートでキャッチされて勝手に死ぬ想定
    return;
}

var cg = new CommandGenerator(op, config);
if (cg == null) {
    // ここに来ることはない
    // 例外が投げられてルートでキャッチされて勝手に死ぬ想定
    return;
}

var psi = new ProcessStartInfo();
psi.FileName = config.CodePath;
psi.WindowStyle = ProcessWindowStyle.Hidden;

foreach (var argv in cg.GenerateCommand()) {
    psi.ArgumentList.Add(argv);
}

Process.Start(psi);


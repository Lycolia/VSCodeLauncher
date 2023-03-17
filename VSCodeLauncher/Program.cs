using VSCodeLauncher.Lib.Config;

/**
 * 処理
 * 
 * config.jsonをロード
 *  ファイルがなければエラー
 *  フォーマット不正もエラー
 * フルパスがUNCパスでなければローカル
 *  codeを普通に蹴る
 * UNCであればリモート
 *  <config.type>を見る
 *      SSHならssh-remote+<config.hostName>
 *      WSLならwsl+<config.hostName>
 * フルパス先頭から<config.explorerPrefix>を削る
 * フルパス先頭に<appendPrefix>を足す
 * 以下の方式でcodeを蹴る
 * <config.CodePath> <MODE+HOST_NAME> <FULL_PATH>
 * 
 * このアプリ自体は以下の形式で蹴る
 *  VSCodeLauncher.exe path\to\config.json <FULL_PATH>
 * 
 */

var cmdArgs = Environment.GetCommandLineArgs();
try {
    var configFile = ConfigFile.LoadConfig("./config.json");
    if (configFile != null) {

    }
} catch (Exception ex) {
    Console.WriteLine(ex);
}
var t = configFile.Config;

// UNCパス判定
// 起動コマンド生成
// 起動

Console.WriteLine("");

//var cmdArgs = Environment.GetCommandLineArgs();

//var CodeBinPath = cmdArgs[1];
///**
// * ssh-remote+<remoteHost>
// * wsl+<distro name>
// */
//var OpenMode = cmdArgs[2];
//var RemotePathPrefix = cmdArgs[3];
//var FullPath = cmdArgs[4];

//var RegEscapedRemotePathPrefix = Regex.Escape(RemotePathPrefix);
//var IsRemotePath = Regex.IsMatch(FullPath, $"^{RegEscapedRemotePathPrefix}");


//var psi = new ProcessStartInfo();
//psi.FileName = CodeBinPath;
//psi.WindowStyle = ProcessWindowStyle.Hidden;

//Console.WriteLine(CodeBinPath);
//Console.WriteLine(OpenMode);
//Console.WriteLine(RemotePathPrefix);
//Console.WriteLine(FullPath);

//if (IsRemotePath) {

//    // open with WSL
//    var wslPath = Regex.Replace(FullPath, $"^{RegEscapedRemotePathPrefix}", "");
//    Console.WriteLine("wslPath" + wslPath);
//    Console.ReadLine();

//    psi.ArgumentList.Add("--remote");
//    psi.ArgumentList.Add(OpenMode);
//    psi.ArgumentList.Add(wslPath.Replace(@"\", "/"));
//    Process.Start(psi);
//} else {
//    // open with Windows
//    psi.ArgumentList.Add(FullPath);
//    Process.Start(psi);
//}


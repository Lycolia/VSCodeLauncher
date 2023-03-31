# VSCodeLauncher

VSCode でリモートのパスを開く時の面倒臭さを少し解決するツールです。

以下のスクリーンショットのように、Explorer の右クリックメニューからリモート環境を開くとリモートモードで VSCode を起動することが出来ます。Windows ローカル環境を開く場合はそのまま開きます。

![image](https://user-images.githubusercontent.com/33796432/228558077-9042e45c-6106-4a0d-9997-e0d8d483663d.png)

## 動作確認環境

リモート環境を開く場合は対応した拡張機能が必要です。

| 環境                                                                                                      | バージョン        |
| --------------------------------------------------------------------------------------------------------- | ----------------- |
| Windows 11 Pro 64bit 版                                                                                   | 22621.1413        |
| Visual Studio Code                                                                                        | 1.76.2            |
| 拡張機能：[Remote - SSH](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-ssh) | v0.101.2023032815 |
| 拡張機能：[WSL](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-wsl)          | v0.76.1           |

## 対応しているパス形式

| 環境    | パス形式                                        | 備考                                                                     |
| ------- | ----------------------------------------------- | ------------------------------------------------------------------------ |
| Windows | `C:\Users\foo\Desktop`                          | ドライブレターがついてないのは開けません。                               |
| SSH     | `\\example.com\foo\desktop`                     | samba のパスを開くことを想定してます。ホスト部分は IP でもいけます。多分 |
| WSL     | `\\wsl.localhost\Ubuntu-20.04\home\foo\desktop` | 新しい WSL のパス形式です。                                              |
| WSL     | `\\wsl$\Ubuntu-20.04\home\foo\desktop`          | 古い WSL パス形式です。環境がないので動作確認してません                  |

## インストール方法

1. [release ページ](https://github.com/Lycolia/VSCodeLauncher/releases)から zip を落とすか、ソースコードを落として VisualStudio でビルドする
    1. Visual Studio 2022 でビルド確認してます
2. 適当なパスに展開する
3. 以下のレジストリキーに `"C:\path\to\VSCodeLauncher.exe" "%V"` を追加する
    - `\HKEY_CLASSES_ROOT\Directory\shell\VSCode\command`
    - `\HKEY_CLASSES_ROOT\Directory\Background\shell\VSCode\command`
4. `config.json` を設定する

### `config.json` フォーマット

-   このファイルは Explorer 上のパスと実際に開くパスの差分を解決するためにあります。
    -   やってることは Explorer から取得したパスをそれぞれの環境向けに変換して VSCode に渡してるだけです。
-   `\` は `\\` でエスケープして記述します。

<!--prettier-ignore-->
```jsonc
{
  // VSCodeのexeパスを指定します
  "CodePath": "C:\\Users\\<your-name>\\AppData\\Local\\Programs\\Microsoft VS Code\\Code.exe",
  // リモート環境の設定。KEY VALUE形式です。
  "Remote": {
    // WSLの場合、ディストリビューション名をキーに指定します
    "Ubuntu-20.04": {
      // 先頭の不要なパスを除外する設定です
      //   例えばExplorer上は以下だが
      //   \\wsl.localhost\Ubuntu-20.04\home\foo\desktop
      //   実際は以下を開きたい場合
      //   \home\foo\desktop
      //   以下のように指定することで開くことが出来ます
      //   \\\\wsl.localhost\\Ubuntu-20.04\\
      "ExplorerPrefix": "\\\\wsl.localhost\\Ubuntu-20.04\\",
      // 先頭に必要なパスを追記する設定です
      //   WSLの場合は空文字で大丈夫です
      "AppendPrefix": ""
    },
    // SSHの場合、UNCパスの頭についてるホスト名を指定します
    "example.com": {
      // 先頭の不要なパスを除外する設定です
      //   例えばExplorer上は以下だが
      //   \\example.com\foo\desktop
      //   実際は以下を開きたい場合
      //   \home\foo\desktop
      //   以下のように指定することで開くことが出来ます
      //   \\\\example.com\\
      "ExplorerPrefix": "\\\\example.com\\",
      // 先頭に必要なパスを追記する設定です。ディレクトリの区切りは \ でなく / で書きます。
      //   ExplorerPrefixだけでは foo/desktop を開いてしまうので
      //   こちらの内容を足して /home/foo/desktop になるようにします
      "AppendPrefix": "/home/"
    }
  }
}
```

## 作った理由

毎回ここからリモート環境を選んだり、ここになかったら頑張ってディレクトリ開く手間があり、面倒だったため。Explorer からやったほうが直感的で早い。
![image](https://user-images.githubusercontent.com/33796432/228574556-2b2a31a6-b3d5-46a2-afc4-bd1997fe962e.png)

WSL のパス開いたときは一応 WSL 拡張で開くか聞いてくれるのですが、SSH だと聞いてくれないので、そこを解消する目的もありました。

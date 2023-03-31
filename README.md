# VSCodeLauncher

VSCode �Ń����[�g�̃p�X���J�����̖ʓ|�L����������������c�[���ł��B

�ȉ��̃X�N���[���V���b�g�̂悤�ɁAExplorer �̉E�N���b�N���j���[���烊���[�g�����J���ƃ����[�g���[�h�� VSCode ���N�����邱�Ƃ��o���܂��BWindows ���[�J�������J���ꍇ�͂��̂܂܊J���܂��B

![image](https://user-images.githubusercontent.com/33796432/228558077-9042e45c-6106-4a0d-9997-e0d8d483663d.png)

## ����m�F��

�����[�g�����J���ꍇ�͑Ή������g���@�\���K�v�ł��B

| ��                                                                                                      | �o�[�W����        |
| --------------------------------------------------------------------------------------------------------- | ----------------- |
| Windows 11 Pro 64bit ��                                                                                   | 22621.1413        |
| Visual Studio Code                                                                                        | 1.76.2            |
| �g���@�\�F[Remote - SSH](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-ssh) | v0.101.2023032815 |
| �g���@�\�F[WSL](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-wsl)          | v0.76.1           |

## �Ή����Ă���p�X�`��

| ��    | �p�X�`��                                        | ���l                                                                     |
| ------- | ----------------------------------------------- | ------------------------------------------------------------------------ |
| Windows | `C:\Users\foo\Desktop`                          | �h���C�u���^�[�����ĂȂ��̂͊J���܂���B                               |
| SSH     | `\\example.com\foo\desktop`                     | samba �̃p�X���J�����Ƃ�z�肵�Ă܂��B�z�X�g������ IP �ł������܂��B���� |
| WSL     | `\\wsl.localhost\Ubuntu-20.04\home\foo\desktop` | �V���� WSL �̃p�X�`���ł��B                                              |
| WSL     | `\\wsl$\Ubuntu-20.04\home\foo\desktop`          | �Â� WSL �p�X�`���ł��B�����Ȃ��̂œ���m�F���Ă܂���                  |

## �C���X�g�[�����@

1. [release �y�[�W](https://github.com/Lycolia/VSCodeLauncher/releases)���� zip �𗎂Ƃ����A�\�[�X�R�[�h�𗎂Ƃ��� VisualStudio �Ńr���h����
    1. Visual Studio 2022 �Ńr���h�m�F���Ă܂�
2. �K���ȃp�X�ɓW�J����
3. �ȉ��̃��W�X�g���L�[�� `"C:\path\to\VSCodeLauncher.exe" "%V"` ��ǉ�����
    - `\HKEY_CLASSES_ROOT\Directory\shell\VSCode\command`
    - `\HKEY_CLASSES_ROOT\Directory\Background\shell\VSCode\command`
4. `config.json` ��ݒ肷��

### `config.json` �t�H�[�}�b�g

-   ���̃t�@�C���� Explorer ��̃p�X�Ǝ��ۂɊJ���p�X�̍������������邽�߂ɂ���܂��B
    -   ����Ă邱�Ƃ� Explorer ����擾�����p�X�����ꂼ��̊������ɕϊ����� VSCode �ɓn���Ă邾���ł��B
-   `\` �� `\\` �ŃG�X�P�[�v���ċL�q���܂��B

<!--prettier-ignore-->
```jsonc
{
  // VSCode��exe�p�X���w�肵�܂�
  "CodePath": "C:\\Users\\<your-name>\\AppData\\Local\\Programs\\Microsoft VS Code\\Code.exe",
  // �����[�g���̐ݒ�BKEY VALUE�`���ł��B
  "Remote": {
    // WSL�̏ꍇ�A�f�B�X�g���r���[�V���������L�[�Ɏw�肵�܂�
    "Ubuntu-20.04": {
      // �擪�̕s�v�ȃp�X�����O����ݒ�ł�
      //   �Ⴆ��Explorer��͈ȉ�����
      //   \\wsl.localhost\Ubuntu-20.04\home\foo\desktop
      //   ���ۂ͈ȉ����J�������ꍇ
      //   \home\foo\desktop
      //   �ȉ��̂悤�Ɏw�肷�邱�ƂŊJ�����Ƃ��o���܂�
      //   \\\\wsl.localhost\\Ubuntu-20.04\\
      "ExplorerPrefix": "\\\\wsl.localhost\\Ubuntu-20.04\\",
      // �擪�ɕK�v�ȃp�X��ǋL����ݒ�ł�
      //   WSL�̏ꍇ�͋󕶎��ő��v�ł�
      "AppendPrefix": ""
    },
    // SSH�̏ꍇ�AUNC�p�X�̓��ɂ��Ă�z�X�g�����w�肵�܂�
    "example.com": {
      // �擪�̕s�v�ȃp�X�����O����ݒ�ł�
      //   �Ⴆ��Explorer��͈ȉ�����
      //   \\example.com\foo\desktop
      //   ���ۂ͈ȉ����J�������ꍇ
      //   \home\foo\desktop
      //   �ȉ��̂悤�Ɏw�肷�邱�ƂŊJ�����Ƃ��o���܂�
      //   \\\\example.com\\
      "ExplorerPrefix": "\\\\example.com\\",
      // �擪�ɕK�v�ȃp�X��ǋL����ݒ�ł��B�f�B���N�g���̋�؂�� \ �łȂ� / �ŏ����܂��B
      //   ExplorerPrefix�����ł� foo/desktop ���J���Ă��܂��̂�
      //   ������̓��e�𑫂��� /home/foo/desktop �ɂȂ�悤�ɂ��܂�
      "AppendPrefix": "/home/"
    }
  }
}
```

## ��������R

���񂱂����烊���[�g����I�񂾂�A�����ɂȂ�������撣���ăf�B���N�g���J����Ԃ�����A�ʓ|���������߁BExplorer ���������ق��������I�ő����B
![image](https://user-images.githubusercontent.com/33796432/228574556-2b2a31a6-b3d5-46a2-afc4-bd1997fe962e.png)

WSL �̃p�X�J�����Ƃ��͈ꉞ WSL �g���ŊJ���������Ă����̂ł����ASSH ���ƕ����Ă���Ȃ��̂ŁA��������������ړI������܂����B

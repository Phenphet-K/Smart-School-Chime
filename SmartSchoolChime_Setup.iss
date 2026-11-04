; Script generated for Smart School Chime Setup
#define MyAppName "Smart School Chime"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Phenphet-K"
#define MyAppURL "https://github.com/Phenphet-K/Smart-School-Chime"
#define MyAppExeName "SmartSchoolChime.exe"

[Setup]
AppId={{E6F7A9C2-3B4D-4E8F-9C1A-7D5E8F3B9A1C}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={commonpf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputDir=dist
OutputBaseFilename=SmartSchoolChime_Setup_v1.0.0
SetupIconFile=icon.ico
UninstallDisplayIcon={app}\icon.ico
Compression=lzma2/ultra64
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64compatible
ArchitecturesAllowed=x64compatible
PrivilegesRequired=admin

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"
Name: "firewall"; Description: "Allow Smart School Chime through Windows Firewall for Mobile Broadcast"; GroupDescription: "Network Configuration:"

[Files]
; Copy everything from dist\SmartSchoolChime (including Config, data, Sound, exe, dll, icons)
Source: "dist\SmartSchoolChime\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\icon.ico"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\icon.ico"; Tasks: desktopicon

[Run]
Filename: "netsh.exe"; Parameters: "advfirewall firewall add rule name=""Smart School Chime"" dir=in action=allow program=""{app}\{#MyAppExeName}"" enable=yes"; Flags: runhidden; Tasks: firewall
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[UninstallRun]
Filename: "netsh.exe"; Parameters: "advfirewall firewall delete rule name=""Smart School Chime"""; Flags: runhidden; RunOnceId: "DelFirewallRule"


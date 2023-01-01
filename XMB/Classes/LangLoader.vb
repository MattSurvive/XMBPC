Public Class LangLoader

    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32
    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32

    Public Shared Function INI_ReadValueFromFile(ByVal strSection As String, ByVal strKey As String, ByVal strDefault As String, ByVal strFile As String) As String
        Dim strTemp As String = Space(1024), lLength As Integer
        lLength = GetPrivateProfileString(strSection, strKey, strDefault, strTemp, strTemp.Length, strFile)
        Return (strTemp.Substring(0, lLength))
    End Function

    Public Shared Function INI_WriteValueToFile(ByVal strSection As String, ByVal strKey As String, ByVal strValue As String, ByVal strFile As String) As Boolean
        Return (Not (WritePrivateProfileString(strSection, strKey, strValue, strFile) = 0))
    End Function

    Public Shared Function GetStringOfLang(ByVal Section As String, ByVal Key As String)
        If INI_ReadValueFromFile("System", "Language", "", ".\system\sys.ini") = "Deutsch" Then
            Return INI_ReadValueFromFile(Section, Key, "", ".\languages\DE.ini")
        ElseIf INI_ReadValueFromFile("System", "Language", "", ".\system\sys.ini") = "Français" Then
            Return INI_ReadValueFromFile(Section, Key, "", ".\languages\FR.ini")
        ElseIf INI_ReadValueFromFile("System", "Language", "", ".\system\sys.ini") = "English" Then
            Return INI_ReadValueFromFile(Section, Key, "", ".\languages\EN.ini")
        ElseIf INI_ReadValueFromFile("System", "Language", "", ".\system\sys.ini") = "Letzebuergesch" Then
            Return INI_ReadValueFromFile(Section, Key, "", ".\languages\LU.ini")
        ElseIf INI_ReadValueFromFile("System", "Language", "", ".\system\sys.ini") = "Espagnol" Then
            Return INI_ReadValueFromFile(Section, Key, "", ".\languages\ES.ini")
        ElseIf INI_ReadValueFromFile("System", "Language", "", ".\system\sys.ini") = "Italiano" Then
            Return INI_ReadValueFromFile(Section, Key, "", ".\languages\IT.ini")
        End If
    End Function

    Public Shared Sub ChangeLanguage()
        SetupXMB_SecondPart.MusicStr.Text = GetStringOfLang("Setup", "MusicPath")
        SetupXMB_SecondPart.VidStr.Text = GetStringOfLang("Setup", "VideoPath")
        SetupXMB_SecondPart.PicStr.Text = GetStringOfLang("Setup", "PicturePath")
        SetupXMB_SecondPart.PCStr.Text = GetStringOfLang("Setup", "PCGames")
        SetupXMB_SecondPart.PSStr.Text = GetStringOfLang("Setup", "PSGames")
        SetupXMB_SecondPart.RetroStr.Text = GetStringOfLang("Setup", "RetroGames")
        SetupXMB_SecondPart.SaveGames.Text = GetStringOfLang("Setup", "Save")
        SetupXMB_SecondPart.SaveMedia.Text = GetStringOfLang("Setup", "Save")
        SetupXMB_SecondPart.SavePS2Games.Text = GetStringOfLang("Setup", "Save")
        SetupXMB_SecondPart.SaveRetroGames.Text = GetStringOfLang("Setup", "Save")
        SetupXMB_SecondPart.Text = GetStringOfLang("Setup", "SetupTitle")

        XMB.UsersTxt.Text = GetStringOfLang("XMB", "Users")
        XMB.SettingsTxt.Text = GetStringOfLang("XMB", "Settings")
        XMB.PhotosTxt.Text = GetStringOfLang("XMB", "Photo")
        XMB.MusicTxt.Text = GetStringOfLang("XMB", "Music")
        XMB.VideosTxt.Text = GetStringOfLang("XMB", "Video")
        XMB.GamesTxt.Text = GetStringOfLang("XMB", "Game")
        XMB.BrowserTxt.Text = GetStringOfLang("XMB", "Network")

        XMB.CreateNewUser.Text = GetStringOfLang("XMB", "CreateNewUser")
        XMB.SettingsThemeText.Text = GetStringOfLang("XMB", "SettingsThemeText")
        XMB.SettingsUpdateText.Text = GetStringOfLang("XMB", "SettingsUpdateText")
        XMB.NotificationsT.Text = GetStringOfLang("XMB", "NotificationText") + " v3.0.2"
        XMB.UserLoginName.Text = GetStringOfLang("XMB", "NotLoggedIn")
        XMB.UserDescr.Text = GetStringOfLang("XMB", "PleaseLoginFirst")
        XMB.PoweroffTxt.Text = GetStringOfLang("XMB", "PowerOff")
        XMB.RadioTxt.Text = GetStringOfLang("XMB", "Radio")
        XMB.NotificationTxt.Text = GetStringOfLang("XMB", "UpdateNotification")
        XMB.AddFriendTxt.Text = GetStringOfLang("XMB", "AddFriend")

        DiscExplorer.FilesList.Columns(0).Text = GetStringOfLang("DiscExplorer", "FileName")
        DiscExplorer.FilesList.Columns(1).Text = GetStringOfLang("DiscExplorer", "Type")
        DiscExplorer.FilesList.Columns(2).Text = GetStringOfLang("DiscExplorer", "Compatible")

        DiscExplorer.FilesList.Columns(2).Text = GetStringOfLang("DiscExplorer", "Compatible")

        BackgroundDownload.BackGroundDLTxt.Text = GetStringOfLang("Downloader", "DiscGameName")
        BackgroundDownload.BackGroundAdviceTxt.Text = GetStringOfLang("Downloader", "BackGroundAdviceTxt") + vbNewLine + GetStringOfLang("Downloader", "BackGroundAdviceTxt2")

    End Sub

End Class
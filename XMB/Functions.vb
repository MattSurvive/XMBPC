Imports System.Net
Imports System.IO

Public Class Functions

    Public Shared WithEvents WebCli As New WebClient
    Public Shared WithEvents weclient As WebClient = New WebClient()
    Public Shared WithEvents weclient2 As WebClient = New WebClient()
    Public Shared Package As String
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

    Public Shared Sub LoadP3T(ByVal theme As String)

        Try
            Dim ThemeLoader As New Process()
            ThemeLoader.StartInfo.FileName = ".\tools\p3textractor\p3textractor.exe"
            ThemeLoader.StartInfo.Arguments = """" + theme + """"
            ThemeLoader.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            ThemeLoader.Start()

            ThemeLoader.WaitForExit()

            If ThemeLoader.HasExited Then

                For Each jimmy In Directory.GetFiles(".\extracted." + Path.GetFileName(theme), "*.gim", SearchOption.TopDirectoryOnly)
                    File.Delete(jimmy)
                Next

                XMB.BackgroundImage = Image.FromFile(".\extracted." + Path.GetFileName(theme) + "\hd_2.jpg")
                XMB.Home.Image = Image.FromFile(".\extracted." + Path.GetFileName(theme) + "\icon_user_1.gim.png")
                XMB.Settings.Image = Image.FromFile(".\extracted." + Path.GetFileName(theme) + "\icon_setting_1.gim.png")
                XMB.Pictures.Image = Image.FromFile(".\extracted." + Path.GetFileName(theme) + "\icon_photo_1.gim.png")
                XMB.Musics.Image = Image.FromFile(".\extracted." + Path.GetFileName(theme) + "\icon_music_1.gim.png")
                XMB.Videos.Image = Image.FromFile(".\extracted." + Path.GetFileName(theme) + "\icon_video_1.gim.png")
                XMB.Games.Image = Image.FromFile(".\extracted." + Path.GetFileName(theme) + "\icon_game_1.gim.png")
                XMB.Browser.Image = Image.FromFile(".\extracted." + Path.GetFileName(theme) + "\icon_network_1.gim.png")
                XMB.Friends.Image = Image.FromFile(".\extracted." + Path.GetFileName(theme) + "\icon_friend_1.gim.png")
                XMB.MeUserIco.Image = Image.FromFile(".\extracted." + Path.GetFileName(theme) + "\icon_playermet_1.gim.png")
                XMB.NewUserBox.Image = Image.FromFile(".\extracted." + Path.GetFileName(theme) + "\icon_addfriend_1.gim.png")
                XMB.SettingsTheme.Image = Image.FromFile(".\extracted." + Path.GetFileName(theme) + "\icon_theme_setting_1.gim.png")

                ThemeLoader.Close()

                XMB.Activate()
                XMB.ActiveControl = XMB.Home
                XMB.themechanged = True
                XMB.themepath = ".\extracted." + Path.GetFileName(theme) + "\"
            End If

        Catch ex As Exception
        End Try

    End Sub

End Class
Imports System.IO
Imports System.Net
Imports DiscUtils.Iso9660
Imports System.Text
Imports System.Runtime.InteropServices

Public Class SetupXMB_SecondPart

#Region "FensAnim"

    Private Declare Function AnimateWindow Lib "user32" (ByVal hwnd As Integer, ByVal Time As Integer, ByVal Flags As Integer) As Integer
    Private Const AW_ACTIVATE = &H20000
    Private Const AW_BLEND = &H80000
    Private Const AW_CENTER = &H10
    Private Const AW_SLIDE = &H40000
    Private Const AW_HIDE = &H10000
    Private Const AW_HOR_POSITIVE = &H1
    Private Const AW_HOR_NEGATIVE = &H2
    Private Const AW_VER_POSITIVE = &H4
    Private Const AW_VER_NEGATIVE = &H8
    Private Const WM_PAINT = &HF

    Enum FensAnimArt As Integer
        EINBLENDEN
        AUSBLENDEN
    End Enum

    Enum FensAnimEffekt As Integer
        DIMMEN
        ROLLEN_SEITE
        ROLLEN_MITTE
        SCHIEBEN
    End Enum

    Enum FensAnimRichtung As Integer
        N
        NO
        O
        SO
        S
        SW
        W
        NW
    End Enum

    Private Sub FensAnim(ByVal Fenster As Form, ByVal Art As FensAnimArt, ByVal Effekt As FensAnimEffekt, ByVal Richtung As FensAnimRichtung, ByVal Dauer_ms As Integer)

        ' Fehlerbehandlung aktivieren       
        Try
            Dim Flags As Integer = 0

            ' Flag Ein/Ausblenden
            Select Case Art
                Case FensAnimArt.EINBLENDEN
                    Flags += AW_ACTIVATE
                Case FensAnimArt.AUSBLENDEN
                    Flags += AW_HIDE
            End Select

            ' Effect-Flag addieren
            Select Case Effekt
                Case FensAnimEffekt.ROLLEN_SEITE
                    Flags += 0
                Case FensAnimEffekt.ROLLEN_MITTE
                    Flags += AW_CENTER
                Case FensAnimEffekt.SCHIEBEN
                    Flags += AW_SLIDE
                Case FensAnimEffekt.DIMMEN
                    Flags += AW_BLEND
            End Select

            ' Richtungs-Flags addieren
            Select Case Richtung
                Case FensAnimRichtung.N
                    Flags += AW_VER_NEGATIVE
                Case FensAnimRichtung.NO
                    Flags += AW_VER_NEGATIVE + AW_HOR_POSITIVE
                Case FensAnimRichtung.O
                    Flags += AW_HOR_POSITIVE
                Case FensAnimRichtung.SO
                    Flags += AW_VER_POSITIVE + AW_HOR_POSITIVE
                Case FensAnimRichtung.S
                    Flags += AW_VER_POSITIVE
                Case FensAnimRichtung.SW
                    Flags += AW_VER_POSITIVE + AW_HOR_NEGATIVE
                Case FensAnimRichtung.W
                    Flags += AW_HOR_NEGATIVE
                Case FensAnimRichtung.NW
                    Flags += AW_VER_NEGATIVE + AW_HOR_NEGATIVE
            End Select

            ' Animation ausführen
            ' (Programm/Thread ist solange pausiert)
            AnimateWindow(Fenster.Handle.ToInt32, Dauer_ms, Flags)
        Catch : End Try

        ' sicherheits Fenster anzeigen/verstecken
        ' (falls Animation fehlschlägt!)
        Select Case Art
            Case FensAnimArt.EINBLENDEN
                Fenster.Show()
            Case FensAnimArt.AUSBLENDEN
                Fenster.Hide()
        End Select

        ' sicherheitshalber Neuzeichnen
        ' (um Grafikfehler zu vermeiden)
        Fenster.Refresh()
    End Sub

#End Region

    Private Sub SaveMedia_Click(sender As Object, e As EventArgs) Handles SaveMedia.Click
        Functions.INI_WriteValueToFile("Paths", "MusicPath", MusicPath.Text, ".\media\paths.ini")
        Functions.INI_WriteValueToFile("Paths", "VideoPath", VideosPath.Text, ".\media\paths.ini")
        Functions.INI_WriteValueToFile("Paths", "PicturesPath", PicturesPath.Text, ".\media\paths.ini")

        SaveMedia.Enabled = False
    End Sub

    Private Sub SaveGames_Click(sender As Object, e As EventArgs) Handles SaveGames.Click

        Dim GamesFileWriter As New StreamWriter(".\glist.txt")

        For Each line As String In FirstGamePath.Lines
            If Not line = "" Then
                GamesFileWriter.WriteLine(line)
            End If
        Next

        GamesFileWriter.Close()
        SaveGames.Enabled = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then
            MusicPath.Text = FolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If FolderBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then
            VideosPath.Text = FolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If FolderBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PicturesPath.Text = FolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If FileBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then

            If FileBrowser.SafeFileName.Contains(".url") Then

                Dim SteamGameID As String
                SteamGameID = Functions.INI_ReadValueFromFile("InternetShortcut", "URL", "", FileBrowser.FileName).ToString

                Dim OnlyID As String()
                OnlyID = SteamGameID.Split("/")

                FirstGamePath.AppendText(SteamGameID + ";" + Steamtitle("http://store.steampowered.com/app/" + OnlyID(3)).ToString + vbNewLine)

            ElseIf FileBrowser.SafeFileName.Contains(".exe") Then

                Try

                    Dim GameName As FileVersionInfo = FileVersionInfo.GetVersionInfo(FileBrowser.FileName)
                    FirstGamePath.AppendText(FileBrowser.FileName + ";" + GameName.ProductName.ToString.Replace("(TM)", "") + vbNewLine)

                Catch ex As Exception
                    FirstGamePath.AppendText(FileBrowser.FileName + ";" + FileBrowser.SafeFileName.Replace(".exe", "").ToString + vbNewLine)
                End Try

            End If

        End If
    End Sub

    Private Function GetTitle(ByVal UrlToLoad As String, ByVal Code As String) As String
        Dim uri As New Uri(UrlToLoad)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse
        Dim Title As String = ""
        Dim HTML As String = ""
        Dim TempArray As Array
        Dim Temp As String = ""
        Dim DelimiterA() As String = {"<title>"}
        Dim DelimiterB() As String = {"</title>"}

        Try
            If (uri.Scheme = uri.UriSchemeHttp) Then
                request = HttpWebRequest.Create(uri)
                request.Method = WebRequestMethods.Http.Get
                request.Timeout = 60000
                response = request.GetResponse
                Dim reader As New StreamReader(response.GetResponseStream())
                HTML = reader.ReadToEnd
                response.Close()
            Else
                HTML = ""
            End If

            If HTML <> "" Then
                If (InStr(HTML, "<title>") > 0) And (InStr(HTML, "</title>") > 0) Then
                    TempArray = HTML.Split(DelimiterA, StringSplitOptions.None)
                    Temp = TempArray(1)
                    TempArray = Temp.Split(DelimiterB, StringSplitOptions.None)
                    Title = TempArray(0)
                End If
            End If

            Return Title.Replace("[", "").Replace("]", "").Replace("PAL-Unk", "").Replace("NTSC-U", "").Replace(Code, "").Replace("PAL-G", "").Replace("NTSC-J", "").Replace("NTSC-Unk", "").Replace("PAL-Unk", "").Replace("PAL-M5", "").Replace("PAL-E", "").Replace("PAL-M7", "").Replace("PAL-M4", "").Replace("PAL-F", "").Replace("PAL-S", "")

        Catch ex As Exception
            Return Code.Replace("BOOT2=cdrom0:\", "")
        End Try

    End Function

    Private Function Steamtitle(ByVal UrlToLoad As String) As String
        Dim uri As New Uri(UrlToLoad)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse
        Dim Title As String = ""
        Dim HTML As String = ""
        Dim TempArray As Array
        Dim Temp As String = ""
        Dim DelimiterA() As String = {"<title>"}
        Dim DelimiterB() As String = {"</title>"}

        Try
            If (uri.Scheme = uri.UriSchemeHttp) Then
                request = HttpWebRequest.Create(uri)
                request.Method = WebRequestMethods.Http.Get
                request.Timeout = 60000
                response = request.GetResponse
                Dim reader As New StreamReader(response.GetResponseStream())
                HTML = reader.ReadToEnd
                response.Close()
            Else
                HTML = ""
            End If

            If HTML <> "" Then
                If (InStr(HTML, "<title>") > 0) And (InStr(HTML, "</title>") > 0) Then
                    TempArray = HTML.Split(DelimiterA, StringSplitOptions.None)
                    Temp = TempArray(1)
                    TempArray = Temp.Split(DelimiterB, StringSplitOptions.None)
                    Title = TempArray(0)
                End If
            End If

            Return Title.Replace(" auf Steam", "").Replace(" on Steam", "")

        Catch ex As Exception

        End Try

    End Function

    Private Sub SavePS2Games_Click(sender As Object, e As EventArgs) Handles SavePS2Games.Click
        If SaveGames.Enabled = False Then

            Dim GamesFileWriter As New StreamWriter(".\psgameslist.txt")

            For Each line As String In PS2Files.Lines

                If line.Length > 5 And line.Contains(".iso") Then

                    On Error Resume Next

                    Using isoStream As FileStream = File.Open(line.ToString, FileMode.Open, FileAccess.Read, FileShare.Read)
                        Dim cd As New CDReader(isoStream, True)
                        Dim fileStream As Stream = cd.OpenFile("\system.cnf", FileMode.Open)

                        Dim strb As New StringBuilder()
                        Dim b As Byte() = New Byte(fileStream.Length) {}
                        Dim temp As New UTF8Encoding(True)

                        While fileStream.Read(b, 0, b.Length) > 0
                            strb.Append(temp.GetString(b))
                        End While

                        Dim Code As String = strb.ToString.Split(vbNewLine)(0)
                        Code = Code.Replace("BOOT2 = cdrom0:\", "").Replace("BOOT2=cdrom0:\", "").Replace("_", "-").Replace(";1", "").Replace(".", "")

                        Dim Title As String
                        Title = GetTitle("http://www.sonyindex.com/Pages/" + Code + ".htm", Code)

                        GamesFileWriter.WriteLine(line + ";" + Title)

                    End Using

                ElseIf line.Length > 5 Then

                    Dim fn As String = Path.GetFileNameWithoutExtension(line)

                    GamesFileWriter.WriteLine(line + ";" + fn)

                End If
            Next

            GamesFileWriter.Close()
            SavePS2Games.Enabled = False

        Else
            MsgBox("You forgot to click a SAVE button!")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If NewSelector.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each game In NewSelector.FileNames
                PS2Files.AppendText(game + vbNewLine)
            Next
        End If
    End Sub

    Private Sub SetupXMB_SecondPart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not LangLoader.INI_ReadValueFromFile("System", "Language", "", ".\system\sys.ini") = "English" Then
            LangLoader.ChangeLanguage()
        End If
    End Sub

    Private Sub SaveRetroGames_Click(sender As Object, e As EventArgs) Handles SaveRetroGames.Click
        If SavePS2Games.Enabled = False Then

            Dim GamesFileWriter As New StreamWriter(".\retrogameslist.txt")

            For Each line As String In RetroFiles.Lines
                If Not line = "" Then
                    GamesFileWriter.WriteLine(line)
                End If
            Next

            GamesFileWriter.Close()

            SaveRetroGames.Enabled = False

        Else
            MsgBox("You forgot to click a SAVE button!")
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If FileBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each game In FileBrowser.FileNames
                Dim fn As String = Path.GetFileNameWithoutExtension(game)
                RetroFiles.AppendText(game + ";" + fn + vbNewLine)
            Next
        End If
    End Sub

    Private Sub SaveNintendoGames_Click(sender As Object, e As EventArgs) Handles SaveNintendoGames.Click
        If SaveRetroGames.Enabled = False Then

            Dim GamesFileWriter As New StreamWriter(".\nintendogameslist.txt")

            For Each line As String In RetroFiles.Lines
                If Not line = "" Then
                    GamesFileWriter.WriteLine(line)
                End If
            Next

            GamesFileWriter.Close()

            If MsgBox("You are now ready to use XMBPC!", MsgBoxStyle.OkOnly, "Setup Completed") = MsgBoxResult.Ok Then
                Process.Start("XMBPC.exe")
                StartUpHook.Close()
            End If

        Else
            MsgBox("You forgot to click a SAVE button!")
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If NintendoSelector.ShowDialog() = Windows.Forms.DialogResult.OK Then

            For Each game In NintendoSelector.FileNames
                Dim fn As String = Path.GetFileNameWithoutExtension(game)
                NintendoFiles.AppendText(game + ";" + fn + vbNewLine)
            Next

        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Dim GamesFileWriter As New StreamWriter(".\glist.txt")
        Dim PSGamesFileWriter As New StreamWriter(".\psgameslist.txt")
        Dim RetroGamesFileWriter As New StreamWriter(".\retrogameslist.txt")
        Dim NGamesFileWriter As New StreamWriter(".\nintendogameslist.txt")

        Dim GamesList As New List(Of String)
        Dim PSGamesList As New List(Of String)
        Dim RetroGamesList As New List(Of String)
        Dim NGamesList As New List(Of String)

        For Each Game In AllGamesList.Lines

            If Game.Contains(".exe") Or Game.Contains(".url") Then

                GamesList.Add(Game)

            ElseIf Game.Contains(".iso") Or Game.Contains(".bin") Or Game.Contains(".BIN") Or Game.Contains(".cso") Then

                PSGamesList.Add(Game)

            ElseIf Game.Contains(".gba") Or Game.Contains(".gbc") Or Game.Contains(".gb") Or Game.Contains(".smc") Or Game.Contains(".smd") Or Game.Contains(".nes") Then

                RetroGamesList.Add(Game)

            ElseIf Game.Contains(".nds") Or Game.Contains(".gcm") Or Game.Contains(".ISO") Then

                NGamesList.Add(Game)

            End If

        Next

        For Each line As String In GamesList
            If Not line = "" Then
                GamesFileWriter.WriteLine(line)
            End If
        Next

        GamesFileWriter.Close()

        For Each line As String In PSGamesList
            If Not line = "" Then

                If line.Contains(".iso") Then

                    On Error Resume Next

                    Using isoStream As FileStream = File.Open(line.ToString, FileMode.Open, FileAccess.Read, FileShare.Read)
                        Dim cd As New CDReader(isoStream, True)
                        Dim fileStream As Stream = cd.OpenFile("\system.cnf", FileMode.Open)

                        Dim strb As New StringBuilder()
                        Dim b As Byte() = New Byte(fileStream.Length) {}
                        Dim temp As New UTF8Encoding(True)

                        While fileStream.Read(b, 0, b.Length) > 0
                            strb.Append(temp.GetString(b))
                        End While

                        Dim Code As String = strb.ToString.Split(vbNewLine)(0)
                        Code = Code.Replace("BOOT2 = cdrom0:\", "").Replace("BOOT2=cdrom0:\", "").Replace("_", "-").Replace(";1", "").Replace(".", "")

                        Dim Title As String
                        Title = GetTitle("http://www.sonyindex.com/Pages/" + Code + ".htm", Code)

                        PSGamesFileWriter.WriteLine(line + ";" + Title)

                    End Using

                ElseIf line.Length > 5 Then

                    Dim fn As String = Path.GetFileNameWithoutExtension(line)

                    PSGamesFileWriter.WriteLine(line + ";" + fn)

                End If

            End If
        Next

        PSGamesFileWriter.Close()

        For Each line As String In RetroGamesList
            If Not line = "" Then
                RetroGamesFileWriter.WriteLine(line)
            End If
        Next

        RetroGamesFileWriter.Close()

        For Each line As String In NGamesList
            If Not line = "" Then
                NGamesFileWriter.WriteLine(line)
            End If
        Next

        NGamesFileWriter.Close()

        If MsgBox("You are now ready to use XMBPC!", MsgBoxStyle.OkOnly, "Setup Completed") = MsgBoxResult.Ok Then
            Process.Start("XMBPC.exe")
            StartUpHook.Close()
        End If

    End Sub

    Private Sub BrowseGames_Click(sender As Object, e As EventArgs) Handles BrowseGames.Click

        If FileBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then

            If FileBrowser.SafeFileName.Contains(".url") Then

                For Each game In FileBrowser.FileNames

                    If game.Contains(".url") Then

                        Dim SteamGameID As String
                        SteamGameID = Functions.INI_ReadValueFromFile("InternetShortcut", "URL", "", FileBrowser.FileName).ToString

                        Dim OnlyID As String()
                        OnlyID = SteamGameID.Split("/")

                        AllGamesList.AppendText(SteamGameID + ";" + Steamtitle("http://store.steampowered.com/app/" + OnlyID(3)).ToString + vbNewLine)

                    End If

                Next

            ElseIf FileBrowser.SafeFileName.Contains(".exe") Then

                For Each game In FileBrowser.FileNames

                    If game.Contains(".exe") Then

                        Try

                            Dim GameName As FileVersionInfo = FileVersionInfo.GetVersionInfo(FileBrowser.FileName)
                            AllGamesList.AppendText(FileBrowser.FileName + ";" + GameName.ProductName.ToString.Replace("(TM)", "") + vbNewLine)

                        Catch ex As Exception
                            AllGamesList.AppendText(FileBrowser.FileName + ";" + FileBrowser.SafeFileName.Replace(".exe", "").ToString + vbNewLine)
                        End Try

                    End If

                Next

            ElseIf FileBrowser.SafeFileName.Contains(".nds") Or FileBrowser.SafeFileName.Contains(".gcm") Or FileBrowser.SafeFileName.Contains(".ISO") Then

                For Each game In FileBrowser.FileNames

                    If game.Contains(".nds") Or game.Contains(".gcm") Or game.Contains(".ISO") Then

                        Dim fn As String = Path.GetFileNameWithoutExtension(game)
                        AllGamesList.AppendText(game + ";" + fn + vbNewLine)

                    End If

                Next

            ElseIf FileBrowser.SafeFileName.Contains(".iso") Or FileBrowser.SafeFileName.Contains(".bin") Or FileBrowser.SafeFileName.Contains(".BIN") Or FileBrowser.SafeFileName.Contains(".cso") Then

                For Each game In FileBrowser.FileNames

                    If game.Contains(".iso") Or game.Contains(".bin") Or game.Contains(".BIN") Or game.Contains(".cso") Then

                        AllGamesList.AppendText(FileBrowser.FileName + vbNewLine)

                    End If

                Next

            ElseIf FileBrowser.SafeFileName.Contains(".gba") Or FileBrowser.SafeFileName.Contains(".gbc") Or FileBrowser.SafeFileName.Contains(".gb") Or FileBrowser.SafeFileName.Contains(".smc") Or FileBrowser.SafeFileName.Contains(".smd") Or FileBrowser.SafeFileName.Contains(".nes") Then

                For Each game In FileBrowser.FileNames

                    If game.Contains(".gba") Or game.Contains(".gbc") Or game.Contains(".gb") Or game.Contains(".smc") Or game.Contains(".smd") Or game.Contains(".nes") Then
                        Dim fn As String = Path.GetFileNameWithoutExtension(game)
                        AllGamesList.AppendText(game + ";" + fn + vbNewLine)
                    End If

                Next

            End If

        End If

    End Sub

End Class
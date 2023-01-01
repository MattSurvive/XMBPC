Imports System.IO
Imports System.Net
Imports DiscUtils.Iso9660
Imports System.Text
Imports System.Runtime.InteropServices

Public Class NewSetup_SecondPart

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

    Private Sub MusicPath_MouseClick(sender As Object, e As MouseEventArgs) Handles MusicPath.MouseClick
        If FolderBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then
            MusicPath.Text = FolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub VideosPath_MouseClick(sender As Object, e As MouseEventArgs) Handles VideosPath.MouseClick
        If FolderBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then
            VideosPath.Text = FolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub PicturesPath_MouseClick(sender As Object, e As MouseEventArgs) Handles PicturesPath.MouseClick
        If FolderBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PicturesPath.Text = FolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub AllGamesList_MouseClick(sender As Object, e As MouseEventArgs) Handles AllGamesList.MouseClick

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

    Private Sub ContinueBox_Click(sender As Object, e As EventArgs) Handles ContinueBox.Click

        Functions.INI_WriteValueToFile("Paths", "MusicPath", MusicPath.Text, ".\media\paths.ini")
        Functions.INI_WriteValueToFile("Paths", "VideoPath", VideosPath.Text, ".\media\paths.ini")
        Functions.INI_WriteValueToFile("Paths", "PicturesPath", PicturesPath.Text, ".\media\paths.ini")

        Dim GameName As String

        Dim PCGamesFileWriter As New StreamWriter(".\glist.txt")
        Dim PSGamesFileWriter As New StreamWriter(".\psgameslist.txt")
        Dim RetroGamesFileWriter As New StreamWriter(".\retrogameslist.txt")
        Dim NGamesFileWriter As New StreamWriter(".\nintendogameslist.txt")

        Dim PCGamesList As New List(Of String)
        Dim PSGamesList As New List(Of String)
        Dim RetroGamesList As New List(Of String)
        Dim NGamesList As New List(Of String)

        For Each Game In AllGamesList.Lines

            If Game.Contains(".exe") Or Game.Contains(".url") Then

                PCGamesList.Add(Game)

            ElseIf Game.Contains(".iso") Or Game.Contains(".bin") Or Game.Contains(".BIN") Or Game.Contains(".cso") Then

                PSGamesList.Add(Game)

            ElseIf Game.Contains(".gba") Or Game.Contains(".gbc") Or Game.Contains(".gb") Or Game.Contains(".smc") Or Game.Contains(".smd") Or Game.Contains(".nes") Then

                RetroGamesList.Add(Game)

            ElseIf Game.Contains(".nds") Or Game.Contains(".gcm") Or Game.Contains(".ISO") Then

                NGamesList.Add(Game)

            End If

        Next

        PCGamesFileWriter.WriteLine("Internal-Storage;Playstation Games")
        PCGamesFileWriter.WriteLine("Internal-Storage;Retro Games")
        PCGamesFileWriter.WriteLine("Internal-Storage;Nintendo Games")

        For Each line As String In PCGamesList
            If Not line = "" Then

                'GameName = line.Split(";")(1)
                'Directory.CreateDirectory(".\games\pc").CreateSubdirectory(".\" + GameName)

                'Dim PCGamesFileWriter As New StreamWriter(".\games\pc\" + GameName + "\" + GameName + ".txt")
                PCGamesFileWriter.WriteLine(line)

            End If
        Next

        PCGamesFileWriter.Close()

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

End Class
Imports System.IO
Imports AForge.Controls
Imports System.Runtime.InteropServices

Public Class DiscExplorer

    Dim info As List(Of Joystick.DeviceInfo) = Joystick.GetAvailableDevices
    Dim joy As New Joystick
    <DllImport("user32.dll")> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As Int32) As Short
    End Function

    Public NewFolder As String
    Public LastFolder As String
    Public RootFolder As String

    Private Sub DiscExplorer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        XMB.Enabled = True
    End Sub

    Private Sub ControllerTimer_Tick(sender As Object, e As EventArgs) Handles ControllerTimer.Tick
        Dim status As AForge.Controls.Joystick.Status = joy.GetCurrentStatus

        If status.YAxis = 1 Or GetAsyncKeyState(Keys.Down) Then
            If Not FilesList.Items.Count = 0 Then
                Dim previousSelectedIndex As Integer = FilesList.FocusedItem.Index
                FilesList.Items(previousSelectedIndex + 1).Selected = True
            End If
        ElseIf status.YAxis = -1 Or GetAsyncKeyState(Keys.Up) Then
            If Not FilesList.Items.Count = 0 Then
                Dim previousSelectedIndex As Integer = FilesList.FocusedItem.Index
                FilesList.Items(previousSelectedIndex - 1).Selected = True
            End If
        End If

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button5) And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button6) Or GetAsyncKeyState(Keys.R) And GetAsyncKeyState(Keys.S) Then
            If XMB.CurrentRadioState = "Playing" Then
                XMB.RadioPlayer.close()
                XMB.CurrentRadioState = "Stopped"
            End If
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button5) And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button6) Or GetAsyncKeyState(Keys.R) And GetAsyncKeyState(Keys.P) Then
            If XMB.CurrentRadioState = "Stopped" Then
                XMB.RadioPlayer.URL = XMB.CurrentRadioURL
                XMB.CurrentRadioState = "Playing"
            End If
        End If

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or GetAsyncKeyState(Keys.Enter) Then
            Dim MouseEv As New MouseEventArgs(Windows.Forms.MouseButtons.Left, 2, 1, 1, 1)
            FilesList_MouseDoubleClick(Me, MouseEv)
        End If

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button2) = True Or GetAsyncKeyState(Keys.Escape) Then
            Me.Close()

            XMB.Enabled = True
            XMB.BringToFront()
            XMB.Activate()
            XMB.ActiveControl = XMB.Home
        End If

    End Sub

    Private Sub KeyboardTimer_Tick(sender As Object, e As EventArgs) Handles KeyboardTimer.Tick

        If GetAsyncKeyState(Keys.Down) Then
            If Not FilesList.Items.Count = 0 Then
                Dim previousSelectedIndex As Integer = FilesList.FocusedItem.Index
                FilesList.Items(previousSelectedIndex + 1).Selected = True
            End If
        ElseIf GetAsyncKeyState(Keys.Up) Then
            If Not FilesList.Items.Count = 0 Then
                Dim previousSelectedIndex As Integer = FilesList.FocusedItem.Index
                FilesList.Items(previousSelectedIndex - 1).Selected = True
            End If
        End If

        If GetAsyncKeyState(Keys.R) And GetAsyncKeyState(Keys.S) Then
            If XMB.CurrentRadioState = "Playing" Then
                XMB.RadioPlayer.close()
                XMB.CurrentRadioState = "Stopped"
            End If
        ElseIf GetAsyncKeyState(Keys.R) And GetAsyncKeyState(Keys.P) Then
            If XMB.CurrentRadioState = "Stopped" Then
                XMB.RadioPlayer.URL = XMB.CurrentRadioURL
                XMB.CurrentRadioState = "Playing"
            End If
        End If

        If GetAsyncKeyState(Keys.Enter) Then
            Dim MouseEv As New MouseEventArgs(Windows.Forms.MouseButtons.Left, 2, 1, 1, 1)
            FilesList_MouseDoubleClick(Me, MouseEv)
        End If


        If GetAsyncKeyState(Keys.Escape) Then
            Me.Close()

            XMB.Enabled = True
            XMB.BringToFront()
            XMB.Activate()
            XMB.ActiveControl = XMB.Home
        End If

    End Sub

    Private Sub DiscExplorer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If info.Count = 0 Then
            KeyboardTimer.Start()
        Else
            joy = New Joystick(0)
            ControllerTimer.Start()
        End If

        DiscIco.Image = XMB.SelectedGame.Image
        DiscTitle.Text = XMB.SelectedGame.Tag + " - " + XMB.SelectedGameText.Text

        LastFolder = XMB.SelectedGame.Tag
        RootFolder = XMB.SelectedGame.Tag

        For Each discfile In Directory.GetFiles(XMB.SelectedGame.Tag)
            With FilesList.Items.Add(discfile)
                .SubItems.Add(Path.GetExtension(discfile))
                .SubItems.Add(CheckCompat(discfile))
            End With
        Next

        For Each discfolder In Directory.GetDirectories(XMB.SelectedGame.Tag)
            With FilesList.Items.Add(discfolder)
                .SubItems.Add("Folder")
            End With
        Next

    End Sub

    Private Function CheckCompat(ByVal Fl As String) As String

        If Fl.EndsWith(".exe") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - " + LangLoader.GetStringOfLang("DiscExplorer", "ExecutableFile")
        ElseIf Fl.EndsWith(".msi") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - " + LangLoader.GetStringOfLang("DiscExplorer", "SetupFile")

        ElseIf Fl.EndsWith(".htm") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - " + LangLoader.GetStringOfLang("DiscExplorer", "WithBrowser")
        ElseIf Fl.EndsWith(".html") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - " + LangLoader.GetStringOfLang("DiscExplorer", "WithBrowser")
        ElseIf Fl.EndsWith(".url") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - " + LangLoader.GetStringOfLang("DiscExplorer", "WithBrowser")

        ElseIf Fl.EndsWith(".IFO") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - " + LangLoader.GetStringOfLang("DiscExplorer", "Movie")
        ElseIf Fl.EndsWith(".avi") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - AVI " + LangLoader.GetStringOfLang("DiscExplorer", "Movie")
        ElseIf Fl.EndsWith(".mkv") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - MKV " + LangLoader.GetStringOfLang("DiscExplorer", "Movie")
        ElseIf Fl.EndsWith(".mpeg") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - MPEG " + LangLoader.GetStringOfLang("DiscExplorer", "Movie")
        ElseIf Fl.EndsWith(".mpg") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - MPG " + LangLoader.GetStringOfLang("DiscExplorer", "Movie")
        ElseIf Fl.EndsWith(".mp4") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - MP4 " + LangLoader.GetStringOfLang("DiscExplorer", "Movie")
        ElseIf Fl.EndsWith(".wmv") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - WMV " + LangLoader.GetStringOfLang("DiscExplorer", "Movie")

        ElseIf Fl.EndsWith(".mp3") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - MP3 " + LangLoader.GetStringOfLang("DiscExplorer", "Music")
        ElseIf Fl.EndsWith(".wav") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - WAV " + LangLoader.GetStringOfLang("DiscExplorer", "Music")
        ElseIf Fl.EndsWith(".wma") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - WMA " + LangLoader.GetStringOfLang("DiscExplorer", "Music")
        ElseIf Fl.EndsWith(".flac") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - FLAC " + LangLoader.GetStringOfLang("DiscExplorer", "Music")

        ElseIf Fl.EndsWith(".jpg") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - JPG " + LangLoader.GetStringOfLang("DiscExplorer", "Picture")
        ElseIf Fl.EndsWith(".JPG") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - JPG " + LangLoader.GetStringOfLang("DiscExplorer", "Picture")
        ElseIf Fl.EndsWith(".jpeg") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - JPEG " + LangLoader.GetStringOfLang("DiscExplorer", "Picture")
        ElseIf Fl.EndsWith(".gif") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - GIF " + LangLoader.GetStringOfLang("DiscExplorer", "Picture")
        ElseIf Fl.EndsWith(".png") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - PNG " + LangLoader.GetStringOfLang("DiscExplorer", "Picture")

        ElseIf Fl.EndsWith(".iso") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - " + LangLoader.GetStringOfLang("DiscExplorer", "ButOnly") + " PS2 ISOs"
        ElseIf Fl.EndsWith(".bin") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - " + LangLoader.GetStringOfLang("DiscExplorer", "ButOnly") + " PS1 BINs"
        ElseIf Fl.EndsWith(".cso") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - " + LangLoader.GetStringOfLang("DiscExplorer", "Compressed")

        ElseIf Fl.EndsWith(".gba") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - Gameboy Advance " + LangLoader.GetStringOfLang("DiscExplorer", "Game")
        ElseIf Fl.EndsWith(".gbc") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - Gameboy Color " + LangLoader.GetStringOfLang("DiscExplorer", "Game")
        ElseIf Fl.EndsWith(".gb") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - Gameboy " + LangLoader.GetStringOfLang("DiscExplorer", "Game")
        ElseIf Fl.EndsWith(".nes") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - Nintendo " + LangLoader.GetStringOfLang("DiscExplorer", "Game")
        ElseIf Fl.EndsWith(".smd") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - Sega " + LangLoader.GetStringOfLang("DiscExplorer", "Game")
        ElseIf Fl.EndsWith(".smc") Then
            Return LangLoader.GetStringOfLang("DiscExplorer", "Yes") + " - Super Nintendo " + LangLoader.GetStringOfLang("DiscExplorer", "Game")

        Else
            Return "No - " + LangLoader.GetStringOfLang("DiscExplorer", "NotCompatible")
        End If

    End Function

    Private Sub HandleFile(ByVal Fil As String)

        If Fil.EndsWith(".exe") Then
            Process.Start(Fil)
        ElseIf Fil.EndsWith(".msi") Then
            Process.Start(Fil)

        ElseIf Fil.EndsWith(".htm") Then
            Browser.Show()
            Browser.BringToFront()
            Browser.WebBrowser1.Navigate(Fil)
            Browser.Activate()
        ElseIf Fil.EndsWith(".html") Then
            Browser.Show()
            Browser.BringToFront()
            Browser.WebBrowser1.Navigate(Fil)
            Browser.Activate()
        ElseIf Fil.EndsWith(".url") Then
            Browser.Show()
            Browser.BringToFront()
            Browser.WebBrowser1.Navigate(Fil)
            Browser.Activate()

        ElseIf Fil.EndsWith(".IFO") Then
            XMB.CurrentVideoTrack = Fil
            VideoPlayer.Show()
            VideoPlayer.BringToFront()
        ElseIf Fil.EndsWith(".avi") Then
            XMB.CurrentVideoTrack = Fil
            VideoPlayer.Show()
            VideoPlayer.BringToFront()
        ElseIf Fil.EndsWith(".mkv") Then
            XMB.CurrentVideoTrack = Fil
            VideoPlayer.Show()
            VideoPlayer.BringToFront()
        ElseIf Fil.EndsWith(".mpeg") Then
            XMB.CurrentVideoTrack = Fil
            VideoPlayer.Show()
            VideoPlayer.BringToFront()
        ElseIf Fil.EndsWith(".mpg") Then
            XMB.CurrentVideoTrack = Fil
            VideoPlayer.Show()
            VideoPlayer.BringToFront()
        ElseIf Fil.EndsWith(".mp4") Then
            XMB.CurrentVideoTrack = Fil
            VideoPlayer.Show()
            VideoPlayer.BringToFront()
        ElseIf Fil.EndsWith(".wmv") Then
            XMB.CurrentVideoTrack = Fil
            VideoPlayer.Show()
            VideoPlayer.BringToFront()

        ElseIf Fil.EndsWith(".mp3") Then
            XMB.CurrentMusicTrack = Fil
            MusicPlayer.Show()
            MusicPlayer.BringToFront()
        ElseIf Fil.EndsWith(".wav") Then
            XMB.CurrentMusicTrack = Fil
            MusicPlayer.Show()
            MusicPlayer.BringToFront()
        ElseIf Fil.EndsWith(".wma") Then
            XMB.CurrentMusicTrack = Fil
            MusicPlayer.Show()
            MusicPlayer.BringToFront()
        ElseIf Fil.EndsWith(".flac") Then
            XMB.CurrentMusicTrack = Fil
            MusicPlayer.Show()
            MusicPlayer.BringToFront()

        ElseIf Fil.EndsWith(".jpg") Then
            XMB.CurrentPictureTrack = Fil
            PictureViewer.specialstate = True
            PictureViewer.Show()
            PictureViewer.BringToFront()
        ElseIf Fil.EndsWith(".JPG") Then
            XMB.CurrentPictureTrack = Fil
            PictureViewer.specialstate = True
            PictureViewer.Show()
            PictureViewer.BringToFront()
        ElseIf Fil.EndsWith(".jpeg") Then
            XMB.CurrentPictureTrack = Fil
            PictureViewer.specialstate = True
            PictureViewer.Show()
            PictureViewer.BringToFront()
        ElseIf Fil.EndsWith(".gif") Then
            XMB.CurrentPictureTrack = Fil
            PictureViewer.specialstate = True
            PictureViewer.Show()
            PictureViewer.BringToFront()
        ElseIf Fil.EndsWith(".png") Then
            XMB.CurrentPictureTrack = Fil
            PictureViewer.specialstate = True
            PictureViewer.Show()
            PictureViewer.BringToFront()

        ElseIf Fil.EndsWith(".iso") Then
            XMB.SwitchPCSXPlugin("Plugin")

            XMB.GameSect = "DISC"
            XMB.GameID = 1
            XMB.GameFormat = "PS2"

            XMB.PlayGameIntro()

            XMB.currentgamestate = "ps2"
        ElseIf Fil.EndsWith(".bin") Then
            XMB.GameSect = "DISC"
            XMB.GameID = 1
            XMB.GameFormat = "PSX"

            XMB.PlayGameIntro()

            XMB.currentgamestate = "ps1"
        ElseIf Fil.EndsWith(".cso") Then
            XMB.GameSect = "PS"
            XMB.GameID = 1
            XMB.GameFormat = "CSO"

            XMB.PlayGameIntro()

            XMB.currentgamestate = "psp"

        ElseIf Fil.EndsWith(".gba") Then
            XMB.GameSect = "RETRO"
            XMB.GameID = 1
            XMB.GameFormat = "GBA"

            XMB.PlayGameIntro()

            XMB.currentgamestate = "retro"
        ElseIf Fil.EndsWith(".gbc") Then
            XMB.GameSect = "RETRO"
            XMB.GameID = 1
            XMB.GameFormat = "GBC"

            XMB.PlayGameIntro()

            XMB.currentgamestate = "retro"
        ElseIf Fil.EndsWith(".gb") Then
            XMB.GameSect = "RETRO"
            XMB.GameID = 1
            XMB.GameFormat = "GBC"

            XMB.PlayGameIntro()

            XMB.currentgamestate = "retro"
        ElseIf Fil.EndsWith(".nes") Then
            XMB.GameSect = "RETRO"
            XMB.GameID = 1
            XMB.GameFormat = "NES"

            XMB.PlayGameIntro()

            XMB.currentgamestate = "retro"
        ElseIf Fil.EndsWith(".smd") Then
            XMB.GameSect = "RETRO"
            XMB.GameID = 1
            XMB.GameFormat = "SMD"

            XMB.PlayGameIntro()

            XMB.currentgamestate = "retro"
        ElseIf Fil.EndsWith(".smc") Then
            XMB.GameSect = "RETRO"
            XMB.GameID = 1
            XMB.GameFormat = "SMC"

            XMB.PlayGameIntro()

            XMB.currentgamestate = "retro"

        End If

    End Sub

    Public Sub FilesList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles FilesList.MouseDoubleClick

        If FilesList.FocusedItem.SubItems(1).Text = "Folder" Then

            NewFolder = FilesList.FocusedItem.Text
            LastFolder = Directory.GetParent(FilesList.FocusedItem.Text).FullName

            FilesList.Items.Clear()

            FilesList.Items.Add("..").SubItems.Add("..")

            For Each discfile In Directory.GetFiles(NewFolder)
                With FilesList.Items.Add(discfile)
                    .SubItems.Add(Path.GetExtension(discfile))
                    .SubItems.Add(CheckCompat(discfile))
                End With
            Next

            For Each discfolder In Directory.GetDirectories(NewFolder)
                With FilesList.Items.Add(discfolder)
                    .SubItems.Add("Folder")
                End With
            Next

        ElseIf FilesList.FocusedItem.SubItems(1).Text = ".." Then

            LastFolder = Directory.GetParent(NewFolder).FullName
            NewFolder = LastFolder

            FilesList.Items.Clear()

            If Not RootFolder = LastFolder Then
                FilesList.Items.Add("..").SubItems.Add("..")
            End If

            For Each discfile In Directory.GetFiles(NewFolder)
                With FilesList.Items.Add(discfile)
                    .SubItems.Add(Path.GetExtension(discfile))
                    .SubItems.Add(CheckCompat(discfile))
                End With
            Next

            For Each discfolder In Directory.GetDirectories(NewFolder)
                With FilesList.Items.Add(discfolder)
                    .SubItems.Add("Folder")
                End With
            Next

        ElseIf FilesList.FocusedItem.SubItems(2).Text.Contains("Yes") Or FilesList.FocusedItem.SubItems(2).Text.Contains("Oui") Or FilesList.FocusedItem.SubItems(2).Text.Contains("Ja") Or FilesList.FocusedItem.SubItems(2).Text.Contains("Si") Then
            HandleFile(FilesList.FocusedItem.Text)
        End If


    End Sub

End Class
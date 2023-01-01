Imports HundredMilesSoftware.UltraID3Lib
Imports System.IO
Imports XMBPC.libZPlay

Public Class MusicPlayer

    Dim info As List(Of AForge.Controls.Joystick.DeviceInfo) = AForge.Controls.Joystick.GetAvailableDevices
    Dim joy As New AForge.Controls.Joystick(0)

    Dim myplayer As New ZPlay()
    Dim myplayerstatus As New TStreamStatus
    Dim myplayerposition As New TStreamTime
    Dim myplayerstreaminfo As New TStreamInfo

    Private m_UltraID3 As New UltraID3
    Private m_CurrentPictureFrame As ID3v23PictureFrame
    Private m_PictureTypes As ArrayList
    Private m_FileName As String
    Private m_PictureFrames As ID3FrameCollection
    Private m_PictureIndex As Integer

    Public Sub SetInfos(ByVal MusicFile As String)
        m_UltraID3.Read(MusicFile)
        m_PictureFrames = m_UltraID3.ID3v2Tag.Frames.GetFrames(MultipleInstanceID3v2FrameTypes.ID3v23Picture)
        m_PictureIndex = -1

        If m_PictureFrames.Count > 0 Then
            m_PictureIndex = 0
        End If

        Dim PictureFrameCount As Integer = m_PictureFrames.Count

        If PictureFrameCount > 0 Then

            m_CurrentPictureFrame = CType(m_PictureFrames.Item(m_PictureIndex), ID3v23PictureFrame)

            With m_CurrentPictureFrame
                If m_CurrentPictureFrame.Picture IsNot Nothing Then
                    TrackCover.Image = m_CurrentPictureFrame.Picture
                Else
                    TrackCover.Image = My.Resources.MusicDefault
                End If
            End With

        End If

        TrackName.Text = m_UltraID3.Title
        TrackInfos.Text = m_UltraID3.Artist + " / " + m_UltraID3.Album

    End Sub

    Private Sub MusicPlayer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ControllerInputTimer.Stop()
        myplayer.StopPlayback()
        XMB.Enabled = True
    End Sub

    Private Sub MusicPlayer_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        SetInfos(XMB.CurrentMusicTrack)

        myplayer.OpenFile(XMB.CurrentMusicTrack, TStreamFormat.sfAutodetect)
        myplayer.StartPlayback()
        TrackCount.Text = XMB.currenttrack.ToString + "/" + XMB.musiclist.Count.ToString

        Me.ActiveControl = CurrentPlayStatus
    End Sub

    Private Sub ControllerInputTimer_Tick(sender As Object, e As EventArgs) Handles ControllerInputTimer.Tick
        Dim status As AForge.Controls.Joystick.Status = joy.GetCurrentStatus

        myplayer.GetStatus(myplayerstatus)
        myplayer.GetPosition(myplayerposition)
        myplayer.GetStreamInfo(myplayerstreaminfo)

        If myplayerstatus.fPlay Then

            If CurrentPlayStatus.Focused = True Then
                CurrentPlayStatus.Image = My.Resources.tex_pause_status
            Else
                CurrentPlayStatus.Image = My.Resources.tex_cp_pause
            End If

            CurrentPosition.Text = myplayerposition.hms.hour.ToString("D2") + ":" + myplayerposition.hms.minute.ToString("D2") + ":" + myplayerposition.hms.second.ToString("D2") _
                + " / " + myplayerstreaminfo.Length.hms.hour.ToString("D2") + ":" + myplayerstreaminfo.Length.hms.minute.ToString("D2") + ":" + myplayerstreaminfo.Length.hms.second.ToString("D2")

            TrackProgress.Maximum = myplayerstreaminfo.Length.sec.ToString
            TrackProgress.Value = myplayerposition.sec.ToString

        Else

            If CurrentPlayStatus.Focused = True Then
                CurrentPlayStatus.Image = My.Resources.tex_play_status
            Else
                CurrentPlayStatus.Image = My.Resources.tex_cp_play
            End If

        End If

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button1) = True Then

            If ControlPanel.Visible = True Then
                ControlPanel.Visible = False
                Me.ActiveControl = CurrentPlayStatus
            Else
                ControlPanel.Visible = True
                Me.ActiveControl = PlayButton
            End If

        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button2) = True Then
            
            Me.Close()
        End If

        If CurrentPlayStatus.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Then

            If myplayerstatus.fPlay Then
                myplayer.PausePlayback()
            Else
                myplayer.ResumePlayback()
            End If

        End If

        If status.XAxis = 1 Then
            ControlControlBoxRight()
        ElseIf status.XAxis = -1 Then
            ControlControlBoxLeft()
        End If

        If status.YAxis = 1 Then
            ControlControlBoxBot()
        ElseIf status.YAxis = -1 Then
            ControlControlBoxTop()
        End If

    End Sub

    Private Sub MusicPlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ControllerInputTimer.Start()
    End Sub

    Public Sub ControlControlBoxRight()

        If VolumeButton.Focused = True Then
            Me.ActiveControl = VisualiserButton
        ElseIf VisualiserButton.Focused = True Then
            Me.ActiveControl = PlaylistButton
        ElseIf PlaylistButton.Focused = True Then
            Me.ActiveControl = TrashButton
        ElseIf TrashButton.Focused = True Then
            Me.ActiveControl = InformationsButton
        ElseIf InformationsButton.Focused = True Then
            Me.ActiveControl = VolumeButton
        End If

        If FbackwardsButton.Focused = True Then
            Me.ActiveControl = FforwardButton
        ElseIf FforwardButton.Focused = True Then
            Me.ActiveControl = BackwardsButton
        ElseIf BackwardsButton.Focused = True Then
            Me.ActiveControl = ForwardButton
        ElseIf ForwardButton.Focused = True Then
            Me.ActiveControl = PlayButton
        ElseIf PlayButton.Focused = True Then
            Me.ActiveControl = PauseButton
        ElseIf PauseButton.Focused = True Then
            Me.ActiveControl = StopButton
        ElseIf StopButton.Focused = True Then
            Me.ActiveControl = FbackwardsButton
        End If

        If RepeatButton.Focused = True Then
            Me.ActiveControl = ShuffleButton
        ElseIf ShuffleButton.Focused = True Then
            Me.ActiveControl = RepeatButton
        End If

    End Sub

    Public Sub ControlControlBoxLeft()

        If InformationsButton.Focused = True Then
            Me.ActiveControl = TrashButton
        ElseIf TrashButton.Focused = True Then
            Me.ActiveControl = PlaylistButton
        ElseIf PlaylistButton.Focused = True Then
            Me.ActiveControl = VisualiserButton
        ElseIf VisualiserButton.Focused = True Then
            Me.ActiveControl = VolumeButton
        ElseIf VolumeButton.Focused = True Then
            Me.ActiveControl = InformationsButton
        End If

        If StopButton.Focused = True Then
            Me.ActiveControl = PauseButton
        ElseIf PauseButton.Focused = True Then
            Me.ActiveControl = PlayButton
        ElseIf PlayButton.Focused = True Then
            Me.ActiveControl = ForwardButton
        ElseIf ForwardButton.Focused = True Then
            Me.ActiveControl = BackwardsButton
        ElseIf BackwardsButton.Focused = True Then
            Me.ActiveControl = FforwardButton
        ElseIf FforwardButton.Focused = True Then
            Me.ActiveControl = FbackwardsButton
        ElseIf FbackwardsButton.Focused = True Then
            Me.ActiveControl = StopButton
        End If

        If ShuffleButton.Focused = True Then
            Me.ActiveControl = RepeatButton
        ElseIf RepeatButton.Focused = True Then
            Me.ActiveControl = ShuffleButton
        End If

    End Sub

    Public Sub ControlControlBoxTop()

        If InformationsButton.Focused = True Then
            Me.ActiveControl = ShuffleButton
        ElseIf ShuffleButton.Focused = True Then
            Me.ActiveControl = PlayButton
        ElseIf PlayButton.Focused = True Then
            Me.ActiveControl = TrashButton
        ElseIf TrashButton.Focused = True Then
            Me.ActiveControl = ShuffleButton
        ElseIf PauseButton.Focused = True Then
            Me.ActiveControl = InformationsButton
        ElseIf ForwardButton.Focused = True Then
            Me.ActiveControl = PlaylistButton
        ElseIf PlaylistButton.Focused = True Then
            Me.ActiveControl = ShuffleButton
        ElseIf RepeatButton.Focused = True Then
            Me.ActiveControl = BackwardsButton
        ElseIf BackwardsButton.Focused = True Then
            Me.ActiveControl = VisualiserButton
        ElseIf VisualiserButton.Focused = True Then
            Me.ActiveControl = RepeatButton
        ElseIf FforwardButton.Focused = True Then
            Me.ActiveControl = VolumeButton
        ElseIf VolumeButton.Focused = True Then
            Me.ActiveControl = FforwardButton
        End If

    End Sub

    Public Sub ControlControlBoxBot()

        If ShuffleButton.Focused = True Then
            Me.ActiveControl = TrashButton

        ElseIf TrashButton.Focused = True Then
            Me.ActiveControl = PlayButton

        ElseIf PlayButton.Focused = True Then
            Me.ActiveControl = ShuffleButton

        ElseIf PauseButton.Focused = True Then
            Me.ActiveControl = InformationsButton

        ElseIf InformationsButton.Focused = True Then
            Me.ActiveControl = PauseButton

        ElseIf ForwardButton.Focused = True Then
            Me.ActiveControl = ShuffleButton

        ElseIf PlaylistButton.Focused = True Then
            Me.ActiveControl = ForwardButton

        ElseIf RepeatButton.Focused = True Then
            Me.ActiveControl = VisualiserButton

        ElseIf VisualiserButton.Focused = True Then
            Me.ActiveControl = BackwardsButton

        ElseIf BackwardsButton.Focused = True Then
            Me.ActiveControl = RepeatButton

        ElseIf FforwardButton.Focused = True Then
            Me.ActiveControl = VolumeButton

        ElseIf VolumeButton.Focused = True Then
            Me.ActiveControl = FforwardButton
        End If

    End Sub

#Region "HOVERS"

    Private Sub FbackwardsButton_GotFocus(sender As Object, e As EventArgs) Handles FbackwardsButton.GotFocus
        FbackwardsButton.Image = My.Resources.tex_cp_prev_hover
    End Sub

    Private Sub FforwardButton_GotFocus(sender As Object, e As EventArgs) Handles FforwardButton.GotFocus
        FforwardButton.Image = My.Resources.tex_cp_next_hover
    End Sub

    Private Sub BackwardsButton_GotFocus(sender As Object, e As EventArgs) Handles BackwardsButton.GotFocus
        BackwardsButton.Image = My.Resources.tex_cp_searchb_hover
    End Sub

    Private Sub ForwardButton_GotFocus(sender As Object, e As EventArgs) Handles ForwardButton.GotFocus
        ForwardButton.Image = My.Resources.tex_cp_searchf_hover
    End Sub

    Private Sub InformationsButton_GotFocus(sender As Object, e As EventArgs) Handles InformationsButton.GotFocus
        InformationsButton.Image = My.Resources.tex_cp_showinfo_hover
    End Sub

    Private Sub PauseButton_GotFocus(sender As Object, e As EventArgs) Handles PauseButton.GotFocus
        PauseButton.Image = My.Resources.tex_cp_pause_hover
    End Sub

    Private Sub PlayButton_GotFocus(sender As Object, e As EventArgs) Handles PlayButton.GotFocus
        PlayButton.Image = My.Resources.tex_cp_play_hover
    End Sub

    Private Sub PlaylistButton_GotFocus(sender As Object, e As EventArgs) Handles PlaylistButton.GotFocus
        PlaylistButton.Image = My.Resources.tex_cp_playlist_hover
    End Sub

    Private Sub RepeatButton_GotFocus(sender As Object, e As EventArgs) Handles RepeatButton.GotFocus
        RepeatButton.Image = My.Resources.tex_cp_repeat_hover
    End Sub

    Private Sub ShuffleButton_GotFocus(sender As Object, e As EventArgs) Handles ShuffleButton.GotFocus
        ShuffleButton.Image = My.Resources.tex_cp_shuffle_hover
    End Sub

    Private Sub StopButton_GotFocus(sender As Object, e As EventArgs) Handles StopButton.GotFocus
        StopButton.Image = My.Resources.tex_cp_stop_hover
    End Sub

    Private Sub TrashButton_GotFocus(sender As Object, e As EventArgs) Handles TrashButton.GotFocus
        TrashButton.Image = My.Resources.tex_cp_delete_hover
    End Sub

    Private Sub VisualiserButton_GotFocus(sender As Object, e As EventArgs) Handles VisualiserButton.GotFocus
        VisualiserButton.Image = My.Resources.tex_cp_vislizer_hover
    End Sub

    Private Sub VolumeButton_GotFocus(sender As Object, e As EventArgs) Handles VolumeButton.GotFocus
        VolumeButton.Image = My.Resources.tex_cp_volume_hover
    End Sub


    Private Sub FbackwardsButton_LostFocus(sender As Object, e As EventArgs) Handles FbackwardsButton.LostFocus
        FbackwardsButton.Image = My.Resources.tex_cp_prev
    End Sub

    Private Sub FforwardButton_LostFocus(sender As Object, e As EventArgs) Handles FforwardButton.LostFocus
        FforwardButton.Image = My.Resources.tex_cp_next
    End Sub

    Private Sub BackwardsButton_LostFocus(sender As Object, e As EventArgs) Handles BackwardsButton.LostFocus
        BackwardsButton.Image = My.Resources.tex_cp_searchb
    End Sub

    Private Sub ForwardButton_LostFocus(sender As Object, e As EventArgs) Handles ForwardButton.LostFocus
        ForwardButton.Image = My.Resources.tex_cp_searchf
    End Sub

    Private Sub InformationsButton_LostFocus(sender As Object, e As EventArgs) Handles InformationsButton.LostFocus
        InformationsButton.Image = My.Resources.tex_cp_showinfo
    End Sub

    Private Sub PauseButton_LostFocus(sender As Object, e As EventArgs) Handles PauseButton.LostFocus
        PauseButton.Image = My.Resources.tex_cp_pause
    End Sub

    Private Sub PlayButton_LostFocus(sender As Object, e As EventArgs) Handles PlayButton.LostFocus
        PlayButton.Image = My.Resources.tex_cp_play
    End Sub

    Private Sub PlaylistButton_LostFocus(sender As Object, e As EventArgs) Handles PlaylistButton.LostFocus
        PlaylistButton.Image = My.Resources.tex_cp_playlist
    End Sub

    Private Sub RepeatButton_LostFocus(sender As Object, e As EventArgs) Handles RepeatButton.LostFocus
        RepeatButton.Image = My.Resources.tex_cp_repeat
    End Sub

    Private Sub ShuffleButton_LostFocus(sender As Object, e As EventArgs) Handles ShuffleButton.LostFocus
        ShuffleButton.Image = My.Resources.tex_cp_shuffle
    End Sub

    Private Sub StopButton_LostFocus(sender As Object, e As EventArgs) Handles StopButton.LostFocus
        StopButton.Image = My.Resources.tex_cp_stop
    End Sub

    Private Sub TrashButton_LostFocus(sender As Object, e As EventArgs) Handles TrashButton.LostFocus
        TrashButton.Image = My.Resources.tex_cp_delete
    End Sub

    Private Sub VisualiserButton_LostFocus(sender As Object, e As EventArgs) Handles VisualiserButton.LostFocus
        VisualiserButton.Image = My.Resources.tex_cp_vislizer
    End Sub

    Private Sub VolumeButton_LostFocus(sender As Object, e As EventArgs) Handles VolumeButton.LostFocus
        VolumeButton.Image = My.Resources.tex_cp_volume
    End Sub

#End Region

End Class
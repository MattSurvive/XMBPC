Imports System.IO
Imports AForge.Controls
Imports WMPLib
Imports System.Runtime.InteropServices

Public Class VideoPlayer

    Dim info As List(Of AForge.Controls.Joystick.DeviceInfo) = AForge.Controls.Joystick.GetAvailableDevices
    Dim joy As New AForge.Controls.Joystick
    <DllImport("user32.dll")> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As Int32) As Short
    End Function

    Dim WithEvents MediaPlayer As New WindowsMediaPlayer()
    Public CurrentVolume As Integer

    Private Sub VideoPlayer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ControllerInputTimer.Stop()
        MediaPlayer.Ctlcontrols.stop()
        XMB.Enabled = True
    End Sub

    Private Sub VideoPlayer_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Controls.Add(MediaPlayer)

        CurrentVolume = 50

        MediaPlayer.Dock = DockStyle.Fill
        MediaPlayer.uiMode = "none"
        MediaPlayer.URL = XMB.CurrentVideoTrack
        MediaPlayer.stretchToFit = True
        MediaPlayer.settings.volume = 50

        If info.Count = 0 Then
            KeyboardTimer.Start()
        Else
            joy = New Joystick(0)
            ControllerInputTimer.Start()
        End If
    End Sub

    Private Sub ControllerInputTimer_Tick(sender As Object, e As EventArgs) Handles ControllerInputTimer.Tick
        Dim status As AForge.Controls.Joystick.Status = joy.GetCurrentStatus

        MediaPlayer.settings.volume = CurrentVolume

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button2) = True Or GetAsyncKeyState(Keys.Escape) Then
            Me.Close()
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button5) = True Or GetAsyncKeyState(Keys.H) Then
            If CurrentVolume = 100 Then
                CurrentVolume = CurrentVolume
            Else
                CurrentVolume = CurrentVolume + 5
            End If
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button7) = True Or GetAsyncKeyState(Keys.N) Then
            If CurrentVolume = 0 Then
                CurrentVolume = CurrentVolume
            Else
                CurrentVolume = CurrentVolume - 5
            End If
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button12) And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button9) Then

            If HelpBox.Visible = True Then
                HelpBox.Visible = False
            Else
                HelpBox.Visible = True
            End If
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button5) And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button6) Or GetAsyncKeyState(Keys.R) And GetAsyncKeyState(Keys.S) Then
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

    End Sub

    Private Sub KeyboardTimer_Tick(sender As Object, e As EventArgs) Handles KeyboardTimer.Tick

        MediaPlayer.settings.volume = CurrentVolume

        'If (MediaPlayer.network.frameRate <> 0) Then
        'FramerateTxt.Text = "Frame Rate: " + MediaPlayer.network.frameRate.ToString + " kb/s" + vbNewLine + _
        '    "Bit Rate:" + MediaPlayer.network.bitRate.ToString + vbNewLine + _
        '    "Duration: " + MediaPlayer.currentMedia.durationString + vbNewLine + _
        '    "Size: " + MediaPlayer.currentMedia.imageSourceWidth.ToString + "x" + MediaPlayer.currentMedia.imageSourceHeight.ToString
        'End If

        If GetAsyncKeyState(Keys.Escape) Then
            Me.Close()
        ElseIf GetAsyncKeyState(Keys.H) Then
            If CurrentVolume = 100 Then
                CurrentVolume = CurrentVolume
            Else
                CurrentVolume = CurrentVolume + 5
            End If
        ElseIf GetAsyncKeyState(Keys.N) Then
            If CurrentVolume = 0 Then
                CurrentVolume = CurrentVolume
            Else
                CurrentVolume = CurrentVolume - 5
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

    End Sub

End Class
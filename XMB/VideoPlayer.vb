Imports System.IO

Public Class VideoPlayer

    Dim info As List(Of AForge.Controls.Joystick.DeviceInfo) = AForge.Controls.Joystick.GetAvailableDevices
    Dim joy As New AForge.Controls.Joystick(0)

    Dim WithEvents MediaPlayer As New AxWMPLib.AxWindowsMediaPlayer()

    Dim CurrentVolume As Integer = 50

    Private Sub VideoPlayer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ControllerInputTimer.Stop()
        MediaPlayer.Ctlcontrols.stop()
        XMB.Enabled = True
    End Sub

    Private Sub VideoPlayer_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Controls.Add(MediaPlayer)

        MediaPlayer.Dock = DockStyle.Fill
        MediaPlayer.uiMode = "none"
        MediaPlayer.URL = XMB.CurrentVideoTrack
        MediaPlayer.stretchToFit = True
        MediaPlayer.settings.volume = CurrentVolume

        ControllerInputTimer.Start()
    End Sub

    Private Sub ControllerInputTimer_Tick(sender As Object, e As EventArgs) Handles ControllerInputTimer.Tick
        Dim status As AForge.Controls.Joystick.Status = joy.GetCurrentStatus

        MediaPlayer.settings.volume = CurrentVolume

        If CurrentVolume = 100 And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button5) = True Then
            CurrentVolume = CurrentVolume
        ElseIf CurrentVolume = 0 And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button7) = True Then
            CurrentVolume = CurrentVolume
        End If

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button2) = True Then
            Me.Close()
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button5) = True Then
            CurrentVolume = CurrentVolume + 1
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button7) = True Then
            CurrentVolume = CurrentVolume - 1
        End If

    End Sub

End Class
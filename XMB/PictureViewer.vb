Imports System.IO

Public Class PictureViewer

    Dim info As List(Of AForge.Controls.Joystick.DeviceInfo) = AForge.Controls.Joystick.GetAvailableDevices
    Dim joy As New AForge.Controls.Joystick(0)
    Dim currimage As Integer

    Private Sub PictureViewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ControllerInputTimer.Stop()
        XMB.Enabled = True
        XMB.ActiveControl = XMB.Home
    End Sub

    Private Sub PictureViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ControllerInputTimer.Start()
        Me.BackgroundImage = Image.FromFile(XMB.picturelist(XMB.CurrentPictureTrack.Split(";")(1)).ToString)

        currimage = XMB.CurrentPictureTrack.Split(";")(1)
    End Sub

    Private Sub ControllerInputTimer_Tick(sender As Object, e As EventArgs) Handles ControllerInputTimer.Tick
        Dim status As AForge.Controls.Joystick.Status = joy.GetCurrentStatus

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button1) = True Then

            XMB.BackgroundImage = Image.FromFile(XMB.picturelist(currimage).ToString)
            MsgBox("New background has been set", MsgBoxStyle.OkOnly)

        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button2) = True Then
            Me.Close()

        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Then
            SendKeys.Send("{ENTER}")

        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button5) = True Then

            Try
                Me.BackgroundImage = Image.FromFile(XMB.picturelist(currimage - 1).ToString)
                currimage = currimage - 1
            Catch ex As Exception
            End Try

        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button6) = True Then

            Try
                Me.BackgroundImage = Image.FromFile(XMB.picturelist(currimage + 1).ToString)
                currimage = currimage + 1
            Catch ex As Exception
            End Try

        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button4) = True Then

            If Me.BackgroundImageLayout = ImageLayout.Center Then
                Me.BackgroundImageLayout = ImageLayout.None
            ElseIf Me.BackgroundImageLayout = ImageLayout.None Then
                Me.BackgroundImageLayout = ImageLayout.Stretch
            ElseIf Me.BackgroundImageLayout = ImageLayout.Stretch Then
                Me.BackgroundImageLayout = ImageLayout.Tile
            ElseIf Me.BackgroundImageLayout = ImageLayout.Tile Then
                Me.BackgroundImageLayout = ImageLayout.Zoom
            ElseIf Me.BackgroundImageLayout = ImageLayout.Zoom Then
                Me.BackgroundImageLayout = ImageLayout.Center
            End If

        End If

    End Sub

End Class
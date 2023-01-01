Imports System.IO
Imports AForge.Controls
Imports System.Runtime.InteropServices

Public Class PictureViewer

    Dim info As List(Of AForge.Controls.Joystick.DeviceInfo) = AForge.Controls.Joystick.GetAvailableDevices
    Dim joy As New AForge.Controls.Joystick
    <DllImport("user32.dll")> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As Int32) As Short
    End Function
    Dim currimage As Integer
    Public specialstate As Boolean

    Private Sub PictureViewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ControllerInputTimer.Stop()
        KeyboardTimer.Stop()

        If Not specialstate = True Then
            XMB.Enabled = True
            XMB.ActiveControl = XMB.Home
            specialstate = False
        Else
            DiscExplorer.BringToFront()
            specialstate = False
        End If

    End Sub

    Private Sub PictureViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If info.Count = 0 Then
            KeyboardTimer.Start()
        Else
            joy = New Joystick(0)
            ControllerInputTimer.Start()
        End If

        If Not specialstate = True Then
            Me.BackgroundImage = Image.FromFile(XMB.picturelist(XMB.SelectedPicture.Tag.Split(";")(1)).ToString)
            currimage = XMB.SelectedPicture.Tag.Split(";")(1)
        Else
            Me.BackgroundImage = Image.FromFile(XMB.CurrentPictureTrack)
        End If

    End Sub

    Private Sub ControllerInputTimer_Tick(sender As Object, e As EventArgs) Handles ControllerInputTimer.Tick
        Dim status As AForge.Controls.Joystick.Status = joy.GetCurrentStatus

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button1) = True Or GetAsyncKeyState(Keys.U) Then

            XMB.BackgroundImage = Image.FromFile(XMB.picturelist(currimage).ToString)
            Functions.INI_WriteValueToFile("System", "Background", XMB.picturelist(currimage).ToString, ".\system\sys.ini")

            SystemDialog.DialogTxt.Text = "New background has been set"
            SystemDialog.DialogPossibilities = "OKONLY"

            SystemDialog.ShowDialog()

        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button2) = True Or GetAsyncKeyState(Keys.Escape) Then
            Me.Close()
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or GetAsyncKeyState(Keys.Enter) Then
            SendKeys.Send("{ENTER}")
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button5) = True Or GetAsyncKeyState(Keys.Left) Then

            Try
                Me.BackgroundImage = Image.FromFile(XMB.picturelist(currimage - 1).ToString)
                currimage = currimage - 1
            Catch ex As Exception
            End Try

        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button6) = True Or GetAsyncKeyState(Keys.Right) Then

            Try
                Me.BackgroundImage = Image.FromFile(XMB.picturelist(currimage + 1).ToString)
                currimage = currimage + 1
            Catch ex As Exception
            End Try

        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button4) = True Or GetAsyncKeyState(Keys.S) Then

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

        If GetAsyncKeyState(Keys.U) Then

            XMB.BackgroundImage = Image.FromFile(XMB.picturelist(currimage).ToString)
            Functions.INI_WriteValueToFile("System", "Background", XMB.picturelist(currimage).ToString, ".\system\sys.ini")

            SystemDialog.DialogTxt.Text = "New background has been set"
            SystemDialog.DialogPossibilities = "OKONLY"

            SystemDialog.ShowDialog()

        ElseIf GetAsyncKeyState(Keys.Escape) Then
            Me.Close()
        ElseIf GetAsyncKeyState(Keys.Left) Then

            Try
                Me.BackgroundImage = Image.FromFile(XMB.picturelist(currimage - 1).ToString)
                currimage = currimage - 1
            Catch ex As Exception
            End Try

        ElseIf GetAsyncKeyState(Keys.Right) Then

            Try
                Me.BackgroundImage = Image.FromFile(XMB.picturelist(currimage + 1).ToString)
                currimage = currimage + 1
            Catch ex As Exception
            End Try

        ElseIf GetAsyncKeyState(Keys.S) Then

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
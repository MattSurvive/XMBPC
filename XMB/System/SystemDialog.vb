Imports AForge.Controls
Imports System.Runtime.InteropServices

Public Class SystemDialog

    Dim info As List(Of AForge.Controls.Joystick.DeviceInfo) = AForge.Controls.Joystick.GetAvailableDevices
    Dim joy As New AForge.Controls.Joystick

    <DllImport("user32.dll")> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As Int32) As Short
    End Function

    Public DialogResponse As String
    Public DialogPossibilities As String

    Private Sub SystemDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If DialogResponse = "Yes" Then
            Me.DialogResult = Windows.Forms.DialogResult.Yes
        ElseIf DialogResponse = "No" Then
            Me.DialogResult = Windows.Forms.DialogResult.No
        ElseIf DialogResponse = "Ok" Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        ElseIf DialogResponse = "Cancel" Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If

    End Sub

    Private Sub SystemDialog_Load(sender As Object, e As EventArgs) Handles Me.Load

        If info.Count = 0 Then
            KeyboardTimer.Start()
        Else
            joy = New Joystick(0)
            ControllerInputTimer.Start()
        End If

        If DialogPossibilities = "OKONLY" Then
            ContinueTxt.Text = "OK"

            MsgIco2.Visible = False
            CancelTxt.Visible = False
        ElseIf DialogPossibilities = "OKCANCEL" Then
            ContinueTxt.Text = "OK"

            MsgIco2.Visible = True
            CancelTxt.Visible = True
            CancelTxt.Text = "Cancel"
        ElseIf DialogPossibilities = "YESNO" Then
            ContinueTxt.Text = "Yes"

            MsgIco2.Visible = True
            CancelTxt.Visible = True
            CancelTxt.Text = "No"
        End If

    End Sub

    Private Sub ControllerInputTimer_Tick(sender As Object, e As EventArgs) Handles ControllerInputTimer.Tick
        Dim status As AForge.Controls.Joystick.Status = joy.GetCurrentStatus

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or GetAsyncKeyState(Keys.Enter) Then

            If ContinueTxt.Text = "OK" Then
                DialogResponse = "Ok"
                Me.Close()
            ElseIf ContinueTxt.Text = "Yes" Then
                DialogResponse = "Yes"
                Me.Close()
            End If

        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button2) = True Or GetAsyncKeyState(Keys.Escape) Then

            If ContinueTxt.Text = "Cancel" Then
                DialogResponse = "Cancel"
                Me.Close()
            ElseIf ContinueTxt.Text = "No" Then
                DialogResponse = "No"
                Me.Close()
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

    End Sub

    Private Sub KeyboardTimer_Tick(sender As Object, e As EventArgs) Handles KeyboardTimer.Tick

        If GetAsyncKeyState(Keys.Enter) Then

            If ContinueTxt.Text = "OK" Then
                DialogResponse = "Ok"
                Me.Close()
            ElseIf ContinueTxt.Text = "Yes" Then
                DialogResponse = "Yes"
                Me.Close()
            End If

        ElseIf GetAsyncKeyState(Keys.Escape) Then

            If ContinueTxt.Text = "Cancel" Then
                DialogResponse = "Cancel"
                Me.Close()
            ElseIf ContinueTxt.Text = "No" Then
                DialogResponse = "No"
                Me.Close()
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
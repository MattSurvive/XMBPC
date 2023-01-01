Imports System.IO
Imports AForge.Controls
Imports System.Runtime.InteropServices

Public Class Browser

    Dim info As List(Of AForge.Controls.Joystick.DeviceInfo) = AForge.Controls.Joystick.GetAvailableDevices
    Dim joy As New AForge.Controls.Joystick
    <DllImport("user32.dll")> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As Int32) As Short
    End Function
    Private Declare Function SetCursorPos Lib "user32" (ByVal X As Integer, ByVal Y As Integer) As Integer
    Private Declare Sub mouse_event Lib "user32.dll" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As IntPtr)
    Private isFileDownload As Boolean

    Private Sub PerformMouseClick(ByVal LClick_RClick_DClick As String)
        Const MOUSEEVENTF_LEFTDOWN As Integer = 2
        Const MOUSEEVENTF_LEFTUP As Integer = 4
        Const MOUSEEVENTF_RIGHTDOWN As Integer = 6
        Const MOUSEEVENTF_RIGHTUP As Integer = 8

        If LClick_RClick_DClick = "RClick" Then
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, IntPtr.Zero)
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, IntPtr.Zero)
        ElseIf LClick_RClick_DClick = "LClick" Then
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero)
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero)
        ElseIf LClick_RClick_DClick = "DClick" Then
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero)
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero)
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero)
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero)
        End If

    End Sub

    Private Sub Browser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        XMB.Enabled = True
    End Sub

    Private Sub Browser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If info.Count = 0 Then
            KeyboardTimer.Start()
        Else
            joy = New Joystick(0)
            ControllerInputTimer.Start()
        End If

        PageN.Parent = TopBar
        PageN.Location = New Point(80, 8)
        PageL.Parent = TopBar
        PageL.Location = New Point(670, 8)

        Dim wbBase As SHDocVw.WebBrowser = DirectCast(WebBrowser1.ActiveXInstance, SHDocVw.WebBrowser)
        AddHandler wbBase.NewWindow3, AddressOf NewWindow3

        'BrowserMenu.Parent = WebBrowser1
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        PageN.Text = WebBrowser1.DocumentTitle.ToString
        PageL.Text = WebBrowser1.Document.Url.ToString
    End Sub

    Private Sub ControllerInputTimer_Tick(sender As Object, e As EventArgs) Handles ControllerInputTimer.Tick
        Dim status As AForge.Controls.Joystick.Status = joy.GetCurrentStatus

        If status.XAxis = 1 Or GetAsyncKeyState(Keys.Right) Then
            SetCursorPos(MousePosition.X + 15, MousePosition.Y)
        ElseIf status.XAxis = -1 Or GetAsyncKeyState(Keys.Left) Then
            SetCursorPos(MousePosition.X - 15, MousePosition.Y)
        End If

        If status.YAxis = 1 Or GetAsyncKeyState(Keys.Down) Then
            SetCursorPos(MousePosition.X, MousePosition.Y + 15)
        ElseIf status.YAxis = -1 Or GetAsyncKeyState(Keys.Up) Then
            SetCursorPos(MousePosition.X, MousePosition.Y - 15)
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

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button4) = True And status.YAxis = 1 Then
            SendKeys.Send("{PGDN}")
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button4) = True And status.YAxis = -1 Then
            SendKeys.Send("{PGUP}")
        End If

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button1) = True Or GetAsyncKeyState(Keys.F8) Then

            If BrowserMenu.Visible Then
                BrowserMenu.Visible = False
            Else
                BrowserMenu.Visible = True
            End If

        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button2) = True Or GetAsyncKeyState(Keys.Escape) Then

            Me.Close()

            XMB.Enabled = True

            XMB.BringToFront()
            XMB.Activate()
            XMB.ActiveControl = XMB.Home

        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Then
            PerformMouseClick("LClick")
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button5) = True Or GetAsyncKeyState(Keys.Back) Then
            WebBrowser1.GoBack()
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button6) = True Or GetAsyncKeyState(Keys.Shift) Then
            WebBrowser1.GoForward()
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button12) = True Or GetAsyncKeyState(Keys.F9) Then
            If URLBox.Visible = False Then
                URLBox.Visible = True
                Me.ActiveControl = URLBox
            Else
                URLBox.Visible = False
                Me.ActiveControl = WebBrowser1
            End If
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button10) And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button11) Then

            If HelpBox.Visible = True Then
                HelpBox.Visible = False
            Else
                HelpBox.Visible = True
            End If
        End If

    End Sub

    Private Sub KeyboardTimer_Tick(sender As Object, e As EventArgs) Handles KeyboardTimer.Tick

        If GetAsyncKeyState(Keys.Right) Then
            SetCursorPos(MousePosition.X + 15, MousePosition.Y)
        ElseIf GetAsyncKeyState(Keys.Left) Then
            SetCursorPos(MousePosition.X - 15, MousePosition.Y)
        End If

        If GetAsyncKeyState(Keys.Down) Then
            SetCursorPos(MousePosition.X, MousePosition.Y + 15)
        ElseIf GetAsyncKeyState(Keys.Up) Then
            SetCursorPos(MousePosition.X, MousePosition.Y - 15)
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

        If GetAsyncKeyState(Keys.F8) Then

            If BrowserMenu.Visible Then
                BrowserMenu.Visible = False
            Else
                BrowserMenu.Visible = True
            End If

        ElseIf GetAsyncKeyState(Keys.Escape) Then

            Me.Close()

            XMB.Enabled = True
            XMB.BringToFront()
            XMB.Activate()
            XMB.ActiveControl = XMB.Home

        ElseIf GetAsyncKeyState(Keys.Back) Then
            WebBrowser1.GoBack()
        ElseIf GetAsyncKeyState(Keys.Shift) Then
            WebBrowser1.GoForward()
        ElseIf GetAsyncKeyState(Keys.F9) Then
            If URLBox.Visible = False Then
                URLBox.Visible = True
                Me.ActiveControl = URLBox
            Else
                URLBox.Visible = False
                Me.ActiveControl = WebBrowser1
            End If
        End If

    End Sub

    Private Sub URLBox_KeyDown(sender As Object, e As KeyEventArgs) Handles URLBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            WebBrowser1.Navigate(URLBox.Text, False)
            URLBox.Visible = False
        End If
    End Sub

    Private Sub NewWindow3(ByRef ppDisp As Object, ByRef Cancel As Boolean, ByVal dwFlags As Long, ByVal bstrUrlContext As String, ByVal bstrUrl As String)

        WebBrowser1.Navigate(bstrUrl)

        If bstrUrl.ToString.EndsWith(".pls") Or bstrUrl.EndsWith(".asx") Or bstrUrl.EndsWith(".m3u") Then
            Cancel = True
            WebBrowser1.Stop()

            SystemDialog.DialogTxt.Text = "This is a radio stream, would you like to play it?" + vbNewLine + "You can stop the player with pressing R+S (L1+R1) or restart the player with R+P (L1+R1 too)"
            SystemDialog.DialogPossibilities = "YESNO"

            If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                XMB.CurrentRadioURL = bstrUrl
                XMB.RadioPlayer.URL = bstrUrl
            End If

        End If

    End Sub

    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating

        If e.Url.ToString.EndsWith(".pls") Or e.Url.ToString.EndsWith(".asx") Or e.Url.ToString.EndsWith(".m3u") Then
            e.Cancel = True
            WebBrowser1.Stop()
        End If

    End Sub

    Private Sub WebBrowser1_NewWindow(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles WebBrowser1.NewWindow
        e.Cancel = True
    End Sub

End Class
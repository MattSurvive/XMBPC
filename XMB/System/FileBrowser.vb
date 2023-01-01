Imports System.IO
Imports AForge.Controls
Imports System.Runtime.InteropServices

Public Class FileBrowser

    Dim info As List(Of AForge.Controls.Joystick.DeviceInfo) = AForge.Controls.Joystick.GetAvailableDevices
    Dim joy As New AForge.Controls.Joystick
    <DllImport("user32.dll")> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As Int32) As Short
    End Function

    Private Sub ControllerInputTimer_Tick(sender As Object, e As EventArgs) Handles ControllerInputTimer.Tick
        Dim status As AForge.Controls.Joystick.Status = joy.GetCurrentStatus

        If status.YAxis = 1 Then

            If Not FilesList.Items.Count = 0 Then

                Dim previousSelectedIndex As Integer = FilesList.SelectedItems(0).Index
                FilesList.SelectedItems(0).Selected = False
                FilesList.Items(previousSelectedIndex + 1).Selected = True

            End If

        ElseIf status.YAxis = -1 Then

            If Not FilesList.Items.Count = 0 Then

                Dim previousSelectedIndex As Integer = FilesList.SelectedItems(0).Index
                FilesList.SelectedItems(0).Selected = False
                FilesList.Items(previousSelectedIndex - 1).Selected = True

            End If

        End If

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Then
            If Not FilesList.Items.Count = 0 Then
                Functions.LoadP3T(FilesList.SelectedItems(0).Text)
                Me.Close()
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

        If GetAsyncKeyState(Keys.Down) Then

            If Not FilesList.Items.Count = 0 Then

                Dim previousSelectedIndex As Integer = FilesList.SelectedItems(0).Index
                FilesList.SelectedItems(0).Selected = False
                FilesList.Items(previousSelectedIndex + 1).Selected = True

            End If

        ElseIf GetAsyncKeyState(Keys.Up) Then

            If Not FilesList.Items.Count = 0 Then

                Dim previousSelectedIndex As Integer = FilesList.SelectedItems(0).Index
                FilesList.SelectedItems(0).Selected = False
                FilesList.Items(previousSelectedIndex - 1).Selected = True

            End If

        ElseIf GetAsyncKeyState(Keys.Enter) Then
            If Not FilesList.Items.Count = 0 Then
                Functions.LoadP3T(FilesList.SelectedItems(0).Text)
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

    Private Sub FileBrowser_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            For Each fil In Directory.GetFiles(".\media\themes", "*.p3t", SearchOption.TopDirectoryOnly)
                Dim FI As New FileInfo(fil)
                Dim SizeInKB As String = FormatNumber(FI.Length / 1024, 2).ToString

                With FilesList.Items.Add(fil)
                    .SubItems.Add(Path.GetFileNameWithoutExtension(fil))
                    .SubItems.Add(Path.GetExtension(fil).Replace(".", ""))
                    .SubItems.Add(SizeInKB + " MB")
                End With
            Next

            FilesList.Items(0).Selected = True

        Catch ex As Exception

            SystemDialog.DialogTxt.Text = LangLoader.GetStringOfLang("Filebrowser", "NoThemeFoundError") + vbNewLine + LangLoader.GetStringOfLang("Filebrowser", "NoThemeFoundError2")
            SystemDialog.DialogPossibilities = "OKONLY"

            If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If

        End Try

        If info.Count = 0 Then
            KeyboardTimer.Start()
        Else
            joy = New Joystick(0)
            ControllerInputTimer.Start()
        End If

    End Sub

End Class
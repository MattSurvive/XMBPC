Imports System.IO

Public Class FileBrowser

    Dim info As List(Of AForge.Controls.Joystick.DeviceInfo) = AForge.Controls.Joystick.GetAvailableDevices
    Dim joy As New AForge.Controls.Joystick(0)

    Private Sub ControllerInputTimer_Tick(sender As Object, e As EventArgs) Handles ControllerInputTimer.Tick
        Dim status As AForge.Controls.Joystick.Status = joy.GetCurrentStatus

        If status.YAxis = 1 Then

            Dim previousSelectedIndex As Integer = FilesList.SelectedItems(0).Index
            FilesList.SelectedItems(0).Selected = False
            FilesList.Items(previousSelectedIndex + 1).Selected = True

        ElseIf status.YAxis = -1 Then

            Dim previousSelectedIndex As Integer = FilesList.SelectedItems(0).Index
            FilesList.SelectedItems(0).Selected = False
            FilesList.Items(previousSelectedIndex - 1).Selected = True

        End If

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Then
            Functions.LoadP3T(FilesList.SelectedItems(0).Text)
            Me.Close()
        End If

    End Sub

    Private Sub FileBrowser_Load(sender As Object, e As EventArgs) Handles Me.Load

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

        ControllerInputTimer.Start()
    End Sub

End Class
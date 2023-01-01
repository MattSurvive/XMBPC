Imports System.IO
Imports Microsoft.WindowsAPICodePack.ApplicationServices
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Management

Public Class XMBDesk

    Private MausPosition As Point
    Declare Function ShowWindow Lib "User32" (ByVal hWnd As IntPtr, ByVal nCmdShow As ShowWindowCommands) As Boolean
    Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Const SWP_HIDEWINDOW = &H80
    Const SWP_SHOWWINDOW = &H40
    Dim taskBars As Integer
    Dim clickedtaskbaritem As String
    Dim clickedtaskbaritemtext As ToolStripItem
    Dim WithEvents procwatcher As New ProcessWatcher()

    Public Enum ShowWindowCommands
        SW_HIDE = 0
        SW_SHOWNORMAL = 1
        SW_NORMAL = 1
        SW_SHOWMINIMIZED = 2
        SW_SHOWMAXIMIZED = 3
        SW_MAXIMIZE = 3
        SW_SHOWNOACTIVATE = 4
        SW_SHOW = 5
        SW_MINIMIZE = 6
        SW_SHOWMINNOACTIVE = 7
        SW_SHOWNA = 8
        SW_RESTORE = 9
        SW_SHOWDEFAULT = 10
        SW_FORCEMINIMIZE = 11
        SW_MAX = 11
    End Enum


#Region "RightClickMenu Events"

    Private Sub CatalystControlCenterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CatalystControlCenterToolStripMenuItem.Click
        Try
            Process.Start(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\ATI Technologies\ATI.ACE\Core-Static\CCC.exe")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub NVIDIAControlCenterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NVIDIAControlCenterToolStripMenuItem.Click
        Try
            Process.Start(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\NVIDIA Corporation\Control Panel Client\nvcplui.exe")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            Process.Start(Desktop.SelectedItems(0).Tag)                                  ' Try to open the selected shortcut
        Catch ex As Exception
            MsgBox("Could not start selected shortcut", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub UmbennenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UmbennenToolStripMenuItem.Click
        Desktop.SelectedItems(0).BeginEdit()                                        ' Starts LabelEdit with selected shortcut
    End Sub

    Private Sub LöschenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LöschenToolStripMenuItem.Click
        If MsgBox("Would you like to delete " + Desktop.SelectedItems(0).Text + " ?", MsgBoxStyle.YesNo, "Delete file") = MsgBoxResult.Yes Then
            File.Delete(Desktop.SelectedItems(0).Tag)                               ' Deletes the selected shortcut if answered with YES
        End If
    End Sub

    Private Sub AlsAdministratorÖffnenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AlsAdministratorÖffnenToolStripMenuItem.Click
        Dim PSInfo As New ProcessStartInfo

        PSInfo.FileName = Desktop.SelectedItems(0).Tag
        PSInfo.Verb = "runas"
        Process.Start(PSInfo)
    End Sub

    Private Sub DateipfadÖffnenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DateipfadÖffnenToolStripMenuItem.Click

        If Not Desktop.SelectedItems(0).ImageIndex = 0 Then
            Try
                Dim fi As New FileInfo(Desktop.SelectedItems(0).Tag)
                Process.Start(fi.DirectoryName)
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub EigenschaftenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EigenschaftenToolStripMenuItem.Click
        Try
            Properties.Show()
        Catch ex As Exception
        End Try
    End Sub

#End Region

    Private Sub CheckGraphicsCard()
        If Directory.Exists(My.Computer.FileSystem.Drives(0).Name + "ATI") Then
            CatalystControlCenterToolStripMenuItem.Enabled = True
            NVIDIAControlCenterToolStripMenuItem.Enabled = False
        ElseIf Directory.Exists(My.Computer.FileSystem.Drives(0).Name + "NVIDIA") Then
            CatalystControlCenterToolStripMenuItem.Enabled = False
            NVIDIAControlCenterToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub GetNetworkInfos(ByVal StatusOrValues As Integer)
        If StatusOrValues = 0 Then
            If My.Computer.Network.IsAvailable = True Then
                DesktopToolTips.SetToolTip(Network_App, "Connected")
            ElseIf My.Computer.Network.IsAvailable = False Then
                DesktopToolTips.SetToolTip(Network_App, "No connection")
            End If
        End If
    End Sub

    Private Sub LoadFilesAndFolders_OfDesktop()

        Desktop.Items.Clear()

        Desktop.Items.Add("Return to XMB", 1)

        For Each DesktopShortcut In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.SpecialDirectories.Desktop)

            Dim ShortcutIcon As Icon = Icon.ExtractAssociatedIcon(DesktopShortcut)  ' Get the associated icon from the shortcut
            Dim FI As New FileInfo(DesktopShortcut)                                 ' Get the file informations

            DesktopImages.Images.Add(ShortcutIcon.ToBitmap)                         ' Add the associated icons from the shortcut to the imagelist

            With Desktop.Items.Add(Path.GetFileNameWithoutExtension(FI.FullName), DesktopImages.Images.Count - 1)
                .Tag = FI.FullName                                                  ' Add a tag to use it later
            End With

        Next

        For Each DesktopFolderShortcut In My.Computer.FileSystem.GetDirectories(My.Computer.FileSystem.SpecialDirectories.Desktop)

            Dim DI As New DirectoryInfo(DesktopFolderShortcut)                       ' Get the direcotry informations

            With Desktop.Items.Add(DI.Name, 0)                                       ' Use ImageIndex 0 for folder icon
                .Tag = DI.FullName                                                   ' Add a tag to use it later
            End With

        Next

    End Sub

    Private Sub LoadTaskBar()

        For Each processnames As Process In Process.GetProcesses

            If processnames.MainWindowTitle <> "" Then

                Dim ShIcon As Icon

                Try

                    ShIcon = Icon.ExtractAssociatedIcon(processnames.Modules(0).FileName)

                    With TaskBar.Items.Add(processnames.MainWindowTitle.Split("-")(0), ShIcon.ToBitmap)
                        .Tag = processnames.MainWindowHandle
                        .ToolTipText = processnames.Id
                        .Name = processnames.ProcessName
                    End With

                Catch

                End Try

            End If
        Next

    End Sub

    Public Function GetShellLinkPath(ByVal datei As String) As String

        Dim oShell As New Shell32.Shell
        Dim oFolder As Shell32.Folder
        Dim oLink As Shell32.ShellLinkObject
        Dim sPath As String
        Dim sFile As String
        Dim sLinkFile As String = datei

        sPath = Path.GetDirectoryName(sLinkFile)
        sFile = Path.GetFileName(sLinkFile)
        oFolder = oShell.NameSpace(sPath)
        oLink = oFolder.Items.Item(sFile).GetLink

        Return oLink.WorkingDirectory

    End Function

    Private Sub System_Timer_Tick(sender As Object, e As EventArgs) Handles System_Timer.Tick
        Clocktime.Text = Format(Now, "HH:mm:ss") & vbNewLine & Format(Now, "dd.MM.yyyy")
    End Sub

    Private Sub Other_System_Services_Tick(sender As Object, e As EventArgs) Handles Other_System_Services.Tick
        GetNetworkInfos(0)
    End Sub

    Private Sub XMBDesk_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SetWindowPos(taskBars, 0&, 0&, 0&, 0&, 0&, SWP_SHOWWINDOW)
        procwatcher.Stop()

        If XMB.Enabled = False Then
            XMB.Enabled = True
            XMB.BringToFront()
            XMB.Activate()
            XMB.ActiveControl = XMB.DesktopBox
        End If
    End Sub

    Private Sub XMBDesk_Load(sender As Object, e As EventArgs) Handles Me.Load

        procwatcher.Start()

        taskBars = FindWindow("Shell_traywnd", "")

        SetWindowPos(taskBars, 0&, 0&, 0&, 0&, 0&, SWP_HIDEWINDOW)

        TaskBar.Renderer = New ToolStripRend

        Me.Size = New Size(1920, 1080)
        Me.WindowState = FormWindowState.Maximized

        Bot_Box.Parent = Desktop
        TaskBar.ForeColor = Color.White

        LoadFilesAndFolders_OfDesktop()
        GetNetworkInfos(0)

        System_Timer.Start()
        Other_System_Services.Start()

        CheckGraphicsCard()

        For Each processname As Process In Process.GetProcesses

            Dim ShIcon As Icon

            If processname.MainWindowTitle <> "" Then
                Try

                    ShIcon = Icon.ExtractAssociatedIcon(processname.Modules(0).FileName)

                    With TaskBar.Items.Add(processname.MainWindowTitle.Split("-")(0), ShIcon.ToBitmap)
                        .Tag = processname.MainWindowHandle
                        .ToolTipText = processname.Id
                        .Name = processname.ProcessName.ToString
                    End With

                Catch

                End Try

            End If
        Next

    End Sub

    Private Sub Desktop_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Desktop.MouseClick

        If e.Button = MouseButtons.Right Then
            If Desktop.SelectedItems.Count > 0 And Desktop.SelectedItems.Count < 2 Then
                ItemRightclickMenu.Show(MousePosition)                                   ' If a shortcut is selected, open the ItemRightClickMenu
            End If
        End If

        If e.Button = MouseButtons.Left Then

            If TaskBarRightMenu.Visible = True Then
                TaskBarRightMenu.Visible = False
            End If

            'If Desktop.SelectedItems.Count > 0 And Desktop.SelectedItems.Count < 2 And Desktop.SelectedItems(0).Selected = True Then
            'Desktop.SelectedItems(0).BeginEdit()                                 ' If a shortcut gets selected with MouseButtons.Left then start editing (Windows Version -> 2 clicks with delay)

            'End If
        End If

    End Sub

    Private Sub Desktop_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Desktop.MouseDoubleClick
        If Desktop.SelectedItems(0).Text = "Return to XMB" Then
            Me.Close()

            XMB.Enabled = True
            XMB.BringToFront()
            XMB.Activate()
            XMB.ActiveControl = XMB.DesktopBox
        Else
            Process.Start(Desktop.SelectedItems(0).Tag)
        End If
    End Sub

    Private Sub Rightclickmenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Rightclickmenu.Opening
        If Desktop.SelectedItems.Count > 0 And Desktop.SelectedItems.Count < 2 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TaskBar_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles TaskBar.ItemClicked
        ShowWindow(e.ClickedItem.Tag, ShowWindowCommands.SW_RESTORE)
    End Sub

    Private Sub TaskBar_MouseClick(sender As Object, e As MouseEventArgs) Handles TaskBar.MouseClick
        If e.Button.Right Then

            Dim xpos As Integer = e.Location.X
            Dim ypos As Integer = e.Location.Y

            Try
                clickedtaskbaritem = TaskBar.GetItemAt(xpos, ypos).ToolTipText
                clickedtaskbaritemtext = TaskBar.GetItemAt(xpos, ypos)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub CloseApplToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim prs() As System.Diagnostics.Process
        Dim process As System.Diagnostics.Process
        prs = System.Diagnostics.Process.GetProcesses()

        For Each process In prs
            If process.Id = clickedtaskbaritem Then
                process.Kill()
            End If
        Next

        TaskBar.Items.Remove(clickedtaskbaritemtext)

    End Sub

    Private Sub procwatcher_ProcessCreated(proc As Win32_Process) Handles procwatcher.ProcessCreated

        Dim ShIcon As Icon
        Dim p As Process = Process.GetProcessById(proc.ProcessId)

        Try

            If p.MainWindowTitle <> "" Then

                ShIcon = Icon.ExtractAssociatedIcon(p.Modules(0).FileName)

                With TaskBar.Items.Add(p.MainWindowTitle.Split("-")(0), ShIcon.ToBitmap)
                    .Tag = p.Handle
                    .ToolTipText = p.Id
                    .Name = p.ProcessName
                End With

            End If

        Catch

        End Try

    End Sub

    Private Sub procwatcher_ProcessDeleted(proc As Win32_Process) Handles procwatcher.ProcessDeleted

        For Each app As ToolStripItem In TaskBar.Items
            If app.ToolTipText.ToString = proc.ProcessId.ToString Then
                TaskBar.Items.Remove(app)
            End If
        Next

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

        Dim ProcessToKill As Process = Process.GetProcessById(clickedtaskbaritemtext.ToolTipText)
        ProcessToKill.Kill()

        TaskBar.Items.Remove(clickedtaskbaritemtext)

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Appearence.Show()
    End Sub

End Class
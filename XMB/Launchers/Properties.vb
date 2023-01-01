Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Public Class Properties

    <DllImport("shell32.dll", EntryPoint:="FindExecutable")> _
    Public Shared Function FindExecutableA(lpFile As String, lpDirectory As String, lpResult As StringBuilder) As Long
    End Function

    Public Shared Function FindExe(Path As String) As String
        Dim objResult As New StringBuilder(1024)
        Dim lngResult As Long = 0

        lngResult = FindExecutableA(Path, "", objResult)

        If lngResult >= 32 Then
            Return objResult.ToString()
        End If

        Return ""
    End Function

    Public Sub Load_Properties(ByVal InFile As String)
        Try
            Dim FI As New FileInfo(InFile)
            Dim FI2 As New FileInfo(FindExe(InFile))

            FileIcon.Image = Icon.ExtractAssociatedIcon(InFile).ToBitmap
            FileText.Text = FI.Name
            FileType.Text = FI.Extension
            OpensWith.Text = FI2.Name + " (" + FI.Extension + ")"
            OpensWithIcon.Image = Icon.ExtractAssociatedIcon(FI2.FullName).ToBitmap

            FilePath.Text = FI.DirectoryName
            Dim NewSize As Integer = FI.Length / 1024
            Dim NewHDDSize As Integer = FI.Length / 1000
            FileSize.Text = NewSize.ToString + " KB (" + FI.Length.ToString + " bytes)"
            FileSizeOnHDD.Text = NewHDDSize.ToString + " KB (" + FI.Length.ToString + " bytes)"

            FileCreation.Text = FI.CreationTime
            FileChange.Text = FI.LastWriteTime
            FileLastAccess.Text = FI.LastAccessTime

            If FI.Attributes = FileAttributes.ReadOnly Then
                IsProtected.Checked = True
            End If

            If FI.Attributes = FileAttributes.Hidden Then
                IsHidden.Checked = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Properties_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Load_Properties(XMBDesk.Desktop.SelectedItems(0).Tag)
    End Sub

End Class
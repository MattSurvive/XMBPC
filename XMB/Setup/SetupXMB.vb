Imports System.Drawing.Drawing2D
Imports Microsoft.Win32
Imports System.Threading
Imports System.IO

Public Class SetupXMB

    Dim joy As New AForge.Controls.Joystick()

    Public Shared Function GenerateArchitecture()
        If Registry.LocalMachine.OpenSubKey("Hardware\Description\System\CentralProcessor\0").GetValue("Identifier").ToString.Contains("x86") Then
            Return "32"
        Else
            Return "64"
        End If
    End Function

    Public Function Autostart(ByVal AutostartEnable As Boolean)
        Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
        If AutostartEnable = True Then
            key.SetValue(My.Application.Info.AssemblyName, System.Reflection.Assembly.GetEntryAssembly.Location)
        Else
            key.DeleteValue(My.Application.Info.AssemblyName, False)
        End If
        key.Close()
        Return AutostartEnable
    End Function

    Private Sub Boot_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        StartUpHook.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Functions.INI_WriteValueToFile("System", "Language", LangBox.SelectedItem.ToString, ".\system\sys.ini")
        Functions.INI_WriteValueToFile("System", "Background", "Standard", ".\system\sys.ini")
        Functions.INI_WriteValueToFile("UserDetails", "Username", UserName.Text, ".\users\user1.ini")

        If StartWithWin.Checked Then
            Autostart(True)
        End If

        SetupXMB_SecondPart.Show()
        Me.Hide()
    End Sub

    Private Sub SetupXMB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UserName.Text = Environment.UserName.ToString
    End Sub

End Class
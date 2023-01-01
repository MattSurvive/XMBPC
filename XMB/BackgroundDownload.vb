Imports System.Net
Imports System.IO
Imports Microsoft.Win32
Imports System.Net.NetworkInformation
Imports System.Net.NetworkInformation.Ping

Public Class BackgroundDownload

    Dim WithEvents dlclient As WebClient = New WebClient()
    Dim WithEvents dlclient2 As WebClient = New WebClient()

    Dim info As List(Of AForge.Controls.Joystick.DeviceInfo) = AForge.Controls.Joystick.GetAvailableDevices
    Dim joy As New AForge.Controls.Joystick(0)

    Dim timerID As IntPtr = 0
    Dim downloadSpeed As Integer = 0
    Dim maximumSpeed As Integer = 1
    Dim averageSpeed As Integer = 2
    Dim loopCount As Integer = 0
    Dim byteCount As Integer = 0
    Dim currBytes As Long
    Dim prevBytes As Long
    Dim downloadSize As Long = 0
    Dim startTime As Long
    Dim elapsedTime As TimeSpan
    Dim timeLeft As TimeSpan
    Dim timeLeftAverage As Double

    Public package As String
    Public pkgurl As String

    Private Sub BackgroundDownload_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        On Error Resume Next

        SystemEvents.KillTimer(timerID)
        timerID = Nothing
        currBytes = 0
        prevBytes = 0
        downloadSpeed = 0
        maximumSpeed = 0
        averageSpeed = 0
        loopCount = 0
        byteCount = 0
        ProgressBar1.Value = 0

        XMB.currentxmbstate = ""
        XMB.ActiveControl = XMB.Home
    End Sub

    Public Function GetFileNameFromURL(ByVal URL As String) As String
        Try
            Return URL.Substring(URL.LastIndexOf("/") + 1)
        Catch ex As Exception
            Return URL
        End Try
    End Function

    Private Sub dlclient_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles dlclient.DownloadFileCompleted
        If Not e.Cancelled Then
            If MsgBox("Press Cross (X) or click OK to update XMBPC.", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Process.Start(".\updates\xmbpc_update.exe")
            End If
        End If
    End Sub

    Sub downloadUpdating(ByVal sender As Object, ByVal e As Microsoft.Win32.TimerElapsedEventArgs)
        downloadSpeed = (currBytes - prevBytes)
        elapsedTime = TimeSpan.FromTicks((Now.Ticks - startTime))
        ETAS.Text = String.Format("{0:00}h {1:00}m {2:00}s left", elapsedTime.TotalHours, elapsedTime.Minutes, elapsedTime.Seconds)

        If downloadSpeed < 1 Then
            DLS.Text = "< 1 KB/s"
        Else
            DLS.Text = FormatNumber(downloadSpeed / 1024, 2).ToString & " KB/s"
        End If

        If Not downloadSpeed < 1 Then
            loopCount += 1
            byteCount += downloadSpeed

            timeLeftAverage = CDbl(elapsedTime.TotalSeconds / currBytes)
            timeLeft = TimeSpan.FromSeconds(timeLeftAverage * (downloadSize - currBytes))

            ETA.Text = String.Format("{0:00}h {1:00}m {2:00}s left", timeLeft.TotalHours, timeLeft.Minutes, timeLeft.Seconds)
        End If

        prevBytes = currBytes
    End Sub

    Private Sub dlclient_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles dlclient.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        downloadSize = e.TotalBytesToReceive
        currBytes = e.BytesReceived
    End Sub

    Private Sub BackgroundDownload_Load(sender As Object, e As EventArgs) Handles Me.Load
        ControllerInputTimer.Start()

        If Not Directory.Exists(".\updates") Then
            Directory.CreateDirectory(".\updates")
        End If

        If XMB.Game1.Focused = True Then
            pkgurl = XMB.Game1.Tag
        ElseIf XMB.Game2.Focused = True Then
            pkgurl = XMB.Game2.Tag
        ElseIf XMB.Game3.Focused = True Then
            pkgurl = XMB.Game3.Tag
        End If
    End Sub

    Private Sub BackgroundDownload_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        AddHandler SystemEvents.TimerElapsed, AddressOf downloadUpdating

        currBytes = 0
        prevBytes = 0
        downloadSpeed = 0
        maximumSpeed = 0
        averageSpeed = 0
        loopCount = 0
        byteCount = 0
        ProgressBar1.Value = 0

        If XMB.currentxmbstate = "UPDATE" Then
            PackageText.Text = "Looking for updates" + vbNewLine + "Please wait"
            CheckReleaseUpdates()
        End If

    End Sub

    Public Sub CheckReleaseUpdates()

        Dim FI As FileVersionInfo = FileVersionInfo.GetVersionInfo(".\XMBPC.exe")
        Dim ver1 As String = FI.FileVersion

        Dim verclient As New WebClient()
        Dim ver2 As String = verclient.DownloadString("http://85.31.189.150/XMBPCE/CURRENTVERSION.txt")

        If ver1 < ver2 Then
            pkgurl = "http://85.31.189.150/XMBPCE/DL/updates/XMBPC_UPDATE.zip"

            Dim MyWebRequest As WebRequest = MyWebRequest.Create(New Uri(pkgurl))
            Dim myResponse As WebResponse = MyWebRequest.GetResponse()
            Dim Filesize As Long = myResponse.ContentLength()

            PackageText.Text = "XMBPC_UPDATE.zip" + vbNewLine + FormatNumber(Filesize / 1024 / 1024, 2).Replace(",", ".") + " MB"

            timerID = SystemEvents.CreateTimer((1000))
            startTime = Now.Ticks

            dlclient.DownloadFileAsync(New Uri(pkgurl), ".\updates\XMBPC_UPDATE.zip")
            dlclient2.DownloadFileAsync(New Uri("http://85.31.189.150/XMBPCE/DL/updates/xmbpc_update.exe"), ".\updates\xmbpc_update.exe")
        Else

            If MsgBox("No updates found!", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Me.Close()
            End If

        End If

    End Sub

    Private Sub ControllerInputTimer_Tick(sender As Object, e As EventArgs) Handles ControllerInputTimer.Tick
        Dim status As AForge.Controls.Joystick.Status = joy.GetCurrentStatus

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Then
            SendKeys.Send("{ENTER}")
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button2) = True Then
            dlclient.CancelAsync()
            Me.Close()
        End If

    End Sub

End Class
Imports System.IO
Imports WMPLib

Public Class Boot

    Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Const SWP_HIDEWINDOW = &H80
    Const SWP_SHOWWINDOW = &H40
    Dim taskBars As Integer

#Region "FensAnim"

    Private Declare Function AnimateWindow Lib "user32" (ByVal hwnd As Integer, ByVal Time As Integer, ByVal Flags As Integer) As Integer
    Private Const AW_ACTIVATE = &H20000
    Private Const AW_BLEND = &H80000
    Private Const AW_CENTER = &H10
    Private Const AW_SLIDE = &H40000
    Private Const AW_HIDE = &H10000
    Private Const AW_HOR_POSITIVE = &H1
    Private Const AW_HOR_NEGATIVE = &H2
    Private Const AW_VER_POSITIVE = &H4
    Private Const AW_VER_NEGATIVE = &H8
    Private Const WM_PAINT = &HF

    Enum FensAnimArt As Integer
        EINBLENDEN
        AUSBLENDEN
    End Enum

    Enum FensAnimEffekt As Integer
        DIMMEN
        ROLLEN_SEITE
        ROLLEN_MITTE
        SCHIEBEN
    End Enum

    Enum FensAnimRichtung As Integer
        N
        NO
        O
        SO
        S
        SW
        W
        NW
    End Enum

    Private Sub FensAnim(ByVal Fenster As Form, ByVal Art As FensAnimArt, ByVal Effekt As FensAnimEffekt, ByVal Richtung As FensAnimRichtung, ByVal Dauer_ms As Integer)

        ' Fehlerbehandlung aktivieren       
        Try
            Dim Flags As Integer = 0

            ' Flag Ein/Ausblenden
            Select Case Art
                Case FensAnimArt.EINBLENDEN
                    Flags += AW_ACTIVATE
                Case FensAnimArt.AUSBLENDEN
                    Flags += AW_HIDE
            End Select

            ' Effect-Flag addieren
            Select Case Effekt
                Case FensAnimEffekt.ROLLEN_SEITE
                    Flags += 0
                Case FensAnimEffekt.ROLLEN_MITTE
                    Flags += AW_CENTER
                Case FensAnimEffekt.SCHIEBEN
                    Flags += AW_SLIDE
                Case FensAnimEffekt.DIMMEN
                    Flags += AW_BLEND
            End Select

            ' Richtungs-Flags addieren
            Select Case Richtung
                Case FensAnimRichtung.N
                    Flags += AW_VER_NEGATIVE
                Case FensAnimRichtung.NO
                    Flags += AW_VER_NEGATIVE + AW_HOR_POSITIVE
                Case FensAnimRichtung.O
                    Flags += AW_HOR_POSITIVE
                Case FensAnimRichtung.SO
                    Flags += AW_VER_POSITIVE + AW_HOR_POSITIVE
                Case FensAnimRichtung.S
                    Flags += AW_VER_POSITIVE
                Case FensAnimRichtung.SW
                    Flags += AW_VER_POSITIVE + AW_HOR_NEGATIVE
                Case FensAnimRichtung.W
                    Flags += AW_HOR_NEGATIVE
                Case FensAnimRichtung.NW
                    Flags += AW_VER_NEGATIVE + AW_HOR_NEGATIVE
            End Select

            ' Animation ausführen
            ' (Programm/Thread ist solange pausiert)
            AnimateWindow(Fenster.Handle.ToInt32, Dauer_ms, Flags)
        Catch : End Try

        ' sicherheits Fenster anzeigen/verstecken
        ' (falls Animation fehlschlägt!)
        Select Case Art
            Case FensAnimArt.EINBLENDEN
                Fenster.Show()
            Case FensAnimArt.AUSBLENDEN
                Fenster.Hide()
        End Select

        ' sicherheitshalber Neuzeichnen
        ' (um Grafikfehler zu vermeiden)
        Fenster.Refresh()
    End Sub

#End Region

    Private Function DoesProcessExists(ByVal PName As String) As Boolean
        Return System.Diagnostics.Process.GetProcessesByName(PName).Length >= 1
    End Function

    Private Function OS_Extra_Graphics()
        If My.Computer.Info.OSFullName.Contains("Windows Vista") Then
            Return "1"
        ElseIf My.Computer.Info.OSFullName.Contains("Windows 7") Then
            Return "1"
        ElseIf My.Computer.Info.OSFullName.Contains("Windows 8") Then
            Return "1"
        Else
            Return "0"
        End If
    End Function

    Public Sub SwitchToXMB()
        FensAnim(Me, FensAnimArt.AUSBLENDEN, FensAnimEffekt.DIMMEN, FensAnimRichtung.N, 200)
        Me.Visible = False

        FensAnim(XMB, FensAnimArt.EINBLENDEN, FensAnimEffekt.DIMMEN, FensAnimRichtung.N, 200)
        XMB.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Boot_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        StartUpHook.Close()
    End Sub

    Private Sub XMB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        taskBars = FindWindow("Shell_traywnd", "")
        SetWindowPos(taskBars, 0&, 0&, 0&, 0&, 0&, SWP_HIDEWINDOW)

        Me.Size = New Size(1920, 1080)
        Me.ClientSize = New Size(1920, 1080)
        Me.WindowState = FormWindowState.Maximized

        BootMPlayer.uiMode = "none"
        BootMPlayer.settings.volume = 70
        BootMPlayer.Dock = DockStyle.Fill
        BootMPlayer.stretchToFit = True

        BootMPlayer.URL = My.Computer.FileSystem.CurrentDirectory + "\media\xmb.wmv"

    End Sub

    Public Function getFiles(ByVal SourceFolder As String, ByVal Filter As String, ByVal searchOption As SearchOption) As String()

        Dim alFiles As ArrayList = New ArrayList()

        Dim MultipleFilters() As String = Filter.Split("|")

        For Each FileFilter As String In MultipleFilters
            alFiles.AddRange(Directory.GetFiles(SourceFolder, FileFilter, searchOption))
        Next

        Return alFiles.ToArray(Type.GetType("System.String"))
    End Function

    Private Sub BootMPlayer_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles BootMPlayer.PlayStateChange

        If e.newState = BootMPlayer.playState.wmppsMediaEnded Then

            SetWindowPos(taskBars, 0&, 0&, 0&, 0&, 0&, SWP_SHOWWINDOW)

            If Functions.INI_ReadValueFromFile("UserDetails", "Password", "", ".\users\user1.ini") <> "" Then

                FensAnim(Me, FensAnimArt.AUSBLENDEN, FensAnimEffekt.DIMMEN, FensAnimRichtung.N, 200)
                Me.Visible = False

                FensAnim(Lockscreen, FensAnimArt.EINBLENDEN, FensAnimEffekt.DIMMEN, FensAnimRichtung.N, 200)
                Lockscreen.WindowState = FormWindowState.Maximized

            Else

                SwitchToXMB()

            End If

        End If

    End Sub

End Class
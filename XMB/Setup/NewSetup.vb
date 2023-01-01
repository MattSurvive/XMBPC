Imports Transitions
Imports Microsoft.Win32

Public Class NewSetup

    Dim joy As New AForge.Controls.Joystick()

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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If SetupTxt.Text = "Hi, " + Environment.UserName + "!" Then

            SetupTxt.Text = "Welcome to XMBPC!"

        ElseIf SetupTxt.Text = "Welcome to XMBPC!" Then

            SetupTxt.Text = "Setup is starting now..."
            Timer2.Start()

        ElseIf SetupTxt.Text = "Setup is starting now..." Then

            SetupTxt.Visible = False
            Timer1.Stop()
            Timer2.Stop()

            PictureBox1.Visible = True
            UsernameTxt.Visible = True
            StartWithWinTxt.Visible = True
            StartWithWin.Visible = True
            SelectLangTxt.Visible = True
            LangBox.Visible = True
            ContinueBox.Visible = True
            UserTxt.Visible = True
            PassTxt.Visible = True
            PasswordTxt.Visible = True

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))

            transition.add(PictureBox1, "Top", 200)

            transition.add(UserTxt, "Top", 340)
            transition.add(UsernameTxt, "Top", 380)

            transition.add(PassTxt, "Top", 410)
            transition.add(PasswordTxt, "Top", 450)

            transition.add(StartWithWinTxt, "Top", 500)
            transition.add(StartWithWin, "Top", 540)

            transition.add(SelectLangTxt, "Top", 580)
            transition.add(LangBox, "Top", 620)

            transition.add(ContinueBox, "Top", 680)

            transition.run()

        End If


    End Sub

    Private Sub NewSetup_Load(sender As Object, e As EventArgs) Handles Me.Load

        SetupTxt.Text = "Hi, " + Environment.UserName + "!"
        UsernameTxt.Text = Environment.UserName

        Timer1.Start()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        SetupTxt.Glow += 1

        If SetupTxt.Glow = 10 Then
            SetupTxt.Glow = 0
        End If
    End Sub

    Private Sub ContinueBox_Click(sender As Object, e As EventArgs) Handles ContinueBox.Click

        Functions.INI_WriteValueToFile("System", "Language", LangBox.SelectedItem.ToString, ".\system\sys.ini")
        Functions.INI_WriteValueToFile("System", "Background", "Standard", ".\system\sys.ini")

        Functions.INI_WriteValueToFile("UserDetails", "Username", UsernameTxt.Text, ".\users\user1.ini")
        Functions.INI_WriteValueToFile("UserDetails", "Password", MD5StringHash(PasswordTxt.Text), ".\users\user1.ini")

        If StartWithWin.Checked Then
            Autostart(True)
        End If

        FensAnim(NewSetup_SecondPart, FensAnimArt.EINBLENDEN, FensAnimEffekt.DIMMEN, FensAnimRichtung.N, 300)
        NewSetup_SecondPart.WindowState = FormWindowState.Maximized

    End Sub

End Class
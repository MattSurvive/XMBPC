Public Class Lockscreen

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

    Public Sub SwitchToXMB()
        FensAnim(Me, FensAnimArt.AUSBLENDEN, FensAnimEffekt.DIMMEN, FensAnimRichtung.N, 200)
        Me.Visible = False

        FensAnim(XMB, FensAnimArt.EINBLENDEN, FensAnimEffekt.DIMMEN, FensAnimRichtung.N, 200)
        XMB.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Lockscreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UsernameTxt.Text = Environment.UserName
    End Sub

    Private Sub ContinueBox_Click(sender As Object, e As EventArgs) Handles ContinueBox.Click

        Dim pw As String = Functions.INI_ReadValueFromFile("UserDetails", "Password", "", ".\users\user1.ini")

        If MD5StringHash(PasswordTxt.Text) = pw Then
            SwitchToXMB()
        Else
            MsgBox("Entered password is not correct!", MsgBoxStyle.Critical, "Authentication failed")
        End If

    End Sub

    Private Sub PasswordTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles PasswordTxt.KeyDown

        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True

            Dim pw As String = Functions.INI_ReadValueFromFile("UserDetails", "Password", "", ".\users\user1.ini")

            If MD5StringHash(PasswordTxt.Text) = pw Then
                SwitchToXMB()
            Else
                MsgBox("Entered password is not correct!", MsgBoxStyle.Critical, "Authentication failed")
            End If

        End If

    End Sub

End Class
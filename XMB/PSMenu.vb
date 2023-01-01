Imports AForge.Controls
Imports System.Runtime.InteropServices

Public Class PSMenu

    Dim info As List(Of AForge.Controls.Joystick.DeviceInfo) = AForge.Controls.Joystick.GetAvailableDevices
    Dim joy As New AForge.Controls.Joystick
    <DllImport("user32.dll")> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As Int32) As Short
    End Function

    Private Sub ControlBottom()
        If quitgame.Focused = True Then
            Me.ActiveControl = turnoffsystem
        ElseIf turnoffsystem.Focused = True Then
            Me.ActiveControl = quitgame
        End If
    End Sub

    Private Sub ControlTop()
        If quitgame.Focused = True Then
            Me.ActiveControl = turnoffsystem
        ElseIf turnoffsystem.Focused = True Then
            Me.ActiveControl = quitgame
        End If
    End Sub

    Private Sub quitgame_GotFocus(sender As Object, e As EventArgs) Handles quitgame.GotFocus
        quitgame.GlowState = True
    End Sub

    Private Sub turnoffsystem_GotFocus(sender As Object, e As EventArgs) Handles turnoffsystem.GotFocus
        turnoffsystem.GlowState = True
    End Sub

    Private Sub quitgame_LostFocus(sender As Object, e As EventArgs) Handles quitgame.LostFocus
        quitgame.GlowState = False
    End Sub

    Private Sub turnoffsystem_LostFocus(sender As Object, e As EventArgs) Handles turnoffsystem.LostFocus
        turnoffsystem.GlowState = False
    End Sub

    Private Sub ControllerTimer_Tick(sender As Object, e As EventArgs) Handles ControllerTimer.Tick
        Dim status As AForge.Controls.Joystick.Status = joy.GetCurrentStatus

        If status.YAxis = 1 Or GetAsyncKeyState(Keys.Down) Then
            ControlBottom()

            If XMB.currentgamestate = "" Then
                My.Computer.Audio.Play(".\media\xmb_browse_tick.wav", AudioPlayMode.Background)
            End If

        ElseIf status.YAxis = -1 Or GetAsyncKeyState(Keys.Up) Then
            ControlTop()

            If XMB.currentgamestate = "" Then
                My.Computer.Audio.Play(".\media\xmb_browse_tick.wav", AudioPlayMode.Background)
            End If
        End If

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or GetAsyncKeyState(Keys.Enter) Then

            If turnoffsystem.Focused = True Then
                XMB.Close()
            End If

            If quitgame.Focused = True Then

                If XMB.currentgamestate = "game1" Then
                    Try
                        XMB.Game1Start.Kill()
                    Catch ex As Exception
                    End Try
                ElseIf XMB.currentgamestate = "ps2" Then
                    Try
                        XMB.PS2GameStart.Kill()
                    Catch ex As Exception
                    End Try
                ElseIf XMB.currentgamestate = "ps1" Then
                    Try
                        XMB.PS1GameStart.Kill()
                    Catch ex As Exception
                    End Try
                ElseIf XMB.currentgamestate = "psp" Then
                    Try
                        XMB.PSPGameStart.Kill()
                    Catch ex As Exception
                    End Try
                ElseIf XMB.currentgamestate = "retro" Then
                    Try
                        XMB.RetroGameStart.Kill()
                    Catch ex As Exception
                    End Try
                ElseIf XMB.currentgamestate = "nintendo" Then
                    Try
                        XMB.NintendoGameStart.Kill()
                    Catch ex As Exception
                    End Try
                End If

                XMB.CallPSButton()
                XMB.Focus()
                XMB.Activate()
                XMB.BringToFront()
                XMB.ActiveControl = XMB.Home
            End If

        End If

    End Sub

    Private Sub KeyboardTimer_Tick(sender As Object, e As EventArgs) Handles KeyboardTimer.Tick

        If GetAsyncKeyState(Keys.Down) Then
            ControlBottom()

            If XMB.currentgamestate = "" Then
                My.Computer.Audio.Play(".\media\xmb_browse_tick.wav", AudioPlayMode.Background)
            End If

        ElseIf GetAsyncKeyState(Keys.Up) Then
            ControlTop()

            If XMB.currentgamestate = "" Then
                My.Computer.Audio.Play(".\media\xmb_browse_tick.wav", AudioPlayMode.Background)
            End If
        End If

        If GetAsyncKeyState(Keys.Enter) Then

            If turnoffsystem.Focused = True Then
                XMB.Close()
            End If

            If quitgame.Focused = True Then

                If XMB.currentgamestate = "game1" Then
                    Try
                        XMB.Game1Start.Kill()
                    Catch ex As Exception
                    End Try
                ElseIf XMB.currentgamestate = "ps2" Then
                    Try
                        XMB.PS2GameStart.Kill()
                    Catch ex As Exception
                    End Try
                ElseIf XMB.currentgamestate = "ps1" Then
                    Try
                        XMB.PS1GameStart.Kill()
                    Catch ex As Exception
                    End Try
                ElseIf XMB.currentgamestate = "psp" Then
                    Try
                        XMB.PSPGameStart.Kill()
                    Catch ex As Exception
                    End Try
                ElseIf XMB.currentgamestate = "retro" Then
                    Try
                        XMB.RetroGameStart.Kill()
                    Catch ex As Exception
                    End Try
                ElseIf XMB.currentgamestate = "nintendo" Then
                    Try
                        XMB.NintendoGameStart.Kill()
                    Catch ex As Exception
                    End Try
                End If

                XMB.CallPSButton()
                XMB.Focus()
                XMB.Activate()
                XMB.BringToFront()
                XMB.ActiveControl = XMB.Home
            End If

        End If

    End Sub

    Private Sub PSMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If info.Count = 0 Then
            KeyboardTimer.Start()
        Else
            joy = New Joystick(0)
            ControllerTimer.Start()
        End If

        If Not LangLoader.INI_ReadValueFromFile("System", "Language", "", ".\system\sys.ini") = "English" Then
            quitgame.Text = LangLoader.GetStringOfLang("PSMenu", "QuitGame")
            turnoffsystem.Text = LangLoader.GetStringOfLang("PSMenu", "TurnOff")
        End If

        Me.ActiveControl = quitgame
    End Sub

End Class
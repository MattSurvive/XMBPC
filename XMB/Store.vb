Imports AForge.Controls
Imports System.Net
Imports System.IO

Public Class Store

    Dim info As List(Of Joystick.DeviceInfo) = Joystick.GetAvailableDevices
    Dim joy As New Joystick
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Long) As Integer

    Dim WithEvents dlclient As WebClient = New WebClient()
    Dim WithEvents dlclient1 As WebClient = New WebClient()
    Dim WithEvents dlclient2 As WebClient = New WebClient()
    Dim WithEvents dlclient3 As WebClient = New WebClient()

    Private Sub Store_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UserName.Text = XMB.UserLoginName.Text
        UserStatus.Text = XMB.UserDescr.Text
        UserAvatar.Image = XMB.UserAvatar.Image

        If info.Count = 0 Then
            KeyboardTimer.Start()
        Else
            joy = New Joystick(0)
            ControllerTimer.Start()
        End If

        dlclient.DownloadFileAsync(New Uri("http://85.31.189.150/XMBPCE/DL/store/gba.txt"), ".\roms\gba.txt")
        StoreVer.Text = dlclient1.DownloadString(New Uri("http://85.31.189.150/XMBPCE/STORE.txt"))
        dlclient2.DownloadFileAsync(New Uri("http://85.31.189.150/XMBPCE/DL/store/nes.txt"), ".\roms\nes.txt")
        dlclient3.DownloadFileAsync(New Uri("http://85.31.189.150/XMBPCE/DL/store/sega.txt"), ".\roms\sega.txt")

        Me.ActiveControl = HomeTxt
    End Sub

#Region "Hovers"

    Private Sub HomeTxt_GotFocus(sender As Object, e As EventArgs) Handles HomeTxt.GotFocus
        DropGlowOfText(HomeTxt)
    End Sub

    Private Sub GBATxt_GotFocus(sender As Object, e As EventArgs) Handles GBATxt.GotFocus
        DropGlowOfText(GBATxt)
    End Sub

    Private Sub GBCTxt_GotFocus(sender As Object, e As EventArgs) Handles GBCTxt.GotFocus
        DropGlowOfText(GBCTxt)
    End Sub

    Private Sub NESTxt_GotFocus(sender As Object, e As EventArgs) Handles NESTxt.GotFocus
        DropGlowOfText(NESTxt)
    End Sub

    Private Sub SEGATxt_GotFocus(sender As Object, e As EventArgs) Handles SEGATxt.GotFocus
        DropGlowOfText(SEGATxt)
    End Sub

    Private Sub SNESTxt_GotFocus(sender As Object, e As EventArgs) Handles SNESTxt.GotFocus
        DropGlowOfText(SNESTxt)
    End Sub

    Private Sub HomeTxt_LostFocus(sender As Object, e As EventArgs) Handles HomeTxt.LostFocus
        DropGlowOfText(HomeTxt)
    End Sub

    Private Sub GBATxt_LostFocus(sender As Object, e As EventArgs) Handles GBATxt.LostFocus
        DropGlowOfText(GBATxt)
    End Sub

    Private Sub GBCTxt_LostFocus(sender As Object, e As EventArgs) Handles GBCTxt.LostFocus
        DropGlowOfText(GBCTxt)
    End Sub

    Private Sub NESTxt_LostFocus(sender As Object, e As EventArgs) Handles NESTxt.LostFocus
        DropGlowOfText(NESTxt)
    End Sub

    Private Sub SEGATxt_LostFocus(sender As Object, e As EventArgs) Handles SEGATxt.LostFocus
        DropGlowOfText(SEGATxt)
    End Sub

    Private Sub SNESTxt_LostFocus(sender As Object, e As EventArgs) Handles SNESTxt.LostFocus
        DropGlowOfText(SNESTxt)
    End Sub

#End Region

    Public Sub LoadGBAFiles()

        Game1.Image = My.Resources.gba
        Game2.Image = My.Resources.gba
        Game3.Image = My.Resources.gba
        Game4.Image = My.Resources.gba
        Game5.Image = My.Resources.gba
        Game6.Image = My.Resources.gba
        Game7.Image = My.Resources.gba
        Game8.Image = My.Resources.gba
        Game9.Image = My.Resources.gba
        Game10.Image = My.Resources.gba
        Game11.Image = My.Resources.gba
        Game12.Image = My.Resources.gba

        Game1Txt.Text = File.ReadAllLines(".\roms\gba.txt")(0).Split(";")(0)
        Game2Txt.Text = File.ReadAllLines(".\roms\gba.txt")(1).Split(";")(0)
        Game3Txt.Text = File.ReadAllLines(".\roms\gba.txt")(2).Split(";")(0)
        Game4Txt.Text = File.ReadAllLines(".\roms\gba.txt")(3).Split(";")(0)
        Game5Txt.Text = File.ReadAllLines(".\roms\gba.txt")(4).Split(";")(0)
        Game6Txt.Text = File.ReadAllLines(".\roms\gba.txt")(5).Split(";")(0)
        Game7Txt.Text = File.ReadAllLines(".\roms\gba.txt")(6).Split(";")(0)
        Game8Txt.Text = File.ReadAllLines(".\roms\gba.txt")(7).Split(";")(0)
        Game9Txt.Text = File.ReadAllLines(".\roms\gba.txt")(8).Split(";")(0)
        Game10Txt.Text = File.ReadAllLines(".\roms\gba.txt")(9).Split(";")(0)
        Game11Txt.Text = File.ReadAllLines(".\roms\gba.txt")(10).Split(";")(0)
        Game12Txt.Text = File.ReadAllLines(".\roms\gba.txt")(11).Split(";")(0)

        Game1.Tag = File.ReadAllLines(".\roms\gba.txt")(0).Split(";")(1)
        Game2.Tag = File.ReadAllLines(".\roms\gba.txt")(1).Split(";")(1)
        Game3.Tag = File.ReadAllLines(".\roms\gba.txt")(2).Split(";")(1)
        Game4.Tag = File.ReadAllLines(".\roms\gba.txt")(3).Split(";")(1)
        Game5.Tag = File.ReadAllLines(".\roms\gba.txt")(4).Split(";")(1)
        Game6.Tag = File.ReadAllLines(".\roms\gba.txt")(5).Split(";")(1)
        Game7.Tag = File.ReadAllLines(".\roms\gba.txt")(6).Split(";")(1)
        Game8.Tag = File.ReadAllLines(".\roms\gba.txt")(7).Split(";")(1)
        Game9.Tag = File.ReadAllLines(".\roms\gba.txt")(8).Split(";")(1)
        Game10.Tag = File.ReadAllLines(".\roms\gba.txt")(9).Split(";")(1)
        Game11.Tag = File.ReadAllLines(".\roms\gba.txt")(10).Split(";")(1)
        Game12.Tag = File.ReadAllLines(".\roms\gba.txt")(11).Split(";")(1)

    End Sub

    Public Sub LoadNESFiles()

        Game1.Image = My.Resources.nes
        Game2.Image = My.Resources.nes
        Game3.Image = My.Resources.nes
        Game4.Image = My.Resources.nes
        Game5.Image = My.Resources.nes
        Game6.Image = My.Resources.nes
        Game7.Image = My.Resources.nes
        Game8.Image = My.Resources.nes
        Game9.Image = My.Resources.nes
        Game10.Image = My.Resources.nes
        Game11.Image = My.Resources.nes
        Game12.Image = My.Resources.nes

        Game1Txt.Text = File.ReadAllLines(".\roms\nes.txt")(0).Split(";")(0)
        Game2Txt.Text = File.ReadAllLines(".\roms\nes.txt")(1).Split(";")(0)
        Game3Txt.Text = File.ReadAllLines(".\roms\nes.txt")(2).Split(";")(0)
        Game4Txt.Text = File.ReadAllLines(".\roms\nes.txt")(3).Split(";")(0)
        Game5Txt.Text = File.ReadAllLines(".\roms\nes.txt")(4).Split(";")(0)
        Game6Txt.Text = File.ReadAllLines(".\roms\nes.txt")(5).Split(";")(0)
        Game7Txt.Text = File.ReadAllLines(".\roms\nes.txt")(6).Split(";")(0)
        Game8Txt.Text = File.ReadAllLines(".\roms\nes.txt")(7).Split(";")(0)
        Game9Txt.Text = File.ReadAllLines(".\roms\nes.txt")(8).Split(";")(0)
        Game10Txt.Text = File.ReadAllLines(".\roms\nes.txt")(9).Split(";")(0)
        Game11Txt.Text = File.ReadAllLines(".\roms\nes.txt")(10).Split(";")(0)
        Game12Txt.Text = File.ReadAllLines(".\roms\nes.txt")(11).Split(";")(0)

        Game1.Tag = File.ReadAllLines(".\roms\nes.txt")(0).Split(";")(1)
        Game2.Tag = File.ReadAllLines(".\roms\nes.txt")(1).Split(";")(1)
        Game3.Tag = File.ReadAllLines(".\roms\nes.txt")(2).Split(";")(1)
        Game4.Tag = File.ReadAllLines(".\roms\nes.txt")(3).Split(";")(1)
        Game5.Tag = File.ReadAllLines(".\roms\nes.txt")(4).Split(";")(1)
        Game6.Tag = File.ReadAllLines(".\roms\nes.txt")(5).Split(";")(1)
        Game7.Tag = File.ReadAllLines(".\roms\nes.txt")(6).Split(";")(1)
        Game8.Tag = File.ReadAllLines(".\roms\nes.txt")(7).Split(";")(1)
        Game9.Tag = File.ReadAllLines(".\roms\nes.txt")(8).Split(";")(1)
        Game10.Tag = File.ReadAllLines(".\roms\nes.txt")(9).Split(";")(1)
        Game11.Tag = File.ReadAllLines(".\roms\nes.txt")(10).Split(";")(1)
        Game12.Tag = File.ReadAllLines(".\roms\nes.txt")(11).Split(";")(1)

    End Sub

    Public Sub LoadSEGAFiles()

        Game1.Image = My.Resources.sega
        Game2.Image = My.Resources.sega
        Game3.Image = My.Resources.sega
        Game4.Image = My.Resources.sega
        Game5.Image = My.Resources.sega
        Game6.Image = My.Resources.sega
        Game7.Image = My.Resources.sega
        Game8.Image = My.Resources.sega
        Game9.Image = My.Resources.sega
        Game10.Image = My.Resources.sega
        Game11.Image = My.Resources.sega
        Game12.Image = My.Resources.sega

        Game1Txt.Text = File.ReadAllLines(".\roms\sega.txt")(0).Split(";")(0)
        Game2Txt.Text = File.ReadAllLines(".\roms\sega.txt")(1).Split(";")(0)
        Game3Txt.Text = File.ReadAllLines(".\roms\sega.txt")(2).Split(";")(0)
        Game4Txt.Text = File.ReadAllLines(".\roms\sega.txt")(3).Split(";")(0)
        Game5Txt.Text = File.ReadAllLines(".\roms\sega.txt")(4).Split(";")(0)
        Game6Txt.Text = File.ReadAllLines(".\roms\sega.txt")(5).Split(";")(0)
        Game7Txt.Text = File.ReadAllLines(".\roms\sega.txt")(6).Split(";")(0)
        Game8Txt.Text = File.ReadAllLines(".\roms\sega.txt")(7).Split(";")(0)
        Game9Txt.Text = File.ReadAllLines(".\roms\sega.txt")(8).Split(";")(0)
        Game10Txt.Text = File.ReadAllLines(".\roms\sega.txt")(9).Split(";")(0)
        Game11Txt.Text = File.ReadAllLines(".\roms\sega.txt")(10).Split(";")(0)
        Game12Txt.Text = File.ReadAllLines(".\roms\sega.txt")(11).Split(";")(0)

        Game1.Tag = File.ReadAllLines(".\roms\sega.txt")(0).Split(";")(1)
        Game2.Tag = File.ReadAllLines(".\roms\sega.txt")(1).Split(";")(1)
        Game3.Tag = File.ReadAllLines(".\roms\sega.txt")(2).Split(";")(1)
        Game4.Tag = File.ReadAllLines(".\roms\sega.txt")(3).Split(";")(1)
        Game5.Tag = File.ReadAllLines(".\roms\sega.txt")(4).Split(";")(1)
        Game6.Tag = File.ReadAllLines(".\roms\sega.txt")(5).Split(";")(1)
        Game7.Tag = File.ReadAllLines(".\roms\sega.txt")(6).Split(";")(1)
        Game8.Tag = File.ReadAllLines(".\roms\sega.txt")(7).Split(";")(1)
        Game9.Tag = File.ReadAllLines(".\roms\sega.txt")(8).Split(";")(1)
        Game10.Tag = File.ReadAllLines(".\roms\sega.txt")(9).Split(";")(1)
        Game11.Tag = File.ReadAllLines(".\roms\sega.txt")(10).Split(";")(1)
        Game12.Tag = File.ReadAllLines(".\roms\sega.txt")(11).Split(";")(1)

    End Sub

    Private Sub ControlMenuBottom()
        If HomeTxt.Focused = True Then
            Me.ActiveControl = GBATxt
        ElseIf GBATxt.Focused = True Then
            Me.ActiveControl = GBCTxt
        ElseIf GBCTxt.Focused = True Then
            Me.ActiveControl = SNESTxt
        ElseIf SNESTxt.Focused = True Then
            Me.ActiveControl = NESTxt
        ElseIf NESTxt.Focused = True Then
            Me.ActiveControl = SEGATxt
        ElseIf SEGATxt.Focused = True Then
            Me.ActiveControl = HomeTxt
        End If
    End Sub

    Private Sub ControlMenuTop()
        If HomeTxt.Focused = True Then
            Me.ActiveControl = SEGATxt
        ElseIf SEGATxt.Focused = True Then
            Me.ActiveControl = NESTxt
        ElseIf NESTxt.Focused = True Then
            Me.ActiveControl = SNESTxt
        ElseIf SNESTxt.Focused = True Then
            Me.ActiveControl = GBCTxt
        ElseIf GBCTxt.Focused = True Then
            Me.ActiveControl = GBATxt
        ElseIf GBATxt.Focused = True Then
            Me.ActiveControl = HomeTxt
        End If
    End Sub

    Private Sub DropGlowOfText(ByVal Lab As gLabel.gLabel)

        If Lab.GlowState = True Then
            Lab.GlowState = False
        Else
            Lab.GlowState = True
        End If

    End Sub

    Private Sub ControllerTimer_Tick(sender As Object, e As EventArgs) Handles ControllerTimer.Tick
        Dim status As AForge.Controls.Joystick.Status = joy.GetCurrentStatus

        If status.YAxis = 1 Or GetAsyncKeyState(Keys.Down) Then
            ControlMenuBottom()
        ElseIf status.YAxis = -1 Or GetAsyncKeyState(Keys.Up) Then
            ControlMenuTop()
        End If

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button2) = True Or GetAsyncKeyState(Keys.Escape) Then
            Me.Close()

            XMB.Enabled = True
            XMB.BringToFront()
            XMB.Activate()
            XMB.ActiveControl = XMB.Home

        End If

    End Sub

    Private Sub KeyboardTimer_Tick(sender As Object, e As EventArgs) Handles KeyboardTimer.Tick

        If GetAsyncKeyState(Keys.Down) Then
            ControlMenuBottom()
        ElseIf GetAsyncKeyState(Keys.Up) Then
            ControlMenuTop()
        End If

        If GetAsyncKeyState(Keys.Escape) Then
            Me.Close()

            XMB.Enabled = True
            XMB.BringToFront()
            XMB.Activate()
            XMB.ActiveControl = XMB.Home

        End If

    End Sub

    Private Sub GBATxt_Click(sender As Object, e As EventArgs) Handles GBATxt.Click
        LoadGBAFiles()
        CategoryTxt.Text = "Gameboy Advance Roms"
    End Sub

    Private Sub NESTxt_Click(sender As Object, e As EventArgs) Handles NESTxt.Click
        LoadNESFiles()
        CategoryTxt.Text = "Nintendo Roms"
    End Sub

    Private Sub SEGATxt_Click(sender As Object, e As EventArgs) Handles SEGATxt.Click
        LoadSEGAFiles()
        CategoryTxt.Text = "Sega Roms"
    End Sub

End Class
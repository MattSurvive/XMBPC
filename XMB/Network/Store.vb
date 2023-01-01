Imports AForge.Controls
Imports System.Net
Imports System.IO
Imports System.Runtime.InteropServices

Public Class Store

    Dim info As List(Of Joystick.DeviceInfo) = Joystick.GetAvailableDevices
    Dim joy As New Joystick
    <DllImport("user32.dll")> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As Int32) As Short
    End Function

    Dim WithEvents dlclient As WebClient = New WebClient()
    Dim WithEvents dlclient1 As WebClient = New WebClient()
    Dim WithEvents dlclient2 As WebClient = New WebClient()
    Dim WithEvents dlclient3 As WebClient = New WebClient()
    Dim WithEvents dlclient4 As WebClient = New WebClient()
    Dim WithEvents dlclient5 As WebClient = New WebClient()
    Dim WithEvents dlclient6 As WebClient = New WebClient()

    Public game1index As Integer
    Public game2index As Integer
    Public game3index As Integer
    Public game4index As Integer
    Public game5index As Integer
    Public game6index As Integer
    Public game7index As Integer
    Public game8index As Integer
    Public game9index As Integer
    Public game10index As Integer
    Public game11index As Integer
    Public game12index As Integer

    Dim currentgames As Integer
    Public currentpkg As String

    Dim gameslist As New List(Of String)

    Private Sub Store_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            File.Delete(".\roms\gba.txt")
            File.Delete(".\roms\nes.txt")
            File.Delete(".\roms\snes.txt")
            File.Delete(".\roms\gbc.txt")
            File.Delete(".\roms\sega.txt")
            File.Delete(".\system\tools.txt")

            If XMB.Enabled = False Then
                XMB.Enabled = True
                XMB.ActiveControl = XMB.Home
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Store_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UserName.Text = XMB.UserLoginName.Text
        UserStatus.Text = XMB.UserDescr.Text

        If info.Count = 0 Then
            KeyboardTimer.Start()
        Else
            joy = New Joystick(0)
            ControllerTimer.Start()
        End If

        If Not Directory.Exists(".\roms") Then
            Directory.CreateDirectory(".\roms")
        End If

        dlclient.DownloadFileAsync(New Uri("http://85.31.189.150/XMBPCE/DL/store/gba.txt"), ".\roms\gba.txt")
        StoreVer.Text = dlclient1.DownloadString(New Uri("http://85.31.189.150/XMBPCE/STORE.txt"))
        dlclient2.DownloadFileAsync(New Uri("http://85.31.189.150/XMBPCE/DL/store/nes.txt"), ".\roms\nes.txt")
        dlclient3.DownloadFileAsync(New Uri("http://85.31.189.150/XMBPCE/DL/store/sega.txt"), ".\roms\sega.txt")
        dlclient4.DownloadFileAsync(New Uri("http://85.31.189.150/XMBPCE/DL/store/snes.txt"), ".\roms\snes.txt")
        dlclient5.DownloadFileAsync(New Uri("http://85.31.189.150/XMBPCE/DL/store/gbc.txt"), ".\roms\gbc.txt")
        dlclient6.DownloadFileAsync(New Uri("http://85.31.189.150/XMBPCE/DL/store/tools.txt"), ".\system\tools.txt")

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

    Private Sub AddonsTools_GotFocus(sender As Object, e As EventArgs) Handles AddonsToolsTxt.GotFocus
        DropGlowOfText(AddonsToolsTxt)
    End Sub

    Private Sub AddonsTools_LostFocus(sender As Object, e As EventArgs) Handles AddonsToolsTxt.LostFocus
        DropGlowOfText(AddonsToolsTxt)
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

    Public Sub MakeVisible(Optional ByVal special As Boolean = False)

        If Not Game1.Visible And special = False Then
            Game1.Visible = True
            Game2.Visible = True
            Game3.Visible = True
            Game4.Visible = True
            Game5.Visible = True
            Game6.Visible = True
            Game7.Visible = True
            Game8.Visible = True
            Game9.Visible = True
            Game10.Visible = True
            Game11.Visible = True
            Game12.Visible = True

            Game1Txt.Visible = True
            Game2Txt.Visible = True
            Game3Txt.Visible = True
            Game4Txt.Visible = True
            Game5Txt.Visible = True
            Game6Txt.Visible = True
            Game7Txt.Visible = True
            Game8Txt.Visible = True
            Game9Txt.Visible = True
            Game10Txt.Visible = True
            Game11Txt.Visible = True
            Game12Txt.Visible = True

            BrowseNext.Visible = True
        ElseIf Not Game1.Visible And special = True Then
            Game1.Visible = True
            Game2.Visible = True
            Game3.Visible = True
            Game4.Visible = True
            Game5.Visible = True
            Game6.Visible = True
            Game7.Visible = True
            Game8.Visible = False
            Game9.Visible = False
            Game10.Visible = False
            Game11.Visible = False
            Game12.Visible = False

            Game1Txt.Visible = True
            Game2Txt.Visible = True
            Game3Txt.Visible = True
            Game4Txt.Visible = True
            Game5Txt.Visible = True
            Game6Txt.Visible = True
            Game7Txt.Visible = True
            Game8Txt.Visible = False
            Game9Txt.Visible = False
            Game10Txt.Visible = False
            Game11Txt.Visible = False
            Game12Txt.Visible = False
        ElseIf Game1.Visible And special = True Then
            Game8.Visible = False
            Game9.Visible = False
            Game10.Visible = False
            Game11.Visible = False
            Game12.Visible = False

            Game8Txt.Visible = False
            Game9Txt.Visible = False
            Game10Txt.Visible = False
            Game11Txt.Visible = False
            Game12Txt.Visible = False
        ElseIf Game1.Visible And special = False Then
            Game1.Visible = True
            Game2.Visible = True
            Game3.Visible = True
            Game4.Visible = True
            Game5.Visible = True
            Game6.Visible = True
            Game7.Visible = True
            Game8.Visible = True
            Game9.Visible = True
            Game10.Visible = True
            Game11.Visible = True
            Game12.Visible = True

            Game1Txt.Visible = True
            Game2Txt.Visible = True
            Game3Txt.Visible = True
            Game4Txt.Visible = True
            Game5Txt.Visible = True
            Game6Txt.Visible = True
            Game7Txt.Visible = True
            Game8Txt.Visible = True
            Game9Txt.Visible = True
            Game10Txt.Visible = True
            Game11Txt.Visible = True
            Game12Txt.Visible = True

            BrowseNext.Visible = True
        End If
    End Sub

    Public Sub LoadGBAFiles()

        MakeVisible(False)
        CategoryTxt.Text = "Gameboy Advance Roms"
        gameslist.Clear()

        For Each games In File.ReadAllLines(".\roms\gba.txt")
            gameslist.Add(games)
        Next

        currentgames = 12

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

        Game1Txt.Text = gameslist(0).Split(";")(0)
        Game2Txt.Text = gameslist(1).Split(";")(0)
        Game3Txt.Text = gameslist(2).Split(";")(0)
        Game4Txt.Text = gameslist(3).Split(";")(0)
        Game5Txt.Text = gameslist(4).Split(";")(0)
        Game6Txt.Text = gameslist(5).Split(";")(0)
        Game7Txt.Text = gameslist(6).Split(";")(0)
        Game8Txt.Text = gameslist(7).Split(";")(0)
        Game9Txt.Text = gameslist(8).Split(";")(0)
        Game10Txt.Text = gameslist(9).Split(";")(0)
        Game11Txt.Text = gameslist(10).Split(";")(0)
        Game12Txt.Text = gameslist(11).Split(";")(0)

        Game1.Tag = gameslist(0).Split(";")(1)
        Game2.Tag = gameslist(1).Split(";")(1)
        Game3.Tag = gameslist(2).Split(";")(1)
        Game4.Tag = gameslist(3).Split(";")(1)
        Game5.Tag = gameslist(4).Split(";")(1)
        Game6.Tag = gameslist(5).Split(";")(1)
        Game7.Tag = gameslist(6).Split(";")(1)
        Game8.Tag = gameslist(7).Split(";")(1)
        Game9.Tag = gameslist(8).Split(";")(1)
        Game10.Tag = gameslist(9).Split(";")(1)
        Game11.Tag = gameslist(10).Split(";")(1)
        Game12.Tag = gameslist(11).Split(";")(1)

    End Sub

    Public Sub LoadNESFiles()

        MakeVisible(False)
        CategoryTxt.Text = "Nintendo Roms"
        gameslist.Clear()

        For Each games In File.ReadAllLines(".\roms\nes.txt")
            gameslist.Add(games)
        Next

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

        Game1Txt.Text = gameslist(0).Split(";")(0)
        Game2Txt.Text = gameslist(1).Split(";")(0)
        Game3Txt.Text = gameslist(2).Split(";")(0)
        Game4Txt.Text = gameslist(3).Split(";")(0)
        Game5Txt.Text = gameslist(4).Split(";")(0)
        Game6Txt.Text = gameslist(5).Split(";")(0)
        Game7Txt.Text = gameslist(6).Split(";")(0)
        Game8Txt.Text = gameslist(7).Split(";")(0)
        Game9Txt.Text = gameslist(8).Split(";")(0)
        Game10Txt.Text = gameslist(9).Split(";")(0)
        Game11Txt.Text = gameslist(10).Split(";")(0)
        Game12Txt.Text = gameslist(11).Split(";")(0)

        Game1.Tag = gameslist(0).Split(";")(1)
        Game2.Tag = gameslist(1).Split(";")(1)
        Game3.Tag = gameslist(2).Split(";")(1)
        Game4.Tag = gameslist(3).Split(";")(1)
        Game5.Tag = gameslist(4).Split(";")(1)
        Game6.Tag = gameslist(5).Split(";")(1)
        Game7.Tag = gameslist(6).Split(";")(1)
        Game8.Tag = gameslist(7).Split(";")(1)
        Game9.Tag = gameslist(8).Split(";")(1)
        Game10.Tag = gameslist(9).Split(";")(1)
        Game11.Tag = gameslist(10).Split(";")(1)
        Game12.Tag = gameslist(11).Split(";")(1)

    End Sub

    Public Sub LoadSEGAFiles()

        MakeVisible(False)
        CategoryTxt.Text = "Sega Roms"
        gameslist.Clear()

        For Each games In File.ReadAllLines(".\roms\sega.txt")
            gameslist.Add(games)
        Next

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

        Game1Txt.Text = gameslist(0).Split(";")(0)
        Game2Txt.Text = gameslist(1).Split(";")(0)
        Game3Txt.Text = gameslist(2).Split(";")(0)
        Game4Txt.Text = gameslist(3).Split(";")(0)
        Game5Txt.Text = gameslist(4).Split(";")(0)
        Game6Txt.Text = gameslist(5).Split(";")(0)
        Game7Txt.Text = gameslist(6).Split(";")(0)
        Game8Txt.Text = gameslist(7).Split(";")(0)
        Game9Txt.Text = gameslist(8).Split(";")(0)
        Game10Txt.Text = gameslist(9).Split(";")(0)
        Game11Txt.Text = gameslist(10).Split(";")(0)
        Game12Txt.Text = gameslist(11).Split(";")(0)

        Game1.Tag = gameslist(0).Split(";")(1)
        Game2.Tag = gameslist(1).Split(";")(1)
        Game3.Tag = gameslist(2).Split(";")(1)
        Game4.Tag = gameslist(3).Split(";")(1)
        Game5.Tag = gameslist(4).Split(";")(1)
        Game6.Tag = gameslist(5).Split(";")(1)
        Game7.Tag = gameslist(6).Split(";")(1)
        Game8.Tag = gameslist(7).Split(";")(1)
        Game9.Tag = gameslist(8).Split(";")(1)
        Game10.Tag = gameslist(9).Split(";")(1)
        Game11.Tag = gameslist(10).Split(";")(1)
        Game12.Tag = gameslist(11).Split(";")(1)

    End Sub

    Public Sub LoadSNESFiles()

        MakeVisible(False)
        CategoryTxt.Text = "Super Nintendo Roms"
        gameslist.Clear()

        For Each games In File.ReadAllLines(".\roms\snes.txt")
            gameslist.Add(games)
        Next

        Game1.Image = My.Resources.snesi
        Game2.Image = My.Resources.snesi
        Game3.Image = My.Resources.snesi
        Game4.Image = My.Resources.snesi
        Game5.Image = My.Resources.snesi
        Game6.Image = My.Resources.snesi
        Game7.Image = My.Resources.snesi
        Game8.Image = My.Resources.snesi
        Game9.Image = My.Resources.snesi
        Game10.Image = My.Resources.snesi
        Game11.Image = My.Resources.snesi
        Game12.Image = My.Resources.snesi

        Game1Txt.Text = gameslist(0).Split(";")(0)
        Game2Txt.Text = gameslist(1).Split(";")(0)
        Game3Txt.Text = gameslist(2).Split(";")(0)
        Game4Txt.Text = gameslist(3).Split(";")(0)
        Game5Txt.Text = gameslist(4).Split(";")(0)
        Game6Txt.Text = gameslist(5).Split(";")(0)
        Game7Txt.Text = gameslist(6).Split(";")(0)
        Game8Txt.Text = gameslist(7).Split(";")(0)
        Game9Txt.Text = gameslist(8).Split(";")(0)
        Game10Txt.Text = gameslist(9).Split(";")(0)
        Game11Txt.Text = gameslist(10).Split(";")(0)
        Game12Txt.Text = gameslist(11).Split(";")(0)

        Game1.Tag = gameslist(0).Split(";")(1)
        Game2.Tag = gameslist(1).Split(";")(1)
        Game3.Tag = gameslist(2).Split(";")(1)
        Game4.Tag = gameslist(3).Split(";")(1)
        Game5.Tag = gameslist(4).Split(";")(1)
        Game6.Tag = gameslist(5).Split(";")(1)
        Game7.Tag = gameslist(6).Split(";")(1)
        Game8.Tag = gameslist(7).Split(";")(1)
        Game9.Tag = gameslist(8).Split(";")(1)
        Game10.Tag = gameslist(9).Split(";")(1)
        Game11.Tag = gameslist(10).Split(";")(1)
        Game12.Tag = gameslist(11).Split(";")(1)

    End Sub

    Public Sub LoadGBCFiles()

        MakeVisible(False)
        CategoryTxt.Text = "Gameboy Color Roms"
        gameslist.Clear()

        For Each games In File.ReadAllLines(".\roms\gbc.txt")
            gameslist.Add(games)
        Next

        Game1.Image = My.Resources.gbc
        Game2.Image = My.Resources.gbc
        Game3.Image = My.Resources.gbc
        Game4.Image = My.Resources.gbc
        Game5.Image = My.Resources.gbc
        Game6.Image = My.Resources.gbc
        Game7.Image = My.Resources.gbc
        Game8.Image = My.Resources.gbc
        Game9.Image = My.Resources.gbc
        Game10.Image = My.Resources.gbc
        Game11.Image = My.Resources.gbc
        Game12.Image = My.Resources.gbc

        Game1Txt.Text = gameslist(0).Split(";")(0)
        Game2Txt.Text = gameslist(1).Split(";")(0)
        Game3Txt.Text = gameslist(2).Split(";")(0)
        Game4Txt.Text = gameslist(3).Split(";")(0)
        Game5Txt.Text = gameslist(4).Split(";")(0)
        Game6Txt.Text = gameslist(5).Split(";")(0)
        Game7Txt.Text = gameslist(6).Split(";")(0)
        Game8Txt.Text = gameslist(7).Split(";")(0)
        Game9Txt.Text = gameslist(8).Split(";")(0)
        Game10Txt.Text = gameslist(9).Split(";")(0)
        Game11Txt.Text = gameslist(10).Split(";")(0)
        Game12Txt.Text = gameslist(11).Split(";")(0)

        Game1.Tag = gameslist(0).Split(";")(1)
        Game2.Tag = gameslist(1).Split(";")(1)
        Game3.Tag = gameslist(2).Split(";")(1)
        Game4.Tag = gameslist(3).Split(";")(1)
        Game5.Tag = gameslist(4).Split(";")(1)
        Game6.Tag = gameslist(5).Split(";")(1)
        Game7.Tag = gameslist(6).Split(";")(1)
        Game8.Tag = gameslist(7).Split(";")(1)
        Game9.Tag = gameslist(8).Split(";")(1)
        Game10.Tag = gameslist(9).Split(";")(1)
        Game11.Tag = gameslist(10).Split(";")(1)
        Game12.Tag = gameslist(11).Split(";")(1)

    End Sub

    Public Sub LoadAddonsToolsFiles()

        MakeVisible(True)
        CategoryTxt.Text = "Addons / Tools"
        gameslist.Clear()

        For Each games In File.ReadAllLines(".\system\tools.txt")
            gameslist.Add(games)
        Next

        Game1.Image = My.Resources.addons_icon
        Game2.Image = My.Resources.addons_icon
        Game3.Image = My.Resources.addons_icon
        Game4.Image = My.Resources.addons_icon
        Game5.Image = My.Resources.addons_icon
        Game6.Image = My.Resources.addons_icon
        Game7.Image = My.Resources.addons_icon

        Game1Txt.Text = gameslist(0).Split(";")(0)
        Game2Txt.Text = gameslist(1).Split(";")(0)
        Game3Txt.Text = gameslist(2).Split(";")(0)
        Game4Txt.Text = gameslist(3).Split(";")(0)
        Game5Txt.Text = gameslist(4).Split(";")(0)
        Game6Txt.Text = gameslist(5).Split(";")(0)
        Game7Txt.Text = gameslist(6).Split(";")(0)

        Game1.Tag = gameslist(0).Split(";")(1)
        Game2.Tag = gameslist(1).Split(";")(1)
        Game3.Tag = gameslist(2).Split(";")(1)
        Game4.Tag = gameslist(3).Split(";")(1)
        Game5.Tag = gameslist(4).Split(";")(1)
        Game6.Tag = gameslist(5).Split(";")(1)
        Game7.Tag = gameslist(6).Split(";")(1)

    End Sub

    Private Sub BrowseNext_Click(sender As Object, e As EventArgs) Handles BrowseNext.Click
        If CategoryTxt.Text = "Gameboy Advance Roms" Then
            LoadNextGBAFiles()
        ElseIf CategoryTxt.Text = "Nintendo Roms" Then
            LoadNextNESFiles()
        ElseIf CategoryTxt.Text = "Sega Roms" Then
            LoadNextSEGAFiles()
        ElseIf CategoryTxt.Text = "Super Nintendo Roms" Then
            LoadNextSNESFiles()
        ElseIf CategoryTxt.Text = "Gameboy Color Roms" Then
            LoadNextGBCFiles()
        End If

        BrowseLast.Visible = True

    End Sub

    Private Sub BrowseLast_Click(sender As Object, e As EventArgs) Handles BrowseLast.Click
        If CategoryTxt.Text = "Gameboy Advance Roms" Then
            LoadLastGBAFiles()
        ElseIf CategoryTxt.Text = "Nintendo Roms" Then
            LoadLastNESFiles()
        ElseIf CategoryTxt.Text = "Sega Roms" Then
            LoadLastSEGAFiles()
        ElseIf CategoryTxt.Text = "Super Nintendo Roms" Then
            LoadLastSNESFiles()
        ElseIf CategoryTxt.Text = "Gameboy Color Roms" Then
            LoadLastGBCFiles()
        End If

        If currentgames = 12 Then
            BrowseLast.Visible = False
        End If

    End Sub

    Public Sub LoadNextGBAFiles()

        On Error Resume Next

        Game1Txt.Text = gameslist(currentgames + 1).Split(";")(0)
        Game1.Tag = gameslist(currentgames + 1).Split(";")(1)

        Game2Txt.Text = gameslist(currentgames + 2).Split(";")(0)
        Game2.Tag = gameslist(currentgames + 2).Split(";")(1)

        Game3Txt.Text = gameslist(currentgames + 3).Split(";")(0)
        Game3.Tag = gameslist(currentgames + 3).Split(";")(1)

        Game4Txt.Text = gameslist(currentgames + 4).Split(";")(0)
        Game4.Tag = gameslist(currentgames + 4).Split(";")(1)

        Game5Txt.Text = gameslist(currentgames + 5).Split(";")(0)
        Game5.Tag = gameslist(currentgames + 5).Split(";")(1)

        Game6Txt.Text = gameslist(currentgames + 6).Split(";")(0)
        Game6.Tag = gameslist(currentgames + 6).Split(";")(1)

        Game7Txt.Text = gameslist(currentgames + 7).Split(";")(0)
        Game7.Tag = gameslist(currentgames + 7).Split(";")(1)

        Game8Txt.Text = gameslist(currentgames + 8).Split(";")(0)
        Game8.Tag = gameslist(currentgames + 8).Split(";")(1)

        Game9Txt.Text = gameslist(currentgames + 9).Split(";")(0)
        Game9.Tag = gameslist(currentgames + 9).Split(";")(1)

        Game10Txt.Text = gameslist(currentgames + 10).Split(";")(0)
        Game10.Tag = gameslist(currentgames + 10).Split(";")(1)

        Game11Txt.Text = gameslist(currentgames + 11).Split(";")(0)
        Game11.Tag = gameslist(currentgames + 11).Split(";")(1)

        Game12Txt.Text = gameslist(currentgames + 12).Split(";")(0)
        Game12.Tag = gameslist(currentgames + 12).Split(";")(1)

        currentgames = currentgames + 12

    End Sub

    Public Sub LoadNextNESFiles()

        On Error Resume Next

        Game1Txt.Text = gameslist(currentgames + 1).Split(";")(0)
        Game1.Tag = gameslist(currentgames + 1).Split(";")(1)

        Game2Txt.Text = gameslist(currentgames + 2).Split(";")(0)
        Game2.Tag = gameslist(currentgames + 2).Split(";")(1)

        Game3Txt.Text = gameslist(currentgames + 3).Split(";")(0)
        Game3.Tag = gameslist(currentgames + 3).Split(";")(1)

        Game4Txt.Text = gameslist(currentgames + 4).Split(";")(0)
        Game4.Tag = gameslist(currentgames + 4).Split(";")(1)

        Game5Txt.Text = gameslist(currentgames + 5).Split(";")(0)
        Game5.Tag = gameslist(currentgames + 5).Split(";")(1)

        Game6Txt.Text = gameslist(currentgames + 6).Split(";")(0)
        Game6.Tag = gameslist(currentgames + 6).Split(";")(1)

        Game7Txt.Text = gameslist(currentgames + 7).Split(";")(0)
        Game7.Tag = gameslist(currentgames + 7).Split(";")(1)

        Game8Txt.Text = gameslist(currentgames + 8).Split(";")(0)
        Game8.Tag = gameslist(currentgames + 8).Split(";")(1)

        Game9Txt.Text = gameslist(currentgames + 9).Split(";")(0)
        Game9.Tag = gameslist(currentgames + 9).Split(";")(1)

        Game10Txt.Text = gameslist(currentgames + 10).Split(";")(0)
        Game10.Tag = gameslist(currentgames + 10).Split(";")(1)

        Game11Txt.Text = gameslist(currentgames + 11).Split(";")(0)
        Game11.Tag = gameslist(currentgames + 11).Split(";")(1)

        Game12Txt.Text = gameslist(currentgames + 12).Split(";")(0)
        Game12.Tag = gameslist(currentgames + 12).Split(";")(1)

        currentgames = currentgames + 12

    End Sub

    Public Sub LoadNextSEGAFiles()

        On Error Resume Next

        Game1Txt.Text = gameslist(currentgames + 1).Split(";")(0)
        Game1.Tag = gameslist(currentgames + 1).Split(";")(1)

        Game2Txt.Text = gameslist(currentgames + 2).Split(";")(0)
        Game2.Tag = gameslist(currentgames + 2).Split(";")(1)

        Game3Txt.Text = gameslist(currentgames + 3).Split(";")(0)
        Game3.Tag = gameslist(currentgames + 3).Split(";")(1)

        Game4Txt.Text = gameslist(currentgames + 4).Split(";")(0)
        Game4.Tag = gameslist(currentgames + 4).Split(";")(1)

        Game5Txt.Text = gameslist(currentgames + 5).Split(";")(0)
        Game5.Tag = gameslist(currentgames + 5).Split(";")(1)

        Game6Txt.Text = gameslist(currentgames + 6).Split(";")(0)
        Game6.Tag = gameslist(currentgames + 6).Split(";")(1)

        Game7Txt.Text = gameslist(currentgames + 7).Split(";")(0)
        Game7.Tag = gameslist(currentgames + 7).Split(";")(1)

        Game8Txt.Text = gameslist(currentgames + 8).Split(";")(0)
        Game8.Tag = gameslist(currentgames + 8).Split(";")(1)

        Game9Txt.Text = gameslist(currentgames + 9).Split(";")(0)
        Game9.Tag = gameslist(currentgames + 9).Split(";")(1)

        Game10Txt.Text = gameslist(currentgames + 10).Split(";")(0)
        Game10.Tag = gameslist(currentgames + 10).Split(";")(1)

        Game11Txt.Text = gameslist(currentgames + 11).Split(";")(0)
        Game11.Tag = gameslist(currentgames + 11).Split(";")(1)

        Game12Txt.Text = gameslist(currentgames + 12).Split(";")(0)
        Game12.Tag = gameslist(currentgames + 12).Split(";")(1)

        currentgames = currentgames + 12

    End Sub

    Public Sub LoadNextSNESFiles()

        On Error Resume Next

        Game1Txt.Text = gameslist(currentgames + 1).Split(";")(0)
        Game1.Tag = gameslist(currentgames + 1).Split(";")(1)

        Game2Txt.Text = gameslist(currentgames + 2).Split(";")(0)
        Game2.Tag = gameslist(currentgames + 2).Split(";")(1)

        Game3Txt.Text = gameslist(currentgames + 3).Split(";")(0)
        Game3.Tag = gameslist(currentgames + 3).Split(";")(1)

        Game4Txt.Text = gameslist(currentgames + 4).Split(";")(0)
        Game4.Tag = gameslist(currentgames + 4).Split(";")(1)

        Game5Txt.Text = gameslist(currentgames + 5).Split(";")(0)
        Game5.Tag = gameslist(currentgames + 5).Split(";")(1)

        Game6Txt.Text = gameslist(currentgames + 6).Split(";")(0)
        Game6.Tag = gameslist(currentgames + 6).Split(";")(1)

        Game7Txt.Text = gameslist(currentgames + 7).Split(";")(0)
        Game7.Tag = gameslist(currentgames + 7).Split(";")(1)

        Game8Txt.Text = gameslist(currentgames + 8).Split(";")(0)
        Game8.Tag = gameslist(currentgames + 8).Split(";")(1)

        Game9Txt.Text = gameslist(currentgames + 9).Split(";")(0)
        Game9.Tag = gameslist(currentgames + 9).Split(";")(1)

        Game10Txt.Text = gameslist(currentgames + 10).Split(";")(0)
        Game10.Tag = gameslist(currentgames + 10).Split(";")(1)

        Game11Txt.Text = gameslist(currentgames + 11).Split(";")(0)
        Game11.Tag = gameslist(currentgames + 11).Split(";")(1)

        Game12Txt.Text = gameslist(currentgames + 12).Split(";")(0)
        Game12.Tag = gameslist(currentgames + 12).Split(";")(1)

        currentgames = currentgames + 12

    End Sub

    Public Sub LoadNextGBCFiles()

        On Error Resume Next

        Game1Txt.Text = gameslist(currentgames + 1).Split(";")(0)
        Game1.Tag = gameslist(currentgames + 1).Split(";")(1)

        Game2Txt.Text = gameslist(currentgames + 2).Split(";")(0)
        Game2.Tag = gameslist(currentgames + 2).Split(";")(1)

        Game3Txt.Text = gameslist(currentgames + 3).Split(";")(0)
        Game3.Tag = gameslist(currentgames + 3).Split(";")(1)

        Game4Txt.Text = gameslist(currentgames + 4).Split(";")(0)
        Game4.Tag = gameslist(currentgames + 4).Split(";")(1)

        Game5Txt.Text = gameslist(currentgames + 5).Split(";")(0)
        Game5.Tag = gameslist(currentgames + 5).Split(";")(1)

        Game6Txt.Text = gameslist(currentgames + 6).Split(";")(0)
        Game6.Tag = gameslist(currentgames + 6).Split(";")(1)

        Game7Txt.Text = gameslist(currentgames + 7).Split(";")(0)
        Game7.Tag = gameslist(currentgames + 7).Split(";")(1)

        Game8Txt.Text = gameslist(currentgames + 8).Split(";")(0)
        Game8.Tag = gameslist(currentgames + 8).Split(";")(1)

        Game9Txt.Text = gameslist(currentgames + 9).Split(";")(0)
        Game9.Tag = gameslist(currentgames + 9).Split(";")(1)

        Game10Txt.Text = gameslist(currentgames + 10).Split(";")(0)
        Game10.Tag = gameslist(currentgames + 10).Split(";")(1)

        Game11Txt.Text = gameslist(currentgames + 11).Split(";")(0)
        Game11.Tag = gameslist(currentgames + 11).Split(";")(1)

        Game12Txt.Text = gameslist(currentgames + 12).Split(";")(0)
        Game12.Tag = gameslist(currentgames + 12).Split(";")(1)

        currentgames = currentgames + 12

    End Sub

    Public Sub LoadLastGBAFiles()

        On Error Resume Next

        Game1Txt.Text = gameslist(currentgames - 24).Split(";")(0)
        Game1.Tag = gameslist(currentgames - 24).Split(";")(1)

        Game2Txt.Text = gameslist(currentgames - 23).Split(";")(0)
        Game2.Tag = gameslist(currentgames - 23).Split(";")(1)

        Game3Txt.Text = gameslist(currentgames - 22).Split(";")(0)
        Game3.Tag = gameslist(currentgames - 22).Split(";")(1)

        Game4Txt.Text = gameslist(currentgames - 21).Split(";")(0)
        Game4.Tag = gameslist(currentgames - 21).Split(";")(1)

        Game5Txt.Text = gameslist(currentgames - 20).Split(";")(0)
        Game5.Tag = gameslist(currentgames - 20).Split(";")(1)

        Game6Txt.Text = gameslist(currentgames - 19).Split(";")(0)
        Game6.Tag = gameslist(currentgames - 19).Split(";")(1)

        Game7Txt.Text = gameslist(currentgames - 18).Split(";")(0)
        Game7.Tag = gameslist(currentgames - 18).Split(";")(1)

        Game8Txt.Text = gameslist(currentgames - 17).Split(";")(0)
        Game8.Tag = gameslist(currentgames - 17).Split(";")(1)

        Game9Txt.Text = gameslist(currentgames - 16).Split(";")(0)
        Game9.Tag = gameslist(currentgames - 16).Split(";")(1)

        Game10Txt.Text = gameslist(currentgames - 15).Split(";")(0)
        Game10.Tag = gameslist(currentgames - 15).Split(";")(1)

        Game11Txt.Text = gameslist(currentgames - 14).Split(";")(0)
        Game11.Tag = gameslist(currentgames - 14).Split(";")(1)

        Game12Txt.Text = gameslist(currentgames - 13).Split(";")(0)
        Game12.Tag = gameslist(currentgames - 13).Split(";")(1)

        currentgames = currentgames - 12

    End Sub

    Public Sub LoadLastNESFiles()

        On Error Resume Next

        Game1Txt.Text = gameslist(currentgames - 24).Split(";")(0)
        Game1.Tag = gameslist(currentgames - 24).Split(";")(1)

        Game2Txt.Text = gameslist(currentgames - 23).Split(";")(0)
        Game2.Tag = gameslist(currentgames - 23).Split(";")(1)

        Game3Txt.Text = gameslist(currentgames - 22).Split(";")(0)
        Game3.Tag = gameslist(currentgames - 22).Split(";")(1)

        Game4Txt.Text = gameslist(currentgames - 21).Split(";")(0)
        Game4.Tag = gameslist(currentgames - 21).Split(";")(1)

        Game5Txt.Text = gameslist(currentgames - 20).Split(";")(0)
        Game5.Tag = gameslist(currentgames - 20).Split(";")(1)

        Game6Txt.Text = gameslist(currentgames - 19).Split(";")(0)
        Game6.Tag = gameslist(currentgames - 19).Split(";")(1)

        Game7Txt.Text = gameslist(currentgames - 18).Split(";")(0)
        Game7.Tag = gameslist(currentgames - 18).Split(";")(1)

        Game8Txt.Text = gameslist(currentgames - 17).Split(";")(0)
        Game8.Tag = gameslist(currentgames - 17).Split(";")(1)

        Game9Txt.Text = gameslist(currentgames - 16).Split(";")(0)
        Game9.Tag = gameslist(currentgames - 16).Split(";")(1)

        Game10Txt.Text = gameslist(currentgames - 15).Split(";")(0)
        Game10.Tag = gameslist(currentgames - 15).Split(";")(1)

        Game11Txt.Text = gameslist(currentgames - 14).Split(";")(0)
        Game11.Tag = gameslist(currentgames - 14).Split(";")(1)

        Game12Txt.Text = gameslist(currentgames - 13).Split(";")(0)
        Game12.Tag = gameslist(currentgames - 13).Split(";")(1)

        currentgames = currentgames - 12

    End Sub

    Public Sub LoadLastSEGAFiles()

        On Error Resume Next

        Game1Txt.Text = gameslist(currentgames - 24).Split(";")(0)
        Game1.Tag = gameslist(currentgames - 24).Split(";")(1)

        Game2Txt.Text = gameslist(currentgames - 23).Split(";")(0)
        Game2.Tag = gameslist(currentgames - 23).Split(";")(1)

        Game3Txt.Text = gameslist(currentgames - 22).Split(";")(0)
        Game3.Tag = gameslist(currentgames - 22).Split(";")(1)

        Game4Txt.Text = gameslist(currentgames - 21).Split(";")(0)
        Game4.Tag = gameslist(currentgames - 21).Split(";")(1)

        Game5Txt.Text = gameslist(currentgames - 20).Split(";")(0)
        Game5.Tag = gameslist(currentgames - 20).Split(";")(1)

        Game6Txt.Text = gameslist(currentgames - 19).Split(";")(0)
        Game6.Tag = gameslist(currentgames - 19).Split(";")(1)

        Game7Txt.Text = gameslist(currentgames - 18).Split(";")(0)
        Game7.Tag = gameslist(currentgames - 18).Split(";")(1)

        Game8Txt.Text = gameslist(currentgames - 17).Split(";")(0)
        Game8.Tag = gameslist(currentgames - 17).Split(";")(1)

        Game9Txt.Text = gameslist(currentgames - 16).Split(";")(0)
        Game9.Tag = gameslist(currentgames - 16).Split(";")(1)

        Game10Txt.Text = gameslist(currentgames - 15).Split(";")(0)
        Game10.Tag = gameslist(currentgames - 15).Split(";")(1)

        Game11Txt.Text = gameslist(currentgames - 14).Split(";")(0)
        Game11.Tag = gameslist(currentgames - 14).Split(";")(1)

        Game12Txt.Text = gameslist(currentgames - 13).Split(";")(0)
        Game12.Tag = gameslist(currentgames - 13).Split(";")(1)

        currentgames = currentgames - 12

    End Sub

    Public Sub LoadLastSNESFiles()

        On Error Resume Next

        Game1Txt.Text = gameslist(currentgames - 24).Split(";")(0)
        Game1.Tag = gameslist(currentgames - 24).Split(";")(1)

        Game2Txt.Text = gameslist(currentgames - 23).Split(";")(0)
        Game2.Tag = gameslist(currentgames - 23).Split(";")(1)

        Game3Txt.Text = gameslist(currentgames - 22).Split(";")(0)
        Game3.Tag = gameslist(currentgames - 22).Split(";")(1)

        Game4Txt.Text = gameslist(currentgames - 21).Split(";")(0)
        Game4.Tag = gameslist(currentgames - 21).Split(";")(1)

        Game5Txt.Text = gameslist(currentgames - 20).Split(";")(0)
        Game5.Tag = gameslist(currentgames - 20).Split(";")(1)

        Game6Txt.Text = gameslist(currentgames - 19).Split(";")(0)
        Game6.Tag = gameslist(currentgames - 19).Split(";")(1)

        Game7Txt.Text = gameslist(currentgames - 18).Split(";")(0)
        Game7.Tag = gameslist(currentgames - 18).Split(";")(1)

        Game8Txt.Text = gameslist(currentgames - 17).Split(";")(0)
        Game8.Tag = gameslist(currentgames - 17).Split(";")(1)

        Game9Txt.Text = gameslist(currentgames - 16).Split(";")(0)
        Game9.Tag = gameslist(currentgames - 16).Split(";")(1)

        Game10Txt.Text = gameslist(currentgames - 15).Split(";")(0)
        Game10.Tag = gameslist(currentgames - 15).Split(";")(1)

        Game11Txt.Text = gameslist(currentgames - 14).Split(";")(0)
        Game11.Tag = gameslist(currentgames - 14).Split(";")(1)

        Game12Txt.Text = gameslist(currentgames - 13).Split(";")(0)
        Game12.Tag = gameslist(currentgames - 13).Split(";")(1)

        currentgames = currentgames - 12

    End Sub

    Public Sub LoadLastGBCFiles()

        On Error Resume Next

        Game1Txt.Text = gameslist(currentgames - 24).Split(";")(0)
        Game1.Tag = gameslist(currentgames - 24).Split(";")(1)

        Game2Txt.Text = gameslist(currentgames - 23).Split(";")(0)
        Game2.Tag = gameslist(currentgames - 23).Split(";")(1)

        Game3Txt.Text = gameslist(currentgames - 22).Split(";")(0)
        Game3.Tag = gameslist(currentgames - 22).Split(";")(1)

        Game4Txt.Text = gameslist(currentgames - 21).Split(";")(0)
        Game4.Tag = gameslist(currentgames - 21).Split(";")(1)

        Game5Txt.Text = gameslist(currentgames - 20).Split(";")(0)
        Game5.Tag = gameslist(currentgames - 20).Split(";")(1)

        Game6Txt.Text = gameslist(currentgames - 19).Split(";")(0)
        Game6.Tag = gameslist(currentgames - 19).Split(";")(1)

        Game7Txt.Text = gameslist(currentgames - 18).Split(";")(0)
        Game7.Tag = gameslist(currentgames - 18).Split(";")(1)

        Game8Txt.Text = gameslist(currentgames - 17).Split(";")(0)
        Game8.Tag = gameslist(currentgames - 17).Split(";")(1)

        Game9Txt.Text = gameslist(currentgames - 16).Split(";")(0)
        Game9.Tag = gameslist(currentgames - 16).Split(";")(1)

        Game10Txt.Text = gameslist(currentgames - 15).Split(";")(0)
        Game10.Tag = gameslist(currentgames - 15).Split(";")(1)

        Game11Txt.Text = gameslist(currentgames - 14).Split(";")(0)
        Game11.Tag = gameslist(currentgames - 14).Split(";")(1)

        Game12Txt.Text = gameslist(currentgames - 13).Split(";")(0)
        Game12.Tag = gameslist(currentgames - 13).Split(";")(1)

        currentgames = currentgames - 12

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
            Me.ActiveControl = AddonsToolsTxt
        ElseIf AddonsToolsTxt.Focused = True Then
            Me.ActiveControl = HomeTxt
        End If
    End Sub

    Private Sub ControlMenuTop()
        If HomeTxt.Focused = True Then
            Me.ActiveControl = AddonsToolsTxt
        ElseIf AddonsToolsTxt.Focused = True Then
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

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button5) And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button6) Or GetAsyncKeyState(Keys.R) And GetAsyncKeyState(Keys.S) Then
            If XMB.CurrentRadioState = "Playing" Then
                XMB.RadioPlayer.close()
                XMB.CurrentRadioState = "Stopped"
            End If
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button5) And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button6) Or GetAsyncKeyState(Keys.R) And GetAsyncKeyState(Keys.P) Then
            If XMB.CurrentRadioState = "Stopped" Then
                XMB.RadioPlayer.URL = XMB.CurrentRadioURL
                XMB.CurrentRadioState = "Playing"
            End If
        End If

        If status.XAxis = 1 Or GetAsyncKeyState(Keys.Right) Then

            If CategoryTxt.Text = "Gameboy Advance Roms" Then
                LoadNextGBAFiles()
            ElseIf CategoryTxt.Text = "Nintendo Roms" Then
                LoadNextNESFiles()
            ElseIf CategoryTxt.Text = "Sega Roms" Then
                LoadNextSEGAFiles()
            ElseIf CategoryTxt.Text = "Super Nintendo Roms" Then
                LoadNextSNESFiles()
            ElseIf CategoryTxt.Text = "Gameboy Color Roms" Then
                LoadNextGBCFiles()
            End If

            BrowseLast.Visible = True

        ElseIf status.XAxis = -1 Or GetAsyncKeyState(Keys.Left) Then

            If CategoryTxt.Text = "Gameboy Advance Roms" Then
                LoadLastGBAFiles()
            ElseIf CategoryTxt.Text = "Nintendo Roms" Then
                LoadLastNESFiles()
            ElseIf CategoryTxt.Text = "Sega Roms" Then
                LoadLastSEGAFiles()
            ElseIf CategoryTxt.Text = "Super Nintendo Roms" Then
                LoadLastSNESFiles()
            ElseIf CategoryTxt.Text = "Gameboy Color Roms" Then
                LoadLastGBCFiles()
            End If

            If currentgames = 12 Then
                BrowseLast.Visible = False
            End If

        End If

        If SNESTxt.Focused And GetAsyncKeyState(Keys.Enter) Or SNESTxt.Focused And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) Then
            LoadSNESFiles()
        ElseIf GBCTxt.Focused And GetAsyncKeyState(Keys.Enter) Or GBCTxt.Focused And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) Then
            LoadGBCFiles()
        ElseIf GBATxt.Focused And GetAsyncKeyState(Keys.Enter) Or GBATxt.Focused And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) Then
            LoadGBAFiles()
        ElseIf NESTxt.Focused And GetAsyncKeyState(Keys.Enter) Or NESTxt.Focused And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) Then
            LoadNESFiles()
        ElseIf SEGATxt.Focused And GetAsyncKeyState(Keys.Enter) Or SEGATxt.Focused And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) Then
            LoadSEGAFiles()
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

        If GetAsyncKeyState(Keys.R) And GetAsyncKeyState(Keys.S) Then
            If XMB.CurrentRadioState = "Playing" Then
                XMB.RadioPlayer.close()
                XMB.CurrentRadioState = "Stopped"
            End If
        ElseIf GetAsyncKeyState(Keys.R) And GetAsyncKeyState(Keys.P) Then
            If XMB.CurrentRadioState = "Stopped" Then
                XMB.RadioPlayer.URL = XMB.CurrentRadioURL
                XMB.CurrentRadioState = "Playing"
            End If
        End If

        If GetAsyncKeyState(Keys.Right) Then

            If CategoryTxt.Text = "Gameboy Advance Roms" Then
                LoadNextGBAFiles()
            ElseIf CategoryTxt.Text = "Nintendo Roms" Then
                LoadNextNESFiles()
            ElseIf CategoryTxt.Text = "Sega Roms" Then
                LoadNextSEGAFiles()
            ElseIf CategoryTxt.Text = "Super Nintendo Roms" Then
                LoadNextSNESFiles()
            ElseIf CategoryTxt.Text = "Gameboy Color Roms" Then
                LoadNextGBCFiles()
            End If

            BrowseLast.Visible = True

        ElseIf GetAsyncKeyState(Keys.Left) Then

            If CategoryTxt.Text = "Gameboy Advance Roms" Then
                LoadLastGBAFiles()
            ElseIf CategoryTxt.Text = "Nintendo Roms" Then
                LoadLastNESFiles()
            ElseIf CategoryTxt.Text = "Sega Roms" Then
                LoadLastSEGAFiles()
            ElseIf CategoryTxt.Text = "Super Nintendo Roms" Then
                LoadLastSNESFiles()
            ElseIf CategoryTxt.Text = "Gameboy Color Roms" Then
                LoadLastGBCFiles()
            End If

            If currentgames = 12 Then
                BrowseLast.Visible = False
            End If

        End If

        If SNESTxt.Focused And GetAsyncKeyState(Keys.Enter) Then
            LoadSNESFiles()
        ElseIf GBCTxt.Focused And GetAsyncKeyState(Keys.Enter) Then
            LoadGBCFiles()
        ElseIf GBATxt.Focused And GetAsyncKeyState(Keys.Enter) Then
            LoadGBAFiles()
        ElseIf NESTxt.Focused And GetAsyncKeyState(Keys.Enter) Then
            LoadNESFiles()
        ElseIf SEGATxt.Focused And GetAsyncKeyState(Keys.Enter) Then
            LoadSEGAFiles()
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
        Me.ActiveControl = GBATxt
        LoadGBAFiles()
    End Sub

    Private Sub NESTxt_Click(sender As Object, e As EventArgs) Handles NESTxt.Click
        Me.ActiveControl = NESTxt
        LoadNESFiles()
    End Sub

    Private Sub SEGATxt_Click(sender As Object, e As EventArgs) Handles SEGATxt.Click
        Me.ActiveControl = SEGATxt
        LoadSEGAFiles()
    End Sub

    Private Sub GBCTxt_Click(sender As Object, e As EventArgs) Handles GBCTxt.Click
        Me.ActiveControl = GBCTxt
        LoadGBCFiles()
    End Sub

    Private Sub SNESTxt_Click(sender As Object, e As EventArgs) Handles SNESTxt.Click
        Me.ActiveControl = SNESTxt
        LoadSNESFiles()
    End Sub

    Private Sub AddonsToolsTxt_Click(sender As Object, e As EventArgs) Handles AddonsToolsTxt.Click
        Me.ActiveControl = AddonsToolsTxt
        LoadAddonsToolsFiles()
    End Sub

    Private Sub Game1_Click(sender As Object, e As EventArgs) Handles Game1.Click

        SystemDialog.DialogTxt.Text = "Would you like to download " + Game1Txt.Text + " ?"
        SystemDialog.DialogPossibilities = "YESNO"

        If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.Yes Then

            If CategoryTxt.Text = "Addons / Tools" Then
                currentpkg = "TOOL"
            Else
                currentpkg = "GAME"
            End If

            BackgroundDownload.Show()
            BackgroundDownload.BringToFront()

            BackgroundDownload.DownloadStorePKG(Game1Txt.Text, Game1.Tag)

        End If

    End Sub

    Private Sub Game2_Click(sender As Object, e As EventArgs) Handles Game2.Click
        SystemDialog.DialogTxt.Text = "Would you like to download " + Game2Txt.Text + " ?"
        SystemDialog.DialogPossibilities = "YESNO"

        If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.Yes Then

            If CategoryTxt.Text = "Addons / Tools" Then
                currentpkg = "TOOL"
            Else
                currentpkg = "GAME"
            End If

            BackgroundDownload.Show()
            BackgroundDownload.BringToFront()

            BackgroundDownload.DownloadStorePKG(Game2Txt.Text, Game2.Tag)

        End If
    End Sub

    Private Sub Game3_Click(sender As Object, e As EventArgs) Handles Game3.Click
        SystemDialog.DialogTxt.Text = "Would you like to download " + Game3Txt.Text + " ?"
        SystemDialog.DialogPossibilities = "YESNO"

        If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.Yes Then

            If CategoryTxt.Text = "Addons / Tools" Then
                currentpkg = "TOOL"
            Else
                currentpkg = "GAME"
            End If

            BackgroundDownload.Show()
            BackgroundDownload.BringToFront()

            BackgroundDownload.DownloadStorePKG(Game3Txt.Text, Game3.Tag)

        End If
    End Sub

    Private Sub Game4_Click(sender As Object, e As EventArgs) Handles Game4.Click
        SystemDialog.DialogTxt.Text = "Would you like to download " + Game4Txt.Text + " ?"
        SystemDialog.DialogPossibilities = "YESNO"

        If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.Yes Then

            If CategoryTxt.Text = "Addons / Tools" Then
                currentpkg = "TOOL"
            Else
                currentpkg = "GAME"
            End If

            BackgroundDownload.Show()
            BackgroundDownload.BringToFront()

            BackgroundDownload.DownloadStorePKG(Game4Txt.Text, Game4.Tag)

        End If
    End Sub

    Private Sub Game5_Click(sender As Object, e As EventArgs) Handles Game5.Click
        SystemDialog.DialogTxt.Text = "Would you like to download " + Game5Txt.Text + " ?"
        SystemDialog.DialogPossibilities = "YESNO"

        If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.Yes Then

            If CategoryTxt.Text = "Addons / Tools" Then
                currentpkg = "TOOL"
            Else
                currentpkg = "GAME"
            End If

            BackgroundDownload.Show()
            BackgroundDownload.BringToFront()

            BackgroundDownload.DownloadStorePKG(Game5Txt.Text, Game5.Tag)

        End If
    End Sub

    Private Sub Game6_Click(sender As Object, e As EventArgs) Handles Game6.Click
        SystemDialog.DialogTxt.Text = "Would you like to download " + Game6Txt.Text + " ?"
        SystemDialog.DialogPossibilities = "YESNO"

        If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.Yes Then

            If CategoryTxt.Text = "Addons / Tools" Then
                currentpkg = "TOOL"
            Else
                currentpkg = "GAME"
            End If

            BackgroundDownload.Show()
            BackgroundDownload.BringToFront()

            BackgroundDownload.DownloadStorePKG(Game6Txt.Text, Game6.Tag)

        End If
    End Sub

    Private Sub Game7_Click(sender As Object, e As EventArgs) Handles Game7.Click
        SystemDialog.DialogTxt.Text = "Would you like to download " + Game7Txt.Text + " ?"
        SystemDialog.DialogPossibilities = "YESNO"

        If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.Yes Then

            If CategoryTxt.Text = "Addons / Tools" Then
                currentpkg = "TOOL"
            Else
                currentpkg = "GAME"
            End If

            BackgroundDownload.Show()
            BackgroundDownload.BringToFront()

            BackgroundDownload.DownloadStorePKG(Game7Txt.Text, Game7.Tag)

        End If
    End Sub

    Private Sub Game8_Click(sender As Object, e As EventArgs) Handles Game8.Click
        SystemDialog.DialogTxt.Text = "Would you like to download " + Game8Txt.Text + " ?"
        SystemDialog.DialogPossibilities = "YESNO"

        If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.Yes Then

            If CategoryTxt.Text = "Addons / Tools" Then
                currentpkg = "TOOL"
            Else
                currentpkg = "GAME"
            End If

            BackgroundDownload.Show()
            BackgroundDownload.BringToFront()

            BackgroundDownload.DownloadStorePKG(Game8Txt.Text, Game8.Tag)

        End If
    End Sub

    Private Sub Game9_Click(sender As Object, e As EventArgs) Handles Game9.Click
        SystemDialog.DialogTxt.Text = "Would you like to download " + Game9Txt.Text + " ?"
        SystemDialog.DialogPossibilities = "YESNO"

        If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.Yes Then

            If CategoryTxt.Text = "Addons / Tools" Then
                currentpkg = "TOOL"
            Else
                currentpkg = "GAME"
            End If

            BackgroundDownload.Show()
            BackgroundDownload.BringToFront()

            BackgroundDownload.DownloadStorePKG(Game9Txt.Text, Game9.Tag)

        End If
    End Sub

    Private Sub Game10_Click(sender As Object, e As EventArgs) Handles Game10.Click
        SystemDialog.DialogTxt.Text = "Would you like to download " + Game10Txt.Text + " ?"
        SystemDialog.DialogPossibilities = "YESNO"

        If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.Yes Then

            If CategoryTxt.Text = "Addons / Tools" Then
                currentpkg = "TOOL"
            Else
                currentpkg = "GAME"
            End If

            BackgroundDownload.Show()
            BackgroundDownload.BringToFront()

            BackgroundDownload.DownloadStorePKG(Game10Txt.Text, Game10.Tag)

        End If
    End Sub

    Private Sub Game11_Click(sender As Object, e As EventArgs) Handles Game11.Click
        SystemDialog.DialogTxt.Text = "Would you like to download " + Game11Txt.Text + " ?"
        SystemDialog.DialogPossibilities = "YESNO"

        If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.Yes Then

            If CategoryTxt.Text = "Addons / Tools" Then
                currentpkg = "TOOL"
            Else
                currentpkg = "GAME"
            End If

            BackgroundDownload.Show()
            BackgroundDownload.BringToFront()

            BackgroundDownload.DownloadStorePKG(Game11Txt.Text, Game11.Tag)

        End If
    End Sub

    Private Sub Game12_Click(sender As Object, e As EventArgs) Handles Game12.Click
        SystemDialog.DialogTxt.Text = "Would you like to download " + Game12Txt.Text + " ?"
        SystemDialog.DialogPossibilities = "YESNO"

        If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.Yes Then

            If CategoryTxt.Text = "Addons / Tools" Then
                currentpkg = "TOOL"
            Else
                currentpkg = "GAME"
            End If

            BackgroundDownload.Show()
            BackgroundDownload.BringToFront()

            BackgroundDownload.DownloadStorePKG(Game12Txt.Text, Game12.Tag)

        End If
    End Sub

End Class
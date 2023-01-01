Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports Microsoft.Win32
Imports HundredMilesSoftware.UltraID3Lib
Imports DiscUtils.Iso9660
Imports System.Text
Imports System.Net
Imports AForge.Controls
Imports Transitions
Imports WMPLib

Public Class XMB

    Dim info As List(Of Joystick.DeviceInfo) = Joystick.GetAvailableDevices
    Dim joy As New Joystick

    Public WithEvents MediaPlayer As New WindowsMediaPlayer()

    <DllImport("user32.dll")> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As Int32) As Short
    End Function

    Dim PS_Button_Background As New PictureBox
    Dim PS_Button_Controls As New PSMenu

    Public currentcategory As String
    Public currentxmbstate As String
    Public currentgamestate As String = ""
    Public currentvideostate As String = "unloaded"
    Public currentnetworkstate As String = "offline"
    Public currentnotificationstate As String = "unnotified"
    Public themechanged As Boolean = False
    Public themepath As String

    Public currenttrack As Integer
    Public currentvideos As Integer
    Public currentgames As Integer
    Public currentps2games As Integer
    Public currentretrogames As Integer
    Public currentnintendogames As Integer
    Public currentpictures As Integer

    Public musiclist As New List(Of String)
    Public videolist As New List(Of String)
    Public picturelist As New List(Of String)
    Public gameslist As New List(Of String)
    Public ps2gameslist As New List(Of String)
    Public retrogameslist As New List(Of String)
    Public nintendogameslist As New List(Of String)

    Public friendslist As New List(Of String)

    Public CurrentMusicTrack As String
    Public CurrentVideoTrack As String
    Public CurrentPictureTrack As String
    Public CurrentGameDisc As String

    Public CurrentRadioState As String
    Public CurrentRadioURL As String

    Public GameSect As String
    Public GameID As Integer
    Public GameFormat As String

    Public WithEvents Game1Start As New System.Diagnostics.Process()
    Public WithEvents Game2Start As New System.Diagnostics.Process()
    Public WithEvents PS2GameStart As New System.Diagnostics.Process()
    Public WithEvents PS1GameStart As New System.Diagnostics.Process()
    Public WithEvents PSPGameStart As New System.Diagnostics.Process()
    Public WithEvents RetroGameStart As New System.Diagnostics.Process()
    Public WithEvents NintendoGameStart As New System.Diagnostics.Process()

    Dim secondtime As Boolean = False
    Public GameDisc As Boolean = False

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

#Region "WINDOWS DECLARATIONS"

    Private Declare Function RegisterHotKey Lib "user32" (ByVal hWnd As IntPtr, ByVal id As Integer, ByVal fsModifier As Integer, ByVal vk As Integer) As Integer
    Private Declare Sub UnregisterHotKey Lib "user32" (ByVal hWnd As IntPtr, ByVal id As Integer)
    Private Const Key_NONE As Integer = &H0
    Private Const WM_HOTKEY As Integer = &H312
    Declare Auto Function FindWindow Lib "User32.dll" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Declare Auto Function SetForeGroundWindow Lib "User32.dll" (ByVal Hwnd As IntPtr) As Long
    Declare Function s Lib "winmm.dll" Alias "mciSendStringA" (ByVal ab As String, ByVal ass As String, ByVal ss As Integer, ByVal aas As Integer) As Integer
    Declare Function ExtractIcon Lib "shell32.dll" Alias "ExtractIconExA" (ByVal lpszFile As String, ByVal nIconIndex As Integer, ByRef phiconLarge As Integer, ByRef phiconSmall As Integer, ByVal nIcons As Integer) As Integer
    Private Const DBTF_MEDIA As UInteger = &H1
    Private Const DBT_DEVICEARRIVAL As UInteger = &H8000
    Private Const DBT_DEVICEREMOVECOMPLETE As UInteger = &H8004
    Private Const DBT_DEVTYP_VOLUME As UInteger = &H2
    Private m_UltraID3 As New UltraID3
    Private m_CurrentPictureFrame As ID3v23PictureFrame
    Private m_PictureTypes As ArrayList
    Private m_FileName As String
    Private m_PictureFrames As ID3FrameCollection
    Private m_PictureIndex As Integer
    Const SW_RESTORE As Int32 = 9

#End Region

#Region "WINDOWS FUNCTIONS"

    Private Structure DEV_BROADCAST_HDR
        Public dbch_size As Int32
        Public dbch_devicetype As Int32
        Public dbch_reserved As Int32
    End Structure

    Private Structure DEV_BROADCAST_VOLUME
        Public dbcv_size As Int32
        Public dbcv_devicetype As Int32
        Public dbcv_reserved As Int32
        Public dbcv_unitmask As Int32
        Public dbcv_flags As Int16
    End Structure

    Protected Function FirstDriveFromMask(ByVal Unit As Int32) As Char
        Dim Ix As Integer
        For Ix = 0 To 25
            If Unit And Ix Then Exit For
            Unit = Unit >> 1
        Next
        Return Chr(Ix + Asc("A"))
    End Function

    Public Function ReadLine(ByVal line As Integer, ByVal filepath As String) As String
        Try
            Dim lines As String() = File.ReadAllLines(filepath)

            If line > 0 Then
                Return lines(line - 1)
            ElseIf line < 0 Then
                Return lines(lines.Length + line - 1)
            Else
                Return ""
            End If

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.WParam.ToInt32
            Case DBT_DEVICEARRIVAL
                Dim b As DEV_BROADCAST_HDR
                b = Marshal.PtrToStructure(m.LParam, GetType(DEV_BROADCAST_HDR))

                If b.dbch_devicetype = DBT_DEVTYP_VOLUME Then
                    Dim c As DEV_BROADCAST_VOLUME
                    c = Marshal.PtrToStructure(m.LParam, GetType(DEV_BROADCAST_VOLUME))

                    If c.dbcv_flags And DBTF_MEDIA Then

                        For Each drive In DriveInfo.GetDrives()

                            If drive.DriveType = DriveType.CDRom And drive.IsReady = True Then

                                If File.Exists(drive.ToString() + "system.cnf") Then

                                    If ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT2 " Then
                                        CheckPS2Game(drive.ToString() + "system.cnf", 0)
                                        CurrentGameDisc = "PS2"

                                    ElseIf ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT2" Then
                                        CheckPS2Game(drive.ToString() + "system.cnf", 0)
                                        CurrentGameDisc = "PS2"

                                    ElseIf ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT " Then
                                        CheckPS1Game(drive.ToString() + "system.cnf", 0)
                                        CurrentGameDisc = "PS1"

                                    ElseIf ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT" Then
                                        CheckPS1Game(drive.ToString() + "system.cnf", 0)
                                        CurrentGameDisc = "PS1"

                                    End If

                                    SelectedGame.Tag = drive.ToString()
                                    GameDisc = True

                                    OldGame1.Visible = False
                                    OldGame1Text.Visible = False

                                    OldGame2.Visible = False
                                    OldGame2Text.Visible = False

                                    Game1.Tag = SplitGamePath(gameslist(0).ToString, 0)
                                    Game1Text.Text = SplitGamePath(gameslist(0).ToString, 1)
                                    Game1.Image = GetGameCover(gameslist(0).ToString)

                                    Game2.Tag = SplitGamePath(gameslist(1).ToString, 0)
                                    Game2Text.Text = SplitGamePath(gameslist(1).ToString, 1)
                                    Game2.Image = GetGameCover(gameslist(1).ToString)

                                    Game3.Tag = SplitGamePath(gameslist(2).ToString, 0)
                                    Game3Text.Text = SplitGamePath(gameslist(2).ToString, 1)
                                    Game3.Image = GetGameCover(gameslist(2).ToString)

                                    Game4.Tag = SplitGamePath(gameslist(3).ToString, 0)
                                    Game4Text.Text = SplitGamePath(gameslist(3).ToString, 1)
                                    Game4.Image = GetGameCover(gameslist(3).ToString)

                                    currentgames = 3

                                Else

                                    SelectedGameText.Text = LangLoader.GetStringOfLang("XMB", "FileDisc")
                                    SelectedGame.Image = My.Resources.disc_nameless
                                    SelectedGame.Tag = drive.ToString()

                                    OldGame1.Visible = False
                                    OldGame1Text.Visible = False

                                    OldGame2.Visible = False
                                    OldGame2Text.Visible = False

                                    Game1.Tag = SplitGamePath(gameslist(0).ToString, 0)
                                    Game1Text.Text = SplitGamePath(gameslist(0).ToString, 1)
                                    Game1.Image = GetGameCover(gameslist(0).ToString)

                                    Game2.Tag = SplitGamePath(gameslist(1).ToString, 0)
                                    Game2Text.Text = SplitGamePath(gameslist(1).ToString, 1)
                                    Game2.Image = GetGameCover(gameslist(1).ToString)

                                    Game3.Tag = SplitGamePath(gameslist(2).ToString, 0)
                                    Game3Text.Text = SplitGamePath(gameslist(2).ToString, 1)
                                    Game3.Image = GetGameCover(gameslist(2).ToString)

                                    Game4.Tag = SplitGamePath(gameslist(3).ToString, 0)
                                    Game4Text.Text = SplitGamePath(gameslist(3).ToString, 1)
                                    Game4.Image = GetGameCover(gameslist(3).ToString)

                                    currentgames = 3

                                    Me.ActiveControl = Games

                                End If

                            End If
                        Next
                    End If

                End If

            Case DBT_DEVICEREMOVECOMPLETE
                Dim b As DEV_BROADCAST_HDR
                b = Marshal.PtrToStructure(m.LParam, GetType(DEV_BROADCAST_HDR))

                If b.dbch_devicetype = DBT_DEVTYP_VOLUME Then
                    Dim c As DEV_BROADCAST_VOLUME
                    c = Marshal.PtrToStructure(m.LParam, GetType(DEV_BROADCAST_VOLUME))

                    If c.dbcv_flags And DBTF_MEDIA Then
                        SelectedGame.Image = My.Resources.disc_nameless
                        SelectedGameText.Text = "No disc inserted"
                        GameDisc = False
                    End If

                End If
        End Select

        MyBase.WndProc(m)
    End Sub

    Private Function ReturnIcon(ByVal Path As String, ByVal Index As Integer, Optional ByVal small As Boolean = False) As Icon
        Dim bigIcon As Integer
        Dim smallIcon As Integer

        ExtractIcon(Path, Index, bigIcon, smallIcon, 1)

        If bigIcon = 0 Then
            ExtractIcon(Path, 0, bigIcon, smallIcon, 1)
        End If

        If bigIcon <> 0 Then
            If small = False Then
                Return Icon.FromHandle(bigIcon)
            Else
                Return Icon.FromHandle(smallIcon)
            End If
        Else
            Return Nothing
        End If
    End Function

    Public Function CheckAddress(ByVal URL As String) As Boolean
        Try
            Dim request As WebRequest = WebRequest.Create(URL)
            Dim response As WebResponse = request.GetResponse()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function getFiles(ByVal SourceFolder As String, ByVal Filter As String, ByVal searchOption As SearchOption) As String()
        Dim alFiles As ArrayList = New ArrayList()
        Dim MultipleFilters() As String = Filter.Split("|")

        For Each FileFilter As String In MultipleFilters
            alFiles.AddRange(Directory.GetFiles(SourceFolder, FileFilter, searchOption))
        Next

        Return alFiles.ToArray(Type.GetType("System.String"))
    End Function

#End Region

#Region "GRAPHICAL FUNCTIONS"

    Private Sub DropShadowOfText(ByVal Lab As gLabel.gLabel)

        If Lab.ShadowState = True Then
            Lab.ShadowState = False
        Else
            Lab.ShadowState = True
        End If

    End Sub

    Private Function DropShadowOfImage(ByVal IMG As String) As Bitmap

        Dim sourceImage As Image = Image.FromFile(IMG)
        Dim format As ImageFormat = sourceImage.RawFormat
        Dim bmpOut As Bitmap = New Bitmap(sourceImage)

        While sourceImage IsNot Nothing
            sourceImage.Dispose()
            sourceImage = Nothing
        End While

        DropShadow(bmpOut, Color.LightGray, Nothing, ShadowDirections.BOTTOM_RIGHT, 190, 4, 1, True)

        Return bmpOut

    End Function

    Public Enum ShadowDirections As Integer
        TOP_RIGHT = 1
        BOTTOM_RIGHT = 2
        BOTTOM_LEFT = 3
        TOP_LEFT = 4
    End Enum

    Public Sub DropShadow(ByRef SourceImage As Drawing.Bitmap, _
                        ByVal ShadowColor As Drawing.Color, _
                        ByVal BackgroundColor As Drawing.Color, _
                        Optional ByVal ShadowDirection As ShadowDirections = _
                                              ShadowDirections.BOTTOM_RIGHT, _
                        Optional ByVal ShadowOpacity As Integer = 190, _
                        Optional ByVal ShadowSoftness As Integer = 4, _
                        Optional ByVal ShadowDistance As Integer = 5, _
                        Optional ByVal ShadowRoundedEdges As Boolean = True)
        Dim ImgTarget As Bitmap = Nothing
        Dim ImgShadow As Bitmap = Nothing
        Dim g As Graphics = Nothing
        Try
            If SourceImage IsNot Nothing Then
                If ShadowOpacity = 0 Then
                    ShadowOpacity = 0
                ElseIf ShadowOpacity = 255 Then
                    ShadowOpacity = 255
                End If
                If ShadowSoftness = 1 Then
                    ShadowSoftness = 1
                ElseIf ShadowSoftness = 30 Then
                    ShadowSoftness = 30
                End If
                If ShadowDistance = 1 Then
                    ShadowDistance = 1
                ElseIf ShadowDistance = 50 Then
                    ShadowDistance = 50
                End If
                If ShadowColor = Color.Transparent Then
                    ShadowColor = Color.Black
                End If
                If BackgroundColor = Color.Transparent Then
                    BackgroundColor = Color.White
                End If

                'get shadow
                Dim shWidth As Integer = CInt(SourceImage.Width / ShadowSoftness)
                Dim shHeight As Integer = CInt(SourceImage.Height / ShadowSoftness)
                ImgShadow = New Bitmap(shWidth, shHeight)
                g = Graphics.FromImage(ImgShadow)
                g.Clear(Color.Transparent)
                g.InterpolationMode = InterpolationMode.HighQualityBicubic
                g.SmoothingMode = SmoothingMode.AntiAlias
                Dim sre As Integer = 0
                If ShadowRoundedEdges = True Then sre = 1
                g.FillRectangle(New SolidBrush(Color.FromArgb(ShadowOpacity, ShadowColor)), _
                                      sre, sre, shWidth, shHeight)
                g.Dispose()

                'draw shadow
                Dim d_shWidth As Integer = SourceImage.Width + ShadowDistance
                Dim d_shHeight As Integer = SourceImage.Height + ShadowDistance
                ImgTarget = New Bitmap(d_shWidth, d_shHeight)
                g = Graphics.FromImage(ImgTarget)
                g.Clear(BackgroundColor)
                g.InterpolationMode = InterpolationMode.HighQualityBicubic
                g.SmoothingMode = SmoothingMode.AntiAlias
                g.DrawImage(ImgShadow, New Rectangle(0, 0, d_shWidth, d_shHeight), 0, 0, ImgShadow.Width, ImgShadow.Height, GraphicsUnit.Pixel)
                Select Case ShadowDirection
                    Case ShadowDirections.BOTTOM_RIGHT
                        g.DrawImage(SourceImage, _
                            New Rectangle(0, 0, SourceImage.Width, SourceImage.Height), _
                               0, 0, SourceImage.Width, SourceImage.Height, GraphicsUnit.Pixel)
                    Case ShadowDirections.BOTTOM_LEFT
                        g.Dispose()
                        ImgTarget.RotateFlip(RotateFlipType.RotateNoneFlipX)
                        g = Graphics.FromImage(ImgTarget)
                        g.DrawImage(SourceImage, _
                             New Rectangle(ShadowDistance, 0, SourceImage.Width, SourceImage.Height), 0, 0, SourceImage.Width, SourceImage.Height, GraphicsUnit.Pixel)
                    Case ShadowDirections.TOP_LEFT
                        g.Dispose()
                        ImgTarget.RotateFlip(RotateFlipType.Rotate180FlipNone)
                        g = Graphics.FromImage(ImgTarget)
                        g.DrawImage(SourceImage, New Rectangle(ShadowDistance, ShadowDistance, SourceImage.Width, SourceImage.Height), 0, 0, SourceImage.Width, SourceImage.Height, GraphicsUnit.Pixel)
                    Case ShadowDirections.TOP_RIGHT
                        g.Dispose()
                        ImgTarget.RotateFlip(RotateFlipType.RotateNoneFlipY)
                        g = Graphics.FromImage(ImgTarget)
                        g.DrawImage(SourceImage, New Rectangle(0, ShadowDistance, SourceImage.Width, SourceImage.Height), 0, 0, SourceImage.Width, SourceImage.Height, GraphicsUnit.Pixel)
                End Select

                g.Dispose()
                g = Nothing
                ImgShadow.Dispose()
                ImgShadow = Nothing

                SourceImage = New Bitmap(ImgTarget)
                ImgTarget.Dispose()
                ImgTarget = Nothing
            End If

        Catch ex As Exception
            If g IsNot Nothing Then
                g.Dispose()
                g = Nothing
            End If
            If ImgShadow IsNot Nothing Then
                ImgShadow.Dispose()
                ImgShadow = Nothing
            End If
            If ImgTarget IsNot Nothing Then
                ImgTarget.Dispose()
                ImgTarget = Nothing
            End If
        End Try

    End Sub

    Private Function Luminosity(ByVal pColor As Long) As Integer
        Dim iR As Integer, iG As Integer, iB As Integer
        Dim nRPct As Single, nGPct As Single, nBPct As Single
        Dim nMax As Single, nMin As Single
        Dim nLumPct As Single

        'get the individual value for red, green, and blue
        iR = pColor Mod 256
        pColor = pColor \ 256
        iG = pColor Mod 256
        pColor = pColor \ 256
        iB = pColor Mod 256

        ' get the percentage of each color
        nRPct = iR / 255
        nGPct = iG / 255
        nBPct = iB / 255

        ' get highest and lowest percentages
        If nRPct > nGPct And nRPct > nBPct Then
            nMax = nRPct
        ElseIf nGPct > nBPct Then
            nMax = nGPct
        Else
            nMax = nBPct
        End If

        If nRPct < nGPct And nRPct < nBPct Then
            nMin = nRPct
        ElseIf nGPct < nBPct Then
            nMin = nGPct
        Else
            nMin = nBPct
        End If

        ' get the percentage of luminosity
        nLumPct = (nMin + nMax) / 2

        ' return the luminosity min (darkest) = 0 max (lightest) = 240
        Luminosity = nLumPct * 240

    End Function

#End Region

#Region "DISC FUNTIONS"

    Private Function GetGameNameOfDisc(ByVal DrivePath As String)

        Try

            If File.Exists(DrivePath + "autorun.inf") Then

                If Not Functions.INI_ReadValueFromFile("autorun", "label", "", DrivePath + "autorun.inf") = "" Then
                    Return Functions.INI_ReadValueFromFile("autorun", "label", "", DrivePath + "autorun.inf")

                ElseIf Not Functions.INI_ReadValueFromFile("autorun", "Name", "", DrivePath + "autorun.inf") = "" Then
                    Return Functions.INI_ReadValueFromFile("autorun", "Name", "", DrivePath + "autorun.inf")

                ElseIf Not Functions.INI_ReadValueFromFile("autorun", "Product", "", DrivePath + "autorun.inf") = "" Then
                    Return Functions.INI_ReadValueFromFile("autorun", "Product", "", DrivePath + "autorun.inf")

                End If

            ElseIf File.Exists(DrivePath + "setup.inf") Then

                If Not Functions.INI_ReadValueFromFile("Startup", "Product", "", DrivePath + "setup.inf") = "" Then
                    Return Functions.INI_ReadValueFromFile("Startup", "Product", "", DrivePath + "setup.inf")

                ElseIf Not Functions.INI_ReadValueFromFile("Startup", "label", "", DrivePath + "setup.inf") = "" Then
                    Return Functions.INI_ReadValueFromFile("Startup", "label", "", DrivePath + "setup.inf")

                ElseIf Not Functions.INI_ReadValueFromFile("Startup", "Name", "", DrivePath + "setup.inf") = "" Then
                    Return Functions.INI_ReadValueFromFile("Startup", "Name", "", DrivePath + "setup.inf")

                ElseIf Not Functions.INI_ReadValueFromFile("Info", "Product", "", DrivePath + "setup.inf") = "" Then
                    Return Functions.INI_ReadValueFromFile("Info", "Product", "", DrivePath + "setup.inf")

                ElseIf Not Functions.INI_ReadValueFromFile("Info", "Name", "", DrivePath + "setup.inf") = "" Then
                    Return Functions.INI_ReadValueFromFile("Info", "Name", "", DrivePath + "setup.inf")

                ElseIf Not Functions.INI_ReadValueFromFile("Info", "label", "", DrivePath + "setup.inf") = "" Then
                    Return Functions.INI_ReadValueFromFile("Info", "label", "", DrivePath + "setup.inf")

                End If

            End If

        Catch ex As Exception
        End Try

    End Function

    Private Sub GetLogoOfDisc(ByVal ImageState As Integer, Optional ByVal GameTitle As String = "")
        Dim seldrive As String

        For Each drive In DriveInfo.GetDrives()
            If drive.DriveType = DriveType.CDRom And drive.IsReady = True Then
                seldrive = drive.ToString()
            End If
        Next

        If ImageState = 0 Then
            If File.Exists(seldrive + "logo.png") Then
                SelectedGame.Image = DropShadowOfImage(seldrive + "logo.png")
            ElseIf File.Exists(seldrive + "Splash.bmp") Then
                SelectedGame.Image = DropShadowOfImage(seldrive + "Splash.bmp")
            End If
        Else
            SelectedGame.Image = GetGameCover(GameTitle)
        End If

    End Sub

#End Region

#Region "MUSIC FUNCTIONS"

    Public Function Cover(ByVal MusicFile As String) As Image
        m_UltraID3.Read(MusicFile)
        m_PictureFrames = m_UltraID3.ID3v2Tag.Frames.GetFrames(MultipleInstanceID3v2FrameTypes.ID3v23Picture)
        m_PictureIndex = -1

        If m_PictureFrames.Count > 0 Then
            m_PictureIndex = 0
        End If

        Dim PictureFrameCount As Integer = m_PictureFrames.Count

        If PictureFrameCount > 0 Then

            m_CurrentPictureFrame = CType(m_PictureFrames.Item(m_PictureIndex), ID3v23PictureFrame)

            With m_CurrentPictureFrame
                If m_CurrentPictureFrame.Picture IsNot Nothing Then
                    Return m_CurrentPictureFrame.Picture
                Else
                    Return My.Resources.MusicDefault
                End If
            End With

        Else
            Return My.Resources.MusicDefault
        End If

    End Function

#End Region

#Region "VIDEO FUNCTIONS"

    Public Function Thumbnail(ByVal Pfad As String) As String
        Dim outputdir As String
        Dim outputfile As String
        Dim fulloutput As String
        Dim split As String() = Pfad.Split("\")

        outputdir = split(split.Length - 2)
        outputfile = Path.GetFileNameWithoutExtension(Pfad) + ".jpg"
        fulloutput = My.Computer.FileSystem.CurrentDirectory + "\media\thumbnails\" + outputfile

        If File.Exists(My.Computer.FileSystem.CurrentDirectory + "\media\thumbnails\" + outputfile) Then
            Return My.Computer.FileSystem.CurrentDirectory + "\media\thumbnails\" + outputfile
        Else

            Try
                Dim ffmpeg As New Process
                ffmpeg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                ffmpeg.StartInfo.FileName = "ffmpeg.exe"
                ffmpeg.StartInfo.Arguments = ("-i  """ + Pfad + """ -f image2 -vframes 1 -ss 3 """ + fulloutput + """")
                ffmpeg.Start()
            Catch ex As Exception
                Return "ERROR"
            End Try

            Return fulloutput

        End If
    End Function

#End Region

#Region "GAME FUNCTIONS"

    Private Function SplitGamePath(ByVal GameStr As String, ByVal Options As Integer)
        Return GameStr.Split(";")(Options)
    End Function

    Private Function GetGameCover(ByVal Game As String, Optional ByVal otheriso As Boolean = False) As Image
        Dim ConvertedGame As String = Game.Split(";")(1)
        Dim CoverbyExt As String = Game.Split(";")(0)

        If File.Exists(".\media\Covers\" + ConvertedGame.Replace(" ", "-") + ".png") Then
            Return Image.FromFile(".\media\Covers\" + ConvertedGame.Replace(" ", "-") + ".png")

        Else

            If CoverbyExt.Contains(".cso") Then
                Return My.Resources.psp
            ElseIf CoverbyExt.Contains(".bin") Then
                Return My.Resources.ps1
            ElseIf CoverbyExt.Contains(".iso") And otheriso = False Then
                Return My.Resources.ps2
            ElseIf CoverbyExt.Contains(".gba") Then
                Return My.Resources.gba
            ElseIf CoverbyExt.Contains(".smc") Then
                Return My.Resources.snes
            ElseIf CoverbyExt.Contains(".smd") Then
                Return My.Resources.sega
            ElseIf CoverbyExt.Contains(".nes") Then
                Return My.Resources.nes
            ElseIf CoverbyExt.Contains(".gbc") Then
                Return My.Resources.gbc
            ElseIf CoverbyExt.Contains(".nds") Then
                Return My.Resources.nds
            ElseIf CoverbyExt.Contains(".gcm") Then
                Return My.Resources.gcm
            ElseIf CoverbyExt.Contains(".iso") And otheriso = True Then
                Return My.Resources.wii1
            Else
                Return My.Resources.Game_Default_PS3
            End If

        End If
    End Function

    Private Sub Game1Start_Exited(sender As Object, e As EventArgs) Handles Game1Start.Exited
        currentgamestate = ""
    End Sub

    Private Sub PS1GameStart_Exited(sender As Object, e As EventArgs) Handles PS1GameStart.Exited
        currentgamestate = ""
    End Sub

    Private Sub PS2GameStart_Exited(sender As Object, e As EventArgs) Handles PS2GameStart.Exited
        currentgamestate = ""
    End Sub

    Private Sub PSPGameStart_Exited(sender As Object, e As EventArgs) Handles PSPGameStart.Exited
        currentgamestate = ""
    End Sub

    Private Sub RetroGameStart_Exited(sender As Object, e As EventArgs) Handles RetroGameStart.Exited
        currentgamestate = ""
    End Sub

    Private Sub NintendoGameStart_Exited(sender As Object, e As EventArgs) Handles NintendoGameStart.Exited
        currentgamestate = ""
    End Sub

    Private Function GetTitle(ByVal UrlToLoad As String) As String
        Dim uri As New Uri(UrlToLoad)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse
        Dim Title As String = ""
        Dim HTML As String = ""
        Dim TempArray As Array
        Dim Temp As String = ""
        Dim DelimiterA() As String = {"<title>"}
        Dim DelimiterB() As String = {"</title>"}

        Try
            If (uri.Scheme = uri.UriSchemeHttp) Then
                request = HttpWebRequest.Create(uri)
                request.Method = WebRequestMethods.Http.Get
                request.Timeout = 60000
                response = request.GetResponse
                Dim reader As New StreamReader(response.GetResponseStream())
                HTML = reader.ReadToEnd
                response.Close()
            Else
                HTML = ""
            End If

            If HTML <> "" Then
                If (InStr(HTML, "<title>") > 0) And (InStr(HTML, "</title>") > 0) Then
                    TempArray = HTML.Split(DelimiterA, StringSplitOptions.None)
                    Temp = TempArray(1)
                    TempArray = Temp.Split(DelimiterB, StringSplitOptions.None)
                    Title = TempArray(0)
                End If
            End If
        Catch ex As Exception
            Title = ""
        End Try

        Return Title
    End Function

    Private Sub CheckPS2Game(ByVal GameP As String, ByVal Type As Integer)

        If Type = 0 Then

            Dim Game_ID As String
            Dim Read_Lines As String() = File.ReadAllLines(GameP)

            Game_ID = Read_Lines(0).ToString.Replace("BOOT2 = cdrom0:\", "").Replace("BOOT2=cdrom0:\", "").Replace("_", "-").Replace(";1", "").Replace(".", "")

            If GetTitle("http://www.sonyindex.com/Pages/" + Game_ID + ".htm").Replace("[", "").Replace("]", "").Replace("PAL-Unk", "").Replace("NTSC-U", "").Replace(Game_ID, "").Replace("PAL-G", "").Replace("NTSC-J", "").Replace("NTSC-Unk", "").Replace("PAL-Unk", "").Replace("PAL-M5", "") = Nothing Then
                SelectedGameText.Text = "PS2 Game Disc"
            Else
                SelectedGameText.Text = GetTitle("http://www.sonyindex.com/Pages/" + Game_ID + ".htm").Replace("[", "").Replace("]", "").Replace("PAL-Unk", "").Replace("NTSC-U", "").Replace(Game_ID, "").Replace("PAL-G", "").Replace("NTSC-J", "").Replace("NTSC-Unk", "").Replace("PAL-Unk", "").Replace("PAL-M5", "")
            End If

            Dim GameRegionAndID As String() = Game_ID.Split("-")

            If CheckAddress("http://spiffycovers.com/images/thumbs/ps2/" + GameRegionAndID(0) + "/" + GameRegionAndID(1) + ".png") = True Then
                SelectedGame.ImageLocation = "http://spiffycovers.com/images/thumbs/ps2/" + GameRegionAndID(0) + "/" + GameRegionAndID(1) + ".png"
            Else
                SelectedGame.Image = My.Resources.ps2disc
            End If

        Else

            Using isoStream As FileStream = File.Open(GameP, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)

                Dim cd As New CDReader(isoStream, True)
                Dim fileStream As Stream = cd.OpenFile("\system.cnf", FileMode.Open)
                Dim strb As New StringBuilder()
                Dim b As Byte() = New Byte(fileStream.Length) {}
                Dim temp As New UTF8Encoding(True)

                While fileStream.Read(b, 0, b.Length) > 0
                    strb.Append(temp.GetString(b))
                End While

                Dim Code As String = strb.ToString.Split(vbNewLine)(0)
                Dim Title As String

                Code = Code.Replace("BOOT2 = cdrom0:\", "").Replace("BOOT2=cdrom0:\", "").Replace("_", "-").Replace(";1", "").Replace(".", "")
                Title = GetTitle("http://www.sonyindex.com/Pages/" + Code + ".htm").Replace("[", "").Replace("]", "").Replace("PAL-Unk", "").Replace("NTSC-U", "").Replace(Code, "").Replace("PAL-G", "").Replace("NTSC-J", "").Replace("NTSC-Unk", "").Replace("PAL-Unk", "").Replace("PAL-M5", "")

            End Using
        End If

    End Sub

    Private Sub CheckPS1Game(ByVal GameP As String, ByVal Type As Integer)

        If Type = 0 Then

            Dim Game_ID As String
            Dim Read_Lines As String() = File.ReadAllLines(GameP)

            Game_ID = Read_Lines(0).ToString.Replace("BOOT = cdrom0:\", "").Replace("BOOT=cdrom0:\", "").Replace("BOOT=cdrom:\", "").Replace("BOOT = cdrom:\", "").Replace("_", "-").Replace(";1", "").Replace(".", "")

            If GetTitle("http://www.sonyindex.com/Pages/" + Game_ID + ".htm").Replace("[", "").Replace("]", "").Replace("PAL-Unk", "").Replace("NTSC-U", "").Replace(Game_ID, "").Replace("PAL-G", "").Replace("NTSC-J", "").Replace("NTSC-Unk", "").Replace("PAL-Unk", "").Replace("PAL-M5", "") = Nothing Then
                SelectedGameText.Text = "PS1 Game Disc"
            Else
                SelectedGameText.Text = GetTitle("http://www.sonyindex.com/Pages/" + Game_ID + ".htm").Replace("[", "").Replace("]", "").Replace("PAL-Unk", "").Replace("NTSC-U", "").Replace(Game_ID, "").Replace("PAL-G", "").Replace("NTSC-J", "").Replace("NTSC-Unk", "").Replace("PAL-Unk", "").Replace("PAL-M5", "")
            End If

            Dim GameRegionAndID As String() = Game_ID.Split("-")

            If CheckAddress("http://spiffycovers.com/images/thumbs/ps1/" + GameRegionAndID(0) + "/" + GameRegionAndID(1) + ".png") = True Then
                SelectedGame.ImageLocation = "http://spiffycovers.com/images/thumbs/ps1/" + GameRegionAndID(0) + "/" + GameRegionAndID(1) + ".png"
            Else
                SelectedGame.Image = My.Resources.ps1disc
            End If

        Else

            Using isoStream As FileStream = File.Open(GameP, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)

                Dim cd As New CDReader(isoStream, True)
                Dim fileStream As Stream = cd.OpenFile("\system.cnf", FileMode.Open)
                Dim strb As New StringBuilder()
                Dim b As Byte() = New Byte(fileStream.Length) {}
                Dim temp As New UTF8Encoding(True)

                While fileStream.Read(b, 0, b.Length) > 0
                    strb.Append(temp.GetString(b))
                End While

                Dim Code As String = strb.ToString.Split(vbNewLine)(0)
                Dim Title As String

                Code = Code.Replace("BOOT = cdrom0:\", "").Replace("BOOT=cdrom0:\", "").Replace("BOOT=cdrom:\", "").Replace("BOOT = cdrom:\", "").Replace("_", "-").Replace(";1", "").Replace(".", "")
                Title = GetTitle("http://www.sonyindex.com/Pages/" + Code + ".htm").Replace("[", "").Replace("]", "").Replace("PAL-Unk", "").Replace("NTSC-U", "").Replace(Code, "").Replace("PAL-G", "").Replace("NTSC-J", "").Replace("NTSC-Unk", "").Replace("PAL-Unk", "").Replace("PAL-M5", "")

            End Using

        End If

    End Sub

    Public Sub SwitchPCSXPlugin(ByVal SwitchTo As String)
        Try

            If Not Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\PCSX2") Then

                SystemDialog.DialogTxt.Text = "You need to configure PS2Loader first."
                SystemDialog.DialogPossibilities = "OKONLY"

                SystemDialog.ShowDialog()

            Else

                If SwitchTo = "Plugin" Then

                    Dim reader As StreamReader = New StreamReader(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\PCSX2\inis\PCSX2_ui.ini")
                    Dim sLine As String = reader.ReadToEnd()
                    reader.Close()

                    Dim writer As StreamWriter = New StreamWriter(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\PCSX2\inis\PCSX2_ui.ini")
                    writer.Write(sLine.Replace("CdvdSource=Iso", "CdvdSource=Plugin"))
                    writer.Close()

                ElseIf SwitchTo = "ISO" Then

                    Dim reader As StreamReader = New StreamReader(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\PCSX2\inis\PCSX2_ui.ini")
                    Dim sLine As String = reader.ReadToEnd()
                    reader.Close()

                    Dim writer As StreamWriter = New StreamWriter(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\PCSX2\inis\PCSX2_ui.ini")
                    writer.Write(sLine.Replace("CdvdSource=Plugin", "CdvdSource=Iso"))
                    writer.Close()

                End If

            End If

        Catch ex As Exception
            MsgBox("Could not change PCSX2 plugin", MsgBoxStyle.Critical, "PS2Loader Error")
        End Try
    End Sub

    Public Sub PlayGameIntro()
        Me.Controls.Add(MediaPlayer)
        MediaPlayer.BringToFront()
        MediaPlayer.Dock = DockStyle.Fill
        MediaPlayer.uiMode = "none"
        MediaPlayer.URL = My.Computer.FileSystem.CurrentDirectory + "\media\gamestart.wmv"
        'MediaPlayer.stretchToFit = True
        MediaPlayer.settings.volume = 50
    End Sub

    Public Sub PlayGameIntro_NoAnimation()

        If GenerateArchitecture() = "32" Then
            StartGame(GameSect, GameID, GameFormat)
        Else
            StartGame_x64(GameSect, GameID, GameFormat)
        End If

        Me.ActiveControl = Home

    End Sub

    Public Sub StartGame(ByVal Section As String, ByVal ID As Integer, ByVal Format As String)

        If Section = "PC" And ID = 1 And Format = "EXE" Then
            Game1Start.StartInfo.FileName = SelectedGame.Tag
            Game1Start.Start()

        ElseIf Section = "PS" And ID = 1 And Format = "ISO" Then
            PS2GameStart.StartInfo.FileName = ".\system\ps2loader\pcsx2.exe"
            PS2GameStart.StartInfo.Arguments = """" + PS2Game1.Tag + """"
            PS2GameStart.Start()
        ElseIf Section = "PS" And ID = 1 And Format = "CSO" Then
            PSPGameStart.StartInfo.FileName = ".\system\psploader\PPSSPPWindows.exe"
            PSPGameStart.StartInfo.Arguments = """" + PS2Game1.Tag + """"
            PSPGameStart.Start()
        ElseIf Section = "PS" And ID = 1 And Format = "BIN" Then
            PS1GameStart.StartInfo.FileName = ".\system\ps1loader\ePSXe.exe"
            PS1GameStart.StartInfo.Arguments = "-nogui -bios """ + My.Computer.FileSystem.CurrentDirectory + "\system\ps1loader\bios\SCPH1001.BIN"" " + "-loadbin " + """" + PS2Game1.Tag + """"
            PS1GameStart.Start()

        ElseIf Section = "DISC" And ID = 1 And Format = "PS2" Then
            PS2GameStart.StartInfo.FileName = ".\system\ps2loader\pcsx2.exe"
            PS2GameStart.StartInfo.Arguments = SelectedGame.Tag
            PS2GameStart.Start()
        ElseIf Section = "DISC" And ID = 1 And Format = "PSX" Then
            PS1GameStart.StartInfo.FileName = ".\system\ps1loader\ePSXe.exe"
            PS1GameStart.StartInfo.Arguments = "-nogui -bios """ + My.Computer.FileSystem.CurrentDirectory + "\system\ps1loader\bios\SCPH1001.BIN"""
            PS1GameStart.Start()

        ElseIf Section = "RETRO" And ID = 1 And Format = "GBA" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\gba.dll """ + PS2Game1.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 1 And Format = "GBC" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\gbc.dll """ + PS2Game1.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 1 And Format = "SMC" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\snes.dll """ + PS2Game1.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 1 And Format = "SMD" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\sega.dll """ + PS2Game1.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 1 And Format = "NES" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\nes.dll """ + PS2Game1.Tag + """"
            RetroGameStart.Start()

        ElseIf Section = "NINTENDO" And ID = 1 And Format = "NDS" Then
            NintendoGameStart.StartInfo.FileName = ".\system\dsloader\DeSmuME_0.9.9_x86.exe"
            NintendoGameStart.StartInfo.Arguments = """" + PS2Game1.Tag + """"
            NintendoGameStart.Start()
        ElseIf Section = "NINTENDO" And ID = 1 And Format = "GCM" Then
            NintendoGameStart.StartInfo.FileName = ".\system\wiicubeloader\x32\Dolphin.exe"
            NintendoGameStart.StartInfo.Arguments = "-e """ + PS2Game1.Tag + """"
            NintendoGameStart.Start()
        ElseIf Section = "NINTENDO" And ID = 1 And Format = "ISO" Then
            NintendoGameStart.StartInfo.FileName = ".\system\wiicubeloader\x32\Dolphin.exe"
            NintendoGameStart.StartInfo.Arguments = "-e """ + PS2Game1.Tag + """"
            NintendoGameStart.Start()

        End If

    End Sub

    Public Sub StartGame_x64(ByVal Section As String, ByVal ID As Integer, ByVal Format As String)

        If Section = "PC" And ID = 1 And Format = "EXE" Then
            Game1Start.StartInfo.FileName = SelectedGame.Tag
            Game1Start.Start()

        ElseIf Section = "PS" And ID = 1 And Format = "ISO" Then
            PS2GameStart.StartInfo.FileName = ".\system\ps2loader\pcsx2.exe"
            PS2GameStart.StartInfo.Arguments = """" + PS2Game1.Tag + """"
            PS2GameStart.Start()
        ElseIf Section = "PS" And ID = 1 And Format = "CSO" Then
            PSPGameStart.StartInfo.FileName = ".\system\psploader\PPSSPPWindows64.exe"
            PSPGameStart.StartInfo.Arguments = """" + PS2Game1.Tag + """"
            PSPGameStart.Start()
        ElseIf Section = "PS" And ID = 1 And Format = "BIN" Then
            PS1GameStart.StartInfo.FileName = ".\system\ps1loader\ePSXe.exe"
            PS1GameStart.StartInfo.Arguments = "-nogui -bios """ + My.Computer.FileSystem.CurrentDirectory + "\system\ps1loader\bios\SCPH1001.BIN"" " + "-loadbin " + """" + PS2Game1.Tag + """"
            PS1GameStart.Start()

        ElseIf Section = "DISC" And ID = 1 And Format = "PS2" Then
            PS2GameStart.StartInfo.FileName = ".\system\ps2loader\pcsx2.exe"
            PS2GameStart.StartInfo.Arguments = SelectedGame.Tag
            PS2GameStart.Start()
        ElseIf Section = "DISC" And ID = 1 And Format = "PSX" Then
            PS1GameStart.StartInfo.FileName = ".\system\ps1loader\ePSXe.exe"
            PS1GameStart.StartInfo.Arguments = "-nogui -bios """ + My.Computer.FileSystem.CurrentDirectory + "\system\ps1loader\bios\SCPH1001.BIN"""
            PS1GameStart.Start()

        ElseIf Section = "RETRO" And ID = 1 And Format = "GBA" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\gba.dll """ + PS2Game1.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 1 And Format = "GBC" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\gbc.dll """ + PS2Game1.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 1 And Format = "SMC" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\snes.dll """ + PS2Game1.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 1 And Format = "SMD" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\sega.dll """ + PS2Game1.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 1 And Format = "NES" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\nes.dll """ + PS2Game1.Tag + """"
            RetroGameStart.Start()

        ElseIf Section = "NINTENDO" And ID = 1 And Format = "NDS" Then
            NintendoGameStart.StartInfo.FileName = ".\system\dsloader\DeSmuME_0.9.9_x86.exe"
            NintendoGameStart.StartInfo.Arguments = """" + PS2Game1.Tag + """"
            NintendoGameStart.Start()
        ElseIf Section = "NINTENDO" And ID = 1 And Format = "GCM" Then
            NintendoGameStart.StartInfo.FileName = ".\system\wiicubeloader\x64\Dolphin.exe"
            NintendoGameStart.StartInfo.Arguments = "-e """ + PS2Game1.Tag + """"
            NintendoGameStart.Start()
        ElseIf Section = "NINTENDO" And ID = 1 And Format = "ISO" Then
            NintendoGameStart.StartInfo.FileName = ".\system\wiicubeloader\x64\Dolphin.exe"
            NintendoGameStart.StartInfo.Arguments = "-e """ + PS2Game1.Tag + """"
            NintendoGameStart.Start()

        End If

    End Sub

#End Region

#Region "Timers"

    Private Sub TimeClocker_Tick(sender As Object, e As EventArgs) Handles TimeClocker.Tick
        TheTime.Text = Now.ToString
    End Sub

    Private Sub NetworkTimer_Tick(sender As Object, e As EventArgs) Handles NetworkTimer.Tick
        If currentnetworkstate = "online" Then

            If currentnotificationstate = "unnotified" Then

                Dim FI As FileVersionInfo = FileVersionInfo.GetVersionInfo(".\XMBPC.exe")
                Dim ver1 As String = FI.FileVersion

                Dim verclient As New WebClient()
                Dim ver2 As String = verclient.DownloadString("http://85.31.189.150/XMBPCE/CURRENTVERSION.txt")

                If ver1 < ver2 Then
                    My.Computer.Audio.Play(My.Resources.snd_trophy, AudioPlayMode.Background)
                    NotificationTxt2.Text = LangLoader.GetStringOfLang("XMB", "UpdateAvailable1") + ver2.ToString + " " + LangLoader.GetStringOfLang("XMB", "UpdateAvailable2")
                    NotificationBox.Visible = True
                    NotificationTxt.Visible = True
                    NotificationTxt2.Visible = True
                    NotificationIco.Visible = True
                End If

                currentnotificationstate = "notified"
            End If

        End If
    End Sub

    Private Sub ControllerInputTimer_Tick(sender As Object, e As EventArgs) Handles ControllerInputTimer.Tick

        Dim status As Joystick.Status = joy.GetCurrentStatus

        If status.XAxis = 1 Or GetAsyncKeyState(Keys.Right) Then
            ControlRight()
        ElseIf status.XAxis = -1 Or GetAsyncKeyState(Keys.Left) Then
            ControlLeft()
        End If

        If status.YAxis = 1 Or GetAsyncKeyState(Keys.Down) Then
            ControlBottom()

            If currentcategory = "users" Then
                ControlUsersBottom()
            ElseIf currentcategory = "settings" Then
                ControlSettingsBottom()
            ElseIf currentcategory = "network" Then
                ControlNetworkBottom()
            End If

            If SelectedGame.Focused Then
                BrowseNextGames()
            ElseIf PS2Game1.Focused And SelectedGameText.Text = "Playstation Games" Then
                BrowseNextPS2Games()
            ElseIf PS2Game1.Focused And SelectedGameText.Text = "Retro Games" Then
                BrowseNextRetroGames()
            ElseIf PS2Game1.Focused And SelectedGameText.Text = "Nintendo Games" Then
                BrowseNextNintendoGames()

            ElseIf SelectedTrack.Focused Then
                BrowseNextMusic()
            ElseIf SelectedPicture.Focused Then
                BrowseNextPictures()
            ElseIf SelectedVid.Focused Then
                BrowseNextVideos()
            End If

        ElseIf status.YAxis = -1 Or GetAsyncKeyState(Keys.Up) Then
            ControlTop()

            If currentcategory = "users" Then
                ControlUsersTop()
            ElseIf currentcategory = "settings" Then
                ControlSettingsTop()
            ElseIf currentcategory = "network" Then
                ControlNetworkTop()
            End If

            If SelectedGame.Focused Then
                BrowseLastGames()
            ElseIf PS2Game1.Focused And SelectedGameText.Text = "Playstation Games" Then
                BrowseLastPS2Games()
            ElseIf PS2Game1.Focused And SelectedGameText.Text = "Retro Games" Then
                BrowseLastRetroGames()
            ElseIf PS2Game1.Focused And SelectedGameText.Text = "Nintendo Games" Then
                BrowseLastNintendoGames()

            ElseIf SelectedTrack.Focused Then
                BrowseLastMusic()
            ElseIf SelectedPicture.Focused Then
                BrowseLastPictures()
            ElseIf SelectedVid.Focused Then
                BrowseLastVideos()
            End If

        End If

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button5) And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button6) Or GetAsyncKeyState(Keys.R) And GetAsyncKeyState(Keys.S) Then
            If CurrentRadioState = "Playing" Then
                RadioPlayer.close()
                CurrentRadioState = "Stopped"
            End If
        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button5) And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button6) Or GetAsyncKeyState(Keys.R) And GetAsyncKeyState(Keys.P) Then
            If CurrentRadioState = "Stopped" Then
                RadioPlayer.URL = CurrentRadioURL
                CurrentRadioState = "Playing"
            End If
        End If

        If BrowserBox.Focused Or SelectedGame.Focused Or PS2Game1.Focused Or YoutubeBox.Focused Or StoreBox.Focused Or RadioBox.Focused Or DesktopBox.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoStart")
        ElseIf SelectedTrack.Focused Or Track1.Focused Or Track2.Focused Or Track3.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoListen")
        ElseIf SelectedVid.Focused Or Vid1.Focused Or Vid2.Focused Or Vid3.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoWatch")
        ElseIf SelectedPicture.Focused Or Picture1.Focused Or Picture2.Focused Or Picture3.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoWatch")
        ElseIf AddFriend.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoAdd")
        Else
            AdviceIco.Image = Nothing
            AdviceTxt.Text = ""
        End If

        If status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button13) = True Or GetAsyncKeyState(Keys.Home) Then
            CallPSButton()
        End If

        If SelectedGame.Focused And GetAsyncKeyState(Keys.Enter) And GameDisc = False Or SelectedGame.Focused And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) And GameDisc = False Then

            Games.Size = New Size(96, 96)
            GamesTxt.Visible = False
            GamesTxt.GlowState = False

            HideGames()
            Me.ActiveControl = Home

            GameSect = "PC"
            GameID = 1
            GameFormat = "EXE"

            'PlayGameIntro()
            PlayGameIntro_NoAnimation()

            currentgamestate = "game1"

        ElseIf SelectedGame.Focused And GetAsyncKeyState(Keys.Enter) And GameDisc = True Or SelectedGame.Focused And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) And GameDisc = True Then

            Games.Size = New Size(96, 96)
            GamesTxt.Visible = False
            GamesTxt.GlowState = False

            For Each drive In DriveInfo.GetDrives()

                If drive.DriveType = DriveType.CDRom And drive.IsReady = True Then

                    If File.Exists(drive.ToString() + "system.cnf") Then
                        If ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT2 " Then
                            CheckPS2Game(drive.ToString() + "system.cnf", 0)
                            CurrentGameDisc = "PS2"

                            SwitchPCSXPlugin("Plugin")

                            SelectedGame.Tag = drive.ToString

                            GameSect = "DISC"
                            GameID = 1
                            GameFormat = "PS2"

                            'PlayGameIntro()
                            PlayGameIntro_NoAnimation()

                            currentgamestate = "game1"

                        ElseIf ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT2" Then
                            CheckPS2Game(drive.ToString() + "system.cnf", 0)
                            CurrentGameDisc = "PS2"

                            SwitchPCSXPlugin("Plugin")

                            SelectedGame.Tag = drive.ToString

                            GameSect = "DISC"
                            GameID = 1
                            GameFormat = "PS2"

                            'PlayGameIntro()
                            PlayGameIntro_NoAnimation()

                            currentgamestate = "game1"

                        ElseIf ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT " Then
                            CheckPS1Game(drive.ToString() + "system.cnf", 0)
                            CurrentGameDisc = "PS1"

                            SelectedGame.Tag = drive.ToString

                            GameSect = "DISC"
                            GameID = 1
                            GameFormat = "PSX"

                            'PlayGameIntro()
                            PlayGameIntro_NoAnimation()

                            currentgamestate = "game1"

                        ElseIf ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT" Then
                            CheckPS1Game(drive.ToString() + "system.cnf", 0)
                            CurrentGameDisc = "PS1"

                            SelectedGame.Tag = drive.ToString

                            GameSect = "DISC"
                            GameID = 1
                            GameFormat = "PSX"

                            'PlayGameIntro()
                            PlayGameIntro_NoAnimation()

                            currentgamestate = "game1"

                        End If

                    Else

                        SelectedGameText.Text = LangLoader.GetStringOfLang("XMB", "FileDisc")
                        SelectedGame.Image = My.Resources.disc_nameless
                        SelectedGame.Tag = drive.ToString

                        DiscExplorer.Show()
                        DiscExplorer.BringToFront()
                        DiscExplorer.Activate()

                        Me.Enabled = False

                    End If

                End If

            Next

            HideGames()

        ElseIf PS2Game1.Focused And GetAsyncKeyState(Keys.Enter) Or PS2Game1.Focused And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) Then

            Games.Size = New Size(96, 96)
            GamesTxt.Visible = False
            GamesTxt.GlowState = False

            HideGames()
            Hideps2Games()
            Me.ActiveControl = Home

            Dim GameIF As New FileInfo(PS2Game1.Tag)

            If GameIF.Extension = ".iso" And SelectedGameText.Text = "Playstation Games" Then
                SwitchPCSXPlugin("ISO")
                GameSect = "PS"
                GameID = 1
                GameFormat = "ISO"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "ps2"
            ElseIf GameIF.Extension = ".cso" Then
                GameSect = "PS"
                GameID = 1
                GameFormat = "CSO"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "psp"
            ElseIf GameIF.Extension = ".bin" Then
                GameSect = "PS"
                GameID = 1
                GameFormat = "BIN"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "ps1"
            ElseIf GameIF.Extension = ".gba" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "GBA"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".gbc" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "GBC"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".gb" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "GBC"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smc" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "SMC"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smd" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "SMD"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".nes" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "NES"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"

            ElseIf GameIF.Extension = ".nds" Then

                GameSect = "NINTENDO"
                GameID = 1
                GameFormat = "NDS"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"

            ElseIf GameIF.Extension = ".gcm" Then

                GameSect = "NINTENDO"
                GameID = 1
                GameFormat = "GCM"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"

            ElseIf GameIF.Extension = ".iso" And SelectedGameText.Text = "Nintendo Games" Then

                GameSect = "NINTENDO"
                GameID = 1
                GameFormat = "ISO"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"
            End If

        ElseIf BrowserBox.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or BrowserBox.Focused And GetAsyncKeyState(Keys.Enter) Then

            Browser.Show()
            Browser.BringToFront()
            Browser.Activate()

            Me.Enabled = False

        ElseIf SelectedTrack.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or SelectedTrack.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideMusic()
            Me.ActiveControl = Home

            CurrentMusicTrack = SelectedTrack.Tag

            MusicPlayer.Show()
            MusicPlayer.BringToFront()

            Me.Enabled = False

        ElseIf SelectedVid.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or SelectedVid.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideVideos()
            Me.ActiveControl = Home

            CurrentVideoTrack = SelectedVid.Tag

            VideoPlayer.Show()
            VideoPlayer.BringToFront()

            Me.Enabled = False

        ElseIf SelectedPicture.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or SelectedPicture.Focused And GetAsyncKeyState(Keys.Enter) Then

            HidePictures()
            Me.ActiveControl = Home

            CurrentPictureTrack = SelectedPicture.Tag

            PictureViewer.Show()
            PictureViewer.BringToFront()

            Me.Enabled = False

        ElseIf SettingsTheme.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or SettingsTheme.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideSettings()
            Me.ActiveControl = Home

            FileBrowser.Show()
            FileBrowser.BringToFront()

        ElseIf SettingsUpdate.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or SettingsUpdate.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideSettings()
            Me.ActiveControl = Home

            currentxmbstate = "UPDATE"

            BackgroundDownload.Show()
            BackgroundDownload.BringToFront()

        ElseIf status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button12) And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button9) Then

            If HelpBox.Visible = True Then
                HelpBox.Visible = False
            Else
                HelpBox.Visible = True
            End If

        ElseIf YoutubeBox.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or YoutubeBox.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideVideos()
            Me.ActiveControl = Home

            Browser.Show()
            Browser.BringToFront()
            Browser.WebBrowser1.Navigate("http://www.youtube.com")
            Browser.Activate()

            Me.Enabled = False

        ElseIf Poweroff.Focused And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or Poweroff.Focused And GetAsyncKeyState(Keys.Enter) Then

            SystemDialog.DialogTxt.Text = LangLoader.GetStringOfLang("XMB", "ExitXMBPC")
            SystemDialog.DialogPossibilities = "YESNO"

            If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                StartUpHook.Close()
            Else
                Me.ActiveControl = Home
            End If

        ElseIf StoreBox.Focused And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or StoreBox.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideNetwork()
            Me.ActiveControl = Home

            Store.Show()
            Store.BringToFront()
            Store.Activate()

        ElseIf RadioBox.Focused And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or RadioBox.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideMusic()
            Me.ActiveControl = Home

            Browser.Show()
            Browser.BringToFront()
            Browser.WebBrowser1.Navigate("http://www.surfmusic.de/")
            Browser.Activate()

            Me.Enabled = False

        ElseIf DesktopBox.Focused And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or RadioBox.Focused And GetAsyncKeyState(Keys.Enter) Then

            FensAnim(XMBDesk, FensAnimArt.EINBLENDEN, FensAnimEffekt.DIMMEN, FensAnimRichtung.N, 500)

            Me.Enabled = False

        End If

    End Sub

    Private Sub KeyboardTimer_Tick(sender As Object, e As EventArgs) Handles KeyboardTimer.Tick

        If GetAsyncKeyState(Keys.Right) Then
            ControlRight()
        ElseIf GetAsyncKeyState(Keys.Left) Then
            ControlLeft()
        End If

        If GetAsyncKeyState(Keys.Down) Then
            ControlBottom()

            If currentcategory = "users" Then
                ControlUsersBottom()
            ElseIf currentcategory = "settings" Then
                ControlSettingsBottom()
            ElseIf currentcategory = "network" Then
                ControlNetworkBottom()
            End If

            If SelectedGame.Focused Then
                BrowseNextGames()
            ElseIf PS2Game1.Focused And SelectedGameText.Text = "Playstation Games" Then
                BrowseNextPS2Games()
            ElseIf PS2Game1.Focused And SelectedGameText.Text = "Retro Games" Then
                BrowseNextRetroGames()
            ElseIf PS2Game1.Focused And SelectedGameText.Text = "Nintendo Games" Then
                BrowseNextNintendoGames()

            ElseIf SelectedTrack.Focused Then
                BrowseNextMusic()
            ElseIf SelectedPicture.Focused Then
                BrowseNextPictures()
            ElseIf SelectedVid.Focused Then
                BrowseNextVideos()
            End If

        ElseIf GetAsyncKeyState(Keys.Up) Then
            ControlTop()

            If currentcategory = "users" Then
                ControlUsersTop()
            ElseIf currentcategory = "settings" Then
                ControlSettingsTop()
            ElseIf currentcategory = "network" Then
                ControlNetworkTop()
            End If

            If SelectedGame.Focused Then
                BrowseLastGames()
            ElseIf PS2Game1.Focused And SelectedGameText.Text = "Playstation Games" Then
                BrowseLastPS2Games()
            ElseIf PS2Game1.Focused And SelectedGameText.Text = "Retro Games" Then
                BrowseLastRetroGames()
            ElseIf PS2Game1.Focused And SelectedGameText.Text = "Nintendo Games" Then
                BrowseLastNintendoGames()

            ElseIf SelectedTrack.Focused Then
                BrowseLastMusic()
            ElseIf SelectedPicture.Focused Then
                BrowseLastPictures()
            ElseIf SelectedVid.Focused Then
                BrowseLastVideos()
            End If

        End If

        If GetAsyncKeyState(Keys.R) And GetAsyncKeyState(Keys.S) Then
            If CurrentRadioState = "Playing" Then
                RadioPlayer.close()
                CurrentRadioState = "Stopped"
            End If
        ElseIf GetAsyncKeyState(Keys.R) And GetAsyncKeyState(Keys.P) Then
            If CurrentRadioState = "Stopped" Then
                RadioPlayer.URL = CurrentRadioURL
                CurrentRadioState = "Playing"
            End If
        ElseIf GetAsyncKeyState(Keys.D) And GetAsyncKeyState(Keys.M) Then
            FensAnim(XMBDesk, FensAnimArt.EINBLENDEN, FensAnimEffekt.DIMMEN, FensAnimRichtung.N, 500)
        End If

        If BrowserBox.Focused Or SelectedGame.Focused Or PS2Game1.Focused Or YoutubeBox.Focused Or StoreBox.Focused Or RadioBox.Focused Or DesktopBox.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoStart")
        ElseIf SelectedTrack.Focused Or Track1.Focused Or Track2.Focused Or Track3.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoListen")
        ElseIf SelectedVid.Focused Or Vid1.Focused Or Vid2.Focused Or Vid3.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoWatch")
        ElseIf SelectedPicture.Focused Or Picture1.Focused Or Picture2.Focused Or Picture3.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoWatch")
        ElseIf AddFriend.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoAdd")
        Else
            AdviceIco.Image = Nothing
            AdviceTxt.Text = ""
        End If

        If GetAsyncKeyState(Keys.Home) Then
            CallPSButton()
        End If

        If SelectedGame.Focused And GetAsyncKeyState(Keys.Enter) And GameDisc = False Then

            Games.Size = New Size(96, 96)
            GamesTxt.Visible = False
            GamesTxt.GlowState = False

            HideGames()
            Me.ActiveControl = Home

            GameSect = "PC"
            GameID = 1
            GameFormat = "EXE"

            'PlayGameIntro()
            PlayGameIntro_NoAnimation()

            currentgamestate = "game1"

        ElseIf SelectedGame.Focused And GetAsyncKeyState(Keys.Enter) And GameDisc = True Then

            Games.Size = New Size(96, 96)
            GamesTxt.Visible = False
            GamesTxt.GlowState = False

            For Each drive In DriveInfo.GetDrives()

                If drive.DriveType = DriveType.CDRom And drive.IsReady = True Then

                    If File.Exists(drive.ToString() + "system.cnf") Then
                        If ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT2 " Then
                            CheckPS2Game(drive.ToString() + "system.cnf", 0)
                            CurrentGameDisc = "PS2"

                            SwitchPCSXPlugin("Plugin")

                            SelectedGame.Tag = drive.ToString

                            GameSect = "DISC"
                            GameID = 1
                            GameFormat = "PS2"

                            'PlayGameIntro()
                            PlayGameIntro_NoAnimation()

                            currentgamestate = "game1"

                        ElseIf ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT2" Then
                            CheckPS2Game(drive.ToString() + "system.cnf", 0)
                            CurrentGameDisc = "PS2"

                            SwitchPCSXPlugin("Plugin")

                            SelectedGame.Tag = drive.ToString

                            GameSect = "DISC"
                            GameID = 1
                            GameFormat = "PS2"

                            'PlayGameIntro()
                            PlayGameIntro_NoAnimation()

                            currentgamestate = "game1"

                        ElseIf ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT " Then
                            CheckPS1Game(drive.ToString() + "system.cnf", 0)
                            CurrentGameDisc = "PS1"

                            SelectedGame.Tag = drive.ToString

                            GameSect = "DISC"
                            GameID = 1
                            GameFormat = "PSX"

                            'PlayGameIntro()
                            PlayGameIntro_NoAnimation()

                            currentgamestate = "game1"

                        ElseIf ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT" Then
                            CheckPS1Game(drive.ToString() + "system.cnf", 0)
                            CurrentGameDisc = "PS1"

                            SelectedGame.Tag = drive.ToString

                            GameSect = "DISC"
                            GameID = 1
                            GameFormat = "PSX"

                            'PlayGameIntro()
                            PlayGameIntro_NoAnimation()

                            currentgamestate = "game1"

                        End If

                    Else

                        SelectedGameText.Text = LangLoader.GetStringOfLang("XMB", "FileDisc")
                        SelectedGame.Image = My.Resources.disc_nameless
                        SelectedGame.Tag = drive.ToString

                        DiscExplorer.Show()
                        DiscExplorer.BringToFront()
                        DiscExplorer.Activate()

                        Me.Enabled = False

                    End If

                End If

            Next

            HideGames()

        ElseIf PS2Game1.Focused And GetAsyncKeyState(Keys.Enter) Then

            Games.Size = New Size(96, 96)
            GamesTxt.Visible = False
            GamesTxt.GlowState = False

            HideGames()
            Hideps2Games()
            Me.ActiveControl = Home

            Dim GameIF As New FileInfo(PS2Game1.Tag)

            If GameIF.Extension = ".iso" And SelectedGameText.Text = "Playstation Games" Then
                SwitchPCSXPlugin("ISO")
                GameSect = "PS"
                GameID = 1
                GameFormat = "ISO"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "ps2"
            ElseIf GameIF.Extension = ".cso" Then
                GameSect = "PS"
                GameID = 1
                GameFormat = "CSO"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "psp"
            ElseIf GameIF.Extension = ".bin" Then
                GameSect = "PS"
                GameID = 1
                GameFormat = "BIN"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "ps1"
            ElseIf GameIF.Extension = ".gba" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "GBA"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".gbc" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "GBC"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".gb" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "GBC"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smc" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "SMC"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smd" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "SMD"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".nes" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "NES"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"

            ElseIf GameIF.Extension = ".nds" Then

                GameSect = "NINTENDO"
                GameID = 1
                GameFormat = "NDS"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"

            ElseIf GameIF.Extension = ".gcm" Then

                GameSect = "NINTENDO"
                GameID = 1
                GameFormat = "GCM"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"

            ElseIf GameIF.Extension = ".iso" And SelectedGameText.Text = "Nintendo Games" Then

                GameSect = "NINTENDO"
                GameID = 1
                GameFormat = "ISO"

                'PlayGameIntro()
                PlayGameIntro_NoAnimation()

                currentgamestate = "retro"
            End If

        ElseIf BrowserBox.Focused And GetAsyncKeyState(Keys.Enter) Then

            Browser.Show()
            Browser.BringToFront()
            Browser.Activate()

            Me.Enabled = False
        ElseIf SelectedTrack.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideMusic()
            Me.ActiveControl = Home

            CurrentMusicTrack = SelectedTrack.Tag

            MusicPlayer.Show()
            MusicPlayer.BringToFront()

            Me.Enabled = False

        ElseIf SelectedVid.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideVideos()
            Me.ActiveControl = Home

            CurrentVideoTrack = SelectedVid.Tag

            VideoPlayer.Show()
            VideoPlayer.BringToFront()

            Me.Enabled = False

        ElseIf SelectedPicture.Focused And GetAsyncKeyState(Keys.Enter) Then

            HidePictures()
            Me.ActiveControl = Home

            CurrentPictureTrack = SelectedPicture.Tag

            PictureViewer.Show()
            PictureViewer.BringToFront()

            Me.Enabled = False

        ElseIf SettingsTheme.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideSettings()
            Me.ActiveControl = Home

            FileBrowser.Show()
            FileBrowser.BringToFront()

        ElseIf SettingsUpdate.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideSettings()
            Me.ActiveControl = Home

            currentxmbstate = "UPDATE"

            BackgroundDownload.Show()
            BackgroundDownload.BringToFront()

        ElseIf YoutubeBox.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideVideos()
            Me.ActiveControl = Home

            Browser.Show()
            Browser.BringToFront()
            Browser.WebBrowser1.Navigate("http://www.youtube.com")
            Browser.Activate()

            Me.Enabled = False

        ElseIf Poweroff.Focused And GetAsyncKeyState(Keys.Enter) Then

            SystemDialog.DialogTxt.Text = LangLoader.GetStringOfLang("XMB", "ExitXMBPC")
            SystemDialog.DialogPossibilities = "YESNO"

            If SystemDialog.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                StartUpHook.Close()
            Else
                Me.ActiveControl = Home
            End If

        ElseIf StoreBox.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideNetwork()
            Me.ActiveControl = Home

            Store.Show()
            Store.BringToFront()
            Store.Activate()

        ElseIf RadioBox.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideMusic()
            Me.ActiveControl = Home

            Browser.Show()
            Browser.BringToFront()
            Browser.WebBrowser1.Navigate("http://www.surfmusic.de/")
            Browser.Activate()

            Me.Enabled = False

        ElseIf DesktopBox.Focused And GetAsyncKeyState(Keys.Enter) Then

            FensAnim(XMBDesk, FensAnimArt.EINBLENDEN, FensAnimEffekt.DIMMEN, FensAnimRichtung.N, 500)

            Me.Enabled = False

        End If

    End Sub

#End Region

#Region "XMB-Hovers"

    Private Sub NewUserBox_GotFocus(sender As Object, e As EventArgs) Handles NewUserBox.GotFocus
        If Not themechanged = True Then
            NewUserBox.Image = My.Resources.new_user_h
        End If

        DropShadowOfText(CreateNewUser)
    End Sub

    Private Sub NewUserBox_LostFocus(sender As Object, e As EventArgs) Handles NewUserBox.LostFocus
        If Not themechanged = True Then
            NewUserBox.Image = My.Resources.Icons_11
        End If

        DropShadowOfText(CreateNewUser)
    End Sub

    Private Sub MeUserIco_GotFocus(sender As Object, e As EventArgs) Handles MeUserIco.GotFocus
        If Not themechanged = True Then
            MeUserIco.Image = My.Resources.me_user_hover
        End If

        DropShadowOfText(MeUserName)
    End Sub

    Private Sub MeUserIco_LostFocus(sender As Object, e As EventArgs) Handles MeUserIco.LostFocus
        If Not themechanged = True Then
            MeUserIco.Image = My.Resources.me_user
        End If

        DropShadowOfText(MeUserName)
    End Sub

    Private Sub Poweroff_GotFocus(sender As Object, e As EventArgs) Handles Poweroff.GotFocus
        If Not themechanged = True Then
            Poweroff.Image = My.Resources.power_h
        End If

        DropShadowOfText(PoweroffTxt)
    End Sub

    Private Sub Poweroff_LostFocus(sender As Object, e As EventArgs) Handles Poweroff.LostFocus
        If Not themechanged = True Then
            Poweroff.Image = My.Resources.power
        End If

        DropShadowOfText(PoweroffTxt)
    End Sub

    Private Sub DesktopBox_GotFocus(sender As Object, e As EventArgs) Handles DesktopBox.GotFocus
        DropShadowOfText(DesktopTxt)
    End Sub

    Private Sub DesktopTxt_LostFocus(sender As Object, e As EventArgs) Handles DesktopBox.LostFocus
        DropShadowOfText(DesktopTxt)
    End Sub

    Private Sub Home_GotFocus(sender As Object, e As EventArgs) Handles Home.GotFocus
        If Not themechanged = True Then
            'Home.Image = My.Resources.home_h
        End If

        Home.Size = New Size(105, 105)
        UsersTxt.Visible = True
        UsersTxt.GlowState = True

        CreateNewUser.Visible = True
        NewUserBox.Visible = True
        MeUserIco.Visible = True
        MeUserName.Visible = True
        Poweroff.Visible = True
        PoweroffTxt.Visible = True
        DesktopBox.Visible = True
        DesktopTxt.Visible = True
    End Sub

    Private Sub Settings_GotFocus(sender As Object, e As EventArgs) Handles Settings.GotFocus
        If Not themechanged = True Then
            'Settings.Image = My.Resources.settings_h
        End If

        Settings.Size = New Size(105, 105)
        SettingsTxt.Visible = True
        SettingsTxt.GlowState = True

        SettingsTheme.Visible = True
        SettingsThemeText.Visible = True
        SettingsUpdate.Visible = True
        SettingsUpdateText.Visible = True
    End Sub

    Private Sub Pictures_GotFocus(sender As Object, e As EventArgs) Handles Pictures.GotFocus
        If Not themechanged = True Then
            'Pictures.Image = My.Resources.photos_h
        End If

        Pictures.Size = New Size(105, 105)
        PhotosTxt.Visible = True
        PhotosTxt.GlowState = True

        SelectedPicture.Visible = True
        Picture1.Visible = True
        Picture2.Visible = True
        Picture3.Visible = True

        SelectedPictureName.Visible = True
        Picture1Text.Visible = True
        Picture2Text.Visible = True
        Picture3Text.Visible = True

        Me.ActiveControl = SelectedPicture
    End Sub

    Private Sub Musics_GotFocus(sender As Object, e As EventArgs) Handles Musics.GotFocus
        If Not themechanged = True Then
            'Musics.Image = My.Resources.music_h
        End If

        Musics.Size = New Size(105, 105)
        MusicTxt.Visible = True
        MusicTxt.GlowState = True

        SelectedTrack.Visible = True
        Track1.Visible = True
        Track2.Visible = True
        Track3.Visible = True
        RadioBox.Visible = True

        SelectedTrackName.Visible = True
        Track1Name.Visible = True
        Track2Name.Visible = True
        Track3Name.Visible = True
        RadioTxt.Visible = True

        Me.ActiveControl = SelectedTrack
    End Sub

    Private Sub Videos_GotFocus(sender As Object, e As EventArgs) Handles Videos.GotFocus
        If Not themechanged = True Then
            'Videos.Image = My.Resources.videos_h
        End If

        'If currentvideos = 3 And currentvideostate = "unloaded" Then
        'currentvideostate = "loaded"
        'LoadVideos()
        'End If

        Videos.Size = New Size(105, 105)
        VideosTxt.Visible = True
        VideosTxt.GlowState = True

        SelectedVid.Visible = True
        Vid1.Visible = True
        Vid2.Visible = True
        Vid3.Visible = True
        YoutubeBox.Visible = True

        SelectedVidText.Visible = True
        Vid1Text.Visible = True
        Vid2Text.Visible = True
        Vid3Text.Visible = True
        YoutubeTxt.Visible = True

        Me.ActiveControl = SelectedVid
    End Sub

    Private Sub Games_GotFocus(sender As Object, e As EventArgs) Handles Games.GotFocus
        If Not themechanged = True Then
            'Games.Image = My.Resources.games_h
        End If

        Games.Size = New Size(105, 105)
        GamesTxt.Visible = True
        GamesTxt.GlowState = True

        SelectedGame.Visible = True
        SelectedGameText.Visible = True

        Game1.Visible = True
        Game1Text.Visible = True

        Game2.Visible = True
        Game2Text.Visible = True

        Game3Text.Visible = True
        Game3.Visible = True

        Game4.Visible = True
        Game4Text.Visible = True

        Me.ActiveControl = SelectedGame
    End Sub

    Private Sub Browser_GotFocus(sender As Object, e As EventArgs) Handles BrowserBox.GotFocus
        If Not themechanged = True Then
            'Browser.Image = My.Resources.browser_h
        End If

        BrowserBox.Size = New Size(105, 105)
        BrowserTxt.Visible = True
        BrowserTxt.GlowState = True

        StoreBox.Visible = True
        StoreTxt.Visible = True
    End Sub

    Private Sub Home_LostFocus(sender As Object, e As EventArgs) Handles Home.LostFocus
        If Not themechanged = True Then
            Home.Image = My.Resources.home_icon
        End If

        Home.Size = New Size(96, 96)
        UsersTxt.Visible = False
        UsersTxt.GlowState = False

        If Not NewUserBox.Focused = True And Not Poweroff.Focused Then
            HideUsers()
        End If
    End Sub

    Private Sub Settings_LostFocus(sender As Object, e As EventArgs) Handles Settings.LostFocus
        If Not themechanged = True Then
            Settings.Image = My.Resources.settings_icon
        End If

        Settings.Size = New Size(96, 96)
        SettingsTxt.Visible = False
        SettingsTxt.GlowState = False

        If Not Settings.Focused And Not SettingsTheme.Focused And Not SettingsUpdate.Focused Then
            HideSettings()
        End If
    End Sub

    Private Sub Browser_LostFocus(sender As Object, e As EventArgs) Handles BrowserBox.LostFocus
        If Not themechanged = True Then
            BrowserBox.Image = My.Resources.browser_icon
        End If

        BrowserBox.Size = New Size(96, 96)
        BrowserTxt.Visible = False
        BrowserTxt.GlowState = False

        If Not BrowserBox.Focused = True And Not StoreBox.Focused = True Then
            HideNetwork()
        End If

    End Sub

#End Region

#Region "XMB-Browsing"

    Private Sub ControlRight()
        If currentgamestate = "" And Me.Enabled Then
            My.Computer.Audio.Play(".\media\xmb_browse_tick.wav", AudioPlayMode.Background)
        End If

        If Home.Focused = True Then
            Me.ActiveControl = Settings
        ElseIf Settings.Focused = True Then
            Me.ActiveControl = Pictures
        ElseIf Pictures.Focused = True Then
            Me.ActiveControl = Musics
        ElseIf Musics.Focused = True Then
            Me.ActiveControl = Videos
        ElseIf Videos.Focused = True Then
            Me.ActiveControl = Games
        ElseIf Games.Focused = True Then
            Me.ActiveControl = BrowserBox
        ElseIf BrowserBox.Focused = True Then
            Me.ActiveControl = Home

        ElseIf SelectedGame.Focused And SelectedGameText.Text = "Playstation Games" Then

            LoadPS2Games()

            PS2Game1.Visible = True
            PS2Game1Text.Visible = True
            PS2Game2.Visible = True
            PS2Game2Text.Visible = True
            PS2Game3.Visible = True
            PS2Game3Text.Visible = True
            PS2Game4.Visible = True
            PS2Game4Text.Visible = True

            Game1.Visible = False
            Game1Text.Visible = False
            Game2.Visible = False
            Game2Text.Visible = False
            Game3.Visible = False
            Game3Text.Visible = False
            Game4.Visible = False
            Game4Text.Visible = False

            Me.ActiveControl = PS2Game1

        ElseIf SelectedGame.Focused And SelectedGameText.Text = "Retro Games" Then

            LoadRetroGames()

            PS2Game1.Visible = True
            PS2Game1Text.Visible = True
            PS2Game2.Visible = True
            PS2Game2Text.Visible = True
            PS2Game3.Visible = True
            PS2Game3Text.Visible = True
            PS2Game4.Visible = True
            PS2Game4Text.Visible = True

            Game1.Visible = False
            Game1Text.Visible = False
            Game2.Visible = False
            Game2Text.Visible = False
            Game3.Visible = False
            Game3Text.Visible = False
            Game4.Visible = False
            Game4Text.Visible = False

            Me.ActiveControl = PS2Game1

        ElseIf SelectedGame.Focused And SelectedGameText.Text = "Nintendo Games" Then

            LoadNintendoGames()

            PS2Game1.Visible = True
            PS2Game1Text.Visible = True
            PS2Game2.Visible = True
            PS2Game2Text.Visible = True
            PS2Game3.Visible = True
            PS2Game3Text.Visible = True
            PS2Game4.Visible = True
            PS2Game4Text.Visible = True

            Game1.Visible = False
            Game1Text.Visible = False
            Game2.Visible = False
            Game2Text.Visible = False
            Game3.Visible = False
            Game3Text.Visible = False
            Game4.Visible = False
            Game4Text.Visible = False

            Me.ActiveControl = PS2Game1

        ElseIf SelectedGame.Focused And Not SelectedGameText.Text = "Playstation Games" Then
            HideGames()
            Hideps2Games()
            Me.ActiveControl = BrowserBox

        ElseIf SelectedGame.Focused And Not SelectedGameText.Text = "Retro Games" Then
            HideGames()
            Hideps2Games()
            Me.ActiveControl = BrowserBox

        ElseIf SelectedGame.Focused And Not SelectedGameText.Text = "Nintendo Games" Then
            HideGames()
            Hideps2Games()
            Me.ActiveControl = BrowserBox

        ElseIf SelectedTrack.Focused Then
            HideMusic()
            Me.ActiveControl = Videos

        ElseIf SelectedVid.Focused Then
            HideVideos()
            Me.ActiveControl = Games

        ElseIf SelectedPicture.Focused Then
            HidePictures()
            Me.ActiveControl = Musics

        End If

        If currentcategory = "users" Then
            Me.ActiveControl = Settings
            HideUsers()

        ElseIf currentcategory = "settings" Then
            Me.ActiveControl = Pictures
            HideSettings()

        End If

    End Sub

    Private Sub ControlLeft()
        If currentgamestate = "" And Me.Enabled Then
            My.Computer.Audio.Play(".\media\xmb_browse_tick.wav", AudioPlayMode.Background)
        End If

        If Home.Focused = True Then
            Me.ActiveControl = BrowserBox
        ElseIf BrowserBox.Focused Then
            Me.ActiveControl = Games
        ElseIf Games.Focused Then
            Me.ActiveControl = Videos
        ElseIf Videos.Focused = True Then
            Me.ActiveControl = Musics
        ElseIf Musics.Focused = True Then
            Me.ActiveControl = Pictures
        ElseIf Pictures.Focused = True Then
            Me.ActiveControl = Settings
        ElseIf Settings.Focused = True Then
            Me.ActiveControl = Home
        ElseIf SelectedGame.Focused Then
            HideGames()
            Hideps2Games()
            Me.ActiveControl = Videos
        ElseIf SelectedTrack.Focused Then
            HideMusic()
            Me.ActiveControl = Pictures
        ElseIf SelectedVid.Focused Then
            HideVideos()
            Me.ActiveControl = Musics
        ElseIf SelectedPicture.Focused Then
            HidePictures()
            Me.ActiveControl = Settings
        ElseIf PS2Game1.Focused Then
            Hideps2Games()

            Me.ActiveControl = SelectedGame

            Game1.Visible = True
            Game2.Visible = True
            Game3.Visible = True
            Game4.Visible = True

            Game1Text.Visible = True
            Game2Text.Visible = True
            Game3Text.Visible = True
            Game4Text.Visible = True

        End If

        If currentcategory = "settings" Then
            Me.ActiveControl = Home
            HideSettings()

        ElseIf currentcategory = "network" Then
            Me.ActiveControl = Games
            HideNetwork()

        End If

    End Sub

    Private Sub ControlBottom()
        If currentgamestate = "" And Me.Enabled Then
            My.Computer.Audio.Play(".\media\xmb_browse_tick.wav", AudioPlayMode.Background)
        End If

        If Home.Focused = True Then
            currentcategory = "users"
        End If

        If Settings.Focused = True Then
            currentcategory = "settings"
        End If

        If Pictures.Focused = True Then
            currentcategory = "pictures"
        End If

        If Musics.Focused = True Then
            currentcategory = "music"
        End If

        If Videos.Focused = True Then
            currentcategory = "videos"
        End If

        If Games.Focused = True Then
            currentcategory = "games"
        End If

        If BrowserBox.Focused = True Then
            currentcategory = "network"
        End If

    End Sub

    Private Sub ControlTop()
        If currentgamestate = "" And Me.Enabled Then
            My.Computer.Audio.Play(".\media\xmb_browse_tick.wav", AudioPlayMode.Background)
        End If

        If Home.Focused = True Then
            currentcategory = "users"
        End If

        If Settings.Focused = True Then
            currentcategory = "settings"
        End If

        If Pictures.Focused = True Then
            currentcategory = "pictures"
        End If

        If Musics.Focused = True Then
            currentcategory = "music"
        End If

        If Videos.Focused = True Then
            currentcategory = "videos"
        End If

        If Games.Focused = True Then
            currentcategory = "games"
        End If

        If BrowserBox.Focused = True Then
            currentcategory = "network"
        End If

    End Sub

#End Region

#Region "XMB-Games-Browsing"

    Private Sub ClearGames()

        PS2Game1.Tag = ""
        PS2Game1Text.Text = ""
        PS2Game1.Image = Nothing

        PS2Game2.Tag = ""
        PS2Game2Text.Text = ""
        PS2Game2.Image = Nothing

        PS2Game3.Tag = ""
        PS2Game3Text.Text = ""
        PS2Game3.Image = Nothing

        PS2Game4.Tag = ""
        PS2Game4Text.Text = ""
        PS2Game4.Image = Nothing

    End Sub

    Private Sub HideGames()

        SelectedGame.Visible = False
        SelectedGameText.Visible = False
        Game1.Visible = False
        Game1Text.Visible = False
        Game2.Visible = False
        Game2Text.Visible = False
        Game3.Visible = False
        Game3Text.Visible = False
        Game4.Visible = False
        Game4Text.Visible = False
        OldGame1.Visible = False
        OldGame1Text.Visible = False
        OldGame2.Visible = False
        OldGame2Text.Visible = False

        currentcategory = "xmb"
    End Sub

    Private Sub Hideps2Games()

        PS2Game1.Visible = False
        PS2Game1Text.Visible = False
        PS2Game2.Visible = False
        PS2Game2Text.Visible = False
        PS2Game3.Visible = False
        PS2Game3Text.Visible = False
        PS2Game4.Visible = False
        PS2Game4Text.Visible = False

        currentcategory = "games"
    End Sub

    Private Sub LoadDisc()

        On Error Resume Next

        For Each drive In DriveInfo.GetDrives()

            If drive.DriveType = DriveType.CDRom And drive.IsReady = True Then

                If File.Exists(drive.ToString() + "system.cnf") Then
                    If ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT2 " Then
                        CheckPS2Game(drive.ToString() + "system.cnf", 0)
                        CurrentGameDisc = "PS2"

                    ElseIf ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT2" Then
                        CheckPS2Game(drive.ToString() + "system.cnf", 0)
                        CurrentGameDisc = "PS2"

                    ElseIf ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT " Then
                        CheckPS1Game(drive.ToString() + "system.cnf", 0)
                        CurrentGameDisc = "PS1"

                    ElseIf ReadLine(1, drive.ToString() + "system.cnf").Split("=")(0) = "BOOT" Then
                        CheckPS1Game(drive.ToString() + "system.cnf", 0)
                        CurrentGameDisc = "PS1"

                    End If

                    SelectedGame.Tag = drive.ToString

                Else

                    SelectedGameText.Text = LangLoader.GetStringOfLang("XMB", "FileDisc")
                    SelectedGame.Image = My.Resources.disc_nameless
                    SelectedGame.Tag = drive.ToString

                End If

            End If

        Next

    End Sub

    Private Sub LoadGames()

        On Error Resume Next

        currentgames = 4

        For Each Gamex As String In File.ReadAllLines(".\glist.txt")
            gameslist.Add(Gamex)
        Next

        SelectedGame.Tag = SplitGamePath(gameslist(0).ToString, 0)
        SelectedGameText.Text = SplitGamePath(gameslist(0).ToString, 1)
        SelectedGame.Image = GetGameCover(gameslist(0).ToString)

        Game1.Tag = SplitGamePath(gameslist(1).ToString, 0)
        Game1Text.Text = SplitGamePath(gameslist(1).ToString, 1)
        Game1.Image = GetGameCover(gameslist(1).ToString)

        Game2.Tag = SplitGamePath(gameslist(2).ToString, 0)
        Game2Text.Text = SplitGamePath(gameslist(2).ToString, 1)
        Game2.Image = GetGameCover(gameslist(2).ToString)

        If Not gameslist(3) = "" Then
            Game3.Tag = SplitGamePath(gameslist(3).ToString, 0)
            Game3Text.Text = SplitGamePath(gameslist(3).ToString, 1)
            Game3.Image = GetGameCover(gameslist(3).ToString)
        Else
            currentgames = currentgames - 1

            Game3.Tag = Nothing
            Game3Text.Text = ""
            Game3.Image = Nothing
        End If

        If Not gameslist(3) = "" Then
            Game4.Tag = SplitGamePath(gameslist(4).ToString, 0)
            Game4Text.Text = SplitGamePath(gameslist(4).ToString, 1)
            Game4.Image = GetGameCover(gameslist(4).ToString)
        Else
            currentgames = currentgames - 1

            Game4.Tag = Nothing
            Game4Text.Text = ""
            Game4.Image = Nothing
        End If

    End Sub

    Private Sub LoadPS2Games()

        ClearGames()

        On Error Resume Next

        For Each Ga As String In File.ReadAllLines(".\psgameslist.txt")
            ps2gameslist.Add(Ga)
        Next

        PS2Game1.Tag = SplitGamePath(ps2gameslist(0).ToString, 0)
        PS2Game1Text.Text = SplitGamePath(ps2gameslist(0).ToString, 1)
        PS2Game1.Image = GetGameCover(ps2gameslist(0).ToString)

        PS2Game2.Tag = SplitGamePath(ps2gameslist(1).ToString, 0)
        PS2Game2Text.Text = SplitGamePath(ps2gameslist(1).ToString, 1)
        PS2Game2.Image = GetGameCover(ps2gameslist(1).ToString)

        PS2Game3.Tag = SplitGamePath(ps2gameslist(2).ToString, 0)
        PS2Game3Text.Text = SplitGamePath(ps2gameslist(2).ToString, 1)
        PS2Game3.Image = GetGameCover(ps2gameslist(2).ToString)

        PS2Game4.Tag = SplitGamePath(ps2gameslist(3).ToString, 0)
        PS2Game4Text.Text = SplitGamePath(ps2gameslist(3).ToString, 1)
        PS2Game4.Image = GetGameCover(ps2gameslist(3).ToString)

        currentps2games = 3

    End Sub

    Public Sub LoadRetroGames()

        ClearGames()

        On Error Resume Next

        For Each Ga As String In File.ReadAllLines(".\retrogameslist.txt")
            retrogameslist.Add(Ga)
        Next

        PS2Game1.Tag = SplitGamePath(retrogameslist(0).ToString, 0)
        PS2Game1Text.Text = SplitGamePath(retrogameslist(0).ToString, 1)
        PS2Game1.Image = GetGameCover(retrogameslist(0).ToString)

        PS2Game2.Tag = SplitGamePath(retrogameslist(1).ToString, 0)
        PS2Game2Text.Text = SplitGamePath(retrogameslist(1).ToString, 1)
        PS2Game2.Image = GetGameCover(retrogameslist(1).ToString)

        PS2Game3.Tag = SplitGamePath(retrogameslist(2).ToString, 0)
        PS2Game3Text.Text = SplitGamePath(retrogameslist(2).ToString, 1)
        PS2Game3.Image = GetGameCover(retrogameslist(2).ToString)

        PS2Game4.Tag = SplitGamePath(retrogameslist(3).ToString, 0)
        PS2Game4Text.Text = SplitGamePath(retrogameslist(3).ToString, 1)
        PS2Game4.Image = GetGameCover(retrogameslist(3).ToString)

        currentretrogames = 3

    End Sub

    Public Sub LoadNintendoGames()

        ClearGames()

        On Error Resume Next

        For Each Ga As String In File.ReadAllLines(".\nintendogameslist.txt")
            nintendogameslist.Add(Ga)
        Next

        PS2Game1.Tag = SplitGamePath(nintendogameslist(0).ToString, 0)
        PS2Game1Text.Text = SplitGamePath(nintendogameslist(0).ToString, 1)
        PS2Game1.Image = GetGameCover(nintendogameslist(0).ToString)

        PS2Game2.Tag = SplitGamePath(nintendogameslist(1).ToString, 0)
        PS2Game2Text.Text = SplitGamePath(nintendogameslist(1).ToString, 1)
        PS2Game2.Image = GetGameCover(nintendogameslist(1).ToString)

        PS2Game3.Tag = SplitGamePath(nintendogameslist(2).ToString, 0)
        PS2Game3Text.Text = SplitGamePath(nintendogameslist(2).ToString, 1)
        PS2Game3.Image = GetGameCover(nintendogameslist(2).ToString)

        PS2Game4.Tag = SplitGamePath(nintendogameslist(3).ToString, 0)
        PS2Game4Text.Text = SplitGamePath(nintendogameslist(3).ToString, 1)
        PS2Game4.Image = GetGameCover(nintendogameslist(3).ToString)

        currentnintendogames = 3

    End Sub

    Private Sub BrowseNextGames()

        On Error Resume Next

        If secondtime = True Then
            OldGame2.Visible = True
            OldGame2Text.Visible = True

            OldGame2.Tag = OldGame1.Tag
            OldGame2Text.Text = OldGame1Text.Text
            OldGame2.Image = OldGame1.Image
        End If

        OldGame1.Visible = True
        OldGame1Text.Visible = True

        OldGame1.Tag = SelectedGame.Tag
        OldGame1Text.Text = SelectedGameText.Text
        OldGame1.Image = SelectedGame.Image

        SelectedGame.Tag = Game1.Tag
        SelectedGameText.Text = Game1Text.Text
        SelectedGame.Image = Game1.Image

        Game1.Tag = Game2.Tag
        Game1Text.Text = Game2Text.Text
        Game1.Image = Game2.Image

        Game2.Tag = Game3.Tag
        Game2Text.Text = Game3Text.Text
        Game2.Image = Game3.Image

        Game3.Tag = Game4.Tag
        Game3Text.Text = Game4Text.Text
        Game3.Image = Game4.Image

        If gameslist(currentgames + 1) = "" Then
            Game4.Tag = SplitGamePath(gameslist(0).ToString, 0)
            Game4Text.Text = SplitGamePath(gameslist(0).ToString, 1)
            Game4.Image = GetGameCover(gameslist(0).ToString)

            currentgames = 0
        Else
            Game4.Tag = SplitGamePath(gameslist(currentgames + 1).ToString, 0)
            Game4Text.Text = SplitGamePath(gameslist(currentgames + 1).ToString, 1)
            Game4.Image = GetGameCover(gameslist(currentgames + 1).ToString)

            currentgames = currentgames + 1
        End If

        If Not secondtime = True Then
            secondtime = True
        End If

    End Sub

    Private Sub BrowseLastGames()

        On Error Resume Next

        Game4.Tag = Game3.Tag
        Game4Text.Text = Game3Text.Text
        Game4.Image = Game3.Image

        Game3.Tag = Game2.Tag
        Game3Text.Text = Game2Text.Text
        Game3.Image = Game2.Image

        Game2.Tag = Game1.Tag
        Game2Text.Text = Game1Text.Text
        Game2.Image = Game1.Image

        Game1.Tag = SelectedGame.Tag
        Game1Text.Text = SelectedGameText.Text
        Game1.Image = SelectedGame.Image

        SelectedGame.Tag = OldGame1.Tag
        SelectedGameText.Text = OldGame1Text.Text
        SelectedGame.Image = OldGame1.Image

        OldGame1.Tag = OldGame2.Tag
        OldGame1Text.Text = OldGame2Text.Text
        OldGame1.Image = OldGame2.Image

        If gameslist(currentgames - 1) = "" Then

            OldGame2.Visible = False
            OldGame2Text.Visible = False

            OldGame1.Tag = SplitGamePath(gameslist(0).ToString, 0)
            OldGame1Text.Text = SplitGamePath(gameslist(0).ToString, 1)
            OldGame1.Image = GetGameCover(gameslist(0).ToString)

            currentgames = 0

        Else
            OldGame2.Tag = SplitGamePath(gameslist(currentgames - 1).ToString, 0)
            OldGame2Text.Text = SplitGamePath(gameslist(currentgames - 1).ToString, 1)
            OldGame2.Image = GetGameCover(gameslist(currentgames - 1).ToString)

            currentgames = currentgames - 1
        End If

    End Sub

    Private Sub BrowseNextPS2Games()

        On Error Resume Next

        PS2Game1.Tag = PS2Game2.Tag
        PS2Game1Text.Text = PS2Game2Text.Text
        PS2Game1.Image = PS2Game2.Image

        PS2Game2.Tag = PS2Game3.Tag
        PS2Game2Text.Text = PS2Game3Text.Text
        PS2Game2.Image = PS2Game3.Image

        PS2Game3.Tag = PS2Game4.Tag
        PS2Game3Text.Text = PS2Game4Text.Text
        PS2Game3.Image = PS2Game4.Image

        If ps2gameslist(currentps2games + 1) = "" Then
            PS2Game4.Tag = SplitGamePath(ps2gameslist(0).ToString, 0)
            PS2Game4Text.Text = SplitGamePath(ps2gameslist(0).ToString, 1)
            PS2Game4.Image = GetGameCover(ps2gameslist(0).ToString)

            currentps2games = 0
        Else
            PS2Game4.Tag = SplitGamePath(ps2gameslist(currentps2games + 1).ToString, 0)
            PS2Game4Text.Text = SplitGamePath(ps2gameslist(currentps2games + 1).ToString, 1)
            PS2Game4.Image = GetGameCover(ps2gameslist(currentps2games + 1).ToString)

            currentps2games = currentps2games + 1
        End If

    End Sub

    Private Sub BrowseLastPS2Games()

        On Error Resume Next

        PS2Game4.Tag = PS2Game3.Tag
        PS2Game4Text.Text = PS2Game3Text.Text
        PS2Game4.Image = PS2Game3.Image

        PS2Game3.Tag = PS2Game2.Tag
        PS2Game3Text.Text = PS2Game2Text.Text
        PS2Game3.Image = PS2Game2.Image

        PS2Game2.Tag = PS2Game1.Tag
        PS2Game2Text.Text = PS2Game1Text.Text
        PS2Game2.Image = PS2Game1.Image

        If ps2gameslist(currentps2games - 1) = "" Then
            PS2Game1.Tag = SplitGamePath(ps2gameslist(0).ToString, 0)
            PS2Game1Text.Text = SplitGamePath(ps2gameslist(0).ToString, 1)
            PS2Game1.Image = GetGameCover(ps2gameslist(0).ToString)

            currentps2games = 0
        Else
            PS2Game1.Tag = SplitGamePath(ps2gameslist(currentps2games - 1).ToString, 0)
            PS2Game1Text.Text = SplitGamePath(ps2gameslist(currentps2games - 1).ToString, 1)
            PS2Game1.Image = GetGameCover(ps2gameslist(currentps2games - 1).ToString)

            currentps2games = currentps2games - 1
        End If

    End Sub

    Private Sub BrowseNextRetroGames()

        On Error Resume Next

        PS2Game1.Tag = PS2Game2.Tag
        PS2Game1Text.Text = PS2Game2Text.Text
        PS2Game1.Image = PS2Game2.Image

        PS2Game2.Tag = PS2Game3.Tag
        PS2Game2Text.Text = PS2Game3Text.Text
        PS2Game2.Image = PS2Game3.Image

        PS2Game3.Tag = PS2Game4.Tag
        PS2Game3Text.Text = PS2Game4Text.Text
        PS2Game3.Image = PS2Game4.Image

        If retrogameslist(currentretrogames + 1) = "" Then
            PS2Game3.Tag = SplitGamePath(retrogameslist(0).ToString, 0)
            PS2Game3Text.Text = SplitGamePath(retrogameslist(0).ToString, 1)
            PS2Game3.Image = GetGameCover(retrogameslist(0).ToString)

            currentps2games = 0
        Else
            PS2Game3.Tag = SplitGamePath(retrogameslist(currentretrogames + 1).ToString, 0)
            PS2Game3Text.Text = SplitGamePath(retrogameslist(currentretrogames + 1).ToString, 1)
            PS2Game3.Image = GetGameCover(retrogameslist(currentretrogames + 1).ToString)

            currentretrogames = currentretrogames + 1
        End If

    End Sub

    Private Sub BrowseLastRetroGames()

        On Error Resume Next

        PS2Game4.Tag = PS2Game3.Tag
        PS2Game4Text.Text = PS2Game3Text.Text
        PS2Game4.Image = PS2Game3.Image

        PS2Game3.Tag = PS2Game2.Tag
        PS2Game3Text.Text = PS2Game2Text.Text
        PS2Game3.Image = PS2Game2.Image

        PS2Game2.Tag = PS2Game1.Tag
        PS2Game2Text.Text = PS2Game1Text.Text
        PS2Game2.Image = PS2Game1.Image

        If retrogameslist(currentretrogames - 1) = "" Then
            PS2Game1.Tag = SplitGamePath(retrogameslist(0).ToString, 0)
            PS2Game1Text.Text = SplitGamePath(retrogameslist(0).ToString, 1)
            PS2Game1.Image = GetGameCover(retrogameslist(0).ToString)

            currentretrogames = 0
        Else
            PS2Game1.Tag = SplitGamePath(retrogameslist(currentretrogames - 1).ToString, 0)
            PS2Game1Text.Text = SplitGamePath(retrogameslist(currentretrogames - 1).ToString, 1)
            PS2Game1.Image = GetGameCover(retrogameslist(currentretrogames - 1).ToString)

            currentretrogames = currentretrogames - 1
        End If

    End Sub

    Private Sub BrowseNextNintendoGames()

        On Error Resume Next

        PS2Game1.Tag = PS2Game2.Tag
        PS2Game1Text.Text = PS2Game2Text.Text
        PS2Game1.Image = PS2Game2.Image

        PS2Game2.Tag = PS2Game3.Tag
        PS2Game2Text.Text = PS2Game3Text.Text
        PS2Game2.Image = PS2Game3.Image

        PS2Game3.Tag = PS2Game4.Tag
        PS2Game3Text.Text = PS2Game4Text.Text
        PS2Game3.Image = PS2Game4.Image

        If nintendogameslist(currentnintendogames + 1) = "" Then
            PS2Game3.Tag = SplitGamePath(nintendogameslist(0).ToString, 0)
            PS2Game3Text.Text = SplitGamePath(nintendogameslist(0).ToString, 1)
            PS2Game3.Image = GetGameCover(nintendogameslist(0).ToString)

            currentps2games = 0
        Else
            PS2Game3.Tag = SplitGamePath(nintendogameslist(currentnintendogames + 1).ToString, 0)
            PS2Game3Text.Text = SplitGamePath(nintendogameslist(currentnintendogames + 1).ToString, 1)
            PS2Game3.Image = GetGameCover(nintendogameslist(currentnintendogames + 1).ToString)

            currentnintendogames = currentnintendogames + 1
        End If

    End Sub

    Private Sub BrowseLastNintendoGames()

        On Error Resume Next

        PS2Game4.Tag = PS2Game3.Tag
        PS2Game4Text.Text = PS2Game3Text.Text
        PS2Game4.Image = PS2Game3.Image

        PS2Game3.Tag = PS2Game2.Tag
        PS2Game3Text.Text = PS2Game2Text.Text
        PS2Game3.Image = PS2Game2.Image

        PS2Game2.Tag = PS2Game1.Tag
        PS2Game2Text.Text = PS2Game1Text.Text
        PS2Game2.Image = PS2Game1.Image

        If nintendogameslist(currentnintendogames - 1) = "" Then
            PS2Game1.Tag = SplitGamePath(nintendogameslist(0).ToString, 0)
            PS2Game1Text.Text = SplitGamePath(nintendogameslist(0).ToString, 1)
            PS2Game1.Image = GetGameCover(nintendogameslist(0).ToString)

            currentnintendogames = 0
        Else
            PS2Game1.Tag = SplitGamePath(nintendogameslist(currentnintendogames - 1).ToString, 0)
            PS2Game1Text.Text = SplitGamePath(nintendogameslist(currentnintendogames - 1).ToString, 1)
            PS2Game1.Image = GetGameCover(nintendogameslist(currentnintendogames - 1).ToString)

            currentnintendogames = currentnintendogames - 1
        End If

    End Sub

#End Region

#Region "XMB-Users-Browsing"

    Private Sub HideUsers()
        NewUserBox.Top = 400
        CreateNewUser.Top = 415
        MeUserIco.Top = 500
        MeUserName.Top = 515
        DesktopBox.Top = 600
        DesktopTxt.Top = 615
        Poweroff.Top = 700
        PoweroffTxt.Top = 715

        NewUserBox.Visible = False
        CreateNewUser.Visible = False
        MeUserIco.Visible = False
        MeUserName.Visible = False
        Poweroff.Visible = False
        PoweroffTxt.Visible = False
        DesktopBox.Visible = False
        DesktopTxt.Visible = False
        currentcategory = "xmb"
    End Sub

    Private Sub ControlUsersBottom()
        If Home.Focused = True Then
            Me.ActiveControl = NewUserBox
        ElseIf NewUserBox.Focused = True Then
            Me.ActiveControl = MeUserIco

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))
            transition.add(NewUserBox, "Top", 200)
            transition.add(CreateNewUser, "Top", 215)

            transition.add(MeUserIco, "Top", 400)
            transition.add(MeUserName, "Top", 415)

            transition.add(DesktopBox, "Top", 500)
            transition.add(DesktopTxt, "Top", 515)

            transition.add(Poweroff, "Top", 600)
            transition.add(PoweroffTxt, "Top", 615)

            transition.run()

        ElseIf MeUserIco.Focused = True Then
            Me.ActiveControl = DesktopBox

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))

            transition.add(MeUserIco, "Top", 200)
            transition.add(MeUserName, "Top", 215)

            transition.add(DesktopBox, "Top", 400)
            transition.add(DesktopTxt, "Top", 415)

            transition.add(Poweroff, "Top", 500)
            transition.add(PoweroffTxt, "Top", 515)

            transition.add(NewUserBox, "Top", 600)
            transition.add(CreateNewUser, "Top", 615)

            transition.run()

        ElseIf DesktopBox.Focused = True Then
            Me.ActiveControl = Poweroff

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))

            transition.add(DesktopBox, "Top", 200)
            transition.add(DesktopTxt, "Top", 215)

            transition.add(Poweroff, "Top", 400)
            transition.add(PoweroffTxt, "Top", 415)

            transition.add(NewUserBox, "Top", 500)
            transition.add(CreateNewUser, "Top", 515)

            transition.add(MeUserIco, "Top", 600)
            transition.add(MeUserName, "Top", 615)

            transition.run()

        ElseIf Poweroff.Focused = True Then
            Me.ActiveControl = Home

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))
            transition.add(NewUserBox, "Top", 400)
            transition.add(CreateNewUser, "Top", 415)

            transition.add(MeUserIco, "Top", 500)
            transition.add(MeUserName, "Top", 515)

            transition.add(DesktopBox, "Top", 600)
            transition.add(DesktopTxt, "Top", 615)

            transition.add(Poweroff, "Top", 700)
            transition.add(PoweroffTxt, "Top", 715)

            transition.run()

            currentcategory = "xmb"
        End If
    End Sub

    Private Sub ControlUsersTop()
        If Home.Focused Then
            Me.ActiveControl = Poweroff

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))

            transition.add(DesktopBox, "Top", 200)
            transition.add(DesktopTxt, "Top", 215)

            transition.add(MeUserIco, "Top", 600)
            transition.add(MeUserName, "Top", 615)

            transition.add(NewUserBox, "Top", 500)
            transition.add(CreateNewUser, "Top", 515)

            transition.add(Poweroff, "Top", 400)
            transition.add(PoweroffTxt, "Top", 415)

            transition.run()

        ElseIf Poweroff.Focused = True Then
            Me.ActiveControl = DesktopBox

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))

            transition.add(MeUserIco, "Top", 200)
            transition.add(MeUserName, "Top", 215)

            transition.add(DesktopBox, "Top", 400)
            transition.add(DesktopTxt, "Top", 415)

            transition.add(Poweroff, "Top", 500)
            transition.add(PoweroffTxt, "Top", 515)

            transition.add(NewUserBox, "Top", 600)
            transition.add(CreateNewUser, "Top", 615)

            transition.run()

        ElseIf DesktopBox.Focused = True Then
            Me.ActiveControl = MeUserIco

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))
            transition.add(NewUserBox, "Top", 200)
            transition.add(CreateNewUser, "Top", 215)

            transition.add(MeUserIco, "Top", 400)
            transition.add(MeUserName, "Top", 415)

            transition.add(DesktopBox, "Top", 500)
            transition.add(DesktopTxt, "Top", 515)

            transition.add(Poweroff, "Top", 600)
            transition.add(PoweroffTxt, "Top", 615)

            transition.run()

        ElseIf MeUserIco.Focused = True Then
            Me.ActiveControl = NewUserBox

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))

            transition.add(Poweroff, "Top", 200)
            transition.add(PoweroffTxt, "Top", 215)

            transition.add(NewUserBox, "Top", 400)
            transition.add(CreateNewUser, "Top", 415)

            transition.add(DesktopBox, "Top", 600)
            transition.add(DesktopTxt, "Top", 615)

            transition.add(MeUserIco, "Top", 500)
            transition.add(MeUserName, "Top", 515)

            transition.run()

        ElseIf NewUserBox.Focused = True Then
            Me.ActiveControl = Home

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))

            transition.add(NewUserBox, "Top", 400)
            transition.add(CreateNewUser, "Top", 415)

            transition.add(MeUserIco, "Top", 500)
            transition.add(MeUserName, "Top", 515)

            transition.add(DesktopBox, "Top", 600)
            transition.add(DesktopTxt, "Top", 615)

            transition.add(Poweroff, "Top", 700)
            transition.add(PoweroffTxt, "Top", 715)

            transition.run()

            currentcategory = "xmb"
        End If
    End Sub

#End Region

#Region "XMB-Network-Browsing"

    Private Sub HideNetwork()
        StoreBox.Visible = False
        StoreTxt.Visible = False
        currentcategory = "xmb"
    End Sub

    Private Sub ControlNetworkBottom()
        If BrowserBox.Focused = True Then
            Me.ActiveControl = StoreBox
        ElseIf StoreBox.Focused = True Then
            Me.ActiveControl = BrowserBox
            currentcategory = "xmb"
        End If
    End Sub

    Private Sub ControlNetworkTop()
        If BrowserBox.Focused = True Then
            Me.ActiveControl = StoreBox
        ElseIf StoreBox.Focused = True Then
            Me.ActiveControl = BrowserBox
            currentcategory = "xmb"
        End If
    End Sub

    Private Sub Store_GotFocus(sender As Object, e As EventArgs) Handles StoreBox.GotFocus
        DropShadowOfText(StoreTxt)
    End Sub

    Private Sub Store_LostFocus(sender As Object, e As EventArgs) Handles StoreBox.LostFocus
        DropShadowOfText(StoreTxt)
    End Sub

#End Region

#Region "XMB-Music-Browsing"

    Public Sub LoadMusic()

        On Error Resume Next

        Dim musicfiles() As String = getFiles(Functions.INI_ReadValueFromFile("Paths", "MusicPath", "", ".\media\paths.ini"), "*.mp3|*.aac|*.wav|*.flac|*.ogg", SearchOption.AllDirectories)

        For Each Musics As String In musicfiles
            musiclist.Add(Musics)
        Next

        SelectedTrack.Image = Cover(musiclist(0).ToString)
        SelectedTrackName.Text = Path.GetFileNameWithoutExtension(musiclist(0).ToString)
        SelectedTrack.Tag = musiclist(0).ToString

        Track1.Image = Cover(musiclist(1).ToString)
        Track1Name.Text = Path.GetFileNameWithoutExtension(musiclist(1).ToString)
        Track1.Tag = musiclist(1).ToString

        Track2.Image = Cover(musiclist(2).ToString)
        Track2Name.Text = Path.GetFileNameWithoutExtension(musiclist(2).ToString)
        Track2.Tag = musiclist(2).ToString

        Track3.Image = Cover(musiclist(3).ToString)
        Track3Name.Text = Path.GetFileNameWithoutExtension(musiclist(3).ToString)
        Track3.Tag = musiclist(3).ToString

        currenttrack = 3

    End Sub

    Private Sub HideMusic()
        SelectedTrack.Visible = False
        Track1.Visible = False
        Track2.Visible = False
        Track3.Visible = False
        RadioBox.Visible = False
        OldTrack1.Visible = False
        OldTrack2.Visible = False

        SelectedTrackName.Visible = False
        Track1Name.Visible = False
        Track2Name.Visible = False
        Track3Name.Visible = False
        RadioTxt.Visible = False
        OldTrack1Text.Visible = False
        OldTrack2.Visible = False

        currentcategory = "xmb"
    End Sub

    Private Sub BrowseNextMusic()

        On Error Resume Next

        If secondtime = True Then
            OldTrack2.Visible = True
            OldTrack2Text.Visible = True

            OldTrack2.Tag = OldTrack1.Tag
            OldTrack2Text.Text = OldTrack1Text.Text
            OldTrack2.Image = OldTrack1.Image
        End If

        OldTrack1.Visible = True
        OldTrack1Text.Visible = True

        OldTrack1.Tag = SelectedTrack.Tag
        OldTrack1Text.Text = SelectedTrackName.Text
        OldTrack1.Image = SelectedTrack.Image

        SelectedTrack.Tag = Track1.Tag
        SelectedTrackName.Text = Track1Name.Text
        SelectedTrack.Image = Track1.Image

        Track1.Tag = Track2.Tag
        Track1Name.Text = Track2Name.Text
        Track1.Image = Track2.Image

        Track2.Tag = Track3.Tag
        Track2Name.Text = Track3Name.Text
        Track2.Image = Track3.Image

        If musiclist(currenttrack + 1) = "" Then
            Track3.Tag = musiclist(0).ToString
            Track3Name.Text = Path.GetFileNameWithoutExtension(musiclist(0).ToString)
            Track3.Image = Cover(musiclist(0).ToString)

            currenttrack = 0
        Else
            Track3.Tag = musiclist(currenttrack + 1).ToString
            Track3Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack + 1).ToString)
            Track3.Image = Cover(musiclist(currenttrack + 1).ToString)

            currenttrack = currenttrack + 1
        End If

        If Not secondtime = True Then
            secondtime = True
        End If

    End Sub

    Private Sub BrowseLastMusic()

        On Error Resume Next

        If musiclist(currenttrack - 1) = "" Then
            OldTrack2.Visible = False
            OldTrack2Text.Visible = False

            Track3.Tag = Track2.Tag
            Track3Name.Text = Track2Name.Text
            Track3.Image = Track2.Image

            Track2.Tag = Track1.Tag
            Track2Name.Text = Track1Name.Text
            Track2.Image = Track1.Image

            Track1.Tag = SelectedTrack.Tag
            Track1Name.Text = SelectedTrackName.Text
            Track1.Image = SelectedTrack.Image

            SelectedTrack.Tag = OldTrack1.Tag
            SelectedTrackName.Text = OldTrack1Text.Text
            SelectedTrack.Image = OldTrack1.Image

            OldTrack1.Tag = musiclist(0).ToString
            OldTrack1Text.Text = Path.GetFileNameWithoutExtension(musiclist(0).ToString)
            OldTrack1.Image = Cover(musiclist(0).ToString)

            currenttrack = 0

        Else

            Track3.Tag = Track2.Tag
            Track3Name.Text = Track2Name.Text
            Track3.Image = Track2.Image

            Track2.Tag = Track1.Tag
            Track2Name.Text = Track1Name.Text
            Track2.Image = Track1.Image

            Track1.Tag = SelectedTrack.Tag
            Track1Name.Text = SelectedTrackName.Text
            Track1.Image = SelectedTrack.Image

            SelectedTrack.Tag = OldTrack1.Tag
            SelectedTrackName.Text = OldTrack1Text.Text
            SelectedTrack.Image = OldTrack1.Image

            OldTrack1.Tag = OldTrack2.Tag
            OldTrack1Text.Text = OldTrack2Text.Text
            OldTrack1.Image = OldTrack2.Image

            OldTrack2.Tag = musiclist(currenttrack - 1).ToString
            OldTrack2Text.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack - 1).ToString)
            OldTrack2.Image = Cover(musiclist(currenttrack - 1).ToString)

            currenttrack = currenttrack - 1
        End If


    End Sub

#End Region

#Region "XMB-Video-Browsing"

    Public Sub LoadVideos()

        On Error Resume Next

        Dim videofiles() As String = getFiles(Functions.INI_ReadValueFromFile("Paths", "VideoPath", "", ".\media\paths.ini"), "*.avi|*.wmv|*.mp4|*.mpg|*.mpeg|*.mkv", SearchOption.AllDirectories)

        For Each Vids As String In videofiles
            videolist.Add(Vids)
        Next

        SelectedVid.Image = Image.FromFile(Thumbnail(videolist(0).ToString))
        SelectedVidText.Text = Path.GetFileNameWithoutExtension(videolist(0).ToString)
        SelectedVid.Tag = videolist(0).ToString

        Vid1.Image = Image.FromFile(Thumbnail(videolist(1).ToString))
        Vid1Text.Text = Path.GetFileNameWithoutExtension(videolist(1).ToString)
        Vid1.Tag = videolist(1).ToString

        Vid2.Image = Image.FromFile(Thumbnail(videolist(2).ToString))
        Vid2Text.Text = Path.GetFileNameWithoutExtension(videolist(2).ToString)
        Vid2.Tag = videolist(2).ToString

        Vid3.Image = Image.FromFile(Thumbnail(videolist(3).ToString))
        Vid3Text.Text = Path.GetFileNameWithoutExtension(videolist(3).ToString)
        Vid3.Tag = videolist(3).ToString

        currentvideos = 3

    End Sub

    Private Sub BrowseNextVideos()

        On Error Resume Next

        If secondtime = True Then
            OldVid2.Visible = True
            OldVid2Text.Visible = True

            OldVid2.Tag = OldVid1.Tag
            OldVid2Text.Text = OldVid1Text.Text
            OldVid2.Image = OldVid1.Image
        End If

        OldVid1.Visible = True
        OldVid1Text.Visible = True

        OldVid1.Tag = SelectedVid.Tag
        OldVid1Text.Text = SelectedVidText.Text
        OldVid1.Image = SelectedVid.Image

        SelectedVid.Tag = Vid1.Tag
        SelectedVidText.Text = Vid1Text.Text
        SelectedVid.Image = Vid1.Image

        Vid1.Tag = Vid2.Tag
        Vid1Text.Text = Vid2Text.Text
        Vid1.Image = Vid2.Image

        Vid2.Tag = Vid3.Tag
        Vid2Text.Text = Vid3Text.Text
        Vid2.Image = Vid3.Image

        If musiclist(currentvideos + 1) = "" Then
            Vid3.Tag = videolist(0).ToString
            Vid3Text.Text = Path.GetFileNameWithoutExtension(videolist(0).ToString)
            Vid3.Image = Image.FromFile(Thumbnail(videolist(0).ToString))

            currentvideos = 0
        Else
            Vid3.Tag = videolist(currentvideos + 1).ToString
            Vid3Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos + 1).ToString)
            Vid3.Image = Image.FromFile(Thumbnail(videolist(currentvideos + 1).ToString))

            currentvideos = currentvideos + 1
        End If

        If Not secondtime = True Then
            secondtime = True
        End If

    End Sub

    Private Sub BrowseLastVideos()

        On Error Resume Next

        Vid3.Tag = Vid2.Tag
        Vid3Text.Text = Vid2Text.Text
        Vid3.Image = Vid2.Image

        Vid2.Tag = Vid1.Tag
        Vid2Text.Text = Vid1Text.Text
        Vid2.Image = Vid1.Image

        Vid1.Tag = SelectedVid.Tag
        Vid1Text.Text = SelectedVidText.Text
        Vid1.Image = SelectedVid.Image

        SelectedVid.Tag = OldVid1.Tag
        SelectedVidText.Text = OldVid1Text.Text
        SelectedVid.Image = OldVid1.Image

        OldVid1.Tag = OldVid2.Tag
        OldVid1Text.Text = OldVid2Text.Text
        OldVid1.Image = OldVid2.Image

        If musiclist(currentvideos - 1) = "" Then
            OldVid2.Visible = False
            OldVid2Text.Visible = False

            OldVid1.Tag = videolist(0).ToString
            OldVid1Text.Text = Path.GetFileNameWithoutExtension(videolist(0).ToString)
            OldVid1.Image = Image.FromFile(Thumbnail(videolist(0).ToString))

            currentvideos = 0
        Else
            OldVid2.Tag = videolist(currentvideos - 1).ToString
            OldVid2Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos - 1).ToString)
            OldVid2.Image = Image.FromFile(Thumbnail(videolist(currentvideos - 1).ToString))

            currentvideos = currentvideos - 1
        End If

    End Sub

    Private Sub HideVideos()
        SelectedVid.Visible = False
        Vid1.Visible = False
        Vid2.Visible = False
        Vid3.Visible = False
        YoutubeBox.Visible = False
        OldVid1.Visible = False
        OldVid2.Visible = False

        SelectedVidText.Visible = False
        Vid1Text.Visible = False
        Vid2Text.Visible = False
        Vid3Text.Visible = False
        YoutubeTxt.Visible = False
        OldVid1Text.Visible = False
        OldVid2Text.Visible = False

        currentcategory = "xmb"
    End Sub

#End Region

#Region "XMB-Pictures-Browsing"

    Public Sub LoadPictures()

        On Error Resume Next

        Dim picturefiles() As String = getFiles(Functions.INI_ReadValueFromFile("Paths", "PicturesPath", "", ".\media\paths.ini"), "*.jpg|*.jpeg|*.png|*.gif", SearchOption.AllDirectories)

        For Each Pics As String In picturefiles
            picturelist.Add(Pics)
        Next

        SelectedPicture.Image = Image.FromFile(picturelist(0).ToString)
        SelectedPictureName.Text = Path.GetFileNameWithoutExtension(picturelist(0).ToString)
        SelectedPicture.Tag = picturelist(0).ToString + ";0"

        Picture1.Image = Image.FromFile(picturelist(1).ToString)
        Picture1Text.Text = Path.GetFileNameWithoutExtension(picturelist(1).ToString)
        Picture1.Tag = picturelist(1).ToString + ";1"

        Picture2.Image = Image.FromFile(picturelist(2).ToString)
        Picture2Text.Text = Path.GetFileNameWithoutExtension(picturelist(2).ToString)
        Picture2.Tag = picturelist(2).ToString + ";2"

        Picture3.Image = Image.FromFile(picturelist(3).ToString)
        Picture3Text.Text = Path.GetFileNameWithoutExtension(picturelist(3).ToString)
        Picture3.Tag = picturelist(3).ToString + ";3"

        currentpictures = 3

    End Sub

    Private Sub BrowseNextPictures()

        On Error Resume Next

        If secondtime = True Then
            OldPicture2.Visible = True
            OldPicture2Text.Visible = True

            OldPicture2.Tag = OldPicture1.Tag
            OldPicture2Text.Text = OldPicture1Text.Text
            OldPicture2.Image = OldPicture1.Image
        End If

        OldPicture1.Visible = True
        OldPicture1Text.Visible = True

        OldPicture1.Tag = SelectedPicture.Tag
        OldPicture1Text.Text = SelectedPictureName.Text
        OldPicture1.Image = SelectedPicture.Image

        SelectedPicture.Tag = Picture1.Tag
        SelectedPictureName.Text = Picture1Text.Text
        SelectedPicture.Image = Picture1.Image

        Picture1.Tag = Picture2.Tag
        Picture1Text.Text = Picture2Text.Text
        Picture1.Image = Picture2.Image

        Picture2.Tag = Picture3.Tag
        Picture2Text.Text = Picture3Text.Text
        Picture2.Image = Picture3.Image

        If musiclist(currentpictures + 1) = "" Then
            Picture3.Tag = picturelist(0).ToString + ";" + (0).ToString
            Picture3Text.Text = Path.GetFileNameWithoutExtension(picturelist(0).ToString)
            Picture3.Image = Image.FromFile(picturelist(0).ToString)

            currentpictures = 0
        Else
            Picture3.Tag = picturelist(currentpictures + 1).ToString + ";" + (currentpictures + 1).ToString
            Picture3Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures + 1).ToString)
            Picture3.Image = Image.FromFile(picturelist(currentpictures + 1).ToString)

            currentpictures = currentpictures + 1
        End If

        If Not secondtime = True Then
            secondtime = True
        End If

    End Sub

    Private Sub BrowseLastPictures()

        On Error Resume Next

        Picture3.Tag = Picture2.Tag
        Picture3Text.Text = Picture2Text.Text
        Picture3.Image = Picture2.Image

        Picture2.Tag = Picture1.Tag
        Picture2Text.Text = Picture1Text.Text
        Picture2.Image = Picture1.Image

        Picture1.Tag = SelectedPicture.Tag
        Picture1Text.Text = SelectedPictureName.Text
        Picture1.Image = SelectedPicture.Image

        SelectedPicture.Tag = OldPicture1.Tag
        SelectedPictureName.Text = OldPicture1Text.Text
        SelectedPicture.Image = OldPicture1.Image

        OldPicture1.Tag = OldPicture2.Tag
        OldPicture1Text.Text = OldPicture2Text.Text
        OldPicture1.Image = OldPicture2.Image

        If musiclist(currentpictures - 1) = "" Then
            OldPicture2.Visible = False
            OldPicture2Text.Visible = False

            OldPicture1.Tag = picturelist(0).ToString + ";" + (0).ToString
            OldPicture1Text.Text = Path.GetFileNameWithoutExtension(picturelist(0).ToString)
            OldPicture1.Image = Image.FromFile(picturelist(0).ToString)

            currentpictures = 0
        Else
            OldPicture2.Tag = picturelist(currentpictures - 1).ToString + ";" + (currentpictures - 1).ToString
            OldPicture2Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures - 1).ToString)
            OldPicture2.Image = Image.FromFile(picturelist(currentpictures - 1).ToString)

            currentpictures = currentpictures - 1
        End If

    End Sub

    Private Sub HidePictures()
        SelectedPicture.Visible = False
        Picture1.Visible = False
        Picture2.Visible = False
        Picture3.Visible = False
        OldPicture1.Visible = False
        OldPicture2.Visible = False

        SelectedPictureName.Visible = False
        Picture1Text.Visible = False
        Picture2Text.Visible = False
        Picture3Text.Visible = False
        OldPicture1Text.Visible = False
        OldPicture2Text.Visible = False

        currentcategory = "xmb"
    End Sub

#End Region

#Region "XMB-Settings-Browsing"

    Private Sub SettingsTheme_GotFocus(sender As Object, e As EventArgs) Handles SettingsTheme.GotFocus
        DropShadowOfText(SettingsThemeText)

        If Not themechanged = True Then
            SettingsTheme.Image = My.Resources.settings_theme_hover
        End If
    End Sub

    Private Sub SettingsTheme_LostFocus(sender As Object, e As EventArgs) Handles SettingsTheme.LostFocus
        DropShadowOfText(SettingsThemeText)

        If Not themechanged = True Then
            SettingsTheme.Image = My.Resources.settings_theme
        End If
    End Sub

    Private Sub SettingsUpdate_GotFocus(sender As Object, e As EventArgs) Handles SettingsUpdate.GotFocus
        DropShadowOfText(SettingsUpdateText)

        If Not themechanged = True Then
            SettingsUpdate.Image = My.Resources.update_icon_h
        End If
    End Sub

    Private Sub SettingsUpdate_LostFocus(sender As Object, e As EventArgs) Handles SettingsUpdate.LostFocus
        DropShadowOfText(SettingsUpdateText)

        If Not themechanged = True Then
            SettingsUpdate.Image = My.Resources.update_icon
        End If
    End Sub

    Private Sub HideSettings()
        SettingsTheme.Top = 400
        SettingsThemeText.Top = 415
        SettingsUpdate.Top = 500
        SettingsUpdateText.Top = 515

        SettingsTheme.Visible = False
        SettingsUpdate.Visible = False
        SettingsThemeText.Visible = False
        SettingsUpdateText.Visible = False
        currentcategory = "xmb"
    End Sub

    Private Sub ControlSettingsBottom()
        If Settings.Focused = True Then
            Me.ActiveControl = SettingsTheme
        ElseIf SettingsTheme.Focused = True Then
            Me.ActiveControl = SettingsUpdate

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))
            transition.add(SettingsTheme, "Top", 200)
            transition.add(SettingsThemeText, "Top", 215)
            transition.add(SettingsUpdate, "Top", 400)
            transition.add(SettingsUpdateText, "Top", 415)

            transition.run()
        ElseIf SettingsUpdate.Focused = True Then
            Me.ActiveControl = Settings

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))
            transition.add(SettingsTheme, "Top", 400)
            transition.add(SettingsThemeText, "Top", 415)
            transition.add(SettingsUpdate, "Top", 500)
            transition.add(SettingsUpdateText, "Top", 515)

            transition.run()

            currentcategory = "xmb"
        End If
    End Sub

    Private Sub ControlSettingsTop()
        If Settings.Focused = True Then
            Me.ActiveControl = SettingsUpdate

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))
            transition.add(SettingsTheme, "Top", 200)
            transition.add(SettingsThemeText, "Top", 215)
            transition.add(SettingsUpdate, "Top", 400)
            transition.add(SettingsUpdateText, "Top", 415)

            transition.run()
        ElseIf SettingsUpdate.Focused = True Then
            Me.ActiveControl = SettingsTheme

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))
            transition.add(SettingsTheme, "Top", 400)
            transition.add(SettingsThemeText, "Top", 415)
            transition.add(SettingsUpdate, "Top", 500)
            transition.add(SettingsUpdateText, "Top", 515)

            transition.run()
        ElseIf SettingsTheme.Focused = True Then
            Me.ActiveControl = Settings
            currentcategory = "xmb"
        End If
    End Sub

#End Region

    Private Sub XMB_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        StartUpHook.Close()
    End Sub

    Private Sub XMB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1920, 1080)
        ClientSize = New Size(1920, 1080)
        Me.WindowState = FormWindowState.Maximized

        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

        If Not Functions.INI_ReadValueFromFile("System", "Background", "", ".\system\sys.ini") = "Standard" Then
            If Functions.INI_ReadValueFromFile("System", "Background", "", ".\system\sys.ini") = "" Then
                Functions.INI_WriteValueToFile("System", "Background", "Standard", ".\system\sys.ini")
            Else
                Me.BackgroundImage = Image.FromFile(Functions.INI_ReadValueFromFile("System", "Background", "", ".\system\sys.ini"))
            End If
        End If

        If info.Count = 0 Then
            KeyboardTimer.Start()
        Else
            joy = New Joystick(0)
            ControllerInputTimer.Start()
        End If

        TimeClocker.Start()
        MeUserName.Text = Functions.INI_ReadValueFromFile("UserDetails", "Username", "", ".\users\user1.ini")

        LoadGames()
        LoadMusic()
        LoadVideos()
        LoadPictures()

        If Not LangLoader.INI_ReadValueFromFile("System", "Language", "", ".\system\sys.ini") = "English" Then
            LangLoader.ChangeLanguage()
        End If

        NotificationTxt.Parent = NotificationBox
        NotificationTxt2.Parent = NotificationBox
        NotificationIco.Parent = NotificationBox

        Me.ActiveControl = Home

        '_Time.Begin()
    End Sub

    Public Sub CallPSButton()
        If Me.Controls.Contains(PS_Button_Background) = True Then
            Me.Controls.Remove(PS_Button_Background)
            Me.Controls.Remove(PS_Button_Controls)

            Me.BringToFront()
            Me.Focus()
            Me.ActiveControl = Home

            If currentgamestate = "game1" Then
                Try
                    AppActivate(Game1Start.Id)
                Catch ex As Exception
                End Try
            ElseIf currentgamestate = "game2" Then
                Try
                    AppActivate(Game2Start.Id)
                Catch ex As Exception
                End Try
            ElseIf currentgamestate = "ps2" Then
                Try
                    AppActivate(PS2GameStart.Id)
                Catch ex As Exception
                End Try
            ElseIf currentgamestate = "ps1" Then
                Try
                    AppActivate(PS1GameStart.Id)
                Catch ex As Exception
                End Try
            ElseIf currentgamestate = "retro" Then
                Try
                    AppActivate(RetroGameStart.Id)
                Catch ex As Exception
                End Try
            End If

        Else
            PS_Button_Background.BackColor = Color.Transparent
            PS_Button_Background.Image = My.Resources.psbg
            PS_Button_Background.Size = Me.Size
            PS_Button_Background.BackgroundImageLayout = ImageLayout.Stretch
            PS_Button_Background.SizeMode = PictureBoxSizeMode.StretchImage

            Me.Controls.Add(PS_Button_Background)
            Me.Controls.Add(PS_Button_Controls)

            PS_Button_Background.BringToFront()
            PS_Button_Controls.Parent = PS_Button_Background

            PS_Button_Controls.Location = New Point(800, 400)
            PS_Button_Controls.BringToFront()

            Dim myProcess As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess()
            AppActivate(myProcess.Id)

            Me.BringToFront()
            PS_Button_Controls.Focus()
            Me.ActiveControl = PS_Button_Controls.quitgame

        End If
    End Sub

    Public Shared Function GenerateArchitecture()
        If Registry.LocalMachine.OpenSubKey("Hardware\Description\System\CentralProcessor\0").GetValue("Identifier").ToString.Contains("x86") Then
            Return "32"
        Else
            Return "64"
        End If
    End Function

    Private Sub MediaPlayer_PlayStateChange1(NewState As Integer) Handles MediaPlayer.PlayStateChange

        If NewState = MediaPlayer.playState.wmppsMediaEnded Then

            If GenerateArchitecture() = "32" Then
                StartGame(GameSect, GameID, GameFormat)
            Else
                StartGame_x64(GameSect, GameID, GameFormat)
            End If

            Me.Controls.Remove(MediaPlayer)
            Me.ActiveControl = Home
        End If

    End Sub

    Private Sub RadioPlayer_PlayStateChange(NewState As Integer) Handles RadioPlayer.PlayStateChange
        If NewState = MediaPlayer.playState.wmppsPlaying Then
            CurrentRadioState = "Playing"
            MediaPlayer.settings.volume = 100
        ElseIf NewState = MediaPlayer.playState.wmppsStopped Then
            CurrentRadioState = "Stopped"
        End If
    End Sub

    Private Sub SelectedGame_GotFocus(sender As Object, e As EventArgs) Handles SelectedGame.GotFocus
        Games.Size = New Size(105, 105)
        GamesTxt.Visible = True
        GamesTxt.GlowState = True
    End Sub

    Private Sub SelectedGame_LostFocus(sender As Object, e As EventArgs) Handles SelectedGame.LostFocus
        Games.Size = New Size(96, 96)
        GamesTxt.Visible = False
        GamesTxt.GlowState = False
    End Sub

    Private Sub SelectedTrack_GotFocus(sender As Object, e As EventArgs) Handles SelectedTrack.GotFocus
        DropShadowOfText(SelectedTrackName)

        Musics.Size = New Size(105, 105)
        MusicTxt.Visible = True
        MusicTxt.GlowState = True
    End Sub

    Private Sub SelectedTrack_LostFocus(sender As Object, e As EventArgs) Handles SelectedTrack.LostFocus
        DropShadowOfText(SelectedTrackName)

        Musics.Size = New Size(96, 96)
        MusicTxt.Visible = False
        MusicTxt.GlowState = False
    End Sub

    Private Sub SelectedVid_GotFocus(sender As Object, e As EventArgs) Handles SelectedVid.GotFocus
        DropShadowOfText(SelectedVidText)

        Videos.Size = New Size(105, 105)
        VideosTxt.Visible = True
        VideosTxt.GlowState = True
    End Sub

    Private Sub SelectedVid_LostFocus(sender As Object, e As EventArgs) Handles SelectedVid.LostFocus
        DropShadowOfText(SelectedVidText)

        Videos.Size = New Size(96, 96)
        VideosTxt.Visible = False
        VideosTxt.GlowState = False
    End Sub

    Private Sub SelectedPicture_GotFocus(sender As Object, e As EventArgs) Handles SelectedPicture.GotFocus
        DropShadowOfText(SelectedPictureName)

        Pictures.Size = New Size(105, 105)
        PhotosTxt.Visible = True
        PhotosTxt.GlowState = True
    End Sub

    Private Sub SelectedPicture_LostFocus(sender As Object, e As EventArgs) Handles SelectedPicture.LostFocus
        DropShadowOfText(SelectedPictureName)

        Pictures.Size = New Size(96, 96)
        PhotosTxt.Visible = False
        PhotosTxt.GlowState = False
    End Sub

    Private Sub BGTimer_Tick(sender As Object, e As EventArgs) Handles BGTimer.Tick

    End Sub
End Class
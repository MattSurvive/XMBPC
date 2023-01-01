Imports System.IO
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports Microsoft.Win32
Imports HundredMilesSoftware.UltraID3Lib
Imports DiscUtils.Iso9660
Imports System.Text
Imports System.Net
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Data
Imports AForge.Controls
Imports Transitions
Imports AxWMPLib

Public Class XMB

    Dim info As List(Of Joystick.DeviceInfo) = Joystick.GetAvailableDevices
    Dim joy As New Joystick

    Public WithEvents MediaPlayer As New AxWindowsMediaPlayer()

    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Long) As Integer

    Dim PS_Button_Background As New PictureBox
    Dim PS_Button_Controls As New PSMenu

    Public currentcategory As String
    Public currentxmbstate As String
    Public currentgamestate As String = ""
    Public currentvideostate As String = "unloaded"
    Public currentnetworkstate As String = "offline"
    Public themechanged As Boolean = False
    Public themepath As String

    Public currenttrack As Integer
    Public currentvideos As Integer
    Public currentgames As Integer
    Public currentps2games As Integer
    Public currentretrogames As Integer
    Public currentpictures As Integer

    Public musiclist As New List(Of String)
    Public videolist As New List(Of String)
    Public picturelist As New List(Of String)
    Public gameslist As New List(Of String)
    Public ps2gameslist As New List(Of String)
    Public retrogameslist As New List(Of String)
    Public friendslist As New List(Of String)

    Public CurrentMusicTrack As String
    Public CurrentVideoTrack As String
    Public CurrentPictureTrack As String
    Public CurrentGameDisc As String

    Public GameSect As String
    Public GameID As Integer
    Public GameFormat As String

    Public WithEvents Game1Start As New System.Diagnostics.Process()
    Public WithEvents Game2Start As New System.Diagnostics.Process()
    Public WithEvents PS2GameStart As New System.Diagnostics.Process()
    Public WithEvents PS1GameStart As New System.Diagnostics.Process()
    Public WithEvents PSPGameStart As New System.Diagnostics.Process()
    Public WithEvents RetroGameStart As New System.Diagnostics.Process()

#Region "WINDOWS DECLARATIONS"

    Private Declare Function RegisterHotKey Lib "user32" (ByVal hWnd As IntPtr, ByVal id As Integer, ByVal fsModifier As Integer, ByVal vk As Integer) As Integer
    Private Declare Sub UnregisterHotKey Lib "user32" (ByVal hWnd As IntPtr, ByVal id As Integer)
    Private Const Key_NONE As Integer = &H0
    Private Const WM_HOTKEY As Integer = &H312
    Declare Auto Function FindWindow Lib "User32.dll" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Declare Auto Function SetForeGroundWindow Lib "User32.dll" (ByVal Hwnd As IntPtr) As Long
    Declare Function s Lib "winmm.dll" Alias "mciSendStringA" (ByVal ab As String, ByVal ass As String, ByVal s As Integer, ByVal aas As Integer) As Integer
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
                                    DiscGame.Tag = drive.ToString()

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

                                Else

                                    DiscGameName.Text = GetGameNameOfDisc(drive.ToString())
                                    GetLogoOfDisc(0)

                                    Me.ActiveControl = Games
                                    currentcategory = "games"

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
                        DiscGame.Image = My.Resources.disc_nameless
                        DiscGameName.Text = "No disc inserted"
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
                DiscGame.Image = DropShadowOfImage(seldrive + "logo.png")
            ElseIf File.Exists(seldrive + "Splash.bmp") Then
                DiscGame.Image = DropShadowOfImage(seldrive + "Splash.bmp")
            End If
        Else
            DiscGame.Image = GetGameCover(GameTitle)
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

    Private Sub Game1Start_Exited(sender As Object, e As EventArgs) Handles Game1Start.Exited
        currentgamestate = ""
    End Sub

    Private Sub Game2Start_Exited(sender As Object, e As EventArgs) Handles Game2Start.Exited
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
                DiscGameName.Text = "PS2 Game Disc"
            Else
                DiscGameName.Text = GetTitle("http://www.sonyindex.com/Pages/" + Game_ID + ".htm").Replace("[", "").Replace("]", "").Replace("PAL-Unk", "").Replace("NTSC-U", "").Replace(Game_ID, "").Replace("PAL-G", "").Replace("NTSC-J", "").Replace("NTSC-Unk", "").Replace("PAL-Unk", "").Replace("PAL-M5", "")
            End If

            Dim GameRegionAndID As String() = Game_ID.Split("-")

            If CheckAddress("http://spiffycovers.com/images/thumbs/ps2/" + GameRegionAndID(0) + "/" + GameRegionAndID(1) + ".png") = True Then
                DiscGame.ImageLocation = "http://spiffycovers.com/images/thumbs/ps2/" + GameRegionAndID(0) + "/" + GameRegionAndID(1) + ".png"
            Else
                DiscGame.Image = My.Resources.ps2disc
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
                DiscGameName.Text = "PS1 Game Disc"
            Else
                DiscGameName.Text = GetTitle("http://www.sonyindex.com/Pages/" + Game_ID + ".htm").Replace("[", "").Replace("]", "").Replace("PAL-Unk", "").Replace("NTSC-U", "").Replace(Game_ID, "").Replace("PAL-G", "").Replace("NTSC-J", "").Replace("NTSC-Unk", "").Replace("PAL-Unk", "").Replace("PAL-M5", "")
            End If

            Dim GameRegionAndID As String() = Game_ID.Split("-")

            If CheckAddress("http://spiffycovers.com/images/thumbs/ps1/" + GameRegionAndID(0) + "/" + GameRegionAndID(1) + ".png") = True Then
                DiscGame.ImageLocation = "http://spiffycovers.com/images/thumbs/ps1/" + GameRegionAndID(0) + "/" + GameRegionAndID(1) + ".png"
            Else
                DiscGame.Image = My.Resources.ps1disc
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

    Private Sub CheckPSPGame(ByVal GameP As String)



    End Sub

    Private Sub SwitchPCSXPlugin(ByVal SwitchTo As String)
        Try

            If Not Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\PCSX2") Then
                MsgBox("You need to configure PS2Loader first.", MsgBoxStyle.OkOnly, "PCSX2 not configured")
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
        MediaPlayer.URL = My.Computer.FileSystem.CurrentDirectory + "\media\gamestart.avi"
        MediaPlayer.stretchToFit = True
        MediaPlayer.settings.volume = 50
    End Sub

    Public Sub StartGame(ByVal Section As String, ByVal ID As Integer, ByVal Format As String)

        If Section = "PC" And ID = 1 And Format = "EXE" Then
            Game1Start.StartInfo.FileName = Game1.Tag
            Game1Start.Start()
        ElseIf Section = "PC" And ID = 2 And Format = "EXE" Then
            Game2Start.StartInfo.FileName = Game2.Tag
            Game2Start.Start()

        ElseIf Section = "PS" And ID = 1 And Format = "ISO" Then
            PS2GameStart.StartInfo.FileName = ".\system\ps2loader\pcsx2-r5350.exe"
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

        ElseIf Section = "PS" And ID = 2 And Format = "ISO" Then
            PS2GameStart.StartInfo.FileName = ".\system\ps2loader\pcsx2-r5350.exe"
            PS2GameStart.StartInfo.Arguments = """" + PS2Game2.Tag + """"
            PS2GameStart.Start()
        ElseIf Section = "PS" And ID = 2 And Format = "CSO" Then
            PSPGameStart.StartInfo.FileName = ".\system\psploader\PPSSPPWindows.exe"
            PSPGameStart.StartInfo.Arguments = """" + PS2Game2.Tag + """"
            PSPGameStart.Start()
        ElseIf Section = "PS" And ID = 2 And Format = "BIN" Then
            PS1GameStart.StartInfo.FileName = ".\system\ps1loader\ePSXe.exe"
            PS1GameStart.StartInfo.Arguments = "-nogui -bios """ + My.Computer.FileSystem.CurrentDirectory + "\system\ps1loader\bios\SCPH1001.BIN"" " + "-loadbin " + """" + PS2Game2.Tag + """"
            PS1GameStart.Start()

        ElseIf Section = "PS" And ID = 3 And Format = "ISO" Then
            PS2GameStart.StartInfo.FileName = ".\system\ps2loader\pcsx2-r5350.exe"
            PS2GameStart.StartInfo.Arguments = """" + PS2Game3.Tag + """"
            PS2GameStart.Start()
        ElseIf Section = "PS" And ID = 3 And Format = "CSO" Then
            PSPGameStart.StartInfo.FileName = ".\system\psploader\PPSSPPWindows.exe"
            PSPGameStart.StartInfo.Arguments = """" + PS2Game3.Tag + """"
            PSPGameStart.Start()
        ElseIf Section = "PS" And ID = 3 And Format = "BIN" Then
            PS1GameStart.StartInfo.FileName = ".\system\ps1loader\ePSXe.exe"
            PS1GameStart.StartInfo.Arguments = "-nogui -bios """ + My.Computer.FileSystem.CurrentDirectory + "\system\ps1loader\bios\SCPH1001.BIN"" " + "-loadbin " + """" + PS2Game3.Tag + """"
            PS1GameStart.Start()

        ElseIf Section = "DISC" And ID = 1 And Format = "PS2" Then
            PS2GameStart.StartInfo.FileName = ".\system\ps2loader\pcsx2-r5350.exe"
            PS2GameStart.StartInfo.Arguments = DiscGame.Tag
            PS2GameStart.Start()
        ElseIf Section = "DISC" And ID = 1 And Format = "PSX" Then
            PS1GameStart.StartInfo.FileName = ".\system\ps1loader\ePSXe.exe"
            PS1GameStart.StartInfo.Arguments = "-nogui -bios """ + My.Computer.FileSystem.CurrentDirectory + "\system\ps1loader\bios\SCPH1001.BIN"""
            PS1GameStart.Start()

        ElseIf Section = "RETRO" And ID = 1 And Format = "GBA" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\gba.dll """ + RetroGame1.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 1 And Format = "GBC" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\gbc.dll """ + RetroGame1.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 1 And Format = "SMC" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\snes.dll """ + RetroGame1.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 1 And Format = "SMD" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\sega.dll """ + RetroGame1.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 1 And Format = "NES" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\nes.dll """ + RetroGame1.Tag + """"
            RetroGameStart.Start()

        ElseIf Section = "RETRO" And ID = 2 And Format = "GBA" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\gba.dll """ + RetroGame2.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 2 And Format = "GBC" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\gbc.dll """ + RetroGame2.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 2 And Format = "SMC" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\snes.dll """ + RetroGame2.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 2 And Format = "SMD" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\sega.dll """ + RetroGame2.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 2 And Format = "NES" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\nes.dll """ + RetroGame2.Tag + """"
            RetroGameStart.Start()

        ElseIf Section = "RETRO" And ID = 3 And Format = "GBA" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\gba.dll """ + RetroGame3.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 3 And Format = "GBC" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\gbc.dll """ + RetroGame3.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 3 And Format = "SMC" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\snes.dll """ + RetroGame3.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 3 And Format = "SMD" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\sega.dll """ + RetroGame3.Tag + """"
            RetroGameStart.Start()
        ElseIf Section = "RETRO" And ID = 3 And Format = "NES" Then
            RetroGameStart.StartInfo.FileName = ".\system\retroloader\retroarch.exe"
            RetroGameStart.StartInfo.Arguments = "-L .\system\retroloader\libs\nes.dll """ + RetroGame3.Tag + """"
            RetroGameStart.Start()
        End If

    End Sub

#End Region

#Region "XMBPC NETWORK"

    Private Sub AddNetworkFriend(ByVal FRN As String)

        friendslist.Clear()

        Dim conn As MySqlConnection
        conn = New MySqlConnection
        conn.ConnectionString = "server=85.31.189.150;user id=psmultitools;password=12345PSMultiTools12345;database=xmbpc"

        Try
            conn.Open()
        Catch myerror As MySqlException
            MsgBox("Could not connect to server: " & myerror.Message.ToString)
        End Try

        Dim benutzer As String = MD5StringHash(UserLoginName.Text)

        Dim myAdapter As New MySqlDataAdapter
        Dim SQLAbfrage As String = "UPDATE `users` SET `Friends` =CONCAT(`Friends`,';" + FRN + "') WHERE Username='" + Replace(benutzer, " ", "") + "' LIMIT 1"
        Dim myCommand As New MySqlCommand
        myCommand.Connection = conn
        myCommand.CommandText = SQLAbfrage

        myAdapter.SelectCommand = myCommand
        Dim myData As MySqlDataReader
        myData = myCommand.ExecuteReader()

        conn.Close()
        ClearFriends()
        ConnectToServer()

    End Sub

    Public Sub ConnectToServer()
        Dim conn As MySqlConnection
        conn = New MySqlConnection
        conn.ConnectionString = "server=85.31.189.150;user id=psmultitools;password=12345PSMultiTools12345;database=xmbpc"

        friendslist.Clear()
        ClearFriends()

        Try
            conn.Open()
        Catch myerror As MySqlException
            MsgBox("Could not connect to server: " & myerror.Message.ToString)
        End Try

        Dim benutzer As String = MD5StringHash(UserLoginName.Text)

        Dim myAdapter As New MySqlDataAdapter
        Dim SQLAbfrage As String = "SELECT * FROM users WHERE Username='" + Replace(benutzer, " ", "") + "'"
        Dim myCommand As New MySqlCommand
        myCommand.Connection = conn
        myCommand.CommandText = SQLAbfrage

        myAdapter.SelectCommand = myCommand
        Dim myData As MySqlDataReader
        myData = myCommand.ExecuteReader()

        If myData.HasRows Then

            While myData.Read()
                Dim myfriends As String()
                myfriends = myData("Friends").ToString.Split(";")

                friendslist.AddRange(myfriends)
            End While

            conn.Close()
            LoadFriends()

        Else
            MsgBox("Could not login to XMBPC Network, please check your username or password! Maybe you're console banned :P", MsgBoxStyle.Critical, "XMBPC Network")
        End If
    End Sub

    Public Sub LoadFriends()

        Dim friendscount As Integer = friendslist.Count

        If friendscount = 1 Then

            For Each frnds In friendslist.GetRange(0, 1)
                GetFriends(frnds)
            Next

        ElseIf friendscount = 2 Then

            For Each frnds In friendslist.GetRange(0, 2)
                GetFriends(frnds)
            Next

        ElseIf friendscount <= 3 Then

            For Each frnds In friendslist.GetRange(0, 3)
                GetFriends(frnds)
            Next

        End If

    End Sub

    Public Sub GetFriends(ByVal frnds As String)
        Dim conn As MySqlConnection
        conn = New MySqlConnection
        conn.ConnectionString = "server=85.31.189.150;user id=psmultitools;password=12345PSMultiTools12345;database=xmbpc"

        conn.Open()

        Dim benutzer As String = MD5StringHash(frnds)

        Dim myAdapter As New MySqlDataAdapter
        Dim SQLAbfrage As String = "SELECT * FROM users WHERE Username='" + Replace(benutzer, " ", "") + "'"
        Dim myCommand As New MySqlCommand

        myCommand.Connection = conn
        myCommand.CommandText = SQLAbfrage
        myAdapter.SelectCommand = myCommand

        Dim myData As MySqlDataReader
        myData = myCommand.ExecuteReader()

        If myData.HasRows Then

            While myData.Read()

                On Error Resume Next

                If Friend1Name.Text = "" Then

                    Friend1Name.Text = frnds
                    Friend1Status.Text = myData("LastActivity").ToString

                    Dim lb() As Byte = myData("Avatar")
                    Dim lstr As New MemoryStream(lb)

                    Friend1Ava.Image = Image.FromStream(lstr)

                ElseIf Friend2Name.Text = "" Then

                    Friend2Name.Text = frnds
                    Friend2Status.Text = myData("LastActivity").ToString

                    Dim lb() As Byte = myData("Avatar")
                    Dim lstr As New MemoryStream(lb)

                    Friend2Ava.Image = Image.FromStream(lstr)

                ElseIf Friend3Name.Text = "" Then

                    Friend3Name.Text = frnds
                    Friend3Status.Text = myData("LastActivity").ToString

                    Dim lb() As Byte = myData("Avatar")
                    Dim lstr As New MemoryStream(lb)

                    Friend3Ava.Image = Image.FromStream(lstr)

                End If

            End While

            conn.Close()

        Else
            MsgBox("Could not login to XMBPC Network, please check your username or password! Maybe you're console banned :P", MsgBoxStyle.Critical, "XMBPC Network")
        End If

    End Sub

    Private Sub ClearFriends()
        Friend1Ava.Image = Nothing
        Friend2Ava.Image = Nothing
        Friend3Ava.Image = Nothing

        Friend1Name.Text = ""
        Friend2Name.Text = ""
        Friend3Name.Text = ""

        Friend1Status.Text = ""
        Friend2Status.Text = ""
        Friend3Status.Text = ""
    End Sub

    Public Sub UpdateStatus(ByVal Stat As String)

        Dim conn As MySqlConnection
        conn = New MySqlConnection
        conn.ConnectionString = "server=85.31.189.150;user id=psmultitools;password=12345PSMultiTools12345;database=xmbpc"

        Try
            conn.Open()
        Catch myerror As MySqlException
            MsgBox("Could not connect to server: " & myerror.Message.ToString)
        End Try

        Dim benutzer As String = MD5StringHash(UserLoginName.Text)

        Dim myAdapter As New MySqlDataAdapter
        Dim SQLAbfrage As String = "UPDATE `users` SET `LastActivity`='" + Stat + "' WHERE Username='" + Replace(benutzer, " ", "") + "'"
        Dim myCommand As New MySqlCommand
        myCommand.Connection = conn
        myCommand.CommandText = SQLAbfrage

        myAdapter.SelectCommand = myCommand
        Dim myData As MySqlDataReader
        myData = myCommand.ExecuteReader()

        conn.Close()
        UserDescr.Text = Stat

    End Sub

    Private Sub ForceLogoff()

        If currentnetworkstate = "online" Then

            NetworkTimer.Stop()

            Dim conn As MySqlConnection
            conn = New MySqlConnection
            conn.ConnectionString = "server=85.31.189.150;user id=psmultitools;password=12345PSMultiTools12345;database=xmbpc"

            Try
                conn.Open()
            Catch myerror As MySqlException
                MsgBox("Could not connect to server: " & myerror.Message.ToString)
            End Try

            Dim benutzer As String = MD5StringHash(UserLoginName.Text)

            Dim myAdapter As New MySqlDataAdapter
            Dim SQLAbfrage As String = "UPDATE `users` SET `LastActivity`='Offline' WHERE Username='" + Replace(benutzer, " ", "") + "'"
            Dim myCommand As New MySqlCommand
            myCommand.Connection = conn
            myCommand.CommandText = SQLAbfrage

            myAdapter.SelectCommand = myCommand
            Dim myData As MySqlDataReader
            myData = myCommand.ExecuteReader()

            conn.Close()

        End If

    End Sub

    Private Sub UpdateAvatar()

        Dim conn As MySqlConnection
        Dim cmd As MySqlCommand

        conn = New MySqlConnection
        conn.ConnectionString = "server=85.31.189.150;user id=psmultitools;password=12345PSMultiTools12345;database=xmbpc"

        Dim benutzer As String = MD5StringHash("superfurry")
        Dim sql As String

        conn.Open()

        Dim CmdString As String = "UPDATE `users` SET `Avatar`='" + File.ReadAllBytes(".\default.png").ToString + "' WHERE Username='" + Replace(benutzer, " ", "") + "'"

        cmd = New MySqlCommand(CmdString, conn)
        cmd.ExecuteNonQuery()

        conn.Close()


    End Sub

#End Region

#Region "Timers"

    Private Sub TimeClocker_Tick(sender As Object, e As EventArgs) Handles TimeClocker.Tick
        TheTime.Text = Now.ToString
    End Sub

    Private Sub NetworkTimer_Tick(sender As Object, e As EventArgs) Handles NetworkTimer.Tick
        If currentnetworkstate = "online" Then
            ConnectToServer()
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

            If currentcategory = "games" Then
                ControlGamesBottom()
            ElseIf currentcategory = "ps2games" Then
                ControlPS2GamesBottom()
            ElseIf currentcategory = "retrogames" Then
                ControlRetroGamesBottom()
            ElseIf currentcategory = "users" Then
                ControlUsersBottom()
            ElseIf currentcategory = "music" Then
                ControlMusicBottom()
            ElseIf currentcategory = "videos" Then
                ControlVideosBottom()
            ElseIf currentcategory = "pictures" Then
                ControlPicturesBottom()
            ElseIf currentcategory = "settings" Then
                ControlSettingsBottom()
            ElseIf currentcategory = "friends" Then
                ControlFriendsBottom()
            ElseIf currentcategory = "network" Then
                ControlNetworkBottom()
            End If

        ElseIf status.YAxis = -1 Or GetAsyncKeyState(Keys.Up) Then
            ControlTop()

            If currentcategory = "games" Then
                ControlGamesTop()
            ElseIf currentcategory = "ps2games" Then
                ControlPS2GamesTop()
            ElseIf currentcategory = "retrogames" Then
                ControlRetroGamesTop()
            ElseIf currentcategory = "users" Then
                ControlUsersTop()
            ElseIf currentcategory = "music" Then
                ControlMusicTop()
            ElseIf currentcategory = "videos" Then
                ControlVideosTop()
            ElseIf currentcategory = "pictures" Then
                ControlPicturesTop()
            ElseIf currentcategory = "settings" Then
                ControlSettingsTop()
            ElseIf currentcategory = "friends" Then
                ControlFriendsTop()
            ElseIf currentcategory = "network" Then
                ControlNetworkTop()
            End If

        End If

        If BrowserBox.Focused Or Game1.Focused Or Game2.Focused Or DiscGame.Focused Or PS2Game1.Focused Or PS2Game2.Focused Or PS2Game3.Focused Or YoutubeBox.Focused Or StoreBox.Focused Then

            If Game1.Focused = True And Game1Text.Text.Contains("Install") Then
                AdviceIco.Image = My.Resources.cross1
                AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoInstall")
            ElseIf Game2.Focused = True And Game2Text.Text.Contains("Install") Then
                AdviceIco.Image = My.Resources.cross1
                AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoInstall")
            Else
                AdviceIco.Image = My.Resources.cross1
                AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoStart")
            End If

        ElseIf Track1.Focused Or Track2.Focused Or Track3.Focused Or Track4.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoListen")
        ElseIf Vid1.Focused Or Vid2.Focused Or Vid3.Focused Or Vid4.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoWatch")
        ElseIf Picture1.Focused Or Picture2.Focused Or Picture3.Focused Or Picture4.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoWatch")
        ElseIf MeUserIco.Focused Then
            'AdviceIco.Image = My.Resources.square
            'AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressSquareToEdit")

        ElseIf UserAvatar.Focused And currentnetworkstate = "offline" Then
            AdviceIco.Image = My.Resources.square
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressSquareToLogin")
        ElseIf UserAvatar.Focused And currentnetworkstate = "online" Then
            AdviceIco.Image = My.Resources.square
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressSquareToLogoff")
        ElseIf UserAvatar.Focused And currentnetworkstate = "online" Then

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

        If Game1.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or Game1.Focused And GetAsyncKeyState(Keys.Enter) Then
            If Game1Text.Text.Contains("Install") Then

                BackgroundDownload.Show()
                BackgroundDownload.pkgurl = Game1.Tag
            Else

                HideGames()
                Me.ActiveControl = Home

                GameSect = "PC"
                GameID = 1
                GameFormat = "EXE"

                PlayGameIntro()

                currentgamestate = "game1"
            End If
        ElseIf Game2.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or Game2.Focused And GetAsyncKeyState(Keys.Enter) Then
            If Game2Text.Text.Contains("Install") Then

                BackgroundDownload.Show()
                BackgroundDownload.pkgurl = Game2.Tag
            Else

                HideGames()
                Me.ActiveControl = Home

                GameSect = "PC"
                GameID = 2
                GameFormat = "EXE"

                PlayGameIntro()

                currentgamestate = "game2"
            End If

        ElseIf PS2Game1.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or PS2Game1.Focused And GetAsyncKeyState(Keys.Enter) Then
            If PS2Game1Text.Text.Contains("Install") Then

                BackgroundDownload.Show()
                BackgroundDownload.pkgurl = PS2Game1.Tag
            Else

                HideGames()
                Hideps2Games()
                Me.ActiveControl = Home

                Dim GameIF As New FileInfo(PS2Game1.Tag)

                If GameIF.Extension = ".iso" Then

                    SwitchPCSXPlugin("ISO")

                    GameSect = "PS"
                    GameID = 1
                    GameFormat = "ISO"

                    PlayGameIntro()

                    currentgamestate = "ps2"
                ElseIf GameIF.Extension = ".cso" Then

                    GameSect = "PS"
                    GameID = 1
                    GameFormat = "CSO"

                    PlayGameIntro()

                    currentgamestate = "psp"
                Else

                    GameSect = "PS"
                    GameID = 1
                    GameFormat = "BIN"

                    PlayGameIntro()

                    currentgamestate = "ps1"
                End If

            End If

        ElseIf PS2Game2.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or PS2Game2.Focused And GetAsyncKeyState(Keys.Enter) Then
            If PS2Game2Text.Text.Contains("Install") Then

                BackgroundDownload.Show()
                BackgroundDownload.pkgurl = PS2Game2.Tag
            Else

                HideGames()
                Hideps2Games()
                Me.ActiveControl = Home

                Dim GameIF As New FileInfo(PS2Game2.Tag)

                If GameIF.Extension = ".iso" Then
                    SwitchPCSXPlugin("ISO")
                    GameSect = "PS"
                    GameID = 2
                    GameFormat = "ISO"

                    PlayGameIntro()

                    currentgamestate = "ps2"
                ElseIf GameIF.Extension = ".cso" Then
                    GameSect = "PS"
                    GameID = 2
                    GameFormat = "CSO"

                    PlayGameIntro()

                    currentgamestate = "psp"
                Else
                    GameSect = "PS"
                    GameID = 2
                    GameFormat = "BIN"

                    PlayGameIntro()

                    currentgamestate = "ps1"
                End If

            End If

        ElseIf PS2Game3.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or PS2Game3.Focused And GetAsyncKeyState(Keys.Enter) Then
            If PS2Game3Text.Text.Contains("Install") Then

                BackgroundDownload.Show()
                BackgroundDownload.pkgurl = PS2Game3.Tag
            Else

                HideGames()
                Hideps2Games()
                Me.ActiveControl = Home

                Dim GameIF As New FileInfo(PS2Game3.Tag)

                If GameIF.Extension = ".iso" Then
                    SwitchPCSXPlugin("ISO")
                    GameSect = "PS"
                    GameID = 3
                    GameFormat = "ISO"

                    PlayGameIntro()

                    currentgamestate = "ps2"
                ElseIf GameIF.Extension = ".cso" Then
                    GameSect = "PS"
                    GameID = 3
                    GameFormat = "CSO"

                    PlayGameIntro()

                    currentgamestate = "psp"
                Else
                    GameSect = "PS"
                    GameID = 3
                    GameFormat = "BIN"

                    PlayGameIntro()

                    currentgamestate = "ps1"
                End If

            End If

        ElseIf RetroGame1.Focused And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or RetroGame1.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideGames()
            Hideps2Games()
            HideRetroGames()
            Me.ActiveControl = Home

            Dim GameIF As New FileInfo(RetroGame1.Tag)

            If GameIF.Extension = ".gba" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "GBA"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".gbc" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "GBC"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smc" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "SMC"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smd" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "SMD"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".nes" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "NES"

                PlayGameIntro()

                currentgamestate = "retro"
            End If

        ElseIf RetroGame2.Focused And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or RetroGame2.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideGames()
            Hideps2Games()
            HideRetroGames()
            Me.ActiveControl = Home

            Dim GameIF As New FileInfo(RetroGame2.Tag)

            If GameIF.Extension = ".gba" Then

                GameSect = "RETRO"
                GameID = 2
                GameFormat = "GBA"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".gbc" Then

                GameSect = "RETRO"
                GameID = 2
                GameFormat = "GBC"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smc" Then

                GameSect = "RETRO"
                GameID = 2
                GameFormat = "SMC"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smd" Then

                GameSect = "RETRO"
                GameID = 2
                GameFormat = "SMD"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".nes" Then

                GameSect = "RETRO"
                GameID = 2
                GameFormat = "NES"

                PlayGameIntro()

                currentgamestate = "retro"
            End If

        ElseIf RetroGame3.Focused And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or RetroGame3.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideGames()
            Hideps2Games()
            HideRetroGames()
            Me.ActiveControl = Home

            Dim GameIF As New FileInfo(RetroGame3.Tag)

            If GameIF.Extension = ".gba" Then

                GameSect = "RETRO"
                GameID = 3
                GameFormat = "GBA"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".gbc" Then

                GameSect = "RETRO"
                GameID = 3
                GameFormat = "GBC"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smc" Then

                GameSect = "RETRO"
                GameID = 3
                GameFormat = "SMC"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smd" Then

                GameSect = "RETRO"
                GameID = 3
                GameFormat = "SMD"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".nes" Then

                GameSect = "RETRO"
                GameID = 3
                GameFormat = "NES"

                PlayGameIntro()

                currentgamestate = "retro"
            End If

        ElseIf DiscGame.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or DiscGame.Focused And GetAsyncKeyState(Keys.Enter) Then

            If CurrentGameDisc = "PS2" Then

                HideGames()
                Hideps2Games()
                Me.ActiveControl = Home

                SwitchPCSXPlugin("Plugin")

                GameSect = "DISC"
                GameID = 1
                GameFormat = "PS2"

                PlayGameIntro()

                currentgamestate = "ps2"

            ElseIf CurrentGameDisc = "PS1" Then

                HideGames()
                Hideps2Games()
                Me.ActiveControl = Home

                GameSect = "DISC"
                GameID = 1
                GameFormat = "PSX"

                PlayGameIntro()

                currentgamestate = "ps1"

            End If

        ElseIf BrowserBox.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or BrowserBox.Focused And GetAsyncKeyState(Keys.Enter) Then

            Browser.Show()
            Browser.BringToFront()
            Browser.Activate()

            Me.Enabled = False
        ElseIf Track1.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or Track1.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideMusic()
            Me.ActiveControl = Home

            CurrentMusicTrack = Track1.Tag

            MusicPlayer.Show()
            MusicPlayer.BringToFront()

            Me.Enabled = False
        ElseIf Track2.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or Track2.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideMusic()
            Me.ActiveControl = Home

            CurrentMusicTrack = Track2.Tag

            MusicPlayer.Show()
            MusicPlayer.BringToFront()

            Me.Enabled = False
        ElseIf Track3.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or Track3.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideMusic()
            Me.ActiveControl = Home

            CurrentMusicTrack = Track3.Tag

            MusicPlayer.Show()
            MusicPlayer.BringToFront()

            Me.Enabled = False
        ElseIf Track4.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or Track4.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideMusic()
            Me.ActiveControl = Home

            CurrentMusicTrack = Track4.Tag

            MusicPlayer.Show()
            MusicPlayer.BringToFront()

            Me.Enabled = False

        ElseIf Vid1.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or Vid1.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideVideos()
            Me.ActiveControl = Home

            CurrentVideoTrack = Vid1.Tag

            VideoPlayer.Show()
            VideoPlayer.BringToFront()

            Me.Enabled = False
        ElseIf Vid2.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or Vid2.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideVideos()
            Me.ActiveControl = Home

            CurrentVideoTrack = Vid2.Tag

            VideoPlayer.Show()
            VideoPlayer.BringToFront()

            Me.Enabled = False
        ElseIf Vid3.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or Vid3.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideVideos()
            Me.ActiveControl = Home

            CurrentVideoTrack = Vid3.Tag

            VideoPlayer.Show()
            VideoPlayer.BringToFront()

            Me.Enabled = False
        ElseIf Vid4.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or Vid4.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideVideos()
            Me.ActiveControl = Home

            CurrentVideoTrack = Vid4.Tag

            VideoPlayer.Show()
            VideoPlayer.BringToFront()

            Me.Enabled = False

        ElseIf Picture1.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or Picture1.Focused And GetAsyncKeyState(Keys.Enter) Then

            HidePictures()
            Me.ActiveControl = Home

            CurrentPictureTrack = Picture1.Tag

            PictureViewer.Show()
            PictureViewer.BringToFront()

            Me.Enabled = False

        ElseIf Picture2.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or Picture2.Focused And GetAsyncKeyState(Keys.Enter) Then

            HidePictures()
            Me.ActiveControl = Home

            CurrentPictureTrack = Picture2.Tag

            PictureViewer.Show()
            PictureViewer.BringToFront()

            Me.Enabled = False

        ElseIf Picture3.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or Picture3.Focused And GetAsyncKeyState(Keys.Enter) Then

            HidePictures()
            Me.ActiveControl = Home

            CurrentPictureTrack = Picture3.Tag

            PictureViewer.Show()
            PictureViewer.BringToFront()

            Me.Enabled = False

        ElseIf Picture4.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or Picture4.Focused And GetAsyncKeyState(Keys.Enter) Then

            HidePictures()
            Me.ActiveControl = Home

            CurrentPictureTrack = Picture4.Tag

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

        ElseIf UserAvatar.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button4) = True Or UserAvatar.Focused And GetAsyncKeyState(Keys.Enter) Then

            If currentnetworkstate = "offline" Then
                MyPSLogin.Show()
                MyPSLogin.BringToFront()
            Else

                currentnetworkstate = "offline"
                NetworkTimer.Stop()

                ClearFriends()
                UserAvatar.Image = My.Resources.user
                UserLoginName.Text = "Not logged in"
                UserDescr.Text = "Please login first"

            End If

        ElseIf UserAvatar.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button1) = True Or UserAvatar.Focused And GetAsyncKeyState(Keys.U) Then

            If currentnetworkstate = "online" Then

                Dim newstatus As String = InputBox("Enter your new status:", "Update Status")
                UpdateStatus(newstatus)

            End If

        ElseIf AddFriend.Focused = True And status.IsButtonPressed(AForge.Controls.Joystick.Buttons.Button3) = True Or AddFriend.Focused And GetAsyncKeyState(Keys.Enter) Then

            If currentnetworkstate = "online" Then
                Dim friendname As String = InputBox("Enter the UserID of your friend:", "Add a friend")
                AddNetworkFriend(friendname)
            Else
                MsgBox(LangLoader.GetStringOfLang("XMB", "ErrorAddFriend"), MsgBoxStyle.Critical, "XMBPC Network ERROR #1")
            End If

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

            If MsgBox("Do you really want to exit XMBPC?", MsgBoxStyle.YesNo, "Shutdown XMBPC") = MsgBoxResult.Yes Then
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

            If currentcategory = "games" Then
                ControlGamesBottom()
            ElseIf currentcategory = "ps2games" Then
                ControlPS2GamesBottom()
            ElseIf currentcategory = "retrogames" Then
                ControlRetroGamesBottom()
            ElseIf currentcategory = "users" Then
                ControlUsersBottom()
            ElseIf currentcategory = "music" Then
                ControlMusicBottom()
            ElseIf currentcategory = "videos" Then
                ControlVideosBottom()
            ElseIf currentcategory = "pictures" Then
                ControlPicturesBottom()
            ElseIf currentcategory = "settings" Then
                ControlSettingsBottom()
            ElseIf currentcategory = "friends" Then
                ControlFriendsBottom()
            ElseIf currentcategory = "network" Then
                ControlNetworkBottom()
            End If

        ElseIf GetAsyncKeyState(Keys.Up) Then
            ControlTop()

            If currentcategory = "games" Then
                ControlGamesTop()
            ElseIf currentcategory = "ps2games" Then
                ControlPS2GamesTop()
            ElseIf currentcategory = "retrogames" Then
                ControlRetroGamesTop()
            ElseIf currentcategory = "users" Then
                ControlUsersTop()
            ElseIf currentcategory = "music" Then
                ControlMusicTop()
            ElseIf currentcategory = "videos" Then
                ControlVideosTop()
            ElseIf currentcategory = "pictures" Then
                ControlPicturesTop()
            ElseIf currentcategory = "settings" Then
                ControlSettingsTop()
            ElseIf currentcategory = "friends" Then
                ControlFriendsTop()
            ElseIf currentcategory = "network" Then
                ControlNetworkTop()
            End If

        End If

        If BrowserBox.Focused Or Game1.Focused Or Game2.Focused Or DiscGame.Focused Or PS2Game1.Focused Or PS2Game2.Focused Or PS2Game3.Focused Or YoutubeBox.Focused Or StoreBox.Focused Then

            If Game1.Focused = True And Game1Text.Text.Contains("Install") Then
                AdviceIco.Image = My.Resources.cross1
                AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoInstall")
            ElseIf Game2.Focused = True And Game2Text.Text.Contains("Install") Then
                AdviceIco.Image = My.Resources.cross1
                AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoInstall")
            Else
                AdviceIco.Image = My.Resources.cross1
                AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoStart")
            End If

        ElseIf Track1.Focused Or Track2.Focused Or Track3.Focused Or Track4.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoListen")
        ElseIf Vid1.Focused Or Vid2.Focused Or Vid3.Focused Or Vid4.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoWatch")
        ElseIf Picture1.Focused Or Picture2.Focused Or Picture3.Focused Or Picture4.Focused Then
            AdviceIco.Image = My.Resources.cross1
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressXtoWatch")
        ElseIf MeUserIco.Focused Then
            'AdviceIco.Image = My.Resources.square
            'AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressSquareToEdit")

        ElseIf UserAvatar.Focused And currentnetworkstate = "offline" Then
            AdviceIco.Image = My.Resources.square
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressSquareToLogin")
        ElseIf UserAvatar.Focused And currentnetworkstate = "online" Then
            AdviceIco.Image = My.Resources.square
            AdviceTxt.Text = LangLoader.GetStringOfLang("XMB", "PressSquareToLogoff")
        ElseIf UserAvatar.Focused And currentnetworkstate = "online" Then

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

        If Game1.Focused And GetAsyncKeyState(Keys.Enter) Then
            If Game1Text.Text.Contains("Install") Then

                BackgroundDownload.Show()
                BackgroundDownload.pkgurl = Game1.Tag
            Else

                HideGames()
                Me.ActiveControl = Home

                GameSect = "PC"
                GameID = 1
                GameFormat = "EXE"

                PlayGameIntro()

                currentgamestate = "game1"
            End If
        ElseIf Game2.Focused And GetAsyncKeyState(Keys.Enter) Then
            If Game2Text.Text.Contains("Install") Then

                BackgroundDownload.Show()
                BackgroundDownload.pkgurl = Game2.Tag
            Else

                HideGames()
                Me.ActiveControl = Home

                GameSect = "PC"
                GameID = 2
                GameFormat = "EXE"

                PlayGameIntro()

                currentgamestate = "game2"
            End If

        ElseIf PS2Game1.Focused And GetAsyncKeyState(Keys.Enter) Then
            If PS2Game1Text.Text.Contains("Install") Then

                BackgroundDownload.Show()
                BackgroundDownload.pkgurl = PS2Game1.Tag
            Else

                HideGames()
                Hideps2Games()
                Me.ActiveControl = Home

                Dim GameIF As New FileInfo(PS2Game1.Tag)

                If GameIF.Extension = ".iso" Then
                    SwitchPCSXPlugin("ISO")
                    GameSect = "PS"
                    GameID = 1
                    GameFormat = "ISO"

                    PlayGameIntro()

                    currentgamestate = "ps2"
                ElseIf GameIF.Extension = ".cso" Then
                    GameSect = "PS"
                    GameID = 1
                    GameFormat = "CSO"

                    PlayGameIntro()

                    currentgamestate = "psp"
                Else
                    GameSect = "PS"
                    GameID = 1
                    GameFormat = "BIN"

                    PlayGameIntro()

                    currentgamestate = "ps1"
                End If

            End If

        ElseIf PS2Game2.Focused And GetAsyncKeyState(Keys.Enter) Then
            If PS2Game2Text.Text.Contains("Install") Then

                BackgroundDownload.Show()
                BackgroundDownload.pkgurl = PS2Game2.Tag
            Else

                HideGames()
                Hideps2Games()
                Me.ActiveControl = Home

                Dim GameIF As New FileInfo(PS2Game2.Tag)

                If GameIF.Extension = ".iso" Then
                    SwitchPCSXPlugin("ISO")
                    GameSect = "PS"
                    GameID = 2
                    GameFormat = "ISO"

                    PlayGameIntro()

                    currentgamestate = "ps2"
                ElseIf GameIF.Extension = ".cso" Then
                    GameSect = "PS"
                    GameID = 2
                    GameFormat = "CSO"

                    PlayGameIntro()

                    currentgamestate = "psp"
                Else
                    GameSect = "PS"
                    GameID = 2
                    GameFormat = "BIN"

                    PlayGameIntro()

                    currentgamestate = "ps1"
                End If

            End If

        ElseIf PS2Game3.Focused And GetAsyncKeyState(Keys.Enter) Then
            If PS2Game3Text.Text.Contains("Install") Then

                BackgroundDownload.Show()
                BackgroundDownload.pkgurl = PS2Game3.Tag
            Else

                HideGames()
                Hideps2Games()
                Me.ActiveControl = Home

                Dim GameIF As New FileInfo(PS2Game3.Tag)

                If GameIF.Extension = ".iso" Then
                    SwitchPCSXPlugin("ISO")
                    GameSect = "PS"
                    GameID = 3
                    GameFormat = "ISO"

                    PlayGameIntro()

                    currentgamestate = "ps2"
                ElseIf GameIF.Extension = ".cso" Then
                    GameSect = "PS"
                    GameID = 3
                    GameFormat = "CSO"

                    PlayGameIntro()

                    currentgamestate = "psp"
                Else
                    GameSect = "PS"
                    GameID = 3
                    GameFormat = "BIN"

                    PlayGameIntro()

                    currentgamestate = "ps1"
                End If

            End If

        ElseIf RetroGame1.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideGames()
            Hideps2Games()
            HideRetroGames()
            Me.ActiveControl = Home

            Dim GameIF As New FileInfo(RetroGame1.Tag)

            If GameIF.Extension = ".gba" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "GBA"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".gbc" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "GBC"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smc" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "SMC"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smd" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "SMD"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".nes" Then

                GameSect = "RETRO"
                GameID = 1
                GameFormat = "NES"

                PlayGameIntro()

                currentgamestate = "retro"
            End If

        ElseIf RetroGame2.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideGames()
            Hideps2Games()
            HideRetroGames()
            Me.ActiveControl = Home

            Dim GameIF As New FileInfo(RetroGame2.Tag)

            If GameIF.Extension = ".gba" Then

                GameSect = "RETRO"
                GameID = 2
                GameFormat = "GBA"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".gbc" Then

                GameSect = "RETRO"
                GameID = 2
                GameFormat = "GBC"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smc" Then

                GameSect = "RETRO"
                GameID = 2
                GameFormat = "SMC"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smd" Then

                GameSect = "RETRO"
                GameID = 2
                GameFormat = "SMD"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".nes" Then

                GameSect = "RETRO"
                GameID = 2
                GameFormat = "NES"

                PlayGameIntro()

                currentgamestate = "retro"
            End If

        ElseIf RetroGame3.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideGames()
            Hideps2Games()
            HideRetroGames()
            Me.ActiveControl = Home

            Dim GameIF As New FileInfo(RetroGame3.Tag)

            If GameIF.Extension = ".gba" Then

                GameSect = "RETRO"
                GameID = 3
                GameFormat = "GBA"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".gbc" Then

                GameSect = "RETRO"
                GameID = 3
                GameFormat = "GBC"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smc" Then

                GameSect = "RETRO"
                GameID = 3
                GameFormat = "SMC"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".smd" Then

                GameSect = "RETRO"
                GameID = 3
                GameFormat = "SMD"

                PlayGameIntro()

                currentgamestate = "retro"
            ElseIf GameIF.Extension = ".nes" Then

                GameSect = "RETRO"
                GameID = 3
                GameFormat = "NES"

                PlayGameIntro()

                currentgamestate = "retro"
            End If

        ElseIf DiscGame.Focused And GetAsyncKeyState(Keys.Enter) Then

            If CurrentGameDisc = "PS2" Then

                HideGames()
                Hideps2Games()
                Me.ActiveControl = Home

                SwitchPCSXPlugin("Plugin")

                GameSect = "DISC"
                GameID = 1
                GameFormat = "PS2"

                PlayGameIntro()

                currentgamestate = "ps2"

            ElseIf CurrentGameDisc = "PS1" Then

                HideGames()
                Hideps2Games()
                Me.ActiveControl = Home

                GameSect = "DISC"
                GameID = 1
                GameFormat = "PSX"

                PlayGameIntro()

                currentgamestate = "ps1"

            End If

        ElseIf BrowserBox.Focused And GetAsyncKeyState(Keys.Enter) Then

            Browser.Show()
            Browser.BringToFront()
            Browser.Activate()

            Me.Enabled = False
        ElseIf Track1.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideMusic()
            Me.ActiveControl = Home

            CurrentMusicTrack = Track1.Tag

            MusicPlayer.Show()
            MusicPlayer.BringToFront()

            Me.Enabled = False
        ElseIf Track2.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideMusic()
            Me.ActiveControl = Home

            CurrentMusicTrack = Track2.Tag

            MusicPlayer.Show()
            MusicPlayer.BringToFront()

            Me.Enabled = False
        ElseIf Track3.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideMusic()
            Me.ActiveControl = Home

            CurrentMusicTrack = Track3.Tag

            MusicPlayer.Show()
            MusicPlayer.BringToFront()

            Me.Enabled = False
        ElseIf Track4.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideMusic()
            Me.ActiveControl = Home

            CurrentMusicTrack = Track4.Tag

            MusicPlayer.Show()
            MusicPlayer.BringToFront()

            Me.Enabled = False

        ElseIf Vid1.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideVideos()
            Me.ActiveControl = Home

            CurrentVideoTrack = Vid1.Tag

            VideoPlayer.Show()
            VideoPlayer.BringToFront()

            Me.Enabled = False
        ElseIf Vid2.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideVideos()
            Me.ActiveControl = Home

            CurrentVideoTrack = Vid2.Tag

            VideoPlayer.Show()
            VideoPlayer.BringToFront()

            Me.Enabled = False
        ElseIf Vid3.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideVideos()
            Me.ActiveControl = Home

            CurrentVideoTrack = Vid3.Tag

            VideoPlayer.Show()
            VideoPlayer.BringToFront()

            Me.Enabled = False
        ElseIf Vid4.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideVideos()
            Me.ActiveControl = Home

            CurrentVideoTrack = Vid4.Tag

            VideoPlayer.Show()
            VideoPlayer.BringToFront()

            Me.Enabled = False

        ElseIf Picture1.Focused And GetAsyncKeyState(Keys.Enter) Then

            HidePictures()
            Me.ActiveControl = Home

            CurrentPictureTrack = Picture1.Tag

            PictureViewer.Show()
            PictureViewer.BringToFront()

            Me.Enabled = False

        ElseIf Picture2.Focused And GetAsyncKeyState(Keys.Enter) Then

            HidePictures()
            Me.ActiveControl = Home

            CurrentPictureTrack = Picture2.Tag

            PictureViewer.Show()
            PictureViewer.BringToFront()

            Me.Enabled = False

        ElseIf Picture3.Focused And GetAsyncKeyState(Keys.Enter) Then

            HidePictures()
            Me.ActiveControl = Home

            CurrentPictureTrack = Picture3.Tag

            PictureViewer.Show()
            PictureViewer.BringToFront()

            Me.Enabled = False

        ElseIf Picture4.Focused And GetAsyncKeyState(Keys.Enter) Then

            HidePictures()
            Me.ActiveControl = Home

            CurrentPictureTrack = Picture4.Tag

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

        ElseIf UserAvatar.Focused And GetAsyncKeyState(Keys.Enter) Then

            If currentnetworkstate = "offline" Then
                MyPSLogin.Show()
                MyPSLogin.BringToFront()
            Else

                currentnetworkstate = "offline"
                NetworkTimer.Stop()

                ClearFriends()
                UserAvatar.Image = My.Resources.user
                UserLoginName.Text = "Not logged in"
                UserDescr.Text = "Please login first"

            End If

        ElseIf UserAvatar.Focused And GetAsyncKeyState(Keys.U) Then

            If currentnetworkstate = "online" Then

                Dim newstatus As String = InputBox("Enter your new status:", "Update Status")
                UpdateStatus(newstatus)

            End If

        ElseIf AddFriend.Focused And GetAsyncKeyState(Keys.Enter) Then

            If currentnetworkstate = "online" Then
                Dim friendname As String = InputBox("Enter the UserID of your friend:", "Add a friend")
                AddNetworkFriend(friendname)
            Else
                MsgBox(LangLoader.GetStringOfLang("XMB", "ErrorAddFriend"), MsgBoxStyle.Critical, "XMBPC Network ERROR #1")
            End If

        ElseIf YoutubeBox.Focused And GetAsyncKeyState(Keys.Enter) Then

            HideVideos()
            Me.ActiveControl = Home

            Browser.Show()
            Browser.BringToFront()
            Browser.WebBrowser1.Navigate("http://www.youtube.com")
            Browser.Activate()

            Me.Enabled = False

        ElseIf Poweroff.Focused And GetAsyncKeyState(Keys.Enter) Then

            If MsgBox("Do you really want to exit XMBPC?", MsgBoxStyle.YesNo, "Shutdown XMBPC") = MsgBoxResult.Yes Then
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

        Picture1.Visible = True
        Picture2.Visible = True
        Picture3.Visible = True
        Picture4.Visible = True

        Picture1Text.Visible = True
        Picture2Text.Visible = True
        Picture3Text.Visible = True
        Picture4Text.Visible = True
    End Sub

    Private Sub Musics_GotFocus(sender As Object, e As EventArgs) Handles Musics.GotFocus
        If Not themechanged = True Then
            'Musics.Image = My.Resources.music_h
        End If

        Musics.Size = New Size(105, 105)
        MusicTxt.Visible = True
        MusicTxt.GlowState = True

        Track1.Visible = True
        Track2.Visible = True
        Track3.Visible = True
        Track4.Visible = True

        Track1Name.Visible = True
        Track2Name.Visible = True
        Track3Name.Visible = True
        Track4Name.Visible = True
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

        Vid1.Visible = True
        Vid2.Visible = True
        Vid3.Visible = True
        Vid4.Visible = True
        YoutubeBox.Visible = True

        Vid1Text.Visible = True
        Vid2Text.Visible = True
        Vid3Text.Visible = True
        Vid4Text.Visible = True
        YoutubeTxt.Visible = True
    End Sub

    Private Sub Games_GotFocus(sender As Object, e As EventArgs) Handles Games.GotFocus
        If Not themechanged = True Then
            'Games.Image = My.Resources.games_h
        End If

        Games.Size = New Size(105, 105)
        GamesTxt.Visible = True
        GamesTxt.GlowState = True

        DiscGame.Visible = True
        DiscGameName.Visible = True
        PS2Folder.Visible = True
        PS2Games.Visible = True
        RetroFolder.Visible = True
        RetroGames.Visible = True
        Game1.Visible = True
        Game1Text.Visible = True
        Game2.Visible = True
        Game2Text.Visible = True
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

    Private Sub Friends_GotFocus(sender As Object, e As EventArgs) Handles Friends.GotFocus
        If Not themechanged = True Then
            'Friends.Image = My.Resources.friends_h
        End If

        Friends.Size = New Size(105, 105)
        FriendsTxt.Visible = True
        FriendsTxt.GlowState = True

        UserAvatar.Visible = True
        UserLoginName.Visible = True
        UserDescr.Visible = True

        Friend1Ava.Visible = True
        Friend1Name.Visible = True
        Friend1Status.Visible = True

        Friend2Ava.Visible = True
        Friend2Name.Visible = True
        Friend2Status.Visible = True

        Friend3Ava.Visible = True
        Friend3Name.Visible = True
        Friend3Status.Visible = True

        AddFriend.Visible = True
        AddFriendTxt.Visible = True
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

    Private Sub Pictures_LostFocus(sender As Object, e As EventArgs) Handles Pictures.LostFocus
        If Not themechanged = True Then
            Pictures.Image = My.Resources.pictures_icon
        End If

        Pictures.Size = New Size(96, 96)
        PhotosTxt.Visible = False
        PhotosTxt.GlowState = False

        If Not Picture1.Focused = True Then
            If Not Picture4.Focused = True Then
                HidePictures()
            End If
        End If
    End Sub

    Private Sub Musics_LostFocus(sender As Object, e As EventArgs) Handles Musics.LostFocus
        If Not themechanged = True Then
            Musics.Image = My.Resources.music_icon
        End If

        Musics.Size = New Size(96, 96)
        MusicTxt.Visible = False
        MusicTxt.GlowState = False

        If Not Track1.Focused = True Then
            If Not Track4.Focused = True Then
                HideMusic()
            End If
        End If

    End Sub

    Private Sub Videos_LostFocus(sender As Object, e As EventArgs) Handles Videos.LostFocus
        If Not themechanged = True Then
            Videos.Image = My.Resources.video_icon
        End If

        Videos.Size = New Size(96, 96)
        VideosTxt.Visible = False
        VideosTxt.GlowState = False

        If Not YoutubeBox.Focused = True Then
            If Not Vid4.Focused = True Then
                HideVideos()
            End If
        End If
    End Sub

    Private Sub Games_LostFocus(sender As Object, e As EventArgs) Handles Games.LostFocus
        If Not themechanged = True Then
            Games.Image = My.Resources.games_icon
        End If

        Games.Size = New Size(96, 96)
        GamesTxt.Visible = False
        GamesTxt.GlowState = False

        If Not DiscGame.Focused = True And Not Game2.Focused = True Then
            HideGames()
            Hideps2Games()
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

    Private Sub Friends_LostFocus(sender As Object, e As EventArgs) Handles Friends.LostFocus
        If Not themechanged = True Then
            Friends.Image = My.Resources.friends_icon
        End If

        Friends.Size = New Size(96, 96)
        FriendsTxt.Visible = False
        FriendsTxt.GlowState = False

        If Not UserAvatar.Focused And Not Friends.Focused Then
            HideFriends()
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
            Me.ActiveControl = Friends
        ElseIf Friends.Focused = True Then
            Me.ActiveControl = Home
        End If

        If currentcategory = "games" And PS2Folder.Focused Then
            currentcategory = "ps2games"

            PS2Game1.Visible = True
            PS2Game1Text.Visible = True
            PS2Game2.Visible = True
            PS2Game2Text.Visible = True
            PS2Game3.Visible = True
            PS2Game3Text.Visible = True

            RetroFolder.Visible = False
            RetroGames.Visible = False
            Game1.Visible = False
            Game1Text.Visible = False
            Game2.Visible = False
            Game2Text.Visible = False

            Me.ActiveControl = PS2Game1

        ElseIf currentcategory = "games" And RetroFolder.Focused Then
            currentcategory = "retrogames"

            RetroGame1.Visible = True
            RetroGame1Text.Visible = True
            RetroGame2.Visible = True
            RetroGame2Text.Visible = True
            RetroGame3.Visible = True
            RetroGame3Text.Visible = True

            Game1.Visible = False
            Game1Text.Visible = False
            Game2.Visible = False
            Game2Text.Visible = False

            Me.ActiveControl = RetroGame1

        ElseIf currentcategory = "games" Then
            Me.ActiveControl = BrowserBox
            HideGames()

        ElseIf currentcategory = "ps2games" Then
            Me.ActiveControl = BrowserBox
            HideGames()
            Hideps2Games()

        ElseIf currentcategory = "retrogames" Then
            Me.ActiveControl = BrowserBox
            HideGames()
            Hideps2Games()
            HideRetroGames()

        ElseIf currentcategory = "users" Then
            Me.ActiveControl = Settings
            HideUsers()

        ElseIf currentcategory = "music" Then
            Me.ActiveControl = Videos
            HideMusic()

        ElseIf currentcategory = "videos" Then
            Me.ActiveControl = Games
            HideVideos()

        ElseIf currentcategory = "pictures" Then
            Me.ActiveControl = Musics
            HidePictures()

        ElseIf currentcategory = "settings" Then
            Me.ActiveControl = Pictures
            HideSettings()

        ElseIf currentcategory = "friends" Then
            Me.ActiveControl = Home
            HideFriends()

        ElseIf currentcategory = "network" Then
            Me.ActiveControl = Friends
            HideNetwork()

        End If

    End Sub

    Private Sub ControlLeft()
        If currentgamestate = "" And Me.Enabled Then
            My.Computer.Audio.Play(".\media\xmb_browse_tick.wav", AudioPlayMode.Background)
        End If

        If Home.Focused = True Then
            Me.ActiveControl = Friends
        ElseIf Friends.Focused = True Then
            Me.ActiveControl = BrowserBox
        ElseIf BrowserBox.Focused = True Then
            Me.ActiveControl = Games
        ElseIf Games.Focused = True Then
            Me.ActiveControl = Videos
        ElseIf Videos.Focused = True Then
            Me.ActiveControl = Musics
        ElseIf Musics.Focused = True Then
            Me.ActiveControl = Pictures
        ElseIf Pictures.Focused = True Then
            Me.ActiveControl = Settings
        ElseIf Settings.Focused = True Then
            Me.ActiveControl = Home
        End If

        If currentcategory = "games" Then
            Me.ActiveControl = Videos
            HideGames()

        ElseIf currentcategory = "ps2games" Then
            Me.ActiveControl = PS2Folder
            Hideps2Games()

            RetroFolder.Visible = True
            RetroGames.Visible = True
            Game1.Visible = True
            Game1Text.Visible = True
            Game2.Visible = True
            Game2Text.Visible = True

        ElseIf currentcategory = "retrogames" Then
            Me.ActiveControl = RetroFolder
            HideRetroGames()

            Game1.Visible = True
            Game1Text.Visible = True
            Game2.Visible = True
            Game2Text.Visible = True

        ElseIf currentcategory = "users" Then
            Me.ActiveControl = Friends
            HideUsers()

        ElseIf currentcategory = "music" Then
            Me.ActiveControl = Pictures
            HideMusic()

        ElseIf currentcategory = "videos" Then
            Me.ActiveControl = Musics
            HideVideos()

        ElseIf currentcategory = "pictures" Then
            Me.ActiveControl = Settings
            HidePictures()

        ElseIf currentcategory = "settings" Then
            Me.ActiveControl = Home
            HideSettings()

        ElseIf currentcategory = "friends" Then
            Me.ActiveControl = BrowserBox
            HideFriends()

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

        If Friends.Focused = True Then
            currentcategory = "friends"
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

        If Friends.Focused = True Then
            currentcategory = "friends"
        End If

        If BrowserBox.Focused = True Then
            currentcategory = "network"
        End If

    End Sub

#End Region

#Region "XMB-Games-Browsing"

    Private Sub RetroFolder_GotFocus(sender As Object, e As EventArgs) Handles RetroFolder.GotFocus
        DropShadowOfText(RetroGames)
    End Sub

    Private Sub RetroFolder_LostFocus(sender As Object, e As EventArgs) Handles RetroFolder.LostFocus
        DropShadowOfText(RetroGames)
    End Sub

    Private Sub Game2_GotFocus(sender As Object, e As EventArgs) Handles Game1.GotFocus
        DropShadowOfText(Game1Text)
    End Sub

    Private Sub Game2_LostFocus(sender As Object, e As EventArgs) Handles Game1.LostFocus
        DropShadowOfText(Game1Text)
    End Sub

    Private Sub Game3_GotFocus(sender As Object, e As EventArgs) Handles Game2.GotFocus
        DropShadowOfText(Game2Text)
    End Sub

    Private Sub Game3_LostFocus(sender As Object, e As EventArgs) Handles Game2.LostFocus
        DropShadowOfText(Game2Text)
    End Sub

    Private Sub PS2Folder_GotFocus(sender As Object, e As EventArgs) Handles PS2Folder.GotFocus
        DropShadowOfText(PS2Games)
    End Sub

    Private Sub PS2Folder_LostFocus(sender As Object, e As EventArgs) Handles PS2Folder.LostFocus
        DropShadowOfText(PS2Games)
    End Sub

    Private Sub PS2Game1_GotFocus(sender As Object, e As EventArgs) Handles PS2Game1.GotFocus
        DropShadowOfText(PS2Game1Text)
    End Sub

    Private Sub PS2Game1_LostFocus(sender As Object, e As EventArgs) Handles PS2Game1.LostFocus
        DropShadowOfText(PS2Game1Text)

        If Not PS2Game1.Focused And Not PS2Game2.Focused And Not PS2Game3.Focused Then
            Hideps2Games()
        End If
    End Sub

    Private Sub PS2Game2_GotFocus(sender As Object, e As EventArgs) Handles PS2Game2.GotFocus
        DropShadowOfText(PS2Game2Text)
    End Sub

    Private Sub PS2Game2_LostFocus(sender As Object, e As EventArgs) Handles PS2Game2.LostFocus
        DropShadowOfText(PS2Game2Text)

        If Not PS2Game1.Focused And Not PS2Game2.Focused And Not PS2Game3.Focused Then
            Hideps2Games()
        End If
    End Sub

    Private Sub PS2Game3_GotFocus(sender As Object, e As EventArgs) Handles PS2Game3.GotFocus
        DropShadowOfText(PS2Game3Text)
    End Sub

    Private Sub PS2Game3_LostFocus(sender As Object, e As EventArgs) Handles PS2Game3.LostFocus
        DropShadowOfText(PS2Game3Text)

        If Not PS2Game1.Focused And Not PS2Game2.Focused And Not PS2Game3.Focused Then
            Hideps2Games()
        End If
    End Sub

    Private Sub RetroGame1_GotFocus(sender As Object, e As EventArgs) Handles RetroGame1.GotFocus
        DropShadowOfText(RetroGame1Text)
    End Sub

    Private Sub RetroGame1_LostFocus(sender As Object, e As EventArgs) Handles RetroGame1.LostFocus
        DropShadowOfText(RetroGame1Text)

        If Not RetroGame1.Focused And Not RetroGame2.Focused And Not RetroGame3.Focused Then
            HideRetroGames()
        End If
    End Sub

    Private Sub RetroGame2_GotFocus(sender As Object, e As EventArgs) Handles RetroGame2.GotFocus
        DropShadowOfText(RetroGame2Text)
    End Sub

    Private Sub RetroGame2_LostFocus(sender As Object, e As EventArgs) Handles RetroGame2.LostFocus
        DropShadowOfText(RetroGame2Text)

        If Not RetroGame1.Focused And Not RetroGame2.Focused And Not RetroGame3.Focused Then
            HideRetroGames()
        End If
    End Sub

    Private Sub RetroGame3_GotFocus(sender As Object, e As EventArgs) Handles RetroGame3.GotFocus
        DropShadowOfText(RetroGame3Text)
    End Sub

    Private Sub RetroGame3_LostFocus(sender As Object, e As EventArgs) Handles RetroGame3.LostFocus
        DropShadowOfText(RetroGame3Text)

        If Not RetroGame1.Focused And Not RetroGame2.Focused And Not RetroGame3.Focused Then
            HideRetroGames()
        End If
    End Sub

    Private Sub DiscGame_GotFocus(sender As Object, e As EventArgs) Handles DiscGame.GotFocus
        DropShadowOfText(DiscGameName)
    End Sub

    Private Sub DiscGame_LostFocus(sender As Object, e As EventArgs) Handles DiscGame.LostFocus
        DropShadowOfText(DiscGameName)
    End Sub

    Private Function SplitGamePath(ByVal GameStr As String, ByVal Options As Integer)
        Return GameStr.Split(";")(Options)
    End Function

    Private Function GetGameCover(ByVal Game As String) As Image
        Dim ConvertedGame As String = Game.Split(";")(1)
        Dim CoverbyExt As String = Game.Split(";")(0)

        If File.Exists(".\media\Covers\" + ConvertedGame.Replace(" ", "-") + ".png") Then
            Return Image.FromFile(".\media\Covers\" + ConvertedGame.Replace(" ", "-") + ".png")

        Else

            If CoverbyExt.Contains(".cso") Then
                Return My.Resources.psp
            ElseIf CoverbyExt.Contains(".bin") Then
                Return My.Resources.ps1
            ElseIf CoverbyExt.Contains(".iso") Then
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
            Else
                Return My.Resources.Game_Default_PS3
            End If

        End If
    End Function

    Private Sub HideGames()
        DiscGame.Visible = False
        DiscGameName.Visible = False

        PS2Folder.Visible = False
        PS2Games.Visible = False

        RetroFolder.Visible = False
        RetroGames.Visible = False
        Game1.Visible = False
        Game1Text.Visible = False
        Game2.Visible = False
        Game2Text.Visible = False

        currentcategory = "xmb"
    End Sub

    Private Sub Hideps2Games()

        PS2Game1.Visible = False
        PS2Game1Text.Visible = False
        PS2Game2.Visible = False
        PS2Game2Text.Visible = False
        PS2Game3.Visible = False
        PS2Game3Text.Visible = False

        currentcategory = "games"
    End Sub

    Private Sub HideRetroGames()

        RetroGame1.Visible = False
        RetroGame1Text.Visible = False
        RetroGame2.Visible = False
        RetroGame2Text.Visible = False
        RetroGame3.Visible = False
        RetroGame3Text.Visible = False

        currentcategory = "games"
    End Sub

    Private Sub LoadGames()

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

                    DiscGame.Tag = drive.ToString

                Else

                    DiscGameName.Text = GetGameNameOfDisc(drive.ToString())
                    DiscGame.Image = GetGameCover("disc-game;" + GetGameNameOfDisc(drive.ToString()))

                End If

            End If

        Next

        For Each Gamex As String In File.ReadAllLines(".\glist.txt")
            gameslist.Add(Gamex)
        Next

        Game1.Tag = SplitGamePath(gameslist(0).ToString, 0)
        Game1Text.Text = SplitGamePath(gameslist(0).ToString, 1)
        Game1.Image = GetGameCover(gameslist(0).ToString)

        Game2.Tag = SplitGamePath(gameslist(1).ToString, 0)
        Game2Text.Text = SplitGamePath(gameslist(1).ToString, 1)
        Game2.Image = GetGameCover(gameslist(1).ToString)

        currentgames = 1

    End Sub

    Private Sub LoadPS2Games()

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

        currentps2games = 2

    End Sub

    Private Sub LoadRetroGames()

        On Error Resume Next

        For Each Ga As String In File.ReadAllLines(".\retrogameslist.txt")
            retrogameslist.Add(Ga)
        Next

        RetroGame1.Tag = SplitGamePath(retrogameslist(0).ToString, 0)
        RetroGame1Text.Text = SplitGamePath(retrogameslist(0).ToString, 1)
        RetroGame1.Image = GetGameCover(retrogameslist(0).ToString)

        RetroGame2.Tag = SplitGamePath(retrogameslist(1).ToString, 0)
        RetroGame2Text.Text = SplitGamePath(retrogameslist(1).ToString, 1)
        RetroGame2.Image = GetGameCover(retrogameslist(1).ToString)

        RetroGame3.Tag = SplitGamePath(retrogameslist(2).ToString, 0)
        RetroGame3Text.Text = SplitGamePath(retrogameslist(2).ToString, 1)
        RetroGame3.Image = GetGameCover(retrogameslist(2).ToString)

        currentretrogames = 2

    End Sub

    Private Sub BrowseNextGames()

        On Error Resume Next

        If currentgames + 2 < gameslist.Count Then

            Game1.Tag = SplitGamePath(gameslist(currentgames + 1).ToString, 0)
            Game1Text.Text = SplitGamePath(gameslist(currentgames + 1).ToString, 1)
            Game1.Image = GetGameCover(gameslist(currentgames + 1).ToString)

            Game2.Tag = SplitGamePath(gameslist(currentgames + 2).ToString, 0)
            Game2Text.Text = SplitGamePath(gameslist(currentgames + 2).ToString, 1)
            Game2.Image = GetGameCover(gameslist(currentgames + 2).ToString)

            currentgames = currentgames + 2

        ElseIf currentgames + 1 < gameslist.Count Then

            Game1.Tag = SplitGamePath(gameslist(currentgames + 1).ToString, 0)
            Game1Text.Text = SplitGamePath(gameslist(currentgames + 1).ToString, 1)
            Game1.Image = GetGameCover(gameslist(currentgames + 1).ToString)

            Game2.Tag = Nothing
            Game2Text.Text = ""
            Game2.Image = Nothing

            currentgames = currentgames + 1

        Else

        End If

    End Sub

    Private Sub BrowseLastGames()

        On Error Resume Next

        If currentgames - 2 > -1 Then

            Game1.Tag = SplitGamePath(gameslist(currentgames - 2).ToString, 0)
            Game1Text.Text = SplitGamePath(gameslist(currentgames - 2).ToString, 1)
            Game1.Image = GetGameCover(gameslist(currentgames - 2).ToString)

            Game2.Tag = SplitGamePath(gameslist(currentgames - 1).ToString, 0)
            Game2Text.Text = SplitGamePath(gameslist(currentgames - 1).ToString, 1)
            Game2.Image = GetGameCover(gameslist(currentgames - 1).ToString)

            currentgames = currentgames - 2

        ElseIf currentgames - 1 > -1 Then

            Game1.Tag = SplitGamePath(gameslist(currentgames - 1).ToString, 0)
            Game1Text.Text = SplitGamePath(gameslist(currentgames - 1).ToString, 1)
            Game1.Image = GetGameCover(gameslist(currentgames - 1).ToString)

            currentgames = currentgames - 1

        End If

    End Sub

    Private Sub BrowseNextPS2Games()

        On Error Resume Next

        If currentps2games + 3 < ps2gameslist.Count Then

            PS2Game1.Tag = SplitGamePath(ps2gameslist(currentps2games + 1).ToString, 0)
            PS2Game1Text.Text = SplitGamePath(ps2gameslist(currentps2games + 1).ToString, 1)
            PS2Game1.Image = GetGameCover(ps2gameslist(currentps2games + 1).ToString)

            PS2Game2.Tag = SplitGamePath(ps2gameslist(currentps2games + 2).ToString, 0)
            PS2Game2Text.Text = SplitGamePath(ps2gameslist(currentps2games + 2).ToString, 1)
            PS2Game2.Image = GetGameCover(ps2gameslist(currentps2games + 2).ToString)

            PS2Game3.Tag = SplitGamePath(ps2gameslist(currentps2games + 3).ToString, 0)
            PS2Game3Text.Text = SplitGamePath(ps2gameslist(currentps2games + 3).ToString, 1)
            PS2Game3.Image = GetGameCover(ps2gameslist(currentps2games + 3).ToString)

            currentps2games = currentps2games + 3

        ElseIf currentps2games + 2 < ps2gameslist.Count Then

            PS2Game1.Tag = SplitGamePath(ps2gameslist(currentps2games + 1).ToString, 0)
            PS2Game1Text.Text = SplitGamePath(ps2gameslist(currentps2games + 1).ToString, 1)
            PS2Game1.Image = GetGameCover(ps2gameslist(currentps2games + 1).ToString)

            PS2Game2.Tag = SplitGamePath(ps2gameslist(currentps2games + 2).ToString, 0)
            PS2Game2Text.Text = SplitGamePath(ps2gameslist(currentps2games + 2).ToString, 1)
            PS2Game2.Image = GetGameCover(ps2gameslist(currentps2games + 2).ToString)

            PS2Game3.Tag = Nothing
            PS2Game3Text.Text = ""
            PS2Game3.Image = Nothing

            currentps2games = currentps2games + 2

        ElseIf currentps2games + 1 < ps2gameslist.Count Then

            PS2Game1.Tag = SplitGamePath(ps2gameslist(currentps2games + 1).ToString, 0)
            PS2Game1Text.Text = SplitGamePath(ps2gameslist(currentps2games + 1).ToString, 1)
            PS2Game1.Image = GetGameCover(ps2gameslist(currentps2games + 1).ToString)

            PS2Game2.Tag = Nothing
            PS2Game2Text.Text = ""
            PS2Game2.Image = Nothing

            PS2Game3.Tag = Nothing
            PS2Game3Text.Text = ""
            PS2Game3.Image = Nothing

            currentps2games = currentps2games + 1

        End If

    End Sub

    Private Sub BrowseLastPS2Games()

        On Error Resume Next

        If currentps2games - 3 > -1 Then

            PS2Game1.Tag = SplitGamePath(ps2gameslist(currentps2games - 3).ToString, 0)
            PS2Game1Text.Text = SplitGamePath(ps2gameslist(currentps2games - 3).ToString, 1)
            PS2Game1.Image = GetGameCover(ps2gameslist(currentps2games - 3).ToString)

            PS2Game2.Tag = SplitGamePath(ps2gameslist(currentps2games - 2).ToString, 0)
            PS2Game2Text.Text = SplitGamePath(ps2gameslist(currentps2games - 2).ToString, 1)
            PS2Game2.Image = GetGameCover(ps2gameslist(currentps2games - 2).ToString)

            PS2Game3.Tag = SplitGamePath(ps2gameslist(currentps2games - 1).ToString, 0)
            PS2Game3Text.Text = SplitGamePath(ps2gameslist(currentps2games - 1).ToString, 1)
            PS2Game3.Image = GetGameCover(ps2gameslist(currentps2games - 1).ToString)

            currentps2games = currentps2games - 3

        ElseIf currentps2games - 2 > -1 Then

            PS2Game1.Tag = SplitGamePath(ps2gameslist(currentps2games - 2).ToString, 0)
            PS2Game1Text.Text = SplitGamePath(ps2gameslist(currentps2games - 2).ToString, 1)
            PS2Game1.Image = GetGameCover(ps2gameslist(currentps2games - 2).ToString)

            PS2Game2.Tag = SplitGamePath(ps2gameslist(currentps2games - 1).ToString, 0)
            PS2Game2Text.Text = SplitGamePath(ps2gameslist(currentps2games - 1).ToString, 1)
            PS2Game2.Image = GetGameCover(ps2gameslist(currentps2games - 1).ToString)

            PS2Game3.Tag = SplitGamePath(ps2gameslist(currentps2games - 0).ToString, 0)
            PS2Game3Text.Text = SplitGamePath(ps2gameslist(currentps2games - 0).ToString, 1)
            PS2Game3.Image = GetGameCover(ps2gameslist(currentps2games - 0).ToString)

            currentps2games = currentps2games - 2

        ElseIf currentps2games - 1 > -1 Then

            PS2Game1.Tag = SplitGamePath(ps2gameslist(currentps2games - 1).ToString, 0)
            PS2Game1Text.Text = SplitGamePath(ps2gameslist(currentps2games - 1).ToString, 1)
            PS2Game1.Image = GetGameCover(ps2gameslist(currentps2games - 1).ToString)

            PS2Game2.Tag = SplitGamePath(ps2gameslist(currentps2games - 0).ToString, 0)
            PS2Game2Text.Text = SplitGamePath(ps2gameslist(currentps2games - 0).ToString, 1)
            PS2Game2.Image = GetGameCover(ps2gameslist(currentps2games - 0).ToString)

            PS2Game3.Tag = SplitGamePath(ps2gameslist(currentps2games + 1).ToString, 0)
            PS2Game3Text.Text = SplitGamePath(ps2gameslist(currentps2games + 1).ToString, 1)
            PS2Game3.Image = GetGameCover(ps2gameslist(currentps2games + 1).ToString)

            currentps2games = currentps2games - 1

        End If

    End Sub

    Private Sub BrowseNextRetroGames()

        On Error Resume Next

        If currentretrogames + 3 < retrogameslist.Count Then

            RetroGame1.Tag = SplitGamePath(retrogameslist(currentretrogames + 1).ToString, 0)
            RetroGame1Text.Text = SplitGamePath(retrogameslist(currentretrogames + 1).ToString, 1)
            RetroGame1.Image = GetGameCover(retrogameslist(currentretrogames + 1).ToString)

            RetroGame2.Tag = SplitGamePath(retrogameslist(currentretrogames + 2).ToString, 0)
            RetroGame2Text.Text = SplitGamePath(retrogameslist(currentretrogames + 2).ToString, 1)
            RetroGame2.Image = GetGameCover(retrogameslist(currentretrogames + 2).ToString)

            RetroGame3.Tag = SplitGamePath(retrogameslist(currentretrogames + 3).ToString, 0)
            RetroGame3Text.Text = SplitGamePath(retrogameslist(currentretrogames + 3).ToString, 1)
            RetroGame3.Image = GetGameCover(retrogameslist(currentretrogames + 3).ToString)

            currentretrogames = currentretrogames + 3

        ElseIf currentretrogames + 2 < retrogameslist.Count Then

            RetroGame1.Tag = SplitGamePath(retrogameslist(currentretrogames + 1).ToString, 0)
            RetroGame1Text.Text = SplitGamePath(retrogameslist(currentretrogames + 1).ToString, 1)
            RetroGame1.Image = GetGameCover(retrogameslist(currentretrogames + 1).ToString)

            RetroGame2.Tag = SplitGamePath(retrogameslist(currentretrogames + 2).ToString, 0)
            RetroGame2Text.Text = SplitGamePath(retrogameslist(currentretrogames + 2).ToString, 1)
            RetroGame2.Image = GetGameCover(retrogameslist(currentretrogames + 2).ToString)

            RetroGame3.Tag = Nothing
            RetroGame3Text.Text = ""
            RetroGame3.Image = Nothing

            currentretrogames = currentretrogames + 2

        ElseIf currentretrogames + 1 < retrogameslist.Count Then

            RetroGame1.Tag = SplitGamePath(retrogameslist(currentretrogames + 1).ToString, 0)
            RetroGame1Text.Text = SplitGamePath(retrogameslist(currentretrogames + 1).ToString, 1)
            RetroGame1.Image = GetGameCover(retrogameslist(currentretrogames + 1).ToString)

            RetroGame2.Tag = Nothing
            RetroGame2Text.Text = ""
            RetroGame2.Image = Nothing

            RetroGame3.Tag = Nothing
            RetroGame3Text.Text = ""
            RetroGame3.Image = Nothing

            currentretrogames = currentretrogames + 1

        End If

    End Sub

    Private Sub BrowseLastRetroGames()

        On Error Resume Next

        If currentretrogames - 3 > -1 Then

            RetroGame1.Tag = SplitGamePath(retrogameslist(currentretrogames - 3).ToString, 0)
            RetroGame1Text.Text = SplitGamePath(retrogameslist(currentretrogames - 3).ToString, 1)
            RetroGame1.Image = GetGameCover(retrogameslist(currentretrogames - 3).ToString)

            RetroGame2.Tag = SplitGamePath(retrogameslist(currentretrogames - 2).ToString, 0)
            RetroGame2Text.Text = SplitGamePath(retrogameslist(currentretrogames - 2).ToString, 1)
            RetroGame2.Image = GetGameCover(retrogameslist(currentretrogames - 2).ToString)

            RetroGame3.Tag = SplitGamePath(retrogameslist(currentretrogames - 1).ToString, 0)
            RetroGame3Text.Text = SplitGamePath(retrogameslist(currentretrogames - 1).ToString, 1)
            RetroGame3.Image = GetGameCover(retrogameslist(currentretrogames - 1).ToString)

            currentretrogames = currentretrogames - 3

        ElseIf currentretrogames - 2 > -1 Then

            RetroGame1.Tag = SplitGamePath(retrogameslist(currentretrogames - 2).ToString, 0)
            RetroGame1Text.Text = SplitGamePath(retrogameslist(currentretrogames - 2).ToString, 1)
            RetroGame1.Image = GetGameCover(retrogameslist(currentretrogames - 2).ToString)

            RetroGame2.Tag = SplitGamePath(retrogameslist(currentretrogames - 1).ToString, 0)
            RetroGame2Text.Text = SplitGamePath(retrogameslist(currentretrogames - 1).ToString, 1)
            RetroGame2.Image = GetGameCover(retrogameslist(currentretrogames - 1).ToString)

            RetroGame3.Tag = SplitGamePath(retrogameslist(currentretrogames - 0).ToString, 0)
            RetroGame3Text.Text = SplitGamePath(retrogameslist(currentretrogames - 0).ToString, 1)
            RetroGame3.Image = GetGameCover(retrogameslist(currentretrogames - 0).ToString)

            currentretrogames = currentretrogames - 2

        ElseIf currentretrogames - 1 > -1 Then

            RetroGame1.Tag = SplitGamePath(retrogameslist(currentretrogames - 1).ToString, 0)
            RetroGame1Text.Text = SplitGamePath(retrogameslist(currentretrogames - 1).ToString, 1)
            RetroGame1.Image = GetGameCover(retrogameslist(currentretrogames - 1).ToString)

            RetroGame2.Tag = SplitGamePath(retrogameslist(currentretrogames - 0).ToString, 0)
            RetroGame2Text.Text = SplitGamePath(retrogameslist(currentretrogames - 0).ToString, 1)
            RetroGame2.Image = GetGameCover(retrogameslist(currentretrogames - 0).ToString)

            RetroGame3.Tag = SplitGamePath(retrogameslist(currentretrogames + 1).ToString, 0)
            RetroGame3Text.Text = SplitGamePath(retrogameslist(currentretrogames + 1).ToString, 1)
            RetroGame3.Image = GetGameCover(retrogameslist(currentretrogames + 1).ToString)

            currentretrogames = currentretrogames - 1

        End If

    End Sub

    Private Sub ControlGamesBottom()
        If Games.Focused = True Then
            Me.ActiveControl = DiscGame
        ElseIf DiscGame.Focused = True Then
            Me.ActiveControl = PS2Folder
        ElseIf PS2Folder.Focused = True Then
            Me.ActiveControl = RetroFolder
        ElseIf RetroFolder.Focused = True Then
            If Not Game1Text.Text = "" Then
                Me.ActiveControl = Game1
            End If
        ElseIf Game1.Focused = True Then
            If Not Game2Text.Text = "" Then
                Me.ActiveControl = Game2
            End If
        ElseIf Game2.Focused = True Then
            Me.ActiveControl = Game1
            BrowseNextGames()
        End If
    End Sub

    Private Sub ControlGamesTop()
        If Games.Focused = True Then
            Me.ActiveControl = Game2
        ElseIf Game2.Focused = True Then
            Me.ActiveControl = Game1
        ElseIf Game1.Focused = True Then

            If currentgames = 0 Then
                Me.ActiveControl = RetroFolder
            Else
                BrowseLastGames()
                Me.ActiveControl = Game2
            End If

        ElseIf RetroFolder.Focused = True Then
            Me.ActiveControl = PS2Folder
        ElseIf PS2Folder.Focused = True Then
            Me.ActiveControl = DiscGame
        ElseIf DiscGame.Focused = True Then
            Me.ActiveControl = Games
            currentcategory = "xmb"
        End If
    End Sub

    Private Sub ControlPS2GamesBottom()
        If PS2Game1.Focused = True Then
            If Not PS2Game1Text.Text = "" Then
                Me.ActiveControl = PS2Game2
            End If
        ElseIf PS2Game2.Focused = True Then
            If Not PS2Game2Text.Text = "" Then
                Me.ActiveControl = PS2Game3
            End If
        ElseIf PS2Game3.Focused = True Then
            Me.ActiveControl = PS2Game1
            BrowseNextPS2Games()
        End If
    End Sub

    Private Sub ControlPS2GamesTop()
        If PS2Game3.Focused = True Then
            Me.ActiveControl = PS2Game2
        ElseIf PS2Game2.Focused = True Then
            Me.ActiveControl = PS2Game1
        ElseIf PS2Game1.Focused = True Then
            If currentps2games = 0 Then
                Me.ActiveControl = PS2Folder

                RetroFolder.Visible = True
                RetroGames.Visible = True
                Game1.Visible = True
                Game1Text.Visible = True
                Game2.Visible = True
                Game2Text.Visible = True
            Else
                BrowseLastPS2Games()
                Me.ActiveControl = PS2Game3
            End If
        End If
    End Sub

    Private Sub ControlRetroGamesBottom()
        If RetroGame1.Focused = True Then
            If Not RetroGame2Text.Text = "" Then
                Me.ActiveControl = RetroGame2
            End If
        ElseIf RetroGame2.Focused = True Then
            If Not RetroGame3Text.Text = "" Then
                Me.ActiveControl = RetroGame3
            End If
        ElseIf RetroGame3.Focused = True Then
            Me.ActiveControl = RetroGame1
            BrowseNextRetroGames()
        End If
    End Sub

    Private Sub ControlRetroGamesTop()
        If RetroGame3.Focused = True Then
            Me.ActiveControl = RetroGame2
        ElseIf RetroGame2.Focused = True Then
            Me.ActiveControl = RetroGame1
        ElseIf RetroGame1.Focused = True Then
            If currentretrogames = 0 Then
                Me.ActiveControl = RetroFolder

                RetroFolder.Visible = True
                RetroGames.Visible = True
                Game1.Visible = True
                Game1Text.Visible = True
                Game2.Visible = True
                Game2Text.Visible = True
            Else
                BrowseLastRetroGames()
                Me.ActiveControl = RetroGame3
            End If
        End If
    End Sub

#End Region

#Region "XMB-Users-Browsing"

    Private Sub HideUsers()
        NewUserBox.Top = 400
        CreateNewUser.Top = 415
        MeUserIco.Top = 500
        MeUserName.Top = 515
        Poweroff.Top = 600
        PoweroffTxt.Top = 615

        NewUserBox.Visible = False
        CreateNewUser.Visible = False
        MeUserIco.Visible = False
        MeUserName.Visible = False
        Poweroff.Visible = False
        PoweroffTxt.Visible = False
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

            transition.add(Poweroff, "Top", 500)
            transition.add(PoweroffTxt, "Top", 515)

            transition.run()

        ElseIf MeUserIco.Focused = True Then
            Me.ActiveControl = Poweroff

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))
            NewUserBox.Visible = False
            CreateNewUser.Visible = False

            transition.add(MeUserIco, "Top", 200)
            transition.add(MeUserName, "Top", 215)

            transition.add(Poweroff, "Top", 400)
            transition.add(PoweroffTxt, "Top", 415)

            transition.run()

        ElseIf Poweroff.Focused = True Then
            Me.ActiveControl = Home

            NewUserBox.Visible = True
            CreateNewUser.Visible = True

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))
            transition.add(NewUserBox, "Top", 400)
            transition.add(CreateNewUser, "Top", 415)

            transition.add(MeUserIco, "Top", 500)
            transition.add(MeUserName, "Top", 515)

            transition.add(Poweroff, "Top", 600)
            transition.add(PoweroffTxt, "Top", 615)

            transition.run()

            currentcategory = "xmb"
        End If
    End Sub

    Private Sub ControlUsersTop()
        If Home.Focused Then
            Me.ActiveControl = Poweroff

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))
            NewUserBox.Visible = False
            CreateNewUser.Visible = False

            transition.add(MeUserIco, "Top", 200)
            transition.add(MeUserName, "Top", 215)

            transition.add(Poweroff, "Top", 400)
            transition.add(PoweroffTxt, "Top", 415)

            transition.run()

        ElseIf Poweroff.Focused = True Then
            Me.ActiveControl = MeUserIco

            If NewUserBox.Visible = False Then
                NewUserBox.Visible = True
                CreateNewUser.Visible = True
            End If

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))
            transition.add(NewUserBox, "Top", 200)
            transition.add(CreateNewUser, "Top", 215)

            transition.add(MeUserIco, "Top", 400)
            transition.add(MeUserName, "Top", 415)

            transition.add(Poweroff, "Top", 500)
            transition.add(PoweroffTxt, "Top", 515)

            transition.run()

        ElseIf MeUserIco.Focused = True Then
            Me.ActiveControl = NewUserBox

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))
            transition.add(NewUserBox, "Top", 400)
            transition.add(CreateNewUser, "Top", 415)

            transition.add(MeUserIco, "Top", 500)
            transition.add(MeUserName, "Top", 515)

            transition.add(Poweroff, "Top", 600)
            transition.add(PoweroffTxt, "Top", 615)

            transition.run()

        ElseIf NewUserBox.Focused = True Then
            Me.ActiveControl = Home

            Dim transition As New Transition(New TransitionType_EaseInEaseOut(250))
            transition.add(NewUserBox, "Top", 400)
            transition.add(CreateNewUser, "Top", 415)

            transition.add(MeUserIco, "Top", 500)
            transition.add(MeUserName, "Top", 515)

            transition.add(Poweroff, "Top", 600)
            transition.add(PoweroffTxt, "Top", 615)

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

    Private Sub Track1_GotFocus(sender As Object, e As EventArgs) Handles Track1.GotFocus
        DropShadowOfText(Track1Name)
    End Sub

    Private Sub Track2_GotFocus(sender As Object, e As EventArgs) Handles Track2.GotFocus
        DropShadowOfText(Track2Name)
    End Sub

    Private Sub Track3_GotFocus(sender As Object, e As EventArgs) Handles Track3.GotFocus
        DropShadowOfText(Track3Name)
    End Sub

    Private Sub Track4_GotFocus(sender As Object, e As EventArgs) Handles Track4.GotFocus
        DropShadowOfText(Track4Name)
    End Sub

    Private Sub Track1_LostFocus(sender As Object, e As EventArgs) Handles Track1.LostFocus
        DropShadowOfText(Track1Name)
    End Sub

    Private Sub Track2_LostFocus(sender As Object, e As EventArgs) Handles Track2.LostFocus
        DropShadowOfText(Track2Name)
    End Sub

    Private Sub Track3_LostFocus(sender As Object, e As EventArgs) Handles Track3.LostFocus
        DropShadowOfText(Track3Name)
    End Sub

    Private Sub Track4_LostFocus(sender As Object, e As EventArgs) Handles Track4.LostFocus
        DropShadowOfText(Track4Name)
    End Sub

    Public Sub LoadMusic()
        Dim musicfiles() As String = getFiles(Functions.INI_ReadValueFromFile("Paths", "MusicPath", "", ".\media\paths.ini"), "*.mp3|*.aac|*.wav", SearchOption.AllDirectories)

        For Each Musics As String In musicfiles
            musiclist.Add(Musics)
        Next

        On Error Resume Next

        Track1.Image = Cover(musiclist(0).ToString)
        Track1Name.Text = Path.GetFileNameWithoutExtension(musiclist(0).ToString)
        Track1.Tag = musiclist(0).ToString

        Track2.Image = Cover(musiclist(1).ToString)
        Track2Name.Text = Path.GetFileNameWithoutExtension(musiclist(1).ToString)
        Track2.Tag = musiclist(1).ToString

        Track3.Image = Cover(musiclist(2).ToString)
        Track3Name.Text = Path.GetFileNameWithoutExtension(musiclist(2).ToString)
        Track3.Tag = musiclist(2).ToString

        Track4.Image = Cover(musiclist(3).ToString)
        Track4Name.Text = Path.GetFileNameWithoutExtension(musiclist(3).ToString)
        Track4.Tag = musiclist(3).ToString

        currenttrack = 3

    End Sub

    Private Sub HideMusic()
        Track1.Visible = False
        Track2.Visible = False
        Track3.Visible = False
        Track4.Visible = False

        Track1Name.Visible = False
        Track2Name.Visible = False
        Track3Name.Visible = False
        Track4Name.Visible = False

        currentcategory = "xmb"
    End Sub

    Private Sub BrowseNextMusic()

        On Error Resume Next

        If currenttrack + 4 < musiclist.Count Then

            Track1.Image = Cover(musiclist(currenttrack + 1).ToString)
            Track1Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack + 1).ToString)
            Track1.Tag = musiclist(currenttrack + 1).ToString

            Track2.Image = Cover(musiclist(currenttrack + 2).ToString)
            Track2Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack + 2).ToString)
            Track2.Tag = musiclist(currenttrack + 2).ToString

            Track3.Image = Cover(musiclist(currenttrack + 3).ToString)
            Track3Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack + 3).ToString)
            Track3.Tag = musiclist(currenttrack + 3).ToString

            Track4.Image = Cover(musiclist(currenttrack + 4).ToString)
            Track4Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack + 4).ToString)
            Track4.Tag = musiclist(currenttrack + 4).ToString

            currenttrack = currenttrack + 4

        ElseIf currenttrack + 3 < musiclist.Count Then

            Track1.Image = Cover(musiclist(currenttrack + 1).ToString)
            Track1Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack + 1).ToString)
            Track1.Tag = musiclist(currenttrack + 1).ToString

            Track2.Image = Cover(musiclist(currenttrack + 2).ToString)
            Track2Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack + 2).ToString)
            Track2.Tag = musiclist(currenttrack + 2).ToString

            Track3.Image = Cover(musiclist(currenttrack + 4).ToString)
            Track3Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack + 3).ToString)
            Track3.Tag = musiclist(currenttrack + 3).ToString

            Track4.Image = Nothing
            Track4Name.Text = ""
            Track4.Tag = Nothing

            currenttrack = currenttrack + 3

        ElseIf currenttrack + 2 < musiclist.Count Then

            Track1.Image = Cover(musiclist(currenttrack + 1).ToString)
            Track1Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack + 1).ToString)
            Track1.Tag = musiclist(currenttrack + 1).ToString

            Track2.Image = Cover(musiclist(currenttrack + 2).ToString)
            Track2Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack + 2).ToString)
            Track2.Tag = musiclist(currenttrack + 2).ToString

            Track3.Image = Nothing
            Track3Name.Text = ""
            Track3.Tag = Nothing

            Track4.Image = Nothing
            Track4Name.Text = ""
            Track4.Tag = Nothing

            currenttrack = currenttrack + 2

        ElseIf currenttrack + 1 < musiclist.Count Then

            Track1.Image = Cover(musiclist(currenttrack + 1).ToString)
            Track1Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack + 1).ToString)
            Track1.Tag = musiclist(currenttrack + 1).ToString

            Track2.Image = Nothing
            Track2Name.Text = ""
            Track2.Tag = Nothing

            Track3.Image = Nothing
            Track3Name.Text = ""
            Track3.Tag = Nothing

            Track4.Image = Nothing
            Track4Name.Text = ""
            Track4.Tag = Nothing

            currenttrack = currenttrack + 1

        Else

        End If

    End Sub

    Private Sub BrowseLastMusic()

        On Error Resume Next

        If currenttrack - 4 > -1 Then

            Track1.Image = Cover(musiclist(currenttrack - 4).ToString)
            Track1Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack - 4).ToString)
            Track1.Tag = musiclist(currenttrack - 4).ToString

            Track2.Image = Cover(musiclist(currenttrack - 3).ToString)
            Track2Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack - 3).ToString)
            Track2.Tag = musiclist(currenttrack - 3).ToString

            Track3.Image = Cover(musiclist(currenttrack - 2).ToString)
            Track3Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack - 2).ToString)
            Track3.Tag = musiclist(currenttrack - 2).ToString

            Track4.Image = Cover(musiclist(currenttrack - 1).ToString)
            Track4Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack - 1).ToString)
            Track4.Tag = musiclist(currenttrack - 1).ToString

            currenttrack = currenttrack - 4

        ElseIf currenttrack - 3 > -1 Then

            Track1.Image = Cover(musiclist(currenttrack - 3).ToString)
            Track1Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack - 3).ToString)
            Track1.Tag = musiclist(currenttrack - 3).ToString

            Track2.Image = Cover(musiclist(currenttrack - 2).ToString)
            Track2Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack - 2).ToString)
            Track2.Tag = musiclist(currenttrack - 2).ToString

            Track3.Image = Cover(musiclist(currenttrack - 1).ToString)
            Track3Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack - 1).ToString)
            Track3.Tag = musiclist(currenttrack - 1).ToString

            Track4.Image = Cover(musiclist(currenttrack - 0).ToString)
            Track4Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack - 0).ToString)
            Track4.Tag = musiclist(currenttrack - 0).ToString

            currenttrack = currenttrack - 3

        ElseIf currenttrack - 2 > -1 Then

            Track1.Image = Cover(musiclist(currenttrack - 2).ToString)
            Track1Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack - 2).ToString)
            Track1.Tag = musiclist(currenttrack - 2).ToString

            Track2.Image = Cover(musiclist(currenttrack - 1).ToString)
            Track2Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack - 1).ToString)
            Track2.Tag = musiclist(currenttrack - 1).ToString

            Track3.Image = Cover(musiclist(currenttrack - 0).ToString)
            Track3Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack - 0).ToString)
            Track3.Tag = musiclist(currenttrack - 0).ToString

            Track4.Image = Cover(musiclist(currenttrack + 1).ToString)
            Track4Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack + 1).ToString)
            Track4.Tag = musiclist(currenttrack + 1).ToString

            currenttrack = currenttrack - 2

        ElseIf currenttrack - 1 > -1 Then

            Track1.Image = Cover(musiclist(currenttrack - 1).ToString)
            Track1Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack - 1).ToString)
            Track1.Tag = musiclist(currenttrack - 1).ToString

            Track2.Image = Cover(musiclist(currenttrack - 0).ToString)
            Track2Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack - 0).ToString)
            Track2.Tag = musiclist(currenttrack - 0).ToString

            Track3.Image = Cover(musiclist(currenttrack + 1).ToString)
            Track3Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack + 1).ToString)
            Track3.Tag = musiclist(currenttrack + 1).ToString

            Track4.Image = Cover(musiclist(currenttrack + 2).ToString)
            Track4Name.Text = Path.GetFileNameWithoutExtension(musiclist(currenttrack + 2).ToString)
            Track4.Tag = musiclist(currenttrack + 2).ToString

            currenttrack = currenttrack - 1

        Else

        End If

    End Sub

    Private Sub ControlMusicBottom()
        If Musics.Focused = True Then
            If Not Track1Name.Text = "" Then
                Me.ActiveControl = Track1
            End If
        ElseIf Track1.Focused = True Then
            If Not Track2Name.Text = "" Then
                Me.ActiveControl = Track2
            End If
        ElseIf Track2.Focused = True Then
            If Not Track3Name.Text = "" Then
                Me.ActiveControl = Track3
            End If
        ElseIf Track3.Focused = True Then
            If Not Track4Name.Text = "" Then
                Me.ActiveControl = Track4
            End If
        ElseIf Track4.Focused = True Then
            BrowseNextMusic()
            If Not Track1Name.Text = "" Then
                Me.ActiveControl = Track1
            End If
        End If
    End Sub

    Private Sub ControlMusicTop()
        If Musics.Focused = True Then
            If Not Track4Name.Text = "" Then
                Me.ActiveControl = Track4
            End If

        ElseIf Track4.Focused = True Then

            If Not Track3Name.Text = "" Then
                Me.ActiveControl = Track3
            End If

        ElseIf Track3.Focused = True Then

            If Not Track2Name.Text = "" Then
                Me.ActiveControl = Track2
            End If

        ElseIf Track2.Focused = True Then

            If Not Track1Name.Text = "" Then
                Me.ActiveControl = Track1
            End If

        ElseIf Track1.Focused = True Then

            If currenttrack = 0 Then
                Me.ActiveControl = Musics
                currentcategory = "xmb"
            Else
                BrowseLastMusic()
                If Not Track4Name.Text = "" Then
                    Me.ActiveControl = Track4
                End If
            End If

        End If
    End Sub

#End Region

#Region "XMB-Video-Browsing"

    Private Sub Vid1_GotFocus(sender As Object, e As EventArgs) Handles Vid1.GotFocus
        DropShadowOfText(Vid1Text)
    End Sub

    Private Sub Vid2_GotFocus(sender As Object, e As EventArgs) Handles Vid2.GotFocus
        DropShadowOfText(Vid2Text)
    End Sub

    Private Sub Vid3_GotFocus(sender As Object, e As EventArgs) Handles Vid3.GotFocus
        DropShadowOfText(Vid3Text)
    End Sub

    Private Sub Vid4_GotFocus(sender As Object, e As EventArgs) Handles Vid4.GotFocus
        DropShadowOfText(Vid4Text)
    End Sub

    Private Sub YoutubeBox_GotFocus(sender As Object, e As EventArgs) Handles YoutubeBox.GotFocus
        DropShadowOfText(YoutubeTxt)
    End Sub

    Private Sub YoutubeBox_LostFocus(sender As Object, e As EventArgs) Handles YoutubeBox.LostFocus
        DropShadowOfText(YoutubeTxt)
    End Sub

    Private Sub Vid1_LostFocus(sender As Object, e As EventArgs) Handles Vid1.LostFocus
        DropShadowOfText(Vid1Text)
    End Sub

    Private Sub Vid2_LostFocus(sender As Object, e As EventArgs) Handles Vid2.LostFocus
        DropShadowOfText(Vid2Text)
    End Sub

    Private Sub Vid3_LostFocus(sender As Object, e As EventArgs) Handles Vid3.LostFocus
        DropShadowOfText(Vid3Text)
    End Sub

    Private Sub Vid4_LostFocus(sender As Object, e As EventArgs) Handles Vid4.LostFocus
        DropShadowOfText(Vid4Text)
    End Sub

    Public Sub LoadVideos()
        Dim videofiles() As String = getFiles(Functions.INI_ReadValueFromFile("Paths", "VideoPath", "", ".\media\paths.ini"), "*.avi|*.wmv|*.mp4|*.mpg|*.mpeg|*.mkv", SearchOption.AllDirectories)

        For Each Vids As String In videofiles
            videolist.Add(Vids)
        Next

        On Error Resume Next

        Vid1.Image = Image.FromFile(Thumbnail(videolist(0).ToString))
        Vid1Text.Text = Path.GetFileNameWithoutExtension(videolist(0).ToString)
        Vid1.Tag = videolist(0).ToString

        Vid2.Image = Image.FromFile(Thumbnail(videolist(1).ToString))
        Vid2Text.Text = Path.GetFileNameWithoutExtension(videolist(1).ToString)
        Vid2.Tag = videolist(1).ToString

        Vid3.Image = Image.FromFile(Thumbnail(videolist(2).ToString))
        Vid3Text.Text = Path.GetFileNameWithoutExtension(videolist(2).ToString)
        Vid3.Tag = videolist(2).ToString

        Vid4.Image = Image.FromFile(Thumbnail(videolist(3).ToString))
        Vid4Text.Text = Path.GetFileNameWithoutExtension(videolist(3).ToString)
        Vid4.Tag = videolist(3).ToString

        currentvideos = 3

    End Sub

    Private Sub BrowseNextVideos()

        On Error Resume Next

        If currentvideos + 4 < videolist.Count Then

            Vid1.Image = Image.FromFile(Thumbnail(videolist(currentvideos + 1).ToString))
            Vid1Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos + 1).ToString)
            Vid1.Tag = videolist(currentvideos + 1).ToString

            Vid2.Image = Image.FromFile(Thumbnail(videolist(currentvideos + 2).ToString))
            Vid2Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos + 2).ToString)
            Vid2.Tag = videolist(currentvideos + 2).ToString

            Vid3.Image = Image.FromFile(Thumbnail(videolist(currentvideos + 3).ToString))
            Vid3Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos + 3).ToString)
            Vid3.Tag = videolist(currentvideos + 3).ToString

            Vid4.Image = Image.FromFile(Thumbnail(videolist(currentvideos + 4).ToString))
            Vid4Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos + 4).ToString)
            Vid4.Tag = videolist(currentvideos + 4).ToString

            currentvideos = currentvideos + 4

        ElseIf currentvideos + 3 < videolist.Count Then

            Vid1.Image = Image.FromFile(Thumbnail(videolist(currentvideos + 1).ToString))
            Vid1Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos + 1).ToString)
            Vid1.Tag = videolist(currentvideos + 1).ToString

            Vid2.Image = Image.FromFile(Thumbnail(videolist(currentvideos + 2).ToString))
            Vid2Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos + 2).ToString)
            Vid2.Tag = videolist(currentvideos + 2).ToString

            Vid3.Image = Image.FromFile(Thumbnail(videolist(currentvideos + 3).ToString))
            Vid3Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos + 3).ToString)
            Vid3.Tag = videolist(currentvideos + 3).ToString

            Vid4.Image = Nothing
            Vid4Text.Text = ""
            Vid4.Tag = Nothing

            currentvideos = currentvideos + 3

        ElseIf currentvideos + 2 < videolist.Count Then

            Vid1.Image = Image.FromFile(Thumbnail(videolist(currentvideos + 1).ToString))
            Vid1Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos + 1).ToString)
            Vid1.Tag = videolist(currentvideos + 1).ToString

            Vid2.Image = Image.FromFile(Thumbnail(videolist(currentvideos + 2).ToString))
            Vid2Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos + 2).ToString)
            Vid2.Tag = videolist(currentvideos + 2).ToString

            Vid3.Image = Nothing
            Vid3Text.Text = ""
            Vid3.Tag = Nothing

            Vid4.Image = Nothing
            Vid4Text.Text = ""
            Vid4.Tag = Nothing

            currentvideos = currentvideos + 2

        ElseIf currentvideos + 1 < videolist.Count Then

            Vid1.Image = Image.FromFile(Thumbnail(videolist(currentvideos + 1).ToString))
            Vid1Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos + 1).ToString)
            Vid1.Tag = videolist(currentvideos + 1).ToString

            Vid2.Image = Nothing
            Vid2Text.Text = ""
            Vid2.Tag = Nothing

            Vid3.Image = Nothing
            Vid3Text.Text = ""
            Vid3.Tag = Nothing

            Vid4.Image = Nothing
            Vid4Text.Text = ""
            Vid4.Tag = Nothing

            currentvideos = currentvideos + 1

        Else

        End If

    End Sub

    Private Sub BrowseLastVideos()

        On Error Resume Next

        If currentvideos - 4 > -1 Then

            Vid1.Image = Image.FromFile(Thumbnail(videolist(currentvideos - 4).ToString))
            Vid1Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos - 4).ToString)
            Vid1.Tag = videolist(currentvideos - 4).ToString

            Vid2.Image = Image.FromFile(Thumbnail(videolist(currentvideos - 3).ToString))
            Vid2Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos - 3).ToString)
            Vid2.Tag = videolist(currentvideos - 3).ToString

            Vid3.Image = Image.FromFile(Thumbnail(videolist(currentvideos - 2).ToString))
            Vid3Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos - 2).ToString)
            Vid3.Tag = videolist(currentvideos - 2).ToString

            Vid4.Image = Image.FromFile(Thumbnail(videolist(currentvideos - 1).ToString))
            Vid4Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos - 1).ToString)
            Vid4.Tag = videolist(currentvideos - 1).ToString

            currentvideos = currentvideos - 4

        ElseIf currentvideos - 3 > -1 Then

            Vid1.Image = Image.FromFile(Thumbnail(videolist(currentvideos - 3).ToString))
            Vid1Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos - 3).ToString)
            Vid1.Tag = videolist(currentvideos - 3).ToString

            Vid2.Image = Image.FromFile(Thumbnail(videolist(currentvideos - 2).ToString))
            Vid2Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos - 2).ToString)
            Vid2.Tag = videolist(currentvideos - 2).ToString

            Vid3.Image = Image.FromFile(Thumbnail(videolist(currentvideos - 1).ToString))
            Vid3Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos - 1).ToString)
            Vid3.Tag = videolist(currentvideos - 1).ToString

            Vid4.Image = Image.FromFile(Thumbnail(videolist(currentvideos - 0).ToString))
            Vid4Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos - 0).ToString)
            Vid4.Tag = videolist(currentvideos - 0).ToString

            currentvideos = currentvideos - 3

        ElseIf currentvideos - 2 > -1 Then

            Vid1.Image = Image.FromFile(Thumbnail(videolist(currentvideos - 2).ToString))
            Vid1Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos - 2).ToString)
            Vid1.Tag = videolist(currentvideos - 2).ToString

            Vid2.Image = Image.FromFile(Thumbnail(videolist(currentvideos - 1).ToString))
            Vid2Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos - 1).ToString)
            Vid2.Tag = videolist(currentvideos - 1).ToString

            Vid3.Image = Image.FromFile(Thumbnail(videolist(currentvideos - 0).ToString))
            Vid3Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos - 0).ToString)
            Vid3.Tag = videolist(currentvideos - 0).ToString

            Vid4.Image = Image.FromFile(Thumbnail(videolist(currentvideos + 1).ToString))
            Vid4Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos + 1).ToString)
            Vid4.Tag = videolist(currentvideos + 1).ToString

            currentvideos = currentvideos - 2

        ElseIf currentvideos - 1 > -1 Then

            Vid1.Image = Image.FromFile(Thumbnail(videolist(currentvideos - 1).ToString))
            Vid1Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos - 1).ToString)
            Vid1.Tag = videolist(currentvideos - 1).ToString

            Vid2.Image = Image.FromFile(Thumbnail(videolist(currentvideos - 0).ToString))
            Vid2Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos - 0).ToString)
            Vid2.Tag = videolist(currentvideos - 0).ToString

            Vid3.Image = Image.FromFile(Thumbnail(videolist(currentvideos + 1).ToString))
            Vid3Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos + 1).ToString)
            Vid3.Tag = videolist(currentvideos + 1).ToString

            Vid4.Image = Image.FromFile(Thumbnail(videolist(currentvideos + 2).ToString))
            Vid4Text.Text = Path.GetFileNameWithoutExtension(videolist(currentvideos + 2).ToString)
            Vid4.Tag = videolist(currentvideos + 2).ToString

            currentvideos = currentvideos - 1

        End If

    End Sub

    Private Sub HideVideos()
        Vid1.Visible = False
        Vid2.Visible = False
        Vid3.Visible = False
        Vid4.Visible = False
        YoutubeBox.Visible = False

        Vid1Text.Visible = False
        Vid2Text.Visible = False
        Vid3Text.Visible = False
        Vid4Text.Visible = False
        YoutubeTxt.Visible = False

        currentcategory = "xmb"
    End Sub

    Private Sub ControlVideosBottom()
        If Videos.Focused = True Then
            Me.ActiveControl = YoutubeBox
        ElseIf YoutubeBox.Focused = True Then
            If Not Vid1Text.Text = "" Then
                Me.ActiveControl = Vid1
            End If
        ElseIf Vid1.Focused = True Then
            If Not Vid2Text.Text = "" Then
                Me.ActiveControl = Vid2
            End If
        ElseIf Vid2.Focused = True Then
            If Not Vid3Text.Text = "" Then
                Me.ActiveControl = Vid3
            End If
        ElseIf Vid3.Focused = True Then
            If Not Vid4Text.Text = "" Then
                Me.ActiveControl = Vid4
            End If
        ElseIf Vid4.Focused = True Then
            BrowseNextVideos()
            If Not Vid1Text.Text = "" Then
                Me.ActiveControl = Vid1
            End If
        End If
    End Sub

    Private Sub ControlVideosTop()
        If Videos.Focused = True Then
            If Not Vid4Text.Text = "" Then
                Me.ActiveControl = Vid4
            End If
        ElseIf Vid4.Focused = True Then
            If Not Vid3Text.Text = "" Then
                Me.ActiveControl = Vid3
            End If
        ElseIf Vid3.Focused = True Then
            If Not Vid2Text.Text = "" Then
                Me.ActiveControl = Vid2
            End If
        ElseIf Vid2.Focused = True Then
            If Not Vid1Text.Text = "" Then
                Me.ActiveControl = Vid1
            End If
        ElseIf Vid1.Focused = True Then

            If currentvideos = 0 Then
                Me.ActiveControl = YoutubeBox
            Else
                BrowseLastVideos()
                If Not Vid4Text.Text = "" Then
                    Me.ActiveControl = Vid4
                End If
            End If

        ElseIf YoutubeBox.Focused = True Then
            Me.ActiveControl = Videos
            currentcategory = "xmb"
        End If
    End Sub

#End Region

#Region "XMB-Pictures-Browsing"

    Private Sub Picture1_GotFocus(sender As Object, e As EventArgs) Handles Picture1.GotFocus
        DropShadowOfText(Picture1Text)
    End Sub

    Private Sub Picture2_GotFocus(sender As Object, e As EventArgs) Handles Picture2.GotFocus
        DropShadowOfText(Picture2Text)
    End Sub

    Private Sub Picture3_GotFocus(sender As Object, e As EventArgs) Handles Picture3.GotFocus
        DropShadowOfText(Picture3Text)
    End Sub

    Private Sub Picture4_GotFocus(sender As Object, e As EventArgs) Handles Picture4.GotFocus
        DropShadowOfText(Picture4Text)
    End Sub

    Private Sub Picture1_LostFocus(sender As Object, e As EventArgs) Handles Picture1.LostFocus
        DropShadowOfText(Picture1Text)
    End Sub

    Private Sub Picture2_LostFocus(sender As Object, e As EventArgs) Handles Picture2.LostFocus
        DropShadowOfText(Picture2Text)
    End Sub

    Private Sub Picture3_LostFocus(sender As Object, e As EventArgs) Handles Picture3.LostFocus
        DropShadowOfText(Picture3Text)
    End Sub

    Private Sub Picture4_LostFocus(sender As Object, e As EventArgs) Handles Picture4.LostFocus
        DropShadowOfText(Picture4Text)
    End Sub

    Public Sub LoadPictures()
        Dim picturefiles() As String = getFiles(Functions.INI_ReadValueFromFile("Paths", "PicturesPath", "", ".\media\paths.ini"), "*.jpg|*.jpeg|*.png|*.gif", SearchOption.AllDirectories)

        For Each Pics As String In picturefiles
            picturelist.Add(Pics)
        Next

        On Error Resume Next

        Picture1.Image = Image.FromFile(picturelist(0).ToString)
        Picture1Text.Text = Path.GetFileNameWithoutExtension(picturelist(0).ToString)
        Picture1.Tag = picturelist(0).ToString + ";0"

        Picture2.Image = Image.FromFile(picturelist(1).ToString)
        Picture2Text.Text = Path.GetFileNameWithoutExtension(picturelist(1).ToString)
        Picture2.Tag = picturelist(1).ToString + ";1"

        Picture3.Image = Image.FromFile(picturelist(2).ToString)
        Picture3Text.Text = Path.GetFileNameWithoutExtension(picturelist(2).ToString)
        Picture3.Tag = picturelist(2).ToString + ";2"

        Picture4.Image = Image.FromFile(picturelist(3).ToString)
        Picture4Text.Text = Path.GetFileNameWithoutExtension(picturelist(3).ToString)
        Picture4.Tag = picturelist(3).ToString + ";3"

        currentpictures = 3

    End Sub

    Private Sub BrowseNextPictures()

        On Error Resume Next

        If currentpictures + 4 < picturelist.Count Then

            Picture1.Image = Image.FromFile(picturelist(currentpictures + 1).ToString)
            Picture1Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures + 1).ToString)
            Picture1.Tag = picturelist(currentpictures + 1).ToString + ";" + (currentpictures + 1).ToString

            Picture2.Image = Image.FromFile(picturelist(currentpictures + 2).ToString)
            Picture2Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures + 2).ToString)
            Picture2.Tag = picturelist(currentpictures + 2).ToString + ";" + (currentpictures + 2).ToString

            Picture3.Image = Image.FromFile(picturelist(currentpictures + 3).ToString)
            Picture3Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures + 3).ToString)
            Picture3.Tag = picturelist(currentpictures + 3).ToString + ";" + (currentpictures + 3).ToString

            Picture4.Image = Image.FromFile(picturelist(currentpictures + 4).ToString)
            Picture4Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures + 4).ToString)
            Picture4.Tag = picturelist(currentpictures + 4).ToString + ";" + (currentpictures + 4).ToString

            currentpictures = currentpictures + 4

        ElseIf currentpictures + 4 < picturelist.Count Then

            Picture1.Image = Image.FromFile(picturelist(currentpictures + 1).ToString)
            Picture1Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures + 1).ToString)
            Picture1.Tag = picturelist(currentpictures + 1).ToString + ";" + (currentpictures + 1).ToString

            Picture2.Image = Image.FromFile(picturelist(currentpictures + 2).ToString)
            Picture2Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures + 2).ToString)
            Picture2.Tag = picturelist(currentpictures + 2).ToString + ";" + (currentpictures + 2).ToString

            Picture3.Image = Image.FromFile(picturelist(currentpictures + 3).ToString)
            Picture3Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures + 3).ToString)
            Picture3.Tag = picturelist(currentpictures + 3).ToString + ";" + (currentpictures + 3).ToString

            Picture4.Image = Nothing
            Picture4Text.Text = ""
            Picture4.Tag = Nothing

            currentpictures = currentpictures + 3

        ElseIf currentpictures + 4 < picturelist.Count Then

            Picture1.Image = Image.FromFile(picturelist(currentpictures + 1).ToString)
            Picture1Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures + 1).ToString)
            Picture1.Tag = picturelist(currentpictures + 1).ToString + ";" + (currentpictures + 1).ToString

            Picture2.Image = Image.FromFile(picturelist(currentpictures + 2).ToString)
            Picture2Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures + 2).ToString)
            Picture2.Tag = picturelist(currentpictures + 2).ToString + ";" + (currentpictures + 2).ToString

            Picture3.Image = Nothing
            Picture3Text.Text = ""
            Picture3.Tag = Nothing

            Picture4.Image = Nothing
            Picture4Text.Text = ""
            Picture4.Tag = Nothing

            currentpictures = currentpictures + 2

        ElseIf currentpictures + 4 < picturelist.Count Then

            Picture1.Image = Image.FromFile(picturelist(currentpictures + 1).ToString)
            Picture1Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures + 1).ToString)
            Picture1.Tag = picturelist(currentpictures + 1).ToString + ";" + (currentpictures + 1).ToString

            Picture2.Image = Nothing
            Picture2Text.Text = ""
            Picture2.Tag = Nothing

            Picture3.Image = Nothing
            Picture3Text.Text = ""
            Picture3.Tag = Nothing

            Picture4.Image = Nothing
            Picture4Text.Text = ""
            Picture4.Tag = Nothing

            currentpictures = currentpictures + 1

        Else

        End If

    End Sub

    Private Sub BrowseLastPictures()

        On Error Resume Next

        If currentpictures - 4 > -1 Then

            Picture1.Image = Image.FromFile(picturelist(currentpictures - 4).ToString)
            Picture1Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures - 4).ToString)
            Picture1.Tag = picturelist(currentpictures - 4).ToString + ";" + (currentpictures - 4).ToString

            Picture2.Image = Image.FromFile(picturelist(currentpictures - 3).ToString)
            Picture2Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures - 3).ToString)
            Picture2.Tag = picturelist(currentpictures - 3).ToString + ";" + (currentpictures - 3).ToString

            Picture3.Image = Image.FromFile(picturelist(currentpictures - 2).ToString)
            Picture3Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures - 2).ToString)
            Picture3.Tag = picturelist(currentpictures - 2).ToString + ";" + (currentpictures - 2).ToString

            Picture4.Image = Image.FromFile(picturelist(currentpictures - 1).ToString)
            Picture4Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures - 1).ToString)
            Picture4.Tag = picturelist(currentpictures - 1).ToString + ";" + (currentpictures - 1).ToString

            currentpictures = currentpictures - 4

        ElseIf currentpictures - 3 > -1 Then

            Picture1.Image = Image.FromFile(picturelist(currentpictures - 3).ToString)
            Picture1Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures - 3).ToString)
            Picture1.Tag = picturelist(currentpictures - 3).ToString + ";" + (currentpictures - 3).ToString

            Picture2.Image = Image.FromFile(picturelist(currentpictures - 2).ToString)
            Picture2Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures - 2).ToString)
            Picture2.Tag = picturelist(currentpictures - 2).ToString + ";" + (currentpictures - 2).ToString

            Picture3.Image = Image.FromFile(picturelist(currentpictures - 1).ToString)
            Picture3Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures - 1).ToString)
            Picture3.Tag = picturelist(currentpictures - 1).ToString + ";" + (currentpictures - 1).ToString

            Picture4.Image = Image.FromFile(picturelist(currentpictures - 0).ToString)
            Picture4Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures - 0).ToString)
            Picture4.Tag = picturelist(currentpictures - 0).ToString + ";" + (currentpictures - 0).ToString

            currentpictures = currentpictures - 3

        ElseIf currentpictures - 2 > -1 Then

            Picture1.Image = Image.FromFile(picturelist(currentpictures - 2).ToString)
            Picture1Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures - 2).ToString)
            Picture1.Tag = picturelist(currentpictures - 2).ToString + ";" + (currentpictures - 2).ToString

            Picture2.Image = Image.FromFile(picturelist(currentpictures - 1).ToString)
            Picture2Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures - 1).ToString)
            Picture2.Tag = picturelist(currentpictures - 1).ToString + ";" + (currentpictures - 1).ToString

            Picture3.Image = Image.FromFile(picturelist(currentpictures - 0).ToString)
            Picture3Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures - 0).ToString)
            Picture3.Tag = picturelist(currentpictures - 0).ToString + ";" + (currentpictures - 0).ToString

            Picture4.Image = Image.FromFile(picturelist(currentpictures + 1).ToString)
            Picture4Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures + 1).ToString)
            Picture4.Tag = picturelist(currentpictures + 1).ToString + ";" + (currentpictures + 1).ToString

            currentpictures = currentpictures - 2

        ElseIf currentpictures - 1 > -1 Then

            Picture1.Image = Image.FromFile(picturelist(currentpictures - 1).ToString)
            Picture1Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures - 1).ToString)
            Picture1.Tag = picturelist(currentpictures - 1).ToString + ";" + (currentpictures - 1).ToString

            Picture2.Image = Image.FromFile(picturelist(currentpictures - 0).ToString)
            Picture2Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures - 0).ToString)
            Picture2.Tag = picturelist(currentpictures - 0).ToString + ";" + (currentpictures - 0).ToString

            Picture3.Image = Image.FromFile(picturelist(currentpictures + 1).ToString)
            Picture3Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures + 1).ToString)
            Picture3.Tag = picturelist(currentpictures + 1).ToString + ";" + (currentpictures + 1).ToString

            Picture4.Image = Image.FromFile(picturelist(currentpictures + 2).ToString)
            Picture4Text.Text = Path.GetFileNameWithoutExtension(picturelist(currentpictures + 2).ToString)
            Picture4.Tag = picturelist(currentpictures + 2).ToString + ";" + (currentpictures + 2).ToString

            currentpictures = currentpictures - 1

        End If

    End Sub

    Private Sub HidePictures()
        Picture1.Visible = False
        Picture2.Visible = False
        Picture3.Visible = False
        Picture4.Visible = False

        Picture1Text.Visible = False
        Picture2Text.Visible = False
        Picture3Text.Visible = False
        Picture4Text.Visible = False

        currentcategory = "xmb"
    End Sub

    Private Sub ControlPicturesBottom()
        If Pictures.Focused = True Then
            If Not Picture1Text.Text = "" Then
                Me.ActiveControl = Picture1
            End If
        ElseIf Picture1.Focused = True Then
            If Not Picture2Text.Text = "" Then
                Me.ActiveControl = Picture2
            End If
        ElseIf Picture2.Focused = True Then
            If Not Picture3Text.Text = "" Then
                Me.ActiveControl = Picture3
            End If
        ElseIf Picture3.Focused = True Then
            If Not Picture4Text.Text = "" Then
                Me.ActiveControl = Picture4
            End If
        ElseIf Picture4.Focused = True Then
            BrowseNextPictures()
            Me.ActiveControl = Picture1
        End If
    End Sub

    Private Sub ControlPicturesTop()
        If Pictures.Focused = True Then
            If Not Picture4Text.Text = "" Then
                Me.ActiveControl = Picture4
            End If
        ElseIf Picture4.Focused = True Then
            If Not Picture3Text.Text = "" Then
                Me.ActiveControl = Picture3
            End If
        ElseIf Picture3.Focused = True Then
            If Not Picture2Text.Text = "" Then
                Me.ActiveControl = Picture2
            End If
        ElseIf Picture2.Focused = True Then
            If Not Picture1Text.Text = "" Then
                Me.ActiveControl = Picture1
            End If
        ElseIf Picture1.Focused = True Then
            If currentpictures = 0 Then
                Me.ActiveControl = Pictures
                currentcategory = "xmb"
            Else
                BrowseLastPictures()
                If Not Picture4Text.Text = "" Then
                    Me.ActiveControl = Picture4
                End If
            End If
        End If
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

#Region "XMB-Friends-Browsing"

    Private Sub UserAvatar_GotFocus(sender As Object, e As EventArgs) Handles UserAvatar.GotFocus
        DropShadowOfText(UserLoginName)
        DropShadowOfText(UserDescr)
    End Sub

    Private Sub UserAvatar_LostFocus(sender As Object, e As EventArgs) Handles UserAvatar.LostFocus
        DropShadowOfText(UserLoginName)
        DropShadowOfText(UserDescr)
    End Sub

    Private Sub Friend1Ava_GotFocus(sender As Object, e As EventArgs) Handles Friend1Ava.GotFocus
        DropShadowOfText(Friend1Name)
        DropShadowOfText(Friend1Status)
    End Sub

    Private Sub Friend2Ava_GotFocus(sender As Object, e As EventArgs) Handles Friend2Ava.GotFocus
        DropShadowOfText(Friend2Name)
        DropShadowOfText(Friend2Status)
    End Sub

    Private Sub Friend3Ava_GotFocus(sender As Object, e As EventArgs) Handles Friend3Ava.GotFocus
        DropShadowOfText(Friend3Name)
        DropShadowOfText(Friend3Status)
    End Sub

    Private Sub Friend1Ava_LostFocus(sender As Object, e As EventArgs) Handles Friend1Ava.LostFocus
        DropShadowOfText(Friend1Name)
        DropShadowOfText(Friend1Status)
    End Sub

    Private Sub Friend2Ava_LostFocus(sender As Object, e As EventArgs) Handles Friend2Ava.LostFocus
        DropShadowOfText(Friend2Name)
        DropShadowOfText(Friend2Status)
    End Sub

    Private Sub Friend3Ava_LostFocus(sender As Object, e As EventArgs) Handles Friend3Ava.LostFocus
        DropShadowOfText(Friend3Name)
        DropShadowOfText(Friend3Status)
    End Sub

    Private Sub AddFriend_GotFocus(sender As Object, e As EventArgs) Handles AddFriend.GotFocus
        DropShadowOfText(AddFriendTxt)
        AddFriend.Image = My.Resources.new_user_h
    End Sub

    Private Sub AddFriend_LostFocus(sender As Object, e As EventArgs) Handles AddFriend.LostFocus
        DropShadowOfText(AddFriendTxt)
        AddFriend.Image = My.Resources.Icons_11
    End Sub

    Private Sub HideFriends()
        UserAvatar.Visible = False
        UserLoginName.Visible = False
        UserDescr.Visible = False

        Friend1Ava.Visible = False
        Friend1Name.Visible = False
        Friend1Status.Visible = False

        Friend2Ava.Visible = False
        Friend2Name.Visible = False
        Friend2Status.Visible = False

        Friend3Ava.Visible = False
        Friend3Name.Visible = False
        Friend3Status.Visible = False

        AddFriend.Visible = False
        AddFriendTxt.Visible = False

        currentcategory = "xmb"
    End Sub

    Private Sub ControlFriendsBottom()
        If Friends.Focused = True Then
            Me.ActiveControl = UserAvatar
        ElseIf UserAvatar.Focused = True Then
            Me.ActiveControl = AddFriend
        ElseIf AddFriend.Focused = True Then
            Me.ActiveControl = Friend1Ava
        ElseIf Friend1Ava.Focused = True Then
            Me.ActiveControl = Friend2Ava
        ElseIf Friend2Ava.Focused = True Then
            Me.ActiveControl = Friend3Ava
        ElseIf Friend3Ava.Focused = True Then
            Me.ActiveControl = UserAvatar
            'currentcategory = "xmb"
        End If
    End Sub

    Private Sub ControlFriendsTop()
        If Friends.Focused = True Then
            Me.ActiveControl = Friend3Ava
        ElseIf Friend3Ava.Focused = True Then
            Me.ActiveControl = Friend2Ava
        ElseIf Friend2Ava.Focused = True Then
            Me.ActiveControl = Friend1Ava
        ElseIf Friend1Ava.Focused = True Then
            Me.ActiveControl = AddFriend
        ElseIf AddFriend.Focused = True Then
            Me.ActiveControl = UserAvatar
        ElseIf UserAvatar.Focused = True Then
            Me.ActiveControl = Friends
            currentcategory = "xmb"
        End If
    End Sub

#End Region

    Private Sub XMB_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ForceLogoff()
        StartUpHook.Close()
    End Sub

    Private Sub XMB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1920, 1080)
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
        LoadPS2Games()
        LoadRetroGames()
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

    Private Sub MediaPlayer_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles MediaPlayer.PlayStateChange
        If e.newState = MediaPlayer.playState.wmppsMediaEnded Then
            StartGame(GameSect, GameID, GameFormat)

            Me.Controls.Remove(MediaPlayer)
            Me.ActiveControl = Home
        End If
    End Sub

End Class
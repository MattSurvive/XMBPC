Imports System.IO

Public Class mfcReadID3v2Tag

    Private Structure mcsFrame
        Dim Tag As String
        Dim Flag As Integer
        Dim Size As Integer
        Dim Data1 As Byte()
        Dim Data2 As String
    End Structure

    Public Shared Function ReadID3v2Tag(ByVal sFilename As String) As mcTrack
        Try

            Dim oFS As FileStream
            Dim baHeader(15) As Byte
            Dim oTrack As New mcTrack

            oTrack.Filename = sFilename

            oFS = New FileStream(sFilename, FileMode.Open)

            oFS.Read(baHeader, 0, 10)

            If (baHeader(0) = &H49) And (baHeader(1) = &H44) And (baHeader(2) = &H33) Then

                Dim oFrame As mcsFrame

                oFrame = GetFrame(oFS)
                Do While Not IsNothing(oFrame.Tag)
                    Select Case oFrame.Tag
                        Case "TIT2" : oTrack.Track = oFrame.Data2    ' Song Title
                        Case "TPE1" : oTrack.Artist = oFrame.Data2    ' Artist
                        Case "TALB" : oTrack.Album = oFrame.Data2    ' Album
                        Case "TRCK" : oTrack.CDTrack = CInt(oFrame.Data2.Replace("/", "")) ' CD Track number
                        Case "TCON" : oTrack.Genre = oFrame.Data2    ' Genre Description
                    End Select

                    oFrame = New mcsFrame()
                    oFrame = GetFrame(oFS)
                Loop
            End If
            ReadID3v2Tag = oTrack

            oFS.Close()

            ' --------------------------------------------------
        Catch oError As Exception
            ReadID3v2Tag = Nothing
        End Try

    End Function

    Private Shared Function GetFrame(ByVal oFile As Stream) As mcsFrame
        Try

            Dim oFrame As New mcsFrame()
            Dim baFrame() As Byte
            Dim oEncoding As New System.Text.ASCIIEncoding()

            ReDim baFrame(5)

            ' Pull frame name
            oFile.Read(baFrame, 0, 4)
            oFrame.Tag = oEncoding.GetString(baFrame)

            If baFrame(0) <> 0 Then
                oFrame.Tag = oFrame.Tag.Substring(0, 4).Trim

                ' Get 4 bytes for frame size
                oFile.Read(baFrame, 0, 4)
                oFrame.Size = (65536 * (baFrame(0) * 256 + baFrame(1))) + (baFrame(2) * 256 + baFrame(3))

                ' Skip padding
                oFile.Read(baFrame, 0, 3)

                If oFrame.Size > 0 Then
                    ReDim baFrame(oFrame.Size + 1)

                    oFile.Read(baFrame, 0, oFrame.Size - 1)
                    oFrame.Data1 = baFrame

                    If oFrame.Tag.Substring(0, 1) = "T" Then
                        oFrame.Data2 = oEncoding.GetString(baFrame).Trim.Replace(Chr(0), "")
                    End If
                End If

                GetFrame = oFrame
            Else
                GetFrame = Nothing
            End If

            ' --------------------------------------------------
        Catch oError As Exception
            GetFrame = Nothing
        End Try

    End Function

End Class
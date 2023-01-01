Public Class mcTrack

#Region "Public Declarations"

    Private psAlbum As String = ""            ' dbo.Album.Album_Name
    Private piAlbumID As Integer = 0        ' dbo.Album.Album_ID PK
    Private psArtist As String = ""            ' dbo.Artist.Artist_Name
    Private piArtistID As Integer = 0        ' dbo.Artist.Artist_ID PK
    Private pbBookmarked As Boolean = False
    Private piCDTrack As Integer = 0
    Private psFileName As String = ""
    Private psGenre As String = ""
    Private piID As Integer = 0                ' dbo.Tracks.Track_ID PK
    Private piIndex As Integer = -1            ' Listview index (To enable playing tracks in order regardless of listview's item focus, selections, ect)
    Private piMaxVolume As Integer = 100    ' To allow per-track volume so a particularly loud track can be kicked down a few decibles.
    Private pbPlayed As Boolean = False
    Private psPlayedOn As String = ""
    Private piPlayCount As Integer = 0
    Private psTrack As String = ""

#Region "-- Properties"

    Public Property Album() As String
        <DebuggerStepThrough()> _
        Get
            Album = psAlbum
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal sAlbum As String)
            psAlbum = sAlbum
        End Set
    End Property
    Public Property AlbumID() As Integer
        <DebuggerStepThrough()> _
        Get
            AlbumID = piAlbumID
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal iAlbumID As Integer)
            piAlbumID = iAlbumID
        End Set
    End Property
    Public Property Artist() As String
        <DebuggerStepThrough()> _
        Get
            Artist = psArtist
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal sArtist As String)
            psArtist = sArtist
        End Set
    End Property
    Public Property ArtistID() As Integer
        <DebuggerStepThrough()> _
        Get
            ArtistID = piArtistID
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal iArtistID As Integer)
            piArtistID = iArtistID
        End Set
    End Property
    Public Property Bookmarked() As Boolean
        <DebuggerStepThrough()> _
        Get
            Bookmarked = pbBookmarked
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal bBookmarked As Boolean)
            pbBookmarked = bBookmarked
        End Set
    End Property
    Public Property CDTrack() As Integer
        <DebuggerStepThrough()> _
        Get
            CDTrack = piCDTrack
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal iCDTrack As Integer)
            piCDTrack = iCDTrack
        End Set
    End Property
    Public Property Filename() As String
        <DebuggerStepThrough()> _
        Get
            Filename = psFileName
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal sFileName As String)
            psFileName = sFileName
        End Set
    End Property
    Public Property Genre() As String
        <DebuggerStepThrough()> _
        Get
            Genre = psGenre
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal sGenre As String)
            psGenre = sGenre
        End Set
    End Property
    Public Property ID() As Integer
        <DebuggerStepThrough()> _
        Get
            Return piID
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal iID As Integer)
            piID = iID
        End Set
    End Property
    Public Property Index() As Integer
        <DebuggerStepThrough()> _
        Get
            Index = piIndex
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal iIndex As Integer)
            piIndex = iIndex
        End Set
    End Property
    Public Property MaxVolume() As Integer
        <DebuggerStepThrough()> _
        Get
            MaxVolume = piMaxVolume
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal iMaxVolume As Integer)
            piMaxVolume = iMaxVolume
        End Set
    End Property

    Public Property PlayCount() As Integer
        <DebuggerStepThrough()> _
        Get
            PlayCount = piPlayCount
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal iPlayCount As Integer)
            piPlayCount = iPlayCount
        End Set
    End Property

    Public Property Played() As Boolean
        <DebuggerStepThrough()> _
        Get
            Played = pbPlayed
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal bPlayed As Boolean)
            pbPlayed = bPlayed
        End Set
    End Property

    Public Property PlayedOn() As String
        <DebuggerStepThrough()> _
        Get
            PlayedOn = psPlayedOn
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal sPlayedOn As String)
            psPlayedOn = sPlayedOn
        End Set
    End Property

    Public Property Track() As String
        <DebuggerStepThrough()> _
        Get
            Track = psTrack
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal sTrack As String)
            psTrack = sTrack
        End Set
    End Property

#End Region

    Public Sub New()
        MyBase.New()
        piID = -1
    End Sub

#End Region

End Class
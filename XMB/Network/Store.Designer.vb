<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Store
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Store))
        Me.HomeTxt = New gLabel.gLabel()
        Me.SNESTxt = New gLabel.gLabel()
        Me.NESTxt = New gLabel.gLabel()
        Me.GBATxt = New gLabel.gLabel()
        Me.SEGATxt = New gLabel.gLabel()
        Me.GBCTxt = New gLabel.gLabel()
        Me.UserAvatar = New System.Windows.Forms.PictureBox()
        Me.CategoryTxt = New gLabel.gLabel()
        Me.UserName = New gLabel.gLabel()
        Me.UserStatus = New gLabel.gLabel()
        Me.ControllerTimer = New System.Windows.Forms.Timer(Me.components)
        Me.KeyboardTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StoreVer = New gLabel.gLabel()
        Me.Game1 = New System.Windows.Forms.PictureBox()
        Me.Game2 = New System.Windows.Forms.PictureBox()
        Me.Game3 = New System.Windows.Forms.PictureBox()
        Me.Game7 = New System.Windows.Forms.PictureBox()
        Me.Game6 = New System.Windows.Forms.PictureBox()
        Me.Game5 = New System.Windows.Forms.PictureBox()
        Me.Game11 = New System.Windows.Forms.PictureBox()
        Me.Game10 = New System.Windows.Forms.PictureBox()
        Me.Game9 = New System.Windows.Forms.PictureBox()
        Me.Game12 = New System.Windows.Forms.PictureBox()
        Me.Game8 = New System.Windows.Forms.PictureBox()
        Me.Game4 = New System.Windows.Forms.PictureBox()
        Me.Game1Txt = New gLabel.gLabel()
        Me.Game2Txt = New gLabel.gLabel()
        Me.Game4Txt = New gLabel.gLabel()
        Me.Game3Txt = New gLabel.gLabel()
        Me.Game8Txt = New gLabel.gLabel()
        Me.Game7Txt = New gLabel.gLabel()
        Me.Game6Txt = New gLabel.gLabel()
        Me.Game5Txt = New gLabel.gLabel()
        Me.Game12Txt = New gLabel.gLabel()
        Me.Game11Txt = New gLabel.gLabel()
        Me.Game10Txt = New gLabel.gLabel()
        Me.Game9Txt = New gLabel.gLabel()
        Me.InfoLab = New gLabel.gLabel()
        Me.BrowseNext = New System.Windows.Forms.PictureBox()
        Me.BrowseLast = New System.Windows.Forms.PictureBox()
        Me.AddonsToolsTxt = New gLabel.gLabel()
        CType(Me.UserAvatar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Game1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Game2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Game3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Game7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Game6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Game5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Game11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Game10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Game9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Game12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Game8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Game4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BrowseNext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BrowseLast, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HomeTxt
        '
        Me.HomeTxt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.HomeTxt.BackColor = System.Drawing.Color.Transparent
        Me.HomeTxt.BorderColor = System.Drawing.Color.Transparent
        Me.HomeTxt.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HomeTxt.ForeColor = System.Drawing.Color.White
        Me.HomeTxt.GlowColor = System.Drawing.Color.Black
        Me.HomeTxt.GlowState = False
        Me.HomeTxt.Location = New System.Drawing.Point(12, 237)
        Me.HomeTxt.Name = "HomeTxt"
        Me.HomeTxt.Size = New System.Drawing.Size(191, 44)
        Me.HomeTxt.TabIndex = 1
        Me.HomeTxt.Text = "Home"
        Me.HomeTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SNESTxt
        '
        Me.SNESTxt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.SNESTxt.BackColor = System.Drawing.Color.Transparent
        Me.SNESTxt.BorderColor = System.Drawing.Color.Transparent
        Me.SNESTxt.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SNESTxt.ForeColor = System.Drawing.Color.White
        Me.SNESTxt.GlowColor = System.Drawing.Color.Black
        Me.SNESTxt.GlowState = False
        Me.SNESTxt.Location = New System.Drawing.Point(12, 369)
        Me.SNESTxt.Name = "SNESTxt"
        Me.SNESTxt.Size = New System.Drawing.Size(191, 44)
        Me.SNESTxt.TabIndex = 2
        Me.SNESTxt.Text = "SNES Roms"
        Me.SNESTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NESTxt
        '
        Me.NESTxt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.NESTxt.BackColor = System.Drawing.Color.Transparent
        Me.NESTxt.BorderColor = System.Drawing.Color.Transparent
        Me.NESTxt.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NESTxt.ForeColor = System.Drawing.Color.White
        Me.NESTxt.GlowColor = System.Drawing.Color.Black
        Me.NESTxt.GlowState = False
        Me.NESTxt.Location = New System.Drawing.Point(12, 413)
        Me.NESTxt.Name = "NESTxt"
        Me.NESTxt.Size = New System.Drawing.Size(191, 44)
        Me.NESTxt.TabIndex = 3
        Me.NESTxt.Text = "NES Roms"
        Me.NESTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GBATxt
        '
        Me.GBATxt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.GBATxt.BackColor = System.Drawing.Color.Transparent
        Me.GBATxt.BorderColor = System.Drawing.Color.Transparent
        Me.GBATxt.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBATxt.ForeColor = System.Drawing.Color.White
        Me.GBATxt.GlowColor = System.Drawing.Color.Black
        Me.GBATxt.GlowState = False
        Me.GBATxt.Location = New System.Drawing.Point(12, 281)
        Me.GBATxt.Name = "GBATxt"
        Me.GBATxt.Size = New System.Drawing.Size(191, 44)
        Me.GBATxt.TabIndex = 5
        Me.GBATxt.Text = "GBA Roms"
        Me.GBATxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SEGATxt
        '
        Me.SEGATxt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.SEGATxt.BackColor = System.Drawing.Color.Transparent
        Me.SEGATxt.BorderColor = System.Drawing.Color.Transparent
        Me.SEGATxt.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SEGATxt.ForeColor = System.Drawing.Color.White
        Me.SEGATxt.GlowColor = System.Drawing.Color.Black
        Me.SEGATxt.GlowState = False
        Me.SEGATxt.Location = New System.Drawing.Point(12, 457)
        Me.SEGATxt.Name = "SEGATxt"
        Me.SEGATxt.Size = New System.Drawing.Size(191, 44)
        Me.SEGATxt.TabIndex = 4
        Me.SEGATxt.Text = "SEGA Roms"
        Me.SEGATxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GBCTxt
        '
        Me.GBCTxt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.GBCTxt.BackColor = System.Drawing.Color.Transparent
        Me.GBCTxt.BorderColor = System.Drawing.Color.Transparent
        Me.GBCTxt.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBCTxt.ForeColor = System.Drawing.Color.White
        Me.GBCTxt.GlowColor = System.Drawing.Color.Black
        Me.GBCTxt.GlowState = False
        Me.GBCTxt.Location = New System.Drawing.Point(12, 325)
        Me.GBCTxt.Name = "GBCTxt"
        Me.GBCTxt.Size = New System.Drawing.Size(191, 44)
        Me.GBCTxt.TabIndex = 6
        Me.GBCTxt.Text = "GBC Roms"
        Me.GBCTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UserAvatar
        '
        Me.UserAvatar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UserAvatar.BackColor = System.Drawing.Color.Transparent
        Me.UserAvatar.Image = Global.XMBPC.My.Resources.Resources.user
        Me.UserAvatar.Location = New System.Drawing.Point(1446, 12)
        Me.UserAvatar.Name = "UserAvatar"
        Me.UserAvatar.Size = New System.Drawing.Size(96, 96)
        Me.UserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.UserAvatar.TabIndex = 7
        Me.UserAvatar.TabStop = False
        '
        'CategoryTxt
        '
        Me.CategoryTxt.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.CategoryTxt.BackColor = System.Drawing.Color.Transparent
        Me.CategoryTxt.BorderColor = System.Drawing.Color.Transparent
        Me.CategoryTxt.Font = New System.Drawing.Font("Arial", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CategoryTxt.ForeColor = System.Drawing.Color.White
        Me.CategoryTxt.GlowColor = System.Drawing.Color.Black
        Me.CategoryTxt.Location = New System.Drawing.Point(315, 12)
        Me.CategoryTxt.Name = "CategoryTxt"
        Me.CategoryTxt.Size = New System.Drawing.Size(988, 87)
        Me.CategoryTxt.TabIndex = 8
        Me.CategoryTxt.Text = "Welcome"
        '
        'UserName
        '
        Me.UserName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UserName.BackColor = System.Drawing.Color.Transparent
        Me.UserName.BorderColor = System.Drawing.Color.Transparent
        Me.UserName.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserName.ForeColor = System.Drawing.Color.White
        Me.UserName.GlowColor = System.Drawing.Color.Black
        Me.UserName.Location = New System.Drawing.Point(1174, 28)
        Me.UserName.Name = "UserName"
        Me.UserName.Size = New System.Drawing.Size(266, 28)
        Me.UserName.TabIndex = 9
        Me.UserName.Text = "SvenGDK"
        Me.UserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UserStatus
        '
        Me.UserStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UserStatus.BackColor = System.Drawing.Color.Transparent
        Me.UserStatus.BorderColor = System.Drawing.Color.Transparent
        Me.UserStatus.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserStatus.ForeColor = System.Drawing.Color.White
        Me.UserStatus.GlowColor = System.Drawing.Color.Black
        Me.UserStatus.Location = New System.Drawing.Point(1174, 56)
        Me.UserStatus.Name = "UserStatus"
        Me.UserStatus.Size = New System.Drawing.Size(266, 27)
        Me.UserStatus.TabIndex = 10
        Me.UserStatus.Text = "Online"
        Me.UserStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ControllerTimer
        '
        '
        'KeyboardTimer
        '
        '
        'StoreVer
        '
        Me.StoreVer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StoreVer.BackColor = System.Drawing.Color.Transparent
        Me.StoreVer.BorderColor = System.Drawing.Color.Transparent
        Me.StoreVer.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StoreVer.ForeColor = System.Drawing.Color.White
        Me.StoreVer.GlowColor = System.Drawing.Color.Black
        Me.StoreVer.Location = New System.Drawing.Point(1301, 778)
        Me.StoreVer.Name = "StoreVer"
        Me.StoreVer.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.StoreVer.ShadowState = True
        Me.StoreVer.Size = New System.Drawing.Size(253, 31)
        Me.StoreVer.TabIndex = 12
        Me.StoreVer.Text = "[XMBPC Store v0.0.1]"
        '
        'Game1
        '
        Me.Game1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game1.BackColor = System.Drawing.Color.Transparent
        Me.Game1.Image = Global.XMBPC.My.Resources.Resources.gba
        Me.Game1.Location = New System.Drawing.Point(452, 152)
        Me.Game1.Name = "Game1"
        Me.Game1.Size = New System.Drawing.Size(72, 72)
        Me.Game1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Game1.TabIndex = 13
        Me.Game1.TabStop = False
        Me.Game1.Visible = False
        '
        'Game2
        '
        Me.Game2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game2.BackColor = System.Drawing.Color.Transparent
        Me.Game2.Image = CType(resources.GetObject("Game2.Image"), System.Drawing.Image)
        Me.Game2.Location = New System.Drawing.Point(712, 152)
        Me.Game2.Name = "Game2"
        Me.Game2.Size = New System.Drawing.Size(72, 72)
        Me.Game2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Game2.TabIndex = 14
        Me.Game2.TabStop = False
        Me.Game2.Visible = False
        '
        'Game3
        '
        Me.Game3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game3.BackColor = System.Drawing.Color.Transparent
        Me.Game3.Image = CType(resources.GetObject("Game3.Image"), System.Drawing.Image)
        Me.Game3.Location = New System.Drawing.Point(960, 152)
        Me.Game3.Name = "Game3"
        Me.Game3.Size = New System.Drawing.Size(72, 72)
        Me.Game3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Game3.TabIndex = 15
        Me.Game3.TabStop = False
        Me.Game3.Visible = False
        '
        'Game7
        '
        Me.Game7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game7.BackColor = System.Drawing.Color.Transparent
        Me.Game7.Image = CType(resources.GetObject("Game7.Image"), System.Drawing.Image)
        Me.Game7.Location = New System.Drawing.Point(960, 341)
        Me.Game7.Name = "Game7"
        Me.Game7.Size = New System.Drawing.Size(72, 72)
        Me.Game7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Game7.TabIndex = 18
        Me.Game7.TabStop = False
        Me.Game7.Visible = False
        '
        'Game6
        '
        Me.Game6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game6.BackColor = System.Drawing.Color.Transparent
        Me.Game6.Image = CType(resources.GetObject("Game6.Image"), System.Drawing.Image)
        Me.Game6.Location = New System.Drawing.Point(712, 341)
        Me.Game6.Name = "Game6"
        Me.Game6.Size = New System.Drawing.Size(72, 72)
        Me.Game6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Game6.TabIndex = 17
        Me.Game6.TabStop = False
        Me.Game6.Visible = False
        '
        'Game5
        '
        Me.Game5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game5.BackColor = System.Drawing.Color.Transparent
        Me.Game5.Image = CType(resources.GetObject("Game5.Image"), System.Drawing.Image)
        Me.Game5.Location = New System.Drawing.Point(452, 341)
        Me.Game5.Name = "Game5"
        Me.Game5.Size = New System.Drawing.Size(72, 72)
        Me.Game5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Game5.TabIndex = 16
        Me.Game5.TabStop = False
        Me.Game5.Visible = False
        '
        'Game11
        '
        Me.Game11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game11.BackColor = System.Drawing.Color.Transparent
        Me.Game11.Image = CType(resources.GetObject("Game11.Image"), System.Drawing.Image)
        Me.Game11.Location = New System.Drawing.Point(960, 518)
        Me.Game11.Name = "Game11"
        Me.Game11.Size = New System.Drawing.Size(72, 72)
        Me.Game11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Game11.TabIndex = 21
        Me.Game11.TabStop = False
        Me.Game11.Visible = False
        '
        'Game10
        '
        Me.Game10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game10.BackColor = System.Drawing.Color.Transparent
        Me.Game10.Image = CType(resources.GetObject("Game10.Image"), System.Drawing.Image)
        Me.Game10.Location = New System.Drawing.Point(712, 518)
        Me.Game10.Name = "Game10"
        Me.Game10.Size = New System.Drawing.Size(72, 72)
        Me.Game10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Game10.TabIndex = 20
        Me.Game10.TabStop = False
        Me.Game10.Visible = False
        '
        'Game9
        '
        Me.Game9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game9.BackColor = System.Drawing.Color.Transparent
        Me.Game9.Image = CType(resources.GetObject("Game9.Image"), System.Drawing.Image)
        Me.Game9.Location = New System.Drawing.Point(452, 518)
        Me.Game9.Name = "Game9"
        Me.Game9.Size = New System.Drawing.Size(72, 72)
        Me.Game9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Game9.TabIndex = 19
        Me.Game9.TabStop = False
        Me.Game9.Visible = False
        '
        'Game12
        '
        Me.Game12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game12.BackColor = System.Drawing.Color.Transparent
        Me.Game12.Image = CType(resources.GetObject("Game12.Image"), System.Drawing.Image)
        Me.Game12.Location = New System.Drawing.Point(1219, 518)
        Me.Game12.Name = "Game12"
        Me.Game12.Size = New System.Drawing.Size(72, 72)
        Me.Game12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Game12.TabIndex = 24
        Me.Game12.TabStop = False
        Me.Game12.Visible = False
        '
        'Game8
        '
        Me.Game8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game8.BackColor = System.Drawing.Color.Transparent
        Me.Game8.Image = CType(resources.GetObject("Game8.Image"), System.Drawing.Image)
        Me.Game8.Location = New System.Drawing.Point(1219, 341)
        Me.Game8.Name = "Game8"
        Me.Game8.Size = New System.Drawing.Size(72, 72)
        Me.Game8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Game8.TabIndex = 23
        Me.Game8.TabStop = False
        Me.Game8.Visible = False
        '
        'Game4
        '
        Me.Game4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game4.BackColor = System.Drawing.Color.Transparent
        Me.Game4.Image = CType(resources.GetObject("Game4.Image"), System.Drawing.Image)
        Me.Game4.Location = New System.Drawing.Point(1219, 152)
        Me.Game4.Name = "Game4"
        Me.Game4.Size = New System.Drawing.Size(72, 72)
        Me.Game4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Game4.TabIndex = 22
        Me.Game4.TabStop = False
        Me.Game4.Visible = False
        '
        'Game1Txt
        '
        Me.Game1Txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game1Txt.BackColor = System.Drawing.Color.Transparent
        Me.Game1Txt.BorderColor = System.Drawing.Color.Transparent
        Me.Game1Txt.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Game1Txt.ForeColor = System.Drawing.Color.White
        Me.Game1Txt.GlowColor = System.Drawing.Color.Black
        Me.Game1Txt.Location = New System.Drawing.Point(375, 227)
        Me.Game1Txt.Name = "Game1Txt"
        Me.Game1Txt.Size = New System.Drawing.Size(220, 80)
        Me.Game1Txt.TabIndex = 25
        Me.Game1Txt.Text = "GAME_TITLE_1_LIST"
        Me.Game1Txt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Game1Txt.Visible = False
        '
        'Game2Txt
        '
        Me.Game2Txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game2Txt.BackColor = System.Drawing.Color.Transparent
        Me.Game2Txt.BorderColor = System.Drawing.Color.Transparent
        Me.Game2Txt.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Game2Txt.ForeColor = System.Drawing.Color.White
        Me.Game2Txt.GlowColor = System.Drawing.Color.Black
        Me.Game2Txt.Location = New System.Drawing.Point(635, 227)
        Me.Game2Txt.Name = "Game2Txt"
        Me.Game2Txt.Size = New System.Drawing.Size(220, 80)
        Me.Game2Txt.TabIndex = 26
        Me.Game2Txt.Text = "GAME_TITLE_1_LIST"
        Me.Game2Txt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Game2Txt.Visible = False
        '
        'Game4Txt
        '
        Me.Game4Txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game4Txt.BackColor = System.Drawing.Color.Transparent
        Me.Game4Txt.BorderColor = System.Drawing.Color.Transparent
        Me.Game4Txt.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Game4Txt.ForeColor = System.Drawing.Color.White
        Me.Game4Txt.GlowColor = System.Drawing.Color.Black
        Me.Game4Txt.Location = New System.Drawing.Point(1147, 227)
        Me.Game4Txt.Name = "Game4Txt"
        Me.Game4Txt.Size = New System.Drawing.Size(220, 80)
        Me.Game4Txt.TabIndex = 28
        Me.Game4Txt.Text = "GAME_TITLE_1_LIST"
        Me.Game4Txt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Game4Txt.Visible = False
        '
        'Game3Txt
        '
        Me.Game3Txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game3Txt.BackColor = System.Drawing.Color.Transparent
        Me.Game3Txt.BorderColor = System.Drawing.Color.Transparent
        Me.Game3Txt.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Game3Txt.ForeColor = System.Drawing.Color.White
        Me.Game3Txt.GlowColor = System.Drawing.Color.Black
        Me.Game3Txt.Location = New System.Drawing.Point(887, 227)
        Me.Game3Txt.Name = "Game3Txt"
        Me.Game3Txt.Size = New System.Drawing.Size(220, 80)
        Me.Game3Txt.TabIndex = 27
        Me.Game3Txt.Text = "GAME_TITLE_1_LIST"
        Me.Game3Txt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Game3Txt.Visible = False
        '
        'Game8Txt
        '
        Me.Game8Txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game8Txt.BackColor = System.Drawing.Color.Transparent
        Me.Game8Txt.BorderColor = System.Drawing.Color.Transparent
        Me.Game8Txt.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Game8Txt.ForeColor = System.Drawing.Color.White
        Me.Game8Txt.GlowColor = System.Drawing.Color.Black
        Me.Game8Txt.Location = New System.Drawing.Point(1147, 416)
        Me.Game8Txt.Name = "Game8Txt"
        Me.Game8Txt.Size = New System.Drawing.Size(220, 80)
        Me.Game8Txt.TabIndex = 32
        Me.Game8Txt.Text = "GAME_TITLE_1_LIST"
        Me.Game8Txt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Game8Txt.Visible = False
        '
        'Game7Txt
        '
        Me.Game7Txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game7Txt.BackColor = System.Drawing.Color.Transparent
        Me.Game7Txt.BorderColor = System.Drawing.Color.Transparent
        Me.Game7Txt.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Game7Txt.ForeColor = System.Drawing.Color.White
        Me.Game7Txt.GlowColor = System.Drawing.Color.Black
        Me.Game7Txt.Location = New System.Drawing.Point(878, 416)
        Me.Game7Txt.Name = "Game7Txt"
        Me.Game7Txt.Size = New System.Drawing.Size(220, 80)
        Me.Game7Txt.TabIndex = 31
        Me.Game7Txt.Text = "GAME_TITLE_1_LIST"
        Me.Game7Txt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Game7Txt.Visible = False
        '
        'Game6Txt
        '
        Me.Game6Txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game6Txt.BackColor = System.Drawing.Color.Transparent
        Me.Game6Txt.BorderColor = System.Drawing.Color.Transparent
        Me.Game6Txt.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Game6Txt.ForeColor = System.Drawing.Color.White
        Me.Game6Txt.GlowColor = System.Drawing.Color.Black
        Me.Game6Txt.Location = New System.Drawing.Point(635, 416)
        Me.Game6Txt.Name = "Game6Txt"
        Me.Game6Txt.Size = New System.Drawing.Size(220, 80)
        Me.Game6Txt.TabIndex = 30
        Me.Game6Txt.Text = "GAME_TITLE_1_LIST"
        Me.Game6Txt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Game6Txt.Visible = False
        '
        'Game5Txt
        '
        Me.Game5Txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game5Txt.BackColor = System.Drawing.Color.Transparent
        Me.Game5Txt.BorderColor = System.Drawing.Color.Transparent
        Me.Game5Txt.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Game5Txt.ForeColor = System.Drawing.Color.White
        Me.Game5Txt.GlowColor = System.Drawing.Color.Black
        Me.Game5Txt.Location = New System.Drawing.Point(375, 416)
        Me.Game5Txt.Name = "Game5Txt"
        Me.Game5Txt.Size = New System.Drawing.Size(220, 80)
        Me.Game5Txt.TabIndex = 29
        Me.Game5Txt.Text = "GAME_TITLE_1_LIST"
        Me.Game5Txt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Game5Txt.Visible = False
        '
        'Game12Txt
        '
        Me.Game12Txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game12Txt.BackColor = System.Drawing.Color.Transparent
        Me.Game12Txt.BorderColor = System.Drawing.Color.Transparent
        Me.Game12Txt.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Game12Txt.ForeColor = System.Drawing.Color.White
        Me.Game12Txt.GlowColor = System.Drawing.Color.Black
        Me.Game12Txt.Location = New System.Drawing.Point(1147, 593)
        Me.Game12Txt.Name = "Game12Txt"
        Me.Game12Txt.Size = New System.Drawing.Size(220, 80)
        Me.Game12Txt.TabIndex = 36
        Me.Game12Txt.Text = "GAME_TITLE_1_LIST"
        Me.Game12Txt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Game12Txt.Visible = False
        '
        'Game11Txt
        '
        Me.Game11Txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game11Txt.BackColor = System.Drawing.Color.Transparent
        Me.Game11Txt.BorderColor = System.Drawing.Color.Transparent
        Me.Game11Txt.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Game11Txt.ForeColor = System.Drawing.Color.White
        Me.Game11Txt.GlowColor = System.Drawing.Color.Black
        Me.Game11Txt.Location = New System.Drawing.Point(887, 593)
        Me.Game11Txt.Name = "Game11Txt"
        Me.Game11Txt.Size = New System.Drawing.Size(220, 80)
        Me.Game11Txt.TabIndex = 35
        Me.Game11Txt.Text = "GAME_TITLE_1_LIST"
        Me.Game11Txt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Game11Txt.Visible = False
        '
        'Game10Txt
        '
        Me.Game10Txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game10Txt.BackColor = System.Drawing.Color.Transparent
        Me.Game10Txt.BorderColor = System.Drawing.Color.Transparent
        Me.Game10Txt.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Game10Txt.ForeColor = System.Drawing.Color.White
        Me.Game10Txt.GlowColor = System.Drawing.Color.Black
        Me.Game10Txt.Location = New System.Drawing.Point(635, 593)
        Me.Game10Txt.Name = "Game10Txt"
        Me.Game10Txt.Size = New System.Drawing.Size(220, 80)
        Me.Game10Txt.TabIndex = 34
        Me.Game10Txt.Text = "GAME_TITLE_1_LIST"
        Me.Game10Txt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Game10Txt.Visible = False
        '
        'Game9Txt
        '
        Me.Game9Txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Game9Txt.BackColor = System.Drawing.Color.Transparent
        Me.Game9Txt.BorderColor = System.Drawing.Color.Transparent
        Me.Game9Txt.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Game9Txt.ForeColor = System.Drawing.Color.White
        Me.Game9Txt.GlowColor = System.Drawing.Color.Black
        Me.Game9Txt.Location = New System.Drawing.Point(375, 593)
        Me.Game9Txt.Name = "Game9Txt"
        Me.Game9Txt.Size = New System.Drawing.Size(220, 80)
        Me.Game9Txt.TabIndex = 33
        Me.Game9Txt.Text = "GAME_TITLE_1_LIST"
        Me.Game9Txt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Game9Txt.Visible = False
        '
        'InfoLab
        '
        Me.InfoLab.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.InfoLab.BackColor = System.Drawing.Color.Transparent
        Me.InfoLab.BorderColor = System.Drawing.Color.Transparent
        Me.InfoLab.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoLab.ForeColor = System.Drawing.Color.White
        Me.InfoLab.GlowColor = System.Drawing.Color.Black
        Me.InfoLab.Location = New System.Drawing.Point(0, 783)
        Me.InfoLab.Name = "InfoLab"
        Me.InfoLab.Size = New System.Drawing.Size(526, 26)
        Me.InfoLab.TabIndex = 37
        Me.InfoLab.Text = "Some roms may contain alot of other versions of the game!"
        Me.InfoLab.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'BrowseNext
        '
        Me.BrowseNext.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BrowseNext.BackColor = System.Drawing.Color.Transparent
        Me.BrowseNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BrowseNext.Image = Global.XMBPC.My.Resources.Resources.Actions_go_next_icon
        Me.BrowseNext.Location = New System.Drawing.Point(1422, 341)
        Me.BrowseNext.Name = "BrowseNext"
        Me.BrowseNext.Size = New System.Drawing.Size(72, 72)
        Me.BrowseNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.BrowseNext.TabIndex = 38
        Me.BrowseNext.TabStop = False
        Me.BrowseNext.Visible = False
        '
        'BrowseLast
        '
        Me.BrowseLast.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BrowseLast.BackColor = System.Drawing.Color.Transparent
        Me.BrowseLast.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BrowseLast.Image = Global.XMBPC.My.Resources.Resources.Actions_go_previous_icon
        Me.BrowseLast.Location = New System.Drawing.Point(255, 341)
        Me.BrowseLast.Name = "BrowseLast"
        Me.BrowseLast.Size = New System.Drawing.Size(72, 72)
        Me.BrowseLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.BrowseLast.TabIndex = 39
        Me.BrowseLast.TabStop = False
        Me.BrowseLast.Visible = False
        '
        'AddonsToolsTxt
        '
        Me.AddonsToolsTxt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.AddonsToolsTxt.BackColor = System.Drawing.Color.Transparent
        Me.AddonsToolsTxt.BorderColor = System.Drawing.Color.Transparent
        Me.AddonsToolsTxt.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddonsToolsTxt.ForeColor = System.Drawing.Color.White
        Me.AddonsToolsTxt.GlowColor = System.Drawing.Color.Black
        Me.AddonsToolsTxt.GlowState = False
        Me.AddonsToolsTxt.Location = New System.Drawing.Point(12, 501)
        Me.AddonsToolsTxt.Name = "AddonsToolsTxt"
        Me.AddonsToolsTxt.Size = New System.Drawing.Size(202, 44)
        Me.AddonsToolsTxt.TabIndex = 40
        Me.AddonsToolsTxt.Text = "Addons/Tools"
        Me.AddonsToolsTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Store
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.XMBPC.My.Resources.Resources.xmb_tribute_31
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1554, 809)
        Me.Controls.Add(Me.AddonsToolsTxt)
        Me.Controls.Add(Me.BrowseNext)
        Me.Controls.Add(Me.BrowseLast)
        Me.Controls.Add(Me.InfoLab)
        Me.Controls.Add(Me.Game12Txt)
        Me.Controls.Add(Me.Game11Txt)
        Me.Controls.Add(Me.Game10Txt)
        Me.Controls.Add(Me.Game9Txt)
        Me.Controls.Add(Me.Game8Txt)
        Me.Controls.Add(Me.Game7Txt)
        Me.Controls.Add(Me.Game6Txt)
        Me.Controls.Add(Me.Game5Txt)
        Me.Controls.Add(Me.Game4Txt)
        Me.Controls.Add(Me.Game3Txt)
        Me.Controls.Add(Me.Game2Txt)
        Me.Controls.Add(Me.Game1Txt)
        Me.Controls.Add(Me.Game12)
        Me.Controls.Add(Me.Game8)
        Me.Controls.Add(Me.Game4)
        Me.Controls.Add(Me.Game11)
        Me.Controls.Add(Me.Game10)
        Me.Controls.Add(Me.Game9)
        Me.Controls.Add(Me.Game7)
        Me.Controls.Add(Me.Game6)
        Me.Controls.Add(Me.Game5)
        Me.Controls.Add(Me.Game3)
        Me.Controls.Add(Me.Game2)
        Me.Controls.Add(Me.Game1)
        Me.Controls.Add(Me.StoreVer)
        Me.Controls.Add(Me.UserStatus)
        Me.Controls.Add(Me.UserName)
        Me.Controls.Add(Me.CategoryTxt)
        Me.Controls.Add(Me.UserAvatar)
        Me.Controls.Add(Me.GBCTxt)
        Me.Controls.Add(Me.GBATxt)
        Me.Controls.Add(Me.SEGATxt)
        Me.Controls.Add(Me.NESTxt)
        Me.Controls.Add(Me.SNESTxt)
        Me.Controls.Add(Me.HomeTxt)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Store"
        Me.Text = "Store"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.UserAvatar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Game1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Game2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Game3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Game7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Game6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Game5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Game11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Game10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Game9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Game12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Game8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Game4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BrowseNext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BrowseLast, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HomeTxt As gLabel.gLabel
    Friend WithEvents SNESTxt As gLabel.gLabel
    Friend WithEvents NESTxt As gLabel.gLabel
    Friend WithEvents GBATxt As gLabel.gLabel
    Friend WithEvents SEGATxt As gLabel.gLabel
    Friend WithEvents GBCTxt As gLabel.gLabel
    Friend WithEvents UserAvatar As System.Windows.Forms.PictureBox
    Friend WithEvents CategoryTxt As gLabel.gLabel
    Friend WithEvents UserName As gLabel.gLabel
    Friend WithEvents UserStatus As gLabel.gLabel
    Friend WithEvents ControllerTimer As System.Windows.Forms.Timer
    Friend WithEvents KeyboardTimer As System.Windows.Forms.Timer
    Friend WithEvents StoreVer As gLabel.gLabel
    Friend WithEvents Game1 As System.Windows.Forms.PictureBox
    Friend WithEvents Game2 As System.Windows.Forms.PictureBox
    Friend WithEvents Game3 As System.Windows.Forms.PictureBox
    Friend WithEvents Game7 As System.Windows.Forms.PictureBox
    Friend WithEvents Game6 As System.Windows.Forms.PictureBox
    Friend WithEvents Game5 As System.Windows.Forms.PictureBox
    Friend WithEvents Game11 As System.Windows.Forms.PictureBox
    Friend WithEvents Game10 As System.Windows.Forms.PictureBox
    Friend WithEvents Game9 As System.Windows.Forms.PictureBox
    Friend WithEvents Game12 As System.Windows.Forms.PictureBox
    Friend WithEvents Game8 As System.Windows.Forms.PictureBox
    Friend WithEvents Game4 As System.Windows.Forms.PictureBox
    Friend WithEvents Game1Txt As gLabel.gLabel
    Friend WithEvents Game2Txt As gLabel.gLabel
    Friend WithEvents Game4Txt As gLabel.gLabel
    Friend WithEvents Game3Txt As gLabel.gLabel
    Friend WithEvents Game8Txt As gLabel.gLabel
    Friend WithEvents Game7Txt As gLabel.gLabel
    Friend WithEvents Game6Txt As gLabel.gLabel
    Friend WithEvents Game5Txt As gLabel.gLabel
    Friend WithEvents Game12Txt As gLabel.gLabel
    Friend WithEvents Game11Txt As gLabel.gLabel
    Friend WithEvents Game10Txt As gLabel.gLabel
    Friend WithEvents Game9Txt As gLabel.gLabel
    Friend WithEvents InfoLab As gLabel.gLabel
    Friend WithEvents BrowseNext As System.Windows.Forms.PictureBox
    Friend WithEvents BrowseLast As System.Windows.Forms.PictureBox
    Friend WithEvents AddonsToolsTxt As gLabel.gLabel
End Class

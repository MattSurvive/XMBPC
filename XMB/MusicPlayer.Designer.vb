<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MusicPlayer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MusicPlayer))
        Me.TrackName = New gLabel.gLabel()
        Me.TrackInfos = New gLabel.gLabel()
        Me.ControlPanel = New System.Windows.Forms.Panel()
        Me.InformationsButton = New System.Windows.Forms.PictureBox()
        Me.StopButton = New System.Windows.Forms.PictureBox()
        Me.FbackwardsButton = New System.Windows.Forms.PictureBox()
        Me.PlaylistButton = New System.Windows.Forms.PictureBox()
        Me.ShuffleButton = New System.Windows.Forms.PictureBox()
        Me.FforwardButton = New System.Windows.Forms.PictureBox()
        Me.TrashButton = New System.Windows.Forms.PictureBox()
        Me.RepeatButton = New System.Windows.Forms.PictureBox()
        Me.BackwardsButton = New System.Windows.Forms.PictureBox()
        Me.VisualiserButton = New System.Windows.Forms.PictureBox()
        Me.ForwardButton = New System.Windows.Forms.PictureBox()
        Me.PlayButton = New System.Windows.Forms.PictureBox()
        Me.VolumeButton = New System.Windows.Forms.PictureBox()
        Me.PauseButton = New System.Windows.Forms.PictureBox()
        Me.ControllerInputTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TrackProgress = New System.Windows.Forms.ProgressBar()
        Me.CurrentPosition = New gLabel.gLabel()
        Me.TrackCount = New gLabel.gLabel()
        Me.MusicType = New System.Windows.Forms.PictureBox()
        Me.RepeatBox = New System.Windows.Forms.PictureBox()
        Me.CurrentPlayStatus = New System.Windows.Forms.PictureBox()
        Me.TrackCover = New System.Windows.Forms.PictureBox()
        Me.ControlPanel.SuspendLayout()
        CType(Me.InformationsButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StopButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FbackwardsButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlaylistButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShuffleButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FforwardButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrashButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepeatButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BackwardsButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VisualiserButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ForwardButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlayButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VolumeButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PauseButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MusicType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepeatBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrentPlayStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackCover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrackName
        '
        Me.TrackName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TrackName.BackColor = System.Drawing.Color.Transparent
        Me.TrackName.BorderWidth = 0.0!
        Me.TrackName.FeatherState = False
        Me.TrackName.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrackName.ForeColor = System.Drawing.Color.White
        Me.TrackName.GlowState = False
        Me.TrackName.Location = New System.Drawing.Point(143, 677)
        Me.TrackName.Margin = New System.Windows.Forms.Padding(0)
        Me.TrackName.Name = "TrackName"
        Me.TrackName.ShadowColor = System.Drawing.Color.Black
        Me.TrackName.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.TrackName.ShadowState = True
        Me.TrackName.Size = New System.Drawing.Size(930, 51)
        Me.TrackName.TabIndex = 40
        Me.TrackName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrackInfos
        '
        Me.TrackInfos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TrackInfos.BackColor = System.Drawing.Color.Transparent
        Me.TrackInfos.BorderWidth = 0.0!
        Me.TrackInfos.FeatherState = False
        Me.TrackInfos.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrackInfos.ForeColor = System.Drawing.Color.White
        Me.TrackInfos.GlowState = False
        Me.TrackInfos.Location = New System.Drawing.Point(143, 736)
        Me.TrackInfos.Margin = New System.Windows.Forms.Padding(0)
        Me.TrackInfos.Name = "TrackInfos"
        Me.TrackInfos.ShadowColor = System.Drawing.Color.Black
        Me.TrackInfos.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.TrackInfos.ShadowState = True
        Me.TrackInfos.Size = New System.Drawing.Size(930, 37)
        Me.TrackInfos.TabIndex = 41
        Me.TrackInfos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ControlPanel
        '
        Me.ControlPanel.BackColor = System.Drawing.Color.Transparent
        Me.ControlPanel.Controls.Add(Me.InformationsButton)
        Me.ControlPanel.Controls.Add(Me.StopButton)
        Me.ControlPanel.Controls.Add(Me.FbackwardsButton)
        Me.ControlPanel.Controls.Add(Me.PlaylistButton)
        Me.ControlPanel.Controls.Add(Me.ShuffleButton)
        Me.ControlPanel.Controls.Add(Me.FforwardButton)
        Me.ControlPanel.Controls.Add(Me.TrashButton)
        Me.ControlPanel.Controls.Add(Me.RepeatButton)
        Me.ControlPanel.Controls.Add(Me.BackwardsButton)
        Me.ControlPanel.Controls.Add(Me.VisualiserButton)
        Me.ControlPanel.Controls.Add(Me.ForwardButton)
        Me.ControlPanel.Controls.Add(Me.PlayButton)
        Me.ControlPanel.Controls.Add(Me.VolumeButton)
        Me.ControlPanel.Controls.Add(Me.PauseButton)
        Me.ControlPanel.Location = New System.Drawing.Point(109, 150)
        Me.ControlPanel.Name = "ControlPanel"
        Me.ControlPanel.Size = New System.Drawing.Size(542, 266)
        Me.ControlPanel.TabIndex = 42
        Me.ControlPanel.Visible = False
        '
        'InformationsButton
        '
        Me.InformationsButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.InformationsButton.BackColor = System.Drawing.Color.Transparent
        Me.InformationsButton.Image = Global.XMBPC.My.Resources.Resources.tex_cp_showinfo
        Me.InformationsButton.Location = New System.Drawing.Point(386, 28)
        Me.InformationsButton.Name = "InformationsButton"
        Me.InformationsButton.Size = New System.Drawing.Size(70, 70)
        Me.InformationsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.InformationsButton.TabIndex = 57
        Me.InformationsButton.TabStop = False
        '
        'StopButton
        '
        Me.StopButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.StopButton.BackColor = System.Drawing.Color.Transparent
        Me.StopButton.Image = Global.XMBPC.My.Resources.Resources.tex_cp_stop
        Me.StopButton.Location = New System.Drawing.Point(462, 104)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(70, 70)
        Me.StopButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.StopButton.TabIndex = 46
        Me.StopButton.TabStop = False
        '
        'FbackwardsButton
        '
        Me.FbackwardsButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FbackwardsButton.BackColor = System.Drawing.Color.Transparent
        Me.FbackwardsButton.Image = Global.XMBPC.My.Resources.Resources.tex_cp_prev
        Me.FbackwardsButton.Location = New System.Drawing.Point(6, 104)
        Me.FbackwardsButton.Name = "FbackwardsButton"
        Me.FbackwardsButton.Size = New System.Drawing.Size(70, 70)
        Me.FbackwardsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.FbackwardsButton.TabIndex = 50
        Me.FbackwardsButton.TabStop = False
        '
        'PlaylistButton
        '
        Me.PlaylistButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PlaylistButton.BackColor = System.Drawing.Color.Transparent
        Me.PlaylistButton.Image = Global.XMBPC.My.Resources.Resources.tex_cp_playlist
        Me.PlaylistButton.Location = New System.Drawing.Point(234, 28)
        Me.PlaylistButton.Name = "PlaylistButton"
        Me.PlaylistButton.Size = New System.Drawing.Size(70, 70)
        Me.PlaylistButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PlaylistButton.TabIndex = 56
        Me.PlaylistButton.TabStop = False
        '
        'ShuffleButton
        '
        Me.ShuffleButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ShuffleButton.BackColor = System.Drawing.Color.Transparent
        Me.ShuffleButton.Image = Global.XMBPC.My.Resources.Resources.tex_cp_shuffle
        Me.ShuffleButton.Location = New System.Drawing.Point(262, 180)
        Me.ShuffleButton.Name = "ShuffleButton"
        Me.ShuffleButton.Size = New System.Drawing.Size(98, 70)
        Me.ShuffleButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ShuffleButton.TabIndex = 52
        Me.ShuffleButton.TabStop = False
        '
        'FforwardButton
        '
        Me.FforwardButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FforwardButton.BackColor = System.Drawing.Color.Transparent
        Me.FforwardButton.Image = Global.XMBPC.My.Resources.Resources.tex_cp_next
        Me.FforwardButton.Location = New System.Drawing.Point(82, 104)
        Me.FforwardButton.Name = "FforwardButton"
        Me.FforwardButton.Size = New System.Drawing.Size(70, 70)
        Me.FforwardButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.FforwardButton.TabIndex = 47
        Me.FforwardButton.TabStop = False
        '
        'TrashButton
        '
        Me.TrashButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TrashButton.BackColor = System.Drawing.Color.Transparent
        Me.TrashButton.Image = Global.XMBPC.My.Resources.Resources.tex_cp_delete
        Me.TrashButton.Location = New System.Drawing.Point(310, 28)
        Me.TrashButton.Name = "TrashButton"
        Me.TrashButton.Size = New System.Drawing.Size(70, 70)
        Me.TrashButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.TrashButton.TabIndex = 53
        Me.TrashButton.TabStop = False
        '
        'RepeatButton
        '
        Me.RepeatButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RepeatButton.BackColor = System.Drawing.Color.Transparent
        Me.RepeatButton.Image = Global.XMBPC.My.Resources.Resources.tex_cp_repeat
        Me.RepeatButton.Location = New System.Drawing.Point(158, 180)
        Me.RepeatButton.Name = "RepeatButton"
        Me.RepeatButton.Size = New System.Drawing.Size(98, 70)
        Me.RepeatButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.RepeatButton.TabIndex = 51
        Me.RepeatButton.TabStop = False
        '
        'BackwardsButton
        '
        Me.BackwardsButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BackwardsButton.BackColor = System.Drawing.Color.Transparent
        Me.BackwardsButton.Image = Global.XMBPC.My.Resources.Resources.tex_cp_searchb
        Me.BackwardsButton.Location = New System.Drawing.Point(158, 104)
        Me.BackwardsButton.Name = "BackwardsButton"
        Me.BackwardsButton.Size = New System.Drawing.Size(70, 70)
        Me.BackwardsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.BackwardsButton.TabIndex = 48
        Me.BackwardsButton.TabStop = False
        '
        'VisualiserButton
        '
        Me.VisualiserButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.VisualiserButton.BackColor = System.Drawing.Color.Transparent
        Me.VisualiserButton.Image = Global.XMBPC.My.Resources.Resources.tex_cp_vislizer
        Me.VisualiserButton.Location = New System.Drawing.Point(158, 28)
        Me.VisualiserButton.Name = "VisualiserButton"
        Me.VisualiserButton.Size = New System.Drawing.Size(70, 70)
        Me.VisualiserButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.VisualiserButton.TabIndex = 55
        Me.VisualiserButton.TabStop = False
        '
        'ForwardButton
        '
        Me.ForwardButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ForwardButton.BackColor = System.Drawing.Color.Transparent
        Me.ForwardButton.Image = Global.XMBPC.My.Resources.Resources.tex_cp_searchf
        Me.ForwardButton.Location = New System.Drawing.Point(234, 104)
        Me.ForwardButton.Name = "ForwardButton"
        Me.ForwardButton.Size = New System.Drawing.Size(70, 70)
        Me.ForwardButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ForwardButton.TabIndex = 49
        Me.ForwardButton.TabStop = False
        '
        'PlayButton
        '
        Me.PlayButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PlayButton.BackColor = System.Drawing.Color.Transparent
        Me.PlayButton.Image = Global.XMBPC.My.Resources.Resources.tex_cp_play
        Me.PlayButton.Location = New System.Drawing.Point(310, 104)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(70, 70)
        Me.PlayButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PlayButton.TabIndex = 44
        Me.PlayButton.TabStop = False
        '
        'VolumeButton
        '
        Me.VolumeButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.VolumeButton.BackColor = System.Drawing.Color.Transparent
        Me.VolumeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.VolumeButton.Image = Global.XMBPC.My.Resources.Resources.tex_cp_volume
        Me.VolumeButton.Location = New System.Drawing.Point(82, 28)
        Me.VolumeButton.Name = "VolumeButton"
        Me.VolumeButton.Size = New System.Drawing.Size(70, 70)
        Me.VolumeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.VolumeButton.TabIndex = 54
        Me.VolumeButton.TabStop = False
        '
        'PauseButton
        '
        Me.PauseButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PauseButton.BackColor = System.Drawing.Color.Transparent
        Me.PauseButton.Image = Global.XMBPC.My.Resources.Resources.tex_cp_pause
        Me.PauseButton.Location = New System.Drawing.Point(386, 104)
        Me.PauseButton.Name = "PauseButton"
        Me.PauseButton.Size = New System.Drawing.Size(70, 70)
        Me.PauseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PauseButton.TabIndex = 45
        Me.PauseButton.TabStop = False
        '
        'ControllerInputTimer
        '
        '
        'TrackProgress
        '
        Me.TrackProgress.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TrackProgress.Location = New System.Drawing.Point(1091, 736)
        Me.TrackProgress.Name = "TrackProgress"
        Me.TrackProgress.Size = New System.Drawing.Size(346, 10)
        Me.TrackProgress.TabIndex = 53
        '
        'CurrentPosition
        '
        Me.CurrentPosition.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CurrentPosition.BackColor = System.Drawing.Color.Transparent
        Me.CurrentPosition.BorderWidth = 0.0!
        Me.CurrentPosition.FeatherState = False
        Me.CurrentPosition.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentPosition.ForeColor = System.Drawing.Color.White
        Me.CurrentPosition.GlowState = False
        Me.CurrentPosition.Location = New System.Drawing.Point(1087, 700)
        Me.CurrentPosition.Margin = New System.Windows.Forms.Padding(0)
        Me.CurrentPosition.Name = "CurrentPosition"
        Me.CurrentPosition.ShadowColor = System.Drawing.Color.Black
        Me.CurrentPosition.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.CurrentPosition.ShadowState = True
        Me.CurrentPosition.Size = New System.Drawing.Size(218, 33)
        Me.CurrentPosition.TabIndex = 54
        Me.CurrentPosition.Text = "00:00:00 / 00:00:00"
        Me.CurrentPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrackCount
        '
        Me.TrackCount.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TrackCount.BackColor = System.Drawing.Color.Transparent
        Me.TrackCount.BorderWidth = 0.0!
        Me.TrackCount.FeatherState = False
        Me.TrackCount.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrackCount.ForeColor = System.Drawing.Color.White
        Me.TrackCount.GlowState = False
        Me.TrackCount.Location = New System.Drawing.Point(1249, 638)
        Me.TrackCount.Margin = New System.Windows.Forms.Padding(0)
        Me.TrackCount.Name = "TrackCount"
        Me.TrackCount.ShadowColor = System.Drawing.Color.Black
        Me.TrackCount.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.TrackCount.ShadowState = True
        Me.TrackCount.Size = New System.Drawing.Size(188, 33)
        Me.TrackCount.TabIndex = 56
        Me.TrackCount.Text = "0 / 0"
        Me.TrackCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MusicType
        '
        Me.MusicType.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MusicType.BackColor = System.Drawing.Color.Transparent
        Me.MusicType.Image = Global.XMBPC.My.Resources.Resources.tex_mp3
        Me.MusicType.Location = New System.Drawing.Point(1327, 700)
        Me.MusicType.Name = "MusicType"
        Me.MusicType.Size = New System.Drawing.Size(110, 28)
        Me.MusicType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.MusicType.TabIndex = 55
        Me.MusicType.TabStop = False
        '
        'RepeatBox
        '
        Me.RepeatBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RepeatBox.BackColor = System.Drawing.Color.Transparent
        Me.RepeatBox.Image = Global.XMBPC.My.Resources.Resources.tex_cp_repeat
        Me.RepeatBox.Location = New System.Drawing.Point(137, 601)
        Me.RepeatBox.Name = "RepeatBox"
        Me.RepeatBox.Size = New System.Drawing.Size(98, 70)
        Me.RepeatBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.RepeatBox.TabIndex = 52
        Me.RepeatBox.TabStop = False
        '
        'CurrentPlayStatus
        '
        Me.CurrentPlayStatus.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CurrentPlayStatus.BackColor = System.Drawing.Color.Transparent
        Me.CurrentPlayStatus.Image = Global.XMBPC.My.Resources.Resources.tex_cp_play
        Me.CurrentPlayStatus.Location = New System.Drawing.Point(61, 601)
        Me.CurrentPlayStatus.Name = "CurrentPlayStatus"
        Me.CurrentPlayStatus.Size = New System.Drawing.Size(70, 70)
        Me.CurrentPlayStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.CurrentPlayStatus.TabIndex = 43
        Me.CurrentPlayStatus.TabStop = False
        '
        'TrackCover
        '
        Me.TrackCover.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TrackCover.BackColor = System.Drawing.Color.Transparent
        Me.TrackCover.Image = Global.XMBPC.My.Resources.Resources.MusicDefault
        Me.TrackCover.Location = New System.Drawing.Point(44, 677)
        Me.TrackCover.Name = "TrackCover"
        Me.TrackCover.Size = New System.Drawing.Size(96, 96)
        Me.TrackCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TrackCover.TabIndex = 23
        Me.TrackCover.TabStop = False
        Me.TrackCover.Tag = ""
        '
        'MusicPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1497, 809)
        Me.ControlBox = False
        Me.Controls.Add(Me.TrackCount)
        Me.Controls.Add(Me.MusicType)
        Me.Controls.Add(Me.CurrentPosition)
        Me.Controls.Add(Me.TrackProgress)
        Me.Controls.Add(Me.RepeatBox)
        Me.Controls.Add(Me.CurrentPlayStatus)
        Me.Controls.Add(Me.ControlPanel)
        Me.Controls.Add(Me.TrackInfos)
        Me.Controls.Add(Me.TrackName)
        Me.Controls.Add(Me.TrackCover)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MusicPlayer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "MusicPlayer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ControlPanel.ResumeLayout(False)
        Me.ControlPanel.PerformLayout()
        CType(Me.InformationsButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StopButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FbackwardsButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlaylistButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShuffleButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FforwardButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrashButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepeatButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BackwardsButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VisualiserButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ForwardButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlayButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VolumeButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PauseButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MusicType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepeatBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrentPlayStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackCover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrackCover As System.Windows.Forms.PictureBox
    Friend WithEvents TrackName As gLabel.gLabel
    Friend WithEvents TrackInfos As gLabel.gLabel
    Friend WithEvents ControlPanel As System.Windows.Forms.Panel
    Friend WithEvents CurrentPlayStatus As System.Windows.Forms.PictureBox
    Friend WithEvents PlayButton As System.Windows.Forms.PictureBox
    Friend WithEvents PauseButton As System.Windows.Forms.PictureBox
    Friend WithEvents StopButton As System.Windows.Forms.PictureBox
    Friend WithEvents ForwardButton As System.Windows.Forms.PictureBox
    Friend WithEvents BackwardsButton As System.Windows.Forms.PictureBox
    Friend WithEvents FforwardButton As System.Windows.Forms.PictureBox
    Friend WithEvents FbackwardsButton As System.Windows.Forms.PictureBox
    Friend WithEvents RepeatButton As System.Windows.Forms.PictureBox
    Friend WithEvents RepeatBox As System.Windows.Forms.PictureBox
    Friend WithEvents ShuffleButton As System.Windows.Forms.PictureBox
    Friend WithEvents PlaylistButton As System.Windows.Forms.PictureBox
    Friend WithEvents VisualiserButton As System.Windows.Forms.PictureBox
    Friend WithEvents VolumeButton As System.Windows.Forms.PictureBox
    Friend WithEvents TrashButton As System.Windows.Forms.PictureBox
    Friend WithEvents InformationsButton As System.Windows.Forms.PictureBox
    Friend WithEvents ControllerInputTimer As System.Windows.Forms.Timer
    Friend WithEvents TrackProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents CurrentPosition As gLabel.gLabel
    Friend WithEvents MusicType As System.Windows.Forms.PictureBox
    Friend WithEvents TrackCount As gLabel.gLabel
End Class

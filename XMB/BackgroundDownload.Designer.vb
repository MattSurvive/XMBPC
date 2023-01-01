<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BackgroundDownload
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BackgroundDownload))
        Me.PackageText = New gLabel.gLabel()
        Me.ProgressBar1 = New MetroControls.MetroProgressbar()
        Me.GLabel1 = New gLabel.gLabel()
        Me.ETA = New gLabel.gLabel()
        Me.GLabel3 = New gLabel.gLabel()
        Me.PsSeparator1 = New PSControls.PSSeparator()
        Me.PsSeparator2 = New PSControls.PSSeparator()
        Me.GLabel4 = New gLabel.gLabel()
        Me.DLS = New gLabel.gLabel()
        Me.ControllerInputTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ETAS = New gLabel.gLabel()
        Me.AdviceIco = New System.Windows.Forms.PictureBox()
        Me.DownloadArt = New System.Windows.Forms.PictureBox()
        CType(Me.AdviceIco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DownloadArt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PackageText
        '
        Me.PackageText.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PackageText.BackColor = System.Drawing.Color.Transparent
        Me.PackageText.BorderWidth = 0.0!
        Me.PackageText.FeatherState = False
        Me.PackageText.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PackageText.ForeColor = System.Drawing.Color.White
        Me.PackageText.Glow = 3
        Me.PackageText.GlowColor = System.Drawing.Color.White
        Me.PackageText.Location = New System.Drawing.Point(177, 441)
        Me.PackageText.Margin = New System.Windows.Forms.Padding(0)
        Me.PackageText.Name = "PackageText"
        Me.PackageText.ShadowColor = System.Drawing.Color.Black
        Me.PackageText.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.PackageText.Size = New System.Drawing.Size(285, 92)
        Me.PackageText.TabIndex = 62
        Me.PackageText.Text = "DL-PACKAGE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SIZE in MB"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ProgressBar1.BackColor = System.Drawing.Color.DimGray
        Me.ProgressBar1.BackColorNormal = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.ProgressBar1.BorderColor = System.Drawing.Color.Black
        Me.ProgressBar1.Color = System.Drawing.Color.LightGray
        Me.ProgressBar1.DrawBorders = True
        Me.ProgressBar1.Location = New System.Drawing.Point(522, 396)
        Me.ProgressBar1.Maximum = 100
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(764, 10)
        Me.ProgressBar1.TabIndex = 63
        Me.ProgressBar1.Value = 0
        '
        'GLabel1
        '
        Me.GLabel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GLabel1.BackColor = System.Drawing.Color.Transparent
        Me.GLabel1.BorderWidth = 0.0!
        Me.GLabel1.FeatherState = False
        Me.GLabel1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLabel1.ForeColor = System.Drawing.Color.White
        Me.GLabel1.Glow = 2
        Me.GLabel1.GlowColor = System.Drawing.Color.White
        Me.GLabel1.Location = New System.Drawing.Point(518, 276)
        Me.GLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.GLabel1.Name = "GLabel1"
        Me.GLabel1.ShadowColor = System.Drawing.Color.Black
        Me.GLabel1.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.GLabel1.Size = New System.Drawing.Size(768, 91)
        Me.GLabel1.TabIndex = 64
        Me.GLabel1.Text = "          Downloading selected data..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Do not turn off system.         "
        '
        'ETA
        '
        Me.ETA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ETA.BackColor = System.Drawing.Color.Transparent
        Me.ETA.BorderWidth = 0.0!
        Me.ETA.FeatherState = False
        Me.ETA.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ETA.ForeColor = System.Drawing.Color.White
        Me.ETA.Glow = 2
        Me.ETA.GlowColor = System.Drawing.Color.White
        Me.ETA.Location = New System.Drawing.Point(1037, 370)
        Me.ETA.Margin = New System.Windows.Forms.Padding(0)
        Me.ETA.Name = "ETA"
        Me.ETA.ShadowColor = System.Drawing.Color.Black
        Me.ETA.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.ETA.Size = New System.Drawing.Size(249, 25)
        Me.ETA.TabIndex = 65
        Me.ETA.Text = "00 Seconds left."
        Me.ETA.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'GLabel3
        '
        Me.GLabel3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GLabel3.BackColor = System.Drawing.Color.Transparent
        Me.GLabel3.BorderWidth = 0.0!
        Me.GLabel3.FeatherState = False
        Me.GLabel3.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLabel3.ForeColor = System.Drawing.Color.White
        Me.GLabel3.Glow = 2
        Me.GLabel3.GlowColor = System.Drawing.Color.White
        Me.GLabel3.Location = New System.Drawing.Point(9, 724)
        Me.GLabel3.Margin = New System.Windows.Forms.Padding(0)
        Me.GLabel3.Name = "GLabel3"
        Me.GLabel3.ShadowColor = System.Drawing.Color.Black
        Me.GLabel3.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.GLabel3.Size = New System.Drawing.Size(1479, 29)
        Me.GLabel3.TabIndex = 66
        Me.GLabel3.Text = "You can not perform background download of this content."
        '
        'PsSeparator1
        '
        Me.PsSeparator1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PsSeparator1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PsSeparator1.ForeColor = System.Drawing.Color.Gainsboro
        Me.PsSeparator1.Location = New System.Drawing.Point(-1, 756)
        Me.PsSeparator1.Name = "PsSeparator1"
        Me.PsSeparator1.Size = New System.Drawing.Size(1499, 20)
        Me.PsSeparator1.TabIndex = 67
        '
        'PsSeparator2
        '
        Me.PsSeparator2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PsSeparator2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PsSeparator2.ForeColor = System.Drawing.Color.Gainsboro
        Me.PsSeparator2.Location = New System.Drawing.Point(-1, 3)
        Me.PsSeparator2.Name = "PsSeparator2"
        Me.PsSeparator2.Size = New System.Drawing.Size(1499, 20)
        Me.PsSeparator2.TabIndex = 68
        '
        'GLabel4
        '
        Me.GLabel4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GLabel4.BackColor = System.Drawing.Color.Transparent
        Me.GLabel4.BorderWidth = 0.0!
        Me.GLabel4.FeatherState = False
        Me.GLabel4.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLabel4.ForeColor = System.Drawing.Color.White
        Me.GLabel4.Glow = 2
        Me.GLabel4.GlowColor = System.Drawing.Color.White
        Me.GLabel4.Location = New System.Drawing.Point(7, 772)
        Me.GLabel4.Margin = New System.Windows.Forms.Padding(0)
        Me.GLabel4.Name = "GLabel4"
        Me.GLabel4.ShadowColor = System.Drawing.Color.Black
        Me.GLabel4.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.GLabel4.Size = New System.Drawing.Size(1479, 29)
        Me.GLabel4.TabIndex = 69
        Me.GLabel4.Text = "Cancel"
        '
        'DLS
        '
        Me.DLS.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DLS.BackColor = System.Drawing.Color.Transparent
        Me.DLS.BorderWidth = 0.0!
        Me.DLS.FeatherState = False
        Me.DLS.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DLS.ForeColor = System.Drawing.Color.White
        Me.DLS.Glow = 2
        Me.DLS.GlowColor = System.Drawing.Color.White
        Me.DLS.Location = New System.Drawing.Point(518, 370)
        Me.DLS.Margin = New System.Windows.Forms.Padding(0)
        Me.DLS.Name = "DLS"
        Me.DLS.ShadowColor = System.Drawing.Color.Black
        Me.DLS.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.DLS.Size = New System.Drawing.Size(346, 25)
        Me.DLS.TabIndex = 70
        Me.DLS.Text = "0 kb/s"
        Me.DLS.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ControllerInputTimer
        '
        '
        'ETAS
        '
        Me.ETAS.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ETAS.BackColor = System.Drawing.Color.Transparent
        Me.ETAS.BorderWidth = 0.0!
        Me.ETAS.FeatherState = False
        Me.ETAS.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ETAS.ForeColor = System.Drawing.Color.White
        Me.ETAS.Glow = 2
        Me.ETAS.GlowColor = System.Drawing.Color.White
        Me.ETAS.Location = New System.Drawing.Point(1037, 409)
        Me.ETAS.Margin = New System.Windows.Forms.Padding(0)
        Me.ETAS.Name = "ETAS"
        Me.ETAS.ShadowColor = System.Drawing.Color.Black
        Me.ETAS.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.ETAS.Size = New System.Drawing.Size(249, 25)
        Me.ETAS.TabIndex = 71
        Me.ETAS.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.ETAS.Visible = False
        '
        'AdviceIco
        '
        Me.AdviceIco.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.AdviceIco.BackColor = System.Drawing.Color.Transparent
        Me.AdviceIco.Image = Global.XMBPC.My.Resources.Resources.circle
        Me.AdviceIco.Location = New System.Drawing.Point(680, 771)
        Me.AdviceIco.Name = "AdviceIco"
        Me.AdviceIco.Size = New System.Drawing.Size(32, 32)
        Me.AdviceIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.AdviceIco.TabIndex = 72
        Me.AdviceIco.TabStop = False
        '
        'DownloadArt
        '
        Me.DownloadArt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DownloadArt.Image = Global.XMBPC.My.Resources.Resources.game_tex_default_dxt
        Me.DownloadArt.Location = New System.Drawing.Point(183, 276)
        Me.DownloadArt.Name = "DownloadArt"
        Me.DownloadArt.Size = New System.Drawing.Size(279, 162)
        Me.DownloadArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.DownloadArt.TabIndex = 0
        Me.DownloadArt.TabStop = False
        '
        'BackgroundDownload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1497, 809)
        Me.Controls.Add(Me.AdviceIco)
        Me.Controls.Add(Me.ETAS)
        Me.Controls.Add(Me.DLS)
        Me.Controls.Add(Me.GLabel4)
        Me.Controls.Add(Me.PsSeparator2)
        Me.Controls.Add(Me.PsSeparator1)
        Me.Controls.Add(Me.GLabel3)
        Me.Controls.Add(Me.ETA)
        Me.Controls.Add(Me.GLabel1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.PackageText)
        Me.Controls.Add(Me.DownloadArt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BackgroundDownload"
        Me.Text = "BackgroundDownload"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.AdviceIco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DownloadArt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DownloadArt As System.Windows.Forms.PictureBox
    Friend WithEvents PackageText As gLabel.gLabel
    Friend WithEvents ProgressBar1 As MetroControls.MetroProgressbar
    Friend WithEvents GLabel1 As gLabel.gLabel
    Friend WithEvents ETA As gLabel.gLabel
    Friend WithEvents GLabel3 As gLabel.gLabel
    Friend WithEvents PsSeparator1 As PSControls.PSSeparator
    Friend WithEvents PsSeparator2 As PSControls.PSSeparator
    Friend WithEvents GLabel4 As gLabel.gLabel
    Friend WithEvents DLS As gLabel.gLabel
    Friend WithEvents ControllerInputTimer As System.Windows.Forms.Timer
    Friend WithEvents ETAS As gLabel.gLabel
    Friend WithEvents AdviceIco As System.Windows.Forms.PictureBox
End Class

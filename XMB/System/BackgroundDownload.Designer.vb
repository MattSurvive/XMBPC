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
        Me.BackGroundAdviceTxt = New gLabel.gLabel()
        Me.ETA = New gLabel.gLabel()
        Me.BackGroundDLTxt = New gLabel.gLabel()
        Me.PsSeparator1 = New PSControls.PSSeparator()
        Me.PsSeparator2 = New PSControls.PSSeparator()
        Me.GLabel4 = New gLabel.gLabel()
        Me.DLS = New gLabel.gLabel()
        Me.ControllerInputTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ETAS = New gLabel.gLabel()
        Me.AdviceIco = New System.Windows.Forms.PictureBox()
        Me.DownloadArt = New System.Windows.Forms.PictureBox()
        Me.KeyboardTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.AdviceIco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DownloadArt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PackageText
        '
        Me.PackageText.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PackageText.BackColor = System.Drawing.Color.Transparent
        Me.PackageText.BorderWidth = 0!
        Me.PackageText.FeatherState = False
        Me.PackageText.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PackageText.ForeColor = System.Drawing.Color.White
        Me.PackageText.Glow = 3
        Me.PackageText.GlowColor = System.Drawing.Color.White
        Me.PackageText.Location = New System.Drawing.Point(266, 678)
        Me.PackageText.Margin = New System.Windows.Forms.Padding(0)
        Me.PackageText.Name = "PackageText"
        Me.PackageText.ShadowColor = System.Drawing.Color.Black
        Me.PackageText.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.PackageText.Size = New System.Drawing.Size(428, 142)
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
        Me.ProgressBar1.Location = New System.Drawing.Point(783, 609)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ProgressBar1.Maximum = 100
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1146, 15)
        Me.ProgressBar1.TabIndex = 63
        Me.ProgressBar1.Value = 0
        '
        'BackGroundAdviceTxt
        '
        Me.BackGroundAdviceTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BackGroundAdviceTxt.BackColor = System.Drawing.Color.Transparent
        Me.BackGroundAdviceTxt.BorderWidth = 0!
        Me.BackGroundAdviceTxt.FeatherState = False
        Me.BackGroundAdviceTxt.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BackGroundAdviceTxt.ForeColor = System.Drawing.Color.White
        Me.BackGroundAdviceTxt.Glow = 2
        Me.BackGroundAdviceTxt.GlowColor = System.Drawing.Color.White
        Me.BackGroundAdviceTxt.Location = New System.Drawing.Point(777, 425)
        Me.BackGroundAdviceTxt.Margin = New System.Windows.Forms.Padding(0)
        Me.BackGroundAdviceTxt.Name = "BackGroundAdviceTxt"
        Me.BackGroundAdviceTxt.ShadowColor = System.Drawing.Color.Black
        Me.BackGroundAdviceTxt.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.BackGroundAdviceTxt.Size = New System.Drawing.Size(1152, 140)
        Me.BackGroundAdviceTxt.TabIndex = 64
        Me.BackGroundAdviceTxt.Text = "          Downloading selected data..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Do not turn off system.         "
        '
        'ETA
        '
        Me.ETA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ETA.BackColor = System.Drawing.Color.Transparent
        Me.ETA.BorderWidth = 0!
        Me.ETA.FeatherState = False
        Me.ETA.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ETA.ForeColor = System.Drawing.Color.White
        Me.ETA.Glow = 2
        Me.ETA.GlowColor = System.Drawing.Color.White
        Me.ETA.Location = New System.Drawing.Point(1556, 569)
        Me.ETA.Margin = New System.Windows.Forms.Padding(0)
        Me.ETA.Name = "ETA"
        Me.ETA.ShadowColor = System.Drawing.Color.Black
        Me.ETA.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.ETA.Size = New System.Drawing.Size(374, 38)
        Me.ETA.TabIndex = 65
        Me.ETA.Text = "00 Seconds left."
        Me.ETA.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'BackGroundDLTxt
        '
        Me.BackGroundDLTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BackGroundDLTxt.BackColor = System.Drawing.Color.Transparent
        Me.BackGroundDLTxt.BorderWidth = 0!
        Me.BackGroundDLTxt.FeatherState = False
        Me.BackGroundDLTxt.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BackGroundDLTxt.ForeColor = System.Drawing.Color.White
        Me.BackGroundDLTxt.Glow = 2
        Me.BackGroundDLTxt.GlowColor = System.Drawing.Color.White
        Me.BackGroundDLTxt.Location = New System.Drawing.Point(14, 1114)
        Me.BackGroundDLTxt.Margin = New System.Windows.Forms.Padding(0)
        Me.BackGroundDLTxt.Name = "BackGroundDLTxt"
        Me.BackGroundDLTxt.ShadowColor = System.Drawing.Color.Black
        Me.BackGroundDLTxt.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.BackGroundDLTxt.Size = New System.Drawing.Size(2218, 45)
        Me.BackGroundDLTxt.TabIndex = 66
        Me.BackGroundDLTxt.Text = "You can not perform background download of this content."
        '
        'PsSeparator1
        '
        Me.PsSeparator1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PsSeparator1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PsSeparator1.ForeColor = System.Drawing.Color.Gainsboro
        Me.PsSeparator1.Location = New System.Drawing.Point(0, 1163)
        Me.PsSeparator1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PsSeparator1.Name = "PsSeparator1"
        Me.PsSeparator1.Size = New System.Drawing.Size(2248, 31)
        Me.PsSeparator1.TabIndex = 67
        '
        'PsSeparator2
        '
        Me.PsSeparator2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PsSeparator2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PsSeparator2.ForeColor = System.Drawing.Color.Gainsboro
        Me.PsSeparator2.Location = New System.Drawing.Point(0, 37)
        Me.PsSeparator2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PsSeparator2.Name = "PsSeparator2"
        Me.PsSeparator2.Size = New System.Drawing.Size(2248, 31)
        Me.PsSeparator2.TabIndex = 68
        '
        'GLabel4
        '
        Me.GLabel4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GLabel4.BackColor = System.Drawing.Color.Transparent
        Me.GLabel4.BorderWidth = 0!
        Me.GLabel4.FeatherState = False
        Me.GLabel4.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLabel4.ForeColor = System.Drawing.Color.White
        Me.GLabel4.Glow = 2
        Me.GLabel4.GlowColor = System.Drawing.Color.White
        Me.GLabel4.Location = New System.Drawing.Point(1059, 1188)
        Me.GLabel4.Margin = New System.Windows.Forms.Padding(0)
        Me.GLabel4.Name = "GLabel4"
        Me.GLabel4.ShadowColor = System.Drawing.Color.Black
        Me.GLabel4.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.GLabel4.Size = New System.Drawing.Size(482, 49)
        Me.GLabel4.TabIndex = 69
        Me.GLabel4.Text = "Cancel"
        Me.GLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DLS
        '
        Me.DLS.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DLS.BackColor = System.Drawing.Color.Transparent
        Me.DLS.BorderWidth = 0!
        Me.DLS.FeatherState = False
        Me.DLS.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DLS.ForeColor = System.Drawing.Color.White
        Me.DLS.Glow = 2
        Me.DLS.GlowColor = System.Drawing.Color.White
        Me.DLS.Location = New System.Drawing.Point(777, 569)
        Me.DLS.Margin = New System.Windows.Forms.Padding(0)
        Me.DLS.Name = "DLS"
        Me.DLS.ShadowColor = System.Drawing.Color.Black
        Me.DLS.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.DLS.Size = New System.Drawing.Size(519, 38)
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
        Me.ETAS.BorderWidth = 0!
        Me.ETAS.FeatherState = False
        Me.ETAS.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ETAS.ForeColor = System.Drawing.Color.White
        Me.ETAS.Glow = 2
        Me.ETAS.GlowColor = System.Drawing.Color.White
        Me.ETAS.Location = New System.Drawing.Point(1556, 629)
        Me.ETAS.Margin = New System.Windows.Forms.Padding(0)
        Me.ETAS.Name = "ETAS"
        Me.ETAS.ShadowColor = System.Drawing.Color.Black
        Me.ETAS.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.ETAS.Size = New System.Drawing.Size(374, 38)
        Me.ETAS.TabIndex = 71
        Me.ETAS.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.ETAS.Visible = False
        '
        'AdviceIco
        '
        Me.AdviceIco.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AdviceIco.BackColor = System.Drawing.Color.Transparent
        Me.AdviceIco.Image = Global.XMBPC.My.Resources.Resources.circle
        Me.AdviceIco.Location = New System.Drawing.Point(1006, 1188)
        Me.AdviceIco.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AdviceIco.Name = "AdviceIco"
        Me.AdviceIco.Size = New System.Drawing.Size(48, 49)
        Me.AdviceIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AdviceIco.TabIndex = 72
        Me.AdviceIco.TabStop = False
        '
        'DownloadArt
        '
        Me.DownloadArt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DownloadArt.Image = Global.XMBPC.My.Resources.Resources.game_tex_default_dxt
        Me.DownloadArt.Location = New System.Drawing.Point(274, 425)
        Me.DownloadArt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DownloadArt.Name = "DownloadArt"
        Me.DownloadArt.Size = New System.Drawing.Size(418, 249)
        Me.DownloadArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.DownloadArt.TabIndex = 0
        Me.DownloadArt.TabStop = False
        '
        'KeyboardTimer
        '
        '
        'BackgroundDownload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(2246, 1245)
        Me.Controls.Add(Me.AdviceIco)
        Me.Controls.Add(Me.ETAS)
        Me.Controls.Add(Me.DLS)
        Me.Controls.Add(Me.GLabel4)
        Me.Controls.Add(Me.PsSeparator2)
        Me.Controls.Add(Me.PsSeparator1)
        Me.Controls.Add(Me.BackGroundDLTxt)
        Me.Controls.Add(Me.ETA)
        Me.Controls.Add(Me.BackGroundAdviceTxt)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.PackageText)
        Me.Controls.Add(Me.DownloadArt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "BackgroundDownload"
        Me.Text = "BackgroundDownload"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.AdviceIco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DownloadArt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DownloadArt As System.Windows.Forms.PictureBox
    Friend WithEvents PackageText As gLabel.gLabel
    Friend WithEvents ProgressBar1 As MetroControls.MetroProgressbar
    Friend WithEvents BackGroundAdviceTxt As gLabel.gLabel
    Friend WithEvents ETA As gLabel.gLabel
    Friend WithEvents BackGroundDLTxt As gLabel.gLabel
    Friend WithEvents PsSeparator1 As PSControls.PSSeparator
    Friend WithEvents PsSeparator2 As PSControls.PSSeparator
    Friend WithEvents GLabel4 As gLabel.gLabel
    Friend WithEvents DLS As gLabel.gLabel
    Friend WithEvents ControllerInputTimer As System.Windows.Forms.Timer
    Friend WithEvents ETAS As gLabel.gLabel
    Friend WithEvents AdviceIco As System.Windows.Forms.PictureBox
    Friend WithEvents KeyboardTimer As System.Windows.Forms.Timer
End Class

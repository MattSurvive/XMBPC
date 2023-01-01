<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewSetup_SecondPart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewSetup_SecondPart))
        Me.AllGamesList = New System.Windows.Forms.TextBox()
        Me.GamesTxt = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PicturesPath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.VideosPath = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MusicPath = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FolderBrowser = New System.Windows.Forms.FolderBrowserDialog()
        Me.FileBrowser = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContinueBox = New System.Windows.Forms.PictureBox()
        Me.CoverPic = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContinueBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CoverPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AllGamesList
        '
        Me.AllGamesList.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AllGamesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AllGamesList.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AllGamesList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AllGamesList.Location = New System.Drawing.Point(165, 665)
        Me.AllGamesList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AllGamesList.Multiline = True
        Me.AllGamesList.Name = "AllGamesList"
        Me.AllGamesList.Size = New System.Drawing.Size(1692, 260)
        Me.AllGamesList.TabIndex = 4
        Me.AllGamesList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GamesTxt
        '
        Me.GamesTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GamesTxt.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GamesTxt.ForeColor = System.Drawing.Color.White
        Me.GamesTxt.Location = New System.Drawing.Point(157, 614)
        Me.GamesTxt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.GamesTxt.Name = "GamesTxt"
        Me.GamesTxt.Size = New System.Drawing.Size(1700, 46)
        Me.GamesTxt.TabIndex = 16
        Me.GamesTxt.Text = "Add games (supported files: .iso/.cso/.gcm/.nes/.gb/.gba/.gbc/.nds/.bin/.smc/.exe" &
    "/.smd/.url):"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 1037)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1894, 34)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "XMBPC v4"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label3.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(152, 457)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1705, 46)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Add custom pictures folders:"
        '
        'PicturesPath
        '
        Me.PicturesPath.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PicturesPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicturesPath.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicturesPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PicturesPath.Location = New System.Drawing.Point(160, 508)
        Me.PicturesPath.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PicturesPath.Multiline = True
        Me.PicturesPath.Name = "PicturesPath"
        Me.PicturesPath.Size = New System.Drawing.Size(1697, 96)
        Me.PicturesPath.TabIndex = 3
        Me.PicturesPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(157, 300)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1700, 46)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Add custom video folders:"
        '
        'VideosPath
        '
        Me.VideosPath.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.VideosPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VideosPath.Cursor = System.Windows.Forms.Cursors.Hand
        Me.VideosPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VideosPath.Location = New System.Drawing.Point(159, 351)
        Me.VideosPath.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.VideosPath.Multiline = True
        Me.VideosPath.Name = "VideosPath"
        Me.VideosPath.Size = New System.Drawing.Size(1698, 96)
        Me.VideosPath.TabIndex = 2
        Me.VideosPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(157, 143)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1700, 46)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Add custom music folders:"
        '
        'MusicPath
        '
        Me.MusicPath.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MusicPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MusicPath.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MusicPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MusicPath.Location = New System.Drawing.Point(159, 194)
        Me.MusicPath.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MusicPath.Multiline = True
        Me.MusicPath.Name = "MusicPath"
        Me.MusicPath.Size = New System.Drawing.Size(1698, 96)
        Me.MusicPath.TabIndex = 1
        Me.MusicPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(13, 37)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(1894, 60)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Add Music, Videos, Pictures And Games"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FileBrowser
        '
        Me.FileBrowser.DereferenceLinks = False
        Me.FileBrowser.Multiselect = True
        Me.FileBrowser.Title = "Select all your games"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox4.Image = Global.XMBPC.My.Resources.Resources.search_icon
        Me.PictureBox4.Location = New System.Drawing.Point(165, 949)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(72, 72)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 30
        Me.PictureBox4.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox4, "Save & Start XMBPC")
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox3.Image = Global.XMBPC.My.Resources.Resources.music_icon
        Me.PictureBox3.Location = New System.Drawing.Point(53, 143)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(96, 96)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 26
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox2.Image = Global.XMBPC.My.Resources.Resources.video_icon
        Me.PictureBox2.Location = New System.Drawing.Point(53, 300)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(96, 96)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 23
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = Global.XMBPC.My.Resources.Resources.pictures_icon
        Me.PictureBox1.Location = New System.Drawing.Point(53, 457)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(96, 96)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'ContinueBox
        '
        Me.ContinueBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ContinueBox.BackColor = System.Drawing.Color.Transparent
        Me.ContinueBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ContinueBox.Image = Global.XMBPC.My.Resources.Resources.next_2_icon
        Me.ContinueBox.Location = New System.Drawing.Point(1785, 949)
        Me.ContinueBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ContinueBox.Name = "ContinueBox"
        Me.ContinueBox.Size = New System.Drawing.Size(72, 72)
        Me.ContinueBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ContinueBox.TabIndex = 3
        Me.ContinueBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.ContinueBox, "Save & Start XMBPC")
        '
        'CoverPic
        '
        Me.CoverPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CoverPic.Image = Global.XMBPC.My.Resources.Resources.games_icon
        Me.CoverPic.Location = New System.Drawing.Point(53, 614)
        Me.CoverPic.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CoverPic.Name = "CoverPic"
        Me.CoverPic.Size = New System.Drawing.Size(96, 96)
        Me.CoverPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.CoverPic.TabIndex = 1
        Me.CoverPic.TabStop = False
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(245, 949)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(189, 72)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Detect Games and Library"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(1588, 949)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(189, 72)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Continue"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NewSetup_SecondPart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(1920, 1080)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.MusicPath)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.VideosPath)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PicturesPath)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GamesTxt)
        Me.Controls.Add(Me.ContinueBox)
        Me.Controls.Add(Me.AllGamesList)
        Me.Controls.Add(Me.CoverPic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewSetup_SecondPart"
        Me.Text = "NewSetup"
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContinueBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CoverPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CoverPic As System.Windows.Forms.PictureBox
    Friend WithEvents AllGamesList As System.Windows.Forms.TextBox
    Friend WithEvents ContinueBox As System.Windows.Forms.PictureBox
    Friend WithEvents GamesTxt As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PicturesPath As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents VideosPath As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MusicPath As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents FolderBrowser As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents FileBrowser As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class

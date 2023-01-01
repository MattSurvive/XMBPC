<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VideoPlayer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VideoPlayer))
        Me.ControllerInputTimer = New System.Windows.Forms.Timer(Me.components)
        Me.HelpBox = New System.Windows.Forms.PictureBox()
        Me.KeyboardTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FramerateTxt = New gLabel.gLabel()
        CType(Me.HelpBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ControllerInputTimer
        '
        '
        'HelpBox
        '
        Me.HelpBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.HelpBox.BackColor = System.Drawing.Color.Transparent
        Me.HelpBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HelpBox.Image = Global.XMBPC.My.Resources.Resources.help_videomusic_player
        Me.HelpBox.Location = New System.Drawing.Point(420, 94)
        Me.HelpBox.Name = "HelpBox"
        Me.HelpBox.Size = New System.Drawing.Size(702, 502)
        Me.HelpBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.HelpBox.TabIndex = 106
        Me.HelpBox.TabStop = False
        Me.HelpBox.Visible = False
        '
        'KeyboardTimer
        '
        '
        'FramerateTxt
        '
        Me.FramerateTxt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FramerateTxt.BackColor = System.Drawing.Color.Black
        Me.FramerateTxt.BorderWidth = 0.0!
        Me.FramerateTxt.FeatherState = False
        Me.FramerateTxt.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FramerateTxt.ForeColor = System.Drawing.Color.White
        Me.FramerateTxt.GlowState = False
        Me.FramerateTxt.Location = New System.Drawing.Point(1007, 674)
        Me.FramerateTxt.Margin = New System.Windows.Forms.Padding(0)
        Me.FramerateTxt.Name = "FramerateTxt"
        Me.FramerateTxt.ShadowColor = System.Drawing.Color.Black
        Me.FramerateTxt.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.FramerateTxt.Size = New System.Drawing.Size(481, 126)
        Me.FramerateTxt.TabIndex = 109
        Me.FramerateTxt.Text = "Turn Off System"
        Me.FramerateTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.FramerateTxt.Visible = False
        '
        'VideoPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1497, 809)
        Me.ControlBox = False
        Me.Controls.Add(Me.FramerateTxt)
        Me.Controls.Add(Me.HelpBox)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VideoPlayer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "VideoPlayer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.HelpBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ControllerInputTimer As System.Windows.Forms.Timer
    Friend WithEvents HelpBox As System.Windows.Forms.PictureBox
    Friend WithEvents KeyboardTimer As System.Windows.Forms.Timer
    Friend WithEvents FramerateTxt As gLabel.gLabel
End Class

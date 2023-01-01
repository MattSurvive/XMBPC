<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SystemDialog))
        Me.DialogTxt = New gLabel.gLabel()
        Me.PsSeparator1 = New PSControls.PSSeparator()
        Me.PsSeparator2 = New PSControls.PSSeparator()
        Me.ContinueTxt = New gLabel.gLabel()
        Me.ControllerInputTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MsgIco = New System.Windows.Forms.PictureBox()
        Me.KeyboardTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MsgIco2 = New System.Windows.Forms.PictureBox()
        Me.CancelTxt = New gLabel.gLabel()
        CType(Me.MsgIco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MsgIco2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DialogTxt
        '
        Me.DialogTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DialogTxt.BackColor = System.Drawing.Color.Transparent
        Me.DialogTxt.BorderWidth = 0.0!
        Me.DialogTxt.FeatherState = False
        Me.DialogTxt.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DialogTxt.ForeColor = System.Drawing.Color.White
        Me.DialogTxt.Glow = 2
        Me.DialogTxt.GlowColor = System.Drawing.Color.White
        Me.DialogTxt.Location = New System.Drawing.Point(203, 306)
        Me.DialogTxt.Margin = New System.Windows.Forms.Padding(0)
        Me.DialogTxt.Name = "DialogTxt"
        Me.DialogTxt.ShadowColor = System.Drawing.Color.Black
        Me.DialogTxt.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.DialogTxt.Size = New System.Drawing.Size(1089, 91)
        Me.DialogTxt.TabIndex = 64
        Me.DialogTxt.Text = "%SYSTEM_MESSAGE_DIALOG_TITLE%" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "%SYSTEM_MESSAGE_DIALOG_TEXT%"
        '
        'PsSeparator1
        '
        Me.PsSeparator1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PsSeparator1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PsSeparator1.ForeColor = System.Drawing.Color.Gainsboro
        Me.PsSeparator1.Location = New System.Drawing.Point(0, 756)
        Me.PsSeparator1.Name = "PsSeparator1"
        Me.PsSeparator1.Size = New System.Drawing.Size(1499, 20)
        Me.PsSeparator1.TabIndex = 67
        '
        'PsSeparator2
        '
        Me.PsSeparator2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PsSeparator2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PsSeparator2.ForeColor = System.Drawing.Color.Gainsboro
        Me.PsSeparator2.Location = New System.Drawing.Point(0, 24)
        Me.PsSeparator2.Name = "PsSeparator2"
        Me.PsSeparator2.Size = New System.Drawing.Size(1499, 20)
        Me.PsSeparator2.TabIndex = 68
        '
        'ContinueTxt
        '
        Me.ContinueTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ContinueTxt.BackColor = System.Drawing.Color.Transparent
        Me.ContinueTxt.BorderWidth = 0.0!
        Me.ContinueTxt.FeatherState = False
        Me.ContinueTxt.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContinueTxt.ForeColor = System.Drawing.Color.White
        Me.ContinueTxt.Glow = 2
        Me.ContinueTxt.GlowColor = System.Drawing.Color.White
        Me.ContinueTxt.Location = New System.Drawing.Point(542, 774)
        Me.ContinueTxt.Margin = New System.Windows.Forms.Padding(0)
        Me.ContinueTxt.Name = "ContinueTxt"
        Me.ContinueTxt.ShadowColor = System.Drawing.Color.Black
        Me.ContinueTxt.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.ContinueTxt.Size = New System.Drawing.Size(209, 32)
        Me.ContinueTxt.TabIndex = 69
        Me.ContinueTxt.Text = "Continue"
        Me.ContinueTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ControllerInputTimer
        '
        '
        'MsgIco
        '
        Me.MsgIco.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MsgIco.BackColor = System.Drawing.Color.Transparent
        Me.MsgIco.Image = Global.XMBPC.My.Resources.Resources.cross1
        Me.MsgIco.Location = New System.Drawing.Point(507, 774)
        Me.MsgIco.Name = "MsgIco"
        Me.MsgIco.Size = New System.Drawing.Size(32, 32)
        Me.MsgIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MsgIco.TabIndex = 72
        Me.MsgIco.TabStop = False
        '
        'KeyboardTimer
        '
        '
        'MsgIco2
        '
        Me.MsgIco2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MsgIco2.BackColor = System.Drawing.Color.Transparent
        Me.MsgIco2.Image = Global.XMBPC.My.Resources.Resources.circle
        Me.MsgIco2.Location = New System.Drawing.Point(754, 774)
        Me.MsgIco2.Name = "MsgIco2"
        Me.MsgIco2.Size = New System.Drawing.Size(32, 32)
        Me.MsgIco2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MsgIco2.TabIndex = 74
        Me.MsgIco2.TabStop = False
        '
        'CancelTxt
        '
        Me.CancelTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CancelTxt.BackColor = System.Drawing.Color.Transparent
        Me.CancelTxt.BorderWidth = 0.0!
        Me.CancelTxt.FeatherState = False
        Me.CancelTxt.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelTxt.ForeColor = System.Drawing.Color.White
        Me.CancelTxt.Glow = 2
        Me.CancelTxt.GlowColor = System.Drawing.Color.White
        Me.CancelTxt.Location = New System.Drawing.Point(789, 774)
        Me.CancelTxt.Margin = New System.Windows.Forms.Padding(0)
        Me.CancelTxt.Name = "CancelTxt"
        Me.CancelTxt.ShadowColor = System.Drawing.Color.Black
        Me.CancelTxt.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.CancelTxt.Size = New System.Drawing.Size(209, 32)
        Me.CancelTxt.TabIndex = 73
        Me.CancelTxt.Text = "Cancel"
        Me.CancelTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SystemDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1497, 809)
        Me.Controls.Add(Me.MsgIco2)
        Me.Controls.Add(Me.CancelTxt)
        Me.Controls.Add(Me.MsgIco)
        Me.Controls.Add(Me.ContinueTxt)
        Me.Controls.Add(Me.PsSeparator2)
        Me.Controls.Add(Me.PsSeparator1)
        Me.Controls.Add(Me.DialogTxt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SystemDialog"
        Me.Text = "BackgroundDownload"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MsgIco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MsgIco2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DialogTxt As gLabel.gLabel
    Friend WithEvents PsSeparator1 As PSControls.PSSeparator
    Friend WithEvents PsSeparator2 As PSControls.PSSeparator
    Friend WithEvents ContinueTxt As gLabel.gLabel
    Friend WithEvents ControllerInputTimer As System.Windows.Forms.Timer
    Friend WithEvents MsgIco As System.Windows.Forms.PictureBox
    Friend WithEvents KeyboardTimer As System.Windows.Forms.Timer
    Friend WithEvents MsgIco2 As System.Windows.Forms.PictureBox
    Friend WithEvents CancelTxt As gLabel.gLabel
End Class

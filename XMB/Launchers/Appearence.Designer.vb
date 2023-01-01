<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Appearence
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Appearence))
        Me.BGPreview = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.T1 = New System.Windows.Forms.PictureBox()
        Me.T2 = New System.Windows.Forms.PictureBox()
        Me.T3 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBBG = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.BGPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBBG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BGPreview
        '
        Me.BGPreview.BackColor = System.Drawing.Color.Transparent
        Me.BGPreview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BGPreview.Image = Global.XMBPC.My.Resources.Resources.Windows_7_Official_Pastel_Aurora_windows_7_wallpapers_windows_wallpapers_computer_wallpapers_1920x1080
        Me.BGPreview.Location = New System.Drawing.Point(38, 49)
        Me.BGPreview.Name = "BGPreview"
        Me.BGPreview.Size = New System.Drawing.Size(729, 293)
        Me.BGPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BGPreview.TabIndex = 0
        Me.BGPreview.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BGPreview, "Click to select a new background")
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(275, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(245, 37)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Desktop Background"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'T1
        '
        Me.T1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.T1.BackColor = System.Drawing.Color.Transparent
        Me.T1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.T1.Image = Global.XMBPC.My.Resources.Resources.taskbarbg
        Me.T1.Location = New System.Drawing.Point(138, 385)
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(61, 50)
        Me.T1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.T1.TabIndex = 3
        Me.T1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.T1, "Click to select")
        '
        'T2
        '
        Me.T2.BackColor = System.Drawing.Color.Transparent
        Me.T2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.T2.Image = Global.XMBPC.My.Resources.Resources.taskbarbg1
        Me.T2.Location = New System.Drawing.Point(367, 385)
        Me.T2.Name = "T2"
        Me.T2.Size = New System.Drawing.Size(61, 50)
        Me.T2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.T2.TabIndex = 4
        Me.T2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.T2, "Click to select")
        '
        'T3
        '
        Me.T3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.T3.BackColor = System.Drawing.Color.Transparent
        Me.T3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.T3.Image = Global.XMBPC.My.Resources.Resources.taskbarbg2
        Me.T3.Location = New System.Drawing.Point(596, 385)
        Me.T3.Name = "T3"
        Me.T3.Size = New System.Drawing.Size(61, 50)
        Me.T3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.T3.TabIndex = 5
        Me.T3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.T3, "Click to select")
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(272, 345)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(256, 37)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Taskbar Transparency"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TBBG
        '
        Me.TBBG.BackColor = System.Drawing.Color.Transparent
        Me.TBBG.Cursor = System.Windows.Forms.Cursors.Default
        Me.TBBG.Image = Global.XMBPC.My.Resources.Resources.Windows_7_Official_Pastel_Aurora_windows_7_wallpapers_windows_wallpapers_computer_wallpapers_1920x1080
        Me.TBBG.Location = New System.Drawing.Point(38, 385)
        Me.TBBG.Name = "TBBG"
        Me.TBBG.Size = New System.Drawing.Size(729, 50)
        Me.TBBG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TBBG.TabIndex = 6
        Me.TBBG.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "JPG files|*.jpg|JPEG files|*.jpeg|PNG files|*.png"
        Me.OpenFileDialog1.Title = "Select a new background"
        '
        'Appearence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(812, 452)
        Me.Controls.Add(Me.T3)
        Me.Controls.Add(Me.T2)
        Me.Controls.Add(Me.T1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BGPreview)
        Me.Controls.Add(Me.TBBG)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(828, 491)
        Me.MinimumSize = New System.Drawing.Size(828, 491)
        Me.Name = "Appearence"
        Me.Text = "Personalize XMB Desktop"
        CType(Me.BGPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBBG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BGPreview As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T1 As System.Windows.Forms.PictureBox
    Friend WithEvents T2 As System.Windows.Forms.PictureBox
    Friend WithEvents T3 As System.Windows.Forms.PictureBox
    Friend WithEvents TBBG As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class

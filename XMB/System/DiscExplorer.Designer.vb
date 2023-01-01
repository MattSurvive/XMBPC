<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DiscExplorer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DiscExplorer))
        Me.DiscIco = New System.Windows.Forms.PictureBox()
        Me.DiscTitle = New gLabel.gLabel()
        Me.FilesList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.KeyboardTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ControllerTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DiscIco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DiscIco
        '
        Me.DiscIco.BackColor = System.Drawing.Color.Transparent
        Me.DiscIco.Image = CType(resources.GetObject("DiscIco.Image"), System.Drawing.Image)
        Me.DiscIco.Location = New System.Drawing.Point(12, 12)
        Me.DiscIco.Name = "DiscIco"
        Me.DiscIco.Size = New System.Drawing.Size(96, 96)
        Me.DiscIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.DiscIco.TabIndex = 21
        Me.DiscIco.TabStop = False
        Me.DiscIco.Tag = ""
        '
        'DiscTitle
        '
        Me.DiscTitle.BackColor = System.Drawing.Color.Transparent
        Me.DiscTitle.BorderWidth = 0.0!
        Me.DiscTitle.FeatherState = False
        Me.DiscTitle.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiscTitle.ForeColor = System.Drawing.Color.White
        Me.DiscTitle.Glow = 3
        Me.DiscTitle.GlowColor = System.Drawing.Color.White
        Me.DiscTitle.Location = New System.Drawing.Point(111, 12)
        Me.DiscTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.DiscTitle.Name = "DiscTitle"
        Me.DiscTitle.ShadowColor = System.Drawing.Color.Black
        Me.DiscTitle.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.DiscTitle.Size = New System.Drawing.Size(1432, 96)
        Me.DiscTitle.TabIndex = 117
        Me.DiscTitle.Text = "No Disc Inserted"
        Me.DiscTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FilesList
        '
        Me.FilesList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FilesList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.FilesList.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FilesList.FullRowSelect = True
        Me.FilesList.GridLines = True
        Me.FilesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.FilesList.Location = New System.Drawing.Point(12, 114)
        Me.FilesList.MultiSelect = False
        Me.FilesList.Name = "FilesList"
        Me.FilesList.Size = New System.Drawing.Size(1528, 677)
        Me.FilesList.TabIndex = 118
        Me.FilesList.UseCompatibleStateImageBehavior = False
        Me.FilesList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Filename"
        Me.ColumnHeader1.Width = 617
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Type"
        Me.ColumnHeader2.Width = 116
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "XMBPC compatible"
        Me.ColumnHeader3.Width = 556
        '
        'KeyboardTimer
        '
        '
        'ControllerTimer
        '
        '
        'DiscExplorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1552, 803)
        Me.Controls.Add(Me.FilesList)
        Me.Controls.Add(Me.DiscTitle)
        Me.Controls.Add(Me.DiscIco)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DiscExplorer"
        Me.Text = "Disc Explorer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DiscIco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DiscIco As System.Windows.Forms.PictureBox
    Friend WithEvents DiscTitle As gLabel.gLabel
    Friend WithEvents FilesList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents KeyboardTimer As System.Windows.Forms.Timer
    Friend WithEvents ControllerTimer As System.Windows.Forms.Timer
End Class

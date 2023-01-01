<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileBrowser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileBrowser))
        Me.FilesList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ControllerInputTimer = New System.Windows.Forms.Timer(Me.components)
        Me.HelpBox = New System.Windows.Forms.PictureBox()
        Me.KeyboardTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.HelpBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FilesList
        '
        Me.FilesList.BackColor = System.Drawing.Color.Black
        Me.FilesList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FilesList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader4, Me.ColumnHeader3})
        Me.FilesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FilesList.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FilesList.ForeColor = System.Drawing.Color.White
        Me.FilesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.FilesList.Location = New System.Drawing.Point(0, 0)
        Me.FilesList.MultiSelect = False
        Me.FilesList.Name = "FilesList"
        Me.FilesList.Size = New System.Drawing.Size(1471, 815)
        Me.FilesList.TabIndex = 0
        Me.FilesList.UseCompatibleStateImageBehavior = False
        Me.FilesList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Path"
        Me.ColumnHeader1.Width = 699
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "File"
        Me.ColumnHeader2.Width = 527
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DisplayIndex = 3
        Me.ColumnHeader4.Text = "Type"
        Me.ColumnHeader4.Width = 92
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DisplayIndex = 2
        Me.ColumnHeader3.Text = "Size"
        Me.ColumnHeader3.Width = 153
        '
        'ControllerInputTimer
        '
        '
        'HelpBox
        '
        Me.HelpBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.HelpBox.BackColor = System.Drawing.Color.Transparent
        Me.HelpBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HelpBox.Image = Global.XMBPC.My.Resources.Resources.help_filebrowser
        Me.HelpBox.Location = New System.Drawing.Point(408, 138)
        Me.HelpBox.Name = "HelpBox"
        Me.HelpBox.Size = New System.Drawing.Size(702, 502)
        Me.HelpBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.HelpBox.TabIndex = 105
        Me.HelpBox.TabStop = False
        Me.HelpBox.Visible = False
        '
        'KeyboardTimer
        '
        '
        'FileBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1471, 815)
        Me.ControlBox = False
        Me.Controls.Add(Me.HelpBox)
        Me.Controls.Add(Me.FilesList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FileBrowser"
        Me.Text = "File Browser"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.HelpBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FilesList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ControllerInputTimer As System.Windows.Forms.Timer
    Friend WithEvents HelpBox As System.Windows.Forms.PictureBox
    Friend WithEvents KeyboardTimer As System.Windows.Forms.Timer
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Properties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Properties))
        Me.FileText = New System.Windows.Forms.TextBox()
        Me.FileIcon = New System.Windows.Forms.PictureBox()
        Me.PsSeparator1 = New PSControls.PSSeparator()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PsSeparator2 = New PSControls.PSSeparator()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PsSeparator3 = New PSControls.PSSeparator()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PsSeparator4 = New PSControls.PSSeparator()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.IsProtected = New System.Windows.Forms.CheckBox()
        Me.IsHidden = New System.Windows.Forms.CheckBox()
        Me.FileType = New System.Windows.Forms.Label()
        Me.OpensWith = New System.Windows.Forms.Label()
        Me.FilePath = New System.Windows.Forms.Label()
        Me.FileSize = New System.Windows.Forms.Label()
        Me.FileSizeOnHDD = New System.Windows.Forms.Label()
        Me.FileCreation = New System.Windows.Forms.Label()
        Me.FileChange = New System.Windows.Forms.Label()
        Me.FileLastAccess = New System.Windows.Forms.Label()
        Me.OKB = New System.Windows.Forms.Button()
        Me.AbortB = New System.Windows.Forms.Button()
        Me.AssumeB = New System.Windows.Forms.Button()
        Me.OpensWithIcon = New System.Windows.Forms.PictureBox()
        CType(Me.FileIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OpensWithIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FileText
        '
        Me.FileText.Location = New System.Drawing.Point(109, 19)
        Me.FileText.Name = "FileText"
        Me.FileText.Size = New System.Drawing.Size(272, 20)
        Me.FileText.TabIndex = 1
        '
        'FileIcon
        '
        Me.FileIcon.BackColor = System.Drawing.Color.Transparent
        Me.FileIcon.Location = New System.Drawing.Point(21, 12)
        Me.FileIcon.Name = "FileIcon"
        Me.FileIcon.Size = New System.Drawing.Size(32, 32)
        Me.FileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.FileIcon.TabIndex = 0
        Me.FileIcon.TabStop = False
        '
        'PsSeparator1
        '
        Me.PsSeparator1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.PsSeparator1.ForeColor = System.Drawing.Color.White
        Me.PsSeparator1.Location = New System.Drawing.Point(12, 50)
        Me.PsSeparator1.Name = "PsSeparator1"
        Me.PsSeparator1.Size = New System.Drawing.Size(369, 20)
        Me.PsSeparator1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Type of file:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Opens with:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Location:"
        '
        'PsSeparator2
        '
        Me.PsSeparator2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.PsSeparator2.ForeColor = System.Drawing.Color.White
        Me.PsSeparator2.Location = New System.Drawing.Point(12, 112)
        Me.PsSeparator2.Name = "PsSeparator2"
        Me.PsSeparator2.Size = New System.Drawing.Size(369, 20)
        Me.PsSeparator2.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Size:"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 29)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Size on disk:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PsSeparator3
        '
        Me.PsSeparator3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.PsSeparator3.ForeColor = System.Drawing.Color.White
        Me.PsSeparator3.Location = New System.Drawing.Point(12, 212)
        Me.PsSeparator3.Name = "PsSeparator3"
        Me.PsSeparator3.Size = New System.Drawing.Size(369, 20)
        Me.PsSeparator3.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 235)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Created:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 258)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Modified:"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(12, 282)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 28)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Accessed:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PsSeparator4
        '
        Me.PsSeparator4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.PsSeparator4.ForeColor = System.Drawing.Color.White
        Me.PsSeparator4.Location = New System.Drawing.Point(15, 313)
        Me.PsSeparator4.Name = "PsSeparator4"
        Me.PsSeparator4.Size = New System.Drawing.Size(369, 20)
        Me.PsSeparator4.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 336)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Attributes:"
        '
        'IsProtected
        '
        Me.IsProtected.AutoSize = True
        Me.IsProtected.Location = New System.Drawing.Point(109, 335)
        Me.IsProtected.Name = "IsProtected"
        Me.IsProtected.Size = New System.Drawing.Size(74, 17)
        Me.IsProtected.TabIndex = 15
        Me.IsProtected.Text = "Read-only"
        Me.IsProtected.UseVisualStyleBackColor = True
        '
        'IsHidden
        '
        Me.IsHidden.AutoSize = True
        Me.IsHidden.Location = New System.Drawing.Point(109, 358)
        Me.IsHidden.Name = "IsHidden"
        Me.IsHidden.Size = New System.Drawing.Size(60, 17)
        Me.IsHidden.TabIndex = 16
        Me.IsHidden.Text = "Hidden"
        Me.IsHidden.UseVisualStyleBackColor = True
        '
        'FileType
        '
        Me.FileType.AutoSize = True
        Me.FileType.Location = New System.Drawing.Point(106, 73)
        Me.FileType.Name = "FileType"
        Me.FileType.Size = New System.Drawing.Size(56, 13)
        Me.FileType.TabIndex = 17
        Me.FileType.Text = "Datei-Typ:"
        '
        'OpensWith
        '
        Me.OpensWith.AutoSize = True
        Me.OpensWith.Location = New System.Drawing.Point(131, 96)
        Me.OpensWith.Name = "OpensWith"
        Me.OpensWith.Size = New System.Drawing.Size(20, 13)
        Me.OpensWith.TabIndex = 18
        Me.OpensWith.Text = "(.*)"
        '
        'FilePath
        '
        Me.FilePath.AutoSize = True
        Me.FilePath.Location = New System.Drawing.Point(106, 135)
        Me.FilePath.Name = "FilePath"
        Me.FilePath.Size = New System.Drawing.Size(56, 13)
        Me.FilePath.TabIndex = 19
        Me.FilePath.Text = "Datei-Typ:"
        '
        'FileSize
        '
        Me.FileSize.AutoSize = True
        Me.FileSize.Location = New System.Drawing.Point(106, 158)
        Me.FileSize.Name = "FileSize"
        Me.FileSize.Size = New System.Drawing.Size(56, 13)
        Me.FileSize.TabIndex = 20
        Me.FileSize.Text = "Datei-Typ:"
        '
        'FileSizeOnHDD
        '
        Me.FileSizeOnHDD.AutoSize = True
        Me.FileSizeOnHDD.Location = New System.Drawing.Point(106, 188)
        Me.FileSizeOnHDD.Name = "FileSizeOnHDD"
        Me.FileSizeOnHDD.Size = New System.Drawing.Size(56, 13)
        Me.FileSizeOnHDD.TabIndex = 21
        Me.FileSizeOnHDD.Text = "Datei-Typ:"
        '
        'FileCreation
        '
        Me.FileCreation.AutoSize = True
        Me.FileCreation.Location = New System.Drawing.Point(106, 235)
        Me.FileCreation.Name = "FileCreation"
        Me.FileCreation.Size = New System.Drawing.Size(56, 13)
        Me.FileCreation.TabIndex = 22
        Me.FileCreation.Text = "Datei-Typ:"
        '
        'FileChange
        '
        Me.FileChange.AutoSize = True
        Me.FileChange.Location = New System.Drawing.Point(106, 258)
        Me.FileChange.Name = "FileChange"
        Me.FileChange.Size = New System.Drawing.Size(56, 13)
        Me.FileChange.TabIndex = 23
        Me.FileChange.Text = "Datei-Typ:"
        '
        'FileLastAccess
        '
        Me.FileLastAccess.AutoSize = True
        Me.FileLastAccess.Location = New System.Drawing.Point(106, 289)
        Me.FileLastAccess.Name = "FileLastAccess"
        Me.FileLastAccess.Size = New System.Drawing.Size(56, 13)
        Me.FileLastAccess.TabIndex = 24
        Me.FileLastAccess.Text = "Datei-Typ:"
        '
        'OKB
        '
        Me.OKB.Location = New System.Drawing.Point(136, 395)
        Me.OKB.Name = "OKB"
        Me.OKB.Size = New System.Drawing.Size(75, 23)
        Me.OKB.TabIndex = 25
        Me.OKB.Text = "OK"
        Me.OKB.UseVisualStyleBackColor = True
        '
        'AbortB
        '
        Me.AbortB.Enabled = False
        Me.AbortB.Location = New System.Drawing.Point(217, 395)
        Me.AbortB.Name = "AbortB"
        Me.AbortB.Size = New System.Drawing.Size(75, 23)
        Me.AbortB.TabIndex = 26
        Me.AbortB.Text = "Cancel"
        Me.AbortB.UseVisualStyleBackColor = True
        '
        'AssumeB
        '
        Me.AssumeB.Location = New System.Drawing.Point(298, 395)
        Me.AssumeB.Name = "AssumeB"
        Me.AssumeB.Size = New System.Drawing.Size(86, 23)
        Me.AssumeB.TabIndex = 27
        Me.AssumeB.Text = "Apply"
        Me.AssumeB.UseVisualStyleBackColor = True
        '
        'OpensWithIcon
        '
        Me.OpensWithIcon.BackColor = System.Drawing.Color.Transparent
        Me.OpensWithIcon.Location = New System.Drawing.Point(109, 95)
        Me.OpensWithIcon.Name = "OpensWithIcon"
        Me.OpensWithIcon.Size = New System.Drawing.Size(16, 16)
        Me.OpensWithIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.OpensWithIcon.TabIndex = 28
        Me.OpensWithIcon.TabStop = False
        '
        'Properties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 422)
        Me.Controls.Add(Me.OpensWithIcon)
        Me.Controls.Add(Me.AssumeB)
        Me.Controls.Add(Me.AbortB)
        Me.Controls.Add(Me.OKB)
        Me.Controls.Add(Me.FileLastAccess)
        Me.Controls.Add(Me.FileChange)
        Me.Controls.Add(Me.FileCreation)
        Me.Controls.Add(Me.FileSizeOnHDD)
        Me.Controls.Add(Me.FileSize)
        Me.Controls.Add(Me.FilePath)
        Me.Controls.Add(Me.OpensWith)
        Me.Controls.Add(Me.FileType)
        Me.Controls.Add(Me.IsHidden)
        Me.Controls.Add(Me.IsProtected)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PsSeparator4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PsSeparator3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PsSeparator2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PsSeparator1)
        Me.Controls.Add(Me.FileText)
        Me.Controls.Add(Me.FileIcon)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Properties"
        Me.Text = "Properties (Simplified)"
        CType(Me.FileIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OpensWithIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FileIcon As System.Windows.Forms.PictureBox
    Friend WithEvents FileText As System.Windows.Forms.TextBox
    Friend WithEvents PsSeparator1 As PSControls.PSSeparator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PsSeparator2 As PSControls.PSSeparator
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PsSeparator3 As PSControls.PSSeparator
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PsSeparator4 As PSControls.PSSeparator
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents IsProtected As System.Windows.Forms.CheckBox
    Friend WithEvents IsHidden As System.Windows.Forms.CheckBox
    Friend WithEvents FileType As System.Windows.Forms.Label
    Friend WithEvents OpensWith As System.Windows.Forms.Label
    Friend WithEvents FilePath As System.Windows.Forms.Label
    Friend WithEvents FileSize As System.Windows.Forms.Label
    Friend WithEvents FileSizeOnHDD As System.Windows.Forms.Label
    Friend WithEvents FileCreation As System.Windows.Forms.Label
    Friend WithEvents FileChange As System.Windows.Forms.Label
    Friend WithEvents FileLastAccess As System.Windows.Forms.Label
    Friend WithEvents OKB As System.Windows.Forms.Button
    Friend WithEvents AbortB As System.Windows.Forms.Button
    Friend WithEvents AssumeB As System.Windows.Forms.Button
    Friend WithEvents OpensWithIcon As System.Windows.Forms.PictureBox
End Class

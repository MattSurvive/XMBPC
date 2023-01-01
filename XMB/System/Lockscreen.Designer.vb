<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lockscreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Lockscreen))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PassTxt = New System.Windows.Forms.Label()
        Me.PasswordTxt = New System.Windows.Forms.TextBox()
        Me.UserTxt = New System.Windows.Forms.Label()
        Me.UsernameTxt = New System.Windows.Forms.TextBox()
        Me.ContinueBox = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContinueBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = Global.XMBPC.My.Resources.Resources._1396112114_user_male2
        Me.PictureBox1.Location = New System.Drawing.Point(672, 167)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'PassTxt
        '
        Me.PassTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PassTxt.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PassTxt.ForeColor = System.Drawing.Color.DimGray
        Me.PassTxt.Location = New System.Drawing.Point(623, 392)
        Me.PassTxt.Name = "PassTxt"
        Me.PassTxt.Size = New System.Drawing.Size(232, 36)
        Me.PassTxt.TabIndex = 22
        Me.PassTxt.Text = "Password:"
        Me.PassTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PasswordTxt
        '
        Me.PasswordTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PasswordTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordTxt.Location = New System.Drawing.Point(623, 431)
        Me.PasswordTxt.Name = "PasswordTxt"
        Me.PasswordTxt.Size = New System.Drawing.Size(232, 24)
        Me.PasswordTxt.TabIndex = 21
        Me.PasswordTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.PasswordTxt.UseSystemPasswordChar = True
        '
        'UserTxt
        '
        Me.UserTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.UserTxt.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserTxt.ForeColor = System.Drawing.Color.DimGray
        Me.UserTxt.Location = New System.Drawing.Point(623, 317)
        Me.UserTxt.Name = "UserTxt"
        Me.UserTxt.Size = New System.Drawing.Size(232, 36)
        Me.UserTxt.TabIndex = 20
        Me.UserTxt.Text = "Username:"
        Me.UserTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UsernameTxt
        '
        Me.UsernameTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.UsernameTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameTxt.Location = New System.Drawing.Point(623, 356)
        Me.UsernameTxt.Name = "UsernameTxt"
        Me.UsernameTxt.Size = New System.Drawing.Size(232, 24)
        Me.UsernameTxt.TabIndex = 19
        Me.UsernameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ContinueBox
        '
        Me.ContinueBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ContinueBox.BackColor = System.Drawing.Color.Transparent
        Me.ContinueBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ContinueBox.Image = Global.XMBPC.My.Resources.Resources.Arrow_Next_3_icon
        Me.ContinueBox.Location = New System.Drawing.Point(707, 491)
        Me.ContinueBox.Name = "ContinueBox"
        Me.ContinueBox.Size = New System.Drawing.Size(64, 64)
        Me.ContinueBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ContinueBox.TabIndex = 23
        Me.ContinueBox.TabStop = False
        '
        'Lockscreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(1541, 793)
        Me.Controls.Add(Me.ContinueBox)
        Me.Controls.Add(Me.PassTxt)
        Me.Controls.Add(Me.PasswordTxt)
        Me.Controls.Add(Me.UserTxt)
        Me.Controls.Add(Me.UsernameTxt)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Lockscreen"
        Me.Text = "Lockscreen"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContinueBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PassTxt As System.Windows.Forms.Label
    Friend WithEvents PasswordTxt As System.Windows.Forms.TextBox
    Friend WithEvents UserTxt As System.Windows.Forms.Label
    Friend WithEvents UsernameTxt As System.Windows.Forms.TextBox
    Friend WithEvents ContinueBox As System.Windows.Forms.PictureBox
End Class

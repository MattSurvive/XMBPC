<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewSetup))
        Me.SetupTxt = New gLabel.gLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.UsernameTxt = New System.Windows.Forms.TextBox()
        Me.LangBox = New System.Windows.Forms.ComboBox()
        Me.SelectLangTxt = New System.Windows.Forms.Label()
        Me.StartWithWin = New System.Windows.Forms.CheckBox()
        Me.StartWithWinTxt = New System.Windows.Forms.Label()
        Me.UserTxt = New System.Windows.Forms.Label()
        Me.PassTxt = New System.Windows.Forms.Label()
        Me.PasswordTxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContinueBox = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.ContinueBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SetupTxt
        '
        Me.SetupTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SetupTxt.BackColor = System.Drawing.Color.Transparent
        Me.SetupTxt.BorderWidth = 0!
        Me.SetupTxt.Font = New System.Drawing.Font("Arial", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SetupTxt.ForeColor = System.Drawing.Color.DimGray
        Me.SetupTxt.Glow = 5
        Me.SetupTxt.GlowColor = System.Drawing.Color.Black
        Me.SetupTxt.Location = New System.Drawing.Point(-196, 406)
        Me.SetupTxt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.SetupTxt.Name = "SetupTxt"
        Me.SetupTxt.Size = New System.Drawing.Size(2316, 249)
        Me.SetupTxt.TabIndex = 0
        Me.SetupTxt.Text = "Hi!"
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'UsernameTxt
        '
        Me.UsernameTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.UsernameTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameTxt.Location = New System.Drawing.Point(795, 466)
        Me.UsernameTxt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UsernameTxt.Name = "UsernameTxt"
        Me.UsernameTxt.Size = New System.Drawing.Size(346, 33)
        Me.UsernameTxt.TabIndex = 2
        Me.UsernameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.UsernameTxt.Visible = False
        '
        'LangBox
        '
        Me.LangBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LangBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LangBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LangBox.FormattingEnabled = True
        Me.LangBox.Items.AddRange(New Object() {"English", "Deutsch", "Français", "Espagnol", "Italiano"})
        Me.LangBox.Location = New System.Drawing.Point(795, 885)
        Me.LangBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LangBox.Name = "LangBox"
        Me.LangBox.Size = New System.Drawing.Size(346, 33)
        Me.LangBox.TabIndex = 15
        Me.LangBox.Visible = False
        '
        'SelectLangTxt
        '
        Me.SelectLangTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SelectLangTxt.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectLangTxt.ForeColor = System.Drawing.Color.White
        Me.SelectLangTxt.Location = New System.Drawing.Point(576, 817)
        Me.SelectLangTxt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.SelectLangTxt.Name = "SelectLangTxt"
        Me.SelectLangTxt.Size = New System.Drawing.Size(812, 63)
        Me.SelectLangTxt.TabIndex = 14
        Me.SelectLangTxt.Text = "Please select the desired language:"
        Me.SelectLangTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.SelectLangTxt.Visible = False
        '
        'StartWithWin
        '
        Me.StartWithWin.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.StartWithWin.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.StartWithWin.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartWithWin.ForeColor = System.Drawing.Color.White
        Me.StartWithWin.Location = New System.Drawing.Point(795, 732)
        Me.StartWithWin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.StartWithWin.Name = "StartWithWin"
        Me.StartWithWin.Size = New System.Drawing.Size(348, 58)
        Me.StartWithWin.TabIndex = 13
        Me.StartWithWin.Text = "Yes"
        Me.StartWithWin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.StartWithWin.UseVisualStyleBackColor = True
        Me.StartWithWin.Visible = False
        '
        'StartWithWinTxt
        '
        Me.StartWithWinTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.StartWithWinTxt.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartWithWinTxt.ForeColor = System.Drawing.Color.White
        Me.StartWithWinTxt.Location = New System.Drawing.Point(586, 656)
        Me.StartWithWinTxt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.StartWithWinTxt.Name = "StartWithWinTxt"
        Me.StartWithWinTxt.Size = New System.Drawing.Size(801, 55)
        Me.StartWithWinTxt.TabIndex = 12
        Me.StartWithWinTxt.Text = "Start XMBPC with Windows:"
        Me.StartWithWinTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.StartWithWinTxt.Visible = False
        '
        'UserTxt
        '
        Me.UserTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.UserTxt.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserTxt.ForeColor = System.Drawing.Color.White
        Me.UserTxt.Location = New System.Drawing.Point(795, 406)
        Me.UserTxt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.UserTxt.Name = "UserTxt"
        Me.UserTxt.Size = New System.Drawing.Size(348, 55)
        Me.UserTxt.TabIndex = 16
        Me.UserTxt.Text = "Username:"
        Me.UserTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.UserTxt.Visible = False
        '
        'PassTxt
        '
        Me.PassTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PassTxt.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PassTxt.ForeColor = System.Drawing.Color.White
        Me.PassTxt.Location = New System.Drawing.Point(795, 523)
        Me.PassTxt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PassTxt.Name = "PassTxt"
        Me.PassTxt.Size = New System.Drawing.Size(348, 55)
        Me.PassTxt.TabIndex = 18
        Me.PassTxt.Text = "Password (Optional):"
        Me.PassTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.PassTxt.Visible = False
        '
        'PasswordTxt
        '
        Me.PasswordTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PasswordTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordTxt.Location = New System.Drawing.Point(795, 583)
        Me.PasswordTxt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PasswordTxt.Name = "PasswordTxt"
        Me.PasswordTxt.Size = New System.Drawing.Size(346, 33)
        Me.PasswordTxt.TabIndex = 17
        Me.PasswordTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.PasswordTxt.UseSystemPasswordChar = True
        Me.PasswordTxt.Visible = False
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
        'Timer2
        '
        '
        'ContinueBox
        '
        Me.ContinueBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ContinueBox.BackColor = System.Drawing.Color.Transparent
        Me.ContinueBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ContinueBox.Image = Global.XMBPC.My.Resources.Resources.next_2_icon
        Me.ContinueBox.Location = New System.Drawing.Point(937, 943)
        Me.ContinueBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ContinueBox.Name = "ContinueBox"
        Me.ContinueBox.Size = New System.Drawing.Size(64, 64)
        Me.ContinueBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ContinueBox.TabIndex = 3
        Me.ContinueBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.ContinueBox, "Save & Continue")
        Me.ContinueBox.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = Global.XMBPC.My.Resources.Resources._1396112114_user_male2
        Me.PictureBox1.Location = New System.Drawing.Point(904, 172)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'NewSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(1920, 1080)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PassTxt)
        Me.Controls.Add(Me.PasswordTxt)
        Me.Controls.Add(Me.UserTxt)
        Me.Controls.Add(Me.LangBox)
        Me.Controls.Add(Me.SelectLangTxt)
        Me.Controls.Add(Me.StartWithWin)
        Me.Controls.Add(Me.StartWithWinTxt)
        Me.Controls.Add(Me.ContinueBox)
        Me.Controls.Add(Me.UsernameTxt)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.SetupTxt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewSetup"
        Me.Text = "XMBPC Setup"
        CType(Me.ContinueBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SetupTxt As gLabel.gLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameTxt As System.Windows.Forms.TextBox
    Friend WithEvents ContinueBox As System.Windows.Forms.PictureBox
    Friend WithEvents LangBox As System.Windows.Forms.ComboBox
    Friend WithEvents SelectLangTxt As System.Windows.Forms.Label
    Friend WithEvents StartWithWin As System.Windows.Forms.CheckBox
    Friend WithEvents StartWithWinTxt As System.Windows.Forms.Label
    Friend WithEvents UserTxt As System.Windows.Forms.Label
    Friend WithEvents PassTxt As System.Windows.Forms.Label
    Friend WithEvents PasswordTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class

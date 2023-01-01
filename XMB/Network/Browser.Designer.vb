<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Browser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Browser))
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.PageN = New gLabel.gLabel()
        Me.PageL = New gLabel.gLabel()
        Me.ControllerInputTimer = New System.Windows.Forms.Timer(Me.components)
        Me.BrowserMenu = New System.Windows.Forms.PictureBox()
        Me.TopBar = New System.Windows.Forms.PictureBox()
        Me.URLBox = New System.Windows.Forms.TextBox()
        Me.HelpBox = New System.Windows.Forms.PictureBox()
        Me.KeyboardTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.BrowserMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HelpBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.AllowWebBrowserDrop = False
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 50)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.Size = New System.Drawing.Size(1554, 759)
        Me.WebBrowser1.TabIndex = 0
        Me.WebBrowser1.Url = New System.Uri("http://www.ps3hax.net", System.UriKind.Absolute)
        '
        'PageN
        '
        Me.PageN.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PageN.BackColor = System.Drawing.Color.Transparent
        Me.PageN.BorderWidth = 0.0!
        Me.PageN.FeatherState = False
        Me.PageN.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PageN.ForeColor = System.Drawing.Color.White
        Me.PageN.GlowState = False
        Me.PageN.Location = New System.Drawing.Point(70, 6)
        Me.PageN.Margin = New System.Windows.Forms.Padding(0)
        Me.PageN.Name = "PageN"
        Me.PageN.ShadowColor = System.Drawing.Color.Black
        Me.PageN.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.PageN.Size = New System.Drawing.Size(585, 35)
        Me.PageN.TabIndex = 63
        Me.PageN.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'PageL
        '
        Me.PageL.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PageL.BackColor = System.Drawing.Color.Transparent
        Me.PageL.BorderWidth = 0.0!
        Me.PageL.FeatherState = False
        Me.PageL.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PageL.ForeColor = System.Drawing.Color.White
        Me.PageL.GlowState = False
        Me.PageL.Location = New System.Drawing.Point(655, 6)
        Me.PageL.Margin = New System.Windows.Forms.Padding(0)
        Me.PageL.Name = "PageL"
        Me.PageL.ShadowColor = System.Drawing.Color.Black
        Me.PageL.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.PageL.Size = New System.Drawing.Size(585, 35)
        Me.PageL.TabIndex = 64
        Me.PageL.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'ControllerInputTimer
        '
        '
        'BrowserMenu
        '
        Me.BrowserMenu.BackColor = System.Drawing.Color.Transparent
        Me.BrowserMenu.Dock = System.Windows.Forms.DockStyle.Right
        Me.BrowserMenu.Image = Global.XMBPC.My.Resources.Resources.browserbgmenu
        Me.BrowserMenu.Location = New System.Drawing.Point(1154, 50)
        Me.BrowserMenu.Name = "BrowserMenu"
        Me.BrowserMenu.Size = New System.Drawing.Size(400, 759)
        Me.BrowserMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.BrowserMenu.TabIndex = 65
        Me.BrowserMenu.TabStop = False
        Me.BrowserMenu.Visible = False
        '
        'TopBar
        '
        Me.TopBar.BackColor = System.Drawing.Color.Transparent
        Me.TopBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopBar.Image = Global.XMBPC.My.Resources.Resources.webbartop
        Me.TopBar.Location = New System.Drawing.Point(0, 0)
        Me.TopBar.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TopBar.Name = "TopBar"
        Me.TopBar.Size = New System.Drawing.Size(1554, 50)
        Me.TopBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TopBar.TabIndex = 1
        Me.TopBar.TabStop = False
        '
        'URLBox
        '
        Me.URLBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.URLBox.BackColor = System.Drawing.Color.White
        Me.URLBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.URLBox.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.URLBox.ForeColor = System.Drawing.Color.Black
        Me.URLBox.Location = New System.Drawing.Point(12, 765)
        Me.URLBox.Name = "URLBox"
        Me.URLBox.Size = New System.Drawing.Size(1136, 32)
        Me.URLBox.TabIndex = 66
        Me.URLBox.Visible = False
        '
        'HelpBox
        '
        Me.HelpBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.HelpBox.BackColor = System.Drawing.Color.Black
        Me.HelpBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HelpBox.Image = Global.XMBPC.My.Resources.Resources.help_browser
        Me.HelpBox.Location = New System.Drawing.Point(426, 153)
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
        'Browser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1554, 809)
        Me.Controls.Add(Me.HelpBox)
        Me.Controls.Add(Me.URLBox)
        Me.Controls.Add(Me.PageL)
        Me.Controls.Add(Me.PageN)
        Me.Controls.Add(Me.BrowserMenu)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.TopBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Browser"
        Me.Text = "Browser"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BrowserMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HelpBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents TopBar As System.Windows.Forms.PictureBox
    Friend WithEvents PageN As gLabel.gLabel
    Friend WithEvents PageL As gLabel.gLabel
    Friend WithEvents ControllerInputTimer As System.Windows.Forms.Timer
    Friend WithEvents BrowserMenu As System.Windows.Forms.PictureBox
    Friend WithEvents URLBox As System.Windows.Forms.TextBox
    Friend WithEvents HelpBox As System.Windows.Forms.PictureBox
    Friend WithEvents KeyboardTimer As System.Windows.Forms.Timer
End Class

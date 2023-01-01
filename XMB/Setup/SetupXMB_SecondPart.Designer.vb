<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetupXMB_SecondPart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetupXMB_SecondPart))
        Me.SaveMedia = New System.Windows.Forms.Button()
        Me.MusicStr = New System.Windows.Forms.Label()
        Me.MusicPath = New System.Windows.Forms.TextBox()
        Me.VideosPath = New System.Windows.Forms.TextBox()
        Me.VidStr = New System.Windows.Forms.Label()
        Me.PicturesPath = New System.Windows.Forms.TextBox()
        Me.PicStr = New System.Windows.Forms.Label()
        Me.PCStr = New System.Windows.Forms.Label()
        Me.FirstGamePath = New System.Windows.Forms.TextBox()
        Me.SaveGames = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.FolderBrowser = New System.Windows.Forms.FolderBrowserDialog()
        Me.FileBrowser = New System.Windows.Forms.OpenFileDialog()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.SavePS2Games = New System.Windows.Forms.Button()
        Me.PS2Files = New System.Windows.Forms.TextBox()
        Me.PSStr = New System.Windows.Forms.Label()
        Me.NewSelector = New System.Windows.Forms.OpenFileDialog()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.SaveRetroGames = New System.Windows.Forms.Button()
        Me.RetroFiles = New System.Windows.Forms.TextBox()
        Me.RetroStr = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.SaveNintendoGames = New System.Windows.Forms.Button()
        Me.NintendoFiles = New System.Windows.Forms.TextBox()
        Me.NintendoStr = New System.Windows.Forms.Label()
        Me.NintendoSelector = New System.Windows.Forms.OpenFileDialog()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.AllGamesList = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BrowseGames = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'SaveMedia
        '
        Me.SaveMedia.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveMedia.Location = New System.Drawing.Point(16, 153)
        Me.SaveMedia.Name = "SaveMedia"
        Me.SaveMedia.Size = New System.Drawing.Size(295, 23)
        Me.SaveMedia.TabIndex = 4
        Me.SaveMedia.Text = "Save"
        Me.SaveMedia.UseVisualStyleBackColor = True
        '
        'MusicStr
        '
        Me.MusicStr.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MusicStr.Location = New System.Drawing.Point(16, 9)
        Me.MusicStr.Name = "MusicStr"
        Me.MusicStr.Size = New System.Drawing.Size(295, 21)
        Me.MusicStr.TabIndex = 5
        Me.MusicStr.Text = "Please select a path which contains music:"
        Me.MusicStr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MusicPath
        '
        Me.MusicPath.Location = New System.Drawing.Point(16, 33)
        Me.MusicPath.Name = "MusicPath"
        Me.MusicPath.Size = New System.Drawing.Size(295, 20)
        Me.MusicPath.TabIndex = 6
        '
        'VideosPath
        '
        Me.VideosPath.Location = New System.Drawing.Point(16, 80)
        Me.VideosPath.Name = "VideosPath"
        Me.VideosPath.Size = New System.Drawing.Size(295, 20)
        Me.VideosPath.TabIndex = 8
        '
        'VidStr
        '
        Me.VidStr.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VidStr.Location = New System.Drawing.Point(16, 56)
        Me.VidStr.Name = "VidStr"
        Me.VidStr.Size = New System.Drawing.Size(295, 21)
        Me.VidStr.TabIndex = 7
        Me.VidStr.Text = "Please select a path which contains videos:"
        Me.VidStr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PicturesPath
        '
        Me.PicturesPath.Location = New System.Drawing.Point(16, 127)
        Me.PicturesPath.Name = "PicturesPath"
        Me.PicturesPath.Size = New System.Drawing.Size(295, 20)
        Me.PicturesPath.TabIndex = 10
        '
        'PicStr
        '
        Me.PicStr.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PicStr.Location = New System.Drawing.Point(16, 103)
        Me.PicStr.Name = "PicStr"
        Me.PicStr.Size = New System.Drawing.Size(303, 21)
        Me.PicStr.TabIndex = 9
        Me.PicStr.Text = "Please select a path which contains pictures:"
        Me.PicStr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PCStr
        '
        Me.PCStr.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PCStr.Location = New System.Drawing.Point(737, 292)
        Me.PCStr.Name = "PCStr"
        Me.PCStr.Size = New System.Drawing.Size(299, 21)
        Me.PCStr.TabIndex = 11
        Me.PCStr.Text = "Select your PC games's exe file:"
        Me.PCStr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.PCStr.Visible = False
        '
        'FirstGamePath
        '
        Me.FirstGamePath.Location = New System.Drawing.Point(741, 316)
        Me.FirstGamePath.Multiline = True
        Me.FirstGamePath.Name = "FirstGamePath"
        Me.FirstGamePath.Size = New System.Drawing.Size(295, 114)
        Me.FirstGamePath.TabIndex = 14
        Me.FirstGamePath.Visible = False
        '
        'SaveGames
        '
        Me.SaveGames.Location = New System.Drawing.Point(741, 436)
        Me.SaveGames.Name = "SaveGames"
        Me.SaveGames.Size = New System.Drawing.Size(295, 23)
        Me.SaveGames.TabIndex = 17
        Me.SaveGames.Text = "Save"
        Me.SaveGames.UseVisualStyleBackColor = True
        Me.SaveGames.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(317, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(34, 20)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(317, 80)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(34, 20)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(317, 127)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(34, 20)
        Me.Button3.TabIndex = 20
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1042, 316)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(34, 115)
        Me.Button4.TabIndex = 21
        Me.Button4.Text = "..."
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'FileBrowser
        '
        Me.FileBrowser.DereferenceLinks = False
        Me.FileBrowser.Multiselect = True
        Me.FileBrowser.Title = "Select all your games"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(317, 316)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(34, 114)
        Me.Button5.TabIndex = 25
        Me.Button5.Text = "..."
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'SavePS2Games
        '
        Me.SavePS2Games.Location = New System.Drawing.Point(16, 436)
        Me.SavePS2Games.Name = "SavePS2Games"
        Me.SavePS2Games.Size = New System.Drawing.Size(295, 23)
        Me.SavePS2Games.TabIndex = 24
        Me.SavePS2Games.Text = "Save"
        Me.SavePS2Games.UseVisualStyleBackColor = True
        Me.SavePS2Games.Visible = False
        '
        'PS2Files
        '
        Me.PS2Files.Location = New System.Drawing.Point(16, 316)
        Me.PS2Files.Multiline = True
        Me.PS2Files.Name = "PS2Files"
        Me.PS2Files.Size = New System.Drawing.Size(295, 114)
        Me.PS2Files.TabIndex = 23
        Me.PS2Files.Visible = False
        '
        'PSStr
        '
        Me.PSStr.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PSStr.Location = New System.Drawing.Point(12, 292)
        Me.PSStr.Name = "PSStr"
        Me.PSStr.Size = New System.Drawing.Size(339, 21)
        Me.PSStr.TabIndex = 22
        Me.PSStr.Text = "Select your PS2/PS1/PSP roms:"
        Me.PSStr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.PSStr.Visible = False
        '
        'NewSelector
        '
        Me.NewSelector.FileName = "Please select your Playstation games"
        Me.NewSelector.Filter = "PS2 ISOs|*.iso|PS1 BINs|*.bin|Compressed PSP Games|*.cso"
        Me.NewSelector.Multiselect = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(680, 316)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(34, 114)
        Me.Button6.TabIndex = 29
        Me.Button6.Text = "..."
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'SaveRetroGames
        '
        Me.SaveRetroGames.Location = New System.Drawing.Point(379, 436)
        Me.SaveRetroGames.Name = "SaveRetroGames"
        Me.SaveRetroGames.Size = New System.Drawing.Size(295, 23)
        Me.SaveRetroGames.TabIndex = 28
        Me.SaveRetroGames.Text = "Save"
        Me.SaveRetroGames.UseVisualStyleBackColor = True
        Me.SaveRetroGames.Visible = False
        '
        'RetroFiles
        '
        Me.RetroFiles.Location = New System.Drawing.Point(379, 316)
        Me.RetroFiles.Multiline = True
        Me.RetroFiles.Name = "RetroFiles"
        Me.RetroFiles.Size = New System.Drawing.Size(295, 114)
        Me.RetroFiles.TabIndex = 27
        Me.RetroFiles.Visible = False
        '
        'RetroStr
        '
        Me.RetroStr.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RetroStr.Location = New System.Drawing.Point(375, 292)
        Me.RetroStr.Name = "RetroStr"
        Me.RetroStr.Size = New System.Drawing.Size(339, 21)
        Me.RetroStr.TabIndex = 26
        Me.RetroStr.Text = "Select your SNES/NES/GBA/GBC/SEGA roms:"
        Me.RetroStr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RetroStr.Visible = False
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(1042, 114)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(34, 115)
        Me.Button7.TabIndex = 33
        Me.Button7.Text = "..."
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'SaveNintendoGames
        '
        Me.SaveNintendoGames.Location = New System.Drawing.Point(741, 234)
        Me.SaveNintendoGames.Name = "SaveNintendoGames"
        Me.SaveNintendoGames.Size = New System.Drawing.Size(295, 23)
        Me.SaveNintendoGames.TabIndex = 32
        Me.SaveNintendoGames.Text = "Save"
        Me.SaveNintendoGames.UseVisualStyleBackColor = True
        Me.SaveNintendoGames.Visible = False
        '
        'NintendoFiles
        '
        Me.NintendoFiles.Location = New System.Drawing.Point(741, 114)
        Me.NintendoFiles.Multiline = True
        Me.NintendoFiles.Name = "NintendoFiles"
        Me.NintendoFiles.Size = New System.Drawing.Size(295, 114)
        Me.NintendoFiles.TabIndex = 31
        Me.NintendoFiles.Visible = False
        '
        'NintendoStr
        '
        Me.NintendoStr.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NintendoStr.Location = New System.Drawing.Point(737, 90)
        Me.NintendoStr.Name = "NintendoStr"
        Me.NintendoStr.Size = New System.Drawing.Size(334, 21)
        Me.NintendoStr.TabIndex = 30
        Me.NintendoStr.Text = "Select your Nintendo roms:"
        Me.NintendoStr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.NintendoStr.Visible = False
        '
        'NintendoSelector
        '
        Me.NintendoSelector.FileName = "Please select your Nintendo games"
        Me.NintendoSelector.Filter = "Gamecube|*.gcm|Wii|*.iso|DS|*.nds"
        Me.NintendoSelector.Multiselect = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(378, 153)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(295, 23)
        Me.Button8.TabIndex = 34
        Me.Button8.Text = "Finish Setup"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'AllGamesList
        '
        Me.AllGamesList.Location = New System.Drawing.Point(378, 33)
        Me.AllGamesList.Multiline = True
        Me.AllGamesList.Name = "AllGamesList"
        Me.AllGamesList.Size = New System.Drawing.Size(295, 114)
        Me.AllGamesList.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(374, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(299, 21)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Select all your games:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.Label1, "Nintendo Games: DS, Gamecube, Wii" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Playstation Games: PS1, PS2, PSP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Retro Games:" & _
        " SNES, NES, GBA, GBC, GB")
        '
        'BrowseGames
        '
        Me.BrowseGames.Location = New System.Drawing.Point(679, 33)
        Me.BrowseGames.Name = "BrowseGames"
        Me.BrowseGames.Size = New System.Drawing.Size(34, 114)
        Me.BrowseGames.TabIndex = 37
        Me.BrowseGames.Text = "..."
        Me.ToolTip1.SetToolTip(Me.BrowseGames, "Nintendo Games: DS, Gamecube, Wii" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Playstation Games: PS1, PS2, PSP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Retro Games:" & _
        " SNES, NES, GBA, GBC, GB")
        Me.BrowseGames.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Supported Games"
        '
        'SetupXMB_SecondPart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 191)
        Me.Controls.Add(Me.BrowseGames)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AllGamesList)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.SaveNintendoGames)
        Me.Controls.Add(Me.NintendoFiles)
        Me.Controls.Add(Me.NintendoStr)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.SaveRetroGames)
        Me.Controls.Add(Me.RetroFiles)
        Me.Controls.Add(Me.RetroStr)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.SavePS2Games)
        Me.Controls.Add(Me.PS2Files)
        Me.Controls.Add(Me.PSStr)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.SaveGames)
        Me.Controls.Add(Me.FirstGamePath)
        Me.Controls.Add(Me.PCStr)
        Me.Controls.Add(Me.PicturesPath)
        Me.Controls.Add(Me.PicStr)
        Me.Controls.Add(Me.VideosPath)
        Me.Controls.Add(Me.VidStr)
        Me.Controls.Add(Me.MusicPath)
        Me.Controls.Add(Me.MusicStr)
        Me.Controls.Add(Me.SaveMedia)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(739, 230)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(739, 230)
        Me.Name = "SetupXMB_SecondPart"
        Me.Text = "Add Music, Videos, Pictures And Games"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveMedia As System.Windows.Forms.Button
    Friend WithEvents MusicStr As System.Windows.Forms.Label
    Friend WithEvents MusicPath As System.Windows.Forms.TextBox
    Friend WithEvents VideosPath As System.Windows.Forms.TextBox
    Friend WithEvents VidStr As System.Windows.Forms.Label
    Friend WithEvents PicturesPath As System.Windows.Forms.TextBox
    Friend WithEvents PicStr As System.Windows.Forms.Label
    Friend WithEvents PCStr As System.Windows.Forms.Label
    Friend WithEvents FirstGamePath As System.Windows.Forms.TextBox
    Friend WithEvents SaveGames As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowser As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents FileBrowser As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents SavePS2Games As System.Windows.Forms.Button
    Friend WithEvents PS2Files As System.Windows.Forms.TextBox
    Friend WithEvents PSStr As System.Windows.Forms.Label
    Friend WithEvents NewSelector As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents SaveRetroGames As System.Windows.Forms.Button
    Friend WithEvents RetroFiles As System.Windows.Forms.TextBox
    Friend WithEvents RetroStr As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents SaveNintendoGames As System.Windows.Forms.Button
    Friend WithEvents NintendoFiles As System.Windows.Forms.TextBox
    Friend WithEvents NintendoStr As System.Windows.Forms.Label
    Friend WithEvents NintendoSelector As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents AllGamesList As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BrowseGames As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class

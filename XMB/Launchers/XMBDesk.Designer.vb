<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XMBDesk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XMBDesk))
        Me.DesktopImages = New System.Windows.Forms.ImageList(Me.components)
        Me.Rightclickmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CatalystControlCenterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NVIDIAControlCenterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.NeueVerknüpfungErstellenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerknüpfungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdnerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArchivToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemRightclickMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateipfadÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlsAdministratorÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZuArchivHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.AusschneidenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.VerknüpfungErstellenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UmbennenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.EigenschaftenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesktopToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.Desktop = New System.Windows.Forms.ListView()
        Me.Bot_Box = New System.Windows.Forms.Panel()
        Me.Energy_App = New System.Windows.Forms.PictureBox()
        Me.Clocktime = New System.Windows.Forms.Label()
        Me.Network_App = New System.Windows.Forms.PictureBox()
        Me.Other_System_Services = New System.Windows.Forms.Timer(Me.components)
        Me.System_Timer = New System.Windows.Forms.Timer(Me.components)
        Me.TaskBar = New System.Windows.Forms.ToolStrip()
        Me.TaskBarRightMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Rightclickmenu.SuspendLayout()
        Me.ItemRightclickMenu.SuspendLayout()
        Me.Bot_Box.SuspendLayout()
        CType(Me.Energy_App, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Network_App, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TaskBarRightMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'DesktopImages
        '
        Me.DesktopImages.ImageStream = CType(resources.GetObject("DesktopImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.DesktopImages.TransparentColor = System.Drawing.Color.Transparent
        Me.DesktopImages.Images.SetKeyName(0, "folderbr.png")
        Me.DesktopImages.Images.SetKeyName(1, "Icons.6.png")
        '
        'Rightclickmenu
        '
        Me.Rightclickmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CatalystControlCenterToolStripMenuItem, Me.NVIDIAControlCenterToolStripMenuItem, Me.ToolStripSeparator2, Me.NeueVerknüpfungErstellenToolStripMenuItem, Me.ToolStripSeparator1, Me.ToolStripMenuItem1})
        Me.Rightclickmenu.Name = "ContextMenuStrip1"
        Me.Rightclickmenu.Size = New System.Drawing.Size(198, 104)
        '
        'CatalystControlCenterToolStripMenuItem
        '
        Me.CatalystControlCenterToolStripMenuItem.Enabled = False
        Me.CatalystControlCenterToolStripMenuItem.Name = "CatalystControlCenterToolStripMenuItem"
        Me.CatalystControlCenterToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.CatalystControlCenterToolStripMenuItem.Text = "Catalyst Control Center"
        '
        'NVIDIAControlCenterToolStripMenuItem
        '
        Me.NVIDIAControlCenterToolStripMenuItem.Enabled = False
        Me.NVIDIAControlCenterToolStripMenuItem.Name = "NVIDIAControlCenterToolStripMenuItem"
        Me.NVIDIAControlCenterToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.NVIDIAControlCenterToolStripMenuItem.Text = "NVIDIA Control Center"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(194, 6)
        '
        'NeueVerknüpfungErstellenToolStripMenuItem
        '
        Me.NeueVerknüpfungErstellenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerknüpfungToolStripMenuItem, Me.OrdnerToolStripMenuItem, Me.ArchivToolStripMenuItem})
        Me.NeueVerknüpfungErstellenToolStripMenuItem.Name = "NeueVerknüpfungErstellenToolStripMenuItem"
        Me.NeueVerknüpfungErstellenToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.NeueVerknüpfungErstellenToolStripMenuItem.Text = "New"
        '
        'VerknüpfungToolStripMenuItem
        '
        Me.VerknüpfungToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.VerknüpfungToolStripMenuItem.Name = "VerknüpfungToolStripMenuItem"
        Me.VerknüpfungToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.VerknüpfungToolStripMenuItem.Text = "Shortcut"
        '
        'OrdnerToolStripMenuItem
        '
        Me.OrdnerToolStripMenuItem.Enabled = False
        Me.OrdnerToolStripMenuItem.Name = "OrdnerToolStripMenuItem"
        Me.OrdnerToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.OrdnerToolStripMenuItem.Text = "Folder"
        '
        'ArchivToolStripMenuItem
        '
        Me.ArchivToolStripMenuItem.Enabled = False
        Me.ArchivToolStripMenuItem.Name = "ArchivToolStripMenuItem"
        Me.ArchivToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.ArchivToolStripMenuItem.Text = "Archive"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(194, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(197, 22)
        Me.ToolStripMenuItem1.Text = "Personalize"
        '
        'ItemRightclickMenu
        '
        Me.ItemRightclickMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.DateipfadÖffnenToolStripMenuItem, Me.AlsAdministratorÖffnenToolStripMenuItem, Me.ZuArchivHinzufügenToolStripMenuItem, Me.ToolStripSeparator3, Me.AusschneidenToolStripMenuItem, Me.KopierenToolStripMenuItem, Me.ToolStripSeparator4, Me.VerknüpfungErstellenToolStripMenuItem, Me.LöschenToolStripMenuItem, Me.UmbennenToolStripMenuItem, Me.ToolStripSeparator5, Me.EigenschaftenToolStripMenuItem})
        Me.ItemRightclickMenu.Name = "ItemRechtsklickMenu"
        Me.ItemRightclickMenu.Size = New System.Drawing.Size(184, 242)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'DateipfadÖffnenToolStripMenuItem
        '
        Me.DateipfadÖffnenToolStripMenuItem.Name = "DateipfadÖffnenToolStripMenuItem"
        Me.DateipfadÖffnenToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.DateipfadÖffnenToolStripMenuItem.Text = "Open Location"
        '
        'AlsAdministratorÖffnenToolStripMenuItem
        '
        Me.AlsAdministratorÖffnenToolStripMenuItem.Name = "AlsAdministratorÖffnenToolStripMenuItem"
        Me.AlsAdministratorÖffnenToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.AlsAdministratorÖffnenToolStripMenuItem.Text = "Run as administrator"
        '
        'ZuArchivHinzufügenToolStripMenuItem
        '
        Me.ZuArchivHinzufügenToolStripMenuItem.Enabled = False
        Me.ZuArchivHinzufügenToolStripMenuItem.Name = "ZuArchivHinzufügenToolStripMenuItem"
        Me.ZuArchivHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ZuArchivHinzufügenToolStripMenuItem.Text = "Add to archive"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(180, 6)
        '
        'AusschneidenToolStripMenuItem
        '
        Me.AusschneidenToolStripMenuItem.Enabled = False
        Me.AusschneidenToolStripMenuItem.Name = "AusschneidenToolStripMenuItem"
        Me.AusschneidenToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.AusschneidenToolStripMenuItem.Text = "Cut"
        '
        'KopierenToolStripMenuItem
        '
        Me.KopierenToolStripMenuItem.Enabled = False
        Me.KopierenToolStripMenuItem.Name = "KopierenToolStripMenuItem"
        Me.KopierenToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.KopierenToolStripMenuItem.Text = "Copy"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(180, 6)
        '
        'VerknüpfungErstellenToolStripMenuItem
        '
        Me.VerknüpfungErstellenToolStripMenuItem.Enabled = False
        Me.VerknüpfungErstellenToolStripMenuItem.Name = "VerknüpfungErstellenToolStripMenuItem"
        Me.VerknüpfungErstellenToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.VerknüpfungErstellenToolStripMenuItem.Text = "Create shortcut"
        '
        'LöschenToolStripMenuItem
        '
        Me.LöschenToolStripMenuItem.Name = "LöschenToolStripMenuItem"
        Me.LöschenToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.LöschenToolStripMenuItem.Text = "Delete"
        '
        'UmbennenToolStripMenuItem
        '
        Me.UmbennenToolStripMenuItem.Name = "UmbennenToolStripMenuItem"
        Me.UmbennenToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.UmbennenToolStripMenuItem.Text = "Rename"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(180, 6)
        '
        'EigenschaftenToolStripMenuItem
        '
        Me.EigenschaftenToolStripMenuItem.Name = "EigenschaftenToolStripMenuItem"
        Me.EigenschaftenToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.EigenschaftenToolStripMenuItem.Text = "Properties"
        '
        'Desktop
        '
        Me.Desktop.Alignment = System.Windows.Forms.ListViewAlignment.Left
        Me.Desktop.AllowColumnReorder = True
        Me.Desktop.AllowDrop = True
        Me.Desktop.AutoArrange = False
        Me.Desktop.BackColor = System.Drawing.Color.Black
        Me.Desktop.BackgroundImage = Global.XMBPC.My.Resources.Resources.Windows_7_Official_Pastel_Aurora_windows_7_wallpapers_windows_wallpapers_computer_wallpapers_1920x1080
        Me.Desktop.BackgroundImageTiled = True
        Me.Desktop.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Desktop.ContextMenuStrip = Me.Rightclickmenu
        Me.Desktop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Desktop.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Desktop.ForeColor = System.Drawing.Color.White
        Me.Desktop.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.Desktop.LabelEdit = True
        Me.Desktop.LargeImageList = Me.DesktopImages
        Me.Desktop.Location = New System.Drawing.Point(0, 0)
        Me.Desktop.Name = "Desktop"
        Me.Desktop.Scrollable = False
        Me.Desktop.ShowGroups = False
        Me.Desktop.Size = New System.Drawing.Size(1540, 759)
        Me.Desktop.TabIndex = 10
        Me.Desktop.UseCompatibleStateImageBehavior = False
        '
        'Bot_Box
        '
        Me.Bot_Box.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bot_Box.BackColor = System.Drawing.Color.Transparent
        Me.Bot_Box.Controls.Add(Me.Energy_App)
        Me.Bot_Box.Controls.Add(Me.Clocktime)
        Me.Bot_Box.Controls.Add(Me.Network_App)
        Me.Bot_Box.Location = New System.Drawing.Point(1362, 0)
        Me.Bot_Box.Name = "Bot_Box"
        Me.Bot_Box.Size = New System.Drawing.Size(178, 55)
        Me.Bot_Box.TabIndex = 13
        '
        'Energy_App
        '
        Me.Energy_App.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Energy_App.BackColor = System.Drawing.Color.Transparent
        Me.Energy_App.Image = Global.XMBPC.My.Resources.Resources.Status_battery_charging_icon
        Me.Energy_App.Location = New System.Drawing.Point(17, 8)
        Me.Energy_App.Name = "Energy_App"
        Me.Energy_App.Size = New System.Drawing.Size(32, 32)
        Me.Energy_App.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Energy_App.TabIndex = 22
        Me.Energy_App.TabStop = False
        '
        'Clocktime
        '
        Me.Clocktime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Clocktime.BackColor = System.Drawing.Color.Transparent
        Me.Clocktime.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Clocktime.ForeColor = System.Drawing.Color.White
        Me.Clocktime.Location = New System.Drawing.Point(93, 8)
        Me.Clocktime.Name = "Clocktime"
        Me.Clocktime.Size = New System.Drawing.Size(80, 38)
        Me.Clocktime.TabIndex = 19
        Me.Clocktime.Text = "Label1"
        Me.Clocktime.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Network_App
        '
        Me.Network_App.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Network_App.BackColor = System.Drawing.Color.Transparent
        Me.Network_App.Image = Global.XMBPC.My.Resources.Resources.browser_2_icon
        Me.Network_App.Location = New System.Drawing.Point(55, 8)
        Me.Network_App.Name = "Network_App"
        Me.Network_App.Size = New System.Drawing.Size(32, 32)
        Me.Network_App.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Network_App.TabIndex = 6
        Me.Network_App.TabStop = False
        '
        'Other_System_Services
        '
        Me.Other_System_Services.Interval = 10000
        '
        'System_Timer
        '
        '
        'TaskBar
        '
        Me.TaskBar.AllowMerge = False
        Me.TaskBar.AutoSize = False
        Me.TaskBar.BackColor = System.Drawing.Color.Transparent
        Me.TaskBar.BackgroundImage = Global.XMBPC.My.Resources.Resources.taskbarbg2
        Me.TaskBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TaskBar.ContextMenuStrip = Me.TaskBarRightMenu
        Me.TaskBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TaskBar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TaskBar.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.TaskBar.Location = New System.Drawing.Point(0, 759)
        Me.TaskBar.Name = "TaskBar"
        Me.TaskBar.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.TaskBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TaskBar.ShowItemToolTips = False
        Me.TaskBar.Size = New System.Drawing.Size(1540, 45)
        Me.TaskBar.TabIndex = 14
        Me.TaskBar.TabStop = True
        '
        'TaskBarRightMenu
        '
        Me.TaskBarRightMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2})
        Me.TaskBarRightMenu.Name = "TaskBarRightMenu"
        Me.TaskBarRightMenu.ShowItemToolTips = False
        Me.TaskBarRightMenu.Size = New System.Drawing.Size(151, 26)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = Global.XMBPC.My.Resources.Resources.symbol_delete_icon
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(150, 22)
        Me.ToolStripMenuItem2.Text = "Close Window"
        '
        'XMBDesk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.XMBPC.My.Resources.Resources.Windows_7_Official_Pastel_Aurora_windows_7_wallpapers_windows_wallpapers_computer_wallpapers_1920x1080
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1540, 804)
        Me.Controls.Add(Me.Bot_Box)
        Me.Controls.Add(Me.Desktop)
        Me.Controls.Add(Me.TaskBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "XMBDesk"
        Me.Text = "XMBDesk"
        Me.Rightclickmenu.ResumeLayout(False)
        Me.ItemRightclickMenu.ResumeLayout(False)
        Me.Bot_Box.ResumeLayout(False)
        Me.Bot_Box.PerformLayout()
        CType(Me.Energy_App, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Network_App, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TaskBarRightMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DesktopImages As System.Windows.Forms.ImageList
    Friend WithEvents Rightclickmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CatalystControlCenterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NVIDIAControlCenterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NeueVerknüpfungErstellenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerknüpfungToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdnerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArchivToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemRightclickMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateipfadÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlsAdministratorÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZuArchivHinzufügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AusschneidenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KopierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents VerknüpfungErstellenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UmbennenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EigenschaftenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesktopToolTips As System.Windows.Forms.ToolTip
    Public WithEvents Desktop As System.Windows.Forms.ListView
    Friend WithEvents Bot_Box As System.Windows.Forms.Panel
    Friend WithEvents Energy_App As System.Windows.Forms.PictureBox
    Friend WithEvents Clocktime As System.Windows.Forms.Label
    Friend WithEvents Network_App As System.Windows.Forms.PictureBox
    Friend WithEvents Other_System_Services As System.Windows.Forms.Timer
    Friend WithEvents System_Timer As System.Windows.Forms.Timer
    Friend WithEvents TaskBar As System.Windows.Forms.ToolStrip
    Friend WithEvents TaskBarRightMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
End Class

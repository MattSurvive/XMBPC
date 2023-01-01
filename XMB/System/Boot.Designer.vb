<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Boot
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Boot))
        Me.BootMPlayer = New AxWMPLib.AxWindowsMediaPlayer()
        CType(Me.BootMPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BootMPlayer
        '
        Me.BootMPlayer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BootMPlayer.Enabled = True
        Me.BootMPlayer.Location = New System.Drawing.Point(0, 0)
        Me.BootMPlayer.Name = "BootMPlayer"
        Me.BootMPlayer.OcxState = CType(resources.GetObject("BootMPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.BootMPlayer.Size = New System.Drawing.Size(1497, 804)
        Me.BootMPlayer.TabIndex = 0
        '
        'Boot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1497, 804)
        Me.ControlBox = False
        Me.Controls.Add(Me.BootMPlayer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Boot"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "XMB"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BootMPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BootMPlayer As AxWMPLib.AxWindowsMediaPlayer

End Class

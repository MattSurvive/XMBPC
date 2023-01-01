<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PSMenu
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ControllerTimer = New System.Windows.Forms.Timer(Me.components)
        Me.KeyboardTimer = New System.Windows.Forms.Timer(Me.components)
        Me.quitgame = New gLabel.gLabel()
        Me.turnoffsystem = New gLabel.gLabel()
        Me.SuspendLayout()
        '
        'ControllerTimer
        '
        '
        'KeyboardTimer
        '
        '
        'quitgame
        '
        Me.quitgame.BackColor = System.Drawing.Color.Transparent
        Me.quitgame.BorderWidth = 0.0!
        Me.quitgame.FeatherState = False
        Me.quitgame.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quitgame.ForeColor = System.Drawing.Color.White
        Me.quitgame.Glow = 3
        Me.quitgame.GlowColor = System.Drawing.Color.White
        Me.quitgame.Location = New System.Drawing.Point(30, 10)
        Me.quitgame.Margin = New System.Windows.Forms.Padding(0)
        Me.quitgame.Name = "quitgame"
        Me.quitgame.ShadowColor = System.Drawing.Color.Black
        Me.quitgame.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.quitgame.Size = New System.Drawing.Size(300, 43)
        Me.quitgame.TabIndex = 118
        Me.quitgame.Text = "Quit game"
        '
        'turnoffsystem
        '
        Me.turnoffsystem.BackColor = System.Drawing.Color.Transparent
        Me.turnoffsystem.BorderWidth = 0.0!
        Me.turnoffsystem.FeatherState = False
        Me.turnoffsystem.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.turnoffsystem.ForeColor = System.Drawing.Color.White
        Me.turnoffsystem.Glow = 3
        Me.turnoffsystem.GlowColor = System.Drawing.Color.White
        Me.turnoffsystem.GlowState = False
        Me.turnoffsystem.Location = New System.Drawing.Point(30, 53)
        Me.turnoffsystem.Margin = New System.Windows.Forms.Padding(0)
        Me.turnoffsystem.Name = "turnoffsystem"
        Me.turnoffsystem.ShadowColor = System.Drawing.Color.Black
        Me.turnoffsystem.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.turnoffsystem.Size = New System.Drawing.Size(300, 43)
        Me.turnoffsystem.TabIndex = 119
        Me.turnoffsystem.Text = "Turn off system"
        '
        'PSMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.turnoffsystem)
        Me.Controls.Add(Me.quitgame)
        Me.DoubleBuffered = True
        Me.Name = "PSMenu"
        Me.Size = New System.Drawing.Size(358, 105)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ControllerTimer As System.Windows.Forms.Timer
    Friend WithEvents KeyboardTimer As System.Windows.Forms.Timer
    Friend WithEvents quitgame As gLabel.gLabel
    Friend WithEvents turnoffsystem As gLabel.gLabel

End Class

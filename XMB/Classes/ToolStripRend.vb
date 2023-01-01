Public Class ToolStripRend

    Inherits ToolStripProfessionalRenderer

    Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
    End Sub

    Public Sub New()
        MyBase.New(New ToolStripOverride())
    End Sub

End Class
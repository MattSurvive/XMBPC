Imports System.Drawing
Imports System.Windows.Forms

Public Class ToolStripOverride

    'Inherits ToolStripProfessionalRenderer
    Inherits ProfessionalColorTable
    Public Overrides ReadOnly Property ButtonSelectedHighlight() As Color
        Get
            Return ButtonSelectedGradientMiddle
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonSelectedHighlightBorder() As Color
        Get
            Return ButtonSelectedBorder
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonPressedHighlight() As Color
        Get
            Return ButtonPressedGradientMiddle
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonPressedHighlightBorder() As Color
        Get
            Return ButtonPressedBorder
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonCheckedHighlight() As Color
        Get
            Return ButtonCheckedGradientMiddle
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonCheckedHighlightBorder() As Color
        Get
            Return ButtonSelectedBorder
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonPressedBorder() As Color
        Get
            Return ButtonSelectedBorder
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonSelectedBorder() As Color
        Get
            Return Color.FromName("Highlight")
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonCheckedGradientBegin() As Color
        Get
            Return Color.FromArgb(0, 0, 0, 0)
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonCheckedGradientMiddle() As Color
        Get
            Return Color.FromArgb(0, 0, 0, 0)
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonCheckedGradientEnd() As Color
        Get
            Return Color.FromArgb(0, 0, 0, 0)
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonSelectedGradientBegin() As Color
        Get
            Return Color.FromName("Silver")
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonSelectedGradientMiddle() As Color
        Get
            Return Color.FromArgb(255, 230, 231, 232)
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonSelectedGradientEnd() As Color
        Get
            Return Color.FromName("Gray")
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonPressedGradientBegin() As Color
        Get
            Return Color.FromArgb(255, 214, 214, 214)
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonPressedGradientMiddle() As Color
        Get
            Return Color.FromArgb(255, 214, 214, 214)
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonPressedGradientEnd() As Color
        Get
            Return Color.FromName("Silver")
        End Get
    End Property
    Public Overrides ReadOnly Property CheckBackground() As Color
        Get
            Return Color.FromArgb(255, 196, 225, 255)
        End Get
    End Property
    Public Overrides ReadOnly Property CheckSelectedBackground() As Color
        Get
            Return Color.FromArgb(255, 153, 204, 255)
        End Get
    End Property
    Public Overrides ReadOnly Property CheckPressedBackground() As Color
        Get
            Return Color.FromArgb(255, 153, 204, 255)
        End Get
    End Property
    Public Overrides ReadOnly Property GripDark() As Color
        Get
            Return Color.FromArgb(255, 184, 184, 184)
        End Get
    End Property
    Public Overrides ReadOnly Property GripLight() As Color
        Get
            Return Color.FromName("Window")
        End Get
    End Property
    Public Overrides ReadOnly Property ImageMarginGradientBegin() As Color
        Get
            Return Color.FromArgb(255, 252, 252, 252)
        End Get
    End Property
    Public Overrides ReadOnly Property ImageMarginGradientMiddle() As Color
        Get
            Return Color.FromArgb(255, 248, 248, 248)
        End Get
    End Property
    Public Overrides ReadOnly Property ImageMarginGradientEnd() As Color
        Get
            Return Color.FromName("Control")
        End Get
    End Property
    Public Overrides ReadOnly Property ImageMarginRevealedGradientBegin() As Color
        Get
            Return Color.FromArgb(255, 249, 249, 249)
        End Get
    End Property
    Public Overrides ReadOnly Property ImageMarginRevealedGradientMiddle() As Color
        Get
            Return Color.FromArgb(255, 245, 245, 245)
        End Get
    End Property
    Public Overrides ReadOnly Property ImageMarginRevealedGradientEnd() As Color
        Get
            Return Color.FromArgb(255, 242, 242, 242)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuStripGradientBegin() As Color
        Get
            Return Color.FromName("ButtonFace")
        End Get
    End Property
    Public Overrides ReadOnly Property MenuStripGradientEnd() As Color
        Get
            Return Color.FromArgb(255, 252, 252, 252)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemSelected() As Color
        Get
            Return Color.FromArgb(255, 196, 225, 255)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemBorder() As Color
        Get
            Return Color.FromName("Highlight")
        End Get
    End Property
    Public Overrides ReadOnly Property MenuBorder() As Color
        Get
            Return Color.FromArgb(255, 128, 128, 128)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemSelectedGradientBegin() As Color
        Get
            Return Color.FromArgb(255, 194, 224, 255)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemSelectedGradientEnd() As Color
        Get
            Return Color.FromArgb(255, 194, 224, 255)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemPressedGradientBegin() As Color
        Get
            Return Color.FromArgb(255, 252, 252, 252)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemPressedGradientMiddle() As Color
        Get
            Return Color.FromArgb(255, 245, 245, 245)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemPressedGradientEnd() As Color
        Get
            Return Color.FromArgb(255, 248, 248, 248)
        End Get
    End Property
    Public Overrides ReadOnly Property RaftingContainerGradientBegin() As Color
        Get
            Return Color.FromName("ButtonFace")
        End Get
    End Property
    Public Overrides ReadOnly Property RaftingContainerGradientEnd() As Color
        Get
            Return Color.FromArgb(255, 252, 252, 252)
        End Get
    End Property
    Public Overrides ReadOnly Property SeparatorDark() As Color
        Get
            Return Color.FromArgb(255, 189, 189, 189)
        End Get
    End Property
    Public Overrides ReadOnly Property SeparatorLight() As Color
        Get
            Return Color.FromName("ButtonHighlight")
        End Get
    End Property
    Public Overrides ReadOnly Property StatusStripGradientBegin() As Color
        Get
            Return Color.FromName("ButtonFace")
        End Get
    End Property
    Public Overrides ReadOnly Property StatusStripGradientEnd() As Color
        Get
            Return Color.FromArgb(255, 252, 252, 252)
        End Get
    End Property
    Public Overrides ReadOnly Property ToolStripBorder() As Color
        Get
            Return Color.FromArgb(255, 242, 242, 242)
        End Get
    End Property
    Public Overrides ReadOnly Property ToolStripDropDownBackground() As Color
        Get
            Return Color.FromArgb(255, 253, 253, 253)
        End Get
    End Property
    Public Overrides ReadOnly Property ToolStripGradientBegin() As Color
        Get
            Return Color.FromArgb(255, 252, 252, 252)
        End Get
    End Property
    Public Overrides ReadOnly Property ToolStripGradientMiddle() As Color
        Get
            Return Color.FromArgb(255, 248, 248, 248)
        End Get
    End Property
    Public Overrides ReadOnly Property ToolStripGradientEnd() As Color
        Get
            Return Color.FromName("ButtonFace")
        End Get
    End Property
    Public Overrides ReadOnly Property ToolStripContentPanelGradientBegin() As Color
        Get
            Return Color.FromName("ButtonFace")
        End Get
    End Property
    Public Overrides ReadOnly Property ToolStripContentPanelGradientEnd() As Color
        Get
            Return Color.FromArgb(255, 252, 252, 252)
        End Get
    End Property
    Public Overrides ReadOnly Property ToolStripPanelGradientBegin() As Color
        Get
            Return Color.FromName("ButtonFace")
        End Get
    End Property
    Public Overrides ReadOnly Property ToolStripPanelGradientEnd() As Color
        Get
            Return Color.FromArgb(255, 252, 252, 252)
        End Get
    End Property
    Public Overrides ReadOnly Property OverflowButtonGradientBegin() As Color
        Get
            Return Color.FromArgb(255, 245, 245, 245)
        End Get
    End Property
    Public Overrides ReadOnly Property OverflowButtonGradientMiddle() As Color
        Get
            Return Color.FromArgb(255, 242, 242, 242)
        End Get
    End Property
    Public Overrides ReadOnly Property OverflowButtonGradientEnd() As Color
        Get
            Return Color.FromName("ButtonShadow")
        End Get
    End Property

End Class
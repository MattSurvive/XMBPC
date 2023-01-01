Public Class Appearence

    Private Sub Appearence_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        T1.Parent = TBBG
        T2.Parent = TBBG
        T3.Parent = TBBG

        T1.Location = New Point(130, 0)
        T2.Location = New Point(330, 0)
        T3.Location = New Point(530, 0)
    End Sub

    Private Sub BGPreview_Click(sender As Object, e As EventArgs) Handles BGPreview.Click

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            BGPreview.Image = Image.FromFile(OpenFileDialog1.FileName)
            TBBG.Image = Image.FromFile(OpenFileDialog1.FileName)
            XMBDesk.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
            XMBDesk.Desktop.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
        End If

    End Sub

    Private Sub T1_Click(sender As Object, e As EventArgs) Handles T1.Click
        XMBDesk.TaskBar.BackgroundImage = My.Resources.taskbarbg
    End Sub

    Private Sub T2_Click(sender As Object, e As EventArgs) Handles T2.Click
        XMBDesk.TaskBar.BackgroundImage = My.Resources.taskbarbg1
    End Sub

    Private Sub T3_Click(sender As Object, e As EventArgs) Handles T3.Click
        XMBDesk.TaskBar.BackgroundImage = My.Resources.taskbarbg2
    End Sub

End Class
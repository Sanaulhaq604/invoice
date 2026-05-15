Public Class MyTextBox1
    Inherits TextBox

    Private Sub MyTextBox1_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Me.BackColor = Color.DeepSkyBlue
        Me.selectall()
    End Sub
    Private Sub MyTextBox1_Leave(sender As Object, e As EventArgs) Handles Me.Enter
        Me.BackColor = Color.White
    End Sub
End Class

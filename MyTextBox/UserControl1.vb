Public Class UserControl1
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        TextBox1.BackColor = Color.LightGreen
        TextBox1.SelectAll()
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        TextBox1.BackColor = Color.White
    End Sub
End Class

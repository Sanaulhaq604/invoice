Public Class DisappearingMsgBox
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Me.Close()
    End Sub

    Private Sub DisappearingMsgBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMsg.Text = MainPage.msg
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        MainPage.msg = "STOP"
        Me.Close()
    End Sub
End Class
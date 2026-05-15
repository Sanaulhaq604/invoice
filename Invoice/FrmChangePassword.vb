Public Class FrmChangePassword
    Dim AdminPassword As String = ""
    Private Sub cmbUser_Enter(sender As Object, e As EventArgs) Handles cmbUser.Enter
        Dim dt As DataTable = SQLData("select UserName from users")
        cmbUser.Items.Clear()
        If dt.Rows.Count > 0 Then
            For n = 0 To dt.Rows.Count - 1
                cmbUser.Items.Add(dt.Rows(n)(0))
            Next
        End If
    End Sub

    Private Sub cmbUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUser.SelectedIndexChanged
        txtNewUserName.Text = cmbUser.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPassword_Click(sender As Object, e As EventArgs) Handles btnPassword.Click
        Dim AdminPass As DataTable = SQLData("select password from users where UserType='ADMIN'")
        Dim AdminPassword As String = AdminPass.Rows(0)(0).ToString.ToUpper
        Dim dt As DataTable = SQLData("select password from users where username='" & cmbUser.Text & "'")
        If txtOldPassword.Text.ToUpper <> dt.Rows(0)(0).ToString.ToUpper And txtOldPassword.Text.ToUpper <> AdminPassword Then
            MsgBox("Password incorrect")
            Return
        End If
        If txtNewPassword.Text <> txtConfirmPassword.Text Then
            MsgBox("New password does not match")
            Return
        End If
        SQLData("update users set password='" & txtNewPassword.Text.ToUpper & "', username='" & txtNewUserName.Text & "' where username='" & cmbUser.Text.ToUpper & "'  ")
        MsgBox("Password & User Name Updated !")
        Me.Close()
    End Sub

    Private Sub txtOldPassword_Leave(sender As Object, e As EventArgs) Handles txtOldPassword.Leave
        Dim AdminPass As DataTable = SQLData("select password from users where UserType='ADMIN'")
        Dim AdminPassword As String = AdminPass.Rows(0)(0).ToString.ToUpper
        Dim dt As DataTable = SQLData("select password from users where username='" & cmbUser.Text & "'")
        If txtOldPassword.Text.ToUpper <> dt.Rows(0)(0).ToString.ToUpper And txtOldPassword.Text.ToUpper <> AdminPassword Then
            MsgBox("Password incorrect")
        End If
    End Sub

    Private Sub txtNewUserName_Enter(sender As Object, e As EventArgs) Handles txtNewUserName.Enter
        txtNewUserName.SelectAll()
    End Sub

    Private Sub txtNewPassword_Enter(sender As Object, e As EventArgs) Handles txtNewPassword.Enter
        txtNewPassword.SelectAll()
    End Sub

    Private Sub txtConfirmPassword_Enter(sender As Object, e As EventArgs) Handles txtConfirmPassword.Enter
        txtConfirmPassword.SelectAll()
    End Sub
End Class
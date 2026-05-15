Public Class RouteCustomerOrder
    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCustomerOrder.CellFormatting
        'If dgvCustomerOrder.CurrentCell.ColumnIndex = 0 Then

        'End If
        'dgvCustomerOrder.Rows
        '    dgvCustomerOrder.
        dgvCustomerOrder.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles txtRoute.Leave
        Dim dt As DataTable = SQLData("select id,Subsidary,route,rno from coa where main='trade debtors' and route='" & txtRoute.Text & "' order by rno,Subsidary")
        If dt.Rows.Count > 0 Then
            dgvCustomerOrder.DataSource = dt
        ElseIf dgvCustomerOrder.Rows.Count > 0 Then
            dgvCustomerOrder.DataSource.clear()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub dgvCustomerOrder_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomerOrder.CellValueChanged
        'If dgvCustomerOrder.Rows.Count > 0 Then
        '    If dgvCustomerOrder.Columns(e.ColumnIndex).Name = "colRNO" Then
        '        MsgBox(e.ColumnIndex)
        '    End If

        '    MsgBox(dgvCustomerOrder.CurrentRow.Cells("colRNO").Value.ToString)
        '        'MsgBox(dgvCustomerOrder.CurrentCell.Value)
        '    End If

    End Sub

    Private Sub dgvCustomerOrder_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomerOrder.CellEndEdit
        MsgBox(dgvCustomerOrder.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString + " " + dgvCustomerOrder.Rows(e.RowIndex).Cells(2).Value.ToString)
    End Sub
End Class
Public Class Product
    Sub Generate()
        txtACID.Text = ""
        txtVendorName.Text = ""
        'Dim dt As DataTable = SQLData("SELECT ID,Code,vendor,Company,NAME pname,Category,UrduName,isnull(min,0) Min,isnull(ReOrder,0) ReOrder,isnull(DeadLevel,0) DeadLevel,Stock,PurchaseRate*STOCK Value,PurchaseRate,salerate,salerate2,salerate3 FROM (
        '                                    select ID,Code,name,category,company,min,ReOrder,deadlevel,UrduName,PurchaseRate,vendor,salerate,salerate2,salerate3
        '                                    ,ISNULL((
        '                                    select sum(case when type in ('PURCHASE','Sale RETURN') THEN QTY WHEN type in ('Sale','PURCHASE RETURN') THEN QTY*-1 END) FROM PSPRODUCT WHERE PRID=P.ID AND DATE>=isnull(p.StockDate,'2021-1-1') and date<=dateadd(d,1,getdate()) and isclaim=0
        '                                    ),0) STOCK
        '                                    from Products P where company like '" & txtCompany.Text & "%'  and category like '" & txtCategory.Text & "%' and name like '" & txtName.Text & "%' and vendor = '" & txtVendor.Text & "' ) X order by vendor,company,name,category ")


        Dim dt As DataTable = SQLData("SELECT ID,Code,vendor,Company,NAME pname,Category,UrduName,isnull(min,0) Min,isnull(ReOrder,0) ReOrder,isnull(DeadLevel,0) DeadLevel,Stock,PurchaseRate*STOCK Value,PurchaseRate,salerate,salerate2,salerate3 FROM (
                                            select ID,Code,name,category,company,min,ReOrder,deadlevel,UrduName,PurchaseRate,vendor,salerate,salerate2,salerate3
                                            ,ISNULL((
			select sum(
			case 
				when (type in ('PURCHASE','SALE RETURN')) or (TYPE='STOCK TRANSFER' AND department2 like'{?Location}%') THEN isnull(QTY+isnull(schpc,0),0) 
				WHEN (type in ('SALE','PURCHASE RETURN')) or (TYPE='STOCK TRANSFER' AND department like '{?Location}%') THEN isnull((QTY+isnull(schpc,0))*-1 ,0)
			END) 
			FROM PSPRODUCT pss
			WHERE PSS.PRID=P.ID AND DATE>=isnull(StockDate,'2021-1-1') and date<=GETDATE() and isnull(isclaim,0)=0 )
			,0) STOCK

                                            from Products P where company like '" & txtCompany.Text & "%'  and category like '" & txtCategory.Text & "%' and name like '" & txtName.Text & "%' and ISNULL(vendor,'') LIKE '" & txtVendor.Text & "%' ) X order by vendor,company,name,category ")


        If dt.Rows.Count > 0 Then
            dgvProduct.DataSource = dt
        Else
            If dgvProduct.Rows.Count <> 0 Then
                dgvProduct.DataSource.clear()
            End If
        End If
    End Sub

    'Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.Leave, txtCompany.Leave, txtCategory.Leave, txtVendor.Leave
    '    Generate()
    'End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgvProduct_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvProduct.CellFormatting
        dgvProduct.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub dgvProduct_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProduct.CellEndEdit
        If dgvProduct.Columns(e.ColumnIndex).Name = "Stock" Or dgvProduct.Columns(e.ColumnIndex).Name = "Value" Then
            Return
        End If

        'MsgBox(dgvProduct.Columns(e.ColumnIndex).Name)
        'MsgBox(dgvProduct.Item(e.ColumnIndex, e.RowIndex).Value.ToString)
        'MsgBox(dgvProduct.Item(0, e.RowIndex).Value.ToString)
        Dim col As String
        Dim NewValue As String
        Dim PRID As String
        NewValue = dgvProduct.Item(e.ColumnIndex, e.RowIndex).Value.ToString.ToUpper
        PRID = dgvProduct.Item(0, e.RowIndex).Value.ToString
        If dgvProduct.Columns(e.ColumnIndex).Name = "pname" Then
            col = "Name"
        Else
            col = dgvProduct.Columns(e.ColumnIndex).Name
        End If
        SQLData("update products set " & col & "= N'" & NewValue & "' where id= " & PRID)
    End Sub
    Private Sub txtName_Enter(sender As Object, e As EventArgs) Handles txtName.Enter
        txtName.SelectAll()
    End Sub

    Private Sub txtCompany_Enter(sender As Object, e As EventArgs) Handles txtCompany.Enter
        txtCompany.SelectAll()
    End Sub

    Private Sub txtCategory_Enter(sender As Object, e As EventArgs) Handles txtCategory.Enter
        txtCategory.SelectAll()
    End Sub

    Private Sub TextBox4_Enter(sender As Object, e As EventArgs) Handles txtVendor.Enter
        txtCategory.SelectAll()
    End Sub

    Private Sub txtACID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtACID.KeyDown
        If e.KeyCode = Keys.Enter And txtACID.Text = "" Then
            e.Handled = True
            frmPartySearch.ShowDialog()
            txtACID.Text = frmPartySearch.acID
            txtVendorName.Text = frmPartySearch.CusName
            frmPartySearch.Dispose()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtACID.Text = "" Or txtVendor.Text = "" Or dgvProduct.Rows.Count = 0 Then
            Return
        End If
        SQLData("update products set vendor=" & txtACID.Text & " where company like '" & txtCompany.Text & "%'  and category like '" & txtCategory.Text & "%' and name like '" & txtName.Text & "%'")
        Generate()
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Generate()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnBatchUpdate.Click
        If dgvProduct.Rows.Count = 0 Then
            Return
        End If
        Dim result As DialogResult = MessageBox.Show("Do you want to Batch update selected Products in grid bellow?", "Pls Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result = DialogResult.Yes Then
            If txtNewCompany.Text <> "" Then
                SQLData("update products set company=" & txtNewCompany.Text & " where company like '" & txtCompany.Text & "%'  and category like '" & txtCategory.Text & "%' and name like '" & txtName.Text & "%'")
            End If
            If txtNewModel.Text <> "" Then
                SQLData("update products set category=" & txtNewModel.Text & " where company like '" & txtCompany.Text & "%'  and category like '" & txtCategory.Text & "%' and name like '" & txtName.Text & "%'")
            End If
            If txtNewName.Text <> "" Then
                SQLData("update products set Name=" & txtNewName.Text & " where company like '" & txtCompany.Text & "%'  and category like '" & txtCategory.Text & "%' and name like '" & txtName.Text & "%'")
            End If
            If txtNewUrduName.Text <> "" Then
                SQLData("update products set UrduName=N'" & txtNewUrduName.Text & " where company like '" & txtCompany.Text & "%'  and category like '" & txtCategory.Text & "%' and name like '" & txtName.Text & "%'")
            End If
            Generate()
        End If
    End Sub
End Class
Public Class frmPurchaseList
    Public Property InvNumber As String = ""
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmPurchaseList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDoc.Text = "Purchase List - " + frmLogin.MySqlServer + " - " + frmLogin.UserLevel
        'If frmLogin.UserLevel = "Admin" Then
        '    txtTotal.Visible = True
        '    txtFreightTotal.Visible = True
        '    DGVList.Columns("colGProfit").Visible = True
        '    txtTotalProfit.Visible = True
        '    txtProfitP.Visible = True
        '    DGVList.Columns("colProfitP").Visible = True

        'Else
        '    txtTotal.Visible = False
        '    txtFreightTotal.Visible = False
        '    DGVList.Columns("colGProfit").Visible = False
        '    txtTotalProfit.Visible = False
        '    txtProfitP.Visible = False
        '    DGVList.Columns("colProfitP").Visible = False
        'End If

        DTPStart.Value = Date.Today.AddDays(-10)
        DTPEnd.Value = Date.Today.AddDays(60)
        InvList()
        'DTPStart.Select()
        txtCustomer.SelectAll()
        txtCustomer.Select()
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles txtRoute.TextChanged, txtCustomer.TextChanged, txtDescription.TextChanged
        InvList()
    End Sub

    Private Sub DTPStart_ValueChanged(sender As Object, e As EventArgs) Handles DTPStart.ValueChanged, DTPEnd.ValueChanged
        InvList()
    End Sub


    Sub InvList()
        Dim DT As DataTable
        Dim DT2 As DataTable
        If chkEstimate.Checked = True Then
            DT = SQLData("select ROW_NUMBER() over (order by pd.date,doc) rn,DUEDATE,GOODS,BUILTY,abs(pd.freight) Freight,pd.date,pd.doc,a.Subsidary,a.route,pd.Description,pd.amount  from PSDetail pd join coa a on pd.acid=a.id where pd.date>='" & DTPStart.Value.ToString("d") & "' and pd.date<='" & DTPEnd.Value.ToString("d") & "' and pd.type='Purchase' and a.route like '" & txtRoute.Text & "%' and a.subsidary like '%" & txtCustomer.Text & "%' and builty like '%" & txtBiltyNumber.Text & "%' and (pd.description like '%" & txtDescription.Text & "%' OR pd.description like '%DIF%') order by pd.Duedate")
            DT2 = SQLData("select isnull(sum(amount),0) Amount,isnull(sum(freight),0) Freight,isnull(sum(grossprofit),0) GrossProfit from psdetail pd join coa a on pd.acid=a.id where pd.date>='" & DTPStart.Value.ToString("d") & "' and pd.date<='" & DTPEnd.Value.ToString("d") & "' and pd.type='Purchase' and a.route like '" & txtRoute.Text & "%' and a.subsidary like '%" & txtCustomer.Text & "%' and builty like '%" & txtBiltyNumber.Text & "%' and (pd.description like '%" & txtDescription.Text & "%'  OR PD.DESCRIPTION LIKE '%DIF%' )")
        Else
            'MsgBox("NO ESTIMATES")
            DT = SQLData("select ROW_NUMBER() over (order by pd.date,doc) rn,DUEDATE,GOODS,BUILTY, abs(pd.Freight) Freight,pd.date,pd.doc,a.Subsidary,a.route,pd.Description,pd.amount from PSDetail pd join coa a on pd.acid=a.id      where pd.date>='" & DTPStart.Value.ToString("d") & "' and pd.date<='" & DTPEnd.Value.ToString("d") & "' and pd.type='Purchase' and a.route like '" & txtRoute.Text & "%' and a.subsidary like '%" & txtCustomer.Text & "%' and builty like '%" & txtBiltyNumber.Text & "%'  and pd.description like '%" & txtDescription.Text & "%' and (pd.description not like 'Est%' OR pd.description like '%DIF%') order by pd.Duedate")
            DT2 = SQLData("select isnull(sum(amount),0) Amount,isnull(sum(freight),0) Freight,isnull(sum(grossprofit),0) GrossProfit from psdetail pd join coa a on pd.acid=a.id where pd.date>='" & DTPStart.Value.ToString("d") & "' and pd.date<='" & DTPEnd.Value.ToString("d") & "' and pd.type='Purchase' and a.route like '" & txtRoute.Text & "%' and a.subsidary like '%" & txtCustomer.Text & "%' and builty like '%" & txtBiltyNumber.Text & "%'   and (pd.description like '%" & txtDescription.Text & "%'  OR pd.description like '%DIF%')   ")

        End If

        txtTotalProfit.Text = Form3.Amt(DT2.Rows(0)("GrossProfit"))
        txtTotal.Text = Form3.Amt(DT2.Rows(0)("Amount"))
        txtFreightTotal.Text = Form3.Amt(DT2.Rows(0)("Freight"))
        If Form3.Numbers(txtTotal.Text) <> 0 And Form3.Numbers(txtTotalProfit.Text) <> 0 Then
            txtProfitP.Text = Math.Round((txtTotalProfit.Text / txtTotal.Text) * 100, 2)
        Else
            txtProfitP.Text = 0.00
        End If
        DGVList.DataSource = DT

    End Sub


    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If DGVList.Rows.Count > 0 Then
            For x = 0 To DGVList.Rows.Count - 1
                Dim inv As Integer = DGVList.Rows(x).Cells(2).Value
                Dim Customer As String = DGVList.Rows(x).Cells(3).Value
                'MsgBox(inv)
                Form3.PDFGen(inv, Customer)
            Next
            MsgBox(DGVList.Rows.Count & " Invoices Exported")
        Else
            MsgBox("No Invoices Selected")
        End If
    End Sub

    Private Sub DGVList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVList.CellDoubleClick
        Dim row As DataGridViewRow = DGVList.CurrentRow
        InvNumber = DGVList.SelectedRows(0).Cells("COLDOC").Value.ToString
        Me.Close()
        'SendKeys.Send("{Tab}")
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnPrintSelected.Click
        Dim inv As Integer = DGVList.SelectedRows(0).Cells(2).Value
        Dim InvDate As Date = DGVList.SelectedRows(0).Cells("colDate").Value
        Dim RnDate As Date = DGVList.SelectedRows(0).Cells("ColRdate").Value
        If RnDate >= Convert.ToDateTime("01.06.2020") And InvDate >= RnDate Then
            Form3.PrintInvoice(inv, 1, 1)
        Else
            Form3.PrintInvoice(inv, 1, 0)
        End If

    End Sub




    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If DGVList.Rows.Count > 0 Then
            For x = 0 To DGVList.Rows.Count - 1
                Dim inv As Integer = DGVList.Rows(x).Cells(2).Value
                Dim invdate As Date = DGVList.Rows(x).Cells("colDate").Value
                Dim Rndate As Date = DGVList.Rows(x).Cells("colRDate").Value
                If Rndate >= Convert.ToDateTime("01.06.2020") And invdate >= Rndate Then
                    Form3.PrintInvoice(inv, 1, 1)
                Else
                    Form3.PrintInvoice(inv, 1, 0)
                End If
            Next
            MsgBox(DGVList.Rows.Count & " Invoices Printed")
        Else
            MsgBox("No Invoices Selected")
        End If
    End Sub

    Private Sub btnExportSelected_Click(sender As Object, e As EventArgs) Handles btnExportSelected.Click
        If DGVList.Rows.Count > 0 Then
            Dim inv As Integer = DGVList.SelectedRows(0).Cells(2).Value
            Dim Customer As String = DGVList.SelectedRows(0).Cells(3).Value
            Form3.PDFGen(inv, Customer)
        Else
            MsgBox("No Invoices Selected")
        End If
    End Sub

    Private Sub txtRoute_Enter(sender As Object, e As EventArgs) Handles txtRoute.Enter, txtDescription.Enter
        txtRoute.SelectAll()
    End Sub

    Private Sub txtCustomer_Enter(sender As Object, e As EventArgs) Handles txtCustomer.Enter
        txtCustomer.SelectAll()
    End Sub

    Private Sub txtCustomer_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCustomer.KeyDown, txtDescription.KeyDown, txtRoute.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DGVList.Rows.Count > 0 Then
                Dim index As Integer = DGVList.SelectedRows.Item(0).Index
                'Form3.txtPRID.Text = dgvProduct.Item(1, index).Value.ToString
                InvNumber = DGVList.Item("ColDoc", index).Value.ToString
                Me.Close()
            End If
        End If



    End Sub

    Private Sub chkEstimate_CheckedChanged(sender As Object, e As EventArgs) Handles chkEstimate.CheckedChanged, txtBiltyNumber.Leave
        InvList()
    End Sub

    Private Sub btnListPreview_Click(sender As Object, e As EventArgs) Handles btnListPreview.Click
        MainPage.rptName = settings("Reports Folder") + "InvoiceList.rpt"
        rptInvPreview.ShowDialog()

    End Sub
End Class
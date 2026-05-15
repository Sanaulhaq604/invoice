Public Class ProductSearch
    Public Property ProductID As String = ""
    Public Property prIDtxt As String = ""
    Public Property prName As String = ""
    Public Property prSize As String = ""
    Public Property PrRate As String = ""

    Sub PrSearch()
        If txtItem.Text = Nothing And txtiCode.Text = Nothing Then
            Return
        End If

        Dim dt As DataTable

        If chkDeadItems.Checked = True Then
            dt = Form3.SQLDataSP("SearchProduct2")
        Else
            dt = SQLData("select *,round(SelectedListPrice*((100-discount)/100),2) NetRate from (
select 
--ROW_NUMBER() over (order by id) rn,
code,company,category,name,size,StockQty AvailableStock
,case 
	when (select pd.PriceList from PartyDiscount pd WHERE PD.ACID='" & MainPage.CustID & "' AND PD.company=P.Company)='P' then PurchaseRate 
	when (select pd.PriceList from PartyDiscount pd WHERE PD.ACID='" & MainPage.CustID & "' AND PD.company=P.Company)='A' then SaleRate 
	when (select pd.PriceList from PartyDiscount pd WHERE PD.ACID='" & MainPage.CustID & "' AND PD.company=P.Company)='B' then SaleRate2 
	when (select pd.PriceList from PartyDiscount pd WHERE PD.ACID='" & MainPage.CustID & "' AND PD.company=P.Company)='C' then SaleRate3 
	when '" & MainPage.DocType & "'='Purchase' then PurchaseRate
    ELSE SaleRate
end SelectedListPrice
,case when '" & MainPage.DocType & "'='Purchase' then 'P' else ISNULL((select pd.PriceList from PartyDiscount pd WHERE PD.ACID='" & MainPage.CustID & "' AND PD.company=P.Company),'A') end PriceList
,ISNULL((select pd.discount from PartyDiscount pd WHERE PD.ACID='" & MainPage.CustID & "' AND PD.company=P.Company),0) Discount
--,StockQty AvailableStock
--,DATEDIFF(M,(select max(date) from PSProduct ps where ps.prid=p.id),GETDATE()) LastSaleMonths
,p.id
from products p 
where status='ACTIVE' AND company like '" & txtCompany.Text & "%' and category like '" & txtCategory.Text & "%' and name like '" & txtItem.Text & "%' and prid like '" & txtiCode.Text & "'
group by code,id,company,category,name,urduname,size,boxscheme,packing,purchaserate,salerate,salerate2,salerate3,min,reorder,category2,StockQty 
) x --where x.LastSaleMonths between 0 and 6
order  by name,category      ")
        End If



        'If MainPage.DocType = "Purchase" Then
        '    dt = SQLDataSP("SearchProduct2")
        'Else
        '    dt = SQLDataSP("SearchProduct2")
        'End If
        dgvProduct.DataSource = dt
    End Sub

    Private Sub txtItem_Leave(sender As Object, e As EventArgs) Handles txtCategory.Leave, txtItem.Leave, txtCompany.Leave, txtiCode.TextChanged
        PrSearch()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        prIDtxt = ""
        ProductID = ""
        prName = ""
        MainPage.CustID=""
        'txtItem.Text = ""
        Me.Close()

    End Sub


    Sub ItemSelect()
        If dgvProduct.Rows.Count > 0 Then
            Dim index As Integer = dgvProduct.SelectedRows.Item(0).Index
            'Form3.txtPRID.Text = dgvProduct.Item(1, index).Value.ToString
            prIDtxt = dgvProduct.Item("colCode", index).Value.ToString
            ProductID = dgvProduct.Item("colPID", index).Value.ToString
            prName = dgvProduct.Item("colName", index).Value.ToString + " " + dgvProduct.Item("colCategory", index).Value.ToString + " " + dgvProduct.Item("colCompany", index).Value.ToString
            prSize = dgvProduct.Item("colSize", index).Value.ToString
            PrRate = dgvProduct.Item("colPrice", index).Value.ToString
            MainPage.CustID = ""
            'txtItem.Text = ""
            Me.Close()
            'SendKeys.Send("{TAB}")
            'Return
        End If
    End Sub


    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProduct.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            If dgvProduct.Rows.Count > 0 Then
                Dim index As Integer = dgvProduct.SelectedRows.Item(0).Index
                'Form3.txtPRID.Text = dgvProduct.Item(1, index).Value.ToString
                prIDtxt = dgvProduct.Item("colCode", index).Value.ToString
                ProductID = dgvProduct.Item("colPID", index).Value.ToString
                prName = dgvProduct.Item("colName", index).Value.ToString + " " + dgvProduct.Item("colCategory", index).Value.ToString + " " + dgvProduct.Item("colCompany", index).Value.ToString
                prSize = dgvProduct.Item("colSize", index).Value.ToString
                PrRate = dgvProduct.Item("colPrice", index).Value.ToString
                MainPage.CustID = ""
                'txtItem.Text = ""
                Me.Close()
                'SendKeys.Send("{TAB}")
                'Return
            End If
        End If
    End Sub

    Private Sub txtCompany_Enter(sender As Object, e As EventArgs) Handles txtCompany.Enter
        'If txtItem.Text = "" Then
        '    txtItem.Select()
        '    Return
        'End If
        txtCompany.SelectAll()
    End Sub

    Private Sub txtItem_Enter(sender As Object, e As EventArgs) Handles txtItem.Enter
        txtItem.SelectAll()
        PrSearch()
    End Sub

    Private Sub txtCategory_Enter(sender As Object, e As EventArgs) Handles txtCategory.Enter
        txtCategory.SelectAll()
    End Sub

    Private Sub txtItem_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItem.KeyDown, txtiCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            ItemSelect()
        End If
        If e.KeyCode = Keys.Down And dgvProduct.Rows.Count > 0 Then
            dgvProduct.Select()
        End If

    End Sub

    Private Sub txtCompany_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCompany.KeyDown
        If e.KeyCode = Keys.Enter Then
            ItemSelect()
        End If
        If e.KeyCode = Keys.Down And dgvProduct.Rows.Count > 0 Then
            dgvProduct.Select()
        End If
    End Sub

    Private Sub txtCategory_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCategory.KeyDown
        If e.KeyCode = Keys.Enter Then
            ItemSelect()
        End If
        If e.KeyCode = Keys.Down And dgvProduct.Rows.Count > 0 Then
            dgvProduct.Select()
        End If
    End Sub



    Private Sub dgvProduct_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProduct.CellContentDoubleClick
        prIDtxt = dgvProduct.Item(0, e.RowIndex()).Value
        ProductID = dgvProduct.Item("colPID", e.RowIndex).Value.ToString
        Me.Close()
        'SendKeys.Send("{TAB}")
    End Sub

    Private Sub ProductSearch_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        If txtiCode.Visible = False Then
            txtItem.Select()
            txtItem.SelectAll()
        Else
            txtiCode.Select()
            txtiCode.SelectAll()
        End If
        If dgvProduct.Rows.Count > 0 Then
            'dgvProduct.DataSource = Nothing
        End If
    End Sub

    Private Sub ProductSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MainPage.PSERVER = "ALQASWAAUTOS" Then
            Label4.Visible = True
            txtiCode.Visible = True
        Else
            Label4.Visible = False
            txtiCode.Visible = False
        End If
        PrSearch()
    End Sub

    Private Sub chkDeadItems_CheckedChanged(sender As Object, e As EventArgs) Handles chkDeadItems.CheckedChanged
        PrSearch()
    End Sub


End Class
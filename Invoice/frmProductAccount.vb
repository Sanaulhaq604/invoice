Imports System.Data.SqlClient

Public Class frmProductAccount
    Dim LASTPRID As Integer = 0
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click, Label18.Click

    End Sub

    Sub Start()
        Dim tbid As DataTable = SQLData("select max(id) PID from products")

        Dim prid As Integer = 0
        If tbid.Rows.Count > 0 Then
            prid = tbid.Rows(0)("PID")
        End If
        ProductList()
        txtProductID.Text = prid
        txtProductCode.Text = prid
        LASTPRID = prid
        txtProductID.Select()
        txtProductID.SelectAll()
    End Sub

    Private Sub frmProductAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set cmbStatusFilter first item as selected by default
        If cmbStatusFilter.Items.Count > 0 Then
            cmbStatusFilter.SelectedIndex = 0
        End If
        Start()
        ProductsListIDWise(txtProductID.Text)
        SchQtyDGV(txtProductID.Text)

    End Sub

    Sub ProductList()
        Dim tbProductsList As DataTable
        Dim HL As String = ""
        Dim Status As String = ""
        If chkHL.Checked Then
            HL = " and HighLight=1 "
        Else
            HL = ""
        End If
        If cmbStatusFilter.Text.ToUpper = "ALL" Then
            Status = "and (status like '%' or status is null)"
        Else
            'Status = cmbStatusFilter.Text
            Status = "AND STATUS='" & cmbStatusFilter.Text & "'"
        End If
        If chkDeadItems.Checked = True Then
            tbProductsList = SQLData("select ROW_NUMBER() over (order by id) rn,code,id,company,category,name,urduname,size,boxscheme,packing,purchaserate,salerate,salerate2,salerate3,min,reorder,category2 from products p where company like '" & txtCompany.Text & "%' and category like '" & txtCategory.Text & "%' and name like '" & txtName.Text & "%' " & HL & Status & "  order  by name,category   ")
        Else
            tbProductsList = SQLData("select ROW_NUMBER() over (order by id) rn,code,id,company,category,name,urduname,size,boxscheme,packing,purchaserate,salerate,salerate2,salerate3,min,reorder,category2 from products p where company like '" & txtCompany.Text & "%' and category like '" & txtCategory.Text & "%' and name like '" & txtName.Text & "%' group by code,id,company,category,name,urduname,size,boxscheme,packing,purchaserate,salerate,salerate2,salerate3,min,reorder,category2 having DATEDIFF(D,(select max(date) from PSProduct ps where ps.prid=p.id),getdate()) between 0 and 180   order  by name,category   ")
        End If

        If tbProductsList.Rows.Count > 0 Then
            dgvProductList.DataSource = tbProductsList
        Else
            If dgvProductList.Rows.Count > 1 Then
                dgvProductList.DataSource.clear()
            End If

        End If


    End Sub

    Sub ProductsListIDWise(prid)
        Dim tbProducts As DataTable

        If prid <> 0 Then
            Dim HL As String = "N"
            tbProducts = SQLData("select ROW_NUMBER() over (order by id) rn,*,isnull(status,'') Status2,isnull(SAP_Code,'') SAPCode,isnull(StockDate,'2021-1-1') StockDat,isnull(margin,0) Margin,isnull(FocusItems,0) FocusItems,isnull(Batch,'') Rack,isnull(CtnQty,0) CtnQty,ISNULL(HIGHLIGHT,0) HIGHLIGHT from products where id=" & prid)
            If tbProducts.Rows.Count = 0 Then
                Return
            End If
            If Not IsDBNull(tbProducts.Rows(0)("Highlight")) Then
                If tbProducts.Rows(0)("Highlight") = 1 Then
                    HL = "Y"
                Else
                    HL = "N"
                End If
            Else
                HL = "N"
            End If

            txtMargin.Text = tbProducts.Rows(0)("margin").ToString
            txtSapCode.Text = tbProducts.Rows(0)("SapCode").ToString
            txtProductDetails.Text = tbProducts.Rows(0)("ProductDetails").ToString
            cmbProductCompany.Text = tbProducts.Rows(0)("Company").ToString
            cmbProductModel.Text = tbProducts.Rows(0)("Category").ToString
            cmbHL.Text = HL
            cmbPacking.Text = tbProducts.Rows(0)("Packing").ToString
            cmbUOM.Text = tbProducts.Rows(0)("Size").ToString
            'cmbFocus.Text = tbProducts.Rows(0)("FocusItems").ToString
            txtProductName.Text = tbProducts.Rows(0)("Name").ToString
            txtUrduName.Text = tbProducts.Rows(0)("UrduName").ToString
            txtProductCode.Text = tbProducts.Rows(0)("Code").ToString
            txtPurchaseRate.Text = tbProducts.Rows(0)("PurchaseRate").ToString
            txtSaleRate.Text = tbProducts.Rows(0)("SaleRate").ToString
            txtSaleRate2.Text = Form3.Numbers(tbProducts.Rows(0)("SaleRate2").ToString)
            txtSaleRate3.Text = Form3.Numbers(tbProducts.Rows(0)("SaleRate3").ToString)
            txtMinimumStock.Text = Form3.Numbers(tbProducts.Rows(0)("min").ToString)
            txtReOrderQty.Text = Form3.Numbers(tbProducts.Rows(0)("reorder").ToString)
            txtVendorID.Text = Form3.Numbers(tbProducts.Rows(0)("Vendor").ToString)
            TxtBoxScheme.Text = Form3.Numbers(tbProducts.Rows(0)("BoxScheme").ToString)
            txtRack.Text = tbProducts.Rows(0)("Rack").ToString
            txtCtnQty.Text = tbProducts.Rows(0)("CtnQty").ToString
            dtpStockDate.Value = tbProducts.Rows(0)("StockDat")

            Dim status As String = ""

            If tbProducts.Rows(0)("Status2").ToString = "" Or tbProducts.Rows(0)("Status2").ToString.ToUpper = "ACTIVE" Then
                status = "Active"
            ElseIf tbProducts.Rows(0)("Status2").ToString.ToUpper = "SHORT" Then
                status = "Short"
            Else
                status = "Dead"
            End If
            cmbStatus.Text = status
            'Dim hl As String = "N"
            If tbProducts.Rows(0)("HighLight").ToString = "True" Then
                HL = "Y"
            End If
            cmbHL.Text = HL
            Dim Focus As String = "N"
            Dim PFOCUS As String = tbProducts.Rows(0)("FocusItems").ToString
            'MsgBox(PFOCUS)
            If PFOCUS = "True" Then
                Focus = "Y"
            End If
            cmbFocus.Text = Focus
            If txtVendorID.Text <> 0 Then
                Dim ven As DataTable = SQLData("select isnull(subsidary,'') Vend from coa where id=" & Form3.Numbers(txtVendorID.Text))
                If ven.Rows.Count > 0 Then
                    txtVendorName.Text = ven.Rows(0)("Vend")
                Else
                    txtVendorName.Text = ""
                    txtVendorID.Text = ""
                End If
            Else
                txtVendorName.Text = ""
                txtVendorID.Text = ""
            End If


            'dgvProductList.DataSource = tbProducts
        Else

            cmbProductCompany.Text = ""
            cmbProductModel.Text = ""
            cmbPacking.Text = ""
            cmbUOM.Text = ""
            cmbFocus.Text = ""
            txtProductName.Text = ""
            txtUrduName.Text = ""
            txtPurchaseRate.Text = ""
            txtSaleRate.Text = ""
            txtSaleRate2.Text = ""
            txtSaleRate3.Text = ""
            txtVendorID.Text = ""
            txtVendorName.Text = ""

        End If
    End Sub

    Private Sub txtProductID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductID.KeyDown
        If e.KeyCode = Keys.Down Then
            txtProductID.Text -= 1
            ProductsListIDWise(txtProductID.Text)
            SchQtyDGV(txtProductID.Text)
            txtProductID.Select()
            txtProductID.SelectAll()
        End If
        If e.KeyCode = Keys.Up Then
            If Val(txtProductID.Text) >= LASTPRID Then
                Return
            End If
            txtProductID.Text += 1
            ProductsListIDWise(txtProductID.Text)
            SchQtyDGV(txtProductID.Text)
            txtProductID.Select()
            txtProductID.SelectAll()
        End If

        If e.KeyCode = Keys.Enter Then
            ProductsListIDWise(txtProductID.Text)
            SchQtyDGV(txtProductID.Text)
            txtProductID.Select()
            txtProductID.SelectAll()
        End If

    End Sub

    Private Sub cmbProductCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductCompany.Leave
        SQLData("update products set company='" & cmbProductCompany.Text & "' where id=" & txtProductID.Text)
    End Sub

    Sub SchQtyDGV(prid)
        Dim tbSchQTY As DataTable = SQLData("select *,((select top 1 SaleRate from products where id=" & prid & ")*SchOn)/case when schon+schpcs<>0 then (schon+schpcs) else 1 end NetPrice from SchQTYSlabs where prid=" & prid & " order by date desc,SchOn")
        If tbSchQTY.Rows.Count > 0 Then
            dgvSchemeSlab.DataSource = tbSchQTY
            'For i = 0 To dgvSchemeSlab.Rows.Count - 1
            '    dgvSchemeSlab.Rows(i).HeaderCell.Value = CStr(i + 1)
            'Next
        ElseIf dgvSchemeSlab.Rows.Count > 0 Then
            dgvSchemeSlab.DataSource.clear()
        End If

    End Sub

    Private Sub dgvProductList_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvProductList.CellFormatting
        dgvProductList.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnQtySchSlab.Click
        SQLData("Insert into SchQTYSlabs (date,id,prid,iid) values(getdate(),(select max(iid)+1 from SchQTYSlabs)," & txtProductID.Text & ",(select max(iid)+1 from SchQTYSlabs))")
        SchQtyDGV(txtProductID.Text)
    End Sub

    Private Sub dgvSchemeSlab_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSchemeSlab.CellEndEdit
        Dim col As String
        Dim NewValue As String
        Dim PRID As String
        Dim iid As String

        NewValue = dgvSchemeSlab.Item(e.ColumnIndex, e.RowIndex).Value.ToString.ToUpper
        PRID = dgvSchemeSlab.Item("colSCHQTYPRID", e.RowIndex).Value.ToString
        iid = dgvSchemeSlab.Item("colSchIID", e.RowIndex).Value.ToString
        If dgvSchemeSlab.Columns(e.ColumnIndex).Name = "colQtyDate" Then
            col = "DATE"
        ElseIf dgvSchemeSlab.Columns(e.ColumnIndex).Name = "colSchemeOn" Then
            col = "SchOn"
        ElseIf dgvSchemeSlab.Columns(e.ColumnIndex).Name = "colSchemePcs" Then
            col = "SchPcs"
        ElseIf dgvSchemeSlab.Columns(e.ColumnIndex).Name = "colList" Then
            col = "List"
        ElseIf dgvSchemeSlab.Columns(e.ColumnIndex).Name = "colRate" Then
            col = "Rate"

        Else
            col = dgvSchemeSlab.Columns(e.ColumnIndex).Name
        End If
        SQLData("update SchQTYSlabs set " & col & "= '" & NewValue & "' where prid= " & PRID & " and iid= " & iid)
        SchQtyDGV(txtProductID.Text)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click
        SQLData("Delete from SchQTYSlabs where isnull(schon,0)=0 and isnull(schpcs,0)=0")
        SQLData("delete from products where company='' and name='' and category='' ")
        SQLData("delete from products where company is null and name is null and category is null ")
        Me.Close()
    End Sub

    Sub AllClear()
        txtMinimumStock.Text = ""
        txtOpeningQty.Text = ""
        txtProductCode.Text = ""
        txtProductID.Text = ""
        txtProductName.Text = ""
        txtPurchaseRate.Text = ""
        txtReOrderQty.Text = ""
        txtSaleRate.Text = ""
        txtSaleRate2.Text = ""
        txtSaleRate3.Text = ""
        txtUrduName.Text = ""
        cmbPacking.Text = ""
        txtVendorID.Text = ""
        txtVendorName.Text = ""
        cmbProductCompany.Text = ""
        cmbProductModel.Text = ""
        cmbUOM.Text = ""
        cmbHL.Text = ""
        cmbStatus.Text = ""
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        AllClear()
        Start()
        ProductsListIDWise(txtProductID.Text)
        SchQtyDGV(txtProductID.Text)
        txtProductID.Select()
        txtProductID.SelectAll()

    End Sub

    Private Sub dgvProductList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductList.CellDoubleClick
        txtProductID.Text = dgvProductList.CurrentRow.Cells("colProductID").Value.ToString
        ProductsListIDWise(txtProductID.Text)
        SchQtyDGV(txtProductID.Text)
        txtProductID.Select()
        txtProductID.SelectAll()
    End Sub

    Private Sub cmbProductCompany_Enter(sender As Object, e As EventArgs) Handles cmbProductCompany.Enter
        cmbProductCompany.Items.Clear()
        Dim dt As DataTable = SQLData("select distinct company from products ORDER BY COMPANY")
        For n = 0 To dt.Rows.Count - 1
            cmbProductCompany.Items.Add(dt.Rows(n)("company"))
        Next

    End Sub

    Private Sub cmbProductModel_Enter(sender As Object, e As EventArgs) Handles cmbProductModel.Enter
        cmbProductModel.Items.Clear()
        Dim dt As DataTable = SQLData("select distinct category from products")
        For n = 0 To dt.Rows.Count - 1
            cmbProductModel.Items.Add(dt.Rows(n)("category"))
        Next
    End Sub

    Private Sub cmbProductCompany_TextChanged(sender As Object, e As EventArgs) Handles cmbProductCompany.TextChanged
        Dim SELSTART As Integer = cmbProductCompany.SelectionStart
        cmbProductCompany.Text = cmbProductCompany.Text.ToUpper()
        cmbProductCompany.SelectionStart = SELSTART
    End Sub

    Private Sub cmbProductModel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductModel.TextChanged
        Dim SELSTART As Integer = cmbProductModel.SelectionStart
        cmbProductModel.Text = cmbProductModel.Text.ToUpper()
        cmbProductModel.SelectionStart = SELSTART
    End Sub

    Private Sub cmbUOM_TextChanged(sender As Object, e As EventArgs) Handles cmbUOM.TextChanged
        Dim SELSTART As Integer = cmbUOM.SelectionStart
        cmbUOM.Text = cmbUOM.Text.ToUpper()
        cmbUOM.SelectionStart = SELSTART
    End Sub

    Private Sub cmbProductModel_Leave(sender As Object, e As EventArgs) Handles cmbProductModel.Leave

        SQLData("update products set category='" & cmbProductModel.Text & "' where id=" & txtProductID.Text)
    End Sub

    Private Sub txtProductName_Leave(sender As Object, e As EventArgs) Handles txtProductName.Leave

        SQLData("update products set name='" & txtProductName.Text & "' where id=" & txtProductID.Text)
    End Sub

    Private Sub txtUrduName_Leave(sender As Object, e As EventArgs) Handles txtUrduName.Leave
        SQLData("update products set urduname=N'" & txtUrduName.Text & "' where id=" & txtProductID.Text)
    End Sub

    Private Sub cmbUOM_Leave(sender As Object, e As EventArgs) Handles cmbUOM.Leave
        SQLData("update products set size='" & cmbUOM.Text & "' where id=" & txtProductID.Text)
    End Sub

    Private Sub cmbPacking_Leave(sender As Object, e As EventArgs) Handles cmbPacking.Leave
        SQLData("update products set packing=" & cmbPacking.Text & " where id=" & txtProductID.Text)
    End Sub

    Private Sub txtPurchaseRate_Leave(sender As Object, e As EventArgs) Handles txtPurchaseRate.Leave
        SQLData("update products set PurchaseRate=" & txtPurchaseRate.Text & " where id=" & txtProductID.Text)
    End Sub

    'Private Sub txtSaleRate_Leave(sender As Object, e As EventArgs) Handles txtSaleRate.Leave
    '    SQLData("update products set SaleRate=" & txtSaleRate.Text & " where id=" & txtProductID.Text)
    '    SchQtyDGV(txtProductID.Text)
    '    ProductList()
    'End Sub

    Private Sub txtSaleRate2_Leave(sender As Object, e As EventArgs) Handles txtSaleRate2.Leave
        SQLData("update products set SaleRate2=" & txtSaleRate2.Text & " where id=" & txtProductID.Text)
    End Sub

    Private Sub txtSaleRate3_Leave(sender As Object, e As EventArgs) Handles txtSaleRate3.Leave
        SQLData("update products set SaleRate3=" & txtSaleRate3.Text & " where id=" & txtProductID.Text)
    End Sub

    Private Sub txtMinimumStock_Leave(sender As Object, e As EventArgs) Handles txtMinimumStock.Leave
        SQLData("update products set min=" & Form3.Numbers(txtMinimumStock.Text) & " where id=" & txtProductID.Text)
    End Sub

    Private Sub txtReOrderQty_Leave(sender As Object, e As EventArgs) Handles txtReOrderQty.Leave
        SQLData("update products set ReOrder=" & Form3.Numbers(txtReOrderQty.Text) & " where id=" & txtProductID.Text)
    End Sub

    Private Sub cmbPrefVendor_Leave(sender As Object, e As EventArgs)
        SQLData("update products set Vendor=" & Form3.Numbers(txtVendorID.Text) & " where id=" & txtProductID.Text)
    End Sub

    Private Sub txtProductCode_Leave(sender As Object, e As EventArgs) Handles txtProductCode.Leave
        SQLData("update products set code='" & txtProductCode.Text & "' where id=" & txtProductID.Text)
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        AllClear()
        SQLData("insert into products (odate,id,code,company,name,category,margin) values(getdate()," & LASTPRID + 1 & ",'" & LASTPRID + 1 & "','','','',0   )")
        Start()
        ProductsListIDWise(txtProductID.Text)
    End Sub

    Private Sub txtName_Leave(sender As Object, e As EventArgs) Handles txtName.Leave, txtCategory.Leave, txtCompany.Leave
        ProductList()
    End Sub



    Private Sub txtVendorID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVendorID.KeyDown
        If e.KeyCode = Keys.Enter And txtVendorID.Text = "" Then
            e.Handled = True
            frmPartySearch.ShowDialog()
            txtVendorID.Text = frmPartySearch.acID
            txtVendorName.Text = frmPartySearch.CusName
        End If
    End Sub

    Private Sub txtVendorID_Leave(sender As Object, e As EventArgs) Handles txtVendorID.Leave
        SQLData("update products set vendor=" & Form3.Numbers(txtVendorID.Text) & " where id=" & txtProductID.Text)
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

    Private Sub dgvProductList_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductList.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtProductID.Text = dgvProductList.CurrentRow.Cells("colProductID").Value.ToString
            ProductsListIDWise(txtProductID.Text)
            SchQtyDGV(txtProductID.Text)
            txtProductID.Select()
            txtProductID.SelectAll()
        End If
    End Sub

    Private Sub TxtBoxScheme_Leave(sender As Object, e As EventArgs) Handles TxtBoxScheme.Leave
        SQLData("update products set BoxScheme=" & Form3.Numbers(TxtBoxScheme.Text) & " where id=" & txtProductID.Text)

    End Sub

    Private Sub cmbHL_Leave(sender As Object, e As EventArgs) Handles cmbHL.Leave
        Dim HL As Integer = 0
        If cmbHL.SelectedItem.ToString = "Y" Then
            HL = 1
        Else
            HL = 0
        End If
        SQLData("update products set HighLight=" & HL & " where id=" & txtProductID.Text)
    End Sub

    Private Sub cmbStatus_Leave(sender As Object, e As EventArgs) Handles cmbStatus.Leave
        SQLData("update products set status='" & cmbStatus.Text & "' where id=" & txtProductID.Text)
    End Sub

    Private Sub btnList_Click(sender As Object, e As EventArgs) Handles btnList.Click
        MainPage.rptName = Settings("Reports Folder") + "Product Price List.rpt"
        MainPage.Company = txtCompany.Text
        MainPage.PName = txtName.Text
        MainPage.PCategory = txtCategory.Text
        If chkHL.Checked Then
            MainPage.HighLighted = " and Highlight=1 "
        Else
            MainPage.HighLighted = ""
        End If

        If chkDeadItems.Checked = True Then
            MainPage.DocNumber = 0
        Else
            MainPage.DocNumber = 1
        End If
        rptInvPreview.Show()
    End Sub

    Private Sub chkDeadItems_CheckedChanged(sender As Object, e As EventArgs) Handles chkDeadItems.CheckedChanged
        ProductList()
    End Sub

    Private Sub txtProductDetails_Leave(sender As Object, e As EventArgs) Handles txtProductDetails.Leave
        SQLData("update products set ProductDetails='" & txtProductDetails.Text & "' where id=" & txtProductID.Text)
    End Sub

    Private Sub txtSapCode_Leave(sender As Object, e As EventArgs) Handles txtSapCode.Leave
        SQLData("update products set sap_code='" & txtSapCode.Text.Trim & "' where id=" & txtProductID.Text)
    End Sub

    Private Sub dtpStockDate_Leave(sender As Object, e As EventArgs) Handles dtpStockDate.Leave
        SQLData("update products set StockDate='" & dtpStockDate.Value.ToString("d") & "' where id=" & txtProductID.Text)
    End Sub

    Private Sub txtMargin_TextChanged(sender As Object, e As EventArgs) Handles txtMargin.Leave
        SQLData("update products set Margin=" & txtMargin.Text & " where id=" & txtProductID.Text)
    End Sub

    Private Sub cmbFocus_Leave(sender As Object, e As EventArgs) Handles cmbFocus.Leave
        Dim Focus As Integer = 0
        If cmbFocus.SelectedItem.ToString = "Y" Then
            Focus = 1
        Else
            Focus = 0
        End If
        SQLData("update products set FocusItems=" & Focus & " where id=" & txtProductID.Text)
    End Sub

    Private Sub txtRack_Leave(sender As Object, e As EventArgs) Handles txtRack.Leave
        SQLData("update products set Batch='" & txtRack.Text & "' where id=" & txtProductID.Text)
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles txtCtnQty.Leave
        SQLData("update products set CtnQty=" & Form3.Numbers(txtCtnQty.Text) & " where id=" & txtProductID.Text)
    End Sub

    Private Sub chkHL_CheckedChanged(sender As Object, e As EventArgs) Handles chkHL.CheckedChanged, cmbStatusFilter.SelectedIndexChanged
        ProductList()
    End Sub

    Private Sub btnClearHighLights_Click(sender As Object, e As EventArgs) Handles btnClearHighLights.Click
        For n = 0 To dgvProductList.Rows.Count - 1
            Dim prid As String = dgvProductList.Rows(n).Cells("colProductID").Value
            SQLData("update products set HighLight=0 where id=" & prid)
        Next
        ProductList()
    End Sub

    'Private Sub txtSaleRate_TextChanged(sender As Object, e As EventArgs) Handles txtSaleRate.TextChanged
    '    Dim prid As String = txtProductID.Text
    '    SQLData("update products set highlight=1 where id=" & prid)
    '    cmbHL.Text = "Y"
    'End Sub

    Private Sub txtSaleRate_Leave(sender As Object, e As EventArgs) Handles txtSaleRate.Leave
        ' Validate product id
        Dim prodId As Integer
        If Not Integer.TryParse(txtProductID.Text, prodId) Then
            Return
        End If

        ' Validate new rate
        Dim newRate As Decimal
        If Not Decimal.TryParse(txtSaleRate.Text.Trim(), newRate) Then
            ' invalid input - optionally notify user
            txtSaleRate.BackColor = Color.LightCoral
            Return
        End If

        Try
            ' Read current rate from DB (use parameterized query)
            Dim currentRate As Decimal? = Nothing
            Using conn As New SqlConnection(MainPage.conString)
                conn.Open()
                Using cmd As New SqlCommand("SELECT SaleRate FROM Products WHERE id = @id", conn)
                    cmd.Parameters.AddWithValue("@id", prodId)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
                        currentRate = Convert.ToDecimal(result)
                    End If
                End Using
            End Using

            ' If product not found or rate changed, update and set highlight = 1
            If currentRate Is Nothing OrElse currentRate.Value <> newRate Then
                Using conn As New SqlConnection(MainPage.conString)
                    conn.Open()
                    Using cmd As New SqlCommand("UPDATE Products SET SaleRate = @rate, Highlight = 1 WHERE id = @id", conn)
                        cmd.Parameters.AddWithValue("@rate", newRate)
                        cmd.Parameters.AddWithValue("@id", prodId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                ' Visual feedback: highlight textbox to indicate change
                txtSaleRate.BackColor = Color.LightYellow
            Else
                ' No change: restore default look
                txtSaleRate.BackColor = SystemColors.Window
            End If
        Catch ex As Exception
            ' Log or show error as appropriate for your app
            MessageBox.Show("Failed to update product rate: " & ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        SchQtyDGV(txtProductID.Text)
        ProductList()

    End Sub

End Class
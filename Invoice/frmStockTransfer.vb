Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmStockTransfer
    Dim DocType = "Stock Transfer"
    Dim oldPSID As Integer = 0


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles txtPRID.Enter
        'If txtPRID.Text = "" Then
        '    ProductSearch.ShowDialog()
        '    txtPRID.Text = ProductSearch.prIDtxt
        '    If txtPRID.Text <> "" Then
        '        SendKeys.Send("{TAB}")
        '    End If
        'End If
    End Sub

    Private Sub txtPRID_Leave(sender As Object, e As EventArgs) Handles txtPRID.Leave
        If txtPRID.Text <> "" Then
            Dim dt As DataTable = SQLData("select name+' '+category+' '+company Product from products where code='" & txtPRID.Text & "' ")
            If dt.Rows.Count > 0 Then
                txtProduct.Text = dt.Rows(0)(0)
            Else
                MsgBox("Product Code Does Not Exist")
            End If


        End If
    End Sub

    Private Sub frmStockTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDoc.Text = "Stock Transfer - " + frmLogin.MySqlServer + " - " + frmLogin.UserLevel
        Dim dt As DataTable = SQLData("select distinct department from (
                                             select distinct department from PSProduct
                                             union all 
                                             select distinct department2 from PSProduct) x where department is not null	 ")
        For x = 0 To dt.Rows.Count - 1
            cmbFrom.Items.Add(dt.Rows(x)(0))
            cmbTo.Items.Add(dt.Rows(x)(0))
        Next
    End Sub






    Private Sub txtDocNum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDocNum.KeyDown


        If (e.KeyCode = Keys.Down) Then

            txtDocNum.Text = txtDocNum.Text - 1
            LoadDoc(CInt(txtDocNum.Text))
            e.Handled = True
            txtDocNum.SelectAll()
        End If
        If (e.KeyCode = Keys.Up) Then
            'And CInt(txtDocNum.Text) <= LastInvoiceNumber - 1 Then
            txtDocNum.Text = txtDocNum.Text + 1

            LoadDoc(CInt(txtDocNum.Text))
            e.Handled = True
            txtDocNum.SelectAll()
        End If
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            LoadDoc(CInt(txtDocNum.Text))
            txtDocNum.SelectAll()
            '     SendKeys.Send("{TAB}")
        End If



    End Sub

    Sub LoadDoc(Number)
        If Number = Nothing Then
            Return
        End If
        Dim Order As String = "Product"
        If rdAlphabeticalOrder.Checked Then
            Order = "Product"
        Else
            Order = "ps.id"
        End If

        Dim dt As DataTable = SQLData("select  row_number() over (partition by PS.doc order by PS.DOC) rn,PS.date,PS.type,PS.doc,p.code,p.name+ ' '+p.category+' '+p.company Product,prid,qty,department,department2,ps.id psid,PD.Description,ps.id 
from PSProduct ps join products p on ps.prid=p.id JOIN PSDetail PD ON PS.DOC=PD.DOC AND PS.TYPE=PD.TYPE
where PS.type like 'stock%' and PS.doc=" & Number & " order by " & Order)
        If dt.Rows.Count > 0 Then
            DTP1.Value = dt.Rows(0)("date")
        End If
        DGVStock.DataSource = dt
        If dt.Rows.Count > 0 Then
            txtDescription.Text = dt.Rows(0)("DESCRIPTION")
        Else
            txtDescription.Text = ""
        End If

    End Sub

    Private Sub DGVStock_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVStock.CellDoubleClick
        If e.RowIndex >= 0 Then
            If frmLogin.UserLevel.ToUpper <> "OPERATOR" Then
                ItemsFromGrid(DGVStock.CurrentRow)
            Else
                MsgBox("User Not Allowed")
            End If
        End If
        txtQTY.Select()
        txtQTY.SelectAll()
    End Sub

    Sub ItemsFromGrid(row As DataGridViewRow)
        txtPRID.Text = row.Cells("colCode").Value
        cmbFrom.Text = row.Cells("colFrom").Value
        cmbTo.Text = row.Cells("colTO").Value
        txtProduct.Text = row.Cells("colProduct").Value
        'txtDescription.Text = row.Cells("colDescription").Value
        oldPSID = row.Cells("colPSID").Value
        txtQTY.Text = row.Cells("colQTY").Value
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtDocNum.Text = MainPage.DocNum(DocType)
        oldPSID = 0
        If DGVStock.Rows.Count > 0 Then
            DGVStock.DataSource.clear()
        End If
        txtDocNum.Select()
        txtDocNum.SelectAll()
    End Sub

    Sub Save()
        If oldPSID <> 0 Then

            'SQLData("Update psproduct set doc=" & txtDocNum.Text & ",
            'Date ='" & DTP1.Value.ToString("d") & "',
            'Type ='Stock Transfer',
            'prid = (select id from products where code='" & txtPRID.Text & "'),
            'qty =" & txtQTY.Text & ",
            'department ='" & cmbFrom.Text & "',
            'department2 ='" & cmbTo.Text & "' 
            'where psproduct.id=" & oldPSID & "")
            SQLData("--DELETE FROM STOCK WHERE TYPE='STOCK TRANSFER' AND DOC=" & txtDocNum.Text & " AND ID=" & oldPSID & "
                           DELETE FROM PSPRODUCT WHERE TYPE='STOCK TRANSFER' AND DOC=" & txtDocNum.Text & " AND ID=" & oldPSID & "
                           DELETE FROM PSDETAIL WHERE TYPE='STOCK TRANSFER' AND DOC=" & txtDocNum.Text & "
                              insert into psproduct (doc,date,type,type2,prid,qty,department,department2) 
                              values(" & txtDocNum.Text & ",'" & DTP1.Value.ToString("d") & "','STOCK TRANSFER','',(SELECT ID FROM PRODUCTS WHERE CODE='" & txtPRID.Text & "')," & txtQTY.Text & ",'" & cmbFrom.Text & "','" & cmbTo.Text & "')
                              
                              --INSERT INTO STOCK (DOC,TYPE,DATE,Department,PID,PRID,ProductType,QTY,RATE,AMOUNT,SellingType)                           
                              --VALUES (" & txtDocNum.Text & ",'STOCK TRANSFER IN','" & DTP1.Value.ToString("d") & "','" & cmbTo.Text & "',0,(SELECT ID FROM PRODUCTS WHERE CODE='" & txtPRID.Text & "'),'Ready'," & txtQTY.Text & ",0,0,'')
                              
                              --INSERT INTO STOCK (DOC,TYPE,DATE,Department,PID,PRID,ProductType,QTY,RATE,AMOUNT,SellingType)                           
                              --VALUES (" & txtDocNum.Text & ",'STOCK TRANSFER OUT','" & DTP1.Value.ToString("d") & "','" & cmbFrom.Text & "',0,(SELECT ID FROM PRODUCTS WHERE CODE='" & txtPRID.Text & "'),'Ready'," & txtQTY.Text & "*-1,0,0,'')
                              
                              INSERT INTO PSDETAIL (DOC,DATE,TYPE,Description)
                              VALUES (" & txtDocNum.Text & ",'" & DTP1.Value.ToString("d") & "','STOCK TRANSFER','" & txtDescription.Text & "')
                            ")

            oldPSID = 0
        Else
            SQLData("   insert into psproduct (doc,date,type,type2,prid,qty,department,department2) 
                              values(" & txtDocNum.Text & ",'" & DTP1.Value.ToString("d") & "','STOCK TRANSFER','',(SELECT ID FROM PRODUCTS WHERE CODE='" & txtPRID.Text & "')," & txtQTY.Text & ",'" & cmbFrom.Text & "','" & cmbTo.Text & "')
                              
                              --INSERT INTO STOCK (ID,DOC,TYPE,DATE,Department,PID,PRID,ProductType,QTY,RATE,AMOUNT,SellingType)                           
                              --VALUES (  (SELECT MAX(ID) FROM PSPRODUCT) ," & txtDocNum.Text & ",'STOCK TRANSFER','" & DTP1.Value.ToString("d") & "','" & cmbTo.Text & "',0,(SELECT ID FROM PRODUCTS WHERE CODE='" & txtPRID.Text & "'),'Ready'," & txtQTY.Text & ",0,0,'')
                              
                              --INSERT INTO STOCK (ID,DOC,TYPE,DATE,Department,PID,PRID,ProductType,QTY,RATE,AMOUNT,SellingType)                           
                              --VALUES ( (SELECT MAX(ID) FROM PSPRODUCT)    ," & txtDocNum.Text & ",'STOCK TRANSFER','" & DTP1.Value.ToString() & "','" & cmbFrom.Text & "',0,(SELECT ID FROM PRODUCTS WHERE CODE='" & txtPRID.Text & "'),'Ready'," & txtQTY.Text & "*-1,0,0,'')
                              
                              DELETE FROM PSDETAIL WHERE TYPE='STOCK TRANSFER' AND DOC=" & txtDocNum.Text & "
                              INSERT INTO PSDETAIL (DOC,DATE,TYPE,Description)
                              VALUES (" & txtDocNum.Text & ",'" & DTP1.Value.ToString("d") & "','STOCK TRANSFER','" & txtDescription.Text & "')
                            ")

            If DGVStock.Rows.Count > 0 Then
                DGVStock.FirstDisplayedScrollingRowIndex = DGVStock.Rows.Count - 1
                DGVStock.Rows(DGVStock.Rows.Count - 1).Selected = True
            End If

        End If

    End Sub

    Private Sub txtQTY_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQTY.KeyDown
        If e.KeyCode = Keys.Enter Then
            Save()
            txtPRID.Clear()
            txtProduct.Clear()
            txtQTY.Clear()
            LoadDoc(txtDocNum.Text)
            txtPRID.Select()
        End If
    End Sub

    Private Sub txtPRID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPRID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPRID.Text = "" Then
                ProductSearch.ShowDialog()
                txtPRID.Text = ProductSearch.prIDtxt
                If txtPRID.Text <> "" Then
                    SendKeys.Send("{TAB}")
                End If
            End If
        End If
    End Sub

    Private Sub txtDescription_Leave(sender As Object, e As EventArgs) Handles txtDescription.Leave
        SQLData("Update psdetail set Description='" & txtDescription.Text & "' where type='STOCK TRANSFER' and doc=" & txtDocNum.Text)
    End Sub

    Private Sub btnFrom_Click(sender As Object, e As EventArgs) Handles btnFrom.Click
        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            SQLData("Update psproduct set department='" & cmbFrom.Text & "' where type='stock transfer' and doc=" & txtDocNum.Text)
            SQLData("Update stock set department='" & cmbFrom.Text & "' where type='stock transfer in' and doc=" & txtDocNum.Text)
            LoadDoc(txtDocNum.Text)
        End If
    End Sub

    Private Sub btnTO_Click(sender As Object, e As EventArgs) Handles btnTO.Click
        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            SQLData("Update psproduct set department2='" & cmbTo.Text & "' where type='stock transfer' and doc=" & txtDocNum.Text)
            SQLData("Update stock set department='" & cmbTo.Text & "' where type='stock transfer out' and doc=" & txtDocNum.Text)
            LoadDoc(txtDocNum.Text)
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnAddSupply.Click

        If cmbFrom.Text = "" Or cmbTo.Text = "" Then
            MsgBox("First set 'From' and 'TO' locations")
            cmbFrom.SelectAll()
            cmbFrom.Select()
            Return
        End If
        If frmLogin.UserLevel.ToUpper <> "ADMIN" Then
            Return
        End If
        Dim VN As Integer
        If Val(txtVn.Text) = 0 Then
            Dim dt As DataTable = SQLData("Select isnull(doc,0)+1 Doc where type='stock transfer'")
            VN = dt.Rows(0)("Doc")
            SQLData("UPDATE DOCNUMBER SET DOC=DOC+1
                            INSERT INTO PSDetail (DATE,DOC,TYPE,Description)
                            SELECT CONVERT(DATE,GETDATE())," & VN & ",'STOCK TRANSFER','ADDITIONAL SUPPLY VAN STOCK' 
                            ")
        Else
            VN = Val(txtVn.Text)
        End If
        If frmLogin.UserLevel.ToUpper <> "OPERATOR" Then
            SQLData("insert into PSProduct (date,doc,type,prid,qty,department,department2)

select CONVERT(DATE,GETDATE()) DATE," & VN & " ,'STOCK TRANSFER',Prid,Qty,department,department2
from PSProduct ps join Products p on ps.prid=p.id where department='" & cmbFrom.Text & "' and department2='" & cmbTo.Text & "' and ps.date=
(select top 1 date from PSProduct where department='" & cmbFrom.Text & "' and department2='" & cmbTo.Text & "' order by date desc )
--AND PS.DOC=(select top 1 DOC from PSProduct where department='" & cmbFrom.Text & "' and department2='" & cmbTo.Text & "' order by Doc desc )
order by ps.date desc,Name
")
            LoadDoc(txtDocNum.Text)
            DTP1.Select()

        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure to delete the voucher?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If frmLogin.UserLevel.ToUpper = "ADMIN" And result = DialogResult.Yes Then
            SQLData("DELETE FROM PSDetail WHERE TYPE='STOCK TRANSFER' AND DOC=" & txtDocNum.Text & "
                           DELETE From PSProduct Where Type ='STOCK TRANSFER' AND DOC= " & txtDocNum.Text)
            LoadDoc(MainPage.DocNum("STOCK TRANSFER"))
            txtDocNum.Select()
            txtDocNum.SelectAll()
        End If
    End Sub

    Private Sub DGVStock_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVStock.CellContentClick
        If frmLogin.UserLevel.ToUpper <> "ADMIN" Then
            Return
        End If
        Dim itemNo As Integer = 0
        If e.ColumnIndex = 0 Then
            itemNo = DGVStock.CurrentCell.RowIndex
            'MsgBox(
            'MsgBox(dgvSale.Item("colCODE", e.RowIndex).Value)
            Dim PSID = DGVStock.Item("colPSID", e.RowIndex).Value.ToString
            Dim PSCODE = DGVStock.Item("colCODE", e.RowIndex).Value.ToString
            SQLData("delete from psproduct where type='stock transfer' and doc=" & txtDocNum.Text & " and id=" & PSID)
            LoadDoc(txtDocNum.Text)
            If itemNo > DGVStock.RowCount - 1 Then
                itemNo = itemNo - 1
            End If
            DGVStock.FirstDisplayedScrollingRowIndex = itemNo
            DGVStock.Rows(itemNo).Selected = True
            itemNo = 0
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim Report As New ReportDocument
        Report.Load(settings("Reports Folder") + "Store Transfer Report.rpt")
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In Report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        Report.SetParameterValue("DocNum", txtDocNum.Text)
        Report.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\Additional Supply Stock.pdf")
        txtDocNum.Select()
        txtDocNum.SelectAll()
    End Sub

    Private Sub btnPrint_Click_1(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim Report As New ReportDocument
        Report.Load(settings("Reports Folder") + "Store Transfer Report.rpt")
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In Report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        Report.SetParameterValue("DocNum", txtDocNum.Text)
        Report.PrintToPrinter(1, False, 0, 0)
        SQLData("update products set highlight=0 where exists (select prid from psproduct where type='stock transfer' and doc=" & txtDocNum.Text & " and PsProduct.prid=Products.id)")
        txtDocNum.Select()
        txtDocNum.SelectAll()
    End Sub

    Private Sub DTP1_Leave(sender As Object, e As EventArgs) Handles DTP1.Leave

        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            SQLData("update psproduct set date='" & DTP1.Value.ToString("d") & "' where type='stock transfer' and doc=" & txtDocNum.Text)
            SQLData("update psdetail set date='" & DTP1.Value.ToString("d") & "' where type='stock transfer' and doc=" & txtDocNum.Text)
        End If
    End Sub

    Private Sub DTP1_ValueChanged(sender As Object, e As EventArgs) Handles DTP1.ValueChanged
        If frmLogin.UserLevel.ToUpper <> "ADMIN" Then


        End If
    End Sub

    Private Sub cmbFrom_TextChanged(sender As Object, e As EventArgs) Handles cmbFrom.TextChanged
        Dim SELSTART As Integer = cmbFrom.SelectionStart
        cmbFrom.Text = cmbFrom.Text.ToUpper()
        cmbFrom.SelectionStart = SELSTART
    End Sub

    Private Sub cmbTo_TextChanged(sender As Object, e As EventArgs) Handles cmbTo.TextChanged
        Dim SELSTART As Integer = cmbTo.SelectionStart
        cmbTo.Text = cmbTo.Text.ToUpper()
        cmbTo.SelectionStart = SELSTART
    End Sub

    Private Sub rdAlphabeticalOrder_CheckedChanged(sender As Object, e As EventArgs) Handles rdAlphabeticalOrder.CheckedChanged, rdFeedOrder.CheckedChanged
        LoadDoc(txtDocNum.Text)
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        SQLData("   insert into psproduct (doc,date,type,type2,prid,qty,department,department2) 
                              values( SELECT " & txtDocNum.Text & ",'" & DTP1.Value.ToString("d") & "','STOCK TRANSFER',''
                            ,id PRID,STOCK,'" & cmbFrom.Text & "','" & cmbTo.Text & "' FROM (
			                        select ID ,ISNULL((select sum(case    
                                                                    when (type in ('PURCHASE','SALE RETURN')) or (TYPE='STOCK TRANSFER' AND department2 like'" & cmbFrom.Text & "%') THEN isnull(QTY+isnull(schpc,0),0) 
                            				                        WHEN (type in ('SALE','PURCHASE RETURN')) or (TYPE='STOCK TRANSFER' AND department like '" & cmbFrom.Text & "%') THEN isnull((QTY+isnull(schpc,0))*-1 ,0)
                                                    			   END) FROM PSPRODUCT ps
			WHERE PRID=P.ID AND DATE>=isnull(StockDate,'2021-1-1') and date<='" & DTP1.Value.ToString("d") & "' and isnull(isclaim,0)=0 and (department like 'karvan%' or department2 like '" & cmbFrom.Text & "%')
			),0) STOCK
			from Products P 
			where Company like '%' and category like '%'  and name like '%') 
			X WHERE X.STOCK<>0)")

    End Sub
End Class
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Google.Apis.Requests

Public Class frmEstimate
    Dim InvoiceNumber As String = ""
    Sub StockQty()
        If txtPRID.Text = "" Or chkStock.Checked = False Then
            txtStock.Text = ""
            Return
        End If
        Dim ItemCode As String = ProductSearch.prIDtxt
        Dim StDate As String = dtpDate.Value.ToString("d")
        Dim clm As Integer = 0
        If ChkClaim.Checked Then
            clm = 1
        Else
            clm = 0
        End If
        Dim dt As DataTable = SQLData("select isnull(sum(case when type in ('purchase','sale return') then qty+isnull(schpc,0) when type in ('sale','purchase return') then (qty+isnull(schpc,0))*-1 end),0) StockQty from PSProduct where prid=(select id from products where code='" & ItemCode & "') and isclaim=" & clm & "  and date>=(select stockdate from Products where code='" & ItemCode & "') and date<=dateadd(d,0,'" & StDate & "')")
        Dim Qty As Integer = dt.Rows(0)(0)
        txtStock.Text = Qty
    End Sub
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCustomerID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCustomerID.Text <> "" Then
                SendKeys.Send("{tab}")
            Else
                e.Handled = True
                frmPartySearch.ShowDialog()
                txtCustomerID.Text = frmPartySearch.acID
                txtCustomerName.Text = frmPartySearch.CusName
                txtOCell.Text = frmPartySearch.CustomerMobile
                txtRoute.Text = frmPartySearch.CustomerRoute
                Me.Text += " - " + txtCustomerName.Text
                If txtRoute.Text.Contains("KR") Or txtRoute.Text.Contains("SR") Then
                    txtGoods.Text = "SUPPLY VAN"
                ElseIf txtRoute.Text.ToUpper.Contains("BOOKING") Then
                    txtGoods.Text = "BILTY"
                Else
                    txtGoods.Text = "COUNTER"
                End If
                If cmbSPO.Text = "" Then
                    cmbSPO.Select()
                ElseIf cmbLoc.Text = "" Then
                    cmbLoc.Select()
                Else
                    txtPRID.Select()
                End If
            End If
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPRID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPRID.Text = "" Then
                e.Handled = True
                txtRate.Text = ""
                MainPage.CustID = txtCustomerID.Text
                ProductSearch.ShowDialog()
                'MsgBox(PS.PrID)
                txtPRID.Text = ProductSearch.prIDtxt
                txtProductName.Text = ProductSearch.prName
                txtUOM.Text = ProductSearch.prSize
                txtRate.Text = ProductSearch.PrRate
                If txtPriceList.Text.Trim = "" Then
                    txtPriceList.Text = "A"
                End If
                If txtPRID.Text <> "" Then
                    SendKeys.Send("{TAB}")
                End If
            End If
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtOQty_TextChanged(sender As Object, e As EventArgs) Handles txtOQty.TextChanged
        If txtProductName.Text.ToUpper.Contains("PUBLICITY") Then
            If Val(txtTotalQty.Text) > 0 And Val(txtTotalQty.Text) < 5 Then
                txtDisc1.Text = 0
                txtDisc2.Text = 100
            Else
                txtDisc1.Text = 0
                txtDisc2.Text = 0
            End If
        End If


        txtBQty.Text = txtOQty.Text
        txtAQty.Text = txtOQty.Text
        Scheme()
        ItemTotalCalculations()

    End Sub

    Private Sub txtBillQty_TextChanged(sender As Object, e As EventArgs) Handles txtBQty.TextChanged

        Scheme()
        ItemTotalCalculations()
    End Sub

    Sub LocStock()
        Dim dt As DataTable = SQLData("-- Select the original row
select StoragePoint,--type,doc,
sum(qty) 
Qty from (
SELECT date,prid,
--type,doc,
department StoragePoint, case when type in ('sale','stock transfer')  then (qty+isnull(ps.SchPc,0))*-1 when type='purchase' then (qty+isnull(ps.SchPc,0)) else 0 end qty
FROM psproduct ps join Products p on ps.prid=p.id
where prid=(select id from products where code='" & txtPRID.Text & "') and isnull(isclaim,0)=0 and ps.date>=isnull(p.StockDate,'2021-1-1') and ps.date<=getdate()--and type='stock transfer'
--order by type
UNION ALL

-- Select an additional row if department2 is not NULL
SELECT date,prid,
--type,doc,
department2 AS StoragePoint, qty 
FROM psproduct ps join Products p on ps.prid=p.id
WHERE department2 IS NOT NULL and prid=(select id from products where code='" & txtPRID.Text & "') and isnull(isclaim,0)=0 and ps.date>=isnull(p.StockDate,'2021-1-1') and ps.date<=getdate()
) x  --and type='stock transfer' 
group by StoragePoint--,type,doc
--order by type,Doc")
        If dt.Rows.Count > 0 Then
            dgvLocStock.DataSource = dt
        Else
            If dgvLocStock.RowCount > 0 Then
                dgvLocStock.DataSource.clear()
            End If

        End If

    End Sub

    Private Sub txtPRID_Leave(sender As Object, e As EventArgs) Handles txtPRID.Leave
        Dim PSPRID As String = ProductSearch.ProductID

        If txtPRID.Text = Nothing Then
            Return
        End If
        ' Option B - parse safely and use numeric PSPRID
        ' Safely obtain numeric product id
        Dim parsedPSPRID As Integer = 0
        If Not Integer.TryParse(ProductSearch.ProductID, parsedPSPRID) Then
            ' ProductSearch.ProductID empty or non-numeric -> lookup by code
            Dim dtpsprid As DataTable = SQLData("select id from products where code='" & txtPRID.Text & "'")


            If dtpsprid Is Nothing OrElse dtpsprid.Rows.Count = 0 Then
                ' No product found: set defaults, log and return
                ' (avoid throwing; show message or clear fields)
                txtPRID.BackColor = Color.LightSalmon
                ' TODO: log the failing SQL and values for debugging
                Return
            End If
            Integer.TryParse(dtpsprid.Rows(0)(0).ToString(), parsedPSPRID)
        End If
        ' Use parsedPSPRID (integer) for subsequent numeric comparisons/queries


        ' use parsedPSPRID for numeric comparisons and SQL where numeric id is expected

        txtPRID.BackColor = Color.White
        Dim dt As DataTable
        If txtCustomerID.Text <> "" Then
            dt = SQLData("Select isnull(discount,0) Disc2, isnull(disc1p,0) Disc1, isnull(PriceList,'A') PriceList from PartyDiscount where acid=" & txtCustomerID.Text & " and company=(select company from Products where id='" & PSPRID & "')")

            If dt.Rows.Count > 0 Then
                txtDisc1.Text = dt.Rows(0)("Disc1")
                txtDisc2.Text = dt.Rows(0)("Disc2")
                txtPriceList.Text = dt.Rows(0)("PriceList")
            Else
                txtDisc1.Text = 0
                txtDisc2.Text = 0
                txtPriceList.Text = "A"

            End If
            Dim dt2 As DataTable = SQLData("select company from products where id='" & PSPRID & "'")
            If dt2.Rows.Count > 0 Then
                If dt2.Rows(0)("Company").ToString = "PUBLICITY" Then
                    txtDisc1.Text = 0
                    txtDisc2.Text = 100

                End If
            End If
        Else
            txtDisc1.Text = 0
            txtDisc2.Text = 0
            txtPriceList.Text = "A"
        End If



        Dim SchQty As DataTable = SQLData("select top 1 isnull(schon,0) SchOn,isnull(SchPcs,0) SchPc from SchQTYSlabs where prid=(select id from Products where ID='" & PSPRID & "') order by schon")
        If SchQty.Rows.Count > 0 Then
            txtSchPcs.Text = SchQty.Rows(0)("SchPc")
            txtSchOn.Text = SchQty.Rows(0)("SchOn")
        Else
            txtSchOn.Text = 0
            txtSchPcs.Text = 0
        End If

        If chkHistory.Checked Then
            If txtPRID.Text <> "" And txtCustomerID.Text <> "" Then
                SaleHistory(txtCustomerID.Text, txtPRID.Text, dtpDate.Value.ToString("d"))

            Else
                dgvSaleHistory.Rows.Clear()
            End If
        End If
        ProductQtyScheme(PSPRID)
        If chkStock.Checked Then
            StockQty()
        End If
        LocStock()

    End Sub

    Sub ProductQtyScheme(prID)
        If prID = "" Then
            Return
        End If
        '        Dim dt As DataTable = SQLData("select Schon,SchPcs,round(SaleRate*SchOn/CASE WHEN SCHON=0 OR SCHON IS NULL THEN 1 ELSE  (Schon+SchPcs) END,2) NetRate from (
        'Select Case isnull(SchOn,0) SchOn,isnull(SchPcs,0) SchPcs,(select SaleRate from Products where id='" & prID & "') SaleRate from SchQTYSlabs where prid='" & prID & "' ) x order by schon")

        Dim DT As DataTable = SQLData("select date,Schon,SchPcs,SaleRate,CASE WHEN SCHON=0 OR SCHON IS NULL THEN X.SaleRate ELSE round(SaleRate*SchOn/ (Schon+SchPcs) ,2) END NetRate from (
select date,isnull(SchOn,0) SchOn,isnull(SchPcs,0) SchPcs,Rate SaleRate from SchQTYSlabs where prid=" & prID & " and date<='" & dtpDate.Value.ToString("d") & "' ) x order by schon, date desc")



        If DT.Rows.Count > 0 Then
            If chkScheme.Checked Then
                dgvScheme.DataSource = DT
            Else
                dgvScheme.DataSource.CLEAR()
            End If

        Else
            If dgvScheme.Rows.Count > 0 Then
                dgvScheme.DataSource.clear()
            End If
        End If
    End Sub

    Sub ItemTotalCalculations()
        Dim BQ As Double = 0
        Dim Rt As Double = 0
        If txtBQty.Text <> Nothing Then
            BQ = Val(txtBQty.Text)
        End If
        If txtRate.Text <> Nothing Then
            Rt = Val(txtRate.Text)
        End If
        Dim Gross As Double = BQ * Rt 'txtBQty.Text * txtRate.Text
        Dim d2 As Double = Val(txtDisc2.Text)
        Dim Discounted2 As Double = Gross * ((100 - d2) / 100)
        Dim d1 As Double = Val(txtDisc1.Text)
        Dim totalDiscounted As Double = Math.Round(Discounted2 * ((100 - d1) / 100), 0)
        txtItemTotal.Text = totalDiscounted.ToString()
        If Val(txtTotalQty.Text) > 0 And Val(txtItemTotal.Text) > 0 Then
            txtNetRate.Text = Math.Round(CStr(txtItemTotal.Text) / CStr(txtTotalQty.Text), 2)
        Else
            txtNetRate.Text = txtRate.Text
        End If
    End Sub

    Sub Scheme()
        Dim oqty As Integer = Math.Abs(Val(txtBQty.Text))
        'If txtOQty.Text <> "" Then
        '    oqty = txtOQty.Text
        'End If

        'Dim dt2 As DataTable = SQLData("select top 1 isnull(schon,0) SchOn,isnull(SchPcs,0) SchPc,isnull(List,'A') SaleList,isnull(Rate,0) SaleRate from SchQTYSlabs where 
        '                                    prid=(select id from Products where code='" & txtPRID.Text & "') and schon<=" & oqty & "
        '                                    order by SchOn desc")

        Dim dt As DataTable = SQLData("select top 1 isnull(schon,0) SchOn,isnull(SchPcs,0) SchPc,isnull(List,'A') SaleList,isnull(Rate,0) SaleRate from SchQTYSlabs where 
                                            prid=(select id from Products where code='" & txtPRID.Text & "') and schon<=" & oqty & " and date<='" & dtpDate.Value.ToString("d") & "'
                                            order by date desc,SchOn desc")


        If dt.Rows.Count > 0 Then
            txtSchOn.Text = dt.Rows(0)("SchOn")
            txtSchPcs.Text = dt.Rows(0)("SchPc")
            txtPriceList.Text = dt.Rows(0)("SaleList")
            If Val(dt.Rows(0)("SaleRate")) <> 0 Then
                txtRate.Text = dt.Rows(0)("SaleRate")
            End If

        Else
            txtSchOn.Text = 0
            txtSchPcs.Text = 0
            txtRate.Text = ProductSearch.PrRate
        End If
        QtyScheme()
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles ChkClaim.CheckedChanged
        If ChkClaim.Checked = True Then
            gbItems.BackColor = Color.Red
        Else
            gbItems.BackColor = Color.Transparent
        End If
        If txtPRID.Text = Nothing Then
            txtPRID.SelectAll()
            txtPRID.Select()
        Else
            txtOQty.SelectAll()
            txtOQty.Select()
        End If
    End Sub

    Sub QtyScheme()
        txtFOC.Text = 0
        If chkScheme.Checked = False Then
            txtFOC.Text = 0
            txtTotalQty.Text = txtBQty.Text
        Else
            If Val(txtSchPcs.Text) > 0 Then
                If Val(txtBQty.Text) <> 0 Then
                    Dim SOn As Integer = txtSchOn.Text
                    Dim BQ As Integer = Math.Abs(Val(txtBQty.Text))
                    Dim NumberOfSchemes As Integer = BQ \ SOn
                    If NumberOfSchemes < 1 Then
                        txtFOC.Text = 0
                    End If
                    txtFOC.Text = NumberOfSchemes * txtSchPcs.Text
                Else
                    txtFOC.Text = 0
                End If
                If Val(txtBQty.Text) > 0 Then
                    txtTotalQty.Text = Val(txtBQty.Text) + Val(txtFOC.Text)
                ElseIf Val(txtBQty.Text) < 0 Then
                    txtTotalQty.Text = (Math.Abs(Val(txtBQty.Text)) + Val(txtFOC.Text)) * -1
                End If
            Else
                txtTotalQty.Text = txtOQty.Text
            End If
        End If
    End Sub

    Private Sub txtBQty_TextChanged(sender As Object, e As EventArgs) Handles txtBQty.TextChanged, txtRate.TextChanged
        '        QtyScheme()
        ItemTotalCalculations()

    End Sub
    Private Sub txtOQty_Enter(sender As Object, e As EventArgs) Handles txtOQty.Enter
        If txtProductName.Text = "" Then
            txtPRID.Select()
            Return
        End If
        txtOQty.BackColor = Color.DeepSkyBlue
        txtOQty.SelectAll()

    End Sub
    Private Sub txtBQty_Enter(sender As Object, e As EventArgs) Handles txtBQty.Enter
        txtBQty.BackColor = Color.DeepSkyBlue
        txtBQty.SelectAll()

    End Sub

    Sub ItemAdd()
        ' Check all TextBoxes in gbItems for empty values
        For Each ctrl As Control In gbItems.Controls
            If TypeOf ctrl Is TextBox AndAlso String.IsNullOrWhiteSpace(CType(ctrl, TextBox).Text) Then
                MsgBox("Please fill all required fields.", MsgBoxStyle.Exclamation, "Incomplete Data")
                ctrl.Select()
                Return
            End If
        Next

        Dim ISSCHEME As Integer = 0
        Dim ISCLAIM As Integer = 0
        If chkScheme.Checked = True Then
            ISSCHEME = 1
        Else
            ISSCHEME = 0
        End If
        If ChkClaim.Checked Then
            ISCLAIM = 1
        Else
            ISCLAIM = 0
        End If
        'If txtPRID.Text = "" Or txtOQty.Text = "" Or txtBQty.Text = "" Or txtRate.Text = "" Then
        '    MsgBox("Please enter all the required fields", MsgBoxStyle.Exclamation, "Incomplete Data")
        '    Return
        'End If
        dgvSale.Rows.Add(dgvSale.Rows.Count + 1, ISSCHEME, ISCLAIM, cmbSPO.Text, ProductSearch.prIDtxt, txtProductName.Text, txtOQty.Text, txtAQty.Text, txtBQty.Text, txtFOC.Text, txtRate.Text, txtDisc1.Text, txtDisc2.Text, txtItemTotal.Text, cmbLoc.Text, ProductSearch.ProductID)
        ProductSearch.prIDtxt = ""
        ProductSearch.ProductID = ""
        EstimateTotal()
        dgvSale.FirstDisplayedScrollingRowIndex = dgvSale.RowCount - 1
        dgvSale.Rows(dgvSale.RowCount - 1).Selected = True
        ClearTextBox(gbItems)
        txtPRID.Select()

    End Sub

    Sub FocusItems()
        If txtCustomerID.Text = "" Then
            Return
        End If
        Dim Focus As String = cmbFocusItems.Text
        Dim ConditionalQuery As String = ""
        If Focus = "Focus Items" Then
            dgvFocusItem.Columns("FOCUSDOC").HeaderText = "Bill #"
            ConditionalQuery = "WITH CTE AS (
            SELECT DATE,Doc,PRID,P.NAME+' '+p.Category+' '+P.Company Product,QTY2,QTY,Rate, ROW_NUMBER() OVER (PARTITION BY PRID ORDER BY PRID,DATE DESC) AS RN 
            FROM PSProduct PS JOIN Products P ON PS.PRID=P.ID
            WHERE ACID=" & txtCustomerID.Text & " AND PRID IN (SELECT ID FROM PRODUCTS WHERE FOCUSITEMS='TRUE'  ) and qty>0 AND QTY2 IS NOT NULL
            GROUP BY PRID,doc,DATE,QTY2,QTY,RATE,p.name,p.category,p.Company
            --ORDER BY PRID,DATE DESC
            )
            SELECT * FROM CTE WHERE RN=1 --ORDER BY Date
            UNION 
            SELECT '2001-1-1' Date,0 Doc,ID,NAME+ ' '+CATEGORY+' '+COMPANY PRODUCT,0 QTY2,0 QTY,SALERATE,2 RN
	        FROM Products WHERE FOCUSITEMS='TRUE' AND ID NOT IN (SELECT PRID FROM PSProduct WHERE ACID=" & txtCustomerID.Text & ")
	        ORDER BY RN,DATE"
        ElseIf Focus = "FIT Items" Then
            dgvFocusItem.Columns("FOCUSDOC").HeaderText = "Days"
            ConditionalQuery = "select LastOrderDate DATE,datediff(d,LastOrderDate,getdate()) DOC,ID PRID,NAME+' '+CATEGORY+' '+COMPANY Product--,LastOrderDate--,case when format(LastOrderDate,'dd-MMM-yyyy')='01-jan-1900' then 'No Order' else format(LastOrderDate,'dd-MMM-yyyy') end  LODate
            --,itemstatus,
	        ,isnull((SELECT sum(qty2) FROM PsProduct WHERE PRID=x.ID AND ACID=" & txtCustomerID.Text & " and date=LastOrderDate),0) QTY2
	        ,isnull((SELECT sum(qty) FROM PsProduct WHERE PRID=x.ID AND ACID=" & txtCustomerID.Text & " and date=LastOrderDate),0) QTY
	        , 0 RATE
	        ,0 RN
	        from  (
		        SELECT ID,CODE,NAME,Category,Company,UrduName,
		        isnull((SELECT MAX(DATE) FROM PsProduct WHERE PRID=P.ID AND ACID=" & txtCustomerID.Text & " AND (QTY2>0 or qty>0) and type='sale'),'') LastOrderDate,
		        --isnull((SELECT MAX(DATE) FROM PsProduct WHERE PRID=P.ID and qty>0 and type='sale'),'') ItemStatus
		        isnull((SELECT count(DATE) FROM PsProduct WHERE PRID=P.ID and qty>0 and type='sale' and date>'2024-1-1'),'') ItemStatus
                FROM Products P where company like 'fit-o%' and status<>'short' ) x where ItemStatus>30 --'2024-6-1'
                and +getdate()-LastOrderDate>30
                order by ItemStatus desc--,LastOrderDate;"
        End If
        Dim dt As DataTable = SQLData(ConditionalQuery)
        If dt.Rows.Count > 0 Then
            dgvFocusItem.DataSource = dt
        Else
            If dgvFocusItem.DataSource IsNot Nothing Then
                dgvFocusItem.DataSource = Nothing
            End If
        End If


    End Sub


    Private Sub txtOQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOQty.KeyDown, txtBQty.KeyDown, txtRate.KeyDown, txtDisc1.KeyDown, txtDisc2.KeyDown, txtAQty.KeyDown
        If e.KeyCode = Keys.Enter And Val(txtOQty.Text) <> 0 Then
            e.Handled = True
            ItemAdd()
        End If

    End Sub

    Sub EstimateTotal()
        Dim TotalAmount As Integer = 0
        For n = 0 To dgvSale.Rows.Count - 1
            TotalAmount += dgvSale.Rows(n).Cells("ColAmount").Value

        Next
        Dim EstAmt As Integer = 0
        Dim dt As DataTable
        If txtInvoiceNumber.Text <> Nothing Then
            dt = SQLData("select sum(vist) from psproduct where type='sale' and doc=" & txtInvoiceNumber.Text)
            If dt.Rows.Count > 0 Then
                EstAmt = dt.Rows(0)(0)
            End If
        End If
        txtEstimateTotal.Text = TotalAmount.ToString()
        txtFreight.Text = Form3.Freightcalculations(dtpDate.Value.ToString("d"), EstAmt + txtEstimateTotal.Text, txtRoute.Text, txtCustomerName.Text, txtGoods.Text, txtCustomerID.Text)
        txtEstimateTotal.Text = (Val(txtEstimateTotal.Text) + Math.Abs(Val(txtFreight.Text))).ToString("N")
    End Sub

    Sub ClearTextBox(ByVal root As Control)
        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl
        txtOCell.Text = ""
        If dgvScheme.Rows.Count > 0 Then
            dgvScheme.DataSource.clear()
        End If

        'txtEstimateTotal.Text = ""
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        dgvSale.Rows.Remove(dgvSale.CurrentRow)
    End Sub
    Sub SavePsproduct(InvNo)
        Dim VestAmount As Double = 0
        Dim SPO As String = ""
        Dim Location As String = ""
        Dim OrderQty As Double = 0
        Dim BillQty As Double = 0
        Dim SchPCs As Integer = 0
        Dim CustomerID As String = txtCustomerID.Text
        Dim IsScheme As Integer = 0
        Dim IsClaim As Integer = 0
        Dim ItemCode As String = ""
        Dim ProductID As Integer = 0
        Dim Rate As Double = 0
        Dim SearchDate As Date = dtpDate.Value.ToString
        Dim Cost As String = 0
        Dim Dis1 As Double = 0
        Dim dis2 As Double = 0
        Dim VistAmount As Double = 0
        Dim Dis1Amount As Double = 0
        Dim Dis2Amount As Double = 0
        Dim AmountAfterDis2 As Double = 0
        Dim NetAmount As Double = 0
        Dim AQty As Double = 0
        Dim TallyBy As String = ""
        Dim PackingDateTime As String = ""
        Dim ConditionalValues As String = ""
        Dim ConditionalFields As String = ""
        For n = 0 To dgvSale.Rows.Count - 1
            ItemCode = dgvSale.Item("colCode", n).Value.ToString
            SPO = dgvSale.Item("colSPO", n).Value
            IsScheme = dgvSale.Item("colIsScheme", n).Value
            IsClaim = dgvSale.Item("colClaim", n).Value
            Location = dgvSale.Item("colLocation", n).Value
            OrderQty = dgvSale.Item("colOQty", n).Value
            AQty = dgvSale.Item("colAQty", n).Value
            BillQty = dgvSale.Item("colBQty", n).Value
            SchPCs = dgvSale.Item("colFOC", n).Value
            Rate = dgvSale.Item("colRate", n).Value
            ProductID = dgvSale.Item("colProductID", n).Value
            VestAmount = BillQty * Rate
            Dis1 = dgvSale.Item("colDis1", n).Value
            dis2 = dgvSale.Item("colDis2", n).Value
            If Val(BillQty) = 0 Then
                TallyBy = frmLogin.UserName.ToUpper
                PackingDateTime = DateTime.Now.ToString()
                ConditionalFields = ",TallyBy, PackingDateTime"
                ConditionalValues = $", '{frmLogin.UserName}', '{DateTime.Now}' "
            Else
                ConditionalFields = ""
                ConditionalValues = ""
            End If

            AmountAfterDis2 = (VestAmount * (100 - dis2) / 100)
            NetAmount = (AmountAfterDis2 * (100 - Dis1) / 100)
            Dis2Amount = VestAmount * (dis2 / 100)
            Dis1Amount = AmountAfterDis2 * (Dis1 / 100)
            VistAmount = dgvSale.Item("colAmount", n).Value
            VistAmount = Math.Round(VistAmount, 0)
            Dim NetRate As Double = VistAmount / (BillQty + SchPCs)

            Dim dt As DataTable = SQLData("select isnull(  (select (CASE WHEN QTY=0 THEN 0 ELSE amt/qty END ) Cost from (select ISNULL(sum(vist),0)*((100-avg(extradiscountp))/100) amt,ISNULL(sum(qty),0)+ISNULL(sum(SchPc),0) qty,avg(pd.ExtraDiscountP) ExDisc from PSProduct p join PSDetail pd on p.doc=pd.doc and p.type=pd.type where p.type='purchase' and prid=(select id from products where code='" & ItemCode & "') and p.date=(select max(date) from PSProduct ps where ps.prid=(select id from products where code='" & ItemCode & "') and date<='" & SearchDate & "' and type='purchase') ) x),0) Cost from Products where code='" & ItemCode & "'")
            Cost = dt.Rows(0)("cost")
            Dim Profit As Double = (NetRate - Cost) * (BillQty + SchPCs)
            Profit = Math.Round(Profit, 2)
            If Double.IsNaN(Profit) Or Cost = 0 Then
                Profit = 0
            End If
            'PsProduct
            'SQLData("if (select count(*) from DocNumber where type='psid')=1 
            '                   update docnumber set doc=doc+1 where type='psid'
            '             else 
            '                 insert into docnumber (type,doc) values ('psid',(select max(id) from psproduct))")
            Dim sqlchk As DataTable = SQLData("insert into psproduct 
                         (date,SellingType,SPO,department,type,type2,packet,sch,doc,acid,prid,qty2,AQTY,qty,schpc,rate,vest,discp,discount,discp2,discount2,vist,isclaim,profit,estimate" & ConditionalFields & ")
                         values ('" & dtpDate.Value.ToString("d") & "','DEFAULT','" & SPO & "','" & Location & "','SALE','OUT',0," & IsScheme & "," & InvNo.ToString & ", " & CustomerID & "," & ProductID & ", " & OrderQty & "," & AQty & "," & BillQty & "," & SchPCs & ", " & Rate & ", " & VestAmount & "," & Dis1 & ", " & Dis1Amount & "," & dis2 & ", " & Dis2Amount & ", " & NetAmount & ", " & IsClaim & ", " & Profit & ", " & NetAmount & ConditionalValues & ")
                         ")
            If sqlchk Is Nothing Then
                MsgBox("Error in saving PS Product details.", MsgBoxStyle.Critical, "Database Error")
                btnPost.Enabled = True
            End If
            If ChkClaim.Checked = False Then
                SQLData("update products set StockQty=isnull(StockQty,0)-" & BillQty & " where code='" & ItemCode & "'")
            ElseIf ChkClaim.Checked = True Then
                SQLData("update products set ClaimStock=isnull(ClaimStock,0)-" & BillQty & " where code='" & ItemCode & "'")
            End If

            'PsProductHistory
            SQLData("insert into psproductHistory
                         (date,SellingType,SPO,department,type,type2,packet,sch,doc,acid,prid,qty2,qty,schpc,rate,vest,discp,discount,discp2,discount2,vist,isclaim,profit,UserName,UserLevel,EntryDate,EntryStatus)
                         values ('" & dtpDate.Value.ToString("d") & "','DEFAULT','" & SPO & "','" & Location & "','SALE','EST',0," & IsScheme & "," & InvNo.ToString & ", " & CustomerID & "," & ProductID & ", " & OrderQty & "," & BillQty & "," & SchPCs & ", " & Rate & ", " & VestAmount & "," & Dis1 & ", " & Dis1Amount & "," & dis2 & ", " & Dis2Amount & ", " & NetAmount & ", " & IsClaim & ", " & Profit & ",'" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "','SAVE')
                         ")

            '            SQLData("insert into psproductHistory (id,date,doc,Type,Type2,Prid,ACID,qty2,QTY,RATE,VEST,DISCP,DISCOUNT,DISCP2,DISCOUNT2,ESTIMATE,VIST,SellingType,SchPc,Sch,Department,Profit,isClaim,SPO,UserName,UserLevel,EntryDate,EntryStatus) 
            '                                    values( (select max(id)+1 from psproduct),'" & dtpDate.Value.ToString("d") & "'," & InvNo.ToString & ",'Sale','Out',( select id from products where code='" & txtPRID.Text & "' )," & Val(txtCustomerID.Text) & ", " & Val(txtOQty.Text) & " ,  " & BillQty & ", " & Val(txtRate.Text) & ", " & VestAmount & " ," & Dis1 & "  ,  " & Dis1Amount & ", " & dis2 & ", " & Dis2Amount & "," & NetAmount & " ," & NetAmount & ",'DEFAULT', " & Val(txtSchPcs.Text) & "," & IsScheme & " , '" & Location & "'," & Profit & "," & IsClaim & ",'" & SPO & ",'" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "','SAVE')")

        Next
    End Sub

    Sub SavePsDetailsLedger(InvNo, PreviousBalance)
        Dim GrossProfit As Integer = 0
        Dim NetBillAmount As Integer = 0
        Dim CashRecd As Integer = 0
        Dim Narr As String = txtRefference.Text
        Dim DueDate As Date = dtpDate.Value.AddDays(7).ToString("d")
        Dim dt As DataTable = SQLData("select ROUND(isnull(sum(Profit),0),0) Profit, ROUND(isnull(sum(vist),0),0) NetBillAmount from psproduct where type='sale' and doc=" & InvNo)
        NetBillAmount = dt.Rows(0)("NetBillAmount")
        NetBillAmount = Math.Round(Val(NetBillAmount) + Math.Abs(Val(txtFreight.Text)), 0)
        If chkCash.Checked And dtpDate.Value.ToString("d") = Date.Today Then
            CashRecd = 0
            Narr = "COUNTER BILL, " + frmLogin.UserName + " , " + Date.Now.ToString("t")
        Else
            CashRecd = 0

        End If
        GrossProfit = dt.Rows(0)("Profit")
        Dim EstimateStatus As String = "ESTIMATE"
        'If txtRefference.Text <> "ESTIMATE" Or chkCash.Checked Then
        '    EstimateStatus = "INVOICE"
        'End If
        'PsDetail
        SQLData(" insert into psdetail (doc,date,type,acid,description,extradiscountp,extradiscount,freight,received,amount,duedate,pbalance,term,vehicle,salesman,goods,builty,BUILTYPATH,creditdays,pricelist,grossprofit,status,remarks)
                       values (" & InvNo & ", '" & dtpDate.Value.ToString("d") & "','SALE'," & txtCustomerID.Text & ",'" & Narr & "',0,0," & Val(txtFreight.Text) & "," & CashRecd & "," & NetBillAmount & ",'" & DueDate & "'," & PreviousBalance & ",'CREDIT','','','" & txtGoods.Text & "','','',7,''," & GrossProfit & ", '" & EstimateStatus & "',N'" & txtRemarks.Text & "')
                    ")
        'PsDetailHistory
        SQLData(" insert into psdetailHistory (doc,date,type,acid,description,extradiscountp,extradiscount,freight,received,amount,duedate,pbalance,term,vehicle,salesman,goods,builty,BUILTYPATH,creditdays,pricelist,grossprofit,remarks,UserName,UserLevel,EntryDate,EntryStatus)
                       values (" & InvNo & ", '" & dtpDate.Value.ToString("d") & "','SALE'," & txtCustomerID.Text & ",'" & Narr & "',0,0," & Val(txtFreight.Text) & "," & CashRecd & "," & NetBillAmount & ",'" & DueDate & "'," & PreviousBalance & ",'CREDIT','','','" & txtGoods.Text & "','','',7,''," & GrossProfit & ",N'" & txtRemarks.Text & "','" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "','SAVE')
                    ")

        'Ledgers
        SQLData("insert into ledgers (acid,date,doc,type,narration,invoice,debit,remainingamount,status,EntryBy,EntryDateTime)
                      values (" & txtCustomerID.Text & ",'" & dtpDate.Value.ToString("d") & "'," & InvNo & ",
                      'sale','" & Narr & "'," & InvNo & "," & NetBillAmount & "," & NetBillAmount & ",0, '" & frmLogin.UserName & "','" & Now & "' )
                      ")

        SQLData("insert into ledgers (acid,date,doc,type,narration,invoice,CREDIT,remainingamount)
                      values (4,'" & dtpDate.Value.ToString("d") & "'," & InvNo & ",
                      'sale','" & Narr & "'," & InvNo & "," & NetBillAmount + Val(txtFreight.Text) & ",0 )
                       ")


        If CashRecd <> 0 Then
            SQLData("insert into ledgers (acid,date,doc,type,narration,invoice,Credit,remainingamount,status)
                      values (" & txtCustomerID.Text & ",'" & dtpDate.Value.ToString("d") & "'," & InvNo & ",
                      'sale','Cash Sales '+'" & Narr & "'," & InvNo & "," & NetBillAmount & "," & NetBillAmount & ",0 )
                      ")
            SQLData("insert into ledgers (acid,date,doc,type,narration,invoice,Debit,remainingamount)
                      values (1,'" & dtpDate.Value.ToString("d") & "'," & InvNo & ",
                      'sale','" & Narr & "'," & InvNo & "," & NetBillAmount + Val(txtFreight.Text) & ",0 )
                       ")
        End If

        If Val(txtFreight.Text) <> 0 Then
            SQLData("insert into ledgers (acid,date,doc,type,narration,invoice,CREDIT,remainingamount)
                      values (7,'" & dtpDate.Value.ToString("d") & "'," & InvNo & ",
                      'sale','" & Narr & "'," & InvNo & "," & Val(txtFreight.Text) & ",0 )
                       ")
        End If

        'LedgersHistory
        SQLData("insert into ledgersHistory (acid,date,doc,type,narration,invoice,debit,remainingamount,status,UserName,UserLevel,EntryDate,EntryStatus)
                      values (" & txtCustomerID.Text & ",'" & dtpDate.Value.ToString("d") & "'," & InvNo & ",
                      'sale','" & Narr & "'," & InvNo & "," & NetBillAmount & "," & NetBillAmount & ",0,'" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "','SAVE' )
                      ")
        If EstimateStatus = "INVOICE" Then
            Dim report As New ReportDocument
            Dim FileName As String = Settings("Reports Folder") + "rptInvoice3A5WithRuns.rpt"
            report.Load(FileName)
            For Each tb As Table In report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            report.SetParameterValue("DocNumber", InvNo)
            report.SetParameterValue("Recpt", 0)
            report.SetParameterValue("PreBalance", 0)
            report.SetParameterValue("companyName", "")

            Dim ExportFileName As String = Settings("Temp Folder") + " Invoice # " & InvNo & ", " & txtCustomerName.Text & " " & Date.Now.ToString("dd-MMM-yy hh.mm.ss tt") & ".PDF"
            report.ExportToDisk(ExportFormatType.PortableDocFormat, ExportFileName)

        End If


    End Sub
    Private Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        btnPost.Enabled = False
        Dim PreviousBalnace As Integer = 0
        Dim dtBalance As DataTable = SQLData("select isnull(sum(isnull(debit,0))-sum(isnull(credit,0)),0) Balance from Ledgers where acid=" & txtCustomerID.Text)
        If dtBalance.Rows.Count > 0 Then
            PreviousBalnace = dtBalance.Rows(0)("Balance")
        End If
        'Dim dtPSID As DataTable = SQLData("Select isnull(doc,0)+1 PSID from DocNumber where type='PsID'")
        'Dim PSID As Integer = dtPSID.Rows(0)("PSID")

        'Dim dtLgID As DataTable = SQLData("Select isnull(doc,0)+1 LgID from DocNumber where type='LdgrID'")
        'Dim LgID As Integer = dtLgID.Rows(0)("LgID")

        Dim dtInv As DataTable
        Dim InvNo As Integer = 0
        MainPage.DocNumber = InvNo
        If txtInvoiceNumber.Text.Trim = "" Then
            dtInv = SQLData("Select isnull(Doc,1) InvNo from DocNumber where type='Sale'")
            InvNo = dtInv.Rows(0)("InvNo").ToString
            SQLData("update docnumber set doc=" & InvNo & "+1 where type='sale'")
        Else
            dtInv = SQLData("Select status from psdetail where type='sale' and doc=" & txtInvoiceNumber.Text)
            If dtInv.Rows.Count > 0 Then
                If dtInv.Rows(0)("status").ToString = "ESTIMATE" Then
                    InvNo = txtInvoiceNumber.Text
                    SQLData("delete from psdetail where type='sale' and doc=" & InvNo)
                    SQLData("delete from ledgers where type='sale' and doc=" & InvNo)
                    SQLData("Update PsProduct set date='" & dtpDate.Value.ToString("d") & "',acid='" & txtCustomerID.Text & "' where type='sale' and doc=" & txtInvoiceNumber.Text)
                ElseIf dtInv.Rows(0)("status").ToString = "INVOICE" Then
                    MsgBox("This estimate has been finalized, can not add items")
                    btnPost.Enabled = True
                    txtInvoiceNumber.Select()
                    Return
                Else
                    MsgBox("This Estimate Number does not exist")
                    btnPost.Enabled = True
                    txtInvoiceNumber.Select()
                    Return
                End If
            End If
        End If

        SavePsproduct(InvNo)

        SavePsDetailsLedger(InvNo, PreviousBalnace)

        InvoiceNumber = InvNo
        'MainPage.msg = "Invoice Number: " + InvNo.ToString + " Saved"
        'DisappearingMsgBox.btnClose.Text = "OK"
        'DisappearingMsgBox.Timer1.Interval = 2000
        'DisappearingMsgBox.Show()
        'Console.Beep(500, 1000)
        'MsgBox("Invoice Number: " + InvNo.ToString + " Saved")
        btnRefresh.PerformClick()
        txtEstimateTotal.Text = ""
        btnPost.Enabled = True
    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtEstimateTotal.Text = ""
        ClearTextBox(Me)
        dgvSale.Rows.Clear()
        If dgvSaleHistory.Rows.Count > 0 Then
            dgvSaleHistory.DataSource.Clear()
        End If
        If dgvPendingOrders.Rows.Count > 0 Then
            dgvPendingOrders.DataSource.Clear()
        End If
        If dgvFocusItem.Rows.Count > 0 Then
            dgvFocusItem.DataSource.Clear()
        End If
        chkScheme.Checked = True
        ChkClaim.Checked = False
        chkCash.Checked = False
        txtCustomerID.Select()

        'txtEstimateTotal.Text = ""
        'txtCustomerID.Text = ""
        'txtCustomerName.Text = ""
        'txtFreight.Text = ""
        'txtOCell.Text = ""
        'txtRoute.Text = ""
        'txtInvoiceNumber.Text = ""


        txtRefference.Text = "ESTIMATE"
        txtGoods.Text = "COUNTER"
    End Sub

    Private Sub dgvSale_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSale.CellDoubleClick
        Itemsfromgrid(dgvSale.CurrentRow)
    End Sub
    Sub Itemsfromgrid(rows As DataGridViewRow)
        txtPRID.Text = rows.Cells("colCode").Value.ToString()
        ProductSearch.prIDtxt = txtPRID.Text
        ProductSearch.ProductID = rows.Cells("colProductID").Value
        txtProductName.Text = rows.Cells("colName").Value.ToString()
        cmbLoc.Text = rows.Cells("colLocation").Value.ToString()
        cmbSPO.Text = rows.Cells("colSPO").Value.ToString()
        txtOQty.Text = rows.Cells("colOQty").Value.ToString()
        txtBQty.Text = rows.Cells("colBQty").Value.ToString()
        txtRate.Text = rows.Cells("colRate").Value.ToString()
        ProductSearch.PrRate = txtRate.Text
        txtFOC.Text = CInt(rows.Cells("colFOC").Value)
        txtDisc1.Text = rows.Cells("colDis1").Value.ToString()
        txtDisc2.Text = rows.Cells("colDis2").Value.ToString()
        txtItemTotal.Text = rows.Cells("colAmount").Value.ToString()
        txtUOM.Text = "PC"
        Dim x As Integer = dgvSale.CurrentRow.Index
        dgvSale.Rows.Remove(dgvSale.Rows(x))
        EstimateTotal()
        txtPRID.Select()
        txtPRID.SelectAll()
    End Sub


    Sub FreightCalculations2()
        If dtpDate.Value >= Now.Date And Form3.Numbers(txtEstimateTotal.Text) > 0 And Not txtCustomerName.Text.Contains("#") And txtGoods.Text.Contains("SUPPLY VAN") Then
            If (txtRoute.Text.Contains("SR") Or txtRoute.Text.Contains("KR")) And Form3.Numbers(txtEstimateTotal.Text) > 0 And Form3.Numbers(txtEstimateTotal.Text) < 1000 Then
                txtFreight.Text = 0
            End If
            If (txtRoute.Text.Contains("SR") Or txtRoute.Text.Contains("KR")) And Form3.Numbers(txtEstimateTotal.Text) > 1000 And Form3.Numbers(txtEstimateTotal.Text) < 3000 Then
                txtFreight.Text = -30
            End If
            If (txtRoute.Text.Contains("SR") Or txtRoute.Text.Contains("KR")) And Form3.Numbers(txtEstimateTotal.Text) > 3000 And Form3.Numbers(txtEstimateTotal.Text) < 5000 Then
                txtFreight.Text = -60
            End If
            If (txtRoute.Text.Contains("SR") Or txtRoute.Text.Contains("KR")) And Form3.Numbers(txtEstimateTotal.Text) > 5000 Then
                txtFreight.Text = -80
            End If
            If (txtRoute.Text.Contains("SR") Or txtRoute.Text.Contains("KR")) And Form3.Numbers(txtEstimateTotal.Text) > 90000 Then
                txtFreight.Text = -150
            End If
            If (txtRoute.Text.Contains("SR") Or txtRoute.Text.Contains("KR")) And Form3.Numbers(txtEstimateTotal.Text) > 150000 Then
                txtFreight.Text = -200
            End If
        End If
        If Form3.Numbers(txtEstimateTotal.Text) = 0 Or txtCustomerName.Text.Contains("#") Or txtGoods.Text.Contains("SUPPLY VAN") = False Then
            txtFreight.Text = 0
        End If
    End Sub

    Sub Freightcalculations3(Amount)
        If Form3.Numbers(txtEstimateTotal.Text) = 0 Or txtCustomerName.Text.Contains("#") Or txtGoods.Text.Contains("SUPPLY VAN") = False Then
            txtFreight.Text = 0
            Return
        End If
        Dim TodayFreight As DataTable = SQLData("select isnull(sum(freight),0) TodaysFreight from PSDetail where acid=" & txtCustomerID.Text & " and date between '" & dtpDate.Value.ToString("d") & "'  and dateadd(d,1,'" & dtpDate.Value.ToString("d") & "')")
        If TodayFreight.Rows.Count > 0 Then
            If Numbers(TodayFreight.Rows(0)("TodaysFreight")) <> 0 Then
                txtFreight.Text = 0
                Return 'TodayFreight.Rows(0)("TodaysFreight")
            End If
        End If
        Dim dt As DataTable
        Dim Freight As Integer
        If dtpDate.Value >= Now.Date And Form3.Numbers(txtEstimateTotal.Text) > 0 And Not txtCustomerName.Text.Contains("#") And txtGoods.Text.Contains("SUPPLY VAN") Then
            If (txtRoute.Text.Contains("SR") Or txtRoute.Text.Contains("KR")) Then
                dt = SQLData("select top 1 Freight from freightcalculations where amount>" & Amount & " order by amount")
                If dt.Rows.Count > 0 Then
                    Freight = dt.Rows(0)("Freight")
                    txtFreight.Text = Freight
                Else
                    txtFreight.Text = 0
                End If
            End If
        End If

    End Sub

    Private Sub frmEstimate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDoc.Text = "ESTIMATE - " + MainPage.LoginDetails
        Dim dt As DataTable = SQLData("Select distinct vehicle SPO from PSDetail where type='Sale' ORDER BY VEHICLE")
        ' dt2 = Location
        Dim dt2 As DataTable = SQLData("select distinct department Location from PSProduct where type='sale' ORDER BY DEPARTMENT")   'SPO
        If cmbFocusItems.Items.Count > 0 Then
            cmbFocusItems.SelectedIndex = 0
        End If
        cmbLoc.Items.Clear()
        cmbSPO.Items.Clear()

        For i = 0 To dt2.Rows.Count - 1
            cmbLoc.Items.Add(dt2.Rows(i)(0))

        Next
        For i = 0 To dt.Rows.Count - 1
            cmbSPO.Items.Add(dt.Rows(i)(0))
        Next
    End Sub

    Private Sub chkScheme_CheckedChanged(sender As Object, e As EventArgs) Handles chkScheme.CheckedChanged

        QtyScheme()
        ProductQtyScheme(ProductSearch.ProductID)
        ItemTotalCalculations()
        txtBQty.SelectAll()
        txtBQty.Select()
    End Sub


    Private Sub tbnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        btnPost.PerformClick()

        rfEstimates.txtLDN.Text = InvoiceNumber
        rfEstimates.txtDN.Text = InvoiceNumber
        rfEstimates.txtRN.Text = ""
        rfEstimates.rdSeparat.Checked = True
        rfEstimates.dtpStart.Value = dtpDate.Value
        rfEstimates.dtpEnd.Value = dtpDate.Value
        rfEstimates.Show()
        rfEstimates.btnDisplay.PerformClick()
        InvoiceNumber = ""
        Return

    End Sub

    Sub SaleHistory(ACID, PRID, SearchDate)
        Dim dt As DataTable = SQLData("select top 5 date,doc,qty2,qty,schpc,rate,discp,discp2,vist,spo,department from psproduct where type='sale' and acid=" & ACID & " and prid=(select id from products where code='" & PRID & "') and date<='" & SearchDate & "' order by date desc")
        If dt.Rows.Count > 0 Then
            dgvSaleHistory.DataSource = dt
        Else
            If dgvSaleHistory.Rows.Count > 0 Then
                dgvSaleHistory.DataSource = Nothing
            End If

        End If

    End Sub

    Private Sub chkHistory_CheckedChanged(sender As Object, e As EventArgs) Handles chkHistory.CheckedChanged
        If chkHistory.Checked Then
            If txtPRID.Text <> "" And txtCustomerID.Text <> "" Then
                SaleHistory(txtCustomerID.Text, txtPRID.Text, dtpDate.Value.ToString("d"))

            Else
                dgvSaleHistory.Rows.Clear()
            End If

        End If
        txtOQty.SelectAll()
        txtOQty.Select()
    End Sub

    Private Sub txtGoods_Leave(sender As Object, e As EventArgs) Handles txtGoods.Leave
        EstimateTotal()
        txtPRID.SelectAll()
        txtPRID.Select()
    End Sub

    Private Sub txtGoods_Enter(sender As Object, e As EventArgs) Handles txtGoods.Enter
        txtGoods.SelectAll()
    End Sub

    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            Return
        End If
        Dim dt As Date = dtpDate.Value
        Dim dtlimit As Date = Date.Today.AddDays(3)
        If dt > dtlimit Then
            MsgBox("Pls Check Date")
            dtpDate.Value = Date.Today
            dtpDate.Select()
        End If
        If dtpDate.Value < Date.Today Then
            '.Now.AddDays(3).ToString("d") Then
            MsgBox("Pls Check Date")
            dtpDate.Value = Date.Today
            dtpDate.Select()
        End If
    End Sub

    Private Sub txtOQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOQty.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then e.Handled = True
    End Sub

    Private Sub txtItemTotal_TextChanged(sender As Object, e As EventArgs) Handles txtItemTotal.Leave
        txtItemTotal.BackColor = Color.PaleGreen
        'If txtItemTotal.Text <> "" Then
        '    txtDisc1.Text = "0"
        '    txtDisc2.Text = "0"
        '    txtRate.Text = Math.Round(Form3.Numbers(txtItemTotal.Text) / Form3.Numbers(txtBQty.Text), 2)
        '    txtBQty.SelectAll()
        '    txtBQty.Select()
        'End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        chkCash.Checked = False
        btnPost.PerformClick()
        SQLData("UPDATE PSDETAIL SET STATUS='INVOICE', DESCRIPTION=CASE WHEN DESCRIPTION='ESTIMATE' THEN 'COUNTER BILL ,'+(select top 1 username from PSDetailHistory where type='sale' and doc=" & InvoiceNumber & ")+' '+'" & Date.Now.ToString("t") & "' ELSE DESCRIPTION END WHERE TYPE='SALE' AND DOC=" & InvoiceNumber)
        SQLData("UPDATE LEDGERS SET NARRATION=CASE WHEN NARRATION='ESTIMATE' THEN 'COUNTER BILL ,'+(select top 1 username from PSDetailHistory where type='sale' and doc=" & InvoiceNumber & ")+' , '+'" & Date.Now.ToString("t") & "' ELSE NARRATION END WHERE TYPE='SALE' AND DOC=" & InvoiceNumber)
        MainPage.rptName = Settings("Reports Folder") + "thermal invoice.rpt"
        Dim report As New ReportDocument
        report.Load(MainPage.rptName)
        'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        report.SetParameterValue("DocNumber", InvoiceNumber)
        report.SetParameterValue("Recpt", 0)
        report.SetParameterValue("PreBalance", 0)
        report.SetParameterValue("companyName", "")
        If MainPage.ThermalPrinter <> "" Then
            report.PrintOptions.PrinterName = MainPage.ThermalPrinter
            report.PrintToPrinter(1, False, 0, 0)
        End If
        SQLData("update psproduct set PrintStatus='Due Bill',PrintBy='" & frmLogin.UserName & "',PrintDateTime='" & Date.Now & "' where type='Sale' and doc=" & InvoiceNumber)
    End Sub

    Private Sub txtItemTotal_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemTotal.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtItemTotal.Text <> "" Then
                txtDisc1.Text = "0"
                txtDisc2.Text = "0"
                txtRate.Text = Math.Round(Form3.Numbers(txtItemTotal.Text) / Form3.Numbers(txtBQty.Text), 2)
                txtBQty.SelectAll()
                txtBQty.Select()
            End If
        End If
        If e.KeyCode = Keys.Enter And Val(txtOQty.Text) <> 0 Then
            e.Handled = True
            ItemAdd()
        End If


    End Sub

    Private Sub chkStock_CheckedChanged(sender As Object, e As EventArgs) Handles chkStock.CheckedChanged
        StockQty()
    End Sub

    Sub PendingEstimate()
        Dim dt As DataTable = SQLData("select top 1 pd.Doc,pd.Date from psdetail pd join PsProduct ps on pd.doc=ps.Doc and pd.type=ps.Type where pd.acid=" & txtCustomerID.Text & " and status='ESTIMATE' and PrintStatus is null   --and (date='" & dtpDate.Value.ToString("d") & "' or date=CONVERT(date,dateadd(d,0,getdate()))) ")
        If dt.Rows.Count > 0 Then
            txtInvoiceNumber.BackColor = Color.Green
            txtInvoiceNumber.Text = dt.Rows(0)("DOC")
            lblDate.Text = dt.Rows(0)("Date")
            If lblDate.Text < Date.Today.AddDays(-7) Then
                lblDate.BackColor = Color.Red
            Else
                lblDate.BackColor = Color.Transparent
            End If
        Else
            txtInvoiceNumber.BackColor = Color.White
            txtInvoiceNumber.Text = ""
            lblDate.Text = ""
        End If

    End Sub

    Sub BalanceIcrease()
        Dim dt2 As DataTable = SQLData("select isnull(isnull(sum(debit),0)-isnull(sum(Credit),0),0) Net from ledgers where acid=" & txtCustomerID.Text & " 
and date>=(select top 1 date from ledgers where acid=" & txtCustomerID.Text & " and isnull(debit,0)>0 order by date desc ) 
and date<'" & dtpDate.Value.ToString("d") & "'")
        If dt2.Rows.Count > 0 Then
            Dim Net As Integer = dt2.Rows(0)("Net")
            txtNet.Text = Form3.Amt(Net)
            If Net > 0 Then
                txtNet.BackColor = Color.Red
            Else
                txtNet.BackColor = Color.Green
            End If
        Else
            txtNet.Text = ""
            txtNet.BackColor = Color.White
        End If

        Dim dt3 As DataTable = SQLData("select isnull(round(sum(debit)-sum(credit),0) -
                                            isnull((select sum(Debit) from ledgers where acid=l.acid and date>=dateadd(d,-30,getdate())),0),0) OverDue
                                            from ledgers l where acid=" & txtCustomerID.Text & "
                                            group by acid")
        Dim od As Integer
        If dt3.Rows.Count > 0 Then
            od = dt3.Rows(0)("OverDue")
            If od < 0 Then
                od = 0
            End If
        Else
            od = 0
        End If
        If dt3.Rows.Count > 0 Then
            txtOD.Text = Form3.Amt(od)
            If od > 0 Then
                txtOD.BackColor = Color.Red
                txtOD.ForeColor = Color.White
            Else
                txtOD.BackColor = Color.Green
                txtOD.ForeColor = Color.Black
            End If
        Else
            txtOD.Text = ""
            txtOD.BackColor = Color.White
        End If


    End Sub

    Sub CustomerSelection()
        Dim dt As DataTable = SQLData("select * from coa where id=" & txtCustomerID.Text)
        If dt.Rows.Count > 0 Then
            txtCustomerName.Text = dt.Rows(0)("Subsidary")
            'txtAddress.Text = dt.Rows(0)("OAddress")
            txtOCell.Text = dt.Rows(0)("Ocell")
            txtRoute.Text = dt.Rows(0)("Route")
        Else
            MsgBox("Customer Not Found")
            txtCustomerName.Text = Nothing
            'txtAddress.Text = Nothing
            txtOCell.Text = Nothing
            txtRoute.Text = Nothing
        End If

    End Sub

    Private Sub txtCustomerID_Leave(sender As Object, e As EventArgs) Handles txtCustomerID.Leave
        txtCustomerID.BackColor = Color.White
        If txtCustomerID.Text <> "" Then
            CustomerSelection()
            PendingEstimate()
            PendingOrder()
            BalanceIcrease()
            FocusItems()
        Else
            txtInvoiceNumber.Text = ""
            lblDate.Text = ""
            Return
        End If
        Dim TotalPayment As DataTable = SQLData("select isnull(sum(debit),0) Debit,isnull(sum(credit),0) Credit from ledgers where acid=" & txtCustomerID.Text & " and month(date) =" & dtpDate.Value.Month & " and year(date) = " & dtpDate.Value.Year)
        txtTotalDebit.Text = Form3.Amt(TotalPayment.Rows(0)("Debit"))
        txtTotalCredit.Text = Form3.Amt(TotalPayment.Rows(0)("Credit"))
        txtTotalDiff.Text = Form3.Amt(TotalPayment.Rows(0)("Debit") - TotalPayment.Rows(0)("Credit"))
        If txtTotalDiff.Text > 0 Then
            txtTotalDiff.BackColor = Color.Red
            txtTotalDiff.ForeColor = Color.White
            txtTotalDiff.Font = New Font("Arial", 12, FontStyle.Bold)
        Else
            txtTotalDiff.BackColor = Color.Green
            txtTotalDiff.ForeColor = Color.White
            txtTotalDiff.Font = New Font("Arial", 12, FontStyle.Bold)
        End If

        If txtCustomerName.Text.ToUpper.Contains("COUNTER") And dtpDate.Value.ToString("d") = Date.Today Then
            chkCash.Checked = True
        End If
    End Sub

    Sub PendingOrder()
        Dim dt As DataTable = SQLData("select 
                                            ps.date,ps.doc,p.name+' '+p.Category+' '+p.Company Product,qty2 OrderQty,qty BillQty,ps.Rate,ps.DiscP,DiscP2
                                            ,isnull((select sum(case when type='sale' then (qty+isnull(schpc,0))*-1 when type='Purchase' then (qty+isnull(schpc,0)) end ) from PsProduct pss where pss.prid=ps.prid and pss.date>=isnull(StockDate,'2021-1-1') and pss.date<='" & dtpDate.Value.ToString("d") & "' and isclaim=0),0) Stock                                            
                                            ,isclaim,sch,spo,department,aqty,(select top 1 code from products where id=prid) prid,ps.schpc
                                            from psproduct ps join Products p on ps.prid=p.ID
                                            where acid=" & txtCustomerID.Text & " and qty<>qty2 and type='sale' and date=(select top 1 date from PSProduct where acid=" & txtCustomerID.Text & " and date<'" & dtpDate.Value.ToString("d") & "' order by date desc) order by batch
                                            ")
        If dt.Rows.Count > 0 Then
            dgvPendingOrders.DataSource = dt
            dgvPendingOrders.CurrentRow.Selected = False
        Else
            If dgvPendingOrders.DataSource IsNot Nothing Then
                dgvPendingOrders.DataSource.Clear()
            End If
        End If

    End Sub


    Private Sub txtTotalQty_TextChanged(sender As Object, e As EventArgs) Handles txtTotalQty.TextChanged

    End Sub

    Private Sub txtDisc1_TextChanged(sender As Object, e As EventArgs) Handles txtDisc1.TextChanged, txtDisc2.TextChanged
        ItemTotalCalculations()
    End Sub

    Private Sub txtPRID_Enter(sender As Object, e As EventArgs) Handles txtPRID.Enter
        txtPRID.BackColor = Color.DeepSkyBlue
        If txtCustomerID.Text = "" Then
            txtCustomerID.Text = "8"
            txtCustomerName.Text = "WALK IN CUSTOMER"
            txtRoute.Text = "COUNTER"
        End If
    End Sub

    Private Sub chkCash_CheckedChanged(sender As Object, e As EventArgs) Handles chkCash.CheckedChanged
        If chkCash.Checked Then
            chkCash.BackColor = Color.Green
        Else
            chkCash.BackColor = Color.Transparent

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCashMemo.Click
        chkCash.Checked = True
        dtpDate.Value = Date.Today
        btnPost.PerformClick()
        SQLData("UPDATE PSDETAIL SET STATUS='INVOICE', DESCRIPTION=CASE WHEN DESCRIPTION='ESTIMATE' THEN 'COUNTER BILL ,'+(select top 1 username from PSDetailHistory where type='sale' and doc=" & InvoiceNumber & ")+' '+'" & Date.Now.ToString("t") & "' ELSE DESCRIPTION END WHERE TYPE='SALE' AND DOC=" & InvoiceNumber)
        SQLData("UPDATE LEDGERS SET NARRATION=CASE WHEN NARRATION='ESTIMATE' THEN 'COUNTER BILL ,'+(select top 1 username from PSDetailHistory where type='sale' and doc=" & InvoiceNumber & ")+' , '+'" & Date.Now.ToString("t") & "' ELSE NARRATION END WHERE TYPE='SALE' AND DOC=" & InvoiceNumber)
        MainPage.rptName = Settings("Reports Folder") + "thermal invoice.rpt"
        Dim report As New ReportDocument
        report.Load(MainPage.rptName)
        'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next

        report.SetParameterValue("DocNumber", InvoiceNumber)
        report.SetParameterValue("Recpt", 0)
        report.SetParameterValue("PreBalance", 0)
        report.SetParameterValue("companyName", "")
        'Try
        '    report.PrintOptions.PrinterName = "FP-1100"
        'Catch EX As Exception
        '    MsgBox(EX.ToString)
        'End Try

        If MainPage.ThermalPrinter <> "" Then
            report.PrintOptions.PrinterName = MainPage.ThermalPrinter
            report.PrintToPrinter(1, False, 0, 0)
        End If
        SQLData("update psproduct set PrintStatus='Cash Bill',PrintBy='" & frmLogin.UserName & "',PrintDateTime='" & Date.Now & "' where type='Sale' and doc=" & InvoiceNumber)
    End Sub

    Private Sub dgvFocusItem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvFocusItem.CellFormatting

        If cmbFocusItems.Text = "FIT Items" Then
            For i = 0 To dgvFocusItem.Rows.Count - 1
                If dgvFocusItem.Rows(i).Cells("FocusDoc").Value > 30 Then
                    dgvFocusItem.Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                End If
            Next
        End If
        If cmbFocusItems.Text = "Focus Items" Then
            For i = 0 To dgvFocusItem.Rows.Count - 1
                If dgvFocusItem.Rows(i).Cells("FocusBill").Value = 0 Then
                    dgvFocusItem.Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                End If
            Next
        End If

    End Sub

    Private Sub txtCustomerID_Enter(sender As Object, e As EventArgs) Handles txtCustomerID.Enter
        txtCustomerID.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub cmbSPO_Enter(sender As Object, e As EventArgs) Handles cmbSPO.Enter
        cmbSPO.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub cmbSPO_Leave(sender As Object, e As EventArgs) Handles cmbSPO.Leave
        cmbSPO.BackColor = Color.White
    End Sub

    Private Sub cmbLoc_Enter(sender As Object, e As EventArgs) Handles cmbLoc.Enter
        cmbLoc.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub cmbLoc_Leave(sender As Object, e As EventArgs) Handles cmbLoc.Leave
        cmbLoc.BackColor = Color.White
    End Sub

    Private Sub txtOQty_Leave(sender As Object, e As EventArgs) Handles txtOQty.Leave
        txtOQty.BackColor = Color.White
    End Sub

    Private Sub txtBQty_Leave(sender As Object, e As EventArgs) Handles txtBQty.Leave
        txtBQty.BackColor = Color.White
    End Sub

    Private Sub txtPriceList_Enter(sender As Object, e As EventArgs) Handles txtPriceList.Enter
        txtPriceList.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub txtPriceList_Leave(sender As Object, e As EventArgs) Handles txtPriceList.Leave
        txtPriceList.BackColor = Color.White
    End Sub

    Private Sub txtRate_Enter(sender As Object, e As EventArgs) Handles txtRate.Enter
        txtRate.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub txtRate_Leave(sender As Object, e As EventArgs) Handles txtRate.Leave
        txtRate.BackColor = Color.White
    End Sub

    Private Sub txtDisc1_Enter(sender As Object, e As EventArgs) Handles txtDisc1.Enter
        txtDisc1.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub txtDisc1_Leave(sender As Object, e As EventArgs) Handles txtDisc1.Leave
        txtDisc1.BackColor = Color.White
    End Sub

    Private Sub txtDisc2_Enter(sender As Object, e As EventArgs) Handles txtDisc2.Enter
        txtDisc2.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub txtDisc2_Leave(sender As Object, e As EventArgs) Handles txtDisc2.Leave
        txtDisc2.BackColor = Color.White
    End Sub

    Private Sub txtItemTotal_Enter(sender As Object, e As EventArgs) Handles txtItemTotal.Enter
        txtItemTotal.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub txtAQty_TextChanged(sender As Object, e As EventArgs) Handles txtAQty.TextChanged
        txtBQty.Text = txtAQty.Text
    End Sub

    Private Sub dgvPendingOrders_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvPendingOrders.CellFormatting
        For i = 0 To dgvPendingOrders.Rows.Count - 1
            If dgvPendingOrders.Rows(i).Cells("colStockQty").Value > dgvPendingOrders.Rows(i).Cells("colBillQty").Value Then
                dgvPendingOrders.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            End If
        Next
    End Sub

    Private Sub dgvSale_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSale.CellContentClick

    End Sub

    Private Sub cmbFocusItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFocusItems.SelectedIndexChanged
        FocusItems()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If dgvPendingOrders.Rows.Count = 0 Then
            MsgBox("No Pending Items from last invoice !")
            Return
        End If
        For n = 0 To dgvPendingOrders.Rows.Count - 1
            Dim row As DataGridViewRow = dgvPendingOrders.Rows(n)
            Dim isscheme As Integer = row.Cells("pendingSch").Value
            Dim isclaim As Integer = row.Cells("pendingIsClaim").Value
            Dim spo As String = row.Cells("pendingSPO").Value
            Dim prid As String = row.Cells("Pendingprid").Value
            Dim ProductName As String = row.Cells("colProduct").Value
            Dim pendingAQ As Double = SafeDouble(row.Cells("pendingAQTY").Value)
            Dim billedQ As Double = SafeDouble(row.Cells("colBillQty").Value)
            Dim oqty As Double = pendingAQ - billedQ
            If oqty = 0 Then
                Continue For
            End If
            Dim aqty As Double = oqty
            Dim bqty As Double = oqty
            Dim foc As Integer = row.Cells("SchPC").Value
            Dim rate As Double = Double.Parse(row.Cells("colORate").Value)
            Dim disc1 As Double = Double.Parse(row.Cells("colODic1").Value)
            Dim disc2 As Double = Double.Parse(row.Cells("colODis2").Value)
            Dim amount As Double = Math.Round(bqty * rate - (bqty * rate * disc1 / 100) - (bqty * rate * disc2 / 100), 2)
            Dim uom As String = "PC"
            'Dim schpc As Integer = row.Cells("pendingSchPC").Value
            Dim loc As String = row.Cells("pendingLocation").Value
            Dim ProductTable As DataTable = SQLData("select id from products where code='" & prid & "'")
            Dim ProID As String = ProductTable.Rows(0)("ID")
            dgvSale.Rows.Add(n, isscheme, isclaim, spo, prid, ProductName, oqty, aqty, bqty, foc, rate, disc1, disc2, amount, loc, ProID)
        Next
        EstimateTotal()
        dgvSale.FirstDisplayedScrollingRowIndex = dgvSale.RowCount - 1
        dgvSale.Rows(dgvSale.RowCount - 1).Selected = True
        ClearTextBox(gbItems)
        txtPRID.Select()
    End Sub
    Private Function SafeDouble(obj As Object) As Double
        If obj Is Nothing OrElse Convert.IsDBNull(obj) Then
            Return 0.0
        End If
        Dim s As String = obj.ToString()
        Dim result As Double
        If Double.TryParse(s, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, result) Then
            Return result
        End If
        Return 0.0
    End Function
End Class
Public Class frmProHistory

    Sub ProHistory()
        Dim STV As String = "%"
        Dim DocType As String = ""
        Dim Claim As Integer = 0
        If chkPurchase.Checked = True Then
            DocType = "Purchase"
        Else
            DocType = "%"
        End If

        If chkClaim.Checked = True Then
            Claim = 1
        Else
            Claim = 0
        End If

        Dim tbpid As DataTable = SQLData("select id from Products where code='" & txtprid.Text & "'")
        If tbpid.Rows.Count = 0 Then
            MsgBox("Product not found")
            txtprid.SelectAll()
            txtprid.Select()
            Return
        End If
        Dim pid As String = tbpid.Rows(0)("id")
        Dim tbl As DataTable
        If chkSTV.Checked = True Then
            tbl = SQLData("SELECT *,SUM(QTYIN) OVER (ORDER BY DATE,DOC)-SUM(QTYOUT) OVER (ORDER BY DATE,DOC) BAL FROM (
                                SELECT '" & dStart.Value.ToString("d") & "' DATE,'OE' TYPE,0 DOC,0 ACID,'OPENNING STOCK' SUBSIDARY,'' Description
		                        ,ISNULL(SUM(CASE WHEN TYPE IN ('PURCHASE','SALE RETURN') THEN QTY ELSE 0 END),0)-ISNULL(SUM(CASE WHEN TYPE IN ('SALE','PURCHASE RETURN') THEN QTY ELSE 0 END),0) QTYIN
		                        ,0 QTYOUT,0 Rate,0 NetRate,0 PROFIT,'' DEPARTMENT,'' DEPARTMENT2, '' ISCLAIM
		                        FROM PSProduct 
                                WHERE PRID=" & pid & " AND DATE<'" & dStart.Value.ToString("d") & "'
                                UNION ALL
                                select 
	                            ps.Date
	                            ,ps.TYPE
	                            ,ps.DOC
	                            ,isnull(ps.acid,'') ACID
	                            ,isnull(Subsidary,'Transfered From '+department+' TO '+department2) Subsidary
	                            ,Description 
	                            ,CASE WHEN (ps.TYPE IN ('PURCHASE')) OR (ps.TYPE='STOCK TRANSFER' AND department2 LIKE '" & txtLocation.Text & "%') THEN Qty+isnull(SCHPC,0) ELSE 0 END QTYIN
	                            ,CASE WHEN (ps.TYPE IN ('SALE')) OR (ps.TYPE='STOCK TRANSFER' AND department LIKE '" & txtLocation.Text & "%') THEN Qty+isnull(SCHPC,0) ELSE 0 END QTYOUT
	                            ,isnull(ps.Rate,0),isnull(ROUND(VIST/case when (QTY+SCHPC)<>0 then (QTY+SCHPC) else 1 end,2),0) NetRate, isnull(profit,0)
	                            ,department Location
	                            ,ISNULL(department2,'') Location2
	                            ,isnull(isclaim,0) IsClaim
	                            from PSProduct ps 
	                            left join PSDetail pd on ps.type=pd.type and ps.doc=pd.Doc
	                            left join coa a on ps.acid=a.Id 
	                            where ps.date>='" & dStart.Value.ToString("d") & "'
	                            and ps.date<='" & dEnd.Value.ToString("d") & "'
	                            and isnull(ps.Acid,0) like '" & txtCustID.Text & "%'
	                            and ps.type like '" & DocType & "%'
	                            and isnull(isclaim,0) = " & Claim & "
	                            and (isnull(department2,'') like '" & txtLocation.Text & "%' OR department LIKE '" & txtLocation.Text & "%')
	                            AND PRID=" & pid & "
	                            ) x order by Date")
        Else
            tbl = SQLData("SELECT *,SUM(QTYIN) OVER (ORDER BY DATE,DOC)-SUM(QTYOUT) OVER (ORDER BY DATE,DOC) BAL FROM (
                                SELECT '" & dStart.Value.ToString("d") & "' DATE,'OE' TYPE,0 DOC,0 ACID,'OPENNING STOCK' SUBSIDARY,'' Description, 0 OrderQty
		                    ,ISNULL(SUM(CASE WHEN TYPE IN ('PURCHASE','SALE RETURN') THEN QTY ELSE 0 END),0)-ISNULL(SUM(CASE WHEN TYPE IN ('SALE','PURCHASE RETURN') THEN QTY ELSE 0 END),0) QTYIN
		                    ,0 QTYOUT,0 Rate,0 NetRate,0 PROFIT,'' DEPARTMENT,'' DEPARTMENT2, '' ISCLAIM
		                    FROM PSProduct WHERE PRID=" & pid & " AND DATE<'" & dStart.Value.ToString("d") & "'
                            UNION ALL
                            select 
	                        ps.Date
	                        ,ps.TYPE
	                        ,ps.DOC
	                        ,isnull(ps.acid,'') ACID
	                        ,isnull(Subsidary,'Transfered From '+department+' TO '+department2) Subsidary
	                        ,Description 
	                        ,isnull(qty2,0)+isnull(schpc,0) OrderQty
                            ,CASE WHEN (ps.TYPE IN ('PURCHASE')) OR (ps.TYPE='STOCK TRANSFER' AND department2 LIKE '" & txtLocation.Text & "%') THEN Qty+isnull(SCHPC,0) ELSE 0 END QTYIN
	                        ,CASE WHEN (ps.TYPE IN ('SALE')) OR (ps.TYPE='STOCK TRANSFER' AND department LIKE '" & txtLocation.Text & "%') THEN Qty+isnull(SCHPC,0) ELSE 0 END QTYOUT
	                        ,isnull(ps.Rate,0),isnull(ROUND(VIST/case when (QTY+SCHPC)<>0 then (QTY+SCHPC) else 1 end,2),0) NetRate, isnull(profit,0)
	                        ,department Location
	                        ,ISNULL(department2,'') Location2
	                        ,isnull(isclaim,0) IsClaim
	                        from PSProduct ps 
	                        left join PSDetail pd on ps.type=pd.type and ps.doc=pd.Doc
	                        left join coa a on ps.acid=a.Id 
	                        where ps.date>='" & dStart.Value.ToString("d") & "'
	                        and ps.date<='" & dEnd.Value.ToString("d") & "'
	                        and isnull(ps.Acid,0) like '" & txtCustID.Text & "%'
	                        and ps.type like '" & DocType & "%'
	                        and isnull(isclaim,0) = " & Claim & "
	                        and (isnull(department2,'') like '" & txtLocation.Text & "%' OR department LIKE '" & txtLocation.Text & "%')
	                        AND PRID=" & pid & " and PS.type not like 'STOCK%' --and qty2<>qty and ps.type='sale'
	                        ) x order by Date")
        End If



        'Dim tbl As DataTable = SQLData("  SELECT *,SUM(QTYIN) OVER (ORDER BY DATE,DOC)-SUM(QTYOUT) OVER (ORDER BY DATE,DOC) BAL FROM (
        '                                        SELECT 
        '                                        '" & dStart.Value.ToString("d") & "' DATE ,'OE' TYPE,0 DOC,0 ACID,'OPENNING STOCK' SUBSIDARY,'' Description,
        '                                        ISNULL(SUM(CASE WHEN TYPE IN ('PURCHASE','SALE RETURN') THEN QTY ELSE 0 END),0)-ISNULL(SUM(CASE WHEN TYPE IN ('SALE','PURCHASE RETURN') THEN QTY ELSE 0 END),0) QTYIN,
        '                                         0 QTYOUT,0 Rate,0 NetRate,0 PROFIT,'' DEPARTMENT , '' ISCLAIM
        '                                         FROM PSProduct 
        '                                        WHERE PRID=" & pid & " AND DATE<'" & dStart.Value.ToString("d") & "' 
        '                                        UNION ALL
        '                                        SELECT 
        '                                        PS.DATE,ps.TYPE,ps.DOC,ps.ACID,A.Subsidary,pd.Description,
        '                                        isnull(CASE WHEN ps.TYPE IN ('PURCHASE','Sale Return') and isclaim = " & Claim & " THEN QTY+isnull(SchPc,0) ELSE 0 END,0) QTYIN
        '                                        ,isnull(CASE WHEN ps.TYPE IN ('SALE','PURCHASE RETURN') and isclaim = " & Claim & " THEN QTY+isnull(SCHPC,0) ELSE 0 END,0) QTYOUT
        '                                        ,Rate,ROUND(VIST/(QTY+SCHPC),2) NetRate,profit, department, case when ISNULL(isclaim,0)=1 then 'Claim' else '' end ISCLAIM
        '                                        FROM PSProduct PS JOIN COA A ON PS.ACID=A.ID join PSDetail pd on cast(ps.doc as varchar(6))+ps.type=cast(pd.doc as varchar(6))+pd.Type
        '                                        WHERE PRID=" & pid & " and ps.acid like '" & txtCustID.Text & "%' and ps.type like '" & DocType & "%' and department like '" & txtLocation.Text & "%' and isclaim = " & Claim & "
        '                                        AND QTY<>0
        '                                        ) X WHERE DATE>='" & dStart.Value.ToString("d") & "' AND DATE<='" & dEnd.Value.ToString("d") & "'  ORDER BY DATE

        '")


        '        Dim tbl As DataTable = SQLData("SELECT *,SUM(QTYIN) OVER (ORDER BY DATE,DOC)-SUM(QTYOUT) OVER (ORDER BY DATE,DOC) BAL FROM (
        '                                                SELECT 
        '                                                '" & dStart.Value.ToString("d") & "' DATE ,'OE' TYPE,0 DOC,0 ACID,'OPENNING STOCK' SUBSIDARY,
        '                                                ISNULL(SUM(CASE WHEN TYPE IN ('PURCHASE','SALE RETURN') THEN QTY ELSE 0 END),0)-ISNULL(SUM(CASE WHEN TYPE IN ('SALE','PURCHASE RETURN') THEN QTY ELSE 0 END),0) QTYIN,
        '                                                 0 QTYOUT,0 Rate,0 NetRate,0 PROFIT,'' DEPARTMENT , '' ISCLAIM
        '                                                 FROM PSProduct 
        '                                                WHERE PRID=" & pid & " AND DATE<'" & dStart.Value.ToString("d") & "' 
        '                                                UNION ALL
        '                                                SELECT 
        '                                                PS.DATE,TYPE,DOC,ACID,A.Subsidary,
        '                                                isnull(CASE WHEN TYPE IN ('PURCHASE','Sale Return') and isclaim = " & Claim & " THEN QTY+isnull(SchPc,0) ELSE 0 END,0) QTYIN
        '                                                ,isnull(CASE WHEN TYPE IN ('SALE','PURCHASE RETURN') and isclaim = " & Claim & " THEN QTY+isnull(SCHPC,0) ELSE 0 END,0) QTYOUT
        '                                                ,Rate,ROUND(VIST/(QTY+SCHPC),2) NetRate,profit, department, case when ISNULL(isclaim,0)=1 then 'Claim' else '' end ISCLAIM
        '                                                FROM PSProduct PS JOIN COA A ON PS.ACID=A.ID
        '                                                WHERE PRID=" & pid & " and ps.acid like '" & txtCustID.Text & "%' and type like '" & DocType & "' and isclaim = " & Claim & "
        '                                                AND QTY<>0
        '                                                ) X WHERE DATE>='" & dStart.Value.ToString("d") & "' AND DATE<='" & dEnd.Value.ToString("d") & "'  ORDER BY DATE

        '")
        If tbl.Rows.Count > 0 Then
            dgvProductHistory.DataSource = tbl
            dgvProductHistory.FirstDisplayedScrollingRowIndex = dgvProductHistory.Rows.Count - 1
            Dim totQtyin As Integer = 0
            Dim totQTYOut As Integer = 0
            Dim TotalOrderQty As Integer = 0
            For n = 1 To tbl.Rows.Count - 1
                'If tbl.Rows(n)("Type").ToString.IndexOf("STOCK") = 0 Then
                totQtyin += Form3.Numbers(tbl.Rows(n)("QTYin"))
                totQTYOut += Form3.Numbers(tbl.Rows(n)("QTYout"))
                TotalOrderQty += Form3.Numbers(tbl.Rows(n)("OrderQty"))
                'End If

            Next
            txtTotalOrderQty.Text = TotalOrderQty
            txtTotalQTYin.Text = totQtyin
            txtTotalQTYOut.Text = totQTYOut
            txtTotalQTYBal.Text = totQtyin - totQTYOut

        Else
            dgvProductHistory.DataSource.clear()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        ProHistory()
        ''DataGridView1.DataSource = tbl

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub



    Private Sub frmProHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dStart.Value = Today.AddDays(-30)
        dStart.Value = New DateTime(2022, 6, 23)
        dEnd.Value = Today.AddDays(1)
        If frmLogin.UserLevel.ToUpper <> "ADMIN" Then
            dgvProductHistory.Columns("colNetRate").Visible = False
        Else
            dgvProductHistory.Columns("colNetRate").Visible = True
        End If
    End Sub

    Private Sub txtprid_Enter(sender As Object, e As EventArgs) Handles txtprid.Enter
        If txtprid.Text = "" Then
            ProductSearch.ShowDialog()
            txtprid.Text = ProductSearch.prIDtxt
            txtProduct.Text = ProductSearch.prName
            'btnGenerate.PerformClick()
        End If
    End Sub

    Private Sub dgvProductHistory_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvProductHistory.CellFormatting
        dgvProductHistory.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub dStart_ValueChanged(sender As Object, e As EventArgs) Handles dStart.ValueChanged
        'ProHistory()
    End Sub

    Private Sub dEnd_ValueChanged(sender As Object, e As EventArgs) Handles dEnd.ValueChanged
        'ProHistory()
    End Sub

    Sub DateSelection()
        If rdStockDate.Checked Then
            Dim DT As DataTable = SQLData("SELECT ISNULL(STOCKDATE,'2001-1-1') STOCKDATE FROM PRODUCTS WHERE CODE='" & txtprid.Text & "'")
            If DT.Rows.Count = 0 Then
                Return
            End If
            dStart.Value = DT.Rows(0)("STOCKDATE").ToString
            Dim d As DateTime
            d = DateTime.Now.AddMonths(2)
            d = New DateTime(d.Year, d.Month, 1).AddDays(-1)
            dEnd.Value = d
        End If
        If rdCurrentDate.Checked Then
            dStart.Value = DateTime.Today
            Dim d As DateTime
            d = DateTime.Now.AddMonths(2)
            d = New DateTime(d.Year, d.Month, 1).AddDays(-1)
            dEnd.Value = d
        End If
        If rdLastPurchase.Checked Then
            Dim DT As DataTable = SQLData("SELECT TOP 1 ISNULL(date,'2001-1-1') Date 
FROM PsProduct PS
WHERE type='Purchase' AND PRID=(SELECT ID FROM Products WHERE CODE='" & txtprid.Text & "') Order by date desc")
            If DT.Rows.Count > 0 Then
                dStart.Value = DT.Rows(0)("Date").ToString
            Else
                dStart.Value = DateTime.Today
            End If

            Dim d As DateTime
            d = DateTime.Now.AddMonths(2)
            d = New DateTime(d.Year, d.Month, 1).AddDays(-1)
            dEnd.Value = d
        End If
    End Sub

    Private Sub txtprid_Leave(sender As Object, e As EventArgs) Handles txtprid.Leave
        'ProHistory()
        DateSelection()


    End Sub

    Private Sub txtCustID_Leave(sender As Object, e As EventArgs) Handles txtCustID.Leave
        'ProHistory()
    End Sub

    Private Sub chkPurchase_CheckedChanged(sender As Object, e As EventArgs) Handles chkPurchase.CheckedChanged, chkSTV.CheckedChanged
        'ProHistory()
    End Sub

    Private Sub chkClaim_CheckedChanged(sender As Object, e As EventArgs) Handles chkClaim.CheckedChanged
        'ProHistory()
    End Sub

    Private Sub txtprid_KeyDown(sender As Object, e As KeyEventArgs) Handles txtprid.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtprid.Text = "" Then
                ProductSearch.ShowDialog()
                txtprid.Text = ProductSearch.prIDtxt
                txtProduct.Text = ProductSearch.prName
                'btnGenerate.PerformClick()
            End If
        End If

    End Sub


    Private Sub rdCurrentDate_CheckedChanged(sender As Object, e As EventArgs) Handles rdCurrentDate.CheckedChanged, rdStockDate.CheckedChanged, rdLastPurchase.CheckedChanged
        DateSelection()
    End Sub

    Private Sub txtCustID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCustID.KeyDown
        If e.KeyCode = Keys.Enter And txtCustID.Text = "" Then
            frmPartySearch.ShowDialog()
            txtCustID.Text = frmPartySearch.acID
            txtCustomer.Text = frmPartySearch.CusName
            'btnGenerate.PerformClick()
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim STV As String = "%"
        Dim DocType As String = ""
        Dim Claim As Integer = 0
        If chkPurchase.Checked = True Then
            DocType = "Purchase"
        Else
            DocType = "%"
        End If

        If chkClaim.Checked = True Then
            Claim = 1
        Else
            Claim = 0
        End If

        Dim tbpid As DataTable = SQLData("select id from Products where code='" & txtprid.Text & "'")
        If tbpid.Rows.Count = 0 Then
            MsgBox("Product not found")
            txtprid.SelectAll()
            txtprid.Select()
            Return
        End If
        Dim pid As String = tbpid.Rows(0)("id")
        Dim tbl As DataTable
        If chkSTV.Checked = True Then



            tbl = SQLData("SELECT *,SUM(QTYIN) OVER (ORDER BY DATE,DOC)-SUM(QTYOUT) OVER (ORDER BY DATE,DOC) BAL FROM (
SELECT 
		'" & dStart.Value.ToString("d") & "' DATE,'OE' TYPE,0 DOC,0 ACID,'OPENNING STOCK' SUBSIDARY,'' Description
		,ISNULL(SUM(CASE WHEN TYPE IN ('PURCHASE','SALE RETURN') THEN QTY ELSE 0 END),0)-ISNULL(SUM(CASE WHEN TYPE IN ('SALE','PURCHASE RETURN') THEN QTY ELSE 0 END),0) QTYIN
		,0 QTYOUT,0 Rate,0 NetRate,0 PROFIT,'' DEPARTMENT,'' DEPARTMENT2, '' ISCLAIM
		FROM PSProduct 
        WHERE PRID=" & pid & " AND DATE<'" & dStart.Value.ToString("d") & "'
UNION ALL
select 
	ps.Date
	,ps.TYPE
	,ps.DOC
	,isnull(ps.acid,'') ACID
	,isnull(Subsidary,'Transfered From '+department+' TO '+department2) Subsidary
	,Description 
	,CASE WHEN (ps.TYPE IN ('PURCHASE')) OR (ps.TYPE='STOCK TRANSFER' AND department2 LIKE '" & txtLocation.Text & "%') THEN Qty+isnull(SCHPC,0) ELSE 0 END QTYIN
	,CASE WHEN (ps.TYPE IN ('SALE')) OR (ps.TYPE='STOCK TRANSFER' AND department LIKE '" & txtLocation.Text & "%') THEN Qty+isnull(SCHPC,0) ELSE 0 END QTYOUT
	,isnull(ps.Rate,0),isnull(ROUND(VIST/case when (QTY+SCHPC)<>0 then (QTY+SCHPC) else 1 end,2),0) NetRate, isnull(profit,0)
	,department Location
	,ISNULL(department2,'') Location2
	,isnull(isclaim,0) IsClaim
	from PSProduct ps 
	left join PSDetail pd on ps.type=pd.type and ps.doc=pd.Doc
	left join coa a on ps.acid=a.Id 
	where ps.date>='" & dStart.Value.ToString("d") & "'
	and ps.date<='" & dEnd.Value.ToString("d") & "'
	and isnull(ps.Acid,0) like '" & txtCustID.Text & "%'
	and ps.type like '" & DocType & "%'
	and isnull(isclaim,0) = " & Claim & "
	and (isnull(department2,'') like '" & txtLocation.Text & "%' OR department LIKE '" & txtLocation.Text & "%')
	AND PRID=" & pid & "
	) x order by Date")
        Else
            tbl = SQLData("SELECT *,SUM(QTYIN) OVER (ORDER BY DATE,DOC)-SUM(QTYOUT) OVER (ORDER BY DATE,DOC) BAL FROM (
SELECT 
		'" & dStart.Value.ToString("d") & "' DATE,'OE' TYPE,0 DOC,0 ACID,'OPENNING STOCK' SUBSIDARY,'' Description, 0 OrderQty
		,ISNULL(SUM(CASE WHEN TYPE IN ('PURCHASE','SALE RETURN') THEN QTY ELSE 0 END),0)-ISNULL(SUM(CASE WHEN TYPE IN ('SALE','PURCHASE RETURN') THEN QTY ELSE 0 END),0) QTYIN
		,0 QTYOUT,0 Rate,0 NetRate,0 PROFIT,'' DEPARTMENT,'' DEPARTMENT2, '' ISCLAIM
		FROM PSProduct 
        WHERE PRID=" & pid & " AND DATE<'" & dStart.Value.ToString("d") & "'
UNION ALL
select 
	ps.Date
	,ps.TYPE
	,ps.DOC
	,isnull(ps.acid,'') ACID
	,isnull(Subsidary,'Transfered From '+department+' TO '+department2) Subsidary
	,Description 
	,isnull(qty2,0)+isnull(schpc,0) OrderQty
        ,CASE WHEN (ps.TYPE IN ('PURCHASE')) OR (ps.TYPE='STOCK TRANSFER' AND department2 LIKE '" & txtLocation.Text & "%') THEN Qty+isnull(SCHPC,0) ELSE 0 END QTYIN
	,CASE WHEN (ps.TYPE IN ('SALE')) OR (ps.TYPE='STOCK TRANSFER' AND department LIKE '" & txtLocation.Text & "%') THEN Qty+isnull(SCHPC,0) ELSE 0 END QTYOUT
	,isnull(ps.Rate,0),isnull(ROUND(VIST/case when (QTY+SCHPC)<>0 then (QTY+SCHPC) else 1 end,2),0) NetRate, isnull(profit,0)
	,department Location
	,ISNULL(department2,'') Location2
	,isnull(isclaim,0) IsClaim
	from PSProduct ps 
	left join PSDetail pd on ps.type=pd.type and ps.doc=pd.Doc
	left join coa a on ps.acid=a.Id 
	where ps.date>='" & dStart.Value.ToString("d") & "'
	and ps.date<='" & dEnd.Value.ToString("d") & "'
	and isnull(ps.Acid,0) like '" & txtCustID.Text & "%'
	and ps.type like '" & DocType & "%'
	and isnull(isclaim,0) = " & Claim & "
	and (isnull(department2,'') like '" & txtLocation.Text & "%' OR department LIKE '" & txtLocation.Text & "%')
	AND PRID=" & pid & " and PS.type not like 'STOCK%'
	) x order by Date")


        End If

    End Sub

End Class
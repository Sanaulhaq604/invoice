Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net.Mail
Imports System.ComponentModel

Public Class frmPurchase

    Public Property pridcode As String = ""

    Dim OldPurchaseRate = 0
    Dim SchOnQty As Integer = 0
    Dim SchPcsQty As Integer = 0
    Dim BillQty As Integer = 0
    Dim psproductid As Integer = 0
    Dim sid As Integer = 0
    Dim pBal As Integer = 0
    Dim dn As Integer = 0
    Dim NProfit As Integer = 0
    Dim OldPRID As String = ""
    Dim varVIST As Integer = 0
    Dim LastPurchaseRate As Integer = 0
    Dim NewItem As Boolean = True
    Dim ITEMNO As Integer = 0
    Dim NewDocument As Boolean = True
    Dim oldQty As Double = 0
    ReadOnly cryRPT As New ReportDocument
    Public LastInvoiceNumber As String

    Public Sub PDFGen(FileName)

        Try
            cryRPT.Load(settings("Reports Folder") + "Purchase3A5.rpt")
            'cryRPT.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In cryRPT.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            cryRPT.SetParameterValue("DocNumber", txtInvoice.Text)
            cryRPT.SetParameterValue("PreBalance", 1)
            cryRPT.SetParameterValue("CompanyName", 0)

            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            CrDiskFileDestinationOptions.DiskFileName = FileName

            CrExportOptions = cryRPT.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            cryRPT.Export()
            'cryRPT.PrintToPrinter(1, False, 0, 0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Sub SAVE()
        Dim SCHM As Integer = 0
        Dim CLM As Integer = 0
        Dim GrossAmount As Integer = Val(txtQty.Text) * Val(txtRate.Text)
        Dim ItemNetTotal As Integer = GrossAmount - (Val(txtDiscAmount.Text) + Val(txtDis2Amount.Text))
        Dim UpdatePsProductQuery As String = ""
        Dim UpdateStockQuery As String = ""
        If NewDocument = True Then
            'Or Val(txtInvoice.Text) = LastInvoiceNumber Then
            DNum()
            NewDocument = False
        End If
        'If Val(txtOQty.Text) < Val(txtQty.Text) Then
        '    txtOQty.Text = txtQty.Text
        'End If


        If chkClaim.Checked = True Then
            CLM = 1
        Else
            CLM = 0
        End If

        If chkScheme.Checked = True Then
            SCHM = 1
        Else
            SCHM = 0
        End If

        If psproductid = 0 Then

            UpdatePsProductQuery = String.Format("insert into psproduct (date,doc,Type,Type2,Prid,ACID,qty2,QTY,RATE,VEST,DISCP,DISCOUNT,DISCP2,DISCOUNT2,VIST,SellingType,SchPc,Sch,Department,Profit,isClaim,SPO) 
                                    values('" & dtpText.Value.ToString("d") & "'," & Val(dn) & ",'Purchase','Out',( select id from products where code='" & txtPRID.Text & "' )," & Val(txtCustomerID.Text) & ", " & Val(txtOQty.Text) & " ,  " & Val(txtQty.Text) & ", " & Val(txtRate.Text) & ", " & GrossAmount & " ," & Val(txtDiscP.Text) & "  ,  " & Val(txtDiscAmount.Text) & ", " & Val(txtDisc2p.Text) & ", " & Val(txtDis2Amount.Text) & ", " & ItemNetTotal & ",'DEFAULT', " & Val(txtSchPcs.Text) & "," & SCHM & " , '" & cmbLocation.Text & "'," & Val(txtProfit.Text) & "," & CLM & ",'" & cmbSPO.Text & "' )
                                                    ")


            'SQLData("update products set StockQty=isnull(StockQty,0)+" & txtTotalQty.Text & " where code='" & txtPRID.Text & "'")
        Else
            UpdatePsProductQuery = String.Format("Update psproduct set date='" & dtpText.Value.ToString("d") & "',doc=" & Val(dn) & ",Type='Purchase',Type2='OUT',Prid=( SELECT ID FROM PRODUCTS WHERE CODE='" & txtPRID.Text & "' ),ACID=" & txtCustomerID.Text & ",QTY=" & Val(txtQty.Text) & ",QTY2=" & Val(txtOQty.Text) & ",RATE=" & Val(txtRate.Text) & ",VEST=" & GrossAmount & ",DISCP=" & Val(txtDiscP.Text) & ",DISCOUNT=" & Val(txtDiscAmount.Text) & ",DISCP2=" & Val(txtDisc2p.Text) & ",DISCOUNT2=" & Val(txtDis2Amount.Text) & ",VIST=" & Numbers(txtNetAmount.Text) & ",SellingType='DEFAULT',SchPc=" & Val(txtSchPcs.Text) & ",Sch=" & SCHM & ",Department='" & cmbLocation.Text & "',Profit=" & Val(txtProfit.Text) & ",isClaim=" & CLM & ",SPO='" & cmbSPO.Text & "' Where id=" & psproductid)
            'SQLData("update products set stockqty=isnull(stockqty,0)+" & txtTotalQty.Text & "-(select top 1 qty from psproduct ps Where id=" & psproductid & " ) WHERE CODE='" & txtPRID.Text & "'  ")
        End If
        SQLData(UpdatePsProductQuery)
        'If chkClaim.Checked = False Then
        '    Dim newQty As Double = 0
        '    Dim StockQtyChange As Double = 0
        '    Double.TryParse(txtTotalQty.Text, newQty)
        '    StockQtyChange = newQty - oldQty
        '    If StockQtyChange <> 0 Then
        '        SQLData("update products set stockqty=stockqty+" & StockQtyChange & " where code='" & txtPRID.Text & "' ")
        '    End If
        '    oldQty = 0
        'End If
        If chkClaim.Checked = False Then
            SQLData("update products set StockQty=isnull(StockQty,0)+" & txtTotalQty.Text & " where code='" & txtPRID.Text & "'")
        ElseIf chkClaim.Checked = True Then
            SQLData("update products set ClaimStock=isnull(ClaimStock,0)+" & txtTotalQty.Text & " where code='" & txtPRID.Text & "'")
        End If

        UpdateStockQuery = String.Format("
                                            If  (select count(*) from stock where type='Purchase' and doc=" & Val(dn) & " and prid=(select id from products where code='" & OldPRID & "') ) >0
                                            Begin
	                                            update stock set qty=x.Qty,pid=x.pid,date=x.date,department=x.department,prid=x.prid,producttype=x.producttype,rate=x.rate,amount=x.amount from	(
	                                            select ps.Doc,'Purchase' Type,'" & dtpText.Value.ToString("d") & "' Date,ps.department,ps.acid Pid,ps.Prid,case when ps.isclaim=1 then 'Claim' Else 'Ready' end ProductType,(sum(qty)+sum(SchPc)) Qty,  Rate   ,sum(Vist) Amount,'Default' SellingType
	                                            from PSProduct ps
	                                            where type='Purchase' and doc=" & Val(dn) & " and ps.prid=( select id from products where code='" & txtPRID.Text & "' )
	                                            group by PS.RATE,ps.Doc,ps.department,ps.acid,ps.prid,ps.isclaim) x where stock.doc=" & Val(dn) & " and stock.prid=( select id from products where code='" & OldPRID & "' )
                                            End

                                            Else 
                                            Begin
	                                            insert into stock (ID,Doc,Type,Date,Department,Pid,Prid,ProductType,Qty,Rate,Amount,SellingType)
	                                            select (select max(id)+1 from stock) id,ps.Doc,'Purchase' Type,convert(varchar,'" & dtpText.Value.ToString("d") & "',23) Date,ps.department,ps.acid Pid,ps.Prid,case when ps.isclaim=1 then 'Claim' Else 'Ready' end ProductType,(sum(qty)+sum(SchPc)) Qty, Rate   ,sum(Vist) Amount,'Default' SellingType
	                                            from PSProduct ps
	                                            where type='Purchase' and  ps.doc=" & Val(dn) & " and prid=( select id from products where code='" & txtPRID.Text & "' )
	                                            group by PS.RATE,ps.Doc,ps.department,ps.acid,ps.prid,ps.isclaim
                                            End
                                            ")
        'SQLData(UpdateStockQuery)
        OldPRID = ""
        InvoiceTotals()
        Dim cmbsp As String = ""
        If cmbSPO.Text.Length > 0 Then
            cmbsp = cmbSPO.Text
        End If


        '


        SQLData("
                                                    IF (SELECT COUNT(*) FROM PSDetail WHERE TYPE='Purchase' AND DOC=" & Val(dn) & ")=0
                                                      insert into PSDetail( Doc, Date, Type, Acid, Description, ExtraDiscountP, ExtraDiscount, Freight, Received, Amount, DueDate, PBalance, Term, Vehicle, SalesMan, goods, builty, CreditDays, PriceList, BuiltyPath, remarks)
                                                      Select  " & Val(dn) & ", '" & dtpText.Value.ToString("d") & "', 'Purchase', " & txtCustomerID.Text & ", '" & txtReference.Text & "' , " & Numbers(txtExrtaDiscountP.Text) & ", " & Numbers(txtExtraDiscountAmount.Text) & ", " & Numbers(txtFreight.Text) & ", " & Numbers(txtCashReceived.Text) & ", " & Numbers(txtNetBillAmount.Text) & ", '" & txtDueDate.Value.ToString("d") & "', " & Numbers(txtPreviousBalance.Text) & ", 'CREDIT', '" & cmbSPO.Text & "','" & txtSM.Text & "', '" & cmbGoods.Text & "','" & txtbilty.Text & "', " & txtCDays.Text & ", '" & txtCustomerPrice.Text & "', '" & txtBiltyPath.Text & "', N'" & txtRemarks.Text & "'
                                                    ELSE
                                                      begin
                                                      Update PSDetail SET Date ='" & dtpText.Value.ToString("d") & "',
                                                      Type = 'Purchase', 
                                                      Acid = " & txtCustomerID.Text & ",
                                                      Description = '" & txtReference.Text & "',
                                                      ExtraDiscountP = " & Numbers(txtExrtaDiscountP.Text) & ",
                                                      ExtraDiscount = " & Numbers(txtExtraDiscountAmount.Text) & ",
                                                      Freight = " & Numbers(txtFreight.Text) & ",
                                                      Received = " & Numbers(txtCashReceived.Text) & ",
                                                      Amount = " & Numbers(txtNetBillAmount.Text) & ",
                                                      DueDate = '" & txtDueDate.Value.ToString("d") & "',
                                                      PBalance = " & Numbers(txtPreviousBalance.Text) & ",
                                                      Term ='Credit' ,
                                                      Vehicle = '" & cmbSPO.Text & "',
                                                      SalesMan = '" & txtSM.Text & "',
                                                      goods = '" & cmbGoods.Text & "',
                                                      builty = '" & txtbilty.Text & "',
                                                      CreditDays = " & txtCDays.Text & ",
                                                      PriceList = '" & txtCustomerPrice.Text & "',
                                                      BuiltyPath = '" & txtBiltyPath.Text & "',
                                                      remarks = N'" & txtRemarks.Text & "'
                                                    WHERE PSDETAIL.TYPE ='Purchase' AND PSDETAIL.DOC=" & Val(dn) & "
                                                    End
                                                    ")
        'SQLData(UpdatePsDetailQuery)

        Dim UpdateLedgersQurey As String = String.Format("
                                                            If (SELECT COUNT(*) FROM LEDGERS WHERE TYPE='Purchase' AND DOC=" & Val(dn) & " and acid<>2 and acid<>1  and credit<>0)=0
                                                            Begin
	                                                            insert into ledgers (Acid,Date,Doc,Type,Narration,Invoice,credit,remainingamount)
	                                                            select (Acid,Date,Doc,Type,Description,doc,Amount,amount
	                                                            from PSDetail where type='Purchase' and doc=" & Val(dn) & " 
	                                                        end
                                                            ELSE
                                                            begin
	                                                            update Ledgers set Acid=x.acid,Date=x.date,Doc=x.doc,Type=x.type,Narration=x.Description,Invoice=x.doc,credit=x.amt,remainingamount=x.amt
	                                                            from (select acid,date,doc,type,Description,Amount amt from PSDetail where type='Purchase' and doc=" & Val(dn) & ") x where Ledgers.type='Purchase' and Ledgers.doc=" & Val(dn) & " and ledgers.acid=" & txtCustomerID.Text & "
                                                            end
                                                            IF (SELECT COUNT(*) FROM LEDGERS WHERE TYPE='Purchase' AND DOC=" & Val(dn) & " and acid=2)=0
                                                            Begin
	                                                            insert into ledgers (Acid,Date,Doc,Type,Narration,debit)
	                                                            select (2,Date,Doc,Type,'Purchased From :'+(select subsidary from coa where id=acid) des,Amount
	                                                            from PSDetail where type='Purchase' and doc=" & Val(dn) & "
                                                            end
                                                            ELSE

                                                            begin
	                                                            update Ledgers set Acid=x.acid,Date=x.date,Doc=x.doc,Type=x.type,Narration=x.Des,Invoice=x.doc,debit=x.amt
	                                                            from (select 2 acid,date,doc,type,'Purchased From :'+(select subsidary from coa where id=Acid) des,Amount amt from PSDetail where type='Purchase' and doc=" & Val(dn) & ") x where Ledgers.type='Purchase' and Ledgers.doc=" & Val(dn) & " and ledgers.acid=2
                                                            end

                                                        ")

        Dim UpdateLedgerQuery2 As String = String.Format("  
                                                                
                                                                delete from ledgers where type='Purchase' and doc=" & Val(dn) & " 
                                                                insert into ledgers (Acid,Date,Doc,Type,Narration,Invoice,credit,remainingamount)
	                                                            select Acid,Date,Doc,Type,Description,doc,Amount,amount
	                                                            from PSDetail where type='Purchase' and doc=" & Val(dn) & "

                                                                insert into ledgers (Acid,Date,Doc,Type,Narration,debit)
	                                                            select 2,Date,Doc,Type,'Purchased From:'+(select subsidary from coa where id=acid) des,Amount-isnull(freight,0)
	                                                            from PSDetail where type='Purchase' and doc=" & Val(dn) & "
                                                                
                                                                If isnull( (select received from psdetail where type='Purchase' and doc=" & txtInvoice.Text & "),0)<>0
                                                                begin
                                                                    insert into ledgers (Acid,Date,Doc,Type,Narration,Invoice,debit)
                                                                    Select Acid,Date,Doc,Type,'Cash Paid: '+Description,doc,received
                                                                    From PSDetail Where Type ='Purchase' and doc=" & Val(dn) & "
                                                                    insert into ledgers (Acid,Date,Doc,Type,Narration,Invoice,credit)
                                                                    Select 1,Date,Doc,Type,'Cash Paid: '+(select subsidary from coa where id=acid)+' '+ Description,doc,received
                                                                    From PSDetail Where Type ='Purchase' and doc=" & Val(dn) & "
                                                                end

                                                                If isnull( (select freight from psdetail where type='Purchase' and doc=" & txtInvoice.Text & "),0)<>0
                                                                begin
                                                                insert into ledgers (Acid,Date,Doc,Type,Narration,Invoice,credit)
                                                                Select 7,Date,Doc,Type,Description,doc,freight
                                                                From PSDetail Where Type ='Purchase' and doc=" & Val(dn) & "
                                                                end

                                                                
                                                                ")
        SQLData(UpdateLedgerQuery2)

        SQLData(
                "IF (SELECT COUNT(*) FROM PRODUCTS WHERE COMPANY LIKE 'X%' AND CODE='" & txtPRID.Text & "')>0
                UPDATE PRODUCTS SET COMPANY=SUBSTRING(COMPANY,( CHARINDEX('-',COMPANY)+1),20) FROM PRODUCTS WHERE Company LIKE 'X%' AND CODE='" & txtPRID.Text & "'
                ")


        'Catch ex As Exception
        '    MsgBox("ITEM NOT SAVED " & ex.Message)
        'End Try
        loaditems2(txtInvoice.Text)

        ClearTextBox(gbItems)
        If LastInvoiceNumber = Val(txtInvoice.Text) Then
            LastInvoiceNumber = LastInvoiceNumber + 1
        End If

        txtPRID.Select()
    End Sub

    Sub PartyDiscount(List)
        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            Dim result As DialogResult = MessageBox.Show("Do you want to change Party Discount permanently ?", "Change Discount", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If result = DialogResult.Yes Then
                SQLData(" if (select count(*) from PartyDiscount where acid=" & txtCustomerID.Text & " and company=(select company from Products where code='" & txtPRID.Text & "'))>0
                            update partydiscount set PriceList='" & List & "',discount=isnull(" & txtDisc2p.Text & ",0) where acid=" & txtCustomerID.Text & " and company=(select company from products where code='" & txtPRID.Text & "' )   
                      else
                            insert into partydiscount (ID,Acid,Company,Discount,PriceList) Values (1," & txtCustomerID.Text & ",(select company from products where code='" & txtPRID.Text & "'), isnull(" & txtDisc2p.Text & ",0) , '" & List & "')
                    ")
            End If
        End If
    End Sub


    Function Numbers(Amount As String) As Integer
        If Amount = Nothing Then
            Return 0
        End If

        If Amount = "" Or Amount = " " Then
            Return 0
        End If
        If Not IsNumeric(Amount) Then
            Return 0
        End If
        Return CDbl(Amount)


    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If Numbers(txtInvoice.Text) <> LastInvoiceNumber And txtReference.Text = "" Then
            MsgBox("Please Fill Reference Textbox")
            txtReference.Select()
            txtReference.SelectAll()

            Return
        End If

        Me.Close()
    End Sub


    Sub DNum()
        Dim dt As DataTable = SQLData("select isnull(max(doc),0)+1 from psproduct where type='Purchase'")
        If dt.Rows.Count > 0 Then
            LastInvoiceNumber = dt.Rows(0)(0)
            txtInvoice.Text = LastInvoiceNumber
            'Me.Text = txtInvoice.Text
            Me.Text = "Purchase Voucher - " + txtInvoice.Text
            dn = LastInvoiceNumber
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            btnStockUpdate.Visible = True
        Else
            btnStockUpdate.Visible = False
        End If
        DNum()
        MainPage.DocType = "Purchase"
        lblDoc.Text = "Purchase Voucher - " + MainPage.LoginDetails
        Dim dt As DataTable = SQLData("Select distinct vehicle SPO from PSDetail where type='Purchase'")
        ' dt2 = Location
        Dim dt2 As DataTable = SQLData("select distinct department Location from PSProduct where type='Purchase'")   'SPO
        cmbLocation.Items.Clear()
        cmbSPO.Items.Clear()

        For i = 0 To dt2.Rows.Count - 1
            cmbLocation.Items.Add(dt2.Rows(i)(0))

        Next
        For i = 0 To dt.Rows.Count - 1
            cmbSPO.Items.Add(dt.Rows(i)(0))
        Next

        Dim dt3 As DataTable = SQLData("Select distinct goods from PSDetail where type='Purchase'")
        For i = 0 To dt3.Rows.Count - 1
            cmbGoods.Items.Add(dt3.Rows(i)(0))
        Next


    End Sub

    Public Sub ClearTextBox(ByVal root As Control)
        psproductid = 0
        sid = 0
        LastPurchaseRate = 0

        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                If ctrl.Name = "txtnetbillamount" Then
                    MsgBox(txtNetBillAmount.Text)
                End If
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl
    End Sub

    Sub LoadDoc(DocNum As Integer)
        'clearAll()
        Dim dt As New DataTable
        'DNum()
        ' psDetail = dt
        Dim loaddt As DataTable = SQLData("SELECT PS.date,acid,a.Subsidary,A.OAddress,A.City,A.OCell,PS.AMOUNT,isnull(PS.ExtraDiscountP,0) ExtraDiscountP,isnull(PS.ExtraDiscount,0) ExtraDiscount,isnull(ps.Freight,0) Freight,isnull(PS.RECEIVED,0) Received,PS.PBALANCE,PS.VEHICLE,PS.SALESMAN,isnull(PS.BUILTY,'') Builty,PS.PRICELIST,isnull(PS.BUILTYPATH,'') builtypath,ps.Description,isnull(ps.remarks,'') remarks,A.SM,ISNULL(ps.goods,'') goods,isnull(ps.BuiltyPath,'') BuiltyPath,isnull(ps.CreditDays,0) CreditDays,ISNULL(DueDate,getdate()) DueDate FROM PSDetail PS join coa a on PS.acid=a.id WHERE TYPE='Purchase' AND DOC=" & DocNum & " AND ACID<>1", DocNum)
        If loaddt.Rows.Count > 0 Then
            NewDocument = False
            pBal = loaddt.Rows(0)("PBalance")
            txtPreviousBalance.Text = Format(pBal, "#,##0.00")
            'cmbLocation.Text=select distinct department from PSProduct where type='Purchase' order by doc desc

            'cmbSPO.Text = dt.Rows(0)("Vehicle")

            dtpText.Value = loaddt.Rows(0)(0)
            txtCustomerID.Text = loaddt.Rows(0)(1).ToString
            txtCustomerName.Text = loaddt.Rows(0)(2).ToString
            txtCustomerAddress.Text = loaddt.Rows(0)(3).ToString
            txtCustomerCity.Text = loaddt.Rows(0)(4).ToString
            txtCustomerMobile2.Text = loaddt.Rows(0)(5).ToString
            txtCustomerPrice.Text = loaddt.Rows(0)("PRICELIST").ToString
            txtFreight.Text = loaddt.Rows(0)("Freight")
            txtExrtaDiscountP.Text = loaddt.Rows(0)("ExtraDiscountP")
            txtExtraDiscountAmount.Text = loaddt.Rows(0)("ExtraDiscount")
            txtCashReceived.Text = loaddt.Rows(0)("Received")
            txtReference.Text = loaddt.Rows(0)("Description")
            txtRemarks.Text = loaddt.Rows(0)("Remarks")
            txtSM.Text = loaddt.Rows(0)("SM")
            cmbGoods.Text = loaddt.Rows(0)("Goods")
            txtbilty.Text = loaddt.Rows(0)("BUILTY")
            txtBiltyPath.Text = loaddt.Rows(0)("BuiltyPath")
            txtCDays.Text = loaddt.Rows(0)("CreditDays")
            txtDueDate.Value = loaddt.Rows(0)("DueDate")
        End If
        'If dt.Rows.Count > 0 Then
        '    NewDocument = False
        'Else
        '    NewDocument = True
        'End If

        If Val(txtInvoice.Text) = 0 Then
            MsgBox("null")
            Return
        End If

        loaditems2(Val(txtInvoice.Text))

        dn = txtInvoice.Text
        InvoiceTotals()
    End Sub

    Sub InvoiceTotals()
        ' psProduct Totals = dt3
        Dim dt3 As DataTable = SQLData("select isnull(sum(vest),0) Vest,isnull(avg(DiscP),0) DiscP,isnull(sum(discount),0) Discount,isnull(avg(DiscP2),0) DiscP2,isnull(sum(Discount2),0) Discount2,isnull(sum(vist),0) Vist,isnull(sum(profit),0) Profit from PSProduct where type='Purchase' and doc=" & txtInvoice.Text)
        If dt3.Rows.Count > 0 Then
            txtVEST.Text = Format(Math.Round(Val(dt3.Rows(0)("vest")), 0), "#,##0.00")
            txtDiscP.Text = Format(dt3.Rows(0)("discp"), "#.## ")
            txtDiscount.Text = Math.Round(dt3.Rows(0)("discount"), 0)
            txtDiscP2.Text = Format(dt3.Rows(0)("DiscP2"), "#.##")
            txtDiscount2.Text = Math.Round(dt3.Rows(0)("Discount2"), 0)
            varVIST = Val(dt3.Rows(0)("vist"))
            Dim BillAmt = Val(dt3.Rows(0)("vist")) - Val(txtFreight.Text) - Val(txtExtraDiscountAmount.Text)

            txtNetBillAmount.Text = Format(BillAmt, "#,##0.00")
            NProfit = dt3.Rows(0)("profit")
            txtNetProfit.Text = Format(NProfit - Numbers(txtExtraDiscountAmount.Text), "#,##")
            NProfit = Numbers(txtNetProfit.Text)
            If txtNetProfit.Text <> "" Then
                txtNetProfitP.Text = Format((txtNetProfit.Text / BillAmt) * 100, "#.##")

            End If
            txtNetReceivable.Text = Format(Math.Round(Val(pBal) - Val(BillAmt) - Math.Abs(Val((txtFreight.Text))) - Numbers(txtCashReceived.Text), 0), "#,##0.00")

        End If

    End Sub



    Sub loaditems2(DocNum As Integer)
        Dim con As New SqlConnection("Data Source=" & frmLogin.MySqlServer & ";Initial Catalog=AhmadInternational;User ID=sa;Password=" & MainPage.Password)
        Dim cmd As New SqlCommand()
        'cmd.CommandText = "SELECT ROW_NUMBER() over(order by ps.id) Sr,p.name+' '+p.category+' '+p.Company iname,p.Size,ps.Qty2 OQTY,ps.Qty,ps.SchPc,ps.rate,ps.vest,ps.DiscP,ps.discount,ps.DiscP2,ps.Discount2,ps.vist,PS.department Location,ps.profit,ps.isclaim claim,ps.type,p.code,ps.id,ps.sch,ps.qty+ps.schpc TotQty FROM PSProduct PS join products p on PS.prid=p.id WHERE ps.TYPE='Purchase' AND ps.DOC=" & DocNum & " AND ACID<>1 ORDER BY PS.ID"
        cmd.CommandText = "SELECT ROW_NUMBER() over(order by ps.id) Sr,p.name+' '+p.category+' '+p.Company iname,p.Size,ps.Qty2 OQTY,ps.Qty,isnull(ps.SchPc,0) SchPc, ps.qty+isnull(ps.schpc,0) TotQty  ,ps.rate,ps.vest,ps.DiscP,ps.discount,ps.DiscP2,ps.Discount2,ps.vist,PS.department Location,ps.profit,ps.isclaim claim,p.code,ps.id,isnull(ps.sch,0) sch,PS.SPO FROM PSProduct PS join products p on PS.prid=p.id WHERE ps.TYPE='Purchase' AND ps.DOC=" & DocNum & "  ORDER BY PS.ID"
        cmd.Connection = con
        Dim dt As New DataTable

        'Dim da As New SqlDataAdapter(cmd, con)
        Try
            con.Open()
            Dim READER As SqlDataReader = cmd.ExecuteReader
            dt.Load(READER)
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        dgvSale.DataSource = dt

        If dt.Rows.Count > 0 And NewItem Then
            'dgvSale.Columns("TotQty").DisplayIndex = 8
            dgvSale.FirstDisplayedScrollingRowIndex = dgvSale.Rows.Count - 1
            dgvSale.Rows(dgvSale.Rows.Count - 1).Selected = True
        End If

        If ITEMNO <> 0 Then
            dgvSale.FirstDisplayedScrollingRowIndex = ITEMNO
            dgvSale.Rows(ITEMNO).Selected = True
            ITEMNO = 0
        End If

    End Sub


    Sub LOADITEMS(DocNum As Integer)
        ' psProduct =  dt2
        Dim dt2 As DataTable = SQLData("SELECT ROW_NUMBER() over(order by ps.id) Sr,p.name+' '+p.category+' '+p.Company iname,p.Size,ps.Qty2 OQTY,ps.Qty,ps.SchPc,ps.rate,ps.vest,ps.DiscP,ps.discount,ps.DiscP2,ps.Discount2,ps.vist,PS.department Location,ps.profit,ps.isclaim claim,ps.type,p.code,ps.id,ps.sch,ps.qty+ps.schpc TotQty,s.id sid FROM PSProduct PS join products p on PS.prid=p.id left join stock s on ps.type=s.type and ps.doc=s.doc and ps.prid=s.prid WHERE ps.TYPE='Purchase' AND ps.DOC=" & DocNum & " AND ACID<>1 ORDER BY PS.ID")


        dgvSale.DataSource = dt2
        dgvSale.Columns("TotQty").DisplayIndex = 8
        If dt2.Rows.Count > 0 And NewItem Then
            dgvSale.FirstDisplayedScrollingRowIndex = dgvSale.Rows.Count - 1
            dgvSale.Rows(dgvSale.Rows.Count - 1).Selected = True
        End If
    End Sub

    Sub ItemTotals()
        Dim GrossAmount As Integer = Val(txtQty.Text) * Val(txtRate.Text)
        txtAmount.Text = Format(GrossAmount, "#,##0.00")
        txtDiscAmount.Text = GrossAmount * (Val(txtDiscP.Text) / 100)
        txtDis2Amount.Text = GrossAmount * (Val(txtDisc2p.Text) / 100)
        Dim ItemNetTotal As Integer = GrossAmount - (Val(txtDiscAmount.Text) + Val(txtDis2Amount.Text))
        Dim ItemTotalProfit As Integer = 0
        txtNetAmount.Text = Format(Math.Round(ItemNetTotal, 0), "#,##0.00")
        txtNetAmount.Text = Format(Math.Round(ItemNetTotal, 0), "#,##0.00")
        If ItemNetTotal <> 0 And Val(txtTotalQty.Text) <> 0 And Val(txtCost.Text) <> 0 Then
            txtNetSaleRate.Text = Math.Round(ItemNetTotal / Val(txtTotalQty.Text), 2)
            txtProfitPerPiece.Text = Math.Round(Val(txtNetSaleRate.Text) - Val(txtCost.Text), 2)
            ItemTotalProfit = Math.Round(Val(txtProfitPerPiece.Text) * Val(txtQty.Text), 2)
            txtProfit.Text = ItemTotalProfit
            txtProfitP.Text = Math.Round((ItemTotalProfit / ItemNetTotal) * 100, 2)
        Else
            txtNetSaleRate.Text = 0
            txtProfitPerPiece.Text = 0
            txtProfit.Text = 0
            txtProfitP.Text = 0
        End If

    End Sub

    Sub ItemsFromGrid(rows As DataGridViewRow)
        'ClearTextBox(gbItems)


        If rows.Cells("colSCHCHK").Value = 1 Then
            chkScheme.Checked = True
            chkScheme.BackColor = Color.Aqua
        Else
            chkScheme.Checked = False
            chkScheme.BackColor = Color.Transparent
        End If

        'If rows.Cells("colClaim").Value = 1 Then
        '    chkClaim.Checked = True
        '    'chkClaim.BackColor = Color.Red
        '    gbItems.BackColor = Color.Pink
        'Else
        '    chkClaim.Checked = False
        '    'chkClaim.BackColor = Color.Transparent
        '    gbItems.BackColor = Color.Moccasin
        'End If


        txtPRID.Text = rows.Cells("colCode").Value.ToString()
        itemcost(txtPRID.Text, dtpText.Value)
        txtProduct.Text = rows.Cells("colProduct").Value.ToString()
        cmbLocation.Text = rows.Cells("colLoc").Value.ToString()
        cmbSPO.Text = rows.Cells("colSPO").Value.ToString()
        txtOQty.Text = rows.Cells("colOQty").Value.ToString()
        txtQty.Text = rows.Cells("colBillQty").Value.ToString()
        txtRate.Text = rows.Cells("colRate").Value.ToString()
        txtSchPcs.Text = CInt(rows.Cells("colSch").Value)
        txtTotalQty.Text = (CInt(rows.Cells("colBillQty").Value) + CInt(rows.Cells("colSch").Value)).ToString
        txtAmount.Text = rows.Cells("colAmt").Value.ToString()
        txtDiscP.Text = rows.Cells("colDisc1p").Value.ToString()
        txtDiscAmount.Text = rows.Cells("colDis").Value.ToString()
        txtDisc2p.Text = rows.Cells("colDis2p").Value.ToString()
        txtDis2Amount.Text = rows.Cells("colDis2").Value.ToString()
        txtNetAmount.Text = Format(Val(rows.Cells("colNetAmt").Value.ToString()), "#,##0.00")
        psproductid = rows.Cells("colID").Value
        OldPRID = txtPRID.Text
        'MsgBox(psproductid, sid)
        txtProfit.Text = rows.Cells("colProfit").Value.ToString()
        txtProfitP.Text = ((Val(txtProfit.Text) / Val(txtNetAmount.Text)) * 100).ToString("0.00") + "%"

        If chkClaim.Checked = False Then
            SQLData("update products set StockQty=isnull(StockQty,0)-" & txtTotalQty.Text & " where code='" & txtPRID.Text & "'")
        ElseIf chkClaim.Checked = True Then
            SQLData("update products set ClaimStock=isnull(ClaimStock,0)-" & txtTotalQty.Text & " where code='" & txtPRID.Text & "'")
        End If

        PreviousSoldHistory(txtPRID.Text, txtCustomerID.Text)
        Dim dt As DataTable = SQLData("select ISNULL(schpc,0) SCHPC,ISNULL(schon,0) SCHON from products where code='" & txtPRID.Text & "'")
        If dt.Rows.Count > 0 Then
            txtScheme.Text = dt.Rows(0)("schon") & " + " & dt.Rows(0)("schpc")
            SchOnQty = dt.Rows(0)("schon")
            SchPcsQty = dt.Rows(0)("schpc")
        End If

        'SCHEMEQTY()

        NewItem = False
        ITEMNO = rows.Index
        txtQty.Select()
        'SendKeys.Send("{TAB}")


    End Sub

    Public Function SQLData(Q As String, Optional doc As Integer = 1) As DataTable
        Dim con As New SqlConnection("Data Source=" & frmLogin.MySqlServer & ";Initial Catalog=AhmadInternational;User ID=sa;Password=" & MainPage.Password)
        Dim cmd As String

        Dim dt As New DataTable
        cmd = Q
        Dim da As New SqlDataAdapter(cmd, con)
        'Try
        con.Open()
            da.Fill(dt)
            con.Close()
        'Catch ex As Exception
        'MessageBox.Show(ex.Message)
        'End Try
        Return dt
    End Function

    Public Function SQLDataSP(Q As String, Optional doc As Integer = 1) As DataTable
        Dim con As New SqlConnection("Data Source=" & frmLogin.MySqlServer & ";Initial Catalog=AhmadInternational;User ID=sa;Password=" & MainPage.Password)
        Dim cmd2 As New SqlCommand(Q)

        cmd2.CommandType = CommandType.StoredProcedure
        cmd2.Connection = con
        cmd2.CommandText = "SearchProduct"
        cmd2.Parameters.AddWithValue("@itm", ProductSearch.txtItem.Text)
        cmd2.Parameters.AddWithValue("@comp", ProductSearch.txtCompany.Text)
        cmd2.Parameters.AddWithValue("@cat", ProductSearch.txtCategory.Text)
        cmd2.Parameters.AddWithValue("@PP", txtCustomerID.Text)
        cmd2.Parameters.AddWithValue("@DT", dtpText.Value)
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter(cmd2)
        Try
            con.Open()
            da.Fill(dt)
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return dt
    End Function

    Private Sub txtinvoice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInvoice.KeyDown
        If Numbers(dn) <> LastInvoiceNumber And txtReference.Text = "" Then
            MsgBox("Please Fill Reference Textbox")
            txtReference.Select()
            txtReference.SelectAll()
            e.Handled = True
            Return
        End If

        If (e.KeyCode = Keys.Down) Then
            ClearTextBox(gbCustomer)
            txtInvoice.Text = txtInvoice.Text - 1
            Me.Text = "Purchase Voucher - " + txtInvoice.Text
            dn = txtInvoice.Text
            LoadDoc(CInt(txtInvoice.Text))
            e.Handled = True
            txtInvoice.SelectAll()
        End If
        If (e.KeyCode = Keys.Up) And Numbers(txtInvoice.Text) <= LastInvoiceNumber - 1 Then
            txtInvoice.Text = txtInvoice.Text + 1
            Me.Text = "Purchase Voucher - " + txtInvoice.Text
            dn = txtInvoice.Text


            ClearTextBox(gbCustomer)
            LoadDoc(CInt(txtInvoice.Text))
            e.Handled = True
            txtInvoice.SelectAll()
        End If
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            LoadDoc(CInt(txtInvoice.Text))
            txtInvoice.SelectAll()
            '     SendKeys.Send("{TAB}")
        End If
    End Sub

    'Sub saleGridFormat()


    '    dgvSale.ColumnCount = 12
    '    dgvSale.Columns(0).Width = 350
    '    dgvSale.Columns(0).Name = "Product Name"
    '    dgvSale.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
    '    'dgvSale.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue
    '    dgvSale.Columns(1).Name = "QTY"
    '    dgvSale.Columns(2).Name = "PRICE"



    'End Sub

    'Private Sub dgvSale_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvSale.CellFormatting
    '    'dgvSale.ColumnHeadersDefaultCellStyle = False

    '    dgvSale.Rows(e.RowIndex).HeaderCell.Value = e.RowIndex + 1.ToString
    'End Sub

    Private Sub dgvSale_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSale.CellDoubleClick
        If e.RowIndex >= 0 Then
            ItemsFromGrid(dgvSale.CurrentRow)
        End If
    End Sub

    Private Sub dgvSale_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvSale.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            ItemsFromGrid(dgvSale.CurrentRow)
        End If
    End Sub

    Private Sub txtCustomerID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCustomerID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCustomerID.Text <> "" Then
                '     SendKeys.Send("{tab}")

            Else
                e.Handled = True
                frmPartySearch.ShowDialog()
                txtCustomerID.Text = frmPartySearch.acID
            End If
        End If
    End Sub

    Function Amt(Number As String) As String
        Return Format(Val(Number), "#,##0.00")
    End Function

    Private Sub txtCustomerID_Leave(sender As Object, e As EventArgs) Handles txtCustomerID.Leave
        If txtCustomerID.Text <> "" Then
            SQLData("update psdetail set acid=" & txtCustomerID.Text & " where type='Purchase' and doc=" & txtInvoice.Text & "
        update psproduct set acid=" & txtCustomerID.Text & " where type='Purchase' and doc=" & txtInvoice.Text & "
        update ledgers set acid=" & txtCustomerID.Text & " where type='Purchase' and acid not in(1,2,7) and doc=" & txtInvoice.Text & "
        update stock set pid=" & txtCustomerID.Text & " where type='Purchase' and doc=" & txtInvoice.Text)

            Dim tb As DataTable = SQLData("select Subsidary, route, spo, email, OAddress, city, ocell, pricelist, urduname, ContactPerson, isnull(creditdays,0) creditdays, isnull(creditlimit,0) creditlimit,SM from coa where id=" & txtCustomerID.Text)
            Dim tb2 As DataTable = SQLData("Select ISNULL(sum(debit) - sum(Credit),0) Balance from Ledgers where acid=" & txtCustomerID.Text & " And Date<'" & dtpText.Value.ToString("d") & "'")
            'Dim tb2 As DataTable = SQLData("Select sum(debit) - sum(Credit) Balance from Ledgers where acid=" & txtCustomerID.Text & " and type+ltrim(str(doc,10))<>'Purchase'+'" & txtInvoice.Text.ToString.Trim & "'")
            If tb.Rows.Count = 0 Then

                Return
            End If

            pBal = tb2.Rows(0)("Balance")
            txtPreviousBalance.Text = Amt(tb2.Rows(0)("Balance").ToString())

            'MsgBox(pBal)

            txtCustomerName.Text = tb.Rows(0)(0)
            txtRoute.Text = tb.Rows(0)(1)
            txtEmail.Text = tb.Rows(0)(3)
            txtCustomerAddress.Text = tb.Rows(0)(4)
            txtCustomerCity.Text = tb.Rows(0)(5)
            txtCustomerMobile2.Text = tb.Rows(0)(6)
            txtCDays.Text = tb.Rows(0)("creditdays")
            txtCLimit.Text = Amt(Numbers(tb.Rows(0)("creditlimit")))
            'txtDueDate.Value = dtpText.Value.AddDays(Val(txtCDays.Text)).ToString("d")
            'txtDueDate.Value = tb.Rows(0)("DueDate")
            txtSM.Text = tb.Rows(0)("SM")
            'Dim ACIDUpdateQuery As String = String.Format("
            '                                                update Ledgers set acid= " & txtCustomerID.Text & " where type='Purchase' and doc=" & Val(dn) & " and acid<>4 and acid<>1
            '                                                update PSDetail set acid=" & txtCustomerID.Text & ",pbalance=" & pBal & " where type='Purchase' and doc=" & Val(dn) & "
            '                                                update PSProduct set acid=" & txtCustomerID.Text & " where type='Purchase' and doc=" & Val(dn) & "
            '                                                update stock set pid=" & txtCustomerID.Text & " where type='Purchase' and doc=" & Val(dn) & "
            '                                                ")
            'SQLData(ACIDUpdateQuery)
            CustomerAging(CInt(txtCustomerID.Text))



            If cmbSPO.Text = "" Then
                cmbSPO.Select()
            ElseIf cmbLocation.Text = "" Then
                cmbLocation.Select()
            Else
                txtPRID.Select()
            End If

        End If

    End Sub

    Private Sub txtPRID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPRID.KeyDown
        If chkStock.Checked = True Then
            txtOQty.TabStop = True
        Else
            txtOQty.TabStop = False
        End If
        If e.KeyCode = Keys.Enter Then
            If txtPRID.Text = "" Then
                e.Handled = True
                ProductSearch.ShowDialog()
                'MsgBox(PS.PrID)
                txtPRID.Text = ProductSearch.prIDtxt
                If txtPRID.Text <> "" Then
                    SendKeys.Send("{TAB}")
                End If
            End If
        End If
    End Sub

    Private Sub txtInvoice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInvoice.KeyPress
        If Numbers(dn) <> LastInvoiceNumber And txtReference.Text = "" Then
            MsgBox("Please Fill Reference Textbox")
            txtReference.Select()
            txtReference.SelectAll()
            e.Handled = True
            Return
        End If

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCustomerID_Enter(sender As Object, e As EventArgs) Handles txtCustomerID.Enter
        If txtCustomerID.Text = "" Then
            frmPartySearch.ShowDialog()
            txtCustomerID.Text = frmPartySearch.acID
        End If
    End Sub

    Sub ProductQtyScheme(prCode)
        Dim dt As DataTable = SQLData("select isnull(SchOn,0) SchOn,isnull(SchPcs,0) SchPcs,case when schon<>0 then round(( select PurchaseRate from products where id=sqs.prid)* SchOn/(Schon+SchPcs),2) else (select PurchaseRate from products where id=sqs.prid ) end  NetRate  
from SchQTYSlabs sqs where prid=(select id from Products where code='" & prCode & "')")
        If dt.Rows.Count > 0 Then
            dgvScheme.DataSource = dt
        Else
            If dgvScheme.Rows.Count > 0 Then
                dgvScheme.DataSource.clear()
            End If

        End If
    End Sub

    Private Sub txtPRID_Leave(sender As Object, e As EventArgs) Handles txtPRID.Leave
        If txtCustomerID.Text = "" Then
            txtCustomerID.Text = "290"
        End If
        If txtPRID.Text <> "" Then
            ItemSearch(txtPRID.Text, dtpText.Value)
            PreviousSoldHistory(txtPRID.Text, txtCustomerID.Text)
            PriceSLab()
            QTYChange()
            SCHEMEQTY()
            ProductQtyScheme(txtPRID.Text)
            SchemeRate()
            ItemTotals()
            If chkStock.Checked = True Then
                txtOQty.SelectAll()
                txtOQty.Select()
            Else
                txtQty.SelectAll()
                txtQty.Select()
            End If
        End If
    End Sub

    Sub PriceSLab()
        Dim dt As DataTable = SQLData("select Slab,QTY,Rate from QtySlab where prid=(select id from Products where code='" & txtPRID.Text & "') order by qty")
        DGVPriceSlab.DataSource = dt
        If dt.Rows.Count > 0 Then
            DGVPriceSlab.CurrentRow.Selected = False
        End If
    End Sub

    Sub PreviousSoldHistory(ProductID As String, AccountID As String)
        Dim dt As DataTable = SQLData("select top 5 ROW_NUMBER() over (order by ps.date desc) RN,ps.date,ps.doc,qty,SchPc,rate,DiscP,DiscP2,VIST,pd.ExtraDiscountP ExDisc from PSProduct ps join PSDetail pd on ps.doc=pd.doc and ps.Type=pd.Type where prid=(select id from Products where code='" & ProductID & "') and ps.acid=" & AccountID & " order by ps.date desc")
        dgvHistory.DataSource = dt
        If dt.Rows.Count > 0 Then
            LastPurchaseRate = dt.Rows(0)("rate")
        End If
    End Sub

    Sub itemcost(ItemCode As String, Searchdate As Date)
        'Dim dt As DataTable = SQLData("select id,name+' '+category+' '+company itm,COMPANY,size,packing,SchPc,Schon,PurchaseRate,salerate,SaleRate2,SaleRate3,discount,  (select ISNULL(sum(qty),0) from stock where prid=(select id from products where code='" & ItemCode & "')) stock,isnull(  (select (CASE WHEN QTY=0 THEN 0 ELSE amt/qty END ) Cost from ( select ISNULL(sum(vist),0)*((100-avg(extradiscountp))/100) amt,ISNULL(sum(qty),0)+ISNULL(sum(SchPc),0) qty,avg(pd.ExtraDiscountP) ExDisc from PSProduct p join PSDetail pd on p.doc=pd.doc and p.type=pd.type where p.type='purchase' and prid=(select id from products where code='" & ItemCode & "') and p.date=(select max(date) from PSProduct ps where ps.prid=(select id from products where code='" & ItemCode & "') and date<='" & Searchdate & "' and type='purchase') ) x),0) Cost from Products where code='" & ItemCode & "'")
        'If dt.Rows.Count > 0 Then
        '    txtCost.Text = Numbers(Val(dt.Rows(0)(13)))
        'Else
        '    txtCost.Text = 0
        'End If
        txtCost.Text = 0
    End Sub

    Sub SchemeRate()
        Dim ListRate As Double = 0
        Dim ItemList As DataTable = SQLData("Select PurchaseRate from products where code='" & txtPRID.Text & "'")
        If ItemList.Rows.Count > 0 Then
            ListRate = ItemList.Rows(0)(0)
            txtRate.Text = ListRate
        End If
        If chkScheme.Checked Then
            txtRate.Text = ListRate
        Else
            If dgvScheme.Rows.Count > 0 Then
                txtRate.Text = dgvScheme.Item("ColNetRate", 0).Value
            Else
                txtRate.Text = ListRate
            End If
        End If
    End Sub

    Sub ItemSearch(ItemCode As String, Searchdate As Date)
        'isnull((select sum(case when type in ('purchase','sale return') then qty when type in ('sale','purchase return') then qty*-1 end) from PSProduct where prid=(select id from products where code='" & ItemCode & "') and isclaim=0  and date>='2021-1-1' and date<= '" & dtpText.Value.ToString("d") & "'   ),0) STOCK ,
        Dim dt As DataTable = SQLData("select id,name+' '+category+' '+company,COMPANY,size,packing,ISNULL(SchPc,0),ISNULL(Schon,0),PurchaseRate,salerate,SaleRate2,SaleRate3,isnull(discount,0) Disct,
                                        isnull((select sum(case when type in ('purchase','sale return') then qty+isnull(schpc,0) when type in ('sale','purchase return') then (qty+isnull(schpc,0))*-1 end) from PSProduct where prid=(select id from products where code='" & ItemCode & "') and isclaim=0  and date>=isnull(stockdate,'2021-1-1') and date<=dateadd(d,1,'" & dtpText.Value.ToString("d") & "')),0) STOCK ,        

        0 Cost 
        From Products p where code='" & ItemCode & "'")


        'last
        'Dim dt As DataTable = SQLData("select id,name+' '+category+' '+company,COMPANY,size,packing,ISNULL(SchPc,0),ISNULL(Schon,0),PurchaseRate,salerate,SaleRate2,SaleRate3,isnull(discount,0) Disct,
        '0 stock,
        '(select ISNULL(amt/qty,0) Cost from ( select ISNULL(sum(vist),0)*((100-avg(extradiscountp))/100) amt,ISNULL(sum(qty),0)+ISNULL(sum(SchPc),0) qty,avg(pd.ExtraDiscountP) ExDisc from PSProduct p join PSDetail pd on p.doc=pd.doc and p.type=pd.type where p.type='purchase' and prid=(select id from products where code='" & ItemCode & "') and p.date=(select max(date) from PSProduct ps where ps.prid=(select id from products where code='" & ItemCode & "') and date<='" & Searchdate & "' and type='purchase') ) x) Cost 
        'From Products where code='" & ItemCode & "'")


        '2nd last
        '        Dim dt As DataTable = SQLData("select id,name+' '+category+' '+company,COMPANY,size,packing,ISNULL(SchPc,0),ISNULL(Schon,0),PurchaseRate,salerate,SaleRate2,SaleRate3,isnull(discount,0) Disct,
        '(select ISNULL(sum(qty),0) from stock where prid=(select id from products where code='" & ItemCode & "')) stock,
        '(select ISNULL(amt/qty,0) Cost from ( select ISNULL(sum(vist),0)*((100-avg(extradiscountp))/100) amt,ISNULL(sum(qty),0)+ISNULL(sum(SchPc),0) qty,avg(ExtraDiscountP) ExDisc from inv where type='purchase' and prid=(select id from products where code='" & ItemCode & "') and p.date=(select max(date) from PSProduct ps where ps.prid=(select id from products where code='" & ItemCode & "') and date<='" & Searchdate & "' and type='purchase') ) x) Cost 
        'from Products where code='" & ItemCode & "'")


        If dt.Rows.Count > 0 Then


            txtCost.Text = dt.Rows(0)(13)
            txtDiscP.Text = Val(dt.Rows(0)("Disct"))

            txtProduct.Text = dt.Rows(0)(1)
            txtStock.Text = dt.Rows(0)(12)

            If Val(txtStock.Text) < 0 Then
                txtStock.BackColor = Color.Red
            Else
                txtStock.BackColor = Color.White
            End If

            txtScheme.Text = dt.Rows(0)(6) & " + " & dt.Rows(0)(5)
            SchOnQty = dt.Rows(0)(6)
            SchPcsQty = dt.Rows(0)(5)

            Dim DT2 As DataTable = SQLData("SELECT ACID,COMPANY,ISNULL(DISCOUNT,0) Discount,PRICELIST FROM PARTYDISCOUNT WHERE ACID=" & txtCustomerID.Text & "AND COMPANY='" & dt.Rows(0)(2) & "'")
            If DT2.Rows.Count > 0 Then
                Dim PLIST As String = DT2.Rows(0)("PRICELIST")
                Dim DIS As Integer = DT2.Rows(0)("Discount")
                txtCustomerPrice.Text = PLIST
                txtDisc2p.Text = DT2.Rows(0)("Discount")
            End If

            'If txtCustomerPrice.Text = "P" Then

            'SchemeRate()
            'If LastPurchaseRate < Numbers(txtRate.Text) And Form3.Numbers(LastPurchaseRate) <> 0 Then
            '    txtRate.Text = LastPurchaseRate
            'End If
            'LastPurchaseRate = Numbers(txtRate.Text)

        Else
            MsgBox("Item Not Found")
            txtPRID.Text = ""
            txtPRID.SelectAll()
            txtPRID.Select()
        End If

    End Sub

    Sub PurchaseRateChange(ItemCode)

        If OldPurchaseRate <> 0 And OldPurchaseRate <> Form3.Numbers(txtRate.Text) Then
            Dim Result2 As DialogResult = MessageBox.Show("Purchase rate is Different than current price, Do you want to change prices?", "Price Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If Result2 = DialogResult.Yes And frmLogin.UserLevel.ToUpper = "ADMIN" Then
                SQLData("update Products set PurchaseRate=PurchaseRate+diff, SaleRate=SaleRate+Diff,SaleRate2=SaleRate2+diff, SaleRate3=SaleRate3+diff from (
                select " & txtRate.Text & "-purchaserate Diff from Products where code='" & ItemCode & "') x where code='" & ItemCode & "'")
                MsgBox("Price Updated")
            End If
        Else
            ' SQLData("update Products set PurchaseRate=PurchaseRate+diff, SaleRate=SaleRate+Diff,SaleRate2=SaleRate2+diff, SaleRate3=SaleRate3+diff from (
            'Select Case " & txtRate.Text & "-purchaserate Diff from Products where code='" & ItemCode & "') x where code='" & ItemCode & "'")
        End If

        'End If

        'SQLData("update products set PurchaseRate=" & txtRate.Text & " where code='" & ItemCode & "'")

    End Sub

    Private Sub txtInvoice_Leave(sender As Object, e As EventArgs) Handles txtInvoice.Leave
        'If dn <> txtInvoice.Text Then
        '    LoadDoc(txtInvoice.Text)
        '    txtInvoice.Focus()
        '    txtInvoice.SelectAll()
        'End If

        'txtInvoice.SelectAll()
    End Sub

    Private Sub txtInvoice_Enter(sender As Object, e As EventArgs) Handles txtInvoice.Enter
        txtInvoice.SelectAll()

        If txtInvoice.Text <> "" Then
            dn = txtInvoice.Text
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnPrint.Click
        If txtInvoice.Text <> LastInvoiceNumber Then
            'Dim FileName As String
            'FileName = "D:\Google Drive ai\db backup\Invoice Temp\Invoice # " & txtInvoice.Text + " " + txtCustomerName.Text & ".pdf"

            Try
                cryRPT.Load(settings("Reports Folder") + "Purchase3A5.rpt")
                'cryRPT.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
                For Each tb As Table In cryRPT.Database.Tables
                    tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                    tb.ApplyLogOnInfo(tb.LogOnInfo)
                Next
                cryRPT.SetParameterValue("DocNumber", txtInvoice.Text)
                cryRPT.SetParameterValue("PreBalance", 1)
                cryRPT.SetParameterValue("CompanyName", 0)


                'Dim CrExportOptions As ExportOptions
                'Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
                'Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                'CrDiskFileDestinationOptions.DiskFileName = FileName

                'CrExportOptions = cryRPT.ExportOptions
                'With CrExportOptions
                '    .ExportDestinationType = ExportDestinationType.DiskFile
                '    .ExportFormatType = ExportFormatType.PortableDocFormat
                '    .DestinationOptions = CrDiskFileDestinationOptions
                '    .FormatOptions = CrFormatTypeOptions
                'End With
                ''cryRPT.Export()
                cryRPT.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try






            'PDFGen(FileName)
        Else
            MsgBox("No Invoice to export!", MsgBoxStyle.Information)
        End If

        txtInvoice.Focus()
        txtInvoice.SelectAll()

    End Sub

    Private Sub txtPRID_Enter(sender As Object, e As EventArgs) Handles txtPRID.Enter
        If chkStock.Checked = True Then
            txtOQty.TabStop = True
        Else
            txtOQty.TabStop = False
        End If
        If txtPRID.Text = "" Then

            If NewItem = False Then
                NewItem = True
                Return
            End If

            ProductSearch.ShowDialog()

            'MsgBox(ProductSearch.PrID)
            txtPRID.Text = ProductSearch.prIDtxt

            If txtPRID.Text <> "" Then
                SendKeys.Send("{TAB}")
            End If
            'ProductSearch.Dispose()
            '  SendKeys.Send("{tab}")
        End If

    End Sub

    Sub CustomerAging(acc As Integer)

        Dim DT As DataTable = SQLData("SELECT date,doc,days,credit,round(credit+(bal-rt),0) Remaining 
FROM (
	select top 
			(
			SELECT  (count(*)+1) FROM (
				SELECT DATE,ACID,debit,CREDIT,SUM(credit) OVER(ORDER BY DATE DESC) RT,(SELECT SUM(credit)-SUM(debit) FROM LEDGERS WHERE ACID='" & acc & "')  BAL FROM Ledgers 
				WHERE ACID='" & acc & "' AND credit<>0 ) X WHERE X.RT<BAL
			)
	date,doc,credit,sum(credit) over(order by date desc) RT, (SELECT SUM(credit)-SUM(debit) FROM LEDGERS WHERE ACID='" & acc & "') BAL,DATEDIFF(D,DATE,GETDATE())+1 Days from ledgers where acid='" & acc & "' AND credit<>0
	) XX order by days desc")
        dgvAging.DataSource = DT
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If Numbers(txtInvoice.Text) <> LastInvoiceNumber And txtReference.Text = "" Then
            MsgBox("Please Fill Reference Textbox")
            txtReference.Select()
            txtReference.SelectAll()

            Return
        End If

        clearAll()
        txtNetBillAmount.Text = ""
        txtNetReceivable.Text = ""
        NewDocument = True
        DNum()


    End Sub

    Sub clearAll()
        'Dim inv = TXTINVOICE.TEXT
        psproductid = 0
        OldPRID = ""
        sid = 0
        pBal = 0
        NProfit = 0
        cmbGoods.Text = ""
        ClearTextBox(Me)
        'TXTINVOICE.TEXT = inv
        If dgvSale.Rows.Count > 0 Then
            dgvSale.DataSource.clear()
        End If
        If dgvHistory.Rows.Count > 0 Then
            dgvHistory.DataSource.clear()
        End If
        If dgvAging.Rows.Count > 0 Then
            dgvAging.DataSource.clear()
        End If
        If dgvScheme.Rows.Count > 0 Then
            dgvScheme.DataSource.clear()
        End If
        'TXTINVOICE.TEXT = LastInvoiceNumber
        txtInvoice.SelectAll()
        txtInvoice.Select()

    End Sub

    Private Sub txtExrtaDiscountP_Leave(sender As Object, e As EventArgs) Handles txtExrtaDiscountP.Leave
        If txtExrtaDiscountP.Text <> "" Then
            SQLData("update psdetail set ExtraDiscountP=" & txtExrtaDiscountP.Text & ",extradiscount=" & Numbers(txtExtraDiscountAmount.Text) & ",amount=" & Numbers(txtNetBillAmount.Text) & " where type='Purchase' and doc=" & dn &
                     "update ledgers set credit=" & Numbers(txtNetBillAmount.Text) & " where type='Purchase' and acid=" & txtCustomerID.Text & " and credit<>0 and doc=" & dn &
                     "update ledgers set debit=" & Numbers(txtNetBillAmount.Text) & " where type='Purchase' and acid=2 and debit<>0 and doc=" & dn &
                     "update stock set amount=" & Numbers(txtNetBillAmount.Text) & " where type='purchase' and doc=" & dn
            )
        Else
            SQLData("update psdetail Set ExtraDiscountP= 0, extradiscount = 0, amount = " & Numbers(txtNetBillAmount.Text) & " where type='Purchase' and doc=" & dn &
                    "update ledgers set credit= " & Numbers(txtNetBillAmount.Text) & " where type='Purchase' and acid=" & txtCustomerID.Text & " and credit<>0 and doc=" & dn &
                    "update ledgers set debit=" & Numbers(txtNetBillAmount.Text) & " where type='Purchase' and acid=2 and debit<>0 and doc=" & dn &
                    "update stock set amount= " & Numbers(txtNetBillAmount.Text) & "where type='purchase' and doc=" & dn
            )
        End If
    End Sub

    Private Sub cmbLocation_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbLocation.KeyDown
        If e.KeyCode = Keys.Enter Then
            '   SendKeys.Send("{TAB}")
        End If
    End Sub

    Sub QTYChange()
        Dim DT As DataTable = SQLData("select top 1 * from QTYSlab where prid=(select id from Products where code='" & txtPRID.Text & "') and qty<=" & Math.Abs(Val(txtQty.Text)) & " order by qty desc")
        Dim dtsch As DataTable
        If Numbers(txtQty.Text) <> 0 Then
            dtsch = SQLData("select top 1 isnull(SchOn,0) SchOn,isnull(SchPcs,0) SchPcs from SchQTYSlabs where schon<=ABS(" & Val(txtQty.Text) & ") and prid=(select id from products where code='" & txtPRID.Text & "') order by schon desc")

            If dtsch.Rows.Count > 0 Then
                SchOnQty = dtsch(0)("Schon")
                SchPcsQty = dtsch.Rows(0)("SchPcs")
                txtScheme.Text = SchOnQty.ToString + " + " + SchPcsQty.ToString
            Else
                SchOnQty = 0
                SchPcsQty = 0
                '  txtScheme.Text = 0.ToString + "+" + 0.ToString

            End If
        End If
    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged
        QTYChange()
        SCHEMEQTY()
        ItemTotals()
    End Sub

    Sub SCHEMEQTY()
        lblSchemeDiff.Text = 0
        lblSchemeDiff.Visible = False
        If chkScheme.Checked = False Then
            txtSchPcs.Text = 0
            txtTotalQty.Text = txtQty.Text
            Return
        End If
        BillQty = (Val(txtQty.Text))
        If SchPcsQty > 0 Then
            If BillQty < 0 Then
                txtSchPcs.Text = Math.Floor((Math.Abs(BillQty) / SchOnQty) * SchPcsQty) * -1
            ElseIf BillQty = 0 Then
                txtSchPcs.Text = 0
            Else
                txtSchPcs.Text = Math.Floor((Math.Abs(BillQty) / SchOnQty) * SchPcsQty)
                lblSchemeDiff.Text = BillQty Mod SchOnQty
                If lblSchemeDiff.Text <> 0 Then
                    lblSchemeDiff.Visible = True
                Else
                    lblSchemeDiff.Visible = False
                End If

            End If
        Else
            txtSchPcs.Text = 0
        End If
        txtTotalQty.Text = Val(txtQty.Text) + Val(txtSchPcs.Text)
    End Sub

    Private Sub chkScheme_CheckedChanged(sender As Object, e As EventArgs) Handles chkScheme.CheckedChanged
        SCHEMEQTY()
        SchemeRate()
        ItemTotals()
        txtQty.SelectAll()
        txtQty.Select()
    End Sub

    Private Sub txtRate_Enter(sender As Object, e As EventArgs) Handles txtRate.Enter
        OldPurchaseRate = Form3.Numbers(txtRate.Text)
        If Val(txtQty.Text) = 0 Or txtQty.Text = "" Then
            txtQty.Select()
        End If
        txtRate.SelectAll()
    End Sub

    Private Sub txtQty_Enter(sender As Object, e As EventArgs) Handles txtQty.Enter
        If txtTotalQty.Text = Nothing Then
            oldQty = 0
        Else
            oldQty = txtTotalQty.Text
        End If


        If txtPRID.Text = "" Then
            txtPRID.Select()
        Else
            txtQty.SelectAll()
        End If

    End Sub

    Private Sub txtRate_TextChanged(sender As Object, e As EventArgs) Handles txtRate.TextChanged, txtDiscP.TextChanged, txtDisc2p.TextChanged
        ItemTotals()
    End Sub

    Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQty.KeyDown, txtOQty.KeyDown

        If e.KeyCode = Keys.Enter And txtProduct.Text <> "" Then
            SAVE()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub DISC2P_KEYDOWN() Handles txtDisc2p.KeyDown
        PartyDiscount("P")

    End Sub

    Private Sub txtRate_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDiscP.KeyDown, txtDisc2p.KeyDown, txtRate.KeyDown
        e.Handled = True
        If e.KeyCode = Keys.Enter And Val(txtRate.Text) <> 0 Then
            '          Dim Result As DialogResult = MsgBox("Purchase rate is lower than current price, Do you want to replace price?", MessageBoxButtons.YesNo, "Price Change",)


            PurchaseRateChange(txtPRID.Text)

            SAVE()
        End If
    End Sub






    Private Sub txtDiscP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDiscP.KeyDown
        e.Handled = True
        If e.KeyCode = Keys.Enter And Val(txtDiscP.Text) <> 0 Then
            SAVE()
        End If
    End Sub

    Private Sub txtDisc2p_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDisc2p.KeyDown
        e.Handled = True
        If e.KeyCode = Keys.Enter And Val(txtDisc2p.Text) <> 0 Then
            SAVE()
        End If
    End Sub

    Sub NetBill()
        Dim BillAmt = varVIST - Numbers(txtExtraDiscountAmount.Text) - Numbers(txtFreight.Text)
        txtNetBillAmount.Text = Format(BillAmt, "#,##0.00")
        txtNetReceivable.Text = Format(Numbers(txtPreviousBalance.Text) - BillAmt + Numbers(txtCashReceived.Text), "#,##0.00")
        txtNetProfit.Text = Format(NProfit - Numbers(txtExtraDiscountAmount.Text), "#,##0.00")
        txtNetProfitP.Text = Format((Numbers(txtNetProfit.Text) / BillAmt) * 100, "0.00")
    End Sub

    Private Sub txtFreight_TextChanged(sender As Object, e As EventArgs) Handles txtFreight.TextChanged
        NetBill()

    End Sub

    Private Sub txtExrtaDiscountP_TextChanged(sender As Object, e As EventArgs) Handles txtExrtaDiscountP.KeyUp
        '    txtExtraDiscountAmount.Text = Val(txtVEST.Text) * (Val(txtExrtaDiscountP.Text) / 100)
        '    Dim BillAmt = Val(txtVEST.Text) - Val(txtFreight.Text) - Val(txtExtraDiscountAmount.Text)
        '    txtNetBillAmount.Text = Format(BillAmt, "#,##0.00")



        If Numbers(txtExrtaDiscountP.Text) = 0 Or Numbers(txtVEST.Text) = 0 Then
            txtExtraDiscountAmount.Text = 0
        Else
            txtExtraDiscountAmount.Text = Math.Round(varVIST * (Val(txtExrtaDiscountP.Text) / 100), 0)
        End If
        NetBill()
        'Dim BillAmt = Numbers(txtVEST.Text) - Numbers(txtFreight.Text) - Numbers(txtExtraDiscountAmount.Text)
        'txtNetBillAmount.Text = Format(BillAmt, "#,##0.00")
    End Sub

    Private Sub txtExtraDiscountAmount_Leave(sender As Object, e As EventArgs) Handles txtExtraDiscountAmount.KeyUp

        If Numbers(txtExtraDiscountAmount.Text) = 0 Or Numbers(txtVEST.Text) = 0 Then
            txtExrtaDiscountP.Text = 0
        Else
            Dim edp = Numbers(txtExtraDiscountAmount.Text) / varVIST
            If edp <> 0 Then
                edp = edp * 100
            End If
            txtExrtaDiscountP.Text = Format(edp, "#,##0.000")
        End If
        NetBill()
        'Dim BillAmt = Numbers(txtVEST.Text) - Numbers(txtFreight.Text) - Numbers(txtExtraDiscountAmount.Text)
        'txtNetBillAmount.Text = Format(BillAmt, "#,##0.00")
    End Sub

    Private Sub txtReference_Leave(sender As Object, e As EventArgs) Handles txtReference.Leave

        If txtReference.Text <> Nothing Then
            SQLData("update psdetail set description='" & txtReference.Text & "' where type='Purchase' and doc= " & Val(dn))
            SQLData("update ledgers set narration='" & txtReference.Text & "' where type='Purchase' and doc=" & Val(dn) & " and acid<>2")
        End If
    End Sub

    Private Sub txtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        If txtRemarks.Text <> Nothing Then
            SQLData("update psdetail set remarks=N'" & txtRemarks.Text & "' where type='Purchase' and doc= " & dn)
        End If
    End Sub

    Private Sub txtReference_Enter(sender As Object, e As EventArgs) Handles txtReference.Enter
        txtReference.SelectAll()
    End Sub

    Private Sub txtRemarks_Enter(sender As Object, e As EventArgs) Handles txtRemarks.Enter
        txtRemarks.SelectAll()
    End Sub

    Private Sub cmbSPO_Leave(sender As Object, e As EventArgs) Handles cmbSPO.Leave
        If cmbSPO.Text <> Nothing Then
            SQLData("update psdetail set Vehicle='" & cmbSPO.Text & "' where type='Purchase' and doc= " & Val(dn))
        End If
    End Sub

    Private Sub btnExp_Click(sender As Object, e As EventArgs) Handles btnExp.Click

        If txtInvoice.Text <> LastInvoiceNumber Then
            Dim FileName As String
            FileName = "D:\Google Drive ai\db backup\Invoice Temp\PURCHASE ORDER # " & txtInvoice.Text + " " + txtCustomerName.Text & ".pdf"
            PDFGen(FileName)
        Else
            MsgBox("No Invoice to export!", MsgBoxStyle.Information)
        End If
        txtInvoice.SelectAll()
        txtInvoice.Select()
    End Sub

    Private Sub dtpText_Leave(sender As Object, e As EventArgs) Handles dtpText.Leave
        Dim DATEUPDATE = String.Format("
                                        update ledgers set date='" & dtpText.Value.ToString("d") & "' WHERE TYPE='Purchase' AND DOC=" & dn & "
                                        update PSDETAIL set date='" & dtpText.Value.ToString("d") & "' WHERE TYPE='Purchase' AND DOC=" & dn & "
                                        update PSPRODUCT set date='" & dtpText.Value.ToString("d") & "' WHERE TYPE='Purchase' AND DOC=" & dn & "
                                        update STOCK set date='" & dtpText.Value.ToString("d") & "' WHERE TYPE='Purchase' AND DOC=" & dn & "
                                    ")
        SQLData(DATEUPDATE)
    End Sub

    Private Sub txtFreight_Enter(sender As Object, e As EventArgs) Handles txtFreight.Enter, txtFreight.MouseClick
        txtFreight.SelectAll()
    End Sub

    Private Sub txtFreight_Leave(sender As Object, e As EventArgs) Handles txtFreight.Leave
        If txtFreight.Text = Nothing Then
            txtFreight.Text = 0
        End If
        SQLData("
                        update psdetail set freight=" & Numbers(txtFreight.Text) & ", amount=" & Numbers(txtNetBillAmount.Text) & " where type='Purchase' and doc=" & dn & "
                        update ledgers set credit=" & Numbers(txtNetBillAmount.Text) & ",remainingamount=" & Numbers(txtNetBillAmount.Text) & " where type='Purchase' and doc=" & dn & " and acid=" & txtCustomerID.Text & "
                        update ledgers set credit=" & Numbers(txtNetBillAmount.Text) + Numbers(txtFreight.Text) & " where type='Purchase' and doc=" & dn & " and acid= 7
                                                        
                        if (select count(*) from ledgers where type='Purchase' and doc=" & dn & " and acid=7)=0
                        begin
                            insert into ledgers (acid,date,doc,type,narration,invoice,credit)
                            select 7,'" & dtpText.Value.ToString("d") & "'," & dn & ",'Purchase','" & txtReference.Text & "'," & dn & "," & Numbers(txtFreight.Text) & "
                        end
                            else
                        update ledgers set credit=" & Numbers(txtFreight.Text) & " where type='Purchase' and doc=" & dn & " and acid= 7

                                                      ")

    End Sub

    Private Sub txtExtraDiscountAmount_Leave_1(sender As Object, e As EventArgs) Handles txtExtraDiscountAmount.Leave
        SQLData("update psdetail set ExtraDiscountP=" & txtExrtaDiscountP.Text & ",extradiscount=" & Numbers(txtExtraDiscountAmount.Text) & ",amount=" & Numbers(txtNetBillAmount.Text) & " where type='Purchase' and doc=" & dn &
                     "update ledgers set credit=" & Numbers(txtNetBillAmount.Text) & " where type='Purchase' and acid=" & txtCustomerID.Text & " and doc=" & dn
            )
    End Sub

    Private Sub txtCashReceived_TextChanged(sender As Object, e As EventArgs) Handles txtCashReceived.TextChanged
        NetBill()
    End Sub

    Private Sub txtCashReceived_Leave(sender As Object, e As EventArgs) Handles txtCashReceived.Leave
        Dim CashReceivedUpdate As String = ""
        If Numbers(txtCashReceived.Text) <> 0 Then
            CashReceivedUpdate = String.Format("UPDATE PSDETAIL SET RECEIVED=" & Numbers(txtCashReceived.Text) & " WHERE TYPE='Purchase' AND DOC=" & Val(dn))
            SQLData(CashReceivedUpdate)

            CashReceivedUpdate = String.Format(" delete from ledgers where type='Purchase' and doc=" & Val(dn) & " AND debit<>0 and acid=" & txtCustomerID.Text & "
                                                 delete from ledgers where type='Purchase' and doc=" & Val(dn) & "  and acid=1               
                                                                If isnull( (select received from psdetail where type='Purchase' and doc=" & txtInvoice.Text & "),0)<>0
                                                                begin
                                                                    insert into ledgers (Acid,Date,Doc,Type,Narration,Invoice,debit)
                                                                    Select Acid,Date,Doc,Type,'Cash Paid: '+(select subsidary from coa where id=acid)+' '+ Description,doc,received
                                                                    From PSDetail Where Type ='Purchase' and doc=" & Val(dn) & "
                                                                    insert into ledgers (Acid,Date,Doc,Type,Narration,Invoice,credit)
                                                                    Select 1,Date,Doc,Type,'Cash Paid: '+(select subsidary from coa where id=acid)+' '+ Description,doc,received
                                                                    From PSDetail Where Type ='Purchase' and doc=" & Val(dn) & "
                                                                end
                                                ")
        Else
            CashReceivedUpdate = String.Format("delete from ledgers where type='Purchase' and doc=" & Val(dn) & " and debit<>0 and acid=" & Numbers(txtCustomerID.Text) & "
                                                delete from ledgers where type='Purchase' and doc=" & Val(dn) & "  and acid=1               
                                                update psdetail set received=0 where type='Purchase' and doc=" & Val(dn)
                                                )
        End If
        SQLData(CashReceivedUpdate)
        btnRefresh.Select()
    End Sub

    Private Sub chkClaim_CheckedChanged(sender As Object, e As EventArgs) Handles chkClaim.CheckedChanged
        If chkClaim.CheckState = CheckState.Checked Then
            gbItems.BackColor = Color.Red
        Else
            gbItems.BackColor = Color.Moccasin
        End If

        txtPRID.Select()

    End Sub

    Private Sub txtQty_Leave(sender As Object, e As EventArgs) Handles txtQty.Leave
        'If Val(txtOQty.Text) < Val(txtQty.Text) Then
        '    txtOQty.Text = txtQty.Text
        'End If
    End Sub

    Private Sub lblRemarks_Click(sender As Object, e As EventArgs) Handles lblRemarks.Click, Label43.Click, Label42.Click, Label44.Click

    End Sub



    Private Sub cmbGoods_Leave(sender As Object, e As EventArgs) Handles cmbGoods.Leave
        SQLData("update psdetail set goods='" & cmbGoods.Text & "' where type='Purchase' and doc=" & txtInvoice.Text)
    End Sub

    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles txtbilty.Leave, txtBiltyPath.Leave
        SQLData("update psdetail set builty='" & txtbilty.Text & "' where type='Purchase' and doc=" & txtInvoice.Text)
    End Sub

    Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles btnBiltyBrowse.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
            txtBiltyPath.Text = strFileName
            SQLData("update psdetail set BuiltyPath='" & txtBiltyPath.Text & "' where type='Purchase' and doc=" & Val(dn))
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnBiltyClear.Click
        SQLData("update psdetail set BuiltyPath='' where type='Purchase' and doc=" & Val(dn))
        txtBiltyPath.Text = ""
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim Result As DialogResult = MessageBox.Show("Do you really want to delete current Purchase Voucher", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If Result = DialogResult.No Or frmLogin.UserLevel.ToUpper <> "ADMIN" Then
            Return
        End If
        SQLData("delete from psdetail where type='purchase' and doc=" & dn &
                "delete from ledgers where type='purchase' and doc=" & dn &
                "delete from psproduct where type='purchase' and doc=" & dn &
                "delete from stock where type='purchase' and doc=" & dn
                )
        btnRefresh.PerformClick()
    End Sub

    Private Sub txtRate_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtRate.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            PurchaseRateChange(txtPRID.Text)
        End If
    End Sub

    Private Sub txtInvoice_TextChanged(sender As Object, e As EventArgs) Handles txtInvoice.TextChanged

    End Sub

    Private Sub txtOQty_TextChanged(sender As Object, e As EventArgs) Handles txtOQty.TextChanged

        If Val(txtStock.Text) < 0 Then
            txtQty.Text = Math.Abs(Val(txtStock.Text)) + Val(txtOQty.Text)
        Else
            txtQty.Text = Val(txtOQty.Text) - Val(txtStock.Text)
        End If

    End Sub

    Private Sub chkStock_CheckedChanged(sender As Object, e As EventArgs) Handles chkStock.CheckedChanged
        If chkStock.Checked = True Then
            txtOQty.TabStop = True
            txtOQty.Enabled = True
            txtOQty.Select()
            txtOQty.SelectAll()
        Else
            txtOQty.TabStop = False
            txtOQty.Enabled = False
            txtQty.Select()
            txtQty.SelectAll()
        End If
    End Sub

    Private Sub btnPurchaseList_Click(sender As Object, e As EventArgs) Handles btnPurchaseList.Click
        frmPurchaseList.ShowDialog()
        If frmPurchaseList.InvNumber <> "" Then
            txtInvoice.Text = frmPurchaseList.InvNumber
            LoadDoc(txtInvoice.Text)
            Me.Text = "Invoice - " + txtInvoice.Text
            txtInvoice.Select()
            SendKeys.Send("{enter}")
            frmPurchaseList.InvNumber = ""
        End If




    End Sub

    Private Sub cmbGoods_TextChanged(sender As Object, e As EventArgs) Handles cmbGoods.TextChanged
        Dim SELSTART As Integer = Me.cmbGoods.SelectionStart
        cmbGoods.Text = cmbGoods.Text.ToUpper()
        cmbGoods.SelectionStart = SELSTART
    End Sub

    Private Sub txtDueDate_Leave(sender As Object, e As EventArgs) Handles txtDueDate.Leave
        SQLData("update psdetail set duedate='" & txtDueDate.Value.ToString("d") & "' where type='Purchase' and doc=" & txtInvoice.Text & "   ")
    End Sub

    Private Sub txtPRID_TextChanged(sender As Object, e As EventArgs) Handles txtPRID.TextChanged

    End Sub

    Private Sub cmbSPO_TextChanged(sender As Object, e As EventArgs) Handles cmbSPO.TextChanged
        Dim SELSTART As Integer = Me.cmbSPO.SelectionStart
        cmbSPO.Text = cmbSPO.Text.ToUpper()
        cmbSPO.SelectionStart = SELSTART
    End Sub

    Private Sub cmbLocation_TextChanged(sender As Object, e As EventArgs) Handles cmbLocation.TextChanged
        Dim SELSTART As Integer = Me.cmbLocation.SelectionStart
        cmbLocation.Text = cmbLocation.Text.ToUpper()
        cmbLocation.SelectionStart = SELSTART
    End Sub

    Private Sub txtAmount_Leave(sender As Object, e As EventArgs) Handles txtAmount.Leave
        If Val(Numbers(txtTotalQty.Text)) <> 0 And Val(Numbers(txtAmount.Text)) <> 0 Then
            Dim rate As Double = Math.Round(Val(Numbers(txtAmount.Text)) / Val(Numbers(txtTotalQty.Text)), 4)
            txtRate.Text = rate
            txtQty.SelectAll()
            txtQty.Select()
        End If
    End Sub

    Private Sub txtDiscP_Validated(sender As Object, e As EventArgs) Handles txtDiscP.Validated

    End Sub

    Private Sub Button1_Click_4(sender As Object, e As EventArgs) Handles btnStockUpdate.Click

        SQLData("
WITH cte AS (
    SELECT 
        p.id,
        p.name,
        p.category,
		p.StockDate
    FROM Products p
    WHERE p.id IN (
        SELECT prid 
        FROM PsProduct 
        WHERE type = 'purchase' 
          AND doc = " & txtInvoice.Text & "
    )
)
update cte set StockDate=(select date from PSDetail where type='purchase' and doc=" & txtInvoice.Text & " );

          with StockUpdate as (
select id,name,category,company,StockQty,
isnull((
select sum(case when type in ('purchase','sale return') then qty+isnull(schpc,0) when type in ('sale','purchase return') then (qty+isnull(schpc,0))*-1 end) from PsProduct ps where ps.prid=p.id and ps.date>=p.stockdate and isclaim=0
),0) CurrentStock
from Products p where id in (select prid from PsProduct ps where type='purchase' and doc=" & txtInvoice.Text & "))
update StockUpdate set StockQty=CurrentStock
")
        txtInvoice.SelectAll()
        txtInvoice.Select()
    End Sub
End Class

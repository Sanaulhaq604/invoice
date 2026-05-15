Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


'Imports System.DirectoryServices

Public Class Form3
    Public Property pridcode As String = ""
    Public Property CustID As String = ""


    Dim EmailFileName As String = ""
    Dim Company As String = ""
    Dim SchOnQty As Integer = 0
    Dim SchPcsQty As Integer = 0
    Dim BillQty As Integer = 0
    Dim psproductid As Integer = 0
    Dim sid As Integer = 0
    Dim pBal As Integer = 0
    Dim dn As Integer = 0
    Dim NProfit As Integer = 0
    Dim OldPRID As String = ""
    Dim OldDate As Date = Date.Today
    Dim FileName As String = ""
    Dim VarRef As String = ""
    Dim NewItem As Boolean = True
    Dim ITEMNO As Integer = 0
    Dim NewDocument As Boolean = True
    Dim LastSalePrice As Integer = 0
    Dim CostPrice As Integer = 0
    Dim CusID As String = ""
    Dim oldQty As Double = 0
    ReadOnly cryRPT As New ReportDocument
    Public LastInvoiceNumber As String
    Public Property InvoiceNumber As Integer = 0


    Public Sub PDFGen(InvNo As Integer, Customer As String)



        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim InvEst As String = "Invoice "
        If txtReference.Text.ToUpper.Contains("ESTIMATE") Then
            InvEst = "Estimate "
        End If

        If DTPRuns.Value >= Convert.ToDateTime("01.06.2020") And dtpText.Value >= DTPRuns.Value Then

            cryRpt.Load(Settings("Reports Folder") + "rptInvoice3A5WithRuns.rpt")
        Else
            cryRpt.Load(Settings("Reports Folder") + "rptInvoice3A5WithRuns.rpt")
        End If
        If rdDC.Checked = True Then
            MainPage.rptName = Settings("Reports Folder") + "rptInvoiceDC.rpt"
            cryRpt.Load(MainPage.rptName)
            InvEst = "DC"
        End If
        Dim TempFolder As String = Settings("Temp Folder")
        FileName = TempFolder + InvEst & " # " & InvNo.ToString + " " + Customer & " " & Date.Now.ToString.Replace(":", ".") & ".pdf"
        EmailFileName = FileName


        With crConnectionInfo
            .ServerName = frmLogin.MySqlServer
            .DatabaseName = frmLogin.MyDataBase
            .UserID = "sa"
            .Password = MainPage.Password
        End With

        CrTables = cryRpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        Try
            cryRpt.SetParameterValue("DocNumber", InvNo)
            If chkPBal.Checked = True Then
                cryRpt.SetParameterValue("PreBalance", 1)
            Else
                cryRpt.SetParameterValue("PreBalance", 0)
            End If
            cryRpt.SetParameterValue("CompanyName", 0)
            cryRpt.SetParameterValue("RECPT", 0)
            'cryRpt.SetParameterValue("RECPT", MainPage.Rcpt)





            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            CrDiskFileDestinationOptions.DiskFileName = FileName

            CrExportOptions = cryRpt.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            cryRpt.Export()

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

    End Sub

    Public Function PDFGenF(InvNo As Integer, Customer As String) As String

        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim InvEst As String = "Invoice "
        'If txtReference.Text.ToUpper.Contains("ESTIMATE") Then
        '    InvEst = "Estimate "
        'End If

        If DTPRuns.Value >= Convert.ToDateTime("01.06.2020") And dtpText.Value >= DTPRuns.Value Then

            cryRpt.Load(Settings("Reports Folder") + "rptInvoice3A5WithRuns.rpt")
        Else
            cryRpt.Load(Settings("Reports Folder") + "rptInvoice3A5.rpt")
        End If
        If rdDC.Checked = True Then
            MainPage.rptName = Settings("Reports Folder") + "rptInvoiceClaim.rpt"
            cryRpt.Load(Settings("Reports Folder") + "rptInvoiceClaim.rpt")
        End If
        FileName = Settings("Temp Folder") + InvEst & " # " & InvNo.ToString + " " + Customer & ".pdf"



        With crConnectionInfo
            .ServerName = frmLogin.MySqlServer
            .DatabaseName = frmLogin.MyDataBase
            .UserID = "sa"
            .Password = MainPage.Password
        End With

        CrTables = cryRpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        Try
            cryRpt.SetParameterValue("DocNumber", InvNo)
            If chkPBal.Checked = True Then
                cryRpt.SetParameterValue("PreBalance", 1)
            Else
                cryRpt.SetParameterValue("PreBalance", 0)
            End If
            cryRpt.SetParameterValue("CompanyName", 0)
            cryRpt.SetParameterValue("RECPT", 0)
            'cryRpt.SetParameterValue("RECPT", MainPage.Rcpt)





            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            CrDiskFileDestinationOptions.DiskFileName = FileName

            CrExportOptions = cryRpt.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            cryRpt.Export()

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
        Return FileName
    End Function

    Sub SAVE()
        If frmLogin.UserLevel.ToUpper = "VIEWER" Then
            MsgBox("USER NOT ALLOWED")
            txtPRID.SelectAll()
            txtPRID.Select()
            Return
        End If
        If txtRate.Text = 0 Then
            MsgBox("Items with ZERO rate can not be saved, Please change rate")
            txtPRID.Select()
            txtPRID.SelectAll()
            Return
        End If
        Dim SCHM As Integer = 0
        Dim CLM As Integer = 0
        Dim GrossAmount As Integer = Val(txtQty.Text) * Val(txtRate.Text)
        Dim ItemNetTotal As Integer = GrossAmount - (Val(txtDiscAmount.Text) + Val(txtDis2Amount.Text))
        Dim UpdatePsProductQuery As String = ""
        Dim UpdateStockQuery As String = ""
        'VarRef = Regex.Unescape(txtReference.Text)
        Dim billqty As Double = txtTotalQty.Text
        If NewDocument = True Then
            DNum()
            SQLData("update docnumber set doc=(" & txtInvoice.Text & ")+1 where type='sale'")
            NewDocument = False
        End If
        If Val(txtOQty.Text) < Val(txtQty.Text) Then
            txtOQty.Text = txtQty.Text
        End If
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
        '---------------------UpDate PsProduct---------------------
        If psproductid = 0 Then
            SQLData("insert into psproduct (date,doc,Type,Type2,Prid,ACID,qty2,QTY,RATE,VEST,DISCP,DISCOUNT,DISCP2,DISCOUNT2,ESTIMATE,VIST,SellingType,SchPc,Sch,Department,Profit,isClaim,SPO,PRuns) 
                                    values( '" & dtpText.Value.ToString("d") & "'," & Val(dn) & ",'Sale','Out',( select id from products where code='" & txtPRID.Text & "' )," & Val(txtCustomerID.Text) & ", " & Val(txtOQty.Text) & " ,  " & Val(txtQty.Text) & ", " & Val(txtRate.Text) & ", " & GrossAmount & " ," & Val(txtDiscP.Text) & "  ,  " & Val(txtDiscAmount.Text) & ", " & Val(txtDisc2p.Text) & ", " & Val(txtDis2Amount.Text) & "," & Numbers(txtEstimateAmount.Text) & " ," & ItemNetTotal & ",'DEFAULT', " & Val(txtSchPcs.Text) & "," & SCHM & " , '" & cmbLocation.Text & "'," & Val(txtProfit.Text) & "," & CLM & ",'" & cmbSPO.Text & "'," & Numbers(txtPRuns.Text) & " )
                                                    ")
            SQLData("insert into psproductHistory (date,doc,Type,Type2,Prid,ACID,qty2,QTY,RATE,VEST,DISCP,DISCOUNT,DISCP2,DISCOUNT2,ESTIMATE,VIST,SellingType,SchPc,Sch,Department,Profit,isClaim,SPO,PRuns,UserName,UserLevel,EntryDate,EntryStatus) 
                                    values( '" & dtpText.Value.ToString("d") & "'," & Val(dn) & ",'Sale','Out',( select id from products where code='" & txtPRID.Text & "' )," & Val(txtCustomerID.Text) & ", " & Val(txtOQty.Text) & " ,  " & Val(txtQty.Text) & ", " & Val(txtRate.Text) & ", " & GrossAmount & " ," & Val(txtDiscP.Text) & "  ,  " & Val(txtDiscAmount.Text) & ", " & Val(txtDisc2p.Text) & ", " & Val(txtDis2Amount.Text) & "," & Numbers(txtEstimateAmount.Text) & " ," & ItemNetTotal & ",'DEFAULT', " & Val(txtSchPcs.Text) & "," & SCHM & " , '" & cmbLocation.Text & "'," & Val(txtProfit.Text) & "," & CLM & ",'" & cmbSPO.Text & "'," & Numbers(txtPRuns.Text) & " ,'" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "','SAVE')")
        Else
            SQLData("Update psproduct set date='" & dtpText.Value.ToString("d") & "',doc=" & Val(dn) & ",Type='Sale',Type2='OUT',Prid=( SELECT ID FROM PRODUCTS WHERE CODE='" & txtPRID.Text & "' ),ACID=" & txtCustomerID.Text & ",QTY=" & Val(txtQty.Text) & ",QTY2=" & Val(txtOQty.Text) & ",RATE=" & Val(txtRate.Text) & ",VEST=" & GrossAmount & ",DISCP=" & Val(txtDiscP.Text) & ",DISCOUNT=" & Val(txtDiscAmount.Text) & ",DISCP2=" & Val(txtDisc2p.Text) & ",DISCOUNT2=" & Val(txtDis2Amount.Text) & ",Estimate =" & Numbers(txtEstimateAmount.Text) & " ,    VIST=" & Numbers(txtNetAmount.Text) & ",SellingType='DEFAULT',SchPc=" & Val(txtSchPcs.Text) & ",Sch=" & SCHM & ",Department='" & cmbLocation.Text & "',Profit=" & Val(txtProfit.Text) & ",isClaim=" & CLM & ", PRuns=" & Numbers(txtPRuns.Text) & ",SPO='" & cmbSPO.Text & "' Where id=" & psproductid)
            SQLData("insert into psproductHistory (date,doc,Type,Type2,Prid,ACID,qty2,QTY,RATE,VEST,DISCP,DISCOUNT,DISCP2,DISCOUNT2,ESTIMATE,VIST,SellingType,SchPc,Sch,Department,Profit,isClaim,SPO,PRuns,UserName,UserLevel,EntryDate,EntryStatus) 
                                    values( '" & dtpText.Value.ToString("d") & "'," & Val(dn) & ",'Sale','Out',( select id from products where code='" & txtPRID.Text & "' )," & Val(txtCustomerID.Text) & ", " & Val(txtOQty.Text) & " ,  " & Val(txtQty.Text) & ", " & Val(txtRate.Text) & ", " & GrossAmount & " ," & Val(txtDiscP.Text) & "  ,  " & Val(txtDiscAmount.Text) & ", " & Val(txtDisc2p.Text) & ", " & Val(txtDis2Amount.Text) & "," & Numbers(txtEstimateAmount.Text) & " ," & ItemNetTotal & ",'DEFAULT', " & Val(txtSchPcs.Text) & "," & SCHM & " , '" & cmbLocation.Text & "'," & Val(txtProfit.Text) & "," & CLM & ",'" & cmbSPO.Text & "'," & Numbers(txtPRuns.Text) & " ,'" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "','EDIT')")
            '            If chkClaim.Checked = False Then
            'SQLData("update products set stockqty=isnull(stockqty,0)-(" & txtTotalQty.Text & "-(select ISNULL(qty,0) from psproduct ps Where id=" & psproductid & " )) WHERE CODE='" & txtPRID.Text & "'")
            '       End If
        End If
        'Dim newQty As Double = 0
        'Dim StockQtyChange As Double = 0
        'Double.TryParse(txtTotalQty.Text, newQty)
        'StockQtyChange = newQty - oldQty
        If chkClaim.Checked = False Then
            SQLData("update products set StockQty=isnull(StockQty,0)-" & billqty & " where code='" & txtPRID.Text & "'")
        ElseIf chkClaim.Checked = True Then
            SQLData("update products set ClaimStock=isnull(ClaimStock,0)-" & billqty & " where code='" & txtPRID.Text & "'")
        End If
        'oldQty = 0
        '---------------------Update Stock-------------------------
        'SQLData("If  (select count(*) from stock where type='sale' and doc=" & Val(dn) & " and prid=(select id from products where code='" & OldPRID & "') ) >0
        '                                    Begin 
        '                                    update stock set qty=x.Qty,pid=x.pid,date=x.date,department=x.department,prid=x.prid,producttype=x.producttype,rate=x.rate,amount=x.amount from	(select ps.Doc,'Sale' Type,'" & dtpText.Value.ToString("d") & "' Date,ps.department,ps.acid Pid,ps.Prid,case when ps.isclaim=1 then 'Claim' Else 'Ready' end ProductType,(ISNULL(sum(qty),0)+ISNULL(sum(SchPc),0))*-1 Qty,  Rate   ,ISNULL(sum(Vist),0) Amount,'Default' SellingType from PSProduct ps where type='sale' and doc=" & Val(dn) & " and ps.prid=( select id from products where code='" & txtPRID.Text & "' ) 	                                            group by PS.RATE,ps.Doc,ps.department,ps.acid,ps.prid,ps.isclaim) x where stock.doc=" & Val(dn) & " and stock.prid=( select id from products where code='" & OldPRID & "' )
        '                                    End
        '                                    Else 
        '                                    Begin
        '                                     insert into stock (ID,Doc,Type,Date,Department,Pid,Prid,ProductType,Qty,Rate,Amount,SellingType) select (select isnull(max(id),0)+1 from stock) id,ps.Doc,'Sale' Type,'" & dtpText.Value.ToString("d") & "' Date,ps.department,ps.acid Pid,ps.Prid,case when ps.isclaim=1 then 'Claim' Else 'Ready' end ProductType,(ISNULL(sum(qty),0)+ISNULL(sum(SchPc),0))*-1 Qty, Rate   ,ISNULL(sum(Vist),0) Amount,'Default' SellingType from PSProduct ps where type='sale' and  ps.doc=" & Val(dn) & " and prid=( select id from products where code='" & txtPRID.Text & "' )
        '                                     group by PS.RATE,ps.Doc,ps.department,ps.acid,ps.prid,ps.isclaim
        '                                    End
        '                                    ")


        OldPRID = ""
        InvoiceTotals()
        FreightUpdate()

        UpDatePsDetail2()
        LedgerUpdate()
        loaditems2(txtInvoice.Text)
        If ITEMNO <> 0 Then
            dgvSale.FirstDisplayedScrollingRowIndex = ITEMNO
            dgvSale.Rows(ITEMNO).Selected = True
            ITEMNO = 0
        End If

        ClearTextBox(gbItems)
        If LastInvoiceNumber = Val(txtInvoice.Text) Then
            LastInvoiceNumber = LastInvoiceNumber + 1
        End If

        txtPRID.Select()
    End Sub
    Sub UpDatePsDetail2()
        If Val(txtNetBillAmount.Text) = 0 Then
            'Numbers(txtNetBillAmount.text)
            lblCost.BackColor = Color.Red
        End If
        lblCost.BackColor = Color.Transparent
        SQLData("IF (SELECT COUNT(*) FROM PSDetail WHERE TYPE='SALE' AND DOC=" & Val(dn) & ")=0
                 insert into PSDetail(Doc,Date,Type,Acid,Description,ExtraDiscountP,ExtraDiscount,Freight,Received,Amount,DueDate,PBalance,Term,Vehicle,SalesMan,goods,builty,CreditDays,PriceList,BuiltyPath,remarks,GrossProfit,status)
                 SELECT 
                 " & Val(dn) & ", '" & dtpText.Value.ToString("d") & "', 'SALE', " & txtCustomerID.Text & ",  '" & txtReference.Text & "' , " & Numbers(txtExrtaDiscountP.Text) & ", " & Numbers(txtExtraDiscountAmount.Text) & ", " & Numbers(txtFreight.Text) & ", " & Numbers(txtCashReceived.Text) & ", " & CInt(txtNetBillAmount.Text) & ", '" & txtDueDate.Text & "', " & Numbers(txtPreviousBalance.Text) & ", 'CREDIT', '" & cmbSPO.Text & "','" & txtSM.Text & "', '" & cmbGoods.Text & "','" & txtbilty.Text & "', " & txtCDays.Text & ", '" & txtCustomerPrice.Text & "', '" & txtBiltyPath.Text & "', N'" & txtRemarks.Text & "'," & Numbers(txtNetProfit.Text) & ",'ESTIMATE'    
                 ELSE
                 BEGIN
                 UPDATE PSDetail SET 
                 Doc=" & Val(dn) & ",
                 Date ='" & dtpText.Value.ToString("d") & "',
                 Type = 'Sale',
                 Acid = " & txtCustomerID.Text & " ,
                 Description = '" & txtReference.Text & "' ,
                 ExtraDiscountP = " & Numbers(txtExrtaDiscountP.Text) & " ,
                 ExtraDiscount = " & Numbers(txtExtraDiscountAmount.Text) & " ,
                 Freight = " & Numbers(txtFreight.Text) & " ,
                 Received = " & Numbers(txtCashReceived.Text) & " ,
                 Amount = " & CInt(txtNetBillAmount.Text) & " ,
                 DueDate = '" & txtDueDate.Text & "' ,
                 PBalance = " & CInt(txtPreviousBalance.Text) & " ,
                 Term = 'CREDIT' ,
                 Vehicle = '" & cmbSPO.Text & "',
                 SalesMan = '" & txtSM.Text & "' ,
                 goods = '" & cmbGoods.Text & "' ,
                 builty = '" & txtbilty.Text & "' ,
                 CreditDays = " & txtCDays.Text & ",
                 PriceList =      '" & txtCustomerPrice.Text & "' ,
                 BuiltyPath =  '" & txtBiltyPath.Text & "' ,
                 remarks = N'" & txtRemarks.Text & "'  , 
                 GrossProfit = " & Numbers(txtNetProfit.Text) & "
                 WHERE PSDETAIL.TYPE='SALE' AND PSDETAIL.DOC=" & Val(dn) & "
                 END
                  ")
        SQLData("WITH CTE AS (SELECT ROW_NUMBER() OVER (ORDER BY DOC) RN,* FROM PSDetail WHERE type ='sale' and DOC=" & txtInvoice.Text & ") 
                --SELECT * FROM CTE
                DELETE FROM CTE WHERE RN=2
                    ")

        SQLData("IF (SELECT COUNT(*) FROM PSDetailHistory WHERE TYPE='SALE' AND DOC=" & Val(dn) & ")=0
                 insert into PSDetailHistory(Doc,Date,Type,Acid,Description,ExtraDiscountP,ExtraDiscount,Freight,Received,Amount,DueDate,PBalance,Term,Vehicle,SalesMan,goods,builty,CreditDays,PriceList,BuiltyPath,remarks,GrossProfit,UserName,UserLevel,EntryDate)
                 SELECT 
                 " & Val(dn) & ", '" & dtpText.Value.ToString("d") & "', 'SALE', " & txtCustomerID.Text & ",  '" & txtReference.Text & "' , " & Numbers(txtExrtaDiscountP.Text) & ", " & Numbers(txtExtraDiscountAmount.Text) & ", " & Numbers(txtFreight.Text) & ", " & Numbers(txtCashReceived.Text) & ", " & CInt(txtNetBillAmount.Text) & ", '" & txtDueDate.Text & "', " & Numbers(txtPreviousBalance.Text) & ", 'CREDIT', '" & cmbSPO.Text & "','" & txtSM.Text & "', '" & cmbGoods.Text & "','" & txtbilty.Text & "', " & txtCDays.Text & ", '" & txtCustomerPrice.Text & "', '" & txtBiltyPath.Text & "', N'" & txtRemarks.Text & "'," & Numbers(txtNetProfit.Text) & ",'" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "'    
")
    End Sub



    Sub LedgerUpdate()
        SQLData("
                 delete from ledgers where type='sale' and doc=" & Val(dn) & " 
                 insert into ledgers (Acid,Date,Doc,Type,Narration,Invoice,Debit,remainingamount)
	             select Acid,Date,Doc,Type,Description,doc,Amount,amount
	             from PSDetail where type='sale' and doc=" & Val(dn) & "

                 insert into ledgers (Acid,Date,Doc,Type,Narration,Credit,Invoice)
	             select 4,Date,Doc,Type,'Sold to:'+(select subsidary from coa where id=acid) des,Amount-isnull(freight,0),doc
	             from PSDetail where type='sale' and doc=" & Val(dn) & "
                                                                
                  If isnull( (select top 1 received from psdetail where type='sale' and doc=" & txtInvoice.Text & "),0)<>0
                  begin
                        insert into ledgers (Acid,Date,Doc,Type,Narration,Invoice,credit)
                        Select Acid,Date,Doc,Type,'Cash Recd: '+Description,doc,received
                        From PSDetail Where Type ='sale' and doc=" & Val(dn) & "
                        insert into ledgers (Acid,Date,Doc,Type,Narration,Invoice,debit)
                        Select 1,Date,Doc,Type,'Cash Recd: '+(select subsidary from coa where id=acid)+' '+ Description,doc,received
                        From PSDetail Where Type ='sale' and doc=" & Val(dn) & "
                  end

                  If isnull( (select top 1 freight from psdetail where type='sale' and doc=" & txtInvoice.Text & "),0)<>0
                  begin
                       insert into ledgers (Acid,Date,Doc,Type,Narration,Invoice,credit)
                       Select 7,Date,Doc,Type,Description,doc,freight
                       From PSDetail Where Type ='sale' and doc=" & Val(dn) & "
                  end
                       ")
    End Sub

    Function Numbers(Amount As String) As Double
        If Amount = Nothing Then
            Return 0
        End If

        If Amount = "" Or Amount = " " Then
            Return 0
        End If
        If Not IsNumeric(Amount) Then
            Return 0
        End If
        'Amount = Double.Parse(Amount)
        'Return Amount

        Return CDbl(Amount)
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        If Numbers(txtInvoice.Text) <> LastInvoiceNumber And txtReference.Text = "" Then
            MsgBox("Please Fill Reference Textbox")
            'txtReference.Select()
            'txtReference.SelectAll()

            Return
        End If

        Dim DT As DataTable = SQLData("SELECT COUNT(*) FROM PSDETAIL WHERE STATUS='ESTIMATE' AND DATE>'2024-1-1' AND DATE<'" & Date.Today & "'")
        If DT.Rows.Count > 0 Then

            If DT.Rows(0)(0) > 1 Then
                'DisappearingMsgBox.lblMsg.Text = "There are some Pending Orders, Please Wait"
                'DisappearingMsgBox.Timer1.Enabled = False
                ''DisappearingMsgBox.MdiParent = Form3
                'DisappearingMsgBox.BringToFront()
                'DisappearingMsgBox.Show()


                MsgBox("Some old estimates are still pending, Pls wait after pressing OK!")
                Dim frmInvList As New frmInvoiceList

                frmInvList.DTPStart.Value = New DateTime(2024, 1, 1)
                frmInvList.DTPEnd.Value = Date.Today.AddDays(-1)
                frmInvList.chkEstimates.Checked = True
                frmInvList.txtRoute.Text = ""
                frmInvList.txtCustomer.Text = ""
                frmInvList.txtDescription.Text = ""
                'DisappearingMsgBox.Close()
                frmInvList.ShowDialog()
                If frmInvoiceList.InvNumber <> "" Then
                    txtInvoice.Text = frmInvoiceList.InvNumber
                    LoadDoc(txtInvoice.Text)
                    Me.Text = "Invoice - " + txtInvoice.Text
                    txtInvoice.Select()
                    SendKeys.Send("{enter}")
                    frmInvoiceList.InvNumber = ""
                    Return
                End If
                frmInvList.Visible = False
                'MsgBox("PENDING ESTIMATES")
            End If
        End If

        Me.Close()
    End Sub

    Sub DNum()
        Dim dt As DataTable = SQLData("select isnull(DOC,1) from DocNumber where type='SALE'")
        If dt.Rows.Count > 0 Then
            LastInvoiceNumber = dt.Rows(0)(0)
            txtInvoice.Text = LastInvoiceNumber
            Me.Text = "Invoice - " + txtInvoice.Text
            dn = LastInvoiceNumber
        End If
        txtInvoice.Select()
        txtInvoice.SelectAll()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Controls.Add(frmLogIn.MenuStrip1)
        SQLData("delete from psproduct where doc=0")
        MainPage.DocType = "Invoice"
        'If txtInvoice.Text = "" Then
        DNum()
        'End If

        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            dgvSale.Columns("colProfit").Visible = True
            dgvSale.Columns("colPP").Visible = True
            'lblProfit.Visible = True
            txtNetProfitP.Visible = True
            txtNetProfit.Visible = True

            lblItemProfit.Visible = True
            lblCost.Visible = True
            txtCost.Visible = True
            txtProfitP.Visible = True
            txtProfit.Visible = True

            btnDelete.Enabled = True

        Else
            dgvSale.Columns("colProfit").Visible = False
            dgvSale.Columns("colPP").Visible = False
            'lblProfit.Visible = False
            txtNetProfitP.Visible = False
            txtNetProfit.Visible = False

            lblItemProfit.Visible = False
            lblCost.Visible = False
            txtCost.Visible = False
            txtProfitP.Visible = False
            txtProfit.Visible = False

            btnDelete.Enabled = False
        End If
        lblDoc.Text = "ESTIMATE - " + MainPage.LoginDetails
        lblDoc.BackColor = Color.Red
        '  saleGridFormat()


        Dim dt As DataTable = SQLData("Select distinct vehicle SPO from PSDetail where type='Sale' ORDER BY VEHICLE")
        ' dt2 = Location
        Dim dt2 As DataTable = SQLData("select distinct department Location from PSProduct where type='sale' ORDER BY DEPARTMENT")   'SPO
        cmbLocation.Items.Clear()
        cmbSPO.Items.Clear()

        For i = 0 To dt2.Rows.Count - 1
            cmbLocation.Items.Add(dt2.Rows(i)(0))

        Next
        For i = 0 To dt.Rows.Count - 1
            cmbSPO.Items.Add(dt.Rows(i)(0))
        Next

        '***************Pending Estimates***************
        Dim EstDt As DataTable = SQLData("SELECT COUNT(*) FROM PSDETAIL WHERE STATUS='ESTIMATE' AND DATE>'2024-1-1' AND DATE<'" & Date.Today & "'")
        If EstDt.Rows.Count > 0 Then

            If EstDt.Rows(0)(0) > 1 Then
                'DisappearingMsgBox.lblMsg.Text = "There are some Pending Orders, Please Wait"
                'DisappearingMsgBox.Timer1.Enabled = False
                ''DisappearingMsgBox.MdiParent = Form3
                'DisappearingMsgBox.BringToFront()
                'DisappearingMsgBox.Show()


                MsgBox("Some old estimates are still pending, Pls wait after pressing OK!")
                Dim frmInvList As New frmInvoiceList

                frmInvList.DTPStart.Value = New DateTime(2024, 1, 1)
                frmInvList.DTPEnd.Value = Date.Today.AddDays(-1)
                frmInvList.chkEstimates.Checked = True
                frmInvList.txtRoute.Text = ""
                frmInvList.txtCustomer.Text = ""
                frmInvList.txtDescription.Text = ""
                'DisappearingMsgBox.Close()
                frmInvList.ShowDialog()
                If frmInvList.InvNumber <> "" Then
                    txtInvoice.Text = frmInvList.InvNumber
                    LoadDoc(txtInvoice.Text)
                    Me.Text = "Invoice - " + txtInvoice.Text
                    txtInvoice.Select()
                    SendKeys.Send("{enter}")
                    frmInvList.InvNumber = ""
                    Return
                End If
                frmInvList.Visible = False
                'MsgBox("PENDING ESTIMATES")
            End If
        End If


        '************************************



        'Me.Opacity = 100
    End Sub

    Public Sub ClearTextBox(ByVal root As Control)
        psproductid = 0
        sid = 0
        'cmbGoods.Text = ""
        LastSalePrice = 0
        OldDate = Date.Today

        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox And ctrl.Name <> "txtEP" Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl
    End Sub

    Sub LoadDoc(DocNum As Integer)
        'clearAll()
        Dim dt As New DataTable
        'DNum()
        ' psDetail = dt
        Dim Sort As String = "ID"

        Dim loaddt As DataTable = SQLData("SELECT PS.date,acid,a.Subsidary,A.OAddress,A.City,A.OCell,PS.AMOUNT,isnull(PS.ExtraDiscountP,0) ExtraDiscountP,isnull(PS.ExtraDiscount,0) ExtraDiscount,isnull(PS.Freight,0) Freight,isnull(PS.RECEIVED,0) Received,ISNULL(PS.PBALANCE,0) PBALANCE,PS.VEHICLE,PS.SALESMAN,ISNULL(PS.BUILTY,'') BUILTY,PS.PRICELIST,isnull(PS.BUILTYPATH,'') BUILTYPATH,ISNULL(ps.Description,'') Description,isnull(ps.remarks,'') remarks,isnull(A.SM,'') SM,ISNULL(ps.goods,'') Goods,isnull(ps.BuiltyPath,0) BuiltyPath,isnull(PS.CreditDays,0) CreditDays,isnull(a.creditlimit,0) Limit,a.route,isnull(a.RunsDate,convert(datetime,'01.01.2020',104)) RDate,isnull(PS.STATUS,'') status,isnull(UrduName,'') UrduName,isnull(ContactPerson,'') ContactPerson,ISNULL(CTN,'P') CTN,ISNULL(SHOPPER,'P') SHOPPER FROM PSDetail PS join coa a on PS.acid=a.id WHERE TYPE='SALE' AND DOC=" & DocNum & " AND ACID<>1", DocNum)
        'txtInvoice.Text = MainPage.DocNumber
        Dim psp As DataTable = SQLData("select PS.*,P.BATCH from psproduct PS JOIN PRODUCTS P ON PS.PRID=P.ID where type='SALE' AND DOC=" & txtInvoice.Text & "  order by " & Sort)
        Dim HasImage As DataTable = SQLData("SELECT CASE WHEN IMAGE IS NOT NULL  THEN 'YES' ELSE 'NO' END HasReceipt FROM IMAGES.DBO.name_reciepts WHERE TYPE='SALE' AND DOC=" & txtInvoice.Text)
        If HasImage.Rows.Count > 0 Then
            If HasImage.Rows(0)("HasReceipt") = "YES" Then
                btnBiltyView.Enabled = True
            Else
                btnBiltyView.Enabled = False
            End If
        Else
            btnBiltyView.Enabled = False
        End If
        If psp.Rows.Count > 0 Then
            NewDocument = False
        Else
            NewDocument = True
        End If

        If loaddt.Rows.Count > 0 Then

            pBal = loaddt.Rows(0)("PBalance")
            txtPreviousBalance.Text = Format(pBal, "#,##0.00")

            dtpText.Value = loaddt.Rows(0)(0)
            OldDate = dtpText.Value
            txtCTN.Text = loaddt.Rows(0)("ctn")
            txtShopper.Text = loaddt.Rows(0)("SHOPPER")
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
            txtRoute.Text = loaddt.Rows(0)("Route")
            txtCLimit.Text = Amt(loaddt.Rows(0)("Limit"))
            txtDueDate.Text = dtpText.Value.AddDays(Val(txtCDays.Text)).ToString("d")
            DTPRuns.Value = loaddt.Rows(0)("RDate")
            txtUrduName.Text = loaddt.Rows(0)("UrduName")
            txtPerson.Text = loaddt.Rows(0)("ContactPerson")
            If loaddt.Rows(0)("STATUS") = "INVOICE" Then
                lblDoc.BackColor = Color.Green
                lblDoc.Text = "INVOICE - " + frmLogin.MySqlServer + " - " + frmLogin.UserLevel

            Else
                lblDoc.BackColor = Color.Red
                lblDoc.Text = "ESTIMATE - " + frmLogin.MySqlServer + " - " + frmLogin.UserLevel
            End If
        Else
            txtCustomerPrice.Text = "A"
        End If
        'If dt.Rows.Count > 0 Then
        '    NewDocument = False
        'Else
        '    NewDocument = True
        'End If
        If Val(MainPage.DocNumber) <> 0 Then
            'txtInvoice.Text = MainPage.DocNumber
        End If
        If Val(txtInvoice.Text) = 0 Then
            MsgBox("null")
            Return
        End If

        loaditems2(Val(txtInvoice.Text))
        If ITEMNO <> 0 Then
            If ITEMNO < dgvSale.Rows.Count - 1 Then

                dgvSale.FirstDisplayedScrollingRowIndex = ITEMNO
                dgvSale.Rows(ITEMNO).Selected = True
            End If
            ITEMNO = 0
        End If

        dn = txtInvoice.Text
        InvoiceTotals()
        CusID = txtCustomerID.Text
        max()
        Dim dtUser As DataTable = SQLData("Select UserName,convert(Date,EntryDate) EDate,Convert(varchar(15),convert(time,EntryDate)) ETime from psdetailHistory where type='Sale' and doc=" & txtInvoice.Text)
        If dtUser.Rows.Count > 0 Then
            txtUserName.Text = dtUser.Rows(0)("UserName")
            txtEntryDate.Text = dtUser.Rows(0)("EDate")
            txtEntryTime.Text = dtUser.Rows(0)("ETime")
        Else
            txtUserName.Text = Nothing
            txtEntryDate.Text = Nothing
            txtEntryTime.Text = Nothing
        End If
    End Sub

    'Public Function GetComputers() As String
    '    Dim result As String = ""

    '    ' Get the domin name
    '    Dim ipproperties As NetworkInformation.IPGlobalProperties = NetworkInformation.IPGlobalProperties.GetIPGlobalProperties()
    '    Dim domain As String = ipproperties.DomainName

    '    Dim domainEntry As DirectoryEntry = New DirectoryEntry("WinNT://" + domain)
    '    domainEntry.Children.SchemaFilter.Add("computer")

    '    For Each computer As DirectoryEntry In domainEntry.Children
    '        result = result & computer.Name & Environment.NewLine
    '    Next

    '    Return result

    'End Function


    Sub InvoiceTotals()
        Freightcalculations(dtpText.Value, txtNetBillAmount.Text, txtRoute.Text, txtCustomerName.Text, cmbGoods.Text, txtCustomerID.Text)

        ' psProduct Totals = dt3
        Dim dt3 As DataTable = SQLData("select isnull(sum(vest),0) Vest,isnull(avg(DiscP),0) DiscP,isnull(sum(discount),0) Discount,isnull(avg(DiscP2),0) DiscP2,isnull(sum(Discount2),0) Discount2,isnull(sum(vist),0) Vist,isnull(sum(profit),0) Profit,isnull(sum(PRuns),0) TRuns,isnull(sum(estimate),0) TEstimate from PSProduct where type='sale' and prid is not null and doc=" & txtInvoice.Text)
        If dt3.Rows.Count > 0 Then
            txtVEST.Text = Format(Math.Round(Val(dt3.Rows(0)("vest")), 0), "#,##0.00")
            txtDiscP.Text = Format(dt3.Rows(0)("discp"), "#.## ")
            txtDiscount.Text = Math.Round(dt3.Rows(0)("discount"), 0)
            txtDiscP2.Text = Format(dt3.Rows(0)("DiscP2"), "#.##")
            txtDiscount2.Text = Math.Round(dt3.Rows(0)("Discount2"), 0)
            txtTRuns.Text = dt3.Rows(0)("TRuns")

            Dim TotalEstimate = Val(dt3.Rows(0)("TEstimate")) - Val(txtFreight.Text) - Val(txtExtraDiscountAmount.Text)
            Dim BillAmt = Val(dt3.Rows(0)("vist")) - Val(txtFreight.Text) - Val(txtExtraDiscountAmount.Text)
            txtTotalEstimate.Text = Format(TotalEstimate, "#,##0.00")
            txtNetBillAmount.Text = Format(BillAmt, "#,##0.00")
            NProfit = dt3.Rows(0)("profit")
            txtNetProfit.Text = Format(NProfit - Numbers(txtExtraDiscountAmount.Text), "#,##")
            NProfit = Numbers(txtNetProfit.Text)
            If txtNetProfit.Text <> "" Then
                txtNetProfitP.Text = Format((txtNetProfit.Text / BillAmt) * 100, "#.##")

            End If
            'txtNetReceivable.Text = Format(Math.Round(Val(pBal) + Val(BillAmt) + Math.Abs(Val((txtFreight.Text))) - Numbers(txtCashReceived.Text), 0), "#,##0.00")
            txtNetReceivable.Text = Format(Math.Round(Val(pBal) + Val(BillAmt) - Numbers(txtCashReceived.Text), 0), "#,##0.00")

        End If

    End Sub



    Sub loaditems2(DocNum As Integer)
        Dim SORT As String = "PS.ID"
        If rdIDSort.Checked = True Then
            SORT = "PS.ID"
        End If
        If rdRackSort.Checked Then
            SORT = "P.Batch"
        End If
        If rdAlphabetic.Checked Then
            SORT = "P.Name"
        End If
        Dim con As New SqlConnection(MainPage.conString)
        Dim cmd As New SqlCommand()
        'cmd.CommandText = "SELECT ROW_NUMBER() over(order by ps.id) Sr,p.name+' '+p.category+' '+p.Company iname,p.Size,ps.Qty2 OQTY,ps.Qty,ps.SchPc,ps.rate,ps.vest,ps.DiscP,ps.discount,ps.DiscP2,ps.Discount2,ps.vist,PS.department Location,ps.profit,ps.isclaim claim,ps.type,p.code,ps.id,ps.sch,ps.qty+ps.schpc TotQty FROM PSProduct PS join products p on PS.prid=p.id WHERE ps.TYPE='SALE' AND ps.DOC=" & DocNum & " AND ACID<>1 ORDER BY PS.ID"
        cmd.CommandText = "SELECT ROW_NUMBER() over(order by ps.id) Sr,p.name+' '+p.category+' '+p.Company iname,p.Size,ps.Qty2 OQTY,ps.Qty,ps.SchPc, ps.qty+ps.schpc TotQty  ,ps.rate,ps.vest,ps.DiscP,ps.discount,ps.DiscP2,ps.Discount2,isnull(ps.estimate,0) Estimate,ps.vist,PS.department Location,ps.profit,CASE WHEN PROFIT<>0 and vist <>0 THEN ROUND((PROFIT/VIST),2) ELSE 0 END PP,isnull(ps.isclaim,0) claim,p.code,ps.id,ps.sch,PS.SPO,isnull(ps.pruns,0) PRuns,p.batch Rack,trim(isnull(TallyBy,'')) TallyBy,isnull(format(PackingDateTime, 'dd-MM-yy HH:mm:ss'),'') PackingDateTime FROM PSProduct PS join products p on PS.prid=p.id WHERE ps.TYPE='SALE' AND ps.DOC=" & DocNum & " AND ACID<>1  order by " & SORT
        cmd.Connection = con
        Dim dt As New DataTable

        'Dim da As New SqlDataAdapter(cmd, con)
        'Try
        con.Open()
        Dim READER As SqlDataReader = cmd.ExecuteReader
        dt.Load(READER)
        con.Close()
        'Catch ex As Exception
        'MessageBox.Show(ex.Message)
        'End Try
        dgvSale.DataSource = dt



        If dt.Rows.Count > 0 And NewItem Then
            'dgvSale.Columns("TotQty").DisplayIndex = 8
            'dgvSale.FirstDisplayedScrollingRowIndex = dgvSale.Rows.Count - 1
            'dgvSale.Rows(dgvSale.Rows.Count - 1).Selected = True
        End If



    End Sub


    Sub LOADITEMS(DocNum As Integer)
        ' psProduct =  dt2
        Dim dt2 As DataTable = SQLData("SELECT ROW_NUMBER() over(order by ps.id) Sr,p.name+' '+p.category+' '+p.Company iname,p.Size,ps.Qty2 OQTY,ps.Qty,ps.SchPc,ps.rate,ps.vest,ps.DiscP,ps.discount,ps.DiscP2,ps.Discount2,ps.vist,PS.department Location,ps.profit,ps.isclaim claim,ps.type,p.code,ps.id,ps.sch,ps.qty+ps.schpc TotQty,s.id sid FROM PSProduct PS join products p on PS.prid=p.id left join stock s on ps.type=s.type and ps.doc=s.doc and ps.prid=s.prid WHERE ps.TYPE='SALE' AND ps.DOC=" & DocNum & " AND ACID<>1 ORDER BY PS.ID")


        dgvSale.DataSource = dt2
        dgvSale.Columns("TotQty").DisplayIndex = 8
        If dt2.Rows.Count > 0 And NewItem Then
            dgvSale.FirstDisplayedScrollingRowIndex = dgvSale.Rows.Count - 1
            dgvSale.Rows(dgvSale.Rows.Count - 1).Selected = True
        End If
    End Sub

    Sub ItemTotals()
        If chkRuns.Checked = False Then
            txtPRuns.Text = 0
            txtRuns.Text = 0
        End If
        Dim GrossAmount As Integer = Val(txtQty.Text) * Val(txtRate.Text)
        txtAmount.Text = Format(GrossAmount, "#,##0.00")

        txtDis2Amount.Text = GrossAmount * (Val(txtDisc2p.Text) / 100)

        txtDiscAmount.Text = (GrossAmount - txtDis2Amount.Text) * (Val(txtDiscP.Text) / 100)

        txtPRuns.Text = Numbers(txtRuns.Text) * Numbers(txtTotalQty.Text)
        Dim ItemNetTotal As Integer = (GrossAmount - Val(txtDis2Amount.Text)) - Val(txtDiscAmount.Text)
        Dim GrossEstimate As Integer = Val(txtOQty.Text) * Val(txtRate.Text)
        Dim EstimateAmount As Integer = GrossEstimate - (GrossEstimate * (Val(txtDisc2p.Text) / 100))
        txtEstimateAmount.Text = Amt(EstimateAmount)
        Dim ItemTotalProfit As Integer = 0
        txtNetAmount.Text = Format(Math.Round(ItemNetTotal, 0), "#,##0.00")
        'txtNetAmount.Text = Format(Math.Round(ItemNetTotal, 0), "#,##0.00")
        txtERate.Text = Numbers(txtRate.Text) - ((Numbers(txtRate.Text) * Numbers(txtEP.Text)) / 100)
        'If ItemNetTotal <> 0 And Val(txtTotalQty.Text) <> 0 And Val(txtCost.Text) <> 0 Then
        If ItemNetTotal = 0 Then
            txtNetSaleRate.Text = 0
        Else
            If Val(txtTotalQty.Text) <> 0 Then

                txtNetSaleRate.Text = Math.Round(ItemNetTotal / Val(txtTotalQty.Text), 2)
            Else
                txtNetSaleRate.Text = Math.Round(ItemNetTotal, 2)
            End If
        End If

        txtProfitPerPiece.Text = Math.Round(Val(txtNetSaleRate.Text) - Val(txtCost.Text), 2)
        ItemTotalProfit = Math.Round(Val(txtProfitPerPiece.Text) * Numbers(txtQty.Text), 2)
        txtProfit.Text = ItemTotalProfit
        txtProfitP.Text = Math.Round((ItemTotalProfit / ItemNetTotal) * 100, 2)
        If Numbers(txtCost.Text) = 0 Then
            txtProfit.Text = 0
            txtProfitP.Text = 0
        End If

        'Else
        'txtNetSaleRate.Text = 0
        'txtProfitPerPiece.Text = 0
        'txtProfit.Text = 0
        'txtProfitP.Text = 0
        'End If

    End Sub

    Sub ItemsFromGrid(rows As DataGridViewRow)
        'ClearTextBox(gbItems)
        If rows.Cells("TallyBy").Value.ToString.Trim <> "" And frmLogin.UserLevel.ToUpper <> "ADMIN" Then
            MsgBox("This item is Packed By: " + rows.Cells("TallyBy").Value.ToString.Trim + " and can not be updated by current user", MsgBoxStyle.Information, "Tally By")
        End If
        If rows.Cells("colSCHCHK").Value = 1 Then
            chkScheme.Checked = True
            chkScheme.BackColor = Color.Chartreuse
        Else
            chkScheme.Checked = False
            chkScheme.BackColor = Color.Transparent
        End If

        If rows.Cells("colClaim").Value = 1 Then
            chkClaim.Checked = True
            'chkClaim.BackColor = Color.Red
            gbItems.BackColor = Color.Pink
        Else
            chkClaim.Checked = False
            'chkClaim.BackColor = Color.Transparent
            gbItems.BackColor = Color.Moccasin
        End If


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
            SQLData("update products set stockqty=stockqty+" & txtTotalQty.Text & " where code='" & txtPRID.Text & "'")
        ElseIf chkClaim.Checked = True Then
            SQLData("update products set ClaimStock=ClaimStock+" & txtTotalQty.Text & " where code='" & txtPRID.Text & "'")
        End If


        PreviousSoldHistory(txtPRID.Text, txtCustomerID.Text)
        Dim dt As DataTable = SQLData("Select ISNULL(schpc,0) SCHPC,ISNULL(schon,0) SCHON from products where code='" & txtPRID.Text & "'")
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

    'Public Function SQLData(Q As String, Optional doc As Integer = 1) As DataTable
    '    Dim con As New SqlConnection(MainPage.conString)

    '    Dim cmd As String

    '    Dim dt As New DataTable
    '    cmd = Q
    '    Dim da As New SqlDataAdapter(cmd, con)
    '    Try
    '        con.Open()
    '        da.Fill(dt)
    '        con.Close()
    '    Catch ex As Exception
    '        MessageBox.Show(Q + " " + ex.Message)
    '    End Try
    '    Return dt
    'End Function

    Public Function SQLDataSP(Q As String, Optional doc As Integer = 1) As DataTable
        Dim con As New SqlConnection(MainPage.conString)
        Dim cmd2 As New SqlCommand(Q)

        cmd2.CommandType = CommandType.StoredProcedure
        cmd2.Connection = con
        cmd2.CommandText = Q
        Dim ITEM As String = ProductSearch.txtItem.Text
        Dim COMPANY As String = ProductSearch.txtCompany.Text
        Dim CATEGORY As String = ProductSearch.txtCategory.Text
        Dim PP As String = MainPage.CustID
        Dim DTE As Date = dtpText.Value
        cmd2.Parameters.AddWithValue("@itm", ProductSearch.txtItem.Text)
        cmd2.Parameters.AddWithValue("@comp", ProductSearch.txtCompany.Text)
        If MainPage.PSERVER = "ALQASWAAUTOS" Then
            cmd2.Parameters.AddWithValue("@iCode", ProductSearch.txtiCode.Text)
        End If
        cmd2.Parameters.AddWithValue("@cat", ProductSearch.txtCategory.Text)
        cmd2.Parameters.AddWithValue("@PP", MainPage.CustID)
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

        If txtInvoice.Text = "" Then
            Return
        End If




        If Numbers(dn) <> LastInvoiceNumber And txtReference.Text = "" Then
            MsgBox("Please Fill Reference Textbox")
            'txtReference.Select()
            'txtReference.SelectAll()
            e.Handled = True
            Return
        End If

        If (e.KeyCode = Keys.Down) Then
            ClearTextBox(gbCustomer)
            txtInvoice.Text = txtInvoice.Text - 1
            Me.Text = "Invoice - " + txtInvoice.Text
            LoadDoc(CInt(txtInvoice.Text))
            e.Handled = True
            txtInvoice.SelectAll()
        End If
        If (e.KeyCode = Keys.Up) And CInt(txtInvoice.Text) <= LastInvoiceNumber - 1 Then
            txtInvoice.Text = txtInvoice.Text + 1
            Me.Text = "Invoice - " + txtInvoice.Text
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
            If frmLogin.UserLevel.ToUpper = "OPERATOR" And lblDoc.Text.ToUpper.Contains("INVOICE") Then
                MsgBox("Finalized Invoice can not be changed by this user")
                Return
            End If
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
        Return Format(Val(Number), "#,##0")
    End Function

    Private Sub txtCustomerID_Leave(sender As Object, e As EventArgs) Handles txtCustomerID.Leave
        If txtCustomerID.Text = "" Then
            Return
        End If
        CustID = txtCustomerID.Text
        If NewDocument = False Then
            If frmLogin.UserLevel.ToUpper = "ADMIN" Or dtpText.Value > DateTime.Now.Date And txtCustomerID.Text <> "" Then
                SQLData("update psdetail set acid=" & txtCustomerID.Text & ", pBalance = " & CInt(txtPreviousBalance.Text) & " where type='sale' and doc=" & txtInvoice.Text & "
                    update psproduct set acid=" & txtCustomerID.Text & " where type='sale' and doc=" & txtInvoice.Text & "
                    update ledgers set acid=" & txtCustomerID.Text & " where type='sale' and acid not in(1,4,7) and doc=" & txtInvoice.Text & "
                  --  update stock set pid=" & txtCustomerID.Text & " where type='sale' and doc=" & txtInvoice.Text)
            Else
                MsgBox("USER NOT ALLOWED")
            End If

        End If
        Dim tb As DataTable = SQLData("select Subsidary, route, spo, email, OAddress, city, ocell, pricelist, urduname, isnull(ContactPerson,'') ContactPerson, isnull(creditdays,0) creditdays, 
(SELECT ISNULL(round(SUM(CREDIT)/3,0),0) AvgRecovery FROM LEDGERS L WHERE L.ACID=" & txtCustomerID.Text & "
AND L.DATE between DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE())-3, 0)
and DATEADD(MONTH, DATEDIFF(MONTH, -1, GETDATE())-1, -1))

creditlimit,SM,isnull( RunsDate ,convert(datetime,'2020.01.01',104) ) RDate from coa where id=" & txtCustomerID.Text)
        'Dim tb2 As DataTable = SQLData("Select ISNULL(sum(debit),0) - ISNULL(sum(Credit),0) Balance from Ledgers where acid=" & txtCustomerID.Text & " And Date<'" & dtpText.Value.ToString("d") & "'")
        Dim preB As String = Amt(PreBalance(txtCustomerID.Text, dtpText.Value, "Sale", txtInvoice.Text))
        'Dim tb2 As DataTable = SQLData("Select sum(debit) - sum(Credit) Balance from Ledgers where acid=" & txtCustomerID.Text & " and type+ltrim(str(doc,10))<>'sale'+'" & txtInvoice.Text.ToString.Trim & "'")

        If tb.Rows.Count = 0 Then

            Return
        End If

        max()

        'pBal = tb2.Rows(0)("Balance")
        'txtPreviousBalance.Text = Amt(tb2.Rows(0)("Balance").ToString())
        pBal = preB
        txtPreviousBalance.Text = preB
        txtNetReceivable.Text = Amt(Numbers(preB) + Numbers(txtNetBillAmount.Text) - Numbers(txtCashReceived.Text))
        'MsgBox(pBal)

        txtCustomerName.Text = tb.Rows(0)(0)
        txtRoute.Text = tb.Rows(0)(1)
        txtEmail.Text = tb.Rows(0)(3)
        txtUrduName.Text = tb.Rows(0)("urduname")
        txtPerson.Text = tb.Rows(0)("ContactPerson")
        txtCustomerAddress.Text = tb.Rows(0)(4)
        txtCustomerCity.Text = tb.Rows(0)(5)
        txtCustomerMobile2.Text = tb.Rows(0)(6)
        txtCDays.Text = tb.Rows(0)("creditdays")
        txtCLimit.Text = Amt(Numbers(tb.Rows(0)("creditlimit")))
        txtDueDate.Text = dtpText.Value.AddDays(Val(txtCDays.Text)).ToString("d")
        txtSM.Text = tb.Rows(0)("SM")
        DTPRuns.Value = tb.Rows(0)("RDate")
        'Dim ACIDUpdateQuery As String = String.Format("
        '                                                update Ledgers set acid= " & txtCustomerID.Text & " where type='sale' and doc=" & Val(dn) & " and acid<>4 and acid<>1
        '                                                update PSDetail set acid=" & txtCustomerID.Text & ",pbalance=" & pBal & " where type='sale' and doc=" & Val(dn) & "
        '                                                update PSProduct set acid=" & txtCustomerID.Text & " where type='sale' and doc=" & Val(dn) & "
        '                                                update stock set pid=" & txtCustomerID.Text & " where type='sale' and doc=" & Val(dn) & "
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
        CompanyWiseDiscount()


    End Sub

    Sub max()

        Dim tb3 As DataTable = SQLData("Select isnull(max(debit),0) MaxBill,isnull(max(credit),0) MaxRecovery from ledgers l where acid='" & CusID & "' And Date BETWEEN  DATEADD(MONTH,-3,GETDATE()) And GETDATE()   ")
        If tb3.Rows.Count > 0 Then
            txtMaxSale.Text = Amt(tb3.Rows(0)("MaxBill"))
            txtMaxRecovery.Text = Amt(tb3.Rows(0)("MaxRecovery"))
        Else
            txtMaxRecovery.Text = 0
            txtMaxSale.Text = 0
        End If
    End Sub

    Private Sub txtPRID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPRID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPRID.Text = "" Then
                e.Handled = True
                txtRate.Text = ""
                LastSalePrice = 0


                MainPage.CustID = txtCustomerID.Text
                ProductSearch.ShowDialog()
                'MsgBox(PS.PrID)
                txtPRID.Text = ProductSearch.prIDtxt
                If txtPRID.Text <> "" Then
                    SendKeys.Send("{TAB}")
                End If
            End If
        End If




        'If e.KeyCode = Keys.Enter Then
        '    If txtPRID.Text = "" Then
        '        e.Handled = True
        '        ProductSearch.ShowDialog()
        '        'MsgBox(PS.PrID)
        '        txtPRID.Text = ProductSearch.prIDtxt
        '        If txtPRID.Text <> "" Then
        '            SendKeys.Send("{TAB}")
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub txtInvoice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInvoice.KeyPress
        If Numbers(dn) <> LastInvoiceNumber And txtReference.Text = "" Then
            MsgBox("Please Fill Reference Textbox")
            ' txtReference.Select()
            ' txtReference.SelectAll()
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

    Private Sub txtPRID_Leave(sender As Object, e As EventArgs) Handles txtPRID.Leave
        If txtCustomerID.Text = "" Then
            txtCustomerID.Text = "290"
        End If

        If txtPRID.Text <> "" Then
            MainPage.CustID = txtCustomerID.Text
            ItemSearch(txtPRID.Text, dtpText.Value)
            PreviousSoldHistory(txtPRID.Text, txtCustomerID.Text)
            PriceSLab()
            PriceLists()
            SCHEMEQTY()
            QtySalbs()
            ItemTotals()
            CompanyWiseDiscount()
            If dgvCompanyWiseDiscount.Rows.Count > 0 Then
                Dim x = -1
                For n = 1 To dgvCompanyWiseDiscount.Rows.Count - 1
                    If dgvCompanyWiseDiscount.Rows(n).Cells(0).Value = Company Then
                        x = n
                        Exit For
                    End If

                Next
                If x >= 0 Then
                    dgvCompanyWiseDiscount.Rows(x).Selected = True
                    dgvCompanyWiseDiscount.FirstDisplayedScrollingRowIndex = x
                Else
                    dgvCompanyWiseDiscount.CurrentCell = Nothing
                    If dgvCompanyWiseDiscount.Rows.Count > 0 Then
                        dgvCompanyWiseDiscount.FirstDisplayedScrollingRowIndex = 0
                    End If
                End If
            End If
            If txtProduct.Text.ToUpper.Contains("PUBLICITY") Then
                txtDisc2p.Text = "100"
            End If


            txtOQty.SelectAll()
            txtOQty.Select()

        End If

    End Sub

    Sub PriceLists()
        Dim dt As DataTable = SQLData("Select 'P' List,PurchaseRate Rate FROM Products WHERE CODE='" & txtPRID.Text & "'
                                        UNION ALL
                                        SELECT 'A',SALERATE FROM Products WHERE CODE='" & txtPRID.Text & "'
                                        UNION ALL
                                        SELECT 'B',SaleRate2 FROM Products WHERE CODE='" & txtPRID.Text & "'
                                        UNION ALL
                                        SELECT 'C',SaleRate3 FROM Products WHERE CODE='" & txtPRID.Text & "'")
        If dt.Rows.Count > 0 Then
            dgvPriceLists.DataSource = dt
            Dim plist = ""
            Dim X = -1

            For n = 0 To dgvPriceLists.Rows().Count - 1
                If dgvPriceLists.Rows(n).Cells(0).Value = txtCustomerPrice.Text Then
                    plist = dgvPriceLists.Rows(n).Cells(0).Value
                    X = n
                    Exit For
                End If

            Next
            If X > 0 Then
                dgvPriceLists.Rows(X).Selected = True
                dgvPriceLists.FirstDisplayedScrollingRowIndex = X
            Else
                dgvPriceLists.CurrentCell = Nothing
            End If
        Else
            If dgvPriceLists.Rows.Count > 0 Then
                dgvPriceLists.DataSource.clear()
            End If
        End If
    End Sub

    Sub QtySalbs()
        Dim dt As DataTable = SQLData("select schon,SchPcs from SchQTYSlabs where prid=(select id from Products where code='" & txtPRID.Text & "') order by schon")
        If dt.Rows.Count > 0 Then
            dgvQtySlabSchemes.DataSource = dt
        Else
            If dgvQtySlabSchemes.Rows.Count > 0 Then
                dgvQtySlabSchemes.DataSource.clear()
            End If

        End If
    End Sub

    Sub CompanyWiseDiscount()
        Dim dt As DataTable = SQLData("select Company,PriceList,discount from PartyDiscount where acid=" & txtCustomerID.Text & " and discount is not null order by discount desc")
        If dt.Rows.Count > 0 Then
            dgvCompanyWiseDiscount.DataSource = dt

        Else
            If dgvCompanyWiseDiscount.Rows.Count > 0 Then
                dgvCompanyWiseDiscount.DataSource.clear()
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
        Dim dt As DataTable = SQLData("select top 5 ROW_NUMBER() over (order by ps.date desc) RN,ps.date,ps.doc,qty,SchPc,rate,DiscP,DiscP2,VIST,pd.ExtraDiscountP ExDisc,ISNULL(SPO,'') SPO,ISNULL(QTY2,0) QTY2 from PSProduct ps join PSDetail pd on ps.doc=pd.doc and ps.Type=pd.Type where prid=(select id from Products where code='" & ProductID & "') and ps.acid=" & AccountID & " order by ps.date desc")
        If dt.Rows.Count <> 0 Then
            LastSalePrice = Numbers(dt.Rows(0)("rate"))
        End If

        dgvHistory.DataSource = dt

    End Sub

    Sub itemcost(ItemCode As String, Searchdate As Date)
        Dim dt As DataTable = SQLData("select id,name+' '+category+' '+company itm,COMPANY,size,packing,SchPc,Schon,PurchaseRate,salerate,SaleRate2,SaleRate3,discount,  (select ISNULL(sum(qty),0) from stock where prid=(select id from products where code='" & ItemCode & "')) stock,isnull(  (select (CASE WHEN QTY=0 THEN 0 ELSE amt/qty END ) Cost from ( select ISNULL(sum(vist),0)*((100-avg(extradiscountp))/100) amt,ISNULL(sum(qty),0)+ISNULL(sum(SchPc),0) qty,avg(pd.ExtraDiscountP) ExDisc from PSProduct p join PSDetail pd on p.doc=pd.doc and p.type=pd.type where p.type='purchase' and prid=(select id from products where code='" & ItemCode & "') and p.date=(select max(date) from PSProduct ps where ps.prid=(select id from products where code='" & ItemCode & "') and date<='" & Searchdate & "' and type='purchase') ) x),0) Cost from Products where code='" & ItemCode & "'")
        If dt.Rows.Count > 0 Then
            txtCost.Text = Numbers(Val(dt.Rows(0)(13)))
        Else
            txtCost.Text = 0
        End If
    End Sub


    Sub ProductCost2(ItemCode As String, SearchDate As Date)
        Dim clm As Integer = 0
        If chkClaim.Checked Then
            clm = 1
        Else
            clm = 0
        End If
        Dim dt As DataTable = SQLData("if (select count(*) from RateHistory where prid=(select id from Products where code='" & ItemCode & "'))>0
begin
        Select  Top 1 * from (Select top 1 
                    isnull(rh.date,'2010-1-1') Date,p.id,p.code,p.Company,p.name,p.UrduName,p.category,p.packing,p.size,isnull(rh.PurchaseRate,p.PurchaseRate) PurchaseRate,isnull(rh.salerate,p.SaleRate) SaleRate,isnull(rh.SaleRate2,p.SaleRate2) SaleRate2, isnull(rh.SaleRate3,p.SaleRate3) SaleRate3, isnull(rh.Schon,p.Schon) Schon, ISNULL(rh.schpc,p.SchPc) SchPc, isnull(rh.Runs,isnull(p.Runs,0)) Runs,name+' '+category+' '+company ProductName
                    , isnull(discount, 0) Disct,
                    isnull((select sum(case when type in ('purchase','sale return') then qty+isnull(schpc,0) when type in ('sale','purchase return') then (qty+isnull(schpc,0))*-1 end) from PSProduct where prid=(select id from products where code='" & ItemCode & "') and isclaim=" & clm & "  and date>='2022-6-23' and date<=dateadd(d,1,'" & dtpText.Value.ToString("d") & "')),0) STOCK ,
					(select ISNULL(amt/case when qty = 0 then 1 else qty end,0) Cost 
							from( select ISNULL(sum(vist),0)*((100-avg(extradiscountp))/100) amt,ISNULL(sum(qty),0)+ISNULL(sum(SchPc),0) qty,avg(pd.ExtraDiscountP) ExDisc from PSProduct p join PSDetail pd On p.doc= pd.doc And p.type = pd.type where p.type='purchase' and prid=(select id from products where code='" & ItemCode & "') and p.date=(select max(date) from PSProduct ps where ps.prid=(select id from products where code='" & ItemCode & "') and date<='" & SearchDate & "' and type='purchase') ) x) Cost 
From products p left Join RateHistory rh on rh.prid=p.id 
Where p.code ='" & ItemCode & "' and '" & SearchDate & "'>=date order by Date desc) x 
end 
Else
            begin
            Select  Top 1 * from (Select top 1 
                    isnull(rh.date,'2010-1-1') Date,p.id,p.code,p.Company,p.name,p.UrduName,p.category,p.packing,p.size,isnull(rh.PurchaseRate,p.PurchaseRate) PurchaseRate,isnull(rh.salerate,p.SaleRate) SaleRate,isnull(rh.SaleRate2,p.SaleRate2) SaleRate2, isnull(rh.SaleRate3,p.SaleRate3) SaleRate3, isnull(rh.Schon,isnull(p.Schon,0)) Schon, ISNULL(rh.schpc,isnull(p.SchPc,0)) SchPc, isnull(rh.Runs,isnull(p.Runs,0)) Runs, name+' '+category+' '+company ProductName
                    , isnull(discount, 0) Disct,
                    isnull((select sum(case when type in ('purchase','sale return') then qty+isnull(schpc,0) when type in ('sale','purchase return') then (qty+isnull(schpc,0))*-1 end) from PSProduct where prid=(select id from products where code='" & ItemCode & "') and isclaim=" & clm & "  and date>='2022-6-23' and date<=dateadd(d,1,'" & dtpText.Value.ToString("d") & "')),0) STOCK ,
					(select ISNULL(amt/case when qty = 0 then 1 else qty end,0) Cost 
							from( select ISNULL(sum(vist),0)*((100-avg(extradiscountp))/100) amt,ISNULL(sum(qty),0)+ISNULL(sum(SchPc),0) qty,avg(pd.ExtraDiscountP) ExDisc from PSProduct p join PSDetail pd On p.doc= pd.doc And p.type = pd.type where p.type='purchase' and prid=(select id from products where code='" & ItemCode & "') and p.date=(select max(date) from PSProduct ps where ps.prid=(select id from products where code='" & ItemCode & "') and date<='" & SearchDate & "' and type='purchase') ) x) Cost 
From products p left Join RateHistory rh on rh.prid=p.id 
Where p.code ='" & ItemCode & "' ) x 
end "
)

        'If dt.Rows.Count = 0 Then
        '    Return
        'End If
        If dt.Rows.Count = 0 Then
            MsgBox("ITEM NOT FOUND")
            txtPRID.Text = ""
            txtPRID.Select()
            Return
        End If
        Company = dt.Rows(0)("Company")
        '        Dim dt As DataTable = SQLData("select id,name+' '+category+' '+company,COMPANY,size,packing,ISNULL(SchPc,0),ISNULL(Schon,0),PurchaseRate,salerate,SaleRate2,SaleRate3,isnull(discount,0) Disct,
        '(select ISNULL(sum(qty),0) from stock where prid=(select id from products where code='" & ItemCode & "')) stock,
        '(select ISNULL(amt/qty,0) Cost from ( select ISNULL(sum(vist),0)*((100-avg(extradiscountp))/100) amt,ISNULL(sum(qty),0)+ISNULL(sum(SchPc),0) qty,avg(ExtraDiscountP) ExDisc from inv where type='purchase' and prid=(select id from products where code='" & ItemCode & "') and p.date=(select max(date) from PSProduct ps where ps.prid=(select id from products where code='" & ItemCode & "') and date<='" & Searchdate & "' and type='purchase') ) x) Cost 
        'from Products where code='" & ItemCode & "'")

        If dt.Rows.Count > 0 Then

            txtCost.Text = dt.Rows(0)("cost")
            txtDiscP.Text = Val(dt.Rows(0)("Disct"))

            txtProduct.Text = dt.Rows(0)("ProductName")
            txtStock.Text = dt.Rows(0)("Stock")
            txtSize.Text = dt.Rows(0)("Size")
            If Val(txtStock.Text) <= 0 Then
                txtStock.BackColor = Color.Red
            Else
                txtStock.BackColor = Color.White
            End If
            If Numbers(txtQty.Text) > 0 Then
                Dim dtsch As DataTable = SQLData("select top 1 SchOn,SchPcs from SchQTYSlabs where schon<=isnull(" & txtQty.Text & ",0) and prid=(select id from products where code='" & txtPRID.Text & "') order by schon desc")

                If dtsch.Rows.Count > 0 Then
                    SchOnQty = dtsch(0)("Schon")
                    SchPcsQty = dtsch.Rows(0)("SchPcs")
                    txtScheme.Text = SchOnQty.ToString + "+" + SchPcsQty.ToString
                Else
                    SchOnQty = 0
                    SchPcsQty = 0
                    txtScheme.Text = 0.ToString + "+" + 0.ToString

                End If

            End If

            'txtScheme.Text = dt.Rows(0)(6) & " + " & dt.Rows(0)(5)
            'SchOnQty = dt.Rows(0)(6)
            'SchPcsQty = dt.Rows(0)(5)
            txtRuns.Text = dt.Rows(0)("Runs")

            If txtCustomerPrice.Text = "P" Then
                txtRate.Text = dt.Rows(0)("PurchaseRate")
            ElseIf txtCustomerPrice.Text = "B" Then
                txtRate.Text = dt.Rows(0)("SaleRate2")
            ElseIf txtCustomerPrice.Text = "C" Then
                txtRate.Text = dt.Rows(0)("SaleRate3")
            Else
                txtRate.Text = dt.Rows(0)("SaleRate")
            End If
        Else
            MsgBox("Item Not Found")
            txtPRID.Text = ""
            txtPRID.SelectAll()
            txtPRID.Select()
        End If
    End Sub







    Sub ProductCost(ItemCode As String, SearchDate As Date)
        'ISNULL((SELECT SUM(ISNULL(QTY,0))+SUM(ISNULL(SCHPC,0)) FROM PSProduct WHERE PRID=(select id from products where code='" & ItemCode & "') AND TYPE IN('PURCHASE','SALE RETURN') ),0)-ISNULL((SELECT SUM(ISNULL(QTY,0))+SUM(ISNULL(SCHPC,0)) FROM PSProduct WHERE PRID=(select id from products where code='" & ItemCode & "') AND TYPE in ('SALE','PURCHASE RETURN') ),0) STOCK ,

        'dateadd(d,1,'" & dtpText.Value.ToString("d") & "')
        Dim dt As DataTable
        If chkStock.Checked Then
            dt = SQLData("Select id, Name +' '+category+' '+company,COMPANY,size,packing,ISNULL(SchPc,0),ISNULL(Schon,0),PurchaseRate,salerate,SaleRate2,SaleRate3,isnull(discount,0) Disct,
            isnull((select sum(case when type in ('purchase','sale return') then qty+isnull(schpc,0) when type in ('sale','purchase return') then (qty+isnull(schpc,0))*-1 end) from PSProduct where prid=(select id from products where code='" & ItemCode & "') and isclaim=0  and date>=isnull(stockdate,'2021-1-1') and date<=dateadd(d,1,'" & dtpText.Value.ToString("d") & "')),0) STOCK ,
            (select ISNULL(amt/case when qty = 0 then 1 else qty end,0) Cost 
            from ( select ISNULL(sum(vist),0)*((100-avg(extradiscountp))/100) amt,ISNULL(sum(qty),0)+ISNULL(sum(SchPc),0) qty,avg(pd.ExtraDiscountP) ExDisc from PSProduct p join PSDetail pd on p.doc=pd.doc and p.type=pd.type where p.type='purchase' and prid=(select id from products where code='" & ItemCode & "') and p.date=(select max(date) from PSProduct ps where ps.prid=(select id from products where code='" & ItemCode & "') and date<='" & SearchDate & "' and type='purchase') ) x) Cost 
            ,isnull(runs,0) runs        
            from Products p where code='" & ItemCode & "'")
        Else
            dt = SQLData("Select id, Name +' '+category+' '+company,COMPANY,size,packing,ISNULL(SchPc,0),ISNULL(Schon,0),PurchaseRate,salerate,SaleRate2,SaleRate3,isnull(discount,0) Disct,
            0 STOCK ,
            (select ISNULL(amt/case when qty = 0 then 1 else qty end,0) Cost 
            from ( select ISNULL(sum(vist),0)*((100-avg(extradiscountp))/100) amt,ISNULL(sum(qty),0)+ISNULL(sum(SchPc),0) qty,avg(pd.ExtraDiscountP) ExDisc from PSProduct p join PSDetail pd on p.doc=pd.doc and p.type=pd.type where p.type='purchase' and prid=(select id from products where code='" & ItemCode & "') and p.date=(select max(date) from PSProduct ps where ps.prid=(select id from products where code='" & ItemCode & "') and date<='" & SearchDate & "' and type='purchase') ) x) Cost 
            ,isnull(runs,0) runs        
            from Products p where code='" & ItemCode & "'")
        End If

        'If dt.Rows.Count = 0 Then
        '    Return
        'End If
        If dt.Rows.Count = 0 Then
            MsgBox("ITEM NOT FOUND")
            txtPRID.Text = ""
            txtPRID.Select()
            Return
        End If
        Company = dt.Rows(0)("Company")
        '        Dim dt As DataTable = SQLData("select id,name+' '+category+' '+company,COMPANY,size,packing,ISNULL(SchPc,0),ISNULL(Schon,0),PurchaseRate,salerate,SaleRate2,SaleRate3,isnull(discount,0) Disct,
        '(select ISNULL(sum(qty),0) from stock where prid=(select id from products where code='" & ItemCode & "')) stock,
        '(select ISNULL(amt/qty,0) Cost from ( select ISNULL(sum(vist),0)*((100-avg(extradiscountp))/100) amt,ISNULL(sum(qty),0)+ISNULL(sum(SchPc),0) qty,avg(ExtraDiscountP) ExDisc from inv where type='purchase' and prid=(select id from products where code='" & ItemCode & "') and p.date=(select max(date) from PSProduct ps where ps.prid=(select id from products where code='" & ItemCode & "') and date<='" & Searchdate & "' and type='purchase') ) x) Cost 
        'from Products where code='" & ItemCode & "'")

        If dt.Rows.Count > 0 Then

            txtCost.Text = dt.Rows(0)(13)
            'txtDiscP.Text = Val(dt.Rows(0)("Disct"))

            txtProduct.Text = dt.Rows(0)(1)
            txtStock.Text = dt.Rows(0)(12)
            txtSize.Text = dt.Rows(0)("Size")
            If Val(txtStock.Text) <= 0 Then
                txtStock.BackColor = Color.Red
            Else
                txtStock.BackColor = Color.White
            End If
            If Numbers(txtQty.Text) > 0 Then
                Dim dtsch As DataTable = SQLData("select top 1 SchOn,SchPcs from SchQTYSlabs where schon<=isnull(" & txtQty.Text & ",0) and prid=(select id from products where code='" & txtPRID.Text & "') order by schon desc")

                If dtsch.Rows.Count > 0 Then
                    SchOnQty = dtsch(0)("Schon")
                    SchPcsQty = dtsch.Rows(0)("SchPcs")
                    txtScheme.Text = SchOnQty.ToString + "+" + SchPcsQty.ToString
                Else
                    SchOnQty = 0
                    SchPcsQty = 0
                    txtScheme.Text = 0.ToString + "+" + 0.ToString

                End If

            End If

            'txtScheme.Text = dt.Rows(0)(6) & " + " & dt.Rows(0)(5)
            'SchOnQty = dt.Rows(0)(6)
            'SchPcsQty = dt.Rows(0)(5)
            txtRuns.Text = dt.Rows(0)("Runs")

            If txtCustomerPrice.Text = "P" Then
                txtRate.Text = dt.Rows(0)(7)
            ElseIf txtCustomerPrice.Text = "B" Then
                txtRate.Text = dt.Rows(0)(9)
            ElseIf txtCustomerPrice.Text = "C" Then
                txtRate.Text = dt.Rows(0)(10)
            Else
                txtRate.Text = dt.Rows(0)(8)
            End If
        Else
            MsgBox("Item Not Found")
            txtPRID.Text = ""
            txtPRID.SelectAll()
            txtPRID.Select()
        End If

    End Sub

    Sub ItemSearch(ItemCode As String, Searchdate As Date)

        '(select ISNULL(sum(qty),0) from stock where prid=(select id from products where code='" & ItemCode & "') and date>='2020-04-01') stock
        '(SELECT SUM(QTY)+SUM(ISNULL(SCHPC,0)) FROM PSProduct WHERE PRID=P.ID AND TYPE IN('PURCHASE','SALE RETURN') )-(SELECT SUM(QTY)+SUM(ISNULL(SCHPC,0)) FROM PSProduct WHERE PRID=P.ID AND TYPE in ('SALE','PURCHASE RETURN') ) STOCK 


        Dim DT2 As DataTable = SQLData("SELECT ACID,COMPANY,ISNULL(DISCOUNT,0) Discount,isnull(Disc1P,0) Disc1,PriceList FROM PARTYDISCOUNT WHERE ACID=" & txtCustomerID.Text & " AND COMPANY=(select company from Products where code='" & txtPRID.Text & "')")
        If DT2.Rows.Count > 0 Then
            Dim PLIST As String = DT2.Rows(0)("PriceList")
            Dim DIS As Integer = DT2.Rows(0)(2)
            txtCustomerPrice.Text = PLIST
            txtDisc2p.Text = DT2.Rows(0)("Discount")
            txtDiscP.Text = DT2.Rows(0)("Disc1")
        Else
            txtCustomerPrice.Text = "A"
            txtDisc2p.Text = "0"
        End If
        ProductCost(ItemCode, Searchdate)



        If LastSalePrice > Numbers(txtRate.Text) And txtCustomerPrice.Text <> "P" Then
            txtRate.Text = LastSalePrice
        End If

    End Sub

    Private Sub txtInvoice_Leave(sender As Object, e As EventArgs) Handles txtInvoice.Leave
        If txtInvoice.Text = "" Then
            DNum()
        End If
        If dn <> txtInvoice.Text Then
            LoadDoc(txtInvoice.Text)
            txtInvoice.Focus()
            txtInvoice.SelectAll()
        End If

        'txtInvoice.SelectAll()



    End Sub

    Private Sub txtInvoice_Enter(sender As Object, e As EventArgs) Handles txtInvoice.Enter
        txtInvoice.SelectAll()

        If txtInvoice.Text <> "" Then
            dn = txtInvoice.Text
            Me.Text = "Invoice - " + txtInvoice.Text
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim Result As DialogResult = MessageBox.Show("Do you want to print on Laser Printer ?", "Print Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.No Then
            txtInvoice.Focus()
            txtInvoice.SelectAll()
            Return
        End If
        If rdWReceipt.Checked = True Then
            MainPage.Rcpt = 1
        Else
            MainPage.Rcpt = 0
        End If
        If rdEstimate.Checked = True Then
            'rfEstimates.Show()
            'rfEstimates.txtLDN.Text = txtInvoice.Text
            'rfEstimates.txtDN.Text = txtInvoice.Text
            'rfEstimates.txtRN.Text = ""
            'rfEstimates.rdALL.Checked = True
            'rfEstimates.btnGenerate.PerformClick()
            Return
        End If

        Dim PBAL As Integer = chkPBal.CheckState
        If txtCustomerName.Text.Contains("Counter") Then
            PBAL = 0
        End If

        If txtInvoice.Text <> LastInvoiceNumber Then
            If DTPRuns.Value >= Convert.ToDateTime("01.06.2020") And dtpText.Value >= DTPRuns.Value Then
                PrintInvoice(txtInvoice.Text, PBAL, 1)
            Else
                PrintInvoice(txtInvoice.Text, PBAL, 1)
            End If
            'PrintInvoice(txtInvoice.Text, chkPBal.CheckState)

        Else
            MsgBox("No Invoice to export!", MsgBoxStyle.Information)
        End If

        txtInvoice.Focus()
        txtInvoice.SelectAll()

    End Sub

    Sub PrintInvoice(Number, Pre, RunsFormat)

        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table
        Dim ReportPath As String = Settings("Reports Folder")

        If rdReceipt.Checked = True Then
            cryRpt.Load(ReportPath + "rptInvoiceReceipt.rpt")


        Else
            If RunsFormat = 1 Then
                cryRpt.Load(ReportPath + "rptInvoice3A5WithRuns.rpt")

            Else
                cryRpt.Load(ReportPath + "rptInvoice3A5.rpt")
            End If

        End If

        With crConnectionInfo
            .ServerName = frmLogin.MySqlServer
            .DatabaseName = frmLogin.MyDataBase
            .UserID = "sa"
            .Password = MainPage.Password
        End With

        CrTables = cryRpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        Try

            'cryRpt.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In cryRpt.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            cryRpt.SetParameterValue("DocNumber", Number)
            cryRpt.SetParameterValue("PreBalance", Pre)
            cryRpt.SetParameterValue("CompanyName", 0)
            cryRpt.SetParameterValue("RECPT", MainPage.Rcpt)
            cryRpt.PrintToPrinter(1, False, 0, 0)
            cryRpt.Close()
            cryRpt.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtPRID_Enter(sender As Object, e As EventArgs) Handles txtPRID.Enter
        MainPage.CustID = txtCustomerID.Text
        DateUserCheck()
        If txtPRID.Text = "" Then
            If NewItem = False Then
                NewItem = True
                Return
            End If
            txtRate.Text = ""
            LastSalePrice = 0
            ProductSearch.ShowDialog()
            txtPRID.Text = ProductSearch.prIDtxt
            If txtPRID.Text <> "" Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Sub CustomerAging(acc As Integer)

        Dim DT As DataTable = SQLData("Select Date,Doc,Days,Debit,round(debit+(bal-rt),0) Remaining FROM (select top (Select  (count(*) + 1) FROM (Select  Date,ACID,Debit,CREDIT,SUM(DEBIT) OVER(ORDER BY Date DESC) RT,					(Select ISNULL(SUM(DEBIT),0)-ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE ACID=" & acc & ")  BAL 				FROM Ledgers   				WHERE ACID =" & acc & " And Debit<>0 ) X WHERE X.RT<BAL			)	acid, Date, doc, debit, sum(debit) over(order by date desc) RT, 								(SELECT ISNULL(SUM(DEBIT),0)-ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE ACID=" & acc & ") BAL,DATEDIFF(D,DATE,GETDATE())+1 Days from ledgers where acid=" & acc & " And Debit<>0								) XX order by days desc")
        dgvAging.DataSource = DT
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles btnRefresh.Click
        'txtInvoice.Select()
        Dim server As String = txtSMServer.Text
        If Numbers(txtInvoice.Text) <> LastInvoiceNumber And txtReference.Text = "" Then
            MsgBox("Please Fill Reference Textbox")
            'txtReference.Select()
            'txtReference.SelectAll()
            Return
        End If

        clearAll()
        lblDoc.BackColor = Color.Red
        lblDoc.Text = "ESTIMATE - " + frmLogin.MySqlServer + " - " + frmLogin.UserLevel

        txtNetBillAmount.Text = ""
        cmbGoods.Text = ""
        cmbSPO.Text = ""
        cmbLocation.Text = ""
        chkPBal.Checked = True
        'chkScheme.Checked = True
        chkClaim.Checked = False
        txtNetReceivable.Text = ""
        NewDocument = True
        txtSMServer.Text = server
        DNum()


    End Sub

    Sub clearAll()
        txtInvoice.Select()
        txtInvoice.SelectAll()
        'Dim inv = TXTINVOICE.TEXT
        psproductid = 0
        OldPRID = ""
        sid = 0
        pBal = 0
        NProfit = 0
        OldDate = Date.Today
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
        If dgvCompanyWiseDiscount.Rows.Count > 0 Then
            dgvCompanyWiseDiscount.DataSource.clear()
        End If
        If dgvQtySlabSchemes.Rows.Count > 0 Then
            dgvQtySlabSchemes.DataSource.clear()
        End If
        If dgvPriceLists.Rows.Count > 0 Then
            dgvPriceLists.DataSource.clear()
        End If

        dtpText.Value = Date.Today
        'TXTINVOICE.TEXT = LastInvoiceNumber


    End Sub

    Private Sub txtExrtaDiscountP_Leave(sender As Object, e As EventArgs) Handles txtExrtaDiscountP.Leave
        Dim net As Integer = (Numbers(txtVEST.Text) - Numbers(txtDiscount.Text) - Numbers(txtDiscount2.Text))
        UpdatePsDetails()
        UpDateLedgers()
        'If txtExrtaDiscountP.Text <> "" Then
        '    SQLData("update psdetail set ExtraDiscountP=" & txtExrtaDiscountP.Text & ",extradiscount=" & Numbers(txtExtraDiscountAmount.Text) & ",amount=" & Numbers(txtNetBillAmount.Text) & " where type='sale' and doc=" & dn &
        '             "update ledgers set debit=" & Numbers(txtNetBillAmount.Text) & " where type='sale' and acid=" & txtCustomerID.Text & " and debit is not null and doc=" & dn
        '    )
        'Else
        '    SQLData("update psdetail Set ExtraDiscountP= 0, extradiscount = 0, amount = " & Numbers(txtNetBillAmount.Text) & " where type='sale' and doc=" & dn
        '    )
        '    LedgerUpdate()
        'End If
    End Sub

    Private Sub cmbLocation_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbLocation.KeyDown
        If e.KeyCode = Keys.Enter Then
            '   SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged

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


        'If DTSCH.Rows.Count > 0 Then
        '    txtRate.Text = dtsch.Rows(0)("RATE")
        '    If Val(DT.Rows(0)("ISDISC")) = 0 Then
        '        txtDiscP.Text = 0
        '    End If
        'End If


        If Val(txtQty.Text) < 0 Then                    'Returns
            Dim LastSale As DataTable = SQLData("select top 1 isnull(spo,'') SPO,vist/(qty+isnull(schpc,0)) NRate from PSProduct where prid=(select id from Products where code='" & txtPRID.Text & "') and acid=" & txtCustomerID.Text & " and qty>0 order by date desc")
            If LastSale.Rows.Count > 0 Then
                chkScheme.Checked = False
                cmbSPO.Text = LastSale.Rows(0)("SPO")
                txtRate.Text = LastSale.Rows(0)("NRate")
                txtDiscP.Text = "0"
                txtDisc2p.Text = "0"
            End If
        Else
            If LastSalePrice > Numbers(txtRate.Text) And txtCustomerPrice.Text <> "P" Then
                txtRate.Text = LastSalePrice
            End If
        End If

        SCHEMEQTY()
        ItemTotals()
        If Val(txtQty.Text) + Val(txtSchPcs.Text) > Val(txtStock.Text) Then
            txtQty.BackColor = Color.Red
            txtSchPcs.BackColor = Color.Red
            txtTotalQty.BackColor = Color.Red
        Else
            txtQty.BackColor = Color.LightGreen
            txtSchPcs.BackColor = Color.LightGreen
            txtTotalQty.BackColor = Color.Green
        End If
    End Sub

    Sub SCHEMEQTY()
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
            End If
        Else
            txtSchPcs.Text = 0
        End If
        txtTotalQty.Text = Val(txtQty.Text) + Val(txtSchPcs.Text)
    End Sub

    Private Sub chkScheme_CheckedChanged(sender As Object, e As EventArgs) Handles chkScheme.CheckedChanged
        SCHEMEQTY()
        ItemTotals()
        'If txtQty.Text <> "" Then
        txtOQty.Select()
        txtOQty.SelectAll()
        'End If
        Return
    End Sub

    Private Sub txtRate_Enter(sender As Object, e As EventArgs) Handles txtRate.Enter
        If Val(txtQty.Text) = 0 Or txtQty.Text = "" Then
            txtQty.Select()
        End If
    End Sub

    Private Sub txtQty_Enter(sender As Object, e As EventArgs) Handles txtQty.Enter
        If txtPRID.Text = "" Then
            txtPRID.Select()
        Else
            txtQty.SelectAll()
        End If

    End Sub

    Private Sub txtRate_TextChanged(sender As Object, e As EventArgs) Handles txtRate.TextChanged, txtDiscP.TextChanged, txtDisc2p.TextChanged
        ItemTotals()
    End Sub

    Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQty.KeyDown, txtRate.KeyDown, txtDiscP.KeyDown, txtDiscP2.KeyDown, txtOQty.KeyDown

        If txtQty.Text = "" Then
            Return
        End If
        If e.KeyCode = Keys.Enter And txtProduct.Text <> "" Then
            If frmLogin.UserLevel.ToUpper = "OPERATOR" And lblDoc.Text.ToUpper.Contains("INVOICE") Then
                MsgBox("New Items can not be changed in Finalized Invoices")
                ClearTextBox(gbItems)
                Return
            End If
            SAVE()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtRate_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRate.KeyDown, txtDiscP.KeyDown, txtDisc2p.KeyDown
        e.Handled = True
        If frmLogin.UserLevel.ToUpper <> "ADMIN" Then
            Return
        End If
        If e.KeyCode = Keys.Enter And Val(txtRate.Text) <> 0 Then
            If frmLogin.UserLevel.ToUpper = "ADMIN" Then


                Dim List As String = "A"
                If txtProduct.Text <> "" Then
                    If txtCustomerPrice.Text = "" Then
                        List = "A"
                    ElseIf txtCustomerPrice.Text = "P" Then
                        List = "P"
                    ElseIf txtCustomerPrice.Text = "C" Then
                        List = "C"
                    ElseIf txtCustomerPrice.Text = "B" Then
                        List = "B"
                    Else
                        List = "A"
                    End If
                    PartyDiscount(List)


                End If
            End If
            SAVE()
            txtRate.Select()





        End If
    End Sub

    Private Sub txtDiscP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDiscP.KeyDown
        e.Handled = True
        If e.KeyCode = Keys.Enter And Val(txtDiscP.Text) <> 0 Then
            SAVE()
        End If
    End Sub

    'Private Sub txtDisc2p_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDisc2p.KeyDown
    '    e.Handled = True
    '    If e.KeyCode = Keys.Enter And Val(txtDisc2p.Text) <> 0 Then
    '        SAVE()
    '    End If
    'End Sub

    Sub NetBill()

        Dim BillAmt = Numbers(txtVEST.Text) - Numbers(txtFreight.Text) - Numbers(txtExtraDiscountAmount.Text) - Numbers(txtDiscount.Text) - Numbers(txtDiscount2.Text)
        txtNetBillAmount.Text = Format(BillAmt, "#,##0.00")
        txtNetReceivable.Text = Format(Numbers(txtPreviousBalance.Text) + BillAmt - Numbers(txtCashReceived.Text), "#,##0.00")
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
            txtExtraDiscountAmount.Text = Math.Round((Numbers(txtVEST.Text) - Numbers(txtDiscount.Text) - Numbers(txtDiscount2.Text)) * (Val(txtExrtaDiscountP.Text) / 100), 0)
        End If
        NetBill()
        'Dim BillAmt = Numbers(txtVEST.Text) - Numbers(txtFreight.Text) - Numbers(txtExtraDiscountAmount.Text)
        'txtNetBillAmount.Text = Format(BillAmt, "#,##0.00")
    End Sub

    Private Sub txtExtraDiscountAmount_Leave(sender As Object, e As EventArgs) Handles txtExtraDiscountAmount.KeyUp

        If Numbers(txtExtraDiscountAmount.Text) = 0 Or Numbers(txtVEST.Text) = 0 Then
            txtExrtaDiscountP.Text = 0
        Else
            Dim edp = Numbers(txtExtraDiscountAmount.Text) / (Numbers(txtVEST.Text) - Numbers(txtDiscount.Text) - Numbers(txtDiscount2.Text))
            If edp <> 0 Then
                edp = Math.Round(edp * 100, 2)
            End If
            txtExrtaDiscountP.Text = Format(edp, "#,##0.00")
        End If
        NetBill()
        'Dim BillAmt = Numbers(txtVEST.Text) - Numbers(txtFreight.Text) - Numbers(txtExtraDiscountAmount.Text)
        'txtNetBillAmount.Text = Format(BillAmt, "#,##0.00")
    End Sub

    Private Sub txtReference_Leave(sender As Object, e As EventArgs) Handles txtReference.Leave
        VarRef = Regex.Escape(txtReference.Text)
        VarRef = Regex.Unescape(txtReference.Text)
        VarRef = txtReference.Text
        If frmLogin.UserLevel.ToUpper = "OPERATOR" And lblDoc.Text.ToUpper = "INVOICE" Then

            Return
        End If

        If VarRef <> Nothing Then
            SQLData("update psdetail Set description= '" & txtReference.Text & "' where type='sale' and doc= " & Val(dn))
            SQLData("update ledgers set narration= '" & txtReference.Text & "' where type='sale' and doc=" & Val(dn) & " and acid<>4")
        End If
    End Sub

    Sub RemarksUpdate()
        SQLData("update psdetail set remarks=N'" & txtRemarks.Text & "' where type='sale' and doc= " & dn)
    End Sub

    Private Sub txtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave

        RemarksUpdate()

    End Sub

    Function Freightcalculations(ddate, Amount, Route, CustomerName, Transporter, ACID) As Integer
        If CustomerName.contains("##") Then
            Return 0
        End If
        Dim TodayFreight As DataTable = SQLData("select isnull(sum(freight),0) TodaysFreight from PSDetail where acid=" & ACID & " and date between '" & ddate & "'  and dateadd(d,1,'" & ddate & "')")

        If TodayFreight.Rows.Count > 0 Then
            'MsgBox(Numbers(TodayFreight.Rows(0)("TodaysFreight")))
            If Numbers(TodayFreight.Rows(0)("TodaysFreight")) <> 0 Then
                Return 0 'TodayFreight.Rows(0)("TodaysFreight")
            End If
        End If
        Dim dt As DataTable
        Dim Freight As Integer
        If ddate >= Now.Date And Numbers(Amount) > 0 And Transporter.Contains("SUPPLY VAN") Then 'And Not CustomerName.Contains("#")
            If Route.Contains("SR") Or Route.Contains("KR") Then
                dt = SQLData("select top 1 Freight from freightcalculations where amount<" & Numbers(Amount) & " order by amount desc")
                If dt.Rows.Count > 0 Then
                    Freight = dt.Rows(0)("Freight")
                    Freight = Freight * -1
                    Return Freight
                Else
                    Return 0
                End If
            End If
        End If
        If Numbers(Amount) = 0 Or Transporter.Contains("SUPPLY VAN") = False Then 'Or CustomerName.Contains("#")
            Return 0
        End If
        Return 0
    End Function


    Sub FreightCalculations2()
        If dtpText.Value >= Now.Date And Numbers(txtNetBillAmount.Text) > 0 And Not txtCustomerName.Text.Contains("#") And cmbGoods.Text.Contains("SUPPLY VAN") Then
            If (txtRoute.Text.Contains("SR") Or txtRoute.Text.Contains("KR")) And Numbers(txtNetBillAmount.Text) > 0 And Numbers(txtNetBillAmount.Text) < 1000 Then
                txtFreight.Text = 0
            End If
            If (txtRoute.Text.Contains("SR") Or txtRoute.Text.Contains("KR")) And Numbers(txtNetBillAmount.Text) > 1000 And Numbers(txtNetBillAmount.Text) < 3000 Then
                txtFreight.Text = -30
            End If
            If (txtRoute.Text.Contains("SR") Or txtRoute.Text.Contains("KR")) And Numbers(txtNetBillAmount.Text) > 3000 And Numbers(txtNetBillAmount.Text) < 5000 Then
                txtFreight.Text = -60
            End If
            If (txtRoute.Text.Contains("SR") Or txtRoute.Text.Contains("KR")) And Numbers(txtNetBillAmount.Text) > 5000 Then
                txtFreight.Text = -80
            End If
            If (txtRoute.Text.Contains("SR") Or txtRoute.Text.Contains("KR")) And Numbers(txtNetBillAmount.Text) > 90000 Then
                txtFreight.Text = -150
            End If
            If (txtRoute.Text.Contains("SR") Or txtRoute.Text.Contains("KR")) And Numbers(txtNetBillAmount.Text) > 150000 Then
                txtFreight.Text = -200
            End If
        End If
        If Numbers(txtNetBillAmount.Text) = 0 Or txtCustomerName.Text.Contains("#") Or cmbGoods.Text.Contains("SUPPLY VAN") = False Then
            txtFreight.Text = 0
        End If
    End Sub



    'Sub FreightCalculations()
    '    Dim rt() As String = {"R1", "KR1", "SR1", "R2", "KR2", "SR2", "R3", "KR3", "SR3", "R4", "KR4", "SR4", "R5", "KR5", "SR5", "R6", "KR6", "SR6", "R7", "KR7", "SR7", "R8", "SR8", "KR8"}
    '    If dtpText.Value >= Now.Date And Numbers(txtNetBillAmount.Text) > 0 And cmbGoods.Text.ToUpper = "SUPPLY VAN" And Not txtCustomerName.Text.Contains("#") Then
    '        If rt.Contains(txtRoute.Text) And Numbers(txtNetBillAmount.Text) > 0 And Numbers(txtNetBillAmount.Text) < 2000 Then
    '            txtFreight.Text = 0
    '        End If
    '        If rt.Contains(txtRoute.Text) And Numbers(txtNetBillAmount.Text) > 2000 And Numbers(txtNetBillAmount.Text) < 3000 Then
    '            txtFreight.Text = -30
    '        End If
    '        If rt.Contains(txtRoute.Text) And Numbers(txtNetBillAmount.Text) > 3000 And Numbers(txtNetBillAmount.Text) < 5000 Then
    '            txtFreight.Text = -50
    '        End If
    '        If rt.Contains(txtRoute.Text) And Numbers(txtNetBillAmount.Text) > 5000 Then
    '            txtFreight.Text = -70
    '        End If
    '        If rt.Contains(txtRoute.Text) And Numbers(txtNetBillAmount.Text) > 90000 Then
    '            txtFreight.Text = -130
    '        End If
    '    End If
    '    If Numbers(txtNetBillAmount.Text) = 0 Or cmbGoods.Text.ToUpper = "COUNTER" Or txtCustomerName.Text.Contains("#") Then
    '        txtFreight.Text = 0
    '    End If
    'End Sub

    Private Sub txtReference_Enter(sender As Object, e As EventArgs) Handles txtReference.Enter

        If txtReference.Text = "" Then
            txtReference.Text = "ESTIMATE"
        End If

        'If rt.Contains(txtRoute.Text) And Numbers(txtPreviousBalance.Text) > Numbers(txtNetBillAmount.Text) And txtRemarks.Text = "" Then
        '    txtRemarks.Text = "براہ مہربانی لازما سابقہ رقم ادا کریں"
        '    RemarksUpdate()
        'End If

        Freightcalculations(dtpText.Value, txtNetBillAmount.Text, txtRoute.Text, txtCustomerName.Text, cmbGoods.Text, txtCustomerID.Text)
        InvoiceTotals()

        txtReference.SelectAll()
    End Sub

    Private Sub txtRemarks_Enter(sender As Object, e As EventArgs) Handles txtRemarks.Enter
        txtRemarks.SelectAll()
    End Sub

    Private Sub cmbSPO_Leave(sender As Object, e As EventArgs) Handles cmbSPO.Leave
        cmbSPO.Items.Add(cmbSPO.Text)
        If cmbSPO.Text <> Nothing And frmLogin.UserLevel.ToUpper = "ADMIN" Then
            SQLData("update psdetail set Vehicle='" & cmbSPO.Text & "' where type='sale' and doc= " & Val(dn))
        End If
        cmbSPO.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Sub Whatsapp(number As String, msg As String, Optional delay As Integer = 4)
        Dim Delaytime As Integer = delay * 1000
        Try

            Dim web As New WebBrowser
            msg = msg.Replace(" ", "%20")
            web.Navigate("whatsapp://send?phone=" & number & " &text=" & msg.Replace(Environment.NewLine, "%0a"))

            Threading.Thread.Sleep(2000)


            If Clipboard.ContainsImage = True Then
                SendKeys.Send("^v")
                Threading.Thread.Sleep(3000)
            End If




            SendKeys.Send("{Enter}")
        Catch ex As Exception
            SendKeys.Send("%{TAB}")

            'SendKeys.Send("%{F4}")
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ClaimExcel()
        MainPage.rptName = Settings("Reports Folder") + "ClaimExcel.rpt"
        cryRPT.Load(MainPage.rptName)
        Dim RPN = MainPage.rptName
        'cryRPT.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In cryRPT.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        Dim FileN As String = Settings("Temp Folder") + "CLAIM # " & txtInvoice.Text & ".xls"
        cryRPT.SetParameterValue("Doc", txtInvoice.Text)
        cryRPT.ExportToDisk(ExportFormatType.Excel, FileN)
    End Sub

    Private Sub btnExp_Click(sender As Object, e As EventArgs) Handles btnExp.Click
        'Dim ph As String
        'ph = "923308551600"

        'For n = 1 To 3
        '    Whatsapp(ph, "")
        '    Threading.Thread.Sleep(3000)
        '    ph = "923017044604"
        '    n += 1
        'Next


        MainPage.Rcpt = 0
        If RDClaimExcel.Checked Then
            ClaimExcel()
            txtInvoice.SelectAll()
            txtInvoice.Select()
            Return
        End If

        If rdWReceipt.Checked = True Then
            MainPage.Rcpt = 1
        Else
            MainPage.Rcpt = 0
        End If
        If chkPBal.Checked = True Then
            MainPage.PreviousBalance = 1
        Else
            MainPage.PreviousBalance = 0
        End If
        If rbALL.Checked = True Or rdWReceipt.Checked = True Then
            MainPage.rptName = Settings("Reports Folder") + "rptInvoice3A5WithRuns.rpt"
            If DTPRuns.Value >= Convert.ToDateTime("01.06.2020") Then
                If dtpText.Value >= DTPRuns.Value Then
                    MainPage.rptName = Settings("Reports Folder") + "rptInvoice3A5WithRuns.rpt"
                End If
            End If
        End If
        If rdPending.Checked = True Then
            MainPage.rptName = Settings("Reports Folder") + "rptInvoice3A5Pending.rpt"
            Dim cryrpt As New ReportDocument
            'MsgBox(settings("Reports Folder") + " " + MainPage.rptName)
            cryrpt.Load(MainPage.rptName)

            'cryrpt.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In cryrpt.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            cryrpt.SetParameterValue("DocNumber", txtInvoice.Text)
            cryrpt.SetParameterValue("RECPT", MainPage.Rcpt)
            cryrpt.SetParameterValue("PreBalance", MainPage.PreviousBalance)
            cryrpt.SetParameterValue("CompanyName", 0)
            Dim Tempfolder As String = Settings("Temp Folder")
            FileName = Tempfolder + "Pending Items Invoice # " & txtInvoice.Text + " " + txtCustomerName.Text & " " & Date.Now.ToString.Replace(":", ".") & ".pdf"
            cryrpt.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)
        End If

        If rbFIT.Checked = True Then
            MainPage.rptName = Settings("Reports Folder") + "rptInvoice3A5FIT.rpt"
        End If
        If rbLocal.Checked = True Then
            MainPage.rptName = Settings("Reports Folder") + "rptInvoice3A5Local.rpt"
        End If
        If rdNetRate.Checked = True Then


            MainPage.rptName = Settings("Reports Folder") + "rptInvoice3A5NetRate.rpt"
        End If
        If rdDC.Checked = True Then
            MainPage.rptName = Settings("Reports Folder") + "rptInvoiceDC.rpt"
        End If
        If txtInvoice.Text <> LastInvoiceNumber Then
            'If DTPRuns.Value >= Convert.ToDateTime("01.06.2020") And dtpText.Value >= DTPRuns.Value Then
            '    PrintInvoice(txtInvoice.Text, chkPBal.CheckState, 1)
            'Else
            '    PrintInvoice(txtInvoice.Text, chkPBal.CheckState, 0)
            'End If




            PDFGen(txtInvoice.Text, txtCustomerName.Text)
        Else
            MsgBox("No Invoice to export!", MsgBoxStyle.Information)
        End If

        'SMS

        If chkSMS.Checked = True Then
            SMS(txtCustomerMobile2.Text, txtInvoice.Text, txtNetBillAmount.Text, dtpText.Value)
        End If
        If txtCustomerMobile2.Text <> "" Then


        End If

        txtInvoice.SelectAll()
        txtInvoice.Select()
    End Sub

    Function InvMsg(BillNumber As String, BillAmount As String, dt As Date) As String
        Dim rec As String = ""
        Dim ob As String = ""
        Dim msg As String

        Dim UName As String = ""
        If txtUrduName.Text.Trim = "" Then
            UName = ""
        Else
            UName = "%0a بل بنام :" & txtUrduName.Text
        End If
        Dim pb As String = PreBalance(txtCustomerID.Text, dtpText.Value, "Sale", BillNumber)
        If Val(pb) <> 0 Then
            If Val(pb) < 0 Then
                ob = "%0a سابقہ بقایا :" & Amt(Math.Abs(CInt(pb)) - 0) & "-"
            Else
                ob = "%0a سابقہ بقایا :" & Amt(pb - 0)
            End If
        End If
        If Val(txtCashReceived.Text) <> 0 Then
            If txtCashReceived.Text < 0 Then
                rec = "%0a نقد وصول :" & Amt(Math.Abs(CInt(txtCashReceived.Text)) - 0) & "-"
            Else
                rec = "%0a نقد وصول :" & Amt(txtCashReceived.Text - 0)
            End If
        Else
            rec = ""
        End If
        Dim billamt As String = ""
        If BillAmount < 0 Then
            billamt = Amt(Math.Abs(CInt(BillAmount)) - 0) & "-"
        Else
            billamt = BillAmount
        End If
        Dim NB As String = Val(Numbers(pb)) + Val(Numbers(BillAmount)) - Val(Numbers(txtCashReceived.Text))
        Dim NetB As String = "%0a کل بقایا بیلنس :" & Amt(NB - 0)
        If txtNetReceivable.Text < 0 Then
            NetB = "%0a کل بقایا بیلنس :" & Amt(Math.Abs(CInt(NB) - 0)) & "-"
        Else
            NetB = "%0a کل بقایا بیلنس :" & Amt(NB - 0)
        End If
        Dim SMSServer As String = txtSMServer.Text
        msg = "السلام علیکم " &
            "%0a بل نمبر :" & BillNumber &
            UName &
            "%0a مورخہ :" & dt.ToString("dd-MM-yy") &
            ob &
            "%0a بل کی رقم : " & billamt & rec &
            NetB &
            "%0a احمدانٹرنیشنل "
        Return msg
    End Function


    Sub SMS(Mobile As String, BillNumber As String, BillAmount As String, dt As Date, Optional Svr As String = "1.125")
        If Mobile.Trim = "" Then
            MainPage.msg = "No mobile Number to send SMS"
            DisappearingMsgBox.Show()
            Return
        End If
        Dim winHttpReq As Object
        Dim myURL, msg As String
        msg = InvMsg(BillNumber, BillAmount, dt)

        myURL = "http://192.168." & Svr & ":8090/SendSMS?username=Sanaulhaq&password=123&phone=" & Mobile & "&message=" & msg
        winHttpReq = CreateObject("winHttp.winHttprequest.5.1")
        winHttpReq.open("post", myURL, False)
        Try
            winHttpReq.send()
            'MainPage.msg = "Message Sent successfully"
            'DisappearingMsgBox.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Sub DateUserCheck()
        If dtpText.Value <> OldDate Then
            If frmLogin.UserLevel = "Operator" Then
                If dtpText.Value < Date.Today Or dtpText.Value > Date.Today.AddDays(2) Then
                    MsgBox("Please enter correct Dates")
                    dtpText.Value = OldDate
                    dtpText.Select()
                End If
            End If
        End If
    End Sub

    Private Sub dtpText_Leave(sender As Object, e As EventArgs) Handles dtpText.Leave

        DateUserCheck()

        If frmLogin.UserLevel = "Operator" And dtpText.Value < Date.Today.AddDays(-1) Then
            Return
        End If


        If frmLogin.UserLevel.ToUpper <> "OPERATOR" Then
            Dim DATEUPDATE = String.Format("
                                        update ledgers set date='" & dtpText.Value.ToString("d") & "' WHERE TYPE='SALE' AND DOC=" & dn & "
                                        update PSDETAIL set date='" & dtpText.Value.ToString("d") & "' WHERE TYPE='SALE' AND DOC=" & dn & "
                                        update PSPRODUCT set date='" & dtpText.Value.ToString("d") & "' WHERE TYPE='SALE' AND DOC=" & dn & "
                                       -- update STOCK set date='" & dtpText.Value.ToString("d") & "' WHERE TYPE='SALE' AND DOC=" & dn & "
                                    ")
            SQLData(DATEUPDATE)
        End If
    End Sub

    Private Sub txtFreight_Enter(sender As Object, e As EventArgs) Handles txtFreight.Enter, txtFreight.MouseClick
        txtFreight.SelectAll()
    End Sub

    Sub FreightUpdate()
        VarRef = Regex.Escape(txtReference.Text)
        VarRef = txtReference.Text
        SQLData("
                                                        update psdetail set freight=" & Numbers(txtFreight.Text) & ", amount=" & CInt(txtNetBillAmount.Text) & " where type='sale' and doc=" & dn & "
                                                        update ledgers set debit=" & CInt(txtNetBillAmount.Text) & ",remainingamount=" & CInt(txtNetBillAmount.Text) & " where type='sale' and doc=" & dn & " and acid=" & txtCustomerID.Text & " 
                                                        update ledgers set credit=" & CInt(txtNetBillAmount.Text) + Numbers(txtFreight.Text) & " where type='sale' and doc=" & dn & " and acid= 7
                                                        
                                                        if (select count(*) from ledgers where type='sale' and doc=" & dn & " and acid=7)=0
                                                        begin
                                                            insert into ledgers (acid,date,doc,type,narration,invoice,credit)
                                                            select 7,'" & dtpText.Value.ToString("d") & "'," & dn & ",'Sale', '" & VarRef & "'," & dn & "," & Numbers(txtFreight.Text) & "
                                                        end
                                                        else
                                                        update ledgers set credit=" & Numbers(txtFreight.Text) & " where type='sale' and doc=" & dn & " and acid= 7

                                                      ")

    End Sub

    Private Sub txtFreight_Leave(sender As Object, e As EventArgs) Handles txtFreight.Leave
        FreightUpdate()
        'SQLData(UpdateFreight)
    End Sub

    Private Sub txtExtraDiscountAmount_Leave_1(sender As Object, e As EventArgs) Handles txtExtraDiscountAmount.Leave
        'SQLData("update psdetail set ExtraDiscountP=" & txtExrtaDiscountP.Text & ",extradiscount=" & Numbers(txtExtraDiscountAmount.Text) & ",amount=" & Numbers(txtNetBillAmount.Text) & " where type='sale' and doc=" & dn &
        '             "update ledgers set debit=" & Numbers(txtNetBillAmount.Text) & " where type='sale' and acid=" & txtCustomerID.Text & " and doc=" & dn
        '    )
        UpdatePsDetails()
        UpDateLedgers()
    End Sub

    Private Sub txtCashReceived_TextChanged(sender As Object, e As EventArgs) Handles txtCashReceived.TextChanged
        NetBill()
    End Sub

    Private Sub txtCashReceived_Leave(sender As Object, e As EventArgs) Handles txtCashReceived.Leave
        If frmLogin.UserLevel.ToUpper = "OPERATOR" Then
            If dtpText.Value <> Date.Today Then
                MsgBox("Previous Date Entries are Not Allowed")
                Return
            End If
            Dim dt As DataTable = SQLData("select top 1 UserName from LedgersHistory where type='sale' and doc=" & txtInvoice.Text & " and EntryStatus='save' ")

            If dt.Rows.Count > 0 Then
                Dim UserNm As String
                UserNm = dt.Rows(0)(0)
                If UserNm <> frmLogin.UserName Then
                    MsgBox("Other User Entries are not allowed")
                    Return
                End If
            End If

        End If

        If Numbers(txtCashReceived.Text) <> 0 Then
            SQLData("UPDATE PSDETAIL SET RECEIVED=" & CInt(txtCashReceived.Text) & " WHERE TYPE='SALE' AND DOC=" & Val(dn))
        Else
            SQLData("delete from ledgers where type='sale' and doc=" & Val(dn) & " and credit<>0 and acid=" & txtCustomerID.Text & "
                         delete from ledgers where type='sale' and doc=" & Val(dn) & "  and acid=1")
        End If
        UpDatePsDetail2()
        UpDateLedgers()
        btnRefresh.Select()
    End Sub

    Private Sub chkClaim_CheckedChanged(sender As Object, e As EventArgs) Handles chkClaim.CheckedChanged

        If chkClaim.Checked = True Then
            'chkClaim.BackColor = Color.Red
            gbItems.BackColor = Color.Pink
        Else
            chkClaim.Checked = False
            'chkClaim.BackColor = Color.Transparent
            gbItems.BackColor = Color.Moccasin
        End If

        txtQty.Select()
    End Sub

    Private Sub txtQty_Leave(sender As Object, e As EventArgs) Handles txtQty.Leave
        'If Val(txtOQty.Text) < Val(txtQty.Text) Then
        '    txtOQty.Text = txtQty.Text
        'End If
    End Sub



    Private Sub ComboBox1_Enter(sender As Object, e As EventArgs) Handles cmbGoods.Enter
        cmbGoods.Items.Clear()
        Dim dt As DataTable = SQLData("Select distinct goods from PSDetail where type='Sale'")
        For i = 0 To dt.Rows.Count - 1
            cmbGoods.Items.Add(dt.Rows(i)(0))
        Next
        If cmbGoods.Text = "" Then
            cmbGoods.Text = "SUPPLY VAN"
        End If
        cmbGoods.SelectAll()
    End Sub

    Private Sub cmbGoods_Leave(sender As Object, e As EventArgs) Handles cmbGoods.Leave
        SQLData("update psdetail set goods='" & cmbGoods.Text & "' where type='sale' and doc=" & txtInvoice.Text)
    End Sub

    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles txtbilty.Leave, txtBiltyPath.Leave
        SQLData("update psdetail set builty='" & txtbilty.Text & "' where type='sale' and doc=" & txtInvoice.Text)
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
            SQLData("update psdetail set BuiltyPath='" & txtBiltyPath.Text & "' where type='sale' and doc=" & Val(dn))
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnBiltyClear.Click
        SQLData("update psdetail set BuiltyPath='' where type='sale' and doc=" & Val(dn))
        txtBiltyPath.Text = ""
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim Result As DialogResult = MessageBox.Show("Do You Really Want to Delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If Result = DialogResult.Yes Then
            SQLData("delete from psdetail where type='Sale' and doc=" & dn &
                "delete from ledgers where type='Sale' and doc=" & dn &
                "delete from psproduct where type='Sale' and doc=" & dn &
                "delete from stock where type='Sale' and doc=" & dn
                )
            MsgBox("Invoice Deleted")
            btnRefresh.PerformClick()
        Else
            MsgBox("Nothing Deleted")
            txtInvoice.Select()
        End If

    End Sub

    Private Sub btnList_Click(sender As Object, e As EventArgs) Handles btnList.Click
        'frmInvoiceList.DTPStart.Value = Date.Today
        frmInvoiceList.DTPEnd.Value = Date.Today.AddDays(1)
        'frmInvoiceList.chkALL.Checked = True
        'frmInvoiceList.chkALL.Checked
        frmInvoiceList.ShowDialog()
        If frmInvoiceList.InvNumber <> "" Then
            txtInvoice.Text = frmInvoiceList.InvNumber
            LoadDoc(txtInvoice.Text)
            Me.Text = "Invoice - " + txtInvoice.Text
            txtInvoice.Select()
            SendKeys.Send("{enter}")
            frmInvoiceList.InvNumber = ""
        End If
        frmInvoiceList.Visible = False
    End Sub

    Private Sub txtCustomerPrice_Leave(sender As Object, e As EventArgs) Handles txtCustomerPrice.Leave

        Dim List As String = "A"
        If txtProduct.Text <> "" Then
            If txtCustomerPrice.Text = "" Then
                List = "A"
            ElseIf txtCustomerPrice.Text = "P" Then
                List = "P"
            ElseIf txtCustomerPrice.Text = "C" Then
                List = "C"
            ElseIf txtCustomerPrice.Text = "B" Then
                List = "B"
            Else
                List = "A"
            End If
            If txtDisc2p.Text <> 100 Then
                PartyDiscount(List)
            End If

            txtPRID.Select()
            txtPRID.SelectAll()
        End If

    End Sub

    Sub PartyDiscount(List)
        If frmLogin.UserLevel.ToUpper <> "ADMIN" Then
            Return
        End If
        Dim Result As DialogResult = MessageBox.Show("Do You Really Want to Update Price List", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If Result = DialogResult.Yes Then

            SQLData(" if (select count(*) from PartyDiscount where acid=" & txtCustomerID.Text & " and company=(select company from Products where code='" & txtPRID.Text & "'))>0
                            update partydiscount set PriceList='" & List & "',Disc1P=" & txtDiscP.Text & "  ,discount=" & txtDisc2p.Text & " where acid=" & txtCustomerID.Text & " and company=(select company from products where code='" & txtPRID.Text & "' )   
                      else
                            insert into partydiscount (ID,Acid,Company,Discount,Disc1P,PriceList) Values (1," & txtCustomerID.Text & ",(select company from products where code='" & txtPRID.Text & "'), " & txtDisc2p.Text & " ,  " & txtDiscP.Text & " , '" & List & "')
                    ")
        End If
    End Sub

    Private Sub txtCustomerName_Leave(sender As Object, e As EventArgs) Handles txtCustomerName.Leave
        If txtCustomerID.Text <> "" And txtCustomerName.Text <> "" Then
            If frmLogin.UserLevel.ToUpper <> "ADMIN" Then
                Return
            End If
            SQLData("Update coa set subsidary='" & txtCustomerName.Text & "' where id=" & txtCustomerID.Text & "   ")
        End If
    End Sub

    Private Sub txtCustomerAddress_Leave(sender As Object, e As EventArgs) Handles txtCustomerAddress.Leave
        If txtCustomerID.Text <> "" And txtCustomerAddress.Text <> "" Then
            SQLData("Update coa set oaddress='" & txtCustomerAddress.Text & "' where id=" & txtCustomerID.Text & "   ")
        End If
    End Sub

    Private Sub txtCustomerCity_Leave(sender As Object, e As EventArgs) Handles txtCustomerCity.Leave
        If txtCustomerID.Text <> "" And txtCustomerCity.Text <> "" Then
            SQLData("Update coa set City='" & txtCustomerCity.Text & "' where id=" & txtCustomerID.Text & "   ")
        End If
    End Sub

    Private Sub txtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        If txtCustomerID.Text <> "" And txtEmail.Text <> "" Then
            SQLData("Update coa set email='" & txtEmail.Text & "' where id=" & txtCustomerID.Text & "   ")
        End If
    End Sub

    Private Sub txtCustomerMobile2_Leave(sender As Object, e As EventArgs) Handles txtCustomerMobile2.Leave
        If txtCustomerID.Text <> "" And txtCustomerMobile2.Text <> "" Then
            SQLData("Update coa set ocell='" & txtCustomerMobile2.Text & "' where id=" & txtCustomerID.Text & "   ")

        End If
    End Sub

    Private Sub txtCDays_Leave(sender As Object, e As EventArgs) Handles txtCDays.Leave
        If txtCustomerID.Text <> "" And txtCDays.Text <> "" Then
            SQLData("Update coa set creditdays='" & txtCDays.Text & "' where id=" & txtCustomerID.Text & "   ")
        End If
    End Sub

    Private Sub Form3_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Control + Keys.L Then
            MsgBox("")
            frmLedger.Show()

        End If

        If (e.Control AndAlso (e.KeyCode = Keys.S)) Then
            btnSMS.PerformClick()
            btnRefresh.PerformClick()
        End If
        If (e.Control AndAlso (e.KeyCode = Keys.W)) Then
            btnWhatsap.PerformClick()
            btnRefresh.PerformClick()
        End If

        If (e.Control AndAlso (e.KeyCode = Keys.O)) Then
            'If lblDoc.BackColor = Color.Red Then
            '    lblDoc.BackColor = Color.Green
            '    lblDoc.Text = "INVOICE - " + frmLogin.MySqlServer + " - " + frmLogin.UserLevel
            '    SQLData("UPDATE PSDETAIL SET STATUS='INVOICE' WHERE TYPE='SALE' AND DOC='" & txtInvoice.Text & "'")
            'Else
            '    lblDoc.BackColor = Color.Red
            '    lblDoc.Text = "ESTIMATE - " + frmLogin.MySqlServer + " - " + frmLogin.UserLevel
            '    SQLData("UPDATE PSDETAIL SET STATUS='ESTIMATE' WHERE TYPE='SALE' AND DOC='" & txtInvoice.Text & "'")
            'End If
            '' SendKeys.Send("{escape}")
            ChangeStatus()

        End If
    End Sub

    Private Sub txtCustomerName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCustomerName.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            If txtCustomerID.Text = "" Then
                SQLData("INSERT INTO COA (DATE,ID,MAIN,ACCATEGORY,CONTROL,Subsidary,UrduName,ContactPerson,OCell,OAddress,City,SPO,code,route,VAN,DAY,creditdays,creditlimit)
                        VALUES(   '" & dtpText.Value.ToString("d") & "',  (SELECT isnull(max(id),0)+1 FROM COA),'TRADE DEBTORS','OTHERS','P','" & txtCustomerName.Text & "','',''," & txtCustomerMobile2.Text & ",'" & txtCustomerAddress.Text & "','" & txtCustomerCity.Text & "'," & txtCustomerID.Text & ",'" & txtRoute.Text & "','',''," & txtCDays.Text & "," & txtCLimit.Text & ")      
                        ")
            End If
        End If

    End Sub

    Private Sub Button1_Click_4(sender As Object, e As EventArgs) Handles tbnPreview.Click
        'rptInvPreview.MdiParent = MainPage
        If rdEstimate.Checked = True Then
            rfEstimates.Show()
            rfEstimates.txtLDN.Text = txtInvoice.Text
            rfEstimates.txtDN.Text = txtInvoice.Text
            rfEstimates.txtRN.Text = ""
            rfEstimates.rdALL.Checked = True
            rfEstimates.btnDisplay.PerformClick()
            Return
        End If


        If rdWReceipt.Checked = True Then
            MainPage.Rcpt = 1
        Else
            MainPage.Rcpt = 0
        End If


        If chkPBal.Checked = True Then
            MainPage.PreviousBalance = 1
        Else
            MainPage.PreviousBalance = 0
        End If

        If rdReceipt.Checked = True Then
            MainPage.rptName = Settings("Reports Folder") + "rptInvoiceReceiptNew.rpt"
        End If

        If rbALL.Checked = True Or rdWReceipt.Checked = True Then
            'MainPage.rptName = settings("Reports Folder") + "rptInvoice3A5.rpt"
            'If DTPRuns.Value >= Convert.ToDateTime("01.06.2020") Then
            'If dtpText.Value >= DTPRuns.Value Then
            MainPage.rptName = Settings("Reports Folder") + "rptInvoice3A5WithRuns.rpt"
            '    End If
            'End If
        End If
        If rdPending.Checked = True Then
            MainPage.rptName = Settings("Reports Folder") + "rptInvoice3A5Pending.rpt"
        End If

        If rbFIT.Checked = True Then
            MainPage.rptName = Settings("Reports Folder") + "rptInvoice3A5FIT.rpt"
        End If
        If rbLocal.Checked = True Then
            MainPage.rptName = Settings("Reports Folder") + "rptInvoice3A5Local.rpt"
        End If

        If rdNetRate.Checked = True Then
            MainPage.rptName = Settings("Reports Folder") + "rptInvoice3A5NetRate.rpt"
        End If
        If rdDC.Checked = True Then
            MainPage.rptName = Settings("Reports Folder") + "rptInvoiceClaim.rpt"
        End If

        MainPage.DocNumber = dn
        rptInvPreview.ShowDialog()
    End Sub

    Private Sub txtRoute_Leave(sender As Object, e As EventArgs) Handles txtRoute.Leave
        SQLData("update coa set route='" & txtRoute.Text & "' where id=" & txtCustomerID.Text)
    End Sub

    Private Sub txtReference_Click(sender As Object, e As EventArgs) Handles txtReference.Click
        'txtReference.SelectAll()
    End Sub

    Private Sub rbALL_CheckedChanged(sender As Object, e As EventArgs) Handles rbALL.CheckedChanged, rbLocal.CheckedChanged, rbFIT.CheckedChanged, rdPending.CheckedChanged, rdNetRate.CheckedChanged, rdDC.CheckedChanged, rdEstimate.CheckedChanged

    End Sub

    Private Sub DTPRuns_Leave(sender As Object, e As EventArgs) Handles DTPRuns.Leave
        If txtCustomerID.Text <> "" Then
            'And DTPRuns.Value >= Convert.ToDateTime("01.06.2020") Then
            SQLData("update coa set RunsDate='" & DTPRuns.Value & "' where id=" & txtCustomerID.Text & "  ")
            txtPRID.Select()
        End If
    End Sub

    Private Sub dgvSale_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSale.CellContentClick
        'MsgBox(e.ColumnIndex)

        If e.ColumnIndex = 19 Then
            Dim row As DataGridViewRow = dgvSale.Rows(e.RowIndex)
            row.Cells("colClaim").Value = Convert.ToBoolean(row.Cells("colClaim").EditedFormattedValue)
            If Convert.ToBoolean(row.Cells("colClaim").Value) = True Then

                Dim PSID = dgvSale.Item("colID", e.RowIndex).Value.ToString
                Dim PSCODE = dgvSale.Item("colCODE", e.RowIndex).Value.ToString
                Dim psqty = dgvSale.Item("colTotalQTY", e.RowIndex).Value.ToString

                SQLData("update psproduct set isclaim=1 where id=" & PSID)
                ' SQLData("update stock set producttype='Claim' where type='sale' and doc=" & dn & " and prid=(select id from products where code='" & PSCODE & "') and qty=" & psqty)
                ' MsgBox(Convert.ToBoolean(row.Cells("colClaim").Value))
                'MsgBox(dgvSale.Item("colid", e.RowIndex).Value.ToString)

            Else

                Dim PSID = dgvSale.Item("colID", e.RowIndex).Value.ToString
                Dim PSCODE = dgvSale.Item("colCODE", e.RowIndex).Value.ToString
                Dim psqty = dgvSale.Item("colTotalQTY", e.RowIndex).Value.ToString

                SQLData("update psproduct set isclaim=0 where id=" & PSID)
                '     SQLData("update stock set producttype='Ready' where type='sale' and doc=" & dn & " and prid=(select id from products where code='" & PSCODE & "') and qty=" & psqty)

            End If


            'Dim Checked As Boolean = CType(dgvSale.CurrentCell.Value, Boolean)
            'If Checked Then
            '    MessageBox.Show("You have checked")
            'Else
            '    MessageBox.Show("You have un-checked")
            'End If


        End If


        If e.ColumnIndex = 0 Then
            'MsgBox(
            'MsgBox(dgvSale.Item("colCODE", e.RowIndex).Value)
            Dim PSID = dgvSale.Item("colID", e.RowIndex).Value.ToString
            Dim PSCODE = dgvSale.Item("colCODE", e.RowIndex).Value.ToString

            ITEMNO = dgvSale.CurrentCell.RowIndex
            'PSPRODUCT
            SQLData("UPDATE PSPRODUCT SET QTY=0,VEST=0,Discount=0,Discount2=0,SchPc=0,VIST=0,PROFIT=0 WHERE ID=" & PSID)
            SQLData("insert psproducthistory (id,date,doc,Type,Prid,ACID,QTY,RATE,VEST,DISCP,DISCOUNT,DISCP2,DISCOUNT2,ESTIMATE,VIST,SchPc,Sch,Profit,isClaim,UserName,UserLevel,EntryDate,EntryStatus) 
                              VALUES( '" & PSID & "','" & dtpText.Value.ToString("d") & "'," & txtInvoice.Text & ",'SALE',(select id from products where code='" & PSCODE & "'),'" & txtCustomerID.Text & "',0,0,0,0,0,0,0,0,0,0,0,0,0,'" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "','EDIT')
")
            'STOCK
            'SQLData("DELETE FROM STOCK WHERE TYPE='SALE' AND DOC=" & dn & " AND PRID=(SELECT ID FROM PRODUCTS WHERE CODE='" & PSCODE & "') ")
            'SQLData("insert into stock (ID,Doc,Type,Date,Department,Pid,Prid,ProductType,Qty,Rate,Amount,SellingType)
            'select (select isnull(max(id),0)+1 from stock) id,ps.Doc,'Sale' Type,'" & dtpText.Value.ToString() & "' Date,ps.department,ps.acid Pid,ps.Prid,case when ps.isclaim=1 then 'Claim' Else 'Ready' end ProductType,(ISNULL(sum(qty),0)+ISNULL(sum(SchPc),0))*-1 Qty, Rate   ,ISNULL(sum(Vist),0) Amount,'Default' SellingType
            'From PSProduct ps
            ' where type='sale' and  ps.doc=" & Val(dn) & " and prid=( select id from products where code='" & txtPRID.Text & "' )
            'Group by PS.RATE,ps.Doc,ps.department,ps.acid,ps.prid,ps.isclaim")
            InvoiceTotals()
            'PSDETAIL
            UpdatePsDetails()
            'LEDGER
            UpDateLedgers()


            loaditems2(txtInvoice.Text)

            dgvSale.FirstDisplayedScrollingRowIndex = ITEMNO
            dgvSale.Rows(ITEMNO).Selected = True
            ITEMNO = 0


            ClearTextBox(gbItems)
            If LastInvoiceNumber = Val(txtInvoice.Text) Then
                LastInvoiceNumber += 1
            End If


        End If

    End Sub

    Sub UpdatePsDetails()
        SQLData("DELETE FROM PSDETAIL WHERE TYPE='SALE' AND DOC=" & dn)
        SQLData("insert into PSDetail(Doc,Date,Type,Acid,Description,ExtraDiscountP,ExtraDiscount,Freight,Received,Amount,DueDate,PBalance,Term,Vehicle,SalesMan,goods,builty,CreditDays,PriceList,BuiltyPath,remarks,GrossProfit)
                                                      SELECT 
                                                      " & Val(dn) & ", '" & dtpText.Value.ToString("d") & "', 'SALE', " & txtCustomerID.Text & ",  '" & VarRef & "' , " & Numbers(txtExrtaDiscountP.Text) & ", " & Numbers(txtExtraDiscountAmount.Text) & ", " & Numbers(txtFreight.Text) & ", " & Numbers(txtCashReceived.Text) & ", " & Numbers(txtNetBillAmount.Text) & ", '" & txtDueDate.Text & "', " & Numbers(txtPreviousBalance.Text) & ", 'CREDIT', '" & cmbSPO.Text & "','" & txtSM.Text & "', '" & cmbGoods.Text & "','" & txtbilty.Text & "', " & txtCDays.Text & ", '" & txtCustomerPrice.Text & "', '" & txtBiltyPath.Text & "', N'" & txtRemarks.Text & "'," & Numbers(txtNetProfit.Text))
        lblDoc.BackColor = Color.Red
        lblDoc.Text = "ESTIMATE - " + frmLogin.MySqlServer + " - " + frmLogin.UserLevel
        lblDoc.Refresh()
    End Sub

    Sub UpDateLedgers()
        SQLData("DELETE FROM LEDGERS WHERE TYPE='SALE' AND DOC=" & dn)
        SQLData("   insert into ledgers (Acid,Date,Doc,Type,Narration,Invoice,Debit,remainingamount)
	                    select Acid,Date,Doc,Type,Description,doc,Amount,amount
	                    from PSDetail where type='sale' and doc=" & Val(dn) & "

                        insert into ledgers (Acid,Date,Doc,Type,Narration,Credit,Invoice)
	                    select 4,Date,Doc,Type,'Sold to:'+(select subsidary from coa where id=acid) des,Amount,doc
	                    from PSDetail where type='sale' and doc=" & Val(dn) & "
                                                                
                        If isnull( (select received from psdetail where type='sale' and doc=" & txtInvoice.Text & "),0)<>0
                        begin
                            insert into ledgers (Acid,Date,Doc,Type,Narration,Invoice,credit)
                            Select Acid,Date,Doc,Type,'Cash Recd: '+Description,doc,received
                            From PSDetail Where Type ='sale' and doc=" & Val(dn) & "
                            insert into ledgers (Acid,Date,Doc,Type,Narration,Invoice,debit)
                            Select 1,Date,Doc,Type,'Cash Recd: '+(select subsidary from coa where id=acid)+' '+ Description,doc,received
                            From PSDetail Where Type ='sale' and doc=" & Val(dn) & "
                        end

                        If isnull( (select freight from psdetail where type='sale' and doc=" & txtInvoice.Text & "),0)<>0
                        begin
                            insert into ledgers (Acid,Date,Doc,Type,Narration,Invoice,credit)
                            Select 7,Date,Doc,Type,Description,doc,freight
                            From PSDetail Where Type ='sale' and doc=" & Val(dn) & "
                        end
                    ")
    End Sub

    Private Sub dtpText_Enter(sender As Object, e As EventArgs) Handles dtpText.Enter
        OldDate = dtpText.Value
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If lblDoc.Text.Contains("INVOICE") Then
            If frmLogin.UserLevel.ToUpper <> "ADMIN" Or frmLogin.UserLevel.ToUpper <> "SUPERVISOR" Then
                MsgBox("This Invoice is finalized, can not be Cancelled!")
                Return
            End If
        End If
        Dim Result As DialogResult = MessageBox.Show("Do You Really Want to Cancel", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If Result = DialogResult.Yes Then
            SQLData("update PSProduct set QTY=0,QTY2=0,VEST=0,Discount=0,Discount2=0,VIST=0,SchPc=0,profit=0 where doc=" & dn & " and type='Sale'
                     update PSDetail set Description=case when CHARINDEX('estimate',description)>1 then concat('NO PAYMENT, CANCELLED AMOUNT: ',Amount,' ')  else  concat('NO PAYMENT, CANCELLED AMOUNT: ',Amount,' ',Description) end,Discount=0,ExtraDiscount=0,Freight=0,Amount=0,Received=0,GrossProfit=0 FROM PSDetail WHERE DOC=" & dn & " and type='sale'
                  --   update stock set QTY=0,AMOUNT=0 FROM STOCK WHERE DOC=" & dn & "
                     update Ledgers set Narration= case when charindex('estimate',narration)>1 then concat('NO PAYMENT, CANCELLED AMOUNT: ',0,' ') else    CONCAT('NO PAYMENT, CANCELLED AMOUNT: ', CASE WHEN DEBIT<>0 THEN Debit ELSE Credit END ,' : ', Narration) end   ,DEBIT=0,Credit=0,remainingamount=0 FROM Ledgers WHERE type='sale' and DOC=" & dn)
            'MsgBox("Invoice Cancelled")
            Console.Beep()
            Dim DT As DataTable = SQLData("SELECT NARRATION FROM LEDGERS WHERE TYPE='SALE' AND DOC=" & dn)
            txtFreight.Text = 0
            txtReference.Text = DT.Rows(0)("NARRATION")
            txtReference.SelectionStart = 0
            txtReference.Focus()
            txtReference.Select(0, 10)
            'btnRefresh.PerformClick()
        Else
            MsgBox("Nothing Cancelled")
            txtInvoice.Select()
        End If
    End Sub

    Private Sub dgvSale_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvSale.CellFormatting

        If e.ColumnIndex = dgvSale.Columns("colAMT").Index Then
            If Not IsDBNull(e.Value) AndAlso Convert.ToDecimal(e.Value) > 0 Then
                e.CellStyle.BackColor = Color.Aquamarine
            Else
                e.CellStyle.BackColor = Color.White
            End If
        End If

        If e.ColumnIndex = dgvSale.Columns("colBillQty").Index Then
            If Not IsDBNull(e.Value) AndAlso Convert.ToDecimal(e.Value) < 0 Then
                e.CellStyle.BackColor = Color.Red
            End If
            If Not IsDBNull(e.Value) AndAlso Convert.ToDecimal(e.Value) = 0 Then
                e.CellStyle.BackColor = Color.Silver
            End If
        End If

    End Sub

    'Private Sub txtOQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOQty.KeyDown
    '    If txtOQty.Text = "" Then
    '        Return
    '    End If
    '    If e.KeyCode = Keys.Enter And txtProduct.Text <> "" Then
    '        SAVE()
    '        e.Handled = True
    '        e.SuppressKeyPress = True
    '    End If
    'End Sub

    Private Sub txtOQty_TextChanged(sender As Object, e As EventArgs) Handles txtOQty.TextChanged
        txtQty.Text = txtOQty.Text
    End Sub

    Private Sub txtDisc2p_Leave(sender As Object, e As EventArgs) Handles txtDisc2p.Leave, txtDiscP.Leave
        Dim List As String = "A"
        If txtProduct.Text <> "" Then
            If txtCustomerPrice.Text = "" Then
                List = "A"
            ElseIf txtCustomerPrice.Text = "P" Then
                List = "P"
            ElseIf txtCustomerPrice.Text = "C" Then
                List = "C"
            ElseIf txtCustomerPrice.Text = "B" Then
                List = "B"
            Else
                List = "A"
            End If
            PartyDiscount(List)
        End If
    End Sub

    Private Sub txtNetAmount_TextChanged(sender As Object, e As EventArgs) Handles txtNetAmount.Leave
        txtDis2Amount.Text = Numbers(txtAmount.Text) - Numbers(txtNetAmount.Text)
        txtDisc2p.Text = 0
        txtDis2Amount.Text = 0
        txtRate.Text = Numbers(txtNetAmount.Text) / Numbers(txtTotalQty.Text)
        txtNetSaleRate.Text = txtRate.Text
        txtProfit.Text = Numbers(txtNetSaleRate.Text) - Numbers(txtCost.Text)
        'txtDisc2p.Text = (Numbers(txtDis2Amount.Text) / Numbers(txtAmount.Text) * 100)
        SAVE()
    End Sub

    Private Sub btnSPO_Click(sender As Object, e As EventArgs) Handles btnSPO.Click
        If cmbSPO.Text <> "" And frmLogin.UserLevel.ToUpper = "ADMIN" Then
            SQLData("update psproduct set spo='" & cmbSPO.Text & "' where type='sale' and doc=" & txtInvoice.Text & " ")
        End If
        loaditems2(txtInvoice.Text)
        cmbSPO.Select()
        cmbSPO.SelectAll()
    End Sub

    Private Sub btnLocation_Click(sender As Object, e As EventArgs) Handles btnLocation.Click
        If cmbLocation.Text <> "" And frmLogin.UserLevel.ToUpper = "ADMIN" Then
            SQLData("update psproduct set department='" & cmbLocation.Text & "' where type='sale' and doc=" & txtInvoice.Text & " ")
        End If
        loaditems2(txtInvoice.Text)
        cmbSPO.Select()
        cmbSPO.SelectAll()
    End Sub

    Private Sub txtSize_Leave(sender As Object, e As EventArgs) Handles txtSize.Leave
        If txtProduct.Text <> "" Then
            SQLData("Update products set size='" & txtSize.Text & "' where code='" & txtPRID.Text & "'")
        End If
    End Sub

    Private Sub cmbGoods_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGoods.TextChanged
        Dim SELSTART As Integer = Me.cmbGoods.SelectionStart
        cmbGoods.Text = cmbGoods.Text.ToUpper()
        cmbGoods.SelectionStart = SELSTART
    End Sub

    Private Sub cmbSPO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSPO.TextChanged
        Dim SELSTART As Integer = cmbSPO.SelectionStart
        'cmbSPO.Text = cmbSPO.Text.ToUpper()
        'cmbSPO.SelectionStart = SELSTART
    End Sub

    Private Sub cmbLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLocation.TextChanged
        Dim SELSTART As Integer = Me.cmbLocation.SelectionStart
        cmbLocation.Text = cmbLocation.Text.ToUpper()
        cmbLocation.SelectionStart = SELSTART
    End Sub

    Private Sub cmbLocation_Leave(sender As Object, e As EventArgs) Handles cmbLocation.Leave
        'If psproductid <> 0 Then
        '    SQLData("update psproduct set department='" & cmbLocation.Text & "' where type='sale' and doc=" & txtInvoice.Text & " and id=" & psproductid)
        'End If
        cmbLocation.Items.Add(cmbLocation.Text)
        cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub Button1_Click_5(sender As Object, e As EventArgs) Handles btnLocationAdd.Click
        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            cmbLocation.DropDownStyle = ComboBoxStyle.DropDown
            cmbLocation.Select()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSPOAdd.Click
        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            cmbSPO.DropDownStyle = ComboBoxStyle.DropDown
            cmbSPO.Select()
        End If
    End Sub

    Private Sub txtRate_Leave(sender As Object, e As EventArgs) Handles txtRate.Leave
        If txtRate.Text < txtCost.Text Then
            Dim Result As DialogResult = MessageBox.Show("Entered price is bellow cost, Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If Result = DialogResult.No Then
                txtPRID.Select()

            End If
        End If

    End Sub

    Sub ChangeStatus()
        If txtReference.Text.Contains("ESTIMATE") And lblDoc.BackColor <> Color.Green Then
            MsgBox("Pls change description first from 'ESTIMATE'!")
            txtReference.Select()
            txtReference.SelectAll()
            Return
        End If
        If lblDoc.Text.Contains("INVOICE") Then
            If frmLogin.UserLevel.ToUpper = "OPERATOR" Then
                MsgBox("Finalized Invoice can not be changed by this user")
                Return
            End If
            lblDoc.BackColor = Color.Red
            lblDoc.Text = "ESTIMATE - " + frmLogin.MySqlServer + " - " + frmLogin.UserLevel
            SQLData("UPDATE PSDETAIL SET STATUS='ESTIMATE' WHERE TYPE='SALE' AND DOC='" & txtInvoice.Text & "'")
        Else
            Dim DT As DataTable = SQLData("SELECT COUNT(*) Count from psproduct WHERE TYPE='SALE' AND DOC=" & txtInvoice.Text & " and PrintStatus is null")
            Dim NullCount As String = ""
            Dim result As DialogResult
            If DT.Rows.Count > 0 Then
                NullCount = Val(DT.Rows(0)(0))
                If NullCount > 0 Then
                    result = MessageBox.Show("This estimate has " & NullCount & " items which are not printed in estimates, Do you still want to convert it into invoice ?", "Pending Items", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If result = DialogResult.No Then
                        Return
                    End If
                End If
            End If
            lblDoc.BackColor = Color.Green
            lblDoc.Text = "INVOICE - " + frmLogin.MySqlServer + " - " + frmLogin.UserLevel
            SQLData("UPDATE PSDETAIL SET STATUS='INVOICE' WHERE TYPE='SALE' AND DOC='" & txtInvoice.Text & "'")
            SQLData("UPDATE psproduct SET PrintStatus='INVOICE',PRINTBY='" & frmLogin.UserName & "',PrintDateTime='" & Date.Now & "' WHERE TYPE='SALE' AND DOC='" & txtInvoice.Text & "'")
        End If
    End Sub

    Private Sub lblDoc_Click(sender As Object, e As EventArgs) Handles lblDoc.Click

        ChangeStatus()
    End Sub

    Private Sub Button1_Click_6(sender As Object, e As EventArgs)

    End Sub

    Sub ChangeBillDiscount(CustomerID As String, Doc As Integer, Company As String, dis1 As Double, dis2 As Double)
        SQLData("Update PSProduct set 
                 DiscP2=" & dis2 & "
                 ,DiscP=" & dis1 & "
                 ,Discount2=round((vest* " & dis2 & " /100),2)
                 ,discount=round(((vest-round(vest* " & dis2 & " /100,2)) * " & dis1 & " /100),2)
                 ,vist=round(vest-(Discount2+ps.discount),0)
                 From PSProduct ps Join Products p on ps.Prid=p.id
                 Where acid =" & CustomerID & " And ps.Qty<>0 And type='sale' and p.Company like '" & Company & "%'
                 And doc=" & Doc & " AND TYPE='SALE'
                 and discp<>100 and discp2<>100

                 update psproduct set profit=(
                 Case when ps.vist<>0 And ps.qty+isnull(ps.schpc,0)<>0 then ps.vist/(ps.qty+isnull(ps.SchPc,0)) else 0 end
-                (select top 1 pss.vist/(pss.qty+isnull(pss.SchPc,0)) from PSProduct pss where pss.prid=ps.Prid And pss.date<=ps.date And pss.vist<>0 And pss.type='purchase' and pss.qty+isnull(pss.schpc,0)<>0 order by date desc)
                 )*qty 
                 From PSProduct ps where doc=" & Doc & "

                Update PSDetail set amount=(select round(sum(vist)-pd.Freight,0) from PSProduct ps where ps.doc=pd.Doc )
                ,GrossProfit=round((select sum(profit) from PSProduct where type='sale' and doc=pd.doc),0)
                From PSDetail pd Where pd.acid =" & CustomerID & " And type='sale'
                And doc=" & Doc & "

                Update Ledgers set Debit=(select amount from PSDetail pd where pd.doc=l.doc and pd.type='sale') 
                From ledgers l Where l.acid =" & CustomerID & " And type='sale' And l.doc=" & Doc & "")
        SQLData("if (select count(*) from PartyDiscount where acid=" & CustomerID & " and company='" & Company & "' )>0 update PartyDiscount set discount=" & dis2 & ",disc1P=" & dis1 & " where acid=" & CustomerID & " and company='" & Company & "' else insert into PartyDiscount (id,acid,company,discount,disc1P,PriceList) values ((select isnull(max(id),0) from PartyDiscount)+1," & CustomerID & ",'" & Company & "'," & dis2 & "," & dis1 & ",'A')")

    End Sub

    Private Sub txtFitDiscount_Leave(sender As Object, e As EventArgs) Handles txtCompanyDiscount2.Leave
        If txtCompanyDiscount2.Text = "" Then
            Return
        End If
        If frmLogin.UserLevel.ToUpper <> "ADMIN" Then
            MsgBox("User not allowed")
            Return
        End If
        Dim dis As Double = If(txtCompanyDiscount2.Text = Nothing, 0, txtCompanyDiscount2.Text)
        Dim dis1 As Double = If(txtCompanyDiscount1.Text = Nothing, 0, txtCompanyDiscount1.Text)
        Dim acid As Integer = txtCustomerID.Text
        Dim doc As Integer = txtInvoice.Text
        Dim result As DialogResult = MessageBox.Show("Pls Confirm Details: " + doc.ToString + " " + cmbDisCompany.Text + " " + dis1.ToString + " " + dis.ToString, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result = DialogResult.No Then
            Return
        End If
        SQLData("Update PSProduct set 
                 DiscP2=" & dis & "
				 ,DiscP=" & dis1 & "
                 ,Discount2=round((vest* " & dis & " /100),2)
				 ,discount=round(((vest-round(vest* " & dis & " /100,2)) * " & dis1 & " /100),2)
				 ,vist=round(vest-(Discount2+ps.discount),0)
                 From PSProduct ps Join Products p on ps.Prid=p.id
                 Where acid =" & acid & " And ps.Qty<>0 And type='sale' and p.Company like '" & cmbDisCompany.Text & "%'
                 And doc=" & doc & " AND TYPE='SALE'
                 and discp<>100 and discp2<>100

                update psproduct set profit=(
Case when ps.vist<>0 And ps.qty+isnull(ps.schpc,0)<>0 then ps.vist/(ps.qty+isnull(ps.SchPc,0)) else 0 end
-
(select top 1 pss.vist/(pss.qty+isnull(pss.SchPc,0)) from PSProduct pss where pss.prid=ps.Prid And pss.date<=ps.date And pss.vist<>0 And pss.type='purchase' and pss.qty+isnull(pss.schpc,0)<>0 order by date desc)
)*qty 
From PSProduct ps where doc=" & doc & "

                Update PSDetail set amount=(select round(sum(vist)-pd.Freight,0) from PSProduct ps where ps.doc=pd.Doc )
                ,GrossProfit=round((select sum(profit) from PSProduct where type='sale' and doc=pd.doc),0)
                From PSDetail pd Where pd.acid =" & acid & " And type='sale'
                And doc=" & doc & "

                Update Ledgers set Debit=(select amount from PSDetail pd where pd.doc=l.doc and pd.type='sale') 
                From ledgers l Where l.acid =" & acid & " And type='sale' And l.doc=" & doc & "")
        SQLData("if (select count(*) from PartyDiscount where acid=" & txtCustomerID.Text & " and company='" & cmbDisCompany.Text & "' )>0 update PartyDiscount set discount=" & dis & ",disc1P=" & dis1 & " where acid=" & txtCustomerID.Text & " and company='" & cmbDisCompany.Text & "' else insert into PartyDiscount (id,acid,company,discount,disc1P,PriceList) values ((select isnull(max(id),0) from PartyDiscount)+1," & txtCustomerID.Text & ",'" & cmbDisCompany.Text & "'," & dis & "," & dis1 & ",'A')")
        LoadDoc(txtInvoice.Text)
        txtInvoice.Select()
        txtInvoice.SelectAll()
    End Sub

    Private Sub dtpText_Validating(sender As Object, e As CancelEventArgs) Handles dtpText.Validating
        If dtpText.Value <> OldDate Then
            If frmLogin.UserLevel = "Operator" Then
                If dtpText.Value < Date.Today Or dtpText.Value > Date.Today.AddDays(2) Then
                    MsgBox("Please enter correct Dates")
                    dtpText.Value = OldDate
                    dtpText.Select()
                End If
            End If
        End If
    End Sub

    Public Function HaveInternetConnection(site) As Boolean

        Try
            Return My.Computer.Network.Ping(site, 50000)
        Catch
            Return False
        End Try

    End Function


    Private Sub Button1_Click_7(sender As Object, e As EventArgs) Handles btnWhatsap.Click
        'If HaveInternetConnection() = False Then

        '    MsgBox("Computer is not connected to the internet.")
        '    Return
        'End If


        Dim FileName As String = PDFGenF(txtInvoice.Text, txtCustomerName.Text)
        Dim ocell As String = txtCustomerMobile2.Text
        Dim InvDate2 As String = DateChange(dtpText.Value)

        Dim FullStringLength As Integer = FileName.Length
        Dim FileNameStart As Integer = FileName.LastIndexOf("\") + 1
        Dim FileNameStop As Integer = FullStringLength - FileNameStart
        Dim OnlyfileName As String = FileName.Substring(FileNameStart, FileNameStop)

        Dim MOB As DataTable = SQLData("select case when ocell2wa='y' then cell2 else ocell end Mobile from coa where id='" & txtCustomerID.Text & "'     ")
        ocell = MOB.Rows(0)("MOBILE")
        'AppInstallMsg(txtCustomerID.Text, ocell)
        ocell = ocell.Substring(1)
        ocell = "92" + ocell.Replace(" ", "")
        '---------------------------
        Dim link As String = ""
        'Dim net As Boolean = HaveInternetConnection("www.google.com")
        'If net = False Then
        '    Dim result As DialogResult = MessageBox.Show("Ineternet not working, Do you want to continue?", "Internet not working", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        '    If result = DialogResult.No Then
        '        Return
        '    End If
        'Else

        '    link = frmRouteWhatsapp.UploadFile(OnlyfileName, "D:\Google Drive ai\db backup\Invoice Temp\" & OnlyfileName)
        '    link = Environment.NewLine + "*بل میں آئٹم کی تفصیل کھولنے کے لئے نیچے دئیے نیلے لنک کو دبائیں*" _
        '    + Environment.NewLine + link + Environment.NewLine + "-----------------------------------------------"

        'End If
        'If link = "No File" Then
        '    MsgBox("No file uploaded")
        '    Return
        'End If

        Dim BillAMT As String = ""
        Dim RecAmt As String = ""
        If Val(Numbers(txtNetBillAmount.Text)) < 0 Then
            BillAMT = " بل کی رقم    :" & Amt(Math.Abs(CInt(txtNetBillAmount.Text)) - 0) & "-"
        Else
            BillAMT = " بل کی رقم    :" & Amt(txtNetBillAmount.Text - 0)
        End If
        If Val(txtCashReceived.Text) <> 0 Then
            RecAmt = Environment.NewLine + " نقد رقم وصول : " & Amt(txtCashReceived.Text)

        End If
        Dim PB As String = ""
        Dim NB As String = ""
        If Val(txtPreviousBalance.Text) <> 0 Then
            PB = Environment.NewLine + "سابقہ بقایا    : " & txtPreviousBalance.Text
            NB = Environment.NewLine + "*کل بقایا رقم  : " & txtNetReceivable.Text & "*"
        End If


        'link = ""
        Dim MyMsg As String = "*بل نمبر  " & txtInvoice.Text & "*" _
            + Environment.NewLine & "*بل کی تاریخ " & InvDate2 & "*" _
            + Environment.NewLine & " بل بنام " & txtUrduName.Text _
            + Environment.NewLine _
            + PB _
            + Environment.NewLine + "بل کی رقم    : " & txtNetBillAmount.Text _
            + RecAmt _
            + NB
        '+ Environment.NewLine _
        '+ Environment.NewLine + "اوپر والا لنک گوگل ڈرائیو سے کھل جائے گا،گوگل ڈرائیوانسٹال کرنے کے لِے نیچے والا لنک دبائیں" _
        '+ Environment.NewLine + "https://play.google.com/store/apps/details?id=com.google.android.apps.docs" _
        '+ Environment.NewLine _
        '+ Environment.NewLine + "*" & "نوٹ: اگر اوپر کے دونوں لنک نیلے نہیں ہیں تو ہمارا موبائیل نمبر سیو کرنے پر لنک نیلے ہو جایں کے اور دبانے پر کھل گے" & "*" _
        '+ Environment.NewLine _
        '+ Environment.NewLine + "احمد انٹرنیشنل فیصل آباد"
        '-------------------------
        'Dim link As String = frmRouteWhatsapp.UploadFile(OnlyfileName, "D:\Google Drive ai\db backup\Invoice Temp\" & OnlyfileName)
        'Dim MyMsg As String = "*Invoice Number # " & txtInvoice.Text & "*" _
        '+ Environment.NewLine + "Bill Amoount  : " & txtNetBillAmount.Text.ToString() _
        '+ Environment.NewLine + "Cash Received: " & txtCashReceived.Text _
        '+ Environment.NewLine + link
        Clipboard.Clear()

        'AppInstallMsg(ocell)
        'Whatsapp(ocell, "")
        'Threading.Thread.Sleep(500)
        'Form3.ClickAt(700, 800)
        'Threading.Thread.Sleep(500)
        'Whatsapp(ocell, MyMsg)
        'SendFile(FileName)
        WASender.StartWhatsAppSession()
        WASender.SendAttachment(ocell, FileName)
        Threading.Thread.Sleep(2000)
        WASender.SendMessage(ocell, MyMsg)

    End Sub

    'Public Declare Sub Mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlag As UInteger)
    'LeftUp = &H4
    'RightDown = &H8
    'RightUp = &H10
    'MiddleDown = &H20
    'MiddleUp = &H40

    Private Const MOUSEEVENTF_LEFTDOWN As UInteger = &H2
    Private Const MOUSEEVENTF_LEFTUP As UInteger = &H4
    Private Declare Sub mouse_event Lib "user32.dll" (ByVal dwFlags As UInteger, ByVal dx As Integer, ByVal dy As Integer, ByVal dwData As UInteger, ByVal dwExtraInfo As Integer)
    Private Declare Function SetCursorPos Lib "user32.dll" (ByVal x As Integer, ByVal y As Integer) As Boolean

    'A method to move the cursor to a given position and click the left button
    Public Shared Sub ClickAt(ByVal x As Integer, ByVal y As Integer)
        'Move the cursor to the desired position
        SetCursorPos(x, y)
        'Press the left button down and then release it
        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
    End Sub

    Private Declare Function BlockInput Lib "user32" Alias "BlockInput" (ByVal fBlock As Long) As Long



    Sub SendFile(File)
        'BlockInput(True)
        'Me.Cursor = New Cursor(Cursor.Current.Handle)
        'Cursor.Position = New Point(512, 705)
        'Mouse_event(&H2)
        'Mouse_event(&H4)
        'ClickAt(650, 700)
        SendKeys.Send("+{TAB}")
        Threading.Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Threading.Thread.Sleep(1000)
        SendKeys.Send("{DOWN}")
        Threading.Thread.Sleep(1000)
        SendKeys.Send("{DOWN}")
        Threading.Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Threading.Thread.Sleep(3000)
        SendKeys.Send(File)
        Threading.Thread.Sleep(4000)
        SendKeys.Send("{ENTER}")
        Threading.Thread.Sleep(3000)
        SendKeys.Send("{ENTER}")
        Threading.Thread.Sleep(3000)
        SendKeys.Send("{TAB}")
        Threading.Thread.Sleep(3000)
        SendKeys.Send("%{TAB}")
        'BlockInput(False)
    End Sub



    Function NumberToText(ByVal n As Integer) As String

        Select Case n
            Case 0
                Return ""

            Case 1 To 19
                Dim arr() As String = {"One", "Two", "Three", "Four", "Five", "Six", "Seven",
    "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
      "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
                Return arr(n - 1) & " "

            Case 20 To 99
                Dim arr() As String = {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"}
                Return arr(n \ 10 - 2) & " " & NumberToText(n Mod 10)

            Case 100 To 199
                Return "One Hundred " & NumberToText(n Mod 100)

            Case 200 To 999
                Return NumberToText(n \ 100) & "Hundreds " & NumberToText(n Mod 100)

            Case 1000 To 1999
                Return "One Thousand " & NumberToText(n Mod 1000)

            Case 2000 To 999999
                Return NumberToText(n \ 1000) & "Thousands " & NumberToText(n Mod 1000)

            Case 1000000 To 1999999
                Return "One Million " & NumberToText(n Mod 1000000)

            Case 1000000 To 999999999
                Return NumberToText(n \ 1000000) & "Millions " & NumberToText(n Mod 1000000)

            Case 1000000000 To 1999999999
                Return "One Billion " & NumberToText(n Mod 1000000000)

            Case Else
                Return NumberToText(n \ 1000000000) & "Billion " _
    & NumberToText(n Mod 1000000000)
        End Select
    End Function




    Sub AppInstallMsg(ACID, ocell)

        Dim dt As DataTable = SQLData("select isnull(crate,0) crate from coa where CASE WHEN OCELL2WA='Y' THEN Cell2 ELSE OCell END='" & ocell & "'")
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("crate").ToString = "0" Then
                Dim MyMsg1 As String = "*اگر بل نہ کھل رہا ہو تو:*" _
            + Environment.NewLine _
            + Environment.NewLine + "1- ہمارا دکان والا نمبر 03308581600 اپنے موبائیل save کر لیں." _
            + Environment.NewLine + "2- اپنے موبائیل میں یہ ایپ انسٹال کر لیں" _
            + Environment.NewLine + "https://play.google.com/store/apps/details?id=com.google.android.apps.docs"

                ocell = ocell.Substring(1)
                ocell = "92" + ocell.Replace(" ", "")
                Whatsapp(ocell, MyMsg1)
                SQLData("update coa set crate='1' where id='" & ACID & "'")
            End If
        End If



    End Sub

    Private Sub btnSMS_Click(sender As Object, e As EventArgs) Handles btnSMS.Click
        SMS(txtCustomerMobile2.Text, txtInvoice.Text, txtNetBillAmount.Text, dtpText.Value, txtSMServer.Text)
        MainPage.msg = "Message Sent successfully"
        DisappearingMsgBox.Show()
        txtInvoice.SelectAll()
        txtInvoice.Select()
    End Sub

    Private Sub txtPerson_Leave(sender As Object, e As EventArgs) Handles txtPerson.Leave
        If txtPerson.Text <> "" Then
            SQLData("update coa set ContactPerson='" & txtPerson.Text & "' where id=" & txtCustomerID.Text)
            txtInvoice.Select()
            txtInvoice.SelectAll()
        End If
    End Sub

    Private Sub txtCTN_Enter(sender As Object, e As EventArgs) Handles txtCTN.Enter
        txtCTN.SelectAll()
    End Sub

    Private Sub txtShopper_Enter(sender As Object, e As EventArgs) Handles txtShopper.Enter
        txtShopper.SelectAll()
    End Sub

    Private Sub txtCTN_Leave(sender As Object, e As EventArgs) Handles txtCTN.Leave
        SQLData("update psdetail set ctn='" & txtCTN.Text & "' where type='sale' and doc='" & txtInvoice.Text & "'")
    End Sub

    Private Sub txtShopper_Leave(sender As Object, e As EventArgs) Handles txtShopper.Leave
        SQLData("update psdetail set Shopper='" & txtShopper.Text & "' where type='sale' and doc='" & txtInvoice.Text & "'")
    End Sub

    Private Sub btnBiltyView_Click(sender As Object, e As EventArgs) Handles btnBiltyView.Click

        Dim dt As DataTable = SQLImageData("SELECT image FROM name_reciepts WHERE type='sale' and doc=" & txtInvoice.Text)
        If dt.Rows(0)("IMAGE") IsNot DBNull.Value Then
            Dim img() As Byte = DirectCast(dt.Rows(0)("IMAGE"), Byte())
            If img.Length > 0 Then

                Dim f As New ViewImage()
                f.WindowState = FormWindowState.Maximized
                ' set pbBilty image
                'f.pbBilty.Image = CType(img().Image.Clone(), Image)

                ' show form
                f.ShowDialog()



                'Try


                Using ms As New IO.MemoryStream(img)
                    f.pbBilty.Image = Image.FromStream(ms, True, True)
                    f.ShowDialog()
                    '        imgShop.Image = Image.FromStream(ms, True, True)
                    '        'imgShop.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                End Using
                '    btnShopRotate.Enabled = True
                'Catch ex As Exception
                '    btnShopRotate.Enabled = False
                '    MsgBox("Shop image load failed: " & ex.Message)

                'End Try
                'btnShopRotate.Enabled = False
            End If
        End If




        'If txtBiltyPath.Text = "" Then
        '    MsgBox("No Bilty to show")
        '    Return
        'End If
        'Dim filename As String = System.IO.Path.Combine(txtBiltyPath.Text)
        'ViewImage.pbBilty.Image = Image.FromFile(filename)
        'ViewImage.Show()
    End Sub



    Private Sub rdIDSort_CheckedChanged(sender As Object, e As EventArgs) Handles rdIDSort.CheckedChanged, rdRackSort.CheckedChanged, rdAlphabetic.CheckedChanged
        loaditems2(Val(txtInvoice.Text))
    End Sub

    Private Sub Button1_Click_8(sender As Object, e As EventArgs) Handles Button1.Click
        If txtEmail.Text = "" Then
            MsgBox("No Email address to send Email to:")
            Return
        End If
        PDFGen(txtInvoice.Text, txtCustomerName.Text)
        Using Mymsg As New MailMessage
            Mymsg.From = New MailAddress("ahmedinternationalfsd@gmail.com")

            Mymsg.To.Add("sanaulhaq@live.com")
            Mymsg.Body = EmailFileName
            Dim at As New Attachment(EmailFileName)
            'Dim at2 As New Attachment("D:\Google Drive ai\db backup\Invoice Temp\CashBook " & Now.Date & ".pdf")
            Mymsg.Attachments.Add(at)
            'Mymsg.Attachments.Add(at2)
            Mymsg.Subject = EmailFileName
            'Mymsg.Priority = Mymsg.Priority.Normal
            Using smtp As New SmtpClient
                smtp.UseDefaultCredentials = False
                smtp.EnableSsl = True
                smtp.Port = 587
                smtp.Host = "smtp.gmail.com"
                smtp.Credentials = New Net.NetworkCredential("ahmedinternationalfsd", "Strong-Gold21")
                smtp.Send(Mymsg)
            End Using

        End Using

        MsgBox("Email Sent")
    End Sub

    Private Sub chkStock_CheckedChanged(sender As Object, e As EventArgs) Handles chkStock.CheckedChanged
        'txtPRID.SelectAll()
        txtPRID.Select()


    End Sub

    Private Sub btnBill_Click(sender As Object, e As EventArgs) Handles btnBill.Click
        Dim Result As DialogResult = MessageBox.Show("Do you want to print On Thermal Printer ?", "Print Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.No Then
            txtInvoice.Focus()
            txtInvoice.SelectAll()
            Return
        End If
        'Dim DT As DataTable = txt_to_data("D:\Settings.txt", True, "=")
        'Dim DRows() As DataRow = DT.Select("PARAMETER='THERMAL PRINTER'")
        'Dim TPrinter As String = ""
        ''If DRows.Length = 0 Then

        ''End If
        'If DRows.Length > 0 Then
        '    For Each row As DataRow In DRows
        '        TPrinter = row(1).ToString
        '    Next
        '    MainPage.ThermalPrinter = TPrinter
        'End If
        Dim tPrinter As String = Settings("Thermal Printer")

        MainPage.Rcpt = 0
        Dim cryRpt As New ReportDocument

        cryRpt.Load(Settings("Reports Folder") + "thermal invoice.rpt")
        Try

            'cryRpt.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In cryRpt.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next

            cryRpt.SetParameterValue("DocNumber", txtInvoice.Text)
            cryRpt.SetParameterValue("PreBalance", 0)
            cryRpt.SetParameterValue("CompanyName", 0)
            cryRpt.SetParameterValue("RECPT", MainPage.Rcpt)
            If MainPage.ThermalPrinter <> "" Then
                cryRpt.PrintOptions.PrinterName = tPrinter
                cryRpt.PrintToPrinter(1, False, 0, 0)
                SQLData("update psproduct set PrintStatus='Bill',PrintBy='" & frmLogin.UserName & "',PrintDateTime='" & Date.Now & "' where type='Sale' and doc=" & txtInvoice.Text)
            End If
            cryRpt.Close()
            cryRpt.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox1_Enter_1(sender As Object, e As EventArgs) Handles cmbDisCompany.Enter

        Dim dt As DataTable = SQLData("Select distinct company from products p join PSProduct ps on p.id=ps.prid where ps.type='sale' and ps.doc=" & txtInvoice.Text)
        cmbDisCompany.Items.Clear()
        If dt.Rows.Count > 0 Then
            For n = 0 To dt.Rows.Count - 1
                cmbDisCompany.Items.Add(dt.Rows(n)("Company").ToString)
            Next

        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        rfEstimates.txtLDN.Text = txtInvoice.Text
        rfEstimates.txtDN.Text = txtInvoice.Text
        rfEstimates.txtRN.Text = ""
        rfEstimates.rdSeparat.Checked = True
        rfEstimates.dtpStart.Value = dtpText.Value
        rfEstimates.dtpEnd.Value = dtpText.Value
        rfEstimates.Show()
        'rfEstimates.btnDisplay.PerformClick()





        'Dim OptionalQuery As String = ""
        'Dim tPrinter As String = settings("Thermal Printer")
        'Dim FocusCompany As String = "%"
        'Dim FocusCompany2 As String = "%"
        'Dim OPR As String = "LIKE"
        'Dim OPR2 As String = "OR"
        'If rbALL.Checked Then
        '    FocusCompany = "%"
        '    OPR = "LIKE"
        '    OPR2 = "OR"
        'End If
        'If rbFIT.Checked Then
        '    FocusCompany = "FIT%"
        '    FocusCompany2 = "EXCEL%"
        '    OPR = "LIKE"
        '    OPR2 = "OR"
        'End If
        'If rbLocal.Checked Then
        '    FocusCompany = "FIT%"
        '    FocusCompany2 = "EXCEL%"
        '    OPR = "NOT LIKE"
        '    OPR2 = "AND"
        'End If

        'MainPage.Rcpt = 0
        'Dim cryRpt As New ReportDocument
        'Dim ItemNumber As Integer = 0
        'cryRpt.Load(settings("Reports Folder") + "thermal estimate.rpt")
        'Try

        '    'cryRpt.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        '    For Each tb As Table In cryRpt.Database.Tables
        '        tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
        '        tb.ApplyLogOnInfo(tb.LogOnInfo)
        '    Next
        '    If txtItemNumber.Text <> "" Then
        '        ItemNumber = Val(txtItemNumber.Text)
        '    Else
        '        ItemNumber = 0
        '    End If
        '    If ChkPendingItems.Checked Then
        '        OptionalQuery = " and PrintStatus is null"
        '        ItemNumber = 0
        '    Else
        '        OptionalQuery = ""

        '    End If

        '    cryRpt.SetParameterValue("DocNumber", txtInvoice.Text)
        '    cryRpt.SetParameterValue("ItemNumber", ItemNumber)
        '    cryRpt.SetParameterValue("Company", FocusCompany)
        '    cryRpt.SetParameterValue("Company2", FocusCompany2)
        '    cryRpt.SetParameterValue("OPR", OPR)
        '    cryRpt.SetParameterValue("OPR2", OPR2)
        '    cryRpt.SetParameterValue("Query", OptionalQuery)
        '    cryRpt.SetParameterValue("User", frmLogin.UserName)
        '    If MainPage.ThermalPrinter <> "" Then
        '        cryRpt.PrintOptions.PrinterName = tPrinter
        '        cryRpt.PrintToPrinter(1, False, 0, 0)
        '        SQLData("with cte as (
        '            select row_number() over (order by ps.id) rn,type,Doc,Company,PrintStatus,PrintBy,PrintDateTime from PsProduct ps join Products p on ps.prid=p.id where type='sale' and doc=" & txtInvoice.Text & "
        '            ) update cte set PrintStatus='Estimate',PrintBy='" & frmLogin.UserName & "',PrintDateTime='" & Date.Now & "' WHERE RN>=" & ItemNumber & " AND (COMPANY " & OPR & "  '%" & FocusCompany & "%' " & OPR2 & " COMPANY " & OPR & " '%" & FocusCompany2 & "%')
        '            ")
        '        'MsgBox("PRINTED")
        '    End If
        '    cryRpt.Close()
        '    cryRpt.Dispose()
        '    'SQLData("update psproduct set printstatus='Estimate',PrintedBy='" & frmLogin.UserName & "',PrintTime='" & Date.Now & "' where type='sale' and doc=" & txtInvoice.Text)


        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        txtItemNumber.Text = ""
        txtInvoice.Select()
        txtInvoice.SelectAll()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPendingItems.CheckedChanged
        If ChkPendingItems.Checked Then
            txtItemNumber.Enabled = True
        Else
            txtItemNumber.Enabled = False
        End If
    End Sub

    Public Sub CuTextBox(parent As Control)
        For Each ctrl As Control In parent.Controls
            ' Handle TextBox controls
            If TypeOf ctrl Is TextBox Then
                AddHandler DirectCast(ctrl, TextBox).Enter, AddressOf TxtBoxEnter
                AddHandler DirectCast(ctrl, TextBox).Leave, AddressOf TxtBoxLeave
            End If

            ' Handle RadioButton controls

            ' Recursively handle nested controls (e.g., in GroupBox, Panel, etc.)
            If ctrl.HasChildren Then
                CuTextBox(ctrl)
            End If
        Next
    End Sub

    Sub TxtBoxEnter(sender As Object, e As EventArgs)
        If TypeOf sender Is TextBox Then
            Dim txtBox As TextBox = DirectCast(sender, TextBox)
            txtBox.BackColor = Color.Tan
            txtBox.SelectAll()
        End If

    End Sub

    Sub TxtBoxLeave(sender As Object, e As EventArgs)
        If TypeOf sender Is TextBox Then
            Dim txtBox As TextBox = DirectCast(sender, TextBox)
            txtBox.BackColor = Color.White
            txtBox.SelectAll()
        End If

    End Sub




End Class

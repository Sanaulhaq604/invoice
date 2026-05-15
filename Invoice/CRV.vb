Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class CRV
    Dim BatchChange As Boolean = False
    Dim NetDebit As Integer
    Private Declare Function GetActiveWindow Lib "user32" Alias "GetActiveWindow" () As IntPtr

    Private Declare Function GetWindowRect Lib "user32" _
                    (ByVal hwnd As IntPtr,
                    ByRef lpRect As RECT) _
                    As Integer

    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    Private Sub Buttonx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonx.Click
        Dim r As New RECT
        GetWindowRect(GetActiveWindow, r)
        Dim img As New Bitmap(100, 400)
        Dim gr As Graphics = Graphics.FromImage(img)
        'gr.CopyFromScreen(New Point(r.Left, r.Top), Point.Empty, img.Size)
        gr.CopyFromScreen(New Point(100, 150), Point.Empty, img.Size)
        'gr.CopyFromScreen(New Point(5, 10), Point.Empty, img.Size)
        img.Save("test.gif")
        txtACID.Select()
        txtACID.SelectAll()
        'Process.Start("test.png")
    End Sub






    Dim SessionRecovery As Integer = 0
    Dim LastVocuher As Integer = 0
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub CRV_Load(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Activated, MyBase.Enter
        'MsgBox(frmLogin.UserLevel)
        Form3.CuTextBox(Me)
        lblDoc.Text = "Cash Receipt Voucher - " + frmLogin.MySqlServer + " - " + frmLogin.UserLevel
        vno()
        dgvUpdate()
        'dgvCRV.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvCRV.Columns("Amount").DefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
        'dgvCRV.Columns("Amount").DefaultCellStyle.Format = "N2"
    End Sub

    Sub dgvUpdate()
        'MsgBox(dtp1.Value.ToString("d"))
        Dim DGVOrder As String = ""
        If rdDoc.Checked Then
            DGVOrder = "doc"
        ElseIf rdRNO.Checked Then
            DGVOrder = "route,rno"
        ElseIf rdCustomer.Checked Then
            DGVOrder = "subsidary"
        ElseIf rdAmount.Checked Then
            DGVOrder = "credit"
        End If
        Dim dt2 As DataTable = SQLData("select ROW_NUMBER() over (order by l.date) rn,l.Date,Doc,l.acid,a.subsidary Title,a.UrduName,a.route,Narration,isnull(credit,0) Amount,isnull(rno,0) RNO from ledgers l join coa a on l.Acid=a.Id where type='CRV' and l.date='" & dtp1.Value.ToString("d") & "' and acid<>1 and route like '%" & txtRoute.Text & "%' and subsidary like '%" & txtCusName.Text & "%' and narration like '%" & txtNarrationFilter.Text & "%' order by " & DGVOrder)
        If dt2.Rows.Count > 0 Then
            dgvCRV.DataSource = dt2
        Else
            If dgvCRV.Rows.Count > 0 Then
                dgvCRV.DataSource.clear()
            End If
            txtDayTotal.Text = 0
        End If
        Dim dtTotals As DataTable = SQLData("select ROW_NUMBER() over (order by route) RN,a.route,sum(isnull(credit,0)) Credit
                                                    from ledgers l join coa a on l.acid=a.id
                                                    where l.date='" & dtp1.Value.ToString("d") & "' and type='crv' and acid<>1
                                                    and a.route like '%" & txtRoute.Text & "%'
                                                    group by a.route
                                                    order by a.route")
        Dim OB As Integer = 0
        Dim OBtable As DataTable = SQLData("SELECT isnull(SUM(isnull(DEBIT,0))-SUM(isnull(CREDIT,0)),0) OB FROM LEDGERS WHERE ACID=1 AND date>'2023-10-31' and DATE<'" & dtp1.Value.ToString("d") & "'")
        If OBtable.Rows.Count > 0 Then
            OB = OBtable.Rows(0)("OB")
        Else
            OB = 0
        End If
        Dim DayTotals As DataTable = SQLData("SELECT ISNULL(SUM(DEBIT),0) DayDebit,ISNULL(SUM(Credit),0) DayCredit FROM LEDGERS WHERE ACID=1 AND DATE='" & dtp1.Value.ToString("d") & "'")
        Dim TodayReceipts As Integer = 0
        Dim TodayPayments As Integer = 0
        Dim TodayBal As Integer = 0
        Dim NetCashBalance As Integer = 0
        If DayTotals.Rows.Count > 0 Then
            TodayReceipts = DayTotals.Rows(0)("DayDebit")
            TodayPayments = DayTotals.Rows(0)("DayCredit")
        Else
            TodayReceipts = 0
            TodayPayments = 0

        End If
        TodayBal = TodayReceipts - TodayPayments
        NetCashBalance = OB + TodayBal

        txtOB.Text = Form3.Amt(OB)
        txtTodayReceipts.Text = Form3.Amt(TodayReceipts)
        txtTodayPayments.Text = Form3.Amt(TodayPayments)
        txtNetCashBalance.Text = Form3.Amt(NetCashBalance)

        'MsgBox(dt2.Rows.Count)
        Dim DayTotal As Integer = 0




        If dtTotals.Rows.Count > 0 Then
            dgvTotals.DataSource = dtTotals
            dgvTotals.ClearSelection()
            For n = 0 To dtTotals.Rows.Count - 1
                DayTotal += dtTotals.Rows(n)("Credit")
            Next
            txtDayTotal.Text = DayTotal
        Else
            If dgvTotals.Rows.Count > 0 Then
                dgvTotals.DataSource.clear()
            End If
        End If


    End Sub

    Private Sub dtp1_Leave(sender As Object, e As EventArgs) Handles dtp1.Leave, dtp1.ValueChanged, rdAmount.CheckedChanged, rdCustomer.CheckedChanged, rdDoc.CheckedChanged, rdRNO.CheckedChanged

        dgvUpdate()
    End Sub
    Sub bit()




    End Sub




    Sub save()
        Dim ConditionalInsertQuery As String = ""
        Dim ConditionalInsertValue As String = ""
        Dim Narr As String = ""
        If frmLogin.UserLevel.ToUpper = "ADMIN" Or frmLogin.UserLevel.ToUpper = "SUPERVISOR" Then
            ConditionalInsertQuery = ",ReceiptStatus"
            ConditionalInsertValue = ",'CRV'"
            Narr = txtNarration.Text
        Else
            ConditionalInsertQuery = ""
            ConditionalInsertValue = ""
            Narr = "Pending - Cash Recd. by " & frmLogin.UserName & " ," & txtNarration.Text
        End If
        If Val(txtCRVNo.Text) = LastVocuher Then
            Dim docDT As DataTable = SQLData("Select isnull(doc,1) Doc from docnumber where type='CRV'")
            LastVocuher = docDT.Rows(0)(0)
            SQLData("update docnumber set doc=" & LastVocuher + 1 & " where type='crv' ")
            txtCRVNo.Text = LastVocuher
            Me.Text = "Cash Receipt - " + txtCRVNo.Text
        End If
        SQLData("
            if (select count(*) from Ledgers where type='CRV' and doc=" & txtCRVNo.Text & ")=0
                begin
                insert into ledgers (date,type,doc,acid,narration,credit,EntryBy,EntryDateTime" & ConditionalInsertQuery & ")
                select '" & dtp1.Value.ToString("d") & "','CRV'," & txtCRVNo.Text & "," & txtACID.Text & ",N'" & Narr & "'," & Form3.Numbers(txtAmount.Text) & ",'" & frmLogin.UserName & "','" & Date.Now & "'" & ConditionalInsertValue & "

                insert into ledgers (date,type,doc,acid,narration,debit,EntryBy,EntryDateTime" & ConditionalInsertQuery & ")
                select '" & dtp1.Value.ToString("d") & "','CRV'," & txtCRVNo.Text & ",1,N'" & Narr & " :From " & txtCustomerName.Text & "'," & Form3.Numbers(txtAmount.Text) & ",'" & frmLogin.UserName & "','" & Date.Now & "'" & ConditionalInsertValue & "

                insert into ledgersHistory (date,type,doc,acid,narration,credit,UserName,UserLevel,EntryDate,EntryStatus)
                select '" & dtp1.Value.ToString("d") & "','CRV'," & txtCRVNo.Text & "," & txtACID.Text & ",N'" & Narr & "'," & Form3.Numbers(txtAmount.Text) & ",'" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "' , 'SAVE'
                                                       
                end
            else
                begin
                update ledgers set acid=" & txtACID.Text & ",date='" & dtp1.Value.ToString("d") & "',narration=N'" & txtNarration.Text & "',credit=" & Form3.Numbers(txtAmount.Text) & " where type='CRV' and doc=" & txtCRVNo.Text & " and acid<>1
                update ledgers set date='" & dtp1.Value.ToString("d") & "',narration='" & txtNarration.Text & " :From " & txtCustomerName.Text & "',debit=" & Form3.Numbers(txtAmount.Text) & " where type='CRV' and doc=" & txtCRVNo.Text & " and acid=1

                insert into ledgersHistory (date,type,doc,acid,narration,credit,UserName,UserLevel,EntryDate,EntryStatus)
                select '" & dtp1.Value.ToString("d") & "','CRV'," & txtCRVNo.Text & "," & txtACID.Text & ",N'" & txtNarration.Text & "'," & Form3.Numbers(txtAmount.Text) & ",'" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "' , 'EDIT'
                                                        
                end
            ")


        SessionRecovery += Form3.Numbers(txtAmount.Text)
        txtSessionTotal.Text = SessionRecovery
        If chkSMS.Checked = True Then
            SMS(txtOCell.Text, txtCRVNo.Text, txtAmount.Text, dtp1.Value, txtSMServer.Text)
        End If

        textclear()
        If dgvHistory.Rows.Count > 0 Then
            dgvHistory.DataSource.clear()
        End If

        'insert into ledgersHistory (id,date,type,doc,acid,narration,credit,UserName,UserLevel,EntryDate,EntryStatus)
        '                                                select (select max(id) from ledgers),'" & dtp1.Value.ToString("d") & "','CRV'," & txtCRVNo.Text & "," & txtACID.Text & ",'" & txtNarration.Text & "'," & Form3.Numbers(txtAmount.Text) & "," & frmLogin.UserName & "," & frmLogin.UserLevel & ",'" & Date.Now & "' , 'EDIT'



        vno()
        dgvUpdate()
        If dgvCRV.Rows.Count > 0 Then

            dgvCRV.FirstDisplayedScrollingRowIndex = dgvCRV.Rows.Count - 1
            dgvCRV.Rows(dgvCRV.Rows.Count - 1).Selected = True
        End If
        txtACID.Select()
        NetDebit = 0
    End Sub

    Sub textclear()
        txtACID.Clear()
        txtAmount.Clear()
        txtCustomerName.Clear()
    End Sub

    Sub vno()
        Dim dt As DataTable = SQLData("select isnull(doc,1) Doc from DocNumber where type='CRV'")
        If dt.Rows.Count > 0 Then
            LastVocuher = Val(dt.Rows(0)(0))
            txtCRVNo.Text = LastVocuher
            Me.Text = "Cash Receipt - " + LastVocuher.ToString()
        End If
    End Sub

    Private Sub ctbSave_Click(sender As Object, e As EventArgs) Handles ctbSave.Click
        save()
    End Sub

    Function BalanceIncrease(AccID, DAT) As String
        If AccID = "" Then
            Return 0
        End If
        Dim dt As DataTable = SQLData("Select isnull(sum(debit),0) Debit,isnull(sum(credit),0) Credit from ledgers where acid=" & AccID & " and date>=(select top 1 date from ledgers where acid=" & AccID & " and debit>0 and date<='" & DAT & "'  order by date desc) ")
        If dt.Rows.Count > 0 Then
            Dim Debit As Integer = dt.Rows(0)("Debit")
            Dim Credit As Integer = dt.Rows(0)("Credit")
            Return Val(Debit) - Val(Credit)

        Else
            Return ""
        End If
    End Function

    Private Sub txtACID_Leave(sender As Object, e As EventArgs) Handles txtACID.Leave
        If txtACID.Text = "" Then
            NetDebit = 0
            If dgvHistory.Rows().Count > 0 Then
                dgvHistory.DataSource.clear()
            End If

            Return
        End If
        Dim TotalPayment As DataTable = SQLData("select isnull(sum(debit),0) Debit,isnull(sum(credit),0) Credit from ledgers where acid=" & txtACID.Text & " and month(date) =" & dtp1.Value.Month & " and year(date) = " & dtp1.Value.Year)
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
        Dim dt As DataTable = SQLData("Select Subsidary,case when ocell2wa='y' then cell2 else ocell end ocell,isnull(urduname,'') UrduName from coa where id=" & txtACID.Text & "")
        If dt.Rows.Count > 0 Then
            txtCustomerName.Text = dt.Rows(0)("Subsidary")
            txtUrduName.Text = dt.Rows(0)("UrduName")
            txtOCell.Text = dt.Rows(0)("Ocell")
            PreviousBalance()
        End If
        If txtNarration.Text <> "" Then
            txtAmount.SelectAll()
            txtAmount.Select()
        End If
        NetDebit = BalanceIncrease(txtACID.Text, dtp1.Value.ToString("d"))
        txtBalanceIncrease.Text = Form3.Amt(NetDebit)
        txtBalanceIncrease.Text = Form3.Amt(NetDebit - Form3.Numbers(txtAmount.Text))
        If (txtBalanceIncrease.Text) > 0 Then
            txtBalanceIncrease.BackColor = Color.Red
            txtBalanceIncrease.ForeColor = Color.White
        Else
            txtBalanceIncrease.BackColor = Color.Green
        End If
        histroyGrid()
    End Sub

    Sub histroyGrid()
        Dim dt As DataTable = SQLData("select top 12 date,TYPE+'-'+CONVERT(VARCHAR(10),DOC) DOC,narration,isnull(debit,0) Debit,isnull(credit,0) Credit from ledgers where acid=" & txtACID.Text & " order by date desc,TYPE ")
        If dt.Rows.Count > 0 Then
            dgvHistory.DataSource = dt
        Else
            If dgvHistory.Rows.Count > 0 Then
                dgvHistory.DataSource.clear()
            End If
        End If

    End Sub


    Private Sub txtAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            save()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtACID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtACID.KeyDown
        If e.KeyCode = Keys.Enter And txtACID.Text <> "" Then
            SendKeys.Send("{tab}")
            e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Enter And txtACID.Text = "" Then
            e.Handled = True
            frmPartySearch.ShowDialog()
            txtACID.Text = frmPartySearch.acID
            frmPartySearch.Dispose()
        End If

    End Sub

    Private Sub dgvCRV_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles dgvCRV.ColumnAdded
        'e.Column.DefaultCellStyle = New DataGridViewCellStyle(e.Column.DefaultCellStyle)
        'e.Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub txtACID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtACID.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCRVNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCRVNo.KeyDown
        If e.KeyCode = Keys.Down Then
            txtCRVNo.Text = Val(txtCRVNo.Text) - 1
            Me.Text = "Cash Receipt - " + txtCRVNo.Text
            DocLoad()
        End If
        If e.KeyCode = Keys.Up And txtCRVNo.Text < LastVocuher - 1 Then
            txtCRVNo.Text = Val(txtCRVNo.Text) + 1
            Me.Text = "Cash Receipt - " + txtCRVNo.Text
            DocLoad()
        End If
        If e.KeyCode = Keys.Enter Then
            DocLoad()
        End If

    End Sub

    Sub PreviousBalance()
        Dim dt As DataTable = SQLData("select isnull(sum(debit),0)-isnull(sum(credit),0) Bal from ledgers where acid=" & txtACID.Text & " and date<='" & dtp1.Value.ToString("d") & "' and doc<>" & txtCRVNo.Text)
        txtPBal.Text = Form3.Amt(dt.Rows(0)("Bal"))
    End Sub

    Sub DocLoad()
        Dim dt As DataTable = SQLData("select l.date,l.acid,a.Subsidary,l.Narration,l.Credit,isnull(urduname,'') UrduName from ledgers l join coa a on l.acid=a.id where l.type='CRV' and  acid<>1 and doc=" & txtCRVNo.Text)
        If dt.Rows.Count = 0 Then
            MsgBox("VOUCHER NOT FOUND!")
            Return
        End If
        dtp1.Value = dt.Rows(0)("date")
        txtACID.Text = dt.Rows(0)("acid")
        txtCustomerName.Text = dt.Rows(0)("subsidary")
        txtNarration.Text = dt.Rows(0)("narration")
        txtAmount.Text = dt.Rows(0)("credit")
        txtUrduName.Text = dt.Rows(0)("UrduName")
        dgvUpdate()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        dtp1.Value = Now.Date
        vno()
        textclear()
        NetDebit = 0
        If dgvHistory.Rows.Count > 0 Then
            dgvHistory.DataSource.clear()
        End If
        dgvUpdate()
        dtp1.Select()
    End Sub

    Sub itemsfromGrid(row As DataGridViewRow)
        If frmLogin.UserLevel.ToUpper <> "ADMIN" And frmLogin.UserLevel.ToUpper <> "SUPERVISOR" Then
            MsgBox("You are not authorized to edit existing voucher!")
            Return
        End If
        txtCRVNo.Text = row.Cells("colDoc").Value.ToString()
        Me.Text = "Cash Receipt - " + txtCRVNo.Text
        txtACID.Text = row.Cells("colACID").Value.ToString()
        txtCustomerName.Text = row.Cells("colCustomer").Value.ToString()
        txtNarration.Text = row.Cells("colNarration").Value.ToString()
        txtAmount.Text = row.Cells("colAmount").Value.ToString()
        txtAmount.SelectAll()
        txtAmount.Select()
    End Sub

    Private Sub dgvCRV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCRV.CellDoubleClick
        itemsfromGrid(dgvCRV.CurrentRow)
    End Sub

    Private Sub dgvCRV_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvCRV.KeyDown
        If e.KeyCode = Keys.Enter And dgvCRV.Rows.Count > 0 Then
            e.Handled = True
            itemsfromGrid(dgvCRV.CurrentRow)
        End If

    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        txtNBal.Text = Form3.Amt(Form3.Numbers(txtPBal.Text) - Form3.Numbers(txtAmount.Text))
        'txtAmount.Text = Form3.Amt(Form3.Numbers(txtAmount.Text))
        txtBalanceIncrease.Text = Form3.Amt(NetDebit - Form3.Numbers(txtAmount.Text))
        If (txtBalanceIncrease.Text) > 0 Then
            txtBalanceIncrease.BackColor = Color.Red
            txtBalanceIncrease.ForeColor = Color.White
        Else
            txtBalanceIncrease.BackColor = Color.Green
        End If
        txtAmount.Text = Format(Val(Replace(txtAmount.Text, ",", "")), "#,###,###")
        txtAmount.SelectionStart = txtAmount.TextLength

    End Sub

    Sub btnWhatsApp()
        Dim UName As String = ""
        For n = 0 To dgvCRV.Rows.Count - 1
            Dim CusID As String = dgvCRV.Item("colACID", n).Value
            Dim CRVNumber As String = dgvCRV.Item("colDoc", n).Value
            Dim UrduName As String = dgvCRV.Item("ColUrduName", n).Value.ToString

            lblCustomerName.Text = UrduName
            lblCustomerName.Refresh()

            'Dim PreBal As DataTable = SQLData("select sum(isnull(debit,0))-sum(isnull(credit,0)) PreBal from ledgers where acid=" & CusID & " and date<='" & dtp1.Value & "' and type+cast(doc as varchar(10))<>'CRV" & CRVNumber & "' and acid<>1")
            'Dim PreviousBalance As String = PreBal.Rows(0)(0)
            Dim PreviousBalance As String = PreBalance(CusID.ToString, dgvCRV.Item("colDate", n).Value, "CRV", CRVNumber)

            Dim cell As DataTable = SQLData("select case when ocell2wa='y' then cell2 else ocell end Mobile from coa where id=" & CusID)
            Dim InvDate2 As String = DateChange(dgvCRV.Item("colDate", n).Value)
            Dim mobile As String = cell.Rows(0)(0)
            Dim NetBalance As String = PreviousBalance - dgvCRV.Item("colAmount", n).Value
            If UrduName.Trim = "" Then
                UName = ""
            Else
                UName = "%0a وصولی بنام :" & UrduName
            End If
            Dim MyMsg As String = "*وصولی نمبر" + " " + dgvCRV.Item("colDoc", n).Value.ToString + "*" _
            + Environment.NewLine + "وصولی کی تاریخ" + " " + InvDate2 _
            + UName _
            + Environment.NewLine _
            + Environment.NewLine + "*سابقہ یقایا" + " " + Form3.Amt(PreviousBalance.ToString) + "*" _
            + Environment.NewLine + "وصولی کی رقم" + " " + Form3.Amt(dgvCRV.Item("colAmount", n).Value.ToString) _
            + Environment.NewLine + "*کل بقایا بیلنس" + " " + Form3.Amt(NetBalance.ToString) + "*" _
            + Environment.NewLine _
            + Environment.NewLine + "احمد انٹرنیشنل - فیصل آباد"
            mobile = mobile.Substring(1)
            mobile = "92" + mobile.Replace(" ", "")
            Form3.Whatsapp(mobile, MyMsg)
            'Form3.Whatsapp(mobile, MyMsg)
            Threading.Thread.Sleep(txtDelay.Text * 1000)
        Next
        Console.Beep(500, 3000)
    End Sub

    Sub CRVWhatsapp()
        Dim UName As String = ""
        Dim PreB As String = ""
        Dim NetB As String = ""
        Dim n As Integer = dgvCRV.CurrentCell.RowIndex
        Dim CusID As String = dgvCRV.Item("colACID", n).Value
        Dim CRVNumber As String = dgvCRV.Item("colDoc", n).Value
        Dim UrduName As String = dgvCRV.Item("ColUrduName", n).Value.ToString

        lblCustomerName.Text = UrduName
        lblCustomerName.Refresh()

        'Dim PreBal As DataTable = SQLData("select sum(isnull(debit,0))-sum(isnull(credit,0)) PreBal from ledgers where acid=" & CusID & " and date<='" & dtp1.Value & "' and type+cast(doc as varchar(10))<>'CRV" & CRVNumber & "' and acid<>1")
        'Dim PreviousBalance As String = PreBal.Rows(0)(0)
        Dim PreviousBalance As String = PreBalance(CusID.ToString, dgvCRV.Item("colDate", n).Value, "CRV", CRVNumber)

        Dim cell As DataTable = SQLData("select case when ocell2wa='y' then cell2 else ocell end Mobile from coa where id=" & CusID)
        Dim InvDate2 As String = DateChange(dgvCRV.Item("colDate", n).Value)
        'Dim InvDate2 As String = frmInvoiceList.DateChange(dtp1.Value)
        Dim mobile As String = cell.Rows(0)(0)
        Dim NetBalance As String = PreviousBalance - dgvCRV.Item("colAmount", n).Value
        If UrduName.Trim = "" Then
            UName = ""
        Else
            UName = "%0a وصولی بنام :" & UrduName
        End If

        If chkPB.Checked = False Then
            PreB = ""
            NetB = ""
        Else
            PreB = "%0a *کل بقایا بیلنس" + " " + Form3.Amt(PreviousBalance.ToString) + "*"
            NetB = "%0a *کل بقایا بیلنس" + " " + Form3.Amt(NetBalance.ToString) + "*"
        End If



        Dim MyMsg As String = "*وصولی نمبر" + " " + dgvCRV.Item("colDoc", n).Value.ToString + "*" _
            + Environment.NewLine + "وصولی کی تاریخ" + " " + InvDate2 _
            + UName _
            + Environment.NewLine _
            + PreB _
            + Environment.NewLine + "وصولی کی رقم" + " " + Form3.Amt(dgvCRV.Item("colAmount", n).Value.ToString) _
            + NetB _
            + Environment.NewLine _
            + Environment.NewLine + "احمد انٹرنیشنل - فیصل آباد"
        mobile = mobile.Substring(1)
        mobile = "92" + mobile.Replace(" ", "")
        Form3.Whatsapp(mobile, MyMsg)
        'Form3.Whatsapp(mobile, MyMsg)
        'Threading.Thread.Sleep(txtDelay.Text * 1000)

        'Console.Beep(500, 3000)
    End Sub



    Function RouteMsg(Msg As String, Mobile As String)

        Return ""
    End Function


    Sub btnWhatsAppWithNoEntries()
        Dim dt As DataTable = SQLData("select acid,Subsidary,UrduName,(select case when a.OCELL2WA='Y' then Cell2 else ocell end OCell from COA a where a.id=xx.acid) OCell
                                            ,route,type,doc,prebal2,Credit,prebal2-Credit NetBalance
	                                        from (
	                                        select 
	                                        aa.id acid,aa.Subsidary,aa.OCell,aa.UrduName,aa.route,isnull(x.type,'') Type,isnull(convert(char(10),x.doc),'') Doc,isnull(x.Credit,0) Credit
	                                        ,isnull((select sum(l2.debit)-sum(l2.credit) from ledgers l2 where l2.ACid=aa.id and l2.date<='" & dtp1.Value.ToString("d") & "'
	                                        and (isnull(CONVERT(char(10),l2.doc),'')+l2.TYPE) <> (isnull(CONVERT(char(10),x.doc),'')+'CRV') --and l2.Id<isnull(x.Id,9999999999)
		                                        ),0) prebal2
	                                        ,isnull(Datediff(m,(select max(date) from ledgers l3 where l3.Acid=aa.id),getDate()),100) LastDate
                                            from (select l.id,a.id ACID,Subsidary,type,doc,isnull(Credit,0) Credit
	                                        from coa a full join ledgers l on a.id=l.acid
	                                        where route like '%" & txtRoute.Text & "%' and l.date='" & dtp1.Value.ToString("d") & "' and type='crv'
	                                        ) x right join COA aa on x.ACId=aa.Id 
	                                        where aa.route like '%" & txtRoute.Text & "%'
	                                        ) xx where xx.LastDate<7 and xx.prebal2+xx.Credit>100 and xx.OCell<>''
	                                        order by xx.Doc,xx.Subsidary ")

        For n = 0 To dt.Rows.Count - 1
            Dim UName As String = ""
            Dim PreB As String = ""
            Dim NetB As String = ""
            Dim CusID As String = dt.Rows(n)("ACid")
            Dim CRVNumber As String = dt.Rows(n)("doc")
            Dim UrduName As String = dt.Rows(n)("UrduName")

            lblCustomerName.Text = UrduName
            lblCustomerName.Refresh()

            'Dim PreBal As DataTable = SQLData("select sum(isnull(debit,0))-sum(isnull(credit,0)) PreBal from ledgers where acid=" & CusID & " and date<='" & dtp1.Value & "' and type+cast(doc as varchar(10))<>'CRV" & CRVNumber & "' and acid<>1")
            'Dim PreviousBalance As String = PreBal.Rows(0)(0)
            Dim PreviousBalance As String = dt.Rows(n)("PreBal2")
            'frmInvoiceList.PreBalance(CusID.ToString, dgvCRV.Item("colDate", n).Value, "CRV", CRVNumber)

            'Dim cell As DataTable = dt.Rows(n)("Ocell")
            'SQLData("select case when ocell2wa='y' then cell2 else ocell end Mobile from coa where id=" & CusID)
            'Dim InvDate2 As String = dtp1.Value.ToString("d")
            Dim InvDate2 As String = DateChange(dtp1.Value)

            'frmInvoiceList.DateChange(dgvCRV.Item("colDate", n).Value)
            Dim mobile As String = dt.Rows(n)("Ocell")
            Dim NetBalance As String = dt.Rows(n)("NetBalance")
            If UrduName.Trim = "" Then
                UName = ""
            Else
                UName = "%0a وصولی بنام :" & UrduName
            End If

            If chkPB.Checked = False Then
                PreB = ""
                NetB = ""
            Else
                PreB = "%0a * سابقہ بقایا " + " " + Form3.Amt(PreviousBalance.ToString) + "*"
                NetB = "%0a *کل بقایا رقم" + " " + Form3.Amt(NetBalance.ToString) + "*"
            End If
            Dim AmountinWords = Form3.NumberToText(Form3.Amt(dt.Rows(n)("Credit").ToString))

            Dim MyMsg As String = "*وصولی نمبر" + CRVNumber.ToString.Trim + "*" _
                + Environment.NewLine + "وصولی کی تاریخ" + " " + InvDate2 _
                + UName _
                + Environment.NewLine _
                + PreB _
                + Environment.NewLine + "وصولی کی رقم" + " " + Form3.Amt(dt.Rows(n)("Credit").ToString) _
                + Environment.NewLine + AmountinWords _
                + Environment.NewLine _
                + NetB _
                + Environment.NewLine _
                + Environment.NewLine + "احمد انٹرنیشنل - فیصل آباد"
            mobile = mobile.Substring(1)
            mobile = "92" + mobile.Replace(" ", "")

            'MsgBox(mobile + " " + MyMsg)
            Form3.Whatsapp(mobile, "")
            Threading.Thread.Sleep(500)
            Form3.Whatsapp(mobile, MyMsg)
            Form3.ClickAt(700, 800)
            Threading.Thread.Sleep(500)
            SendKeys.Send("{ENTER}")
            Threading.Thread.Sleep(500)
            SendKeys.Send("{ESC}")
            Threading.Thread.Sleep(500)
            SendKeys.Send("{ESC}")
        Next
        Console.Beep(500, 3000)
    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnWhatsappSend.Click
        If rdRoute.Checked Then
            If txtRoute.Text = Nothing Then
                MsgBox("Pls enter route first!")
                txtRoute.Select()
                Return
            End If
            btnWhatsAppWithNoEntries()
        End If

        If rdNoEntry.Checked Then
            If txtRoute.Text = Nothing Then
                MsgBox("Pls enter route first!")
                txtRoute.Select()
                Return
            End If
            btnWhatsAppWithNoEntries()
        End If


        If rdDGV.Checked = True Then
            btnWhatsApp()
        End If


        If rdCRV.Checked Then
            CRVWhatsapp()
        End If

    End Sub

    Private Sub txtRoute_TextChanged(sender As Object, e As EventArgs) Handles txtRoute.TextChanged, txtCusName.TextChanged
        dgvUpdate()
    End Sub

    Sub SMS(Mobile As String, BillNumber As String, BillAmount As String, dt As Date, Optional Svr As String = "1.125")

        If Mobile.Trim = "" Then
            MainPage.msg = "No mobile Number to send SMS"
            DisappearingMsgBox.Show()
            Return
        End If
        Dim winHttpReq As Object
        Dim myURL, msg As String
        Dim UName As String = ""
        If txtUrduName.Text.Trim = "" Then
            UName = ""
        Else
            UName = "%0a وصولی بنام :" & txtUrduName.Text
        End If
        Dim SMSServer As String = txtSMServer.Text
        Dim NetBalance As String = Form3.Amt(txtPBal.Text - BillAmount)
        Dim PreBala As String = Form3.Amt(txtPBal.Text - 0)
        If NetBalance < 0 Then
            NetBalance = Form3.Amt(Math.Abs(CInt(NetBalance)).ToString) + "-"
        End If
        If txtPBal.Text < 0 Then
            PreBala = Form3.Amt(Math.Abs(CInt(txtPBal.Text)).ToString) + "-"
        End If

        If chkPB.Checked = True Then
            PreBala = "%0a  سابقہ بقایا " & PreBala
            NetBalance = "%0a  کل بقایا بیلنس " & NetBalance
        Else
            PreBala = ""
            NetBalance = ""
        End If

        msg = "السلام علیکم " &
            "%0a وصولی نمبر" & BillNumber &
            "%0a مورخہ" & dt.ToString("yy-MM-dd") &
            UName &
            PreBala &
            "%0a  نقد وصولی کی رقم " & Form3.Amt(BillAmount - 0) &
            NetBalance &
            "%0a احمدانٹرنیشنل "
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

    Private Sub chkSMS_CheckedChanged(sender As Object, e As EventArgs) Handles chkSMS.CheckedChanged, chkPB.CheckedChanged
        txtAmount.SelectAll()
        txtAmount.Select()
    End Sub

    Sub btnSMSSend()

        'Mobile As String, BillNumber As String, BillAmount As String, dt As Date, Optional Svr As String = "1.125"

        For n = 0 To dgvCRV.Rows.Count - 1
            Dim UName As String = ""
            Dim CusID As String = dgvCRV.Item("colACID", n).Value
            Dim CRVNumber As String = dgvCRV.Item("colDoc", n).Value
            Dim UrduName As String = dgvCRV.Item("ColUrduName", n).Value.ToString
            lblCustomerName.Text = UrduName
            Me.Refresh()
            'Dim PreBal As DataTable = SQLData("select sum(isnull(debit,0))-sum(isnull(credit,0)) PreBal from ledgers where acid=" & CusID & " and date<='" & dtp1.Value & "' and type+cast(doc as varchar(10))<>'CRV" & CRVNumber & "' and acid<>1")
            'Dim PreviousBalance As String = PreBal.Rows(0)(0)
            Dim PreviousBalance As String = PreBalance(CusID.ToString, dgvCRV.Item("colDate", n).Value, "CRV", CRVNumber)

            Dim cell As DataTable = SQLData("select case when ocell2wa='y' then cell2 else ocell end Mobile from coa where id=" & CusID)
            Dim InvDate2 As String = DateChange(dgvCRV.Item("colDate", n).Value)
            Dim mobile As String = cell.Rows(0)(0)
            Dim NetBalance As String = PreviousBalance - dgvCRV.Item("colAmount", n).Value

            If UrduName.Trim = "" Then
                UName = ""
            Else
                UName = "%0a وصولی بنام :" & UrduName
            End If

            If PreviousBalance < 0 Then
                PreviousBalance = Form3.Amt(Math.Abs(CInt(PreviousBalance)).ToString) + "-"
            Else
                PreviousBalance = Form3.Amt(Math.Abs(CInt(PreviousBalance)).ToString)
            End If
            If NetBalance < 0 Then
                NetBalance = Form3.Amt(Math.Abs(CInt(NetBalance)).ToString) + "-"
            Else
                NetBalance = Form3.Amt(Math.Abs(CInt(NetBalance)).ToString)
            End If
            Dim DocNum As String = dgvCRV.Item("colAmount", n).Value.ToString
            Dim amt As String = Form3.Amt(dgvCRV.Item("colAmount", n).Value.ToString)
            Dim MyMsg As String = "وصولی نمبر" + " " + DocNum _
            + "%0a وصولی کی تاریخ" + " " + InvDate2 _
            + UName _
            + "%0a وصولی کی رقم" + " " + amt _
            + "%0a سابقہ یقایا" + " " + PreviousBalance _
            + "%0a کل بقایا بیلنس" + " " + NetBalance
            'mobile = mobile.Substring(1)
            'mobile = "mobile.Replace(" ", "")

            Dim winHttpReq As Object
            Dim myURL As String

            Dim svr As String = txtSMServer.Text


            myURL = "http://192.168." & svr & ":8090/SendSMS?username=Sanaulhaq&password=123&phone=" & mobile & "&message=" & MyMsg


            winHttpReq = CreateObject("winHttp.winHttprequest.5.1")
            winHttpReq.open("post", myURL, False)
            Try
                winHttpReq.send()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            'SMS(mobile, DocNum, amt, InvDate2)

            Threading.Thread.Sleep(5000)
        Next
        MainPage.msg = "Message Sent successfully"
        lblCustomerName.Text = ""
        DisappearingMsgBox.Show()
        Console.Beep(500, 3000)
    End Sub


    Sub btnSMSSendWithNoEntries()

        Dim PreB As String = ""
        Dim NetB As String = ""

        Dim dt As DataTable = SQLData("select acid,Subsidary,UrduName,(select case when a.OCELL2WA='Y' then Cell2 else ocell end OCell from COA a where a.id=xx.acid) OCell
                                            ,route,type,doc,prebal2,Credit,prebal2-Credit NetBalance
	                                        from (
	                                        select 
	                                        aa.id acid,aa.Subsidary,aa.OCell,aa.UrduName,aa.route,isnull(x.type,'') Type,isnull(convert(char(10),x.doc),'') Doc,isnull(x.Credit,0) Credit
	                                        ,isnull((select sum(l2.debit)-sum(l2.credit) from ledgers l2 where l2.ACid=aa.id and l2.date<='" & dtp1.Value.ToString("d") & "'
	                                        and (isnull(CONVERT(char(10),l2.doc),'')+l2.TYPE) <> (isnull(CONVERT(char(10),x.doc),'')+'CRV') --and l2.Id<isnull(x.Id,9999999999)
		                                        ),0) prebal2
	                                        ,isnull(Datediff(m,(select max(date) from ledgers l3 where l3.Acid=aa.id),getDate()),100) LastDate
                                            from (select l.id,a.id ACID,Subsidary,type,doc,isnull(Credit,0) Credit
	                                        from coa a full join ledgers l on a.id=l.acid
	                                        where route like '%" & txtRoute.Text & "%' and l.date='" & dtp1.Value.ToString("d") & "' and type='crv'
	                                        ) x right join COA aa on x.ACId=aa.Id 
	                                        where aa.route like '%" & txtRoute.Text & "%'
	                                        ) xx where xx.LastDate<7 and xx.prebal2+xx.Credit>100 and xx.OCell<>''
	                                        order by xx.Doc,xx.Subsidary ")

        For n = 0 To dt.Rows.Count - 1
            Dim UName As String = ""
            Dim CusID As String = dt.Rows(n)("ACid")
            Dim CRVNumber As String = Trim(dt.Rows(n)("doc"))
            Dim UrduName As String = dt.Rows(n)("UrduName")

            lblCustomerName.Text = UrduName
            lblCustomerName.Refresh()

            'Dim PreBal As DataTable = SQLData("select sum(isnull(debit,0))-sum(isnull(credit,0)) PreBal from ledgers where acid=" & CusID & " and date<='" & dtp1.Value & "' and type+cast(doc as varchar(10))<>'CRV" & CRVNumber & "' and acid<>1")
            'Dim PreviousBalance As String = PreBal.Rows(0)(0)
            Dim PreviousBalance As String = dt.Rows(n)("PreBal2")
            'frmInvoiceList.PreBalance(CusID.ToString, dgvCRV.Item("colDate", n).Value, "CRV", CRVNumber)

            'Dim cell As DataTable = dt.Rows(n)("Ocell")
            'SQLData("select case when ocell2wa='y' then cell2 else ocell end Mobile from coa where id=" & CusID)
            Dim InvDate2 As String = DateChange(dtp1.Value.ToString("d"))
            'frmInvoiceList.DateChange(dgvCRV.Item("colDate", n).Value)
            Dim mobile As String = dt.Rows(n)("Ocell")
            Dim NetBalance As String = dt.Rows(n)("NetBalance")
            If UrduName.Trim = "" Then
                UName = ""
            Else
                UName = "%0a وصولی بنام :" & UrduName
            End If

            If chkPB.Checked = False Then
                PreB = ""
                NetB = ""
            Else
                PreB = "%0a *کل بقایا بیلنس" + " " + Form3.Amt(NetBalance.ToString) + "*"
                NetB = "%0a *کل بقایا بیلنس" + " " + Form3.Amt(NetBalance.ToString) + "*"
            End If


            Dim MyMsg As String = "* نقد وصولی نمبر" + Trim(CRVNumber.ToString) + "*" _
                + Environment.NewLine + "وصولی کی تاریخ" + " " + InvDate2 _
                + UName _
                + Environment.NewLine _
                + PreB _
                + Environment.NewLine + "وصولی کی رقم" + " " + Form3.Amt(dt.Rows(n)("Credit").ToString) _
                + NetB _
                + Environment.NewLine _
                + Environment.NewLine + "احمد انٹرنیشنل - فیصل آباد"
            'mobile = mobile.Substring(1)
            'mobile = "92" + mobile.Replace(" ", "")


            Dim winHttpReq As Object
            Dim myURL As String

            Dim svr As String = txtSMServer.Text

            MyMsg = MyMsg.Replace(Environment.NewLine, "%0a")

            myURL = "http://192.168." & svr & ":8090/SendSMS?username=Sanaulhaq&password=123&phone=" & mobile & "&message=" & MyMsg


            winHttpReq = CreateObject("winHttp.winHttprequest.5.1")
            winHttpReq.open("post", myURL, False)
            Try
                winHttpReq.send()

            Catch ex As Exception
                MainPage.msg = ex.Message
                DisappearingMsgBox.Show()
            End Try


            'SMS(mobile, DocNum, amt, InvDate2)

            Threading.Thread.Sleep(txtDelay.Text * 1000)
        Next
        MainPage.msg = "Message Sent successfully"
        lblCustomerName.Text = ""
        DisappearingMsgBox.Show()
        Console.Beep(500, 3000)
    End Sub




    Private Sub btnSMS_Click(sender As Object, e As EventArgs) Handles btnSMS.Click
        If chkNoEntry.Checked = False Then
            btnSMSSend()
        Else
            btnSMSSendWithNoEntries()
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnDateUpdate.Click
        If frmLogin.UserLevel.ToUpper = "OPERATOR" Then
            MsgBox("User Not Allowed")
            Return
        End If
        dtp2.Visible = True
        BatchChange = True
        dtp2.Select()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnNarrationUpdate.Click
        If frmLogin.UserLevel.ToUpper = "OPERATOR" Then
            MsgBox("User Not Allowed")
            Return
        End If
        Dim CRVNo As Integer

        For n = 0 To dgvCRV.Rows.Count - 1
            CRVNo = dgvCRV.Item("colDoc", n).Value
            SQLData("update ledgers set narration=N'" & txtNarration.Text & "' where type='crv' and doc=" & CRVNo)

        Next
        dgvUpdate()
    End Sub

    Private Sub dtp2_Leave(sender As Object, e As EventArgs) Handles dtp2.Leave
        dtp2.Visible = False
        dtp1.Select()
        If BatchChange = False Then
            Return
        End If
        Dim result As DialogResult = MessageBox.Show("Do you really want to change the date", "Change Batch Date ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result = DialogResult.No Then
            MsgBox("Nothing changed")
        Else
            Dim CRVNo As Integer
            For n = 0 To dgvCRV.Rows.Count - 1
                CRVNo = dgvCRV.Item("colDoc", n).Value
                SQLData("update ledgers set date='" & dtp2.Value.ToString("d") & "' where type='crv' and doc=" & CRVNo)
            Next
        End If

        dtp1.Value = dtp2.Value
        BatchChange = False
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ReceiptNumber As String = ""
        Dim row As DataGridViewRow = dgvCRV.SelectedRows(0)
        ReceiptNumber = row.Cells("ColDoc").Value.ToString
        'Dim TPrinter As String = Settings("Thermal Printer")
        MainPage.Rcpt = 0
        Dim cryRpt As New ReportDocument
        cryRpt.Load(settings("Reports Folder") + "thermal receipt.rpt")
        Try
            For Each tb As Table In cryRpt.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next

            cryRpt.SetParameterValue("DocNumber", ReceiptNumber)

            If MainPage.ThermalPrinter <> "" Then
                cryRpt.PrintOptions.PrinterName = Settings("Thermal Printer")
                cryRpt.PrintToPrinter(1, False, 0, 0)
            End If
            cryRpt.Close()
            cryRpt.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        txtCRVNo.SelectAll()
        txtCRVNo.Select()
    End Sub

    Private Sub txtNarration_Enter(sender As Object, e As EventArgs) Handles txtNarration.Enter, txtAmount.Enter
        If txtACID.Text = "" Then
            txtACID.Select()
        End If
    End Sub

    Private Sub txtNarrationFilter_Leave(sender As Object, e As EventArgs) Handles txtNarrationFilter.Leave
        dgvUpdate()
    End Sub
End Class
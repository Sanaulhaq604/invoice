Public Class CPV
    Dim SessionRecovery As Integer = 0
    Dim LastVocuher As Integer = 0
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Sub WhatsApp()
        Dim n As Integer = dgvCRV.CurrentCell.RowIndex
        Dim ACID As String = dgvCRV.Item("colACID", n).Value.ToString
        Dim Doc As String = dgvCRV.Item("colDoc", n).Value.ToString
        Dim CPVDate As String = DateChange(dgvCRV.Item("colDate", n).Value)
        Dim AMT As String = dgvCRV.Item("colAmount", n).Value.ToString
        Dim dt As DataTable = SQLData("select isnull(UrduName,'') UrduName, case when ocell2wa='y' then cell2 else ocell end Mobile from coa where id=" & ACID & "     ")
        Dim UName As String = dt.Rows(0)("UrduName").ToString
        Dim Mobile As String = dt.Rows(0)("Mobile")
        Dim PreviousBalance As String = PreBalance(ACID.ToString, dgvCRV.Item("colDate", n).Value, "CPV", Doc)
        Dim NetBalance As String = PreviousBalance - dgvCRV.Item("colAmount", n).Value
        Dim PreB As String = ""
        Dim NetB As String = ""

        If dt.Rows(0)("UrduName").ToString.Trim = "" Then
            UName = ""
        Else
            UName = dt.Rows(0)("UrduName").ToString
            UName = "%0a ادائیگی بنام :" & UName
        End If

        If chkPB.Checked = False Then
            PreB = ""
            NetB = ""
        Else
            PreB = "%0a *سابقہ یقایا" + " " + Form3.Amt(PreviousBalance.ToString) + "*"
            NetB = "%0a *کل بقایا بیلنس" + " " + Form3.Amt(NetBalance.ToString) + "*"

        End If

        Mobile = Mobile.Substring(1)
        Mobile = "92" + Mobile.Replace(" ", "")

        Dim MyMsg As String = "*ادائیگی نمبر" + " " + Doc + "*" _
            + Environment.NewLine + "ادائیگی کی تاریخ" + " " + CPVDate _
            + UName _
            + Environment.NewLine _
            + PreB _
            + Environment.NewLine + "ادائیگی کی رقم " + " " + Form3.Amt(dgvCRV.Item("colAmount", n).Value.ToString) _
            + NetB _
            + Environment.NewLine _
            + Environment.NewLine + "احمد انٹرنیشنل - فیصل آباد"


        Form3.Whatsapp(Mobile, MyMsg)
        'Threading.Thread.Sleep(txtDelay.Text * 1000)
        Console.Beep(500, 3000)




    End Sub




    Private Sub CRV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDoc.Text = "Cash Payment Voucher - " + frmLogin.MySqlServer + " - " + frmLogin.UserLevel
        vno()
        dgvUpdate()
        'dgvCRV.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvCRV.Columns("Amount").DefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
        'dgvCRV.Columns("Amount").DefaultCellStyle.Format = "N2"
    End Sub

    Sub dgvUpdate()
        Dim dt2 As DataTable = SQLData("select ROW_NUMBER() over (order by l.date) rn,l.Date,Doc,l.acid,a.subsidary Title,Narration,isnull(DEBIT,0) Amount from ledgers l join coa a on l.Acid=a.Id where type='CPV' and l.date='" & dtp1.Value.ToString("d") & "' and acid<>1 order by doc")
        If dt2.Rows.Count > 0 Then
            dgvCRV.DataSource = dt2
        Else
            If dgvCRV.Rows.Count > 0 Then
                dgvCRV.DataSource.clear()
            End If
            txtDayTotals.Text = 0
        End If

        Dim dtTotals As DataTable = SQLData("select ROW_NUMBER() over (order by a.main) RN,a.main,sum(l.debit) Debit 
                                                   from ledgers l join coa a on l.acid=a.id 
                                                   where l.acid=1 and l.date='" & dtp1.Value.ToString("d") & "' and acid<>1
                                                   group by a.Main ")
        Dim OB As Integer = 0
        Dim OBtable As DataTable = SQLData("SELECT isnull(SUM(isnull(DEBIT,0))-SUM(isnull(CREDIT,0)),0) OB FROM LEDGERS WHERE ACID=1 and date>'2023-10-31' AND DATE<'" & dtp1.Value.ToString("d") & "'")
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
                DayTotal += dtTotals.Rows(n)("Debit")
            Next
            txtDayTotals.Text = Form3.Amt(DayTotal)
        Else
            If dgvTotals.Rows.Count > 0 Then
                dgvTotals.DataSource.clear()
            End If
        End If



    End Sub

    Private Sub dtp1_Leave(sender As Object, e As EventArgs) Handles dtp1.Leave, dtp1.ValueChanged
        dgvUpdate()
    End Sub

    Sub save()
        If frmLogin.UserLevel.ToUpper = "OPERATOR" Then
            txtAmount.Text = 0
            Return
        End If
        If chkSMS.Checked Then
            SMS(txtOcell.Text, txtCRVNo.Text, txtAmount.Text, dtp1.Value, txtSMServer.Text)
        End If
        If Val(txtCRVNo.Text) = LastVocuher Then
            Dim docDT As DataTable = SQLData("select isnull(max(doc)+1,1) from ledgers where type='CPV'")
            txtCRVNo.Text = docDT.Rows(0)(0)
            LastVocuher = txtCRVNo.Text
            SQLData("update docnumber set doc=" & LastVocuher & "+1 where Type='CPV'")
            Me.Text = "Cash Payment - " + txtCRVNo.Text
        End If
        Dim UpdateLedgers As String = String.Format("
                                                    if (select count(*) from Ledgers where type='CPV' and doc=" & txtCRVNo.Text & ")=0
                                                        begin
                                                        insert into ledgers (date,type,doc,acid,narration,DEBIT,EntryBy,EntryDateTime,ReceiptStatus)
                                                        select '" & dtp1.Value.ToString("d") & "','CPV'," & txtCRVNo.Text & "," & txtACID.Text & ",'" & txtNarration.Text & "'," & Form3.Numbers(txtAmount.Text) & ", '" & frmLogin.UserName & "','" & Date.Now & "','CPV'

                                                        insert into ledgers (date,type,doc,acid,narration,CREDIT,EntryBy,EntryDateTime,ReceiptStatus)
                                                        select '" & dtp1.Value.ToString("d") & "','CPV'," & txtCRVNo.Text & ",1,'" & txtNarration.Text & " :To " & txtCustomerName.Text & "'," & Form3.Numbers(txtAmount.Text) & ", '" & frmLogin.UserName & "','" & Date.Now & "','CRV'

                                                        insert into ledgersHistory (date,type,doc,acid,narration,DEBIT,UserName,UserLevel,EntryDate,EntryStatus)
                                                        select '" & dtp1.Value.ToString("d") & "','CPV'," & txtCRVNo.Text & "," & txtACID.Text & ",'" & txtNarration.Text & "'," & Form3.Numbers(txtAmount.Text) & ",'" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "' , 'SAVE'

                                                        end
                                                    else
                                                        begin
                                                        update ledgers set acid=" & txtACID.Text & ",date='" & dtp1.Value.ToString("d") & "',narration='" & txtNarration.Text & "',DEBIT=" & Form3.Numbers(txtAmount.Text) & " where type='CPV' and doc=" & txtCRVNo.Text & " and acid<>1
                                                        update ledgers set date='" & dtp1.Value.ToString("d") & "',narration='" & txtNarration.Text & " :To " & txtCustomerName.Text & "',CREDIT=" & Form3.Numbers(txtAmount.Text) & " where type='CPV' and doc=" & txtCRVNo.Text & " and acid=1
                                                        
                                                        insert into ledgersHistory (date,type,doc,acid,narration,DEBIT,UserName,UserLevel,EntryDate,EntryStatus)
                                                        select '" & dtp1.Value.ToString("d") & "','CPV'," & txtCRVNo.Text & "," & txtACID.Text & ",'" & txtNarration.Text & "'," & Form3.Numbers(txtAmount.Text) & ",'" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "' , 'EDIT'

                                                        end
                                                    ")

        SQLData(UpdateLedgers)
        SessionRecovery += Form3.Numbers(txtAmount.Text)
        txtDayTotals.Text = SessionRecovery
        textclear()
        vno()
        dgvUpdate()
        If dgvCRV.Rows.Count > 0 Then

            dgvCRV.FirstDisplayedScrollingRowIndex = dgvCRV.Rows.Count - 1
            dgvCRV.Rows(dgvCRV.Rows.Count - 1).Selected = True
        End If


        txtACID.Select()

    End Sub

    Sub textclear()
        txtACID.Clear()
        txtAmount.Clear()
        txtCustomerName.Clear()
        txtPBal.Clear()
        txtNBal.Clear()
        txtNarration.Clear()
    End Sub



    Sub vno()
        Dim dt As DataTable = SQLData("select isnull(max(doc),0)+1 from ledgers where type='CPV'")
        If dt.Rows.Count > 0 Then
            txtCRVNo.Text = dt.Rows(0)(0)
            Me.Text = "Cash Payment - " + txtCRVNo.Text
            LastVocuher = Val(dt.Rows(0)(0))

        End If
    End Sub

    Private Sub ctbSave_Click(sender As Object, e As EventArgs) Handles ctbSave.Click
        save()
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

    Private Sub txtACID_Leave(sender As Object, e As EventArgs) Handles txtACID.Leave
        If txtACID.Text = "" Then

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
        Dim dt As DataTable = SQLData("Select Subsidary, ocell, isnull(Urduname,'') UrduName from coa where id=" & txtACID.Text & "")
        If dt.Rows.Count > 0 Then
            txtCustomerName.Text = dt.Rows(0)("Subsidary")
            txtOcell.Text = dt.Rows(0)("Ocell")
            txtUrduName.Text = dt.Rows(0)("UrduName")
            PreviousBalance()
        End If
        If txtNarration.Text <> "" Then
            txtAmount.SelectAll()
            txtAmount.Select()
        End If
        histroyGrid()
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
            SendKeys.Send("{tab}")
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
            Me.Text = "Cash Payment - " + txtCRVNo.Text
            DocLoad()
        End If
        If e.KeyCode = Keys.Up And txtCRVNo.Text < LastVocuher - 1 Then
            txtCRVNo.Text = Val(txtCRVNo.Text) + 1
            Me.Text = "Cash Payment - " + txtCRVNo.Text
            DocLoad()
        End If
        If e.KeyCode = Keys.Enter Then
            DocLoad()
        End If

    End Sub

    Sub PreviousBalance()
        Dim dt As DataTable = SQLData("select isnull(sum(debit),0)-isnull(sum(CREDIT),0) Bal from ledgers where acid=" & txtACID.Text & " and date<='" & dtp1.Value.ToString("d") & "' and doc<>" & txtCRVNo.Text)
        txtPBal.Text = Form3.Amt(dt.Rows(0)("Bal"))
    End Sub

    Sub DocLoad()
        Dim dt As DataTable = SQLData("select l.date,l.acid,a.Subsidary,l.Narration,l.DEBIT,isnull(UrduName,'') UrduName from ledgers l join coa a on l.acid=a.id where l.type='CPV' and  acid<>1 and doc=" & txtCRVNo.Text)
        If dt.Rows.Count = 0 Then
            MsgBox("VOUCHER NOT FOUND!")
            Return
        End If
        dtp1.Value = dt.Rows(0)("date")
        txtACID.Text = dt.Rows(0)("acid")
        txtCustomerName.Text = dt.Rows(0)("subsidary")
        txtNarration.Text = dt.Rows(0)("narration")
        txtAmount.Text = dt.Rows(0)("DEBIT")
        txtUrduName.Text = dt.Rows(0)("UrduName")
        dgvUpdate()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        dtp1.Value = Now.Date
        vno()
        textclear()
        dgvUpdate()
        dtp1.Select()
    End Sub

    Sub itemsfromGrid(row As DataGridViewRow)
        txtCRVNo.Text = row.Cells("colDoc").Value.ToString()
        Me.Text = "Cash Payment - " + txtCRVNo.Text
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
        txtNBal.Text = Form3.Amt(Form3.Numbers(txtPBal.Text) + Form3.Numbers(txtAmount.Text))
        'txtAmount.Text = Form3.Amt(Form3.Numbers(txtAmount.Text))

        txtAmount.Text = Format(Val(Replace(txtAmount.Text, ",", "")), "#,###,###")
        txtAmount.SelectionStart = txtAmount.TextLength

    End Sub

    Private Sub txtDayTotals_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Sub SMS(Mobile As String, BillNumber As String, BillAmount As String, dt As Date, Optional Svr As String = "1.134")

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
            UName = "%0a ادائیگی بنام :" & txtUrduName.Text
        End If
        Dim SMSServer As String = txtSMServer.Text
        Dim NetBalance As String = Form3.Amt(Form3.Numbers(txtPBal.Text) + BillAmount)
        Dim PreBala As String = Form3.Amt(Form3.Numbers(txtPBal.Text) - 0)
        If NetBalance < 0 Then
            NetBalance = Form3.Amt(Math.Abs(CInt(NetBalance)).ToString) + "-"
        End If
        If Form3.Numbers(txtPBal.Text) < 0 Then
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
            "%0a ادائیگی نمبر" & BillNumber &
            "%0a مورخہ" & dt.ToString("yy-MM-dd") &
            UName &
            PreBala &
            "%0a  نقد ادائیگی کی رقم " & Form3.Amt(Form3.Numbers(BillAmount) - 0) &
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

    Private Sub btnWhatsappSend_Click(sender As Object, e As EventArgs) Handles btnWhatsappSend.Click
        WhatsApp()
    End Sub

    Private Sub txtNarration_Enter(sender As Object, e As EventArgs) Handles txtNarration.Enter, txtAmount.Enter
        If txtACID.Text = "" Then
            txtACID.Select()
        End If
    End Sub
End Class
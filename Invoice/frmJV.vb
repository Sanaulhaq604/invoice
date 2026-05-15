Public Class frmJV
    Dim dNum As Integer

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Sub DocNumber()
        Dim dt As DataTable = SQLData("select isnull(max(doc),0)+1 from ledgers where type='jv'")
        dNum = dt.Rows(0)(0)
        txtDocNumber.Text = dNum

    End Sub

    Private Sub frmJV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DocNumber()
    End Sub

    Private Sub txtDocNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDocNumber.KeyDown
        If e.KeyCode = Keys.Down And Val(txtDocNumber.Text) > 0 Then
            txtDocNumber.Text = Val(txtDocNumber.Text) - 1
        End If
        If e.KeyCode = Keys.Up And Val(txtDocNumber.Text) < dNum Then
            txtDocNumber.Text = Val(txtDocNumber.Text) + 1
        End If
    End Sub

    Sub Totals()
        Dim TotalDebit As Integer = 0
        Dim TotalCredit As Integer = 0
        For n = 0 To dgvJV.Rows.Count - 1
            TotalDebit += Form3.Numbers(dgvJV.Rows(n).Cells("colDebit").Value)
            TotalCredit += Form3.Numbers(dgvJV.Rows(n).Cells("colCredit").Value)
        Next
        txtTotalCredit.Text = TotalCredit.ToString("N")
        txtTotalDebit.Text = TotalDebit.ToString("N")
        Dim difference As Integer = 0
        difference = TotalDebit - TotalCredit
        If difference <> 0 Then
            txtDifference.Text = difference.ToString("N")
            txtDifference.Visible = True
        Else
            txtDifference.Visible = False

        End If
    End Sub

    Private Sub txtDocNumber_TextChanged(sender As Object, e As EventArgs) Handles txtDocNumber.TextChanged
        Dim dt As DataTable = SQLData("Select l.date,acid,a.subsidary,narration,isnull(debit,0) Debit,isnull(credit,0) Credit from ledgers l join coa a on l.acid=a.id where type='JV' and doc=" & txtDocNumber.Text)
        dgvJV.Rows.Clear()
        Dim acid As String
        Dim title As String
        Dim narration As String
        Dim debit As Integer
        Dim credit As Integer
        If dt.Rows.Count > 0 Then
            dtpDate.Value = dt.Rows(0)("Date").ToString
        Else
            dtpDate.Value = Date.Now
        End If

        For n = 0 To dt.Rows.Count - 1
            acid = dt.Rows(n)("ACID")
            title = dt.Rows(n)("subsidary")
            narration = dt.Rows(n)("Narration")
            debit = dt.Rows(n)("debit")
            credit = dt.Rows(n)("Credit")
            dgvJV.Rows.Add(acid, title, narration, debit, credit)
        Next



        Totals()
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtACID.KeyDown
        If txtACID.Text <> "" Then
            '     SendKeys.Send("{tab}")

        Else
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
                frmPartySearch.ShowDialog()

                txtACID.Text = frmPartySearch.acID
                txtAccountTitle.Text = frmPartySearch.CusName

            End If
        End If
            If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDebit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDebit.KeyDown
        If Val(txtDebit.Text) <> 0 And e.KeyCode = Keys.Enter Then
            e.Handled = True

            dgvJV.Rows.Add(txtACID.Text, txtAccountTitle.Text, txtNarration.Text, Val(txtDebit.Text).ToString("N"), Val(txtCredit.Text).ToString("N"))
            lblChanges.Visible = True
            Totals()
            ClearTextBoxes()
            txtACID.Select()
        ElseIf Val(txtDebit.Text) = 0 And e.KeyCode = Keys.Enter Then
            txtDebit.Text = ""
            e.Handled = True
                SendKeys.Send("{tab}")

        End If
    End Sub

    Private Sub txtCredit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCredit.KeyDown
        If Val(txtCredit.Text) <> 0 And e.KeyCode = Keys.Enter Then
            e.Handled = True
            dgvJV.Rows.Add(txtACID.Text, txtAccountTitle.Text, txtNarration.Text, txtDebit.Text, txtCredit.Text)
            lblChanges.Visible = True
            Totals()
            ClearTextBoxes()
            txtACID.Select()
        ElseIf Val(txtCredit.Text) = 0 And e.KeyCode = Keys.Enter Then
            txtCredit.Text = ""
            e.Handled = True
            SendKeys.Send("{tab}")

        End If

    End Sub

    Sub ClearTextBoxes()
        txtAccountTitle.Text = ""
        txtACID.Text = ""
        txtDebit.Text = ""
        txtCredit.Text = ""
    End Sub

    Private Sub txtNarration_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNarration.KeyDown
        If e.KeyCode = Keys.Enter And txtNarration.Text <> "" Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub


    Sub ItemsFromGrid(rows As DataGridViewRow)
        lblChanges.Visible = True
        Dim x As Integer = dgvJV.CurrentRow.Index

        txtACID.Text = rows.Cells("colID").Value.ToString
        txtAccountTitle.Text = rows.Cells("colTitle").Value.ToString
        txtNarration.Text = rows.Cells("colNarration").Value.ToString
        txtDebit.Text = rows.Cells("colDebit").Value.ToString
        txtCredit.Text = rows.Cells("colCredit").Value.ToString
        If Val(txtDebit.Text) <> 0 Then
            txtDebit.SelectAll()
            txtDebit.Select()
        ElseIf Val(txtCredit.Text) <> 0 Then
            txtCredit.SelectAll()
            txtCredit.Select()
        Else
            txtACID.SelectAll()
            txtACID.Select()
        End If
        dgvJV.Rows.Remove(dgvJV.Rows(x))
        Totals()
    End Sub
    Private Sub dgvJV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvJV.CellDoubleClick
        ItemsFromGrid(dgvJV.CurrentRow)

    End Sub

    Sub SAVE()
        If txtDocNumber.Text = dNum Then
            DocNumber()
        End If
        SQLData("delete from ledgers where type='jv' and doc=" & txtDocNumber.Text)
        Dim ACID As String
        Dim Narration As String
        Dim debit As Integer
        Dim credit As Integer
        Dim dat As Date = dtpDate.Value.ToString("d")
        Dim DOCNUMB As String = txtDocNumber.Text


        For n = 0 To dgvJV.Rows.Count - 1
            ACID = dgvJV.Item("colID", n).Value.ToString
            Narration = dgvJV.Item("colNarration", n).Value.ToString
            debit = Form3.Numbers(dgvJV.Item("colDebit", n).Value)
            credit = Form3.Numbers(dgvJV.Item("colCredit", n).Value)


            SQLData("insert into ledgers (date,type,doc,acid,narration,debit,credit) 
                                values ('" & dat & "','JV'," & DOCNUMB & "," & ACID & ",N'" & Narration & "'," & debit & "," & credit & ")
                                ")
        Next
        lblChanges.Visible = False
        DocNumber()
        ClearTextBoxes()
        txtNarration.Text = ""
        dgvJV.Rows.Clear()
        txtDocNumber.SelectAll()
        txtDocNumber.Select()

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtDifference.Visible = True Then
            MsgBox("Journal Voucher not balance, pls balance it before saving")
            Return
        Else
            SAVE()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If frmLogin.UserLevel.ToUpper <> "ADMIN" Then
            MsgBox("User not allowed")
            Return
        End If
        Dim result As DialogResult = MessageBox.Show("Do you really want to delete the voucher ?", "Confirm Deletion", buttons:=MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result = DialogResult.Yes Then
            SQLData("delete from ledgers where type='jv' and doc=" & txtDocNumber.Text)
            MsgBox("Deleted")
            lblChanges.Visible = False
            DocNumber()
            ClearTextBoxes()
            txtNarration.Text = ""
            dgvJV.Rows.Clear()
            txtDocNumber.SelectAll()
            txtDocNumber.Select()
        End If
    End Sub

    Private Sub dtpDate_Leave(sender As Object, e As EventArgs) Handles dtpDate.Leave
        SQLData("UPDATE LEDGERS SET DATE='" & dtpDate.Value.ToString("d") & "' WHERE TYPE='JV' AND DOC=" & txtDocNumber.Text)
    End Sub

    Private Sub txtACID_Leave(sender As Object, e As EventArgs) Handles txtACID.Leave
        If txtACID.Text = "" Then
            txtPreviousBalance.Text = 0
            Return
        End If
        Dim dt As DataTable = SQLData("Select isnull(sum(isnull(debit,0))-sum(isnull(credit,0)),0) PBalance from ledgers where acid=" & txtACID.Text & " and date<='" & dtpDate.Value.ToString("d") & "'")
        Dim PreBalance As Integer = 0
        If dt.Rows.Count > 0 Then
            PreBalance = Math.Round(dt.Rows(0)("PBalance"), 0)
        End If
        txtPreviousBalance.Text = PreBalance.ToString("N")
    End Sub
End Class
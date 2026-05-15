Public Class frmSalary
    Private Sub frmSalary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim N = DateTime.Now.AddMonths(-1)
        Dim D = New DateTime(N.Year, N.Month, DateTime.DaysInMonth(N.Year, N.Month))
        dtpDate.Value = D
        SalaryGrid()
    End Sub
    Sub SalaryGrid()
        Dim dt As DataTable = SQLData("SELECT id,Subsidary,creditlimit Salary,cast(day(EOMONTH('" & dtpDate.Value.ToString("d") & "')) as varchar(5)) Days,creditlimit CurrentSalary FROM COA WHERE MAIN='STAFF' AND STATUS='ACTIVE' and Control like '%salary acc%' order by Subsidary")
        dgvSalary.DataSource = dt
        Totals()
    End Sub

    Sub Totals()
        Dim TotalSalary As Integer = 0
        Dim CurrentTotal As Integer = 0
        Dim DaysInMonth As Double = DateTime.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month)
        'Dim DailyTotalSalary As Double
        'Dim DailyPayableSalary As Double
        For n = 0 To dgvSalary.Rows.Count - 1
            TotalSalary += Val(dgvSalary.Item("colSalary", n).Value)
            CurrentTotal += Val(dgvSalary.Item("colCurrentSalary", n).Value)
        Next
        txtCurrentMonthSalaryTotal.Text = CurrentTotal.ToString("N")
        txtMonthlySalaryTotal.Text = TotalSalary.ToString("N")
        txtDailyTotalSalary.Text = (TotalSalary / DaysInMonth).ToString("N")
        txtDailyPayableSalary.Text = (CurrentTotal / DaysInMonth).ToString("N")

    End Sub

    Private Sub dgvSalary_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSalary.CellEndEdit
        Dim colIndex As Integer = e.ColumnIndex
        If colIndex = 2 Then
            Dim salary As Double = dgvSalary.CurrentRow.Cells(2).Value
            Dim AcID As String = dgvSalary.CurrentRow.Cells(0).Value
            SQLData("update coa set creditlimit=" & salary & " where id=" & AcID & "")
        End If
        If colIndex = 3 Then
            Dim salary As Double = dgvSalary.CurrentRow.Cells(2).Value
            Dim WorkingDays As Double = dgvSalary.CurrentRow.Cells(3).Value
            Dim DaysInMonth As Double = DateTime.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month)
            Dim CurrentSalary As Double = Math.Round((salary / DaysInMonth) * WorkingDays, 0)
            dgvSalary.CurrentRow.Cells(4).Value = CurrentSalary
        End If
        Totals()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Sub save()
        DocNumber()
        Dim ACID As String
        Dim Narration As String
        Dim debit As Integer = 0
        Dim credit As Integer
        Dim workingDays As Double
        Dim totalSalary As Integer
        Dim dat As Date = dtpDate.Value.ToString("d")

        For n = 0 To dgvSalary.Rows.Count - 1
            ACID = dgvSalary.Item("colID", n).Value.ToString
            workingDays = dgvSalary.Item("colDays", n).Value.ToString
            totalSalary = dgvSalary.Item("colSalary", n).Value.ToString
            Narration = "Salary of " & workingDays & " days @ " & totalSalary & " for M/o " + MonthName(dtpDate.Value.Month) + "-" + dtpDate.Value.Year.ToString
            credit = Form3.Numbers(dgvSalary.Item("colCurrentSalary", n).Value)
            SQLData("insert into ledgers (date,type,doc,acid,narration,debit,credit) 
            values ('" & dat & "','JV'," & dnum & "," & ACID & ",N'" & Narration & "'," & debit & "," & credit & ")
                          ")
        Next
        Narration = "Total Salaries for M/o " + MonthName(dtpDate.Value.Month) + "-" + dtpDate.Value.Year.ToString
        SQLData("insert into ledgers (date,type,doc,acid,narration,debit,credit) 
            values ('" & dat & "','JV'," & dnum & ",712,N'" & Narration & "'," & Form3.Numbers(txtCurrentMonthSalaryTotal.Text) & ",0)
                          ")
        MsgBox("Salary JV " & dnum & " Posted")
        Me.Close()
    End Sub
    Dim dnum As Integer
    Sub DocNumber()
        Dim dt As DataTable = SQLData("select max(doc)+1 from ledgers where type='jv'")
        dNum = dt.Rows(0)(0)
    End Sub

    Private Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        save()
    End Sub

    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        SalaryGrid()
    End Sub
End Class
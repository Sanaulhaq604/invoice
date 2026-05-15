Public Class frmRouteCalls
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim Pending As String = ""
        Dim Optr As String = " not in "
        Dim Optr2 As String = " and "


        If rdFinal.Checked Then
            Pending = "'OK','NO','NT'"
            Optr = " in "
            Optr2 = "or"
        End If
        If rdPending.Checked Then
            Pending = "'OK','NO','NT'"
            Optr = " not in "
            Optr2 = "and"
            'Else
            '    Pending = "'DKJFHAEUIRH1213'"
        End If
        If rdBlank.Checked Then
            Pending = " '' "
            Optr = " in "
            Optr2 = " and "
        End If
        If txtRoute.Text = "" Then
            MsgBox("Please select Rouote First !")
            txtRoute.Select()
            txtRoute.SelectAll()
            Return
        End If
        If cmbCaller.Text = "" Then
            MsgBox("Please select Caller Name First !")
            cmbCaller.SelectAll()
            cmbCaller.Select()
            Return
        End If

        Dim dt As DataTable = SQLData("WITH NumberedCalls AS (
    SELECT 
        Calls.ACID,
        Calls.TIME,
		calls.date,
        Calls.REMARKS,
		calls.CalledBy,
        ROW_NUMBER() OVER (PARTITION BY Calls.ACID ORDER BY Calls.TIME) AS CallNumber
    FROM 
        Calls where calls.date='" & dtp1.Value.ToString("d") & "'
)
SELECT * FROM (
SELECT
    COA.ID,
	isnull((Select max(date) from ledgers where acid=coa.id and type='sale' and debit>0),'2010-1-1') LastSaleDate,
	(select sum(debit) from ledgers where acid=coa.Id and date=(Select top 1 date from ledgers where acid=coa.id and type='sale' and debit>0 order by date desc)) LastSalesAmount,
    (select sum(isnull(debit,0))-sum(isnull(credit,0)) from ledgers where acid=coa.id) Balance,
	COA.Subsidary,
    ISNULL(COA.OCell,'') OCell,
	isnull(COA.CELL2,'') Cell2,
	TRIM(isnull(calledby,'')) CalledBy,
    TRIM(ISNULL(MAX(CASE WHEN CallNumber = 1 THEN TIME END),'')) AS CallTime1,
    TRIM(ISNULL(MAX(CASE WHEN CallNumber = 1 THEN REMARKS END),'')) AS Remarks1,
    TRIM(ISNULL(MAX(CASE WHEN CallNumber = 2 THEN TIME END),'')) AS CallTime2,
    TRIM(ISNULL(MAX(CASE WHEN CallNumber = 2 THEN REMARKS END),'')) AS Remarks2,
    TRIM(ISNULL(MAX(CASE WHEN CallNumber = 3 THEN TIME END),'')) AS CallTime3,
    TRIM(ISNULL(MAX(CASE WHEN CallNumber = 3 THEN REMARKS END),'')) AS Remarks3
FROM 
    COA
LEFT JOIN 
    NumberedCalls ON COA.ID = NumberedCalls.ACID
WHERE 
    COA.ROUTE LIKE '%" & txtRoute.Text & "%'  and isnull((Select max(date) from ledgers where acid=coa.id and type='sale' and debit>0),'2010-1-1')>dateadd(YYYY,-1,'" & dtp1.Value.ToString("d") & "') 
GROUP BY 
    COA.ID, COA.Subsidary, COA.OCell,COA.Cell2,calledby) X WHERE Remarks1 " & Optr & " (" & Pending & ") " & Optr2 & " Remarks2 " & Optr & " (" & Pending & ") " & Optr2 & " Remarks3 " & Optr & " (" & Pending & ") order by LastSaleDate DESC
	")
        dgvRouteCustomersList.DataSource = dt
        ' dgvRouteCustomersList.Columns("time1").DefaultCellStyle.Format = "HH:mm tt"
    End Sub

    Private Sub dgvRouteCustomersList_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvRouteCustomersList.CellFormatting

        ' Check if the row is the one you want to change color for
        For Each row As DataGridViewRow In dgvRouteCustomersList.Rows
            ' Example: Check if values in column 1 and column 2 are certain values
            If Not row.IsNewRow Then
                Dim column1Value As String = row.Cells(9).Value.ToString().Trim.ToUpper ' Column 1 (index 0)
                Dim column2Value As String = row.Cells(11).Value.ToString().Trim.ToUpper ' Column 2 (index 1)
                Dim column3Value As String = row.Cells(13).Value.ToString().Trim.ToUpper ' Column 2 (index 1)
                ' Example condition: If both column1 and column2 have "ABC" and "123" respectively, change color
                If column1Value = "OK" Or column2Value = "OK" Or column3Value = "OK" Then
                    row.DefaultCellStyle.BackColor = Color.LightGreen
                ElseIf column1Value = "NO" Or column2Value = "NO" Or column3Value = "NO" Then
                    row.DefaultCellStyle.BackColor = Color.Red
                ElseIf column1Value = "NT" Or column2Value = "NT" Or column3Value = "NT" Then
                    row.DefaultCellStyle.BackColor = Color.LightPink
                ElseIf column1Value = "NA" Or column2Value = "NA" Or column3Value = "NA" Then
                    row.DefaultCellStyle.BackColor = Color.LightGray
                ElseIf column1Value = "PF" Or column2Value = "PF" Or column3Value = "PF" Then
                    row.DefaultCellStyle.BackColor = Color.Orchid
                ElseIf column1Value = "BZ" Or column2Value = "BZ" Or column3Value = "BZ" Then
                    row.DefaultCellStyle.BackColor = Color.LemonChiffon
                Else
                    ' Reset to default color if the condition is not met
                    row.DefaultCellStyle.BackColor = Color.White
                End If
            End If
        Next
    End Sub

    Private Sub dgvRouteCustomersList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRouteCustomersList.CellEndEdit
        dgvRouteCustomersList.CurrentCell.Value = dgvRouteCustomersList.CurrentCell.Value.ToString.ToUpper
        Dim ROW As DataGridViewRow = dgvRouteCustomersList.CurrentRow
        Dim CurrentTime As String = DateTime.Now.ToString("HH:mm")
        Dim ACID As String = ROW.Cells(0).Value.ToString
        Dim Caller As String = cmbCaller.Text.ToUpper
        Dim CDat As String = dtp1.Value.ToString("d")


        If dgvRouteCustomersList.CurrentCell.ColumnIndex = 9 Then
            If dgvRouteCustomersList.Item(8, e.RowIndex).Value.ToString.Trim = "" Then
                dgvRouteCustomersList.Item(8, e.RowIndex).Value = CurrentTime
            End If
        End If
        If dgvRouteCustomersList.CurrentCell.ColumnIndex = 11 Then
            If dgvRouteCustomersList.Item(10, e.RowIndex).Value.ToString.Trim = "" Then
                dgvRouteCustomersList.Item(10, e.RowIndex).Value = CurrentTime
            End If
        End If
        If dgvRouteCustomersList.CurrentCell.ColumnIndex = 13 Then
            If dgvRouteCustomersList.Item(12, e.RowIndex).Value.ToString.Trim = "" Then
                dgvRouteCustomersList.Item(12, e.RowIndex).Value = CurrentTime
            End If
        End If

        If dgvRouteCustomersList.Item(7, e.RowIndex).Value.ToString.Trim = "" Then
            dgvRouteCustomersList.Item(7, e.RowIndex).Value = Caller
        End If
        Dim TIME1 As String = ROW.Cells(8).Value.ToString.Trim
        Dim REMARK1 As String = ROW.Cells(9).Value.ToString.ToUpper.Trim

        Dim TIME2 As String = ROW.Cells(10).Value.ToString.Trim
        Dim REMARK2 As String = ROW.Cells(11).Value.ToString.ToUpper.Trim

        Dim TIME3 As String = ROW.Cells(12).Value.ToString.Trim
        Dim REMARK3 As String = ROW.Cells(13).Value.ToString.ToUpper.Trim



        SQLData("delete from calls where date='" & CDat & "' and acid='" & ACID & "'   ")
        If TIME1 IsNot "" And REMARK1 IsNot "" Then
            SQLData("Insert into calls (date,acid,CalledBy,Time,Remarks) values('" & CDat & "','" & ACID & "','" & Caller & "','" & TIME1 & "','" & REMARK1 & "') ")
        End If
        If TIME2 IsNot "" And REMARK2 IsNot "" Then
            SQLData("Insert into calls (date,acid,CalledBy,Time,Remarks) values('" & CDat & "','" & ACID & "','" & Caller & "','" & TIME2 & "','" & REMARK2 & "') ")
        End If
        If TIME3 IsNot "" And REMARK3 IsNot "" Then
            SQLData("Insert into calls (date,acid,CalledBy,Time,Remarks) values('" & CDat & "','" & ACID & "','" & Caller & "','" & TIME3 & "','" & REMARK3 & "') ")
        End If
    End Sub


    Private Sub dgvRouteCustomersList_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvRouteCustomersList.EditingControlShowing
        Dim txtBox As TextBox = TryCast(e.Control, TextBox)
        If txtBox IsNot Nothing Then
            ' Remove any existing handlers to prevent multiple event handling
            RemoveHandler txtBox.GotFocus, AddressOf TextBox_GotFocus
            ' Add a new handler for the GotFocus event
            AddHandler txtBox.GotFocus, AddressOf TextBox_GotFocus
        End If

        'Dim colindex = dgvRouteCustomersList.CurrentCell.ColumnIndex
        'If colindex = 9 Or colindex = 11 Or colindex = 13 Then
        '    Dim txt As TextBox = CType(e.Control, TextBox)
        '    RemoveHandler txt.KeyPress, AddressOf TextBox_TextChanged
        '    AddHandler txt.KeyPress, AddressOf TextBox_TextChanged
        'End If

    End Sub

    Private Sub TextBox_GotFocus(sender As Object, e As EventArgs)
        ' Select all text in the TextBox when it gets focus
        Dim txtBox As TextBox = CType(sender, TextBox)
        txtBox.SelectAll()
    End Sub
    Private Sub TextBox_TextChanged(sender As Object, e As KeyPressEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        txt.Text = txt.Text.ToUpper()
        txt.SelectionStart = txt.Text.Length

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvRouteCustomersList.RowPostPaint
        ' Get the row number (index + 1 because index is zero-based)
        Dim rowNumber As String = (e.RowIndex + 1).ToString()

        ' Define the font and text alignment for the row number
        Dim rowHeaderFont As New Font("Segoe UI", 10, FontStyle.Bold, GraphicsUnit.Point)

        ' Calculate the size and position of the row number text
        Dim textSize As SizeF = e.Graphics.MeasureString(rowNumber, rowHeaderFont)
        Dim headerBounds As Rectangle = e.RowBounds
        'Dim rowHeaderXPosition As Integer = dgvRouteCustomersList.RowHeadersWidth - Convert.ToInt32(textSize.Width) - 4

        Dim rowHeaderXPosition As Integer = (dgvRouteCustomersList.RowHeadersWidth - textSize.Width) / 2
        Dim rowHeaderYPosition As Integer = (headerBounds.Height - textSize.Height) / 2 + headerBounds.Y


        ' Draw the row number in the row header cell
        e.Graphics.DrawString(rowNumber, rowHeaderFont, Brushes.Black, rowHeaderXPosition, headerBounds.Y + 4)
    End Sub


End Class
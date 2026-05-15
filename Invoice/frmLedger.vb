Imports CrystalDecisions.CrystalReports.Engine

'Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmLedger
    Dim FileName As String = ""
    Sub Last30Days()
        dtpStart.Value = Today.Date.AddDays(-30)
        DtpEnd.Value = Today.Date.AddDays(+1)
    End Sub

    ' Ensure there is a DataGridViewButtonColumn at the right-most position for viewing images
    Private Sub EnsureViewImageColumn()
        Try
            If DataGridView1.Columns.Contains("colViewImage") Then
                ' Move it to the right-most position
                Dim col = DataGridView1.Columns("colViewImage")
                col.DisplayIndex = DataGridView1.Columns.Count - 1
                Return
            End If

            Dim btnCol As New DataGridViewButtonColumn()
            btnCol.Name = "colViewImage"
            btnCol.HeaderText = ""
            btnCol.UseColumnTextForButtonValue = False ' we set text per-row
            btnCol.FlatStyle = FlatStyle.Flat
            btnCol.Width = 84
            btnCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            btnCol.DefaultCellStyle.Padding = New Padding(6, 4, 6, 4)
            ' Use a neutral default; per-row styling mirrors the Dashboard style (green enabled, gray disabled)
            btnCol.DefaultCellStyle.BackColor = Color.LightGray
            btnCol.DefaultCellStyle.ForeColor = Color.Gray
            DataGridView1.Columns.Add(btnCol)
            btnCol.DisplayIndex = DataGridView1.Columns.Count - 1
        Catch
            ' ignore
        End Try
    End Sub

    ' Populate the View Image button cells based on presence of image in images DB
    Private Sub PopulateViewImageButtons()
        Try
            If DataGridView1.Rows.Count = 0 Then Return
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.IsNewRow Then Continue For
                Dim dType As String = ""
                Dim dNumber As String = ""
                If DataGridView1.Columns.Contains("colType") Then dType = Convert.ToString(row.Cells("colType").Value)
                If dType = "" AndAlso DataGridView1.Columns.Contains("Type") Then dType = Convert.ToString(row.Cells("Type").Value)
                If DataGridView1.Columns.Contains("colDoc") Then dNumber = Convert.ToString(row.Cells("colDoc").Value)
                If dNumber = "" AndAlso DataGridView1.Columns.Contains("Doc") Then dNumber = Convert.ToString(row.Cells("Doc").Value)

                Dim btnCellIndex As Integer = -1
                If DataGridView1.Columns.Contains("colViewImage") Then btnCellIndex = DataGridView1.Columns("colViewImage").Index

                If btnCellIndex >= 0 Then
                    If String.IsNullOrWhiteSpace(dType) Or String.IsNullOrWhiteSpace(dNumber) Then
                        row.Cells(btnCellIndex).Value = Nothing
                        row.Cells(btnCellIndex).ReadOnly = True
                        row.Cells(btnCellIndex).Style.BackColor = Color.White
                        row.Cells(btnCellIndex).Style.ForeColor = Color.Black
                    Else
                        Dim q As String = "SELECT TOP 1 IMAGE FROM images.dbo.name_reciepts WHERE [type]='" & dType.Replace("'", "''") & "' AND doc='" & dNumber.Replace("'", "''") & "'"
                        Dim dtImg As DataTable = SQLImageData(q)
                        If dtImg.Rows.Count > 0 AndAlso Not IsDBNull(dtImg.Rows(0)(0)) Then
                            ' Match Dashboard appearance: enabled green button with black text
                            row.Cells(btnCellIndex).Value = "View"
                            row.Cells(btnCellIndex).ReadOnly = False
                            row.Cells(btnCellIndex).Style.BackColor = Color.LightGreen
                            row.Cells(btnCellIndex).Style.ForeColor = Color.Black
                            row.Cells(btnCellIndex).Style.Font = New Font(DataGridView1.Font, FontStyle.Bold)
                            row.Cells(btnCellIndex).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Else
                            ' Disabled state: no text, gray background
                            row.Cells(btnCellIndex).Value = ""
                            row.Cells(btnCellIndex).ReadOnly = True
                            row.Cells(btnCellIndex).Style.BackColor = Color.LightGray
                            row.Cells(btnCellIndex).Style.ForeColor = Color.Gray
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            ' silent
        End Try
    End Sub

    ' Handle clicks on view-image column
    Private Sub DataGridView1_CellContentClick_OpenImage(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick, DataGridView1.CellClick
        Try
            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Return
            If Not DataGridView1.Columns(e.ColumnIndex).Name = "colViewImage" Then Return
            Dim cell = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex)
            If cell.ReadOnly Then Return
            If Convert.ToString(cell.Value).Trim <> "View" Then Return

            Dim dType As String = ""
            Dim dNumber As String = ""
            If DataGridView1.Columns.Contains("colType") Then dType = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells("colType").Value)
            If dType = "" AndAlso DataGridView1.Columns.Contains("Type") Then dType = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells("Type").Value)
            If DataGridView1.Columns.Contains("colDoc") Then dNumber = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells("colDoc").Value)
            If dNumber = "" AndAlso DataGridView1.Columns.Contains("Doc") Then dNumber = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells("Doc").Value)
            If dType = "" Or dNumber = "" Then Return

            Dim q As String = "SELECT IMAGE FROM name_reciepts WHERE [type]='" & dType.Replace("'", "''") & "' AND doc='" & dNumber.Replace("'", "''") & "'"
            Dim dtImg As DataTable = SQLImageData(q)
            If dtImg.Rows.Count = 0 Then
                MsgBox("No image found for type='" & dType & "' doc='" & dNumber & "'. (SQL: " & q & ")")
                Return
            End If
            If IsDBNull(dtImg.Rows(0)(0)) Then
                MsgBox("Image is NULL for type='" & dType & "' doc='" & dNumber & "'. (SQL: " & q & ")")
                Return
            End If
            Dim img() As Byte = DirectCast(dtImg.Rows(0)(0), Byte())

            ' Use the richer frmImageViewer if available; fall back to simple view
            Try
                Dim wa = Screen.FromControl(Me).WorkingArea
                Dim docId As Integer = 0
                Dim parsed As Boolean = Integer.TryParse(dNumber, docId)
                ' Diagnostic: confirm bytes length
                If img Is Nothing Then
                    MsgBox("Image byte array is Nothing for type='" & dType & "' doc='" & dNumber & "'.")
                    Return
                End If
                MsgBox("Opening image: type='" & dType & "' doc='" & dNumber & "' bytes=" & img.Length)

                Dim viewer As New frmImageViewer(docId, dType)
                ' Use the specialized show method to make initial height = working area height
                viewer.ShowImageMaxHeight(img)
            Catch ex As Exception
                MsgBox("Error showing image: " & ex.Message & vbCrLf & "SQL: " & q)
                ' Fallback: simple picturebox dialog
                Using ms2 As New IO.MemoryStream(img)
                    Try
                        Dim bmp = Image.FromStream(ms2)
                        Dim tmp As New Form()
                        tmp.StartPosition = FormStartPosition.CenterParent
                        tmp.ClientSize = New Size(Math.Min(bmp.Width, Screen.PrimaryScreen.WorkingArea.Width), Math.Min(bmp.Height, Screen.PrimaryScreen.WorkingArea.Height))
                        Dim pb2 As New PictureBox() With {.Image = bmp, .Dock = DockStyle.Fill, .SizeMode = PictureBoxSizeMode.Zoom}
                        tmp.Controls.Add(pb2)
                        tmp.ShowDialog()
                    Catch ex2 As Exception
                        MsgBox("Failed to load image in fallback: " & ex2.Message)
                    End Try
                End Using
            End Try

        Catch ex As Exception
            ' ignore
        End Try
    End Sub

    ' Also handle mouse clicks explicitly to ensure button clicks are captured
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Return
            If Not DataGridView1.Columns(e.ColumnIndex).Name = "colViewImage" Then Return
            Dim cell = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex)
            If cell Is Nothing Then Return
            If Convert.ToString(cell.Value).Trim <> "View" Then
                ' disabled/empty cell - nothing to do
                Return
            End If

            ' call the same open logic used by content click
            OpenImageForRow(e.RowIndex)
        Catch
        End Try
    End Sub

    Private Sub OpenImageForRow(rowIndex As Integer)
        Try
            If rowIndex < 0 Or rowIndex >= DataGridView1.Rows.Count Then Return
            Dim row = DataGridView1.Rows(rowIndex)
            Dim dType As String = ""
            Dim dNumber As String = ""
            If DataGridView1.Columns.Contains("colType") Then dType = Convert.ToString(row.Cells("colType").Value)
            If dType = "" AndAlso DataGridView1.Columns.Contains("Type") Then dType = Convert.ToString(row.Cells("Type").Value)
            If DataGridView1.Columns.Contains("colDoc") Then dNumber = Convert.ToString(row.Cells("colDoc").Value)
            If dNumber = "" AndAlso DataGridView1.Columns.Contains("Doc") Then dNumber = Convert.ToString(row.Cells("Doc").Value)
            If dType = "" Or dNumber = "" Then Return

            Dim q As String = "SELECT IMAGE FROM name_reciepts WHERE [type]='" & dType.Replace("'", "''") & "' AND doc='" & dNumber.Replace("'", "''") & "'"
            Dim dtImg As DataTable = SQLImageData(q)
            If dtImg.Rows.Count = 0 Then
                MsgBox("No image found for type='" & dType & "' doc='" & dNumber & "'. (SQL: " & q & ")")
                Return
            End If
            If IsDBNull(dtImg.Rows(0)(0)) Then
                MsgBox("Image is NULL for type='" & dType & "' doc='" & dNumber & "'. (SQL: " & q & ")")
                Return
            End If
            Dim img() As Byte = DirectCast(dtImg.Rows(0)(0), Byte())

            If img Is Nothing OrElse img.Length = 0 Then
                MsgBox("Image bytes empty for type='" & dType & "' doc='" & dNumber & "'.")
                Return
            End If

            Dim docId As Integer = 0
            Integer.TryParse(dNumber, docId)
            Dim viewer As New frmImageViewer(docId, dType)
            viewer.ShowImageMaxHeight(img)
        Catch ex As Exception
            MsgBox("Error opening image: " & ex.Message)
        End Try
    End Sub

    ' Resize narration column to fill available space and avoid horizontal scrolling
    Private Sub AdjustNarrationWidth()
        Try
            If Not DataGridView1.Columns.Contains("colNarration") AndAlso Not DataGridView1.Columns.Contains("Narration") Then Return
            Dim narrationColName = If(DataGridView1.Columns.Contains("colNarration"), "colNarration", "Narration")

            ' Disable autosizing to apply manual widths
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            Dim total = DataGridView1.ClientSize.Width - DataGridView1.RowHeadersWidth - 4
            Dim otherWidth As Integer = 0
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Name = narrationColName Then Continue For
                If Not c.Visible Then Continue For
                ' Respect minimum reasonable widths for common columns
                Dim w = c.Width
                If c.Name.ToLower().Contains("date") AndAlso w < 90 Then w = 90
                If c.Name.ToLower().Contains("type") AndAlso w < 80 Then w = 80
                If c.Name.ToLower().Contains("doc") AndAlso w < 70 Then w = 70
                If c.Name.ToLower().Contains("debit") OrElse c.Name.ToLower().Contains("credit") OrElse c.Name.ToLower().Contains("balance") Then
                    If w < 80 Then w = 80
                End If
                otherWidth += w
            Next

            Dim avail = total - otherWidth
            If avail < 150 Then avail = 150
            DataGridView1.Columns(narrationColName).Width = avail
        Catch
        End Try
    End Sub

    ' Force-fit columns to DataGridView client width so no horizontal scroll appears.
    Private Sub ForceFitColumnWidths()
        Try
            If DataGridView1.Columns.Count = 0 Then Return

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            Dim totalAvail As Integer = DataGridView1.ClientSize.Width - DataGridView1.RowHeadersWidth - 4
            If totalAvail <= 0 Then Return

            ' Fixed width for view button column if present
            Dim viewWidth As Integer = 84
            If DataGridView1.Columns.Contains("colViewImage") Then
                totalAvail -= viewWidth
            Else
                viewWidth = 0
            End If

            ' Define weights for other columns (smaller numbers = smaller width)
            Dim weights As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase) From {
                {"colDate", 10}, {"colType", 8}, {"colDoc", 6}, {"colNarration", 40}, {"colDebit", 8}, {"colCredit", 8}, {"colBalance", 8}, {"colClosing", 6}
            }

            ' Collect visible columns to size
            Dim cols As New List(Of DataGridViewColumn)
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If Not c.Visible Then Continue For
                If String.Equals(c.Name, "colViewImage", StringComparison.OrdinalIgnoreCase) Then Continue For
                cols.Add(c)
            Next

            ' Compute total weight for present columns
            Dim totalWeight As Integer = 0
            For Each c In cols
                If weights.ContainsKey(c.Name) Then
                    totalWeight += weights(c.Name)
                Else
                    totalWeight += 4 ' default small weight
                End If
            Next

            If totalWeight = 0 Then Return

            ' Assign widths based on weights, respect minimums
            Dim assigned As Integer = 0
            For i = 0 To cols.Count - 1
                Dim c = cols(i)
                Dim w = If(weights.ContainsKey(c.Name), weights(c.Name), 4)
                Dim colWidth As Integer = CInt(Math.Floor(totalAvail * (w / totalWeight)))
                ' Minimum sensible widths
                If c.Name.ToLower().Contains("date") AndAlso colWidth < 90 Then colWidth = 90
                If c.Name.ToLower().Contains("type") AndAlso colWidth < 80 Then colWidth = 80
                If c.Name.ToLower().Contains("doc") AndAlso colWidth < 70 Then colWidth = 70
                If c.Name.ToLower().Contains("debit") OrElse c.Name.ToLower().Contains("credit") OrElse c.Name.ToLower().Contains("balance") Then
                    If colWidth < 80 Then colWidth = 80
                End If
                ' For last column assign remaining pixels to avoid rounding leftover
                If i = cols.Count - 1 Then
                    colWidth = Math.Max(colWidth, totalAvail - assigned)
                End If
                c.Width = colWidth
                assigned += colWidth
            Next

            ' Finally set view column width and ensure last display index
            If DataGridView1.Columns.Contains("colViewImage") Then
                Dim vcol = DataGridView1.Columns("colViewImage")
                vcol.Width = viewWidth
                vcol.DisplayIndex = DataGridView1.Columns.Count - 1
            End If

        Catch
        End Try
    End Sub

    Sub LastTally()
        Dim dt As DataTable = SQLData("select isnull((select top 1 date from ledgers where acid=" & txtAcID.Text & " and status=2 order by date desc),'2010-1-1') Date")
        Dim dat As Date = dt.Rows(0)(0)
        dtpStart.Value = dat
        DtpEnd.Value = Today.Date.AddDays(+1)
        Ledger()
    End Sub

    Sub CurrentMonth()
        dtpStart.Value = New DateTime(Now.Year, Now.Month, 1)
        DtpEnd.Value = Today.Date.AddDays(+1)
    End Sub

    Sub Last6Months()
        dtpStart.Value = Today.Date.AddDays(-180)
        DtpEnd.Value = Today.Date.AddDays(+1)
    End Sub

    Sub ALL()
        dtpStart.Value = Today.Date.AddYears(-20)
        DtpEnd.Value = Today.Date.AddDays(+1)
    End Sub
    Private Sub frmLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'UIThemeHelper.ApplyTheme(Me)
        lblDoc.Text = "Ledger - " + MainPage.LoginDetails
        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.DataSource.clear()
        End If
        Last30Days()
        txtAcID.SelectAll()
        txtAcID.Select()
    End Sub

    Public Sub PDFGen(AccNum As Integer, Customer As String, Descption As String)
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim ReportPath As String = Settings("Reports Folder")
        cryRpt.Load(ReportPath + "\rptLedgerNew3.rpt")
        For Each tb As Table In cryRpt.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        FileName = Settings("Temp Folder") + "Ledger Acc # " & AccNum & ", " & Customer & ".pdf"
        Try
            cryRpt.SetParameterValue("AccNum", AccNum)
            cryRpt.SetParameterValue("DateStart", dtpStart.Value.ToString("d"))
            cryRpt.SetParameterValue("DateEnd", DtpEnd.Value.ToString("d"))
            cryRpt.SetParameterValue("Descp", Descption)
            cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, Settings("Temp Folder") + "Ledger Acc # " & txtAcID.Text & ", " & txtCustomerName.Text & ".pdf")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        txtAcID.Select()
        txtAcID.SelectAll()
    End Sub

    Private Sub ctnExit_Click(sender As Object, e As EventArgs) Handles ctnExit.Click
        Me.Close()
    End Sub

    Sub Ledger()
        If txtAcID.Text = "" Then
            Return
        End If
        If IsNumeric(txtAcID.Text) = False Then
            MsgBox("Pls enter valid account id")
            Return
        End If
        Dim match As String = ""
        If rdAllEntries.Checked Then
            match = ""
        ElseIf rdNoMatch.Checked Then
            match = "0"
        ElseIf rdOnlyMatch.Checked Then
            match = "1"
        Else
            match = ""
        End If
        Dim dt2 As DataTable = SQLData("select subsidary,isnull(ocell,'') ocell from coa where id=" & txtAcID.Text)
        If dt2.Rows.Count = 0 Then
            MsgBox("Account Not found!")
            Return
        End If
        DataGridView1.Columns("colBalance").HeaderText = "Balance"
        Me.Text = "Ledger - " + txtAcID.Text
        txtCustomerName.Text = dt2.Rows(0)("subsidary")
        txtCustomerMobile2.Text = dt2.Rows(0)("ocell")
        Dim dt As DataTable = SQLData("select *,sum(isnull(x.Debit,0)) over (order by DATE,ID)-sum(isnull(x.Credit,0)) over (order by DATE,ID) Total from 
        (select id,Date,Type,Doc,isnull(Narration,'') Narration,ISNULL(debit,0) Debit,ISNULL(credit,0) Credit, isnull(status,0) Status from ledgers l where acid=" & txtAcID.Text & " and narration like '%" & txtDescription.Text & "%' AND TYPE LIKE '" & txtDoc.Text & "%' and doc like '" & txtNumber.Text & "%' and date>='" & dtpStart.Value & "' and date<= '" & DtpEnd.Value & "' AND ISNULL(CREDIT,'') like '" & txtCredit.Text & "%'  and isnull(status,0) like '%" & match & "'
        union
        select 0 id,'" & dtpStart.Value.AddDays(-1) & "','OE',0,'Opening Balance',(select isnull(sum(debit),0)-isnull(sum(credit),0) from Ledgers l2 where l2.acid=" & txtAcID.Text & " and date<'" & dtpStart.Value & "'),0,0 Status
        ) x 
        ")
        Dim dtTotals As DataTable = SQLData("select isnull(sum(debit),0) totDebit, isnull(sum(credit),0) totCredit from ledgers where acid= " & txtAcID.Text & "  and narration like '%" & txtDescription.Text & "%' AND TYPE like '" & txtDoc.Text & "%' and doc like '" & txtNumber.Text & "%'  and date>='" & dtpStart.Value & "'   and date<='" & DtpEnd.Value & "' and isnull(status,0) like '%" & match & "'  ")
        DataGridView1.DataSource = dt
        GRIDBACKCOLOR()
        ' Add view-image column and populate per-row state
        EnsureViewImageColumn()
        PopulateViewImageButtons()
        AdjustNarrationWidth()

        If DataGridView1.Rows.Count > 0 Then
            If rdTally.Checked Then
                DataGridView1.FirstDisplayedScrollingRowIndex = 1
            Else
                DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.Rows.Count - 1
            End If
        End If
        txtTotalDebit.Text = Form3.Amt(dtTotals.Rows(0)("totDebit"))
        txtTotalCredit.Text = Form3.Amt(dtTotals.Rows(0)("totCredit"))
        Dim dif = dtTotals.Rows(0)("totDebit") - dtTotals.Rows(0)("totCredit")
        Dim NetBal As Integer = dt.Rows(dt.Rows.Count - 1)("total")
        txtBalance.Text = Form3.Amt(NetBal)
        If dif > 0 Then
            txtDifference.ForeColor = Color.Red
        ElseIf dif < 0 Then
            txtDifference.ForeColor = Color.Green
        End If
        txtDifference.Text = Form3.Amt(dif)
        DataGridView1.Columns("colID").Visible = False

        ' Ensure monthly closing column is removed and widths reset for normal ledger
        RemoveClosingColumnFromGrid()
        AdjustColumnWidths(False)
        ' Recompute final fit so view column is visible and no horizontal scroll
        ForceFitColumnWidths()
    End Sub

    Sub GRIDBACKCOLOR()
        For Each R As DataGridViewRow In DataGridView1.Rows
            If R.Cells("Status").Value = 1 Then
                R.DefaultCellStyle.BackColor = Color.LightGreen
            ElseIf R.Cells("Status").Value = 2 Then
                R.DefaultCellStyle.BackColor = Color.Yellow
            ElseIf R.Cells("COLNARRATION").Value.ToString.ToUpper.Contains("NILL") Or R.Cells("COLNARRATION").Value.ToString.ToUpper.Contains("*") Or R.Cells("COLNARRATION").Value.ToString.ToUpper.Contains("TALLY") Then
                R.DefaultCellStyle.BackColor = Color.LightBlue
            ElseIf R.Cells("COLNARRATION").Value.ToString.ToUpper.Contains("PENDING") Then
                R.DefaultCellStyle.BackColor = Color.Red
                R.DefaultCellStyle.ForeColor = Color.White
                R.DefaultCellStyle.Font = New Font(DataGridView1.DefaultCellStyle.Font, FontStyle.Bold)
            Else
                R.DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub

    ' Add or remove a closing balance column and adjust column widths
    Private Sub EnsureClosingColumn(dt As DataTable)
        If dt Is Nothing Then Return

        ' add Closing column if not present
        If Not dt.Columns.Contains("Closing") Then
            dt.Columns.Add("Closing", GetType(Decimal))
        End If

        Dim running As Decimal = 0D
        For Each r As DataRow In dt.Rows
            Dim tot As Decimal = 0D
            If Not IsDBNull(r("total")) Then
                Decimal.TryParse(r("total").ToString(), tot)
            End If
            running = running + tot
            r("Closing") = running
        Next
    End Sub

    Private Sub EnsureClosingColumnInGrid()
        Try
            ' If explicit colClosing already exists, ensure visible and format and exit
            If DataGridView1.Columns.Contains("colClosing") Then
                With DataGridView1.Columns("colClosing")
                    .Visible = True
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "N0"
                    .ReadOnly = True
                    .Width = 120
                End With
                Return
            End If

            ' If DataGridView auto-generated a bound column for "Closing", reuse it and apply formatting
            For Each existingCol As DataGridViewColumn In DataGridView1.Columns
                If String.Equals(existingCol.DataPropertyName, "Closing", StringComparison.OrdinalIgnoreCase) Then
                    existingCol.Name = "colClosing"
                    existingCol.HeaderText = "Closing"
                    existingCol.ReadOnly = True
                    existingCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    existingCol.DefaultCellStyle.Format = "N0"
                    existingCol.Width = 120
                    existingCol.Visible = True
                    Return
                End If
            Next

            ' Otherwise insert a new column bound to Closing with formatting
            Dim col As New DataGridViewTextBoxColumn()
            col.Name = "colClosing"
            col.DataPropertyName = "Closing"
            col.HeaderText = "Closing"
            col.ReadOnly = True
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            col.DefaultCellStyle.Format = "N0"
            col.Width = 120

            ' insert before Status column if present
            Dim insertIndex As Integer = DataGridView1.Columns.Count
            If DataGridView1.Columns.Contains("Status") Then
                insertIndex = DataGridView1.Columns("Status").Index
            End If
            DataGridView1.Columns.Insert(insertIndex, col)
        Catch
            ' Silent catch to match existing style
        End Try
    End Sub

    Private Sub RemoveClosingColumnFromGrid()
        Try
            If DataGridView1.Columns.Contains("colClosing") Then
                DataGridView1.Columns.Remove("colClosing")
            End If
        Catch
        End Try
    End Sub

    Private Sub AdjustColumnWidths(isMonthly As Boolean)
        Try
            Dim avail = DataGridView1.ClientSize.Width - DataGridView1.RowHeadersWidth - 20
            If avail <= 0 Then Return

            If isMonthly Then
                ' desired base widths: date, type, doc, narration, debit, credit, balance, closing
                Dim base() As Integer = {110, 90, 90, 350, 120, 120, 120, 120}
                Dim names() As String = {"colDate", "colType", "colDoc", "colNarration", "colDebit", "colCredit", "colBalance", "colClosing"}
                Dim totalBase As Integer = 0
                For Each b In base
                    totalBase += b
                Next
                For i = 0 To names.Length - 1
                    If DataGridView1.Columns.Contains(names(i)) Then
                        Dim w = CInt(base(i) * avail / totalBase)
                        DataGridView1.Columns(names(i)).Width = Math.Max(50, w)
                    End If
                Next
            Else
                ' restore defaults from designer
                If DataGridView1.Columns.Contains("colDate") Then DataGridView1.Columns("colDate").Width = 125
                If DataGridView1.Columns.Contains("colType") Then DataGridView1.Columns("colType").Width = 125
                If DataGridView1.Columns.Contains("colDoc") Then DataGridView1.Columns("colDoc").Width = 125
                If DataGridView1.Columns.Contains("colNarration") Then DataGridView1.Columns("colNarration").Width = 460
                If DataGridView1.Columns.Contains("colDebit") Then DataGridView1.Columns("colDebit").Width = 120
                If DataGridView1.Columns.Contains("colCredit") Then DataGridView1.Columns("colCredit").Width = 120
                If DataGridView1.Columns.Contains("colBalance") Then DataGridView1.Columns("colBalance").Width = 140
            End If
        Catch
        End Try
    End Sub

    Sub LedgerPeriodicTotal()
        If txtAcID.Text = "" Then
            Return
        End If
        Dim dt2 As DataTable = SQLData("select subsidary,ocell,isnull(status,0) Status from coa where id=" & txtAcID.Text)
        If dt2.Rows.Count = 0 Then
            MsgBox("Account Not found!")
            Return
        End If
        DataGridView1.Columns("colBalance").HeaderText = "Difference"
        Me.Text = "Ledger - " + txtAcID.Text
        txtCustomerName.Text = dt2.Rows(0)("subsidary")
        txtCustomerMobile2.Text = dt2.Rows(0)("ocell")
        Dim dt As DataTable = SQLData("   select 0 id,'" & dtpStart.Value & "' Date,'OE' Type,0 Doc,'Opening Balance' Narration,(select isnull(sum(debit),0)-isnull(sum(credit),0) from Ledgers l2 where l2.acid=" & txtAcID.Text & " and date<'" & dtpStart.Value & "') Debit,0 Credit, (select isnull(sum(debit),0)-isnull(sum(credit),0) from Ledgers l2 where l2.acid=" & txtAcID.Text & " and date<'" & dtpStart.Value & "') total,'0' Status
                                            union
                                                SELECT 0 id,convert(datetime,CONVERT(VARCHAR(6),YEAR(DATE))+'.01.'+CONVERT(VARCHAR(6),MONTH(DATE)) ,104) DATE,'' TYPE,'' DOC,DATENAME(MONTH,DATE)+'-'+DATENAME(YEAR,DATE) NARRATION,ISNULL(SUM(DEBIT),0) DEBIT, ISNULL(SUM(CREDIT),0) CREDIT ,  ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) total,'0' Status
                                                FROM Ledgers l
                                                WHERE ACID=" & txtAcID.Text & " AND DATE>='" & dtpStart.Value & "' AND DATE<='" & DtpEnd.Value & "' 
                                                GROUP BY month(date),year(date),DATENAME(MONTH,DATE)+'-'+DATENAME(YEAR,DATE)
                                                ")
        Dim dtTotals As DataTable = SQLData("select isnull(sum(debit),0) totDebit, isnull(sum(credit),0) totCredit from ledgers where acid= " & txtAcID.Text & "  and narration like '%" & txtDescription.Text & "%'  and date>='" & dtpStart.Value & "'   and date<='" & DtpEnd.Value & "'  ")
        DataGridView1.DataSource = dt
        ' compute cumulative closing balance per row and add column to grid
        EnsureClosingColumn(dt)
        EnsureClosingColumnInGrid()
        AdjustColumnWidths(True)

        ' Ensure view-image column and populate buttons for periodic view too
        EnsureViewImageColumn()
        PopulateViewImageButtons()
        AdjustNarrationWidth()
        ForceFitColumnWidths()

        txtTotalDebit.Text = Form3.Amt(dtTotals.Rows(0)("totDebit"))
        txtTotalCredit.Text = Form3.Amt(dtTotals.Rows(0)("totCredit"))
        Dim dif = dtTotals.Rows(0)("totDebit") - dtTotals.Rows(0)("totCredit")
        Dim NetBal As Integer = dt.Rows(dt.Rows.Count - 1)("total")
        txtBalance.Text = Form3.Amt(NetBal)
        If dif > 0 Then
            txtDifference.ForeColor = Color.Red
        ElseIf dif < 0 Then
            txtDifference.ForeColor = Color.Green
        End If
        txtDifference.Text = Form3.Amt(dif)
        DataGridView1.Columns("colID").Visible = False

    End Sub

    Private Sub TextBox3_Leave(sender As Object, e As EventArgs) Handles txtAcID.Leave, txtDescription.TextChanged, dtpStart.ValueChanged, DtpEnd.ValueChanged, txtDoc.Leave, txtRoute.Leave, txtNumber.Leave
        lblDeal.Text = ""
        lblDate.Text = ""
        If txtAcID.Text <> "" Then
            Dim dt As DataTable = SQLData("select top 1 date,narration from ledgers where acid='" & txtAcID.Text & "' and narration like '%deal%' order by date desc")
            If dt.Rows.Count > 0 Then
                lblDate.Text = dt.Rows(0)("Date")
                lblDeal.Text = dt.Rows(0)("Narration")
            End If
        End If
        If rdTally.Checked And txtAcID.Text <> "" Then
            LastTally()
        End If
        If chkMTR.Checked = True Then
            LedgerPeriodicTotal()
        Else
            Ledger()
        End If
    End Sub

    Private Sub txtAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAcID.KeyDown, txtDoc.KeyDown, txtRoute.KeyDown
        If e.KeyCode = Keys.Enter And txtAcID.Text <> "" Then
            e.SuppressKeyPress = True
            If chkMTR.Checked = True Then
                LedgerPeriodicTotal()
            Else
                Ledger()
            End If
            DataGridView1.Select()
        End If
        If e.KeyCode = Keys.Enter And txtAcID.Text = "" Then
            e.Handled = True
            frmPartySearch.ShowDialog()
            txtAcID.Text = frmPartySearch.acID
            txtRoute.Text = frmPartySearch.CustomerRoute
            frmPartySearch.Dispose()
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim cryRpt As New ReportDocument
        Dim FileName As String
        Dim ReportPath As String = Settings("Reports Folder")
        FileName = "D: \Google Drive ai\db backup\Invoice Temp\Ledger Acc # " & txtAcID.Text & ", " & txtCustomerName.Text & ".pdf"
        If chkMTR.Checked = True Then
            FileName = Settings("Temp Folder") + "Monthly Transactions Acc # " & txtAcID.Text & ", " & txtCustomerName.Text & ".pdf"
            cryRpt.Load(ReportPath + "rptLedgerNewTotals2.rpt")
            For Each tb As Table In cryRpt.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            cryRpt.SetParameterValue("AccID", txtAcID.Text)
            cryRpt.SetParameterValue("SDate", dtpStart.Value.ToString("d"))
            cryRpt.SetParameterValue("EDate", DtpEnd.Value.ToString("d"))
            cryRpt.ExportToDisk(ExportFormatType.Excel, FileName)
            MsgBox("File exported")
            txtAcID.Select()
            txtAcID.SelectAll()
            Return

        Else
            cryRpt.Load(ReportPath + "rptLedgerNewExcel.rpt")
            FileName = Settings("Temp Folder") + "Ledger Acc # " & txtAcID.Text & ", " & txtCustomerName.Text & ".xls"
        End If
        For Each tb As Table In cryRpt.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        cryRpt.SetParameterValue("AccNum", txtAcID.Text)
        cryRpt.SetParameterValue("DateStart", dtpStart.Value.ToString("d"))
        cryRpt.SetParameterValue("DateEnd", DtpEnd.Value.ToString("d"))
        cryRpt.SetParameterValue("Descp", txtDescription.Text)
        cryRpt.ExportToDisk(ExportFormatType.Excel, FileName)
        MsgBox("File exported")
        txtAcID.Select()
        txtAcID.SelectAll()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        LedgerPeriodicTotal()
    End Sub

    Private Sub chkMTR_CheckedChanged(sender As Object, e As EventArgs) Handles chkMTR.CheckedChanged
        If chkMTR.Checked = True Then
            dtpStart.Value = New DateTime(Now.Year, Now.Month, 1).AddMonths(-12)
            LedgerPeriodicTotal()
        Else
            dtpStart.Value = Today.Date.AddDays(-30)
            Ledger()
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim Result As DialogResult = MessageBox.Show("Do you want to print on Laser Printer ?", "Print Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.No Then
            txtAcID.Select()
            txtAcID.SelectAll()
            Return
        End If
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table
        Dim FileName As String
        FileName = "D:\Google Drive ai\db backup\Invoice Temp\Ledger Acc # " & txtAcID.Text & ", " & txtCustomerName.Text & ".pdf"
        cryRpt.Load(Settings("Reports Folder") + "rptLedgerNew3.rpt")
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
            cryRpt.SetParameterValue("AccNum", txtAcID.Text)
            cryRpt.SetParameterValue("DateStart", dtpStart.Value.ToString("d"))
            cryRpt.SetParameterValue("DateEnd", DtpEnd.Value.ToString("d"))
            cryRpt.SetParameterValue("Descp", txtDescription.Text)
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
        txtAcID.Select()
        txtAcID.SelectAll()
        cryRpt.PrintToPrinter(1, False, 0, 0)
    End Sub

    Private Sub TXTACID_Enter(sender As Object, e As EventArgs) Handles txtAcID.Enter, txtDoc.Enter, txtRoute.Enter
        txtAcID.SelectAll()
    End Sub

    Private Sub txtDescription_Enter(sender As Object, e As EventArgs) Handles txtDescription.Enter
        txtDescription.SelectAll()
    End Sub
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim rNumber = e.RowIndex
        Dim dNumber As String = DataGridView1.Item("colDoc", e.RowIndex).Value.ToString
        Dim dType As String = DataGridView1.Item("colType", e.RowIndex).Value.ToString
        If DataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen Then
            DataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.White
        Else
            DataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen
        End If
        DataGridView1.Rows(rNumber).Selected = False
        DataGridView1.Refresh()
        SQLData("update ledgers set status=case when status = 1 then 0 else 1 end where type='" & dType & "' and doc='" & dNumber & "' and acid='" & txtAcID.Text & "'    ")
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = 116 Then
            Dim rNumber = DataGridView1.CurrentRow.Index
            If rNumber < 1 Then
                MsgBox("Pls select any row first")
                Return
            End If
            Dim dNumber As String = DataGridView1.Item("colDoc", rNumber).Value.ToString
            Dim dType As String = DataGridView1.Item("colType", rNumber).Value.ToString
            Dim cBalance As String = Form3.Amt(DataGridView1.Item("ColBalance", rNumber).Value.ToString)
            SQLData("update ledgers set status=case when status = 2 then 0 else 2 end,
                                              Narration=case when charindex('P.TALLY',narration) = 0 then narration+' P.TALLY BALANCE '+'" & cBalance & "' 
                                                            when charindex('P.TALLY',narration)>0 then substring(narration,1,charindex('P.TALLY',narration)-1) 
                                                            else narration end
                                                    where type='" & dType & "' and doc='" & dNumber & "' and acid='" & txtAcID.Text & "'    ")
            Dim NARR As String = DataGridView1.Item("ColNarration", rNumber).Value
            If DataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow Then
                DataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.White
                If NARR.IndexOf("P.TALLY BALANCE") > 0 Then
                    NARR = NARR.Substring(0, NARR.IndexOf("P.TALLY BALANCE") - 1)
                End If
            Else
                DataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow
                NARR = NARR + " P.TALLY BALANCE " + cBalance
            End If
            DataGridView1.Item("ColNarration", rNumber).Value = NARR
            DataGridView1.Rows(rNumber).Selected = False
            DataGridView1.Refresh()
        End If
    End Sub

    Private Sub btnExport_Click_1(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim cryRpt As New ReportDocument
        Dim FileName As String

        FileName = "D:\Google Drive ai\db backup\Invoice Temp\Ledger Acc # " & txtAcID.Text & ", " & txtCustomerName.Text & ".pdf"
        If chkMTR.Checked = True Then
            FileName = "D:\Google Drive ai\db backup\Invoice Temp\Monthly Transactions Acc # " & txtAcID.Text & ", " & txtCustomerName.Text & ".pdf"
            cryRpt.Load(Settings("Reports Folder") + "MTR.rpt")
            For Each tb As Table In cryRpt.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            cryRpt.SetParameterValue("AccID", txtAcID.Text)
            cryRpt.SetParameterValue("SDate", dtpStart.Value.ToString("d"))
            cryRpt.SetParameterValue("EDate", DtpEnd.Value.ToString("d"))
            cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)
            MsgBox("File exported")
            txtAcID.Select()
            txtAcID.SelectAll()
            Return
        Else
            cryRpt.Load(Settings("Reports Folder") + "rptLedgerNew3.rpt")
            FileName = "D:\Google Drive ai\db backup\Invoice Temp\Ledger Acc # " & txtAcID.Text & ", " & txtCustomerName.Text & ".pdf"
        End If
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table
        With crConnectionInfo
            .ServerName = frmLogin.MySqlServer
            .DatabaseName = frmLogin.MyDataBase
            .UserID = "sa"
            .Password = MainPage.Password
        End With
        '====================

        '===========================
        CrTables = cryRpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
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
        cryRpt.SetParameterValue("AccNum", txtAcID.Text)
        cryRpt.SetParameterValue("DateStart", dtpStart.Value.ToString("d"))
        cryRpt.SetParameterValue("DateEnd", DtpEnd.Value.ToString("d"))
        cryRpt.SetParameterValue("Descp", txtDescription.Text)
        cryRpt.Export()
        MsgBox("File exported")
        txtAcID.Select()
        txtAcID.SelectAll()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ocell As String = txtCustomerMobile2.Text
        ocell = ocell.Substring(1)
        ocell = "92" + ocell.Replace(" ", "")
        PDFGen(txtAcID.Text, txtCustomerName.Text, "")
        Form3.Whatsapp(ocell, "")
        Form3.SendFile(FileName)
    End Sub

    Private Sub rd30Days_CheckedChanged(sender As Object, e As EventArgs) Handles rd30Days.CheckedChanged
        If rd30Days.Checked Then
            Last30Days()

        End If
    End Sub

    Private Sub rdCurrent_CheckedChanged(sender As Object, e As EventArgs) Handles rdCurrent.CheckedChanged
        CurrentMonth()
    End Sub

    Private Sub rd6Months_CheckedChanged(sender As Object, e As EventArgs) Handles rd6Months.CheckedChanged
        Last6Months()
    End Sub

    Private Sub rdAll_CheckedChanged(sender As Object, e As EventArgs) Handles rdAll.CheckedChanged
        ALL()
    End Sub

    Private Sub rdAllEntries_CheckedChanged(sender As Object, e As EventArgs) Handles rdAllEntries.CheckedChanged, rdNoMatch.CheckedChanged, rdOnlyMatch.CheckedChanged
        Ledger()
    End Sub

    Private Sub rdTally_CheckedChanged(sender As Object, e As EventArgs) Handles rdTally.CheckedChanged
        LastTally()
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        DGVRowNumbers.AddRowNumbers(DataGridView1, e)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If frmLogin.UserLevel.ToUpper() = "ADMIN" Then
            SQLData("update ledgers set status=0 where acid=" & txtAcID.Text & " and date>='" & dtpStart.Value.ToString("d") & "' and date<='" & DtpEnd.Value.ToString("d") & "'")
            Ledger()
        End If

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

        Try
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
            If Not DataGridView1.Columns.Contains("colBalance") Then Return
            If DataGridView1.Columns(e.ColumnIndex).Name <> "colBalance" Then Return

            Dim val = e.Value
            If val Is Nothing OrElse IsDBNull(val) Then
                ' reset to defaults to avoid leftover formatting
                e.CellStyle.BackColor = DataGridView1.DefaultCellStyle.BackColor
                e.CellStyle.ForeColor = DataGridView1.DefaultCellStyle.ForeColor
                Return
            End If

            Dim d As Decimal
            If Decimal.TryParse(val.ToString(), d) And chkMTR.Checked Then
                If d > 0D Then
                    e.CellStyle.BackColor = Color.Red
                    e.CellStyle.ForeColor = Color.White
                Else
                    ' restore default styling for non-positive values
                    e.CellStyle.BackColor = DataGridView1.DefaultCellStyle.BackColor
                    e.CellStyle.ForeColor = DataGridView1.DefaultCellStyle.ForeColor
                End If

                ' ensure numeric format and right alignment
                e.CellStyle.Format = "N0"
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Catch
            ' match existing silent-fail style
        End Try
    End Sub
End Class
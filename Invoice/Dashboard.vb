Imports System.Data.SqlClient
Imports System.Threading

Partial Public Class Dashboard
    Inherits System.Windows.Forms.Form

    Private dgvDifferences As DataGridView = Nothing
    Private lblInfo As Label = Nothing
    Private pnlFilters As Panel = Nothing
    Private txtRoute As TextBox = Nothing
    Private txtEntryBy As TextBox = Nothing
    Private txtSubsidiary As TextBox = Nothing
    Private _fullDataTable As DataTable = Nothing
    Private _filterDelayTimer As System.Windows.Forms.Timer = Nothing

    Private _refreshTimer As System.Threading.Timer
    Private _refreshIntervalMs As Integer = 30000
    Private _isRefreshing As Boolean = False
    Private _fetchDataFunc As Func(Of DataTable) = Nothing

    ' ── Initialize Filter Panel ──────────────────────────────────────────────

    Private Sub InitializeFilterPanel()
        If pnlFilters Is Nothing Then
            pnlFilters = New Panel()
            pnlFilters.Dock = DockStyle.Top
            pnlFilters.Height = 45
            pnlFilters.BackColor = Color.FromArgb(245, 245, 245)
            pnlFilters.BorderStyle = BorderStyle.FixedSingle
            pnlFilters.AutoScroll = False
            Me.Controls.Add(pnlFilters)

            ' Create labels and textboxes in ONE LINE
            Dim startY As Integer = 8
            Dim startX As Integer = 15
            Dim labelWidth As Integer = 70
            Dim textboxWidth As Integer = 150
            Dim xOffset As Integer = startX
            Dim font As New Font("Segoe UI", 9, FontStyle.Regular)

            ' Route Filter
            Dim lblRoute As New Label()
            lblRoute.Text = "Route:"
            lblRoute.Font = font
            lblRoute.Location = New Point(xOffset, startY)
            lblRoute.Size = New Size(labelWidth, 20)
            pnlFilters.Controls.Add(lblRoute)
            xOffset += labelWidth + 5

            txtRoute = New TextBox()
            txtRoute.Location = New Point(xOffset, startY)
            txtRoute.Size = New Size(textboxWidth, 20)
            txtRoute.Font = font
            AddHandler txtRoute.TextChanged, AddressOf FilterTextBox_TextChanged
            pnlFilters.Controls.Add(txtRoute)
            xOffset += textboxWidth + 20

            ' EntryBy Filter
            Dim lblEntryBy As New Label()
            lblEntryBy.Text = "Entry By:"
            lblEntryBy.Font = font
            lblEntryBy.Location = New Point(xOffset, startY)
            lblEntryBy.Size = New Size(labelWidth, 20)
            pnlFilters.Controls.Add(lblEntryBy)
            xOffset += labelWidth + 5

            txtEntryBy = New TextBox()
            txtEntryBy.Location = New Point(xOffset, startY)
            txtEntryBy.Size = New Size(textboxWidth, 20)
            txtEntryBy.Font = font
            AddHandler txtEntryBy.TextChanged, AddressOf FilterTextBox_TextChanged
            pnlFilters.Controls.Add(txtEntryBy)
            xOffset += textboxWidth + 20

            ' Subsidiary Filter
            Dim lblSubsidiary As New Label()
            lblSubsidiary.Text = "Subsidiary:"
            lblSubsidiary.Font = font
            lblSubsidiary.Location = New Point(xOffset, startY)
            lblSubsidiary.Size = New Size(labelWidth, 20)
            pnlFilters.Controls.Add(lblSubsidiary)
            xOffset += labelWidth + 5

            txtSubsidiary = New TextBox()
            txtSubsidiary.Location = New Point(xOffset, startY)
            txtSubsidiary.Size = New Size(textboxWidth, 20)
            txtSubsidiary.Font = font
            AddHandler txtSubsidiary.TextChanged, AddressOf FilterTextBox_TextChanged
            pnlFilters.Controls.Add(txtSubsidiary)
            xOffset += textboxWidth + 20

            ' Clear Filters Button
            Dim btnClearFilters As New Button()
            btnClearFilters.Text = "Clear Filters"
            btnClearFilters.Location = New Point(xOffset, startY - 2)
            btnClearFilters.Size = New Size(100, 24)
            btnClearFilters.Font = font
            AddHandler btnClearFilters.Click, AddressOf ClearFilters_Click
            pnlFilters.Controls.Add(btnClearFilters)

            ' Make sure panel is visible and in front
            pnlFilters.Visible = True
            pnlFilters.BringToFront()
        End If
    End Sub

    Private Sub FilterTextBox_TextChanged(sender As Object, e As EventArgs)
        ' Debounce filter updates to avoid lag
        If _filterDelayTimer Is Nothing Then
            _filterDelayTimer = New System.Windows.Forms.Timer()
            _filterDelayTimer.Interval = 300
            AddHandler _filterDelayTimer.Tick, AddressOf FilterDelayTimer_Tick
        End If
        _filterDelayTimer.Stop()
        _filterDelayTimer.Start()
    End Sub

    Private Sub FilterDelayTimer_Tick(sender As Object, e As EventArgs)
        _filterDelayTimer.Stop()
        ApplyFilters()
    End Sub

    Private Sub ApplyFilters()
        If _fullDataTable Is Nothing OrElse dgvDifferences Is Nothing Then Return

        Dim routeFilter As String = txtRoute.Text.Trim().ToLower()
        Dim entryByFilter As String = txtEntryBy.Text.Trim().ToLower()
        Dim subsidaryFilter As String = txtSubsidiary.Text.Trim().ToLower()

        Dim dv As New DataView(_fullDataTable)
        Dim filterConditions As New List(Of String)

        If Not String.IsNullOrEmpty(routeFilter) Then
            filterConditions.Add($"Route LIKE '%{routeFilter.Replace("'", "''")}%'")
        End If

        If Not String.IsNullOrEmpty(entryByFilter) Then
            filterConditions.Add($"EntryBy LIKE '%{entryByFilter.Replace("'", "''")}%'")
        End If

        If Not String.IsNullOrEmpty(subsidaryFilter) Then
            filterConditions.Add($"Subsidary LIKE '%{subsidaryFilter.Replace("'", "''")}%'")
        End If

        If filterConditions.Count > 0 Then
            dv.RowFilter = String.Join(" AND ", filterConditions)
        Else
            dv.RowFilter = ""
        End If

        dgvDifferences.DataSource = dv.ToTable()

        ' Re-populate S.No and buttons after filtering
        If dgvDifferences.Columns.Contains("SNo") Then
            For rowIdx As Integer = 0 To dgvDifferences.Rows.Count - 1
                dgvDifferences.Rows(rowIdx).Cells("SNo").Value = rowIdx + 1
                dgvDifferences.Rows(rowIdx).Cells("SNo").Style.Font = New Font("Segoe UI", 12, FontStyle.Bold)
                dgvDifferences.Rows(rowIdx).Cells("SNo").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        End If

        ' Update button states
        If dgvDifferences.Columns.Contains("HasImage") Then
            For rowIdx As Integer = 0 To dgvDifferences.Rows.Count - 1
                Dim hasImageValue = dgvDifferences.Rows(rowIdx).Cells("HasImage").Value
                Dim buttonCell = dgvDifferences.Rows(rowIdx).Cells("ViewImage")

                If hasImageValue IsNot Nothing AndAlso hasImageValue.ToString().ToUpper() = "YES" Then
                    buttonCell.Value = "View"
                    buttonCell.Style.ForeColor = Color.Black
                    buttonCell.Style.BackColor = Color.LightGreen
                Else
                    buttonCell.Value = ""
                    buttonCell.Style.ForeColor = Color.Gray
                    buttonCell.Style.BackColor = Color.LightGray
                End If
            Next
        End If
    End Sub

    Private Sub ClearFilters_Click(sender As Object, e As EventArgs)
        txtRoute.Text = ""
        txtEntryBy.Text = ""
        txtSubsidiary.Text = ""
        ApplyFilters()
    End Sub

    ' ── Auto-refresh ─────────────────────────────────────────────────────────

    Public Sub StartAutoRefresh(fetchData As Func(Of DataTable))
        _fetchDataFunc = fetchData
        _refreshTimer = New System.Threading.Timer(
            AddressOf RefreshTimerCallback,
            Nothing,
            _refreshIntervalMs,
            _refreshIntervalMs)
    End Sub

    Private Sub RefreshTimerCallback(state As Object)
        If _isRefreshing Then Return
        _isRefreshing = True
        Try
            Dim dt As DataTable = _fetchDataFunc()
            If Me.IsHandleCreated Then
                Me.Invoke(New Action(Sub() ShowDifferences(dt)))
            End If
        Catch
        Finally
            _isRefreshing = False
        End Try
    End Sub

    Public Sub StopAutoRefresh()
        If _refreshTimer IsNot Nothing Then
            _refreshTimer.Dispose()
            _refreshTimer = Nothing
        End If
    End Sub

    ' ── Form Load Event - Maximize and fill available space ─────────────────────

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Maximize the form to fill available MDI area
            Me.WindowState = FormWindowState.Maximized
            Me.Width = Me.Parent.ClientSize.Width
            Me.Height = Me.Parent.ClientSize.Height
        Catch
            ' If issues occur, set a reasonable default size
            Me.Width = Math.Min(1400, Screen.PrimaryScreen.WorkingArea.Width - 50)
            Me.Height = Math.Min(700, Screen.PrimaryScreen.WorkingArea.Height - 100)
        End Try
    End Sub

    ' ── Main display method ───────────────────────────────────────────────────

    Public Sub ShowDifferences(dt As DataTable)
        ' Initialize filter panel FIRST (before info label)
        InitializeFilterPanel()

        ' Store full data table for filtering
        _fullDataTable = dt

        If lblInfo Is Nothing Then
            lblInfo = New Label()
            lblInfo.Dock = DockStyle.Top
            lblInfo.Height = 30
            lblInfo.TextAlign = ContentAlignment.MiddleCenter
            lblInfo.Font = New Font("Segoe UI", 10, FontStyle.Regular)
            lblInfo.ForeColor = Color.DarkBlue
            Me.Controls.Add(lblInfo)
        End If

        ' Ensure filter panel is on top and visible
        If pnlFilters IsNot Nothing Then
            pnlFilters.BringToFront()
        End If

        If dt Is Nothing Then
            lblInfo.Text = "No data available (database error or no results). Check logs\db_errors.log."
            If dgvDifferences IsNot Nothing Then dgvDifferences.DataSource = Nothing
            Return
        End If

        If dt.Rows.Count = 0 Then
            lblInfo.Text = "No differences found."
            If dgvDifferences IsNot Nothing Then dgvDifferences.DataSource = Nothing
            Return
        End If

        lblInfo.Text = "Loading data..."

        If dgvDifferences Is Nothing Then
            dgvDifferences = New DataGridView()
            dgvDifferences.Dock = DockStyle.Fill
            dgvDifferences.ReadOnly = False
            dgvDifferences.AllowUserToAddRows = False
            dgvDifferences.AllowUserToDeleteRows = False
            dgvDifferences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.None
            dgvDifferences.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgvDifferences.RowHeadersVisible = False
            dgvDifferences.Font = New Font("Segoe UI", 12, FontStyle.Regular)
            dgvDifferences.ScrollBars = ScrollBars.Both
            Me.Controls.Add(dgvDifferences)
            ' DO NOT call BringToFront() on DGV - it will hide the filter panel!
            AddHandler dgvDifferences.CellClick, AddressOf dgvDifferences_CellClick
            AddHandler dgvDifferences.CellFormatting, AddressOf dgvDifferences_CellFormatting
        End If

        ' Populate data asynchronously to keep UI responsive
        Task.Run(Sub() PopulateGridAsync(dt))
    End Sub

    ' ── Async method to populate grid without blocking UI ──────────────────────

    Private Sub PopulateGridAsync(dt As DataTable)
        Try
            If Me.InvokeRequired Then
                Me.Invoke(New Action(Sub() PopulateGridAsync(dt)))
                Return
            End If

            dgvDifferences.DataSource = dt

            ' ── Hide HasImage column ──────────────────────────────────────────────
            If dgvDifferences.Columns.Contains("HasImage") Then
                dgvDifferences.Columns("HasImage").Visible = False
            End If

            ' Disable horizontal scroll bar
            dgvDifferences.ScrollBars = ScrollBars.Vertical

            ' ── Credit column: right-aligned, N0 format ───────────────────────────
            If dgvDifferences.Columns.Contains("Credit") Then
                Dim creditCol = dgvDifferences.Columns("Credit")
                creditCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                creditCol.DefaultCellStyle.Format = "N0"
                creditCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

            ' ── S.No column – add once, always at index 0 ────────────────────────
            If Not dgvDifferences.Columns.Contains("SNo") Then
                Dim snoCol As New DataGridViewTextBoxColumn()
                snoCol.Name = "SNo"
                snoCol.HeaderText = "S.No"
                snoCol.ReadOnly = True
                dgvDifferences.Columns.Add(snoCol)
                dgvDifferences.Columns("SNo").DisplayIndex = 0
            End If

            ' ── View button column – add once ─────────────────────────────────────
            If Not dgvDifferences.Columns.Contains("ViewImage") Then
                Dim btnColumn As New DataGridViewButtonColumn()
                btnColumn.Name = "ViewImage"
                btnColumn.HeaderText = "View"
                btnColumn.Text = "View"
                btnColumn.UseColumnTextForButtonValue = False
                dgvDifferences.Columns.Add(btnColumn)
            End If

            ' ── Resolve button column – add once ──────────────────────────────────
            If Not dgvDifferences.Columns.Contains("Resolve") Then
                Dim resolveColumn As New DataGridViewButtonColumn()
                resolveColumn.Name = "Resolve"
                resolveColumn.HeaderText = "Resolve"
                resolveColumn.Text = "Resolve"
                resolveColumn.UseColumnTextForButtonValue = True
                dgvDifferences.Columns.Add(resolveColumn)
            End If

            ' NOW apply all column widths (after all columns are added)
            ' ── Set responsive column widths to fit all columns without horizontal scroll ──────────────
            ' Calculate available width for columns
            Dim availableWidth As Integer = dgvDifferences.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 5

            ' Define optimal widths for each column
            Dim columnWidths As New Dictionary(Of String, Integer) From {
                {"SNo", 45},
                {"Date", 90},
                {"Type", 15},
                {"Doc", 15},
                {"Route", 200},
                {"ID", 60},
                {"Subsidary", 300},
                {"Credit", 80},
                {"EntryBy", 100},
                {"EntryDateTime", 150},
                {"ViewImage", 55},
                {"Resolve", 80}
            }

            ' Define minimum widths for specific columns
            Dim minColumnWidths As New Dictionary(Of String, Integer) From {
                {"Type", 15},
                {"Doc", 15}
            }

            ' Calculate total required width
            Dim totalRequiredWidth As Integer = 0
            For Each kvp In columnWidths
                If dgvDifferences.Columns.Contains(kvp.Key) Then
                    Dim col = dgvDifferences.Columns(kvp.Key)
                    If col.Visible Then
                        totalRequiredWidth += kvp.Value
                    End If
                End If
            Next

            ' Apply column widths - if content fits, use it; otherwise scale down proportionally
            If totalRequiredWidth > availableWidth Then
                ' Scale down all columns proportionally to fit available width
                Dim scaleFactor As Double = CDbl(availableWidth) / CDbl(totalRequiredWidth)
                For Each kvp In columnWidths
                    If dgvDifferences.Columns.Contains(kvp.Key) Then
                        Dim col = dgvDifferences.Columns(kvp.Key)
                        If col.Visible Then
                            ' Use specific minimum for Type/Doc, otherwise use 40px minimum
                            Dim minWidth As Integer = If(minColumnWidths.ContainsKey(kvp.Key), minColumnWidths(kvp.Key), 40)
                            col.Width = Math.Max(CInt(kvp.Value * scaleFactor), minWidth)
                        End If
                    End If
                Next
            Else
                ' Use defined widths
                For Each kvp In columnWidths
                    If dgvDifferences.Columns.Contains(kvp.Key) Then
                        Dim col = dgvDifferences.Columns(kvp.Key)
                        If col.Visible Then
                            col.Width = kvp.Value
                        End If
                    End If
                Next
            End If

            ' Handle any remaining unmapped columns
            For Each col As DataGridViewColumn In dgvDifferences.Columns
                If col.Visible AndAlso Not columnWidths.ContainsKey(col.Name) Then
                    col.Width = Math.Max(availableWidth / dgvDifferences.Columns.Count, 60)
                End If
            Next

            ' Populate S.No – bold, centered (AFTER width is set)
            For rowIdx As Integer = 0 To dgvDifferences.Rows.Count - 1
                Dim cell = dgvDifferences.Rows(rowIdx).Cells("SNo")
                cell.Value = rowIdx + 1
                cell.Style.Font = New Font("Segoe UI", 12, FontStyle.Bold)
                cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            ' Set button colour based on HasImage and add Resolve button style
            If dgvDifferences.Columns.Contains("HasImage") Then
                For rowIdx As Integer = 0 To dgvDifferences.Rows.Count - 1
                    Dim hasImageValue = dgvDifferences.Rows(rowIdx).Cells("HasImage").Value
                    Dim buttonCell = dgvDifferences.Rows(rowIdx).Cells("ViewImage")
                    Dim resolveCell = dgvDifferences.Rows(rowIdx).Cells("Resolve")

                    If hasImageValue IsNot Nothing AndAlso hasImageValue.ToString().ToUpper() = "YES" Then
                        buttonCell.Value = "View"
                        buttonCell.Style.ForeColor = Color.Black
                        buttonCell.Style.BackColor = Color.LightGreen
                    Else
                        buttonCell.Value = ""
                        buttonCell.Style.ForeColor = Color.Gray
                        buttonCell.Style.BackColor = Color.LightGray
                    End If

                    ' Style Resolve button
                    resolveCell.Value = "Resolve"
                    resolveCell.Style.ForeColor = Color.White
                    resolveCell.Style.BackColor = Color.DodgerBlue
                Next
            End If

            ' Update info label
            lblInfo.Text = ""

        Catch ex As Exception
            If lblInfo IsNot Nothing Then
                lblInfo.Text = $"Error loading data: {ex.Message}"
            End If
        End Try
    End Sub

    ' ── CellFormatting: Credit N0 with null safety ────────────────────────────

    Private Sub dgvDifferences_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        If dgvDifferences.Columns(e.ColumnIndex).Name <> "Credit" Then Return

        If e.Value Is Nothing OrElse IsDBNull(e.Value) Then
            e.Value = ""
            e.FormattingApplied = True
            Return
        End If

        Dim numVal As Decimal = 0
        If Decimal.TryParse(e.Value.ToString(), numVal) Then
            e.Value = numVal.ToString("N0")
            e.FormattingApplied = True
        End If
    End Sub

    ' ── Button click – open image viewer or resolve issue ──────────────────

    Private Sub dgvDifferences_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then Return

        ' Handle Resolve button click
        If dgvDifferences.Columns(e.ColumnIndex).Name = "Resolve" Then
            Try
                If MsgBox("Are you sure you want to resolve this issue?", vbYesNo + vbQuestion) = vbYes Then
                    Dim docType As String = ""
                    Dim docNum As Integer = 0

                    If dgvDifferences.Columns.Contains("type") Then
                        Dim typeValue = dgvDifferences.Rows(e.RowIndex).Cells("type").Value
                        If typeValue IsNot Nothing Then docType = typeValue.ToString()
                    End If

                    If dgvDifferences.Columns.Contains("doc") Then
                        Dim docValue = dgvDifferences.Rows(e.RowIndex).Cells("doc").Value
                        If docValue IsNot Nothing Then Integer.TryParse(docValue.ToString(), docNum)
                    End If

                    If String.IsNullOrWhiteSpace(docType) OrElse docNum = 0 Then
                        MsgBox("Unable to resolve: Missing document type or number.", vbExclamation)
                        Return
                    End If

                    ' Update ledger status in database
                    Using conn As New SqlConnection(MainPage.conString2)
                        Using cmd As New SqlCommand(
                            "UPDATE ledgers SET LedgerStatus='resolved' WHERE [type]=@type AND doc=@doc", conn)
                            cmd.Parameters.AddWithValue("@type", docType)
                            cmd.Parameters.AddWithValue("@doc", docNum)
                            conn.Open()
                            cmd.ExecuteNonQuery()
                            conn.Close()
                        End Using
                    End Using

                    ' Remove the row from the DataGridView
                    dgvDifferences.Rows.RemoveAt(e.RowIndex)

                    ' Repopulate S.No after deletion
                    If dgvDifferences.Columns.Contains("SNo") Then
                        For rowIdx As Integer = 0 To dgvDifferences.Rows.Count - 1
                            dgvDifferences.Rows(rowIdx).Cells("SNo").Value = rowIdx + 1
                        Next
                    End If

                    MsgBox("Issue resolved successfully!", vbInformation)
                End If
            Catch ex As Exception
                MsgBox("Error resolving issue: " & ex.Message, vbExclamation)
            End Try
            Return
        End If

        ' Handle View Image button click
        If dgvDifferences.Columns(e.ColumnIndex).Name <> "ViewImage" Then Return

        Dim hasImageCell = dgvDifferences.Rows(e.RowIndex).Cells("HasImage")
        If hasImageCell Is Nothing OrElse hasImageCell.Value Is Nothing Then Return
        If hasImageCell.Value.ToString().ToUpper() <> "YES" Then Return

        Dim docType2 As String = ""
        Dim docNum2 As Integer = 0

        If dgvDifferences.Columns.Contains("type") Then
            Dim typeValue = dgvDifferences.Rows(e.RowIndex).Cells("type").Value
            If typeValue IsNot Nothing Then docType2 = typeValue.ToString()
        End If

        If dgvDifferences.Columns.Contains("doc") Then
            Dim docValue = dgvDifferences.Rows(e.RowIndex).Cells("doc").Value
            If docValue IsNot Nothing Then Integer.TryParse(docValue.ToString(), docNum2)
        End If

        If String.IsNullOrWhiteSpace(docType2) OrElse docNum2 = 0 Then
            MsgBox("Unable to load image: Missing document type or number.", vbExclamation)
            Return
        End If

        Try
            Dim imgBytes As Byte() = Nothing

            Using conn As New SqlConnection(MainPage.conString2)
                Using cmd As New SqlCommand(
                    "SELECT im.image FROM images.dbo.name_reciepts im WHERE im.[type] = @type AND im.doc = @doc", conn)
                    cmd.Parameters.AddWithValue("@type", docType2)
                    cmd.Parameters.AddWithValue("@doc", docNum2)
                    conn.Open()
                    Dim reader = cmd.ExecuteReader()
                    If reader.Read() Then imgBytes = CType(reader("image"), Byte())
                    reader.Close()
                End Using
            End Using

            If imgBytes Is Nothing OrElse imgBytes.Length = 0 Then
                MsgBox("Image not found in database.", vbExclamation)
                Return
            End If

            Dim viewer = New frmImageViewer(docNum2, docType2)
            viewer.LoadImage(imgBytes)
            viewer.ShowImageMaxHeight(imgBytes)

        Catch ex As Exception
            MsgBox("Error loading image: " & ex.Message, vbExclamation)
        End Try
    End Sub

End Class
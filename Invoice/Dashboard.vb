Imports System.Data.SqlClient
Imports System.Threading

Partial Public Class Dashboard
    Inherits System.Windows.Forms.Form

    Private dgvDifferences As DataGridView = Nothing
    Private lblInfo As Label = Nothing

    Private _refreshTimer As System.Threading.Timer
    Private _refreshIntervalMs As Integer = 30000
    Private _isRefreshing As Boolean = False
    Private _fetchDataFunc As Func(Of DataTable) = Nothing

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

    ' ── Main display method ───────────────────────────────────────────────────

    Public Sub ShowDifferences(dt As DataTable)
        If lblInfo Is Nothing Then
            lblInfo = New Label()
            lblInfo.Dock = DockStyle.Top
            lblInfo.Height = 30
            lblInfo.TextAlign = ContentAlignment.MiddleCenter
            lblInfo.Font = New Font("Segoe UI", 10, FontStyle.Regular)
            lblInfo.ForeColor = Color.DarkBlue
            Me.Controls.Add(lblInfo)
            lblInfo.BringToFront()
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

        lblInfo.Text = ""

        If dgvDifferences Is Nothing Then
            dgvDifferences = New DataGridView()
            dgvDifferences.Dock = DockStyle.Fill
            dgvDifferences.ReadOnly = True
            dgvDifferences.AllowUserToAddRows = False
            dgvDifferences.AllowUserToDeleteRows = False
            dgvDifferences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvDifferences.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgvDifferences.RowHeadersVisible = False
            dgvDifferences.Font = New Font("Segoe UI", 12, FontStyle.Regular)
            Me.Controls.Add(dgvDifferences)
            dgvDifferences.BringToFront()
            AddHandler dgvDifferences.CellClick, AddressOf dgvDifferences_CellClick
            AddHandler dgvDifferences.CellFormatting, AddressOf dgvDifferences_CellFormatting
        End If

        dgvDifferences.DataSource = dt

        ' ── Hide HasImage column ──────────────────────────────────────────────
        If dgvDifferences.Columns.Contains("HasImage") Then
            dgvDifferences.Columns("HasImage").Visible = False
        End If

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
            snoCol.Width = 55
            dgvDifferences.Columns.Add(snoCol)
            dgvDifferences.Columns("SNo").DisplayIndex = 0
        End If

        ' Populate S.No – bold, centered
        For rowIdx As Integer = 0 To dgvDifferences.Rows.Count - 1
            Dim cell = dgvDifferences.Rows(rowIdx).Cells("SNo")
            cell.Value = rowIdx + 1
            cell.Style.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        ' ── View button column – add once ─────────────────────────────────────
        If Not dgvDifferences.Columns.Contains("ViewImage") Then
            Dim btnColumn As New DataGridViewButtonColumn()
            btnColumn.Name = "ViewImage"
            btnColumn.HeaderText = "Action"
            btnColumn.Text = "View"
            btnColumn.UseColumnTextForButtonValue = False
            dgvDifferences.Columns.Add(btnColumn)
        End If

        ' Set button colour based on HasImage
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

        ' ── Resize form to content ────────────────────────────────────────────
        If dgvDifferences.Columns.Count > 0 Then

            ' Step 1: auto-size all columns first
            For Each col As DataGridViewColumn In dgvDifferences.Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

            ' Step 2: override EntryBy AFTER auto-size so it sticks
            If dgvDifferences.Columns.Contains("EntryBy") Then
                dgvDifferences.Columns("EntryBy").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                dgvDifferences.Columns("EntryBy").Width = 150
            End If

            ' Step 3: recalculate total width AFTER all overrides
            Dim totalWidth As Integer = 0
            For Each col As DataGridViewColumn In dgvDifferences.Columns
                totalWidth += col.Width
            Next
            If dgvDifferences.Rows.Count > 10 Then totalWidth += 20

            Me.ClientSize = New Size(
                Math.Min(Math.Max(totalWidth + 30, 800), Screen.PrimaryScreen.WorkingArea.Width - 100),
                Math.Min(dgvDifferences.Rows.Count * 30 + 100, Screen.PrimaryScreen.WorkingArea.Height - 100))
        End If
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

    ' ── Button click – open image viewer ──────────────────────────────────────

    Private Sub dgvDifferences_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then Return
        If dgvDifferences.Columns(e.ColumnIndex).Name <> "ViewImage" Then Return

        Dim hasImageCell = dgvDifferences.Rows(e.RowIndex).Cells("HasImage")
        If hasImageCell Is Nothing OrElse hasImageCell.Value Is Nothing Then Return
        If hasImageCell.Value.ToString().ToUpper() <> "YES" Then Return

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
            MsgBox("Unable to load image: Missing document type or number.", vbExclamation)
            Return
        End If

        Try
            Dim imgBytes As Byte() = Nothing

            Using conn As New SqlConnection(MainPage.conString2)
                Using cmd As New SqlCommand(
                    "SELECT im.image FROM images.dbo.name_reciepts im WHERE im.[type] = @type AND im.doc = @doc", conn)
                    cmd.Parameters.AddWithValue("@type", docType)
                    cmd.Parameters.AddWithValue("@doc", docNum)
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

            Dim viewer = New frmImageViewer(docNum, docType)
            viewer.LoadImage(imgBytes)
            viewer.ShowImageMaxHeight(imgBytes)

        Catch ex As Exception
            MsgBox("Error loading image: " & ex.Message, vbExclamation)
        End Try
    End Sub

End Class
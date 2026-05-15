Imports System.Data.SqlClient
Imports System.Globalization

Public Class frmRecovery

    ' ── State ────────────────────────────────────────────────────────────────
    Private _nodeCheckedState As New Dictionary(Of String, HashSet(Of String))()
    Private _prevNodePath As String = Nothing
    Private _columnsInitialized As Boolean = False
    Private _bsRecovery As New BindingSource()
    Private _isShowingImage As Boolean = False

    ' ── Connection string (single source of truth) ───────────────────────────
    Private ReadOnly Property ConnStr As String
        Get
            Return "Data source=aiserver;database=ahmadinternational;User ID=sa;Password=Ai;"
        End Get
    End Property

    ' =========================================================================
    '  FORM LIFECYCLE
    ' =========================================================================

    Private Sub frmRecovery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Recovery Form - " & MainPage.LoginDetails
        TreeView1.DrawMode = TreeViewDrawMode.Normal
        AddHandler dgvRecovery.RowPostPaint, AddressOf dgvRecovery_RowPostPaint
        LoadTreeView()
    End Sub

    Private Sub frmRecovery_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Timer1.Enabled = chkAutoUpdate.Checked
    End Sub

    Private Sub frmRecovery_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Timer1.Enabled = False
    End Sub

    ' =========================================================================
    '  GRID — ROW NUMBERING & COLOURING
    ' =========================================================================

    Private Sub dgvRecovery_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
        Dim dgv As DataGridView = CType(sender, DataGridView)
        Dim rowIdx As String = (e.RowIndex + 1).ToString()
        Dim centerFmt As New StringFormat() With {
            .Alignment = StringAlignment.Center,
            .LineAlignment = StringAlignment.Center
        }
        Dim hdrBounds As New Rectangle(e.RowBounds.Left, e.RowBounds.Top,
                                       dgv.RowHeadersWidth, e.RowBounds.Height)
        Using b As New SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor)
            Using bigFont As New Drawing.Font(dgv.RowHeadersDefaultCellStyle.Font.FontFamily,
                                              10, Drawing.FontStyle.Bold)
                e.Graphics.DrawString(rowIdx, bigFont, b, hdrBounds, centerFmt)
            End Using
        End Using
        dgv.RowHeadersWidth = 50
    End Sub

    Private Sub dgvRecovery_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) _
        Handles dgvRecovery.RowPrePaint
        If Not dgvRecovery.Columns.Contains("Type") Then Return
        Dim rowType = dgvRecovery.Rows(e.RowIndex).Cells("Type").Value
        dgvRecovery.Rows(e.RowIndex).DefaultCellStyle.BackColor =
            If(rowType IsNot Nothing AndAlso rowType.ToString() = "CPV",
               Color.LightPink, Color.White)
    End Sub

    ' =========================================================================
    '  TREEVIEW — BUILD
    ' =========================================================================

    Private Async Sub LoadTreeView()
        Dim rows = Await Task.Run(Function() FetchTreeRowsFromDb())
        BuildTreeFromRows(rows)
        RestoreOrSelectFirstNode()
    End Sub

    ''' <summary>Returns (docType, entryby, date, route) tuples.</summary>
    Private Function FetchTreeRowsFromDb() As List(Of Tuple(Of String, String, DateTime, String))
        Dim rows As New List(Of Tuple(Of String, String, DateTime, String))()
        Using conn As New SqlConnection(ConnStr)
            conn.Open()
            Dim sql As String = "
                SELECT
                    ISNULL(L.[date], '2021-01-01')            AS [date],
                    CASE
                        WHEN L.[type] IN ('CRV','CPV') THEN 'CASH'
                        WHEN L.[type] = 'BRV'          THEN 'BANK'
                    END                                        AS [type],
                    L.[doc],
                    L.[acid],
                    CASE WHEN L.[type] IN ('CRV','BRV') THEN L.[credit]
                         WHEN L.[type] = 'CPV'          THEN L.[debit]
                    END                                        AS credit,
                    L.[entryby],
                    (SELECT Route FROM coa WHERE id = L.acid) AS Route
                FROM ledgers L
                WHERE L.receiptstatus IS NULL
                  AND L.type IN ('CRV','CPV','BRV')
                  AND CASE WHEN L.type IN ('CRV','BRV') THEN L.credit
                           WHEN L.type = 'CPV'          THEN L.debit
                      END > 0
                ORDER BY L.entryby, L.EntrydateTime, L.[type],
                         (SELECT Route FROM coa WHERE id = L.acid), L.doc"

            Using cmd As New SqlCommand(sql, conn)
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim eb As String = NullStr(rdr("entryby"))
                        Dim tp As String = NullStr(rdr("type"))
                        Dim rt As String = NullStr(rdr("Route"))
                        Dim dt As DateTime = Convert.ToDateTime(rdr("date"))
                        rows.Add(Tuple.Create(tp, eb, dt, rt))
                    End While
                End Using
            End Using
        End Using
        Return rows
    End Function

    Private Sub BuildTreeFromRows(rows As List(Of Tuple(Of String, String, DateTime, String)))
        TreeView1.BeginUpdate()
        Try
            TreeView1.Nodes.Clear()
            TreeView1.DrawMode = TreeViewDrawMode.Normal

            Dim allTypes = rows _
                .Select(Function(r) DefaultIfBlank(r.Item1, "(UnknownType)")) _
                .Distinct() _
                .OrderBy(Function(t) t)

            For Each docType In allTypes
                Dim docNode As TreeNode = TreeView1.Nodes.Add(docType, docType)
                Dim typeRows = rows.Where(Function(r) String.Equals(
                    DefaultIfBlank(r.Item1, "(UnknownType)"), docType,
                    StringComparison.OrdinalIgnoreCase))

                If chkDateWise.Checked Then
                    BuildDateWise(docNode, typeRows)
                Else
                    BuildEntryWise(docNode, typeRows)
                End If
            Next

            TreeView1.CollapseAll()
            For Each n As TreeNode In TreeView1.Nodes
                If n.Text.Trim().ToUpper() = "BANK" Then
                    n.Collapse()
                Else
                    n.Expand()
                End If
            Next
        Finally
            TreeView1.EndUpdate()
        End Try
    End Sub

    ''' <summary>Tree layout: Type(0) → Date(1) → EntryBy(2) → Route(3)</summary>
    Private Sub BuildDateWise(docNode As TreeNode,
                               rows As IEnumerable(Of Tuple(Of String, String, DateTime, String)))
        Dim dateGroups = rows _
            .GroupBy(Function(r) r.Item3.Date) _
            .OrderByDescending(Function(g) g.Key)

        For Each dateGroup In dateGroups
            Dim dateStr = dateGroup.Key.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture)
            Dim dateNode As TreeNode = docNode.Nodes.Add(dateStr, dateStr)
            dateNode.Tag = dateGroup.Key

            Dim entryGroups = dateGroup _
                .GroupBy(Function(r) DefaultIfBlank(r.Item2, "(Unknown)")) _
                .OrderBy(Function(g) g.Key)

            For Each eg In entryGroups
                Dim entryNode As TreeNode = dateNode.Nodes.Add(eg.Key, eg.Key)
                AddUniqueRouteNodes(entryNode, eg)
            Next
        Next
    End Sub

    ''' <summary>Tree layout: Type(0) → EntryBy(1) → Date(2) → Route(3)</summary>
    Private Sub BuildEntryWise(docNode As TreeNode,
                                rows As IEnumerable(Of Tuple(Of String, String, DateTime, String)))
        Dim entryGroups = rows _
            .GroupBy(Function(r) DefaultIfBlank(r.Item2, "(Unknown)")) _
            .OrderBy(Function(g) g.Key)

        For Each eg In entryGroups
            Dim entryNode As TreeNode = docNode.Nodes.Add(eg.Key, eg.Key)

            Dim dateGroups = eg _
                .GroupBy(Function(r) r.Item3.Date) _
                .OrderByDescending(Function(g) g.Key)

            For Each dateGroup In dateGroups
                Dim dateStr = dateGroup.Key.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture)
                Dim dateNode As TreeNode = entryNode.Nodes.Add(dateStr, dateStr)
                dateNode.Tag = dateGroup.Key
                AddUniqueRouteNodes(dateNode, dateGroup)
            Next
        Next
    End Sub

    ''' <summary>
    ''' Adds one child node per DISTINCT, non-blank route.
    ''' </summary>
    Private Sub AddUniqueRouteNodes(parent As TreeNode,
                                    rows As IEnumerable(Of Tuple(Of String, String, DateTime, String)))
        Dim uniqueRoutes = rows _
            .Select(Function(r) DefaultIfBlank(r.Item4, "(No Route)")) _
            .Distinct() _
            .OrderBy(Function(r) r)

        For Each route As String In uniqueRoutes
            parent.Nodes.Add(route, route)
        Next
    End Sub

    ' ── Node path helpers ─────────────────────────────────────────────────────

    Private Function GetNodePath(node As TreeNode) As String
        If node Is Nothing Then Return ""
        Dim parts As New List(Of String)()
        Dim cur = node
        Do
            parts.Insert(0, cur.Text)
            cur = cur.Parent
        Loop While cur IsNot Nothing
        Return String.Join("|", parts)
    End Function

    Private Function FindNodeByPath(nodes As TreeNodeCollection,
                                    pathParts As String(),
                                    level As Integer) As TreeNode
        For Each node As TreeNode In nodes
            If node.Text = pathParts(level) Then
                If level = pathParts.Length - 1 Then Return node
                Return FindNodeByPath(node.Nodes, pathParts, level + 1)
            End If
        Next
        Return Nothing
    End Function

    Private Sub RestoreOrSelectFirstNode()
        If Not String.IsNullOrEmpty(_prevNodePath) Then
            Dim parts = _prevNodePath.Split("|"c)
            Dim found = FindNodeByPath(TreeView1.Nodes, parts, 0)
            If found IsNot Nothing Then
                TreeView1.SelectedNode = found
            ElseIf TreeView1.Nodes.Count > 0 Then
                TreeView1.SelectedNode = TreeView1.Nodes(0)
            End If
        ElseIf TreeView1.Nodes.Count > 0 Then
            TreeView1.SelectedNode = TreeView1.Nodes(0)
        End If

        If TreeView1.SelectedNode IsNot Nothing Then
            TreeView1.SelectedNode.EnsureVisible()
            TreeView1.Focus()
            TreeView1_AfterSelect(TreeView1, New TreeViewEventArgs(TreeView1.SelectedNode))
        End If
    End Sub

    ' =========================================================================
    '  TREEVIEW — AFTER-SELECT  (async DB fetch → grid)
    ' =========================================================================

    Private Async Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) _
        Handles TreeView1.AfterSelect

        ' Persist checked state of previous node
        SaveCheckedStateForPath(_prevNodePath)

        Dim entryby As String = ""
        Dim route As String = ""
        Dim typeList As List(Of String) = Nothing
        Dim dateNodeRef As TreeNode = Nothing
        Dim node = e.Node

        DecodeNodeFilters(node, entryby, route, typeList, dateNodeRef)

        ' Build date parameter
        Dim dateParam As Object = DBNull.Value
        If dateNodeRef IsNot Nothing Then
            If TypeOf dateNodeRef.Tag Is DateTime Then
                dateParam = CType(dateNodeRef.Tag, DateTime)
            Else
                Dim dtCandidate As DateTime
                If DateTime.TryParseExact(dateNodeRef.Text, "dd-MMM-yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, dtCandidate) OrElse
                   DateTime.TryParse(dateNodeRef.Text, CultureInfo.CurrentCulture,
                        DateTimeStyles.None, dtCandidate) Then
                    dateParam = dtCandidate
                End If
            End If
        End If

        Dim entryParam As Object = If(String.IsNullOrEmpty(entryby), DBNull.Value, CObj(entryby))
        Dim routeParam As Object = If(String.IsNullOrEmpty(route), DBNull.Value, CObj(route))

        ' Build type filter clause
        Dim typeInClause As String
        If typeList IsNot Nothing Then
            typeInClause = "AND L.type IN (" &
                String.Join(",", typeList.Select(Function(t, i) "@type" & i)) & ")"
        Else
            typeInClause = "AND (@type IS NULL OR L.type = @type)"
        End If

        Dim query As String = "
            SELECT
                L.[date],
                FORMAT(L.EntryDateTime, 'HH:mm')                               AS EntryTime,
                L.Type,
                L.doc,
                L.[acid],
                a.Subsidary                                                     AS Title,
                (
                    SELECT TOP 1 c.Subsidary
                    FROM ledgers l2
                    JOIN coa c ON l2.acid = c.id
                    WHERE l2.doc  = L.doc
                      AND l2.type = L.type
                      AND l2.acid <> L.acid
                )                                                               AS SecondTitle,
                (SELECT Route FROM coa WHERE id = L.acid)                       AS Route,
                L.Narration,
                CASE WHEN L.type IN ('CRV','BRV') THEN  L.[credit]
                     WHEN L.type = 'CPV'          THEN  L.debit * -1
                     ELSE 0
                END                                                             AS Amount,
                CASE WHEN (
                        SELECT top 1 DATALENGTH(im.image)
                        FROM   images.dbo.name_reciepts im
                        WHERE  im.type = L.type
                          AND  im.doc  = L.doc
                    ) > 0
                     THEN 'Yes' ELSE 'No'
                END                                                             AS HasImage
            FROM ledgers L
            JOIN coa a ON L.acid = a.id
            WHERE L.receiptstatus IS NULL
              AND CASE WHEN L.type IN ('CRV','BRV') THEN L.[credit]
                       WHEN L.type = 'CPV'          THEN L.debit
                       ELSE 0 END > 0
              AND (@entryby IS NULL OR L.entryby = @entryby)
              AND (@date    IS NULL OR CONVERT(date, L.[date]) = @date)
              " & typeInClause & "
              AND (@route   IS NULL OR (SELECT Route FROM coa WHERE id = L.acid) = @route)
            ORDER BY HasImage DESC, [date] DESC, [type] DESC, EntrydateTime DESC"

        Dim dt As DataTable = Await Task.Run(Function()
                                                 Dim localDt As New DataTable()
                                                 Using conn As New SqlConnection(ConnStr)
                                                     conn.Open()
                                                     Using cmd As New SqlCommand(query, conn)
                                                         cmd.Parameters.AddWithValue("@entryby", entryParam)
                                                         cmd.Parameters.AddWithValue("@date", dateParam)
                                                         cmd.Parameters.AddWithValue("@route", routeParam)

                                                         If typeList IsNot Nothing Then
                                                             For i = 0 To typeList.Count - 1
                                                                 cmd.Parameters.AddWithValue("@type" & i, typeList(i))
                                                             Next
                                                         Else
                                                             Dim typeParam As Object = DBNull.Value
                                                             If node IsNot Nothing AndAlso Not String.IsNullOrEmpty(node.Text) Then
                                                                 typeParam = CObj(node.Text)
                                                             End If
                                                             cmd.Parameters.AddWithValue("@type", typeParam)
                                                         End If

                                                         Using adapter As New SqlDataAdapter(cmd)
                                                             adapter.Fill(localDt)
                                                         End Using
                                                     End Using
                                                 End Using
                                                 Return localDt
                                             End Function)

        SetupAndBindGrid(dt)

        ' Restore checkbox state for the newly selected node
        Dim currPath = GetNodePath(node)
        If _nodeCheckedState.ContainsKey(currPath) Then
            Dim checkedSet = _nodeCheckedState(currPath)
            For Each r As DataGridViewRow In dgvRecovery.Rows
                r.Cells("Select").Value = checkedSet.Contains(RowKey(r))
            Next
        End If

        CalculateTotal()
        _prevNodePath = currPath
    End Sub

    Private Sub DecodeNodeFilters(node As TreeNode,
                                  ByRef entryby As String,
                                  ByRef route As String,
                                  ByRef typeList As List(Of String),
                                  ByRef dateNodeRef As TreeNode)
        ' Walk up to top-level node to resolve type
        Dim topNode = node
        While topNode.Parent IsNot Nothing
            topNode = topNode.Parent
        End While

        Select Case topNode.Text.ToUpper()
            Case "CASH" : typeList = New List(Of String) From {"CRV", "CPV"}
            Case "BANK" : typeList = New List(Of String) From {"BRV"}
            Case Else : typeList = New List(Of String) From {topNode.Text}
        End Select

        If chkDateWise.Checked Then
            ' Layout: Type(0) → Date(1) → EntryBy(2) → Route(3)
            Select Case node.Level
                Case 1
                    dateNodeRef = node
                Case 2
                    dateNodeRef = node.Parent
                    entryby = node.Text
                Case 3
                    dateNodeRef = node.Parent.Parent
                    entryby = node.Parent.Text
                    route = node.Text
            End Select
        Else
            ' Layout: Type(0) → EntryBy(1) → Date(2) → Route(3)
            Select Case node.Level
                Case 1
                    entryby = node.Text
                Case 2
                    entryby = node.Parent.Text
                    dateNodeRef = node
                Case 3
                    entryby = node.Parent.Parent.Text
                    dateNodeRef = node.Parent
                    route = node.Text
            End Select
        End If
    End Sub

    ' =========================================================================
    '  GRID — SETUP & BIND
    ' =========================================================================

    Private Sub SetupAndBindGrid(dt As DataTable)
        dgvRecovery.SuspendLayout()
        Try
            dgvRecovery.AutoGenerateColumns = False

            ' Add Select boolean column
            If Not dt.Columns.Contains("Select") Then
                dt.Columns.Add("Select", GetType(Boolean))
            End If

            ' Default Select values based on type & image availability
            For Each dr As DataRow In dt.Rows
                Dim t As String = dr("Type").ToString()
                Dim img As String = dr("HasImage").ToString()
                dr("Select") = (t = "CRV") OrElse (t = "BRV" AndAlso img = "Yes")
            Next

            ' Add ViewImageText derived column
            If Not dt.Columns.Contains("ViewImageText") Then
                Dim vc As New DataColumn("ViewImageText", GetType(String))
                vc.Expression = "IIF(ISNULL(HasImage,'No') = 'Yes', 'View', 'No Image')"
                dt.Columns.Add(vc)
            End If

            ' Build columns once; reset flag so columns can be rebuilt when form reloads
            If Not _columnsInitialized Then
                dgvRecovery.Columns.Clear()
                dgvRecovery.Columns.AddRange(New DataGridViewColumn() {
                    MakeTextCol("date", "Date", 70),
                    MakeTextCol("Route", "Route", 70),
                    MakeTextCol("EntryTime", "Time", 50),
                    MakeTextCol("Type", "Type", 50),
                    MakeTextCol("doc", "Doc", 60),
                    MakeTextCol("acid", "AcID", 50),
                    MakeTextCol("Title", "Title", 220),
                    MakeTextCol("SecondTitle", "In Account", 220),
                    MakeTextCol("Narration", "Narration", 220),
                    MakeAmountCol(),
                    New DataGridViewCheckBoxColumn() With {
                        .Name = "Select", .HeaderText = "✔ Select",
                        .DataPropertyName = "Select",
                        .ReadOnly = False, .Width = 40},
                    New DataGridViewTextBoxColumn() With {
                        .Name = "HasImage", .HeaderText = "HasImage",
                        .DataPropertyName = "HasImage",
                        .ReadOnly = True, .Visible = False},
                    New DataGridViewButtonColumn() With {
                        .Name = "ViewImage", .HeaderText = "Image",
                        .DataPropertyName = "ViewImageText",
                        .UseColumnTextForButtonValue = False,
                        .ReadOnly = False, .Width = 70}
                })
                dgvRecovery.Columns("Title").DefaultCellStyle.Font = New Font(dgvRecovery.DefaultCellStyle.Font, FontStyle.Bold)
                dgvRecovery.Columns("Title").DefaultCellStyle.BackColor = Color.LightYellow
                dgvRecovery.Columns("amount").DefaultCellStyle.Font = New Font(dgvRecovery.DefaultCellStyle.Font, FontStyle.Bold)
                dgvRecovery.Columns("amount").DefaultCellStyle.BackColor = Color.LightYellow

                AddHandler dgvRecovery.CellFormatting, AddressOf dgvRecovery_CellFormatting
                AddHandler dgvRecovery.CurrentCellDirtyStateChanged, AddressOf dgvRecovery_CurrentCellDirtyStateChanged
                AddHandler dgvRecovery.CellValueChanged, AddressOf dgvRecovery_CellValueChanged
                AddHandler dgvRecovery.CellContentClick, AddressOf dgvRecovery_CellContentClick
                AddHandler dgvRecovery.CellClick, AddressOf dgvRecovery_CellClick

                _columnsInitialized = True
            End If

            _bsRecovery.DataSource = dt
            dgvRecovery.DataSource = _bsRecovery
            dgvRecovery.Refresh()
        Finally
            dgvRecovery.ResumeLayout()
        End Try
    End Sub

    Private Function MakeTextCol(prop As String, header As String,
                                  width As Integer) As DataGridViewTextBoxColumn
        Return New DataGridViewTextBoxColumn() With {
            .Name = prop, .HeaderText = header,
            .DataPropertyName = prop,
            .ReadOnly = True, .Width = width}
    End Function

    Private Function MakeAmountCol() As DataGridViewTextBoxColumn
        Dim col As New DataGridViewTextBoxColumn() With {
            .Name = "Amount", .HeaderText = "Amount",
            .DataPropertyName = "Amount",
            .ReadOnly = True, .Width = 70}
        col.DefaultCellStyle.Format = "N0"
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Return col
    End Function

    ' ── Grid event handlers ───────────────────────────────────────────────────

    Private Sub dgvRecovery_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        If dgvRecovery.Columns(e.ColumnIndex).Name <> "ViewImage" Then Return

        Dim hasImage = CellStr(dgvRecovery.Rows(e.RowIndex).Cells("HasImage").Value)
        If String.Equals(hasImage, "Yes", StringComparison.OrdinalIgnoreCase) Then
            e.CellStyle.BackColor = Color.LightGreen
            e.CellStyle.ForeColor = Color.Black
            e.CellStyle.SelectionBackColor = Color.LightGreen
            e.CellStyle.SelectionForeColor = Color.Black
        Else
            e.CellStyle.BackColor = Color.LightGray
            e.CellStyle.ForeColor = Color.Gray
            e.CellStyle.SelectionBackColor = Color.LightGray
            e.CellStyle.SelectionForeColor = Color.Gray
        End If
    End Sub

    Private Sub dgvRecovery_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
        If dgvRecovery.IsCurrentCellDirty Then
            dgvRecovery.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvRecovery_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso
           dgvRecovery.Columns(e.ColumnIndex).Name = "Select" Then
            CalculateTotal()
        End If
    End Sub

    Private Async Sub dgvRecovery_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso
           dgvRecovery.Columns(e.ColumnIndex).Name = "ViewImage" Then
            Await OpenImageDialogSingleInstanceAsync(e.RowIndex)
        End If
    End Sub

    Private Async Sub dgvRecovery_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso
           dgvRecovery.Columns(e.ColumnIndex).Name = "ViewImage" Then
            Await OpenImageDialogSingleInstanceAsync(e.RowIndex)
        End If
    End Sub

    ' =========================================================================
    '  IMAGE VIEWER
    ' =========================================================================

    Private Async Function OpenImageDialogSingleInstanceAsync(rowIndex As Integer) As Task
        If _isShowingImage Then Return
        Try
            _isShowingImage = True
            Await ShowImageForRowAsync(rowIndex)
        Finally
            _isShowingImage = False
        End Try
    End Function

    Private Async Function ShowImageForRowAsync(rowIndex As Integer) As Task
        If rowIndex < 0 OrElse rowIndex >= dgvRecovery.Rows.Count Then Return

        Dim row = dgvRecovery.Rows(rowIndex)
        Dim hasImage = CellStr(row.Cells("HasImage").Value)
        If Not String.Equals(hasImage, "Yes", StringComparison.OrdinalIgnoreCase) Then Return

        Dim docObj = row.Cells("doc").Value
        Dim docType = CellStr(row.Cells("Type").Value)
        Dim docId As Integer
        If docObj Is Nothing OrElse Not Integer.TryParse(docObj.ToString(), docId) Then Return

        Dim imgBytes As Byte() = Await Task.Run(Function()
                                                    Using conn As New SqlConnection(ConnStr)
                                                        Using cmd As New SqlCommand(
                                                            "SELECT im.image FROM images.dbo.name_reciepts im " &
                                                            "WHERE im.[type] = @type AND im.doc = @doc", conn)
                                                            cmd.Parameters.AddWithValue("@type", docType)
                                                            cmd.Parameters.AddWithValue("@doc", docId)
                                                            conn.Open()
                                                            Dim result = cmd.ExecuteScalar()
                                                            If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
                                                                Return CType(result, Byte())
                                                            End If
                                                        End Using
                                                    End Using
                                                    Return Nothing
                                                End Function)

        If imgBytes Is Nothing OrElse imgBytes.Length = 0 Then
            MessageBox.Show("Image not found.", "Image",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using frm As New frmImageViewer(docId, docType)
            frm.LoadImage(imgBytes)
            frm.ShowDialog(Me)
        End Using
    End Function

    ' =========================================================================
    '  TOTAL CALCULATION
    ' =========================================================================

    Private Sub CalculateTotal()
        Dim total As Decimal = 0D
        For Each row As DataGridViewRow In dgvRecovery.Rows
            If row.Cells("Select").Value IsNot Nothing AndAlso
               Convert.ToBoolean(row.Cells("Select").Value) Then
                Dim amt = row.Cells("Amount").Value
                If amt IsNot Nothing AndAlso amt IsNot DBNull.Value Then
                    total += Convert.ToDecimal(amt)
                End If
            End If
        Next
        txtTotal.Text = total.ToString("N0")
    End Sub

    ' =========================================================================
    '  ACTIONS — UPDATE / DELETE / SELECT-ALL
    ' =========================================================================

    Private Sub UpdateDoc(docTypeGroup As String)
        If frmLogin.UserLevel.ToUpper() <> "ADMIN" Then Return

        Dim typeList = ResolveTypeList(docTypeGroup)
        Dim docIds As New List(Of Integer)()

        For Each r As DataGridViewRow In dgvRecovery.Rows
            If Convert.ToBoolean(r.Cells("Select").Value) AndAlso
               typeList.Contains(r.Cells("Type").Value.ToString()) Then
                docIds.Add(Convert.ToInt32(r.Cells("doc").Value))
            End If
        Next
        If docIds.Count = 0 Then Return

        Dim typeListSql = String.Join(",", typeList.Select(Function(t) "'" & t & "'"))
                Dim docListSql = String.Join(",", docIds)
        Dim sql = "UPDATE ledgers
                   SET NARRATION     = LTRIM(REPLACE(REPLACE(NARRATION, 'PENDING -', ''), 'pending:', '')),
                       receiptStatus = 'Received'
                   WHERE type IN (" & typeListSql & ")
                     AND doc  IN (" & docListSql & ")"

        ExecuteNonQuery(sql)
        txtTotal.Text = "0.00"
        LoadTreeView()
    End Sub

    Private Sub btnCRV_Click(sender As Object, e As EventArgs) Handles btnCRV.Click
        ConfirmAndUpdate("CASH", btnCRV)
    End Sub

    Private Sub btnBRV_Click(sender As Object, e As EventArgs) Handles btnBRV.Click
        ConfirmAndUpdate("BANK", btnBRV)
    End Sub

    Private Sub ConfirmAndUpdate(group As String, btn As Button)
        If frmLogin.UserLevel.ToUpper() <> "ADMIN" Then Return
        Timer1.Enabled = False
        btn.Enabled = False
        If MessageBox.Show("This will confirm selected entries in ledgers. Are you sure?",
                           "Confirm Receipt", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Warning,
                           MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            UpdateDoc(group)
        End If
        btn.Enabled = True
        Timer1.Enabled = chkAutoUpdate.Checked
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Dim allSelected = dgvRecovery.Rows.Cast(Of DataGridViewRow)() _
                              .All(Function(r) Convert.ToBoolean(r.Cells("Select").Value))
        For Each r As DataGridViewRow In dgvRecovery.Rows
            r.Cells("Select").Value = Not allSelected
        Next
        CalculateTotal()
    End Sub

    ''' <summary>Toggle: select only rows that have an image, deselect the rest.</summary>
    Private Sub btnToggle_Click(sender As Object, e As EventArgs) 'Handles btnToggle.Click
        For Each r As DataGridViewRow In dgvRecovery.Rows
            Dim hasImg As String = If(r.Cells("HasImage").Value IsNot Nothing,
                                      r.Cells("HasImage").Value.ToString(), "")
            r.Cells("Select").Value = (hasImg = "Yes")
        Next
        CalculateTotal()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If frmLogin.UserLevel.ToUpper() <> "ADMIN" Then Return
        If MessageBox.Show("This will delete the selected entries from the ledgers. Are you sure?",
                           "Confirm Deletion", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Warning,
                           MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then Return

        Dim pairs As New List(Of Tuple(Of String, Integer))()
        For Each r As DataGridViewRow In dgvRecovery.Rows
            If Convert.ToBoolean(r.Cells("Select").Value) Then
                pairs.Add(Tuple.Create(r.Cells("Type").Value.ToString(),
                                       Convert.ToInt32(r.Cells("doc").Value)))
            End If
        Next
        If pairs.Count = 0 Then Return

        Dim conditions As New List(Of String)()
        Dim parameters As New List(Of SqlParameter)()
        For i = 0 To pairs.Count - 1
            conditions.Add($"(type = @type{i} AND doc = @doc{i})")
            parameters.Add(New SqlParameter($"@type{i}", pairs(i).Item1))
            parameters.Add(New SqlParameter($"@doc{i}", pairs(i).Item2))
        Next
        ExecuteNonQuery("DELETE FROM ledgers WHERE " & String.Join(" OR ", conditions), parameters)

        txtTotal.Text = "0.00"
        LoadTreeView()
    End Sub

    ' =========================================================================
    '  REFRESH BUTTON
    ' =========================================================================

    Private Sub brnRefresh_Click(sender As Object, e As EventArgs) Handles brnRefresh.Click
        _prevNodePath = If(TreeView1.SelectedNode IsNot Nothing,
                           GetNodePath(TreeView1.SelectedNode), String.Empty)
        LoadTreeView()
    End Sub

    ' =========================================================================
    '  TIMER — AUTO-UPDATE + WHATSAPP SENDER
    ' =========================================================================

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Capture selected tree-node path and checked grid rows before refresh
        Dim selectedPath = If(TreeView1.SelectedNode IsNot Nothing,
                              GetNodePath(TreeView1.SelectedNode), String.Empty)

        Dim checkedDocs As New HashSet(Of String)()
        Dim selectedRowKey As String = Nothing

        For Each r As DataGridViewRow In dgvRecovery.Rows
            If r.Cells("Select").Value IsNot Nothing AndAlso
               Convert.ToBoolean(r.Cells("Select").Value) Then
                checkedDocs.Add(RowKey(r))
            End If
        Next
        If dgvRecovery.CurrentRow IsNot Nothing Then
            selectedRowKey = RowKey(dgvRecovery.CurrentRow)
        End If

        ' Rebuild tree
        Dim rows = FetchTreeRowsFromDb()
        BuildTreeFromRows(rows)

        ' Restore selected tree node
        If Not String.IsNullOrEmpty(selectedPath) Then
            Dim found = FindNodeByPath(TreeView1.Nodes, selectedPath.Split("|"c), 0)
            If found IsNot Nothing Then
                TreeView1.SelectedNode = found
                TreeView1.Select()
            End If
        End If

        ' Restore grid checked / selected state
        For Each r As DataGridViewRow In dgvRecovery.Rows
            Dim key = RowKey(r)
            r.Cells("Select").Value = checkedDocs.Contains(key)
            If selectedRowKey IsNot Nothing AndAlso key = selectedRowKey Then
                r.Selected = True
                dgvRecovery.CurrentCell = r.Cells(0)
            End If
        Next

        ' ── WhatsApp notifications for new unsent receipts ────────────────────
        Dim dt As DataTable = SQLData(
            "SELECT l.date, l.type, l.doc, l.acid, a.subsidary, a.ocell,
                    l.credit, l.narration, l.entryby, l.entrydatetime
             FROM   ledgers l
             JOIN   coa a ON l.acid = a.id
             WHERE  l.whatsappstatus IS NULL
               AND  l.credit > 0
               AND  l.type IN ('CRV','BRV')")

        If dt.Rows.Count = 0 Then Return

        Timer1.Enabled = False
        Dim typeDocPairs As New List(Of Tuple(Of String, Integer))()

        For Each row As DataRow In dt.Rows
            Dim receiptDate = Convert.ToDateTime(row("date")).ToString("dd-MMM-yyyy")
            Dim entryTime = Convert.ToDateTime(row("entrydatetime")).ToString("HH:mm")
            Dim customerName = row("subsidary").ToString().Trim()
            Dim mobile = row("ocell").ToString().Trim()
            Dim amount = Convert.ToDecimal(row("credit"))
            Dim narration = row("narration").ToString().Trim()
            Dim entryBy = row("entryby").ToString().Trim()

            ' Normalise mobile to international format (92xxxxxxxxxx)
            Try
                If mobile.StartsWith("0") Then
                    mobile = "92" & mobile.Substring(1).Replace(" ", "")
                End If
            Catch
                ' Leave mobile unchanged if parsing fails
            End Try

            Dim msg = $"*Receipt Date:* {receiptDate},{Environment.NewLine}" &
                      $"*Entry Time:* {entryTime},{Environment.NewLine}" &
                      $"*Customer Name:* {customerName},{Environment.NewLine}" &
                      $"*Mobile:* {mobile},{Environment.NewLine}" &
                      $"*Amount:* {amount:N0},{Environment.NewLine}" &
                      $"*Narration:* {narration},{Environment.NewLine}" &
                      $"*Entry By:* {entryBy}"

            WASender.StartWhatsAppSession()
            WASender.SendMessage(mobile, msg)
            typeDocPairs.Add(Tuple.Create(row("type").ToString(),
                                          Convert.ToInt32(row("doc"))))
        Next

        If typeDocPairs.Count > 0 Then
            Dim conditions As New List(Of String)()
            Dim parameters As New List(Of SqlParameter)()
            For i = 0 To typeDocPairs.Count - 1
                conditions.Add($"(type = @type{i} AND doc = @doc{i})")
                parameters.Add(New SqlParameter($"@type{i}", typeDocPairs(i).Item1))
                parameters.Add(New SqlParameter($"@doc{i}", typeDocPairs(i).Item2))
            Next
            ExecuteNonQuery("UPDATE ledgers SET whatsappStatus = 'Sent' WHERE " &
                            String.Join(" OR ", conditions), parameters)
        End If

        Timer1.Enabled = chkAutoUpdate.Checked
    End Sub

    ' =========================================================================
    '  MISC UI EVENTS
    ' =========================================================================

    Private Sub chkAutoUpdate_CheckedChanged(sender As Object, e As EventArgs) _
        Handles chkAutoUpdate.CheckedChanged
        Timer1.Enabled = chkAutoUpdate.Checked
    End Sub

    Private Sub chkDateWise_CheckedChanged(sender As Object, e As EventArgs) _
        Handles chkDateWise.CheckedChanged
        TreeView1.DrawMode = TreeViewDrawMode.Normal
        LoadTreeView()
    End Sub

    Private Sub ctnClose_Click(sender As Object, e As EventArgs) Handles ctnClose.Click
        Me.Close()
    End Sub

    ''' <summary>F2 = show date-change controls; F3 = show amount-change controls.</summary>
    Private Sub dgvRecovery_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles dgvRecovery.KeyDown, TreeView1.KeyDown

        Select Case e.KeyCode
            Case Keys.F2
                e.Handled = True
                lblDateChange.Visible = True
                dtpDateChange.Visible = True
                dtpDateChange.Focus()
            Case Keys.F3
                e.Handled = True
                lblAmountChange.Visible = True
                txtAmountChgange.Visible = True
                txtAmountChgange.SelectAll()
                txtAmountChgange.Focus()
        End Select
    End Sub

    Private Sub dtpDateChange_Leave(sender As Object, e As EventArgs) Handles dtpDateChange.Leave
        Dim frm As New frmChoice()
        frm.SetOptions(
            $"This will change the date of the selected entry to " &
            $"{dtpDateChange.Value:dd-MMM-yyyy}. Are you sure?",
            "Selected Entry",
            "All Entries")

        If frm.ShowDialog() = DialogResult.OK Then
            If frm.SelectedOption = "Selected Entry" Then
                If dgvRecovery.CurrentRow Is Nothing Then GoTo Cleanup
                Dim docId = Convert.ToInt32(dgvRecovery.CurrentRow.Cells("doc").Value)
                Dim docType = dgvRecovery.CurrentRow.Cells("Type").Value.ToString()
                ExecuteNonQuery(
                    "UPDATE ledgers SET [date] = @date WHERE doc = @doc AND type = @type",
                    New List(Of SqlParameter) From {
                        New SqlParameter("@date", dtpDateChange.Value.Date),
                        New SqlParameter("@doc", docId),
                        New SqlParameter("@type", docType)
                    })

            ElseIf frm.SelectedOption = "All Entries" Then
                For i = 0 To dgvRecovery.Rows.Count - 1
                    Dim docId = Convert.ToInt32(dgvRecovery.Rows(i).Cells("doc").Value)
                    Dim docType = dgvRecovery.Rows(i).Cells("Type").Value.ToString()
                    ExecuteNonQuery(
                        "UPDATE ledgers SET [date] = @date WHERE doc = @doc AND type = @type",
                        New List(Of SqlParameter) From {
                            New SqlParameter("@date", dtpDateChange.Value.Date),
                            New SqlParameter("@doc", docId),
                            New SqlParameter("@type", docType)
                        })
                Next
                MessageBox.Show("All Entries Updated")
            End If
        Else
            MessageBox.Show("Cancelled")
        End If

Cleanup:
        lblDateChange.Visible = False
        dtpDateChange.Visible = False
        LoadTreeView()
    End Sub

    ' =========================================================================
    '  AMOUNT CHANGE
    ' =========================================================================

    Private Sub txtAmountChgange_Leave(sender As Object, e As EventArgs) _
        Handles txtAmountChgange.Leave

        If String.IsNullOrWhiteSpace(txtAmountChgange.Text) Then
            HideAmountControls()
            Return
        End If

        If dgvRecovery.CurrentRow Is Nothing Then
            HideAmountControls()
            Return
        End If

        Dim docId = Convert.ToInt32(dgvRecovery.CurrentRow.Cells("doc").Value)
        Dim docType = dgvRecovery.CurrentRow.Cells("Type").Value.ToString()
        Dim cleanText = txtAmountChgange.Text.Replace(",", "").Trim()
        Dim newAmount As Decimal

        If Not Decimal.TryParse(cleanText, newAmount) Then
            MessageBox.Show("Invalid amount entered.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            HideAmountControls()
            Return
        End If

        If MessageBox.Show(
                "This will change the amount of voucher " & docType & " " &
                docId.ToString() & " to " & newAmount.ToString("N0") & ". Are you sure?",
                "Confirm Amount Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then
            HideAmountControls()
            Return
        End If

        ExecuteNonQuery(
            "UPDATE ledgers SET credit = @NewAmount WHERE doc = @doc AND type = @type AND credit <> 0;" &
            "UPDATE ledgers SET debit  = @NewAmount WHERE doc = @doc AND type = @type AND debit  <> 0",
            New List(Of SqlParameter) From {
                New SqlParameter("@NewAmount", newAmount),
                New SqlParameter("@doc", docId),
                New SqlParameter("@type", docType)
            })

        LoadTreeView()
        HideAmountControls()
    End Sub

    Private Sub HideAmountControls()
        lblAmountChange.Visible = False
        txtAmountChgange.Visible = False
        dgvRecovery.Select()
    End Sub

    Private Sub txtAmountChgange_TextChanged(sender As Object, e As EventArgs) _
        Handles txtAmountChgange.TextChanged

        RemoveHandler txtAmountChgange.TextChanged, AddressOf txtAmountChgange_TextChanged

        Dim cursorPos As Integer = txtAmountChgange.SelectionStart
        Dim originalLength As Integer = txtAmountChgange.Text.Length
        Dim cleanText As String = txtAmountChgange.Text.Replace(",", "")

        If IsNumeric(cleanText) AndAlso cleanText <> "" Then
            Dim number As Long = CLng(cleanText)
            txtAmountChgange.Text = number.ToString("N0")
            Dim newLength As Integer = txtAmountChgange.Text.Length
            cursorPos += (newLength - originalLength)
            txtAmountChgange.SelectionStart = Math.Max(0, cursorPos)
        End If

        AddHandler txtAmountChgange.TextChanged, AddressOf txtAmountChgange_TextChanged
    End Sub

    ' =========================================================================
    '  PRIVATE HELPERS
    ' =========================================================================

    ''' <summary>Saves checkbox state for the specified node path.</summary>
    Private Sub SaveCheckedStateForPath(path As String)
        If String.IsNullOrEmpty(path) Then Return
        Dim checked As New HashSet(Of String)()
        For Each r As DataGridViewRow In dgvRecovery.Rows
            If r.Cells("Select").Value IsNot Nothing AndAlso
               Convert.ToBoolean(r.Cells("Select").Value) Then
                checked.Add(RowKey(r))
            End If
        Next
        _nodeCheckedState(path) = checked
    End Sub

    Private Function ResolveTypeList(group As String) As List(Of String)
        Select Case group.ToUpper()
            Case "CASH" : Return New List(Of String) From {"CRV", "CPV"}
            Case "BANK" : Return New List(Of String) From {"BRV"}
            Case Else : Return New List(Of String) From {group}
        End Select
    End Function

    ''' <summary>Unique key for a grid row: Type|doc</summary>
    Private Function RowKey(r As DataGridViewRow) As String
        Return r.Cells("Type").Value.ToString() & "|" & r.Cells("doc").Value.ToString()
    End Function

    Private Function DefaultIfBlank(value As String, fallback As String) As String
        Return If(String.IsNullOrWhiteSpace(value), fallback, value)
    End Function

    Private Function NullStr(value As Object) As String
        Return If(value Is DBNull.Value OrElse value Is Nothing,
                  String.Empty, value.ToString().Trim())
    End Function

    Private Function CellStr(value As Object) As String
        Return If(value Is Nothing OrElse value Is DBNull.Value,
                  String.Empty, value.ToString())
    End Function

    ''' <summary>Execute a parameterised non-query SQL statement.</summary>
    Private Sub ExecuteNonQuery(sql As String,
                                Optional parameters As List(Of SqlParameter) = Nothing)
        Using conn As New SqlConnection(ConnStr)
            Using cmd As New SqlCommand(sql, conn)
                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters.ToArray())
                End If
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class
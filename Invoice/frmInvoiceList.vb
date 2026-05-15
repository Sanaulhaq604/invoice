Imports System.Net.Mail
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

' ═══════════════════════════════════════════════════════════════
'  THEME PALETTE  — single source of truth for all colours
' ═══════════════════════════════════════════════════════════════
Module AppTheme
    ' Backgrounds
    Public ReadOnly BgForm As Color = Color.FromArgb(245, 246, 250)
    Public ReadOnly BgPanel As Color = Color.FromArgb(255, 255, 255)
    Public ReadOnly BgCard As Color = Color.FromArgb(255, 255, 255)
    Public ReadOnly BgInput As Color = Color.FromArgb(255, 255, 255)

    ' Grid
    Public ReadOnly GridHeader As Color = Color.FromArgb(220, 225, 235)
    Public ReadOnly GridRowAlt As Color = Color.FromArgb(250, 251, 253)
    Public ReadOnly GridRow As Color = Color.FromArgb(255, 255, 255)
    Public ReadOnly GridSel As Color = Color.FromArgb(0, 120, 212)
    Public ReadOnly GridLine As Color = Color.FromArgb(210, 215, 225)

    ' Accent
    Public ReadOnly Accent As Color = Color.FromArgb(0, 120, 212)
    Public ReadOnly AccentHot As Color = Color.FromArgb(0, 168, 255)
    Public ReadOnly AccentDim As Color = Color.FromArgb(0, 90, 140)

    ' Text
    Public ReadOnly TextPrimary As Color = Color.FromArgb(30, 30, 30)
    Public ReadOnly TextSecondary As Color = Color.FromArgb(100, 100, 100)
    Public ReadOnly TextLabel As Color = Color.FromArgb(0, 120, 212)

    ' Fonts
    Public ReadOnly FontUI As New Font("Segoe UI", 9.0F)
    Public ReadOnly FontUISB As New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
    Public ReadOnly FontHeader As New Font("Segoe UI", 8.0F, FontStyle.Bold)
    Public ReadOnly FontSmall As New Font("Segoe UI", 8.0F)
    Public ReadOnly FontTitle As New Font("Segoe UI Light", 11.0F)
    Public ReadOnly FontStat As New Font("Segoe UI", 9.5F, FontStyle.Bold)
End Module

' ═══════════════════════════════════════════════════════════════
'  MAIN FORM
' ═══════════════════════════════════════════════════════════════
Public Class frmInvoiceList
    Dim RowIndex As Integer = 0
    Public Property InvNumber As String = ""

    ' ── Shared rounded-rect path builder ────────────────────────
    Private Function BuildRoundRect(r As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim d As Integer = radius * 2
        path.AddArc(r.X, r.Y, d, d, 180, 90)
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90)
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90)
        path.AddArc(r.X, r.Bottom - d, d, d, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    ' ════════════════════════════════════════════════════════════
    '  FORM LOAD
    ' ════════════════════════════════════════════════════════════
    Private Sub frmInvoiceList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyUITheme()

        Dim dt As DataTable = SQLData("select distinct UserName from psproducthistory")
        If dt.Rows.Count > 0 Then
            cmbUser.Items.Clear()
            For n = 0 To dt.Rows.Count - 1
                cmbUser.Items.Add(dt.Rows(n)("UserName"))
            Next
        End If

        RowIndex = 0
        lblDoc.Text = "Invoice List  ·  " & frmLogin.MySqlServer &
                      "  ·  " & frmLogin.UserLevel & "  ·  " & frmLogin.UserName

        ApplyUserLevelVisibility()
        InvList()
        AddImageButtonColumn()

        txtCustomer.SelectAll()
        txtCustomer.Select()
    End Sub

    ' ════════════════════════════════════════════════════════════
    '  UI THEME
    ' ════════════════════════════════════════════════════════════
    Private Sub ApplyUITheme()
        Me.BackColor = AppTheme.BgForm
        Me.ForeColor = AppTheme.TextPrimary
        Me.Font = AppTheme.FontUI

        ' Title
        lblDoc.ForeColor = AppTheme.Accent
        lblDoc.Font = AppTheme.FontTitle
        lblDoc.BackColor = Color.Transparent

        ' Walk all controls recursively
        StyleControlTree(Me)

        ' DataGridView dark skin
        With DGVList
            .BackgroundColor = AppTheme.BgForm
            .GridColor = AppTheme.GridLine
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .EnableHeadersVisualStyles = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .RowTemplate.Height = 34
            .ColumnHeadersHeight = 38
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        End With
        With DGVList.ColumnHeadersDefaultCellStyle
            .BackColor = AppTheme.GridHeader
            .ForeColor = AppTheme.TextLabel
            .Font = AppTheme.FontHeader
            .Padding = New Padding(6, 0, 0, 0)
        End With
        With DGVList.DefaultCellStyle
            .BackColor = AppTheme.GridRow
            .ForeColor = AppTheme.TextPrimary
            .Font = AppTheme.FontUI
            .SelectionBackColor = AppTheme.GridSel
            .SelectionForeColor = Color.White
            .Padding = New Padding(6, 0, 0, 0)
        End With
        With DGVList.AlternatingRowsDefaultCellStyle
            .BackColor = AppTheme.GridRowAlt
            .ForeColor = AppTheme.TextPrimary
            .SelectionBackColor = AppTheme.GridSel
            .SelectionForeColor = Color.White
        End With

        ' DateTimePickers
        StyleDatePicker(DTPStart)
        StyleDatePicker(DTPEnd)

        ' Stat boxes (read-only accent-colored)
        For Each tb As TextBox In GetAllControls(Of TextBox)(Me)
            Dim name As String = tb.Name.ToLower()
            If name.StartsWith("txt") AndAlso
               Not name.Contains("customer") AndAlso
               Not name.Contains("route") AndAlso
               Not name.Contains("description") AndAlso
               Not name.Contains("smserver") AndAlso
               Not name.Contains("delay") Then
                tb.BackColor = AppTheme.BgCard
                tb.ForeColor = AppTheme.Accent
                tb.Font = AppTheme.FontStat
                tb.BorderStyle = BorderStyle.None
                tb.ReadOnly = True
                tb.TextAlign = HorizontalAlignment.Right
            Else
                tb.BackColor = AppTheme.BgInput
                tb.ForeColor = AppTheme.TextPrimary
                tb.Font = AppTheme.FontUI
                tb.BorderStyle = BorderStyle.FixedSingle
            End If
        Next

        ' ComboBox
        cmbUser.BackColor = AppTheme.BgInput
        cmbUser.ForeColor = AppTheme.TextPrimary
        cmbUser.FlatStyle = FlatStyle.Flat
        cmbUser.Font = AppTheme.FontUI

        ' CheckBoxes
        For Each cb As CheckBox In GetAllControls(Of CheckBox)(Me)
            cb.ForeColor = AppTheme.TextPrimary
            cb.BackColor = Color.Transparent
            cb.Font = AppTheme.FontUI
        Next

        ' Labels
        For Each lbl As Label In GetAllControls(Of Label)(Me)
            If lbl.Name <> "lblDoc" Then
                lbl.ForeColor = AppTheme.TextSecondary
                lbl.BackColor = Color.Transparent
                lbl.Font = AppTheme.FontUI
            End If
        Next

        ' Buttons
        For Each btn As Button In GetAllControls(Of Button)(Me)
            btn.FlatStyle = FlatStyle.Flat
            btn.BackColor = AppTheme.BgCard
            btn.ForeColor = AppTheme.TextPrimary
            btn.Font = AppTheme.FontUISB
            btn.FlatAppearance.BorderColor = AppTheme.AccentDim
            btn.FlatAppearance.BorderSize = 1
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 0, 168, 255)
            btn.Cursor = Cursors.Hand
        Next
        ' Specific accent colours for key buttons
        AccentBtn(btnExport, Color.FromArgb(0, 168, 255))
        AccentBtn(BtnPrint, Color.FromArgb(0, 200, 120))
        AccentBtn(btnExportSelected, Color.FromArgb(0, 120, 200))
        AccentBtn(btnPrintSelected, Color.FromArgb(200, 140, 0))
        AccentBtn(btnExit, Color.FromArgb(210, 50, 50))
        AccentBtn(Button1, Color.FromArgb(0, 160, 210))   ' mail button
    End Sub

    Private Sub AccentBtn(btn As Button, c As Color)
        If btn Is Nothing Then Return
        btn.BackColor = Color.FromArgb(25, c.R, c.G, c.B)
        btn.ForeColor = c
        btn.FlatAppearance.BorderColor = Color.FromArgb(100, c.R, c.G, c.B)
        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, c.R, c.G, c.B)
    End Sub

    Private Sub StyleControlTree(parent As Control)
        For Each ctrl As Control In parent.Controls
            Select Case True
                Case TypeOf ctrl Is Panel
                    ctrl.BackColor = AppTheme.BgPanel
                Case TypeOf ctrl Is GroupBox
                    ctrl.ForeColor = AppTheme.TextLabel
                    ctrl.BackColor = AppTheme.BgPanel
            End Select
            StyleControlTree(ctrl)
        Next
    End Sub

    Private Sub StyleDatePicker(dtp As DateTimePicker)
        dtp.CalendarForeColor = AppTheme.TextPrimary
        dtp.CalendarMonthBackground = AppTheme.BgCard
        dtp.CalendarTitleBackColor = AppTheme.GridHeader
        dtp.CalendarTitleForeColor = AppTheme.Accent
        dtp.CalendarTrailingForeColor = AppTheme.TextSecondary
        dtp.Font = AppTheme.FontUI
    End Sub

    Private Function GetAllControls(Of T As Control)(parent As Control) As IEnumerable(Of T)
        Dim result As New List(Of T)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is T Then result.Add(CType(ctrl, T))
            result.AddRange(GetAllControls(Of T)(ctrl))
        Next
        Return result
    End Function

    ' ════════════════════════════════════════════════════════════
    '  USER LEVEL VISIBILITY
    ' ════════════════════════════════════════════════════════════
    Private Sub ApplyUserLevelVisibility()
        If frmLogin.UserLevel.ToUpper <> "OPERATOR" Then
            txtTotal.Visible = True
            txtFreightTotal.Visible = True
            txtMonthlyFreightTotal.Visible = True
            txtMonthlyTotal.Visible = True
            txtAvgDailyProfit.Visible = True
            lblTotals.Visible = True
            lblMonthlyTotals.Visible = True

            If frmLogin.UserLevel.ToUpper = "ADMIN" Then
                DGVList.Columns("colGProfit").Visible = True
                txtTotalProfit.Visible = True
                txtProfitP.Visible = True
                DGVList.Columns("colProfitP").Visible = True
                txtMonthlyProfitP.Visible = True
                txtMonthlyProfitTotal.Visible = True
                txtMonthlyEstimatedTotal.Visible = True
                Me.DGVList.Width = 1490 : Me.Width = 1520
            Else
                DGVList.Columns("colGProfit").Visible = False
                txtTotalProfit.Visible = False : txtProfitP.Visible = False
                DGVList.Columns("colProfitP").Visible = False
                txtMonthlyProfitP.Visible = False : txtMonthlyProfitTotal.Visible = False
                txtMonthlyEstimatedTotal.Visible = False : txtAvgDailyProfit.Visible = False
                Me.DGVList.Width = 1350 : Me.Width = 1370
            End If
        Else
            txtTotal.Visible = False : txtFreightTotal.Visible = False
            DGVList.Columns("colGProfit").Visible = False
            txtTotalProfit.Visible = False : txtProfitP.Visible = False
            DGVList.Columns("colProfitP").Visible = False
            txtMonthlyFreightTotal.Visible = False : txtMonthlyProfitP.Visible = False
            txtMonthlyProfitTotal.Visible = False : txtMonthlyTotal.Visible = False
            txtMonthlyEstimatedTotal.Visible = False : lblTotals.Visible = False
            lblMonthlyTotals.Visible = False : txtAvgDailyProfit.Visible = False
            Me.DGVList.Width = 1230 : Me.Width = 1280
        End If
        Me.CenterToScreen()
    End Sub

    ' ════════════════════════════════════════════════════════════
    '  IMAGE BUTTON COLUMN
    ' ════════════════════════════════════════════════════════════

    ''' <summary>Hides raw HasImage column, adds painted button column once.</summary>
    Private Sub AddImageButtonColumn()
        If DGVList.Columns.Contains("HasImage") Then
            DGVList.Columns("HasImage").Visible = False
        End If
        If Not DGVList.Columns.Contains("colImageBtn") Then
            Dim btnCol As New DataGridViewButtonColumn() With {
                .Name = "colImageBtn",
                .HeaderText = "Image",
                .Width = 115,
                .FlatStyle = FlatStyle.Flat
            }
            DGVList.Columns.Add(btnCol)
        End If
    End Sub

    ' ── Custom cell painter — draws the glowing pill button ─────
    Private Sub DGVList_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) _
        Handles DGVList.CellPainting

        If e.RowIndex < 0 Then Return
        If Not DGVList.Columns.Contains("colImageBtn") Then Return
        If e.ColumnIndex < 0 OrElse DGVList.Columns(e.ColumnIndex).Name <> "colImageBtn" Then Return

        e.Handled = True
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit

        ' ── Row background ───────────────────────────────────────
        Dim bg As Color = If((e.State And DataGridViewElementStates.Selected) <> 0,
                             AppTheme.GridSel,
                             If(e.RowIndex Mod 2 = 0, AppTheme.GridRow, AppTheme.GridRowAlt))
        Using br As New SolidBrush(bg)
            g.FillRectangle(br, e.CellBounds)
        End Using
        ' Bottom separator line
        Using lp As New Pen(AppTheme.GridLine, 1)
            g.DrawLine(lp, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                       e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
        End Using

        ' ── Read HasImage ────────────────────────────────────────
        Dim hasImg As String = ""
        If DGVList.Columns.Contains("HasImage") Then
            Dim raw As Object = DGVList.Rows(e.RowIndex).Cells("HasImage").Value
            If raw IsNot Nothing Then hasImg = raw.ToString().ToUpper()
        End If

        ' ── Button rectangle (inset) ─────────────────────────────
        Dim bRect As New Rectangle(
            e.CellBounds.X + 8,
            e.CellBounds.Y + 6,
            e.CellBounds.Width - 16,
            e.CellBounds.Height - 12)

        If hasImg = "YES" Then
            DrawViewImagePill(g, bRect)
        Else
            DrawNoImagePill(g, bRect)
        End If
    End Sub

    ''' <summary>Draws the glowing "View Image" pill with camera icon.</summary>
    Private Sub DrawViewImagePill(g As Graphics, bRect As Rectangle)
        ' Outer ambient glow
        Dim glow As New Rectangle(bRect.X - 5, bRect.Y - 4, bRect.Width + 10, bRect.Height + 8)
        Using glowBrush As New LinearGradientBrush(
            glow,
            Color.FromArgb(45, 0, 190, 255),
            Color.Transparent,
            LinearGradientMode.Vertical)
            Using glowPath As GraphicsPath = BuildRoundRect(glow, 12)
                g.FillPath(glowBrush, glowPath)
            End Using
        End Using

        ' Main pill gradient fill
        Using path As GraphicsPath = BuildRoundRect(bRect, 9)
            Using fill As New LinearGradientBrush(
                bRect,
                Color.FromArgb(255, 0, 170, 250),
                Color.FromArgb(220, 0, 100, 195),
                LinearGradientMode.Vertical)
                g.FillPath(fill, path)
            End Using

            ' Inner top-highlight sheen
            Dim sheen As New Rectangle(bRect.X + 3, bRect.Y + 2,
                                       bRect.Width - 6, (bRect.Height \ 2) - 1)
            If sheen.Width > 0 AndAlso sheen.Height > 0 Then
                Using sheenFill As New LinearGradientBrush(
                    sheen,
                    Color.FromArgb(70, 255, 255, 255),
                    Color.Transparent,
                    LinearGradientMode.Vertical)
                    Using sheenPath As GraphicsPath = BuildRoundRect(sheen, 7)
                        g.FillPath(sheenFill, sheenPath)
                    End Using
                End Using
            End If

            ' Border
            Using border As New Pen(Color.FromArgb(190, 100, 210, 255), 1.2F)
                g.DrawPath(border, path)
            End Using
        End Using

        ' Camera icon (14x11 px)
        Dim ix As Integer = bRect.X + 10
        Dim iy As Integer = bRect.Y + (bRect.Height - 11) \ 2
        Using p As New Pen(Color.White, 1.5F)
            p.LineJoin = LineJoin.Round
            ' Body
            g.DrawRectangle(p, ix, iy + 3, 13, 8)
            ' Lens
            g.DrawEllipse(p, ix + 3, iy + 4, 7, 6)
            ' Flash bump (top notch)
            Dim bump() As Point = {
                New Point(ix + 3, iy + 3),
                New Point(ix + 4, iy + 1),
                New Point(ix + 9, iy + 1),
                New Point(ix + 10, iy + 3)}
            g.DrawLines(p, bump)
        End Using

        ' Label text
        Dim txtRect As New Rectangle(bRect.X + 28, bRect.Y, bRect.Width - 31, bRect.Height)
        Dim sf As New StringFormat() With {
            .Alignment = StringAlignment.Near,
            .LineAlignment = StringAlignment.Center,
            .Trimming = StringTrimming.EllipsisCharacter}
        Using tb As New SolidBrush(Color.White)
            g.DrawString("View Image", AppTheme.FontUISB, tb, txtRect, sf)
        End Using
    End Sub

    ''' <summary>Draws the muted "No Image" pill.</summary>
    Private Sub DrawNoImagePill(g As Graphics, bRect As Rectangle)
        Using path As GraphicsPath = BuildRoundRect(bRect, 9)
            Using fill As New SolidBrush(Color.FromArgb(36, 42, 56))
                g.FillPath(fill, path)
            End Using
            Using border As New Pen(Color.FromArgb(50, 90, 100, 120), 1)
                g.DrawPath(border, path)
            End Using
        End Using
        Dim sf As New StringFormat() With {
            .Alignment = StringAlignment.Center,
            .LineAlignment = StringAlignment.Center}
        Using tb As New SolidBrush(Color.White)
            g.DrawString("No Image", AppTheme.FontSmall, tb, bRect, sf)
        End Using
    End Sub

    ' ── Repaint button cell on hover for subtle pulse ────────────
    Private Sub DGVList_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DGVList.CellMouseEnter
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso
           DGVList.Columns.Contains("colImageBtn") AndAlso
           DGVList.Columns(e.ColumnIndex).Name = "colImageBtn" Then
            DGVList.InvalidateCell(e.ColumnIndex, e.RowIndex)
        End If
    End Sub

    Private Sub DGVList_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DGVList.CellMouseLeave
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso
           DGVList.Columns.Contains("colImageBtn") AndAlso
           DGVList.Columns(e.ColumnIndex).Name = "colImageBtn" Then
            DGVList.InvalidateCell(e.ColumnIndex, e.RowIndex)
        End If
    End Sub

    ' ── Click → open frmImageViewer ─────────────────────────────
    Private Sub DGVList_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DGVList.CellClick
        If e.RowIndex < 0 Then Return
        If Not DGVList.Columns.Contains("colImageBtn") Then Return
        If e.ColumnIndex < 0 OrElse DGVList.Columns(e.ColumnIndex).Name <> "colImageBtn" Then Return

        Dim hasImg As String = ""
        If DGVList.Columns.Contains("HasImage") Then
            Dim raw As Object = DGVList.Rows(e.RowIndex).Cells("HasImage").Value
            If raw IsNot Nothing Then hasImg = raw.ToString().ToUpper()
        End If

        If hasImg <> "YES" Then
            MessageBox.Show("No image is attached to this invoice.",
                            "No Image", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim docId As Integer = CInt(DGVList.Rows(e.RowIndex).Cells("ColDoc").Value)
        Dim imgData As DataTable = SQLData(
            "SELECT image FROM images.dbo.name_reciepts WHERE doc=" & docId & " AND type='sale'")

        If imgData.Rows.Count = 0 OrElse IsDBNull(imgData.Rows(0)("image")) Then
            MessageBox.Show("Image record not found in the database.",
                            "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim viewer As New frmImageViewer(docId, "sale")
        viewer.LoadImage(CType(imgData.Rows(0)("image"), Byte()))
        viewer.Show()
    End Sub

    ' ── Suppress focus rectangle on rows ────────────────────────
    Private Sub DGVList_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) _
        Handles DGVList.RowPrePaint
        e.PaintParts = e.PaintParts And Not DataGridViewPaintParts.Focus
    End Sub

    ' ════════════════════════════════════════════════════════════
    '  FILTER / SEARCH TRIGGERS
    ' ════════════════════════════════════════════════════════════
    Private Sub Filters_TextChanged(sender As Object, e As EventArgs) _
        Handles txtRoute.TextChanged, txtCustomer.TextChanged, txtDescription.TextChanged
        InvList()
    End Sub

    Private Sub DTP_ValueChanged(sender As Object, e As EventArgs) _
        Handles DTPStart.ValueChanged, DTPEnd.ValueChanged
        InvList()
    End Sub

    Private Sub chkALL_CheckedChanged(sender As Object, e As EventArgs) Handles chkALL.CheckedChanged
        If chkALL.Checked Then InvList()
    End Sub

    Private Sub chkInvoices_CheckedChanged(sender As Object, e As EventArgs) Handles chkInvoices.CheckedChanged
        If chkInvoices.Checked Then InvList()
    End Sub

    Private Sub chkEstimates_CheckedChanged(sender As Object, e As EventArgs) Handles chkEstimates.CheckedChanged
        InvList()
    End Sub

    Private Sub cmbUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUser.SelectedIndexChanged
        InvList()
    End Sub

    ' ════════════════════════════════════════════════════════════
    '  MAIN DATA LOAD
    ' ════════════════════════════════════════════════════════════
    Sub InvList()
        Dim FDate As Date = New DateTime(Now.Year, Now.Month, 1)
        Dim thisDay As Integer = Microsoft.VisualBasic.DateAndTime.Day(DTPEnd.Value)
        Dim EDate As Date = New DateTime(Now.Year, Now.Month, 1).AddMonths(1).AddDays(-1)
        Dim TotalDays As Integer = Microsoft.VisualBasic.DateAndTime.Day(EDate)

        Dim InvoiceStatus As String = ""
        If chkInvoices.Checked Then InvoiceStatus = "INVOICE"
        If chkEstimates.Checked Then InvoiceStatus = "ESTIMATE"

        Dim IList As DataTable = SQLData(
            "select * from (
                select ROW_NUMBER() over (order by pd.date,pd.doc) rn,pd.date,pd.doc,
                       a.UrduName,a.Subsidary,a.route,
                       CASE WHEN OCELL2WA='Y' THEN Cell2 ELSE OCell END oCell,
                       pd.description,pd.amount,ISNULL(PD.RECEIVED,0) RECEIVED,
                       isnull(pd.grossprofit,0) grossprofit,
                       round((case when isnull(pd.amount,0)<>0 then round((pd.grossprofit/pd.amount)*100,2) else 0 end),2) PP,
                       abs(isnull(pd.freight,0)) Freight,
                       isnull(pd.remarks,'') remarks,
                       isnull(a.RunsDate,convert(datetime,'01.01.2020',104)) RDate,
                       ISNULL(pd.GOODS,'') GOODS, a.id,
                       isnull((SELECT TOP 1 UserName FROM PSDetailHistory WHERE DOC=PD.DOC AND TYPE=PD.TYPE),'') UserName,
                       case when (select top 1 DATALENGTH(image) from images.dbo.name_reciepts where type=pd.type and doc=pd.doc)>0
                            then 'Yes' else 'No' end HasImage
                from PSDetail pd join coa a on pd.acid=a.id
                where pd.date>='" & DTPStart.Value.ToString("d") & "'
                  and pd.date<='" & DTPEnd.Value.ToString("d") & "'
                  and pd.type='sale'
                  and a.route like '%" & txtRoute.Text & "%'
                  and a.subsidary like '" & txtCustomer.Text & "%'
                  and pd.description like '%" & txtDescription.Text & "%'
                  and (pd.status LIKE '" & InvoiceStatus & "%' or pd.status is null)
            ) x where x.UserName like '%" & cmbUser.Text & "%'")

        Dim DT3 As DataTable = SQLData(
            "select isnull(sum(amount),0) Amount, isnull(sum(freight),0) Freight,
                    isnull(sum(grossprofit),0) GrossProfit
             from psdetail pd join coa a on pd.acid=a.id
             where pd.date>='" & FDate & "' and pd.date<='" & DTPEnd.Value.ToString("d") & "'
               and pd.type='sale'")

        ' Bind
        DGVList.DataSource = IList
        FixColumnOrder()
        ' Always hide the raw HasImage column after rebind
        If DGVList.Columns.Contains("HasImage") Then
            DGVList.Columns("HasImage").Visible = False
        End If

        ' Totals
        Dim TotalSale As Long = 0, TotalRecovery As Long = 0
        Dim TotalProfit As Long = 0, TotalFreight As Long = 0
        For n = 0 To DGVList.Rows.Count - 1
            TotalSale += DGVList.Rows(n).Cells("colamount").Value
            TotalRecovery += DGVList.Rows(n).Cells("colReceived").Value
            TotalFreight += DGVList.Rows(n).Cells("colFreight").Value
            TotalProfit += DGVList.Rows(n).Cells("colGprofit").Value
        Next

        txtTotalProfit.Text = Form3.Amt(TotalProfit)
        txtMonthlyProfitTotal.Text = Form3.Amt(DT3.Rows(0)("GrossProfit"))
        txtTotal.Text = Form3.Amt(TotalSale)
        txtMonthlyTotal.Text = Form3.Amt(DT3.Rows(0)("Amount"))
        txtFreightTotal.Text = Form3.Amt(TotalFreight)
        txtMonthlyFreightTotal.Text = Form3.Amt(DT3.Rows(0)("Freight"))
        txtTotalReceipt.Text = Form3.Amt(TotalRecovery)

        txtProfitP.Text = If(Form3.Numbers(txtTotal.Text) <> 0 AndAlso Form3.Numbers(txtTotalProfit.Text) <> 0,
            Math.Round(txtTotalProfit.Text / txtTotal.Text * 100, 2).ToString, "0.00")

        If Form3.Numbers(txtMonthlyProfitTotal.Text) <> 0 Then
            txtMonthlyEstimatedTotal.Text = Form3.Amt((Form3.Numbers(txtMonthlyProfitTotal.Text) / thisDay) * TotalDays)
            txtMonthlyProfitP.Text = Math.Round(txtMonthlyProfitTotal.Text / txtMonthlyTotal.Text * 100, 2)
            txtAvgDailyProfit.Text = Form3.Amt(Form3.Numbers(txtMonthlyProfitTotal.Text) / thisDay)
        Else
            txtMonthlyEstimatedTotal.Text = "0.00"
            txtMonthlyProfitP.Text = "0.00"
            txtAvgDailyProfit.Text = "0.00"
        End If

        If RowIndex > 0 AndAlso RowIndex <= DGVList.Rows.Count - 1 Then
            DGVList.Rows(RowIndex).Selected = True
        End If
    End Sub

    ' ════════════════════════════════════════════════════════════
    '  EXPORT / PRINT
    ' ════════════════════════════════════════════════════════════
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If DGVList.Rows.Count = 0 Then MsgBox("No Invoices Selected") : Return
        MainPage.Rcpt = If(chkReceipt.Checked, 1, 0)
        For x = 0 To DGVList.Rows.Count - 1
            Dim inv As Integer = DGVList.Rows(x).Cells("ColDoc").Value
            Dim CustomerName As String = DGVList.Rows(x).Cells("ColCustomer").Value
            Dim mob As String = "92" & DGVList.Rows(x).Cells("colOCell").Value.ToString.Substring(1).Replace(" ", "")
            PDFExport(inv, CustomerName)
        Next
        MsgBox(DGVList.Rows.Count & " Invoices Exported")
    End Sub

    Private Sub DGVList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DGVList.CellDoubleClick
        ' Don't close on image button column
        If DGVList.Columns.Contains("colImageBtn") AndAlso e.ColumnIndex >= 0 AndAlso
           DGVList.Columns(e.ColumnIndex).Name = "colImageBtn" Then Return
        InvNumber = DGVList.SelectedRows(0).Cells("ColDoc").Value.ToString
        Me.Close()
    End Sub

    Private Sub btnPrintSelected_Click(sender As Object, e As EventArgs) Handles btnPrintSelected.Click
        Dim inv As Integer = DGVList.SelectedRows(0).Cells("colDoc").Value
        Dim InvDate As Date = DGVList.SelectedRows(0).Cells("colDate").Value
        Dim RnDate As Date = DGVList.SelectedRows(0).Cells("ColRdate").Value
        MainPage.Rcpt = If(chkReceipt.Checked, 1, 0)
        Form3.PrintInvoice(inv, 1, If(RnDate >= Convert.ToDateTime("01.06.2020") AndAlso InvDate >= RnDate, 1, 0))
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If MessageBox.Show("Print on Laser Printer?", "Confirm",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        BtnPrint.Enabled = False
        If DGVList.Rows.Count = 0 Then
            MsgBox("No Invoices Selected") : BtnPrint.Enabled = True : Return
        End If

        For x = 0 To DGVList.Rows.Count - 1
            MainPage.Rcpt = If(chkReceipt.Checked, 1, 0)
            Dim inv As Integer = DGVList.Rows(x).Cells("ColDoc").Value
            Dim InvAmount As Integer = DGVList.Rows(x).Cells("colAmount").Value
            If chkSMS.Checked Then
                Form3.SMS(DGVList.Rows(x).Cells("colOcell").Value,
                          DGVList.Rows(x).Cells("colDoc").Value,
                          DGVList.Rows(x).Cells("colAmount").Value,
                          DGVList.Rows(x).Cells("colDate").Value)
            End If
            If Val(InvAmount) > 0 Then Form3.PrintInvoice(inv, 1, 1)
        Next
        MsgBox(DGVList.Rows.Count & " Invoices Printed")
        BtnPrint.Enabled = True
        btnExport.PerformClick()
    End Sub

    Private Sub btnExportSelected_Click(sender As Object, e As EventArgs) Handles btnExportSelected.Click
        If DGVList.Rows.Count = 0 Then MsgBox("No Invoices Selected") : Return
        PDFExport(DGVList.SelectedRows(0).Cells(2).Value, DGVList.SelectedRows(0).Cells(3).Value)
    End Sub

    ' ════════════════════════════════════════════════════════════
    '  KEYBOARD / GRID EVENTS
    ' ════════════════════════════════════════════════════════════
    Private Sub txtCustomer_Enter(sender As Object, e As EventArgs) Handles txtCustomer.Enter
        txtCustomer.SelectAll()
    End Sub
    Private Sub txtRoute_Enter(sender As Object, e As EventArgs) Handles txtRoute.Enter
        txtRoute.SelectAll()
    End Sub
    Private Sub txtDescription_Enter(sender As Object, e As EventArgs) Handles txtDescription.Enter
        txtDescription.SelectAll()
    End Sub

    Private Sub SearchBox_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtCustomer.KeyDown, txtDescription.KeyDown, txtRoute.KeyDown
        If e.KeyCode = Keys.Enter AndAlso DGVList.Rows.Count > 0 Then
            InvNumber = DGVList.SelectedRows(0).Cells("ColDoc").Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub DGVList_KeyDown(sender As Object, e As KeyEventArgs) Handles DGVList.KeyDown
        If e.KeyCode = Keys.Enter Then
            InvNumber = DGVList.SelectedRows(0).Cells("ColDoc").Value.ToString
            Me.Close()
        End If
        If e.KeyCode = Keys.F4 Then
            Dim Doc As String = DGVList.Item("colDoc", DGVList.CurrentRow.Index).Value
            SQLData("UPDATE PSDETAIL SET STATUS=CASE WHEN STATUS='INVOICE' THEN 'ESTIMATE' ELSE 'INVOICE' END " &
                    "WHERE TYPE='SALE' AND DOC=" & Doc)
        End If
    End Sub

    Private Sub btnListPreview_Click(sender As Object, e As EventArgs) Handles btnListPreview.Click
        MainPage.rptName = Settings("Reports Folder") + "InvoiceList.rpt"
        rptInvPreview.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    ' ════════════════════════════════════════════════════════════
    '  MAIL
    ' ════════════════════════════════════════════════════════════
    Sub PDFGen()
        Dim report As New ReportDocument
        report.Load(Settings("Reports Folder") + "salebook2.rpt")
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        report.SetParameterValue("date", DTPStart.Value.ToString("d"))
        report.SetParameterValue("EDate", DTPEnd.Value.ToString("d"))
        report.ExportToDisk(ExportFormatType.PortableDocFormat,
            Settings("Temp Folder") + "SaleBook " & Now.Date & ".pdf")
        report.Load(Settings("Reports Folder") + "CashBook.rpt")
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        report.SetParameterValue("BookDate", DTPStart.Value.ToString("d"))
        report.ExportToDisk(ExportFormatType.PortableDocFormat,
            Settings("Temp Folder") + "CashBook " & Now.Date & ".pdf")
    End Sub

    Sub mail()
        PDFGen()
        Using Mymsg As New MailMessage
            Mymsg.From = New MailAddress("sanaulhaq604@gmail.com")
            Mymsg.To.Add("sanaulhaq@live.com")
            Mymsg.Body = "SaleBook " & DTPStart.Value.ToString("d") &
                         " to " & DTPEnd.Value.ToString("d") & " " & txtMonthlyEstimatedTotal.Text
            Mymsg.Attachments.Add(New Attachment(Settings("Temp Folder") + "SaleBook " & Now.Date & ".pdf"))
            Mymsg.Attachments.Add(New Attachment(Settings("Temp Folder") + "CashBook " & Now.Date & ".pdf"))
            Mymsg.Subject = "SaleBook " & DTPStart.Value.ToString("d") & " to " & DTPEnd.Value.ToString("d")
            Using smtp As New SmtpClient
                smtp.UseDefaultCredentials = False : smtp.EnableSsl = True
                smtp.Port = 587 : smtp.Host = "smtp.gmail.com"
                smtp.Credentials = New Net.NetworkCredential("sanaulhaq604", "StrongGold21")
                smtp.Send(Mymsg)
            End Using
        End Using
        MsgBox("Email Sent")
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        mail()
    End Sub

    ' ════════════════════════════════════════════════════════════
    '  WHATSAPP SEND
    ' ════════════════════════════════════════════════════════════
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Clipboard.ContainsImage Then Clipboard.Clear()
        For i = 0 To DGVList.Rows.Count - 1
            Dim invoice As String = DGVList.Rows(i).Cells("ColDoc").Value.ToString
            Dim CustomerName As String = DGVList.Rows(i).Cells("ColCustomer").Value.ToString
            Dim ocell As String = "92" & DGVList.Rows(i).Cells("colOCell").Value.ToString.Substring(1).Replace(" ", "")
            Dim FileName As String = Form3.PDFGenF(invoice, CustomerName)
            WASender.StartWhatsAppSession()
            WASender.SendAttachment(ocell, FileName)
            Threading.Thread.Sleep(2000)
        Next
        Console.Beep(2000, 3000)
    End Sub

    ' ════════════════════════════════════════════════════════════
    '  SMS
    ' ════════════════════════════════════════════════════════════
    Private Sub btnSMS_Click(sender As Object, e As EventArgs) Handles btnSMS.Click
        For i = 0 To DGVList.Rows.Count - 1
            lblcustomerName.Text = DGVList.Rows(i).Cells("ColCustomer").Value.ToString
            lblcustomerName.Refresh()
            SMS(DGVList.Rows(i).Cells("ColACID").Value.ToString,
                DGVList.Rows(i).Cells("colOCell").Value.ToString,
                DGVList.Rows(i).Cells("ColDoc").Value.ToString,
                DGVList.Rows(i).Cells("ColAmount").Value.ToString,
                DGVList.Rows(i).Cells("ColDate").Value,
                txtSMServer.Text)
            Threading.Thread.Sleep(txtDelay.Text * 1000)
        Next
        MainPage.msg = "Messages Sent successfully"
        DisappearingMsgBox.Show()
        Console.Beep(2000, 3000)
    End Sub

    Sub SMS(CusId As String, Mobile As String, BillNumber As String,
            BillAmount As String, dt As Date, Optional Svr As String = "1.125")
        If Mobile = "" Then Return
        Dim pb As String = PreBalance(CusId, dt, "Sale", BillNumber)
        Dim netb As Double = Val(pb) + Val(BillAmount)
        Dim ob As String = ""
        If Val(pb) <> 0 Then
            ob = If(Val(pb) < 0,
                "%0a سابقہ بقایا " & Form3.Amt(Math.Abs(CInt(pb))) & "-",
                "%0a سابقہ بقایا " & Form3.Amt(pb))
        End If
        Dim netbStr As String = If(netb < 0,
            "%0a کل بقایا بیلنس " & Form3.Amt(Math.Abs(CInt(netb))) & "-",
            "%0a کل بقایا بیلنس " & Form3.Amt(Math.Abs(netb)))

        Dim msg As String = "السلام علیکم " &
            "%0a بل نمبر" & BillNumber & "%0a مورخہ" & dt.ToString("dd-MM-yy") & ob &
            "%0a بل کی رقم " & Form3.Amt(BillAmount) & netbStr & "%0a احمدانٹرنیشنل "

        Dim winHttpReq As Object = CreateObject("winHttp.winHttprequest.5.1")
        winHttpReq.open("post",
            "http://192.168." & Svr & ":8090/SendSMS?username=Sanaulhaq&password=123&phone=" &
            Mobile & "&message=" & msg, False)
        Try
            winHttpReq.send()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ' ════════════════════════════════════════════════════════════
    '  MISC
    ' ════════════════════════════════════════════════════════════
    Private Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Integer, ByVal dx As Integer,
        ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        mouse_event(&H2, 700, 656, 0, 0)
        mouse_event(&H4, 700, 656, 0, 0)
    End Sub

    ' ════════════════════════════════════════════════════════════
    '  HELPER FUNCTIONS
    ' ════════════════════════════════════════════════════════════
    Function DateChange(Dte As Date) As String
        Return Year(Dte) & "-" & Month(Dte) & "-" & Dte.ToString.Substring(0, 2)
    End Function
    Private Sub FixColumnOrder()
        If DGVList.Columns.Count = 0 Then Return

        Try
            ' Set your desired order (adjust indexes if needed)
            DGVList.Columns("colNumber").DisplayIndex = 0
            DGVList.Columns("colDate").DisplayIndex = 1
            DGVList.Columns("colDoc").DisplayIndex = 2
            DGVList.Columns("colCustomer").DisplayIndex = 3
            DGVList.Columns("colRoute").DisplayIndex = 4
            DGVList.Columns("colOCell").DisplayIndex = 5
            DGVList.Columns("colDesc").DisplayIndex = 6
            DGVList.Columns("colAmount").DisplayIndex = 7
            DGVList.Columns("colReceived").DisplayIndex = 8
            DGVList.Columns("colFreight").DisplayIndex = 9
            DGVList.Columns("colGProfit").DisplayIndex = 10
            DGVList.Columns("colProfitP").DisplayIndex = 11

            ' Keep Image button at the end
            If DGVList.Columns.Contains("colImageBtn") Then
                DGVList.Columns("colImageBtn").DisplayIndex = DGVList.Columns.Count - 1
            End If

        Catch
            ' ignore if any column missing (safe)
        End Try
    End Sub
    Function PreBalance(ACID As String, dte As Date, DocType As String, DocNumber As Integer) As String
        Dim PreBal As DataTable = SQLData(
            "select isnull(sum(isnull(debit,0))-sum(isnull(credit,0)),0) PreBal " &
            "from ledgers where acid=" & ACID &
            " and date<='" & dte & "'" &
            " and '" & DocType & "'+cast(doc as varchar(10))<>'" & DocType & "'+ cast(" & DocNumber & " as varchar(10))" &
            " and acid<>1")
        Return If(PreBal.Rows.Count > 0, PreBal.Rows(0)(0).ToString, "0")
    End Function

End Class


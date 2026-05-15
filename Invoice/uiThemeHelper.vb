Imports System.Drawing
Imports System.Windows.Forms

Public Module UIThemeHelper

    Public Sub ApplyTheme(form As Form)

        form.BackColor = AppTheme.BgForm
        form.ForeColor = AppTheme.TextPrimary
        form.Font = AppTheme.FontUI

        StyleControls(form)

        ' DataGridView styling
        For Each dgv In GetAllControls(Of DataGridView)(form)
            StyleGrid(dgv)
        Next

        ' Buttons
        For Each btn In GetAllControls(Of Button)(form)
            StyleButton(btn)
        Next

        ' TreeView
        For Each tv In GetAllControls(Of TreeView)(form)
            tv.BackColor = AppTheme.BgPanel
            tv.ForeColor = AppTheme.TextPrimary
            tv.BorderStyle = BorderStyle.None
        Next

    End Sub

    Private Sub StyleGrid(dgv As DataGridView)

        With dgv
            .BackgroundColor = AppTheme.BgForm
            .GridColor = AppTheme.GridLine
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .EnableHeadersVisualStyles = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowTemplate.Height = 34
            .ColumnHeadersHeight = 38
        End With

        With dgv.ColumnHeadersDefaultCellStyle
            .BackColor = AppTheme.GridHeader
            .ForeColor = AppTheme.TextLabel
            .Font = AppTheme.FontHeader
        End With

        With dgv.DefaultCellStyle
            .BackColor = AppTheme.GridRow
            .ForeColor = AppTheme.TextPrimary
            .SelectionBackColor = AppTheme.GridSel
            .SelectionForeColor = Color.White
        End With

        With dgv.AlternatingRowsDefaultCellStyle
            .BackColor = AppTheme.GridRowAlt
        End With

    End Sub

    Private Sub StyleButton(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.BackColor = AppTheme.BgCard
        btn.ForeColor = AppTheme.TextPrimary
        btn.Font = AppTheme.FontUISB
        btn.FlatAppearance.BorderColor = AppTheme.AccentDim
        btn.FlatAppearance.BorderSize = 1
    End Sub

    Private Sub StyleControls(parent As Control)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is Panel OrElse TypeOf ctrl Is GroupBox Then
                ctrl.BackColor = AppTheme.BgPanel
            End If
            StyleControls(ctrl)
        Next
    End Sub

    Private Function GetAllControls(Of T As Control)(parent As Control) As IEnumerable(Of T)
        Dim list As New List(Of T)
        For Each c As Control In parent.Controls
            If TypeOf c Is T Then list.Add(CType(c, T))
            list.AddRange(GetAllControls(Of T)(c))
        Next
        Return list
    End Function

End Module
Public Class frmPartySearch
    Public Property acID As String = ""
    Public Property CusName As String = ""
    Public Property CusAddress As String = ""
    Public Property CustomerRoute As String = ""
    Public Property CustomerMobile As String = ""

    Sub CustomerSelect()
        If DataGridView1.Rows.Count > 0 Then
            Dim index As Integer = DataGridView1.SelectedRows.Item(0).Index
            acID = DataGridView1.Item("colID", index).Value.ToString
            CusName = DataGridView1.Item("colName", index).Value.ToString
            CusAddress = DataGridView1.Item("colAdd", index).Value.ToString
            CustomerRoute = DataGridView1.Item("colRoute", index).Value.ToString
            CustomerMobile = DataGridView1.Item("colOCell", index).Value.ToString

            Me.Close()
            'SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        Me.Close()
    End Sub

    Sub PartySearch()
        Dim dt As DataTable
        dt = SQLData("select id,subsidary,oaddress,spo,route,ocell,isnull(Cell2,'')  Cell2 from coa where subsidary like'%" & txtCustomerSearch.Text & "%'" & "and route like'%" & txtRoute.Text & "%' and (ocell like '%" & txtMobile.Text.Trim & "%' or cell2 like '%" & txtMobile.Text.Trim & "%' and code like '%" & txtCode.Text & "%'  )")
        Me.DataGridView1.DataSource = dt
        Label2.Text = DataGridView1.Rows.Count

    End Sub

    Private Sub txtCustID_TextChanged(sender As Object, e As EventArgs) Handles txtCustomerSearch.TextChanged, txtCustomerSearch.Enter, txtMobile.TextChanged, txtRoute.TextChanged, txtCode.TextChanged
        PartySearch()
    End Sub

    Private Sub txtCustomerSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCustomerSearch.KeyDown, txtRoute.KeyDown, txtMobile.KeyDown
        If e.KeyCode = Keys.Enter Then
            CustomerSelect()
        End If
        If e.KeyCode = Keys.Down And DataGridView1.Rows.Count > 0 Then
            DataGridView1.Select()
        End If
    End Sub



    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            CustomerSelect()
        End If
    End Sub

    Private Sub txtCustomerSearch_Enter(sender As Object, e As EventArgs) Handles txtCustomerSearch.Enter
        txtCustomerSearch.SelectAll()
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        acID = DataGridView1.Item(0, e.RowIndex()).Value
        CusName = DataGridView1.Item(1, e.RowIndex()).Value
        CusAddress = DataGridView1.Item(2, e.RowIndex()).Value
        CustomerMobile = DataGridView1.Item("colOCell", e.RowIndex).Value.ToString

        Me.Close()
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmPartySearch_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtCustomerSearch.SelectAll()
        txtCustomerSearch.Select()
        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.DataSource.clear()
        End If

    End Sub

    Private Sub frmPartySearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PartySearch()
    End Sub

    Private Sub txtRoute_TextChanged(sender As Object, e As EventArgs) Handles txtRoute.TextChanged
        PartySearch()
    End Sub

    Private Sub txtRoute_Enter(sender As Object, e As EventArgs) Handles txtRoute.Enter
        'If txtCustomerSearch.Text = "" Then
        '    txtCustomerSearch.Select()
        '    txtCustomerSearch.SelectAll()
        'End If
    End Sub
End Class
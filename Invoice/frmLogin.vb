Imports System.Data.SqlClient
Imports Microsoft.SqlServer
Public Class frmLogin
    Public MySqlServer As String
    Public MyDataBase As String = "AhmadInternational"
    Public User As String = ""
    Public Property UserLevel As String = ""
    Public Property UserName As String = ""


    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown, cmbServer.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPassword.Text = "" Then
                End
            End If
            login()
        End If
        If e.KeyCode = Keys.Escape Then
            End
        End If
    End Sub

    Private Sub ApplyServerCredentials(serverName As String)
        ' Centralized, deterministic server -> credential mapping
        If serverName = "108.181.197.181,19995" Then
            MainPage.User = "Sanaulhaq"
            MainPage.Password = "StrongGold24$"
        ElseIf serverName = "HP840" Then
            MainPage.User = "sa"
            MainPage.Password = "Ahmad"
        Else
            MainPage.User = "sa"
            MainPage.Password = "Ai"
        End If
    End Sub

    Sub login()
        MySqlServer = cmbServer.Text.Trim()
        ' Ensure credentials are set based on the server chosen
        ApplyServerCredentials(MySqlServer)

        MainPage.conString = "Server=" & MySqlServer & ";Database=" & MyDataBase & ";User ID=" & MainPage.User & ";Password=" & MainPage.Password & ";Connection Timeout=45"
        MainPage.conString2 = "Server=" & MySqlServer & ";Database=images;User ID=" & MainPage.User & ";Password=" & MainPage.Password & ";Connection Timeout=45"

        Dim DT As DataTable = SQLData("select * from users where password='" & txtPassword.Text.ToUpper & "'")
        If DT.Rows.Count = 0 Then
            MainPage.msg = "User not found"
            DisappearingMsgBox.Show()
            End
        Else
            UserLevel = DT.Rows(0)("UserType")
            UserName = DT.Rows(0)("UserName")
            Me.Hide()
            MainPage.LoginDetails = MySqlServer + " - " + Me.UserLevel + " - " + Me.UserName
            MainPage.Text = MainPage.LoginDetails
            MainPage.Show()
        End If

        Using con As New SqlConnection(MainPage.conString)
            Try
                con.Open()
            Catch ex As Exception
                cmbServer.Text = ""
                MsgBox("Server not responding or authentication failed: " & ex.Message)
                cmbServer.DisplayMember = Nothing
                Return
            End Try
        End Using
    End Sub

    Private Sub txtPassword_Enter(sender As Object, e As EventArgs) Handles txtPassword.Enter
        'txtPassword.Text = ""
        txtPassword.Select()
        txtPassword.SelectAll()
    End Sub

    'Public Function txt_to_data(ByVal filename As String, ByVal header As Boolean, ByVal delimiter As String) As DataTable
    '    'New datatable
    '    Dim dt As DataTable = New DataTable

    '    'Read the contents of the textfile into an array
    '    Dim sr As IO.StreamReader = New IO.StreamReader(filename)
    '    Dim txtlines() As String = sr.ReadToEnd.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
    '    sr.Close()
    '    'Return nothing if there's nothing in the textfile
    '    If txtlines.Count = 0 Then
    '        Return Nothing
    '    End If

    '    Dim column_count As Integer = 0
    '    For Each col As String In txtlines(0).Split({delimiter}, StringSplitOptions.None)
    '        If header Then
    '            'If there's a header then add it by it's name
    '            dt.Columns.Add(col)
    '            dt.Columns(column_count).Caption = col
    '        Else
    '            'If there's no header then add it by the column count
    '            dt.Columns.Add(String.Format("Column{0}", column_count))
    '            dt.Columns(column_count).Caption = String.Format("Column{0}", column_count + 1)
    '        End If

    '        column_count += 1
    '    Next

    '    If header Then
    '        For rows As Integer = 1 To txtlines.Count - 1 'start at one because there's a header for the first line(0)
    '            'Declare a new datarow
    '            Dim dr As DataRow = dt.NewRow

    '            'Set the column count back to 0, we can reuse this variable ;]
    '            column_count = 0
    '            For Each col As String In txtlines(rows).Split({delimiter}, StringSplitOptions.None) 'Each column in the row
    '                'The column in cue is set for the datarow
    '                dr(column_count) = col
    '                column_count += 1
    '            Next

    '            'Add the row
    '            dt.Rows.Add(dr)
    '        Next
    '    Else
    '        For rows As Integer = 0 To txtlines.Count - 1 'start at zero because there's no header
    '            'Declare a new datarow
    '            Dim dr As DataRow = dt.NewRow

    '            'Set the column count back to 0, we can reuse this variable ;]
    '            column_count = 0
    '            For Each col As String In txtlines(rows).Split({delimiter}, StringSplitOptions.None) 'Each column in the row
    '                'The column in cue is set for the datarow
    '                dr(column_count) = col
    '                column_count += 1
    '            Next

    '            'Add the row
    '            dt.Rows.Add(dr)
    '        Next
    '    End If

    '    Return dt
    'End Function

    'Public Function Settings(Parameter As String) As String
    '    Dim DT As DataTable = txt_to_data("D:\Settings.txt", True, "=")
    '    Dim DRows() As DataRow = DT.Select("PARAMETER='" & Parameter & "'")
    '    Dim ReturnValue As String = ""
    '    If DRows.Length > 0 Then
    '        For Each row As DataRow In DRows
    '            ReturnValue = row(1).ToString
    '        Next
    '    End If
    '    If Parameter.EndsWith("Folder") Then
    '        If Not ReturnValue.EndsWith("\") Then
    '            ReturnValue += "\"
    '        End If
    '    End If
    '    'If Parameter = "Reports Path" Then
    '    '    ReturnValue = "\\" + MySqlServer + "\" + ReturnValue
    '    'End If

    '    Return ReturnValue
    'End Function


    Sub GetParametersFromTextFile2()
        MainPage.ThermalPrinter = Settings("THERMAL PRINTER")
        MainPage.PSERVER = Settings("PSERVER")
        MainPage.OSERVER = Settings("OSERVER")
        'Settings("Reports Folder") = Settings("Reports Folder")
        'MainPage.PSERVER = Settings("PSERVER")
    End Sub





    Sub GetParametersFromTextFile()
        Dim DT As DataTable = txt_to_data("D:\Settings.txt", True, "=")
        Dim DRows() As DataRow = DT.Select("PARAMETER='THERMAL PRINTER'")
        Dim TPrinter As String = ""
        'If DRows.Length = 0 Then

        'End If
        If DRows.Length > 0 Then
            For Each row As DataRow In DRows
                TPrinter = row(1).ToString
            Next
            MainPage.ThermalPrinter = TPrinter
        End If
        DRows = DT.Select("PARAMETER='PSERVER'")
        If DRows.Length > 0 Then
            Dim PSERVER As String = ""

            For Each row As DataRow In DRows
                PSERVER = row(1).ToString
            Next
            MainPage.PSERVER = PSERVER
            MySqlServer = PSERVER
        End If

        DRows = DT.Select("PARAMETER='CSERVER'")
        If DRows.Length > 0 Then
            Dim CSERVER As String = ""

            For Each row As DataRow In DRows
                CSERVER = row(1).ToString
            Next
            MainPage.CSERVER = CSERVER
            'MySqlServer = PSERVER
        End If




        DRows = DT.Select("PARAMETER='OSERVER'")
        If DRows.Length > 0 Then
            Dim OSERVER As String = ""
            For Each row As DataRow In DRows
                OSERVER = row(1).ToString
            Next
            MainPage.OSERVER = OSERVER
        End If


        DRows = DT.Select("PARAMETER='Reports Folder'")
        If DRows.Length > 0 Then
            Dim ReportsFolder As String = ""
            For Each row As DataRow In DRows
                ReportsFolder = row(1).ToString
            Next
            'MsgBox(ReportsFolder)
            'Settings("Reports Folder") = ReportsFolder
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetParametersFromTextFile2()

        MainPage.conString = "Server=" & MySqlServer & ";Database=" & MyDataBase & ";User ID=" & MainPage.User & ";Password=" & MainPage.Password & ";;Connection Timeout=45"
        If cmbServer.Items.Count = 0 Then
            cmbServer.Items.Clear()
            cmbServer.Items.Add(MainPage.PSERVER)
            cmbServer.Items.Add(MainPage.OSERVER)
            'cmbServer.Items.Add(MainPage.CSERVER)
            If MainPage.PSERVER <> Environment.MachineName And MainPage.OSERVER <> Environment.MachineName Then
                cmbServer.Items.Add(Environment.MachineName)
            End If
            cmbServer.SelectedIndex = 0

            'If cmbServer.SelectedIndex < 0 Then
            '    cmbServer.SelectedIndex = 0
            'End If
        End If

        'cmbServer.Text = Environment.MachineName
        '
        'txtPassword.SelectAll()
        txtPassword.Select()
    End Sub

    Private Sub cmbServer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbServer.SelectedIndexChanged
        MySqlServer = cmbServer.Text
    End Sub

    Private Sub cmbServer_Leave(sender As Object, e As EventArgs) Handles cmbServer.Leave
        ' Keep UI event, but delegate to the central method
        MySqlServer = cmbServer.Text.Trim()
        ApplyServerCredentials(MySqlServer)
    End Sub
End Class
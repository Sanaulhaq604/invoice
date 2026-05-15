Imports ExcelDataReader
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class ImportFromExcel
    Dim tables As DataTableCollection


    Public Function GetWorksheetData(fileName As String, worksheetName As String) As DataTable
        Dim connectionString As String = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={fileName};Extended Properties='Excel 12.0 Xml;HDR=YES'"
        Dim query As String = $"SELECT * FROM [70cc 125cc$A7:J]"
        Using connection As New OleDbConnection(connectionString)
            connection.Open()
            Using adapter As New OleDbDataAdapter(query, connection)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)
                connection.Close()
                Return dataTable
            End Using
        End Using
    End Function



    Private Sub cmbSheets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSheets.SelectedIndexChanged

        Dim dt2 As DataTable = GetWorksheetData(txtFileName.Text, cmbSheets.SelectedItem.ToString())

        Dim dt As DataTable = tables(cmbSheets.SelectedItem.ToString())
        For n = 0 To CInt(txtStartingRowNumber.Text)
            dt.Rows.RemoveAt(0)
        Next

        'Assuming you have a DataGridView named dgv And a DataTable named dt

        ' First, set the AutoGenerateColumns property to false
        DataGridView1.AutoGenerateColumns = False

        ' Now, add columns to the DataGridView and set their DataPropertyName
        For Each col As DataColumn In dt2.Columns
            Dim newColumn As New DataGridViewTextBoxColumn()
            newColumn.DataPropertyName = col.ColumnName
            newColumn.HeaderText = col.ColumnName
            If col.ColumnName = "NAME" Then
                newColumn.Width = 250
            ElseIf col.ColumnName = "F5" Then
                newColumn.Width = 150
            End If
            newColumn.Name = col.ColumnName
            DataGridView1.Columns.Add(newColumn)
        Next




        DataGridView1.DataSource = dt2
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls"}
            If ofd.ShowDialog() = DialogResult.OK Then
                txtFileName.Text = ofd.FileName
                Using stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read)
                    Using reader As IExcelDataReader = ExcelReaderFactory.CreateReader(stream)
                        Dim result As DataSet = reader.AsDataSet(New ExcelDataSetConfiguration() With {.ConfigureDataTable = Function(__) New ExcelDataTableConfiguration() With {
                                                                                                                                       .UseHeaderRow = True}})
                        cmbSheets.Items.Clear()
                        tables = result.Tables
                        For Each table As DataTable In tables
                            cmbSheets.Items.Add(table.TableName)
                        Next
                    End Using
                End Using
            End If
        End Using

    End Sub

End Class
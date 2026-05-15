Imports System.Data.SqlClient

Public Class attendence


    'Public Function SQLData(Q As String, Optional doc As Integer = 1) As DataTable
    '    Dim con As New SqlConnection(MainPage.conString)

    '    Dim cmd As String

    '    Dim dt As New DataTable
    '    cmd = Q
    '    Dim da As New SqlDataAdapter(cmd, con)
    '    'Try
    '    con.Open()
    '    da.Fill(dt)
    '    con.Close()
    '    'Catch ex As Exception
    '    'MessageBox.Show(ex.Message)
    '    'End Try
    '    Return dt
    'End Function


    'Public MyDataBase As String = "ahmadinternational"


    Private Sub AttendanceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmployeeData()
    End Sub

    Sub LoadEmployeeData()

        Dim dt As DataTable = SQLData("SELECT id, name FROM Employee")

        dgvAttendance.Rows.Clear()


        For Each row As DataRow In dt.Rows
            dgvAttendance.Rows.Add(
                row("name").ToString(),              ' EmpName
                "11:00 AM",                          ' Time_In
                "9:00 PM",                           ' Time_Out
                "Present"                            ' Absent (ComboBox default)
            )
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            For Each row As DataGridViewRow In dgvAttendance.Rows
                If Not row.IsNewRow Then
                    Dim empName As String = row.Cells("EmpName").Value.ToString()
                    Dim timeIn As String = row.Cells("Time_In").Value.ToString()
                    Dim timeOut As String = row.Cells("Time_Out").Value.ToString()
                    Dim status As String = row.Cells("Absent").Value.ToString()

                    SQLData("INSERT INTO Attendance (DateMarked, EmployeeName, TimeIn, TimeOut, Status) VALUES ('" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "', '" & empName & "', '" & timeIn & "', '" & timeOut & "', '" & status & "' )")
                End If
            Next

            MessageBox.Show("Attendance saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error saving attendance: " & ex.Message)
        End Try
    End Sub

End Class
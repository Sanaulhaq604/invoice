Public Class GridTest
    Private Sub GridTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DT As DataTable = txt_to_data("D:\Settings.txt", True, "=")
        Dim DRows() As DataRow = DT.Select("PARAMETER='THERMAL PRINTER'")
        Dim TPrinter As String = ""
        'If DRows.Length = 0 Then

        'End If
        For Each row As DataRow In DRows
            TPrinter = row(1).ToString

        Next
        MsgBox(TPrinter)
    End Sub
End Class
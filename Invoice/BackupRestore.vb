Imports System.Data.SqlClient
Public Class BackupRestore
    Dim server As String = frmLogin.MySqlServer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False

        Dim con As New SqlConnection(MainPage.conString)
        'Dim cmd1 As New SqlCommand("  exec xp_cmdshell 'del ""   " & txtFile.Text & "   ""'  ", con)
        'Dim cmd1 As New SqlCommand("  exec xp_cmdshell 'del D:\Google Drive ai\db backup\NewBackup.bak'  ", con)

        Dim FileToDelete As String

        FileToDelete = txtFile.Text

        If System.IO.File.Exists(FileToDelete) = True Then

            System.IO.File.Delete(FileToDelete)
            'MessageBox.Show("File Deleted")

        End If




        Dim cmd2 As New SqlCommand("ALTER DATABASE ahmadinternational SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
BACKUP DATABASE ahmadinternational 
TO DISK = N'" & txtFile.Text & "' 
WITH INIT;
ALTER DATABASE ahmadinternational SET MULTI_USER
", con)
        'Dim cmd2 As New SqlCommand("backup database ahmadinternational to disk='\\192.168.18.164\D\NewBackup.bak'", con)

        Try
            con.Open()
            'cmd1.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Backup File, " & txtFile.Text & "  Created Successfully", "Backup Made", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            Button1.Enabled = True
            Me.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Enabled = False
        Dim con As New SqlConnection(MainPage.conString)

        Dim cmd As New SqlCommand("
use master
ALTER DATABASE " & MainPage.MyDataBase & " SET Single_User WITH Rollback Immediate
restore database " & MainPage.MyDataBase & " from disk=N'" & txtFile.Text & "'
ALTER DATABASE ahmadinternational SET Multi_User
", con)
        Dim RES As DialogResult = MessageBox.Show("Do you really want to resotre from Backup File?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If RES = 6 Then
            RES = MessageBox.Show("ARE YOUR REALLY SURE?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If RES = 6 Then

                Try
                    con.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Backup restored successfully from file " & txtFile.Text, "Backup Restored", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    con.Close()
                    Button2.Enabled = True
                End Try

            End If
        End If
    End Sub

    Private Sub BackupRestore_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub BackupRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
        Dim d As Date

        d = Date.Now.AddMonths(1)
        d = New Date(d.Year, d.Month, 1).AddDays(-1)
        If Now.Date = d Then
            txtFile.Text = "D:\Google Drive ai\db backup\NewBackup " & MonthName(Now.Month) & "-" & Now.Year & ".bak"
        End If

    End Sub

    Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click
        OpenFileDialog1.FileName = txtFile.Text
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFile.Text = OpenFileDialog1.FileName
        End If
    End Sub
End Class



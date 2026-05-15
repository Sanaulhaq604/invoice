'Public Class frmSettings
'    

'    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click
'        Me.Close()
'    End Sub

'    Sub update()
'End Class


Imports System.IO

Public Class frmSettings

    ' Dim settingsFile As String = Application.StartupPath & "\settings.txt"
    'Dim Setting As New Dictionary(Of String, String)

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtThermalPrinter.Text = Settings("Thermal Printer")
        txtReportsFolder.Text = Settings("Reports Folder")
        txtTempFolder.Text = Settings("Temp Folder")
        txtserver.Text = Settings("pserver")
        txtCompany.Text = Settings("company")
        TxtAddress.Text = Settings("address")
        TxtMobile.Text = Settings("Mobile")
        txtLaserPrinter.Text = Settings("Laser Printer")
        txtDatbase.Text = Settings("Database")


    End Sub




    'UPDATE BUTTON
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim result As DialogResult = MessageBox.Show("Are you sure to change settings ?", "Change Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If result = DialogResult.No Then
            Return
        End If

        UpdateSettings("d:\settings.txt", "Thermal Printer", txtThermalPrinter.Text)
        UpdateSettings("d:\settings.txt", "Company", txtCompany.Text)
        UpdateSettings("d:\settings.txt", "address", TxtAddress.Text)
        UpdateSettings("d:\settings.txt", "mobile", TxtMobile.Text)
        UpdateSettings("d:\settings.txt", "Laser Printer", txtLaserPrinter.Text)
        UpdateSettings("d:\settings.txt", "database", txtDatbase.Text)
        UpdateSettings("d:\settings.txt", "Reports Folder", txtReportsFolder.Text)
        UpdateSettings("d:\settings.txt", "Temp Folder", txtTempFolder.Text)
        UpdateSettings("d:\settings.txt", "Pserver", txtserver.Text)

        MessageBox.Show("Settings Updated Successfully")
        MainPage.lbCompany()
    End Sub


    'SAVE SETTINGS
    Sub UpdateSettings(FilePath As String, Key As String, NewValue As String)

        Dim lines As New List(Of String)
        '= File.ReadAllLines(FilePath)
        If File.Exists(FilePath) Then
            lines = File.ReadAllLines(FilePath).ToList()
        End If
        Dim KeyFound As Boolean = False
        For i As Integer = 0 To lines.Count - 1
            If lines(i).StartsWith(Key & "=") Then
                lines(i) = Key & "=" & NewValue
                KeyFound = True
                Exit For
            End If
        Next
        If Not KeyFound Then
            lines.add(Key & "=" & NewValue)
        End If
        File.WriteAllLines(FilePath, lines)
    End Sub


    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class
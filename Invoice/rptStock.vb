Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptStock
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim state As Integer = 2
        Dim Clm As Integer = 0
        Dim IncludeValue As Integer = 0
        If rdclaim.Checked Then
            Clm = 1
        Else
            Clm = 0
        End If
        If rdALL.Checked Then
            state = 2
        End If
        If rdNegative.Checked Then
            state = 1
        End If
        If rdPositive.Checked Then
            state = 0
        End If
        Dim report As New ReportDocument
        Dim chkdead As Integer = 0

        If chkDeadLevel.Checked = True Then
            chkdead = 1
        Else
            chkdead = 0
        End If

        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            If chkValue.Checked = True Then
                IncludeValue = 1
            Else
                IncludeValue = 0
            End If
        Else
            IncludeValue = 0
        End If
        'MsgBox(IncludeValue)
        If chkUrdu.Checked Then
            report.Load(settings("Reports Folder") + "StockReportUrdu.rpt")
        Else
            report.Load(settings("Reports Folder") + "StockReport.rpt")
        End If
        'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        report.SetParameterValue("COMP", txtCompany.Text)
        report.SetParameterValue("Location", txtLocation.Text)
        report.SetParameterValue("ProductName", txtProductName.Text)
        report.SetParameterValue("Model", txtCategory.Text)
        report.SetParameterValue("MINUS", state)
        report.SetParameterValue("DT", DateTimePicker1.Value.ToString("d"))
        report.SetParameterValue("sort order selection", "AMT")
        report.SetParameterValue("DL", chkdead)
        report.SetParameterValue("IncludeValue", IncludeValue)
        report.SetParameterValue("CLM", Clm)
        Dim filename As String = Settings("Temp Folder") + txtCompany.Text & " Stock Report " & DateTimePicker1.Value.ToString("d") & ".PDF"
        report.ExportToDisk(ExportFormatType.PortableDocFormat, filename)
        CrystalReportViewer1.ReportSource = report
        CrystalReportViewer1.Refresh()
        txtCompany.Select()
        txtCompany.SelectAll()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles tbnClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim state As Integer = 2
        Dim IncludeValue As Integer = 0
        If rdALL.Checked Then
            state = 2
        End If
        If rdNegative.Checked Then
            state = 1
        End If
        If rdPositive.Checked Then
            state = 0
        End If
        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            If chkValue.Checked = True Then
                IncludeValue = 1
            Else
                IncludeValue = 0
            End If
        Else
            IncludeValue = 0
        End If
        Dim report As New ReportDocument
        Dim clm As Integer = 0
        If rdClaim.Checked Then
            clm = 1
        Else
            clm = 0
        End If
        If chkUrdu.Checked Then
            report.Load(settings("Reports Folder") + "StockReportUrdu.rpt")
        Else
            report.Load(settings("Reports Folder") + "StockReport.rpt")
        End If
        'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        report.SetParameterValue("clm", clm)
        report.SetParameterValue("COMP", txtCompany.Text)
        report.SetParameterValue("Location", txtLocation.Text)
        report.SetParameterValue("ProductName", txtProductName.Text)
        report.SetParameterValue("Model", txtCategory.Text)
        report.SetParameterValue("MINUS", state)
        report.SetParameterValue("DT", DateTimePicker1.Value.ToString("d"))
        report.SetParameterValue("IncludeValue", IncludeValue)
        If chkDeadLevel.Checked = True Then
            report.SetParameterValue("DL", 1)
        Else
            report.SetParameterValue("DL", 0)
        End If
        report.SetParameterValue("sort order selection", "AMT")
        If chkUrdu.Checked Then
            Dim filename As String = settings("Temp Folder") + txtCompany.Text & " Stock Report " & DateTimePicker1.Value.ToString("d") & ".PDF"
            report.ExportToDisk(ExportFormatType.PortableDocFormat, filename)
        Else
            report.ExportToDisk(ExportFormatType.Excel, "D:\Google Drive ai\db backup\Invoice Temp\Stock Report.xls")
        End If
        txtCompany.Select()
        txtCompany.SelectAll()
    End Sub
End Class
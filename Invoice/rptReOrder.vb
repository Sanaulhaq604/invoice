Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class rptReOrder
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim report As New ReportDocument
        report.Load(settings("Reports Folder") + "ReOrder.rpt")
        'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        report.SetParameterValue("Vendor", txtACID.Text)
        report.SetParameterValue("Company", txtCompany.Text)
        CRViewer.AllowedExportFormats = ViewerExportFormats.PdfFormat
        CRViewer.ReportSource = report
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim report As New ReportDocument
        If chkUrdu.Checked Then
            report.Load(settings("Reports Folder") + "ReOrderUrdu.rpt")
            If chkName.Checked Then
                report.SetParameterValue("TitleName", 0)
            Else
                report.SetParameterValue("TitleName", 1)
            End If
            If chkTitle.Checked Then
                report.SetParameterValue("Title", 0)
            Else
                report.SetParameterValue("Title", 1)
            End If
            If chkScheme.Checked Then
                report.SetParameterValue("Scheme", 0)
            Else
                report.SetParameterValue("Scheme", 1)
            End If
        Else
            report.Load(settings("Reports Folder") + "ReOrder.rpt")
        End If
        'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        report.SetParameterValue("Vendor", txtACID.Text)
        report.SetParameterValue("Company", txtCompany.Text)
        Dim excelFormatOpts As New ExcelFormatOptions
        report.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.Excel
        excelFormatOpts.ShowGridLines = True
        report.ExportOptions.FormatOptions = excelFormatOpts
        Dim Vendor As String = ""
        If chkTitle.Checked Then
            Vendor = txtACID.Text & " " & txtName.Text & " "
        Else
            Vendor = ""
        End If
        If chkUrdu.Checked Then
            report.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\AI Demand " & txtCompany.Text & " " & Vendor & Today.ToString("d") & ".pdf")
        Else
            report.ExportToDisk(ExportFormatType.Excel, "D:\Google Drive ai\db backup\Invoice Temp\AI Demand " & txtCompany.Text & " " & Vendor & Today.ToString("d") & ".xls")
        End If
        Console.Beep(2000, 1000)
        'MsgBox("File Exported !")
        txtCompany.Select()
        txtCompany.SelectAll()
    End Sub

    Private Sub txtACID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtACID.KeyDown
        If e.KeyCode = Keys.Enter And txtACID.Text = "" Then
            e.Handled = True
            frmPartySearch.ShowDialog()
            txtACID.Text = frmPartySearch.acID
            txtName.Text = frmPartySearch.CusName
            frmPartySearch.Dispose()
        End If
    End Sub

    Private Sub txtACID_Leave(sender As Object, e As EventArgs) Handles txtACID.Leave
        If txtACID.Text <> "" Then
            Dim dt As DataTable = SQLData("select subsidary from coa where id=" & txtACID.Text)
            If dt.Rows.Count > 0 Then
                txtName.Text = dt.Rows(0)("Subsidary")
            Else
                txtName.Text = ""
            End If
        Else
            txtName.Text = ""
        End If
        If txtACID.Text = "273" Or txtACID.Text = "909" Or txtACID.Text = "956" Or txtACID.Text = "454" Or txtCompany.Text.Contains("FIT") Then
            chkScheme.Checked = True
        Else
            chkScheme.Checked = False
        End If
    End Sub

    Private Sub txtCompany_Leave(sender As Object, e As EventArgs) Handles txtCompany.Leave
        If txtACID.Text = "273" Or txtACID.Text = "909" Or txtACID.Text = "956" Or txtACID.Text = "454" Or txtCompany.Text.Contains("FIT") Then
            chkScheme.Checked = True
        Else
            chkScheme.Checked = False
        End If
    End Sub
End Class
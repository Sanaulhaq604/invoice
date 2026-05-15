Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmRouteDetails
    Private Sub frmRouteDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTP1.Value = Date.Today
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Generate()
    End Sub


    Sub Generate()
        If txtRoute.Text = "" Then
            MsgBox("Please enter route number")
            Return
        End If
        Try
            Dim Report As New ReportDocument
            Dim crtableLogoninfos As New TableLogOnInfos
            Dim crtableLogoninfo As New TableLogOnInfo
            Dim crConnectionInfo As New ConnectionInfo
            Dim CrTables As Tables
            Dim CrTable As Table
            Dim ReportPath As String = settings("Reports Folder")
            If Not ReportPath.EndsWith("\") Then
                ReportPath += "\"
            End If
            Report.Load(ReportPath + "rptRouteDetail2.rpt")
            With crConnectionInfo
                .ServerName = frmLogin.MySqlServer
                .DatabaseName = frmLogin.MyDataBase
                .UserID = "sa"
                .Password = "Ai"
            End With
            CrTables = Report.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next
            Dim chkbal As Integer = 0
            If chkBalance.Checked = True Then
                chkbal = 1
            Else chkbal = 0
            End If

            'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            Report.SetParameterValue("Date", DTP1.Value.ToString("d"))
            Report.SetParameterValue("Route", txtRoute.Text)
            Report.SetParameterValue("CheckBalance", chkbal)
            'Report.PrintOptions.PaperSize = PaperSize.PaperA5

            CrystalReportViewer1.ReportSource = Report
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtRoute_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRoute.KeyDown
        If e.KeyCode = Keys.Enter Then
            Generate()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If txtRoute.Text = "" Then
            MsgBox("Please enter route number")
            Return
        End If
        Dim Report As New ReportDocument
        Dim chkbal As Integer = 0
        If chkBalance.Checked = True Then
            chkbal = 1
        Else chkbal = 0
        End If


        Report.Load(settings("Reports Folder") + "rptRouteDetail2.rpt")
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In Report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next


        Report.SetParameterValue("Date", DTP1.Value.ToString("d"))
        Report.SetParameterValue("Route", txtRoute.Text)
        Report.SetParameterValue("CheckBalance", chkbal)
        Report.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\DRF " & txtRoute.Text & " " & DTP1.Value.ToString("d") & ".pdf")
        txtRoute.Select()
        txtRoute.SelectAll()

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click, btnThermalLoad.Click
        Dim report As New ReportDocument
        'Dim ReportPath As String = "\\" + frmLogin.MySqlServer + "\" + settings("Reports Folder")
        Dim ReportPath As String = Settings("Reports Folder")
        Dim TempFolder As String = Settings("TEMP FOLDER")
        If sender Is btnThermalLoad Then
            report.Load(ReportPath + "RouteLoadDetailThermal.rpt")
        Else
            report.Load(ReportPath + "RouteLoadDetail2.rpt")
        End If


        'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        report.SetParameterValue("Date", DTP1.Value.ToString("d"))
        report.SetParameterValue("Route", txtRoute.Text)
        If sender Is btnThermalLoad Then
            report.ExportToDisk(ExportFormatType.PortableDocFormat, TempFolder + "\ LOAD DETAILS " + txtRoute.Text + " Dated " + DTP1.Value.ToString("d") + ".PDF")
            report.PrintOptions.PrinterName = Settings("Thermal Printer")
            report.PrintToPrinter(1, False, 0, 0)
        Else
            report.ExportToDisk(ExportFormatType.PortableDocFormat, TempFolder + "\ LOAD DETAILS " + txtRoute.Text + " Dated " + DTP1.Value.ToString("d") + ".PDF")
            CrystalReportViewer1.ReportSource = report
        End If
        'MainPage.rptName = settings("Reports Folder") + "Cancelled Items.rpt"
        'MainPage.ReportName = "Cancelled Items"
        Dim report2 As New ReportDocument
        Dim SPO As String = ""
        report2.Load(ReportPath + "Cancelled Items.rpt")
        'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In report2.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        report2.SetParameterValue("Route", txtRoute.Text)
        report2.SetParameterValue("SDATE", DTP1.Value.ToString("d"))
        report2.SetParameterValue("COMPANY", "")
        report2.SetParameterValue("OSPO", SPO)
        report2.SetParameterValue("ProductID", "")
        report2.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\ " & SPO & " Cancelled Items " & Date.Today & " route " & txtRoute.Text & ".pdf")
        SPO = "SALMAN"
        report2.SetParameterValue("Route", txtRoute.Text)
        report2.SetParameterValue("SDATE", DTP1.Value.ToString("d"))
        report2.SetParameterValue("COMPANY", "")
        report2.SetParameterValue("OSPO", SPO)
        report2.SetParameterValue("ProductID", "")
        report2.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\ " & SPO & " Cancelled Items " & Date.Today & " route " & txtRoute.Text & ".pdf")
        SPO = "ARIF"
        report2.SetParameterValue("Route", txtRoute.Text)
        report2.SetParameterValue("SDATE", DTP1.Value.ToString("d"))
        report2.SetParameterValue("COMPANY", "")
        report2.SetParameterValue("OSPO", SPO)
        report2.SetParameterValue("ProductID", "")
        report2.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\ " & SPO & " Cancelled Items " & Date.Today & " route " & txtRoute.Text & ".pdf")
        'report.PrintToPrinter(1, False, 0, 0)

    End Sub
End Class
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class PeriodicReports
    Private Sub PeriodicReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDoc.Text = "Periodic Report - " + MainPage.LoginDetails
        dtpStart.Value = New DateTime(Now.Year, Now.Month, 1).AddMonths(-1)
        dtpEnd.Value = New DateTime(Now.Year, Now.Month, 1).AddDays(-1)
        lblReportName.Text = MainPage.ReportName
        Me.Text = MainPage.ReportName

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports folder") + "LastReceiptDays.rpt" Then
            txtRoute.Select()
            txtRoute.SelectAll()
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "SPO ORDER SUMMARY COMPANY WISE.rpt" Then
            dtpEnd.Value = Date.Now.AddDays(1)
            dtpStart.Value = Date.Now
        End If
        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "Turnover.rpt" Then
            dtpStart.Value = Date.Today
            cmbSPO.SelectAll()
            cmbSPO.Select()
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "SVSalesComissionReport.rpt" Then
            cmbSPO.Select()
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "Route Ledger 2.rpt" Then
            txtRoute.SelectAll()
            txtRoute.Select()
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "InActive Customers with Balance.rpt" Then
            txtDays.Text = 20
            txtDays.Enabled = True
            txtRoute.SelectAll()
            txtRoute.Select()
        End If

        If MainPage.ReportName = "SPO Sales Comission Report" Then
            dtpStart.Value = Today
            dtpEnd.Value = Today
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "Monthly Payable Summary.rpt" Then
            '    chkSummary.Visible = True
            '    lblEnd.Visible = True
            '    dtpEnd.Visible = True
            '    cmbMain.Visible = True
            '    rdALL.Visible = True
            '    rdEntry.Visible = True
            '    rdNoEntry.Visible = True
            Dim DT As DataTable = SQLData("SELECT DISTINCT MAIN FROM COA order by main")
            cmbMain.Items.Clear()
            cmbMain.Items.Add("ALL")
            For i = 0 To DT.Rows.Count - 1
                cmbMain.Items.Add(DT.Rows(i)(0))
            Next
            If frmLogin.User.ToUpper = "ADMIN" Then
                cmbMain.SelectedIndex = cmbMain.Items.IndexOf("TRADE CREDITORS")
                cmbSPO.Text = ""
            Else
                cmbMain.SelectedIndex = cmbMain.Items.IndexOf("TRADE DEBTORS")
                cmbSPO.Text = "%CLASSIC%"
            End If
        End If
        'If Settings("Reports Folder") + MainPage.rptName = settings("Reports Folder") + "Route Ledger 2.rpt" Then
        '    lblStart.Visible = False
        '    lblEnd.Visible = False
        '    dtpStart.Visible = False
        '    dtpEnd.Visible = False
        '    btnExport.Enabled = False
        '    lblRoute.Visible = False
        '    txtRoute.Visible = False
        '    lblDays.Visible = False
        '    txtDays.Visible = False
        '    cmbMain.Visible = False
        '    cmbSPO.Visible = False
        '    chkALL.Visible = False
        '    chkSummary.Visible = False
        '    rdALL.Visible = False
        '    rdEntry.Visible = False
        '    rdNoEntry.Visible = False
        '    txtRoute.Visible = True
        '    btnClose.Visible = True
        '    btnGenerate.Visible = True
        '    lblSPO.Visible = False
        '    cmbSPO.Visible = False
        '    lblEnd.Visible = False
        '    dtpEnd.Visible = False


        'End If
        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "Cancelled Items.rpt" Then
            dtpStart.Value = Today
            txtRoute.Select()
            txtRoute.SelectAll()
        End If
    End Sub


    Sub RouteLdgers()
        Dim Report As New ReportDocument
        Report.Load(Settings("Reports Folder") + MainPage.rptName)
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In Report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next

        Report.SetParameterValue("Route", txtRoute.Text)
        Report.SetParameterValue("SPO", cmbSPO.Text)
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.AllowedExportFormats = 1

    End Sub

    Sub LastReceiptDays()
        Dim Report As New ReportDocument
        Report.Load(Settings("Reports Folder") + MainPage.rptName)
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In Report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next

        Report.SetParameterValue("Route", txtRoute.Text)
        Report.SetParameterValue("SPO", cmbSPO.Text)
        Report.SetParameterValue("Days", txtDays.Text)
        Report.SetParameterValue("SDate", dtpStart.Value.ToString("d"))
        Report.SetParameterValue("EDate", dtpEnd.Value.ToString("d"))
        Dim FileName As String = Settings("Temp Folder") + txtRoute.Text + " Last Receipt Days " + cmbSPO.Text & " " & Today.ToString("d") & ".pdf"
        Report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.Zoom(1)
        CrystalReportViewer1.AllowedExportFormats = 1
    End Sub

    Sub PeriodicSummary()
        Dim Report As New ReportDocument
        Report.Load(Settings("Reports Folder") + MainPage.rptName)
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In Report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next

        Report.SetParameterValue("OpeningDate", dtpStart.Value)
        Report.SetParameterValue("ClosingDate", dtpEnd.Value)
        Report.SetParameterValue("Company", txtCompany.Text)
        Dim FileName As String = Settings("Temp Folder") + "Product Activity " & dtpStart.Value.ToString("d") & " To " & dtpEnd.Value.ToString("d") & ".pdf"
        Report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.AllowedExportFormats = 1
        CrystalReportViewer1.Zoom(1)
    End Sub

    Sub InActiveCustomers()
        Dim Report As New ReportDocument
        txtReportName.Text = MainPage.rptName
        Report.Load(Settings("Reports Folder") + MainPage.rptName)
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In Report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        Report.SetParameterValue("Route", txtRoute.Text)
        Report.SetParameterValue("Days", txtDays.Text)
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.AllowedExportFormats = 1
        CrystalReportViewer1.Zoom(1)
    End Sub

    Sub BillsAging()
        If txtCustomerID.Text = "" And txtRoute.Text = "" And cmbSPO.Text = "" Then
            MsgBox("Must Select some criteria first !")
            Return
        End If
        Dim Report As New ReportDocument
        Dim Days As String = txtDays.Text

        Report.Load(Settings("Reports Folder") + MainPage.rptName)
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In Report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        Dim AccId As String = "%"
        If txtCustomerID.Text <> "" Then
            AccId = txtCustomerID.Text
        Else
            AccId = "%"
        End If
        Dim dt As DataTable = SQLData("Select id,Subsidary,isnull(CreditDays,0) CreditDays,(Select sum(isnull(debit,0))-sum(isnull(credit,0)) from ledgers where acid=a.Id) CustomerBalance
,isnull((select sum(debit) from ledgers where acid=a.id and date>=DATEADD(d,-a.creditdays,getdate())),0) Bills
from coa a where subsidary like '" & txtCustomerName.Text & "%' and id like '" & AccId & "' and route like '" & txtRoute.Text & "%' and spo like '" & cmbSPO.Text & "%' and main='trade debtors'
group by Id,Subsidary,creditdays
having (select sum(isnull(debit,0))-sum(isnull(credit,0)) from ledgers where acid=a.Id)>isnull((select sum(debit) from ledgers where acid=a.id and date>=DATEADD(d,-a.creditdays,getdate())),0)")
        If dt.Rows.Count = 0 Then
            MsgBox("No Record Found with selected criteria !")
            Return
        End If
        Dim CusID As String = ""
        Dim CDays As String = ""
        Dim CusName As String = ""
        Dim FileName As String = ""
        For n = 0 To dt.Rows.Count - 1
            CusID = dt.Rows(n)("ID")
            CDays = dt.Rows(n)("CreditDays")
            CusName = dt.Rows(n)("Subsidary")
            Report.SetParameterValue("acid", CusID)
            Report.SetParameterValue("DaysLimit", CDays)
            FileName = Settings("Temp Folder") + "Aging " & CusID & "  " & CusName & " " & Now.Date & ".pdf"
            Report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)
            If txtCustomerID.Text <> "" Then
                CrystalReportViewer1.ReportSource = Nothing
                CrystalReportViewer1.ReportSource = Report
            End If
        Next


    End Sub

    Sub RouteCalls()
        If txtRoute.Text = Nothing Then
            Return
        End If
        Dim report As New ReportDocument
        report.Load(Settings("Reports Folder") + MainPage.rptName)
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        report.SetParameterValue("Route", txtRoute.Text)
        report.SetParameterValue("Years", 1)
        'Dim FileName As String = "D:\Google Drive ai\db backup\Invoice Temp\Route Calls " & txtRoute.Text & " Dated " & Now.Date & ".pdf"
        Dim FileName As String = Settings("Temp Folder") + "Route Calls " & txtRoute.Text & " Dated " & Now.Date & ".xls"
        report.ExportToDisk(ExportFormatType.Excel, FileName)
        CrystalReportViewer1.ReportSource = report

    End Sub

    Sub CustomerSalesCompanyWise()
        Dim report As New ReportDocument
        report.Load(Settings("Reports Folder") + MainPage.rptName)
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        report.SetParameterValue("company", txtCompany.Text)
        report.SetParameterValue("acid", txtCustomerID.Text)
        Dim FileName As String = Settings("Temp Folder") + "Customer Demand Company wise " & txtCustomerName.Text & " Dated " & Now.Date & ".pdf"
        report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)
        CrystalReportViewer1.ReportSource = report

    End Sub

    Sub SpoOrderSummary()
        Dim report As New ReportDocument
        report.Load(Settings("Reports Folder") + MainPage.rptName)
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        report.SetParameterValue("SPO", cmbSPO.Text)
        report.SetParameterValue("SDate", dtpStart.Value.ToString("d"))
        report.SetParameterValue("EDate", dtpEnd.Value.ToString("d"))
        report.SetParameterValue("Route", txtRoute.Text)
        Dim FileName As String = Settings("Temp Folder") + "SPO " & cmbSPO.Text & " " & txtRoute.Text & " Order Summary Dated " & Now.Date & ".pdf"
        report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)
        CrystalReportViewer1.ReportSource = report
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports folder") + "LastReceiptDays.rpt" Then
            LastReceiptDays()
        End If
        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports folder") + "Customer Bill Aging.rpt" Then
            BillsAging()
        End If
        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "SPO ORDER SUMMARY COMPANY WISE.rpt" Then
            SpoOrderSummary()
        End If


        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "Customer Sale Company Wise.rpt" Then
            CustomerSalesCompanyWise()
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "RouteCalls.rpt" Then
            RouteCalls()
        End If




        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "CustomerAgingReport.rpt" Then
            RouteAging()
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "Cancelled Items.rpt" Then
            Dim report As New ReportDocument
            report.Load(Settings("Reports Folder") + "Cancelled Items.rpt")
            'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            report.SetParameterValue("Route", txtRoute.Text)
            report.SetParameterValue("SDATE", dtpStart.Value.ToString("d"))
            report.SetParameterValue("COMPANY", txtCompany.Text)
            report.SetParameterValue("ProductID", txtPRID.Text)
            report.SetParameterValue("OSPO", cmbSPO.Text)
            report.ExportToDisk(ExportFormatType.PortableDocFormat, Settings("Temp Folder") + "Cancelled Items " & dtpStart.Value.ToString("d") & " route " & txtRoute.Text & ".pdf")
            CrystalReportViewer1.ReportSource = report

            Dim report2 As New ReportDocument
            report2.Load(Settings("Reports Folder") + "Cancelled Items Summary.rpt")
            'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In report2.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            report2.SetParameterValue("Route", txtRoute.Text)
            report2.SetParameterValue("SDATE", dtpStart.Value.ToString("d"))
            report2.SetParameterValue("eDATE", dtpEnd.Value.ToString("d"))
            report2.SetParameterValue("COMPANY", txtCompany.Text)
            report2.ExportToDisk(ExportFormatType.PortableDocFormat, Settings("Temp Folder") + "Cancelled Items Summary" & dtpStart.Value.ToString("d") & " To " & dtpEnd.Value.ToString("d") & " route " & txtRoute.Text & ".pdf")



        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "AllBooks.rpt" Then
            Dim report As New ReportDocument
            report.Load(Settings("Reports Folder") + "salebook2.rpt")
            'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            report.SetParameterValue("date", dtpStart.Value.ToString("d"))
            report.SetParameterValue("EDate", dtpEnd.Value.ToString("d"))
            report.ExportToDisk(ExportFormatType.PortableDocFormat, Settings("Temp Folder") + "SaleBook " & Now.Date & ".pdf")
            CrystalReportViewer1.ReportSource = report

            'report.Load(settings("Reports Folder") + "CashBook.rpt")
            'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            'report.SetParameterValue("BookDate", dtpStart.Value.ToString("d"))

            'report.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\CashBook " & Now.Date & ".pdf")


        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "Turnover.rpt" Then

            Dim report As New ReportDocument
            Dim report2 As New ReportDocument
            report.Load(Settings("Reports Folder") + MainPage.rptName)
            '   report2.Load(Settings("Reports Folder") + "TurnOverExcel.rpt")
            txtReportName.Text = MainPage.rptName
            'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next

            'For Each tb As Table In report2.Database.Tables
            '    tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            '    tb.ApplyLogOnInfo(tb.LogOnInfo)
            'Next

            'report.SetParameterValue("dt", dtpStart.Value.ToString("d"))
            report.SetParameterValue("route", txtRoute.Text)
            report.SetParameterValue("SPO", cmbSPO.Text)

            Dim days As String = txtDays.Text
            If days = "" Then
                days = 30
            End If
            report.SetParameterValue("Days", days)
            Dim FileName = MainPage.TempFolder + cmbSPO.Text + " " + txtRoute.Text + " TurnOver Report " + Date.Today + ".pdf"
            report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)

            'report2.SetParameterValue("route", txtRoute.Text)
            'report2.SetParameterValue("SPO", cmbSPO.Text)
            'FileName = MainPage.TempFolder + cmbSPO.Text + " " + txtRoute.Text + " TurnOver Report " + Date.Today + ".xls"
            'report2.ExportToDisk(ExportFormatType.Excel, FileName)

            CrystalReportViewer1.ReportSource = report

        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "SVSalesComissionReport.rpt" Then
            Dim report As New ReportDocument
            report.Load(Settings("Reports Folder") + MainPage.rptName)
            txtReportName.Text = MainPage.rptName
            '    report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next

            report.SetParameterValue("SDat", dtpStart.Value.ToString("d"))
            report.SetParameterValue("EDat", dtpEnd.Value.ToString("d"))
            report.SetParameterValue("SPO", cmbSPO.Text)
            'report.SetParameterValue("loc", cmbLocation.Text)
            report.SetParameterValue("Route", txtRoute.Text)
            CrystalReportViewer1.ReportSource = report
            Dim FileName As String
            FileName = MainPage.TempFolder + cmbSPO.Text + " Sales Bonus " + dtpStart.Value.ToString("MMM") + dtpStart.Value.ToString("yy") + ".pdf"
            report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "Product Activity.rpt" Then
            PeriodicSummary()

        End If


        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "InActive Customers with Balance.rpt" Then
            InActiveCustomers()
        End If
        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "Route Ledger 2.rpt" Then
            RouteLdgers()
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "Monthly Payable Summary.rpt" Then
            mps()
        End If


        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "SupplyVanSales.rpt" Then
            dsvs()
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "MonthlyRunsReportSummary.rpt" Then
            MonthlyRunsReport()
        End If
        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "SPO STG Sale.rpt" Then
            SPOComission()
        End If
        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "rptCustOmerActivityRoute.rpt" Then
            DailyRouteActivity()
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "BalanceIncrease.rpt" Then
            BalanceIncreae()
        End If


    End Sub


    Sub mps()
        Dim Report As New ReportDocument
        Dim summary As Integer = 0
        Dim NoEntry As Integer = 0
        Dim main As String = ""
        If chkSummary.Checked = True Then
            summary = 1
        Else
            summary = 0
        End If
        If rdALL.Checked = True Then
            NoEntry = 0
        ElseIf rdEntry.Checked = True Then
            NoEntry = 1
        ElseIf rdNoEntry.Checked = True Then
            NoEntry = 2
        End If
        If cmbMain.Text = "ALL" Then
            main = ""
        Else
            main = cmbMain.Text
        End If

        Report.Load(Settings("Reports Folder") + MainPage.rptName)
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In Report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next

        Report.SetParameterValue("SDate", dtpStart.Value)
        Report.SetParameterValue("EDate", dtpEnd.Text)
        Report.SetParameterValue("summary", summary)
        Report.SetParameterValue("mains", main)
        Report.SetParameterValue("NoEntry", NoEntry)
        Report.SetParameterValue("SPO", cmbSPO.Text)
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.AllowedExportFormats = 1
        CrystalReportViewer1.Zoom(1)
    End Sub

    Sub dsvs()
        Dim Report As New ReportDocument
        Report.Load(Settings("Reports Folder") + MainPage.rptName)
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In Report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next

        Report.SetParameterValue("SDat", dtpStart.Value)
        Report.SetParameterValue("EDat", dtpEnd.Text)
        Report.SetParameterValue("Loc", cmbLocation.Text)
        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            Report.SetParameterValue("Profit", txtDays.Text)
        Else
            Report.SetParameterValue("Profit", 0)
        End If

        Report.SetParameterValue("PP", txtRoute.Text)
        Report.SetParameterValue("SPO", cmbSPO.Text)

        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.AllowedExportFormats = 1
    End Sub

    Sub BalanceIncreae()
        Dim Report As New ReportDocument
        Report.Load(Settings("Reports Folder") + MainPage.rptName)
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In Report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        'Report.SetParameterValue("Days", txtDays.Text)
        Report.SetParameterValue("Route", txtRoute.Text)
        Report.SetParameterValue("OpeningDate", dtpStart.Value)
        Report.SetParameterValue("ClosingDate", dtpEnd.Text)
        Report.SetParameterValue("SPO", cmbSPO.Text)
        Report.SetParameterValue("Summary", 1)
        Report.SetParameterValue("totals", 1)
        If chkDecreaseBalance.Checked = True Then
            Report.SetParameterValue("all", 1)
        Else
            Report.SetParameterValue("all", 0)
        End If

        'If chkALL.Checked = True Then
        '    Report.SetParameterValue("all", 1)
        'Else
        '    Report.SetParameterValue("all", 0)
        'End If
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.AllowedExportFormats = 1
    End Sub

    Sub DailyRouteActivity()
        Dim Report As New ReportDocument
        Report.Load(Settings("Reports Folder") + MainPage.rptName)
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In Report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        Report.SetParameterValue("to", dtpStart.Value.ToString("d"))
        Report.SetParameterValue("rt", txtRoute.Text)
        CrystalReportViewer1.ReportSource = Report


    End Sub


    Sub MonthlyRunsReport()
        Dim report As New ReportDocument
        report.Load(Settings("Reports Folder") + MainPage.rptName)
        'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        report.SetParameterValue("OpeningDate", dtpStart.Value.ToString("d"))
        report.SetParameterValue("ClosingDate", dtpEnd.Value.ToString("d"))
        CrystalReportViewer1.ReportSource = report
        'CrystalReportViewer1.Zoom(3)
    End Sub

    Sub SPOComission()
        Dim report As New ReportDocument
        report.Load(Settings("Reports Folder") + MainPage.rptName)

        txtReportName.Text = MainPage.rptName
        'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        'report.VerifyDatabase()

        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table
        With crConnectionInfo
            .ServerName = frmLogin.MySqlServer
            .DatabaseName = frmLogin.MyDataBase
            .UserID = "sa"
            .Password = "Ai"
        End With

        CrTables = report.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next



        report.SetParameterValue("StartingDate", dtpStart.Value.ToString("d"))
        report.SetParameterValue("EndingDate", dtpEnd.Value.ToString("d"))
        report.SetParameterValue("SPO", cmbSPO.Text)
        report.ExportToDisk(ExportFormatType.PortableDocFormat, Settings("Temp folder") + "SPO " + cmbSPO.Text + " Sales From " + dtpStart.Value + " To " + dtpEnd.Value + ".pdf")
        CrystalReportViewer1.ReportSource = report

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmbSPO_Enter(sender As Object, e As EventArgs) Handles cmbSPO.Enter
        Dim dt As DataTable = SQLData("select distinct spo from coa where spo<>'' ")
        cmbSPO.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                cmbSPO.Items.Add(dt.Rows(i)("spo"))
            Next
        End If
    End Sub

    Private Sub txtDays_TextChanged(sender As Object, e As EventArgs) Handles txtDays.TextChanged
        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "SupplyVanSales.rpt" Then
            Return
        End If
        If Val(txtDays.Text) = 0 Then
            dtpStart.Value = New DateTime(Now.Year, 1, 1)
            dtpEnd.Value = Date.Now.AddDays(-1)
        Else
            dtpEnd.Value = Date.Now.AddDays(-1)
            dtpStart.Value = dtpEnd.Value.AddDays(-Val(txtDays.Text))
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "Customer Bill Aging.rpt" Then
            BillsAging()
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "Cancelled Items.rpt" Then
            Dim report As New ReportDocument
            report.Load(Settings("Reports Folder") + "Cancelled Items.rpt")
            'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            report.SetParameterValue("Route", txtRoute.Text)
            report.SetParameterValue("SDATE", dtpStart.Value.ToString("d"))
            report.SetParameterValue("ProductID", txtPRID.Text)
            report.SetParameterValue("OSPO", cmbSPO.Text)

            Dim filename As String = Settings("Temp folder") + "Cancelled Items " & dtpStart.Value.ToString("d") & " route " & txtRoute.Text & ".pdf"
            report.ExportToDisk(ExportFormatType.PortableDocFormat, Settings("Temp folder") + "Cancelled Items " & dtpStart.Value.ToString("d") & " route " & txtRoute.Text & ".pdf")
            'Form3.Whatsapp("923009760025", "")
            'Form3.SendFile(filename)
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "Points.rpt" Then
            Dim report As New ReportDocument
            report.Load(Settings("Reports Folder") + "points.rpt")
            'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            report.SetParameterValue("StartingDate", dtpStart.Value.ToString("d"))
            report.SetParameterValue("EndingDate", dtpEnd.Value.ToString("d"))
            report.ExportToDisk(ExportFormatType.Excel, Settings("Temp folder") + "Points From " & dtpStart.Value.ToString("d") & " to " & dtpEnd.Value.ToString("d") & ".xls")
            MsgBox("Points File Exported")
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "AllBooks.rpt" Then
            Dim report As New ReportDocument
            report.Load(Settings("Reports Folder") + "salebook2.rpt")
            'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            report.SetParameterValue("date", dtpStart.Value.ToString("d"))
            report.SetParameterValue("EDate", dtpEnd.Value.ToString("d"))
            report.ExportToDisk(ExportFormatType.PortableDocFormat, Settings("Temp folder") + "SaleBook " & Now.Date & ".pdf")
            'CrystalReportViewer1.ReportSource = report

            report.Load(Settings("Reports Folder") + "CashBook.rpt")
            'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            report.SetParameterValue("BookDate", dtpStart.Value.ToString("d"))
            report.ExportToDisk(ExportFormatType.PortableDocFormat, Settings("Temp folder") + "CashBook " & Now.Date & ".pdf")


        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "Turnover.rpt" Then
            Dim report As New ReportDocument
            report.Load(Settings("Reports Folder") + MainPage.rptName)
            txtReportName.Text = MainPage.rptName
            'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            'report.SetParameterValue("dt", dtpStart.Value.ToString("d"))
            report.SetParameterValue("route", txtRoute.Text)
            report.SetParameterValue("SPO", cmbSPO.Text)
            Dim FileName As String
            FileName = MainPage.TempFolder + txtRoute.Text + " TurnOver Report " + dtpStart.Value.ToString("d") + ".pdf"
            report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "SVSalesComissionReport.rpt" Then
            Dim report As New ReportDocument
            report.Load(Settings("Reports Folder") + MainPage.rptName)
            txtReportName.Text = MainPage.rptName
            'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            report.SetParameterValue("SDat", dtpStart.Value.ToString("d"))
            report.SetParameterValue("EDat", dtpEnd.Value.ToString("d"))
            report.SetParameterValue("Route", txtRoute.Text)
            'report.SetParameterValue("SPO", cmbSPO.Text)
            'report.SetParameterValue("loc", cmbLocation.Text)
            Dim FileName As String
            If Not MainPage.TempFolder.EndsWith("/") Then
                MainPage.TempFolder += "/"
            End If
            FileName = MainPage.TempFolder + "Supply Van Sales Bonus " + dtpStart.Value.ToString("MMM") + "-" + dtpStart.Value.ToString("yy") + ".pdf"
            report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "MonthlyRunsReportSummary.rpt" Then
            Dim report As New ReportDocument
            report.Load(Settings("Reports Folder") + "MonthlyRunsReportSummaryExcel.rpt")
            'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            report.SetParameterValue("OpeningDate", dtpStart.Value.ToString("d"))
            report.SetParameterValue("ClosingDate", dtpEnd.Value.ToString("d"))
            report.ExportToDisk(ExportFormatType.Excel, Settings("Temp folder") + "Monthly Runs Report " & dtpStart.Value.ToString("MMMM") & ".xls ")
            dtpStart.Select()
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "InActive Customers with Balance.rpt" Then
            Dim Report As New ReportDocument
            txtReportName.Text = MainPage.rptName
            Report.Load(Settings("Reports Folder") + MainPage.rptName)
            'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In Report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            Report.SetParameterValue("Route", txtRoute.Text)
            Report.SetParameterValue("Days", txtDays.Text)
            Dim FileName As String
            FileName = MainPage.TempFolder + txtRoute.Text + " InActive Customers " + Today.ToString("d") + ".pdf"
            Report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)
            txtRoute.SelectAll()
            txtRoute.Select()
        End If

        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "Route Ledger 2.rpt" Then
            Dim Report As New ReportDocument
            txtReportName.Text = MainPage.rptName
            Report.Load(Settings("Reports Folder") + MainPage.rptName)
            'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In Report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            Report.SetParameterValue("Route", txtRoute.Text)
            Dim CSPo As String = cmbSPO.Text
            Report.SetParameterValue("SPO", CSPo)
            'Report.SetParameterValue("Days", txtDays.Text)
            Dim FileName As String
            If Not MainPage.TempFolder.EndsWith("\") Then
                MainPage.TempFolder += "\"
            End If
            FileName = MainPage.TempFolder + txtRoute.Text + " Route Ledgers " + Today.ToString("d") + ".pdf"
            Report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)
            'MsgBox("Report Exported")
            txtRoute.SelectAll()
            txtRoute.Select()
        End If
        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "SPO Sales Comission 2.rpt" Then
            Dim report As New ReportDocument
            report.Load(Settings("Reports Folder") + MainPage.rptName)
            txtReportName.Text = MainPage.rptName
            'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            report.SetParameterValue("StartingDate", dtpStart.Value.ToString("d"))
            report.SetParameterValue("EndingDate", dtpEnd.Value.ToString("d"))
            'report.SetParameterValue("SPO", cmbSPO.Text)
            report.ExportToDisk(ExportFormatType.PortableDocFormat, Settings("Temp folder") + "SPO Sales From " + dtpStart.Value + " To " + dtpEnd.Value + ".pdf")
        End If
        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "BalanceIncrease.rpt" Then
            Dim Report As New ReportDocument
            Report.Load(Settings("Reports Folder") + MainPage.rptName)

            Dim crtableLogoninfos As New TableLogOnInfos
            Dim crtableLogoninfo As New TableLogOnInfo
            Dim crConnectionInfo As New ConnectionInfo
            Dim CrTables As Tables
            Dim CrTable As Table
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

            'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            'Report.SetParameterValue("Days", txtDays.Text)
            Report.SetParameterValue("Route", txtRoute.Text)
            Report.SetParameterValue("OpeningDate", dtpStart.Value)
            Report.SetParameterValue("ClosingDate", dtpEnd.Text)
            Report.SetParameterValue("SPO", cmbSPO.Text)
            Report.SetParameterValue("Summary", 1)
            If chkDecreaseBalance.Checked Then
                Report.SetParameterValue("all", 1)
            Else
                Report.SetParameterValue("all", 0)
            End If
            Report.SetParameterValue("totals", 1)


            Report.ExportToDisk(ExportFormatType.PortableDocFormat, Settings("Temp folder") + txtRoute.Text & " Balance Increase " & dtpStart.Value.ToString("d") & " to " & dtpEnd.Value.ToString("d") & ".pdf ")
            txtRoute.Select()
            txtRoute.SelectAll()
        End If
        If Settings("Reports Folder") + MainPage.rptName = Settings("Reports Folder") + "SupplyVanSales.rpt" Then
            Dim Report As New ReportDocument
            Report.Load(Settings("Reports Folder") + MainPage.rptName)
            'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            Dim crtableLogoninfos As New TableLogOnInfos
            Dim crtableLogoninfo As New TableLogOnInfo
            Dim crConnectionInfo As New ConnectionInfo
            Dim CrTables As Tables
            Dim CrTable As Table
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


            Report.SetParameterValue("SDat", dtpStart.Value)
            Report.SetParameterValue("EDat", dtpEnd.Text)
            Report.SetParameterValue("Loc", cmbLocation.Text)

            If frmLogin.UserLevel.ToUpper = "ADMIN" Then
                Report.SetParameterValue("Profit", txtDays.Text)
            Else
                Report.SetParameterValue("Profit", 0)
            End If

            Report.SetParameterValue("PP", txtRoute.Text)
            Report.SetParameterValue("SPO", cmbSPO.Text)
            Report.ExportToDisk(ExportFormatType.PortableDocFormat, Settings("Temp folder") + "Supply Sales " & cmbSPO.Text & " From " & dtpStart.Value.ToString("d") & " to " & dtpEnd.Value.ToString("d") & ".pdf ")
            cmbLocation.SelectAll()
            cmbLocation.Select()

        End If
        MsgBox("File Exported !")

    End Sub


    Private Sub dtpStart_Leave(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged

        dtpEnd.Value = New DateTime(dtpStart.Value.Year, dtpStart.Value.Month, 1).AddMonths(1).AddDays(-1)

    End Sub

    Private Sub rd30Days_CheckedChanged(sender As Object, e As EventArgs) Handles rd30Days.CheckedChanged
        dtpStart.Value = Today.Date.AddDays(-30)
        dtpEnd.Value = Today.Date.AddDays(+1)
    End Sub

    Private Sub rdCurrent_CheckedChanged(sender As Object, e As EventArgs) Handles rdCurrent.CheckedChanged
        dtpStart.Value = New DateTime(Now.Year, Now.Month, 1)
        dtpEnd.Value = Today.Date.AddDays(+1)
    End Sub

    Private Sub rd6Months_CheckedChanged(sender As Object, e As EventArgs) Handles rd6Months.CheckedChanged
        dtpStart.Value = Today.Date.AddDays(-180)
        dtpEnd.Value = Today.Date.AddDays(+1)
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        dtpStart.Value = Today.Date.AddYears(-20)
        dtpEnd.Value = Today.Date.AddDays(+1)
    End Sub

    Sub RouteAging()
        Dim report As New ReportDocument

        report.Load(Settings("Reports Folder") + "CustomerAgingReport.rpt")
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        Dim dt As DataTable = SQLData("select subsidary,spo,route from coa where spo like '%" & cmbSPO.Text & "%' and subsidary like '%" & txtCustomerName.Text & "%' and  route like '%" & txtRoute.Text & "%'       ")
        If dt.Rows.Count > 0 Then
            Dim CusName As String
            If dt.Rows.Count > 0 Then
                CusName = dt.Rows(0)("Subsidary")
            Else
                CusName = "--"
            End If
            If txtCustomerName.Text = "" Then
                CusName = " All Route customers "
            End If
            Dim SP As String = dt.Rows(0)("SPO")
            Dim RT As String = dt.Rows(0)("Route")
            RT = txtRoute.Text
            SP = cmbSPO.Text
            'report.SetDatabaseLogon("sa", "Ai", MySqlServer, MyDataBase)
            For Each tb As Table In report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            report.SetParameterValue("SPO", cmbSPO.Text)
            report.SetParameterValue("CustomerName", txtCustomerName.Text)
            report.SetParameterValue("Route", txtRoute.Text)
            CrystalReportViewer1.ReportSource = report
            report.ExportToDisk(ExportFormatType.PortableDocFormat, Settings("Temp Folder") + "Aging " & CusName & " , " & RT & ", " & SP & ", " & Now.Date.ToString("d") & ".pdf")
            txtCustomerName.Select()
            txtCustomerName.SelectAll()
            DisappearingMsgBox.Show()
        Else
            MsgBox("Not Record to export !")
        End If

    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim report As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table
        'SPO SALE REPORT
        If cmbSPO.Text = Nothing Then
            MsgBox("SELECT SPO FIRST !")
            Return
        Else
            MainPage.rptName = Settings("Reports Folder") + "SPO STG Sale.rpt"
            report.Load(Settings("Reports Folder") + MainPage.rptName)
            txtReportName.Text = MainPage.rptName
            'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)

            With crConnectionInfo
                .ServerName = frmLogin.MySqlServer
                .DatabaseName = frmLogin.MyDataBase
                .UserID = "sa"
                .Password = "Ai"
            End With
            CrTables = report.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next


            Dim SDAT As Date = New DateTime(Now.Year, Now.Month, 1)
            Dim EDAT As Date = Date.Today
            report.SetParameterValue("StartingDate", SDAT)
            report.SetParameterValue("EndingDate", EDAT)
            report.SetParameterValue("SPO", cmbSPO.Text)
            report.ExportToDisk(ExportFormatType.PortableDocFormat, Settings("Temp Folder") + "SPO " + cmbSPO.Text + " Sales From " + SDAT + " To " + EDAT + ".pdf")
        End If


        'TurnOver Report

        MainPage.rptName = Settings("Reports Folder") + "Turnover.rpt"

        txtReportName.Text = MainPage.rptName
        'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        report.Load(Settings("Reports Folder") + MainPage.rptName)
        With crConnectionInfo
            .ServerName = frmLogin.MySqlServer
            .DatabaseName = frmLogin.MyDataBase
            .UserID = "sa"
            .Password = "Ai"
        End With
        CrTables = report.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        'report.SetParameterValue("dt", dtpStart.Value.ToString("d"))
        report.SetParameterValue("route", txtRoute.Text)
        Dim FileName As String
        FileName = MainPage.TempFolder + txtRoute.Text + " TurnOver Report " + Today.ToString("d") + ".pdf"

        report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)

        'InActive Customer Report
        'Dim Report As New ReportDocument
        MainPage.rptName = Settings("Reports Folder") + "InActive Customers with Balance.rpt"
        If txtDays.Text = "" Then
            txtDays.Text = "20"
        End If
        txtReportName.Text = MainPage.rptName
        report.Load(Settings("Reports Folder") + MainPage.rptName)
        'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)

        With crConnectionInfo
            .ServerName = frmLogin.MySqlServer
            .DatabaseName = frmLogin.MyDataBase
            .UserID = "sa"
            .Password = "Ai"
        End With
        CrTables = report.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
        report.SetParameterValue("Route", txtRoute.Text)
        report.SetParameterValue("Days", txtDays.Text)
        'Dim FileName As String
        FileName = MainPage.TempFolder + txtRoute.Text + " InActive Customers " + Today.ToString("d") + ".pdf"
        report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)

        'Route Ledgers
        MainPage.rptName = Settings("Reports Folder") + "Route Ledger 2.rpt"
        txtReportName.Text = MainPage.rptName
        report.Load(Settings("Reports Folder") + MainPage.rptName)
        'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)

        With crConnectionInfo
            .ServerName = frmLogin.MySqlServer
            .DatabaseName = frmLogin.MyDataBase
            .UserID = "sa"
            .Password = "Ai"
        End With
        CrTables = report.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
        report.SetParameterValue("Route", txtRoute.Text)
        'Report.SetParameterValue("Days", txtDays.Text)
        'Dim FileName As String
        FileName = MainPage.TempFolder + txtRoute.Text + " Route Ledgers " + Today.ToString("d") + ".pdf"
        report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)

        'Route Aging
        MainPage.rptName = Settings("Reports Folder") + "CustomerAgingReport.rpt"
        report.Load(Settings("Reports Folder") + MainPage.rptName)
        'Dim dt As DataTable = SQLData("select subsidary,spo,route from coa where spo like '%" & txtSPO.Text & "%' and subsidary like '%" & txtCustomerName.Text & "%' and  route like '%" & txtRoute.Text & "%'       ")
        'If dt.Rows.Count > 0 Then
        '    Dim CusName As String
        '    If dt.Rows.Count > 0 Then
        '        CusName = dt.Rows(0)("Subsidary")
        '    Else
        '        CusName = "--"
        '    End If
        '    If txtCustomerName.Text = "" Then
        '        CusName = " All Route customers "
        '    End If
        '    Dim SP As String = dt.Rows(0)("SPO")
        '    Dim RT As String = dt.Rows(0)("Route")
        Dim RT As String = txtRoute.Text
        '    SP = txtSPO.Text
        Dim CusName As String = " All Route customers "
        'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        report.SetParameterValue("SPO", cmbSPO.Text)
        report.SetParameterValue("CustomerName", "")
        report.SetParameterValue("Route", txtRoute.Text)
        FileName = MainPage.TempFolder + "Aging " & CusName & " , " & RT & ", " & Now.Date.ToString("d") & ".pdf"
        report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)
        'End If

        MsgBox("All Reports Exported")
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCustomerID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCustomerID.Text = "" Then
                frmPartySearch.ShowDialog()
                txtCustomerID.Text = frmPartySearch.acID
                txtCustomerName.Text = frmPartySearch.CusName
            End If
        End If
    End Sub

    Private Sub txtPRID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPRID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPRID.Text = "" Then
                e.Handled = True
                MainPage.CustID = txtCustomerID.Text
                ProductSearch.ShowDialog()
                'MsgBox(PS.PrID)
                txtPRID.Text = ProductSearch.prIDtxt
                txtProductName.Text = ProductSearch.prName
                If txtPRID.Text <> "" Then
                    SendKeys.Send("{TAB}")
                End If
            End If
        End If
    End Sub
End Class
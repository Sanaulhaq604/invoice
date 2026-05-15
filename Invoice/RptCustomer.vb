Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class RptCustomer
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles txtCompany.Enter, txtrdate.Enter, txtProduct.Enter
        If txtCustomerID.Text = "" Then
            frmPartySearch.ShowDialog()
            txtCustomerID.Text = frmPartySearch.acID
            txtCustomerName.Text = frmPartySearch.CusName + ", " + frmPartySearch.CusAddress
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If MainPage.rptName = settings("Reports Folder") + "Customer Bill Aging.rpt" Then
            Aging()
            Return
        End If
        If MainPage.rptName = settings("Reports Folder") + "Periodic Pending Orders Report.rpt" Then
            PendingOrders()
            Return
        End If


        Try
            Dim Report As New ReportDocument
            Dim dis As String = txtDiscP2.Text

            Report.Load(Settings("Reports Folder") + MainPage.rptName)
            'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In Report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next

            Report.SetParameterValue("StartDate", DTPStart.Value.ToString("d"))
            Report.SetParameterValue("EndDate", DTPEnd.Value.ToString("d"))
            Report.SetParameterValue("AccID", txtCustomerID.Text)

            If MainPage.rptName = "CustomerSalesWithDiscount.rpt" Then
                Report.SetParameterValue("Comp", txtCompany.Text)
                Report.SetParameterValue("ProductName", txtProduct.Text)
                Report.SetParameterValue("DiscP2ParaString", dis)
                If chkReturns.Checked = True Then
                    Report.SetParameterValue("Returns", 1)
                Else
                    Report.SetParameterValue("Returns", 0)
                End If

            End If
            Dim FileName As String = Settings("Temp Folder") + "Pending Items " & txtCustomerName.Text & " from " & DTPStart.Value.ToString("d") & " to " & DTPEnd.Value.ToString("d") & ".pdf"
            'MsgBox(FileName)
            Report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)

            CrystalReportViewer1.ReportSource = Report
            'CrystalReportViewer1.AllowedExportFormats = ExportFormatType.PortableDocFormat

            'CrystalReportViewer1.expo

            '            Report.ExportOptions
            '           CrystalReportViewer1.AllowedExportFormats
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub txtCustomerID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCustomerID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCustomerID.Text = "" Then
                frmPartySearch.ShowDialog()
                txtCustomerID.Text = frmPartySearch.acID
                txtCustomerName.Text = frmPartySearch.CusName + ", " + frmPartySearch.CusAddress
            End If
        End If
    End Sub



    Private Sub txtCustomerID_TextChanged(sender As Object, e As EventArgs) Handles txtCustomerID.TextChanged

    End Sub

    Private Sub txtCustomerID_Leave(sender As Object, e As EventArgs) Handles txtCustomerID.Leave
        If txtCustomerID.Text <> "" Then
            Dim rdtable As DataTable = SQLData("SELECT isnull(RunsDate,'') RunsDate,isnull(ocell,'') ocell,isnull(creditdays,0) creditdays,Subsidary FROM COA WHERE ID='" & txtCustomerID.Text & "'")
            If rdtable.Rows.Count > 0 Then
                txtCustomerName.Text = rdtable.Rows(0)("Subsidary")
                txtrdate.Text = rdtable.Rows(0)("RunsDate")
                txtMobile.Text = rdtable.Rows(0)("ocell")
                If MainPage.rptName = settings("Reports Folder") + "Customer Bill Aging.rpt" Then
                    txtDiscP2.Text = rdtable.Rows(0)("creditdays")
                Else
                    txtDiscP2.Text = ""
                End If

            Else
                txtrdate.Text = ""
                txtMobile.Text = ""
            End If
            If Convert.ToDateTime(txtrdate.Text) < Convert.ToDateTime("01.06.2020") Then
                txtrdate.BackColor = Color.Red
                txtrdate.ForeColor = Color.White
            Else
                txtrdate.BackColor = Color.White
                txtrdate.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub cmdChangeRunsDate_Click(sender As Object, e As EventArgs) Handles cmdChangeRunsDate.Click
        SQLData("update coa set runsdate='" & DTPStart.Value & "'  where id='" & txtCustomerID.Text & "'   ")
        Dim rdtable As DataTable = SQLData("SELECT isnull(RunsDate,'') RunsDate FROM COA WHERE ID='" & txtCustomerID.Text & "'")
        If rdtable.Rows.Count > 0 Then
            txtrdate.Text = rdtable.Rows(0)("RunsDate")
            If Convert.ToDateTime(txtrdate.Text) < Convert.ToDateTime("01.06.2020") Then
                txtrdate.BackColor = Color.Red
                txtrdate.ForeColor = Color.White
            Else
                txtrdate.BackColor = Color.White
                txtrdate.ForeColor = Color.Black
            End If
        Else
            txtrdate.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        Dim Report As New ReportDocument
        Dim dis As String = txtDiscP2.Text
        MsgBox(MainPage.rptName)
        Report.Load(Settings("REPORTS FOLDER") + MainPage.rptName)
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In Report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next

        If MainPage.rptName = settings("Reports Folder") + "Customer Bill Aging.rpt" Then
            Report.SetParameterValue("acid", txtCustomerID.Text.ToString())
            Report.SetParameterValue("DaysLimit", txtDiscP2.Text)


            Report.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\Aging " & txtCustomerID.Text & "  " & txtCustomerName.Text & " " & Now.Date & ".pdf")
            txtCustomerID.Select()
            txtCustomerID.SelectAll()
            Return
        End If

        'Report.SetParameterValue("Comp", txtCompany.Text)
        'Report.SetParameterValue("ProductName", txtProduct.Text)
        'Report.SetParameterValue("DiscP2ParaString", txtDiscP2.Text)
        If MainPage.rptName <> settings("Reports Folder") + "TotalPeriodicRuns.rpt" Then
            If chkReturns.Checked = True Then
                Report.SetParameterValue("Returns", 1)
            Else
                Report.SetParameterValue("Returns", 0)
            End If
            Report.SetParameterValue("OpeningDate", DTPStart.Value.ToString("d"))
            Report.SetParameterValue("ClosingDate", DTPEnd.Value.ToString("d"))
            Report.SetParameterValue("Party", txtCustomerID.Text)


            Report.SetParameterValue("Comp", txtCompany.Text)
            Report.SetParameterValue("ProductName", txtProduct.Text)
            Report.SetParameterValue("DiscP2ParaString", dis)



            If DTPStart.Value.ToString("MMM") = DTPEnd.Value.ToString("MMM") Then
                'Report.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\Runs " & txtCustomerName.Text & " " & DTPStart.Value.ToString("MMM") & ".pdf")
                Report.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\Customer Sales " & txtCustomerName.Text & " " & DTPStart.Value.ToString("MMM") & ".pdf")
            Else
                'Report.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\CustomerSales.pdf")
                Report.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\Customer Sales " & txtCustomerName.Text & " " & DTPStart.Value.ToString("MMM") & " - " & DTPEnd.Value.ToString("MMM") & ".pdf")
            End If
            Return

        End If
        Report.SetParameterValue("OpeningDate", DTPStart.Value.ToString("d"))
        Report.SetParameterValue("ClosingDate", DTPEnd.Value.ToString("d"))
        Report.SetParameterValue("Party", txtCustomerID.Text)

        If MainPage.rptName = settings("Reports Folder") + "CustomerSalesWithDiscount.rpt" Then
            Report.SetParameterValue("Comp", txtCompany.Text)
            If chkReturns.Checked = True Then
                Report.SetParameterValue("Returns", 1)
            Else
                Report.SetParameterValue("Returns", 0)
            End If
            Report.SetParameterValue("Comp", txtCompany.Text)
            Report.SetParameterValue("ProductName", txtProduct.Text)
            Report.SetParameterValue("DiscP2ParaString", "")
            If chkReturns.Checked = True Then
                Report.SetParameterValue("Returns", 1)
            Else
                Report.SetParameterValue("Returns", 0)
            End If

        End If


        If DTPStart.Value.ToString("MMM") = DTPEnd.Value.ToString("MMM") Then
            'Report.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\Runs " & txtCustomerName.Text & " " & DTPStart.Value.ToString("MMM") & ".pdf")
            Report.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\Customer Sales " & txtCustomerName.Text & " " & DTPStart.Value.ToString("MMM") & ".pdf")
        Else
            'Report.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\CustomerSales.pdf")
            Report.ExportToDisk(ExportFormatType.PortableDocFormat, "D:\Google Drive ai\db backup\Invoice Temp\Customer Sales " & txtCustomerName.Text & " " & DTPStart.Value.ToString("MMM") & " - " & DTPEnd.Value.ToString("MMM") & ".pdf")
        End If
        txtCustomerID.Select()
        txtCustomerID.SelectAll()

    End Sub


    Private Sub txtMobile_Leave(sender As Object, e As EventArgs) Handles txtMobile.Leave
        If txtCustomerID.Text <> "" And txtMobile.Text <> "" Then
            SQLData("Update COA set ocell='" & txtMobile.Text & "' where id='" & txtCustomerID.Text & "'  ")
        End If

    End Sub

    Sub PendingOrders()
        Dim report As New ReportDocument
        report.Load(MainPage.rptName)
        'report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        report.SetParameterValue("AccID", txtCustomerID.Text)
        report.SetParameterValue("StartDate", DTPStart.Value.ToString("d"))
        report.SetParameterValue("EndDate", DTPEnd.Value.ToString("d"))
        Dim FileName As String = Settings("Temp Folder") + " Pending Items " & txtCustomerName.Text & " from " & DTPStart.Value.ToString("d") & " to " & DTPEnd.Value.ToString("d") & ".pdf"
        MsgBox(FileName)
        report.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)

        CrystalReportViewer1.ReportSource = report

    End Sub

    Private Sub RptCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'DTPStart.Value = Today.AddDays(-30)
        'New DateTime(Now.Year, Now.Month - 1, 1)
        DTPStart.Value = New DateTime(Now.Year, Now.Month, 1).AddMonths(-1)
        DTPEnd.Value = New DateTime(Now.Year, Now.Month, 1).AddDays(-1)

        If MainPage.rptName = settings("Reports Folder") + "Periodic Pending Orders Report.rpt" Then
            lblProduct.Visible = False
            lblMobile.Visible = False
            lblCompany.Visible = False
            lblDisc.Visible = False
            lblrDate.Visible = False

            txtCompany.Visible = False
            txtDiscP2.Visible = False
            txtProduct.Visible = False
            txtrdate.Visible = False
            cmdChangeRunsDate.Visible = False
            chkReturns.Visible = False

        End If


        If MainPage.rptName = settings("Reports Folder") + "Customer Bill Aging.rpt" Then
            lblStart.Visible = False
            lblEnd.Visible = False
            lblCompany.Visible = False
            lblProduct.Visible = False
            lblDisc.Text = "Credit Days"
            lblDisc.Visible = True


            txtCompany.Visible = False
            txtProduct.Visible = False
            txtDiscP2.Visible = True

            DTPStart.Visible = False
            DTPEnd.Visible = False

            chkReturns.Visible = False

        End If
        If MainPage.rptName = settings("Reports Folder") + "TotalPeriodicRuns.rpt" Then
            lblDisc.Visible = False
            txtDiscP2.Visible = False
        End If


    End Sub

    Sub Aging()
        Dim Report As New ReportDocument
        Dim dis As String = txtDiscP2.Text

        Report.Load(MainPage.rptName)
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In Report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        Report.SetParameterValue("acid", txtCustomerID.Text.ToString)
        Report.SetParameterValue("DaysLimit", txtDiscP2.Text)
        CrystalReportViewer1.ReportSource = Report
    End Sub


    Private Sub RptCustomer_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtCustomerID.Select()
        txtCustomerID.SelectAll()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles lblMobile.Click, lblDisc.Click

    End Sub
End Class
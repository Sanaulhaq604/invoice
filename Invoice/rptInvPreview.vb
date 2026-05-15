Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class rptInvPreview

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub rptInvPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn1.Left = rptInvPreview.ActiveForm.Width - btn1.Width
        If MainPage.rptName = settings("Reports Folder") + "rptInvoice3A5.rpt" Or MainPage.rptName = settings("Reports Folder") + "rptInvoice3A5WithRuns.rpt" Or MainPage.rptName = settings("Reports Folder") + "rptInvoice3A5FIT.rpt" Or MainPage.rptName = settings("Reports Folder") + "rptInvoice3A5Local.rpt" Or MainPage.rptName = settings("Reports Folder") + "rptInvoice3A5Pending.rpt" Or MainPage.rptName = settings("Reports Folder") + "rptInvoice3A5NetRate.rpt" Or MainPage.rptName = settings("Reports Folder") + "rptInvoiceClaim.rpt" Or MainPage.rptName = settings("Reports Folder") + "rptInvoiceReceipt.rpt" Then
            InvPreview()
        End If
        If MainPage.rptName = settings("Reports Folder") + "InvoiceList.rpt" Then
            InvListPreview()
        End If
        If MainPage.rptName = settings("Reports Folder") + "rptCustOmerActivityRoute.rpt" Then
            DailyRouteActivity()
        End If
        If MainPage.rptName = settings("Reports Folder") + "rptCustOmerActivityRoute.rpt" Then
            DailyRouteActivity()
        End If
        If MainPage.rptName = settings("Reports Folder") + "Product Price List.rpt" Then
            PriceList()
        End If

    End Sub

    Sub PriceList()
        Try
            Dim cryrpt As New ReportDocument
            cryrpt.Load(MainPage.rptName)
            'cryrpt.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In cryrpt.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next

            cryrpt.SetParameterValue("Company", MainPage.Company)
            cryrpt.SetParameterValue("Dead", MainPage.DocNumber)
            cryrpt.SetParameterValue("Name", MainPage.PName)
            cryrpt.SetParameterValue("Category", MainPage.PCategory)
            cryrpt.SetParameterValue("HighLighted", MainPage.HighLighted)
            Dim HL As String = ""
            If MainPage.HighLighted <> "" Then
                HL = " HighLighted"
            Else
                HL = ""
            End If
            If MainPage.Company <> "" Or HL <> "" Then
                cryrpt.ExportToDisk(ExportFormatType.PortableDocFormat, MainPage.TempFolder + " " + MainPage.Company + HL + " Price List " + Date.Today + ".pdf")
            End If


            CrystalReportViewer1.ReportSource = cryrpt
            'CrystalReportViewer1.Zoom(1)
            CrystalReportViewer1.Refresh()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub DailyRouteActivity()
        Try
            Dim cryrpt As New ReportDocument
            cryrpt.Load(MainPage.rptName)
            'cryrpt.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In cryrpt.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next

            'cryrpt.SetParameterValue("Customer", frmInvoiceList.txtCustomer.Text)
            'cryrpt.SetParameterValue("Descp", frmInvoiceList.txtDescription.Text)
            'cryrpt.SetParameterValue("SDate", frmInvoiceList.DTPStart.Value.ToString("d"))
            'cryrpt.SetParameterValue("Edate", frmInvoiceList.DTPEnd.Value.ToString("d"))
            'cryrpt.SetParameterValue("rn", frmInvoiceList.txtRoute.Text)

            'cryrpt.SetParameterValue("CompanyName", 0)
            CrystalReportViewer1.ReportSource = cryrpt
            CrystalReportViewer1.Zoom(1)
            CrystalReportViewer1.Refresh()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub InvListPreview()
        Try
            Dim cryrpt As New ReportDocument
            cryrpt.Load(MainPage.rptName)
            'cryrpt.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In cryrpt.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            cryrpt.SetParameterValue("Customer", frmInvoiceList.txtCustomer.Text)
            cryrpt.SetParameterValue("Descp", frmInvoiceList.txtDescription.Text)
            cryrpt.SetParameterValue("SDate", frmInvoiceList.DTPStart.Value.ToString("d"))
            cryrpt.SetParameterValue("Edate", frmInvoiceList.DTPEnd.Value.ToString("d"))
            cryrpt.SetParameterValue("rn", frmInvoiceList.txtRoute.Text)
            CrystalReportViewer1.AllowedExportFormats = (CrystalDecisions.Shared.ViewerExportFormats.AllFormats Xor CrystalDecisions.Shared.ViewerExportFormats.RptFormat)
            'cryrpt.SetParameterValue("CompanyName", 0)
            CrystalReportViewer1.ReportSource = cryrpt
            'CrystalReportViewer1.AllowedExportFormats = ViewerExportFormats.PdfFormat
            CrystalReportViewer1.Zoom(1)
            CrystalReportViewer1.Refresh()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Sub InvPreview()
        Try
            Dim cryrpt As New ReportDocument
            'MsgBox(MainPage.rptName)
            cryrpt.Load(MainPage.rptName)

            'cryrpt.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In cryrpt.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            cryrpt.SetParameterValue("DocNumber", MainPage.DocNumber)
            cryrpt.SetParameterValue("RECPT", MainPage.Rcpt)
            cryrpt.SetParameterValue("PreBalance", MainPage.PreviousBalance)
            cryrpt.SetParameterValue("CompanyName", 0)
            CrystalReportViewer1.AllowedExportFormats = ViewerExportFormats.PdfFormat
            CrystalReportViewer1.ReportSource = cryrpt
            'CrystalReportViewer1.Zoom(1)
            CrystalReportViewer1.Refresh()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub Preview2()




    End Sub

    Private Sub CrystalReportViewer1_KeyDown(sender As Object, e As KeyEventArgs) Handles CrystalReportViewer1.KeyDown
        e.Handled = True
        Me.Close()
    End Sub

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn1.Click

        Me.Close()
    End Sub

End Class
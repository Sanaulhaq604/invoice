Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared



Public Class rfEstimates

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnExport.Click

        Try
            Dim Report As New ReportDocument
            Report.Load(settings("Reports Folder") + "DailyRouteEstimatesEXPORT.rpt")
            'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In Report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            If rdFIT.Checked = True Then
                Report.SetParameterValue("comp", 1)
            ElseIf rdLOCAL.Checked = True Then
                Report.SetParameterValue("comp", 0)
            Else
                Report.SetParameterValue("comp", 2)
            End If

            Report.SetParameterValue("DN", txtDN.Text)
            Report.SetParameterValue("LDN", txtLDN.Text)
            Report.SetParameterValue("RN", txtRN.Text)
            'CrystalReportViewer1.ReportSource = Report
            Report.ExportToDisk(ExportFormatType.Excel, "D:\Google Drive ai\db backup\Invoice Temp\DE " & Today.ToString("d") & ".xls")
            txtDN.Select()
            txtDN.SelectAll()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub rfEstimates_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '    Dim StartInvoice As DataTable = SQLData("select isnull((select min(doc) from psdetail where type='sale' and description like '%estimate%' and date>='" & Now.Date.AddDays(-1) & "'),0) DN
        '   ,(select max(doc) from psdetail where type='sale' and description like '%estimate%' and date<=DATEADD(D,3,getdate()) and doc is not null) LDN")
        '  txtDN.Text = StartInvoice.Rows(0)("DN")
        ' txtLDN.Text = StartInvoice.Rows(0)("LDN")

        ' Call the recursive method for the form
        dtpStart.Value = Now.Date.AddDays(-8)
        dtpEnd.Value = Now.Date.AddDays(+2)
        AddHandlersForAllControls(Me)
        btnDisplay.PerformClick()
        btnPrint.Enabled = False
        txtRN.Select()
        txtRN.SelectAll()
    End Sub

    ' Recursive method to add handlers for TextBox and RadioButton
    Private Sub AddHandlersForAllControls(parent As Control)
        For Each ctrl As Control In parent.Controls
            ' Handle TextBox controls
            If TypeOf ctrl Is TextBox Then
                AddHandler DirectCast(ctrl, TextBox).TextChanged, AddressOf CommonEventHandler
            End If

            ' Handle RadioButton controls
            If TypeOf ctrl Is RadioButton Then
                AddHandler DirectCast(ctrl, RadioButton).CheckedChanged, AddressOf CommonEventHandler
            End If

            ' Recursively handle nested controls (e.g., in GroupBox, Panel, etc.)
            If ctrl.HasChildren Then
                AddHandlersForAllControls(ctrl)
            End If
        Next
    End Sub

    ' Common event handler for TextBox and RadioButton
    Private Sub CommonEventHandler(sender As Object, e As EventArgs)
        ' Identify the control type that triggered the event
        '    If TypeOf sender Is TextBox Then
        '        Dim txtBox As TextBox = DirectCast(sender, TextBox)
        '    'MessageBox.Show($"TextBox {txtBox.Name} text changed: {txtBox.Text}")
        '    btnPrint.Enabled = False
        'ElseIf TypeOf sender Is RadioButton Then
        '        Dim radioBtn As RadioButton = DirectCast(sender, RadioButton)
        '    'MessageBox.Show($"RadioButton {radioBtn.Name} checked state changed: {radioBtn.Checked}")
        btnPrint.Enabled = False

    End Sub



    'Sub CommanTextChange(sender As Object, e As EventArgs)
    '    If TypeOf sender Is RadioButton Then
    '        Dim RadioBtn As RadioButton = DirectCast(sender, RadioButton)
    '        MessageBox.Show($"RadioButton{RadioBtn.Name} checked state changed: {RadioBtn.Checked}")
    '    End If
    '    btnPrint.Enabled = False
    'End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        'Try
        Dim OptionalQuery As String = ""
        Dim LoadReport As String
        Dim DocNumberQuery As String = ""
        If rdSummary.Checked Then
            Dim SummaryReport As New ReportDocument
            LoadReport = Settings("Reports Folder") + "LocalEstimatesSummary.rpt"
            SummaryReport.Load(LoadReport)
            'SummaryReport.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In SummaryReport.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            SummaryReport.SetParameterValue("StartDoc", txtDN.Text)
            SummaryReport.SetParameterValue("EndDoc", txtLDN.Text)
            SummaryReport.SetParameterValue("Route", txtRN.Text)

            CrystalReportViewer1.ReportSource = SummaryReport

            txtRN.Select()
            txtRN.SelectAll()
            btnPrint.Enabled = True
            Return
        End If
        Dim Report As New ReportDocument
        '    MsgBox(settings("Reports Folder"))
        Report.Load(settings("Reports Folder") + "DailyRouteEstimatesNew.rpt")
        'Report.Load(settings("Reports Folder") + "Thermal Estimate.rpt")
        'Report.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        For Each tb As Table In Report.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        If rdRackSort.Checked Then
            Report.SetParameterValue("Sort", "BATCH")
        ElseIf rdAlphabet.Checked Then
            Report.SetParameterValue("Sort", "NAME")
        Else
            Report.SetParameterValue("Sort", "PSID")
        End If

        If rdFIT.Checked = True Then
            Report.SetParameterValue("comp", 1)
        End If
        If rdLOCAL.Checked = True Then
            Report.SetParameterValue("comp", 0)
        End If
        If rdALL.Checked = True Or rdOptionPending.Checked Then
            Report.SetParameterValue("comp", 2)
        End If

        If rdOptionPending.Checked Then
            OptionalQuery = " and PrintStatus is null"
        Else
            OptionalQuery = ""
        End If
        If Not txtDN.Text = Nothing Or Not txtLDN.Text = Nothing Then
            DocNumberQuery = " and pd.doc between " & txtDN.Text & " and " & txtLDN.Text
        Else
            DocNumberQuery = ""
        End If

        Dim DNum As String = txtDN.Text
        Dim LDNum As String = txtLDN.Text

        If DNum = "" Then
            DNum = 0
        End If
        If LDNum = "" Then
            LDNum = 100000000
        End If
        Report.SetParameterValue("SDate", dtpStart.Value.ToString("d"))
        Report.SetParameterValue("EDate", dtpEnd.Value.ToString("d"))
        Report.SetParameterValue("DocNumberQuery", DocNumberQuery)
        Report.SetParameterValue("DN", DNum)
        Report.SetParameterValue("LDN", LDNum)
        Report.SetParameterValue("RN", txtRN.Text)
        Report.SetParameterValue("OptionalQuery", OptionalQuery)
        CrystalReportViewer1.AllowedExportFormats = 1
        CrystalReportViewer1.ReportSource = Report
        'CrystalReportViewer1.Refresh()
        CrystalReportViewer1.Zoom(1)
        Dim t As Task = Task.Delay(3000).ContinueWith(Sub()
                                                          If Me.InvokeRequired Then
                                                              Me.Invoke(Sub() txtRN.Focus())
                                                          Else
                                                              txtRN.Focus()
                                                          End If
                                                      End Sub)
        'Me.BeginInvoke(Sub() txtRN.Select())
        'Report.ExportToDisk(ExportFormatType.Excel, "D:\Google Drive ai\db backup\Invoice Temp\DE " & Today.ToString("d"))

        btnPrint.Enabled = True
        txtRN.Focus()
        txtRN.Select()
        txtRN.SelectAll()

        CrystalReportViewer1.Enabled = True
        '  Catch ex As Exception
        ' MsgBox(ex.ToString)
        ' End Try

    End Sub


    Sub ThermalEstimates()
        Dim DocNumber As Integer
        Dim FocusCompany As String = "%"
        Dim FocusCompany2 As String = "%"
        Dim OPR As String = "LIKE"
        Dim OPR2 As String = "OR"
        Dim DocNumberQuery As String = ""
        If rdALL.Checked Then
            FocusCompany = "%"
            OPR = "LIKE"
            OPR2 = "OR"
        End If
        If rdFIT.Checked Then
            FocusCompany = "FIT%"
            FocusCompany2 = "EXCEL%"
            OPR = "LIKE"
            OPR2 = "OR"
        End If
        If rdLOCAL.Checked Then
            FocusCompany = "FIT%"
            FocusCompany2 = "EXCEL%"
            OPR = "NOT LIKE"
            OPR2 = "AND"
        End If
        If Not txtDN.Text = Nothing Or Not txtLDN.Text = Nothing Then
            DocNumberQuery = " and pd.doc between " & txtDN.Text & " and " & txtLDN.Text
        Else
            DocNumberQuery = ""
        End If

        Dim dt As DataTable = SQLData("select doc from PSDetail pd join coa a on pd.acid=a.id where pd.date between '" & dtpStart.Value.ToString("d") & "' and '" & dtpEnd.Value.ToString("d") & "' and route like '" & txtRN.Text & "%' " & DocNumberQuery)
        MainPage.Rcpt = 0
        If dt.Rows.Count > 0 Then
            For n = 0 To dt.Rows.Count - 1
                DocNumber = dt.Rows(n)("Doc")


                Dim cryRpt As New ReportDocument
                Dim ItemNumber As Integer = 0
                cryRpt.Load(settings("Reports Folder") + "thermal estimate.rpt")
                Try

                    'cryRpt.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
                    For Each tb As Table In cryRpt.Database.Tables
                        tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                        tb.ApplyLogOnInfo(tb.LogOnInfo)
                    Next

                    ItemNumber = 0

                    cryRpt.SetParameterValue("DocNumber", DocNumber)
                    cryRpt.SetParameterValue("ItemNumber", ItemNumber)
                    cryRpt.SetParameterValue("Company", FocusCompany)
                    cryRpt.SetParameterValue("Company2", FocusCompany2)
                    cryRpt.SetParameterValue("OPR", OPR)
                    cryRpt.SetParameterValue("OPR2", OPR2)
                    If MainPage.ThermalPrinter <> "" Then
                        cryRpt.PrintOptions.PrinterName = MainPage.ThermalPrinter
                        cryRpt.PrintToPrinter(1, False, 0, 0)
                    End If
                    cryRpt.Close()
                    cryRpt.Dispose()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try



            Next
            txtDN.Select()
            txtDN.SelectAll()
            MsgBox("All Selected Estimates Printed !")
        End If

    End Sub

    Sub EstimatePrint(Opr As String, opr2 As String, FocusCompany As String, FocusCompany2 As String, SDoc As String, LDoc As String, Route As String, DocNumber As String, ItemNumber As String, OptionalQuery As String, SDate As Date, Edate As Date)
        Dim DocNumberQuery As String = " and ps.doc>=" & SDoc & " and ps.doc<=" & LDoc
        If SDoc = "" Or LDoc = "" Then
            DocNumberQuery = ""
        Else
            DocNumberQuery = " and ps.doc>=" & SDoc & " and ps.doc<=" & LDoc
        End If

        Dim dt As DataTable = SQLData("with cte as (
                                            select ps.doc 
                                            from PsProduct ps join PSDetail pd on ps.doc=pd.doc and ps.type=pd.Type join Products p on ps.prid=p.ID join coa a on ps.acid=a.id
                                            where ps.type='sale' and ps.date between '" & SDate & "' and '" & Edate & "' and (company " & Opr & " '" & FocusCompany & "%' " & opr2 & " Company " & Opr & " '" & FocusCompany2 & "%' ) and qty>0 and route like '" & Route & "%' " & DocNumberQuery & OptionalQuery & ")
                                            select distinct doc from cte ORDER BY DOC")
        MainPage.Rcpt = 0
        'MsgBox(dt.Rows.Count)
        If dt.Rows.Count > 0 Then
            For n = 0 To dt.Rows.Count - 1
                DocNumber = dt.Rows(n)("Doc")
                Dim cryRpt As New ReportDocument
                ItemNumber = 0
                cryRpt.Load(settings("Reports Folder") + "thermal estimate.rpt")
                Try
                    'cryRpt.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
                    For Each tb As Table In cryRpt.Database.Tables
                        tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                        tb.ApplyLogOnInfo(tb.LogOnInfo)
                    Next
                    ItemNumber = 0
                    cryRpt.SetParameterValue("DocNumber", DocNumber)
                    cryRpt.SetParameterValue("ItemNumber", ItemNumber)
                    cryRpt.SetParameterValue("Company", FocusCompany)
                    cryRpt.SetParameterValue("Company2", FocusCompany2)
                    cryRpt.SetParameterValue("OPR", Opr)
                    cryRpt.SetParameterValue("OPR2", opr2)
                    cryRpt.SetParameterValue("Query", OptionalQuery)
                    cryRpt.SetParameterValue("User", frmLogin.UserName)
                    If MainPage.ThermalPrinter <> "" Then
                        cryRpt.PrintOptions.PrinterName = settings("Thermal Printer")
                        cryRpt.PrintToPrinter(1, False, 0, 0)
                        SQLData("with cte as (
                             Select row_number() over (order by ps.id) rn,type,Doc,Company,PrintStatus,PrintBy,PrintDateTime from PsProduct ps join Products p on ps.prid=p.id where type='sale' and doc=" & DocNumber & "
                                        ) update cte set PrintStatus='Estimate',PrintBy='" & frmLogin.UserName & "',PrintDateTime='" & Date.Now & "' WHERE RN>=0 AND (COMPANY " & Opr & "  '%" & FocusCompany & "%' " & opr2 & " COMPANY " & Opr & " '%" & FocusCompany2 & "%')
                                      ")
                    End If
                    cryRpt.Close()
                    cryRpt.Dispose()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try



            Next
        End If
    End Sub


    Sub ThermalEstimates2()
        Dim OptionalQuery As String = " and PrintStatus is null"
        Dim FocusCompany As String = "Fit%"
        Dim FocusCompany2 As String = "Excel%"
        Dim SDoc As String = txtDN.Text
        Dim LDoc As String = txtLDN.Text
        Dim Route As String = txtRN.Text
        Dim Opr As String = "Like"
        Dim opr2 As String = "and"
        Dim DocNumber As Integer
        If rdLOCAL.Checked Then
            Opr = "Not like"
            opr2 = "and"
        End If
        If rdFIT.Checked Then
            Opr = "Like"
            opr2 = "OR"
        End If
        If rdALL.Checked Then
            FocusCompany = "%"
            FocusCompany2 = "%"
            Opr = "like"
            opr2 = "or"
        End If
        If rdOptionAll.Checked Then
            OptionalQuery = ""
        End If
        If rdOptionPending.Checked Then
            OptionalQuery = " and PrintStatus is null"
        End If
        If rdSeparat.Checked Then
            Opr = "Like"
            opr2 = "OR"
            EstimatePrint(Opr, opr2, FocusCompany, FocusCompany2, SDoc, LDoc, Route, DocNumber, 0, OptionalQuery, dtpStart.Value.ToString("d"), dtpEnd.Value.ToString("d"))
            Opr = "Not like"
            opr2 = "and"
            'EstimatePrint(Opr, opr2, FocusCompany, FocusCompany2, SDoc, LDoc, Route, DocNumber, 0, OptionalQuery, dtpStart.Value.ToString("d"), dtpEnd.Value.ToString("d"))

        Else
            EstimatePrint(Opr, opr2, FocusCompany, FocusCompany2, SDoc, LDoc, Route, DocNumber, 0, OptionalQuery, dtpStart.Value.ToString("d"), dtpEnd.Value.ToString("d"))
        End If


        'Dim dt As DataTable = SQLData("with cte as (
        '                                    select ps.doc 
        '                                    from PsProduct ps join PSDetail pd on ps.doc=pd.doc and ps.type=pd.Type join Products p on ps.prid=p.ID join coa a on ps.acid=a.id
        '                                    where pd.Status='estimate' and (company " & Opr & " '" & FocusCompany & "%' " & opr2 & " Company " & Opr & " '" & FocusCompany2 & "%' ) and ps.doc>=" & SDoc & " and ps.doc<=" & LDoc & " and qty>0 and route like '" & Route & "%')
        '                                    select distinct doc from cte")
        'MainPage.Rcpt = 0
        'If dt.Rows.Count > 0 Then
        '    For n = 0 To dt.Rows.Count - 1
        '        DocNumber = dt.Rows(n)("Doc")
        '        Dim cryRpt As New ReportDocument
        '        Dim ItemNumber As Integer = 0
        '        cryRpt.Load(settings("Reports Folder") + "thermal estimate.rpt")
        '        Try
        '            'cryRpt.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
        '            For Each tb As Table In cryRpt.Database.Tables
        '                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
        '                tb.ApplyLogOnInfo(tb.LogOnInfo)
        '            Next
        '            ItemNumber = 0
        '            cryRpt.SetParameterValue("DocNumber", DocNumber)
        '            cryRpt.SetParameterValue("ItemNumber", ItemNumber)
        '            cryRpt.SetParameterValue("Company", FocusCompany)
        '            cryRpt.SetParameterValue("Company2", FocusCompany2)
        '            cryRpt.SetParameterValue("OPR", Opr)
        '            cryRpt.SetParameterValue("OPR2", opr2)
        '            cryRpt.SetParameterValue("Query", OptionalQuery)
        '            cryRpt.SetParameterValue("User", frmLogin.UserName)
        '            If MainPage.ThermalPrinter <> "" Then
        '                cryRpt.PrintOptions.PrinterName = settings("Thermal Printer")
        '                cryRpt.PrintToPrinter(1, False, 0, 0)
        '                SQLData("with cte as (
        '                                select row_number() over (order by ps.id) rn,type,Doc,Company,PrintStatus,PrintBy,PrintDateTime from PsProduct ps join Products p on ps.prid=p.id where type='sale' and doc=" & DocNumber & "
        '                                ) update cte set PrintStatus='Estimate',PrintBy='" & frmLogin.UserName & "',PrintDateTime='" & Date.Now & "' WHERE RN>=0 AND (COMPANY " & Opr & "  '%" & FocusCompany & "%' " & opr2 & " COMPANY " & Opr & " '%" & FocusCompany2 & "%')
        '                              ")
        '            End If
        '            cryRpt.Close()
        '            cryRpt.Dispose()
        '        Catch ex As Exception
        '            MsgBox(ex.ToString)
        '        End Try



        '    Next
        Console.Beep()
        txtRN.Select()
        txtRN.SelectAll()
        'MsgBox("All Selected Estimates Printed !")
        'End If

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles btnPrint.Click
        If rdSummary.Checked Then
            Dim SummaryReport As New ReportDocument
            Dim LoadReport = Settings("Reports Folder") + "LocalEstimatesSummary.rpt"
            SummaryReport.Load(LoadReport)
            'SummaryReport.SetDatabaseLogon("sa", "Ai", frmLogin.MySqlServer, MainPage.MyDataBase)
            For Each tb As Table In SummaryReport.Database.Tables
                tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            SummaryReport.SetParameterValue("StartDoc", txtDN.Text)
            SummaryReport.SetParameterValue("EndDoc", txtLDN.Text)
            SummaryReport.SetParameterValue("Route", txtRN.Text)

            'CrystalReportViewer1.ReportSource = SummaryReport
            SummaryReport.PrintOptions.PrinterName = Settings("Thermal Printer")
            SummaryReport.PrintToPrinter(1, False, 0, 0)

            txtRN.Select()
            txtRN.SelectAll()
            btnPrint.Enabled = False
            Return
        End If


        ThermalEstimates2()
        btnPrint.Enabled = False
        'Console.Beep()
        txtRN.SelectAll()
        txtRN.Select()
    End Sub

    Private Sub txtRN_Enter(sender As Object, e As EventArgs) Handles txtRN.Enter
        txtRN.SelectAll()
    End Sub
End Class
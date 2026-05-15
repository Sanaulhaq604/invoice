Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.IO
Imports System.Net
Imports System.Net.WebClient
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Web.UI.WebControls
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class MainPage

    Private isCheckingReceipts As Integer = 0

    Public CustomerAging As DataTable
    Public ConInfo As New ConnectionInfo
    Public ThermalPrinter As String = ""
    Public PSERVER As String = ""
    Public OSERVER As String = ""
    Public CSERVER As String = ""
    Public Password As String = "Ai"
    Public PName As String = ""
    Public PCategory As String = ""
    Public MyDataBase As String = "ahmadinternational"
    Public conString As String = "Data source=" & frmLogin.MySqlServer & ";database=" & MyDataBase & ";User ID=sa;Password=Ai;"
    Public conString2 As String
    Public TempFolder As String = Settings("TEMP FOLDER")
    Public ReportPath As String
    Public ReportName As String = ""
    Public Company As String = ""
    Public HighLighted As String = ""
    Public User As String = "sa"
    Public PrID As String = ""
    Public CustID As String = ""
    Public imgFile As String = ""
    Public msg As String = "Task Completed"
    Public DocNumber As Integer = 0
    Public Rcpt As Integer = 0
    Public rptName As String = ""
    Public DocType As String = ""
    Public LoginDetails As String
    Public PreviousBalance As Integer = 0
    Public Property StkVoucher As Integer

    ' Dashboard instance
    Public Shared Dashboard As New Dashboard()

    ' Sales background worker
    Private dtSales As New DataTable
    Private BackgroundWorker1 As ComponentModel.BackgroundWorker

    ' ═══════════════════════════════════════════════════════════════════════════
    '  FORM LOAD / CLOSE
    ' ═══════════════════════════════════════════════════════════════════════════

    Private Sub MainPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not String.IsNullOrWhiteSpace(frmLogin.MySqlServer) Then
                conString = "Server=" & frmLogin.MySqlServer & ";Database=" & MyDataBase & ";User ID=sa;Password=Ai;"
                conString2 = conString
            End If
        Catch
        End Try

        ' Form caption
        Dim companyName As String = Settings("Company")
        If String.IsNullOrWhiteSpace(companyName) Then companyName = "Accounts"
        Dim serverLabel As String = If(String.IsNullOrWhiteSpace(frmLogin.MySqlServer), "Server: unknown", "Server: " & frmLogin.MySqlServer)
        Dim userLabel As String = If(String.IsNullOrWhiteSpace(frmLogin.UserName), "", $"{frmLogin.UserName} ({frmLogin.UserLevel})")
        Me.Text = $"{companyName} — {serverLabel}{If(userLabel = "", "", " — " & userLabel)}"

        ' Bottom-right company label
        Try
            lblCompany.Text = If(userLabel = "", serverLabel, $"User: {userLabel}  |  {serverLabel}")
            lblCompany.Font = New Font("Segoe UI", 14, FontStyle.Regular)
            lblCompany.BackColor = Color.FromArgb(210, Color.White)
            lblCompany.ForeColor = Color.Black
            lblCompany.AutoSize = True
            lblCompany.Visible = True
            lblCompany.BringToFront()
            Dim margin As Integer = 20
            lblCompany.Left = Math.Max(10, Me.ClientSize.Width - lblCompany.Width - margin)
            lblCompany.Top = Math.Max(10, Me.ClientSize.Height - lblCompany.Height - margin)
        Catch
        End Try

        ' Start dashboard monitor (non-blocking)
        StartDifferencesMonitor()
    End Sub

    Private Sub MainPage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dashboard.StopAutoRefresh()
        WASender.StopSession()
    End Sub

    Private Sub MainPage_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        Try
            Dim companyName As String = Settings("Company")
            If String.IsNullOrWhiteSpace(companyName) Then companyName = "Accounts"
            Me.Text = companyName & " — Dashboard"
        Catch
        End Try
    End Sub

    Private Sub MainPage_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.End Then Me.Close()
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════════
    '  DASHBOARD / DIFFERENCES MONITOR
    ' ═══════════════════════════════════════════════════════════════════════════

    Public Function FetchDifferencesFromDB() As DataTable
        Try
            Dim q As String =
                "select cast(l.date as date) Date,l.type,l.doc,a.Route,a.ID,Subsidary,l.Credit,trim(EntryBy) as EntryBy,EntryDateTime" & vbCrLf &
                ",case when DATALENGTH(image)>0 then 'Yes' else 'No' End HasImage" & vbCrLf &
                " from ledgers l join coa a on l.acid=a.Id join Images.dbo.name_reciepts im on l.type=im.type and l.doc=im.Doc" & vbCrLf &
                " where LedgerStatus='difference' and credit is not null" & vbCrLf &
                " order by Route,EntryBy,EntryDateTime"
            Return SQLData(q)
        Catch ex As Exception
            Try
                Dim logFolder As String = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs")
                If Not System.IO.Directory.Exists(logFolder) Then System.IO.Directory.CreateDirectory(logFolder)
                System.IO.File.AppendAllText(
                    System.IO.Path.Combine(logFolder, "db_errors.log"),
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] FetchDifferencesFromDB: {ex.Message}{Environment.NewLine}")
            Catch
            End Try
            Return Nothing
        End Try
    End Function

    Private Sub StartDifferencesMonitor()
        Task.Run(Sub()
                     Try
                         Dim dt As DataTable = FetchDifferencesFromDB()

                         If Me.IsHandleCreated Then
                             Me.BeginInvoke(New Action(Sub()
                                                           Dashboard.MdiParent = Me
                                                           Dashboard.FormBorderStyle = FormBorderStyle.None
                                                           Dashboard.Show()
                                                           Dashboard.BringToFront()
                                                           Dashboard.ShowDifferences(dt)
                                                           ' Start auto-refresh after first load
                                                           Dashboard.StartAutoRefresh(AddressOf FetchDifferencesFromDB)
                                                       End Sub))
                         End If

                         ' Background mark-as-checked
                         Try
                             Using con As New SqlConnection(conString)
                                 con.Open()
                                 Using cmd As New SqlCommand(
                                     "UPDATE ledgers SET LedgerStatus=@newStatus " &
                                     "WHERE LedgerStatus='difference' AND credit IS NOT NULL " &
                                     "AND EXISTS (SELECT 1 FROM Images.dbo.name_reciepts im WHERE im.[type]=ledgers.type AND im.doc=ledgers.doc)", con)
                                     cmd.Parameters.AddWithValue("@newStatus", "difference_checked")
                                     cmd.CommandTimeout = 120
                                     cmd.ExecuteNonQuery()
                                 End Using
                             End Using
                         Catch
                         End Try

                     Catch ex As Exception
                         Try
                             Dim logFolder As String = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs")
                             If Not System.IO.Directory.Exists(logFolder) Then System.IO.Directory.CreateDirectory(logFolder)
                             System.IO.File.AppendAllText(
                                 System.IO.Path.Combine(logFolder, "background_errors.log"),
                                 $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] StartDifferencesMonitor: {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}")
                         Catch
                         End Try

                         If Me.IsHandleCreated Then
                             Me.BeginInvoke(New Action(Sub()
                                                           Dashboard.MdiParent = Me
                                                           Dashboard.FormBorderStyle = FormBorderStyle.None
                                                           Dashboard.Show()
                                                           Dashboard.BringToFront()
                                                           Dashboard.ShowDifferences(Nothing)
                                                       End Sub))
                         End If
                     End Try
                 End Sub)
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════════
    '  TIMER1 – RECEIPT CHECKER (unchanged logic, cleaned up)
    ' ═══════════════════════════════════════════════════════════════════════════

    Private Async Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If System.Threading.Interlocked.Exchange(isCheckingReceipts, 1) = 1 Then Return
        Timer1.Enabled = False
        Try
            Await Task.Run(Sub()
                               Try
                                   CheckNewReceipts()
                               Catch ex As Exception
                                   Try
                                       Dim logFolder As String = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs")
                                       If Not System.IO.Directory.Exists(logFolder) Then System.IO.Directory.CreateDirectory(logFolder)
                                       System.IO.File.AppendAllText(
                                           System.IO.Path.Combine(logFolder, "background_errors.log"),
                                           $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Timer1 background error: {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}")
                                   Catch
                                   End Try
                                   If Me.IsHandleCreated Then
                                       Me.BeginInvoke(New Action(Sub() Label1.Text = "Background error: " & ex.Message))
                                   End If
                               End Try
                           End Sub)
        Finally
            Timer1.Enabled = True
            System.Threading.Interlocked.Exchange(isCheckingReceipts, 0)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════════
    '  BACKGROUND WORKER – SALES CHART
    ' ═══════════════════════════════════════════════════════════════════════════

    Private Sub LoadSalesInBackground()
        If BackgroundWorker1 Is Nothing Then
            BackgroundWorker1 = New ComponentModel.BackgroundWorker()
            AddHandler BackgroundWorker1.DoWork, AddressOf BackgroundWorker1_DoWork
            AddHandler BackgroundWorker1.RunWorkerCompleted, AddressOf BackgroundWorker1_RunWorkerCompleted
        End If
        If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs)
        Dim q As String =
            "SELECT FORMAT([date], 'yyyy-MM') AS Month," & vbCrLf &
            "       ROUND(SUM(vist)/1000000,2) AS Total" & vbCrLf &
            "FROM PsProduct" & vbCrLf &
            "WHERE type = 'sale'" & vbCrLf &
            "  AND [date] >= DATEADD(MONTH, -6, CAST(GETDATE() AS date))" & vbCrLf &
            "GROUP BY FORMAT([date], 'yyyy-MM'), YEAR([date]), MONTH([date])" & vbCrLf &
            "ORDER BY YEAR([date]), MONTH([date]);"
        e.Result = SQLData(q)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs)
        If e.Error IsNot Nothing Then Exit Sub
        If e.Result Is Nothing OrElse Not TypeOf e.Result Is DataTable Then
            Label1.Text = "Sales data unavailable"
            Return
        End If
        dtSales = CType(e.Result, DataTable)
        If dtSales Is Nothing Then
            Label1.Text = "Sales data unavailable"
            Return
        End If
        ' Dashboard lifecycle is owned by StartDifferencesMonitor – do NOT call Show/BringToFront here
        Label1.Text = "Last updated: " & Now.ToString("HH:mm:ss")
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════════
    '  UTILITY
    ' ═══════════════════════════════════════════════════════════════════════════

    Sub ChangeIdColumn()
        SQLData("exec sp_rename 'LEDGERS.id','oldid_temp','COLUMN'
                alter table LEDGERS add id int identity(1,1)
                alter table LEDGERS drop column oldid_temp
                exec sp_rename 'LEDGERSHISTORY.id','oldid_temp','COLUMN'
                alter table LEDGERSHISTORY add id int identity(1,1)
                alter table LEDGERShistory drop column oldid_temp
                exec sp_rename 'psproductHISTORY.id','oldid_temp','COLUMN'
                alter table psproductHISTORY add id int identity(1,1)
                alter table psproducthistory drop column oldid_temp
                exec sp_rename 'psproduct.id','oldid_temp','COLUMN'
                alter table psproduct add id int identity(1,1)
                alter table psproduct drop column oldid_temp")
    End Sub

    Sub DocNumberCheck()
        SQLData("if not exists(select * from sys.tables where name='docnumBER')
    begin
        create table DocNumber (Type varchar(20), Doc Int)
        insert into DocNumber (type,Doc) values('SALE',(SELECT MAX(DOC)+1 FROM PSProduct WHERE TYPE='SALE'))
        insert into DocNumber (type,Doc) values('PURCHASE',(SELECT MAX(DOC)+1 FROM PSProduct WHERE TYPE='PURCHASE'))
        insert into DocNumber (type,Doc) values('CRV',(SELECT MAX(DOC)+1 FROM LEDGERS WHERE TYPE='CRV'))
        insert into DocNumber (type,Doc) values('CPV',(SELECT MAX(DOC)+1 FROM LEDGERS WHERE TYPE='CPV'))
        insert into DocNumber (type,Doc) values('JV',(SELECT MAX(DOC)+1 FROM LEDGERS WHERE TYPE='JV'))
        insert into DocNumber (type,Doc) values('STOCK TRANSFER',(SELECT MAX(DOC)+1 FROM PSProduct WHERE TYPE='STOCK TRANSFER'))
        insert into DocNumber (type,Doc) values('BRV',(SELECT MAX(DOC)+1 FROM LEDGERS WHERE TYPE='BRV'))
        insert into DocNumber (type,Doc) values('PsID',(SELECT MAX(ID)+1 FROM PSProduct))
        insert into DocNumber (type,Doc) values('LdgrID',(SELECT MAX(ID)+1 FROM Ledgers))
    END")
    End Sub

    Function DocNum(Type) As Integer
        Dim dt As DataTable = SQLData("select isnull(max(doc),0)+1 Num from PSPRODUCT where type='" & Type & "'")
        Return dt.Rows(0)("Num")
    End Function

    Public Sub lbCompany()
        lblCompany.Text = Settings("Company")
        lblCompany.Left = Me.ClientSize.Width - lblCompany.Width
        lblCompany.Top = Me.ClientSize.Height - lblCompany.Height
        lblCompany.Parent = Me
        lblCompany.BackColor = Color.Transparent
        lblCompany.AutoSize = True
    End Sub

    Sub PannelsDisplay()
    End Sub

    Sub CashnBank()
        Return
        If Me.MdiChildren.Length > 0 Then Return
        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            pnlCashnBank.Visible = False
            dgvCashnBank.Visible = False
            Dim tb As DataTable = SQLData("select Subsidary,round(sum(isnull(debit,0))-sum(isnull(credit,0)),0) Balance
                                          from ledgers l join coa a on l.acid=a.id
                                          where a.main='CASH AND BANK BALANCES'
                                          group by Subsidary
                                          having round(sum(isnull(debit,0))-sum(isnull(credit,0)),0)<>0
                                          order by Balance desc")
            dgvCashnBank.DataSource = tb
            Dim CnB As Integer = 0
            If tb.Rows.Count > 0 Then
                For n = 0 To tb.Rows.Count - 1
                    CnB += tb.Rows(n)("Balance")
                Next
                txtCashnBank.Text = Form3.Amt(CnB)
            Else
                txtCashnBank.Text = "0"
            End If
        Else
            pnlCashnBank.Visible = False
            dgvCashnBank.Visible = False
        End If
    End Sub

    Sub CustomerAgingSummary()
        Return
        If Me.MdiChildren.Length > 1 Then Return
        CustomerAging = SQLData("use AhmadInternational
            select route,acid,subsidary,ocell,second+third TotalOverDue,third,second,first,bal from (
            select ACID,SUBSIDARY,ocell,route,
            case when bal>=days30 then ISNULL(days30,0) when bal<=days30 then ISNULL(bal,0) end first,
            case when bal<=days30 then 0 when bal>=days30+Days60 then Days60 when bal<=days30+days60 then bal-days30 end second,
            case when bal<=days30 then 0 when bal<=days30+days60 then 0 when bal>=days30+days60+days90 then BAL when bal<=days30+days60+days90 then bal-(days30+days60) end third,BAL
            from (
            SELECT ACID,SUBSIDARY,ocell,route,
            ROUND((SELECT ISNULL(SUM(DEBIT),0)-ISNULL(SUM(CREDIT),0) WHERE ACID=L2.Acid),0) BAL
            ,ROUND((SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE ACID=L2.ACID AND date>=DATEADD(m,-1,getdate()) and date<=getdate()),0) Days30
            ,ROUND((SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE ACID=L2.ACID AND date>=DATEADD(m,-2,getdate()) and date<=DATEADD(m,-1,getdate())),0) Days60
            ,ROUND((SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE ACID=L2.ACID AND date<=DATEADD(m,-2,getdate())),0) Days90
            FROM Ledgers L2 JOIN COA A ON L2.ACID=A.ID
            WHERE A.MAIN='TRADE DEBTORS' and a.route like '%" & txtRoute.Text & "%' and a.subsidary like '%" & txtCustomerName.Text & "%' and a.spo like '%" & txtSPO.Text & "%'
            GROUP BY route,ACID,Subsidary,ocell) x WHERE BAL>0 and route<>'') xx
            ORDER BY SECOND DESC,route")
        If CustomerAging.Rows.Count > 0 Then dgvAging.DataSource = CustomerAging
    End Sub

    Sub MainPageEstimates()
        Return
        If Me.MdiChildren.Length > 1 Then Return
        Dim tot As Integer = 0
        Dim EstimatesDataTable As DataTable = SQLData("select ROW_NUMBER() over (order by pd.date) rn,a.route,pd.date,pd.doc,a.Subsidary,pd.Description,pd.Amount
            from PSDetail pd join coa a on pd.acid=a.Id
            where Description like 'estimate%'
            and pd.date>'" & dtpEstimates.Value & "'
            and type='sale'
            and a.route like '%" & txtEstRoute.Text & "%'
            and a.subsidary like '%" & txtEstCustomerName.Text & "%'
            order by date,route,doc")
        If EstimatesDataTable.Rows.Count > 0 Then
            dgvEstimates.DataSource = EstimatesDataTable
            If frmLogin.UserLevel.ToUpper = "ADMIN" Then
                For n = 0 To EstimatesDataTable.Rows.Count - 1
                    tot += dgvEstimates.Rows(n).Cells(6).Value
                    lblMainEstiamateTotal.Text = Form3.Amt(tot)
                Next
            End If
        ElseIf dgvEstimates.Rows.Count > 0 Then
            dgvEstimates.DataSource.clear()
            lblMainEstiamateTotal.Text = ""
        End If
    End Sub

    Sub SendPendingMsgs()
        Dim dt As DataTable = SQLData("WITH RankedWA AS (
    SELECT *, ROW_NUMBER() OVER (PARTITION BY type, doc ORDER BY (SELECT NULL)) AS rn
    FROM WA WHERE status IS NULL)
SELECT * FROM RankedWA WHERE rn = 1;")
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim id As String = row("ID").ToString()
                Dim waChat As String = row("Whatsapp_chat").ToString()
                Dim message As String = row("message").ToString()
                Dim filePath As String = ""
                Dim type As String = row("Type").ToString.Trim()
                Dim doc As String = row("doc").ToString.Trim()
                If type.ToUpper = "SALE" Then filePath = PDFExport(doc, "")
                Try
                    If filePath.Trim <> "" Then
                        SendAttachment(waChat, filePath)
                        System.Threading.Thread.Sleep(1000)
                    End If
                    If message.Trim <> "" Then SendMessage(waChat, message)
                    System.Threading.Thread.Sleep(1000)
                    SQLData("UPDATE WA SET status='SENT',sent_date='" & Date.Today.ToString("d") & "',sent_time='" & Date.Now.ToString("HH:mm") & "',Sending_Machine='" & Environment.MachineName & "' WHERE id=" & id)
                Catch ex As Exception
                    SQLData("UPDATE WA SET status='FAILED' WHERE id=" & row("id").ToString())
                End Try
            Next
        End If
    End Sub

    Public Function UrduDay(dt As Date) As String
        Select Case dt.ToString("dddd").ToUpper
            Case "SATURDAY" : Return " ہفتہ "
            Case "SUNDAY" : Return " اتوار "
            Case "MONDAY" : Return " پیر "
            Case "TUESDAY" : Return " منگل "
            Case "WEDNESDAY" : Return " بدھ "
            Case "THURSDAY" : Return " جمعرات "
            Case "FRIDAY" : Return " جمعہ "
        End Select
        Return ""
    End Function

    Private Function CpuId() As String
        Dim wmi As Object = GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from Win32_Processor")
        Dim cpu_ids As String = ""
        For Each cpu As Object In processors
            cpu_ids = cpu_ids & ", " & cpu.ProcessorId
        Next
        If cpu_ids.Length > 0 Then cpu_ids = cpu_ids.Substring(2)
        Return cpu_ids
    End Function

    Private Sub SendWhatsAppMessageWithAttachment(phoneNumber As String, message As String, filePath As String)
        Dim boundary As String = "----WhatsAppBoundary" & DateTime.Now.Ticks.ToString("x")
        Dim request As HttpWebRequest = CType(WebRequest.Create("https://api.whatsapp.com/send"), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "multipart/form-data; boundary=" & boundary
        Dim postData As String = "--" & boundary & vbCrLf
        postData += "Content-Disposition: form-data; name=""phone""" & vbCrLf & vbCrLf
        postData += phoneNumber & vbCrLf
        postData += "--" & boundary & vbCrLf
        postData += "Content-Disposition: form-data; name=""text""" & vbCrLf & vbCrLf
        postData += message & vbCrLf
        postData += "--" & boundary & vbCrLf
        postData += "Content-Disposition: form-data; name=""attachment""; filename=""" & Path.GetFileName(filePath) & """" & vbCrLf
        postData += "Content-Type: application/pdf" & vbCrLf & vbCrLf
        Dim fileBytes As Byte() = File.ReadAllBytes(filePath)
        postData += Convert.ToBase64String(fileBytes) & vbCrLf
        postData += "--" & boundary & "--"
        Dim postBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(postData)
        request.ContentLength = postBytes.Length
        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(postBytes, 0, postBytes.Length)
        End Using
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        Using responseReader As New StreamReader(response.GetResponseStream())
            responseReader.ReadToEnd()
        End Using
        response.Close()
    End Sub

    Public Sub Main()
        Dim phoneNumber As String = "1234567890"
        Dim message As String = "Hello! I'm sending you a PDF file."
        Dim filePath As String = "C:\Path\To\Your\File.pdf"
        SendWhatsAppMessageWithAttachment(phoneNumber, message, filePath)
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════════
    '  MENU / TOOLBAR EVENT HANDLERS
    ' ═══════════════════════════════════════════════════════════════════════════

    Private Sub InvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InvoiceToolStripMenuItem.Click
        Dim f3 As New Form3
        f3.MdiParent = Me
        f3.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BackupRestoreToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BackupRestoreToolStripMenuItem1.Click
        BackupRestore.Show()
    End Sub

    Private Sub DailyEstimatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailyEstimatesToolStripMenuItem.Click
        rfEstimates.MdiParent = Me
        rfEstimates.Show()
    End Sub

    Private Sub LedgersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LedgersToolStripMenuItem.Click
        Dim ldgr As New frmLedger
        ldgr.MdiParent = Me
        ldgr.Show()
    End Sub

    Private Sub CashReceiptVoucherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashReceiptVoucherToolStripMenuItem.Click
        CRV.MdiParent = Me
        CRV.Show()
    End Sub

    Private Sub CashPaymentVoucherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashPaymentVoucherToolStripMenuItem.Click
        CPV.MdiParent = Me
        CPV.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub PurchaseVoucherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseVoucherToolStripMenuItem.Click
        Dim PV As New frmPurchase
        PV.MdiParent = Me
        PV.Show()
    End Sub

    Private Sub StoreTransferVoucherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StoreTransferVoucherToolStripMenuItem.Click
        frmStockTransfer.MdiParent = Me
        StkVoucher = DocNum("Stock Transfer")
        frmStockTransfer.txtDocNum.Text = StkVoucher
        frmStockTransfer.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim f3 As New Form3
        f3.MdiParent = Me
        f3.Show()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim PV As New frmPurchase
        PV.MdiParent = Me
        PV.Show()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        CRV.MdiParent = Me
        CRV.Show()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        StopSession()
        Dim spath = "D:\Google Drive ai\db backup\New Repos\Invoice\Invoice\bin\Debug\app.publish"
        If System.IO.Directory.Exists(spath) Then
            SetAttr(spath, vbNormal)
            System.IO.Directory.Delete(spath, True)
        End If
        Dim pro = Process.GetProcessesByName("Invoice")
        For i = 0 To pro.Count - 1
            pro(i).CloseMainWindow()
        Next
        End
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Dim ldgr As New frmLedger
        ldgr.MdiParent = Me
        ldgr.Show()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        CPV.MdiParent = Me
        CPV.Show()
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        BRV.MdiParent = Me
        BRV.Show()
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        frmStockTransfer.MdiParent = Me
        StkVoucher = DocNum("Stock Transfer")
        frmStockTransfer.txtDocNum.Text = StkVoucher
        frmStockTransfer.Show()
    End Sub

    Private Sub BankReceiptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BankReceiptToolStripMenuItem.Click
        BRV.MdiParent = Me
        BRV.Show()
    End Sub

    Private Sub ChartOfAccountsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChartOfAccountsToolStripMenuItem.Click
        COA.MdiParent = Me
        COA.Show()
    End Sub

    Private Sub ProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductToolStripMenuItem.Click
        Product.Show()
    End Sub

    Private Sub StockReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockReportToolStripMenuItem.Click
        rptStock.MdiParent = Me
        rptStock.Show()
    End Sub

    Private Sub ReOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReOrderToolStripMenuItem.Click
        rptReOrder.MdiParent = Me
        rptReOrder.Show()
    End Sub

    Private Sub ProductAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductAccountToolStripMenuItem.Click
        frmProductAccount.MdiParent = Me
        frmProductAccount.Show()
    End Sub

    Private Sub CustomersRouteOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomersRouteOrderToolStripMenuItem.Click
        RouteCustomerOrder.MdiParent = Me
        RouteCustomerOrder.Show()
    End Sub

    Private Sub WhatsAppToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WhatsAppToolStripMenuItem.Click
        frmRouteWhatsapp.MdiParent = Me
        frmRouteWhatsapp.Show()
    End Sub

    Private Sub IMPORTSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IMPORTSToolStripMenuItem.Click
        ImportFromExcel.MdiParent = Me
        ImportFromExcel.Show()
    End Sub

    Private Sub CUSTOMERPENDINGORDERSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CUSTOMERPENDINGORDERSToolStripMenuItem.Click
        RptCustomer.MdiParent = Me
        rptName = ReportPath + "Periodic Pending Orders Report.rpt"
        RptCustomer.Show()
    End Sub

    Private Sub EstimateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstimateToolStripMenuItem.Click
        Dim est As New frmEstimate
        est.MdiParent = Me
        est.Show()
    End Sub

    Private Sub SALARYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SALARYToolStripMenuItem.Click
        If frmLogin.UserLevel.ToUpper <> "ADMIN" Then Return
        frmSalary.MdiParent = Me
        frmSalary.Show()
    End Sub

    Private Sub JournalVoucherJVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JournalVoucherJVToolStripMenuItem.Click
        If frmLogin.UserLevel.ToUpper <> "ADMIN" Then Return
        frmJV.MdiParent = Me
        frmJV.Show()
    End Sub

    Private Sub ProductHistroyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductHistroyToolStripMenuItem.Click
        frmProHistory.MdiParent = Me
        frmProHistory.Show()
    End Sub

    Private Sub ChangeUserToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ChangeUserToolStripMenuItem.Click
        frmLogin.Show()
    End Sub

    Private Sub AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AToolStripMenuItem.Click
        RptCustomer.MdiParent = Me
        rptName = ReportPath + "TotalPeriodicRuns.rpt"
        RptCustomer.Show()
    End Sub

    Private Sub TotalMonthlyRunsSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalMonthlyRunsSummaryToolStripMenuItem.Click
        PeriodicReports.lblSPO.Visible = False
        PeriodicReports.cmbSPO.Visible = False
        rptName = ReportPath + "MonthlyRunsReportSummary.rpt"
        Dim PReport As New PeriodicReports
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub SalesComissionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesComissionToolStripMenuItem.Click
        ReportName = "SPO Sales Comission Report"
        rptName = ReportPath + "SPO STG Sale.rpt"
        Dim PReport As New PeriodicReports
        PReport.cmbSPO.Enabled = True
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub DailyRouteDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailyRouteDetailsToolStripMenuItem.Click
        frmRouteDetails.MdiParent = Me
        frmRouteDetails.Show()
    End Sub

    Private Sub DailyRouteAccountsActivityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailyRouteAccountsActivityToolStripMenuItem.Click
        rptName = ReportPath + "rptCustOmerActivityRoute.rpt"
        Dim PReport As New PeriodicReports
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub RouteBalanceIncreaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RouteBalanceIncreaseToolStripMenuItem.Click
        ReportName = "Balance Change Report"
        rptName = ReportPath + "BalanceIncrease.rpt"
        Dim PReport As New PeriodicReports
        PReport.cmbSPO.Enabled = True
        PReport.txtRoute.Enabled = True
        PReport.chkDecreaseBalance.Visible = True
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub mnuMPS_Click(sender As Object, e As EventArgs) Handles mnuMPS.Click
        rptName = ReportPath + "Monthly Payable Summary.rpt"
        ReportName = "Monthly Accounts Summary"
        Dim PReport As New PeriodicReports
        PReport.rdALL.Enabled = True
        PReport.rdEntry.Enabled = True
        PReport.rdNoEntry.Enabled = True
        PReport.cmbSPO.Enabled = True
        PReport.txtRoute.Enabled = True
        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            PReport.cmbMain.Enabled = True
        Else
            PReport.cmbMain.Enabled = False
        End If
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub RouteLedgersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RouteLedgersToolStripMenuItem.Click
        ReportName = "Route Ledgers"
        rptName = ReportPath + "Route Ledger 2.rpt"
        Dim PReport As New PeriodicReports
        PReport.txtRoute.Enabled = True
        PReport.cmbSPO.Enabled = True
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub CustomerSalesWithDiscountToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CustomerSalesWithDiscountToolStripMenuItem1.Click
        RptCustomer.MdiParent = Me
        rptName = ReportPath + "CustomerSalesWithDiscount.rpt"
        RptCustomer.Show()
    End Sub

    Private Sub CustomerAgingReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerAgingReportToolStripMenuItem.Click
        ReportName = "Customer Bills Aging"
        rptName = ReportPath + "Customer Bill Aging.rpt"
        Dim PReport As New PeriodicReports
        PReport.txtCustomerID.Enabled = True
        PReport.txtCustomerName.Enabled = True
        PReport.txtRoute.Enabled = True
        PReport.cmbSPO.Enabled = True
        PReport.txtDays.Enabled = True
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub PreiodicSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreiodicSummaryToolStripMenuItem.Click
        ReportName = "Product Activity"
        rptName = ReportPath + "Product Activity.rpt"
        Dim PReport As New PeriodicReports
        PReport.txtCompany.Enabled = True
        PReport.txtCompany.Select()
        PReport.txtCompany.SelectAll()
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub RouteInactiveCustomersWithBalancesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RouteInactiveCustomersWithBalancesToolStripMenuItem.Click
        rptName = ReportPath + "InActive Customers with Balance.rpt"
        ReportName = "Route InActive Customers"
        Dim PReport As New PeriodicReports
        PReport.txtRoute.Enabled = True
        PReport.cmbSPO.Enabled = True
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub SupplyVanSalesComissionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplyVanSalesComissionToolStripMenuItem.Click
        ReportName = "Supply Van Sales Comission Report"
        rptName = ReportPath + "SVSalesComissionReport.rpt"
        Dim PReport As New PeriodicReports
        PReport.txtRoute.Enabled = True
        PReport.cmbSPO.Enabled = True
        PReport.txtRoute.Text = "K"
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub TurnOverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TurnOverToolStripMenuItem.Click
        rptName = ReportPath + "Turnover.rpt"
        ReportName = "Turnover Report"
        Dim PReport As New PeriodicReports
        PReport.txtRoute.Enabled = True
        PReport.cmbSPO.Enabled = True
        PReport.txtDays.Enabled = True
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub AllBooksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllBooksToolStripMenuItem.Click
        rptName = ReportPath + "AllBooks.rpt"
        ReportName = "All Books Report"
        Dim PReport As New PeriodicReports
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub PointsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PointsToolStripMenuItem.Click
        rptName = ReportPath + "Points.rpt"
        ReportName = "Customer Points Report"
        Dim PReport As New PeriodicReports
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub CancelledItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelledItemsToolStripMenuItem.Click
        rptName = ReportPath + "Cancelled Items.rpt"
        ReportName = "Cancelled Items"
        Dim PReport As New PeriodicReports
        PReport.txtCompany.Enabled = True
        PReport.cmbSPO.Enabled = True
        PReport.txtRoute.Enabled = True
        PReport.txtPRID.Enabled = True
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        FrmChangePassword.Show()
    End Sub

    Private Sub RouteAgingReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RouteAgingReportToolStripMenuItem.Click
        rptName = ReportPath + "CustomerAgingReport.rpt"
        ReportName = "Route Aging Report"
        Dim PReport As New PeriodicReports
        PReport.MdiParent = Me
        PReport.cmbSPO.Enabled = True
        PReport.txtRoute.Enabled = True
        PReport.txtCustomerID.Enabled = True
        PReport.txtCustomerName.Enabled = True
        PReport.Show()
    End Sub

    Private Sub GRIDTESTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GRIDTESTToolStripMenuItem.Click
        GridTest.MdiParent = Me
        GridTest.Show()
    End Sub

    Private Sub IDColumnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IDColumnToolStripMenuItem.Click
        ChangeIdColumn()
    End Sub

    Private Sub RouteCallsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RouteCallsToolStripMenuItem.Click
        rptName = ReportPath + "RouteCalls.rpt"
        ReportName = "Route Calls"
        Dim PReport As New PeriodicReports
        PReport.MdiParent = Me
        PReport.txtRoute.Enabled = True
        PReport.Show()
    End Sub

    Private Sub RouteCallsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RouteCallsToolStripMenuItem1.Click
        frmRouteCalls.MdiParent = Me
        frmRouteCalls.Show()
    End Sub

    Private Sub CustomerDemandProductWiseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerDemandProductWiseToolStripMenuItem.Click
        rptName = ReportPath + "Customer Sale Company Wise.rpt"
        ReportName = "Customer Sale Company Wise"
        Dim PReport As New PeriodicReports
        PReport.MdiParent = Me
        PReport.txtCompany.Enabled = True
        PReport.txtCustomerID.Enabled = True
        PReport.Show()
    End Sub

    Private Sub SPOOrderSummaryCompanyWiseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SPOOrderSummaryCompanyWiseToolStripMenuItem.Click
        ReportName = "SPO ORDER SUMMARY COMPANY WISE"
        rptName = ReportPath + "SPO ORDER SUMMARY COMPANY WISE.rpt"
        Dim PReport As New PeriodicReports
        PReport.txtRoute.Enabled = True
        PReport.cmbSPO.Enabled = True
        PReport.txtRoute.Text = ""
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub RecoveryConfirmationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecoveryConfirmationToolStripMenuItem.Click
        frmRecovery.MdiParent = Me
        frmRecovery.Show()
    End Sub

    Private Sub CashCounterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashCounterToolStripMenuItem.Click
        Dim CC As New CashCounter
        CC.MdiParent = Me
        CC.Show()
    End Sub

    Private Sub InvoiceListToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles InvoiceListToolStripMenuItem1.Click
        frmInvoiceList.Show()
    End Sub

    Private Sub DailySaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailySaleToolStripMenuItem.Click
        rptName = ReportPath + "SupplyVanSales.rpt"
        Dim PReport As New PeriodicReports
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    Private Sub SetUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetUpToolStripMenuItem.Click
        frmSettings.MdiParent = Me
        frmSettings.Show()
    End Sub

    Private Sub AttendenceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AttendenceToolStripMenuItem.Click
        attendence.MdiParent = Me
        attendence.Show()
    End Sub

    Private Sub LastReceiptDaysToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LastReceiptDaysToolStripMenuItem.Click
        rptName = ReportPath + "LastReceiptDays.rpt"
        ReportName = "Last Receipt Days Report"
        Dim PReport As New PeriodicReports
        PReport.txtRoute.Enabled = True
        PReport.cmbSPO.Enabled = True
        PReport.txtDays.Enabled = True
        PReport.txtDays.Text = "0"
        PReport.MdiParent = Me
        PReport.Show()
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════════
    '  DGV / CONTROL EVENT HANDLERS
    ' ═══════════════════════════════════════════════════════════════════════════

    Private Sub dgvEstimates_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvEstimates.CellFormatting
        If Me.MdiChildren.Length = 0 Then
            If e.ColumnIndex = dgvEstimates.Columns("ColDate").Index Then
                If e.Value < Date.Today.AddDays(-1) Then
                    e.CellStyle.BackColor = Color.Orange
                    e.CellStyle.ForeColor = Color.White
                    e.CellStyle.Font = New Font(dgvEstimates.Font, FontStyle.Bold)
                End If
                If e.Value < Date.Today.AddDays(-8) Then
                    e.CellStyle.BackColor = Color.Red
                    e.CellStyle.ForeColor = Color.White
                    e.CellStyle.Font = New Font(dgvEstimates.Font, FontStyle.Bold)
                End If
                If e.Value = Date.Today.AddDays(1) Then
                    e.CellStyle.BackColor = Color.Green
                    e.CellStyle.ForeColor = Color.White
                    e.CellStyle.Font = New Font(dgvEstimates.Font, FontStyle.Bold)
                End If
            End If
            dgvEstimates.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
        End If
    End Sub

    Private Sub dgvAging_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvAging.CellFormatting
        If Me.MdiChildren.Length = 0 Then
            dgvAging.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
        End If
    End Sub

    Private Sub dgvEstimates_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEstimates.CellDoubleClick
        Dim InvNumber = dgvEstimates.SelectedRows(0).Cells(3).Value.ToString
        MsgBox(InvNumber)
        Dim f3 As New Form3
        f3.txtInvoice.Text = InvNumber
        DocNumber = InvNumber
        f3.MdiParent = Me
        f3.Show()
        Form3.LoadDoc(CInt(InvNumber))
        Me.Text = "Invoice - " + f3.txtInvoice.Text
        SendKeys.Send("{enter}")
        f3.txtInvoice.Select()
    End Sub

    Private Sub txtRoute_TextChanged(sender As Object, e As EventArgs) Handles txtRoute.Leave, txtSPO.Leave, txtCustomerName.Leave
    End Sub

    Private Sub txtEstRoute_TextChanged(sender As Object, e As EventArgs) Handles txtEstRoute.TextChanged, txtEstCustomerName.TextChanged
    End Sub

    Private Sub txtRoute_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRoute.KeyDown, txtCustomerName.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            txtRoute.Select()
            txtRoute.SelectAll()
        End If
    End Sub

    Private Sub dtpEstimates_ValueChanged(sender As Object, e As EventArgs) Handles dtpEstimates.ValueChanged
    End Sub

    Private Sub ReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsToolStripMenuItem.Click
    End Sub

    Private Sub DailtBooksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailtBooksToolStripMenuItem.Click
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim report As New ReportDocument
        report.Load(ReportPath + "CustomerAgingReport.rpt")
        Dim dt As DataTable = SQLData("select subsidary,spo,route from coa where spo like '%" & txtSPO.Text & "%' and subsidary like '%" & txtCustomerName.Text & "%' and route like '%" & txtRoute.Text & "%'")
        If dt.Rows.Count > 0 Then
            Dim CusName As String = If(dt.Rows.Count > 0, dt.Rows(0)("Subsidary").ToString(), "--")
            If txtCustomerName.Text = "" Then CusName = " All Route customers "
            Dim RT As String = txtRoute.Text
            Dim SP As String = txtSPO.Text
            For Each tb As CrystalDecisions.CrystalReports.Engine.Table In report.Database.Tables
                tb.LogOnInfo.ConnectionInfo = ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            report.SetParameterValue("SPO", txtSPO.Text)
            report.SetParameterValue("CustomerName", txtCustomerName.Text)
            report.SetParameterValue("Route", txtRoute.Text)
            report.ExportToDisk(ExportFormatType.PortableDocFormat,
                Settings("Temp folder") + "Aging " & CusName & " , " & RT & ", " & SP & ", " & Now.Date.ToString("d") & ".pdf")
            txtCustomerName.Select()
            txtCustomerName.SelectAll()
            DisappearingMsgBox.Show()
        Else
            MsgBox("No Record to export!")
        End If
    End Sub

    Private Sub PrintSupplyVanItemsSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintSupplyVanItemsSummaryToolStripMenuItem.Click
        Dim CheckDate As String = If(Date.Today.DayOfWeek = DayOfWeek.Saturday,
                                     Date.Today.AddDays(-2).ToString("d"),
                                     Date.Today.ToString("d"))
        Dim dt As DataTable = SQLData("select * from psproduct where printstatus is null and entryby='DANISH' and date='" & CheckDate & "'")
        If dt.Rows.Count = 0 Then
            MsgBox("No Record to Print!")
            Return
        End If
        Dim cryRpt As New ReportDocument
        cryRpt.Load(Settings("Reports Folder") + "Daily Supply Sale Summary.rpt")
        Try
            For Each tb As CrystalDecisions.CrystalReports.Engine.Table In cryRpt.Database.Tables
                tb.LogOnInfo.ConnectionInfo = ConInfo
                tb.ApplyLogOnInfo(tb.LogOnInfo)
            Next
            cryRpt.SetParameterValue("User", "DANISH")
            cryRpt.PrintOptions.PrinterName = Settings("Thermal Printer")
            cryRpt.PrintToPrinter(1, False, 0, 0)
            cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat,
                Settings("Temp folder") + "Daily Supply Van Items Summary, Print by:" & frmLogin.UserName.ToUpper & " For " & CheckDate & " Printed By " & Date.Now & ".pdf")
            cryRpt.Close()
            cryRpt.Dispose()
            SQLData("update psproduct set printstatus='Printed',PrintBy='" & frmLogin.UserName & "', PrintDateTime='" & Date.Now & "' where printstatus is null and entryby='DANISH' and date='" & CheckDate & "'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class
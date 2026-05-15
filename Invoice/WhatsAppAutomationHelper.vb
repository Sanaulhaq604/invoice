Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI

Module WASender

#Region "CONFIG"

    Private ReadOnly ConnectionString As String = MainPage.conString
    Private driver As IWebDriver = Nothing
    Private wait As WebDriverWait = Nothing
    Private sessionUnavailableUntil As DateTime = DateTime.MinValue
    Private ReadOnly SessionBackoffMinutes As Integer = 5

#End Region

#Region "SESSION MANAGEMENT"

    Public Sub StartWhatsAppSession()
        If DateTime.Now < sessionUnavailableUntil Then Exit Sub
        If driver IsNot Nothing Then Exit Sub

        Try
            Dim options As New ChromeOptions()
            options.AddArgument("--user-data-dir=C:\WhatsAppProfile")
            options.AddArgument("--profile-directory=Default")
            options.AddArgument("--start-maximized")

            Dim driverFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drivers")
            Dim service = ChromeDriverService.CreateDefaultService(driverFolder)
            service.HideCommandPromptWindow = True

            driver = New ChromeDriver(service, options)
            wait = New WebDriverWait(driver, TimeSpan.FromSeconds(60))

            driver.Navigate().GoToUrl("https://web.whatsapp.com/")

            ' Wait until WhatsApp loads chats
            wait.Until(Function(d) d.FindElements(By.XPath("//div[@id='pane-side']")).Count > 0)

        Catch ex As Exception
            LogError("StartWhatsAppSession", ex)
            sessionUnavailableUntil = DateTime.Now.AddMinutes(SessionBackoffMinutes)
            StopSession()
        End Try
    End Sub

    Public Sub StopSession()
        Try
            If driver IsNot Nothing Then
                driver.Quit()
                driver.Dispose()
            End If
        Catch
        End Try

        driver = Nothing
        wait = Nothing
    End Sub

    Private Sub EnsureSession()
        Try
            If driver Is Nothing Then
                StartWhatsAppSession()
                Exit Sub
            End If
            Dim t = driver.Title
        Catch
            StopSession()
            StartWhatsAppSession()
        End Try
    End Sub

#End Region

#Region "SEND MESSAGE"

    Public Function SendMessage(recipient As String, message As String) As Boolean
        EnsureSession()
        Try
            recipient = CleanNumber(recipient)
            Dim url = $"https://web.whatsapp.com/send?phone={recipient}"
            driver.Navigate().GoToUrl(url)

            ' Wait until chat input appears or invalid number notice
            wait.Until(Function(d)
                           Return d.FindElements(By.XPath("//footer//div[@contenteditable='true']")).Count > 0 Or
                                  d.FindElements(By.XPath("//*[contains(text(),'not on WhatsApp')]")).Count > 0
                       End Function)

            Dim invalidNotice = driver.FindElements(By.XPath("//*[contains(text(),'not on WhatsApp')]")).FirstOrDefault()
            If invalidNotice IsNot Nothing Then
                LogError("Invalid WhatsApp Number", New Exception(recipient))
                Return False
            End If

            Dim inputBox = driver.FindElement(By.XPath("//footer//div[@contenteditable='true']"))

            ' Send multi-line message as one
            Dim lines = message.Split({Environment.NewLine}, StringSplitOptions.None)
            For i As Integer = 0 To lines.Length - 1
                inputBox.SendKeys(lines(i))
                If i < lines.Length - 1 Then inputBox.SendKeys(Keys.Shift + Keys.Enter)
            Next

            inputBox.SendKeys(Keys.Enter)

            ' Confirm sent
            Return ConfirmMessageSent(message, recipient)

        Catch ex As Exception
            LogError("SendMessage to " + recipient, ex)
            If TypeOf ex Is WebDriverException Then StopSession()
            Return False
        End Try
    End Function

    Public Sub SendMessageWithRetry(number As String, msg As String)
        Dim attempts As Integer = 0
        While attempts < 3
            If SendMessage(number, msg) Then Exit Sub
            attempts += 1
            Thread.Sleep(2000)
            If attempts = 3 Then LogError("SendMessage Retry Failed", New Exception(number))
        End While
    End Sub

#End Region

#Region "SEND MEDIA / ATTACHMENT"

    Public Sub SendMedia(recipient As String, filePath As String, Optional caption As String = "")
        EnsureSession()
        If Not File.Exists(filePath) Then
            LogError("SendMedia", New Exception("File not found: " & filePath))
            Exit Sub
        End If

        Try
            recipient = CleanNumber(recipient)
            driver.Navigate().GoToUrl($"https://web.whatsapp.com/send?phone={recipient}")

            Dim inputBox = wait.Until(Function(d) d.FindElement(By.XPath("//footer//div[@contenteditable='true']")))
            Thread.Sleep(1500)

            Dim attach = wait.Until(Function(d) d.FindElement(By.CssSelector("span[data-icon='clip']")))
            attach.Click()
            Thread.Sleep(700)

            Dim fileInput = wait.Until(Function(d) d.FindElement(By.CssSelector("input[type='file']")))
            fileInput.SendKeys(filePath)
            Thread.Sleep(2500)

            If caption <> "" Then
                inputBox.SendKeys(caption)
                Thread.Sleep(800)
            End If

            inputBox.SendKeys(Keys.Enter)
            Thread.Sleep(2000)

        Catch ex As Exception
            LogError("SendMedia", ex)
            StopSession()
        End Try
    End Sub

    Public Sub SendAttachment(recipient As String, filePath As String)
        SendMedia(recipient, filePath, "")
    End Sub

#End Region

#Region "CONFIRM MESSAGE"

    Private Function ConfirmMessageSent(message As String, recepient As String) As Boolean
        Dim sent As Boolean = False
        Dim timeout = DateTime.Now.AddSeconds(10)
        While DateTime.Now < timeout
            Try
                Dim bubbles = driver.FindElements(By.XPath("//div[contains(@class,'message-out')]"))
                If bubbles.Count > 0 Then
                    sent = True
                    Exit While
                End If
            Catch
            End Try
            Thread.Sleep(300)
        End While

        If Not sent Then LogError("Send Failed", New Exception(recepient + " " + message))
        Return sent
    End Function

#End Region

#Region "SQL HELPER"

    Private Function ExecuteQuery(query As String,
                                  Optional parameters As List(Of SqlParameter) = Nothing) As DataTable
        Dim dt As New DataTable
        Using con As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query, con)
                If parameters IsNot Nothing Then cmd.Parameters.AddRange(parameters.ToArray())
                con.Open()
                If query.Trim.ToUpper.StartsWith("SELECT") Then
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                Else
                    cmd.ExecuteNonQuery()
                End If
            End Using
        End Using
        Return dt
    End Function

#End Region

#Region "BUSINESS LOGIC"

    Public Sub CheckNewReceipts()
        Dim query As String =
        "SELECT l.date,l.type,l.doc,l.acid,
                a.subsidary,
                CASE 
                    WHEN a.ocell2wa='Y' AND a.cell2<>'' THEN a.cell2
                    ELSE ocell
                END AS ocell,
                l.credit Amount,l.narration,l.entryby
         FROM ledgers l
         JOIN coa a ON l.acid=a.id
         WHERE ISNULL(whatsappstatus,'')=''
         AND credit>0
         AND type IN ('CRV','BRV')
         AND l.date > DATEADD(DAY,-2,GETDATE())"

        Dim dt = ExecuteQuery(query)
        Dim rnd As New Random

        For Each row As DataRow In dt.Rows
            Dim mobile As String = row("ocell").ToString().Trim()
            If mobile = "" Then Continue For
            Dim formattedMobile = CleanNumber(mobile)

            Dim msg As String =
$"*Receipt Date:* {CDate(row("date")).ToString("dd-MMM-yyyy")}" & Environment.NewLine &
$"*Customer:* {row("subsidary")}" & Environment.NewLine &
$"*Amount:* {Convert.ToDecimal(row("Amount")).ToString("N0")}" & Environment.NewLine &
$"*Narration:* {row("narration")}" & Environment.NewLine &
$"*Entry By:* {row("entryby")}"

            ' Send message and update row only if sent successfully
            If SendMessage(formattedMobile, msg) Then
                UpdateLedgerStatus(row("type").ToString(), Convert.ToInt32(row("doc")))
            End If

            Thread.Sleep(rnd.Next(2000, 4000))
        Next
    End Sub

    Private Sub UpdateLedgerStatus(type As String, doc As Integer)
        Dim query As String =
        "UPDATE ledgers 
         SET whatsappstatus='SENT'
         WHERE type=@type AND doc=@doc"

        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@type", type),
            New SqlParameter("@doc", doc)
        }
        ExecuteQuery(query, parameters)
    End Sub

#End Region

#Region "HELPERS"

    Private Function CleanNumber(number As String) As String
        If String.IsNullOrWhiteSpace(number) Then Return ""
        Dim digits = New String(number.Where(Function(c) Char.IsDigit(c)).ToArray())
        If digits.StartsWith("0") AndAlso digits.Length >= 10 Then
            Return "92" & digits.Substring(1)
        End If
        Return digits
    End Function

    Private Sub LogError(context As String, ex As Exception)

        Try

            Dim log =
$"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]" & Environment.NewLine &
$"Context: {context}" & Environment.NewLine &
$"Message: {ex.Message}" & Environment.NewLine &
$"Stack: {ex.StackTrace}" & Environment.NewLine & Environment.NewLine

            Dim logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs")
            If Not Directory.Exists(logFolder) Then
                Directory.CreateDirectory(logFolder)
            End If

            Dim logFileName = $"whatsapp_error_{DateTime.Now:yyyy-MM-dd}.log"
            Dim fullPath = Path.Combine(logFolder, logFileName)

            File.AppendAllText(fullPath, log)

        Catch
        End Try

    End Sub

#End Region

End Module
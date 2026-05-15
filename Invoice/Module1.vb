'Module Module1
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft

Public Module DGVRowNumbers

    Sub SendSMS(Mobile As String, msg As String, Optional Svr As String = "1.134")
        If Mobile.Trim = "" Then
            MainPage.msg = "No mobile Number to send SMS"
            DisappearingMsgBox.Show()
            Return
        End If
        Dim winHttpReq As Object
        Dim myURL As String
        myURL = "http://192.168." & Svr & ":8090/SendSMS?username=Sanaulhaq&password=123&phone=" & Mobile & "&message=" & msg
        winHttpReq = CreateObject("winHttp.winHttprequest.5.1")
        winHttpReq.open("post", myURL, False)
        Try
            winHttpReq.send()
            'MainPage.msg = "Message Sent successfully"
            'DisappearingMsgBox.Show()
        Catch ex As Exception
            Clipboard.SetText(ex.Message)
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function PDFExport(InvNo As Integer, Optional Customer As String = "") As String
        Dim cryRpt As New ReportDocument
        Dim InvEst As String = "Invoice "
        Dim FileName As String = ""
        cryRpt.Load(Settings("Reports Folder") + "rptInvoice3A5WithRuns.rpt")
        Dim TempFolder As String = Settings("Temp Folder")
        FileName = TempFolder + InvEst & " # " & InvNo.ToString + " " + Customer & " " & Date.Now.ToString.Replace(":", ".") & ".pdf"
        For Each tb As Table In cryRpt.Database.Tables
            tb.LogOnInfo.ConnectionInfo = MainPage.ConInfo
            tb.ApplyLogOnInfo(tb.LogOnInfo)
        Next
        Try
            cryRpt.SetParameterValue("DocNumber", InvNo)
            cryRpt.SetParameterValue("PreBalance", 0)
            cryRpt.SetParameterValue("CompanyName", 0)
            cryRpt.SetParameterValue("RECPT", 0)
            cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)
            Return FileName
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return ""
        End Try
    End Function

    ' Public method to add row numbers to any DataGridView

    Function Numbers(Amount As String) As Double
        If Amount = Nothing Then
            Return 0
        End If

        If Amount = "" Or Amount = " " Then
            Return 0
        End If
        If Not IsNumeric(Amount) Then
            Return 0
        End If
        'Amount = Double.Parse(Amount)
        'Return Amount
        Return CDbl(Amount)
    End Function

    Public Sub AddRowNumbers(ByVal dgv As DataGridView, ByVal e As DataGridViewRowPostPaintEventArgs)
        Dim rowNumber As String = (e.RowIndex + 1).ToString()
        Dim headerBounds As Rectangle = New Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height)

        ' Define Arial Bold font
        Dim font As New Font("Arial", 10, FontStyle.Bold)

        ' Get the selection color (blue) from DataGridView style
        Dim selectionColor As Color = dgv.DefaultCellStyle.SelectionBackColor

        ' Fill the background with the selection color
        Using brush As New SolidBrush(selectionColor)
            e.Graphics.FillRectangle(brush, headerBounds)
        End Using

        ' Define text format
        Dim drawFormat As New StringFormat()
        drawFormat.Alignment = StringAlignment.Center
        drawFormat.LineAlignment = StringAlignment.Center

        ' Draw the row number in White for contrast
        e.Graphics.DrawString(rowNumber, font, Brushes.White, headerBounds, drawFormat)

        ' Create a pen with 1-pixel thickness (matching DataGridView grid lines)
        Dim pen As New Pen(dgv.GridColor, 1)

        ' Draw vertical separator line (between row header and data)
        e.Graphics.DrawLine(pen, headerBounds.Right - 1, headerBounds.Top, headerBounds.Right - 1, headerBounds.Bottom)

        ' Draw horizontal separator line (between rows)
        e.Graphics.DrawLine(pen, headerBounds.Left, headerBounds.Bottom - 1, headerBounds.Right, headerBounds.Bottom - 1)
    End Sub

    Public Function Settings(Parameter As String) As String
        Dim DT As DataTable = txt_to_data("D:\Settings.txt", True, "=")
        Dim DRows() As DataRow = DT.Select("PARAMETER='" & Parameter & "'")
        Dim ReturnValue As String = ""
        If DRows.Length > 0 Then
            For Each row As DataRow In DRows
                ReturnValue = row(1).ToString
            Next
        End If
        If Parameter.EndsWith("Folder") Then
            If Not ReturnValue.EndsWith("\") Then
                ReturnValue += "\"
            End If
        End If
        'If Parameter = "Reports Path" Then
        '    ReturnValue = "\\" + MySqlServer + "\" + ReturnValue
        'End If

        Return ReturnValue
    End Function

    Public Function txt_to_data(ByVal filename As String, ByVal header As Boolean, ByVal delimiter As String) As DataTable
        'New datatable
        Dim dt As DataTable = New DataTable

        'Read the contents of the textfile into an array
        Dim sr As IO.StreamReader = New IO.StreamReader(filename)
        Dim txtlines() As String = sr.ReadToEnd.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
        sr.Close()
        'Return nothing if there's nothing in the textfile
        If txtlines.Count = 0 Then
            Return Nothing
        End If

        Dim column_count As Integer = 0
        For Each col As String In txtlines(0).Split({delimiter}, StringSplitOptions.None)
            If header Then
                'If there's a header then add it by it's name
                dt.Columns.Add(col)
                dt.Columns(column_count).Caption = col
            Else
                'If there's no header then add it by the column count
                dt.Columns.Add(String.Format("Column{0}", column_count))
                dt.Columns(column_count).Caption = String.Format("Column{0}", column_count + 1)
            End If

            column_count += 1
        Next

        If header Then
            For rows As Integer = 1 To txtlines.Count - 1 'start at one because there's a header for the first line(0)
                'Declare a new datarow
                Dim dr As DataRow = dt.NewRow

                'Set the column count back to 0, we can reuse this variable ;]
                column_count = 0
                For Each col As String In txtlines(rows).Split({delimiter}, StringSplitOptions.None) 'Each column in the row
                    'The column in cue is set for the datarow
                    dr(column_count) = col
                    column_count += 1
                Next

                'Add the row
                dt.Rows.Add(dr)
            Next
        Else
            For rows As Integer = 0 To txtlines.Count - 1 'start at zero because there's no header
                'Declare a new datarow
                Dim dr As DataRow = dt.NewRow

                'Set the column count back to 0, we can reuse this variable ;]
                column_count = 0
                For Each col As String In txtlines(rows).Split({delimiter}, StringSplitOptions.None) 'Each column in the row
                    'The column in cue is set for the datarow
                    dr(column_count) = col
                    column_count += 1
                Next

                'Add the row
                dt.Rows.Add(dr)
            Next
        End If

        Return dt
    End Function
    Public Function SQLData(Q As String, Optional doc As Integer = 1) As DataTable
        ' MainPage.conString = "Server=100.122.80.93;Database=AHMADINTERNATIONAL;User ID=sa;Password=Ai;;Connection Timeout=45"
        Dim con As New SqlConnection(MainPage.conString)

        Dim cmd As String

        Dim dt As New DataTable
        cmd = Q
        Dim da As New SqlDataAdapter(cmd, con)
        'Try
        con.Open()
            da.Fill(dt)
            con.Close()
        'Catch ex As Exception
        ' Clipboard.SetText(Q + "      " + ex.Message)
        'MessageBox.Show(Q + "      " + ex.Message)
        'Return Nothing

        'End Try
        Return dt
    End Function

    Public Function SQLImageData(Q As String, Optional doc As Integer = 1) As DataTable
        Dim con As New SqlConnection(MainPage.conString2)

        Dim cmd As String

        Dim dt As New DataTable
        cmd = Q
        Dim da As New SqlDataAdapter(cmd, con)
        Try
            con.Open()
            da.Fill(dt)
            con.Close()
        Catch ex As Exception
            Clipboard.SetText(Q + "      " + ex.Message)
            MessageBox.Show(Q + "      " + ex.Message)

        End Try
        Return dt
    End Function

    Public Function GetTotals(txtAcID As String, txtDescription As String, txtDoc As String, txtNumber As String, dtpStart As DateTimePicker, DtpEnd As DateTimePicker, match As String) As DataTable
        Dim dtTotals As DataTable = SQLData("select isnull(sum(debit),0) totDebit, isnull(sum(credit),0) totCredit from ledgers where acid= '" & txtAcID & "'  and narration like '%" & txtDescription & "%' AND TYPE like '" & txtDoc & "%' and doc like '" & txtNumber & "%'  and date>='" & dtpStart.Value & "' and date<='" & DtpEnd.Value & "' and isnull(status,0) like '%" & match & "'  ")
        Return dtTotals
    End Function

    Function PreBalance(ACID As String, dte As Date, DocType As String, DocNumber As Integer) As String
        Dim PreBal As DataTable = SQLData("select isnull(sum(isnull(debit,0))-sum(isnull(credit,0)),0) PreBal from ledgers where acid=" & ACID & " and date<='" & dte & "' and '" & DocType & "'+cast(doc as varchar(10))<>'" & DocType & "'+ cast(" & DocNumber & " as varchar(10)) and acid<>1")
        Dim PreviousBalance As String
        If PreBal.Rows.Count > 0 Then
            PreviousBalance = PreBal.Rows(0)(0)
        Else
            PreviousBalance = 0
        End If
        Return PreviousBalance
    End Function

    Function DateChange(Dte As Date) As String
        Dim YName As String = Year(Dte)
        Dim MName As String = Month(Dte)
        Dim dt As String = Dte.ToString.Substring(0, 2)
        Dim INVDATE2 As String = YName + "-" + MName + "-" + dt
        Return INVDATE2
    End Function



End Module
'End Module

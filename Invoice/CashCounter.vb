Imports System.Drawing.Imaging
Imports System.IO

Public Class CashCounter
    Private Sub TextBox_GotFocus(sender As Object, e As EventArgs)
        CType(sender, TextBox).SelectAll()
    End Sub
    Dim RouteDT As DataTable
    Sub RouteCalculation()
        RouteDT = SQLData($"SELECT l.Date,acid,type,doc,NARRATION,isnull(Credit,0) Credit,isnull(Debit,0) Debit,ReceiptStatus,format(EntryDateTime,'dd-MM-yy HH:mm:ss') EntryDateTime
        FROM LEDGERS L JOIN COA A ON L.ACID=A.ID WHERE L.DATE>='{dtpDate.Value.ToString("d")}' and L.date<='{dtpToDate.Value.ToString("d")}'  AND NARRATION LIKE '%{txtFrom.Text}%' AND (ROUTE LIKE '{txtRoute.Text}%' or route='') AND ACID<>1 AND TYPE in ('CRV','CPV') and receiptstatus is null")
        Dim RouteTotal As Integer = 0
        If RouteDT.Rows.Count > 0 Then
            For Each row As DataRow In RouteDT.Rows
                RouteTotal += Numbers(row("Credit").ToString() - row("debit").ToString())
            Next
        End If
        lblCash.Text = Form3.Amt(RouteTotal)
        Calculations()
    End Sub


    ' Add this in the form's constructor or Load event to wire up all TextBoxes
    Private Sub CashCounter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                AddHandler CType(ctrl, TextBox).KeyDown, AddressOf TextBox_KeyDown
                AddHandler CType(ctrl, TextBox).GotFocus, AddressOf TextBox_GotFocus
            End If
        Next
    End Sub

    ' This event handler will move focus to the next control when Enter is pressed
    Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not Val(txtTotalAmount.Text) > 0 Then
            MessageBox.Show("Please enter a valid total amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If txtRoute.Text = "" And txtFrom.Text = "" Then
            MessageBox.Show("Please fill in the ROUTE and FROM fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        If frmLogin.UserLevel.ToUpper = "ADMIN" Then
            Dim result As DialogResult = MessageBox.Show("Confirm Selected Vouchers ??", "Recovery Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If result = DialogResult.Yes Then
                If RouteDT.Rows.Count > 0 Then
                    For Each row As DataRow In RouteDT.Rows
                        Dim acid As Integer = row("acid")
                        Dim doc As String = row("doc")
                        Dim type As String = row("type")
                        SQLData($"UPDATE LEDGERS SET ReceiptStatus='Cash Counter', narration=replace(narration,'PENDING - ','') WHERE ACID={acid} AND type='{type}' and DOC='{doc}'")
                    Next
                End If
            End If
        End If
        Try
            ' Capture screenshot
            Dim Group As String = cmbWahstappGroup.Text
            Dim bmp As New Bitmap(Me.Width, Me.Height)
            Dim captureHeight As Integer = Me.Height - GroupBox2.Height - 10
            Me.DrawToBitmap(bmp, New Rectangle(0, 0, Me.Width, captureHeight))

            ' Save to file
            Dim fileName As String = "Route #" & txtRoute.Text + " From " & txtFrom.Text & ".jpg"
            Dim filePath As String = Path.Combine(Settings("TEMP FOLDER"), fileName)
            bmp.Save(filePath, ImageFormat.Jpeg)

            ' Initialize and send WhatsApp message
            WASender.StartWhatsAppSession()

            'WhatsAppAutomationHelper.SendMessage("ai Recovery Suzuki", "Please find attached screenshot: " & fileName)
            If Group <> "" Then
                Dim Caption As String = "Route # " & txtRoute.Text + " From " & txtFrom.Text & " Total Amount: " & txtTotalAmount.Text & " Dated '" & dtpDate.Value.ToString("d") & "'"
                WASender.SendMedia(Group, filePath, Caption)
                WASender.SendMessage("Sanaulhaq Mobilink", Caption)
                'WASender.SendMessage("923308581600", Caption)
            End If

            'WhatsAppAutomationHelper.SendAttachment("923008551600", "D:\Google Drive ai\DB Backup\Invoice Temp\Ledger Acc # 244, SUNNY AUTOS TOBA ~~.pdf")
            'MessageBox.Show("Screenshot saved and message sent via WhatsApp.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Clipboard.SetText(ex.Message)
            MessageBox.Show("Error: " & ex.Message)

        End Try
    End Sub

    Private Sub txt5000_TextChanged(sender As Object, e As EventArgs) Handles txt5000.TextChanged, txt1000.TextChanged, txt500.TextChanged, txt100.TextChanged, txt50.TextChanged, txt20.TextChanged, txt10.TextChanged
        Calculations()
    End Sub

    Sub Calculations()
        txtTotal5000.Text = Form3.Amt(Val(txt5000.Text) * 5000)
        txtTotal1000.Text = Form3.Amt(Val(txt1000.Text) * 1000)
        txtTotal500.Text = Form3.Amt(Val(txt500.Text) * 500)
        txtTotal100.Text = Form3.Amt(Val(txt100.Text) * 100)
        txtTotal50.Text = Form3.Amt(Val(txt50.Text) * 50)
        txtTotal20.Text = Form3.Amt(Val(txt20.Text) * 20)
        txtTotal10.Text = Form3.Amt(Val(txt10.Text) * 10)
        txtTotalAmount.Text = Form3.Amt(Numbers(txtTotal5000.Text) + Numbers(txtTotal1000.Text) + Numbers(txtTotal500.Text) + Numbers(txtTotal100.Text) + Numbers(txtTotal50.Text) + Numbers(txtTotal20.Text) + Numbers(txtTotal10.Text))
        txtDiff.Text = Form3.Amt(Numbers(txtTotalAmount.Text) - Numbers(lblCash.Text))
        If Numbers(txtDiff.Text) <> 0 Then
            txtDiff.BackColor = Color.Red
            txtDiff.ForeColor = Color.White
        Else
            txtDiff.BackColor = Color.LightGreen
            txtDiff.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        WASender.StopSession()
        MyBase.OnFormClosing(e)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim result As DialogResult = MessageBox.Show("Clear all Textboxes ??", "Form Refresh", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result = DialogResult.Yes Then
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is TextBox Then
                    CType(ctrl, TextBox).Text = String.Empty
                End If
            Next
            cmbWahstappGroup.SelectedIndex = -1
            txtRoute.Focus()
        End If
    End Sub

    Private Sub txtRoute_Leave(sender As Object, e As EventArgs) Handles txtRoute.Leave, txtRoute.Leave, dtpDate.Leave, dtpToDate.Leave
        RouteCalculation()
    End Sub
End Class

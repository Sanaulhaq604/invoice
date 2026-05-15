Imports System.Data.SqlClient
Public Class BRV
    Dim SessionRecovery As Integer = 0
    Private _selectedImageBytes() As Byte = Nothing
    Private _pbThumb As PictureBox = Nothing
    Private _btnAttach As Button = Nothing
    Dim LastVocuher As Integer = 0
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub BRV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDoc.Text = "Bank Receipt Voucher - " + frmLogin.MySqlServer + " - " + frmLogin.UserLevel
        Me.Text = "Bank Receipt Voucher"
        vno()
        dgvUpdate()
        EnsureImageAttachControls()
        'dgvCRV.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvCRV.Columns("Amount").DefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
        'dgvCRV.Columns("Amount").DefaultCellStyle.Format = "N2"
    End Sub

    Private Sub EnsureImageAttachControls()
        Try
            ' Create attach button next to save button
            Dim parentCtrl As Control = If(ctbSave.Parent, CType(Me, Control))
            If _btnAttach Is Nothing Then
                _btnAttach = New Button()
                _btnAttach.Text = "Attach Image"
                _btnAttach.Width = 100
                _btnAttach.Height = ctbSave.Height
                ' place the attach button below the save button to avoid overlapping other buttons
                _btnAttach.Top = ctbSave.Top
                _btnAttach.Left = ctbSave.Left - ctbSave.Width - 300
                AddHandler _btnAttach.Click, AddressOf BtnAttach_Click
                parentCtrl.Controls.Add(_btnAttach)
                _btnAttach.BringToFront()
                _btnAttach.Anchor = AnchorStyles.Left Or AnchorStyles.Top
            End If

            ' Create thumbnail box beside the attach button so it doesn't overlap other controls
            If _pbThumb Is Nothing Then
                _pbThumb = New PictureBox()
                _pbThumb.Width = _btnAttach.Width
                _pbThumb.Height = _btnAttach.Height
                _pbThumb.Left = _btnAttach.Left + _btnAttach.Width + 8
                _pbThumb.Top = _btnAttach.Top
                _pbThumb.BorderStyle = BorderStyle.FixedSingle
                _pbThumb.SizeMode = PictureBoxSizeMode.StretchImage
                _pbThumb.Visible = False
                parentCtrl.Controls.Add(_pbThumb)
                _pbThumb.BringToFront()
                _pbThumb.Anchor = AnchorStyles.Left Or AnchorStyles.Top
            End If

            ' Initially disable save until image attached
            ctbSave.Enabled = False
        Catch
        End Try
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs)
        Try
            Using ofd As New OpenFileDialog()
                ofd.Title = "Select Image for BRV"
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
                If ofd.ShowDialog() = DialogResult.OK Then
                    Dim path = ofd.FileName
                    Dim imgBytes() As Byte = IO.File.ReadAllBytes(path)
                    If imgBytes IsNot Nothing AndAlso imgBytes.Length > 0 Then
                        _selectedImageBytes = imgBytes
                        Using ms As New IO.MemoryStream(imgBytes)
                            Dim img = Image.FromStream(ms)
                            _pbThumb.Image = img
                            _pbThumb.Visible = True
                        End Using
                        ctbSave.Enabled = True
                    Else
                        MsgBox("Selected file could not be read as an image.")
                    End If
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error selecting image: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadAttachedImage(docNumber As String)
        Try
            If String.IsNullOrWhiteSpace(docNumber) Then
                _selectedImageBytes = Nothing
                If _pbThumb IsNot Nothing Then _pbThumb.Visible = False
                ctbSave.Enabled = False
                Return
            End If

            Dim q As String = "SELECT TOP 1 IMAGE FROM name_reciepts WHERE [type]='BRV' AND doc='" & docNumber.Replace("'", "''") & "'"
            Dim dtImg As DataTable = SQLImageData(q)
            If dtImg.Rows.Count > 0 AndAlso Not IsDBNull(dtImg.Rows(0)(0)) Then
                Dim imgBytes() As Byte = DirectCast(dtImg.Rows(0)(0), Byte())
                If imgBytes IsNot Nothing AndAlso imgBytes.Length > 0 Then
                    _selectedImageBytes = imgBytes
                    If _pbThumb IsNot Nothing Then
                        Using ms As New IO.MemoryStream(imgBytes)
                            Dim img = Image.FromStream(ms)
                            _pbThumb.Image = img
                            _pbThumb.Visible = True
                        End Using
                    End If
                    ' existing image means save can proceed (editing)
                    ctbSave.Enabled = True
                    Return
                End If
            End If

            ' no image found
            _selectedImageBytes = Nothing
            If _pbThumb IsNot Nothing Then
                _pbThumb.Image = Nothing
                _pbThumb.Visible = False
            End If
            ctbSave.Enabled = False
        Catch ex As Exception
            ' ignore; keep UI consistent
            _selectedImageBytes = Nothing
            If _pbThumb IsNot Nothing Then _pbThumb.Visible = False
            ctbSave.Enabled = False
        End Try
    End Sub

    Sub dgvUpdate()
        'MsgBox(dtp1.Value.ToString("d"))

        Dim dt2 As DataTable = SQLData("SELECT 
    ROW_NUMBER() OVER (ORDER BY l.date) AS RN,
    l.id,
    l.date,
    l.doc,
    l.acid,
    a.subsidary,
    l.narration,
    l.credit,
    r.RecAcc,
    ca.Subsidary AS RecParty
FROM ledgers l
JOIN coa a ON l.acid = a.id
OUTER APPLY (
    SELECT TOP 1 l2.acid AS RecAcc
    FROM ledgers l2
    WHERE l2.type = 'brv' 
      AND l2.doc = l.doc 
      AND l2.debit IS NOT NULL
) r
LEFT JOIN coa ca ON ca.id = r.RecAcc
WHERE l.type = 'brv'
  AND l.date = '" & dtp1.Value.ToString("d") & "'
  AND l.credit IS NOT NULL
ORDER BY l.doc;

")




        'Dim dt2 As DataTable = SQLData("select ROW_NUMBER() over (order by l.date) rn,l.Date,Doc,l.acid,a.subsidary Title,Narration,isnull(credit,0) Amount from ledgers l join coa a on l.Acid=a.Id where type='BRV' and l.date='" & dtp1.Value.ToString("d") & "' and acid<>1 order by doc")
        'MsgBox(dt2.Rows.Count)

        dgvCRV.DataSource = dt2


    End Sub

    Private Sub dtp1_Leave(sender As Object, e As EventArgs) Handles dtp1.Leave, dtp1.ValueChanged
        dgvUpdate()

        ' Load any previously attached image for this BRV
        LoadAttachedImage(txtCRVNo.Text)
    End Sub

    Sub save()
        Dim ConditionalInsertQuery As String = ""
        Dim ConditionalInsertValue As String = ""
        Dim Narr As String = ""
        If frmLogin.UserLevel.ToUpper = "ADMIN" Or frmLogin.UserLevel.ToUpper = "SUPERVISOR" Then
            ConditionalInsertQuery = ",ReceiptStatus"
            ConditionalInsertValue = ",'BRV'"
            Narr = txtNarration.Text
        Else
            ConditionalInsertQuery = ""
            ConditionalInsertValue = ""
            Narr = "Pending - Entry by " & frmLogin.UserName & " ," & txtNarration.Text
        End If
        ' If no image bytes selected, prompt to attach image then abort save so user can confirm
        If _selectedImageBytes Is Nothing OrElse _selectedImageBytes.Length = 0 Then
            If _btnAttach IsNot Nothing Then _btnAttach.PerformClick()
            Return
        End If

        Dim dt As DataTable = SQLData("select doc from docnumber where type='BRV'")
        If txtCRVNo.Text = LastVocuher Then
            SQLData("update docnumber set doc=" & LastVocuher + 1 & " where type='BRV'")
        End If
        Dim UpdateLedgers As String = String.Format("
                                                    if (select count(*) from Ledgers where type='BRV' and doc=" & txtCRVNo.Text & ")=0
                                                        begin
                                                        insert into ledgers (date,type,doc,acid,narration,credit,EntryBy,EntryDateTime" & ConditionalInsertQuery & ")
                                                        select '" & dtp1.Value.ToString("d") & "','BRV'," & txtCRVNo.Text & "," & txtReceivedFromID.Text & ",N'" & Narr & "'," & Form3.Numbers(txtAmount.Text) & ", '" & frmLogin.UserName & "','" & Date.Now & "'" & ConditionalInsertValue & "

                                                        insert into ledgers (date,type,doc,acid,narration,debit,EntryBy,EntryDateTime" & ConditionalInsertQuery & ")
                                                        select '" & dtp1.Value.ToString("d") & "','BRV'," & txtCRVNo.Text & "," & txtACID.Text & ",N'" & Narr & "'," & Form3.Numbers(txtAmount.Text) & ", '" & frmLogin.UserName & "','" & Date.Now & "'" & ConditionalInsertValue & "

                                                        insert into ledgersHistory (date,type,doc,acid,narration,credit,UserName,UserLevel,EntryDate,EntryStatus)
                                                        select '" & dtp1.Value.ToString("d") & "','BRV'," & txtCRVNo.Text & "," & txtReceivedFromID.Text & ",N'" & Narr & "'," & Form3.Numbers(txtAmount.Text) & ",'" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "' , 'SAVE'

                                                       insert into ledgersHistory (date,type,doc,acid,narration,DEBIT,UserName,UserLevel,EntryDate,EntryStatus)
                                                        select '" & dtp1.Value.ToString("d") & "','BRV'," & txtCRVNo.Text & "," & txtACID.Text & ",N'" & Narr & "'," & Form3.Numbers(txtAmount.Text) & ",'" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "' , 'SAVE'

                                                        end
                                                    else
                                                        begin
                                                        update ledgers set acid=" & txtReceivedFromID.Text & ",date='" & dtp1.Value.ToString("d") & "',narration=N'" & txtNarration.Text & "',credit=" & Form3.Numbers(txtAmount.Text) & " where type='BRV' and doc=" & txtCRVNo.Text & " and credit is not null
                                                        update ledgers set acid= " & txtACID.Text & ",date='" & dtp1.Value.ToString("d") & "',narration=N'" & txtNarration.Text & "',debit =" & Form3.Numbers(txtAmount.Text) & " where type='BRV' and doc=" & txtCRVNo.Text & " and debit is not null
                                                        
                                                       insert into ledgersHistory (date,type,doc,acid,narration,DEBIT,UserName,UserLevel,EntryDate,EntryStatus)
                                                        select '" & dtp1.Value.ToString("d") & "','BRV'," & txtCRVNo.Text & "," & txtReceivedFromID.Text & ",N'" & txtNarration.Text & "'," & Form3.Numbers(txtAmount.Text) & ",'" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "' , 'EDIT'

                                                       insert into ledgersHistory (date,type,doc,acid,narration,credit,UserName,UserLevel,EntryDate,EntryStatus)
                                                        select '" & dtp1.Value.ToString("d") & "','BRV'," & txtCRVNo.Text & "," & txtACID.Text & ",N'" & txtNarration.Text & "'," & Form3.Numbers(txtAmount.Text) & ",'" & frmLogin.UserName & "','" & frmLogin.UserLevel & "','" & Date.Now & "' , 'EDIT'
                                                        
                                                        end
                                                    ")

        SQLData(UpdateLedgers)
        ' Ensure an image was attached before finalizing save
        If _selectedImageBytes Is Nothing OrElse _selectedImageBytes.Length = 0 Then
            MsgBox("Please attach an image before saving the BRV.")
            Return
        End If

        ' Save image to images database (name_reciepts) with type='BRV' and doc = txtCRVNo.Text
        Try
            Using con As New SqlConnection(MainPage.conString2)
                con.Open()
                Using cmdExist As New SqlCommand("SELECT COUNT(1) FROM name_reciepts WHERE [type]=@type AND doc=@doc", con)
                    cmdExist.Parameters.AddWithValue("@type", "BRV")
                    cmdExist.Parameters.AddWithValue("@doc", txtCRVNo.Text)
                    Dim exists As Integer = CInt(cmdExist.ExecuteScalar())

                    If exists > 0 Then
                        Using cmdUpd As New SqlCommand("UPDATE name_reciepts SET image = @img WHERE [type]=@type AND doc=@doc", con)
                            cmdUpd.Parameters.AddWithValue("@img", _selectedImageBytes)
                            cmdUpd.Parameters.AddWithValue("@type", "BRV")
                            cmdUpd.Parameters.AddWithValue("@doc", txtCRVNo.Text)
                            cmdUpd.ExecuteNonQuery()
                        End Using
                    Else
                        Using cmdIns As New SqlCommand("INSERT INTO name_reciepts (doc,[type],image) VALUES (@doc,@type,@img)", con)
                            cmdIns.Parameters.AddWithValue("@doc", txtCRVNo.Text)
                            cmdIns.Parameters.AddWithValue("@type", "BRV")
                            cmdIns.Parameters.AddWithValue("@img", _selectedImageBytes)
                            cmdIns.ExecuteNonQuery()
                        End Using
                    End If

                    ' Optionally update audit columns if they exist (username instead of EntryBy)
                    Using cmdAudit As New SqlCommand(
                        "IF COL_LENGTH('dbo.name_reciepts','username') IS NOT NULL BEGIN UPDATE name_reciepts SET username=@user WHERE [type]=@type AND doc=@doc END; " &
                        "IF COL_LENGTH('dbo.name_reciepts','DateTime') IS NOT NULL BEGIN UPDATE name_reciepts SET DateTime=GETDATE() WHERE [type]=@type AND doc=@doc END; " &
                        "IF COL_LENGTH('dbo.name_reciepts','acid') IS NOT NULL BEGIN UPDATE name_reciepts SET acid=@acid WHERE [type]=@type AND doc=@doc END;", con)
                        cmdAudit.Parameters.AddWithValue("@user", frmLogin.UserName)
                        cmdAudit.Parameters.AddWithValue("@type", "BRV")
                        cmdAudit.Parameters.AddWithValue("@doc", txtCRVNo.Text)
                        Dim acidVal As Integer = 0
                        Integer.TryParse(txtReceivedFromID.Text, acidVal)
                        cmdAudit.Parameters.AddWithValue("@acid", acidVal)
                        cmdAudit.ExecuteNonQuery()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Failed to save attached image: " & ex.Message)
        End Try
        ' Clear image from memory and thumbnail after entry saved
        Try
            _selectedImageBytes = Nothing
            If _pbThumb IsNot Nothing Then
                If _pbThumb.Image IsNot Nothing Then
                    _pbThumb.Image.Dispose()
                End If
                _pbThumb.Image = Nothing
                _pbThumb.Visible = False
            End If
            If ctbSave IsNot Nothing Then ctbSave.Enabled = False
        Catch
            ' ignore any dispose errors
        End Try
        If chkSMS.Checked = True Then
            SMS(txtOCell.Text, txtRecdFromMobile.Text, txtCRVNo.Text, txtAmount.Text, dtp1.Value, txtSMServer.Text)
        End If
        SessionRecovery += Form3.Numbers(txtAmount.Text)
        txtSessionTotal.Text = SessionRecovery
        textclear()
        vno()
        dgvUpdate()
        If dgvCRV.Rows.Count > 0 Then

            dgvCRV.FirstDisplayedScrollingRowIndex = dgvCRV.Rows.Count - 1
            dgvCRV.Rows(dgvCRV.Rows.Count - 1).Selected = True
        End If
        txtACID.Select()

    End Sub

    Sub textclear()
        txtACID.Clear()
        txtAmount.Clear()
        txtReceivedInTitle.Clear()
        txtReceivedFromID.Clear()
        txtReceivedFromTitle.Clear()
        txtNarration.Clear()
    End Sub

    Sub vno()
        Dim dt As DataTable = SQLData("select isnull(max(doc),0)+1 from ledgers where type='BRV'")
        If dt.Rows.Count > 0 Then
            txtCRVNo.Text = dt.Rows(0)(0)
            LastVocuher = Val(dt.Rows(0)(0))

        End If
    End Sub

    Private Sub ctbSave_Click(sender As Object, e As EventArgs) Handles ctbSave.Click
        save()
    End Sub


    Private Sub txtAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAmount.KeyDown, txtSessionTotal.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Only enforce image selection for the BRV amount textbox (not session total)
            If sender Is txtAmount Then
                If _selectedImageBytes Is Nothing OrElse _selectedImageBytes.Length = 0 Then
                    ' Open file selection dialog via the attach button. Do not save yet.
                    If _btnAttach IsNot Nothing Then _btnAttach.PerformClick()
                    ' If user did not select an image, return focus to amount textbox
                    If _selectedImageBytes Is Nothing OrElse _selectedImageBytes.Length = 0 Then
                        txtAmount.Select()
                        e.SuppressKeyPress = True
                        Return
                    End If
                End If
                ' If image is already selected (or selected just now), proceed to save
                save()
            Else
                ' For other controls (like txtSessionTotal) just save
                save()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtACID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtACID.KeyDown

        If e.KeyCode = Keys.Enter Then
            If txtACID.Text = "" Then
                frmPartySearch.ShowDialog()
                txtACID.Text = frmPartySearch.acID
                txtReceivedInTitle.Text = frmPartySearch.CusName
                frmPartySearch.Dispose()
            End If

            e.Handled = True
            'SendKeys.Send("{tab}")

        End If

    End Sub

    Private Sub txtACID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtACID.KeyPress, txtReceivedFromID.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCRVNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCRVNo.KeyDown
        If e.KeyCode = Keys.Down Then
            txtCRVNo.Text = Val(txtCRVNo.Text) - 1
            DocLoad()
        End If
        If e.KeyCode = Keys.Up And txtCRVNo.Text < LastVocuher - 1 Then
            txtCRVNo.Text = Val(txtCRVNo.Text) + 1
            DocLoad()
        End If
        If e.KeyCode = Keys.Enter Then
            DocLoad()
        End If

    End Sub

    Sub PreviousBalance()
        Dim dt As DataTable = SQLData("select isnull(sum(debit),0)-isnull(sum(credit),0) Bal from ledgers where acid=" & txtACID.Text & " and date<='" & dtp1.Value.ToString("d") & "' and doc<>" & txtCRVNo.Text)
        txtPBal.Text = Form3.Amt(dt.Rows(0)("Bal"))
    End Sub

    Sub DocLoad()
        Dim dt As DataTable = SQLData("select l.date,l.acid,a.Subsidary,l.Narration,l.Credit,isnull(UrduName,'') UrduName from ledgers l join coa a on l.acid=a.id where l.type='BRV' and  credit is not null and doc=" & txtCRVNo.Text)
        If dt.Rows.Count = 0 Then
            MsgBox("VOUCHER NOT FOUND!")
            Return
        End If
        dtp1.Value = dt.Rows(0)("date")
        txtReceivedFromID.Text = dt.Rows(0)("acid")
        txtReceivedFromTitle.Text = dt.Rows(0)("subsidary")
        txtNarration.Text = dt.Rows(0)("narration")
        txtAmount.Text = dt.Rows(0)("credit")
        txtRecdFromUrduName.Text = dt.Rows(0)("UrduName")
        dt = SQLData("select l.date,l.acid,a.Subsidary,l.Narration,l.Credit,isnull(UrduName,'') UrduName from ledgers l join coa a on l.acid=a.id where l.type='BRV' and  debit is not null and doc=" & txtCRVNo.Text)
        txtACID.Text = dt.Rows(0)("acid")
        txtReceivedInTitle.Text = dt.Rows(0)("subsidary")
        txtRecdInUrduName.Text = dt.Rows(0)("UrduName")
        dgvUpdate()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        dtp1.Value = Now.Date
        vno()
        textclear()
        dgvUpdate()
        dtp1.Select()
    End Sub

    Sub itemsfromGrid(row As DataGridViewRow)
        If frmLogin.UserLevel.ToUpper <> "ADMIN" And frmLogin.UserLevel.ToUpper <> "SUPERVISOR" Then
            MsgBox("You are not authorized to edit existing voucher!")
            Return
        End If
        txtCRVNo.Text = row.Cells("colDoc").Value.ToString()

        txtACID.Text = row.Cells("colRecAcc").Value.ToString()
        txtReceivedInTitle.Text = row.Cells("ColRecParty").Value.ToString()

        txtReceivedFromID.Text = row.Cells("colACID").Value.ToString()
        txtReceivedFromTitle.Text = row.Cells("colCustomer").Value.ToString()

        txtNarration.Text = row.Cells("colNarration").Value.ToString()
        txtAmount.Text = row.Cells("colAmount").Value.ToString()
        txtAmount.SelectAll()
        txtAmount.Select()
        ' Load image for editing
        LoadAttachedImage(txtCRVNo.Text)
    End Sub

    Private Sub dgvCRV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCRV.CellDoubleClick
        itemsfromGrid(dgvCRV.CurrentRow)
    End Sub

    Private Sub dgvCRV_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvCRV.KeyDown
        If e.KeyCode = Keys.Enter And dgvCRV.Rows.Count > 0 Then
            e.Handled = True
            itemsfromGrid(dgvCRV.CurrentRow)
        End If

    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        txtNBal.Text = Form3.Amt(Form3.Numbers(txtPBal.Text) + Form3.Numbers(txtAmount.Text))
        txtRecdFromNetBalance.Text = Form3.Amt(Math.Abs(Form3.Numbers(txtRecdFromPBalance.Text)) - Form3.Numbers(txtAmount.Text))
        'txtAmount.Text = Form3.Amt(Form3.Numbers(txtAmount.Text))


        txtAmount.Text = Format(Val(Replace(txtAmount.Text, ",", "")), "#,###,###")

        txtAmount.SelectionStart = txtAmount.TextLength

    End Sub

    Private Sub txtReceivedFromID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReceivedFromID.KeyDown

        If e.KeyCode = Keys.Enter And txtReceivedFromID.Text = "" Then
            e.Handled = True
            frmPartySearch.ShowDialog()
            txtReceivedFromID.Text = frmPartySearch.acID
            txtReceivedFromTitle.Text = frmPartySearch.CusName
            frmPartySearch.Dispose()
        End If

    End Sub

    Private Sub txtACID_Enter(sender As Object, e As EventArgs) Handles txtACID.Enter
        If txtACID.Text = "" Then
            frmPartySearch.ShowDialog()
            txtACID.Text = frmPartySearch.acID
            txtReceivedInTitle.Text = frmPartySearch.CusName
            'SendKeys.Send("{TAB}")
        End If
        txtACID.SelectAll()
    End Sub

    Private Sub txtReceivedFromID_Enter(sender As Object, e As EventArgs) Handles txtReceivedFromID.Enter
        If txtReceivedFromID.Text = "" Then
            frmPartySearch.ShowDialog()
            txtReceivedFromID.Text = frmPartySearch.acID
            txtReceivedFromTitle.Text = frmPartySearch.CusName
        End If
        txtReceivedFromID.SelectAll()
    End Sub

    Private Sub txtACID_Leave(sender As Object, e As EventArgs) Handles txtACID.Leave
        If txtACID.Text = "" Then
            Return
        End If
        Dim tb As DataTable = SQLData("Select Case When ocell2wa='y' then cell2 else ocell end ocell,isnull(UrduName,'') UrduName from coa where id=" & txtACID.Text)
        If tb.Rows.Count = 0 Then
            MsgBox("Account not found")
            txtACID.Select()
            txtACID.SelectAll()
            Return
        End If
        txtOCell.Text = tb.Rows(0)("Ocell")
        txtRecdInUrduName.Text = tb.Rows(0)("UrduName")
        txtPBal.Text = Form3.Amt(PreBalance(txtACID.Text, dtp1.Value, "BRV", txtCRVNo.Text))

    End Sub

    Private Sub txtReceivedFromID_Leave(sender As Object, e As EventArgs) Handles txtReceivedFromID.Leave
        Dim tb As DataTable = SQLData("select case when ocell2wa='y' then cell2 else ocell end ocell, isnull(UrduName,'') UrduName from coa where id=" & txtReceivedFromID.Text)
        If tb.Rows.Count = 0 Then
            MsgBox("Account not found")
            txtReceivedFromID.Select()
            txtReceivedFromID.SelectAll()
            Return
        End If
        txtRecdFromMobile.Text = tb.Rows(0)("Ocell")
        txtRecdFromUrduName.Text = tb.Rows(0)("UrduName")
        txtRecdFromPBalance.Text = Form3.Amt(PreBalance(txtReceivedFromID.Text, dtp1.Value, "BRV", txtCRVNo.Text))
    End Sub

    Sub SMS(Mobile As String, ReveiverMobile As String, BillNumber As String, BillAmount As String, dt As Date, Optional Svr As String = "1.125")
        '******************Received In Account SMS

        Dim winHttpReq As Object
        Dim myURL, msg As String
        Dim SMSServer As String = txtSMServer.Text
        Dim NetBalance As String = Form3.Amt(txtNBal.Text - 0)
        Dim PreBala As String = Form3.Amt(txtPBal.Text - 0)
        Dim UName As String = ""
        If Mobile <> "" Then
            If NetBalance < 0 Then
                NetBalance = Form3.Amt(Math.Abs(CInt(NetBalance)).ToString) + "-"
            End If
            If txtPBal.Text < 0 Then
                PreBala = Form3.Amt(Math.Abs(CInt(txtPBal.Text)).ToString) + "-"
            End If
            If chkPB.Checked = True Then
                PreBala = "%0a  سابقہ بقایا " & PreBala
                NetBalance = "%0a  کل بقایا بیلنس " & NetBalance
            Else
                PreBala = ""
                NetBalance = ""
            End If
            If txtRecdInUrduName.Text.Trim = "" Then
                UName = ""
            Else
                UName = "%0a ادائیگی بنام :" & txtRecdInUrduName.Text
            End If
            msg = "السلام علیکم " &
                "%0a ادائیگی علاوہ نقد رقم، نمبر" & BillNumber &
                "%0a مورخہ" & dt.ToString("yy-MM-dd") &
                UName &
                PreBala &
                "%0a  ادائیگی کی رقم " & Form3.Amt(BillAmount - 0) &
                NetBalance &
                "%0a احمدانٹرنیشنل "
            myURL = "http://192.168." & Svr & ":8090/SendSMS?username=Sanaulhaq&password=123&phone=" & Mobile & "&message=" & msg
            winHttpReq = CreateObject("winHttp.winHttprequest.5.1")
            winHttpReq.open("post", myURL, False)
            Try
                winHttpReq.send()
                MainPage.msg = "Recd In Message Sent successfully"
                DisappearingMsgBox.Show()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        '******************Received From Account SMS


        If ReveiverMobile = "" Then
            Return
        End If

        SMSServer = txtSMServer.Text
        NetBalance = Form3.Amt(txtRecdFromNetBalance.Text - 0)
        PreBala = Form3.Amt(txtRecdFromPBalance.Text - 0)
        If NetBalance < 0 Then
            NetBalance = Form3.Amt(Math.Abs(CInt(NetBalance)).ToString) + "-"
        End If
        If txtRecdFromPBalance.Text < 0 Then
            PreBala = Form3.Amt(Math.Abs(CInt(PreBala)).ToString) + "-"
        End If
        If chkPB.Checked = True Then
            PreBala = "%0a  سابقہ بقایا " & PreBala
            NetBalance = "%0a  کل بقایا بیلنس " & NetBalance
        Else
            PreBala = ""
            NetBalance = ""
        End If
        If txtRecdFromUrduName.Text.Trim = "" Then
            UName = ""
        Else
            UName = "%0a وصولی بنام :" & txtRecdFromUrduName.Text
        End If

        msg = "السلام علیکم " &
            "%0a وصولی علاوہ نقد رقم، نمبر" & BillNumber &
            "%0a مورخہ" & dt.ToString("yy-MM-dd") &
            UName &
            PreBala &
            "%0a  وصولی کی رقم " & Form3.Amt(BillAmount - 0) &
            NetBalance &
            "%0a احمدانٹرنیشنل "
        myURL = "http://192.168." & Svr & ":8090/SendSMS?username=Sanaulhaq&password=123&phone=" & ReveiverMobile & "&message=" & msg
        winHttpReq = CreateObject("winHttp.winHttprequest.5.1")
        winHttpReq.open("post", myURL, False)
        Try
            winHttpReq.send()
            MainPage.msg = " Recd. From Message Sent successfully"
            DisappearingMsgBox.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try





    End Sub

    Private Sub chkSMS_CheckedChanged(sender As Object, e As EventArgs) Handles chkSMS.CheckedChanged, chkPB.CheckedChanged
        txtAmount.SelectAll()
        txtAmount.Select()
    End Sub


    Function MyMsg() As (Mobile As String, Msg As String)
        Dim n As Integer = dgvCRV.CurrentCell.RowIndex
        If n >= 0 Then
            Dim acid As String = dgvCRV.Item("colACID", n).Value.ToString
            Dim amount As String = dgvCRV.Item("colAmount", n).Value.ToString
            Dim Doc As String = dgvCRV.Item("colDoc", n).Value.ToString
            Dim brvDate As String = DateChange(dgvCRV.Item("colDate", n).Value)
            Dim dt As DataTable = SQLData("select isnull(UrduName,'') UrduName, case when ocell2wa='y' then cell2 else ocell end Mobile from coa where id='" & acid & "'     ")
            Dim Mobile As String
            Dim UName As String
            Dim Narration As String = dgvCRV.Item("colNarration", n).Value.ToString
            Dim PreviousBalance As String = PreBalance(acid.ToString, dgvCRV.Item("colDate", n).Value, "BRV", Doc)
            Dim NetBalance As String = PreviousBalance - dgvCRV.Item("colAmount", n).Value
            If dt.Rows.Count > 0 Then
                UName = dt.Rows(0)("UrduName")
                Mobile = dt.Rows(0)("Mobile")
            Else
                UName = ""
                Mobile = ""
            End If

            If dt.Rows(0)("UrduName").ToString.Trim = "" Then
                UName = ""
            Else
                UName = dt.Rows(0)("UrduName").ToString
                UName = "%0a وصولی بنام :" & UName
            End If

            Dim PreB As String = ""
            Dim NetB As String = ""

            Mobile = Mobile.Substring(1)
            Mobile = "92" + Mobile.Replace(" ", "")

            Dim Msg As String = "*وصولی علاوہ نقد رقم نمبر" + " " + Doc + "*" _
            + Environment.NewLine + "وصولی کی تاریخ" + " " + brvDate _
            + UName _
            + Environment.NewLine + " تفصیل " + " " + Narration _
            + Environment.NewLine _
            + PreB _
            + Environment.NewLine + "وصولی کی رقم " + " " + Form3.Amt(dgvCRV.Item("colAmount", n).Value.ToString) _
            + NetB _
            + Environment.NewLine _
            + Environment.NewLine + "احمد انٹرنیشنل - فیصل آباد"


            Return (Mobile, Msg)
        Else
            Return ("", "")
        End If

    End Function
    Private Sub btnWhatsappSend_Click(sender As Object, e As EventArgs) Handles btnWhatsappSend.Click

        MyMsg()
        Form3.Whatsapp(MyMsg.Mobile, MyMsg.Msg)
        'Form3.Whatsapp("923008551600", MyMsg.Msg)
    End Sub

    Private Sub txtNarration_Enter(sender As Object, e As EventArgs) Handles txtNarration.Enter
        If txtNarration.Text = Nothing Then
            txtNarration.Text = txtRecdInUrduName.Text + " بحوالہ " + txtRecdFromUrduName.Text
            txtNarration.SelectionStart = 0
        End If
    End Sub

    Private Sub dgvCRV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCRV.CellContentClick

    End Sub
End Class
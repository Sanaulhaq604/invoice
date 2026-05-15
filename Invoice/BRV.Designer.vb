<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BRV
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BRV))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.txtACID = New System.Windows.Forms.TextBox()
        Me.txtNarration = New System.Windows.Forms.TextBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.dgvCRV = New System.Windows.Forms.DataGridView()
        Me.txtCRVNo = New System.Windows.Forms.TextBox()
        Me.ctbSave = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtReceivedInTitle = New System.Windows.Forms.TextBox()
        Me.txtSessionTotal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.txtPBal = New System.Windows.Forms.TextBox()
        Me.txtNBal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblDoc = New System.Windows.Forms.Label()
        Me.txtReceivedFromID = New System.Windows.Forms.TextBox()
        Me.txtReceivedFromTitle = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkSMS = New System.Windows.Forms.CheckBox()
        Me.txtOCell = New System.Windows.Forms.TextBox()
        Me.txtSMServer = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtRecdFromMobile = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtRecdFromNetBalance = New System.Windows.Forms.TextBox()
        Me.txtRecdFromPBalance = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkPB = New System.Windows.Forms.CheckBox()
        Me.txtRecdInUrduName = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtRecdFromUrduName = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnWhatsappSend = New System.Windows.Forms.Button()
        Me.gbDebit = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ColNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colACID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRecParty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRecAcc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNarration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvCRV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDebit.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(23, 89)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(83, 23)
        Me.dtp1.TabIndex = 1
        '
        'txtACID
        '
        Me.txtACID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtACID.Location = New System.Drawing.Point(192, 89)
        Me.txtACID.Name = "txtACID"
        Me.txtACID.Size = New System.Drawing.Size(50, 23)
        Me.txtACID.TabIndex = 5
        '
        'txtNarration
        '
        Me.txtNarration.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNarration.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtNarration.Location = New System.Drawing.Point(869, 89)
        Me.txtNarration.Name = "txtNarration"
        Me.txtNarration.Size = New System.Drawing.Size(347, 23)
        Me.txtNarration.TabIndex = 9
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(1215, 89)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(123, 23)
        Me.txtAmount.TabIndex = 10
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvCRV
        '
        Me.dgvCRV.AllowUserToAddRows = False
        Me.dgvCRV.AllowUserToDeleteRows = False
        Me.dgvCRV.AllowUserToResizeRows = False
        Me.dgvCRV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCRV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCRV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCRV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNo, Me.colDate, Me.colACID, Me.colDoc, Me.colID, Me.ColRecParty, Me.colCustomer, Me.ColRecAcc, Me.colNarration, Me.colAmount})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCRV.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvCRV.Location = New System.Drawing.Point(16, 167)
        Me.dgvCRV.MultiSelect = False
        Me.dgvCRV.Name = "dgvCRV"
        Me.dgvCRV.ReadOnly = True
        Me.dgvCRV.RowHeadersVisible = False
        Me.dgvCRV.RowHeadersWidth = 51
        Me.dgvCRV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCRV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCRV.Size = New System.Drawing.Size(1323, 362)
        Me.dgvCRV.TabIndex = 2
        Me.dgvCRV.TabStop = False
        '
        'txtCRVNo
        '
        Me.txtCRVNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCRVNo.Location = New System.Drawing.Point(105, 89)
        Me.txtCRVNo.Name = "txtCRVNo"
        Me.txtCRVNo.Size = New System.Drawing.Size(64, 23)
        Me.txtCRVNo.TabIndex = 3
        '
        'ctbSave
        '
        Me.ctbSave.Location = New System.Drawing.Point(699, 531)
        Me.ctbSave.Name = "ctbSave"
        Me.ctbSave.Size = New System.Drawing.Size(76, 45)
        Me.ctbSave.TabIndex = 11
        Me.ctbSave.Text = "&Save"
        Me.ctbSave.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(862, 531)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(76, 45)
        Me.btnExit.TabIndex = 13
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(102, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Voucher #"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(195, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Acc ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(996, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Narration"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(1256, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Amount"
        '
        'txtReceivedInTitle
        '
        Me.txtReceivedInTitle.BackColor = System.Drawing.Color.Yellow
        Me.txtReceivedInTitle.Enabled = False
        Me.txtReceivedInTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtReceivedInTitle.ForeColor = System.Drawing.Color.Black
        Me.txtReceivedInTitle.Location = New System.Drawing.Point(241, 89)
        Me.txtReceivedInTitle.Name = "txtReceivedInTitle"
        Me.txtReceivedInTitle.Size = New System.Drawing.Size(285, 23)
        Me.txtReceivedInTitle.TabIndex = 7
        Me.txtReceivedInTitle.TabStop = False
        '
        'txtSessionTotal
        '
        Me.txtSessionTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtSessionTotal.Location = New System.Drawing.Point(1223, 553)
        Me.txtSessionTotal.Name = "txtSessionTotal"
        Me.txtSessionTotal.ReadOnly = True
        Me.txtSessionTotal.Size = New System.Drawing.Size(118, 29)
        Me.txtSessionTotal.TabIndex = 4
        Me.txtSessionTotal.TabStop = False
        Me.txtSessionTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.Location = New System.Drawing.Point(241, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Received In"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(780, 531)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(76, 45)
        Me.btnRefresh.TabIndex = 12
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'txtPBal
        '
        Me.txtPBal.BackColor = System.Drawing.Color.LightGreen
        Me.txtPBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtPBal.ForeColor = System.Drawing.Color.Black
        Me.txtPBal.Location = New System.Drawing.Point(403, 67)
        Me.txtPBal.Name = "txtPBal"
        Me.txtPBal.ReadOnly = True
        Me.txtPBal.Size = New System.Drawing.Size(123, 23)
        Me.txtPBal.TabIndex = 15
        Me.txtPBal.TabStop = False
        Me.txtPBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNBal
        '
        Me.txtNBal.BackColor = System.Drawing.Color.LightGreen
        Me.txtNBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtNBal.ForeColor = System.Drawing.Color.Black
        Me.txtNBal.Location = New System.Drawing.Point(403, 111)
        Me.txtNBal.Name = "txtNBal"
        Me.txtNBal.ReadOnly = True
        Me.txtNBal.Size = New System.Drawing.Size(123, 23)
        Me.txtNBal.TabIndex = 15
        Me.txtNBal.TabStop = False
        Me.txtNBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.Location = New System.Drawing.Point(334, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "P.Balance"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.Location = New System.Drawing.Point(340, 116)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "N.Balane"
        '
        'lblDoc
        '
        Me.lblDoc.BackColor = System.Drawing.Color.OliveDrab
        Me.lblDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDoc.ForeColor = System.Drawing.Color.White
        Me.lblDoc.Location = New System.Drawing.Point(-1, -1)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(1362, 34)
        Me.lblDoc.TabIndex = 4
        Me.lblDoc.Text = "Bank Receipt Voucher"
        Me.lblDoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtReceivedFromID
        '
        Me.txtReceivedFromID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtReceivedFromID.Location = New System.Drawing.Point(531, 89)
        Me.txtReceivedFromID.Name = "txtReceivedFromID"
        Me.txtReceivedFromID.Size = New System.Drawing.Size(50, 23)
        Me.txtReceivedFromID.TabIndex = 7
        '
        'txtReceivedFromTitle
        '
        Me.txtReceivedFromTitle.BackColor = System.Drawing.Color.Yellow
        Me.txtReceivedFromTitle.Enabled = False
        Me.txtReceivedFromTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtReceivedFromTitle.ForeColor = System.Drawing.Color.Black
        Me.txtReceivedFromTitle.Location = New System.Drawing.Point(580, 89)
        Me.txtReceivedFromTitle.Name = "txtReceivedFromTitle"
        Me.txtReceivedFromTitle.Size = New System.Drawing.Size(284, 23)
        Me.txtReceivedFromTitle.TabIndex = 7
        Me.txtReceivedFromTitle.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(534, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Acc ID"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label10.Location = New System.Drawing.Point(578, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Received From"
        '
        'chkSMS
        '
        Me.chkSMS.AutoSize = True
        Me.chkSMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkSMS.Location = New System.Drawing.Point(1062, 119)
        Me.chkSMS.Name = "chkSMS"
        Me.chkSMS.Size = New System.Drawing.Size(52, 17)
        Me.chkSMS.TabIndex = 65
        Me.chkSMS.Text = "S&MS"
        Me.chkSMS.UseVisualStyleBackColor = True
        '
        'txtOCell
        '
        Me.txtOCell.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtOCell.Location = New System.Drawing.Point(241, 111)
        Me.txtOCell.Name = "txtOCell"
        Me.txtOCell.ReadOnly = True
        Me.txtOCell.Size = New System.Drawing.Size(98, 23)
        Me.txtOCell.TabIndex = 64
        '
        'txtSMServer
        '
        Me.txtSMServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtSMServer.Location = New System.Drawing.Point(1012, 117)
        Me.txtSMServer.Name = "txtSMServer"
        Me.txtSMServer.Size = New System.Drawing.Size(43, 20)
        Me.txtSMServer.TabIndex = 63
        Me.txtSMServer.Text = "1.125"
        Me.txtSMServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label45.Location = New System.Drawing.Point(966, 121)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(44, 13)
        Me.Label45.TabIndex = 62
        Me.Label45.Text = "Server"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label17.Location = New System.Drawing.Point(187, 115)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 13)
        Me.Label17.TabIndex = 61
        Me.Label17.Text = "Mobile #"
        '
        'txtRecdFromMobile
        '
        Me.txtRecdFromMobile.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtRecdFromMobile.Location = New System.Drawing.Point(580, 111)
        Me.txtRecdFromMobile.Name = "txtRecdFromMobile"
        Me.txtRecdFromMobile.ReadOnly = True
        Me.txtRecdFromMobile.Size = New System.Drawing.Size(98, 23)
        Me.txtRecdFromMobile.TabIndex = 67
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label11.Location = New System.Drawing.Point(534, 115)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 66
        Me.Label11.Text = "Mobile"
        '
        'txtRecdFromNetBalance
        '
        Me.txtRecdFromNetBalance.BackColor = System.Drawing.Color.LightGreen
        Me.txtRecdFromNetBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtRecdFromNetBalance.ForeColor = System.Drawing.Color.Black
        Me.txtRecdFromNetBalance.Location = New System.Drawing.Point(741, 111)
        Me.txtRecdFromNetBalance.Name = "txtRecdFromNetBalance"
        Me.txtRecdFromNetBalance.ReadOnly = True
        Me.txtRecdFromNetBalance.Size = New System.Drawing.Size(123, 23)
        Me.txtRecdFromNetBalance.TabIndex = 70
        Me.txtRecdFromNetBalance.TabStop = False
        Me.txtRecdFromNetBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRecdFromPBalance
        '
        Me.txtRecdFromPBalance.BackColor = System.Drawing.Color.LightGreen
        Me.txtRecdFromPBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtRecdFromPBalance.ForeColor = System.Drawing.Color.Black
        Me.txtRecdFromPBalance.Location = New System.Drawing.Point(741, 67)
        Me.txtRecdFromPBalance.Name = "txtRecdFromPBalance"
        Me.txtRecdFromPBalance.ReadOnly = True
        Me.txtRecdFromPBalance.Size = New System.Drawing.Size(123, 23)
        Me.txtRecdFromPBalance.TabIndex = 71
        Me.txtRecdFromPBalance.TabStop = False
        Me.txtRecdFromPBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label12.Location = New System.Drawing.Point(680, 116)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "N.Balane"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label13.Location = New System.Drawing.Point(674, 72)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 13)
        Me.Label13.TabIndex = 69
        Me.Label13.Text = "P.Balance"
        '
        'chkPB
        '
        Me.chkPB.AutoSize = True
        Me.chkPB.Checked = True
        Me.chkPB.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkPB.Location = New System.Drawing.Point(1121, 119)
        Me.chkPB.Name = "chkPB"
        Me.chkPB.Size = New System.Drawing.Size(125, 17)
        Me.chkPB.TabIndex = 72
        Me.chkPB.Text = "Pr&evious Balance"
        Me.chkPB.UseVisualStyleBackColor = True
        '
        'txtRecdInUrduName
        '
        Me.txtRecdInUrduName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtRecdInUrduName.Location = New System.Drawing.Point(242, 134)
        Me.txtRecdInUrduName.Name = "txtRecdInUrduName"
        Me.txtRecdInUrduName.Size = New System.Drawing.Size(200, 26)
        Me.txtRecdInUrduName.TabIndex = 73
        Me.txtRecdInUrduName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label14.Location = New System.Drawing.Point(409, 96)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 20)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "وصول کنندہ"
        '
        'txtRecdFromUrduName
        '
        Me.txtRecdFromUrduName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtRecdFromUrduName.Location = New System.Drawing.Point(4, 93)
        Me.txtRecdFromUrduName.Name = "txtRecdFromUrduName"
        Me.txtRecdFromUrduName.Size = New System.Drawing.Size(246, 26)
        Me.txtRecdFromUrduName.TabIndex = 75
        Me.txtRecdFromUrduName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label15.Location = New System.Drawing.Point(252, 94)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 20)
        Me.Label15.TabIndex = 74
        Me.Label15.Text = "وصولی بنام"
        '
        'btnWhatsappSend
        '
        Me.btnWhatsappSend.BackgroundImage = CType(resources.GetObject("btnWhatsappSend.BackgroundImage"), System.Drawing.Image)
        Me.btnWhatsappSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWhatsappSend.Location = New System.Drawing.Point(619, 531)
        Me.btnWhatsappSend.Name = "btnWhatsappSend"
        Me.btnWhatsappSend.Size = New System.Drawing.Size(76, 45)
        Me.btnWhatsappSend.TabIndex = 76
        Me.btnWhatsappSend.UseVisualStyleBackColor = True
        '
        'gbDebit
        '
        Me.gbDebit.Controls.Add(Me.Label14)
        Me.gbDebit.Controls.Add(Me.Label19)
        Me.gbDebit.Location = New System.Drawing.Point(183, 41)
        Me.gbDebit.Name = "gbDebit"
        Me.gbDebit.Size = New System.Drawing.Size(345, 122)
        Me.gbDebit.TabIndex = 77
        Me.gbDebit.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label19.Location = New System.Drawing.Point(259, 96)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 20)
        Me.Label19.TabIndex = 74
        Me.Label19.Text = "ادائیگی بنام"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtRecdFromUrduName)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Location = New System.Drawing.Point(529, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(338, 122)
        Me.GroupBox1.TabIndex = 77
        Me.GroupBox1.TabStop = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label16.Location = New System.Drawing.Point(185, 34)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(344, 26)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Debit Details"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label18.Location = New System.Drawing.Point(530, 33)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(340, 26)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Credit Details"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ColNo
        '
        Me.ColNo.DataPropertyName = "rn"
        Me.ColNo.HeaderText = "No."
        Me.ColNo.MinimumWidth = 6
        Me.ColNo.Name = "ColNo"
        Me.ColNo.ReadOnly = True
        Me.ColNo.Width = 40
        '
        'colDate
        '
        Me.colDate.DataPropertyName = "date"
        Me.colDate.FillWeight = 70.0!
        Me.colDate.HeaderText = "Date"
        Me.colDate.MinimumWidth = 6
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        '
        'colACID
        '
        Me.colACID.DataPropertyName = "acid"
        Me.colACID.HeaderText = "ACID"
        Me.colACID.MinimumWidth = 6
        Me.colACID.Name = "colACID"
        Me.colACID.ReadOnly = True
        Me.colACID.Visible = False
        Me.colACID.Width = 125
        '
        'colDoc
        '
        Me.colDoc.DataPropertyName = "doc"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.colDoc.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDoc.HeaderText = "Voucher #"
        Me.colDoc.MinimumWidth = 6
        Me.colDoc.Name = "colDoc"
        Me.colDoc.ReadOnly = True
        Me.colDoc.Width = 70
        '
        'colID
        '
        Me.colID.DataPropertyName = "id"
        Me.colID.HeaderText = "ID"
        Me.colID.MinimumWidth = 6
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Visible = False
        Me.colID.Width = 50
        '
        'ColRecParty
        '
        Me.ColRecParty.DataPropertyName = "RecParty"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ColRecParty.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColRecParty.HeaderText = "Receiving Party"
        Me.ColRecParty.MinimumWidth = 6
        Me.ColRecParty.Name = "ColRecParty"
        Me.ColRecParty.ReadOnly = True
        Me.ColRecParty.Width = 300
        '
        'colCustomer
        '
        Me.colCustomer.DataPropertyName = "Subsidary"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.colCustomer.DefaultCellStyle = DataGridViewCellStyle4
        Me.colCustomer.HeaderText = "Account Title"
        Me.colCustomer.MinimumWidth = 6
        Me.colCustomer.Name = "colCustomer"
        Me.colCustomer.ReadOnly = True
        Me.colCustomer.Width = 300
        '
        'ColRecAcc
        '
        Me.ColRecAcc.DataPropertyName = "RecAcc"
        Me.ColRecAcc.HeaderText = "Receiving Account"
        Me.ColRecAcc.MinimumWidth = 6
        Me.ColRecAcc.Name = "ColRecAcc"
        Me.ColRecAcc.ReadOnly = True
        Me.ColRecAcc.Visible = False
        Me.ColRecAcc.Width = 50
        '
        'colNarration
        '
        Me.colNarration.DataPropertyName = "narration"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Jameel Noori Nastaleeq", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.colNarration.DefaultCellStyle = DataGridViewCellStyle5
        Me.colNarration.HeaderText = "Narration"
        Me.colNarration.MinimumWidth = 6
        Me.colNarration.Name = "colNarration"
        Me.colNarration.ReadOnly = True
        Me.colNarration.Width = 375
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "Credit"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle6
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.MinimumWidth = 6
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 120
        '
        'BRV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(1355, 585)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnWhatsappSend)
        Me.Controls.Add(Me.txtRecdInUrduName)
        Me.Controls.Add(Me.chkPB)
        Me.Controls.Add(Me.txtRecdFromNetBalance)
        Me.Controls.Add(Me.txtRecdFromPBalance)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtRecdFromMobile)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.chkSMS)
        Me.Controls.Add(Me.txtOCell)
        Me.Controls.Add(Me.txtSMServer)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtNBal)
        Me.Controls.Add(Me.txtPBal)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.ctbSave)
        Me.Controls.Add(Me.lblDoc)
        Me.Controls.Add(Me.dgvCRV)
        Me.Controls.Add(Me.txtReceivedFromTitle)
        Me.Controls.Add(Me.txtReceivedInTitle)
        Me.Controls.Add(Me.txtSessionTotal)
        Me.Controls.Add(Me.txtNarration)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.txtCRVNo)
        Me.Controls.Add(Me.txtReceivedFromID)
        Me.Controls.Add(Me.txtACID)
        Me.Controls.Add(Me.dtp1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbDebit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "BRV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CRV"
        CType(Me.dgvCRV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDebit.ResumeLayout(False)
        Me.gbDebit.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents txtACID As TextBox
    Friend WithEvents txtNarration As TextBox
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents dgvCRV As DataGridView
    Friend WithEvents txtCRVNo As TextBox
    Friend WithEvents ctbSave As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtReceivedInTitle As TextBox
    Friend WithEvents txtSessionTotal As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents txtPBal As TextBox
    Friend WithEvents txtNBal As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblDoc As Label
    Friend WithEvents txtReceivedFromID As TextBox
    Friend WithEvents txtReceivedFromTitle As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents chkSMS As CheckBox
    Friend WithEvents txtOCell As TextBox
    Friend WithEvents txtSMServer As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtRecdFromMobile As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtRecdFromNetBalance As TextBox
    Friend WithEvents txtRecdFromPBalance As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents chkPB As CheckBox
    Friend WithEvents txtRecdInUrduName As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtRecdFromUrduName As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents btnWhatsappSend As Button
    Friend WithEvents gbDebit As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents ColNo As DataGridViewTextBoxColumn
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents colACID As DataGridViewTextBoxColumn
    Friend WithEvents colDoc As DataGridViewTextBoxColumn
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents ColRecParty As DataGridViewTextBoxColumn
    Friend WithEvents colCustomer As DataGridViewTextBoxColumn
    Friend WithEvents ColRecAcc As DataGridViewTextBoxColumn
    Friend WithEvents colNarration As DataGridViewTextBoxColumn
    Friend WithEvents colAmount As DataGridViewTextBoxColumn
End Class

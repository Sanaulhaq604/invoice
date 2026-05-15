<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CPV
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.dgvCRV = New System.Windows.Forms.DataGridView()
        Me.ColNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colACID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNarration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblDoc = New System.Windows.Forms.Label()
        Me.ctbSave = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvTotals = New System.Windows.Forms.DataGridView()
        Me.colRN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRoutes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkSMS = New System.Windows.Forms.CheckBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkPB = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnWhatsappSend = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTotalDebit = New System.Windows.Forms.TextBox()
        Me.dgvHistory = New System.Windows.Forms.DataGridView()
        Me.HisDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hisDco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hisNarration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDebit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hisCredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTotalDiff = New System.Windows.Forms.TextBox()
        Me.txtTotalCredit = New System.Windows.Forms.TextBox()
        Me.txtUrduName = New Invoice.CustomTextBox()
        Me.TextBox3 = New Invoice.CustomTextBox()
        Me.txtOcell = New Invoice.CustomTextBox()
        Me.txtSMServer = New Invoice.CustomTextBox()
        Me.txtDayTotals = New Invoice.CustomTextBox()
        Me.TextBox1 = New Invoice.CustomTextBox()
        Me.txtOB = New Invoice.CustomTextBox()
        Me.txtTodayReceipts = New Invoice.CustomTextBox()
        Me.txtTodayPayments = New Invoice.CustomTextBox()
        Me.txtNetCashBalance = New Invoice.CustomTextBox()
        Me.txtNBal = New Invoice.CustomTextBox()
        Me.txtPBal = New Invoice.CustomTextBox()
        Me.txtCustomerName = New Invoice.CustomTextBox()
        Me.txtNarration = New Invoice.CustomTextBox()
        Me.txtAmount = New Invoice.CustomTextBox()
        Me.txtCRVNo = New Invoice.CustomTextBox()
        Me.txtACID = New Invoice.CustomTextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        CType(Me.dgvCRV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(19, 72)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(83, 23)
        Me.dtp1.TabIndex = 1
        '
        'dgvCRV
        '
        Me.dgvCRV.AllowUserToAddRows = False
        Me.dgvCRV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCRV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCRV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCRV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNo, Me.colDate, Me.colDoc, Me.colACID, Me.colCustomer, Me.colNarration, Me.colAmount})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCRV.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCRV.Location = New System.Drawing.Point(19, 131)
        Me.dgvCRV.MultiSelect = False
        Me.dgvCRV.Name = "dgvCRV"
        Me.dgvCRV.ReadOnly = True
        Me.dgvCRV.RowHeadersVisible = False
        Me.dgvCRV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCRV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCRV.Size = New System.Drawing.Size(752, 294)
        Me.dgvCRV.TabIndex = 2
        Me.dgvCRV.TabStop = False
        '
        'ColNo
        '
        Me.ColNo.DataPropertyName = "rn"
        Me.ColNo.HeaderText = "No."
        Me.ColNo.Name = "ColNo"
        Me.ColNo.ReadOnly = True
        Me.ColNo.Width = 30
        '
        'colDate
        '
        Me.colDate.DataPropertyName = "date"
        Me.colDate.HeaderText = "Date"
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        Me.colDate.Width = 80
        '
        'colDoc
        '
        Me.colDoc.DataPropertyName = "doc"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.colDoc.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDoc.HeaderText = "Voucher #"
        Me.colDoc.Name = "colDoc"
        Me.colDoc.ReadOnly = True
        Me.colDoc.Width = 60
        '
        'colACID
        '
        Me.colACID.DataPropertyName = "acid"
        Me.colACID.HeaderText = "ID"
        Me.colACID.Name = "colACID"
        Me.colACID.ReadOnly = True
        Me.colACID.Width = 60
        '
        'colCustomer
        '
        Me.colCustomer.DataPropertyName = "Title"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.colCustomer.DefaultCellStyle = DataGridViewCellStyle3
        Me.colCustomer.HeaderText = "Account Title"
        Me.colCustomer.Name = "colCustomer"
        Me.colCustomer.ReadOnly = True
        Me.colCustomer.Width = 230
        '
        'colNarration
        '
        Me.colNarration.DataPropertyName = "narration"
        Me.colNarration.HeaderText = "Narration"
        Me.colNarration.Name = "colNarration"
        Me.colNarration.ReadOnly = True
        Me.colNarration.Width = 180
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "amount"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle4
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 90
        '
        'lblDoc
        '
        Me.lblDoc.BackColor = System.Drawing.Color.HotPink
        Me.lblDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDoc.ForeColor = System.Drawing.Color.White
        Me.lblDoc.Location = New System.Drawing.Point(0, -1)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(1360, 30)
        Me.lblDoc.TabIndex = 4
        Me.lblDoc.Text = "Cash Payment Voucher"
        Me.lblDoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ctbSave
        '
        Me.ctbSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ctbSave.Location = New System.Drawing.Point(623, 564)
        Me.ctbSave.Name = "ctbSave"
        Me.ctbSave.Size = New System.Drawing.Size(94, 44)
        Me.ctbSave.TabIndex = 12
        Me.ctbSave.Text = "&Save"
        Me.ctbSave.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Red
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.Location = New System.Drawing.Point(815, 564)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(93, 44)
        Me.btnExit.TabIndex = 14
        Me.btnExit.Text = "&Close"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(98, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Voucher #"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(184, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Acc ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(770, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Narration"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(1270, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Amount"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.Location = New System.Drawing.Point(266, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Acc. Title"
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(720, 564)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(93, 44)
        Me.btnRefresh.TabIndex = 13
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.Location = New System.Drawing.Point(1117, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Previous Balance"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.Location = New System.Drawing.Point(1146, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Net Balance"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtOB)
        Me.GroupBox3.Controls.Add(Me.txtTodayReceipts)
        Me.GroupBox3.Controls.Add(Me.txtTodayPayments)
        Me.GroupBox3.Controls.Add(Me.txtNetCashBalance)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Location = New System.Drawing.Point(623, 428)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(284, 136)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Totals"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label14.Location = New System.Drawing.Point(18, 104)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 17)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Net Balance"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 79)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Total Payments"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Total Receipts"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(111, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Openning Balance"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvTotals)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtDayTotals)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(909, 426)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(438, 194)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'dgvTotals
        '
        Me.dgvTotals.AllowUserToAddRows = False
        Me.dgvTotals.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTotals.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTotals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRN, Me.colRoutes, Me.ColReceived})
        Me.dgvTotals.Location = New System.Drawing.Point(21, 14)
        Me.dgvTotals.Name = "dgvTotals"
        Me.dgvTotals.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTotals.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvTotals.RowHeadersVisible = False
        Me.dgvTotals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTotals.Size = New System.Drawing.Size(394, 142)
        Me.dgvTotals.TabIndex = 16
        '
        'colRN
        '
        Me.colRN.DataPropertyName = "rn"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.colRN.DefaultCellStyle = DataGridViewCellStyle7
        Me.colRN.HeaderText = "Sr."
        Me.colRN.Name = "colRN"
        Me.colRN.ReadOnly = True
        Me.colRN.Width = 60
        '
        'colRoutes
        '
        Me.colRoutes.DataPropertyName = "Main"
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.colRoutes.DefaultCellStyle = DataGridViewCellStyle8
        Me.colRoutes.HeaderText = "Group"
        Me.colRoutes.Name = "colRoutes"
        Me.colRoutes.ReadOnly = True
        Me.colRoutes.Width = 200
        '
        'ColReceived
        '
        Me.ColReceived.DataPropertyName = "Debit"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle9.Format = "N2"
        Me.ColReceived.DefaultCellStyle = DataGridViewCellStyle9
        Me.ColReceived.HeaderText = "Payments"
        Me.ColReceived.Name = "ColReceived"
        Me.ColReceived.ReadOnly = True
        Me.ColReceived.Width = 110
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label10.Location = New System.Drawing.Point(199, 165)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 17)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Total Paid"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Session Total"
        '
        'chkSMS
        '
        Me.chkSMS.AutoSize = True
        Me.chkSMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkSMS.Location = New System.Drawing.Point(911, 101)
        Me.chkSMS.Name = "chkSMS"
        Me.chkSMS.Size = New System.Drawing.Size(52, 17)
        Me.chkSMS.TabIndex = 63
        Me.chkSMS.Text = "S&MS"
        Me.chkSMS.UseVisualStyleBackColor = True
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label45.Location = New System.Drawing.Point(818, 101)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(44, 13)
        Me.Label45.TabIndex = 61
        Me.Label45.Text = "Server"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label15.Location = New System.Drawing.Point(271, 103)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 13)
        Me.Label15.TabIndex = 61
        Me.Label15.Text = "Mobile #"
        '
        'chkPB
        '
        Me.chkPB.AutoSize = True
        Me.chkPB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkPB.Location = New System.Drawing.Point(973, 101)
        Me.chkPB.Name = "chkPB"
        Me.chkPB.Size = New System.Drawing.Size(125, 17)
        Me.chkPB.TabIndex = 73
        Me.chkPB.Text = "Pr&evious Balance"
        Me.chkPB.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label18.Location = New System.Drawing.Point(16, 104)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 13)
        Me.Label18.TabIndex = 76
        Me.Label18.Text = "Urdu Name"
        '
        'btnWhatsappSend
        '
        Me.btnWhatsappSend.BackgroundImage = Global.Invoice.My.Resources.Resources.WA
        Me.btnWhatsappSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWhatsappSend.Location = New System.Drawing.Point(517, 537)
        Me.btnWhatsappSend.Name = "btnWhatsappSend"
        Me.btnWhatsappSend.Size = New System.Drawing.Size(100, 71)
        Me.btnWhatsappSend.TabIndex = 78
        Me.btnWhatsappSend.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label16.Location = New System.Drawing.Point(10, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 20)
        Me.Label16.TabIndex = 61
        Me.Label16.Text = "Debit"
        '
        'txtTotalDebit
        '
        Me.txtTotalDebit.BackColor = System.Drawing.Color.White
        Me.txtTotalDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotalDebit.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDebit.Location = New System.Drawing.Point(110, 25)
        Me.txtTotalDebit.Name = "txtTotalDebit"
        Me.txtTotalDebit.ReadOnly = True
        Me.txtTotalDebit.Size = New System.Drawing.Size(111, 26)
        Me.txtTotalDebit.TabIndex = 80
        Me.txtTotalDebit.TabStop = False
        Me.txtTotalDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvHistory
        '
        Me.dgvHistory.AllowUserToAddRows = False
        Me.dgvHistory.AllowUserToDeleteRows = False
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvHistory.ColumnHeadersHeight = 34
        Me.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.HisDate, Me.hisDco, Me.hisNarration, Me.colDebit, Me.hisCredit})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvHistory.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvHistory.Location = New System.Drawing.Point(772, 131)
        Me.dgvHistory.Name = "dgvHistory"
        Me.dgvHistory.ReadOnly = True
        Me.dgvHistory.RowHeadersVisible = False
        Me.dgvHistory.RowHeadersWidth = 51
        Me.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHistory.Size = New System.Drawing.Size(576, 297)
        Me.dgvHistory.TabIndex = 81
        '
        'HisDate
        '
        Me.HisDate.DataPropertyName = "Date"
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.HisDate.DefaultCellStyle = DataGridViewCellStyle12
        Me.HisDate.HeaderText = "Date"
        Me.HisDate.MinimumWidth = 6
        Me.HisDate.Name = "HisDate"
        Me.HisDate.ReadOnly = True
        Me.HisDate.Width = 90
        '
        'hisDco
        '
        Me.hisDco.DataPropertyName = "Doc"
        Me.hisDco.HeaderText = "Number"
        Me.hisDco.MinimumWidth = 6
        Me.hisDco.Name = "hisDco"
        Me.hisDco.ReadOnly = True
        Me.hisDco.Width = 80
        '
        'hisNarration
        '
        Me.hisNarration.DataPropertyName = "Narration"
        Me.hisNarration.HeaderText = "Narration"
        Me.hisNarration.MinimumWidth = 6
        Me.hisNarration.Name = "hisNarration"
        Me.hisNarration.ReadOnly = True
        Me.hisNarration.Width = 205
        '
        'colDebit
        '
        Me.colDebit.DataPropertyName = "debit"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle13.Format = "N0"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.colDebit.DefaultCellStyle = DataGridViewCellStyle13
        Me.colDebit.HeaderText = "Debit"
        Me.colDebit.MinimumWidth = 6
        Me.colDebit.Name = "colDebit"
        Me.colDebit.ReadOnly = True
        Me.colDebit.Width = 90
        '
        'hisCredit
        '
        Me.hisCredit.DataPropertyName = "Credit"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N0"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.hisCredit.DefaultCellStyle = DataGridViewCellStyle14
        Me.hisCredit.HeaderText = "Credit"
        Me.hisCredit.MinimumWidth = 6
        Me.hisCredit.Name = "hisCredit"
        Me.hisCredit.ReadOnly = True
        Me.hisCredit.Width = 90
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtTotalDiff)
        Me.GroupBox2.Controls.Add(Me.txtTotalCredit)
        Me.GroupBox2.Controls.Add(Me.txtTotalDebit)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 449)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(234, 133)
        Me.GroupBox2.TabIndex = 82
        Me.GroupBox2.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label19.Location = New System.Drawing.Point(10, 87)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 20)
        Me.Label19.TabIndex = 61
        Me.Label19.Text = "Difference"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label17.Location = New System.Drawing.Point(10, 57)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 20)
        Me.Label17.TabIndex = 61
        Me.Label17.Text = "Credit"
        '
        'txtTotalDiff
        '
        Me.txtTotalDiff.BackColor = System.Drawing.Color.White
        Me.txtTotalDiff.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotalDiff.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDiff.Location = New System.Drawing.Point(110, 88)
        Me.txtTotalDiff.Name = "txtTotalDiff"
        Me.txtTotalDiff.ReadOnly = True
        Me.txtTotalDiff.Size = New System.Drawing.Size(111, 26)
        Me.txtTotalDiff.TabIndex = 80
        Me.txtTotalDiff.TabStop = False
        Me.txtTotalDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalCredit
        '
        Me.txtTotalCredit.BackColor = System.Drawing.Color.White
        Me.txtTotalCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotalCredit.ForeColor = System.Drawing.Color.Black
        Me.txtTotalCredit.Location = New System.Drawing.Point(110, 57)
        Me.txtTotalCredit.Name = "txtTotalCredit"
        Me.txtTotalCredit.ReadOnly = True
        Me.txtTotalCredit.Size = New System.Drawing.Size(111, 26)
        Me.txtTotalCredit.TabIndex = 80
        Me.txtTotalCredit.TabStop = False
        Me.txtTotalCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUrduName
        '
        Me.txtUrduName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtUrduName.Location = New System.Drawing.Point(88, 100)
        Me.txtUrduName.Name = "txtUrduName"
        Me.txtUrduName.Size = New System.Drawing.Size(182, 23)
        Me.txtUrduName.TabIndex = 77
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TextBox3.Location = New System.Drawing.Point(-486, 102)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 23)
        Me.TextBox3.TabIndex = 64
        '
        'txtOcell
        '
        Me.txtOcell.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtOcell.Location = New System.Drawing.Point(329, 98)
        Me.txtOcell.Name = "txtOcell"
        Me.txtOcell.Size = New System.Drawing.Size(100, 23)
        Me.txtOcell.TabIndex = 64
        '
        'txtSMServer
        '
        Me.txtSMServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtSMServer.Location = New System.Drawing.Point(864, 98)
        Me.txtSMServer.Name = "txtSMServer"
        Me.txtSMServer.Size = New System.Drawing.Size(43, 20)
        Me.txtSMServer.TabIndex = 62
        Me.txtSMServer.Text = "1.125"
        Me.txtSMServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDayTotals
        '
        Me.txtDayTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDayTotals.Location = New System.Drawing.Point(284, 159)
        Me.txtDayTotals.Name = "txtDayTotals"
        Me.txtDayTotals.ReadOnly = True
        Me.txtDayTotals.Size = New System.Drawing.Size(109, 29)
        Me.txtDayTotals.TabIndex = 4
        Me.txtDayTotals.TabStop = False
        Me.txtDayTotals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(92, 159)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(98, 29)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.TabStop = False
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOB
        '
        Me.txtOB.BackColor = System.Drawing.Color.LimeGreen
        Me.txtOB.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtOB.Location = New System.Drawing.Point(128, 13)
        Me.txtOB.Name = "txtOB"
        Me.txtOB.ReadOnly = True
        Me.txtOB.Size = New System.Drawing.Size(149, 29)
        Me.txtOB.TabIndex = 4
        Me.txtOB.TabStop = False
        Me.txtOB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTodayReceipts
        '
        Me.txtTodayReceipts.BackColor = System.Drawing.Color.LawnGreen
        Me.txtTodayReceipts.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTodayReceipts.Location = New System.Drawing.Point(128, 42)
        Me.txtTodayReceipts.Name = "txtTodayReceipts"
        Me.txtTodayReceipts.ReadOnly = True
        Me.txtTodayReceipts.Size = New System.Drawing.Size(149, 26)
        Me.txtTodayReceipts.TabIndex = 4
        Me.txtTodayReceipts.TabStop = False
        Me.txtTodayReceipts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTodayPayments
        '
        Me.txtTodayPayments.BackColor = System.Drawing.Color.Salmon
        Me.txtTodayPayments.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTodayPayments.Location = New System.Drawing.Point(128, 69)
        Me.txtTodayPayments.Name = "txtTodayPayments"
        Me.txtTodayPayments.ReadOnly = True
        Me.txtTodayPayments.Size = New System.Drawing.Size(149, 26)
        Me.txtTodayPayments.TabIndex = 4
        Me.txtTodayPayments.TabStop = False
        Me.txtTodayPayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNetCashBalance
        '
        Me.txtNetCashBalance.BackColor = System.Drawing.Color.LimeGreen
        Me.txtNetCashBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtNetCashBalance.Location = New System.Drawing.Point(128, 97)
        Me.txtNetCashBalance.Name = "txtNetCashBalance"
        Me.txtNetCashBalance.ReadOnly = True
        Me.txtNetCashBalance.Size = New System.Drawing.Size(149, 29)
        Me.txtNetCashBalance.TabIndex = 4
        Me.txtNetCashBalance.TabStop = False
        Me.txtNetCashBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNBal
        '
        Me.txtNBal.BackColor = System.Drawing.Color.Yellow
        Me.txtNBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtNBal.ForeColor = System.Drawing.Color.Black
        Me.txtNBal.Location = New System.Drawing.Point(1224, 94)
        Me.txtNBal.Name = "txtNBal"
        Me.txtNBal.ReadOnly = True
        Me.txtNBal.Size = New System.Drawing.Size(123, 23)
        Me.txtNBal.TabIndex = 15
        Me.txtNBal.TabStop = False
        Me.txtNBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPBal
        '
        Me.txtPBal.BackColor = System.Drawing.Color.Yellow
        Me.txtPBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtPBal.ForeColor = System.Drawing.Color.Black
        Me.txtPBal.Location = New System.Drawing.Point(1224, 50)
        Me.txtPBal.Name = "txtPBal"
        Me.txtPBal.ReadOnly = True
        Me.txtPBal.Size = New System.Drawing.Size(123, 23)
        Me.txtPBal.TabIndex = 15
        Me.txtPBal.TabStop = False
        Me.txtPBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BackColor = System.Drawing.Color.Yellow
        Me.txtCustomerName.Enabled = False
        Me.txtCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCustomerName.ForeColor = System.Drawing.Color.Black
        Me.txtCustomerName.Location = New System.Drawing.Point(269, 72)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(489, 23)
        Me.txtCustomerName.TabIndex = 7
        Me.txtCustomerName.TabStop = False
        '
        'txtNarration
        '
        Me.txtNarration.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNarration.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtNarration.Location = New System.Drawing.Point(757, 72)
        Me.txtNarration.Name = "txtNarration"
        Me.txtNarration.Size = New System.Drawing.Size(468, 23)
        Me.txtNarration.TabIndex = 9
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(1224, 72)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(123, 23)
        Me.txtAmount.TabIndex = 11
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCRVNo
        '
        Me.txtCRVNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCRVNo.Location = New System.Drawing.Point(101, 72)
        Me.txtCRVNo.Name = "txtCRVNo"
        Me.txtCRVNo.Size = New System.Drawing.Size(86, 23)
        Me.txtCRVNo.TabIndex = 3
        Me.txtCRVNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtACID
        '
        Me.txtACID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtACID.Location = New System.Drawing.Point(187, 72)
        Me.txtACID.Name = "txtACID"
        Me.txtACID.Size = New System.Drawing.Size(87, 23)
        Me.txtACID.TabIndex = 5
        Me.txtACID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label23.Location = New System.Drawing.Point(30, -4)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(178, 20)
        Me.Label23.TabIndex = 81
        Me.Label23.Text = "Current Month Totals"
        '
        'CPV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(1360, 615)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvHistory)
        Me.Controls.Add(Me.btnWhatsappSend)
        Me.Controls.Add(Me.txtUrduName)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.chkPB)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.txtOcell)
        Me.Controls.Add(Me.chkSMS)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtSMServer)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.txtNBal)
        Me.Controls.Add(Me.txtPBal)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.ctbSave)
        Me.Controls.Add(Me.lblDoc)
        Me.Controls.Add(Me.dgvCRV)
        Me.Controls.Add(Me.txtCustomerName)
        Me.Controls.Add(Me.txtNarration)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.txtCRVNo)
        Me.Controls.Add(Me.txtACID)
        Me.Controls.Add(Me.dtp1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CPV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cash Payment"
        CType(Me.dgvCRV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvTotals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents dgvCRV As DataGridView
    Friend WithEvents lblDoc As Label
    Friend WithEvents ctbSave As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgvTotals As DataGridView
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents colRN As DataGridViewTextBoxColumn
    Friend WithEvents colRoutes As DataGridViewTextBoxColumn
    Friend WithEvents ColReceived As DataGridViewTextBoxColumn
    Friend WithEvents chkSMS As CheckBox
    Friend WithEvents Label45 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents chkPB As CheckBox
    Friend WithEvents Label18 As Label
    Friend WithEvents btnWhatsappSend As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents txtTotalDebit As TextBox
    Friend WithEvents txtACID As CustomTextBox
    Friend WithEvents txtNarration As CustomTextBox
    Friend WithEvents txtAmount As CustomTextBox
    Friend WithEvents txtCRVNo As CustomTextBox
    Friend WithEvents txtCustomerName As CustomTextBox
    Friend WithEvents txtPBal As CustomTextBox
    Friend WithEvents txtNBal As CustomTextBox
    Friend WithEvents txtOB As CustomTextBox
    Friend WithEvents txtTodayReceipts As CustomTextBox
    Friend WithEvents txtTodayPayments As CustomTextBox
    Friend WithEvents txtNetCashBalance As CustomTextBox
    Friend WithEvents txtDayTotals As CustomTextBox
    Friend WithEvents TextBox1 As CustomTextBox
    Friend WithEvents txtSMServer As CustomTextBox
    Friend WithEvents txtOcell As CustomTextBox
    Friend WithEvents TextBox3 As CustomTextBox
    Friend WithEvents txtUrduName As CustomTextBox
    Friend WithEvents dgvHistory As DataGridView
    Friend WithEvents ColNo As DataGridViewTextBoxColumn
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents colDoc As DataGridViewTextBoxColumn
    Friend WithEvents colACID As DataGridViewTextBoxColumn
    Friend WithEvents colCustomer As DataGridViewTextBoxColumn
    Friend WithEvents colNarration As DataGridViewTextBoxColumn
    Friend WithEvents colAmount As DataGridViewTextBoxColumn
    Friend WithEvents HisDate As DataGridViewTextBoxColumn
    Friend WithEvents hisDco As DataGridViewTextBoxColumn
    Friend WithEvents hisNarration As DataGridViewTextBoxColumn
    Friend WithEvents colDebit As DataGridViewTextBoxColumn
    Friend WithEvents hisCredit As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtTotalDiff As TextBox
    Friend WithEvents txtTotalCredit As TextBox
    Friend WithEvents Label23 As Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProHistory
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dStart = New System.Windows.Forms.DateTimePicker()
        Me.dEnd = New System.Windows.Forms.DateTimePicker()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtprid = New System.Windows.Forms.TextBox()
        Me.txtProduct = New System.Windows.Forms.TextBox()
        Me.txtCustID = New System.Windows.Forms.TextBox()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.txtTotalQTYin = New System.Windows.Forms.TextBox()
        Me.txtTotalQTYOut = New System.Windows.Forms.TextBox()
        Me.txtTotalQTYBal = New System.Windows.Forms.TextBox()
        Me.dgvProductHistory = New System.Windows.Forms.DataGridView()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colParty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQtyIn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQtyOut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNetRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDepartment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLoc2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProfit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClaim = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAcid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkPurchase = New System.Windows.Forms.CheckBox()
        Me.chkClaim = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkSTV = New System.Windows.Forms.CheckBox()
        Me.rdCurrentDate = New System.Windows.Forms.RadioButton()
        Me.rdStockDate = New System.Windows.Forms.RadioButton()
        Me.rdCurrentMonth = New System.Windows.Forms.RadioButton()
        Me.rdLastMonth = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtTotalOrderQty = New System.Windows.Forms.TextBox()
        Me.chkPending = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdLastPurchase = New System.Windows.Forms.RadioButton()
        CType(Me.dgvProductHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dStart
        '
        Me.dStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dStart.Location = New System.Drawing.Point(798, 8)
        Me.dStart.Name = "dStart"
        Me.dStart.Size = New System.Drawing.Size(113, 23)
        Me.dStart.TabIndex = 9
        '
        'dEnd
        '
        Me.dEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dEnd.Location = New System.Drawing.Point(798, 41)
        Me.dEnd.Name = "dEnd"
        Me.dEnd.Size = New System.Drawing.Size(113, 23)
        Me.dEnd.TabIndex = 11
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(1144, 4)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(125, 30)
        Me.btnGenerate.TabIndex = 17
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnClose.Location = New System.Drawing.Point(1272, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(92, 63)
        Me.btnClose.TabIndex = 18
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtprid
        '
        Me.txtprid.Location = New System.Drawing.Point(87, 15)
        Me.txtprid.Name = "txtprid"
        Me.txtprid.Size = New System.Drawing.Size(82, 20)
        Me.txtprid.TabIndex = 1
        '
        'txtProduct
        '
        Me.txtProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtProduct.Location = New System.Drawing.Point(255, 14)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.ReadOnly = True
        Me.txtProduct.Size = New System.Drawing.Size(272, 23)
        Me.txtProduct.TabIndex = 5
        Me.txtProduct.TabStop = False
        '
        'txtCustID
        '
        Me.txtCustID.Location = New System.Drawing.Point(87, 43)
        Me.txtCustID.Name = "txtCustID"
        Me.txtCustID.Size = New System.Drawing.Size(82, 20)
        Me.txtCustID.TabIndex = 3
        '
        'txtCustomer
        '
        Me.txtCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(255, 42)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(272, 23)
        Me.txtCustomer.TabIndex = 7
        Me.txtCustomer.TabStop = False
        '
        'txtTotalQTYin
        '
        Me.txtTotalQTYin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotalQTYin.Location = New System.Drawing.Point(788, 600)
        Me.txtTotalQTYin.Name = "txtTotalQTYin"
        Me.txtTotalQTYin.ReadOnly = True
        Me.txtTotalQTYin.Size = New System.Drawing.Size(71, 23)
        Me.txtTotalQTYin.TabIndex = 4
        Me.txtTotalQTYin.TabStop = False
        '
        'txtTotalQTYOut
        '
        Me.txtTotalQTYOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotalQTYOut.Location = New System.Drawing.Point(858, 600)
        Me.txtTotalQTYOut.Name = "txtTotalQTYOut"
        Me.txtTotalQTYOut.ReadOnly = True
        Me.txtTotalQTYOut.Size = New System.Drawing.Size(71, 23)
        Me.txtTotalQTYOut.TabIndex = 4
        Me.txtTotalQTYOut.TabStop = False
        '
        'txtTotalQTYBal
        '
        Me.txtTotalQTYBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotalQTYBal.Location = New System.Drawing.Point(928, 600)
        Me.txtTotalQTYBal.Name = "txtTotalQTYBal"
        Me.txtTotalQTYBal.ReadOnly = True
        Me.txtTotalQTYBal.Size = New System.Drawing.Size(68, 23)
        Me.txtTotalQTYBal.TabIndex = 4
        Me.txtTotalQTYBal.TabStop = False
        '
        'dgvProductHistory
        '
        Me.dgvProductHistory.AllowUserToAddRows = False
        Me.dgvProductHistory.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProductHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDate, Me.colType, Me.colDoc, Me.colParty, Me.colDesc, Me.colOrderQty, Me.colQtyIn, Me.colQtyOut, Me.colBal, Me.colRate, Me.colNetRate, Me.colDepartment, Me.colLoc2, Me.colProfit, Me.colClaim, Me.colAcid})
        Me.dgvProductHistory.Location = New System.Drawing.Point(28, 72)
        Me.dgvProductHistory.Name = "dgvProductHistory"
        Me.dgvProductHistory.ReadOnly = True
        Me.dgvProductHistory.RowHeadersWidth = 50
        Me.dgvProductHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvProductHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductHistory.Size = New System.Drawing.Size(1337, 529)
        Me.dgvProductHistory.TabIndex = 19
        '
        'colDate
        '
        Me.colDate.DataPropertyName = "Date"
        Me.colDate.HeaderText = "Date"
        Me.colDate.MinimumWidth = 6
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        Me.colDate.Width = 80
        '
        'colType
        '
        Me.colType.DataPropertyName = "Type"
        Me.colType.HeaderText = "Voucher"
        Me.colType.MinimumWidth = 6
        Me.colType.Name = "colType"
        Me.colType.ReadOnly = True
        Me.colType.Width = 80
        '
        'colDoc
        '
        Me.colDoc.DataPropertyName = "Doc"
        Me.colDoc.HeaderText = "Number"
        Me.colDoc.MinimumWidth = 6
        Me.colDoc.Name = "colDoc"
        Me.colDoc.ReadOnly = True
        Me.colDoc.Width = 70
        '
        'colParty
        '
        Me.colParty.DataPropertyName = "Subsidary"
        Me.colParty.HeaderText = "Particulars"
        Me.colParty.MinimumWidth = 6
        Me.colParty.Name = "colParty"
        Me.colParty.ReadOnly = True
        Me.colParty.Width = 230
        '
        'colDesc
        '
        Me.colDesc.DataPropertyName = "description"
        Me.colDesc.HeaderText = "Description"
        Me.colDesc.MinimumWidth = 6
        Me.colDesc.Name = "colDesc"
        Me.colDesc.ReadOnly = True
        Me.colDesc.Width = 180
        '
        'colOrderQty
        '
        Me.colOrderQty.DataPropertyName = "OrderQty"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.colOrderQty.DefaultCellStyle = DataGridViewCellStyle2
        Me.colOrderQty.HeaderText = "Order Qty"
        Me.colOrderQty.Name = "colOrderQty"
        Me.colOrderQty.ReadOnly = True
        Me.colOrderQty.Width = 70
        '
        'colQtyIn
        '
        Me.colQtyIn.DataPropertyName = "QtyIn"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle3.Format = "###.##"
        Me.colQtyIn.DefaultCellStyle = DataGridViewCellStyle3
        Me.colQtyIn.HeaderText = "Qty In"
        Me.colQtyIn.MinimumWidth = 6
        Me.colQtyIn.Name = "colQtyIn"
        Me.colQtyIn.ReadOnly = True
        Me.colQtyIn.Width = 70
        '
        'colQtyOut
        '
        Me.colQtyOut.DataPropertyName = "QtyOut"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.Format = "###.##"
        Me.colQtyOut.DefaultCellStyle = DataGridViewCellStyle4
        Me.colQtyOut.HeaderText = "Qty Out"
        Me.colQtyOut.MinimumWidth = 6
        Me.colQtyOut.Name = "colQtyOut"
        Me.colQtyOut.ReadOnly = True
        Me.colQtyOut.Width = 70
        '
        'colBal
        '
        Me.colBal.DataPropertyName = "Bal"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colBal.DefaultCellStyle = DataGridViewCellStyle5
        Me.colBal.HeaderText = "Balance Qty"
        Me.colBal.MinimumWidth = 6
        Me.colBal.Name = "colBal"
        Me.colBal.ReadOnly = True
        Me.colBal.Width = 70
        '
        'colRate
        '
        Me.colRate.DataPropertyName = "Rate"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colRate.DefaultCellStyle = DataGridViewCellStyle6
        Me.colRate.HeaderText = "Rate"
        Me.colRate.MinimumWidth = 6
        Me.colRate.Name = "colRate"
        Me.colRate.ReadOnly = True
        Me.colRate.Width = 60
        '
        'colNetRate
        '
        Me.colNetRate.DataPropertyName = "NetRate"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colNetRate.DefaultCellStyle = DataGridViewCellStyle7
        Me.colNetRate.HeaderText = "Net Rate"
        Me.colNetRate.MinimumWidth = 6
        Me.colNetRate.Name = "colNetRate"
        Me.colNetRate.ReadOnly = True
        Me.colNetRate.Width = 70
        '
        'colDepartment
        '
        Me.colDepartment.DataPropertyName = "Department"
        Me.colDepartment.HeaderText = "Locaition"
        Me.colDepartment.MinimumWidth = 6
        Me.colDepartment.Name = "colDepartment"
        Me.colDepartment.ReadOnly = True
        Me.colDepartment.Width = 80
        '
        'colLoc2
        '
        Me.colLoc2.DataPropertyName = "Department2"
        Me.colLoc2.HeaderText = "Loc. 2"
        Me.colLoc2.MinimumWidth = 6
        Me.colLoc2.Name = "colLoc2"
        Me.colLoc2.ReadOnly = True
        Me.colLoc2.Width = 80
        '
        'colProfit
        '
        Me.colProfit.DataPropertyName = "Profit"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colProfit.DefaultCellStyle = DataGridViewCellStyle8
        Me.colProfit.HeaderText = "Profit"
        Me.colProfit.MinimumWidth = 6
        Me.colProfit.Name = "colProfit"
        Me.colProfit.ReadOnly = True
        Me.colProfit.Visible = False
        Me.colProfit.Width = 125
        '
        'colClaim
        '
        Me.colClaim.DataPropertyName = "isclaim"
        Me.colClaim.HeaderText = "Claim"
        Me.colClaim.MinimumWidth = 6
        Me.colClaim.Name = "colClaim"
        Me.colClaim.ReadOnly = True
        Me.colClaim.Width = 50
        '
        'colAcid
        '
        Me.colAcid.DataPropertyName = "acid"
        Me.colAcid.HeaderText = "Acid"
        Me.colAcid.MinimumWidth = 6
        Me.colAcid.Name = "colAcid"
        Me.colAcid.ReadOnly = True
        Me.colAcid.Visible = False
        Me.colAcid.Width = 125
        '
        'chkPurchase
        '
        Me.chkPurchase.AutoSize = True
        Me.chkPurchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkPurchase.Location = New System.Drawing.Point(1019, 26)
        Me.chkPurchase.Name = "chkPurchase"
        Me.chkPurchase.Size = New System.Drawing.Size(130, 24)
        Me.chkPurchase.TabIndex = 15
        Me.chkPurchase.Text = "&Only Purchase"
        Me.chkPurchase.UseVisualStyleBackColor = True
        '
        'chkClaim
        '
        Me.chkClaim.AutoSize = True
        Me.chkClaim.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkClaim.Location = New System.Drawing.Point(1019, 47)
        Me.chkClaim.Name = "chkClaim"
        Me.chkClaim.Size = New System.Drawing.Size(67, 24)
        Me.chkClaim.TabIndex = 16
        Me.chkClaim.Text = "Cl&aim"
        Me.chkClaim.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(729, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "&Starting Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(729, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "&Ending Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "&Product ID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "&Account ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(169, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Product Details"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(169, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Account &Details"
        '
        'txtLocation
        '
        Me.txtLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(918, 10)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(79, 23)
        Me.txtLocation.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(935, -4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Location"
        '
        'chkSTV
        '
        Me.chkSTV.AutoSize = True
        Me.chkSTV.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkSTV.Location = New System.Drawing.Point(1019, 3)
        Me.chkSTV.Name = "chkSTV"
        Me.chkSTV.Size = New System.Drawing.Size(115, 24)
        Me.chkSTV.TabIndex = 14
        Me.chkSTV.Text = "&Include STV"
        Me.chkSTV.UseVisualStyleBackColor = True
        '
        'rdCurrentDate
        '
        Me.rdCurrentDate.AutoSize = True
        Me.rdCurrentDate.Location = New System.Drawing.Point(539, 11)
        Me.rdCurrentDate.Margin = New System.Windows.Forms.Padding(2)
        Me.rdCurrentDate.Name = "rdCurrentDate"
        Me.rdCurrentDate.Size = New System.Drawing.Size(85, 17)
        Me.rdCurrentDate.TabIndex = 20
        Me.rdCurrentDate.Text = "Current Date"
        Me.rdCurrentDate.UseVisualStyleBackColor = True
        '
        'rdStockDate
        '
        Me.rdStockDate.AutoSize = True
        Me.rdStockDate.Checked = True
        Me.rdStockDate.Location = New System.Drawing.Point(539, 28)
        Me.rdStockDate.Margin = New System.Windows.Forms.Padding(2)
        Me.rdStockDate.Name = "rdStockDate"
        Me.rdStockDate.Size = New System.Drawing.Size(79, 17)
        Me.rdStockDate.TabIndex = 20
        Me.rdStockDate.TabStop = True
        Me.rdStockDate.Text = "Stock Date"
        Me.rdStockDate.UseVisualStyleBackColor = True
        '
        'rdCurrentMonth
        '
        Me.rdCurrentMonth.AutoSize = True
        Me.rdCurrentMonth.Location = New System.Drawing.Point(539, 45)
        Me.rdCurrentMonth.Margin = New System.Windows.Forms.Padding(2)
        Me.rdCurrentMonth.Name = "rdCurrentMonth"
        Me.rdCurrentMonth.Size = New System.Drawing.Size(92, 17)
        Me.rdCurrentMonth.TabIndex = 20
        Me.rdCurrentMonth.Text = "Current Month"
        Me.rdCurrentMonth.UseVisualStyleBackColor = True
        '
        'rdLastMonth
        '
        Me.rdLastMonth.AutoSize = True
        Me.rdLastMonth.Location = New System.Drawing.Point(100, 12)
        Me.rdLastMonth.Margin = New System.Windows.Forms.Padding(2)
        Me.rdLastMonth.Name = "rdLastMonth"
        Me.rdLastMonth.Size = New System.Drawing.Size(78, 17)
        Me.rdLastMonth.TabIndex = 20
        Me.rdLastMonth.Text = "Last Month"
        Me.rdLastMonth.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.Location = New System.Drawing.Point(1144, 37)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 30)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "E&xport"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtTotalOrderQty
        '
        Me.txtTotalOrderQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotalOrderQty.Location = New System.Drawing.Point(723, 600)
        Me.txtTotalOrderQty.Name = "txtTotalOrderQty"
        Me.txtTotalOrderQty.ReadOnly = True
        Me.txtTotalOrderQty.Size = New System.Drawing.Size(66, 23)
        Me.txtTotalOrderQty.TabIndex = 4
        Me.txtTotalOrderQty.TabStop = False
        '
        'chkPending
        '
        Me.chkPending.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkPending.Location = New System.Drawing.Point(918, 32)
        Me.chkPending.Name = "chkPending"
        Me.chkPending.Size = New System.Drawing.Size(101, 35)
        Me.chkPending.TabIndex = 22
        Me.chkPending.Text = "Only Pending Orders"
        Me.chkPending.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdLastPurchase)
        Me.GroupBox1.Controls.Add(Me.rdLastMonth)
        Me.GroupBox1.Location = New System.Drawing.Point(532, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(191, 67)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'rdLastPurchase
        '
        Me.rdLastPurchase.AutoSize = True
        Me.rdLastPurchase.Location = New System.Drawing.Point(100, 34)
        Me.rdLastPurchase.Name = "rdLastPurchase"
        Me.rdLastPurchase.Size = New System.Drawing.Size(93, 17)
        Me.rdLastPurchase.TabIndex = 0
        Me.rdLastPurchase.TabStop = True
        Me.rdLastPurchase.Text = "Last Purchase"
        Me.rdLastPurchase.UseVisualStyleBackColor = True
        '
        'frmProHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1383, 623)
        Me.Controls.Add(Me.chkPending)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.rdCurrentMonth)
        Me.Controls.Add(Me.rdStockDate)
        Me.Controls.Add(Me.rdCurrentDate)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkClaim)
        Me.Controls.Add(Me.chkSTV)
        Me.Controls.Add(Me.chkPurchase)
        Me.Controls.Add(Me.dgvProductHistory)
        Me.Controls.Add(Me.txtCustomer)
        Me.Controls.Add(Me.txtProduct)
        Me.Controls.Add(Me.txtTotalQTYBal)
        Me.Controls.Add(Me.txtTotalQTYOut)
        Me.Controls.Add(Me.txtTotalOrderQty)
        Me.Controls.Add(Me.txtTotalQTYin)
        Me.Controls.Add(Me.txtCustID)
        Me.Controls.Add(Me.txtprid)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.dEnd)
        Me.Controls.Add(Me.dStart)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmProHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmProHistory"
        CType(Me.dgvProductHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dStart As DateTimePicker
    Friend WithEvents dEnd As DateTimePicker
    Friend WithEvents btnGenerate As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents txtprid As TextBox
    Friend WithEvents txtProduct As TextBox
    Friend WithEvents txtCustID As TextBox
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents txtTotalQTYin As TextBox
    Friend WithEvents txtTotalQTYOut As TextBox
    Friend WithEvents txtTotalQTYBal As TextBox
    Friend WithEvents dgvProductHistory As DataGridView
    Friend WithEvents chkPurchase As CheckBox
    Friend WithEvents chkClaim As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents chkSTV As CheckBox
    Friend WithEvents rdCurrentDate As RadioButton
    Friend WithEvents rdStockDate As RadioButton
    Friend WithEvents rdCurrentMonth As RadioButton
    Friend WithEvents rdLastMonth As RadioButton
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents colType As DataGridViewTextBoxColumn
    Friend WithEvents colDoc As DataGridViewTextBoxColumn
    Friend WithEvents colParty As DataGridViewTextBoxColumn
    Friend WithEvents colDesc As DataGridViewTextBoxColumn
    Friend WithEvents colOrderQty As DataGridViewTextBoxColumn
    Friend WithEvents colQtyIn As DataGridViewTextBoxColumn
    Friend WithEvents colQtyOut As DataGridViewTextBoxColumn
    Friend WithEvents colBal As DataGridViewTextBoxColumn
    Friend WithEvents colRate As DataGridViewTextBoxColumn
    Friend WithEvents colNetRate As DataGridViewTextBoxColumn
    Friend WithEvents colDepartment As DataGridViewTextBoxColumn
    Friend WithEvents colLoc2 As DataGridViewTextBoxColumn
    Friend WithEvents colProfit As DataGridViewTextBoxColumn
    Friend WithEvents colClaim As DataGridViewTextBoxColumn
    Friend WithEvents colAcid As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents txtTotalOrderQty As TextBox
    Friend WithEvents chkPending As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdLastPurchase As RadioButton
End Class

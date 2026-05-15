<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRouteCalls
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.txtRoute = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCaller = New System.Windows.Forms.ComboBox()
        Me.dgvRouteCustomersList = New System.Windows.Forms.DataGridView()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rdAll = New System.Windows.Forms.RadioButton()
        Me.rdPending = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rdFinal = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdBlank = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLastSalesDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLastSales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCurrentBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOcell = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCell2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCalledBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTime1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemarks1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTime2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemarks2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTime3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemarks3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvRouteCustomersList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.LimeGreen
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(-4, -2)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1527, 38)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Route Calls"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(160, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Route"
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(49, 22)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(113, 26)
        Me.dtp1.TabIndex = 2
        '
        'txtRoute
        '
        Me.txtRoute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRoute.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtRoute.Location = New System.Drawing.Point(216, 22)
        Me.txtRoute.Name = "txtRoute"
        Me.txtRoute.Size = New System.Drawing.Size(73, 26)
        Me.txtRoute.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(1168, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(229, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Select Caller to save call record"
        '
        'cmbCaller
        '
        Me.cmbCaller.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmbCaller.FormattingEnabled = True
        Me.cmbCaller.Items.AddRange(New Object() {"HAMZA", "BILAL", "MR. SAEED", "ARIF", "FAKHAR", "SANAULHAQ", "ZAIN", "GULL REHMAR"})
        Me.cmbCaller.Location = New System.Drawing.Point(1214, 61)
        Me.cmbCaller.Name = "cmbCaller"
        Me.cmbCaller.Size = New System.Drawing.Size(157, 28)
        Me.cmbCaller.TabIndex = 9
        '
        'dgvRouteCustomersList
        '
        Me.dgvRouteCustomersList.AllowUserToAddRows = False
        Me.dgvRouteCustomersList.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvRouteCustomersList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRouteCustomersList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRouteCustomersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRouteCustomersList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colLastSalesDate, Me.colLastSales, Me.colCurrentBalance, Me.colCustomerName, Me.colOcell, Me.colCell2, Me.colCalledBy, Me.colTime1, Me.colRemarks1, Me.colTime2, Me.colRemarks2, Me.colTime3, Me.colRemarks3})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRouteCustomersList.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvRouteCustomersList.Location = New System.Drawing.Point(7, 100)
        Me.dgvRouteCustomersList.Name = "dgvRouteCustomersList"
        Me.dgvRouteCustomersList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRouteCustomersList.Size = New System.Drawing.Size(1521, 580)
        Me.dgvRouteCustomersList.TabIndex = 10
        '
        'btnGenerate
        '
        Me.btnGenerate.BackColor = System.Drawing.Color.LightGreen
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(561, 9)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(134, 50)
        Me.btnGenerate.TabIndex = 9
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Red
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnClose.Location = New System.Drawing.Point(1401, 41)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(122, 50)
        Me.btnClose.TabIndex = 11
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.LightGray
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(711, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "NA = NOT ATTEND"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Red
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(711, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "NO = NO ORDER   "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.LightPink
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(866, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 20)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "NT = NEXT TIME "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.LightGreen
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.Location = New System.Drawing.Point(866, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 20)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "OK = ORDER OK"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Orchid
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.Location = New System.Drawing.Point(1008, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(146, 20)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "PF = POWER OFF "
        '
        'rdAll
        '
        Me.rdAll.AutoSize = True
        Me.rdAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdAll.Location = New System.Drawing.Point(443, 19)
        Me.rdAll.Name = "rdAll"
        Me.rdAll.Size = New System.Drawing.Size(112, 21)
        Me.rdAll.TabIndex = 8
        Me.rdAll.Text = "All Customers"
        Me.rdAll.UseVisualStyleBackColor = True
        '
        'rdPending
        '
        Me.rdPending.AutoSize = True
        Me.rdPending.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdPending.Location = New System.Drawing.Point(288, 20)
        Me.rdPending.Name = "rdPending"
        Me.rdPending.Size = New System.Drawing.Size(149, 21)
        Me.rdPending.TabIndex = 6
        Me.rdPending.Text = "Pending Customers"
        Me.rdPending.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.LemonChiffon
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.Location = New System.Drawing.Point(1008, 65)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 20)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "BZ = BUSY             "
        '
        'rdFinal
        '
        Me.rdFinal.AutoSize = True
        Me.rdFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdFinal.Location = New System.Drawing.Point(288, 39)
        Me.rdFinal.Name = "rdFinal"
        Me.rdFinal.Size = New System.Drawing.Size(153, 21)
        Me.rdFinal.TabIndex = 7
        Me.rdFinal.Text = "Finalized Customers"
        Me.rdFinal.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdPending)
        Me.GroupBox1.Controls.Add(Me.rdBlank)
        Me.GroupBox1.Controls.Add(Me.rdFinal)
        Me.GroupBox1.Controls.Add(Me.btnGenerate)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.rdAll)
        Me.GroupBox1.Controls.Add(Me.dtp1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtRoute)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(701, 61)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'rdBlank
        '
        Me.rdBlank.AutoSize = True
        Me.rdBlank.Checked = True
        Me.rdBlank.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdBlank.Location = New System.Drawing.Point(288, 3)
        Me.rdBlank.Name = "rdBlank"
        Me.rdBlank.Size = New System.Drawing.Size(121, 21)
        Me.rdBlank.TabIndex = 5
        Me.rdBlank.TabStop = True
        Me.rdBlank.Text = "Blank Remarks"
        Me.rdBlank.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label10.Location = New System.Drawing.Point(49, -1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(229, 20)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Customer Selection Criteria"
        '
        'colID
        '
        Me.colID.DataPropertyName = "id"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colID.DefaultCellStyle = DataGridViewCellStyle3
        Me.colID.Frozen = True
        Me.colID.HeaderText = "Acc.ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Width = 60
        '
        'colLastSalesDate
        '
        Me.colLastSalesDate.DataPropertyName = "LastSaleDate"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colLastSalesDate.DefaultCellStyle = DataGridViewCellStyle4
        Me.colLastSalesDate.Frozen = True
        Me.colLastSalesDate.HeaderText = "Last Sale Date"
        Me.colLastSalesDate.Name = "colLastSalesDate"
        Me.colLastSalesDate.ReadOnly = True
        '
        'colLastSales
        '
        Me.colLastSales.DataPropertyName = "LastSalesAmount"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        Me.colLastSales.DefaultCellStyle = DataGridViewCellStyle5
        Me.colLastSales.Frozen = True
        Me.colLastSales.HeaderText = "Last Sales"
        Me.colLastSales.Name = "colLastSales"
        Me.colLastSales.ReadOnly = True
        '
        'colCurrentBalance
        '
        Me.colCurrentBalance.DataPropertyName = "Balance"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle6.Format = "N0"
        Me.colCurrentBalance.DefaultCellStyle = DataGridViewCellStyle6
        Me.colCurrentBalance.DividerWidth = 5
        Me.colCurrentBalance.Frozen = True
        Me.colCurrentBalance.HeaderText = "Current Balance"
        Me.colCurrentBalance.Name = "colCurrentBalance"
        Me.colCurrentBalance.ReadOnly = True
        '
        'colCustomerName
        '
        Me.colCustomerName.DataPropertyName = "Subsidary"
        Me.colCustomerName.Frozen = True
        Me.colCustomerName.HeaderText = "Customer Name"
        Me.colCustomerName.Name = "colCustomerName"
        Me.colCustomerName.ReadOnly = True
        Me.colCustomerName.Width = 290
        '
        'colOcell
        '
        Me.colOcell.DataPropertyName = "OCell"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.colOcell.DefaultCellStyle = DataGridViewCellStyle7
        Me.colOcell.Frozen = True
        Me.colOcell.HeaderText = "Mobile"
        Me.colOcell.Name = "colOcell"
        Me.colOcell.ReadOnly = True
        Me.colOcell.Width = 140
        '
        'colCell2
        '
        Me.colCell2.DataPropertyName = "Cell2"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colCell2.DefaultCellStyle = DataGridViewCellStyle8
        Me.colCell2.DividerWidth = 5
        Me.colCell2.Frozen = True
        Me.colCell2.HeaderText = "Mobile 2"
        Me.colCell2.Name = "colCell2"
        Me.colCell2.ReadOnly = True
        Me.colCell2.Width = 120
        '
        'colCalledBy
        '
        Me.colCalledBy.DataPropertyName = "CalledBy"
        Me.colCalledBy.DividerWidth = 2
        Me.colCalledBy.Frozen = True
        Me.colCalledBy.HeaderText = "Called By"
        Me.colCalledBy.Name = "colCalledBy"
        Me.colCalledBy.ReadOnly = True
        '
        'colTime1
        '
        Me.colTime1.DataPropertyName = "CallTime1"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTime1.DefaultCellStyle = DataGridViewCellStyle9
        Me.colTime1.HeaderText = "Time1"
        Me.colTime1.Name = "colTime1"
        Me.colTime1.Width = 60
        '
        'colRemarks1
        '
        Me.colRemarks1.DataPropertyName = "Remarks1"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRemarks1.DefaultCellStyle = DataGridViewCellStyle10
        Me.colRemarks1.DividerWidth = 2
        Me.colRemarks1.HeaderText = "Remark1"
        Me.colRemarks1.Name = "colRemarks1"
        Me.colRemarks1.Width = 90
        '
        'colTime2
        '
        Me.colTime2.DataPropertyName = "CallTime2"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTime2.DefaultCellStyle = DataGridViewCellStyle11
        Me.colTime2.HeaderText = "Time2"
        Me.colTime2.Name = "colTime2"
        Me.colTime2.Width = 60
        '
        'colRemarks2
        '
        Me.colRemarks2.DataPropertyName = "Remarks2"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRemarks2.DefaultCellStyle = DataGridViewCellStyle12
        Me.colRemarks2.DividerWidth = 2
        Me.colRemarks2.HeaderText = "Remark2"
        Me.colRemarks2.Name = "colRemarks2"
        Me.colRemarks2.Width = 90
        '
        'colTime3
        '
        Me.colTime3.DataPropertyName = "CallTime3"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTime3.DefaultCellStyle = DataGridViewCellStyle13
        Me.colTime3.HeaderText = "Time3"
        Me.colTime3.Name = "colTime3"
        Me.colTime3.Width = 60
        '
        'colRemarks3
        '
        Me.colRemarks3.DataPropertyName = "Remarks3"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRemarks3.DefaultCellStyle = DataGridViewCellStyle14
        Me.colRemarks3.HeaderText = "Remark3"
        Me.colRemarks3.Name = "colRemarks3"
        Me.colRemarks3.Width = 90
        '
        'frmRouteCalls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1525, 681)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dgvRouteCustomersList)
        Me.Controls.Add(Me.cmbCaller)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRouteCalls"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmRouteCalls"
        CType(Me.dgvRouteCustomersList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents txtRoute As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbCaller As ComboBox
    Friend WithEvents dgvRouteCustomersList As DataGridView
    Friend WithEvents btnGenerate As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents rdAll As RadioButton
    Friend WithEvents rdPending As RadioButton
    Friend WithEvents Label9 As Label
    Friend WithEvents rdFinal As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents rdBlank As RadioButton
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents colLastSalesDate As DataGridViewTextBoxColumn
    Friend WithEvents colLastSales As DataGridViewTextBoxColumn
    Friend WithEvents colCurrentBalance As DataGridViewTextBoxColumn
    Friend WithEvents colCustomerName As DataGridViewTextBoxColumn
    Friend WithEvents colOcell As DataGridViewTextBoxColumn
    Friend WithEvents colCell2 As DataGridViewTextBoxColumn
    Friend WithEvents colCalledBy As DataGridViewTextBoxColumn
    Friend WithEvents colTime1 As DataGridViewTextBoxColumn
    Friend WithEvents colRemarks1 As DataGridViewTextBoxColumn
    Friend WithEvents colTime2 As DataGridViewTextBoxColumn
    Friend WithEvents colRemarks2 As DataGridViewTextBoxColumn
    Friend WithEvents colTime3 As DataGridViewTextBoxColumn
    Friend WithEvents colRemarks3 As DataGridViewTextBoxColumn
End Class

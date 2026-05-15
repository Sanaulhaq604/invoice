<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInvoiceList
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.DTPStart = New System.Windows.Forms.DateTimePicker()
        Me.txtRoute = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.btnExportSelected = New System.Windows.Forms.Button()
        Me.btnPrintSelected = New System.Windows.Forms.Button()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.DTPEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DGVList = New System.Windows.Forms.DataGridView()
        Me.ColNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRoute = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGoods = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFreight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProfitP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGProfit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOcell = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColACID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUrduName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblDoc = New System.Windows.Forms.Label()
        Me.txtFreightTotal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.btnListPreview = New System.Windows.Forms.Button()
        Me.txtTotalProfit = New System.Windows.Forms.TextBox()
        Me.txtProfitP = New System.Windows.Forms.TextBox()
        Me.txtMonthlyProfitP = New System.Windows.Forms.TextBox()
        Me.txtMonthlyProfitTotal = New System.Windows.Forms.TextBox()
        Me.txtMonthlyFreightTotal = New System.Windows.Forms.TextBox()
        Me.txtMonthlyTotal = New System.Windows.Forms.TextBox()
        Me.lblTotals = New System.Windows.Forms.Label()
        Me.lblMonthlyTotals = New System.Windows.Forms.Label()
        Me.txtMonthlyEstimatedTotal = New System.Windows.Forms.TextBox()
        Me.txtAvgDailyProfit = New System.Windows.Forms.TextBox()
        Me.chkReceipt = New System.Windows.Forms.CheckBox()
        Me.chkALL = New System.Windows.Forms.RadioButton()
        Me.chkEstimates = New System.Windows.Forms.RadioButton()
        Me.chkInvoices = New System.Windows.Forms.RadioButton()
        Me.chkSMS = New System.Windows.Forms.CheckBox()
        Me.txtSMServer = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.btnSMS = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDelay = New System.Windows.Forms.TextBox()
        Me.lblcustomerName = New System.Windows.Forms.Label()
        Me.txtTotalReceipt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbUser = New System.Windows.Forms.ComboBox()
        CType(Me.DGVList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DTPStart
        '
        Me.DTPStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DTPStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPStart.Location = New System.Drawing.Point(294, 46)
        Me.DTPStart.Name = "DTPStart"
        Me.DTPStart.Size = New System.Drawing.Size(122, 26)
        Me.DTPStart.TabIndex = 3
        '
        'txtRoute
        '
        Me.txtRoute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRoute.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtRoute.Location = New System.Drawing.Point(674, 46)
        Me.txtRoute.Name = "txtRoute"
        Me.txtRoute.Size = New System.Drawing.Size(49, 26)
        Me.txtRoute.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(210, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Start Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(620, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 18)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Route"
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Green
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.White
        Me.BtnPrint.Location = New System.Drawing.Point(517, 610)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(107, 31)
        Me.BtnPrint.TabIndex = 14
        Me.BtnPrint.Text = "&Print All"
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Red
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.Location = New System.Drawing.Point(632, 610)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(101, 29)
        Me.btnExit.TabIndex = 15
        Me.btnExit.Text = "&Close"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.Green
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.Location = New System.Drawing.Point(408, 610)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(107, 31)
        Me.btnExport.TabIndex = 13
        Me.btnExport.Text = "&Export All"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Customer"
        '
        'txtCustomer
        '
        Me.txtCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(97, 46)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(108, 26)
        Me.txtCustomer.TabIndex = 1
        '
        'btnExportSelected
        '
        Me.btnExportSelected.BackColor = System.Drawing.Color.LightSkyBlue
        Me.btnExportSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExportSelected.Location = New System.Drawing.Point(122, 610)
        Me.btnExportSelected.Name = "btnExportSelected"
        Me.btnExportSelected.Size = New System.Drawing.Size(107, 31)
        Me.btnExportSelected.TabIndex = 15
        Me.btnExportSelected.Text = "Export Selected"
        Me.btnExportSelected.UseVisualStyleBackColor = False
        '
        'btnPrintSelected
        '
        Me.btnPrintSelected.BackColor = System.Drawing.Color.LightSkyBlue
        Me.btnPrintSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPrintSelected.Location = New System.Drawing.Point(234, 610)
        Me.btnPrintSelected.Name = "btnPrintSelected"
        Me.btnPrintSelected.Size = New System.Drawing.Size(107, 31)
        Me.btnPrintSelected.TabIndex = 16
        Me.btnPrintSelected.Text = "Print Selected"
        Me.btnPrintSelected.UseVisualStyleBackColor = False
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(804, 607)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(88, 26)
        Me.txtTotal.TabIndex = 11
        Me.txtTotal.TabStop = False
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DTPEnd
        '
        Me.DTPEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DTPEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPEnd.Location = New System.Drawing.Point(498, 46)
        Me.DTPEnd.Name = "DTPEnd"
        Me.DTPEnd.Size = New System.Drawing.Size(121, 26)
        Me.DTPEnd.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(420, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 18)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "End Date"
        '
        'DGVList
        '
        Me.DGVList.AllowUserToAddRows = False
        Me.DGVList.AllowUserToDeleteRows = False
        Me.DGVList.AllowUserToOrderColumns = True
        Me.DGVList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVList.ColumnHeadersHeight = 30
        Me.DGVList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNumber, Me.ColDate, Me.ColDoc, Me.ColCustomer, Me.colDesc, Me.colRoute, Me.colGoods, Me.ColFreight, Me.ColAmount, Me.colReceived, Me.colProfitP, Me.colGProfit, Me.colRemarks, Me.colRDate, Me.colOcell, Me.ColPB, Me.ColACID, Me.colUrduName})
        Me.DGVList.Location = New System.Drawing.Point(4, 87)
        Me.DGVList.MultiSelect = False
        Me.DGVList.Name = "DGVList"
        Me.DGVList.ReadOnly = True
        Me.DGVList.RowHeadersVisible = False
        Me.DGVList.RowHeadersWidth = 51
        Me.DGVList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVList.Size = New System.Drawing.Size(1457, 513)
        Me.DGVList.TabIndex = 20
        Me.DGVList.TabStop = False
        '
        'ColNumber
        '
        Me.ColNumber.DataPropertyName = "rn"
        Me.ColNumber.HeaderText = "Sr. #"
        Me.ColNumber.MinimumWidth = 6
        Me.ColNumber.Name = "ColNumber"
        Me.ColNumber.ReadOnly = True
        Me.ColNumber.Width = 40
        '
        'ColDate
        '
        Me.ColDate.DataPropertyName = "date"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.ColDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColDate.HeaderText = "Date"
        Me.ColDate.MinimumWidth = 6
        Me.ColDate.Name = "ColDate"
        Me.ColDate.ReadOnly = True
        Me.ColDate.Width = 60
        '
        'ColDoc
        '
        Me.ColDoc.DataPropertyName = "doc"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ColDoc.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColDoc.HeaderText = "Document"
        Me.ColDoc.MinimumWidth = 6
        Me.ColDoc.Name = "ColDoc"
        Me.ColDoc.ReadOnly = True
        Me.ColDoc.Width = 60
        '
        'ColCustomer
        '
        Me.ColCustomer.DataPropertyName = "Subsidary"
        Me.ColCustomer.HeaderText = "Customer Name"
        Me.ColCustomer.MinimumWidth = 6
        Me.ColCustomer.Name = "ColCustomer"
        Me.ColCustomer.ReadOnly = True
        Me.ColCustomer.Width = 220
        '
        'colDesc
        '
        Me.colDesc.DataPropertyName = "Description"
        Me.colDesc.HeaderText = "Description"
        Me.colDesc.MinimumWidth = 6
        Me.colDesc.Name = "colDesc"
        Me.colDesc.ReadOnly = True
        Me.colDesc.Width = 223
        '
        'colRoute
        '
        Me.colRoute.DataPropertyName = "Route"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRoute.DefaultCellStyle = DataGridViewCellStyle4
        Me.colRoute.HeaderText = "Route"
        Me.colRoute.MinimumWidth = 6
        Me.colRoute.Name = "colRoute"
        Me.colRoute.ReadOnly = True
        Me.colRoute.Width = 80
        '
        'colGoods
        '
        Me.colGoods.DataPropertyName = "Goods"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colGoods.DefaultCellStyle = DataGridViewCellStyle5
        Me.colGoods.HeaderText = "Transporter"
        Me.colGoods.MinimumWidth = 6
        Me.colGoods.Name = "colGoods"
        Me.colGoods.ReadOnly = True
        Me.colGoods.Width = 85
        '
        'ColFreight
        '
        Me.ColFreight.DataPropertyName = "Freight"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColFreight.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColFreight.HeaderText = "Freight"
        Me.ColFreight.MinimumWidth = 6
        Me.ColFreight.Name = "ColFreight"
        Me.ColFreight.ReadOnly = True
        Me.ColFreight.Width = 50
        '
        'ColAmount
        '
        Me.ColAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.ColAmount.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColAmount.HeaderText = "Amount"
        Me.ColAmount.MinimumWidth = 6
        Me.ColAmount.Name = "ColAmount"
        Me.ColAmount.ReadOnly = True
        '
        'colReceived
        '
        Me.colReceived.DataPropertyName = "Received"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.colReceived.DefaultCellStyle = DataGridViewCellStyle8
        Me.colReceived.HeaderText = "Received"
        Me.colReceived.MinimumWidth = 6
        Me.colReceived.Name = "colReceived"
        Me.colReceived.ReadOnly = True
        Me.colReceived.Width = 70
        '
        'colProfitP
        '
        Me.colProfitP.DataPropertyName = "pp"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.colProfitP.DefaultCellStyle = DataGridViewCellStyle9
        Me.colProfitP.HeaderText = "Profit %"
        Me.colProfitP.MinimumWidth = 6
        Me.colProfitP.Name = "colProfitP"
        Me.colProfitP.ReadOnly = True
        Me.colProfitP.Width = 60
        '
        'colGProfit
        '
        Me.colGProfit.DataPropertyName = "grossprofit"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colGProfit.DefaultCellStyle = DataGridViewCellStyle10
        Me.colGProfit.HeaderText = "Gross Profit"
        Me.colGProfit.MinimumWidth = 6
        Me.colGProfit.Name = "colGProfit"
        Me.colGProfit.ReadOnly = True
        Me.colGProfit.Width = 80
        '
        'colRemarks
        '
        Me.colRemarks.DataPropertyName = "remarks"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colRemarks.DefaultCellStyle = DataGridViewCellStyle11
        Me.colRemarks.HeaderText = "Remarks"
        Me.colRemarks.MinimumWidth = 6
        Me.colRemarks.Name = "colRemarks"
        Me.colRemarks.ReadOnly = True
        Me.colRemarks.Width = 120
        '
        'colRDate
        '
        Me.colRDate.DataPropertyName = "Rdate"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRDate.DefaultCellStyle = DataGridViewCellStyle12
        Me.colRDate.HeaderText = "RunsDate"
        Me.colRDate.MinimumWidth = 6
        Me.colRDate.Name = "colRDate"
        Me.colRDate.ReadOnly = True
        Me.colRDate.Visible = False
        Me.colRDate.Width = 80
        '
        'colOcell
        '
        Me.colOcell.DataPropertyName = "ocell"
        Me.colOcell.HeaderText = "Mobile"
        Me.colOcell.MinimumWidth = 6
        Me.colOcell.Name = "colOcell"
        Me.colOcell.ReadOnly = True
        Me.colOcell.Visible = False
        Me.colOcell.Width = 125
        '
        'ColPB
        '
        Me.ColPB.DataPropertyName = "PreB"
        Me.ColPB.HeaderText = "Previous Balance"
        Me.ColPB.MinimumWidth = 6
        Me.ColPB.Name = "ColPB"
        Me.ColPB.ReadOnly = True
        Me.ColPB.Visible = False
        Me.ColPB.Width = 125
        '
        'ColACID
        '
        Me.ColACID.DataPropertyName = "ID"
        Me.ColACID.HeaderText = "CusID"
        Me.ColACID.MinimumWidth = 6
        Me.ColACID.Name = "ColACID"
        Me.ColACID.ReadOnly = True
        Me.ColACID.Visible = False
        Me.ColACID.Width = 125
        '
        'colUrduName
        '
        Me.colUrduName.DataPropertyName = "UrduName"
        Me.colUrduName.HeaderText = "UrduName"
        Me.colUrduName.MinimumWidth = 6
        Me.colUrduName.Name = "colUrduName"
        Me.colUrduName.ReadOnly = True
        Me.colUrduName.Visible = False
        Me.colUrduName.Width = 125
        '
        'lblDoc
        '
        Me.lblDoc.BackColor = System.Drawing.Color.DarkGreen
        Me.lblDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDoc.ForeColor = System.Drawing.Color.White
        Me.lblDoc.Location = New System.Drawing.Point(2, -4)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(1390, 38)
        Me.lblDoc.TabIndex = 14
        Me.lblDoc.Text = "Invoice List"
        Me.lblDoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFreightTotal
        '
        Me.txtFreightTotal.BackColor = System.Drawing.Color.White
        Me.txtFreightTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtFreightTotal.Location = New System.Drawing.Point(955, 607)
        Me.txtFreightTotal.Name = "txtFreightTotal"
        Me.txtFreightTotal.ReadOnly = True
        Me.txtFreightTotal.Size = New System.Drawing.Size(48, 26)
        Me.txtFreightTotal.TabIndex = 11
        Me.txtFreightTotal.TabStop = False
        Me.txtFreightTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(726, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 18)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Desc."
        '
        'txtDescription
        '
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(779, 46)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(94, 26)
        Me.txtDescription.TabIndex = 10
        '
        'btnListPreview
        '
        Me.btnListPreview.BackColor = System.Drawing.Color.Red
        Me.btnListPreview.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnListPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnListPreview.ForeColor = System.Drawing.Color.White
        Me.btnListPreview.Location = New System.Drawing.Point(6, 612)
        Me.btnListPreview.Name = "btnListPreview"
        Me.btnListPreview.Size = New System.Drawing.Size(107, 29)
        Me.btnListPreview.TabIndex = 14
        Me.btnListPreview.Text = "&List Preview"
        Me.btnListPreview.UseVisualStyleBackColor = False
        '
        'txtTotalProfit
        '
        Me.txtTotalProfit.BackColor = System.Drawing.Color.White
        Me.txtTotalProfit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotalProfit.Location = New System.Drawing.Point(1003, 607)
        Me.txtTotalProfit.Name = "txtTotalProfit"
        Me.txtTotalProfit.ReadOnly = True
        Me.txtTotalProfit.Size = New System.Drawing.Size(78, 26)
        Me.txtTotalProfit.TabIndex = 11
        Me.txtTotalProfit.TabStop = False
        Me.txtTotalProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProfitP
        '
        Me.txtProfitP.BackColor = System.Drawing.Color.White
        Me.txtProfitP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtProfitP.Location = New System.Drawing.Point(1079, 607)
        Me.txtProfitP.Name = "txtProfitP"
        Me.txtProfitP.ReadOnly = True
        Me.txtProfitP.Size = New System.Drawing.Size(62, 26)
        Me.txtProfitP.TabIndex = 11
        Me.txtProfitP.TabStop = False
        Me.txtProfitP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtProfitP.Visible = False
        '
        'txtMonthlyProfitP
        '
        Me.txtMonthlyProfitP.BackColor = System.Drawing.Color.White
        Me.txtMonthlyProfitP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtMonthlyProfitP.Location = New System.Drawing.Point(1079, 632)
        Me.txtMonthlyProfitP.Name = "txtMonthlyProfitP"
        Me.txtMonthlyProfitP.ReadOnly = True
        Me.txtMonthlyProfitP.Size = New System.Drawing.Size(62, 26)
        Me.txtMonthlyProfitP.TabIndex = 16
        Me.txtMonthlyProfitP.TabStop = False
        Me.txtMonthlyProfitP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMonthlyProfitP.Visible = False
        '
        'txtMonthlyProfitTotal
        '
        Me.txtMonthlyProfitTotal.BackColor = System.Drawing.Color.White
        Me.txtMonthlyProfitTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtMonthlyProfitTotal.Location = New System.Drawing.Point(1003, 632)
        Me.txtMonthlyProfitTotal.Name = "txtMonthlyProfitTotal"
        Me.txtMonthlyProfitTotal.ReadOnly = True
        Me.txtMonthlyProfitTotal.Size = New System.Drawing.Size(78, 26)
        Me.txtMonthlyProfitTotal.TabIndex = 17
        Me.txtMonthlyProfitTotal.TabStop = False
        Me.txtMonthlyProfitTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMonthlyFreightTotal
        '
        Me.txtMonthlyFreightTotal.BackColor = System.Drawing.Color.White
        Me.txtMonthlyFreightTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtMonthlyFreightTotal.Location = New System.Drawing.Point(955, 632)
        Me.txtMonthlyFreightTotal.Name = "txtMonthlyFreightTotal"
        Me.txtMonthlyFreightTotal.ReadOnly = True
        Me.txtMonthlyFreightTotal.Size = New System.Drawing.Size(48, 26)
        Me.txtMonthlyFreightTotal.TabIndex = 18
        Me.txtMonthlyFreightTotal.TabStop = False
        Me.txtMonthlyFreightTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMonthlyTotal
        '
        Me.txtMonthlyTotal.BackColor = System.Drawing.Color.White
        Me.txtMonthlyTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtMonthlyTotal.Location = New System.Drawing.Point(804, 632)
        Me.txtMonthlyTotal.Name = "txtMonthlyTotal"
        Me.txtMonthlyTotal.ReadOnly = True
        Me.txtMonthlyTotal.Size = New System.Drawing.Size(88, 26)
        Me.txtMonthlyTotal.TabIndex = 19
        Me.txtMonthlyTotal.TabStop = False
        Me.txtMonthlyTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotals
        '
        Me.lblTotals.AutoSize = True
        Me.lblTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblTotals.Location = New System.Drawing.Point(741, 611)
        Me.lblTotals.Name = "lblTotals"
        Me.lblTotals.Size = New System.Drawing.Size(52, 20)
        Me.lblTotals.TabIndex = 20
        Me.lblTotals.Text = "Totals"
        '
        'lblMonthlyTotals
        '
        Me.lblMonthlyTotals.AutoSize = True
        Me.lblMonthlyTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblMonthlyTotals.Location = New System.Drawing.Point(733, 635)
        Me.lblMonthlyTotals.Name = "lblMonthlyTotals"
        Me.lblMonthlyTotals.Size = New System.Drawing.Size(69, 20)
        Me.lblMonthlyTotals.TabIndex = 20
        Me.lblMonthlyTotals.Text = "M.Totals"
        '
        'txtMonthlyEstimatedTotal
        '
        Me.txtMonthlyEstimatedTotal.BackColor = System.Drawing.Color.White
        Me.txtMonthlyEstimatedTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtMonthlyEstimatedTotal.Location = New System.Drawing.Point(1140, 632)
        Me.txtMonthlyEstimatedTotal.Name = "txtMonthlyEstimatedTotal"
        Me.txtMonthlyEstimatedTotal.ReadOnly = True
        Me.txtMonthlyEstimatedTotal.Size = New System.Drawing.Size(86, 26)
        Me.txtMonthlyEstimatedTotal.TabIndex = 19
        Me.txtMonthlyEstimatedTotal.TabStop = False
        Me.txtMonthlyEstimatedTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAvgDailyProfit
        '
        Me.txtAvgDailyProfit.BackColor = System.Drawing.Color.White
        Me.txtAvgDailyProfit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtAvgDailyProfit.Location = New System.Drawing.Point(1140, 607)
        Me.txtAvgDailyProfit.Name = "txtAvgDailyProfit"
        Me.txtAvgDailyProfit.ReadOnly = True
        Me.txtAvgDailyProfit.Size = New System.Drawing.Size(86, 26)
        Me.txtAvgDailyProfit.TabIndex = 21
        Me.txtAvgDailyProfit.TabStop = False
        Me.txtAvgDailyProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkReceipt
        '
        Me.chkReceipt.AutoSize = True
        Me.chkReceipt.Checked = True
        Me.chkReceipt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReceipt.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkReceipt.Location = New System.Drawing.Point(343, 615)
        Me.chkReceipt.Name = "chkReceipt"
        Me.chkReceipt.Size = New System.Drawing.Size(63, 17)
        Me.chkReceipt.TabIndex = 22
        Me.chkReceipt.Text = "Receipt"
        Me.chkReceipt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkReceipt.UseVisualStyleBackColor = True
        '
        'chkALL
        '
        Me.chkALL.AutoSize = True
        Me.chkALL.Checked = True
        Me.chkALL.Location = New System.Drawing.Point(1058, 34)
        Me.chkALL.Name = "chkALL"
        Me.chkALL.Size = New System.Drawing.Size(44, 17)
        Me.chkALL.TabIndex = 11
        Me.chkALL.TabStop = True
        Me.chkALL.Text = "ALL"
        Me.chkALL.UseVisualStyleBackColor = True
        '
        'chkEstimates
        '
        Me.chkEstimates.AutoSize = True
        Me.chkEstimates.Location = New System.Drawing.Point(1058, 68)
        Me.chkEstimates.Name = "chkEstimates"
        Me.chkEstimates.Size = New System.Drawing.Size(65, 17)
        Me.chkEstimates.TabIndex = 13
        Me.chkEstimates.Text = "Estimate"
        Me.chkEstimates.UseVisualStyleBackColor = True
        '
        'chkInvoices
        '
        Me.chkInvoices.AutoSize = True
        Me.chkInvoices.Location = New System.Drawing.Point(1058, 51)
        Me.chkInvoices.Name = "chkInvoices"
        Me.chkInvoices.Size = New System.Drawing.Size(65, 17)
        Me.chkInvoices.TabIndex = 12
        Me.chkInvoices.Text = "Invoices"
        Me.chkInvoices.UseVisualStyleBackColor = True
        '
        'chkSMS
        '
        Me.chkSMS.AutoSize = True
        Me.chkSMS.Location = New System.Drawing.Point(343, 628)
        Me.chkSMS.Name = "chkSMS"
        Me.chkSMS.Size = New System.Drawing.Size(49, 17)
        Me.chkSMS.TabIndex = 23
        Me.chkSMS.Text = "SMS"
        Me.chkSMS.UseVisualStyleBackColor = True
        Me.chkSMS.Visible = False
        '
        'txtSMServer
        '
        Me.txtSMServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtSMServer.Location = New System.Drawing.Point(294, 656)
        Me.txtSMServer.Name = "txtSMServer"
        Me.txtSMServer.Size = New System.Drawing.Size(43, 20)
        Me.txtSMServer.TabIndex = 56
        Me.txtSMServer.Text = "1.125"
        Me.txtSMServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label45.Location = New System.Drawing.Point(292, 640)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(44, 13)
        Me.Label45.TabIndex = 55
        Me.Label45.Text = "Server"
        '
        'btnSMS
        '
        Me.btnSMS.BackgroundImage = Global.Invoice.My.Resources.Resources.SMS1
        Me.btnSMS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSMS.Location = New System.Drawing.Point(343, 642)
        Me.btnSMS.Name = "btnSMS"
        Me.btnSMS.Size = New System.Drawing.Size(43, 38)
        Me.btnSMS.TabIndex = 54
        Me.btnSMS.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Invoice.My.Resources.Resources.WA
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Location = New System.Drawing.Point(386, 640)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(44, 38)
        Me.Button2.TabIndex = 25
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(432, 639)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(47, 40)
        Me.Button1.TabIndex = 24
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(530, 641)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 57
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(244, 640)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Delay"
        '
        'txtDelay
        '
        Me.txtDelay.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDelay.Location = New System.Drawing.Point(246, 654)
        Me.txtDelay.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDelay.Name = "txtDelay"
        Me.txtDelay.Size = New System.Drawing.Size(38, 23)
        Me.txtDelay.TabIndex = 58
        Me.txtDelay.TabStop = False
        Me.txtDelay.Text = "5"
        Me.txtDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblcustomerName
        '
        Me.lblcustomerName.AutoSize = True
        Me.lblcustomerName.Location = New System.Drawing.Point(34, 589)
        Me.lblcustomerName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblcustomerName.Name = "lblcustomerName"
        Me.lblcustomerName.Size = New System.Drawing.Size(0, 13)
        Me.lblcustomerName.TabIndex = 59
        '
        'txtTotalReceipt
        '
        Me.txtTotalReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotalReceipt.Location = New System.Drawing.Point(890, 607)
        Me.txtTotalReceipt.Name = "txtTotalReceipt"
        Me.txtTotalReceipt.Size = New System.Drawing.Size(68, 26)
        Me.txtTotalReceipt.TabIndex = 60
        Me.txtTotalReceipt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.Location = New System.Drawing.Point(875, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 18)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "User"
        '
        'cmbUser
        '
        Me.cmbUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmbUser.FormattingEnabled = True
        Me.cmbUser.Location = New System.Drawing.Point(923, 44)
        Me.cmbUser.Name = "cmbUser"
        Me.cmbUser.Size = New System.Drawing.Size(123, 28)
        Me.cmbUser.TabIndex = 61
        '
        'frmInvoiceList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(1473, 680)
        Me.Controls.Add(Me.cmbUser)
        Me.Controls.Add(Me.txtTotalReceipt)
        Me.Controls.Add(Me.lblcustomerName)
        Me.Controls.Add(Me.txtDelay)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.txtSMServer)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.btnSMS)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chkSMS)
        Me.Controls.Add(Me.chkInvoices)
        Me.Controls.Add(Me.chkEstimates)
        Me.Controls.Add(Me.chkALL)
        Me.Controls.Add(Me.chkReceipt)
        Me.Controls.Add(Me.txtAvgDailyProfit)
        Me.Controls.Add(Me.lblMonthlyTotals)
        Me.Controls.Add(Me.lblTotals)
        Me.Controls.Add(Me.txtMonthlyProfitP)
        Me.Controls.Add(Me.txtMonthlyProfitTotal)
        Me.Controls.Add(Me.txtMonthlyFreightTotal)
        Me.Controls.Add(Me.txtMonthlyEstimatedTotal)
        Me.Controls.Add(Me.txtMonthlyTotal)
        Me.Controls.Add(Me.lblDoc)
        Me.Controls.Add(Me.txtProfitP)
        Me.Controls.Add(Me.txtTotalProfit)
        Me.Controls.Add(Me.txtFreightTotal)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.btnPrintSelected)
        Me.Controls.Add(Me.btnExportSelected)
        Me.Controls.Add(Me.btnListPreview)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.DGVList)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCustomer)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtRoute)
        Me.Controls.Add(Me.DTPEnd)
        Me.Controls.Add(Me.DTPStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmInvoiceList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmInvoiceList"
        CType(Me.DGVList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DTPStart As DateTimePicker
    Friend WithEvents txtRoute As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnPrint As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents btnExportSelected As Button
    Friend WithEvents btnPrintSelected As Button
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents DTPEnd As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents DGVList As DataGridView
    Friend WithEvents lblDoc As Label
    Friend WithEvents txtFreightTotal As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents btnListPreview As Button
    Friend WithEvents txtTotalProfit As TextBox
    Friend WithEvents txtProfitP As TextBox
    Friend WithEvents txtMonthlyProfitP As TextBox
    Friend WithEvents txtMonthlyProfitTotal As TextBox
    Friend WithEvents txtMonthlyFreightTotal As TextBox
    Friend WithEvents txtMonthlyTotal As TextBox
    Friend WithEvents lblTotals As Label
    Friend WithEvents lblMonthlyTotals As Label
    Friend WithEvents txtMonthlyEstimatedTotal As TextBox
    Friend WithEvents txtAvgDailyProfit As TextBox
    Friend WithEvents chkReceipt As CheckBox
    Friend WithEvents chkALL As RadioButton
    Friend WithEvents chkEstimates As RadioButton
    Friend WithEvents chkInvoices As RadioButton
    Friend WithEvents chkSMS As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btnSMS As Button
    Friend WithEvents txtSMServer As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDelay As TextBox
    Friend WithEvents lblcustomerName As Label
    Friend WithEvents txtTotalReceipt As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbUser As ComboBox
    Friend WithEvents ColNumber As DataGridViewTextBoxColumn
    Friend WithEvents ColDate As DataGridViewTextBoxColumn
    Friend WithEvents ColDoc As DataGridViewTextBoxColumn
    Friend WithEvents ColCustomer As DataGridViewTextBoxColumn
    Friend WithEvents colDesc As DataGridViewTextBoxColumn
    Friend WithEvents colRoute As DataGridViewTextBoxColumn
    Friend WithEvents colGoods As DataGridViewTextBoxColumn
    Friend WithEvents ColFreight As DataGridViewTextBoxColumn
    Friend WithEvents ColAmount As DataGridViewTextBoxColumn
    Friend WithEvents colReceived As DataGridViewTextBoxColumn
    Friend WithEvents colProfitP As DataGridViewTextBoxColumn
    Friend WithEvents colGProfit As DataGridViewTextBoxColumn
    Friend WithEvents colRemarks As DataGridViewTextBoxColumn
    Friend WithEvents colRDate As DataGridViewTextBoxColumn
    Friend WithEvents colOcell As DataGridViewTextBoxColumn
    Friend WithEvents ColPB As DataGridViewTextBoxColumn
    Friend WithEvents ColACID As DataGridViewTextBoxColumn
    Friend WithEvents colUrduName As DataGridViewTextBoxColumn
End Class

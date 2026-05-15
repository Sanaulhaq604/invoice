<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PeriodicReports
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
        Me.lblStart = New System.Windows.Forms.Label()
        Me.txtDays = New System.Windows.Forms.TextBox()
        Me.txtRoute = New System.Windows.Forms.TextBox()
        Me.cmbSPO = New System.Windows.Forms.ComboBox()
        Me.cmbLocation = New System.Windows.Forms.ComboBox()
        Me.rdNoEntry = New System.Windows.Forms.RadioButton()
        Me.rdEntry = New System.Windows.Forms.RadioButton()
        Me.rdALL = New System.Windows.Forms.RadioButton()
        Me.cmbMain = New System.Windows.Forms.ComboBox()
        Me.chkSummary = New System.Windows.Forms.CheckBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.chkALL = New System.Windows.Forms.CheckBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.lblDays = New System.Windows.Forms.Label()
        Me.lblSPO = New System.Windows.Forms.Label()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbOtherSelection = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbCustomer = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCustomerID = New System.Windows.Forms.TextBox()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.lblRoute = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gpProduct = New System.Windows.Forms.GroupBox()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPRID = New System.Windows.Forms.TextBox()
        Me.txtCompany = New System.Windows.Forms.TextBox()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbPeriod = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.rd6Months = New System.Windows.Forms.RadioButton()
        Me.rdCurrent = New System.Windows.Forms.RadioButton()
        Me.rd30Days = New System.Windows.Forms.RadioButton()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.txtReportName = New System.Windows.Forms.TextBox()
        Me.lblReportName = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblDoc = New System.Windows.Forms.Label()
        Me.chkDecreaseBalance = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.gbOtherSelection.SuspendLayout()
        Me.gbCustomer.SuspendLayout()
        Me.gpProduct.SuspendLayout()
        Me.gbPeriod.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblStart.Location = New System.Drawing.Point(12, 22)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(40, 17)
        Me.lblStart.TabIndex = 0
        Me.lblStart.Text = "From"
        '
        'txtDays
        '
        Me.txtDays.Enabled = False
        Me.txtDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDays.Location = New System.Drawing.Point(123, 201)
        Me.txtDays.Name = "txtDays"
        Me.txtDays.Size = New System.Drawing.Size(41, 23)
        Me.txtDays.TabIndex = 13
        Me.txtDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRoute
        '
        Me.txtRoute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRoute.Enabled = False
        Me.txtRoute.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtRoute.Location = New System.Drawing.Point(123, 172)
        Me.txtRoute.Name = "txtRoute"
        Me.txtRoute.Size = New System.Drawing.Size(177, 23)
        Me.txtRoute.TabIndex = 11
        '
        'cmbSPO
        '
        Me.cmbSPO.AutoCompleteCustomSource.AddRange(New String() {"DANISH", "SALMAN", "ARIF", "ZESHAN", "HAMZA", "MR. SAEED", "FAKHAR"})
        Me.cmbSPO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSPO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSPO.Enabled = False
        Me.cmbSPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmbSPO.FormattingEnabled = True
        Me.cmbSPO.Items.AddRange(New Object() {"ARIF", "DANISH", "FAKHAR", "HAMZA", "MR. SAEED", "SALMAN", "ZESHAN"})
        Me.cmbSPO.Location = New System.Drawing.Point(123, 54)
        Me.cmbSPO.Name = "cmbSPO"
        Me.cmbSPO.Size = New System.Drawing.Size(177, 24)
        Me.cmbSPO.Sorted = True
        Me.cmbSPO.TabIndex = 3
        '
        'cmbLocation
        '
        Me.cmbLocation.AutoCompleteCustomSource.AddRange(New String() {"DANISH", "SALMAN", "ARIF", "ZESHAN", "HAMZA", "MR. SAEED", "FAKHAR"})
        Me.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLocation.Enabled = False
        Me.cmbLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.Items.AddRange(New Object() {"DANISH", "SALMAN", "ARIF", "ZESHAN", "HAMZA", "MR. SAEED", "FAKHAR", "KARVAN", "SUZUKI"})
        Me.cmbLocation.Location = New System.Drawing.Point(123, 142)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(177, 24)
        Me.cmbLocation.TabIndex = 9
        '
        'rdNoEntry
        '
        Me.rdNoEntry.Enabled = False
        Me.rdNoEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdNoEntry.Location = New System.Drawing.Point(11, 123)
        Me.rdNoEntry.Name = "rdNoEntry"
        Me.rdNoEntry.Size = New System.Drawing.Size(217, 20)
        Me.rdNoEntry.TabIndex = 4
        Me.rdNoEntry.Text = "Accounts WithOut Entries"
        Me.rdNoEntry.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.rdNoEntry.UseVisualStyleBackColor = True
        '
        'rdEntry
        '
        Me.rdEntry.Enabled = False
        Me.rdEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdEntry.Location = New System.Drawing.Point(11, 101)
        Me.rdEntry.Name = "rdEntry"
        Me.rdEntry.Size = New System.Drawing.Size(189, 20)
        Me.rdEntry.TabIndex = 3
        Me.rdEntry.Text = "Accounts with Entries"
        Me.rdEntry.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.rdEntry.UseVisualStyleBackColor = True
        '
        'rdALL
        '
        Me.rdALL.Checked = True
        Me.rdALL.Enabled = False
        Me.rdALL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdALL.Location = New System.Drawing.Point(11, 79)
        Me.rdALL.Name = "rdALL"
        Me.rdALL.Size = New System.Drawing.Size(174, 20)
        Me.rdALL.TabIndex = 2
        Me.rdALL.TabStop = True
        Me.rdALL.Text = "All Accounts"
        Me.rdALL.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.rdALL.UseVisualStyleBackColor = True
        '
        'cmbMain
        '
        Me.cmbMain.DisplayMember = "Trade Creditors"
        Me.cmbMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMain.Enabled = False
        Me.cmbMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmbMain.FormattingEnabled = True
        Me.cmbMain.Items.AddRange(New Object() {"ADMIN & GENERAL EXPENSE", "CASH AND BANK BALANCES", "TRADE CREDITORS", "TRADE DEBTORS", "STAFF"})
        Me.cmbMain.Location = New System.Drawing.Point(123, 24)
        Me.cmbMain.Name = "cmbMain"
        Me.cmbMain.Size = New System.Drawing.Size(177, 24)
        Me.cmbMain.TabIndex = 1
        Me.cmbMain.ValueMember = "1"
        '
        'chkSummary
        '
        Me.chkSummary.AutoSize = True
        Me.chkSummary.Enabled = False
        Me.chkSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkSummary.Location = New System.Drawing.Point(10, 23)
        Me.chkSummary.Name = "chkSummary"
        Me.chkSummary.Size = New System.Drawing.Size(119, 21)
        Me.chkSummary.TabIndex = 0
        Me.chkSummary.Text = "Only Summary"
        Me.chkSummary.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExport.Location = New System.Drawing.Point(127, 632)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(104, 37)
        Me.btnExport.TabIndex = 3
        Me.btnExport.Text = "E&xport"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'chkALL
        '
        Me.chkALL.AutoSize = True
        Me.chkALL.Checked = True
        Me.chkALL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkALL.Enabled = False
        Me.chkALL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkALL.Location = New System.Drawing.Point(10, 43)
        Me.chkALL.Name = "chkALL"
        Me.chkALL.Size = New System.Drawing.Size(126, 21)
        Me.chkALL.TabIndex = 1
        Me.chkALL.Text = "Detailed Report"
        Me.chkALL.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnClose.Location = New System.Drawing.Point(242, 632)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(104, 56)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(11, 632)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(104, 56)
        Me.btnGenerate.TabIndex = 2
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'dtpEnd
        '
        Me.dtpEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEnd.Location = New System.Drawing.Point(203, 19)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(99, 23)
        Me.dtpEnd.TabIndex = 3
        '
        'lblDays
        '
        Me.lblDays.AutoSize = True
        Me.lblDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDays.Location = New System.Drawing.Point(8, 204)
        Me.lblDays.Name = "lblDays"
        Me.lblDays.Size = New System.Drawing.Size(40, 17)
        Me.lblDays.TabIndex = 12
        Me.lblDays.Text = "Days"
        '
        'lblSPO
        '
        Me.lblSPO.AutoSize = True
        Me.lblSPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblSPO.Location = New System.Drawing.Point(8, 58)
        Me.lblSPO.Name = "lblSPO"
        Me.lblSPO.Size = New System.Drawing.Size(78, 17)
        Me.lblSPO.TabIndex = 2
        Me.lblSPO.Text = "SPO Name"
        '
        'dtpStart
        '
        Me.dtpStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStart.Location = New System.Drawing.Point(56, 19)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(100, 23)
        Me.dtpStart.TabIndex = 1
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.DisplayStatusBar = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(353, 83)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1048, 597)
        Me.CrystalReportViewer1.TabIndex = 5
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.gbOtherSelection)
        Me.Panel1.Controls.Add(Me.gbCustomer)
        Me.Panel1.Controls.Add(Me.gpProduct)
        Me.Panel1.Location = New System.Drawing.Point(13, 157)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(333, 418)
        Me.Panel1.TabIndex = 1
        '
        'gbOtherSelection
        '
        Me.gbOtherSelection.Controls.Add(Me.chkDecreaseBalance)
        Me.gbOtherSelection.Controls.Add(Me.Label8)
        Me.gbOtherSelection.Controls.Add(Me.rdNoEntry)
        Me.gbOtherSelection.Controls.Add(Me.chkSummary)
        Me.gbOtherSelection.Controls.Add(Me.chkALL)
        Me.gbOtherSelection.Controls.Add(Me.rdEntry)
        Me.gbOtherSelection.Controls.Add(Me.rdALL)
        Me.gbOtherSelection.Location = New System.Drawing.Point(3, 405)
        Me.gbOtherSelection.Margin = New System.Windows.Forms.Padding(2)
        Me.gbOtherSelection.Name = "gbOtherSelection"
        Me.gbOtherSelection.Padding = New System.Windows.Forms.Padding(2)
        Me.gbOtherSelection.Size = New System.Drawing.Size(303, 177)
        Me.gbOtherSelection.TabIndex = 2
        Me.gbOtherSelection.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label8.Location = New System.Drawing.Point(19, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(179, 17)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Other Selection Criteria"
        '
        'gbCustomer
        '
        Me.gbCustomer.Controls.Add(Me.Label7)
        Me.gbCustomer.Controls.Add(Me.txtCustomerID)
        Me.gbCustomer.Controls.Add(Me.txtCustomerName)
        Me.gbCustomer.Controls.Add(Me.txtDays)
        Me.gbCustomer.Controls.Add(Me.cmbLocation)
        Me.gbCustomer.Controls.Add(Me.lblDays)
        Me.gbCustomer.Controls.Add(Me.txtRoute)
        Me.gbCustomer.Controls.Add(Me.cmbSPO)
        Me.gbCustomer.Controls.Add(Me.cmbMain)
        Me.gbCustomer.Controls.Add(Me.lblRoute)
        Me.gbCustomer.Controls.Add(Me.Label2)
        Me.gbCustomer.Controls.Add(Me.Label1)
        Me.gbCustomer.Controls.Add(Me.Label9)
        Me.gbCustomer.Controls.Add(Me.Label5)
        Me.gbCustomer.Controls.Add(Me.lblSPO)
        Me.gbCustomer.Location = New System.Drawing.Point(3, 6)
        Me.gbCustomer.Name = "gbCustomer"
        Me.gbCustomer.Size = New System.Drawing.Size(303, 237)
        Me.gbCustomer.TabIndex = 0
        Me.gbCustomer.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label7.Location = New System.Drawing.Point(19, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(206, 17)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Customer Selection Criteria"
        '
        'txtCustomerID
        '
        Me.txtCustomerID.Enabled = False
        Me.txtCustomerID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCustomerID.Location = New System.Drawing.Point(123, 84)
        Me.txtCustomerID.Name = "txtCustomerID"
        Me.txtCustomerID.Size = New System.Drawing.Size(55, 23)
        Me.txtCustomerID.TabIndex = 5
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BackColor = System.Drawing.Color.Yellow
        Me.txtCustomerName.Enabled = False
        Me.txtCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCustomerName.Location = New System.Drawing.Point(123, 113)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.ReadOnly = True
        Me.txtCustomerName.Size = New System.Drawing.Size(177, 23)
        Me.txtCustomerName.TabIndex = 7
        Me.txtCustomerName.TabStop = False
        '
        'lblRoute
        '
        Me.lblRoute.AutoSize = True
        Me.lblRoute.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblRoute.Location = New System.Drawing.Point(8, 175)
        Me.lblRoute.Name = "lblRoute"
        Me.lblRoute.Size = New System.Drawing.Size(46, 17)
        Me.lblRoute.TabIndex = 10
        Me.lblRoute.Text = "Route"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Location"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Main"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 19)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Customer ID"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 21)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Customer Name"
        '
        'gpProduct
        '
        Me.gpProduct.Controls.Add(Me.txtCategory)
        Me.gpProduct.Controls.Add(Me.Label10)
        Me.gpProduct.Controls.Add(Me.txtPRID)
        Me.gpProduct.Controls.Add(Me.txtCompany)
        Me.gpProduct.Controls.Add(Me.txtProductName)
        Me.gpProduct.Controls.Add(Me.Label6)
        Me.gpProduct.Controls.Add(Me.Label4)
        Me.gpProduct.Controls.Add(Me.Label12)
        Me.gpProduct.Controls.Add(Me.Label3)
        Me.gpProduct.Location = New System.Drawing.Point(3, 254)
        Me.gpProduct.Margin = New System.Windows.Forms.Padding(2)
        Me.gpProduct.Name = "gpProduct"
        Me.gpProduct.Padding = New System.Windows.Forms.Padding(2)
        Me.gpProduct.Size = New System.Drawing.Size(303, 136)
        Me.gpProduct.TabIndex = 1
        Me.gpProduct.TabStop = False
        '
        'txtCategory
        '
        Me.txtCategory.Enabled = False
        Me.txtCategory.Location = New System.Drawing.Point(123, 112)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(100, 20)
        Me.txtCategory.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label10.Location = New System.Drawing.Point(19, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(194, 17)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Product Selection Criteria"
        '
        'txtPRID
        '
        Me.txtPRID.Enabled = False
        Me.txtPRID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtPRID.Location = New System.Drawing.Point(123, 53)
        Me.txtPRID.Name = "txtPRID"
        Me.txtPRID.Size = New System.Drawing.Size(108, 23)
        Me.txtPRID.TabIndex = 3
        '
        'txtCompany
        '
        Me.txtCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCompany.Enabled = False
        Me.txtCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCompany.Location = New System.Drawing.Point(123, 24)
        Me.txtCompany.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(171, 23)
        Me.txtCompany.TabIndex = 1
        '
        'txtProductName
        '
        Me.txtProductName.BackColor = System.Drawing.Color.Yellow
        Me.txtProductName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductName.Enabled = False
        Me.txtProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtProductName.Location = New System.Drawing.Point(123, 83)
        Me.txtProductName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.ReadOnly = True
        Me.txtProductName.Size = New System.Drawing.Size(171, 23)
        Me.txtProductName.TabIndex = 5
        Me.txtProductName.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 17)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Product ID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Company Name"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 117)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 17)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Model"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Product Name"
        '
        'gbPeriod
        '
        Me.gbPeriod.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPeriod.Controls.Add(Me.Label11)
        Me.gbPeriod.Controls.Add(Me.RadioButton1)
        Me.gbPeriod.Controls.Add(Me.rd6Months)
        Me.gbPeriod.Controls.Add(Me.rdCurrent)
        Me.gbPeriod.Controls.Add(Me.rd30Days)
        Me.gbPeriod.Controls.Add(Me.lblEnd)
        Me.gbPeriod.Controls.Add(Me.lblStart)
        Me.gbPeriod.Controls.Add(Me.dtpStart)
        Me.gbPeriod.Controls.Add(Me.dtpEnd)
        Me.gbPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.gbPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.gbPeriod.Location = New System.Drawing.Point(13, 84)
        Me.gbPeriod.Name = "gbPeriod"
        Me.gbPeriod.Size = New System.Drawing.Size(328, 65)
        Me.gbPeriod.TabIndex = 0
        Me.gbPeriod.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label11.Location = New System.Drawing.Point(22, -4)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(185, 17)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Period Selection Criteria"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(276, 45)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(47, 17)
        Me.RadioButton1.TabIndex = 7
        Me.RadioButton1.Text = "ALL"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rd6Months
        '
        Me.rd6Months.AutoSize = True
        Me.rd6Months.Location = New System.Drawing.Point(187, 45)
        Me.rd6Months.Name = "rd6Months"
        Me.rd6Months.Size = New System.Drawing.Size(105, 17)
        Me.rd6Months.TabIndex = 6
        Me.rd6Months.Text = "Last 6 Months"
        Me.rd6Months.UseVisualStyleBackColor = True
        '
        'rdCurrent
        '
        Me.rdCurrent.AutoSize = True
        Me.rdCurrent.Location = New System.Drawing.Point(89, 45)
        Me.rdCurrent.Name = "rdCurrent"
        Me.rdCurrent.Size = New System.Drawing.Size(105, 17)
        Me.rdCurrent.TabIndex = 5
        Me.rdCurrent.Text = "Current Month"
        Me.rdCurrent.UseVisualStyleBackColor = True
        '
        'rd30Days
        '
        Me.rd30Days.AutoSize = True
        Me.rd30Days.Checked = True
        Me.rd30Days.Location = New System.Drawing.Point(3, 45)
        Me.rd30Days.Name = "rd30Days"
        Me.rd30Days.Size = New System.Drawing.Size(99, 17)
        Me.rd30Days.TabIndex = 4
        Me.rd30Days.TabStop = True
        Me.rd30Days.Text = "Last 30 Days"
        Me.rd30Days.UseVisualStyleBackColor = True
        '
        'lblEnd
        '
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblEnd.Location = New System.Drawing.Point(174, 22)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(25, 17)
        Me.lblEnd.TabIndex = 2
        Me.lblEnd.Text = "To"
        '
        'txtReportName
        '
        Me.txtReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtReportName.Location = New System.Drawing.Point(13, 579)
        Me.txtReportName.Multiline = True
        Me.txtReportName.Name = "txtReportName"
        Me.txtReportName.ReadOnly = True
        Me.txtReportName.Size = New System.Drawing.Size(334, 52)
        Me.txtReportName.TabIndex = 5
        Me.txtReportName.TabStop = False
        '
        'lblReportName
        '
        Me.lblReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblReportName.Location = New System.Drawing.Point(2, 44)
        Me.lblReportName.Name = "lblReportName"
        Me.lblReportName.Size = New System.Drawing.Size(1411, 38)
        Me.lblReportName.TabIndex = 6
        Me.lblReportName.Text = "REP"
        Me.lblReportName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(127, 671)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 22)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Route All Reports"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblDoc
        '
        Me.lblDoc.BackColor = System.Drawing.Color.LightBlue
        Me.lblDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDoc.Location = New System.Drawing.Point(4, 2)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(1410, 40)
        Me.lblDoc.TabIndex = 8
        Me.lblDoc.Text = "Doc"
        Me.lblDoc.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'chkDecreaseBalance
        '
        Me.chkDecreaseBalance.AutoSize = True
        Me.chkDecreaseBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkDecreaseBalance.Location = New System.Drawing.Point(11, 150)
        Me.chkDecreaseBalance.Name = "chkDecreaseBalance"
        Me.chkDecreaseBalance.Size = New System.Drawing.Size(192, 21)
        Me.chkDecreaseBalance.TabIndex = 12
        Me.chkDecreaseBalance.Text = "Include Decrease Balance"
        Me.chkDecreaseBalance.UseVisualStyleBackColor = True
        '
        'PeriodicReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1417, 701)
        Me.Controls.Add(Me.lblDoc)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblReportName)
        Me.Controls.Add(Me.txtReportName)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.gbPeriod)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PeriodicReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PeriodicReports"
        Me.Panel1.ResumeLayout(False)
        Me.gbOtherSelection.ResumeLayout(False)
        Me.gbOtherSelection.PerformLayout()
        Me.gbCustomer.ResumeLayout(False)
        Me.gbCustomer.PerformLayout()
        Me.gpProduct.ResumeLayout(False)
        Me.gpProduct.PerformLayout()
        Me.gbPeriod.ResumeLayout(False)
        Me.gbPeriod.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblStart As Label
    Friend WithEvents dtpEnd As DateTimePicker
    Friend WithEvents dtpStart As DateTimePicker
    Friend WithEvents btnGenerate As Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnClose As Button
    Friend WithEvents cmbSPO As ComboBox
    Friend WithEvents lblSPO As Label
    Friend WithEvents txtRoute As TextBox
    Friend WithEvents txtDays As TextBox
    Friend WithEvents lblDays As Label
    Friend WithEvents chkALL As CheckBox
    Friend WithEvents btnExport As Button
    Friend WithEvents chkSummary As CheckBox
    Friend WithEvents cmbMain As ComboBox
    Friend WithEvents rdNoEntry As RadioButton
    Friend WithEvents rdEntry As RadioButton
    Friend WithEvents rdALL As RadioButton
    Friend WithEvents cmbLocation As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents gbCustomer As GroupBox
    Friend WithEvents lblRoute As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents gbPeriod As GroupBox
    Friend WithEvents lblEnd As Label
    Friend WithEvents gpProduct As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCompany As TextBox
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents gbOtherSelection As GroupBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents rd6Months As RadioButton
    Friend WithEvents rdCurrent As RadioButton
    Friend WithEvents rd30Days As RadioButton
    Friend WithEvents txtReportName As TextBox
    Friend WithEvents lblReportName As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lblDoc As Label
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCustomerID As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPRID As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtCategory As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents chkDecreaseBalance As CheckBox
End Class

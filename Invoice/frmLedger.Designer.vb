<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLedger
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtAcID = New System.Windows.Forms.TextBox()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ctnExit = New System.Windows.Forms.Button()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.DtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDoc = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.txtTotalDebit = New System.Windows.Forms.TextBox()
        Me.txtTotalCredit = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtCustomerMobile2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.chkMTR = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDoc = New System.Windows.Forms.TextBox()
        Me.txtRoute = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDifference = New System.Windows.Forms.TextBox()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCredit = New System.Windows.Forms.TextBox()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rd30Days = New System.Windows.Forms.RadioButton()
        Me.rdCurrent = New System.Windows.Forms.RadioButton()
        Me.rd6Months = New System.Windows.Forms.RadioButton()
        Me.rdAll = New System.Windows.Forms.RadioButton()
        Me.rdAllEntries = New System.Windows.Forms.RadioButton()
        Me.rdNoMatch = New System.Windows.Forms.RadioButton()
        Me.rdOnlyMatch = New System.Windows.Forms.RadioButton()
        Me.lblDeal = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.rdTally = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNarration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDebit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtAcID
        '
        Me.txtAcID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtAcID.Location = New System.Drawing.Point(366, 38)
        Me.txtAcID.Name = "txtAcID"
        Me.txtAcID.Size = New System.Drawing.Size(58, 29)
        Me.txtAcID.TabIndex = 5
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BackColor = System.Drawing.Color.Yellow
        Me.txtCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCustomerName.Location = New System.Drawing.Point(366, 68)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.ReadOnly = True
        Me.txtCustomerName.Size = New System.Drawing.Size(419, 29)
        Me.txtCustomerName.TabIndex = 1
        Me.txtCustomerName.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Starting Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "&Ending Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(264, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Account Title"
        '
        'ctnExit
        '
        Me.ctnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ctnExit.Location = New System.Drawing.Point(654, 643)
        Me.ctnExit.Name = "ctnExit"
        Me.ctnExit.Size = New System.Drawing.Size(86, 45)
        Me.ctnExit.TabIndex = 15
        Me.ctnExit.TabStop = False
        Me.ctnExit.Text = "&Close"
        Me.ctnExit.UseVisualStyleBackColor = True
        '
        'dtpStart
        '
        Me.dtpStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStart.Location = New System.Drawing.Point(123, 41)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(143, 29)
        Me.dtpStart.TabIndex = 1
        '
        'DtpEnd
        '
        Me.DtpEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpEnd.Location = New System.Drawing.Point(123, 71)
        Me.DtpEnd.Name = "DtpEnd"
        Me.DtpEnd.Size = New System.Drawing.Size(143, 29)
        Me.DtpEnd.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(264, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Account &ID"
        '
        'lblDoc
        '
        Me.lblDoc.BackColor = System.Drawing.Color.MediumBlue
        Me.lblDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDoc.ForeColor = System.Drawing.Color.White
        Me.lblDoc.Location = New System.Drawing.Point(-14, -2)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(1350, 35)
        Me.lblDoc.TabIndex = 7
        Me.lblDoc.Text = "Ledger"
        Me.lblDoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(474, 643)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(86, 45)
        Me.btnExport.TabIndex = 13
        Me.btnExport.Text = "E&xport PDF"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'txtTotalDebit
        '
        Me.txtTotalDebit.BackColor = System.Drawing.Color.White
        Me.txtTotalDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotalDebit.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDebit.Location = New System.Drawing.Point(847, 634)
        Me.txtTotalDebit.Name = "txtTotalDebit"
        Me.txtTotalDebit.ReadOnly = True
        Me.txtTotalDebit.Size = New System.Drawing.Size(122, 26)
        Me.txtTotalDebit.TabIndex = 0
        Me.txtTotalDebit.TabStop = False
        Me.txtTotalDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalCredit
        '
        Me.txtTotalCredit.BackColor = System.Drawing.Color.White
        Me.txtTotalCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotalCredit.ForeColor = System.Drawing.Color.Black
        Me.txtTotalCredit.Location = New System.Drawing.Point(968, 634)
        Me.txtTotalCredit.Name = "txtTotalCredit"
        Me.txtTotalCredit.ReadOnly = True
        Me.txtTotalCredit.Size = New System.Drawing.Size(120, 26)
        Me.txtTotalCredit.TabIndex = 0
        Me.txtTotalCredit.TabStop = False
        Me.txtTotalCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(426, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "&Description"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(517, 37)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(268, 29)
        Me.txtDescription.TabIndex = 6
        '
        'txtCustomerMobile2
        '
        Me.txtCustomerMobile2.BackColor = System.Drawing.Color.Yellow
        Me.txtCustomerMobile2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCustomerMobile2.Location = New System.Drawing.Point(1164, 68)
        Me.txtCustomerMobile2.Mask = "0000 - 0000000"
        Me.txtCustomerMobile2.Name = "txtCustomerMobile2"
        Me.txtCustomerMobile2.Size = New System.Drawing.Size(134, 29)
        Me.txtCustomerMobile2.TabIndex = 10
        Me.txtCustomerMobile2.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.Location = New System.Drawing.Point(1100, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 20)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Contact"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(564, 643)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(86, 45)
        Me.btnPrint.TabIndex = 14
        Me.btnPrint.Text = "&Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeight = 40
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colDate, Me.colType, Me.colDoc, Me.colNarration, Me.colDebit, Me.colCredit, Me.colBalance, Me.Status})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.Location = New System.Drawing.Point(20, 129)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 45
        Me.DataGridView1.RowTemplate.Height = 32
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1280, 502)
        Me.DataGridView1.TabIndex = 12
        Me.DataGridView1.TabStop = False
        '
        'chkMTR
        '
        Me.chkMTR.AutoSize = True
        Me.chkMTR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkMTR.Location = New System.Drawing.Point(1129, 40)
        Me.chkMTR.Name = "chkMTR"
        Me.chkMTR.Size = New System.Drawing.Size(144, 24)
        Me.chkMTR.TabIndex = 11
        Me.chkMTR.Text = "&Monthly Totals"
        Me.chkMTR.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(920, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 20)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "&No."
        '
        'txtDoc
        '
        Me.txtDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDoc.Location = New System.Drawing.Point(838, 38)
        Me.txtDoc.Name = "txtDoc"
        Me.txtDoc.Size = New System.Drawing.Size(82, 29)
        Me.txtDoc.TabIndex = 8
        '
        'txtRoute
        '
        Me.txtRoute.BackColor = System.Drawing.Color.Yellow
        Me.txtRoute.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtRoute.Location = New System.Drawing.Point(838, 69)
        Me.txtRoute.Name = "txtRoute"
        Me.txtRoute.Size = New System.Drawing.Size(185, 26)
        Me.txtRoute.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.Location = New System.Drawing.Point(782, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 20)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "&Route"
        '
        'txtDifference
        '
        Me.txtDifference.BackColor = System.Drawing.Color.White
        Me.txtDifference.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDifference.ForeColor = System.Drawing.Color.Black
        Me.txtDifference.Location = New System.Drawing.Point(908, 659)
        Me.txtDifference.Name = "txtDifference"
        Me.txtDifference.ReadOnly = True
        Me.txtDifference.Size = New System.Drawing.Size(120, 26)
        Me.txtDifference.TabIndex = 0
        Me.txtDifference.TabStop = False
        Me.txtDifference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBalance
        '
        Me.txtBalance.BackColor = System.Drawing.Color.White
        Me.txtBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtBalance.ForeColor = System.Drawing.Color.Black
        Me.txtBalance.Location = New System.Drawing.Point(1087, 634)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(135, 26)
        Me.txtBalance.TabIndex = 0
        Me.txtBalance.TabStop = False
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.Location = New System.Drawing.Point(793, 637)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 20)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Totals"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label10.Location = New System.Drawing.Point(754, 663)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(152, 20)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Increase / Decrease"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label11.Location = New System.Drawing.Point(782, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 20)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "&V.Type"
        '
        'txtNumber
        '
        Me.txtNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtNumber.Location = New System.Drawing.Point(949, 37)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(73, 29)
        Me.txtNumber.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label12.Location = New System.Drawing.Point(1046, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Credit"
        '
        'txtCredit
        '
        Me.txtCredit.Location = New System.Drawing.Point(1029, 50)
        Me.txtCredit.Name = "txtCredit"
        Me.txtCredit.Size = New System.Drawing.Size(76, 20)
        Me.txtCredit.TabIndex = 17
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(384, 643)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(86, 45)
        Me.btnExcel.TabIndex = 13
        Me.btnExcel.Text = "Export Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 663)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(295, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Press F5 to mark tally balance at any Selected row"
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Invoice.My.Resources.Resources.WA
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(316, 643)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(66, 45)
        Me.Button1.TabIndex = 19
        Me.Button1.UseVisualStyleBackColor = True
        '
        'rd30Days
        '
        Me.rd30Days.AutoSize = True
        Me.rd30Days.Location = New System.Drawing.Point(17, 104)
        Me.rd30Days.Name = "rd30Days"
        Me.rd30Days.Size = New System.Drawing.Size(87, 17)
        Me.rd30Days.TabIndex = 20
        Me.rd30Days.Text = "Last 30 Days"
        Me.rd30Days.UseVisualStyleBackColor = True
        '
        'rdCurrent
        '
        Me.rdCurrent.AutoSize = True
        Me.rdCurrent.Location = New System.Drawing.Point(102, 104)
        Me.rdCurrent.Name = "rdCurrent"
        Me.rdCurrent.Size = New System.Drawing.Size(92, 17)
        Me.rdCurrent.TabIndex = 20
        Me.rdCurrent.Text = "Current Month"
        Me.rdCurrent.UseVisualStyleBackColor = True
        '
        'rd6Months
        '
        Me.rd6Months.AutoSize = True
        Me.rd6Months.Location = New System.Drawing.Point(194, 104)
        Me.rd6Months.Name = "rd6Months"
        Me.rd6Months.Size = New System.Drawing.Size(69, 17)
        Me.rd6Months.TabIndex = 20
        Me.rd6Months.Text = "6 Months"
        Me.rd6Months.UseVisualStyleBackColor = True
        '
        'rdAll
        '
        Me.rdAll.AutoSize = True
        Me.rdAll.Location = New System.Drawing.Point(322, 104)
        Me.rdAll.Name = "rdAll"
        Me.rdAll.Size = New System.Drawing.Size(44, 17)
        Me.rdAll.TabIndex = 22
        Me.rdAll.Text = "ALL"
        Me.rdAll.UseVisualStyleBackColor = True
        '
        'rdAllEntries
        '
        Me.rdAllEntries.AutoSize = True
        Me.rdAllEntries.Checked = True
        Me.rdAllEntries.Location = New System.Drawing.Point(1023, 103)
        Me.rdAllEntries.Margin = New System.Windows.Forms.Padding(2)
        Me.rdAllEntries.Name = "rdAllEntries"
        Me.rdAllEntries.Size = New System.Drawing.Size(70, 17)
        Me.rdAllEntries.TabIndex = 21
        Me.rdAllEntries.TabStop = True
        Me.rdAllEntries.Text = "All entries"
        Me.rdAllEntries.UseVisualStyleBackColor = True
        '
        'rdNoMatch
        '
        Me.rdNoMatch.AutoSize = True
        Me.rdNoMatch.Location = New System.Drawing.Point(1090, 103)
        Me.rdNoMatch.Margin = New System.Windows.Forms.Padding(2)
        Me.rdNoMatch.Name = "rdNoMatch"
        Me.rdNoMatch.Size = New System.Drawing.Size(72, 17)
        Me.rdNoMatch.TabIndex = 21
        Me.rdNoMatch.Text = "No Match"
        Me.rdNoMatch.UseVisualStyleBackColor = True
        '
        'rdOnlyMatch
        '
        Me.rdOnlyMatch.AutoSize = True
        Me.rdOnlyMatch.Location = New System.Drawing.Point(1158, 103)
        Me.rdOnlyMatch.Margin = New System.Windows.Forms.Padding(2)
        Me.rdOnlyMatch.Name = "rdOnlyMatch"
        Me.rdOnlyMatch.Size = New System.Drawing.Size(79, 17)
        Me.rdOnlyMatch.TabIndex = 21
        Me.rdOnlyMatch.Text = "Only Match"
        Me.rdOnlyMatch.UseVisualStyleBackColor = True
        '
        'lblDeal
        '
        Me.lblDeal.BackColor = System.Drawing.Color.LightGreen
        Me.lblDeal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDeal.Location = New System.Drawing.Point(489, 100)
        Me.lblDeal.Name = "lblDeal"
        Me.lblDeal.Size = New System.Drawing.Size(531, 23)
        Me.lblDeal.TabIndex = 22
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.Color.LightGreen
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDate.Location = New System.Drawing.Point(367, 100)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(113, 23)
        Me.lblDate.TabIndex = 23
        '
        'rdTally
        '
        Me.rdTally.AutoSize = True
        Me.rdTally.Location = New System.Drawing.Point(264, 104)
        Me.rdTally.Name = "rdTally"
        Me.rdTally.Size = New System.Drawing.Size(58, 17)
        Me.rdTally.TabIndex = 21
        Me.rdTally.TabStop = True
        Me.rdTally.Text = "TALLY"
        Me.rdTally.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1232, 100)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 23)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "Clear Tally"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'colID
        '
        Me.colID.DataPropertyName = "id"
        Me.colID.HeaderText = "id"
        Me.colID.MinimumWidth = 6
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Visible = False
        Me.colID.Width = 125
        '
        'colDate
        '
        Me.colDate.DataPropertyName = "date"
        Me.colDate.HeaderText = "Date"
        Me.colDate.MinimumWidth = 6
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        '
        'colType
        '
        Me.colType.DataPropertyName = "type"
        Me.colType.HeaderText = "Voucher"
        Me.colType.MinimumWidth = 6
        Me.colType.Name = "colType"
        Me.colType.ReadOnly = True
        '
        'colDoc
        '
        Me.colDoc.DataPropertyName = "doc"
        Me.colDoc.HeaderText = "Number"
        Me.colDoc.MinimumWidth = 6
        Me.colDoc.Name = "colDoc"
        Me.colDoc.ReadOnly = True
        '
        'colNarration
        '
        Me.colNarration.DataPropertyName = "narration"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Jameel Noori Nastaleeq", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.colNarration.DefaultCellStyle = DataGridViewCellStyle2
        Me.colNarration.HeaderText = "Narration"
        Me.colNarration.MinimumWidth = 6
        Me.colNarration.Name = "colNarration"
        Me.colNarration.ReadOnly = True
        Me.colNarration.Width = 420
        '
        'colDebit
        '
        Me.colDebit.DataPropertyName = "debit"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "#,##.##"
        Me.colDebit.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDebit.HeaderText = "Debit"
        Me.colDebit.MinimumWidth = 6
        Me.colDebit.Name = "colDebit"
        Me.colDebit.ReadOnly = True
        Me.colDebit.Width = 120
        '
        'colCredit
        '
        Me.colCredit.DataPropertyName = "credit"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "#,###.##"
        Me.colCredit.DefaultCellStyle = DataGridViewCellStyle4
        Me.colCredit.HeaderText = "Credit"
        Me.colCredit.MinimumWidth = 6
        Me.colCredit.Name = "colCredit"
        Me.colCredit.ReadOnly = True
        Me.colCredit.Width = 120
        '
        'colBalance
        '
        Me.colBalance.DataPropertyName = "total"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        Me.colBalance.DefaultCellStyle = DataGridViewCellStyle5
        Me.colBalance.HeaderText = "Balance"
        Me.colBalance.MinimumWidth = 6
        Me.colBalance.Name = "colBalance"
        Me.colBalance.ReadOnly = True
        Me.colBalance.Width = 140
        '
        'Status
        '
        Me.Status.DataPropertyName = "status"
        Me.Status.HeaderText = "Status"
        Me.Status.MinimumWidth = 6
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Visible = False
        Me.Status.Width = 125
        '
        'frmLedger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ctnExit
        Me.ClientSize = New System.Drawing.Size(1313, 701)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.rdTally)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblDeal)
        Me.Controls.Add(Me.rdOnlyMatch)
        Me.Controls.Add(Me.rdNoMatch)
        Me.Controls.Add(Me.rdAllEntries)
        Me.Controls.Add(Me.rdAll)
        Me.Controls.Add(Me.rd6Months)
        Me.Controls.Add(Me.rdCurrent)
        Me.Controls.Add(Me.rd30Days)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtCredit)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.chkMTR)
        Me.Controls.Add(Me.txtCustomerMobile2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtBalance)
        Me.Controls.Add(Me.txtDifference)
        Me.Controls.Add(Me.txtTotalCredit)
        Me.Controls.Add(Me.txtTotalDebit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.lblDoc)
        Me.Controls.Add(Me.DtpEnd)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.ctnExit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCustomerName)
        Me.Controls.Add(Me.txtRoute)
        Me.Controls.Add(Me.txtDoc)
        Me.Controls.Add(Me.txtAcID)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmLedger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ledger"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAcID As TextBox
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ctnExit As Button
    Friend WithEvents dtpStart As DateTimePicker
    Friend WithEvents DtpEnd As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents lblDoc As Label
    Friend WithEvents btnExport As Button
    Friend WithEvents txtTotalDebit As TextBox
    Friend WithEvents txtTotalCredit As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtCustomerMobile2 As MaskedTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnPrint As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents chkMTR As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDoc As TextBox
    Friend WithEvents txtRoute As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtDifference As TextBox
    Friend WithEvents txtBalance As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtNumber As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCredit As TextBox
    Friend WithEvents btnExcel As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents rd30Days As RadioButton
    Friend WithEvents rdCurrent As RadioButton
    Friend WithEvents rd6Months As RadioButton
    Friend WithEvents rdAll As RadioButton
    Friend WithEvents rdAllEntries As RadioButton
    Friend WithEvents rdNoMatch As RadioButton
    Friend WithEvents rdOnlyMatch As RadioButton
    Friend WithEvents lblDeal As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents rdTally As RadioButton
    Friend WithEvents Button2 As Button
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents colType As DataGridViewTextBoxColumn
    Friend WithEvents colDoc As DataGridViewTextBoxColumn
    Friend WithEvents colNarration As DataGridViewTextBoxColumn
    Friend WithEvents colDebit As DataGridViewTextBoxColumn
    Friend WithEvents colCredit As DataGridViewTextBoxColumn
    Friend WithEvents colBalance As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
End Class

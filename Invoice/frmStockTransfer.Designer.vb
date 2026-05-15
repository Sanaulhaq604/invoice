<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockTransfer
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTP1 = New System.Windows.Forms.DateTimePicker()
        Me.txtPRID = New System.Windows.Forms.TextBox()
        Me.cmbTo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDocNum = New System.Windows.Forms.TextBox()
        Me.DGVStock = New System.Windows.Forms.DataGridView()
        Me.ColSr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colPSID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColProduct = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.cmbFrom = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProduct = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblDoc = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtQTY = New System.Windows.Forms.TextBox()
        Me.btnFrom = New System.Windows.Forms.Button()
        Me.btnTO = New System.Windows.Forms.Button()
        Me.btnAddSupply = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.rdFeedOrder = New System.Windows.Forms.RadioButton()
        Me.rdAlphabeticalOrder = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtVn = New System.Windows.Forms.TextBox()
        CType(Me.DGVStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'DTP1
        '
        Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP1.Location = New System.Drawing.Point(53, 38)
        Me.DTP1.Name = "DTP1"
        Me.DTP1.Size = New System.Drawing.Size(81, 20)
        Me.DTP1.TabIndex = 1
        '
        'txtPRID
        '
        Me.txtPRID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtPRID.Location = New System.Drawing.Point(270, 104)
        Me.txtPRID.Name = "txtPRID"
        Me.txtPRID.Size = New System.Drawing.Size(100, 23)
        Me.txtPRID.TabIndex = 11
        '
        'cmbTo
        '
        Me.cmbTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmbTo.FormattingEnabled = True
        Me.cmbTo.Location = New System.Drawing.Point(143, 104)
        Me.cmbTo.Name = "cmbTo"
        Me.cmbTo.Size = New System.Drawing.Size(121, 24)
        Me.cmbTo.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Number"
        '
        'txtDocNum
        '
        Me.txtDocNum.Location = New System.Drawing.Point(67, 63)
        Me.txtDocNum.Name = "txtDocNum"
        Me.txtDocNum.Size = New System.Drawing.Size(67, 20)
        Me.txtDocNum.TabIndex = 3
        Me.txtDocNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DGVStock
        '
        Me.DGVStock.AllowUserToAddRows = False
        Me.DGVStock.AllowUserToDeleteRows = False
        Me.DGVStock.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVStock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVStock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColSr, Me.colDelete, Me.colPSID, Me.colCode, Me.colPrid, Me.colDate, Me.colDoc, Me.colType, Me.ColFrom, Me.ColTo, Me.ColProduct, Me.ColQTY})
        Me.DGVStock.Location = New System.Drawing.Point(20, 133)
        Me.DGVStock.Name = "DGVStock"
        Me.DGVStock.ReadOnly = True
        Me.DGVStock.RowHeadersVisible = False
        Me.DGVStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVStock.Size = New System.Drawing.Size(878, 436)
        Me.DGVStock.TabIndex = 14
        '
        'ColSr
        '
        Me.ColSr.DataPropertyName = "rn"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColSr.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColSr.HeaderText = "Sr #"
        Me.ColSr.Name = "ColSr"
        Me.ColSr.ReadOnly = True
        Me.ColSr.Width = 60
        '
        'colDelete
        '
        Me.colDelete.HeaderText = "Delete"
        Me.colDelete.Name = "colDelete"
        Me.colDelete.ReadOnly = True
        Me.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDelete.Width = 80
        '
        'colPSID
        '
        Me.colPSID.DataPropertyName = "PSID"
        Me.colPSID.HeaderText = "PSID"
        Me.colPSID.Name = "colPSID"
        Me.colPSID.ReadOnly = True
        Me.colPSID.Visible = False
        '
        'colCode
        '
        Me.colCode.DataPropertyName = "Code"
        Me.colCode.HeaderText = "Code"
        Me.colCode.Name = "colCode"
        Me.colCode.ReadOnly = True
        Me.colCode.Visible = False
        '
        'colPrid
        '
        Me.colPrid.DataPropertyName = "PRID"
        Me.colPrid.HeaderText = "PRID"
        Me.colPrid.Name = "colPrid"
        Me.colPrid.ReadOnly = True
        Me.colPrid.Visible = False
        '
        'colDate
        '
        Me.colDate.DataPropertyName = "Date"
        Me.colDate.HeaderText = "Date"
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        Me.colDate.Visible = False
        '
        'colDoc
        '
        Me.colDoc.DataPropertyName = "Doc"
        Me.colDoc.HeaderText = "Doc"
        Me.colDoc.Name = "colDoc"
        Me.colDoc.ReadOnly = True
        Me.colDoc.Visible = False
        '
        'colType
        '
        Me.colType.DataPropertyName = "Type"
        Me.colType.HeaderText = "Type"
        Me.colType.Name = "colType"
        Me.colType.ReadOnly = True
        Me.colType.Visible = False
        '
        'ColFrom
        '
        Me.ColFrom.DataPropertyName = "Department"
        Me.ColFrom.HeaderText = "From"
        Me.ColFrom.Name = "ColFrom"
        Me.ColFrom.ReadOnly = True
        Me.ColFrom.Width = 120
        '
        'ColTo
        '
        Me.ColTo.DataPropertyName = "department2"
        Me.ColTo.HeaderText = "To"
        Me.ColTo.Name = "ColTo"
        Me.ColTo.ReadOnly = True
        Me.ColTo.Width = 120
        '
        'ColProduct
        '
        Me.ColProduct.DataPropertyName = "Product"
        Me.ColProduct.HeaderText = "Product"
        Me.ColProduct.Name = "ColProduct"
        Me.ColProduct.ReadOnly = True
        Me.ColProduct.Width = 400
        '
        'ColQTY
        '
        Me.ColQTY.DataPropertyName = "qty"
        Me.ColQTY.HeaderText = "QTY"
        Me.ColQTY.Name = "ColQTY"
        Me.ColQTY.ReadOnly = True
        Me.ColQTY.Width = 70
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExit.Location = New System.Drawing.Point(812, 577)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(81, 38)
        Me.btnExit.TabIndex = 18
        Me.btnExit.Text = "Close"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'cmbFrom
        '
        Me.cmbFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmbFrom.FormattingEnabled = True
        Me.cmbFrom.Location = New System.Drawing.Point(20, 104)
        Me.cmbFrom.Name = "cmbFrom"
        Me.cmbFrom.Size = New System.Drawing.Size(121, 24)
        Me.cmbFrom.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "From"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(145, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "To"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(280, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Item Code"
        '
        'txtProduct
        '
        Me.txtProduct.BackColor = System.Drawing.Color.Yellow
        Me.txtProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtProduct.Location = New System.Drawing.Point(376, 104)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.ReadOnly = True
        Me.txtProduct.Size = New System.Drawing.Size(443, 23)
        Me.txtProduct.TabIndex = 11
        Me.txtProduct.TabStop = False
        '
        'txtDescription
        '
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(307, 50)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(527, 23)
        Me.txtDescription.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(565, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Product"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.Location = New System.Drawing.Point(844, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 17)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Qty"
        '
        'lblDoc
        '
        Me.lblDoc.BackColor = System.Drawing.Color.DarkViolet
        Me.lblDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDoc.ForeColor = System.Drawing.Color.White
        Me.lblDoc.Location = New System.Drawing.Point(-2, 0)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(918, 35)
        Me.lblDoc.TabIndex = 6
        Me.lblDoc.Text = "Store Transfer"
        Me.lblDoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRefresh
        '
        Me.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(468, 577)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(81, 38)
        Me.btnRefresh.TabIndex = 17
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.Location = New System.Drawing.Point(188, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 17)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Description"
        '
        'txtQTY
        '
        Me.txtQTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtQTY.Location = New System.Drawing.Point(823, 104)
        Me.txtQTY.Name = "txtQTY"
        Me.txtQTY.Size = New System.Drawing.Size(75, 23)
        Me.txtQTY.TabIndex = 13
        Me.txtQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnFrom
        '
        Me.btnFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnFrom.Location = New System.Drawing.Point(63, 85)
        Me.btnFrom.Name = "btnFrom"
        Me.btnFrom.Size = New System.Drawing.Size(78, 17)
        Me.btnFrom.TabIndex = 17
        Me.btnFrom.TabStop = False
        Me.btnFrom.Text = "Change All"
        Me.btnFrom.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFrom.UseVisualStyleBackColor = True
        '
        'btnTO
        '
        Me.btnTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnTO.Location = New System.Drawing.Point(181, 84)
        Me.btnTO.Name = "btnTO"
        Me.btnTO.Size = New System.Drawing.Size(78, 17)
        Me.btnTO.TabIndex = 17
        Me.btnTO.TabStop = False
        Me.btnTO.Text = "Change All"
        Me.btnTO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTO.UseVisualStyleBackColor = True
        '
        'btnAddSupply
        '
        Me.btnAddSupply.Location = New System.Drawing.Point(76, 574)
        Me.btnAddSupply.Name = "btnAddSupply"
        Me.btnAddSupply.Size = New System.Drawing.Size(110, 44)
        Me.btnAddSupply.TabIndex = 18
        Me.btnAddSupply.Text = "DUPLICATE LAST VOUCHER"
        Me.btnAddSupply.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(640, 577)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(81, 38)
        Me.btnDelete.TabIndex = 16
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExport.Location = New System.Drawing.Point(554, 577)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(81, 38)
        Me.btnExport.TabIndex = 15
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(726, 577)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(81, 38)
        Me.btnPrint.TabIndex = 14
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'rdFeedOrder
        '
        Me.rdFeedOrder.AutoSize = True
        Me.rdFeedOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdFeedOrder.Location = New System.Drawing.Point(320, 596)
        Me.rdFeedOrder.Name = "rdFeedOrder"
        Me.rdFeedOrder.Size = New System.Drawing.Size(99, 21)
        Me.rdFeedOrder.TabIndex = 19
        Me.rdFeedOrder.Text = "Feed Order"
        Me.rdFeedOrder.UseVisualStyleBackColor = True
        '
        'rdAlphabeticalOrder
        '
        Me.rdAlphabeticalOrder.AutoSize = True
        Me.rdAlphabeticalOrder.Checked = True
        Me.rdAlphabeticalOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdAlphabeticalOrder.Location = New System.Drawing.Point(320, 575)
        Me.rdAlphabeticalOrder.Name = "rdAlphabeticalOrder"
        Me.rdAlphabeticalOrder.Size = New System.Drawing.Size(144, 21)
        Me.rdAlphabeticalOrder.TabIndex = 19
        Me.rdAlphabeticalOrder.TabStop = True
        Me.rdAlphabeticalOrder.Text = "Alphabetical Order"
        Me.rdAlphabeticalOrder.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.Location = New System.Drawing.Point(189, 574)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 44)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "All Stock ""From"" Location"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtVn
        '
        Me.txtVn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtVn.Location = New System.Drawing.Point(14, 583)
        Me.txtVn.Name = "txtVn"
        Me.txtVn.Size = New System.Drawing.Size(58, 29)
        Me.txtVn.TabIndex = 21
        Me.txtVn.TabStop = False
        Me.txtVn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmStockTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(916, 621)
        Me.Controls.Add(Me.txtVn)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.rdAlphabeticalOrder)
        Me.Controls.Add(Me.rdFeedOrder)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddSupply)
        Me.Controls.Add(Me.btnTO)
        Me.Controls.Add(Me.btnFrom)
        Me.Controls.Add(Me.lblDoc)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.DGVStock)
        Me.Controls.Add(Me.cmbFrom)
        Me.Controls.Add(Me.cmbTo)
        Me.Controls.Add(Me.txtDocNum)
        Me.Controls.Add(Me.txtProduct)
        Me.Controls.Add(Me.txtQTY)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtPRID)
        Me.Controls.Add(Me.DTP1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmStockTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmStockTransfer"
        CType(Me.DGVStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents DTP1 As DateTimePicker
    Friend WithEvents txtPRID As TextBox
    Friend WithEvents cmbTo As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDocNum As TextBox
    Friend WithEvents DGVStock As DataGridView
    Friend WithEvents btnExit As Button
    Friend WithEvents cmbFrom As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtProduct As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblDoc As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents txtQTY As TextBox
    Friend WithEvents btnFrom As Button
    Friend WithEvents btnTO As Button
    Friend WithEvents btnAddSupply As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents ColSr As DataGridViewTextBoxColumn
    Friend WithEvents colDelete As DataGridViewButtonColumn
    Friend WithEvents colPSID As DataGridViewTextBoxColumn
    Friend WithEvents colCode As DataGridViewTextBoxColumn
    Friend WithEvents colPrid As DataGridViewTextBoxColumn
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents colDoc As DataGridViewTextBoxColumn
    Friend WithEvents colType As DataGridViewTextBoxColumn
    Friend WithEvents ColFrom As DataGridViewTextBoxColumn
    Friend WithEvents ColTo As DataGridViewTextBoxColumn
    Friend WithEvents ColProduct As DataGridViewTextBoxColumn
    Friend WithEvents ColQTY As DataGridViewTextBoxColumn
    Friend WithEvents btnExport As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents rdFeedOrder As RadioButton
    Friend WithEvents rdAlphabeticalOrder As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents txtVn As TextBox
End Class

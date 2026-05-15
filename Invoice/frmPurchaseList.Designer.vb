<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchaseList
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.colDDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBuilty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGoods = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFreight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRoute = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblDoc = New System.Windows.Forms.Label()
        Me.txtFreightTotal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.chkEstimate = New System.Windows.Forms.CheckBox()
        Me.btnListPreview = New System.Windows.Forms.Button()
        Me.txtTotalProfit = New System.Windows.Forms.TextBox()
        Me.txtProfitP = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBiltyNumber = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.DGVList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DTPStart
        '
        Me.DTPStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DTPStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPStart.Location = New System.Drawing.Point(372, 43)
        Me.DTPStart.Name = "DTPStart"
        Me.DTPStart.Size = New System.Drawing.Size(107, 26)
        Me.DTPStart.TabIndex = 3
        '
        'txtRoute
        '
        Me.txtRoute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRoute.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtRoute.Location = New System.Drawing.Point(721, 43)
        Me.txtRoute.Name = "txtRoute"
        Me.txtRoute.Size = New System.Drawing.Size(57, 26)
        Me.txtRoute.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(286, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Start Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(668, 47)
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
        Me.BtnPrint.Location = New System.Drawing.Point(555, 624)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(107, 38)
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
        Me.btnExit.Location = New System.Drawing.Point(688, 624)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(107, 36)
        Me.btnExit.TabIndex = 15
        Me.btnExit.Text = "&Close"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.Green
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.Location = New System.Drawing.Point(440, 624)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(107, 38)
        Me.btnExport.TabIndex = 13
        Me.btnExport.Text = "&Export All"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Customer"
        '
        'txtCustomer
        '
        Me.txtCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(97, 43)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(186, 26)
        Me.txtCustomer.TabIndex = 1
        '
        'btnExportSelected
        '
        Me.btnExportSelected.BackColor = System.Drawing.Color.LightSkyBlue
        Me.btnExportSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExportSelected.Location = New System.Drawing.Point(189, 624)
        Me.btnExportSelected.Name = "btnExportSelected"
        Me.btnExportSelected.Size = New System.Drawing.Size(107, 38)
        Me.btnExportSelected.TabIndex = 11
        Me.btnExportSelected.Text = "Export Selected"
        Me.btnExportSelected.UseVisualStyleBackColor = False
        '
        'btnPrintSelected
        '
        Me.btnPrintSelected.BackColor = System.Drawing.Color.LightSkyBlue
        Me.btnPrintSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPrintSelected.Location = New System.Drawing.Point(307, 624)
        Me.btnPrintSelected.Name = "btnPrintSelected"
        Me.btnPrintSelected.Size = New System.Drawing.Size(107, 38)
        Me.btnPrintSelected.TabIndex = 12
        Me.btnPrintSelected.Text = "Print Selected"
        Me.btnPrintSelected.UseVisualStyleBackColor = False
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(1036, 613)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(142, 26)
        Me.txtTotal.TabIndex = 11
        Me.txtTotal.TabStop = False
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DTPEnd
        '
        Me.DTPEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DTPEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPEnd.Location = New System.Drawing.Point(561, 43)
        Me.DTPEnd.Name = "DTPEnd"
        Me.DTPEnd.Size = New System.Drawing.Size(106, 26)
        Me.DTPEnd.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(482, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 18)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "End Date"
        '
        'DGVList
        '
        Me.DGVList.AllowUserToAddRows = False
        Me.DGVList.AllowUserToDeleteRows = False
        Me.DGVList.AllowUserToResizeColumns = False
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
        Me.DGVList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNumber, Me.colDDate, Me.colBuilty, Me.colGoods, Me.ColFreight, Me.ColDate, Me.ColDoc, Me.ColCustomer, Me.colDesc, Me.colRoute, Me.ColAmount})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVList.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGVList.Location = New System.Drawing.Point(25, 82)
        Me.DGVList.Name = "DGVList"
        Me.DGVList.ReadOnly = True
        Me.DGVList.RowHeadersVisible = False
        Me.DGVList.RowHeadersWidth = 51
        Me.DGVList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVList.Size = New System.Drawing.Size(1260, 532)
        Me.DGVList.TabIndex = 10
        Me.DGVList.TabStop = False
        '
        'ColNumber
        '
        Me.ColNumber.DataPropertyName = "rn"
        Me.ColNumber.HeaderText = "Sr. #"
        Me.ColNumber.MinimumWidth = 6
        Me.ColNumber.Name = "ColNumber"
        Me.ColNumber.ReadOnly = True
        Me.ColNumber.Width = 50
        '
        'colDDate
        '
        Me.colDDate.DataPropertyName = "DueDate"
        Me.colDDate.HeaderText = "Dispatched On"
        Me.colDDate.Name = "colDDate"
        Me.colDDate.ReadOnly = True
        '
        'colBuilty
        '
        Me.colBuilty.DataPropertyName = "builty"
        Me.colBuilty.HeaderText = "Builty"
        Me.colBuilty.Name = "colBuilty"
        Me.colBuilty.ReadOnly = True
        '
        'colGoods
        '
        Me.colGoods.DataPropertyName = "goods"
        Me.colGoods.HeaderText = "Transporter"
        Me.colGoods.Name = "colGoods"
        Me.colGoods.ReadOnly = True
        Me.colGoods.Width = 150
        '
        'ColFreight
        '
        Me.ColFreight.DataPropertyName = "Freight"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColFreight.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColFreight.HeaderText = "Freight"
        Me.ColFreight.MinimumWidth = 6
        Me.ColFreight.Name = "ColFreight"
        Me.ColFreight.ReadOnly = True
        Me.ColFreight.Width = 80
        '
        'ColDate
        '
        Me.ColDate.DataPropertyName = "date"
        Me.ColDate.HeaderText = "Date"
        Me.ColDate.MinimumWidth = 6
        Me.ColDate.Name = "ColDate"
        Me.ColDate.ReadOnly = True
        Me.ColDate.Width = 80
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
        Me.ColDoc.Width = 70
        '
        'ColCustomer
        '
        Me.ColCustomer.DataPropertyName = "Subsidary"
        Me.ColCustomer.HeaderText = "Customer Name"
        Me.ColCustomer.MinimumWidth = 6
        Me.ColCustomer.Name = "ColCustomer"
        Me.ColCustomer.ReadOnly = True
        Me.ColCustomer.Width = 230
        '
        'colDesc
        '
        Me.colDesc.DataPropertyName = "Description"
        Me.colDesc.HeaderText = "Description"
        Me.colDesc.MinimumWidth = 6
        Me.colDesc.Name = "colDesc"
        Me.colDesc.ReadOnly = True
        Me.colDesc.Width = 330
        '
        'colRoute
        '
        Me.colRoute.DataPropertyName = "Route"
        Me.colRoute.HeaderText = "Route"
        Me.colRoute.MinimumWidth = 6
        Me.colRoute.Name = "colRoute"
        Me.colRoute.ReadOnly = True
        Me.colRoute.Visible = False
        Me.colRoute.Width = 120
        '
        'ColAmount
        '
        Me.ColAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.ColAmount.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColAmount.HeaderText = "Amount"
        Me.ColAmount.MinimumWidth = 6
        Me.ColAmount.Name = "ColAmount"
        Me.ColAmount.ReadOnly = True
        Me.ColAmount.Width = 140
        '
        'lblDoc
        '
        Me.lblDoc.BackColor = System.Drawing.Color.Turquoise
        Me.lblDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDoc.ForeColor = System.Drawing.Color.White
        Me.lblDoc.Location = New System.Drawing.Point(2, -4)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(1294, 38)
        Me.lblDoc.TabIndex = 14
        Me.lblDoc.Text = "Purchase List"
        Me.lblDoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFreightTotal
        '
        Me.txtFreightTotal.BackColor = System.Drawing.Color.White
        Me.txtFreightTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtFreightTotal.Location = New System.Drawing.Point(1177, 613)
        Me.txtFreightTotal.Name = "txtFreightTotal"
        Me.txtFreightTotal.ReadOnly = True
        Me.txtFreightTotal.Size = New System.Drawing.Size(80, 26)
        Me.txtFreightTotal.TabIndex = 11
        Me.txtFreightTotal.TabStop = False
        Me.txtFreightTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(922, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 18)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Desc."
        '
        'txtDescription
        '
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(976, 43)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(111, 26)
        Me.txtDescription.TabIndex = 10
        Me.txtDescription.Text = "PENDING"
        '
        'chkEstimate
        '
        Me.chkEstimate.AutoSize = True
        Me.chkEstimate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkEstimate.Location = New System.Drawing.Point(782, 45)
        Me.chkEstimate.Margin = New System.Windows.Forms.Padding(2)
        Me.chkEstimate.Name = "chkEstimate"
        Me.chkEstimate.Size = New System.Drawing.Size(142, 22)
        Me.chkEstimate.TabIndex = 8
        Me.chkEstimate.Text = "Incld.Estimates"
        Me.chkEstimate.UseVisualStyleBackColor = True
        '
        'btnListPreview
        '
        Me.btnListPreview.BackColor = System.Drawing.Color.Red
        Me.btnListPreview.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnListPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnListPreview.ForeColor = System.Drawing.Color.White
        Me.btnListPreview.Location = New System.Drawing.Point(25, 626)
        Me.btnListPreview.Name = "btnListPreview"
        Me.btnListPreview.Size = New System.Drawing.Size(107, 36)
        Me.btnListPreview.TabIndex = 15
        Me.btnListPreview.Text = "&List Preview"
        Me.btnListPreview.UseVisualStyleBackColor = False
        '
        'txtTotalProfit
        '
        Me.txtTotalProfit.BackColor = System.Drawing.Color.White
        Me.txtTotalProfit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotalProfit.Location = New System.Drawing.Point(799, 636)
        Me.txtTotalProfit.Name = "txtTotalProfit"
        Me.txtTotalProfit.ReadOnly = True
        Me.txtTotalProfit.Size = New System.Drawing.Size(90, 26)
        Me.txtTotalProfit.TabIndex = 11
        Me.txtTotalProfit.TabStop = False
        Me.txtTotalProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalProfit.Visible = False
        '
        'txtProfitP
        '
        Me.txtProfitP.BackColor = System.Drawing.Color.White
        Me.txtProfitP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtProfitP.Location = New System.Drawing.Point(887, 636)
        Me.txtProfitP.Name = "txtProfitP"
        Me.txtProfitP.ReadOnly = True
        Me.txtProfitP.Size = New System.Drawing.Size(57, 26)
        Me.txtProfitP.TabIndex = 11
        Me.txtProfitP.TabStop = False
        Me.txtProfitP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtProfitP.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(976, 617)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Totals"
        '
        'txtBiltyNumber
        '
        Me.txtBiltyNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtBiltyNumber.Location = New System.Drawing.Point(1145, 43)
        Me.txtBiltyNumber.Name = "txtBiltyNumber"
        Me.txtBiltyNumber.Size = New System.Drawing.Size(100, 26)
        Me.txtBiltyNumber.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.Location = New System.Drawing.Point(1089, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 18)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Bilty #"
        '
        'frmPurchaseList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(1297, 668)
        Me.Controls.Add(Me.txtBiltyNumber)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkEstimate)
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
        Me.Name = "frmPurchaseList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPurchaseList"
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
    Friend WithEvents chkEstimate As CheckBox
    Friend WithEvents btnListPreview As Button
    Friend WithEvents txtTotalProfit As TextBox
    Friend WithEvents txtProfitP As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ColNumber As DataGridViewTextBoxColumn
    Friend WithEvents colDDate As DataGridViewTextBoxColumn
    Friend WithEvents colBuilty As DataGridViewTextBoxColumn
    Friend WithEvents colGoods As DataGridViewTextBoxColumn
    Friend WithEvents ColFreight As DataGridViewTextBoxColumn
    Friend WithEvents ColDate As DataGridViewTextBoxColumn
    Friend WithEvents ColDoc As DataGridViewTextBoxColumn
    Friend WithEvents ColCustomer As DataGridViewTextBoxColumn
    Friend WithEvents colDesc As DataGridViewTextBoxColumn
    Friend WithEvents colRoute As DataGridViewTextBoxColumn
    Friend WithEvents ColAmount As DataGridViewTextBoxColumn
    Friend WithEvents txtBiltyNumber As TextBox
    Friend WithEvents Label7 As Label
End Class

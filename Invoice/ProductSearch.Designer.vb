<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductSearch
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtItem = New System.Windows.Forms.TextBox()
        Me.txtCompany = New System.Windows.Forms.TextBox()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvProduct = New System.Windows.Forms.DataGridView()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.chkDeadItems = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtiCode = New System.Windows.Forms.TextBox()
        Me.colCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCompany = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colList = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNetprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLastSaleMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtItem
        '
        Me.txtItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtItem.Location = New System.Drawing.Point(402, 6)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(196, 26)
        Me.txtItem.TabIndex = 3
        '
        'txtCompany
        '
        Me.txtCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCompany.Location = New System.Drawing.Point(694, 6)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(160, 26)
        Me.txtCompany.TabIndex = 5
        '
        'txtCategory
        '
        Me.txtCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCategory.Location = New System.Drawing.Point(919, 6)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(141, 26)
        Me.txtCategory.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(301, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Item Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(606, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Company"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(857, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Model"
        '
        'dgvProduct
        '
        Me.dgvProduct.AllowUserToAddRows = False
        Me.dgvProduct.AllowUserToDeleteRows = False
        Me.dgvProduct.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProduct.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProduct.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCode, Me.colCompany, Me.colCategory, Me.ColName, Me.colSize, Me.ColPrice, Me.colList, Me.colDiscount, Me.colNetprice, Me.colPID, Me.ColStock, Me.colRecNo, Me.colLastSaleMonth})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProduct.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvProduct.Location = New System.Drawing.Point(8, 38)
        Me.dgvProduct.Name = "dgvProduct"
        Me.dgvProduct.ReadOnly = True
        Me.dgvProduct.RowHeadersWidth = 51
        Me.dgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProduct.Size = New System.Drawing.Size(1294, 279)
        Me.dgvProduct.StandardTab = True
        Me.dgvProduct.TabIndex = 9
        '
        'btnExit
        '
        Me.btnExit.BackgroundImage = Global.Invoice.My.Resources.Resources.door_exit2
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExit.Location = New System.Drawing.Point(1224, 322)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(55, 61)
        Me.btnExit.TabIndex = 10
        Me.btnExit.TabStop = False
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'chkDeadItems
        '
        Me.chkDeadItems.AutoSize = True
        Me.chkDeadItems.Checked = True
        Me.chkDeadItems.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDeadItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkDeadItems.Location = New System.Drawing.Point(1066, 8)
        Me.chkDeadItems.Name = "chkDeadItems"
        Me.chkDeadItems.Size = New System.Drawing.Size(165, 21)
        Me.chkDeadItems.TabIndex = 8
        Me.chkDeadItems.TabStop = False
        Me.chkDeadItems.Text = "Include &Dead Items"
        Me.chkDeadItems.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Part Number"
        Me.Label4.Visible = False
        '
        'txtiCode
        '
        Me.txtiCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtiCode.Location = New System.Drawing.Point(124, 6)
        Me.txtiCode.Name = "txtiCode"
        Me.txtiCode.Size = New System.Drawing.Size(174, 26)
        Me.txtiCode.TabIndex = 1
        Me.txtiCode.Visible = False
        '
        'colCode
        '
        Me.colCode.DataPropertyName = "Code"
        Me.colCode.HeaderText = "Item Code"
        Me.colCode.MinimumWidth = 6
        Me.colCode.Name = "colCode"
        Me.colCode.ReadOnly = True
        Me.colCode.Width = 110
        '
        'colCompany
        '
        Me.colCompany.DataPropertyName = "Company"
        Me.colCompany.HeaderText = "Company"
        Me.colCompany.MinimumWidth = 6
        Me.colCompany.Name = "colCompany"
        Me.colCompany.ReadOnly = True
        Me.colCompany.Width = 140
        '
        'colCategory
        '
        Me.colCategory.DataPropertyName = "Category"
        Me.colCategory.HeaderText = "Model"
        Me.colCategory.MinimumWidth = 6
        Me.colCategory.Name = "colCategory"
        Me.colCategory.ReadOnly = True
        Me.colCategory.Width = 140
        '
        'ColName
        '
        Me.ColName.DataPropertyName = "Name"
        Me.ColName.HeaderText = "Product Name"
        Me.ColName.MinimumWidth = 6
        Me.ColName.Name = "ColName"
        Me.ColName.ReadOnly = True
        Me.ColName.Width = 300
        '
        'colSize
        '
        Me.colSize.DataPropertyName = "size"
        Me.colSize.HeaderText = "U.O.M"
        Me.colSize.MinimumWidth = 6
        Me.colSize.Name = "colSize"
        Me.colSize.ReadOnly = True
        Me.colSize.Width = 70
        '
        'ColPrice
        '
        Me.ColPrice.DataPropertyName = "SelectedListPrice"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColPrice.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColPrice.HeaderText = "Price"
        Me.ColPrice.MinimumWidth = 6
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.ReadOnly = True
        Me.ColPrice.Width = 90
        '
        'colList
        '
        Me.colList.DataPropertyName = "PriceList"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colList.DefaultCellStyle = DataGridViewCellStyle3
        Me.colList.HeaderText = "List"
        Me.colList.MinimumWidth = 6
        Me.colList.Name = "colList"
        Me.colList.ReadOnly = True
        Me.colList.Width = 60
        '
        'colDiscount
        '
        Me.colDiscount.DataPropertyName = "discount"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colDiscount.DefaultCellStyle = DataGridViewCellStyle4
        Me.colDiscount.HeaderText = "Disc."
        Me.colDiscount.MinimumWidth = 6
        Me.colDiscount.Name = "colDiscount"
        Me.colDiscount.ReadOnly = True
        Me.colDiscount.Width = 70
        '
        'colNetprice
        '
        Me.colNetprice.DataPropertyName = "NetRate"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colNetprice.DefaultCellStyle = DataGridViewCellStyle5
        Me.colNetprice.HeaderText = "Net Rate"
        Me.colNetprice.MinimumWidth = 6
        Me.colNetprice.Name = "colNetprice"
        Me.colNetprice.ReadOnly = True
        Me.colNetprice.Width = 90
        '
        'colPID
        '
        Me.colPID.DataPropertyName = "ID"
        Me.colPID.HeaderText = "ID"
        Me.colPID.MinimumWidth = 6
        Me.colPID.Name = "colPID"
        Me.colPID.ReadOnly = True
        Me.colPID.Width = 60
        '
        'ColStock
        '
        Me.ColStock.DataPropertyName = "AvailableStock"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColStock.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColStock.HeaderText = "Stock"
        Me.ColStock.MinimumWidth = 6
        Me.ColStock.Name = "ColStock"
        Me.ColStock.ReadOnly = True
        Me.ColStock.Width = 70
        '
        'colRecNo
        '
        Me.colRecNo.DataPropertyName = "rn"
        Me.colRecNo.HeaderText = "rn"
        Me.colRecNo.MinimumWidth = 6
        Me.colRecNo.Name = "colRecNo"
        Me.colRecNo.ReadOnly = True
        Me.colRecNo.Visible = False
        Me.colRecNo.Width = 125
        '
        'colLastSaleMonth
        '
        Me.colLastSaleMonth.DataPropertyName = "LastSaleMonths"
        Me.colLastSaleMonth.HeaderText = "LastSaleMonths"
        Me.colLastSaleMonth.MinimumWidth = 6
        Me.colLastSaleMonth.Name = "colLastSaleMonth"
        Me.colLastSaleMonth.ReadOnly = True
        Me.colLastSaleMonth.Visible = False
        Me.colLastSaleMonth.Width = 125
        '
        'ProductSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(1307, 381)
        Me.Controls.Add(Me.txtiCode)
        Me.Controls.Add(Me.chkDeadItems)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.dgvProduct)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.txtCompany)
        Me.Controls.Add(Me.txtItem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Location = New System.Drawing.Point(50, 30)
        Me.Name = "ProductSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProductSearch"
        CType(Me.dgvProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtItem As TextBox
    Friend WithEvents txtCompany As TextBox
    Friend WithEvents txtCategory As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvProduct As DataGridView
    Friend WithEvents btnExit As Button
    Friend WithEvents chkDeadItems As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtiCode As TextBox
    Friend WithEvents colCode As DataGridViewTextBoxColumn
    Friend WithEvents colCompany As DataGridViewTextBoxColumn
    Friend WithEvents colCategory As DataGridViewTextBoxColumn
    Friend WithEvents ColName As DataGridViewTextBoxColumn
    Friend WithEvents colSize As DataGridViewTextBoxColumn
    Friend WithEvents ColPrice As DataGridViewTextBoxColumn
    Friend WithEvents colList As DataGridViewTextBoxColumn
    Friend WithEvents colDiscount As DataGridViewTextBoxColumn
    Friend WithEvents colNetprice As DataGridViewTextBoxColumn
    Friend WithEvents colPID As DataGridViewTextBoxColumn
    Friend WithEvents ColStock As DataGridViewTextBoxColumn
    Friend WithEvents colRecNo As DataGridViewTextBoxColumn
    Friend WithEvents colLastSaleMonth As DataGridViewTextBoxColumn
End Class

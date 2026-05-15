<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Product
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.dgvProduct = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vendor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Company = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UrduName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Min = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reorder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeadLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PurchaseRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaleRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaleRate2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaleRate3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.txtCompany = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtVendor = New System.Windows.Forms.TextBox()
        Me.lblVendor = New System.Windows.Forms.Label()
        Me.txtACID = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVendorName = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnBatchUpdate = New System.Windows.Forms.Button()
        Me.txtNewUrduName = New System.Windows.Forms.TextBox()
        Me.txtNewName = New System.Windows.Forms.TextBox()
        Me.txtNewModel = New System.Windows.Forms.TextBox()
        Me.txtNewCompany = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.dgvProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(121, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Product"
        '
        'txtName
        '
        Me.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtName.Location = New System.Drawing.Point(76, 30)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(141, 20)
        Me.txtName.TabIndex = 3
        '
        'dgvProduct
        '
        Me.dgvProduct.AllowUserToAddRows = False
        Me.dgvProduct.AllowUserToDeleteRows = False
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProduct.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProduct.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Code, Me.Vendor, Me.Company, Me.Category, Me.pname, Me.UrduName, Me.Stock, Me.Min, Me.Reorder, Me.DeadLevel, Me.Value, Me.PurchaseRate, Me.SaleRate, Me.SaleRate2, Me.SaleRate3})
        Me.dgvProduct.Location = New System.Drawing.Point(16, 61)
        Me.dgvProduct.Name = "dgvProduct"
        Me.dgvProduct.RowHeadersWidth = 65
        Me.dgvProduct.Size = New System.Drawing.Size(1422, 603)
        Me.dgvProduct.TabIndex = 3
        '
        'ID
        '
        Me.ID.DataPropertyName = "id"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'Code
        '
        Me.Code.DataPropertyName = "Code"
        Me.Code.HeaderText = "Code"
        Me.Code.Name = "Code"
        Me.Code.Width = 80
        '
        'Vendor
        '
        Me.Vendor.DataPropertyName = "Vendor"
        Me.Vendor.HeaderText = "Vendor"
        Me.Vendor.Name = "Vendor"
        Me.Vendor.Width = 50
        '
        'Company
        '
        Me.Company.DataPropertyName = "Company"
        Me.Company.HeaderText = "Company"
        Me.Company.Name = "Company"
        '
        'Category
        '
        Me.Category.DataPropertyName = "category"
        Me.Category.FillWeight = 90.0!
        Me.Category.HeaderText = "Model"
        Me.Category.Name = "Category"
        '
        'pname
        '
        Me.pname.DataPropertyName = "pname"
        Me.pname.HeaderText = "NAME"
        Me.pname.Name = "pname"
        Me.pname.Width = 200
        '
        'UrduName
        '
        Me.UrduName.DataPropertyName = "urduname"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.UrduName.DefaultCellStyle = DataGridViewCellStyle13
        Me.UrduName.HeaderText = "Urdu Name"
        Me.UrduName.Name = "UrduName"
        Me.UrduName.Width = 150
        '
        'Stock
        '
        Me.Stock.DataPropertyName = "stock"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Stock.DefaultCellStyle = DataGridViewCellStyle14
        Me.Stock.HeaderText = "Stock QTY"
        Me.Stock.Name = "Stock"
        Me.Stock.Width = 60
        '
        'Min
        '
        Me.Min.DataPropertyName = "min"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Min.DefaultCellStyle = DataGridViewCellStyle15
        Me.Min.HeaderText = "Min QTY"
        Me.Min.Name = "Min"
        Me.Min.Width = 60
        '
        'Reorder
        '
        Me.Reorder.DataPropertyName = "reorder"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Reorder.DefaultCellStyle = DataGridViewCellStyle16
        Me.Reorder.HeaderText = "ReOrder QTY"
        Me.Reorder.Name = "Reorder"
        Me.Reorder.Width = 70
        '
        'DeadLevel
        '
        Me.DeadLevel.DataPropertyName = "DeadLevel"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DeadLevel.DefaultCellStyle = DataGridViewCellStyle17
        Me.DeadLevel.HeaderText = "Dead Level"
        Me.DeadLevel.Name = "DeadLevel"
        Me.DeadLevel.Width = 70
        '
        'Value
        '
        Me.Value.DataPropertyName = "value"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Value.DefaultCellStyle = DataGridViewCellStyle18
        Me.Value.HeaderText = "Stock Value"
        Me.Value.Name = "Value"
        Me.Value.Width = 90
        '
        'PurchaseRate
        '
        Me.PurchaseRate.DataPropertyName = "PurchaseRate"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.PurchaseRate.DefaultCellStyle = DataGridViewCellStyle19
        Me.PurchaseRate.HeaderText = "Purchase Rate"
        Me.PurchaseRate.Name = "PurchaseRate"
        Me.PurchaseRate.Width = 80
        '
        'SaleRate
        '
        Me.SaleRate.DataPropertyName = "SaleRate"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SaleRate.DefaultCellStyle = DataGridViewCellStyle20
        Me.SaleRate.HeaderText = "LIST A"
        Me.SaleRate.Name = "SaleRate"
        Me.SaleRate.Width = 72
        '
        'SaleRate2
        '
        Me.SaleRate2.DataPropertyName = "SaleRate2"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SaleRate2.DefaultCellStyle = DataGridViewCellStyle21
        Me.SaleRate2.HeaderText = "LIST B"
        Me.SaleRate2.Name = "SaleRate2"
        Me.SaleRate2.Width = 72
        '
        'SaleRate3
        '
        Me.SaleRate3.DataPropertyName = "SaleRate3"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SaleRate3.DefaultCellStyle = DataGridViewCellStyle22
        Me.SaleRate3.HeaderText = "LIST C"
        Me.SaleRate3.Name = "SaleRate3"
        Me.SaleRate3.Width = 72
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(366, 10)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(83, 41)
        Me.btnGenerate.TabIndex = 8
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'txtCategory
        '
        Me.txtCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCategory.Location = New System.Drawing.Point(219, 30)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(80, 20)
        Me.txtCategory.TabIndex = 5
        '
        'txtCompany
        '
        Me.txtCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCompany.Location = New System.Drawing.Point(4, 30)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(70, 20)
        Me.txtCompany.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(238, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Model"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Company"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Red
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(1362, 10)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 45)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'txtVendor
        '
        Me.txtVendor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendor.Location = New System.Drawing.Point(301, 30)
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Size = New System.Drawing.Size(63, 20)
        Me.txtVendor.TabIndex = 7
        '
        'lblVendor
        '
        Me.lblVendor.AutoSize = True
        Me.lblVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblVendor.Location = New System.Drawing.Point(309, 16)
        Me.lblVendor.Name = "lblVendor"
        Me.lblVendor.Size = New System.Drawing.Size(47, 13)
        Me.lblVendor.TabIndex = 6
        Me.lblVendor.Text = "Vendor"
        '
        'txtACID
        '
        Me.txtACID.Location = New System.Drawing.Point(6, 29)
        Me.txtACID.Name = "txtACID"
        Me.txtACID.Size = New System.Drawing.Size(41, 20)
        Me.txtACID.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnGenerate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblVendor)
        Me.GroupBox1.Controls.Add(Me.txtVendor)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.txtCompany)
        Me.GroupBox1.Controls.Add(Me.txtCategory)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(450, 52)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Product Selection Criteria"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnUpdate)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtVendorName)
        Me.GroupBox2.Controls.Add(Me.txtACID)
        Me.GroupBox2.Location = New System.Drawing.Point(465, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(472, 52)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Vendor Fixation"
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(401, 10)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(68, 41)
        Me.btnUpdate.TabIndex = 4
        Me.btnUpdate.Text = "&Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(182, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Vendor Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Acc ID"
        '
        'txtVendorName
        '
        Me.txtVendorName.BackColor = System.Drawing.Color.Yellow
        Me.txtVendorName.Location = New System.Drawing.Point(49, 29)
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(349, 20)
        Me.txtVendorName.TabIndex = 3
        Me.txtVendorName.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnBatchUpdate)
        Me.GroupBox3.Controls.Add(Me.txtNewUrduName)
        Me.GroupBox3.Controls.Add(Me.txtNewName)
        Me.GroupBox3.Controls.Add(Me.txtNewModel)
        Me.GroupBox3.Controls.Add(Me.txtNewCompany)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(940, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(421, 53)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Batch Change"
        '
        'btnBatchUpdate
        '
        Me.btnBatchUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnBatchUpdate.Location = New System.Drawing.Point(353, 7)
        Me.btnBatchUpdate.Name = "btnBatchUpdate"
        Me.btnBatchUpdate.Size = New System.Drawing.Size(68, 43)
        Me.btnBatchUpdate.TabIndex = 4
        Me.btnBatchUpdate.Text = "&Batch Update"
        Me.btnBatchUpdate.UseVisualStyleBackColor = True
        '
        'txtNewUrduName
        '
        Me.txtNewUrduName.Location = New System.Drawing.Point(241, 29)
        Me.txtNewUrduName.Name = "txtNewUrduName"
        Me.txtNewUrduName.Size = New System.Drawing.Size(109, 20)
        Me.txtNewUrduName.TabIndex = 0
        '
        'txtNewName
        '
        Me.txtNewName.Location = New System.Drawing.Point(132, 29)
        Me.txtNewName.Name = "txtNewName"
        Me.txtNewName.Size = New System.Drawing.Size(106, 20)
        Me.txtNewName.TabIndex = 0
        '
        'txtNewModel
        '
        Me.txtNewModel.Location = New System.Drawing.Point(62, 29)
        Me.txtNewModel.Name = "txtNewModel"
        Me.txtNewModel.Size = New System.Drawing.Size(67, 20)
        Me.txtNewModel.TabIndex = 0
        '
        'txtNewCompany
        '
        Me.txtNewCompany.Location = New System.Drawing.Point(4, 29)
        Me.txtNewCompany.Name = "txtNewCompany"
        Me.txtNewCompany.Size = New System.Drawing.Size(58, 20)
        Me.txtNewCompany.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.Location = New System.Drawing.Point(262, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "UrduName"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.Location = New System.Drawing.Point(165, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.Location = New System.Drawing.Point(75, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Model"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Company"
        '
        'Product
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1447, 675)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dgvProduct)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "Product"
        Me.Text = "Product Name"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents dgvProduct As DataGridView
    Friend WithEvents btnGenerate As Button
    Friend WithEvents txtCategory As TextBox
    Friend WithEvents txtCompany As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents txtVendor As TextBox
    Friend WithEvents lblVendor As Label
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Code As DataGridViewTextBoxColumn
    Friend WithEvents Vendor As DataGridViewTextBoxColumn
    Friend WithEvents Company As DataGridViewTextBoxColumn
    Friend WithEvents Category As DataGridViewTextBoxColumn
    Friend WithEvents pname As DataGridViewTextBoxColumn
    Friend WithEvents UrduName As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents Min As DataGridViewTextBoxColumn
    Friend WithEvents Reorder As DataGridViewTextBoxColumn
    Friend WithEvents DeadLevel As DataGridViewTextBoxColumn
    Friend WithEvents Value As DataGridViewTextBoxColumn
    Friend WithEvents PurchaseRate As DataGridViewTextBoxColumn
    Friend WithEvents SaleRate As DataGridViewTextBoxColumn
    Friend WithEvents SaleRate2 As DataGridViewTextBoxColumn
    Friend WithEvents SaleRate3 As DataGridViewTextBoxColumn
    Friend WithEvents txtACID As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnUpdate As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtVendorName As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnBatchUpdate As Button
    Friend WithEvents txtNewUrduName As TextBox
    Friend WithEvents txtNewName As TextBox
    Friend WithEvents txtNewModel As TextBox
    Friend WithEvents txtNewCompany As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRV
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
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.txtACID = New System.Windows.Forms.TextBox()
        Me.txtNarration = New System.Windows.Forms.TextBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.dgvCRV = New System.Windows.Forms.DataGridView()
        Me.txtCRVNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ctbSave = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.txtSessionTotal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.txtPBal = New System.Windows.Forms.TextBox()
        Me.txtNBal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ColNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colACID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNarration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvCRV, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'txtACID
        '
        Me.txtACID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtACID.Location = New System.Drawing.Point(187, 72)
        Me.txtACID.Name = "txtACID"
        Me.txtACID.Size = New System.Drawing.Size(87, 23)
        Me.txtACID.TabIndex = 5
        '
        'txtNarration
        '
        Me.txtNarration.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNarration.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtNarration.Location = New System.Drawing.Point(662, 72)
        Me.txtNarration.Name = "txtNarration"
        Me.txtNarration.Size = New System.Drawing.Size(350, 23)
        Me.txtNarration.TabIndex = 9
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(1011, 72)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(123, 23)
        Me.txtAmount.TabIndex = 11
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.dgvCRV.Size = New System.Drawing.Size(1115, 427)
        Me.dgvCRV.TabIndex = 2
        Me.dgvCRV.TabStop = False
        '
        'txtCRVNo
        '
        Me.txtCRVNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCRVNo.Location = New System.Drawing.Point(101, 72)
        Me.txtCRVNo.Name = "txtCRVNo"
        Me.txtCRVNo.Size = New System.Drawing.Size(86, 23)
        Me.txtCRVNo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.OliveDrab
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, -1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1119, 30)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cash Receipt Voucher"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ctbSave
        '
        Me.ctbSave.Location = New System.Drawing.Point(895, 602)
        Me.ctbSave.Name = "ctbSave"
        Me.ctbSave.Size = New System.Drawing.Size(75, 23)
        Me.ctbSave.TabIndex = 12
        Me.ctbSave.Text = "&Save"
        Me.ctbSave.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(1058, 603)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 14
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
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
        Me.Label5.Location = New System.Drawing.Point(659, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Narration"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(1057, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Amount"
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BackColor = System.Drawing.Color.Yellow
        Me.txtCustomerName.Enabled = False
        Me.txtCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCustomerName.ForeColor = System.Drawing.Color.Black
        Me.txtCustomerName.Location = New System.Drawing.Point(269, 72)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(394, 23)
        Me.txtCustomerName.TabIndex = 7
        Me.txtCustomerName.TabStop = False
        '
        'txtSessionTotal
        '
        Me.txtSessionTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtSessionTotal.Location = New System.Drawing.Point(1015, 565)
        Me.txtSessionTotal.Name = "txtSessionTotal"
        Me.txtSessionTotal.ReadOnly = True
        Me.txtSessionTotal.Size = New System.Drawing.Size(118, 29)
        Me.txtSessionTotal.TabIndex = 4
        Me.txtSessionTotal.TabStop = False
        Me.txtSessionTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.btnRefresh.Location = New System.Drawing.Point(976, 602)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 13
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'txtPBal
        '
        Me.txtPBal.BackColor = System.Drawing.Color.Yellow
        Me.txtPBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtPBal.ForeColor = System.Drawing.Color.Black
        Me.txtPBal.Location = New System.Drawing.Point(1011, 50)
        Me.txtPBal.Name = "txtPBal"
        Me.txtPBal.ReadOnly = True
        Me.txtPBal.Size = New System.Drawing.Size(123, 23)
        Me.txtPBal.TabIndex = 15
        Me.txtPBal.TabStop = False
        Me.txtPBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNBal
        '
        Me.txtNBal.BackColor = System.Drawing.Color.Yellow
        Me.txtNBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtNBal.ForeColor = System.Drawing.Color.Black
        Me.txtNBal.Location = New System.Drawing.Point(1011, 94)
        Me.txtNBal.Name = "txtNBal"
        Me.txtNBal.ReadOnly = True
        Me.txtNBal.Size = New System.Drawing.Size(123, 23)
        Me.txtNBal.TabIndex = 15
        Me.txtNBal.TabStop = False
        Me.txtNBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.Location = New System.Drawing.Point(904, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Previous Balance"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.Location = New System.Drawing.Point(933, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Net Balance"
        '
        'ColNo
        '
        Me.ColNo.DataPropertyName = "rn"
        Me.ColNo.HeaderText = "No."
        Me.ColNo.Name = "ColNo"
        Me.ColNo.ReadOnly = True
        Me.ColNo.Width = 40
        '
        'colDate
        '
        Me.colDate.DataPropertyName = "date"
        Me.colDate.HeaderText = "Date"
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
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
        Me.colDoc.Width = 80
        '
        'colACID
        '
        Me.colACID.DataPropertyName = "acid"
        Me.colACID.HeaderText = "ID"
        Me.colACID.Name = "colACID"
        Me.colACID.ReadOnly = True
        Me.colACID.Width = 50
        '
        'colCustomer
        '
        Me.colCustomer.DataPropertyName = "Title"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.colCustomer.DefaultCellStyle = DataGridViewCellStyle3
        Me.colCustomer.HeaderText = "Account Title"
        Me.colCustomer.Name = "colCustomer"
        Me.colCustomer.ReadOnly = True
        Me.colCustomer.Width = 350
        '
        'colNarration
        '
        Me.colNarration.DataPropertyName = "narration"
        Me.colNarration.HeaderText = "Narration"
        Me.colNarration.Name = "colNarration"
        Me.colNarration.ReadOnly = True
        Me.colNarration.Width = 350
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "amount"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle4
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 120
        '
        'CRV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(1154, 630)
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
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvCRV)
        Me.Controls.Add(Me.txtCustomerName)
        Me.Controls.Add(Me.txtSessionTotal)
        Me.Controls.Add(Me.txtNarration)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.txtCRVNo)
        Me.Controls.Add(Me.txtACID)
        Me.Controls.Add(Me.dtp1)
        Me.Name = "CRV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CRV"
        CType(Me.dgvCRV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents txtACID As TextBox
    Friend WithEvents txtNarration As TextBox
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents dgvCRV As DataGridView
    Friend WithEvents txtCRVNo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ctbSave As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents txtSessionTotal As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents txtPBal As TextBox
    Friend WithEvents txtNBal As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ColNo As DataGridViewTextBoxColumn
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents colDoc As DataGridViewTextBoxColumn
    Friend WithEvents colACID As DataGridViewTextBoxColumn
    Friend WithEvents colCustomer As DataGridViewTextBoxColumn
    Friend WithEvents colNarration As DataGridViewTextBoxColumn
    Friend WithEvents colAmount As DataGridViewTextBoxColumn
End Class

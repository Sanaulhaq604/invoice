<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RouteCustomerOrder
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
        Me.txtRoute = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvCustomerOrder = New System.Windows.Forms.DataGridView()
        Me.Colrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRoute = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvCustomerOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Route"
        '
        'txtRoute
        '
        Me.txtRoute.Location = New System.Drawing.Point(64, 39)
        Me.txtRoute.Name = "txtRoute"
        Me.txtRoute.Size = New System.Drawing.Size(100, 20)
        Me.txtRoute.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(183, 37)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "%Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvCustomerOrder
        '
        Me.dgvCustomerOrder.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomerOrder.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCustomerOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomerOrder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Colrno, Me.colRoute, Me.colCustomer, Me.colID})
        Me.dgvCustomerOrder.Location = New System.Drawing.Point(29, 77)
        Me.dgvCustomerOrder.Name = "dgvCustomerOrder"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvCustomerOrder.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCustomerOrder.Size = New System.Drawing.Size(517, 472)
        Me.dgvCustomerOrder.TabIndex = 3
        '
        'Colrno
        '
        Me.Colrno.DataPropertyName = "rno"
        Me.Colrno.HeaderText = "Order"
        Me.Colrno.Name = "Colrno"
        Me.Colrno.Width = 80
        '
        'colRoute
        '
        Me.colRoute.DataPropertyName = "ROUTE"
        Me.colRoute.HeaderText = "Route"
        Me.colRoute.Name = "colRoute"
        Me.colRoute.Visible = False
        '
        'colCustomer
        '
        Me.colCustomer.DataPropertyName = "subsidary"
        Me.colCustomer.HeaderText = "Customer Name"
        Me.colCustomer.Name = "colCustomer"
        Me.colCustomer.ReadOnly = True
        Me.colCustomer.Width = 300
        '
        'colID
        '
        Me.colID.DataPropertyName = "id"
        Me.colID.HeaderText = "Acc. ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Width = 70
        '
        'RouteCustomerOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 561)
        Me.Controls.Add(Me.dgvCustomerOrder)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtRoute)
        Me.Controls.Add(Me.Label1)
        Me.Name = "RouteCustomerOrder"
        Me.Text = "RouteCustomerOrder"
        CType(Me.dgvCustomerOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtRoute As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents dgvCustomerOrder As DataGridView
    Friend WithEvents Colrno As DataGridViewTextBoxColumn
    Friend WithEvents colRoute As DataGridViewTextBoxColumn
    Friend WithEvents colCustomer As DataGridViewTextBoxColumn
    Friend WithEvents colID As DataGridViewTextBoxColumn
End Class

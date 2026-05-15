<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Packing
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.pack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Order = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.scheme = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Product = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pack, Me.Order, Me.scheme, Me.Product, Me.RN})
        Me.DataGridView1.Location = New System.Drawing.Point(27, 69)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(882, 425)
        Me.DataGridView1.TabIndex = 0
        '
        'pack
        '
        Me.pack.HeaderText = "پیک"
        Me.pack.Name = "pack"
        '
        'Order
        '
        Me.Order.HeaderText = "آرڈر"
        Me.Order.Name = "Order"
        '
        'scheme
        '
        Me.scheme.HeaderText = "سکیم"
        Me.scheme.Name = "scheme"
        '
        'Product
        '
        Me.Product.HeaderText = "آئٹم"
        Me.Product.Name = "Product"
        Me.Product.Width = 350
        '
        'RN
        '
        Me.RN.HeaderText = "No"
        Me.RN.Name = "RN"
        Me.RN.Width = 60
        '
        'Packing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 516)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Packing"
        Me.Text = "Packing"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents pack As DataGridViewTextBoxColumn
    Friend WithEvents Order As DataGridViewTextBoxColumn
    Friend WithEvents scheme As DataGridViewTextBoxColumn
    Friend WithEvents Product As DataGridViewTextBoxColumn
    Friend WithEvents RN As DataGridViewTextBoxColumn
End Class

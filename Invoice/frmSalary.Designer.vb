<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalary
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
        Me.dgvSalary = New System.Windows.Forms.DataGridView()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSalary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDays = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCurrentSalary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.txtMonthlySalaryTotal = New System.Windows.Forms.TextBox()
        Me.txtCurrentMonthSalaryTotal = New System.Windows.Forms.TextBox()
        Me.txtDailyTotalSalary = New System.Windows.Forms.TextBox()
        Me.txtDailyPayableSalary = New System.Windows.Forms.TextBox()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvSalary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSalary
        '
        Me.dgvSalary.AllowUserToAddRows = False
        Me.dgvSalary.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSalary.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalary.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colName, Me.colSalary, Me.colDays, Me.colCurrentSalary})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSalary.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvSalary.Location = New System.Drawing.Point(13, 80)
        Me.dgvSalary.Name = "dgvSalary"
        Me.dgvSalary.Size = New System.Drawing.Size(703, 343)
        Me.dgvSalary.TabIndex = 0
        '
        'colID
        '
        Me.colID.DataPropertyName = "id"
        Me.colID.HeaderText = "Account ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Width = 70
        '
        'colName
        '
        Me.colName.DataPropertyName = "subsidary"
        Me.colName.HeaderText = "Employee Name"
        Me.colName.Name = "colName"
        Me.colName.ReadOnly = True
        Me.colName.Width = 300
        '
        'colSalary
        '
        Me.colSalary.DataPropertyName = "salary"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colSalary.DefaultCellStyle = DataGridViewCellStyle2
        Me.colSalary.HeaderText = "Salary"
        Me.colSalary.Name = "colSalary"
        '
        'colDays
        '
        Me.colDays.DataPropertyName = "days"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colDays.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDays.HeaderText = "Days"
        Me.colDays.Name = "colDays"
        Me.colDays.Width = 70
        '
        'colCurrentSalary
        '
        Me.colCurrentSalary.DataPropertyName = "CurrentSalary"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCurrentSalary.DefaultCellStyle = DataGridViewCellStyle4
        Me.colCurrentSalary.HeaderText = "Current Month Salary"
        Me.colCurrentSalary.Name = "colCurrentSalary"
        Me.colCurrentSalary.ReadOnly = True
        '
        'dtpDate
        '
        Me.dtpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(602, 48)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(116, 26)
        Me.dtpDate.TabIndex = 1
        '
        'btnExit
        '
        Me.btnExit.BackgroundImage = Global.Invoice.My.Resources.Resources.door_exit2
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExit.Location = New System.Drawing.Point(283, 429)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(55, 61)
        Me.btnExit.TabIndex = 5
        Me.btnExit.TabStop = False
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'txtMonthlySalaryTotal
        '
        Me.txtMonthlySalaryTotal.BackColor = System.Drawing.Color.Yellow
        Me.txtMonthlySalaryTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtMonthlySalaryTotal.Location = New System.Drawing.Point(430, 425)
        Me.txtMonthlySalaryTotal.Name = "txtMonthlySalaryTotal"
        Me.txtMonthlySalaryTotal.ReadOnly = True
        Me.txtMonthlySalaryTotal.Size = New System.Drawing.Size(100, 26)
        Me.txtMonthlySalaryTotal.TabIndex = 6
        Me.txtMonthlySalaryTotal.TabStop = False
        Me.txtMonthlySalaryTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCurrentMonthSalaryTotal
        '
        Me.txtCurrentMonthSalaryTotal.BackColor = System.Drawing.Color.Yellow
        Me.txtCurrentMonthSalaryTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCurrentMonthSalaryTotal.Location = New System.Drawing.Point(603, 425)
        Me.txtCurrentMonthSalaryTotal.Name = "txtCurrentMonthSalaryTotal"
        Me.txtCurrentMonthSalaryTotal.ReadOnly = True
        Me.txtCurrentMonthSalaryTotal.Size = New System.Drawing.Size(100, 26)
        Me.txtCurrentMonthSalaryTotal.TabIndex = 6
        Me.txtCurrentMonthSalaryTotal.TabStop = False
        Me.txtCurrentMonthSalaryTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDailyTotalSalary
        '
        Me.txtDailyTotalSalary.BackColor = System.Drawing.Color.Yellow
        Me.txtDailyTotalSalary.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDailyTotalSalary.Location = New System.Drawing.Point(430, 457)
        Me.txtDailyTotalSalary.Name = "txtDailyTotalSalary"
        Me.txtDailyTotalSalary.ReadOnly = True
        Me.txtDailyTotalSalary.Size = New System.Drawing.Size(100, 26)
        Me.txtDailyTotalSalary.TabIndex = 6
        Me.txtDailyTotalSalary.TabStop = False
        Me.txtDailyTotalSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDailyPayableSalary
        '
        Me.txtDailyPayableSalary.BackColor = System.Drawing.Color.Yellow
        Me.txtDailyPayableSalary.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDailyPayableSalary.Location = New System.Drawing.Point(603, 457)
        Me.txtDailyPayableSalary.Name = "txtDailyPayableSalary"
        Me.txtDailyPayableSalary.ReadOnly = True
        Me.txtDailyPayableSalary.Size = New System.Drawing.Size(100, 26)
        Me.txtDailyPayableSalary.TabIndex = 6
        Me.txtDailyPayableSalary.TabStop = False
        Me.txtDailyPayableSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPost
        '
        Me.btnPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPost.Location = New System.Drawing.Point(159, 429)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(94, 61)
        Me.btnPost.TabIndex = 7
        Me.btnPost.Text = "&Post JV"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkGreen
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(716, 26)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "SALARY VOUCHER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSalary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 485)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPost)
        Me.Controls.Add(Me.txtCurrentMonthSalaryTotal)
        Me.Controls.Add(Me.txtDailyPayableSalary)
        Me.Controls.Add(Me.txtDailyTotalSalary)
        Me.Controls.Add(Me.txtMonthlySalaryTotal)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.dgvSalary)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSalary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSalary"
        CType(Me.dgvSalary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvSalary As DataGridView
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents colSalary As DataGridViewTextBoxColumn
    Friend WithEvents colDays As DataGridViewTextBoxColumn
    Friend WithEvents colCurrentSalary As DataGridViewTextBoxColumn
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents btnExit As Button
    Friend WithEvents txtMonthlySalaryTotal As TextBox
    Friend WithEvents txtCurrentMonthSalaryTotal As TextBox
    Friend WithEvents txtDailyTotalSalary As TextBox
    Friend WithEvents txtDailyPayableSalary As TextBox
    Friend WithEvents btnPost As Button
    Friend WithEvents Label1 As Label
End Class

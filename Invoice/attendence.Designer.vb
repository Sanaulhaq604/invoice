<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class attendence
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.dgvAttendance = New System.Windows.Forms.DataGridView()
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Time_In = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Time_Out = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Absent = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.btnSave = New System.Windows.Forms.Button()
        CType(Me.dgvAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.Location = New System.Drawing.Point(28, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 17)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "&Date"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(12, 49)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(106, 23)
        Me.DateTimePicker1.TabIndex = 5
        '
        'dgvAttendance
        '
        Me.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAttendance.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmpName, Me.Time_In, Me.Time_Out, Me.Absent})
        Me.dgvAttendance.Location = New System.Drawing.Point(3, 93)
        Me.dgvAttendance.Name = "dgvAttendance"
        Me.dgvAttendance.RowHeadersVisible = False
        Me.dgvAttendance.Size = New System.Drawing.Size(682, 360)
        Me.dgvAttendance.TabIndex = 8
        '
        'EmpName
        '
        Me.EmpName.HeaderText = "Employee Name"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.Width = 250
        '
        'Time_In
        '
        Me.Time_In.HeaderText = "Time In"
        Me.Time_In.Name = "Time_In"
        '
        'Time_Out
        '
        Me.Time_Out.HeaderText = "Time Out"
        Me.Time_Out.Name = "Time_Out"
        '
        'Absent
        '
        Me.Absent.HeaderText = "Absent"
        Me.Absent.Items.AddRange(New Object() {"Present", "Absent", "Late"})
        Me.Absent.Name = "Absent"
        Me.Absent.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Absent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(220, 536)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(123, 23)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'attendence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 571)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dgvAttendance)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "attendence"
        Me.Text = "attendence"
        CType(Me.dgvAttendance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents dgvAttendance As DataGridView
    Friend WithEvents btnSave As Button
    Friend WithEvents EmpName As DataGridViewTextBoxColumn
    Friend WithEvents Time_In As DataGridViewTextBoxColumn
    Friend WithEvents Time_Out As DataGridViewTextBoxColumn
    Friend WithEvents Absent As DataGridViewComboBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttendance
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
        Me.Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Attendance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeIn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeOut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Name, Me.Attendance, Me.TimeIn, Me.TimeOut, Me.Hours})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 62)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(556, 547)
        Me.DataGridView1.TabIndex = 2
        '
        'Name
        '
        Me.Name.HeaderText = "Name"
        Me.Name.Name = "Name"
        '
        'Attendance
        '
        Me.Attendance.HeaderText = "Attendance"
        Me.Attendance.Name = "Attendance"
        '
        'TimeIn
        '
        Me.TimeIn.HeaderText = "Time In"
        Me.TimeIn.Name = "TimeIn"
        '
        'TimeOut
        '
        Me.TimeOut.HeaderText = "Time Out"
        Me.TimeOut.Name = "TimeOut"
        '
        'Hours
        '
        Me.Hours.HeaderText = "Hours"
        Me.Hours.Name = "Hours"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(13, 13)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(114, 26)
        Me.DateTimePicker1.TabIndex = 3
        '
        'frmAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 621)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.DataGridView1)
        'Me.Name = "frmAttendance"
        Me.Text = "frmAttendance"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Name As DataGridViewTextBoxColumn
    Friend WithEvents Attendance As DataGridViewTextBoxColumn
    Friend WithEvents TimeIn As DataGridViewTextBoxColumn
    Friend WithEvents TimeOut As DataGridViewTextBoxColumn
    Friend WithEvents Hours As DataGridViewTextBoxColumn
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class

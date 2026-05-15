<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImportFromExcel
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cmbSheets = New System.Windows.Forms.ComboBox()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtStartingRowNumber = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(13, 13)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1384, 605)
        Me.DataGridView1.TabIndex = 0
        '
        'cmbSheets
        '
        Me.cmbSheets.FormattingEnabled = True
        Me.cmbSheets.Location = New System.Drawing.Point(240, 650)
        Me.cmbSheets.Name = "cmbSheets"
        Me.cmbSheets.Size = New System.Drawing.Size(149, 21)
        Me.cmbSheets.TabIndex = 7
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(80, 625)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(747, 20)
        Me.txtFileName.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(830, 624)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(39, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 629)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "File Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(172, 653)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Sheet Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 653)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Starting Row Number"
        '
        'txtStartingRowNumber
        '
        Me.txtStartingRowNumber.Location = New System.Drawing.Point(123, 650)
        Me.txtStartingRowNumber.Name = "txtStartingRowNumber"
        Me.txtStartingRowNumber.Size = New System.Drawing.Size(33, 20)
        Me.txtStartingRowNumber.TabIndex = 5
        Me.txtStartingRowNumber.Text = "5"
        Me.txtStartingRowNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ImportFromExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1409, 677)
        Me.Controls.Add(Me.txtStartingRowNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.cmbSheets)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "ImportFromExcel"
        Me.Text = "ImportFromExcel"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents cmbSheets As ComboBox
    Friend WithEvents txtFileName As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtStartingRowNumber As TextBox
End Class

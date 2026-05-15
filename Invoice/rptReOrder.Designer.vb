<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptReOrder
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.txtCompany = New System.Windows.Forms.TextBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.txtACID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.CRViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.chkUrdu = New System.Windows.Forms.CheckBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkTitle = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkScheme = New System.Windows.Forms.CheckBox()
        Me.chkName = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(15, 16)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(96, 23)
        Me.DateTimePicker1.TabIndex = 1
        '
        'txtCompany
        '
        Me.txtCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCompany.Location = New System.Drawing.Point(116, 16)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(177, 23)
        Me.txtCompany.TabIndex = 3
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(815, 6)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(76, 41)
        Me.btnGenerate.TabIndex = 6
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'txtACID
        '
        Me.txtACID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtACID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtACID.Location = New System.Drawing.Point(297, 16)
        Me.txtACID.Name = "txtACID"
        Me.txtACID.Size = New System.Drawing.Size(80, 23)
        Me.txtACID.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(170, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Company"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(569, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Vendor"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Red
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnClose.Location = New System.Drawing.Point(1364, 8)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(92, 43)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExport.Location = New System.Drawing.Point(375, 12)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(79, 35)
        Me.btnExport.TabIndex = 3
        Me.btnExport.Text = "&Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'CRViewer
        '
        Me.CRViewer.ActiveViewIndex = -1
        Me.CRViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRViewer.DisplayStatusBar = False
        Me.CRViewer.Location = New System.Drawing.Point(15, 52)
        Me.CRViewer.Name = "CRViewer"
        Me.CRViewer.Size = New System.Drawing.Size(1438, 628)
        Me.CRViewer.TabIndex = 9
        '
        'chkUrdu
        '
        Me.chkUrdu.AutoSize = True
        Me.chkUrdu.Checked = True
        Me.chkUrdu.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUrdu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkUrdu.Location = New System.Drawing.Point(6, 21)
        Me.chkUrdu.Name = "chkUrdu"
        Me.chkUrdu.Size = New System.Drawing.Size(63, 24)
        Me.chkUrdu.TabIndex = 0
        Me.chkUrdu.Text = "Urdu"
        Me.chkUrdu.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.Yellow
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtName.Location = New System.Drawing.Point(379, 16)
        Me.txtName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(431, 23)
        Me.txtName.TabIndex = 11
        Me.txtName.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(306, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Account ID"
        '
        'chkTitle
        '
        Me.chkTitle.AutoSize = True
        Me.chkTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkTitle.Location = New System.Drawing.Point(82, 19)
        Me.chkTitle.Name = "chkTitle"
        Me.chkTitle.Size = New System.Drawing.Size(175, 24)
        Me.chkTitle.TabIndex = 1
        Me.chkTitle.Text = "Account Wise Group"
        Me.chkTitle.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkName)
        Me.GroupBox1.Controls.Add(Me.chkTitle)
        Me.GroupBox1.Controls.Add(Me.chkScheme)
        Me.GroupBox1.Controls.Add(Me.chkUrdu)
        Me.GroupBox1.Controls.Add(Me.btnExport)
        Me.GroupBox1.Location = New System.Drawing.Point(902, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(456, 46)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Export Options"
        '
        'chkScheme
        '
        Me.chkScheme.AutoSize = True
        Me.chkScheme.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkScheme.Location = New System.Drawing.Point(270, 27)
        Me.chkScheme.Name = "chkScheme"
        Me.chkScheme.Size = New System.Drawing.Size(92, 24)
        Me.chkScheme.TabIndex = 2
        Me.chkScheme.Text = "Remarks"
        Me.chkScheme.UseVisualStyleBackColor = True
        '
        'chkName
        '
        Me.chkName.AutoSize = True
        Me.chkName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkName.Location = New System.Drawing.Point(270, 7)
        Me.chkName.Name = "chkName"
        Me.chkName.Size = New System.Drawing.Size(93, 24)
        Me.chkName.TabIndex = 4
        Me.chkName.Text = "Print Title"
        Me.chkName.UseVisualStyleBackColor = True
        '
        'rptReOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1465, 691)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.CRViewer)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.txtACID)
        Me.Controls.Add(Me.txtCompany)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "rptReOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "rptReOrder"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents txtCompany As TextBox
    Friend WithEvents btnGenerate As Button
    Friend WithEvents txtACID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents CRViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkUrdu As CheckBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkTitle As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkScheme As CheckBox
    Friend WithEvents chkName As CheckBox
End Class

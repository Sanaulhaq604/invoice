<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptStock
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.txtCompany = New System.Windows.Forms.TextBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.tbnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rdALL = New System.Windows.Forms.RadioButton()
        Me.rdPositive = New System.Windows.Forms.RadioButton()
        Me.rdNegative = New System.Windows.Forms.RadioButton()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdClaim = New System.Windows.Forms.RadioButton()
        Me.rdFresh = New System.Windows.Forms.RadioButton()
        Me.chkValue = New System.Windows.Forms.CheckBox()
        Me.chkDeadLevel = New System.Windows.Forms.CheckBox()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkUrdu = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(12, 27)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(109, 23)
        Me.DateTimePicker1.TabIndex = 1
        '
        'txtCompany
        '
        Me.txtCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCompany.Location = New System.Drawing.Point(124, 27)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(100, 23)
        Me.txtCompany.TabIndex = 3
        Me.txtCompany.Text = "FIT"
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(884, 15)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(76, 40)
        Me.btnGenerate.TabIndex = 13
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'tbnClose
        '
        Me.tbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.tbnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.tbnClose.Location = New System.Drawing.Point(1044, 15)
        Me.tbnClose.Name = "tbnClose"
        Me.tbnClose.Size = New System.Drawing.Size(76, 40)
        Me.tbnClose.TabIndex = 15
        Me.tbnClose.Text = "&Close"
        Me.tbnClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(42, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(146, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Company"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.DisplayStatusBar = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(25, 70)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1111, 609)
        Me.CrystalReportViewer1.TabIndex = 12
        '
        'txtCategory
        '
        Me.txtCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCategory.Location = New System.Drawing.Point(226, 27)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(84, 23)
        Me.txtCategory.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(249, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Model"
        '
        'rdALL
        '
        Me.rdALL.AutoSize = True
        Me.rdALL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdALL.Location = New System.Drawing.Point(488, 7)
        Me.rdALL.Name = "rdALL"
        Me.rdALL.Size = New System.Drawing.Size(47, 17)
        Me.rdALL.TabIndex = 10
        Me.rdALL.Text = "ALL"
        Me.rdALL.UseVisualStyleBackColor = True
        '
        'rdPositive
        '
        Me.rdPositive.AutoSize = True
        Me.rdPositive.Checked = True
        Me.rdPositive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdPositive.Location = New System.Drawing.Point(488, 24)
        Me.rdPositive.Name = "rdPositive"
        Me.rdPositive.Size = New System.Drawing.Size(91, 17)
        Me.rdPositive.TabIndex = 11
        Me.rdPositive.TabStop = True
        Me.rdPositive.Text = "Above Zero"
        Me.rdPositive.UseVisualStyleBackColor = True
        '
        'rdNegative
        '
        Me.rdNegative.AutoSize = True
        Me.rdNegative.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdNegative.Location = New System.Drawing.Point(488, 41)
        Me.rdNegative.Name = "rdNegative"
        Me.rdNegative.Size = New System.Drawing.Size(92, 17)
        Me.rdNegative.TabIndex = 12
        Me.rdNegative.Text = "Bellow Zero"
        Me.rdNegative.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExport.Location = New System.Drawing.Point(964, 15)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(76, 40)
        Me.btnExport.TabIndex = 14
        Me.btnExport.Text = "&Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkUrdu)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.chkValue)
        Me.GroupBox1.Controls.Add(Me.chkDeadLevel)
        Me.GroupBox1.Controls.Add(Me.rdALL)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.rdPositive)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.rdNegative)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnExport)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.txtCompany)
        Me.GroupBox1.Controls.Add(Me.txtCategory)
        Me.GroupBox1.Controls.Add(Me.tbnClose)
        Me.GroupBox1.Controls.Add(Me.txtLocation)
        Me.GroupBox1.Controls.Add(Me.txtProductName)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnGenerate)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1124, 57)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdClaim)
        Me.GroupBox2.Controls.Add(Me.rdFresh)
        Me.GroupBox2.Location = New System.Drawing.Point(576, 7)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(120, 47)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        '
        'rdClaim
        '
        Me.rdClaim.AutoSize = True
        Me.rdClaim.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdClaim.Location = New System.Drawing.Point(8, 28)
        Me.rdClaim.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rdClaim.Name = "rdClaim"
        Me.rdClaim.Size = New System.Drawing.Size(110, 21)
        Me.rdClaim.TabIndex = 19
        Me.rdClaim.Text = "Claim Stock"
        Me.rdClaim.UseVisualStyleBackColor = True
        '
        'rdFresh
        '
        Me.rdFresh.AutoSize = True
        Me.rdFresh.Checked = True
        Me.rdFresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdFresh.Location = New System.Drawing.Point(8, 5)
        Me.rdFresh.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rdFresh.Name = "rdFresh"
        Me.rdFresh.Size = New System.Drawing.Size(112, 21)
        Me.rdFresh.TabIndex = 18
        Me.rdFresh.TabStop = True
        Me.rdFresh.Text = "Fresh Stock"
        Me.rdFresh.UseVisualStyleBackColor = True
        '
        'chkValue
        '
        Me.chkValue.AutoSize = True
        Me.chkValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkValue.Location = New System.Drawing.Point(697, 1)
        Me.chkValue.Name = "chkValue"
        Me.chkValue.Size = New System.Drawing.Size(104, 17)
        Me.chkValue.TabIndex = 17
        Me.chkValue.Text = "Include Value"
        Me.chkValue.UseVisualStyleBackColor = True
        '
        'chkDeadLevel
        '
        Me.chkDeadLevel.Checked = True
        Me.chkDeadLevel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDeadLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkDeadLevel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkDeadLevel.Location = New System.Drawing.Point(697, 17)
        Me.chkDeadLevel.Name = "chkDeadLevel"
        Me.chkDeadLevel.Size = New System.Drawing.Size(175, 20)
        Me.chkDeadLevel.TabIndex = 16
        Me.chkDeadLevel.Text = "Include Dead Level Stock"
        Me.chkDeadLevel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.chkDeadLevel.UseVisualStyleBackColor = True
        '
        'txtLocation
        '
        Me.txtLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(399, 27)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(81, 23)
        Me.txtLocation.TabIndex = 9
        '
        'txtProductName
        '
        Me.txtProductName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtProductName.Location = New System.Drawing.Point(313, 27)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(84, 23)
        Me.txtProductName.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(412, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Location"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(336, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Name"
        '
        'chkUrdu
        '
        Me.chkUrdu.AutoSize = True
        Me.chkUrdu.Checked = True
        Me.chkUrdu.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUrdu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkUrdu.Location = New System.Drawing.Point(697, 39)
        Me.chkUrdu.Name = "chkUrdu"
        Me.chkUrdu.Size = New System.Drawing.Size(93, 17)
        Me.chkUrdu.TabIndex = 21
        Me.chkUrdu.Text = "Export Urdu"
        Me.chkUrdu.UseVisualStyleBackColor = True
        '
        'rptStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.tbnClose
        Me.ClientSize = New System.Drawing.Size(1149, 693)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "rptStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "rptStock"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents txtCompany As TextBox
    Friend WithEvents btnGenerate As Button
    Friend WithEvents tbnClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents txtCategory As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents rdALL As RadioButton
    Friend WithEvents rdPositive As RadioButton
    Friend WithEvents rdNegative As RadioButton
    Friend WithEvents btnExport As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents chkDeadLevel As CheckBox
    Friend WithEvents chkValue As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rdClaim As RadioButton
    Friend WithEvents rdFresh As RadioButton
    Friend WithEvents chkUrdu As CheckBox
End Class

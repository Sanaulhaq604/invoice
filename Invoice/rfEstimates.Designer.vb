<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class rfEstimates
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
        Me.txtDN = New System.Windows.Forms.TextBox()
        Me.txtLDN = New System.Windows.Forms.TextBox()
        Me.txtRN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.rdFIT = New System.Windows.Forms.RadioButton()
        Me.rdLOCAL = New System.Windows.Forms.RadioButton()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.rdALL = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdSeparat = New System.Windows.Forms.RadioButton()
        Me.rdSummary = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdAlphabet = New System.Windows.Forms.RadioButton()
        Me.rdRackSort = New System.Windows.Forms.RadioButton()
        Me.rdIDSort = New System.Windows.Forms.RadioButton()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rdOptionAll = New System.Windows.Forms.RadioButton()
        Me.rdOptionPending = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDN
        '
        Me.txtDN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDN.Location = New System.Drawing.Point(133, 31)
        Me.txtDN.Name = "txtDN"
        Me.txtDN.Size = New System.Drawing.Size(60, 23)
        Me.txtDN.TabIndex = 3
        Me.txtDN.TabStop = False
        Me.txtDN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLDN
        '
        Me.txtLDN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtLDN.Location = New System.Drawing.Point(133, 51)
        Me.txtLDN.Name = "txtLDN"
        Me.txtLDN.Size = New System.Drawing.Size(60, 23)
        Me.txtLDN.TabIndex = 5
        Me.txtLDN.TabStop = False
        Me.txtLDN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRN
        '
        Me.txtRN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtRN.Location = New System.Drawing.Point(133, 8)
        Me.txtRN.Name = "txtRN"
        Me.txtRN.Size = New System.Drawing.Size(60, 23)
        Me.txtRN.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Startin&g Estimate #"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "E&nding Estimate #"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "&Route #"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Red
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.Location = New System.Drawing.Point(1208, 56)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(85, 76)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "&Close"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnDisplay
        '
        Me.btnDisplay.BackColor = System.Drawing.Color.Green
        Me.btnDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnDisplay.ForeColor = System.Drawing.Color.White
        Me.btnDisplay.Location = New System.Drawing.Point(953, 56)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(85, 76)
        Me.btnDisplay.TabIndex = 5
        Me.btnDisplay.Text = "&Display"
        Me.btnDisplay.UseVisualStyleBackColor = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.DisplayStatusBar = False
        Me.CrystalReportViewer1.Enabled = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(11, 137)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowCopyButton = False
        Me.CrystalReportViewer1.ShowExportButton = False
        Me.CrystalReportViewer1.ShowLogo = False
        Me.CrystalReportViewer1.ShowParameterPanelButton = False
        Me.CrystalReportViewer1.ShowPrintButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1280, 548)
        Me.CrystalReportViewer1.TabIndex = 6
        Me.CrystalReportViewer1.TabStop = False
        '
        'rdFIT
        '
        Me.rdFIT.AutoSize = True
        Me.rdFIT.Location = New System.Drawing.Point(8, 33)
        Me.rdFIT.Name = "rdFIT"
        Me.rdFIT.Size = New System.Drawing.Size(117, 21)
        Me.rdFIT.TabIndex = 1
        Me.rdFIT.Text = "&Focused Items"
        Me.rdFIT.UseVisualStyleBackColor = True
        '
        'rdLOCAL
        '
        Me.rdLOCAL.AutoSize = True
        Me.rdLOCAL.Location = New System.Drawing.Point(8, 52)
        Me.rdLOCAL.Name = "rdLOCAL"
        Me.rdLOCAL.Size = New System.Drawing.Size(103, 21)
        Me.rdLOCAL.TabIndex = 2
        Me.rdLOCAL.Text = "&Other Items "
        Me.rdLOCAL.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Enabled = False
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExport.Location = New System.Drawing.Point(1123, 56)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(85, 76)
        Me.btnExport.TabIndex = 7
        Me.btnExport.Text = "&Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'rdALL
        '
        Me.rdALL.AutoSize = True
        Me.rdALL.Location = New System.Drawing.Point(125, 31)
        Me.rdALL.Name = "rdALL"
        Me.rdALL.Size = New System.Drawing.Size(108, 21)
        Me.rdALL.TabIndex = 3
        Me.rdALL.Text = "&Combined All"
        Me.rdALL.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtDN)
        Me.GroupBox1.Controls.Add(Me.txtLDN)
        Me.GroupBox1.Controls.Add(Me.txtRN)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(239, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(194, 73)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdSeparat)
        Me.GroupBox2.Controls.Add(Me.rdSummary)
        Me.GroupBox2.Controls.Add(Me.rdFIT)
        Me.GroupBox2.Controls.Add(Me.rdLOCAL)
        Me.GroupBox2.Controls.Add(Me.rdALL)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(577, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(260, 73)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'rdSeparat
        '
        Me.rdSeparat.AutoSize = True
        Me.rdSeparat.Checked = True
        Me.rdSeparat.Location = New System.Drawing.Point(8, 14)
        Me.rdSeparat.Name = "rdSeparat"
        Me.rdSeparat.Size = New System.Drawing.Size(95, 21)
        Me.rdSeparat.TabIndex = 0
        Me.rdSeparat.TabStop = True
        Me.rdSeparat.Text = "&Separat All"
        Me.rdSeparat.UseVisualStyleBackColor = True
        '
        'rdSummary
        '
        Me.rdSummary.AutoSize = True
        Me.rdSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdSummary.Location = New System.Drawing.Point(125, 52)
        Me.rdSummary.Name = "rdSummary"
        Me.rdSummary.Size = New System.Drawing.Size(136, 21)
        Me.rdSummary.TabIndex = 4
        Me.rdSummary.Text = "Local Summar&y"
        Me.rdSummary.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdAlphabet)
        Me.GroupBox3.Controls.Add(Me.rdRackSort)
        Me.GroupBox3.Controls.Add(Me.rdIDSort)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(838, 58)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(116, 73)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'rdAlphabet
        '
        Me.rdAlphabet.AutoSize = True
        Me.rdAlphabet.Location = New System.Drawing.Point(7, 51)
        Me.rdAlphabet.Name = "rdAlphabet"
        Me.rdAlphabet.Size = New System.Drawing.Size(103, 21)
        Me.rdAlphabet.TabIndex = 2
        Me.rdAlphabet.Text = "Alphabetical"
        Me.rdAlphabet.UseVisualStyleBackColor = True
        '
        'rdRackSort
        '
        Me.rdRackSort.AutoSize = True
        Me.rdRackSort.Checked = True
        Me.rdRackSort.Location = New System.Drawing.Point(7, 32)
        Me.rdRackSort.Name = "rdRackSort"
        Me.rdRackSort.Size = New System.Drawing.Size(112, 21)
        Me.rdRackSort.TabIndex = 1
        Me.rdRackSort.TabStop = True
        Me.rdRackSort.Text = "Rack Number"
        Me.rdRackSort.UseVisualStyleBackColor = True
        '
        'rdIDSort
        '
        Me.rdIDSort.AutoSize = True
        Me.rdIDSort.Location = New System.Drawing.Point(7, 14)
        Me.rdIDSort.Name = "rdIDSort"
        Me.rdIDSort.Size = New System.Drawing.Size(99, 21)
        Me.rdIDSort.TabIndex = 0
        Me.rdIDSort.Text = "Feed Order"
        Me.rdIDSort.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Enabled = False
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(1038, 56)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(85, 76)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "&Prin&t"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Image = Global.Invoice.My.Resources.Resources.DESKTOP2
        Me.Label4.Location = New System.Drawing.Point(4, -1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1296, 40)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Daily Estimates Packing List"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdOptionAll)
        Me.GroupBox4.Controls.Add(Me.rdOptionPending)
        Me.GroupBox4.Location = New System.Drawing.Point(434, 58)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(140, 73)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'rdOptionAll
        '
        Me.rdOptionAll.AutoSize = True
        Me.rdOptionAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdOptionAll.Location = New System.Drawing.Point(6, 40)
        Me.rdOptionAll.Name = "rdOptionAll"
        Me.rdOptionAll.Size = New System.Drawing.Size(78, 21)
        Me.rdOptionAll.TabIndex = 1
        Me.rdOptionAll.Text = "&All Items"
        Me.rdOptionAll.UseVisualStyleBackColor = True
        '
        'rdOptionPending
        '
        Me.rdOptionPending.AutoSize = True
        Me.rdOptionPending.Checked = True
        Me.rdOptionPending.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdOptionPending.Location = New System.Drawing.Point(6, 14)
        Me.rdOptionPending.Name = "rdOptionPending"
        Me.rdOptionPending.Size = New System.Drawing.Size(115, 21)
        Me.rdOptionPending.TabIndex = 0
        Me.rdOptionPending.TabStop = True
        Me.rdOptionPending.Text = "&Pending Items"
        Me.rdOptionPending.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.dtpEnd)
        Me.GroupBox5.Controls.Add(Me.dtpStart)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(13, 58)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(227, 73)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 17)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Ending Date"
        '
        'dtpEnd
        '
        Me.dtpEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEnd.Location = New System.Drawing.Point(110, 47)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(113, 23)
        Me.dtpEnd.TabIndex = 3
        '
        'dtpStart
        '
        Me.dtpStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStart.Location = New System.Drawing.Point(110, 19)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(113, 23)
        Me.dtpStart.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Starting Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(437, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(135, 17)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "ITEM SELECTION"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(620, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(174, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "COMPANY SELECTION"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(56, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 17)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "DATE SELECTION"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(249, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(174, 17)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "VOUCHER SELECTION"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(871, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 17)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "SORT"
        '
        'rfEstimates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(1302, 686)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnDisplay)
        Me.Controls.Add(Me.btnExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "rfEstimates"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "rfEstimates"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtDN As TextBox
    Friend WithEvents txtLDN As TextBox
    Friend WithEvents txtRN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnDisplay As Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents rdFIT As RadioButton
    Friend WithEvents rdLOCAL As RadioButton
    Friend WithEvents btnExport As Button
    Friend WithEvents rdALL As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rdAlphabet As RadioButton
    Friend WithEvents rdRackSort As RadioButton
    Friend WithEvents rdIDSort As RadioButton
    Friend WithEvents rdSummary As RadioButton
    Friend WithEvents btnPrint As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents rdOptionAll As RadioButton
    Friend WithEvents rdOptionPending As RadioButton
    Friend WithEvents rdSeparat As RadioButton
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents dtpStart As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpEnd As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
End Class

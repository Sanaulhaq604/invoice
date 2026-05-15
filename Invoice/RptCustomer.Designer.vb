<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptCustomer
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
        Me.txtCustomerID = New System.Windows.Forms.TextBox()
        Me.DTPStart = New System.Windows.Forms.DateTimePicker()
        Me.DTPEnd = New System.Windows.Forms.DateTimePicker()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtCompany = New System.Windows.Forms.TextBox()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.txtrdate = New System.Windows.Forms.TextBox()
        Me.lblrDate = New System.Windows.Forms.Label()
        Me.cmdChangeRunsDate = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.lblMobile = New System.Windows.Forms.Label()
        Me.txtMobile = New System.Windows.Forms.MaskedTextBox()
        Me.chkReturns = New System.Windows.Forms.CheckBox()
        Me.txtProduct = New System.Windows.Forms.TextBox()
        Me.lblProduct = New System.Windows.Forms.Label()
        Me.txtDiscP2 = New System.Windows.Forms.TextBox()
        Me.lblDisc = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtCustomerID
        '
        Me.txtCustomerID.Location = New System.Drawing.Point(197, 27)
        Me.txtCustomerID.Name = "txtCustomerID"
        Me.txtCustomerID.Size = New System.Drawing.Size(56, 20)
        Me.txtCustomerID.TabIndex = 5
        '
        'DTPStart
        '
        Me.DTPStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPStart.Location = New System.Drawing.Point(13, 27)
        Me.DTPStart.Name = "DTPStart"
        Me.DTPStart.Size = New System.Drawing.Size(87, 20)
        Me.DTPStart.TabIndex = 1
        '
        'DTPEnd
        '
        Me.DTPEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPEnd.Location = New System.Drawing.Point(104, 27)
        Me.DTPEnd.Name = "DTPEnd"
        Me.DTPEnd.Size = New System.Drawing.Size(87, 20)
        Me.DTPEnd.TabIndex = 3
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BackColor = System.Drawing.Color.Yellow
        Me.txtCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCustomerName.Location = New System.Drawing.Point(254, 26)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.ReadOnly = True
        Me.txtCustomerName.Size = New System.Drawing.Size(402, 23)
        Me.txtCustomerName.TabIndex = 0
        Me.txtCustomerName.TabStop = False
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblStart.Location = New System.Drawing.Point(11, 7)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(91, 17)
        Me.lblStart.TabIndex = 0
        Me.lblStart.Text = "&Starting Date"
        '
        'lblEnd
        '
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblEnd.Location = New System.Drawing.Point(104, 7)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(86, 17)
        Me.lblEnd.TabIndex = 2
        Me.lblEnd.Text = "&Ending Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(183, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Customer &ID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(401, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 17)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Customer &Name"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.DisplayStatusBar = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(13, 88)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowExportButton = False
        Me.CrystalReportViewer1.ShowLogo = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1307, 499)
        Me.CrystalReportViewer1.TabIndex = 7
        Me.CrystalReportViewer1.TabStop = False
        Me.CrystalReportViewer1.ToolPanelWidth = 112
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(13, 53)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(407, 30)
        Me.btnGenerate.TabIndex = 11
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnClose.Location = New System.Drawing.Point(909, 55)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(407, 30)
        Me.btnClose.TabIndex = 13
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtCompany
        '
        Me.txtCompany.Location = New System.Drawing.Point(792, 27)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(88, 20)
        Me.txtCompany.TabIndex = 7
        Me.txtCompany.TabStop = False
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblCompany.Location = New System.Drawing.Point(803, 7)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(67, 17)
        Me.lblCompany.TabIndex = 6
        Me.lblCompany.Text = "&Company"
        '
        'txtrdate
        '
        Me.txtrdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtrdate.Location = New System.Drawing.Point(1050, 21)
        Me.txtrdate.Name = "txtrdate"
        Me.txtrdate.ReadOnly = True
        Me.txtrdate.Size = New System.Drawing.Size(89, 26)
        Me.txtrdate.TabIndex = 7
        Me.txtrdate.TabStop = False
        '
        'lblrDate
        '
        Me.lblrDate.AutoSize = True
        Me.lblrDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblrDate.Location = New System.Drawing.Point(1069, 4)
        Me.lblrDate.Name = "lblrDate"
        Me.lblrDate.Size = New System.Drawing.Size(59, 17)
        Me.lblrDate.TabIndex = 6
        Me.lblrDate.Text = "R.DA&TE"
        '
        'cmdChangeRunsDate
        '
        Me.cmdChangeRunsDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmdChangeRunsDate.Location = New System.Drawing.Point(1140, 22)
        Me.cmdChangeRunsDate.Name = "cmdChangeRunsDate"
        Me.cmdChangeRunsDate.Size = New System.Drawing.Size(79, 27)
        Me.cmdChangeRunsDate.TabIndex = 9
        Me.cmdChangeRunsDate.TabStop = False
        Me.cmdChangeRunsDate.Text = "&Update"
        Me.cmdChangeRunsDate.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExport.Location = New System.Drawing.Point(458, 55)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(407, 30)
        Me.btnExport.TabIndex = 12
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'lblMobile
        '
        Me.lblMobile.AutoSize = True
        Me.lblMobile.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblMobile.Location = New System.Drawing.Point(923, 4)
        Me.lblMobile.Name = "lblMobile"
        Me.lblMobile.Size = New System.Drawing.Size(49, 17)
        Me.lblMobile.TabIndex = 8
        Me.lblMobile.Text = "&Mobile"
        '
        'txtMobile
        '
        Me.txtMobile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtMobile.Location = New System.Drawing.Point(884, 24)
        Me.txtMobile.Mask = "0000 0000000"
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(112, 26)
        Me.txtMobile.TabIndex = 9
        Me.txtMobile.TabStop = False
        '
        'chkReturns
        '
        Me.chkReturns.AutoSize = True
        Me.chkReturns.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkReturns.Location = New System.Drawing.Point(1237, 24)
        Me.chkReturns.Name = "chkReturns"
        Me.chkReturns.Size = New System.Drawing.Size(77, 21)
        Me.chkReturns.TabIndex = 13
        Me.chkReturns.Text = "&Returns"
        Me.chkReturns.UseVisualStyleBackColor = True
        '
        'txtProduct
        '
        Me.txtProduct.Location = New System.Drawing.Point(662, 27)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Size = New System.Drawing.Size(127, 20)
        Me.txtProduct.TabIndex = 7
        Me.txtProduct.TabStop = False
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblProduct.Location = New System.Drawing.Point(676, 7)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(98, 17)
        Me.lblProduct.TabIndex = 6
        Me.lblProduct.Text = "&Product Name"
        '
        'txtDiscP2
        '
        Me.txtDiscP2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDiscP2.Location = New System.Drawing.Point(1002, 22)
        Me.txtDiscP2.Name = "txtDiscP2"
        Me.txtDiscP2.Size = New System.Drawing.Size(41, 26)
        Me.txtDiscP2.TabIndex = 10
        '
        'lblDisc
        '
        Me.lblDisc.AutoSize = True
        Me.lblDisc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDisc.Location = New System.Drawing.Point(999, 2)
        Me.lblDisc.Name = "lblDisc"
        Me.lblDisc.Size = New System.Drawing.Size(43, 17)
        Me.lblDisc.TabIndex = 8
        Me.lblDisc.Text = "Disc2"
        '
        'RptCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1340, 600)
        Me.Controls.Add(Me.txtDiscP2)
        Me.Controls.Add(Me.chkReturns)
        Me.Controls.Add(Me.txtMobile)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.cmdChangeRunsDate)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblrDate)
        Me.Controls.Add(Me.lblDisc)
        Me.Controls.Add(Me.lblMobile)
        Me.Controls.Add(Me.lblProduct)
        Me.Controls.Add(Me.lblCompany)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblEnd)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.DTPEnd)
        Me.Controls.Add(Me.txtrdate)
        Me.Controls.Add(Me.DTPStart)
        Me.Controls.Add(Me.txtProduct)
        Me.Controls.Add(Me.txtCompany)
        Me.Controls.Add(Me.txtCustomerName)
        Me.Controls.Add(Me.txtCustomerID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RptCustomer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCustomerID As TextBox
    Friend WithEvents DTPStart As DateTimePicker
    Friend WithEvents DTPEnd As DateTimePicker
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents lblStart As Label
    Friend WithEvents lblEnd As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnGenerate As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents txtCompany As TextBox
    Friend WithEvents lblCompany As Label
    Friend WithEvents txtrdate As TextBox
    Friend WithEvents lblrDate As Label
    Friend WithEvents cmdChangeRunsDate As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents lblMobile As Label
    Friend WithEvents txtMobile As MaskedTextBox
    Friend WithEvents chkReturns As CheckBox
    Friend WithEvents txtProduct As TextBox
    Friend WithEvents lblProduct As Label
    Friend WithEvents txtDiscP2 As TextBox
    Friend WithEvents lblDisc As Label
End Class

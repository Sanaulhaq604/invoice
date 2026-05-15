<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRecovery
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecovery))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvRecovery = New System.Windows.Forms.DataGridView()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.btnCRV = New System.Windows.Forms.Button()
        Me.btnBRV = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.brnRefresh = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.chkAutoUpdate = New System.Windows.Forms.CheckBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.chkDateWise = New System.Windows.Forms.CheckBox()
        Me.dtpDateChange = New System.Windows.Forms.DateTimePicker()
        Me.lblDateChange = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ctnClose = New System.Windows.Forms.Button()
        Me.lblAmountChange = New System.Windows.Forms.Label()
        Me.txtAmountChgange = New System.Windows.Forms.TextBox()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EntryTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Route = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Doc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNarration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvRecovery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvRecovery
        '
        Me.dgvRecovery.AllowUserToAddRows = False
        Me.dgvRecovery.AllowUserToDeleteRows = False
        Me.dgvRecovery.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRecovery.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRecovery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecovery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDate, Me.EntryTime, Me.Route, Me.Type, Me.Doc, Me.ACID, Me.colName, Me.colNarration, Me.Amount})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRecovery.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvRecovery.Location = New System.Drawing.Point(183, 48)
        Me.dgvRecovery.Name = "dgvRecovery"
        Me.dgvRecovery.RowHeadersWidth = 51
        Me.dgvRecovery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecovery.Size = New System.Drawing.Size(1258, 539)
        Me.dgvRecovery.TabIndex = 1
        '
        'TreeView1
        '
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TreeView1.Location = New System.Drawing.Point(6, 48)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(178, 539)
        Me.TreeView1.TabIndex = 2
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(1252, 589)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(116, 29)
        Me.txtTotal.TabIndex = 3
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCRV
        '
        Me.btnCRV.BackColor = System.Drawing.Color.LightGreen
        Me.btnCRV.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnCRV.Location = New System.Drawing.Point(573, 593)
        Me.btnCRV.Name = "btnCRV"
        Me.btnCRV.Size = New System.Drawing.Size(134, 60)
        Me.btnCRV.TabIndex = 4
        Me.btnCRV.Text = "Post Selected Cash Receipt"
        Me.btnCRV.UseVisualStyleBackColor = False
        '
        'btnBRV
        '
        Me.btnBRV.BackColor = System.Drawing.Color.Aquamarine
        Me.btnBRV.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnBRV.Location = New System.Drawing.Point(707, 593)
        Me.btnBRV.Name = "btnBRV"
        Me.btnBRV.Size = New System.Drawing.Size(134, 60)
        Me.btnBRV.TabIndex = 4
        Me.btnBRV.Text = "Post Selected Bank Receipt"
        Me.btnBRV.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(1008, 591)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(238, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Total For Selected Vouchers"
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Red
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(841, 593)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(134, 60)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "Delete Selected Voichers"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'brnRefresh
        '
        Me.brnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.brnRefresh.Location = New System.Drawing.Point(437, 593)
        Me.brnRefresh.Name = "brnRefresh"
        Me.brnRefresh.Size = New System.Drawing.Size(136, 60)
        Me.brnRefresh.TabIndex = 9
        Me.brnRefresh.Text = "Refresh Data"
        Me.brnRefresh.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 60000
        '
        'chkAutoUpdate
        '
        Me.chkAutoUpdate.AutoSize = True
        Me.chkAutoUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkAutoUpdate.Location = New System.Drawing.Point(13, 612)
        Me.chkAutoUpdate.Name = "chkAutoUpdate"
        Me.chkAutoUpdate.Size = New System.Drawing.Size(106, 21)
        Me.chkAutoUpdate.TabIndex = 10
        Me.chkAutoUpdate.Text = "Auto Update"
        Me.chkAutoUpdate.UseVisualStyleBackColor = True
        Me.chkAutoUpdate.Visible = False
        '
        'btnSelect
        '
        Me.btnSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnSelect.Location = New System.Drawing.Point(1268, 620)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(100, 43)
        Me.btnSelect.TabIndex = 11
        Me.btnSelect.Text = "Toggle Selection"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'chkDateWise
        '
        Me.chkDateWise.AutoSize = True
        Me.chkDateWise.Checked = True
        Me.chkDateWise.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDateWise.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkDateWise.Location = New System.Drawing.Point(13, 638)
        Me.chkDateWise.Name = "chkDateWise"
        Me.chkDateWise.Size = New System.Drawing.Size(92, 21)
        Me.chkDateWise.TabIndex = 12
        Me.chkDateWise.Text = "Date Wise"
        Me.chkDateWise.UseVisualStyleBackColor = True
        '
        'dtpDateChange
        '
        Me.dtpDateChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dtpDateChange.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateChange.Location = New System.Drawing.Point(118, 624)
        Me.dtpDateChange.Name = "dtpDateChange"
        Me.dtpDateChange.Size = New System.Drawing.Size(118, 26)
        Me.dtpDateChange.TabIndex = 13
        Me.dtpDateChange.Visible = False
        '
        'lblDateChange
        '
        Me.lblDateChange.AutoSize = True
        Me.lblDateChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDateChange.Location = New System.Drawing.Point(122, 602)
        Me.lblDateChange.Name = "lblDateChange"
        Me.lblDateChange.Size = New System.Drawing.Size(104, 20)
        Me.lblDateChange.TabIndex = 14
        Me.lblDateChange.Text = "Date Change"
        Me.lblDateChange.Visible = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1453, 32)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Recovery Confirmation"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ctnClose
        '
        Me.ctnClose.BackColor = System.Drawing.Color.White
        Me.ctnClose.BackgroundImage = Global.Invoice.My.Resources.Resources.door_exit1
        Me.ctnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ctnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ctnClose.ForeColor = System.Drawing.Color.Red
        Me.ctnClose.Location = New System.Drawing.Point(1371, 591)
        Me.ctnClose.Name = "ctnClose"
        Me.ctnClose.Size = New System.Drawing.Size(74, 60)
        Me.ctnClose.TabIndex = 5
        Me.ctnClose.UseVisualStyleBackColor = False
        '
        'lblAmountChange
        '
        Me.lblAmountChange.AutoSize = True
        Me.lblAmountChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblAmountChange.Location = New System.Drawing.Point(266, 602)
        Me.lblAmountChange.Name = "lblAmountChange"
        Me.lblAmountChange.Size = New System.Drawing.Size(125, 20)
        Me.lblAmountChange.TabIndex = 14
        Me.lblAmountChange.Text = "Amount Change"
        Me.lblAmountChange.Visible = False
        '
        'txtAmountChgange
        '
        Me.txtAmountChgange.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtAmountChgange.Location = New System.Drawing.Point(270, 625)
        Me.txtAmountChgange.Name = "txtAmountChgange"
        Me.txtAmountChgange.Size = New System.Drawing.Size(109, 26)
        Me.txtAmountChgange.TabIndex = 15
        Me.txtAmountChgange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAmountChgange.Visible = False
        '
        'colDate
        '
        Me.colDate.DataPropertyName = "Date"
        Me.colDate.HeaderText = "Date"
        Me.colDate.MinimumWidth = 6
        Me.colDate.Name = "colDate"
        Me.colDate.Width = 80
        '
        'EntryTime
        '
        Me.EntryTime.DataPropertyName = "EntryTime"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.EntryTime.DefaultCellStyle = DataGridViewCellStyle2
        Me.EntryTime.HeaderText = "Entry Time"
        Me.EntryTime.MinimumWidth = 6
        Me.EntryTime.Name = "EntryTime"
        Me.EntryTime.Width = 60
        '
        'Route
        '
        Me.Route.DataPropertyName = "Route"
        Me.Route.HeaderText = "Route"
        Me.Route.MinimumWidth = 6
        Me.Route.Name = "Route"
        Me.Route.Width = 125
        '
        'Type
        '
        Me.Type.DataPropertyName = "Type"
        Me.Type.HeaderText = "Type"
        Me.Type.MinimumWidth = 6
        Me.Type.Name = "Type"
        Me.Type.Width = 60
        '
        'Doc
        '
        Me.Doc.DataPropertyName = "Doc"
        Me.Doc.HeaderText = "Voucher"
        Me.Doc.MinimumWidth = 6
        Me.Doc.Name = "Doc"
        Me.Doc.Width = 80
        '
        'ACID
        '
        Me.ACID.DataPropertyName = "acid"
        Me.ACID.HeaderText = "ID"
        Me.ACID.MinimumWidth = 6
        Me.ACID.Name = "ACID"
        Me.ACID.Width = 60
        '
        'colName
        '
        Me.colName.DataPropertyName = "Title"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.colName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colName.HeaderText = "Account Title"
        Me.colName.MinimumWidth = 6
        Me.colName.Name = "colName"
        Me.colName.Width = 350
        '
        'colNarration
        '
        Me.colNarration.DataPropertyName = "Narration"
        Me.colNarration.HeaderText = "Narration"
        Me.colNarration.MinimumWidth = 6
        Me.colNarration.Name = "colNarration"
        Me.colNarration.Width = 250
        '
        'Amount
        '
        Me.Amount.DataPropertyName = "amount"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.Format = "N0"
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle4
        Me.Amount.HeaderText = "Amount"
        Me.Amount.MinimumWidth = 6
        Me.Amount.Name = "Amount"
        Me.Amount.Width = 125
        '
        'frmRecovery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1453, 664)
        Me.Controls.Add(Me.txtAmountChgange)
        Me.Controls.Add(Me.lblAmountChange)
        Me.Controls.Add(Me.lblDateChange)
        Me.Controls.Add(Me.dtpDateChange)
        Me.Controls.Add(Me.chkDateWise)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.chkAutoUpdate)
        Me.Controls.Add(Me.brnRefresh)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ctnClose)
        Me.Controls.Add(Me.btnBRV)
        Me.Controls.Add(Me.btnCRV)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.dgvRecovery)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRecovery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmRecovery"
        CType(Me.dgvRecovery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvRecovery As DataGridView
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents btnCRV As Button
    Friend WithEvents btnBRV As Button
    Friend WithEvents ctnClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents brnRefresh As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents chkAutoUpdate As CheckBox
    Friend WithEvents Timer2 As Timer
    Friend WithEvents btnSelect As Button
    Friend WithEvents chkDateWise As CheckBox
    Friend WithEvents dtpDateChange As DateTimePicker
    Friend WithEvents lblDateChange As Label
    Friend WithEvents lblAmountChange As Label
    Friend WithEvents txtAmountChgange As TextBox
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents EntryTime As DataGridViewTextBoxColumn
    Friend WithEvents Route As DataGridViewTextBoxColumn
    Friend WithEvents Type As DataGridViewTextBoxColumn
    Friend WithEvents Doc As DataGridViewTextBoxColumn
    Friend WithEvents ACID As DataGridViewTextBoxColumn
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents colNarration As DataGridViewTextBoxColumn
    Friend WithEvents Amount As DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJV
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDocNumber = New System.Windows.Forms.TextBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.dgvJV = New System.Windows.Forms.DataGridView()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNarration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDebit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.gbItems = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCredit = New System.Windows.Forms.TextBox()
        Me.txtDebit = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNarration = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPreviousBalance = New System.Windows.Forms.TextBox()
        Me.txtAccountTitle = New System.Windows.Forms.TextBox()
        Me.txtACID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtTotalDebit = New System.Windows.Forms.TextBox()
        Me.txtTotalCredit = New System.Windows.Forms.TextBox()
        Me.txtDifference = New System.Windows.Forms.TextBox()
        Me.lblChanges = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.dgvJV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbItems.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(202, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Date"
        '
        'txtDocNumber
        '
        Me.txtDocNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDocNumber.Location = New System.Drawing.Point(107, 38)
        Me.txtDocNumber.Name = "txtDocNumber"
        Me.txtDocNumber.Size = New System.Drawing.Size(74, 26)
        Me.txtDocNumber.TabIndex = 1
        Me.txtDocNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtpDate
        '
        Me.dtpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(255, 39)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(101, 26)
        Me.dtpDate.TabIndex = 3
        '
        'dgvJV
        '
        Me.dgvJV.AllowUserToAddRows = False
        Me.dgvJV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvJV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colTitle, Me.colNarration, Me.colDebit, Me.colCredit})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJV.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvJV.Location = New System.Drawing.Point(10, 130)
        Me.dgvJV.Name = "dgvJV"
        Me.dgvJV.ReadOnly = True
        Me.dgvJV.RowHeadersWidth = 51
        Me.dgvJV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJV.Size = New System.Drawing.Size(1242, 286)
        Me.dgvJV.TabIndex = 5
        Me.dgvJV.TabStop = False
        '
        'colID
        '
        Me.colID.DataPropertyName = "acid"
        Me.colID.HeaderText = "ID"
        Me.colID.MinimumWidth = 6
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Width = 125
        '
        'colTitle
        '
        Me.colTitle.DataPropertyName = "subsidary"
        Me.colTitle.HeaderText = "Account Title"
        Me.colTitle.MinimumWidth = 6
        Me.colTitle.Name = "colTitle"
        Me.colTitle.ReadOnly = True
        Me.colTitle.Width = 350
        '
        'colNarration
        '
        Me.colNarration.DataPropertyName = "narration"
        Me.colNarration.HeaderText = "Narration"
        Me.colNarration.MinimumWidth = 6
        Me.colNarration.Name = "colNarration"
        Me.colNarration.ReadOnly = True
        Me.colNarration.Width = 450
        '
        'colDebit
        '
        Me.colDebit.DataPropertyName = "debit"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colDebit.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDebit.HeaderText = "Debit"
        Me.colDebit.MinimumWidth = 6
        Me.colDebit.Name = "colDebit"
        Me.colDebit.ReadOnly = True
        Me.colDebit.Width = 125
        '
        'colCredit
        '
        Me.colCredit.DataPropertyName = "credit"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colCredit.DefaultCellStyle = DataGridViewCellStyle3
        Me.colCredit.HeaderText = "Credit"
        Me.colCredit.MinimumWidth = 6
        Me.colCredit.Name = "colCredit"
        Me.colCredit.ReadOnly = True
        Me.colCredit.Width = 125
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.Invoice.My.Resources.Resources.door_exit2
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnClose.Location = New System.Drawing.Point(726, 427)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(74, 55)
        Me.btnClose.TabIndex = 7
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "&Close"
        '
        'gbItems
        '
        Me.gbItems.Controls.Add(Me.Label3)
        Me.gbItems.Controls.Add(Me.Label8)
        Me.gbItems.Controls.Add(Me.Label4)
        Me.gbItems.Controls.Add(Me.Label5)
        Me.gbItems.Controls.Add(Me.txtCredit)
        Me.gbItems.Controls.Add(Me.txtDebit)
        Me.gbItems.Controls.Add(Me.Label6)
        Me.gbItems.Controls.Add(Me.txtNarration)
        Me.gbItems.Controls.Add(Me.Label7)
        Me.gbItems.Controls.Add(Me.txtPreviousBalance)
        Me.gbItems.Controls.Add(Me.txtAccountTitle)
        Me.gbItems.Controls.Add(Me.txtACID)
        Me.gbItems.Location = New System.Drawing.Point(9, 68)
        Me.gbItems.Name = "gbItems"
        Me.gbItems.Size = New System.Drawing.Size(1243, 64)
        Me.gbItems.TabIndex = 4
        Me.gbItems.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Acc. ID"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.Location = New System.Drawing.Point(451, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 20)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Pre. Balance"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(238, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 20)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Title"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(732, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Narration"
        '
        'txtCredit
        '
        Me.txtCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCredit.Location = New System.Drawing.Point(1102, 30)
        Me.txtCredit.Name = "txtCredit"
        Me.txtCredit.Size = New System.Drawing.Size(126, 26)
        Me.txtCredit.TabIndex = 9
        Me.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDebit
        '
        Me.txtDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDebit.Location = New System.Drawing.Point(978, 30)
        Me.txtDebit.Name = "txtDebit"
        Me.txtDebit.Size = New System.Drawing.Size(125, 26)
        Me.txtDebit.TabIndex = 7
        Me.txtDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(1014, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Debit"
        '
        'txtNarration
        '
        Me.txtNarration.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNarration.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtNarration.Location = New System.Drawing.Point(569, 30)
        Me.txtNarration.Name = "txtNarration"
        Me.txtNarration.Size = New System.Drawing.Size(409, 26)
        Me.txtNarration.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.Location = New System.Drawing.Point(1137, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 20)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Credit"
        '
        'txtPreviousBalance
        '
        Me.txtPreviousBalance.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtPreviousBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtPreviousBalance.Location = New System.Drawing.Point(443, 30)
        Me.txtPreviousBalance.Name = "txtPreviousBalance"
        Me.txtPreviousBalance.ReadOnly = True
        Me.txtPreviousBalance.Size = New System.Drawing.Size(127, 26)
        Me.txtPreviousBalance.TabIndex = 3
        Me.txtPreviousBalance.TabStop = False
        Me.txtPreviousBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAccountTitle
        '
        Me.txtAccountTitle.BackColor = System.Drawing.Color.Yellow
        Me.txtAccountTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtAccountTitle.Location = New System.Drawing.Point(74, 30)
        Me.txtAccountTitle.Name = "txtAccountTitle"
        Me.txtAccountTitle.ReadOnly = True
        Me.txtAccountTitle.Size = New System.Drawing.Size(370, 26)
        Me.txtAccountTitle.TabIndex = 3
        Me.txtAccountTitle.TabStop = False
        '
        'txtACID
        '
        Me.txtACID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtACID.Location = New System.Drawing.Point(1, 30)
        Me.txtACID.Name = "txtACID"
        Me.txtACID.Size = New System.Drawing.Size(73, 26)
        Me.txtACID.TabIndex = 1
        Me.txtACID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Voucher #"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.Location = New System.Drawing.Point(448, 427)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(116, 55)
        Me.Button1.TabIndex = 6
        Me.Button1.TabStop = False
        Me.Button1.Text = "&Save Voucher"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtTotalDebit
        '
        Me.txtTotalDebit.BackColor = System.Drawing.Color.Yellow
        Me.txtTotalDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotalDebit.Location = New System.Drawing.Point(955, 422)
        Me.txtTotalDebit.Name = "txtTotalDebit"
        Me.txtTotalDebit.ReadOnly = True
        Me.txtTotalDebit.Size = New System.Drawing.Size(100, 26)
        Me.txtTotalDebit.TabIndex = 8
        Me.txtTotalDebit.TabStop = False
        Me.txtTotalDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalCredit
        '
        Me.txtTotalCredit.BackColor = System.Drawing.Color.Yellow
        Me.txtTotalCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTotalCredit.Location = New System.Drawing.Point(1056, 422)
        Me.txtTotalCredit.Name = "txtTotalCredit"
        Me.txtTotalCredit.ReadOnly = True
        Me.txtTotalCredit.Size = New System.Drawing.Size(100, 26)
        Me.txtTotalCredit.TabIndex = 9
        Me.txtTotalCredit.TabStop = False
        Me.txtTotalCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDifference
        '
        Me.txtDifference.BackColor = System.Drawing.Color.Red
        Me.txtDifference.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDifference.ForeColor = System.Drawing.Color.White
        Me.txtDifference.Location = New System.Drawing.Point(999, 449)
        Me.txtDifference.Name = "txtDifference"
        Me.txtDifference.Size = New System.Drawing.Size(112, 26)
        Me.txtDifference.TabIndex = 10
        Me.txtDifference.TabStop = False
        Me.txtDifference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDifference.Visible = False
        '
        'lblChanges
        '
        Me.lblChanges.AutoSize = True
        Me.lblChanges.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblChanges.ForeColor = System.Drawing.Color.Red
        Me.lblChanges.Location = New System.Drawing.Point(171, 439)
        Me.lblChanges.Name = "lblChanges"
        Me.lblChanges.Size = New System.Drawing.Size(274, 31)
        Me.lblChanges.TabIndex = 0
        Me.lblChanges.Text = "Changes Not Saved"
        Me.lblChanges.Visible = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button2.Location = New System.Drawing.Point(591, 427)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 55)
        Me.Button2.TabIndex = 11
        Me.Button2.TabStop = False
        Me.Button2.Text = "&Delete Voucher"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(1176, 33)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Jounal Voucher"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmJV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1264, 492)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtDifference)
        Me.Controls.Add(Me.txtTotalCredit)
        Me.Controls.Add(Me.lblChanges)
        Me.Controls.Add(Me.txtTotalDebit)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dgvJV)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.txtDocNumber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbItems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmJV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmJV"
        CType(Me.dgvJV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbItems.ResumeLayout(False)
        Me.gbItems.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtDocNumber As TextBox
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents dgvJV As DataGridView
    Friend WithEvents btnClose As Button
    Friend WithEvents gbItems As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtACID As TextBox
    Friend WithEvents txtAccountTitle As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNarration As TextBox
    Friend WithEvents txtDebit As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCredit As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtTotalDebit As TextBox
    Friend WithEvents txtTotalCredit As TextBox
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents colTitle As DataGridViewTextBoxColumn
    Friend WithEvents colNarration As DataGridViewTextBoxColumn
    Friend WithEvents colDebit As DataGridViewTextBoxColumn
    Friend WithEvents colCredit As DataGridViewTextBoxColumn
    Friend WithEvents txtDifference As TextBox
    Friend WithEvents lblChanges As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents txtPreviousBalance As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
End Class

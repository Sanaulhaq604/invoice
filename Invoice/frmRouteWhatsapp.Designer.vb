<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRouteWhatsapp
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
        Me.cmbRoute = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvCustomerList = New System.Windows.Forms.DataGridView()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMobile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNetwork = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtMsg = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.txtLink = New System.Windows.Forms.TextBox()
        Me.dtpRoute = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pbRoute = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnSMS = New System.Windows.Forms.Button()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblSMS = New System.Windows.Forms.Label()
        Me.lblSMSLength = New System.Windows.Forms.Label()
        Me.txtDelay = New System.Windows.Forms.TextBox()
        Me.lblCharacters = New System.Windows.Forms.Label()
        Me.lblDelay = New System.Windows.Forms.Label()
        Me.txtStart = New System.Windows.Forms.TextBox()
        CType(Me.dgvCustomerList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbRoute, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbRoute
        '
        Me.cmbRoute.FormattingEnabled = True
        Me.cmbRoute.Location = New System.Drawing.Point(6, 15)
        Me.cmbRoute.Name = "cmbRoute"
        Me.cmbRoute.Size = New System.Drawing.Size(100, 21)
        Me.cmbRoute.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Route"
        '
        'dgvCustomerList
        '
        Me.dgvCustomerList.AllowUserToAddRows = False
        Me.dgvCustomerList.AllowUserToDeleteRows = False
        Me.dgvCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomerList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colName, Me.colMobile, Me.colNetwork})
        Me.dgvCustomerList.Location = New System.Drawing.Point(6, 39)
        Me.dgvCustomerList.Name = "dgvCustomerList"
        Me.dgvCustomerList.ReadOnly = True
        Me.dgvCustomerList.RowHeadersWidth = 51
        Me.dgvCustomerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCustomerList.Size = New System.Drawing.Size(791, 310)
        Me.dgvCustomerList.TabIndex = 20
        Me.dgvCustomerList.TabStop = False
        '
        'colID
        '
        Me.colID.DataPropertyName = "id"
        Me.colID.HeaderText = "ID"
        Me.colID.MinimumWidth = 6
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Width = 125
        '
        'colName
        '
        Me.colName.DataPropertyName = "subsidary"
        Me.colName.HeaderText = "Customer Name"
        Me.colName.MinimumWidth = 6
        Me.colName.Name = "colName"
        Me.colName.ReadOnly = True
        Me.colName.Width = 250
        '
        'colMobile
        '
        Me.colMobile.DataPropertyName = "ocell"
        Me.colMobile.HeaderText = "Mobile Number"
        Me.colMobile.MinimumWidth = 6
        Me.colMobile.Name = "colMobile"
        Me.colMobile.ReadOnly = True
        Me.colMobile.Width = 120
        '
        'colNetwork
        '
        Me.colNetwork.DataPropertyName = "ocellNetwork"
        Me.colNetwork.HeaderText = "Network"
        Me.colNetwork.MinimumWidth = 6
        Me.colNetwork.Name = "colNetwork"
        Me.colNetwork.ReadOnly = True
        Me.colNetwork.Width = 125
        '
        'txtMsg
        '
        Me.txtMsg.Font = New System.Drawing.Font("Urdu Typesetting", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtMsg.Location = New System.Drawing.Point(6, 352)
        Me.txtMsg.Multiline = True
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMsg.Size = New System.Drawing.Size(790, 173)
        Me.txtMsg.TabIndex = 12
        Me.txtMsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(663, 527)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(132, 63)
        Me.btnExit.TabIndex = 17
        Me.btnExit.Text = "&Close"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'txtLink
        '
        Me.txtLink.Location = New System.Drawing.Point(307, 16)
        Me.txtLink.Name = "txtLink"
        Me.txtLink.Size = New System.Drawing.Size(261, 20)
        Me.txtLink.TabIndex = 7
        '
        'dtpRoute
        '
        Me.dtpRoute.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRoute.Location = New System.Drawing.Point(213, 15)
        Me.dtpRoute.Name = "dtpRoute"
        Me.dtpRoute.Size = New System.Drawing.Size(88, 20)
        Me.dtpRoute.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(237, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(599, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "SMS Server"
        '
        'pbRoute
        '
        Me.pbRoute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbRoute.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbRoute.Location = New System.Drawing.Point(802, 15)
        Me.pbRoute.Name = "pbRoute"
        Me.pbRoute.Size = New System.Drawing.Size(454, 571)
        Me.pbRoute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbRoute.TabIndex = 21
        Me.pbRoute.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(135, 527)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 63)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "&UpLoad File"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(135, -1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Customer"
        '
        'txtCustomer
        '
        Me.txtCustomer.Location = New System.Drawing.Point(109, 15)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(107, 20)
        Me.txtCustomer.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(6, 527)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(124, 63)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "UpLoad Image"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnSMS
        '
        Me.btnSMS.BackgroundImage = Global.Invoice.My.Resources.Resources.SMS1
        Me.btnSMS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSMS.Location = New System.Drawing.Point(354, 527)
        Me.btnSMS.Name = "btnSMS"
        Me.btnSMS.Size = New System.Drawing.Size(89, 63)
        Me.btnSMS.TabIndex = 16
        Me.btnSMS.UseVisualStyleBackColor = True
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(608, 15)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(47, 20)
        Me.txtServer.TabIndex = 11
        Me.txtServer.TabStop = False
        Me.txtServer.Text = "1.125"
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.Invoice.My.Resources.Resources.WA
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Location = New System.Drawing.Point(261, 527)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(89, 63)
        Me.Button3.TabIndex = 15
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(375, -1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Link"
        '
        'lblSMS
        '
        Me.lblSMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblSMS.Location = New System.Drawing.Point(447, 524)
        Me.lblSMS.Name = "lblSMS"
        Me.lblSMS.Size = New System.Drawing.Size(213, 31)
        Me.lblSMS.TabIndex = 57
        Me.lblSMS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSMSLength
        '
        Me.lblSMSLength.AutoSize = True
        Me.lblSMSLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblSMSLength.Location = New System.Drawing.Point(513, 574)
        Me.lblSMSLength.Name = "lblSMSLength"
        Me.lblSMSLength.Size = New System.Drawing.Size(17, 17)
        Me.lblSMSLength.TabIndex = 58
        Me.lblSMSLength.Text = "0"
        Me.lblSMSLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDelay
        '
        Me.txtDelay.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDelay.Location = New System.Drawing.Point(577, 572)
        Me.txtDelay.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDelay.Name = "txtDelay"
        Me.txtDelay.Size = New System.Drawing.Size(36, 23)
        Me.txtDelay.TabIndex = 59
        Me.txtDelay.Text = "5"
        Me.txtDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCharacters
        '
        Me.lblCharacters.AutoSize = True
        Me.lblCharacters.Location = New System.Drawing.Point(496, 557)
        Me.lblCharacters.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCharacters.Name = "lblCharacters"
        Me.lblCharacters.Size = New System.Drawing.Size(58, 13)
        Me.lblCharacters.TabIndex = 60
        Me.lblCharacters.Text = "Characters"
        '
        'lblDelay
        '
        Me.lblDelay.AutoSize = True
        Me.lblDelay.Location = New System.Drawing.Point(579, 555)
        Me.lblDelay.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDelay.Name = "lblDelay"
        Me.lblDelay.Size = New System.Drawing.Size(34, 13)
        Me.lblDelay.TabIndex = 60
        Me.lblDelay.Text = "Delay"
        '
        'txtStart
        '
        Me.txtStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtStart.Location = New System.Drawing.Point(572, 14)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(30, 23)
        Me.txtStart.TabIndex = 9
        Me.txtStart.Text = "0"
        Me.txtStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmRouteWhatsapp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(1370, 598)
        Me.Controls.Add(Me.txtStart)
        Me.Controls.Add(Me.lblDelay)
        Me.Controls.Add(Me.lblCharacters)
        Me.Controls.Add(Me.txtDelay)
        Me.Controls.Add(Me.lblSMSLength)
        Me.Controls.Add(Me.lblSMS)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.btnSMS)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtCustomer)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pbRoute)
        Me.Controls.Add(Me.dtpRoute)
        Me.Controls.Add(Me.txtLink)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.txtMsg)
        Me.Controls.Add(Me.dgvCustomerList)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbRoute)
        Me.Name = "frmRouteWhatsapp"
        Me.Text = "frmRouteWhatsapp"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvCustomerList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbRoute, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbRoute As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvCustomerList As DataGridView
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents colMobile As DataGridViewTextBoxColumn
    Friend WithEvents colNetwork As DataGridViewTextBoxColumn
    Friend WithEvents txtMsg As TextBox
    Friend WithEvents btnExit As Button
    Friend WithEvents txtLink As TextBox
    Friend WithEvents dtpRoute As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents pbRoute As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents btnSMS As Button
    Friend WithEvents txtServer As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents lblSMS As Label
    Friend WithEvents lblSMSLength As Label
    Friend WithEvents txtDelay As TextBox
    Friend WithEvents lblCharacters As Label
    Friend WithEvents lblDelay As Label
    Friend WithEvents txtStart As TextBox
End Class

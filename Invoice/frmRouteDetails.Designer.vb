<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRouteDetails
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
        Me.txtRoute = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTP1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.chkBalance = New System.Windows.Forms.CheckBox()
        Me.btnThermalLoad = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtRoute
        '
        Me.txtRoute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRoute.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtRoute.Location = New System.Drawing.Point(250, 10)
        Me.txtRoute.Name = "txtRoute"
        Me.txtRoute.Size = New System.Drawing.Size(103, 23)
        Me.txtRoute.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(191, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Route #"
        '
        'DTP1
        '
        Me.DTP1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP1.Location = New System.Drawing.Point(83, 11)
        Me.DTP1.Name = "DTP1"
        Me.DTP1.Size = New System.Drawing.Size(104, 23)
        Me.DTP1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(42, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Date"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.DisplayStatusBar = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(13, 42)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1343, 576)
        Me.CrystalReportViewer1.TabIndex = 8
        Me.CrystalReportViewer1.TabStop = False
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.Location = New System.Drawing.Point(626, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 36)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "&Recovery Details"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Red
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.Location = New System.Drawing.Point(1251, 1)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(105, 36)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "&Close"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExport.Location = New System.Drawing.Point(751, 1)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(125, 36)
        Me.btnExport.TabIndex = 5
        Me.btnExport.Text = "&Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button2.Location = New System.Drawing.Point(961, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(105, 36)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Load &Details"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'chkBalance
        '
        Me.chkBalance.AutoSize = True
        Me.chkBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkBalance.Location = New System.Drawing.Point(359, 11)
        Me.chkBalance.Name = "chkBalance"
        Me.chkBalance.Size = New System.Drawing.Size(264, 21)
        Me.chkBalance.TabIndex = 9
        Me.chkBalance.Text = "Include Customers With Zeor Balance"
        Me.chkBalance.UseVisualStyleBackColor = True
        '
        'btnThermalLoad
        '
        Me.btnThermalLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnThermalLoad.Location = New System.Drawing.Point(1072, 0)
        Me.btnThermalLoad.Name = "btnThermalLoad"
        Me.btnThermalLoad.Size = New System.Drawing.Size(105, 36)
        Me.btnThermalLoad.TabIndex = 6
        Me.btnThermalLoad.Text = "Thermal Load &Details"
        Me.btnThermalLoad.UseVisualStyleBackColor = True
        '
        'frmRouteDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(1367, 630)
        Me.Controls.Add(Me.chkBalance)
        Me.Controls.Add(Me.btnThermalLoad)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.DTP1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRoute)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRouteDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmRouteDetails"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtRoute As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DTP1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Button1 As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents chkBalance As CheckBox
    Friend WithEvents btnThermalLoad As Button
End Class

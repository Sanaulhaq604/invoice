<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainHeadsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChartOfAccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductAccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StaffAccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VouchersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CashReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CashPaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BankReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BankPaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AccountsToolStripMenuItem, Me.VouchersToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AccountsToolStripMenuItem
        '
        Me.AccountsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainHeadsToolStripMenuItem, Me.ChartOfAccountsToolStripMenuItem, Me.ProductAccountsToolStripMenuItem, Me.StaffAccountsToolStripMenuItem})
        Me.AccountsToolStripMenuItem.Name = "AccountsToolStripMenuItem"
        Me.AccountsToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.AccountsToolStripMenuItem.Text = "Accounts"
        '
        'MainHeadsToolStripMenuItem
        '
        Me.MainHeadsToolStripMenuItem.Name = "MainHeadsToolStripMenuItem"
        Me.MainHeadsToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.MainHeadsToolStripMenuItem.Text = "Main Heads"
        '
        'ChartOfAccountsToolStripMenuItem
        '
        Me.ChartOfAccountsToolStripMenuItem.Name = "ChartOfAccountsToolStripMenuItem"
        Me.ChartOfAccountsToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ChartOfAccountsToolStripMenuItem.Text = "Chart Of Accounts"
        '
        'ProductAccountsToolStripMenuItem
        '
        Me.ProductAccountsToolStripMenuItem.Name = "ProductAccountsToolStripMenuItem"
        Me.ProductAccountsToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ProductAccountsToolStripMenuItem.Text = "Product Accounts"
        '
        'StaffAccountsToolStripMenuItem
        '
        Me.StaffAccountsToolStripMenuItem.Name = "StaffAccountsToolStripMenuItem"
        Me.StaffAccountsToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.StaffAccountsToolStripMenuItem.Text = "Staff Accounts"
        '
        'VouchersToolStripMenuItem
        '
        Me.VouchersToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InvoiceToolStripMenuItem, Me.PurchaseVoucherToolStripMenuItem, Me.CashReceiptToolStripMenuItem, Me.CashPaymentToolStripMenuItem, Me.BankReceiptToolStripMenuItem, Me.BankPaymentToolStripMenuItem})
        Me.VouchersToolStripMenuItem.Name = "VouchersToolStripMenuItem"
        Me.VouchersToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.VouchersToolStripMenuItem.Text = "Vouchers"
        '
        'InvoiceToolStripMenuItem
        '
        Me.InvoiceToolStripMenuItem.Name = "InvoiceToolStripMenuItem"
        Me.InvoiceToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.InvoiceToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.InvoiceToolStripMenuItem.Text = "&Invoice"
        '
        'PurchaseVoucherToolStripMenuItem
        '
        Me.PurchaseVoucherToolStripMenuItem.Name = "PurchaseVoucherToolStripMenuItem"
        Me.PurchaseVoucherToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PurchaseVoucherToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.PurchaseVoucherToolStripMenuItem.Text = "&Purchase Voucher"
        '
        'CashReceiptToolStripMenuItem
        '
        Me.CashReceiptToolStripMenuItem.Name = "CashReceiptToolStripMenuItem"
        Me.CashReceiptToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.CashReceiptToolStripMenuItem.Text = "Cash &Receipt"
        '
        'CashPaymentToolStripMenuItem
        '
        Me.CashPaymentToolStripMenuItem.Name = "CashPaymentToolStripMenuItem"
        Me.CashPaymentToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.CashPaymentToolStripMenuItem.Text = "Cash Paymen&t"
        '
        'BankReceiptToolStripMenuItem
        '
        Me.BankReceiptToolStripMenuItem.Name = "BankReceiptToolStripMenuItem"
        Me.BankReceiptToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.BankReceiptToolStripMenuItem.Text = "&Bank Receipt"
        '
        'BankPaymentToolStripMenuItem
        '
        Me.BankPaymentToolStripMenuItem.Name = "BankPaymentToolStripMenuItem"
        Me.BankPaymentToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.BankPaymentToolStripMenuItem.Text = "Bank Pa&yment"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AccountsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MainHeadsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChartOfAccountsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductAccountsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StaffAccountsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VouchersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InvoiceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PurchaseVoucherToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CashReceiptToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CashPaymentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BankReceiptToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BankPaymentToolStripMenuItem As ToolStripMenuItem
End Class

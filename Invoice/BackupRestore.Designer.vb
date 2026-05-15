<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BackupRestore
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Red
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.Location = New System.Drawing.Point(111, 184)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(182, 47)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "&Restore"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.ForestGreen
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(149, 93)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 47)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "&Backup"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtFile
        '
        Me.txtFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtFile.Location = New System.Drawing.Point(16, 30)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(357, 26)
        Me.txtFile.TabIndex = 5
        Me.txtFile.Text = "D:\Google Drive ai\db backup\NewBackup.bak"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Backup Files |*.bak"
        Me.OpenFileDialog1.RestoreDirectory = True
        '
        'btnOpenFile
        '
        Me.btnOpenFile.BackgroundImage = Global.Invoice.My.Resources.Resources.vector_folder_icon
        Me.btnOpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOpenFile.Location = New System.Drawing.Point(374, 30)
        Me.btnOpenFile.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(33, 26)
        Me.btnOpenFile.TabIndex = 6
        Me.btnOpenFile.UseVisualStyleBackColor = True
        '
        'BackupRestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 235)
        Me.Controls.Add(Me.btnOpenFile)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.KeyPreview = True
        Me.Name = "BackupRestore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BackupRestore"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents txtFile As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnOpenFile As Button
End Class

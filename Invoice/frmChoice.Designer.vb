<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChoice
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
        Me.btnOption1 = New System.Windows.Forms.Button()
        Me.btnOption2 = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblQuestion = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnOption1
        '
        Me.btnOption1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnOption1.Location = New System.Drawing.Point(107, 155)
        Me.btnOption1.Name = "btnOption1"
        Me.btnOption1.Size = New System.Drawing.Size(144, 54)
        Me.btnOption1.TabIndex = 0
        Me.btnOption1.Text = "Button1"
        Me.btnOption1.UseVisualStyleBackColor = True
        '
        'btnOption2
        '
        Me.btnOption2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnOption2.Location = New System.Drawing.Point(289, 155)
        Me.btnOption2.Name = "btnOption2"
        Me.btnOption2.Size = New System.Drawing.Size(144, 54)
        Me.btnOption2.TabIndex = 0
        Me.btnOption2.Text = "Button1"
        Me.btnOption2.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(471, 155)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(144, 54)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "&Cencel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblQuestion
        '
        Me.lblQuestion.AutoSize = True
        Me.lblQuestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblQuestion.Location = New System.Drawing.Point(12, 30)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(105, 24)
        Me.lblQuestion.TabIndex = 1
        Me.lblQuestion.Text = "lblQuestion"
        '
        'frmChoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 238)
        Me.Controls.Add(Me.lblQuestion)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOption2)
        Me.Controls.Add(Me.btnOption1)
        Me.Name = "frmChoice"
        Me.Text = "frmChoice"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOption1 As Button
    Friend WithEvents btnOption2 As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblQuestion As Label
End Class

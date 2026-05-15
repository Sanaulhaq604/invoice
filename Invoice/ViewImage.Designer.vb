<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewImage
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
        Me.pbBilty = New System.Windows.Forms.PictureBox()
        CType(Me.pbBilty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbBilty
        '
        Me.pbBilty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbBilty.Location = New System.Drawing.Point(0, 0)
        Me.pbBilty.Name = "pbBilty"
        Me.pbBilty.Size = New System.Drawing.Size(709, 574)
        Me.pbBilty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbBilty.TabIndex = 0
        Me.pbBilty.TabStop = False
        '
        'ViewImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 574)
        Me.Controls.Add(Me.pbBilty)
        Me.Name = "ViewImage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ViewImage"
        CType(Me.pbBilty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbBilty As PictureBox
End Class

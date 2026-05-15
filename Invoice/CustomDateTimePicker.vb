Public Class CustomDateTimePicker
    Inherits DateTimePicker

    Public Sub New()
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.Format = DateTimePickerFormat.Custom
        Me.CustomFormat = "dd-MMM-yyyy"
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Using g As Graphics = e.Graphics
            g.FillRectangle(New SolidBrush(Color.SkyBlue), Me.ClientRectangle)

            ' Draw text
            Dim sf As New StringFormat With {.LineAlignment = StringAlignment.Center}
            g.DrawString(Me.Text, Me.Font, Brushes.Black, Me.ClientRectangle, sf)

            ' Draw dropdown arrow
            ControlPaint.DrawComboButton(g, New Rectangle(Me.Width - 20, 0, 20, Me.Height), ButtonState.Normal)
        End Using
    End Sub
End Class

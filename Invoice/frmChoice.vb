Public Class frmChoice

    Public Property SelectedOption As String = ""

    ' =========================
    ' SET OPTIONS (MAIN METHOD)
    ' =========================
    Public Sub SetOptions(question As String, option1 As String, option2 As String)

        ' Set text
        lblQuestion.Text = question
        btnOption1.Text = option1
        btnOption2.Text = option2

        ' Allow label wrapping
        lblQuestion.AutoSize = True
        lblQuestion.MaximumSize = New Size(400, 0)

        ' Force layout update
        Me.PerformLayout()
        lblQuestion.Refresh()

        ' ===== WIDTH CALCULATION =====
        Dim textSize As Size = TextRenderer.MeasureText(
            question,
            lblQuestion.Font,
            New Size(600, Integer.MaxValue),
            TextFormatFlags.WordBreak
        )

        Dim minWidth As Integer = 350
        Dim padding As Integer = 80

        Me.Width = Math.Max(minWidth, textSize.Width + padding)

        ' Update label width after form resize
        lblQuestion.MaximumSize = New Size(Me.Width - 40, 0)
        lblQuestion.Refresh()

        ' Center buttons
        CenterButtons()

        ' Force layout again
        Me.PerformLayout()

        ' ===== HEIGHT CALCULATION (SAFE) =====
        Dim bottomControl As Integer =
            Math.Max(btnOption1.Bottom,
            Math.Max(btnOption2.Bottom, btnCancel.Bottom))

        Me.Height = bottomControl + 50

        ' Optional: center form on screen
        Me.StartPosition = FormStartPosition.CenterScreen

    End Sub

    ' =========================
    ' CENTER BUTTONS
    ' =========================
    Private Sub CenterButtons()

        Dim spacing As Integer = 15

        Dim totalWidth As Integer =
            btnOption1.Width +
            btnOption2.Width +
            btnCancel.Width +
            (spacing * 2)

        Dim startX As Integer = (Me.ClientSize.Width - totalWidth) \ 2

        btnOption1.Left = startX
        btnOption2.Left = btnOption1.Right + spacing
        btnCancel.Left = btnOption2.Right + spacing

    End Sub

    ' =========================
    ' BUTTON EVENTS
    ' =========================
    Private Sub btnOption1_Click(sender As Object, e As EventArgs) Handles btnOption1.Click
        SelectedOption = btnOption1.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnOption2_Click(sender As Object, e As EventArgs) Handles btnOption2.Click
        SelectedOption = btnOption2.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        SelectedOption = "Cancel"
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
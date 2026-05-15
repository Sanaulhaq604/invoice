Imports System.Windows.Forms
Public Class CustomTextBox
    Inherits TextBox
    Private orignalBAckColor As Color
    Private orignalText As String
    Public Sub New()
        MyBase.New()
        orignalBAckColor = Me.BackColor
        Me.Font = New Font(Me.Font.FontFamily, 10)
        AddHandler Me.Enter, AddressOf CustomTextBox_Enter
        AddHandler Me.Leave, AddressOf CustomTextBox_Leave
        AddHandler Me.TextChanged, AddressOf CustomTexBox_TextChanged

    End Sub
    Public ReadOnly Property OldText As String
        Get
            Return orignalText
        End Get
    End Property

    Public ReadOnly Property NewText As String
        Get
            Return Me.Text
        End Get
    End Property
    Sub CustomTexBox_TextChanged(Sender As Object, e As EventArgs)
        Dim currentText As String = Me.Text
        If currentText <> currentText.ToUpper() Then
            Dim selectionStart As Integer = Me.SelectionStart
            Me.Text = currentText.ToUpper
            Me.SelectionStart = selectionStart
        End If
    End Sub

    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        e.KeyChar = Char.ToUpper(e.KeyChar)
        MyBase.OnKeyPress(e)
    End Sub

    Sub CustomTextBox_Enter(Sender As Object, e As EventArgs)
        orignalText = Me.Text
        Me.BackColor = Color.DeepSkyBlue
        Me.SelectAll()
    End Sub
    Sub CustomTextBox_Leave(Sender As Object, e As EventArgs)
        Me.BackColor = orignalBAckColor
        If Me.Text <> orignalText Then

        End If
    End Sub

End Class

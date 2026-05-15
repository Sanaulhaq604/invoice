Imports Microsoft.VisualBasic
'Import the necessary namespaces
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

'Declare the mouse event constants and API functions
Public Class MouseClicker
    Private Const MOUSEEVENTF_LEFTDOWN As UInteger = &H2
    Private Const MOUSEEVENTF_LEFTUP As UInteger = &H4
    Private Declare Sub mouse_event Lib "user32.dll" (ByVal dwFlags As UInteger, ByVal dx As Integer, ByVal dy As Integer, ByVal dwData As UInteger, ByVal dwExtraInfo As Integer)
    Private Declare Function SetCursorPos Lib "user32.dll" (ByVal x As Integer, ByVal y As Integer) As Boolean

    'A method to move the cursor to a given position and click the left button
    Public Shared Sub ClickOn(ByVal x As Integer, ByVal y As Integer)
        'Move the cursor to the desired position
        SetCursorPos(x, y)
        'Press the left button down and then release it
        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
    End Sub
End Class

'An example of using the MouseClicker class in a form
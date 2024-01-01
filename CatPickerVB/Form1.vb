Public Class Form1

  Public Function sayHi() As String
    Return "Hi"
  End Function

  Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub

  Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
    Me.Hide()
  End Sub
End Class
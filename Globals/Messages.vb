Public Class Messages
  Public Shared Property statusMsg As String
  Public Shared Property errorMsg As String

  Public Shared Sub appendStatusMsg(appendMessage As String)
    statusMsg += " | " + appendMessage
  End Sub

End Class

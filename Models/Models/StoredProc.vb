Public Class StoredProc
  'Generic repository class to allow the stored procedure repository to have access to base class odbc connection functions

  'Public spParm As ValueTuple(Of String, String)
  Public Property spParamList As New List(Of ValueTuple(Of String, String))

End Class

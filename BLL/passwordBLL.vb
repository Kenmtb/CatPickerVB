Imports DAL
Imports Models
Public Class passwordBLL

  Dim rep As New CatPasswordRepository(Of CatPassword)

  Public Function validatePassword(username As String, password As String, records As IEnumerable(Of CatPassword)) As Boolean
    Return rep.validatePassword(username, password, records)
  End Function

  Public Function getAll() As IEnumerable(Of CatPassword)
    Return rep.getAll()
  End Function


End Class

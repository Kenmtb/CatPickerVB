Imports Models
Public Class passwordDAL
  'Validate cat application password

  Public Function validatePassword(username As String, password As String, records As IEnumerable(Of CatPassword)) As String
    Try
      Dim loggedIn = False
      Dim ID = From rec In records
               Where rec.employeeUserName = username And rec.employeePassword = password
               Select rec.employeeID
      If ID.Count > 0 Then loggedIn = True
      Return loggedIn

    Catch ex As Exception
    End Try
  End Function

End Class

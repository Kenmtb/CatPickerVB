Imports DAL
Imports Models
Public Class CatNoteBLL
  'Run C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI\EmployeesAPI app must be running

  'Choose the model's repository.Local or API - 
  'Dim rep As New CatRepository(Of Cat)

  Dim rep As New CatNoteApiRepository

  Public Function getAll() As CatNote
    Return rep.getAll
  End Function
End Class

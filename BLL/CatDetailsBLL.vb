Imports DAL
Imports Models
Public Class CatDetailsBLL
  'Run C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI\EmployeesAPI app must be running

  'Choose the model's repository.Local or API - 
  'Dim rep As New CatRepository(Of Cat)

  Dim rep As New CatDetailApiRepository(Of CatDetail)

  Dim vmRep As New CatDetailVMRepository(rep)



  Public Function getAll() As CatDetailsVM
    Return vmRep.getAll()
  End Function


  'Public Function getAll(spParams As List(Of ValueTuple(Of String, String))) As CatVM
  Public Function getAll(spParams As List(Of (String, String))) As CatDetailsVM
    'SP filter
    Return vmRep.getAll(spParams)
  End Function

  Public Sub save(rec As CatDetail)
    rep.save(rec)
  End Sub

  Public Sub insert(rec As CatDetail)
    rep.insert(rec)
  End Sub

  Public Sub delete(Id As Integer)
    rep.delete(Id)
  End Sub
End Class

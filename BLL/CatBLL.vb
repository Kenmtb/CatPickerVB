Imports DAL
Imports Models
Public Class CatBLL

  'Run C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI\EmployeesAPI app must be running

  'Choose the model's repository.Local or API - 
  Dim rep As New CatRepository(Of Cat)

  'Dim rep As New CatApiRepository(Of Cat)

  Dim vmRep As New CatVMRepository(rep)



  Public Function getAll() As CatVM
    Return vmRep.getAll()
  End Function


  'Public Function getAll(spParams As List(Of ValueTuple(Of String, String))) As CatVM
  Public Function getAll(spParams As List(Of (String, String))) As CatVM
    'SP filter
    Return vmRep.getAll(spParams)
  End Function

  Public Sub save(rec As Cat)
    rep.save(rec)
  End Sub

  Public Sub insert(rec As Cat)
    rep.insert(rec)
  End Sub

  Public Sub delete(Id As Integer)
    rep.delete(Id)
  End Sub

  'Public Sub getFilterData(rec As catFilter)

  'End Sub
End Class

Imports DAL
Imports Models
Public Class CatNoteBLL
  'Run C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI\EmployeesAPI app must be running

  'Choose the model's repository.Local or API - 
  'Dim rep As New CatRepository(Of Cat)

  Dim rep As New CatNoteApiRepository(Of CatNote)

  Public Sub createCatNotes(dummyObj As CatNote)
    rep.insert(dummyObj) 'need a dummy object to comply with interface. CatNote object is created in the insert process not passed from the UI
  End Sub
End Class

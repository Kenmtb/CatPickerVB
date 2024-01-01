Imports Models
Public Class CatBreedRepository(Of T)
  Inherits ODBCRep(Of CatBreed)
  Implements ICatRepository(Of CatBreed)

  Private rec As CatBreed

  Public Sub New()
    MyBase.conStrName = "CatBreedContext"
    MyBase.createSQLstrings("dbo.breeds")
  End Sub

  Public Sub insert(obj As CatBreed) Implements ICatRepository(Of CatBreed).insert
    Throw New NotImplementedException()
  End Sub

  Public Sub save(obj As CatBreed) Implements ICatRepository(Of CatBreed).save
    Throw New NotImplementedException()
  End Sub

  Public Function getAll() As IEnumerable(Of CatBreed) Implements ICatRepository(Of CatBreed).getAll
    Return getRecords()
  End Function

  Public Function getAll(spParams As List(Of (String, String))) As IEnumerable(Of CatBreed) Implements ICatRepository(Of CatBreed).getAll
    'Public Function getAll(spParams As List(Of Object)) As IEnumerable(Of CatBreed) Implements ICatRepository(Of CatBreed).getAll
    Throw New NotImplementedException()
  End Function

  Public Function getById(id As Object) As CatBreed Implements ICatRepository(Of CatBreed).getById
    'return (GetRecords("SELECT * FROM dbo.cats WHERE Id = " + id)).FirstOrDefault();
    ' id = -1 means a New record Is requested for the editor, otherwise return a record

    If id = -1 Then
      rec = New CatBreed()
      'initNewRec(rec)
      Return rec
    Else
      Return getRecordByID(id)
    End If
  End Function

  Public Function delete(id As Object) As Object Implements ICatRepository(Of CatBreed).delete
    Throw New NotImplementedException()
  End Function

  Public Overrides Function populateRecord(dr As DataRow) As CatBreed
    'Return MyBase.populateRecord(dr)
    Dim Rec = New CatBreed()
    Rec.Id = dr("Id")
    Rec.breedName = dr("breedName").ToString()
    Rec.breedPic = dr("breedPic").ToString()
    Rec.breedDescription = dr("breedDescription").ToString()

    Return Rec
  End Function

  Public Overrides Function populateDataRow(datarec As CatBreed, dr As DataRow) As DataRow
    Dim ds As New DataSet()

    dr("breedName") = datarec.breedName
    dr("breedDescription") = datarec.breedDescription
    dr("breedPic") = datarec.breedPic

    Return dr

  End Function

End Class

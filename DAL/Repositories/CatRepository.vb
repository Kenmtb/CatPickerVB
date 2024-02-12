Imports Models
Imports Globals

Public Class CatRepository(Of T)
  Inherits ODBCRep(Of Cat)
  Implements ICatRepository(Of Cat)

  Dim rec As Cat
  'foriegn
  Private catbreed As New CatBreedRepository(Of CatBreed)

  Public Sub New()
    MyBase.conStrName = "CatsContext"
    MyBase.createSQLstrings("dbo.cats")
  End Sub

  Public Sub insert(obj As Cat) Implements ICatRepository(Of Cat).insert
    'Throw New NotImplementedException()
    insertRecords(obj)
  End Sub

  Public Function delete(id As Object) As Object Implements ICatRepository(Of Cat).delete
    deleteRecord(id)
  End Function


  Public Sub save(obj As Cat) Implements ICatRepository(Of Cat).save
    Try
      saveRecords(obj, obj.Id)
    Catch ex As Exception
      Throw New Exception("Save failed. Changes are not saved ex:")
    End Try
  End Sub

  Public Function MockgetAll() As List(Of Cat)

    Dim testList = New List(Of Cat)()
    Dim cat1 As New Cat
    cat1.name = "Joey"
    cat1.age = 2

    testList.Add(cat1)

    Return testList
  End Function

  'Public Function getAll(spParams As List(Of ValueTuple(Of String, String))) As List(Of Cat) Implements ICatRepository(Of Cat).getAll

  '  Return getRecords("dbo.spGetCatsBy_Age_Breed_Gender", spParams)

  'End Function


  Public Function getAll() As IEnumerable(Of Cat) Implements ICatRepository(Of Cat).getAll
    Try
      Return getRecords()
    Catch ex As Exception

    End Try
  End Function

  Public Function getAll(spParams As List(Of (String, String))) As IEnumerable(Of Cat) Implements ICatRepository(Of Cat).getAll
    Try
      Return getRecords("dbo.spGetCatsBy_Age_Breed_Gender", spParams)
    Catch ex As Exception

    End Try
  End Function

  Public Overrides Function populateRecord(dr As DataRow) As Cat
    Dim catRec = New Cat()
    catRec.Id = dr("ID")
    catRec.name = dr("Name")
    catRec.age = If(Not IsDBNull(dr("age")), DirectCast(dr("age"), Nullable(Of Integer)), Nothing)
    catRec.pic = dr("pic").ToString()
    catRec.gender = dr("gender").ToString()
    catRec.mainColor = dr("mainColor").ToString()
    catRec.secondColor = dr("secondColor").ToString()
    catRec.thirdColor = dr("thirdColor").ToString()
    catRec.arrivalDate = If(Not IsDBNull(dr("arrivalDate")), dr("arrivalDate").ToString(), DateTime.MinValue.ToString())
    catRec.breedId = If(Not IsDBNull(dr("breedId")), DirectCast(dr("breedId"), Integer?), Nothing)
    catRec.detailsId = If(Not IsDBNull(dr("detailsId")), DirectCast(dr("detailsId"), Nullable(Of Integer)), Nothing)
    'foriegn
    catRec.breedName = catbreed.getById(catRec.breedId).breedName


    Return catRec
  End Function



  Public Overrides Function populateDataRow(datarec As Cat, dr As DataRow) As DataRow
    Dim ds As New DataSet()

    dr("name") = datarec.name
    dr("age") = datarec.age
    dr("pic") = datarec.pic
    dr("gender") = datarec.gender
    dr("mainColor") = datarec.mainColor
    dr("secondColor") = datarec.secondColor
    dr("thirdColor") = datarec.thirdColor
    'dr("arrivalDate") = DirectCast(datarec.arrivalDate, DateTime).Date.ToString("yyyy-MM-dd")
    dr("arrivalDate") = (datarec.arrivalDate).Date.ToString("yyyy-MM-dd")
    If (datarec.breedId IsNot Nothing) Then dr("breedId") = datarec.breedId
    'If (datarec.detailsId IsNot Nothing) Then dr("catDetailsId") = datarec.detailsId
    'dr("selected") = datarec.selected
    Return dr

  End Function

  Public Function getById(id As Object) As Cat Implements ICatRepository(Of Cat).getById
    'return (GetRecords("SELECT * FROM dbo.cats WHERE Id = " + id)).FirstOrDefault();
    ' id = -1 means a New record Is requested for the editor, otherwise return a record

    If id = -1 Then
      rec = New Cat()
      initNewRec(rec)
      Return rec
    Else
      Return getRecordByID(id)

    End If
  End Function
  Private Function initNewRec(rec As Cat) As Cat
    'Initialize record with default data
    rec.pic = "default.jpg"
    rec.mainColor = "N/A"
    rec.secondColor = "N/A"
    rec.thirdColor = "N/A"
    rec.arrivalDate = DateTime.Now
    rec.breedId = 29
    Return rec
  End Function

End Class

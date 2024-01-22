Imports Models
Imports DAL
Imports Globals

'We are currently not doing CRUD on passwords, this class may not be needed.
Public Class CatPasswordRepository(Of T)
  Inherits ODBCRep(Of CatPassword)
  Implements ICatPasswordRepository(Of CatPassword)

  Dim rec As CatPassword
  Dim passwordDAL As New DAL.passwordDAL

  Public Sub New()
    MyBase.conStrName = "CatsContext"
    MyBase.createSQLstrings("dbo.Passwords")
  End Sub

  Public Function validatePassword(username As String, password As String, records As IEnumerable(Of CatPassword)) As Boolean
    Return passwordDAL.validatePassword(username, password, records)
  End Function

  Public Sub insert(obj As CatPassword) Implements ICatPasswordRepository(Of CatPassword).insert
    'Throw New NotImplementedException()
    insertRecords(obj)
  End Sub

  Public Function delete(id As Object) As Object Implements ICatPasswordRepository(Of CatPassword).delete

  End Function


  Public Sub save(obj As CatPassword) Implements ICatPasswordRepository(Of CatPassword).save
    Try
      saveRecords(obj, obj.Id)
    Catch ex As Exception
      Throw New Exception("Save failed. Changes are not saved ex:")
    End Try
  End Sub

  Public Function MockgetAll() As List(Of CatPassword)

    'Dim testList = New List(Of CatPassword)()
    'Dim cat1 As New CatPassword
    'cat1.name = "Joey"
    'cat1.age = 2

    'testList.Add(cat1)

    Return Nothing
  End Function


  Public Function getAll() As IEnumerable(Of CatPassword) Implements ICatPasswordRepository(Of CatPassword).getAll
    Try
      Return getRecords()
    Catch ex As Exception

    End Try
  End Function

  Public Function getAll(spParams As List(Of (String, String))) As IEnumerable(Of CatPassword) Implements ICatPasswordRepository(Of CatPassword).getAll
    Try
      'Return getRecords("dbo.spGetCatsBy_Age_Breed_Gender", spParams)      
    Catch ex As Exception
    End Try
  End Function

  Public Function getAll(spParams As List(Of (String, String)), records As IEnumerable(Of CatPassword)) As IEnumerable(Of CatPassword)
    'todo - need to create consumer for this function to provide paramerer and instance of CatPassword records. The records need to be
    'supplied by the consumer, not supplied locally to avoid coupling

  End Function

  Public Overrides Function populateRecord(dr As DataRow) As CatPassword
    'Return MyBase.populateRecord(dr)
    Dim rec = New CatPassword()
    rec.Id = dr("ID")
    rec.employeePassword = dr("password")
    rec.employeeUserName = dr("username")
    rec.employeeID = dr("employeeID")

    'catRec.name = dr("Name")
    'catRec.age = If(Not IsDBNull(dr("age")), DirectCast(dr("age"), Nullable(Of Integer)), Nothing)
    'catRec.pic = dr("pic").ToString()
    'catRec.gender = dr("gender").ToString()
    'catRec.mainColor = dr("mainColor").ToString()
    'catRec.secondColor = dr("secondColor").ToString()
    'catRec.thirdColor = dr("thirdColor").ToString()
    'catRec.arrivalDate = If(Not IsDBNull(dr("arrivalDate")), dr("arrivalDate").ToString(), DateTime.MinValue.ToString())
    'catRec.breedId = If(Not IsDBNull(dr("breedId")), DirectCast(dr("breedId"), Integer?), Nothing)
    'catRec.detailsId = If(Not IsDBNull(dr("detailsId")), DirectCast(dr("detailsId"), Nullable(Of Integer)), Nothing)
    'catRec.selected = If(Not IsDBNull(dr("selected")), DirectCast(dr("selected"), Nullable(Of Boolean)), Nothing)
    Return Rec
  End Function



  Public Overrides Function populateDataRow(datarec As CatPassword, dr As DataRow) As DataRow

    'Todo - Currently there is no creation of new password data
    'If that is needed then:
    '1) Repo for Employeed id needed to get employee first and last name and ID
    '2) Employee name would be used here to create a default username and password.

    Dim ds As New DataSet()

    dr("password") = datarec.employeePassword
    dr("username") = datarec.employeeUserName
    dr("employeeID") = datarec.employeeID

    Return dr

  End Function

  Public Function getById(id As Object) As CatPassword Implements ICatPasswordRepository(Of CatPassword).getById
    'return (GetRecords("SELECT * FROM dbo.cats WHERE Id = " + id)).FirstOrDefault();
    ' id = -1 means a New record Is requested for the editor, otherwise return a record

    If id = -1 Then
      rec = New CatPassword()
      initNewRec(rec)
      Return rec
    Else
      Return getRecordByID(id)

    End If
  End Function
  Private Function initNewRec(rec As CatPassword) As CatPassword
    'Initialize record with default data

    'Todo - Currently there is no initialization needed
    'If that is needed then:
    '1) Repo for Employeed id needed to get employee first and last name and ID
    '2) Employee name would be used here to create a default username and password.

    'rec.pic = "default.jpg"
    'rec.mainColor = "N/A"
    'rec.secondColor = "N/A"
    'rec.thirdColor = "N/A"
    'rec.arrivalDate = DateTime.Now
    'rec.breedId = 29
    Return rec
  End Function
End Class

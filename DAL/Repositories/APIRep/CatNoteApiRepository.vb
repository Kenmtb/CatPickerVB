Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Web.Script.Serialization
Imports Models
Imports Newtonsoft
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
'Imports System.Net.Http.Json.HttpContentJsonExtensions
Imports Globals
Imports APIBase
Imports System.Text.Json


Public Class CatNoteApiRepository(Of T)
  Inherits APIBase(Of CatNote)
  Implements IRepository(Of CatNote)

  Private APIurl As String = "https://localhost:7117/api/CatNotes"

  'website for catNotes is a joke site, the jokes are used as notes
  'https://publicapis.io/jokes-api' - may not have to create account
  'https://www.postman.com/cs-demo/public-rest-apis/request/64pqonf/random-joke - account required



  Public Sub New()
    MyBase.url = APIurl

    model = New CatNote
    client.BaseAddress = New Uri(noteGeneraterAPIurl) 'source of cat note copy used to populate the cat notes table
    client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/text"))
    client.Timeout = New TimeSpan(0, 0, 10)
  End Sub

  Public Shared model As CatNote
  Private noteGeneraterAPIurl As String = "https://official-joke-api.appspot.com/random_joke" '"https://official-joke-api.appspot.com/jokes/1000" 
  'Private urlParameters As String = APIurl
  Private client As HttpClient = New HttpClient

  Dim response As HttpResponseMessage
  Dim rawResponseBody As String
  Dim jsonObject As Object

  'Simulates the creation of cat notes in the catNotes table
  Public Sub insert(dummyObj As CatNote) Implements IRepository(Of CatNote).insert
    'No object is passed from the UI. The note is generated in the repo simular to a mock
    insertHelper()
  End Sub

  Private Async Function insertHelper() As Task(Of CatNote)
    Try
      'Get rest data
      Messages.statusMsg = ""

      response = Await client.GetAsync("").ConfigureAwait(False)

      If Not response.IsSuccessStatusCode Then
        Messages.statusMsg = "API data error: " + response.ReasonPhrase
        GoTo abort
      End If

      'receive the data from the API site
      rawResponseBody = Await response.Content.ReadAsStringAsync.ConfigureAwait(False)

      'Because this API returns json object as text and not JSON text, we can not use the normal deserializing.
      'We have to get the JSON object text then parse it into an object then pack that object into our model.
      jsonObject = JObject.Parse(rawResponseBody)

      'Pack json object content into the model
      model.catNoteId = jsonObject.Item("id").ToString
      model.notetype = jsonObject.Item("type")
      model.noteSetup = jsonObject.Item("setup")
      model.notePunchLine = jsonObject.Item("punchline")

    Catch ex As Exception
      Messages.statusMsg = "Error getting record(s) | API Server error"
    End Try

    Return model
abort:
  End Function

  Public Function getAll() As IEnumerable(Of CatNote) Implements IRepository(Of CatNote).getAll
    'No parameters, create empty list
    Dim result As List(Of CatNote) = getAllHelper(New List(Of (String, String))).Result
    Return result
  End Function
  Public Function getAll(spParams As List(Of (String, String))) As IEnumerable(Of CatNote) Implements IRepository(Of CatNote).getAll
    Dim result As List(Of CatNote) = getAllHelper(spParams).Result
    Return result
  End Function


  'get()
  Public Async Function getAllHelper(List As List(Of (String, String))) As Task(Of IEnumerable(Of CatNote))
    Try
      Dim response As HttpResponseMessage = Await MyBase.getAllAPIHelper(List)
      Dim resStr As String = Await response.Content.ReadAsStringAsync

      If response.IsSuccessStatusCode Then

      Else
        MsgBox("Rest service error ", 0, "API service error")
      End If

      Dim result As New List(Of CatNote)

      'Pack json content into the model
      result = JsonConvert.DeserializeObject(Of List(Of CatNote))(resStr)

      Return result

    Catch ex As Exception
      Messages.statusMsg = "Error getting record(s) | API Server error"
      'MsgBox("Make sure API server is running:C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI\EmployeesAPI ", 0, "API Server error")
    End Try

  End Function



  'Public Function IRepository_getById(id As Object) As IEnumerable(Of CatNote) Implements IRepository(Of CatNote).getById
  '  Dim result As List(Of CatNote) = getByIdHelper(id).Result
  '  Return result
  'End Function


  'Public Async Function getByIdHelper(id As Object) As Task(Of IEnumerable(Of CatNote))
  '  Try
  '    Dim response As HttpResponseMessage = MyBase.getByIdHelper(id).Result
  '    Dim resStr As String = Await response.Content.ReadAsStringAsync

  '    If response.IsSuccessStatusCode Then

  '    Else
  '      MsgBox("Rest service error ", 0, "API service error")
  '    End If

  '    Dim result As New List(Of CatNote)

  '    'Pack json content into the model
  '    result = JsonConvert.DeserializeObject(Of List(Of CatNote))(resStr)

  '    Return result

  '  Catch ex As Exception
  '    Messages.statusMsg = "Error getting record(s) | API Server error"
  '    'MsgBox("Make sure API server is running:C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI\EmployeesAPI ", 0, "API Server error")
  '  End Try

  ' End Function

  Public Function delete(id As Object) As Object Implements IRepository(Of CatNote).delete
    Throw New NotImplementedException()
  End Function

  Public Sub save(obj As CatNote) Implements IRepository(Of CatNote).save
    Throw New NotImplementedException()
  End Sub

  Public Function getById(id As Object) As IEnumerable(Of CatNote) Implements IRepository(Of CatNote).getById
    Throw New NotImplementedException()
  End Function
End Class

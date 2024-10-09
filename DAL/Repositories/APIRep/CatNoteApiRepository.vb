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


Public Class CatNoteApiRepository
  Inherits APIBase(Of CatNote)

  'website for catNotes is a joke site, the jokes are used as notes
  'https://publicapis.io/jokes-api' - may not have to create account
  'https://www.postman.com/cs-demo/public-rest-apis/request/64pqonf/random-joke - account required



  Public Sub New()
    model = New CatNote
    client.BaseAddress = New Uri(APIurl)
    client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/text"))
    client.Timeout = New TimeSpan(0, 0, 10)
  End Sub

  Public Shared model As CatNote
  Private APIurl As String = "https://official-joke-api.appspot.com/jokes/1000" '"https://official-joke-api.appspot.com/random_joke"
  Private urlParameters As String = APIurl
  Private client As HttpClient = New HttpClient

  Dim response As HttpResponseMessage
  Dim rawResponseBody As String
  Dim jsonObject As JObject



  Public Function getAll() As CatNote
    'Dim result As CatNote = getAllHelper().Result
    Return getAllHelper().Result
  End Function

  'get()
  Private Async Function getAllHelper() As Task(Of CatNote)
    Try
      'Get rest data
      Messages.statusMsg = ""

      response = Await client.GetAsync("").ConfigureAwait(False)

      If Not response.IsSuccessStatusCode Then
        Messages.statusMsg = "API data error: " + response.ReasonPhrase
        GoTo abort
      End If

      rawResponseBody = Await response.Content.ReadAsStringAsync.ConfigureAwait(False)

      'Because this API returns json object text, we must create a json object and unpack it. Deserializing will not work :(
      jsonObject = JObject.Parse(rawResponseBody)


      'todo - try changing model names to match and see if deserializing works
      'Pack json object content into the model
      model.noteId = jsonObject.Item("id").ToString
      model.notetype = jsonObject.Item("type")
      model.noteSetup = jsonObject.Item("setup")
      model.notePunchLine = jsonObject.Item("punchline")

    Catch ex As Exception
      Messages.statusMsg = "Error getting record(s) | API Server error"
    End Try

    Return model
abort:
  End Function

End Class

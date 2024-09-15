Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Web.Script.Serialization
Imports Models
Imports Newtonsoft
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Globals
Imports APIBase


Public Class CatApiRepository(Of T)
  Inherits APIBase(Of Cat)
  Implements IRepository(Of Cat)

  Private APIurl As String = "https://localhost:7117/api/CatEmployees"

  'Private urlParameters As String = ""
  Private client As HttpClient ' = New HttpClient

  Public Sub New()
    MyBase.url = APIurl
  End Sub


  Public Sub insert(obj As Cat) Implements IRepository(Of Cat).insert
    '***** Must run api server first! C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI

    'remove unmapped field data
    obj.image = Nothing

    insertHelper(obj)

  End Sub

  Public Async Sub insertHelper(obj As Cat)
    Try

      Dim response As HttpResponseMessage = MyBase.insertAPIHelper(obj).Result
      Dim resStr As String = Await response.Content.ReadAsStringAsync

      If response.IsSuccessStatusCode Then

      Else
        MsgBox("Rest service error ", 0, "API service error")
      End If

      Dim result As New List(Of Cat)

    Catch ex As Exception
      Messages.statusMsg = "Error updating record(s) | API Server error"
      'MsgBox("Make sure API server is running:C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI\EmployeesAPI ", 0, "API Server error")
    End Try
  End Sub

  Public Sub save(obj As Cat) Implements IRepository(Of Cat).save
    '***** Must run api server first! C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI

    'Dim webClient As New System.Net.WebClient
    'Try

    'remove unmapped field data
    obj.image = Nothing

    saveHelper(obj)

    'Catch ex As Exception
    '  Messages.statusMsg = "Error saving record(s) | API Server error"
    '  'MsgBox("Make sure API server is running:C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI\EmployeesAPI ", 0, "API Server error")
    'End Try

    'Throw New NotImplementedException()
  End Sub

  Public Async Sub saveHelper(obj As Cat)
    Try

      Dim response As HttpResponseMessage = MyBase.saveAPIHelper(obj).Result
      Dim resStr As String = Await response.Content.ReadAsStringAsync

      If response.IsSuccessStatusCode Then

      Else
        MsgBox("Rest service error ", 0, "API service error")
      End If

      Dim result As New List(Of Cat)

    Catch ex As Exception
      Messages.statusMsg = "Error saving record(s) | API Server error"
    'MsgBox("Make sure API server is running:C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI\EmployeesAPI ", 0, "API Server error")
    End Try

  End Sub

  Public Function getAll(spParams As List(Of (String, String))) As IEnumerable(Of Cat) Implements IRepository(Of Cat).getAll
    'Dim cats As List(Of Cat) = getAllHelper(spParams).Result
    'Dim cats As List(Of Cat) = MyBase.getAll(spParams)
    'Return MyBase.getAll(spParams)

    Dim result As List(Of Cat) = getAllHelper(spParams).Result
    Return result
  End Function

  Private Function getAll() As IEnumerable(Of Cat) Implements IRepository(Of Cat).getAll
    Dim result As List(Of Cat) = getAllHelper(New List(Of (String, String))).Result
    Return result
  End Function

  'get()
  Public Async Function getAllHelper(List As List(Of (String, String))) As Task(Of IEnumerable(Of Cat))
    Try
      Dim response As HttpResponseMessage = Await getAllAPIHelper(List)
      'Dim response As HttpResponseMessage = MyBase.getAllAPIHelper(List).Result
      Dim resStr As String = Await response.Content.ReadAsStringAsync

      If response.IsSuccessStatusCode Then

      Else
        MsgBox("Rest service error ", 0, "API service error")
      End If

      Dim result As New List(Of Cat)

      'Pack json content into the model
      result = JsonConvert.DeserializeObject(Of List(Of Cat))(resStr)
      'res = JsonConvert.DeserializeObject(Of List(Of Cat))(response.Content.ToString)
      Return result

    Catch ex As Exception
      Messages.statusMsg = "Error getting record(s) | API Server error"
      'MsgBox("Make sure API server is running:C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI\EmployeesAPI ", 0, "API Server error")
    End Try

  End Function


  Public Function delete(id As Object) As Object Implements IRepository(Of Cat).delete

    'The unusedVar is needed to supress a warning that await is required. This function's interface wont allow await and this function calls 
    'a dll with an an await, we need to assign a bogus variable.
    Dim unusedVar = deleteHelper(id)
    Return Nothing
  End Function

  Public Async Function deleteHelper(id As Object) As Task(Of Boolean)
    ''***** Must run api server first! C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI

    Try
      Dim response As HttpResponseMessage = Await MyBase.deleteAPIHelper(id)

      If response.IsSuccessStatusCode Then
      Else
        MsgBox("Rest service error ", 0, "API service error")
      End If

      Return Nothing

    Catch ex As Exception
      Messages.statusMsg = "Error deleting record(s) | API Server error"
      Return Nothing
      'MsgBox("Make sure API server is running:C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI\EmployeesAPI ", 0, "API Server error")
    End Try
  End Function

  Public Function getById(id As Object) As Cat Implements IRepository(Of Cat).getById
    Throw New NotImplementedException()
  End Function

End Class

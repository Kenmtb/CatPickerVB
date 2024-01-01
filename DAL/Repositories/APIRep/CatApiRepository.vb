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

Public Class CatApiRepository(Of T)
  Implements ICatRepository(Of Cat)


  Private url As String = "https://localhost:7117/api/CatEmployees"
  Private urlParameters = ""
  Private client As HttpClient = New HttpClient




  Public Sub insert(obj As Cat) Implements ICatRepository(Of Cat).insert
    '***** Must run api server first! C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI

    Dim webClient As New System.Net.WebClient
    Try

      'remove unmapped field data
      obj.image = Nothing

      'convert data object to string
      client = New HttpClient()
      client.BaseAddress = New Uri(url)
      client.DefaultRequestHeaders.Accept.Add(New System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"))

      Dim str As String = JsonConvert.SerializeObject(obj)
      Dim buffer = System.Text.Encoding.UTF8.GetBytes(str)
      Dim byteData As ByteArrayContent = New ByteArrayContent(buffer)
      byteData.Headers.ContentType = New MediaTypeHeaderValue("application/json")

      'Dim response As HttpResponseMessage = client.PutAsync("", byteData).Result
      Dim response As HttpResponseMessage = client.PostAsync("", byteData).Result

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

  Public Sub save(obj As Cat) Implements ICatRepository(Of Cat).save
    '***** Must run api server first! C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI

    Dim webClient As New System.Net.WebClient
    Try

      'remove unmapped field data
      obj.image = Nothing

      'convert data object to string
      client = New HttpClient()
      client.BaseAddress = New Uri(url)
      client.DefaultRequestHeaders.Accept.Add(New System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"))

      Dim str As String = JsonConvert.SerializeObject(obj)
      'Dim str As String = '[{\"personID\":1,\"personName\":\"joe\",\"personAge\":20,\"personGender\":\"m\"}]'
      Dim buffer = System.Text.Encoding.UTF8.GetBytes(str)
      Dim byteData As ByteArrayContent = New ByteArrayContent(buffer)
      byteData.Headers.ContentType = New MediaTypeHeaderValue("application/json")

      Dim response As HttpResponseMessage = client.PutAsync("", byteData).Result

      If response.IsSuccessStatusCode Then

      Else
        MsgBox("Rest service error ", 0, "API service error")
      End If

      Dim result As New List(Of Cat)

    Catch ex As Exception
      Messages.statusMsg = "Error saving record(s) | API Server error"
      'MsgBox("Make sure API server is running:C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI\EmployeesAPI ", 0, "API Server error")
    End Try

    'Throw New NotImplementedException()
  End Sub


  Public Function getAll(spParams As List(Of (String, String))) As IEnumerable(Of Cat) Implements ICatRepository(Of Cat).getAll
    Dim cats As List(Of Cat) = getAllHelper(spParams).Result
    Return cats
  End Function

  Public Async Function getAllHelper(spParams As List(Of (String, String))) As Task(Of IEnumerable(Of Cat))

    '***** Must run api server first! C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI

    Try
      client = New HttpClient()

      'convert data object to string

      client.BaseAddress = New Uri(url + "/Post-GetAll")
      client.DefaultRequestHeaders.Accept.Add(New System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"))
      Dim str As String = JsonConvert.SerializeObject(spParams.ToArray)

      'Dim sl As New List(Of SQLParam)
      'Dim sq As New SQLParam
      'sq.item1 = "aaa"
      'sq.item2 = "bbb"
      'sl.Add(sq)
      'Dim str As String = JsonConvert.SerializeObject(sl)

      Dim buffer = System.Text.Encoding.UTF8.GetBytes(str)
      Dim byteData As ByteArrayContent = New ByteArrayContent(buffer)
      byteData.Headers.ContentType = New MediaTypeHeaderValue("application/json")

      'Dim response As HttpResponseMessage = client.PutAsync("", byteData).Result
      Dim response As HttpResponseMessage = client.PostAsync("", byteData).Result

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

    'Throw New NotImplementedException()
  End Function

  Public Function getAll() As IEnumerable(Of Cat) Implements ICatRepository(Of Cat).getAll
    '***** Must run api server first! C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI

    Dim webClient As New System.Net.WebClient
    Try

      'Get rest data from the web api
      Dim jsonStr As String = webClient.DownloadString(url)

      Dim result As New List(Of Cat)

      'Pack json content into the model
      result = JsonConvert.DeserializeObject(Of List(Of Cat))(jsonStr)
      'res = JsonConvert.DeserializeObject(Of List(Of Cat))(response.Content.ToString)
      Return result
    Catch ex As Exception
      Messages.statusMsg = "Error getting record(s) | API Server error"
      'MsgBox("Make sure API server is running:C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI\EmployeesAPI ", 0, "API Server error")
    End Try

  End Function

  Public Function getById(id As Object) As Cat Implements ICatRepository(Of Cat).getById
    Throw New NotImplementedException()
  End Function

  Public Function delete(id As Object) As Object Implements ICatRepository(Of Cat).delete
    '***** Must run api server first! C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI

    Dim webClient As New System.Net.WebClient
    Try

      client = New HttpClient()
      client.BaseAddress = New Uri(url + "/" + id.ToString)
      client.DefaultRequestHeaders.Accept.Add(New System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"))

      'Dim str As String = JsonConvert.SerializeObject(obj)
      'Dim buffer = System.Text.Encoding.UTF8.GetBytes(str)
      'Dim byteData As ByteArrayContent = New ByteArrayContent(buffer)
      'byteData.Headers.ContentType = New MediaTypeHeaderValue("application/json")

      'Dim response As HttpResponseMessage = client.PutAsync("", byteData).Result
      Dim response As HttpResponseMessage = client.DeleteAsync("").Result

      If response.IsSuccessStatusCode Then

      Else
        MsgBox("Rest service error ", 0, "API service error")
      End If

      Dim result As New List(Of Cat)

    Catch ex As Exception
      Messages.statusMsg = "Error deleting record(s) | API Server error"
      'MsgBox("Make sure API server is running:C:\Users\Ken\source\repos\EmployeesAPI\EmployeesAPI\EmployeesAPI\EmployeesAPI ", 0, "API Server error")
    End Try
  End Function




End Class

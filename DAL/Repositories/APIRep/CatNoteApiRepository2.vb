Imports System.Net.Http
Imports Models
Imports Newtonsoft.Json
Public Class CatNoteApiRepository2
  Private url As String = "https://localhost:7117/api/CatEmployees"
  Private urlParameters = ""
  Private client As HttpClient = New HttpClient
  Private model As CatNote
  Public Sub getAll()

    client.BaseAddress = New Uri(url)
    client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

    Try
      'Get rest data
      Dim response As HttpResponseMessage = client.GetAsync(urlParameters).Result

      'Pack json content into the model
      model = JsonConvert.DeserializeObject(Of CatNote)(response.Content.ToString)

    Catch ex As Exception

    End Try

  End Sub
End Class

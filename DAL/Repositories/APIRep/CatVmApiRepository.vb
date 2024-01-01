Imports System.Net.Http
Imports Models
Imports Newtonsoft.Json

Public Class CatVmApiRepository

  Private url As String = "https://localhost:7117/api/CatEmployees"
  Private urlParameters = ""
  Private client As HttpClient = New HttpClient
  Private vm As CatVM

  Public Function getAll() As CatVM

    client.BaseAddress = New Uri(url)
    client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

    Try
      'Get rest data
      Dim response As HttpResponseMessage = client.GetAsync(urlParameters).Result

      'Pack json content into the model
      vm.catList = JsonConvert.DeserializeObject(Of List(Of Cat))(response.Content.ToString)

    Catch ex As Exception

    End Try

  End Function

  Public Sub save(rec As Cat)

  End Sub

End Class

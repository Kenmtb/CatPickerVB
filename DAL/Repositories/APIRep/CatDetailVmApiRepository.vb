Imports System.Net.Http
Imports Models
Imports Newtonsoft.Json

'11/29/24 - Considering removing VM apis as we can integrate data at the regular VM level
Public Class CatDetailVmApiRepository
  Private url As String = "https://localhost:7117/api/CatEmployees"
  Private urlParameters = ""
  Private client As HttpClient = New HttpClient
  Private vm As CatDetailsVM
  Private noteRep As CatNoteApiRepository(Of CatNote) 'IRepository(Of CatNote)
  Private catNoteList As New List(Of CatNote)

  Public Function getAll() As CatDetailsVM

    client.BaseAddress = New Uri(url)
    client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

    Try
      'Get rest data
      Dim response As HttpResponseMessage = client.GetAsync(urlParameters).Result

      'Pack json content into the model
      vm.catDetailList = JsonConvert.DeserializeObject(Of List(Of CatDetail))(response.Content.ToString)

      '*** 11/29/24 Note code to add catnotes moved to catDetailsVM. That will allow integration of models at a higher level.


    Catch ex As Exception

    End Try

  End Function

End Class

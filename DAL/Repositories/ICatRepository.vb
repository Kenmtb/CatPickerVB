Imports System.Data.SqlClient


Public Interface ICatRepository(Of T)
  'Function getAll(Optional ByVal sqlStr As String = Nothing, Optional ByRef paramList As List(Of SqlParameter) = Nothing) As IEnumerable(Of T)
  Function getAll() As IEnumerable(Of T)

  Function getAll(spParams As List(Of (String, String))) As IEnumerable(Of T)
  'Function getAll(spParams As List(Of (String, String))) As Task(Of IEnumerable(Of T))


  Function getById(id As Object) As T

  Sub insert(obj As T)

  Function delete(id As Object)

  Sub save(obj As T)

  'Sub update(obj As T)
End Interface

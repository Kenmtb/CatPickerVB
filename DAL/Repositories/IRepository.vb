Imports System.Data.SqlClient
Imports Models

Public Interface IRepository(Of T)

  Function getAll() As IEnumerable(Of T)

  Function getAll(spParams As List(Of (String, String))) As IEnumerable(Of T)

  Function getById(id As Object) As IEnumerable(Of T)

  Sub insert(obj As T)

  Function delete(id As Object) As Object

  Sub save(obj As T)

End Interface

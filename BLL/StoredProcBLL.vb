Imports DAL
Imports Models
Imports Models.StoredProc
Public Class StoredProcBLL(Of T)
  Dim spRep As New StoredProcRep(Of T)
  Dim rep As New CatRepository(Of T)


  Public Function getFilteredData(spParams As List(Of ValueTuple(Of String, String))) As Cat
    Return Nothing
  End Function
End Class

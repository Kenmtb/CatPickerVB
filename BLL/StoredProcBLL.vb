Imports DAL
Imports Models
Imports Models.StoredProc
Public Class StoredProcBLL '(Of T)
  Dim spRep As New StoredProcRep '(Of T)
  'Dim rep As New CatRepository(Of T)

  '9/28/24 - this function will receive a generic data table for now. It is the responsibility of the caller to pack the data into a data object.
  Public Function getSPData(spParams As List(Of (String, String))) As DataTable
    Return spRep.runSP("spGetCatsBy_Age_Breed_Gender", spParams)
  End Function

  Public Function createCatNoteSP(spParams As List(Of (String, String))) As DataTable
    Return spRep.runSP("spInsertCatNotes", spParams)
  End Function



  'Public Function getFilteredData(spParams As List(Of ValueTuple(Of String, String))) As Cat
  '  Return Nothing
  'End Function
End Class

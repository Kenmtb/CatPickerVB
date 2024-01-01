Imports DAL
Imports Models
Public Class CatFilterBLL
  Dim vmCatFilterRep As New CatVMFilterepository()

  Public Function getAll() As CatFilterVM
    Return vmCatFilterRep.getAll()
  End Function
End Class

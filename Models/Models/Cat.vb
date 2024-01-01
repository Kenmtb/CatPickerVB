Imports System.ComponentModel.DataAnnotations.Schema


<Table("dbo.Cats")>
Public Class Cat
  'hidden
  Public Property Id As Integer
  Public Property breedId As Integer?
  Public Property detailsId As Nullable(Of Integer)

  'display
  Public Property name As String
  Public Property age As Nullable(Of Integer)
  Public Property pic As String
  Public Property gender As String
  Public Property mainColor As String
  Public Property secondColor As String
  Public Property thirdColor As String
  Public Property arrivalDate As Date ' Nullable(Of DateTime)


  <NotMapped>
  Public Property image As Byte() 'Holds graphic data
  Public Property selected As Boolean

End Class

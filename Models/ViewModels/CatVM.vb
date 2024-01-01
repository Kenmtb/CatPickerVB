Public Class CatVM
  'record list
  Public Property catList As List(Of Cat)

  'foreign fields
  Public Property breedName As String
  Public Property breedid As Integer

  'drop downs and foriegn key lookup lists
  Public Property catBreedList As List(Of CatBreed)
End Class

Public Class CatVM
  'record list
  Public Property catList As List(Of Cat) 'for the editor
  'Public Property showCatList As List(Of showCat) 'for the datagridview display (fields outside of Cats are included)

  'foreign fields
  'Public Property breedName As String
  Public Property breedid As Integer

  'drop downs and foriegn key lookup lists
  Public Property catBreedList As List(Of CatBreed)
End Class

Public Class CatFilterVM
  'This VM supplies the cat filter UI panel
  'drop downs and foriegn key lookup lists
  Public Property catGenderList As List(Of String) 'Gender is "Male", "Female" and will come from a hardwired list in the DAL
  Public Property catBreedList As List(Of CatBreed)
  'No need for age list.
End Class

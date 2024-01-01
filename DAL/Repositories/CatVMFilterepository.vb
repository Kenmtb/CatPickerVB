Imports Models
Public Class CatVMFilterepository
  Private vm As CatFilterVM
  Private breedRep As CatBreedRepository(Of CatBreed)

  Public Function getAll() As CatFilterVM
    vm = New CatFilterVM()
    vm.catGenderList = New List(Of String) From {"Male", "Female"}

    breedRep = New CatBreedRepository(Of CatBreed)
    vm.catBreedList = breedRep.getAll()
    'No list for age needed
    Return vm
  End Function
End Class

Imports Models
Imports Globals

Public Class CatVMRepository

  Private vm As CatVM

  'rep - comes from catRepository. rep's repository is changed in catRepository
  Private rep As ICatRepository(Of Cat)

  Private catbreed As New CatBreedRepository(Of CatBreed)
  Private detailsRep As CatDetailRepository(Of CatDetail)

  Public Sub New(rep As ICatRepository(Of Cat))

    Me.rep = rep
    'Dim rep = New CatRepository(Of Cat)
    'Dim detailsRep = New CatDetailRepository(Of CatDetail)

    'Instantiate models
    'vm = New CatVM()
    'vm.catList = (New CatRepository(Of Cat)).getAll().ToList()
    'vm.catBreedList = (New CatBreedRepository(Of CatBreed)).getAll.ToList()
  End Sub

  Public Function getAll() As CatVM
    Try
      vm = New CatVM()

      vm.catList = rep.getAll().ToList()
      'vm.catList = (New CatRepository(Of Cat)).getAll().ToList()
      vm.catBreedList = catbreed.getAll.ToList()
      vm.catBreedList.Insert(0, New CatBreed() With {.Id = -1, .breedName = Globals.Defs.selectString}) 'add -- Select -- to front of list 

      Return vm
    Catch ex As Exception
      'Throw New CustomException("Error getting data")
    End Try
  End Function


  Public Function getAll(spParams As List(Of (String, String))) As CatVM
    Try
      'SP filter
      vm = New CatVM()
      vm.catList = rep.getAll(spParams).ToList()
      'vm.catList = (New CatRepository(Of Cat)).getAll(spParams).ToList()
      vm.catBreedList = catbreed.getAll.ToList()
      Return vm
    Catch ex As Exception
      'Messages.statusMsg = "API service error"
    End Try
  End Function

  Public Function getById(id As Integer) As CatVM

    Return vm
  End Function

End Class

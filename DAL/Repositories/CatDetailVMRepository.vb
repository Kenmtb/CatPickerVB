Imports Models
Imports Globals
Public Class CatDetailVMRepository

  Private vm As CatDetailsVM
  Private VMprimaryList As List(Of CatDetail) 'This will be the VM's primary list coming from an API callback

  'rep - comes from catRepository. rep's repository is changed in catRepository
  Private rep As IRepository(Of CatDetail)

  'Private catbreed As New CatBreedRepository(Of CatBreed)
  Private detailsRep As CatDetailRepository(Of CatDetail)

  Public Sub New(rep As IRepository(Of CatDetail))

    Me.rep = rep
    'Dim rep = New CatRepository(Of Cat)
    'Dim detailsRep = New CatDetailRepository(Of CatDetail)

    'Instantiate models
    'vm = New CatVM()
    'vm.catList = (New CatRepository(Of Cat)).getAll().ToList()
    'vm.catBreedList = (New CatBreedRepository(Of CatBreed)).getAll.ToList()
  End Sub

  Public Function getAll() As CatDetailsVM
    Try
      vm = New CatDetailsVM()

      vm.catDetailList = rep.getAll().ToList()

      Return vm
    Catch ex As Exception
      'Throw New CustomException("Error getting data")
    End Try
  End Function


  Public Function getAll(spParams As List(Of (String, String))) As CatDetailsVM
    Try
      'SP filter
      vm = New CatDetailsVM()
      vm.catDetailList = rep.getAll(spParams).ToList()
      'vm.catList = (New CatRepository(Of Cat)).getAll(spParams).ToList() 
      Return vm
    Catch ex As Exception
      'Messages.statusMsg = "API service error"
    End Try
  End Function


  Public Function getById(id As Integer) As CatDetailsVM

    Return vm
  End Function
End Class

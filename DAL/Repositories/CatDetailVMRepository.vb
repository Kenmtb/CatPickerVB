Imports Models
Imports Globals
Public Class CatDetailVMRepository

  Private vm As CatDetailsVM
  'Private VMprimaryList As List(Of CatDetail) 'This will be the VM's primary list coming from an API callback

  'rep - comes from catRepository. rep's repository is changed in catRepository
  Private rep As IRepository(Of CatDetail)

  Private catNoteRep As IRepository(Of CatNote)


  'Private catbreed As New CatBreedRepository(Of CatBreed)
  'Private detailsRep As CatDetailRepository(Of CatDetail)

  Public Sub New(rep As IRepository(Of CatDetail), catNoteRep As IRepository(Of CatNote))

    Me.rep = rep
    Me.catNoteRep = catNoteRep
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

      vm = New CatDetailsVM()
      vm.catDetailList = rep.getAll(spParams).ToList()

      'Get a list of cat notes for each cat record
      For Each detailRec As CatDetail In vm.catDetailList
        'get the note list
        vm.catNoteList = catNoteRep.getAll(
        New List(Of ValueTuple(Of String, String)) From
          {New ValueTuple(Of String, String)("@CatId", detailRec.catId)}
        ).ToList()

      Next


      '        2) add the list to the record

      Return vm
    Catch ex As Exception
      'Messages.statusMsg = "API service error"
    End Try
  End Function


  Public Function getById(id As Integer) As CatDetailsVM

    Return vm
  End Function
End Class

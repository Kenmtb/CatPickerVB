Imports Models
Imports Globals
Imports DAL
Imports System.Linq
Public Class Utilities


  Public Sub New()

  End Sub

  Public Function getSelectedCatsFromModel(model As List(Of Cat)) As List(Of Cat)
    'Dim selCats As List(Of Cat)
    Dim selCats = From x In model Where x.selected = True

    'create a vm with selCats
    Dim catvm As New CatVM
    catvm.catList = selCats

    'call controler/showCats(vm) or showSelectedCats(vm) , send display 
    'Dim ctrl As 

    'may convert this function to a sub.

    Return selCats
  End Function

End Class

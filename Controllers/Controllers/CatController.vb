Imports BLL
Imports Models
Imports Globals
Imports Forms
Imports CatPickerVB

Imports System.Windows.Forms

Public Class CatController

  Dim bll As New BLL.CatBLL
  Dim vm As New CatVM
  Dim frm As IFormView(Of CatVM)

  Public Sub New(frm As IFormView(Of CatVM))
    Me.frm = frm
  End Sub


  Public Sub New()

  End Sub

  Public Sub startForm()
    'fill the startup VM
    vm = bll.getAll()

    frm.initForm(vm)
    frm.Show()
  End Sub

  Public Sub ShowSelectedCats(vm As CatVM)

    Dim model As List(Of Cat) = vm.catList
    Dim selCats = From x In model Where x.selected = True

    Dim view As New ViewShowCats()
    view.frm = New frmShowCats
    view.vm = vm

    'create a vm with selCats
    Dim catvm As New CatVM
    catvm.catList = selCats.ToList()

    view.frm.initForm(catvm)
    view.frm.Show()

  End Sub


End Class

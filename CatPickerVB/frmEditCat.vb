Imports Models
Imports Globals
Imports Globals.Defs

Public Class frmEditCat
  Implements Globals.IFormView(Of CatVM)
  Dim bll As New BLL.CatBLL
  Dim catList = New List(Of Cat)
  Dim frm As Form1
  Dim ctrl As CatController

  Dim vm As CatVM

  'move to resource file
  'Dim imageDir As String = "C:\Users\Ken\source\repos\CatPicker\CatPicker\Images\Cats\"

  'get the form data
  'Public Property vm As CatVM

  Public Sub New()
    ' This call is required by the designer.
    InitializeComponent()
    frm = New Form1()
    'ctrl = New CatController
  End Sub

  Public Sub initForm(vm As CatVM) Implements IFormView(Of CatVM).initForm

    Me.vm = vm
    catList = vm.catList

    Dim bs As New BindingSource()
    bs.DataSource = catList
    dgvCats.DataSource = catList

    'Move to resource file
    Dim img As Image

    'Format
    For Each col As DataGridViewColumn In dgvCats.Columns
      col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    Next

    dgvCats.RowTemplate.Height = 80
    dgvCats.CellBorderStyle = DataGridViewCellBorderStyle.None

    Dim imageCol As DataGridViewImageColumn = dgvCats.Columns("image")
    imageCol.Width = 150
    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom

    dgvCats.Columns("Image").DisplayIndex = 0
    dgvCats.Columns("image").HeaderText = "Picture"
    dgvCats.Columns("name").HeaderText = "Name"
    dgvCats.Columns("age").HeaderText = "Age"
    dgvCats.Columns("gender").HeaderText = "Gender"
    dgvCats.Columns("mainColor").HeaderText = "Main Color"
    dgvCats.Columns("secondColor").HeaderText = "Second Color"
    dgvCats.Columns("thirdColor").HeaderText = "Third Color"
    dgvCats.Columns("arrivalDate").HeaderText = "Arrival Date"

    'Hide
    dgvCats.Columns("Id").Visible = False
    dgvCats.Columns("breedId").Visible = False
    dgvCats.Columns("detailsId").Visible = False
    dgvCats.Columns("pic").Visible = False


    'ADD images to columns
    For Each row As DataGridViewRow In dgvCats.Rows

      'dirImg = imageDir + row.Cells("pic").Value.ToString()

      'get the stored image
      img = Image.FromFile(imageDir + row.Cells("pic").Value.ToString())
      'update the image control
      row.Cells("image").Value = img

    Next

    'hide empty columns
    removeEmptyColumns()

  End Sub

  Private Sub removeEmptyColumns()
    Dim emptyCounter As Integer = 0
    'Iterate through each column
    For columnIndex As Integer = dgvCats.Columns.Count - 1 To 0 Step -1
      'Reset the counter
      emptyCounter = 0

      'Iterate through each row
      For rowIndex As Integer = 0 To dgvCats.Rows.Count - 1
        'Compare the currently iterated cell
        If dgvCats.Rows(rowIndex).Cells(columnIndex).Value Is Nothing OrElse
          dgvCats.Rows(rowIndex).Cells(columnIndex).Value.ToString = Date.MinValue.ToString Then
          'Increment the counter
          emptyCounter += 1
        End If
      Next

      'Compare if the emptyCounter is greater than or equal to the total row count (I say greater than just incase it compares the blank row)
      If emptyCounter >= dgvCats.Rows.Count - 1 Then
        'Remove the currently iterated column
        dgvCats.Columns(columnIndex).Visible = False
      End If
    Next
  End Sub


  Private Sub IFormView_Show() Implements IFormView(Of CatVM).Show
    Throw New NotImplementedException()
  End Sub

  Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    'bll.save(vm.catList)
  End Sub

  Private Sub frmEditCat_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub
End Class
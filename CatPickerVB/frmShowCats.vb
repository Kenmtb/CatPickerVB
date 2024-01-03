
Imports Models
Imports Globals
Imports Globals.Defs
Imports Globals.Utilities
Imports System.IO

Public Class frmShowCats
  Implements Globals.IFormView(Of CatVM)
  Dim bll As New BLL.CatBLL

  Public catList = New List(Of Cat)

  Dim filterBll As New BLL.CatFilterBLL

  Dim frm As Form1
  Dim ctrl As CatController
  Dim vm As CatVM
  Dim rec As Cat
  Dim recIndex As Integer
  Dim bs As BindingSource

  Dim parmList As New List(Of ValueTuple(Of String, String))

  Dim lastRowBoxSelected As Integer = -1 'Preserve the last row's selected box check state
  Dim lastRowSelected As Integer = -1 'Preserve the las row selected

  Public Sub New()
    ' This call is required by the designer.
    InitializeComponent()
    frm = New Form1()
    pnlSearch.Visible = False
    pnlNewCat.Visible = False
    pnlEdit.Visible = True

    grpMenu.Controls.Find("radEdit", True)(0).Select()

    'ctrl = New CatController
  End Sub


  Private Sub bindControls()

  End Sub

  Private Sub setUpForm(vm As CatVM)

  End Sub

  Public Sub initForm(vm As CatVM) Implements IFormView(Of CatVM).initForm

    Try
      ' Add any initialization after the InitializeComponent() call.

      txtStatus.Text = Messages.statusMsg 'get any prev. message


      'If vm.catList.Count = 0 Then GoTo endd

      Me.vm = vm
      catList = vm.catList

      bs = New BindingSource()
      bs.DataSource = catList
      dgvShowCats.DataSource = catList

      'Move to resource file
      Dim img As Image

      'Format
      For Each col As DataGridViewColumn In dgvShowCats.Columns
        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
      Next

      dgvShowCats.RowTemplate.Height = 40 '80
      dgvShowCats.CellBorderStyle = DataGridViewCellBorderStyle.None

      'Format image column
      Dim imageCol As DataGridViewImageColumn = dgvShowCats.Columns("image")
      imageCol.Width = 150
      imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom

      dgvShowCats.Columns("Image").DisplayIndex = 0
      dgvShowCats.Columns("image").HeaderText = "Picture"
      dgvShowCats.Columns("name").HeaderText = "Name"
      dgvShowCats.Columns("age").HeaderText = "Age"
      dgvShowCats.Columns("gender").HeaderText = "Gender"
      dgvShowCats.Columns("mainColor").HeaderText = "Main Color"
      dgvShowCats.Columns("secondColor").HeaderText = "Second Color"
      dgvShowCats.Columns("thirdColor").HeaderText = "Third Color"
      dgvShowCats.Columns("arrivalDate").HeaderText = "Arrival Date"
      dgvShowCats.Columns("selected").HeaderText = "Selected"
      dgvShowCats.RowHeadersVisible = False

      'bind editor controls to data grid  *move to sep. sub
      ClearFormBindings(Me)

      txtName.DataBindings.Add(New System.Windows.Forms.Binding("Text", bs.DataSource, "name", True))
      txtAge.DataBindings.Add(New System.Windows.Forms.Binding("Text", bs.DataSource, "age", True))
      cmbGender.DataBindings.Add(New System.Windows.Forms.Binding("Text", bs.DataSource, "gender", True))
      tdpEditArivalDate.DataBindings.Add(New System.Windows.Forms.Binding("Text", bs.DataSource, "arrivalDate", True))
      txtCatPicName.DataBindings.Add(New System.Windows.Forms.Binding("Text", bs.DataSource, "pic", True))

      'Hide
      dgvShowCats.Columns("Id").Visible = False
      dgvShowCats.Columns("breedId").Visible = False
      dgvShowCats.Columns("detailsId").Visible = False
      dgvShowCats.Columns("pic").Visible = False
      'dgvShowCats.Columns("selected").Visible = False

      'ADD images to columns
      For Each row As DataGridViewRow In dgvShowCats.Rows

        'dirImg = imageDir + row.Cells("pic").Value.ToString()

        'get the stored image
        img = Image.FromFile(imageDir + row.Cells("pic").Value.ToString())
        'update the image control
        row.Cells("image").Value = img

      Next

      'Initialize data
      dlgPictures.InitialDirectory = imageDir
      cmbBreed.DataSource = vm.catBreedList
      cmbBreed.DisplayMember = "breedName"
      cmbBreed.ValueMember = "Id"

      'Create a "clone" of cat breed list and use it as cmbNewCatBreed list data source. This unbinds the new list from
      'cmbBreed's datasource. Otherwise both lists would change when moving throught the data grid view's records.
      Dim newCatBreedList As New List(Of CatBreed)
      For Each brd As CatBreed In vm.catBreedList
        newCatBreedList.Add(brd)
      Next
      cmbNewCatBreed.DataSource = newCatBreedList
      cmbNewCatBreed.DisplayMember = "breedName"
      cmbNewCatBreed.ValueMember = "Id"

      If lastRowSelected > -1 Then
        'Reselect the last selected row and trigger the binding source.
        dgvShowCats.Rows(lastRowSelected).Selected = True
        dgvShowCats.CurrentCell = dgvShowCats.Rows(lastRowSelected).Cells(3) 'trigger bind source, use cell (3) because its  non hidden. 
      ElseIf vm.catList.Count > 0 Then
        'select the first row
        dgvShowCats.Rows(0).Selected = True
        dgvShowCats.CurrentCell = dgvShowCats.Rows(0).Cells(3) 'trigger bind source, use cell (3) because its  non hidden. 
      End If

      Dim currentRow As DataGridViewRow = dgvShowCats.CurrentRow
      If Not IsNothing(currentRow) Then cmbBreed.SelectedValue = currentRow.Cells("breedId").Value

      Messages.statusMsg = "Record count: " + vm.catList.Count.ToString

bypass:
endd:
    Catch e As Exception

    End Try
  End Sub


  Private Function getImageFromStringPathName(imagePathName As String) As Image
    Return Image.FromFile(imagePathName)
  End Function

  Private Sub catDetails(img As Image, name As String)
    picCatPic.Image = img
    txtCatPicName.Text = name
  End Sub

  Private Sub dgvShowCats_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvShowCats.RowEnter


    If e.RowIndex > -1 Then
      recIndex = e.RowIndex
      Dim cells As DataGridViewCellCollection = dgvShowCats.Rows(recIndex).Cells

      '  'catDetails(Image.FromFile(imageDir + dgvShowCats.Rows(row).Cells("pic").Value), dgvShowCats.Rows(row).Cells("name").Value)
      '  'Not sure why this is a composite object, my try breaking into a pic box and text box
      'catDetails(Image.FromFile(imageDir + cells("pic").Value), cells("pic").Value)
      picCatPic.Image = Image.FromFile(imageDir + cells("pic").Value)

      'editor controls
      Dim breeds As List(Of CatBreed) = vm.catBreedList
      Dim breedNames = From brd In breeds
                       Where brd.Id = cells("breedId").Value

      cmbBreed.Text = breedNames(0).breedName

    End If
  End Sub

  Private Sub updateViewModel()

  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    If Not frm.Visible Then
      'frm = New Form1()
      frm.Show()
    End If

    frm.Show()
    frm.TextBox1.Text = txtCatPicName.Text
    txtCatPicName.Text = frm.sayHi() + " " + txtCatPicName.Text
  End Sub

  Private Sub IFormView_Show() Implements IFormView(Of CatVM).Show
    'this overloads the the interface's base class Form.Show()
    Me.Show()
  End Sub

  Private Sub btnShowSelected_Click(sender As Object, e As EventArgs) Handles btnShowSelected.Click
    'Get catID, catname and pic of each checked cat, put into tuple.

    Dim catList As New List(Of Cat)

    For Each dr As DataGridViewRow In dgvShowCats.Rows
      Dim catRec As Cat
      If dr.Cells("selected").Value = True Then
        catRec = New Cat
        catRec.name = dr.Cells("name").Value
        catRec.Id = dr.Cells("Id").Value
        catRec.pic = dr.Cells("pic").Value
        catList.Add(catRec)
      End If
    Next

    'Display the selected cats
    Dim vm As New CatVM
    vm.catList = catList

    ctrl = New CatController
    ctrl.ShowEditor(vm)


  End Sub

  Private Sub btnShowEditor_Click(sender As Object, e As EventArgs) Handles btnShowEditor.Click
    Dim vm As New CatVM
    vm.catList = catList

    ctrl = New CatController
    ctrl.ShowEditor(vm)
  End Sub

  Private Sub picCatPic_Click(sender As Object, e As EventArgs) Handles picCatPic.Click

    dlgPictures.ShowDialog()

    'txtCatPicName.Select()
    txtCatPicName.Text = System.IO.Path.GetFileName(dlgPictures.FileName)
    txtCatPicName.DataBindings("Text").WriteValue() ' required to programatically update controls because ms is to stupid to make it simple

    picCatPic.Image = Image.FromFile(dlgPictures.FileName)

    'btnSave.Select()
    bs.EndEdit()

  End Sub

  Private Sub radEdit_CheckedChanged(sender As Object, e As EventArgs) Handles radEdit.CheckedChanged
    If radEdit.Checked Then
      pnlSearch.Visible = False
      pnlNewCat.Visible = False
      pnlEdit.Visible = True
    End If
  End Sub

  Private Sub radSearch_CheckedChanged(sender As Object, e As EventArgs) Handles radSearch.CheckedChanged
    If radSearch.Checked Then
      pnlSearch.Visible = True
      pnlNewCat.Visible = False
      pnlEdit.Visible = False

      'get panel data
      Dim filterVM As Models.CatFilterVM
      filterVM = filterBll.getAll()
      cmbSearchBreed.DataSource = filterVM.catBreedList
      cmbSearchBreed.DisplayMember = "breedName"
      cmbSearchBreed.ValueMember = "Id"

      cmbSearchGender.Items.Clear()
      cmbSearchGender.Items.Add("Male")
      cmbSearchGender.Items.Add("Female")

    End If

  End Sub

  Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

    'Messages.statusMsg = "Searching"
    txtStatus.Text = "Searching..."

    Dim breedId As String = If(IsNothing(cmbSearchBreed.SelectedValue) Or cmbSearchBreed.Text = "", "", cmbSearchBreed.SelectedValue)
    Dim gender As String = cmbSearchGender.Text
    Dim age As String = txtSearchAge.Text

    'Call SP
    Dim spBLL As New BLL.StoredProcBLL(Of Cat)

    'Set up params
    parmList.Clear()
    parmList.Add(ValueTuple.Create("breedId", breedId))
    parmList.Add(ValueTuple.Create("gender", gender))
    parmList.Add(ValueTuple.Create("age", age))

    Dim vm As CatVM = bll.getAll(parmList)
    initForm(vm)

    txtStatus.Text = Messages.statusMsg
  End Sub

  Private Sub dgvShowCats_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvShowCats.CellContentClick
    If dgvShowCats.Columns(e.ColumnIndex).Name.ToString = "selected" Then

      'Toggle the selected check box
      dgvShowCats.Rows(e.RowIndex).Cells("selected").Value = Not (dgvShowCats.Rows(e.RowIndex).Cells("selected").Value)
    End If

    'Preserve the last selected datagrid row
    lastRowSelected = dgvShowCats.SelectedCells(0).RowIndex

  End Sub

  Private Sub dgvShowCats_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvShowCats.RowStateChanged
    'Preserve the last selected row check box
    If dgvShowCats.SelectedRows.Count > 0 Then
      lastRowBoxSelected = dgvShowCats.SelectedRows(0).Index
    End If
  End Sub

  Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
    'get the record
    Dim rec As New Cat
    rec.name = txtNewCatName.Text
    rec.age = txtNewCatAge.Text
    rec.gender = cmbNewCatGender.Text
    rec.breedId = cmbNewCatBreed.SelectedValue
    rec.detailsId = defaultDetailsId
    rec.mainColor = defaultCatColor
    rec.secondColor = defaultCatColor
    rec.thirdColor = defaultCatColor
    rec.pic = txtNewCatPicName.Text

    If txtNewCatPicName.Text = "" Then
      rec.pic = Defs.defaultPicName
    Else
      rec.pic = txtNewCatPicName.Text
    End If

    'rec.arrivalDate = If(IsDate(txtNewCatDate.Text), txtNewCatDate.Text, #01/01/1900#)
    rec.arrivalDate = If(IsDate(tdpNewArivalDate.Text), tdpNewArivalDate.Text, #01/01/1900#)
    bll.insert(rec)

    dgvShowCats.DataSource = Nothing
    vm = bll.getAll()

    Messages.statusMsg = "Record count: " + vm.catList.Count.ToString
    initForm(vm)

  End Sub

  Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    Dim response As String
    rec = catList(recIndex)

    response = MsgBox("Delete Y/N?", vbYesNo)
    If response = vbYes Then
      bll.delete(rec.Id)

      dgvShowCats.DataSource = Nothing
      vm = bll.getAll()

      Messages.statusMsg = "Record count: " + vm.catList.Count.ToString
      initForm(vm)

    End If
  End Sub

  Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
    parmList.Clear()
    parmList.Add(ValueTuple.Create("breedId", ""))
    parmList.Add(ValueTuple.Create("gender", ""))
    parmList.Add(ValueTuple.Create("age", ""))

    cmbSearchBreed.Text = ""
    cmbSearchGender.Text = ""
    txtSearchAge.Text = ""

    'Dim vm As CatVM = bll.getAll(parmList)
    'initForm(vm)

    'txtStatus.Text = Messages.statusMsg
  End Sub

  Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    If Not validateForm() Then GoTo abort

    rec = catList(recIndex)

    'Handle unbound controls
    rec.breedId = cmbBreed.SelectedItem.Id

    bll.save(rec)

    dgvShowCats.DataSource = Nothing
    'vm = bll.getAll()
    vm = bll.getAll(parmList)

    Messages.statusMsg = "Record count: " + vm.catList.Count.ToString
    initForm(vm)
abort:
  End Sub

  Private Sub btnNewCat_Click(sender As Object, e As EventArgs) Handles btnNewCat.Click
    pnlNewCat.Visible = True
    pnlEdit.Visible = False
    pnlSearch.Visible = False
    cmbNewCatBreed.SelectedIndex = 0
  End Sub

  Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

  End Sub

  Private Function getCatPicFile() As String
    Dim picFile As String = ""

    openFileDialog1.Filter = "Image File | *.jpg"

    If Directory.Exists(imageDir) Then
      openFileDialog1.InitialDirectory = imageDir
    Else
      openFileDialog1.InitialDirectory = "C:\"
    End If

    If openFileDialog1.ShowDialog = DialogResult.OK Then
      picFile = openFileDialog1.SafeFileName
    End If

    Return picFile

  End Function


  Private Sub radNew_CheckedChanged(sender As Object, e As EventArgs) Handles radNew.CheckedChanged
    pnlNewCat.Visible = True
    pnlEdit.Visible = False
    pnlSearch.Visible = False
    cmbNewCatBreed.SelectedIndex = 0
  End Sub



  Private Sub btnSelectNewCatPic_Click(sender As Object, e As EventArgs) Handles btnSelectNewCatPic.Click
    Dim picFile As String = getCatPicFile()
    picNewCatPic.Image = Image.FromFile(imageDir + picFile)
    txtNewCatPicName.Text = picFile
  End Sub

  Private Sub btnSelectCatPic_Click(sender As Object, e As EventArgs) Handles btnSelectCatPic.Click
    Dim picFile As String = getCatPicFile()
    picCatPic.Image = Image.FromFile(imageDir + picFile)
    txtCatPicName.Text = picFile
    txtCatPicName.DataBindings("Text").WriteValue() 'the control is bound so if it changes programatically then update the binding
  End Sub

  Private Function validateForm() As Boolean
    Dim valid As Boolean = True
    'Note, txtAge is bound so set prop CausesValidation=false otherwise errors will prevent leaving control's editor.

    ErrorProvider1.Clear()

    If String.IsNullOrEmpty(txtName.Text.Trim) Then
      ErrorProvider1.SetError(txtName, "Please enter a value")
      valid = False
      txtName.Focus()

    ElseIf txtName.Text.Length > 20 Then
      ErrorProvider1.SetError(txtName, "Maximum of 20 characters")
      valid = False
      txtName.Focus()

    ElseIf String.IsNullOrEmpty(txtAge.Text.Trim) Then
      ErrorProvider1.SetError(txtAge, "Please enter a value")
      valid = False
      txtAge.Focus()

    ElseIf Convert.ToInt32(txtAge.Text) > 99 Or Convert.ToInt32(txtAge.Text) < 1 Then
      ErrorProvider1.SetError(txtAge, "Please enter age (1-99)")
      valid = False
      txtAge.Focus()

    ElseIf Not IsNumeric(txtAge.Text.Trim) Then
      ErrorProvider1.SetError(txtAge, "Please enter a numeric value")
      valid = False
      txtAge.Focus()
    End If

    Return valid

  End Function

  Private Sub txtAge_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAge.Validating

  End Sub

  Private Sub cmbSearchGender_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbSearchGender.KeyDown
    e.SuppressKeyPress = True
  End Sub

  Private Sub cmbSearchBreed_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbSearchBreed.KeyDown
    e.SuppressKeyPress = True
  End Sub
End Class

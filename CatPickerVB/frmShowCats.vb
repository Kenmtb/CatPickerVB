
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

  Dim changesFromDataLoading As Boolean = True
  Dim lastRowBoxSelected As Integer = -1 'Preserve the last row's selected box check state
  Dim lastRowSelected As Integer = -1 'Preserve the las row selected


  Public Sub New()
    ' This call is required by the designer.
    InitializeComponent()
    frm = New Form1()
    pnlSearch.Visible = False
    pnlNewCat.Visible = False
    pnlEdit.Visible = True
    pnlMain.BackColor = Color.FromArgb(100, 44, 44, 44)

    grpMenu.Controls.Find("radEdit", True)(0).Select()
    Messages.statusMsg = ""


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
      If IsNothing(vm) Or Messages.statusMsg.Contains("Error") Then GoTo endd

      changesFromDataLoading = True
      Me.vm = bll.getAll(parmList)
      catList = vm.catList

      bs = New BindingSource()
      bs.DataSource = catList
      dgvShowCats.DataSource = catList
      changesFromDataLoading = False

      'Move to resource file
      Dim img As Image

      dgvShowCats.RowTemplate.Height = 40 '80
      dgvShowCats.CellBorderStyle = DataGridViewCellBorderStyle.None

      'Default cell format
      For Each col As DataGridViewColumn In dgvShowCats.Columns
        'col.SortMode = DataGridViewColumnSortMode.NotSortable
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        col.DefaultCellStyle.Padding = New Padding(5, 10, 0, 0)
        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
      Next

      'Custom cell format
      dgvShowCats.Columns("selected").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

      'Format image column
      Dim imageCol As DataGridViewImageColumn = dgvShowCats.Columns("image")
      imageCol.Width = 150
      imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom

      'dgvShowCats.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

      Label12.TabStop = False

      dgvShowCats.Columns("Image").DisplayIndex = 0
      dgvShowCats.Columns("image").HeaderText = "Picture"
      dgvShowCats.Columns("name").HeaderText = "Name"
      dgvShowCats.Columns("age").HeaderText = "Age"
      dgvShowCats.Columns("gender").HeaderText = "Gender"
      dgvShowCats.Columns("breedName").HeaderText = "Breed"
      'dgvShowCats.Columns("mainColor").HeaderText = "Main Color"
      'dgvShowCats.Columns("secondColor").HeaderText = "Second Color"
      'dgvShowCats.Columns("thirdColor").HeaderText = "Third Color"
      dgvShowCats.Columns("arrivalDate").HeaderText = "Arrival Date"
      dgvShowCats.Columns("selected").HeaderText = "Selected"
      dgvShowCats.RowHeadersVisible = False

      'disable columns
      dgvShowCats.Columns("age").ReadOnly = True


      'bind editor controls to data grid  *move to sep. sub      
      clearControlBinding()

      'editor bindings
      'Note the binding mode is 2 which makes the control read only. This prevents the control from 
      'writing to the binding source which would immediately update the datagridview with out executing a
      'save. At the same time read only allows the control to be updated when moving through dgv records.
      txtName.DataBindings.Add(New System.Windows.Forms.Binding("Text", bs.DataSource, "name", True, 2))
      txtAge.DataBindings.Add(New System.Windows.Forms.Binding("Text", bs.DataSource, "age", True, 2))
      cmbGender.DataBindings.Add(New System.Windows.Forms.Binding("Text", bs.DataSource, "gender", True, 2))
      tdpEditArrivalDate.DataBindings.Add(New System.Windows.Forms.Binding("Text", bs.DataSource, "arrivalDate", True, 2))
      txtCatPicName.DataBindings.Add(New System.Windows.Forms.Binding("Text", bs.DataSource, "pic", True, 2))

      'hide
      dgvShowCats.Columns("Id").Visible = False
      dgvShowCats.Columns("breedId").Visible = False
      dgvShowCats.Columns("detailsId").Visible = False
      dgvShowCats.Columns("pic").Visible = False
      dgvShowCats.Columns("mainColor").Visible = False
      dgvShowCats.Columns("secondColor").Visible = False
      dgvShowCats.Columns("thirdColor").Visible = False
      'dgvShowCats.Columns("selected").Visible = False

      'ADD images to columns
      For Each row As DataGridViewRow In dgvShowCats.Rows

        'dirImg = imageDir + row.Cells("pic").Value.ToString()

        'get the stored image
        Try
          img = Image.FromFile(imageDir + row.Cells("pic").Value.ToString())
          'update the image control

        Catch e As Exception
          img = Image.FromFile(imageDir + "noImage.jpg")
        End Try
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
  Private Sub clearControlBinding()
    txtName.DataBindings.Clear()
    txtAge.DataBindings.Clear()
    cmbGender.DataBindings.Clear()
    tdpEditArrivalDate.DataBindings.Clear()
    txtCatPicName.DataBindings.Clear()
  End Sub

  Private Function getImageFromStringPathName(imagePathName As String) As Image
    Return Image.FromFile(imagePathName)
  End Function

  Private Sub catDetails(img As Image, name As String)
    picCatPic.Image = img
    txtCatPicName.Text = name
  End Sub

  Private Sub dgvShowCats_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvShowCats.RowEnter

    validateEditor()

    If e.RowIndex > -1 Then
      recIndex = e.RowIndex
      Dim cells As DataGridViewCellCollection = dgvShowCats.Rows(recIndex).Cells

      '  'catDetails(Image.FromFile(imageDir + dgvShowCats.Rows(row).Cells("pic").Value), dgvShowCats.Rows(row).Cells("name").Value)
      '  'Not sure why this is a composite object, my try breaking into a pic box and text box
      'catDetails(Image.FromFile(imageDir + cells("pic").Value), cells("pic").Value)
      Try
        picCatPic.Image = Image.FromFile(imageDir + cells("pic").Value)
      Catch ex As Exception
        'if there is no image in the dirctory that matches the image in the dgv then insert a no image jpg.
        picCatPic.Image = Image.FromFile(imageDir + "noImage.jpg")
        cells("pic").Value = "noImage.jpg"
      End Try


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

    ErrorProvider1.SetError(txtName, "Maximum of 20 characters")


    'If Not frm.Visible Then
    '  'frm = New Form1()
    '  frm.Show()
    'End If

    'frm.Show()
    'frm.TextBox1.Text = txtCatPicName.Text
    'txtCatPicName.Text = frm.sayHi() + " " + txtCatPicName.Text
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

  Private Sub picCatPic_Click(sender As Object, e As EventArgs) Handles picCatPic.Click, picNewCatPic.Click

    'dlgPictures.ShowDialog()
    'txtCatPicName.Text = System.IO.Path.GetFileName(dlgPictures.FileName)
    'txtCatPicName.DataBindings("Text").WriteValue() ' required to programatically update controls because ms is to stupid to make it simple
    'picCatPic.Image = Image.FromFile(dlgPictures.FileName)

    Dim picFile As String = getCatPicFile()
    If picFile = "" Then GoTo abort
    picCatPic.Image = Image.FromFile(imageDir + picFile)
    txtCatPicName.Text = picFile
    txtCatPicName.DataBindings("Text").WriteValue() 'the control is bound so if it changes programatically then update the binding

    bs.EndEdit()



abort:

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
    If Not validateSearchEditor() Then GoTo abort

    Messages.statusMsg = "Searching"
    txtStatus.Text = Messages.statusMsg

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
    If IsNothing(vm) Then GoTo abort

    Messages.statusMsg = "Record count: " + vm.catList.Count.ToString

    initForm(vm)

abort:

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
    If Not validateNewCatEditor() Then GoTo abort

    Messages.statusMsg = "Adding new record ..."
    txtStatus.Text = Messages.statusMsg

    Dim rec As New Cat
    rec.name = txtNewCatName.Text
    rec.age = txtNewCatAge.Text
    rec.gender = cmbNewCatGender.Text
    rec.breedId = cmbNewCatBreed.SelectedValue
    'rec.breedName = txtn
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
    If Messages.statusMsg.Contains("Error") Then GoTo abort

    dgvShowCats.DataSource = Nothing
    vm = bll.getAll()
    If IsNothing(vm) Then GoTo abort

    If Not IsNothing(vm) Then Messages.statusMsg = "New record created, Record count: " + vm.catList.Count.ToString

    initForm(vm)
abort:

    txtStatus.Text = Messages.statusMsg

  End Sub

  Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    Dim response As String
    rec = catList(recIndex)

    response = MsgBox("Delete Y/N?", vbYesNo)
    If response = vbYes Then
      Messages.statusMsg = "Deleting record ..."
      txtStatus.Text = Messages.statusMsg
      bll.delete(rec.Id)
      If Messages.statusMsg.Contains("Error") Then GoTo abort

      dgvShowCats.DataSource = Nothing
      vm = bll.getAll()
      If IsNothing(vm) Then GoTo abort

      If Not IsNothing(vm) Then Messages.statusMsg = "Delete successful, Record count: " + vm.catList.Count.ToString


    End If

    initForm(vm)

abort:

    txtStatus.Text = Messages.statusMsg

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
    If Not validateEditor() Then GoTo abort

    Messages.statusMsg = "Saving record ..."
    txtStatus.Text = Messages.statusMsg

    rec = catList(recIndex)

    'pack control data into data object. 
    rec.breedId = cmbBreed.SelectedItem.Id
    rec.breedName = cmbBreed.Text
    rec.age = txtAge.Text
    rec.name = txtName.Text
    rec.gender = cmbGender.SelectedItem.ToString
    rec.arrivalDate = tdpEditArrivalDate.Value
    rec.pic = txtCatPicName.Text

    bll.save(rec)
    If Messages.statusMsg.Contains("Error") Then GoTo abort

    dgvShowCats.DataSource = Nothing
    vm = bll.getAll(parmList)
    If IsNothing(vm) Then GoTo abort

    Messages.statusMsg = "Save successful, Record count: " + vm.catList.Count.ToString

    initForm(vm)

abort:
    txtStatus.Text = Messages.statusMsg

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



  Private Sub btnSelectNewCatPic_Click(sender As Object, e As EventArgs)
    Dim picFile As String = getCatPicFile()
    picNewCatPic.Image = Image.FromFile(imageDir + picFile)
    txtNewCatPicName.Text = picFile
  End Sub

  Private Sub btnSelectCatPic_Click(sender As Object, e As EventArgs)
    Dim picFile As String = getCatPicFile()
    If picFile = "" Then GoTo abort
    picCatPic.Image = Image.FromFile(imageDir + picFile)
    txtCatPicName.Text = picFile
    txtCatPicName.DataBindings("Text").WriteValue() 'the control is bound so if it changes programatically then update the binding
abort:
  End Sub

  Private Function validateEditor() As Boolean
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

    ElseIf (Not IsNumeric(txtAge.Text.Trim)) OrElse (Convert.ToInt32(txtAge.Text) > 99 Or Convert.ToInt32(txtAge.Text) < 1) Then
      ErrorProvider1.SetError(txtAge, "Please enter number (1-99)")
      valid = False
      txtAge.Focus()
    End If

    Return valid

  End Function

  Private Function validateNewCatEditor() As Boolean
    Dim valid As Boolean = True

    ErrorProvider1.Clear()

    If String.IsNullOrEmpty(txtNewCatName.Text.Trim) Then
      ErrorProvider1.SetError(txtNewCatName, "Please enter a value")
      valid = False
      txtNewCatName.Focus()

    ElseIf txtNewCatName.Text.Length > 20 Then
      ErrorProvider1.SetError(txtNewCatName, "Maximum of 20 characters")
      valid = False
      txtNewCatName.Focus()

    ElseIf String.IsNullOrEmpty(txtNewCatAge.Text.Trim) Then
      ErrorProvider1.SetError(txtNewCatAge, "Please enter a value")
      valid = False
      txtNewCatAge.Focus()

    ElseIf (Not IsNumeric(txtNewCatAge.Text.Trim)) OrElse (Convert.ToInt32(txtNewCatAge.Text) > 99 Or Convert.ToInt32(txtNewCatAge.Text) < 1) Then
      ErrorProvider1.SetError(txtNewCatAge, "Please enter number (1-99)")
      valid = False
      txtNewCatAge.Focus()
    End If

    Return valid

  End Function

  Private Function validateSearchEditor() As Boolean
    Dim valid As Boolean = True

    ErrorProvider1.Clear()

    If (txtSearchAge.Text.Length > 0) AndAlso ((Not IsNumeric(txtSearchAge.Text.Trim)) OrElse (Convert.ToInt32(txtSearchAge.Text) > 99 Or Convert.ToInt32(txtSearchAge.Text) < 1)) Then
      ErrorProvider1.SetError(txtSearchAge, "Please enter number (1-99)")
      valid = False
      txtSearchAge.Focus()
    End If

    Return valid

  End Function

  Private Sub txtAge_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)

  End Sub

  Private Sub cmbSearchGender_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbSearchGender.KeyDown
    e.SuppressKeyPress = True
  End Sub

  Private Sub cmbSearchBreed_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbSearchBreed.KeyDown
    e.SuppressKeyPress = True
  End Sub

  Private Sub dgvShowCats_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvShowCats.RowLeave

    'Initialize the DGV row
    ErrorProvider1.Clear()

    validateEditor()
  End Sub

  Private Sub dgvShowCats_SelectionChanged(sender As Object, e As EventArgs) Handles dgvShowCats.SelectionChanged
    'Initialize the DGV row
    ErrorProvider1.Clear()
    validateEditor()
  End Sub

  Private Sub txtAge_Enter(sender As Object, e As EventArgs) Handles txtAge.Enter
    'txtAge.DataBindings.Clear()
    'txtAge.DataBindings.Add(New System.Windows.Forms.Binding("Text", bs.DataSource, "age", True))
  End Sub

  Private Sub dgvShowCats_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)


  End Sub

  Private Sub dgvShowCats_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)

  End Sub

  Private Sub txtAge_Leave(sender As Object, e As EventArgs) Handles txtAge.Leave
    'txtAge.DataBindings.Add(New System.Windows.Forms.Binding("Text", bs.DataSource, "age", True))
  End Sub

  Private Sub dgvShowCats_Leave(sender As Object, e As EventArgs) Handles dgvShowCats.Leave
    'txtAge.DataBindings.Clear()
  End Sub

  Private Sub dgvShowCats_Enter(sender As Object, e As EventArgs) Handles dgvShowCats.Enter
    'txtAge.DataBindings.Clear()
    'txtAge.DataBindings.Add(New System.Windows.Forms.Binding("Text", bs.DataSource, "age", True, 2))
    'txtAge.DataBindings.DefaultDataSourceUpdateMode = 2
  End Sub

  Private Sub txtAge_TextChanged(sender As Object, e As EventArgs) Handles txtAge.TextChanged

  End Sub

  Private Sub txtAge_Validating_1(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAge.Validating

  End Sub

End Class

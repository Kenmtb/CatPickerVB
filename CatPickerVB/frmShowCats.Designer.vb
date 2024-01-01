<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmShowCats
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.dgvShowCats = New System.Windows.Forms.DataGridView()
        Me.picCatPic = New System.Windows.Forms.PictureBox()
        Me.txtCatPicName = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnShowSelected = New System.Windows.Forms.Button()
        Me.btnShowEditor = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtArrivalDate = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.dlgPictures = New System.Windows.Forms.OpenFileDialog()
        Me.pnlEdit = New System.Windows.Forms.Panel()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbBreed = New System.Windows.Forms.ComboBox()
        Me.cmbGender = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.txtSearchAge = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbSearchBreed = New System.Windows.Forms.ComboBox()
        Me.cmbSearchGender = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.radEdit = New System.Windows.Forms.RadioButton()
        Me.grpMenu = New System.Windows.Forms.GroupBox()
        Me.radSearch = New System.Windows.Forms.RadioButton()
        Me.CatBreedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnClearSearch = New System.Windows.Forms.Button()
        Me.btnNewCat = New System.Windows.Forms.Button()
        Me.pnlNewCat = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbNewCatGender = New System.Windows.Forms.ComboBox()
        Me.picNewCatPic = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtNewCatAge = New System.Windows.Forms.TextBox()
        Me.txtNewCatName = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNewCatDate = New System.Windows.Forms.TextBox()
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtNewCatPicName = New System.Windows.Forms.TextBox()
        Me.btnSelectNewCatPic = New System.Windows.Forms.Button()
        Me.radNew = New System.Windows.Forms.RadioButton()
        Me.cmbNewCatBreed = New System.Windows.Forms.ComboBox()
        Me.btnSelectCatPic = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label19 = New System.Windows.Forms.Label()
        CType(Me.dgvShowCats, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCatPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEdit.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.grpMenu.SuspendLayout()
        CType(Me.CatBreedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNewCat.SuspendLayout()
        CType(Me.picNewCatPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvShowCats
        '
        Me.dgvShowCats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShowCats.Location = New System.Drawing.Point(12, 12)
        Me.dgvShowCats.Name = "dgvShowCats"
        Me.dgvShowCats.ReadOnly = True
        Me.dgvShowCats.Size = New System.Drawing.Size(1347, 413)
        Me.dgvShowCats.TabIndex = 0
        Me.dgvShowCats.VirtualMode = True
        '
        'picCatPic
        '
        Me.picCatPic.Location = New System.Drawing.Point(17, 36)
        Me.picCatPic.Name = "picCatPic"
        Me.picCatPic.Size = New System.Drawing.Size(237, 222)
        Me.picCatPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCatPic.TabIndex = 1
        Me.picCatPic.TabStop = False
        '
        'txtCatPicName
        '
        Me.txtCatPicName.Location = New System.Drawing.Point(17, 264)
        Me.txtCatPicName.Name = "txtCatPicName"
        Me.txtCatPicName.ReadOnly = True
        Me.txtCatPicName.Size = New System.Drawing.Size(237, 20)
        Me.txtCatPicName.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1291, 788)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 39)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'btnShowSelected
        '
        Me.btnShowSelected.Location = New System.Drawing.Point(1291, 740)
        Me.btnShowSelected.Name = "btnShowSelected"
        Me.btnShowSelected.Size = New System.Drawing.Size(88, 40)
        Me.btnShowSelected.TabIndex = 4
        Me.btnShowSelected.Text = "Selected Cats"
        Me.btnShowSelected.UseVisualStyleBackColor = True
        Me.btnShowSelected.Visible = False
        '
        'btnShowEditor
        '
        Me.btnShowEditor.Enabled = False
        Me.btnShowEditor.Location = New System.Drawing.Point(1291, 758)
        Me.btnShowEditor.Name = "btnShowEditor"
        Me.btnShowEditor.Size = New System.Drawing.Size(88, 40)
        Me.btnShowEditor.TabIndex = 5
        Me.btnShowEditor.Text = "Edit Cat"
        Me.btnShowEditor.UseVisualStyleBackColor = True
        Me.btnShowEditor.Visible = False
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(333, 36)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(141, 20)
        Me.txtName.TabIndex = 6
        '
        'txtAge
        '
        Me.txtAge.CausesValidation = False
        Me.txtAge.Location = New System.Drawing.Point(333, 62)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Size = New System.Drawing.Size(40, 20)
        Me.txtAge.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(260, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(260, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Age"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(260, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Gender"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(260, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Arrival Date"
        '
        'txtArrivalDate
        '
        Me.txtArrivalDate.Location = New System.Drawing.Point(333, 147)
        Me.txtArrivalDate.Name = "txtArrivalDate"
        Me.txtArrivalDate.Size = New System.Drawing.Size(76, 20)
        Me.txtArrivalDate.TabIndex = 12
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(292, 245)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(70, 27)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'dlgPictures
        '
        Me.dlgPictures.FileName = "OpenFileDialog1"
        '
        'pnlEdit
        '
        Me.pnlEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEdit.Controls.Add(Me.Label19)
        Me.pnlEdit.Controls.Add(Me.btnSelectCatPic)
        Me.pnlEdit.Controls.Add(Me.btnDelete)
        Me.pnlEdit.Controls.Add(Me.Label10)
        Me.pnlEdit.Controls.Add(Me.cmbBreed)
        Me.pnlEdit.Controls.Add(Me.cmbGender)
        Me.pnlEdit.Controls.Add(Me.Label5)
        Me.pnlEdit.Controls.Add(Me.picCatPic)
        Me.pnlEdit.Controls.Add(Me.btnSave)
        Me.pnlEdit.Controls.Add(Me.Label1)
        Me.pnlEdit.Controls.Add(Me.txtAge)
        Me.pnlEdit.Controls.Add(Me.txtCatPicName)
        Me.pnlEdit.Controls.Add(Me.txtName)
        Me.pnlEdit.Controls.Add(Me.Label4)
        Me.pnlEdit.Controls.Add(Me.Label2)
        Me.pnlEdit.Controls.Add(Me.Label3)
        Me.pnlEdit.Controls.Add(Me.txtArrivalDate)
        Me.pnlEdit.Location = New System.Drawing.Point(178, 474)
        Me.pnlEdit.Name = "pnlEdit"
        Me.pnlEdit.Size = New System.Drawing.Size(493, 291)
        Me.pnlEdit.TabIndex = 15
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(333, 229)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(70, 27)
        Me.btnInsert.TabIndex = 26
        Me.btnInsert.Text = "Save New"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(368, 245)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(66, 26)
        Me.btnDelete.TabIndex = 26
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(260, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Breed"
        '
        'cmbBreed
        '
        Me.cmbBreed.AllowDrop = True
        Me.cmbBreed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBreed.FormattingEnabled = True
        Me.cmbBreed.Location = New System.Drawing.Point(333, 91)
        Me.cmbBreed.Name = "cmbBreed"
        Me.cmbBreed.Size = New System.Drawing.Size(141, 21)
        Me.cmbBreed.TabIndex = 17
        '
        'cmbGender
        '
        Me.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGender.FormattingEnabled = True
        Me.cmbGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.cmbGender.Location = New System.Drawing.Point(333, 120)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(76, 21)
        Me.cmbGender.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(156, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 20)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Editor"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(237, 782)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(434, 20)
        Me.txtStatus.TabIndex = 25
        '
        'pnlSearch
        '
        Me.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSearch.Controls.Add(Me.btnClearSearch)
        Me.pnlSearch.Controls.Add(Me.txtSearchAge)
        Me.pnlSearch.Controls.Add(Me.btnSearch)
        Me.pnlSearch.Controls.Add(Me.Label9)
        Me.pnlSearch.Controls.Add(Me.Label8)
        Me.pnlSearch.Controls.Add(Me.Label7)
        Me.pnlSearch.Controls.Add(Me.cmbSearchBreed)
        Me.pnlSearch.Controls.Add(Me.cmbSearchGender)
        Me.pnlSearch.Controls.Add(Me.Label6)
        Me.pnlSearch.Location = New System.Drawing.Point(482, 81)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(493, 291)
        Me.pnlSearch.TabIndex = 16
        '
        'txtSearchAge
        '
        Me.txtSearchAge.Location = New System.Drawing.Point(216, 153)
        Me.txtSearchAge.Name = "txtSearchAge"
        Me.txtSearchAge.Size = New System.Drawing.Size(32, 20)
        Me.txtSearchAge.TabIndex = 24
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(167, 199)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 23
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(134, 160)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Age"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(134, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Breed"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(134, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Gender"
        '
        'cmbSearchBreed
        '
        Me.cmbSearchBreed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchBreed.FormattingEnabled = True
        Me.cmbSearchBreed.Location = New System.Drawing.Point(216, 126)
        Me.cmbSearchBreed.Name = "cmbSearchBreed"
        Me.cmbSearchBreed.Size = New System.Drawing.Size(121, 21)
        Me.cmbSearchBreed.TabIndex = 18
        '
        'cmbSearchGender
        '
        Me.cmbSearchGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchGender.FormattingEnabled = True
        Me.cmbSearchGender.Location = New System.Drawing.Point(216, 99)
        Me.cmbSearchGender.Name = "cmbSearchGender"
        Me.cmbSearchGender.Size = New System.Drawing.Size(121, 21)
        Me.cmbSearchGender.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(212, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 20)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Search"
        '
        'radEdit
        '
        Me.radEdit.AutoSize = True
        Me.radEdit.Location = New System.Drawing.Point(7, 45)
        Me.radEdit.Name = "radEdit"
        Me.radEdit.Size = New System.Drawing.Size(43, 17)
        Me.radEdit.TabIndex = 17
        Me.radEdit.TabStop = True
        Me.radEdit.Text = "Edit"
        Me.radEdit.UseVisualStyleBackColor = True
        '
        'grpMenu
        '
        Me.grpMenu.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.grpMenu.Controls.Add(Me.radNew)
        Me.grpMenu.Controls.Add(Me.radSearch)
        Me.grpMenu.Controls.Add(Me.radEdit)
        Me.grpMenu.Location = New System.Drawing.Point(52, 577)
        Me.grpMenu.Name = "grpMenu"
        Me.grpMenu.Size = New System.Drawing.Size(109, 98)
        Me.grpMenu.TabIndex = 18
        Me.grpMenu.TabStop = False
        '
        'radSearch
        '
        Me.radSearch.AutoSize = True
        Me.radSearch.Location = New System.Drawing.Point(7, 71)
        Me.radSearch.Name = "radSearch"
        Me.radSearch.Size = New System.Drawing.Size(59, 17)
        Me.radSearch.TabIndex = 18
        Me.radSearch.TabStop = True
        Me.radSearch.Text = "Search"
        Me.radSearch.UseVisualStyleBackColor = True
        '
        'CatBreedBindingSource
        '
        Me.CatBreedBindingSource.DataSource = GetType(Models.CatBreed)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(969, 432)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(390, 53)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "To read Cat data from api:  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Run C:\Users\Ken\source\repos\EmployeesAPI\Employee" &
    "sAPI\EmployeesAPI. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Change repository data source in CatBLL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(178, 785)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Status: "
        '
        'btnClearSearch
        '
        Me.btnClearSearch.Location = New System.Drawing.Point(248, 199)
        Me.btnClearSearch.Name = "btnClearSearch"
        Me.btnClearSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnClearSearch.TabIndex = 25
        Me.btnClearSearch.Text = "Clear"
        Me.btnClearSearch.UseVisualStyleBackColor = True
        '
        'btnNewCat
        '
        Me.btnNewCat.Location = New System.Drawing.Point(1311, 721)
        Me.btnNewCat.Name = "btnNewCat"
        Me.btnNewCat.Size = New System.Drawing.Size(63, 26)
        Me.btnNewCat.TabIndex = 27
        Me.btnNewCat.Text = "New Cat"
        Me.btnNewCat.UseVisualStyleBackColor = True
        '
        'pnlNewCat
        '
        Me.pnlNewCat.Controls.Add(Me.btnSelectNewCatPic)
        Me.pnlNewCat.Controls.Add(Me.txtNewCatPicName)
        Me.pnlNewCat.Controls.Add(Me.Label14)
        Me.pnlNewCat.Controls.Add(Me.btnInsert)
        Me.pnlNewCat.Controls.Add(Me.cmbNewCatBreed)
        Me.pnlNewCat.Controls.Add(Me.cmbNewCatGender)
        Me.pnlNewCat.Controls.Add(Me.picNewCatPic)
        Me.pnlNewCat.Controls.Add(Me.Label15)
        Me.pnlNewCat.Controls.Add(Me.txtNewCatAge)
        Me.pnlNewCat.Controls.Add(Me.txtNewCatName)
        Me.pnlNewCat.Controls.Add(Me.Label16)
        Me.pnlNewCat.Controls.Add(Me.Label17)
        Me.pnlNewCat.Controls.Add(Me.Label18)
        Me.pnlNewCat.Controls.Add(Me.txtNewCatDate)
        Me.pnlNewCat.Controls.Add(Me.Label13)
        Me.pnlNewCat.Location = New System.Drawing.Point(792, 511)
        Me.pnlNewCat.Name = "pnlNewCat"
        Me.pnlNewCat.Size = New System.Drawing.Size(493, 291)
        Me.pnlNewCat.TabIndex = 27
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(217, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 20)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "New Cat"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(260, 101)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Breed"
        '
        'cmbNewCatGender
        '
        Me.cmbNewCatGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNewCatGender.FormattingEnabled = True
        Me.cmbNewCatGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.cmbNewCatGender.Location = New System.Drawing.Point(333, 127)
        Me.cmbNewCatGender.Name = "cmbNewCatGender"
        Me.cmbNewCatGender.Size = New System.Drawing.Size(76, 21)
        Me.cmbNewCatGender.TabIndex = 27
        '
        'picNewCatPic
        '
        Me.picNewCatPic.Location = New System.Drawing.Point(17, 37)
        Me.picNewCatPic.Name = "picNewCatPic"
        Me.picNewCatPic.Size = New System.Drawing.Size(237, 222)
        Me.picNewCatPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picNewCatPic.TabIndex = 19
        Me.picNewCatPic.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(260, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Name"
        '
        'txtNewCatAge
        '
        Me.txtNewCatAge.Location = New System.Drawing.Point(333, 69)
        Me.txtNewCatAge.Name = "txtNewCatAge"
        Me.txtNewCatAge.Size = New System.Drawing.Size(40, 20)
        Me.txtNewCatAge.TabIndex = 21
        '
        'txtNewCatName
        '
        Me.txtNewCatName.Location = New System.Drawing.Point(333, 43)
        Me.txtNewCatName.Name = "txtNewCatName"
        Me.txtNewCatName.Size = New System.Drawing.Size(141, 20)
        Me.txtNewCatName.TabIndex = 20
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(260, 157)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 13)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Arrival Date"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(260, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(26, 13)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Age"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(260, 130)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 13)
        Me.Label18.TabIndex = 24
        Me.Label18.Text = "Gender"
        '
        'txtNewCatDate
        '
        Me.txtNewCatDate.Location = New System.Drawing.Point(333, 154)
        Me.txtNewCatDate.Name = "txtNewCatDate"
        Me.txtNewCatDate.Size = New System.Drawing.Size(76, 20)
        Me.txtNewCatDate.TabIndex = 25
        '
        'txtNewCatPicName
        '
        Me.txtNewCatPicName.Location = New System.Drawing.Point(18, 267)
        Me.txtNewCatPicName.Name = "txtNewCatPicName"
        Me.txtNewCatPicName.ReadOnly = True
        Me.txtNewCatPicName.Size = New System.Drawing.Size(236, 20)
        Me.txtNewCatPicName.TabIndex = 30
        '
        'btnSelectNewCatPic
        '
        Me.btnSelectNewCatPic.Location = New System.Drawing.Point(333, 180)
        Me.btnSelectNewCatPic.Name = "btnSelectNewCatPic"
        Me.btnSelectNewCatPic.Size = New System.Drawing.Size(77, 26)
        Me.btnSelectNewCatPic.TabIndex = 31
        Me.btnSelectNewCatPic.Text = "Find Image"
        Me.btnSelectNewCatPic.UseVisualStyleBackColor = True
        '
        'radNew
        '
        Me.radNew.AutoSize = True
        Me.radNew.Location = New System.Drawing.Point(7, 20)
        Me.radNew.Name = "radNew"
        Me.radNew.Size = New System.Drawing.Size(69, 17)
        Me.radNew.TabIndex = 19
        Me.radNew.TabStop = True
        Me.radNew.Text = "Add New"
        Me.radNew.UseVisualStyleBackColor = True
        '
        'cmbNewCatBreed
        '
        Me.cmbNewCatBreed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNewCatBreed.FormattingEnabled = True
        Me.cmbNewCatBreed.Location = New System.Drawing.Point(333, 98)
        Me.cmbNewCatBreed.Name = "cmbNewCatBreed"
        Me.cmbNewCatBreed.Size = New System.Drawing.Size(141, 21)
        Me.cmbNewCatBreed.TabIndex = 28
        '
        'btnSelectCatPic
        '
        Me.btnSelectCatPic.Location = New System.Drawing.Point(333, 173)
        Me.btnSelectCatPic.Name = "btnSelectCatPic"
        Me.btnSelectCatPic.Size = New System.Drawing.Size(77, 26)
        Me.btnSelectCatPic.TabIndex = 32
        Me.btnSelectCatPic.Text = "Find Image"
        Me.btnSelectCatPic.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(213, 13)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(118, 20)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "(Has validation)"
        '
        'frmShowCats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1386, 839)
        Me.Controls.Add(Me.btnNewCat)
        Me.Controls.Add(Me.btnShowSelected)
        Me.Controls.Add(Me.pnlNewCat)
        Me.Controls.Add(Me.btnShowEditor)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.grpMenu)
        Me.Controls.Add(Me.pnlEdit)
        Me.Controls.Add(Me.dgvShowCats)
        Me.Name = "frmShowCats"
        Me.Text = "Form1"
        CType(Me.dgvShowCats, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCatPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEdit.ResumeLayout(False)
        Me.pnlEdit.PerformLayout()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.grpMenu.ResumeLayout(False)
        Me.grpMenu.PerformLayout()
        CType(Me.CatBreedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNewCat.ResumeLayout(False)
        Me.pnlNewCat.PerformLayout()
        CType(Me.picNewCatPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvShowCats As DataGridView
    Friend WithEvents picCatPic As PictureBox
    Friend WithEvents txtCatPicName As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnShowSelected As Button
    Friend WithEvents btnShowEditor As Button
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtAge As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtArrivalDate As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents dlgPictures As OpenFileDialog
    Friend WithEvents pnlEdit As Panel
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents radEdit As RadioButton
    Friend WithEvents grpMenu As GroupBox
    Friend WithEvents radSearch As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbSearchBreed As ComboBox
    Friend WithEvents cmbSearchGender As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbGender As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbBreed As ComboBox
    Friend WithEvents CatBreedBindingSource As BindingSource
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearchAge As TextBox
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnInsert As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents btnClearSearch As Button
    Friend WithEvents btnNewCat As Button
    Friend WithEvents pnlNewCat As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbNewCatGender As ComboBox
    Friend WithEvents picNewCatPic As PictureBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtNewCatAge As TextBox
    Friend WithEvents txtNewCatName As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtNewCatDate As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents openFileDialog1 As OpenFileDialog
    Friend WithEvents txtNewCatPicName As TextBox
    Friend WithEvents btnSelectNewCatPic As Button
    Friend WithEvents radNew As RadioButton
    Friend WithEvents cmbNewCatBreed As ComboBox
    Friend WithEvents btnSelectCatPic As Button
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Label19 As Label
End Class

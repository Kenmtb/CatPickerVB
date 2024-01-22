
Imports Controlers
Imports CatPickerVB
Imports Globals

Public Class frmSplash
  Dim controller As CatController
  Dim bll As New BLL.passwordBLL


  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()
    Me.WindowState = FormWindowState.Minimized

    ' Add any initialization after the InitializeComponent() call.

  End Sub




  Private Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    'controller = New CatController(New frmShowCats)
    controller = New CatController()
    controller.startForm()
    txtStatus.Text = Messages.statusMsg
  End Sub

  Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs)

  End Sub

  Private Sub picShowHidePassword_Click(sender As Object, e As EventArgs) Handles picShowHidePassword.Click
    txtPassword.UseSystemPasswordChar = Not txtPassword.UseSystemPasswordChar
  End Sub

  Private Sub btnPasswordSubmit_Click(sender As Object, e As EventArgs) Handles btnPasswordSubmit.Click
    Dim passwordList As New List(Of Models.CatPassword)
    passwordList = bll.getAll()

    If bll.validatePassword(txtUsername.Text, txtPassword.Text, passwordList) Then
      txtStatus.Text = "Logged In"
    Else
      txtStatus.Text = "Login Failed"
    End If



  End Sub
End Class

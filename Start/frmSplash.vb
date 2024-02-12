

Imports CatPickerVB
Imports Globals
Imports System.Configuration

Public Class frmSplash
  Dim controller As CatController
  Dim bll As New BLL.passwordBLL
  Dim loginRequired As String


  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    loginRequired = ConfigurationManager.AppSettings("LoginRequired")

  End Sub

  Private Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    If loginRequired = "false" Then
      'No login required to run main form
      'Attempt to run the main form
      controller = New CatController()
      controller.startForm()
      txtStatus.Text = Messages.statusMsg
      btnRetry.Visible = True
      pnlLogin.Visible = False

      'Check for errors after attempting to run main form
      If Not checkForEditorStartupErrors() Then
        'Main form OK, hide this form. In load event, the following code is required to hide this form.
        Me.WindowState = FormWindowState.Minimized
        Me.ShowInTaskbar = False
      End If

    Else
      'Login required to run main form
      btnRetry.Visible = False
    End If



  End Sub

  Private Function checkForEditorStartupErrors() As Boolean
    'Check main form to see if it reports any startup errors while attempting to run
    'and set this form's appearance if an error has occured

    Dim startupError As Boolean = False

    If txtStatus.Text.Contains("Error") Then
      'Start up form reported an error, change this form's appearance to indicate an error
      lblMain.Text = "OOPS!"
      Me.BackgroundImage = My.Resources.catPickerSplashAngry
      lblWarning.Visible = True
      Me.Visible = True
      controller.hideForm()
      startupError = True
      txtStatus.BackColor = Color.Salmon
    Else
      'No error or the startup form has not been run yet due to login being required

      'Reset this form to indicate no error
      Me.BackgroundImage = My.Resources.catPickerSplash
      lblWarning.Visible = False
      txtStatus.BackColor = SystemColors.Window
    End If

    Return startupError

  End Function

  Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs)

  End Sub

  Private Sub picShowHidePassword_Click(sender As Object, e As EventArgs) Handles picShowHidePassword.Click
    txtPassword.UseSystemPasswordChar = Not txtPassword.UseSystemPasswordChar
  End Sub

  Private Sub btnPasswordSubmit_Click(sender As Object, e As EventArgs) Handles btnPasswordSubmit.Click

    txtStatus.BackColor = SystemColors.Window

    Dim passwordList As New List(Of Models.CatPassword)
    passwordList = bll.getAll()

    If bll.validatePassword(txtUsername.Text, txtPassword.Text, passwordList) Then
      'Login succeeded
      txtStatus.Text = "Logged In"

      'Attempt to run the main form
      controller = New CatController()
      controller.startForm()
      txtStatus.Text = Messages.statusMsg

      'If main form is error free then hide this form
      If Not checkForEditorStartupErrors() Then Me.Hide()
    Else
      'login failed, reset this form's background
      Me.BackgroundImage = My.Resources.catPickerSplash
      lblWarning.Visible = False
      txtStatus.BackColor = Color.Salmon
      txtStatus.Text = "Login Failed"
    End If
  End Sub

  Private Sub btnRetry_Click(sender As Object, e As EventArgs) Handles btnRetry.Click
    'This button appears if login is not required. It gives the user a chance to retry loading the main form if an error occurs
    txtStatus.Text = "Ready"
    controller = New CatController()
    controller.startForm()
    txtStatus.Text = Messages.statusMsg

    'If the retry is successful then hide this form
    If Not checkForEditorStartupErrors() Then Me.Hide()

  End Sub
End Class

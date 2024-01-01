
Imports Controlers
Imports CatPickerVB
Imports Globals

Public Class frmSplash
  Dim controller As CatController

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

End Class

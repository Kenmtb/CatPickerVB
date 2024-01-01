Imports System.Windows.Forms
Imports Globals.Defs

Public NotInheritable Class Utilities
  Dim fd As OpenFileDialog = New OpenFileDialog()
  Dim strFileName As String

  Public Sub fileDialogBox()

    fd.Title = "Open File Dialog"
    fd.InitialDirectory = imageDir
    fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
    fd.FilterIndex = 2
    fd.RestoreDirectory = True

    If fd.ShowDialog() = DialogResult.OK Then
      strFileName = fd.FileName
    End If
  End Sub

  Public Shared Sub ClearFormBindings(frm As Form)
    'Clears all form controls binding for one container level drill down.
    Dim c As Control
    For Each c In frm.Controls
      c.DataBindings.Clear()
      If c.HasChildren Then
        For Each cc In c.Controls
          cc.DataBindings.Clear()
        Next cc
      End If
    Next c
  End Sub


  Public Shared Function NZ(value As String) As Integer
    If String.IsNullOrEmpty(value) Then value = "0"
    Return Convert.ToInt32(value)
  End Function

End Class
